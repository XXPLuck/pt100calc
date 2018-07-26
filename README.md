# pt100calc

本软件用来进行进行PT100的温度和电阻值相互转换。

转换使用公式进行计算。精度为两位小数。

计算公式

在0℃ - 850℃

R(t) = R(0℃)*(1+A*t+B*t^(2))

在-200℃ - 0℃

R(t) = R(0℃)*(1+A*t+B*t^(2)+C(t-100℃)*t^(3))

式子中：

R(t) : 在温度为t时铂热电阻的电阻值，Ω；

t    : 温度，℃；

A = 3.9083e-3,  ℃^(-1)；

B = -5.775e-7,  ℃^(-2)；

C = -4.183e-12, ℃^(-4)；

标准采用1990年国际温标（ITS-90）的温度值。

铂热电阻的允差为A、B两个等级

A      |		±(0.15+0.002|t|)

B      |		±(0.30+0.005|t|)

注：

	|t|为温度绝对值，℃。


