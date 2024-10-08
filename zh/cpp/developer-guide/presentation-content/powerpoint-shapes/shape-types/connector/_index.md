---
title: 连接器
type: docs
weight: 10
url: /cpp/connector/
keywords: "连接形状, 连接器, PowerPoint 形状, PowerPoint 演示文稿, C++, CPP, Aspose.Slides for C++"
description: "在 C++ 中连接 PowerPoint 形状"
---

PowerPoint 连接器是一种特殊的线条，用于连接或链接两个形状，即使在给定幻灯片上移动或重新定位时，它仍然保持与形状相连。

连接器通常连接到 *连接点*（绿色点），默认情况下存在于所有形状上。当光标靠近它们时，连接点会出现。

*调整点*（橙色点）仅存在于某些连接器上，用于修改连接器的位置和形状。

## **连接器的类型**

在 PowerPoint 中，您可以使用直线、肘部（角度）和曲线连接器。

Aspose.Slides 提供以下连接器：

| 连接器                          | 图像                                                         | 调整点数量 |
| ------------------------------ | ------------------------------------------------------------ | ---------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)     | 0          |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0          |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0          |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)   | 1          |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)   | 2          |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)   | 3          |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0          |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1          |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2          |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3          |

## **使用连接器连接形状**

1. 创建 `Presentation` 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象公开的 `AddAutoShape` 方法向幻灯片添加两个 `AutoShape`。
1. 通过定义连接器类型，使用 `Shapes` 对象公开的 `AddConnector` 方法添加连接器。
1. 使用连接器连接形状。
1. 调用 `Reroute` 方法以应用最短连接路径。
1. 保存演示文稿。

以下 C++ 代码演示了如何在两个形状（一个椭圆和一个矩形）之间添加一个连接器（一个弯曲连接器）：

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

	// 向幻灯片形状集合添加连接器形状
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// 使用连接器连接形状
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);

	// 调用 reroute，在形状之间设置自动最短路径
	connector->Reroute();

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="注意"  color="warning"   %}} 

`connector->Reroute` 方法重新路由连接器并强制其在形状之间采取最短的可能路径。为了实现其目的，该方法可能会更改 `StartShapeConnectionSiteIndex` 和 `EndShapeConnectionSiteIndex` 点。

{{% /alert %}} 

## **指定连接点**

如果您想通过形状上的特定点链接两个形状，则必须以以下方式指定您首选的连接点：

1. 创建 `Presentation` 类的实例。
1. 通过索引获取幻灯片的引用。
1. 使用 `Shapes` 对象公开的 `AddAutoShape` 方法向幻灯片添加两个 `AutoShape`。
1. 通过定义连接器类型，使用 `Shapes` 对象公开的 `AddConnector` 方法添加连接器。
1. 使用连接器连接形状。
1. 在形状上设置您首选的连接点。
1. 保存演示文稿。

以下 C++ 代码演示了一个指定首选连接点的操作：

