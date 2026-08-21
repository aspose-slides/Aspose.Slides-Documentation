---
title: 在 C++ 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/cpp/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 草圖形狀線條
- 格式化接合樣式
- 漸層填充
- 圖案填充
- 圖片填充
- 紋理填充
- 純色填充
- 形狀透明度
- 黑白形狀呈現
- 灰階形狀呈現
- 旋轉形狀
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 C++ 中格式化 PowerPoint 形狀——為 PPT、PPTX 和 ODP 檔案精確且完整地設定填充、線條和效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上加入形狀。由於形狀由線條組成，您可以透過修改或套用效果於輪廓來格式化它們。另外，您也可以透過指定控制內部填充方式的設定來格式化形狀。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ 提供介面與方法，讓您使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟說明了整個流程：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 設定形狀的 [line style](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linestyle/)。  
1. 設定線條寬度。  
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linedashstyle/)。  
1. 設定形狀的線條顏色。  
1. 將已修改的簡報存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// 建立代表簡報檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個 Rectangle 類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// 設定矩形形狀的填色。
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// 為矩形的線條套用格式。
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

## **將草圖效果套用至形狀線條**

草圖效果會讓形狀線條呈現手繪外觀。使用 [IShape::get_LineFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_lineformat/) 取得線條設定，使用 [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilineformat/get_sketchformat/) 取得草圖設定，並使用 [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isketchformat/set_sketchtype/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linesketchtype/) 列舉中選取值。

以下 C++ 程式碼示範如何套用 [LineSketchType::Curved](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並使用 [LineSketchType::None](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/linesketchtype/) 移除效果：

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

由 [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isketchformat/get_sketchtype/) 回傳的值代表直接指派給形狀的設定。若線條格式可從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat::GetEffective](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilineformat/geteffective/)，取得 [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/)，並讀取 [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/)。有效值反映繼承解析後實際套用的格式：

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

* Round  
* Miter  
* Bevel  

預設情況下，PowerPoint 於角度處（例如形狀的角落）連接兩條線時會使用 **Round** 設定。但若您繪製的是銳角形狀，可能會較喜歡 **Miter** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 C++ 程式碼示範如何使用 Miter、Bevel 與 Round 接合類型設定建立三個矩形（如上圖所示）：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增三個 Rectangle 類型的自動形狀。
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// 設定每個矩形形狀的填色。
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 設定線條寬度。
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// 設定每個矩形線條的顏色。
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

## **漸層填充**

在 PowerPoint 中，漸層填充是一種格式化選項，允許您將連續的顏色混合套用至形狀。例如，您可以以兩種或多種顏色漸變的方式填充形狀，使其中一種顏色逐漸淡入另一種顏色。

以下說明如何使用 Aspose.Slides 為形狀套用漸層填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Gradient`。  
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igradientformat/) 介面所公開的漸層停止集合的 `Add` 方法，依所需位置加入兩個喜好的顏色。  
1. 將已修改的簡報存為 PPTX 檔案。

以下 C++ 程式碼示範如何為橢圓套用漸層填充效果：

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個 Ellipse 類型的自動形狀。
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

## **圖案填充**

在 PowerPoint 中，圖案填充是一種格式化選項，可讓您以兩種顏色的設計（如點、條紋、交叉或格子）填充形狀。您可以為圖案的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義的圖案樣式，您可將其套用至形狀以提升簡報的視覺吸引力。即使選取了預定義圖案，仍可自行指定其使用的確切顏色。

以下說明如何使用 Aspose.Slides 為形狀套用圖案填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Pattern`。  
1. 從預定義選項中選擇圖案樣式。  
1. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipatternformat/get_backcolor/)。  
1. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipatternformat/get_forecolor/)。  
1. 將已修改的簡報存為 PPTX 檔案。

以下 C++ 程式碼示範如何為矩形套用圖案填充：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個 Rectangle 類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 設定填充類型為 Pattern。
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// 設定圖案樣式。
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// 設定圖案的背景色與前景色。
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// 將 PPTX 檔案儲存至磁碟。
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The rectangle with pattern fill](pattern-fill.png)

## **圖片填充**

