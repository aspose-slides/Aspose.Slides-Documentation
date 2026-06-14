---
title: "使用 Aspose.Slides for C++ 的 Hello World 應用程式"
type: docs
weight: 80
url: /zh-hant/cpp/hello-world-application-using-aspose-slides/
keywords:
- "Hello World"
- "應用程式"
- "PowerPoint"
- "OpenDocument"
- "簡報"
- "C++"
- "Aspose.Slides"
description: "使用 Aspose.Slides 建立您的第一個 C++ 應用程式，這是一個簡單的 Hello World 範例，讓您開始自動化 PPT、PPTX 與 ODP 簡報。"
---
## **概觀**

本篇文章說明如何使用 Aspose.Slides 建立一個簡單的 **Hello World** PowerPoint 簡報。此範例示範如何建立新的簡報、取得第一張投影片、在指定位置加入矩形 AutoShape、插入包含 **Hello World** 文字的文字框，並調整圖形與文字的格式設定。

它也說明如何透過將文字顏色改為黑色使其可見、將圖形邊框線顏色設為白色以隱藏邊框、移除圖形填充，並將簡報儲存為 PPTX 檔案。

## **建立 Hello World 應用程式的步驟**

依照下列步驟使用 Aspose.Slides for C++ API 建立 **Hello World** 應用程式：

- 建立 Presentation 類別的實例
- 取得簡報中第一張投影片的參考，該投影片於建立 Presentation 時即被建立
- 在投影片的指定位置加入 ShapeType 為 Rectangle 的 AutoShape
- 為 AutoShape 加入包含 Hello World 為預設文字的 TextFrame
- 將文字顏色改為黑色，因預設為白色且在白色背景的投影片上不可見
- 將圖形的線條顏色設為白色，以隱藏圖形邊框
- 移除圖形的預設填充格式
- 最後，使用 Presentation 物件將簡報寫入所需的檔案格式

以下示範了上述步驟的實作範例。

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // 取得第一張投影片
    auto slide = pres->get_Slides()->idx_get(0);

    // 新增矩形類型的 AutoShape
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // 為矩形新增 TextFrame
    shape->AddTextFrame(u"Hello World");

    // 將文字顏色變更為黑色（預設為白色）
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // 將矩形的線條顏色變更為白色
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // 移除圖形的任何填充格式
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // 將簡報儲存至磁碟
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```