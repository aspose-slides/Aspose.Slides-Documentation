---
title: 在簡報中使用 C++ 建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 簡報
- 3D 旋轉
- 3D 深度
- 3D 擠出
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中套用並呈現 PowerPoint 形狀與文字的 3D 效果。設定相機、光照、材質、擠出、填充，以及 3D 文字。"
---
## **概觀**

Aspose.Slides for C++ 可以建立、編輯、保留並轉譯 PowerPoint 風格的 3D 格式設定（用於形狀和文字）。本文介紹旋轉、擠出、斜角、光照、材質、漸層或圖片填充以及 3D 文字等 3D 效果。

{{% alert color="info" title="Note" %}}
本文說明 PowerPoint 形狀和文字的 3D 格式化效果。它不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式概念**

使用 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_threedformat/) 方法對形狀套用 3D 格式。該方法回傳 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/)，用於控制該形狀的 3D 場景。

對文字，使用 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/get_threedformat/) 方法。此方法會對文字框套用 3D 格式，而非形狀本體。

最重要的方法包括：

| 方法 | 控制項目 | 使用時機 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_camera/) | 觀點、預設相機類型、旋轉、縮放和透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設值。 |
| [get_LightRig](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_lightrig/) | 光線預設、方向與光線旋轉。 | 變更 3D 表面上亮部與陰影的呈現方式。 |
| [set_Material](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_material/) | 表面材質，例如平面、啞光、塑膠或金屬。 | 使相同的幾何形狀呈現更平坦、柔和、光亮或金屬感。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 形狀從正面向後延伸的距離。 | 將平面形狀變成可見的厚實 3D 物件。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 擠出側面的顏色。 | 使深度可見，或將側面顏色與正面填充協調。 |
| [set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 格式所使用的額外深度。 | 微調形狀或文字的深度，特別是結合斜角與材質設定時。 |
| [get_BevelTop](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 正面與背面的凸起或圓角邊緣。 | 新增柔化或成形的邊緣，以取代銳利的平面。 |
| [get_ContourColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 物件的輪廓。 | 在渲染輸出中突顯物件邊界。 |

## **建立 3D 形狀**

- 相機設定，因為預設的前視圖可能隱藏擠出效果。
- 光線設定，因為光照使各面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面形狀需要厚度。

以下範例建立一個矩形，於正面加入文字，並套用 3D 格式。相機旋轉值以度數表示，擠出高度為 100 點。範例會將投影片以兩倍預設尺寸渲染為 PNG 圖像，並將簡報儲存為 PPTX。

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

渲染出的投影片圖像顯示矩形為厚實的 3D 塊狀：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

In PowerPoint 中，3D 旋轉是從「3-D Rotation」面板設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 面板，突出顯示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_camera/) 取得相機。此範例建立一個矩形，選擇正視正投影，並分別將其 X、Y、Z 旋轉設定為 20、30、40 度。它在記憶體中配置形狀，未儲存檔案：

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

presentation->Dispose();
```

在需要變更檢視者看到物件的方式時使用相機。它不會改變投影片上 2D 形狀的幾何形狀。它會改變 PowerPoint 以及 Aspose.Slides 在渲染時使用的 3D 觀點。

## **加入擠出與深度**

擠出會透過延伸至正面背後，使形狀看起來較厚。於 PowerPoint 中，深度控制設定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對映至擠出顏色與擠出高度屬性](img_02_02.png)

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_depth/) 方法設定 3D 形狀的深度。[set_ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 方法控制擠出效果的高度，如本範例所示。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

## **在 3D 效果中使用漸層或圖片填充**

3D 格式與形狀填充無關。您可對正面套用純色、漸層、圖案或圖片填充，同時使用相同的相機、光線、材質與擠出設定。

此範例對正面套用藍至橙的漸層，對 150 點的擠出使用深橙色。漸層在 0 與 100 處停止，分別標示漸層的開始與結束。相機旋轉值以度數表示。投影片以兩倍預設尺寸渲染為 PNG 圖像：

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

渲染的 3D 矩形，藍至橙漸層填充與橙色擠出：

![渲染的 3D 矩形，藍至橙漸層填充與橙色擠出](img_02_03.png)

若要改用圖片填充，將圖片加入簡報並指派給形狀填充。本範例需要工作目錄中已有名為 "image.jpg" 的檔案。它會將圖片拉伸填滿矩形，套用 150 點擠出，並以度數設定相機旋轉。範例在記憶體中配置形狀，未儲存或渲染檔案：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

渲染的 3D 矩形，正面使用照片填充與橙色擠出：

![渲染的 3D 矩形，正面使用照片填充與橙色擠出](img_02_04.png)

## **套用 3D 格式至文字**

形狀的 3D 格式影響形狀本體。文字的 3D 格式則影響文字框。此功能適用於 WordArt 類似的效果，讓字母本身需要擠出、材質、光照與相機設定。

以下範例建立帶有橙白格子圖案的文字，套用向上拱形，並透過 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/get_threedformat/) 設定 3D。擠出高度與深度以點為單位，光線旋轉以度數表示。形狀填充與輪廓隱藏，僅顯示文字。範例以兩倍預設投影片尺寸渲染 PNG 圖像，並將簡報儲存為 PPTX：

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

渲染的 3D 文字，拱形 WordArt 變形、橙色圖案填充與深色擠出：

![渲染的 3D 文字，拱形 WordArt 變形、橙色圖案填充與深色擠出](img_02_05.png)

## **在 3D 形狀上保持文字平面**

若要在保留形狀的 3D 外觀時保持文字可讀，請透過 [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_textframeformat/) 呼叫 [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/set_keeptextflat/)。當值為 `true` 時，文字會停留在 3D 場景之外；值為 `false` 時，文字會參與場景並遵循 3D 方向。

此設定不會移除形狀的 3D 格式：其相機、光線、材質與擠出仍透過 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_threedformat/) 設定。它亦不同於普通旋轉。[IShape::set_Rotation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_rotation/) 會在投影片平面旋轉形狀，而 [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/set_rotationangle/) 控制文字在其邊框內的自訂旋轉。將文字保持在 3D 場景之外不會重設這兩個角度。

以下獨立範例建立一個藍色矩形與文字，並在原始旁邊複製一個。兩個形狀具有相同的 3D 格式，僅文字設定不同：左側 `false`、右側 `true`。相機角度以度數表示，擠出高度為 40 點。範例將簡報儲存為 PPTX，並以兩倍預設尺寸將比較投影片渲染為 PNG。

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

並排的 3D 矩形：左側 KeepTextFlat 為 false，右側為 true：

![並排的 3D 矩形：左側 KeepTextFlat 為 false，右側為 true](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這在您將投影片渲染為 [PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)，或產生 [video conversion](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 框架時皆適用。

- 匯出的圖像與 PDF 不是互動式的。匯出後觀眾無法旋轉物件。  
- 最終外觀取決於相機、光線裝置、材質、擠出、填充與投影片縮放的組合。  
- 如果需要檢視繼承或主題基礎的格式值，請閱讀 [effective shape properties](/slides/zh-hant/cpp/shape-effective-properties/)。  
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，視覺結果會被渲染而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會為形狀與文字建立並渲染 PowerPoint 3D 效果。它不會使匯出的圖像、PDF 或 HTML 頁面成為觀眾可旋轉的互動式 3D 場景。在 PPTX 中，若格式支援，3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 形狀或文字的格式設定，例如旋轉、擠出、斜角、光照與材質。本文僅討論 3D 效果。

**需要哪些設定才能看到可見的 3D 形狀？**

最低需要設定相機旋轉，並設定擠出或深度。實務上，亦需設定光線裝置與材質，以使渲染的面具備明顯的高光與陰影。

**我可以同時將 3D 效果套用於形狀與文字嗎？**

可以。對形狀本體使用 [IShape::get_ThreeDFormat]，對文字則使用 [ITextFrameFormat::get_ThreeDFormat]。

**匯出為圖像、PDF、HTML 或影片框架時，3D 效果會顯示嗎？**

會。Aspose.Slides 在產生投影片圖像、PDF、HTML 以及影片轉換所用的框架時，會渲染 3D 效果。匯出的結果僅包含渲染後的外觀，而非可編輯的 3D 物件。

**在套用繼承與主題設定後，我能讀取最終的 3D 值嗎？**

可以。使用在 [Shape Effective Properties] 中描述的有效格式 API，可讀取最終的相機、光線裝置、斜角及相關 3D 值。