在 PowerPoint 中，圖片填充是一種格式化選項，允許您在形狀內插入影像，等同於將圖片作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Picture`。  
1. 將圖片填充模式設為 `Tile`（或其他您偏好的模式）。  
1. 從欲使用的影像建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件。  
1. 將影像傳遞給 `ISlidesPicture.set_Image` 方法。  
1. 將已修改的簡報存為 PPTX 檔案。

以下為名為 **lotus.png** 的圖片示例：

![The lotus picture](lotus.png)

以下 C++ 程式碼示範如何用圖片填充形狀：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個 Rectangle 類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// 設定填充類型為 Picture。
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

若要將平鋪圖片作為紋理並自訂平鋪行為，可使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/picturefillformat/) 類別的以下方法：

- [set_PictureFillMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/)：設定圖片填充模式，`Tile` 或 `Stretch`。  
- [set_TileAlignment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilealignment/)：指定平鋪在形狀內的對齊方式。  
- [set_TileFlip](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileflip/)：控制平鋪是否水平、垂直或雙向翻轉。  
- [set_TileOffsetX](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/)：設定平鋪相對於形狀原點的水平偏移（點數）。  
- [set_TileOffsetY](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/)：設定平鋪相對於形狀原點的垂直偏移（點數）。  
- [set_TileScaleX](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilescalex/)：以百分比定義水平縮放比例。  
- [set_TileScaleY](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/set_tilescaley/)：以百分比定義垂直縮放比例。

以下程式碼示範如何新增一個帶有平鋪圖片填充的矩形，並設定平鋪選項：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto firstSlide = presentation->get_Slide(0);

// 新增一個矩形自動形狀。
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// 設定形狀的填充類型為 Picture。
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 載入影像並將其加入簡報資源。
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// 指定影像給形狀。
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// 配置圖片填充模式與平鋪屬性。
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

## **純色填充**

在 PowerPoint 中，純色填充是一種格式化選項，可將形狀填滿單一、均勻的顏色。此背景色不含任何漸層、紋理或圖案。

使用 Aspose.Slides 為形狀套用純色填充的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Solid`。  
1. 為形狀指派您偏好的填充顏色。  
1. 將已修改的簡報存為 PPTX 檔案。

以下 C++ 程式碼示範如何在 PowerPoint 投影片的矩形上套用純色填充：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個 Rectangle 類型的自動形狀。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 設定填充類型為 Solid。
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

在 PowerPoint 中，當您為形狀套用純色、漸層、圖片或紋理填充時，也可以設定透明度，以控制填充的不透明程度。較高的透明度會使形狀更透明，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填充顏色的 alpha 值來設定透明度。操作方式如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Solid`。  
1. 使用 `Color` 定義具有透明度的顏色（alpha 成分控制透明度）。  
1. 儲存簡報。

以下 C++ 程式碼示範如何為矩形套用透明填色：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 新增一個實心矩形自動形狀。
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 在實心形狀上新增一個透明矩形自動形狀。
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

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉形狀。這在需要特定對齊或設計需求的視覺元素定位時相當有用。

要在投影片上旋轉形狀，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 將形狀的旋轉屬性設定為所需的角度。  
1. 儲存簡報。

以下 C++ 程式碼示範如何將形狀旋轉 5 度：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a presentation file.
auto presentation = MakeObject<Presentation>();

// Get the first slide.
auto slide = presentation->get_Slide(0);

// Add an auto shape of the Rectangle type.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Rotate the shape by 5 degrees.
shape->set_Rotation(5);

// Save the PPTX file to disk.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The shape rotation](shape-rotation.png)

## **加入 3D 斜角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 屬性，為形狀加入 3D 斜角效果。

要為形狀加入 3D 斜角效果，請依下列步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 以定義斜角設定。  
1. 儲存簡報。

以下 C++ 程式碼展示如何為形狀套用 3D 斜角效果：

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Create an instance of the Presentation class.
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

## **加入 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/threedformat/) 屬性，為形狀加入 3D 旋轉效果。

要為形狀套用 3D 旋轉效果：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 向投影片新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。  
1. 使用 [set_CameraType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icamera/set_cameratype/) 與 [set_LightType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilightrig/set_lighttype/) 定義 3D 旋轉。  
1. 儲存簡報。

以下 C++ 程式碼示範如何為形狀套用 3D 旋轉效果：

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The 3D rotation effect](3D-rotation-effect.png)

## **控制形狀的黑白顯示模式**

[IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_blackwhitemode/) 方法指定當簡報以黑白模式檢視或處理時，個別形狀的呈現方式。此方法本身不會啟用黑白顯示，也不會在一般彩色模式下改變形狀的填充、線條或其他格式設定。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/blackwhitemode/) 列舉中的值以選取所需行為。例如，`Automatic` 讓渲染程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰階顏色，`BlackWhite` 僅使用黑白，`Black` 與 `White` 強制單色，`Color` 保留原色，`Hidden` 在黑白模式下隱藏形狀，`NotDefined` 表示未為形狀層級指定模式。

以下 C++ 程式碼建立一個彩色形狀，並在黑白顯示模式下使其呈現為灰色：

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// 在彩色模式下保留橙色填充，但在黑白模式下以灰色渲染形狀。
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

在一般彩色模式下，矩形保留橙色填充；在黑白顯示工作流程中，因其模式設為 `Gray`，因此會以灰階顯示。這讓您在保留完整彩色投影片的同時，為列印、預覽或其他遵循黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

以下 C++ 程式碼示範如何重設版面投影片上所有佔位符形狀的定位、大小與格式，將其恢復為預設設定：

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // 重設投影片上在版面配置中具有佔位符的每個形狀。
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題集**

**形狀格式會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與媒體佔用大部分檔案空間，而形狀的參數（如顏色、效果、漸層）僅以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的形狀，以便將它們分組？**

比較每個形狀的關鍵格式屬性—填充、線條與效果設定。若所有對應值相同，即視為樣式相同，並在邏輯上將這些形狀分組，以簡化後續的樣式管理。

**我可以將自訂的形狀樣式集合儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將含有所需樣式的範例形狀存放於模板投影片或 .POTX 範本檔案中。建立新簡報時，開啟該模板，複製所需的樣式形狀，並在需要的地方重新套用其格式。