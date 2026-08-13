---
title: 使用 C++ 在簡報中建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 簡報
- 3D 旋轉
- 3D 深度
- 3D 拉伸
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中套用與渲染 PowerPoint 圖形與文字的 3D 效果。設定相機、光照、材質、拉伸、填充與 3D 文字。"
---
## **概述**

Aspose.Slides for C++ 能夠建立、編輯、保留及呈現 PowerPoint 風格的 3D 格式化（適用於圖形與文字）。本文介紹旋轉、拉伸、斜角、光照、材質、漸層或圖片填充以及 3D 文字等 3D 效果。

{{% alert color="info" %}}
本文說明的是 PowerPoint 圖形與文字的 3D 格式化效果。它不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果呈現在匯出的 2D 輸出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 介面的 [get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_threedformat/) 方法可對圖形套用 3D 格式化。此方法會回傳 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/)，用來控制該圖形的 3D 場景。

對於文字，使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/) 介面的 [get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/get_threedformat/) 方法。這會將 3D 格式化套用到文字框，而非圖形本體。

最重要的方法如下：

| 方法 | 它控制什麼 | 何時使用 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_camera/) | 視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或符合 PowerPoint 的 3D 旋轉預設。 |
| [get_LightRig](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_lightrig/) | 光源預設、方向與光線旋轉。 | 變更 3D 表面的高光與陰影顯示方式。 |
| [set_Material](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_material/) | 表面材質，例如平面、霧面、塑膠或金屬。 | 讓相同的幾何形狀呈現更平坦、柔和、光亮或金屬感。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 形狀從前表面向後延伸的距離。 | 將平面形狀轉變為可見的厚實 3D 物件。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 拉伸側面的顏色。 | 讓深度可見，或使側面顏色與前景填充相協調。 |
| [set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 格式化使用的額外深度。 | 微調形狀或文字的深度，特別是與斜角與材質設定一起使用時。 |
| [get_BevelTop](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_beveltop/) 和 [get_BevelBottom](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 前後表面的凸起或圓角邊緣。 | 加入柔和或模塑的邊緣，取代銳利的平面。 |
| [get_ContourColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_contourcolor/) 和 [set_ContourWidth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 圖形**

圖形通常需要四種設定才能看起來具備說服力的 3D 效果：

- 相機設定，因為預設的正面視角可能隱藏拉伸效果。
- 光源設定，因為光照使得各面與側面更易辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 拉伸或深度設定，因為平面圖形需要厚度。

以下範例會建立一個矩形，於其正面加入文字，套用 3D 格式化，將簡報儲存為 PPTX，並將投影片渲染為 PNG 影像。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

渲染出的投影片影像顯示矩形為一個厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是從「3-D 旋轉」面板設定的。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉角度。

![PowerPoint 3-D 旋轉面板，已標示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/) 設定相機類型與旋轉：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

在需要變更觀眾看到物件的方式時使用相機。它不會改變投影片上 2D 圖形的幾何形狀，而是變更 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

## **加入拉伸與深度**

拉伸透過將形狀延伸至正面之後，使其看起來更厚。於 PowerPoint 中，深度控制設定此可見厚度，而顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應於拉伸顏色與拉伸高度屬性](img_02_02.png)

使用 [set_ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 設定厚度，使用 [get_ExtrusionColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) 設定側面顏色：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

當需要直接使用 PowerPoint 的深度數值，或將深度與斜角、材質及文字效果結合時，請使用 [set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_depth/)。在許多圖形情境中，`set_ExtrusionHeight` 是較明確的設定，因為它直接表示可見的拉伸厚度。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式化與圖形填充相互獨立。您可以對正面套用純色、漸層、圖案或圖片填充，同時仍使用相同的相機、光源、材質與拉伸設定。

以下範例將漸層填充套用於圖形，並將較深的拉伸顏色套用於側面：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

![渲染的 3D 矩形，藍到橙漸層填充與橙色拉伸](img_02_03.png)

若要改用圖片填充，請將影像加入簡報，並指派給圖形的填充：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

![渲染的 3D 矩形，正面為照片填充且側面為橙色拉伸](img_02_04.png)

## **將 3D 格式化套用於文字**

圖形的 3D 格式化影響圖形本體。文字的 3D 格式化則影響文字框。對於類似 WordArt 的效果很有用，因為字母本身需要拉伸、材質、光照與相機設定。

以下範例建立帶圖案填充的文字，套用 WordArt 變形，並於 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/) 設定 3D 參數：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![渲染的 3D 文字，拱形 WordArt 變形、橙色圖案填充與深色拉伸](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 於儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式化。當渲染或匯出為固定版面配置格式時，3D 場景會被光柵化或繪製成 2D 結果。這在您將投影片渲染為 [PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)，或產生 [video conversion](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 的影格時皆適用。

請注意以下要點：

- 匯出的影像與 PDF 不是互動式的。匯出後觀眾無法旋轉物件。
- 最終外觀取決於相機、光源、材質、拉伸、填充與投影片縮放的組合。
- 若需檢查繼承或佈景主題的格式值，請參閱 [effective shape properties](/slides/zh-hant/cpp/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式化。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **FAQ**

### Aspose.Slides 能否建立互動式 3D 簡報？

Aspose.Slides 會為圖形與文字建立並呈現 PowerPoint 的 3D 效果。它不會使匯出的影像、PDF 或 HTML 頁面變成觀眾可旋轉的互動式 3D 場景。於 PPTX 中，只要格式支援，3D 格式化仍可在 PowerPoint 中進行編輯。

### 3D 模型與 3D 效果有何差異？

3D 模型是插入至簡報的獨立 3D 物件。3D 效果則是對一般 PowerPoint 圖形或文字套用的格式化，如旋轉、拉伸、斜角、光照與材質。本文僅討論 3D 效果。

### 需要哪些設定才能產生可見的 3D 圖形？

最低需設定相機旋轉，並設定拉伸或深度。實務上，亦應設定光源與材質，以使渲染出的表面具有明顯的光亮與陰影。

### 我可以將 3D 效果套用於圖形與文字嗎？

可以。對圖形本體使用 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)，對文字使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/)。

### 匯出為影像、PDF、HTML 或影片影格時，會顯示 3D 效果嗎？

會。Aspose.Slides 在產生投影片影像、PDF、HTML 以及影片轉換的影格時會渲染 3D 效果。匯出的結果僅包含已渲染的外觀，而非可編輯的 3D 物件。

### 我可以在繼承與佈景主題設定套用後讀取最終的 3D 值嗎？

可以。使用在 [Shape Effective Properties](/slides/zh-hant/cpp/shape-effective-properties/) 中描述的有效格式化 API，即可讀取最終的相機、光源、斜角以及相關 3D 值。