---
title: 使用 C++ 管理投影片中的連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/cpp/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線
- 連接線角度
- 連接圖形
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "賦能 C++ 應用程式在 PowerPoint 投影片中繪製、連接與自動路由線條——全面掌控直線、彎角與曲線連接線。"
---
## **介紹**

PowerPoint 連接線是一條特殊的線，用於連接兩個圖形，且即使在投影片上移動或重新定位圖形時仍會保持附著於圖形。

連接線通常會連接到 *連接點*（綠點），這些點預設存在於所有圖形上。當游標靠近時，連接點會顯示。

*調整點*（橙點）僅存在於某些連接線上，可用於調整連接線的位置和形狀。

## **連接線類型**

在 PowerPoint 中，您可以使用直線、彎角（斜角）和曲線連接線。

Aspose.Slides 提供以下連接線：

| 連接線 | 圖像 | 調整點數量 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **使用連接線連接圖形**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 使用 `Shapes` 物件的 `AddAutoShape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.auto_shape) 新增至投影片。  
1. 使用 `Shapes` 物件的 `AddConnector` 方法，依據連接線類型新增連接線。  
1. 使用該連接線將圖形連接起來。  
1. 呼叫 `Reroute` 方法以套用最短的連接路徑。  
1. 儲存投影片。  

以下 C++ 程式碼示範如何在兩個圖形（橢圓形與矩形）之間加入一條連接線（彎曲連接線）：

```c++
// 文件目錄的路徑。
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 載入所需的簡報
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 存取第一張投影片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 存取特定投影片的圖形集合
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 新增橢圓形自動圖形
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 新增矩形自動圖形
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// 將連接線圖形新增至投影片的圖形集合
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// 使用連接線將圖形連接
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// 呼叫 reroute 以設定圖形之間的自動最短路徑
	connector->Reroute();
	
	// 儲存簡報
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
`connector->Reroute` 方法會重新路由連接線，並強制其在圖形之間走最短路徑。為達成此目的，該方法可能會變更 `StartShapeConnectionSiteIndex` 與 `EndShapeConnectionSiteIndex` 位置。 
{{% /alert %}} 

## **指定連接點**

若您希望連接線使用圖形上的特定點來連接兩個圖形，必須依下列方式指定您偏好的連接點：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 使用 `Shapes` 物件的 `AddAutoShape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.auto_shape) 新增至投影片。  
1. 使用 `Shapes` 物件的 `AddConnector` 方法，依據連接線類型新增連接線。  
1. 使用該連接線將圖形連接起來。  
1. 在圖形上設定您偏好的連接點。  
1. 儲存投影片。  

以下 C++ 程式碼示範指定偏好連接點的操作：

```c++
	// 文件目錄的路徑。
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 載入所需的簡報
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 取得第一張投影片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 取得特定投影片的圖形集合
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// 新增橢圓形自動圖形
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// 新增矩形自動圖形
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// 將連接線圖形新增至投影片的圖形集合
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// 使用連接線將圖形連接
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// 設定橢圓形圖形的偏好連接點索引
	int wantedIndex = 6;

	// 檢查偏好索引是否小於最大連接點數量
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// 設定橢圓形自動圖形的偏好連接點
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// 儲存簡報
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **調整連接線點**

