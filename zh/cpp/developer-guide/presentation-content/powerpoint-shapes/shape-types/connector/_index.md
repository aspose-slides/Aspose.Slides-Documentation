---
title: 使用 C++ 在演示文稿中管理连接线
linktitle: 连接线
type: docs
weight: 10
url: /zh/cpp/connector/
keywords:
- 连接线
- 连接线类型
- 连接点
- 连接线
- 连接角度
- 连接形状
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "让 C++ 应用程序能够在 PowerPoint 幻灯片中绘制、连接和自动路由线条——全面控制直线、折线和曲线连接线。"
---

PowerPoint 连接线是一种特殊的线，连接或链接两个形状，并在形状移动或重新定位时保持附着在形状上。

连接线通常连接到*连接点*（绿色点），这些点默认存在于所有形状上。当光标靠近时会显示连接点。

*调整点*（橙色点）仅在某些连接线上存在，用于修改连接线的位置和形状。

## **连接线类型**

在 PowerPoint 中，您可以使用直线、折线（有角度）和曲线连接线。

Aspose.Slides 提供以下连接线：

| 连接线 | Image | 调整点数量 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **使用连接线连接形状**

1. 创建一个 [演示](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 使用 `Shapes` 对象的 `AddAutoShape` 方法向幻灯片添加两个 [自动形状](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape)。  
4. 通过 `Shapes` 对象的 `AddConnector` 方法并指定连接线类型来添加连接线。  
5. 使用该连接线连接形状。  
6. 调用 `Reroute` 方法以应用最短的连接路径。  
7. 保存演示文稿。  

下面的 C++ 代码演示了如何在两个形状（椭圆和矩形）之间添加一个弯曲连接线：
```c++
// 文档目录的路径。
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 加载所需的演示文稿
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 访问特定幻灯片的形状集合
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 添加椭圆自动形状
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 添加矩形自动形状
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// 向幻灯片形状集合添加连接线形状
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// 使用连接线连接形状
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// 调用 Reroute 方法以在形状之间设置自动最短路径
	connector->Reroute();
	
	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 

`connector->Reroute` 方法会重新路由连接线，并强制其在形状之间走最短路径。为实现此目的，方法可能会更改 `StartShapeConnectionSiteIndex` 和 `EndShapeConnectionSiteIndex` 点。 

{{% /alert %}} 

## **指定连接点**

如果希望连接线使用形状上的特定点进行链接，需要按如下方式指定首选连接点：

1. 创建一个 [演示](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 使用 `Shapes` 对象的 `AddAutoShape` 方法向幻灯片添加两个 [自动形状](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape)。  
4. 通过 `Shapes` 对象的 `AddConnector` 方法并指定连接线类型来添加连接线。  
5. 使用该连接线连接形状。  
6. 在形状上设置首选的连接点。  
7. 保存演示文稿。  

下面的 C++ 代码演示了指定首选连接点的操作：
```c++
	// 文档目录的路径。
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 加载所需的演示文稿
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 访问特定幻灯片的形状集合
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 添加椭圆自动形状
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 添加矩形自动形状
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// 向幻灯片的形状集合添加连接线形状
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// 使用连接线连接形状
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// 设置椭圆形状的首选连接点索引
	int wantedIndex = 6;

	// 检查首选索引是否小于最大站点索引计数
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// 在椭圆自动形状上设置首选连接点
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **调整连接点**

您可以通过调整点来修改现有连接线。只有带有调整点的连接线才能以此方式进行更改。请参见 **[连接线类型](/slides/zh/cpp/connector/#types-of-connectors)** 表格。

### **简单案例**

考虑一种情况：两形状（A 和 B）之间的连接线穿过第三个形状（C）：

![connector-obstruction](connector-obstruction.png)

代码：
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```


为避免或绕过第三个形状，我们可以将连接线的垂直线向左移动进行调整：

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```


### **复杂案例**

进行更复杂的调整时，需要考虑以下因素：

* 连接线的可调点与计算其位置的公式紧密相关。因此，更改点的位置可能会改变连接线的形状。  
* 连接线的调整点在数组中按严格顺序定义，编号从连接线的起点到终点。  
* 调整点的值反映连接线形状宽度/高度的百分比。  
  * 形状由连接线的起点和终点乘以 1000 所限定。  
  * 第一点、第二点和第三点分别表示宽度百分比、高度百分比和再次的宽度百分比。  
* 在计算连接线调整点坐标时，需要考虑连接线的旋转和镜像。**注意**，在 **[连接线类型](/slides/zh/cpp/connector/#types-of-connectors)** 中显示的所有连接线的旋转角度均为 0。

#### **案例 1**

考虑两个文本框对象通过连接线链接的情况：

![connector-shape-complex](connector-shape-complex.png)

代码：
```c++
// 实例化一个表示 PPTX 文件的演示文稿类
auto pres = System::MakeObject<Presentation>();
// 获取演示文稿中的第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);
// 从第一张幻灯片获取形状集合
auto shapes = slide->get_Shapes();
// 添加将通过连接线连接在一起的形状
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// 添加一个连接线
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// 指定连接线的方向
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// 指定连接线的线宽
lineFormat->set_Width(3);
// 指定连接线的颜色
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// 使用连接线将形状链接在一起
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// 获取连接线的调整点
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```


**调整**

我们可以将连接线的调整点值对应的宽度和高度百分比分别增加 20% 和 200%：

```c++
// 更改调整点的值
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```


结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了构建一个模型以确定连接线各部分的坐标和形状，我们创建一个对应于 connector.Adjustments[0] 点的水平分量的形状：

```c++
// 绘制连接线的垂直分量
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```


结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们演示了使用基本原理的简单连接线调整操作。实际情况下，需要考虑连接线的旋转以及其显示方式（由 connector.Rotation、connector.Frame.FlipH 和 connector.Frame.FlipV 设置）。下面演示整个过程。

首先，向幻灯片添加一个新的文本框对象（**To 1**）用于连接，并创建一个新的（绿色）连接线，将其连接到已创建的对象上。
```c++
// 创建新的绑定对象
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// 创建新的连接线
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// 使用新创建的连接线连接对象
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// 获取连接线的调整点
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// 更改调整点的值
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```


结果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，创建一个形状对应于通过新连接线的调整点 connector.Adjustments[0] 的水平分量。我们将使用 connector.Rotation、connector.Frame.FlipH 和 connector.Frame.FlipV 的值，并应用围绕给定点 x0 的坐标旋转公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，对象的旋转角度为 90 度，且连接线垂直显示，对应的代码如下：
```c++

```


结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和带旋转角度的复杂调整点的计算。利用这些知识，您可以构建自己的模型（或编写代码）以获取 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接线的调整点值。

## **获取连接线的角度**

1. 创建一个 [演示](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 访问连接线形状。  
4. 使用线的宽度、高度、形状框高度和形状框宽度计算角度。  

下面的 C++ 代码演示了计算连接线形状角度的操作：
```c++
void ConnectorLineAngle()
{

	// 文档目录的路径。
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 加载所需的演示文稿
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// 访问幻灯片的形状集合
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
				//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
				//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```


## **常见问题解答**

**如何判断连接线是否可以“粘贴”到特定形状上？**

检查形状是否公开了[连接站点](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_connectionsitecount/)。如果没有或计数为零，则不支持粘贴，此时请使用自由端点并手动定位。建议在附加之前检查站点计数。

**如果删除了已连接的形状之一，连接线会怎样？**

其两端会被分离；连接线将在幻灯片上保留为普通线条，拥有自由的起点/终点。您可以删除它，或重新分配连接并在需要时使用 [重新路由](https://reference.aspose.com/slides/cpp/aspose.slides/connector/reroute/)。

**复制幻灯片到另一演示文稿时，连接线的绑定会保留吗？**

通常会保留，前提是目标形状也被一并复制。如果将幻灯片插入到没有连接形状的文件中，连接线的两端会变为自由，需要重新附加。