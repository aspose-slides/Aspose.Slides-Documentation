---
title: 在 C++ 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/cpp/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 草圖效果
- 草圖圖形線條
- 格式化接合樣式
- 漸層填滿
- 圖樣填滿
- 圖片填滿
- 紋理填滿
- 實心色填滿
- 圖形透明度
- 旋轉圖形
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 C++ 中格式化 PowerPoint 圖形——精確且完全掌控地為 PPT、PPTX 和 ODP 檔案設定填滿、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上加入圖形。由於圖形是由線條組成，您可以透過修改或套用效果來格式化它們的輪廓。此外，您還可以透過指定控制內部填滿的設定來格式化圖形。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ 提供介面與方法，讓您使用與 PowerPoint 相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂線條樣式。以下步驟說明了操作流程：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動圖形。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// 設定矩形圖形的填色。
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// 套用格式化至矩形的線條。
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

## **套用草圖效果於形狀線條**

草圖效果會讓圖形線條看起來像手繪。使用 [IShape::get_LineFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_lineformat/) 取得線條設定、[ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilineformat/get_sketchformat/) 取得草圖設定，並使用 [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isketchformat/set_sketchtype/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linesketchtype/) 列舉中選取值。

以下 C++ 程式碼示範如何套用 [LineSketchType::Curved](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，以及使用 [LineSketchType::None](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linesketchtype/) 移除效果：

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

由 [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isketchformat/get_sketchtype/) 回傳的值代表直接指派給圖形的設定。若線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat::GetEffective](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilineformat/geteffective/)、存取 [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/)，並讀取 [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/)。有效值會反映在繼承解析後實際套用的格式：

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **格式化接合樣式**

以下是三種接合類型選項：

* 圓角
* 斜角
* 斜面

預設情況下，PowerPoint 在以角度（例如圖形的角落）連接兩條線時，會使用 **圓角** 設定。然而，若您繪製的圖形具有銳角，可能會較喜歡 **斜角** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 C++ 程式碼示範了如何使用斜角、斜面與圓角接合設定建立三個矩形（如上圖所示）：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增三個矩形類型的自動圖形。
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// 為每個矩形圖形設定填色。
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 設定線寬。
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// 為每個矩形的線條設定顏色。
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 設定接合樣式。
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// 為每個矩形加入文字。
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **漸層填滿**

在 PowerPoint 中，漸層填滿是一種格式化選項，可讓您對圖形套用連續的顏色混合。例如，您可以以兩種或多種顏色的方式，使一種顏色逐漸淡入另一種顏色。

以下說明如何使用 Aspose.Slides 為圖形套用漸層填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用由 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igradientformat/) 介面公開的漸層停止集合的 `Add` 方法，加入您偏好的兩種顏色及其位置。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C++ 程式碼示範如何為橢圓套用漸層填滿效果：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個橢圓類型的自動圖形。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// 為橢圓套用漸層格式。
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

## **圖樣填滿**

在 PowerPoint 中，圖樣填滿是一種格式化選項，可讓您對圖形套用兩色設計─例如點、條紋、交叉或格子─。您可以為圖樣的前景與背景自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖樣樣式，您可以將它們套用到圖形，以提升簡報的視覺效果。即使選擇了預定義圖樣，仍可指定要使用的確切顏色。

以下說明如何使用 Aspose.Slides 為圖形套用圖樣填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選擇圖樣樣式。
1. 設定圖樣的 [Background Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipatternformat/get_backcolor/)。
1. 設定圖樣的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipatternformat/get_forecolor/)。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C++ 程式碼示範如何為矩形套用圖樣填滿：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動圖形。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 設定填滿類型為圖樣。
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

## **圖片填滿**