您可以透過調整點來調整現有的連接線。只有具備調整點的連接線才可如此修改。請參考 **[連接線類型](/slides/zh-hant/cpp/connector/#types-of-connectors)** 表格。

### **簡單案例**

考慮一個案例：連接兩個圖形（A 與 B）的連接線穿過第三個圖形（C）：

![connector-obstruction](connector-obstruction.png)

程式碼：

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

為避免或繞過第三個圖形，我們可以透過將其垂直線向左移動來調整連接線：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **複雜案例**

若要執行更複雜的調整，必須考慮以下因素：

* 連接線的可調點與計算其位置的公式緊密相關。因此，點位置的變更可能會改變連接線的形狀。  
* 連接線的調整點在陣列中以嚴格順序定義，且依連接線的起點到終點依序編號。  
* 調整點的值反映連接線形狀寬度/高度的百分比。  
  * 形狀的範圍由連接線的起點與終點乘以 1000 所決定。  
  * 第一点、第二點與第三點分別代表寬度的百分比、高度的百分比以及再次寬度的百分比。  
* 在計算連接線調整點座標時，必須考慮連接線的旋轉與鏡射。**注意**，於 **[連接線類型](/slides/zh-hant/cpp/connector/#types-of-connectors)** 中顯示的所有連接線之旋轉角度皆為 0。

#### **案例 1**

考慮一個案例：兩個文字框物件透過連接線相互連接：

![connector-shape-complex](connector-shape-complex.png)

```c++
// 建立代表 PPTX 檔案的簡報類別實例
auto pres = System::MakeObject<Presentation>();
// 取得簡報中的第一張投影片
auto slide = pres->get_Slides()->idx_get(0);
// 從第一張投影片取得圖形
auto shapes = slide->get_Shapes();
// 新增將透過連接線結合的圖形
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// 新增連接線
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// 指定連接線的方向
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// 指定連接線的線條粗細
lineFormat->set_Width(3);
// 指定連接線的顏色
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// 使用連接線將圖形互相連結
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// 取得連接線的調整點
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**調整**

我們可透過將對應的寬度與高度百分比分別提升 20% 與 200%，來變更連接線的調整點值：

```c++
// 變更調整點的值
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

為了建立一個模型，讓我們能夠確定連接線各個部分的座標與形狀，請建立一個對應於 connector.Adjustments[0] 點之水平元件的圖形：

```c++
// 繪製連接線的垂直部份
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我們示範了使用基本原理的簡單連接線調整操作。在一般情況下，必須考慮連接線的旋轉與顯示方式（由 connector.Rotation、connector.Frame.FlipH 與 connector.Frame.FlipV 設定）。以下示範此過程。

首先，於投影片上新增一個文字框物件（**To 1**）作為連接用途，並建立一條新的（綠色）連接線，將其與先前建立的物件連接。

```c++
// 建立新的繫結物件
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// 建立新的連接線
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// 使用新建立的連接線連接物件
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// 取得連接線的調整點
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// 變更調整點的值
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

結果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，建立一個圖形對應於穿過新連接線之調整點 connector.Adjustments[0] 的水平元件。我們將使用 connector.Rotation、connector.Frame.FlipH 與 connector.Frame.FlipV 的值，並套用常用的繞點旋轉座標轉換公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，物件的旋轉角度為 90 度且連接線垂直顯示，因此以下為相對應的程式碼：

```c++

```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

我們示範了涵蓋簡單調整與帶有旋轉角度之複雜調整點的計算。透過所學，您可開發自己的模型（或撰寫程式碼）以取得 `GraphicsPath` 物件，或甚至根據特定投影片座標設定連接線的調整點值。

## **找出連接線的角度**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 取得連接線形狀。  
1. 使用線的寬度、高度、圖形框的高度與寬度計算角度。  

以下 C++ 程式碼示範計算連接線形狀角度的操作：

```c++
void ConnectorLineAngle()
{

	// 文件目錄的路徑。
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// 載入所需的簡報
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 取得第一張投影片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// 取得投影片的圖形集合
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

## **常見問題**

**如何判斷連接線是否能「黏貼」到特定圖形上？**

檢查該圖形是否提供 [connection sites](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/get_connectionsitecount/)。若無或計數為零，則無法黏貼；此時請使用自由端點並手動定位。在連接前檢查端點數量是明智的做法。

**若刪除其中一個已連接的圖形，連接線會發生什麼情況？**

其兩端會被分離；連接線會以普通線條的形式保留在投影片上，具自由的起點/終點。您可以選擇刪除它，或重新指派連接，必要時使用 [reroute](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/connector/reroute/)。

**在將投影片複製到另一個簡報時，連接線的綁定會被保留嗎？**

一般而言會保留，前提是目標圖形也一併被複製。若將投影片插入未包含連接圖形的檔案，則兩端會變為自由端點，需要重新連接。