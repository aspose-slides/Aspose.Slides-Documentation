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
- 3D 擠壓
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 為 PowerPoint 圖形與文字套用並呈現 3D 效果。設定相機、光線、材質、擠壓、填色與 3D 文字。"
---
## **概觀**

Aspose.Slides for C++ 能夠建立、編輯、保留和呈現類似 PowerPoint 的 3D 格式設定，適用於圖形與文字。本篇文章探討 3D 效果，例如旋轉、擠壓、斜角、光照、材質、漸層或圖片填色，以及 3D 文字。

{{% alert color="primary" %}}
本文說明 PowerPoint 圖形與文字的 3D 格式設定效果。並非針對插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染至匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式設定概念**

使用 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 介面的 [get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_threedformat/) 方法對圖形套用 3D 格式設定。此方法會傳回 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/)，用來控制該圖形的 3D 場景。

對於文字，使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/) 介面的 [get_ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/get_threedformat/) 方法。此方法會將 3D 格式設定套用至文字框，而非圖形本體。

以下是最重要的方法：

| 方法 | 控制項目 | 使用時機 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_camera/) | 觀察點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或匹配 PowerPoint 的 3D 旋轉預設值。 |
| [get_LightRig](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_lightrig/) | 光源預設、方向與光線旋轉。 | 變更 3D 表面的高光與陰影顯示方式。 |
| [set_Material](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_material/) | 表面材質，例如平面、霧面、塑膠或金屬。 | 使相同的幾何形狀呈現更平坦、柔和、光亮或金屬效果。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 圖形自前表面向後延伸的距離。 | 將平面圖形轉換為可見的厚實 3D 物件。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 擠壓側面的顏色。 | 使深度可見，或將側面顏色與前景填色協調。 |
| [set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 格式設定使用的額外 3D 深度。 | 微調圖形或文字的深度，特別是與斜角與材質設定一起使用時。 |
| [get_BevelTop](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_beveltop/) 和 [get_BevelBottom](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 前後表面的凸起或圓滑邊緣。 | 在平坦的表面加入柔化或成型的邊緣，而非鋒利的平面。 |
| [get_ContourColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/get_contourcolor/) 和 [set_ContourWidth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件的邊界。 |

## **建立 3D 圖形**

圖形在看起來具有說服力的 3D 效果前，通常需要四種設定：

- 相機設定，因為預設的正面視圖可能會隱藏擠壓效果。
- 光源設定，因為光照會使表面與側面易於辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠壓或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，於其正面加入文字，套用 3D 格式設定，將簡報儲存為 PPTX，並將投影片呈現為 PNG 圖像。

```cpp
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

渲染出的投影片圖像顯示矩形為一個厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是透過「3-D 旋轉」面板設定。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3-D 旋轉面板，突出顯示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ithreedformat/) 設定相機類型與旋轉：

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

當需要變更檢視者看到物件的角度時使用相機。它不會變更投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 視點。

## **加入擠壓與深度**

擠壓透過將圖形延伸至正面後方，使其看起來更厚。在 PowerPoint 中，深度控制設定此可見厚度，而顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應到擠壓顏色與擠壓高度屬性](img_02_02.png)

設定 [set_ExtrusionHeight] 以調整厚度，並設定 [get_ExtrusionColor] 以調整側面顏色：

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

當需要直接操作 PowerPoint 的深度值，或將深度與斜角、材質及文字效果結合時，使用 [set_Depth]。在多數圖形情境下，`set_ExtrusionHeight` 更直觀，因為它直接表示可見的擠壓。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式設定與圖形填色互相獨立。您可以在正面套用純色、漸層、圖案或圖片填色，同時仍使用相同的相機、光源、材質與擠壓設定。

以下範例將漸層填色套用於圖形，並將較暗的擠壓顏色套用於側面：

```cpp
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

渲染結果保留正面的漸層，並分別呈現擠壓效果：

![渲染的 3D 矩形，藍至橙色漸層填色與橙色擠壓](img_02_03.png)

若要改用圖片填色，先將影像加入簡報，並指派給圖形填色：

```cpp
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

圖片會渲染於正面，而擠壓則會以 3D 側面表面呈現：

![渲染的 3D 矩形，正面使用照片填色、側面為橙色擠壓](img_02_04.png)

## **將 3D 格式設定套用於文字**

圖形的 3D 格式設定會影響圖形本體；文字的 3D 格式設定則會影響文字框。此功能適用於類似 WordArt 的效果，讓文字本身具備擠壓、材質、光照與相機設定。

以下範例建立具有圖案填色的文字，套用 WordArt 變形，並在 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/) 上設定 3D 參數：

```cpp
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

文字會以彎曲、擠壓的 3D 形式呈現：

![渲染的 3D 文字，帶拱形 WordArt 變形、橙色圖案填色與深色擠壓](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式設定。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這在您將投影片渲染為 [PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)，或產生供 [video conversion](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 使用的影格時皆適用。

請留意以下要點：

- 匯出的圖像與 PDF 並非互動式，匯出後觀眾無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠壓、填色與投影片縮放的組合。
- 若需檢視繼承或佈景主題的格式值，請參考 [effective shape properties](/slides/zh-hant/cpp/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式設定。在這些格式中，只會渲染出視覺結果，而非保留可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會建立並呈現圖形與文字的 PowerPoint 3D 效果，但不會使匯出的圖像、PDF 或 HTML 頁面成為觀眾可旋轉的互動式 3D 場景。在 PPTX 中，若格式支援，3D 格式設定仍保留為可在 PowerPoint 中編輯的狀態。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入至簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式設定，如旋轉、擠壓、斜角、光照與材質。本篇文章說明的是 3D 效果。

**要呈現可見的 3D 圖形，需要哪些設定？**

最少需要設定相機旋轉，並同時設定擠壓或深度。實務上，亦建議設定光源與材質，以確保渲染的表面具有明顯的高光與陰影。

**我可以同時對圖形與文字套用 3D 效果嗎？**

可以。使用 [IShape] 針對圖形本體，使用 [ITextFrameFormat] 針對文字。

**在匯出為圖像、PDF、HTML 或影片影格時，3D 效果會出現嗎？**

會。Aspose.Slides 在產生投影片圖像、PDF、HTML 以及用於影片轉換的影格時，皆會渲染 3D 效果。匯出的結果僅包含渲染後的外觀，而非可編輯的 3D 物件。

**我可以在繼承與佈景主題設定套用後，讀取最終的 3D 值嗎？**

可以。使用 [Shape Effective Properties] 中描述的有效格式 API，即可讀取最終的相機、光源、斜角與相關 3D 值。