在 PowerPoint 中，圖片填滿是一種格式化選項，可讓您在圖形內插入影像──實質上將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 為圖形套用圖片填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Picture`。
1. 設定圖片填滿模式為 `Tile`（或其他偏好的模式）。
1. 從您想使用的影像建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件。
1. 將影像傳遞給 `ISlidesPicture.set_Image` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下為「lotus.png」圖片的示例：

![The lotus picture](lotus.png)

以下 C++ 程式碼示範如何以圖片填滿圖形：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動圖形。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// 設定填滿類型為圖片。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 設定圖片填滿模式。
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

若想將平鋪圖片設為紋理並自訂平鋪行為，可使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/picturefillformat/) 類別的下列方法：

- [set_PictureFillMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/)：設定圖片填滿模式──`Tile` 或 `Stretch`。
- [set_TileAlignment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilealignment/)：指定圖形內平鋪圖塊的對齊方式。
- [set_TileFlip](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileflip/)：控制圖塊是否水平、垂直或同時翻轉。
- [set_TileOffsetX](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/)：設定圖塊相對於圖形原點的水平偏移（點）。
- [set_TileOffsetY](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/)：設定圖塊相對於圖形原點的垂直偏移（點）。
- [set_TileScaleX](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilescalex/)：以百分比定義圖塊的水平縮放。
- [set_TileScaleY](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilescaley/)：以百分比定義圖塊的垂直縮放。

以下程式碼範例示範如何新增一個具有平鋪圖片填滿的矩形，並設定平鋪選項：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto firstSlide = presentation->get_Slide(0);

// 新增一個矩形自動圖形。
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// 設定圖形的填滿類型為圖片。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 載入影像並將其加入簡報資源。
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// 指定影像給圖形。
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// 設定圖片填滿模式與平鋪屬性。
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

## **實心色填滿**

在 PowerPoint 中，實心色填滿是一種格式化選項，會以單一、均勻的顏色填滿圖形。此純色背景不會包含任何漸層、紋理或圖樣。

若要使用 Aspose.Slides 為圖形套用實心色填滿，請依以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Solid`。
1. 為圖形指定您偏好的填滿顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 C++ 程式碼示範如何在 PowerPoint 投影片的矩形上套用實心色填滿：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動圖形。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 設定填滿類型為實心。
shape->get_FillFormat()->set_FillType(FillType::Solid);

// 設定填色。
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對圖形套用實心色、漸層、圖片或紋理填滿時，也可以設定透明度以控制填滿的不透明程度。較高的透明度值會使圖形更透，讓背景或底層物件部分可見。

Aspose.Slides 透過調整用於填滿的顏色的 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義具有透明度的顏色（alpha 成分控制透明度）。
1. 儲存簡報。

以下 C++ 程式碼示範如何為矩形套用透明填色：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個實心矩形自動圖形。
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 在實心圖形上方新增一個透明矩形自動圖形。
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The transparent shape](shape-transparency.png)

## **旋轉圖形**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求的視覺元素定位時尤為實用。

若要在投影片上旋轉圖形，請依以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 將圖形的旋轉屬性設為所需角度。
1. 儲存簡報。

以下 C++ 程式碼示範如何將圖形旋轉 5 度：

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個矩形類型的自動圖形。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 將圖形旋轉 5 度。
shape->set_Rotation(5);

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The shape rotation](shape-rotation.png)

## **新增 3D 倒角效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 屬性，為圖形套用 3D 倒角效果。

若要為圖形新增 3D 倒角效果，請依以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 以定義倒角設定。
1. 儲存簡報。

以下 C++ 程式碼示範如何為圖形套用 3D 倒角效果：

```cpp
// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
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

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 屬性，為圖形套用 3D 旋轉效果。

若要為圖形套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
1. 使用 [set_CameraType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icamera/set_cameratype/) 與 [set_LightType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilightrig/set_lighttype/) 定義 3D 旋轉。
1. 儲存簡報。

以下 C++ 程式碼示範如何為圖形套用 3D 旋轉效果：

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

以下 C++ 程式碼示範如何重設投影片的格式，並將所有在 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/layoutslide/) 上具有佔位符的圖形之位置、大小與格式還原為預設設定：

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 重設投影片上在版面配置中具有佔位符的每個圖形。
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**圖形格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與多媒體佔用了大部分檔案空間，而圖形參數（如顏色、效果與漸層）以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性──填滿、線條與效果設定。若所有對應值皆相同，即可視為樣式相同，並在邏輯上將這些圖形分組，這樣可簡化後續的樣式管理。

**我可以將一組自訂圖形樣式儲存至單獨檔案，供其他簡報重複使用嗎？**

可以。將具備所需樣式的樣本圖形存放於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製需要的已樣式化圖形，並在需要的地方重新套用其格式。