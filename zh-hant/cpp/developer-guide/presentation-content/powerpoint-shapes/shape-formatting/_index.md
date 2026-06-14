---
title: 在 C++ 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/cpp/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 格式化連接樣式
- 漸層填色
- 圖樣填色
- 圖片填色
- 紋理填色
- 純色填色
- 形狀透明度
- 旋轉形狀
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 C++ 中格式化 PowerPoint 形狀——精確且全方位地設定 PPT、PPTX 和 ODP 檔案的填色、線條和效果樣式。"
---
## **簡介**

在 PowerPoint，您可以在投影片中新增形狀。由於形狀是由線條組成，您可以透過修改或套用效果於其輪廓來格式化它們。此外，您還可以透過指定設定來控制內部的填滿方式，以格式化形狀。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ 提供介面與方法，讓您能夠使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟概述了此程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 設定形狀的 [line style](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linedashstyle/)。
1. 設定形狀的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// 設定矩形形狀的填充顏色。
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// 套用矩形線條的格式化。
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// 設定矩形線條的顏色。
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The formatted lines in the presentation](formatted-lines.png)

## **格式化連接樣式**

以下為三種連接類型的選項：

* 圓角
* 斜接
* 斜角

預設情況下，PowerPoint 在以角度（例如形狀的角落）連接兩條線時，會使用 **圓角** 設定。然而，如果您正在繪製具有尖銳角度的形狀，可能會較喜歡 **斜接** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 C++ 程式碼示範如何使用斜接、斜角與圓角連接類型設定建立圖中所示的三個矩形：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增三個矩形類型的自動形狀。
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **漸層填色**

在 PowerPoint 中，Gradient Fill（漸層填色）是一種格式化選項，允許您對形狀套用連續的顏色混合。例如，您可以使用兩種或更多顏色，使其中一種顏色逐漸淡入另一種顏色。

以下說明如何使用 Aspose.Slides 為形狀套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igradientformat/) 介面所公開的漸層停止集合的 `Add` 方法，將您偏好的兩種顏色與定義好的位置加入。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C++ 程式碼示範如何對橢圓套用漸層填色效果：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個橢圓類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// 套用漸層格式至橢圓。
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// 設定漸層的方向。
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// 新增兩個漸層停止點。
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The ellipse with gradient fill](gradient-fill.png)

## **圖樣填色**

在 PowerPoint 中，Pattern Fill（圖樣填色）是一種格式化選項，讓您對形狀套用兩種顏色的設計，例如點狀、條紋、交叉陰影或格子。您可以為圖樣的前景與背景自訂顏色。

Aspose.Slides 提供超過 45 種預定義的圖樣樣式，您可以將其套用至形狀，以提升簡報的視覺效果。即使選擇了預定義圖樣，仍可指定其使用的確切顏色。

以下說明如何使用 Aspose.Slides 為形狀套用圖樣填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖樣樣式。
1. 設定圖樣的 [Background Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipatternformat/get_backcolor/)。
1. 設定圖樣的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipatternformat/get_forecolor/)。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C++ 程式碼示範如何對矩形套用圖樣填色：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 設定填充類型為圖樣。
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// 設定圖樣樣式。
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// 設定圖樣的背景色與前景色。
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The rectangle with pattern fill](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，Picture Fill（圖片填色）是一種格式化選項，允許您在形狀內插入影像──實際上將影像作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填色模式設定為 `Tile`（或其他偏好的模式）。
1. 從您想使用的影像建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件。
1. 將影像傳遞至 `ISlidesPicture.set_Image` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為 "lotus.png" 的檔案，內容如下圖所示：

![The lotus picture](lotus.png)

以下 C++ 程式碼示範如何使用圖片填滿形狀：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// 設定填充類型為圖片。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 設定圖片填充模式。
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// 載入影像並將其加入簡報資源。
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// 設定圖片。
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The shape with picture fill](picture-fill.png)

### **將圖片平鋪為紋理**

如果您想將平鋪的圖片設定為紋理並自訂平鋪行為，可使用以下 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/picturefillformat/) 類別的方法：