```c++
// 文档目录的路径。
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 加载所需演示文稿
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 访问第一张幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 访问特定幻灯片的形状集合
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 添加椭圆自动形状
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 添加矩形自动形状
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// 向幻灯片的形状集合添加连接器形状
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// 使用连接器连接形状
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);

	// 设置椭圆形状的首选连接点索引
	int wantedIndex = 6;

	// 检查首选索引是否小于最大连接点索引数
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// 在椭圆自动形状上设置首选连接点
		connector->set_StartShapeConnectionSiteIndex(wantedIndex);
	}

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **调整连接器点**

您可以通过其调整点调整现有连接器。仅具有调整点的连接器可以以这种方式进行更改。请参阅 **[连接器的类型](/slides/cpp/connector/#types-of-connectors)** 下的表格。

#### **简单情况**

考虑一个连接器在两个形状（A 和 B）之间穿过第三个形状（C）的情况：

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

为了避免或绕过第三个形状，我们可以通过将其垂直线向左移动来调整连接器：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **复杂情况**

要执行更复杂的调整，您需要考虑以下因素：

* 连接器的可调整点与计算和确定其位置的公式紧密相关。因此，点位置的更改可能会改变连接器的形状。
* 连接器的调整点在数组中按严格顺序定义。调整点按从连接器的起始点到结束点编号。
* 调整点值反映连接器形状宽度/高度的百分比。
  * 该形状由连接器的起点和终点乘以 1000 限制。
  * 第一个点、第二个点和第三个点分别定义宽度、从高度和再次从宽度的百分比。
* 对于确定连接器调整点坐标的计算，您需要考虑连接器的旋转及其反射。**注意**，在 **[连接器的类型](/slides/cpp/connector/#types-of-connectors)** 下显示的所有连接器的旋转角度为 0。

#### **案例 1**

考虑一个连接两个文本框对象的连接器的情况：

![connector-shape-complex](connector-shape-complex.png)

代码：

```c++
// 实例化一个表示 PPTX 文件的演示文稿类
auto pres = System::MakeObject<Presentation>();
// 获取演示文稿中的第一张幻灯片
auto slide = pres->get_Slides()->idx_get(0);
// 获取第一张幻灯片的形状
auto shapes = slide->get_Shapes();
// 添加通过连接器连接在一起的形状
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"从");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"到");
// 添加连接器
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// 指定连接器的方向
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// 指定连接器线条的厚度
lineFormat->set_Width(3);
// 指定连接器的颜色
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// 使用连接器将形状连接在一起
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// 获取连接器的调整点
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**调整**

我们可以通过分别增加相应的宽度和高度百分比 20% 和 200% 来更改连接器的调整点值：

```c++
// 更改调整点的值
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

结果：

![connector-adjusted-1](connector-adjusted-1.png)

为了定义一个模型，使我们能够确定连接器部分的坐标和形状，让我们创建一个相应于连接器的连接器.Adjustments[0] 点的形状：

```c++
// 绘制连接器的垂直部分
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

结果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我们演示了使用基本原理进行简单连接器调整操作。在正常情况下，您需要考虑连接器的旋转及其显示（通过 connector.Rotation、connector.Frame.FlipH 和 connector.Frame.FlipV 设置）。现在我们将演示该过程。

首先，让我们在幻灯片中添加一个新的文本框对象（**到 1**，用于连接目的），并创建一个将其连接到我们已创建对象的新（绿色）连接器。

```c++
// 创建一个新的绑定对象
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"到 1");
// 创建一个新的连接器
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// 使用新创建的连接器连接对象
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// 获取连接器的调整点
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// 更改调整点的值
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

结果：

![connector-adjusted-3](connector-adjusted-3.png)

接下来，让我们创建一个与新连接器的调整点 connector.Adjustments[0] 相对应的形状。我们将利用连接器数据中的 connector.Rotation、connector.Frame.FlipH 和 connector.Frame.FlipV 的值，并应用流行的围绕给定点 x0 旋转的坐标转换公式：

X = (x — x0) * cos(α) — (y — y0) * sin(α) + x0;

Y = (x — x0) * sin(α) + (y — y0) * cos(α) + y0;

在我们的案例中，物体的旋转角度为 90 度，连接器垂直显示，因此这是相应的代码：

```c++
```

结果：

![connector-adjusted-4](connector-adjusted-4.png)

我们演示了涉及简单调整和复杂调整点（具有旋转角度的调整点）的计算。利用所获得的知识，您可以开发自己的模型（或编写代码）以获得 `GraphicsPath` 对象，甚至根据特定幻灯片坐标设置连接器的调整点值。

## **查找连接器线的角度**

1. 创建 `Presentation` 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问连接器线形状。
1. 使用线宽、高度、形状框高度和形状框宽度计算角度。

以下 C++ 代码演示了我们计算连接器线形状角度的操作：

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
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());
			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
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