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
- 3D 擠出
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中套用並呈現 PowerPoint 圖形與文字的 3D 效果。設定相機、光照、材質、擠出、填充以及 3D 文字。"
---
## **概觀**

Aspose.Slides for C++ 能夠建立、編輯、保存並呈現 PowerPoint 風格的 3D 格式設定，適用於圖形和文字。本文介紹 3D 效果，例如旋轉、擠出、斜面、光照、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="Note" %}}
本文說明的是 PowerPoint 圖形與文字的 3D 格式設定效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖片、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式設定概念**

使用 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) 方法為圖形套用 3D 格式設定。此方法會傳回 [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/)，用以控制該圖形的 3D 場景。

對於文字，請使用 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) 方法。此方法會將 3D 格式設定套用到文字框，而非圖形本體。

最重要的方法包括：

| 方法 | 控制項目 | 使用時機 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | 視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設。 |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | 光源預設、方向與光線旋轉。 | 更改 3D 表面的高光與陰影呈現方式。 |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | 表面材質，例如平面、霧面、塑膠或金屬。 | 讓相同的幾何形狀看起來更平坦、柔和、有光澤或金屬感。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 圖形從正面向後延伸的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 擠出側面的顏色。 | 使深度可見，或讓側面顏色與正面填充協調。 |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 格式設定使用的額外 3D 深度。 | 微調圖形或文字的深度，特別是與斜角與材質設定一起使用時。 |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 正面與背面之提升或圓角邊緣。 | 加入柔和或成型的邊緣，取代銳利平面的外觀。 |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 圖形**

圖形通常需要四種設定，才能呈現出逼真的 3D 效果：

- 相機設定，因為預設的正面視圖可能會隱藏擠出效果。
- 光源設定，因為光線讓各面與側面更易辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面圖形需要具備厚度。

下列範例建立一個矩形、在其正面加入文字，並套用 3D 格式設定。相機旋轉值以度數表示，擠出高度為 100 點。此範例會將投影片渲染為兩倍預設尺寸的 PNG 圖片，並將簡報另存為 PPTX。

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

渲染出的投影片圖像顯示此矩形為一個厚實的 3D 方塊：

![呈現藍色 3D 矩形，正面有白色 3D 文字的渲染圖](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是透過「3-D Rotation」面板設定。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 面板，突出顯示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，可透過 [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) 取得相機。此範例建立一個矩形、選取正交前視圖，並分別將其 X、Y、Z 旋轉設定為 20、30、40 度。它在記憶體中配置圖形，未寫入檔案：

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

當您需要變更觀眾觀看物件的角度時，請使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 以及 Aspose.Slides 渲染時使用的 3D 觀點。

### **從範本圖形複製相機方向**

若要匹配範本圖形的相機方向，先使用 [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) 讀取其預設，再以 [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) 套用。此範例開啟 `template.pptx`，將第一張投影片第一個圖形的相機方向複製到第二個圖形。兩個圖形皆已有 3D 燈光，而第二個圖形則未設定明確的相機旋轉。

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) 以度數回傳角度。索引 `0` 為緯度，`1` 為經度，`2` 為旋轉。請依此順序將角度傳入 [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/)。如果來源未設定明確的旋轉，`GetRotation` 會回傳 null 指標，則保持第二個圖形的角度未設定。明確的 `(0, 0, 0)` 旋轉會回傳三個零的陣列，應予以複製。

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

當您在 PowerPoint 中重新開啟 `camera-copy.pptx` 時，右側的箭頭與左側的矩形具有相同的相機預設與旋轉。兩個圖形使用相同的光源與擠出深度。

![藍色 3D 矩形與右向箭頭，其相機方向相匹配，從上方右側俯視的渲染圖](camera-orientation.png)

## **加入擠出與深度**

擠出透過將圖形延伸至正面後方，使其看起來更厚。於 PowerPoint 中，深度控制決定此可見的厚度，而顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應到擠出顏色與擠出高度屬性](img_02_02.png)