- [set_PictureFillMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/)：設定圖片填色模式—`Tile` 或 `Stretch`。
- [set_TileAlignment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilealignment/)：指定平鋪在形狀內的對齊方式。
- [set_TileFlip](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileflip/)：控制平鋪是否水平翻轉、垂直翻轉或同時翻轉。
- [set_TileOffsetX](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/)：設定平鋪相對於形狀原點的水平偏移量（單位為點）。
- [set_TileOffsetY](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/)：設定平鋪相對於形狀原點的垂直偏移量（單位為點）。
- [set_TileScaleX](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilescalex/)：定義平鋪的水平比例，以百分比表示。
- [set_TileScaleY](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilescaley/)：定義平鋪的垂直比例，以百分比表示。

以下程式碼範例示範如何新增具有平鋪圖片填色的矩形形狀，並設定平鋪選項：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto firstSlide = presentation->get_Slide(0);

// 新增一個矩形自動形狀。
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// 設定形狀的填充類型為圖片。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 載入影像並將其加入簡報資源。
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// 指派影像給形狀。
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// 設定圖片填充模式與平鋪屬性。
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The tile options](tile-options.png)

## **純色填色**

在 PowerPoint 中，Solid Color Fill（純色填色）是一種格式化選項，會以單一均勻的顏色填滿形狀。此純粹的背景色不含任何漸層、紋理或圖樣。

以下說明如何使用 Aspose.Slides 為形狀套用純色填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Solid`。
1. 為形狀指派您偏好的填色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C++ 程式碼示範如何在 PowerPoint 投影片的矩形上套用純色填色：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 設定填充類型為實色。
shape->get_FillFormat()->set_FillType(FillType::Solid);

// 設定填充顏色。
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對形狀套用純色、漸層、圖片或紋理填色時，也可以設定透明度，以控制填色的透明程度。較高的透明度值會讓形狀更透，使背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色使用的顏色之 alpha 值來設定透明度。以下說明如何執行：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義帶有透明度的顏色（`alpha` 成分控制透明度）。
1. 儲存簡報。

以下 C++ 程式碼示範如何對矩形套用透明填色：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個實色矩形自動形狀。
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 在實色形狀上方新增一個透明矩形自動形狀。
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The transparent shape](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉形狀。這在以特定對齊或設計需求定位視覺元素時非常有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 設定形狀的旋轉屬性為所需的角度。
1. 儲存簡報。

以下 C++ 程式碼示範如何將形狀旋轉 5 度：

```cpp
// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 將形狀旋轉 5 度。
shape->set_Rotation(5);

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The shape rotation](shape-rotation.png)

## **新增 3D 倒角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 屬性來套用 3D 倒角效果。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 以定義倒角設定。
1. 儲存簡報。

以下 C++ 程式碼示範如何對形狀套用 3D 倒角效果：

```cpp
// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 在投影片上新增形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The 3D bevel effect](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 屬性來套用 3D 旋轉效果。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 新增至投影片。
1. 使用 [set_CameraType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icamera/set_cameratype/) 與 [set_LightType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilightrig/set_lighttype/) 來定義 3D 旋轉。
1. 儲存簡報。

以下 C++ 程式碼示範如何對形狀套用 3D 旋轉效果：

```cpp
// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// 將簡報儲存為 PPTX 檔案。
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The 3D rotation effect](3D-rotation-effect.png)

## **重設格式**

以下 C++ 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/layoutslide/) 上所有含佔位符的形狀之位置、大小與格式恢復為預設設定：

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 重設投影片上在版面配置中具有佔位符的每個形狀。
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與媒體佔用了大部分檔案空間，而形狀的參數（例如顏色、效果與漸層）僅以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的形狀以便將它們分組？**

比較每個形狀的關鍵格式屬性——填色、線條與效果設定。如果所有對應的值皆相符，則視為樣式相同，並在邏輯上將這些形狀分組，這樣可簡化之後的樣式管理。

**我可以將一組自訂的形狀樣式儲存至單獨檔案，以便在其他簡報中重複使用嗎？**

可以。將具備所需樣式的範例形狀儲存在模板投影片或 .POTX 樣板檔案中。建立新簡報時，開啟該模板，複製所需的樣式形狀，並在需要的地方重新套用其格式。