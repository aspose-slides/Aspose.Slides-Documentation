---
title: 在 C++ 中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/cpp/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中掌握簡報主題，以建立、客製化並轉換具有一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義了設計元素的屬性。當您選取簡報主題時，實際上就是在選擇一組特定的視覺元素及其屬性。

在 PowerPoint 中，主題包括顏色、[字型](/slides/zh-hant/cpp/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/cpp/presentation-background/)以及效果。

![theme-constituents](theme-constituents.png)

## **變更主題顏色**

PowerPoint 主題會為投影片上的不同元素使用特定的一組顏色。若您不喜歡這些顏色，可以透過套用新顏色來變更主題的顏色。為了讓您選取新的主題顏色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) 列舉中提供了相應的值。

以下 C++ 程式碼示範如何變更主題的重點色彩：

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

您可以透過以下方式取得結果顏色的有效值：

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (顏色 [A=255, R=128, G=100, B=162])
```

為了進一步示範顏色變更的操作，我們建立另一個元素，並將（初始操作中）取得的重點顏色指派給它。接著在主題中變更顏色：

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

新顏色會自動套用到兩個元素上。

### **從額外調色盤設定主題顏色**

當您對主主題顏色 (1) 套用亮度變換時，會產生來自額外調色盤 (2) 的顏色。之後您可以設定與取得這些主題顏色。

![additional-palette-colors](additional-palette-colors.png)

**1**- 主主題顏色  
**2**- 來自額外調色盤的顏色。

以下 C++ 程式碼示範從主主題顏色取得額外調色盤顏色，並將其應用於圖形的操作：

```c++
// 強調色 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// 強調色 4，較亮 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// 強調色 4，較亮 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// 強調色 4，較亮 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// 強調色 4，較暗 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// 強調色 4，較暗 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **將 `SchemeColor` 對映至 `IColorScheme` 顏色**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/schemecolor/) 時，可能會注意到它包含以下主題顏色值：

`Background1`, `Background2`, `Text1`, and `Text2`.

然而，`Presentation::get_MasterTheme()::get_ColorScheme()` 會回傳 [IColorScheme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/icolorscheme/)，其提供相對應的顏色為：

`Dark1`, `Dark2`, `Light1`, and `Light2`.

此差異僅在於命名。這些值指向相同的主題顏色槽位，且對映是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`／`Background` 與 `Dark`／`Light` 之間沒有動態轉換，它們只是相同主題顏色的別名。

此命名差異來源於 Microsoft Office 的術語。舊版 Office 使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而較新版的使用者介面則將相同槽位顯示為 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **變更主題字型**

為了讓您為主題及其他用途選取字型，Aspose.Slides 使用以下特殊識別碼（類似於 PowerPoint 中使用的）：

* **+mn-lt** - 內文字型 Latin（次要 Latin 字型）
* **+mj-lt** - 標題字型 Latin（主要 Latin 字型）
* **+mn-ea** - 內文字型 東亞（次要 東亞 字型）
* **+mj-ea** - 正文字型 東亞（主要 東亞 字型）

以下 C++ 程式碼示範如何將 Latin 字型指派給主題元素：

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

以下 C++ 程式碼示範如何變更簡報主題的字型：

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

所有文字方塊的字型都會被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想參閱 [PowerPoint 字型](/slides/zh-hant/cpp/powerpoint-fonts/)。
{{% /alert %}}

## **變更主題背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預設背景，但在一般簡報中僅會儲存其中的 3 種背景。 

![todo:image_alt_text](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，可以執行以下 C++ 程式碼來查詢簡報中預設背景的數量：

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.theme.i_format_scheme/) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) 屬性，您可以在 PowerPoint 主題中新增或存取背景樣式。 
{{% /alert %}}

以下 C++ 程式碼示範如何為簡報設定背景：

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**索引說明**：0 代表無填色。索引從 1 開始。

{{% alert color="primary" title="TIP" %}} 
您可能想參閱 [PowerPoint 背景](/slides/zh-hant/cpp/presentation-background/)。
{{% /alert %}}

## **變更主題效果**

PowerPoint 主題通常為每個樣式陣列包含 3 個值。這些陣列結合後形成 3 種效果：細緻、適中與強烈。例如，將這些效果套用至特定圖形時的結果如下：

![todo:image_alt_text](presentation-design_10.png)

使用 [FormatScheme](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.theme.i_format_scheme/) 類別中的 3 個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563)、[LineStyles](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd)、[EffectStyles](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)），您可以變更主題中的元素（比 PowerPoint 的選項更具彈性）。

以下 C++ 程式碼示範如何透過調整元素部份來變更主題效果：

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

結果會在填色、填充類型、陰影效果等方面產生變化：

![todo:image_alt_text](presentation-design_11.png)

## **常見問題**

**我能在不更改母片的情況下，將主題套用到單一投影片嗎？**  
可以。Aspose.Slides 支援投影片層級的主題覆寫，您可以僅在該投影片套用本機主題，同時保持母片主題不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/slidethememanager/)）。

**將主題從一個簡報安全搬移至另一個簡報的最佳方式是什麼？**  
[Clone slides](/slides/zh-hant/cpp/clone-slides/) 與其母片一起複製到目標簡報。此做法會保留原始的母片、版面配置以及相關的主題，確保外觀保持一致。

**如何在所有繼承與覆寫之後查看「有效」值？**  
使用 API 的「[effective」檢視](/slides/zh-hant/cpp/shape-effective-properties/) 取得主題/顏色/字型/效果的實際值。這些檢視會在套用母片以及任何本機覆寫後回傳解析後的最終屬性。