使用 [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 設定厚度，並使用 [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) 設定側面顏色。此範例為矩形設定 100 點的擠出高度，側面為紫色，並旋轉相機以顯示其厚度。它在記憶體中配置圖形，未寫入檔案：

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

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) 方法設定 3D 圖形的深度。而 [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 方法控制擠出效果的高度，如本範例所示。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式設定與圖形填充互不影響。您可以對正面套用純色、漸層、圖樣或圖片填充，同時保持相同的相機、光源、材質與擠出設定。

此範例將藍色至橙色的漸層套用於正面，側面的 150 點擠出則使用深橙色。漸層的 0 與 100 位置分別標示起始與結束。相機旋轉值以度數表示。投影片渲染為兩倍預設尺寸的 PNG 圖片：

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

渲染結果保留正面的漸層，並分別渲染擠出側面：

![渲染的 3D 矩形，正面為藍至橙漸層填充，側面為橙色擠出](img_02_03.png)

若改用圖片填充，請先將圖片加入簡報，並指派給圖形填充。此範例需要工作目錄中已有名為 "image.jpg" 的檔案。它會將圖片拉伸以填滿矩形，套用 150 點的擠出，並以度數設定相機旋轉。圖形於記憶體中配置，未寫入或渲染檔案：

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

圖片會渲染於正面，而擠出則以 3D 側面表面呈現：

![渲染的 3D 矩形，正面為照片填充，側面為橙色擠出](img_02_04.png)

## **將 3D 格式設定套用於文字**

圖形的 3D 格式設定會影響圖形本體；文字的 3D 格式設定則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下範例建立帶有橙白格線圖樣的文字，套用向上拱形，並透過 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) 設定 3D 參數。擠出高度與深度以點為單位，光源旋轉以度數表示。圖形的填充與輪廓被隱藏，僅顯示文字本身。此範例會以兩倍預設投影片尺寸渲染 PNG 圖片，並將簡報儲存為 PPTX：

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

文字呈現為彎曲、擠出的 3D 字體：

![渲染的 3D 文字，帶有拱形 WordArt 變形、橙色圖樣填充與深色擠出](img_02_05.png)

## **在 3D 圖形上保持文字平面**

若要在保持圖形 3D 外觀的同時使文字可讀，請透過 [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/) 呼叫 [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/)。當值為 `true` 時，文字會保持在 3D 場景之外；為 `false` 時，文字會參與 3D 場景，並跟隨其 3D 方向。

此設定不會移除圖形的 3D 格式設定：其相機、光照、材質與擠出仍透過 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) 進行配置。它也不同於普通的旋轉。[IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) 會在投影片平面上旋轉圖形，而 [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) 控制文字在其邊界盒內的自訂旋轉。將文字保持在 3D 場景之外不會重設上述任何角度。

以下獨立範例建立一個藍色矩形與文字，並在旁邊複製一個相同的圖形。兩個圖形具有相同的 3D 格式設定，唯有文字設定不同：左側為 `false`，右側為 `true`。相機角度以度數表示，擠出高度為 40 點。此範例將簡報儲存為 PPTX，並以兩倍預設尺寸渲染比較投影片為 PNG 圖片。

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

左側的文字遵循 3D 方向；右側的文字保持平面且較易閱讀。兩個矩形皆保留相同的可見擠出與 3D 方向。

![並排的 3D 矩形：左側 KeepTextFlat 為 false，右側為 true](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式設定。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。這在將投影片渲染為 [PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)，或產生用於 [影片轉換](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 的畫格時皆適用。

請注意以下要點：

- 匯出的圖片與 PDF 不是互動式的，匯出後使用者無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠出、填充與投影片縮放的組合。
- 若需檢視繼承或佈景主題設定下的格式值，請參考 [有效圖形屬性](/slides/zh-hant/cpp/shape-effective-properties/)。
- 某些輸出格式無法保存可編輯的 PowerPoint 3D 格式設定。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能夠建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 圖形與文字的 3D 效果。但它不會將匯出的圖片、PDF 或 HTML 頁面製作成可讓觀眾旋轉的互動式 3D 場景。在 PPTX 中，只要格式支援，3D 格式設定仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入到簡報中的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式設定，如旋轉、擠出、斜角、光照與材質。本文僅討論 3D 效果。

**需要哪些設定才能看到可見的 3D 圖形？**

至少需要設定相機旋轉，並設定擠出或深度。實務上，通常也會設定光源與材質，以確保渲染的面具有明顯的高光與陰影。

**我可以將 3D 效果套用於圖形與文字嗎？**

可以。對圖形本體使用 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/)，對文字使用 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/)。

**匯出為圖片、PDF、HTML 或影片畫格時會顯示 3D 效果嗎？**

會。Aspose.Slides 在產生投影片圖像、PDF、HTML 以及用於影片轉換的畫格時，會渲染 3D 效果。匯出的結果僅包含已渲染的外觀，而非可編輯的 3D 物件。

**我可以在套用繼承與佈景主題設定後讀取最終的 3D 值嗎？**

可以。請使用在 [圖形有效屬性](/slides/zh-hant/cpp/shape-effective-properties/) 中描述的有效格式化 API，讀取最終的相機、光源、斜角及相關 3D 值。