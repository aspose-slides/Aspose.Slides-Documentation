---
title: 取得 C++ 簡報中的段落邊界
linktitle: 段落邊界
type: docs
weight: 43
url: /zh-hant/cpp/paragraph-bounds/
keywords:
- 段落邊界
- 段落座標
- 段落大小
- 文字框
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中檢索段落邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概覽**

本文說明如何取得 Aspose.Slides 中段落的邊界、大小和座標。它展示了如何透過 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 使用 [IParagraph::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getrect/) 取得段落矩形，如何取得表格儲存格文字框內段落的座標，並強調測量單位、文字換行對邊界的影響、像素轉換，以及有效段落格式化值等重要細節。

## **取得段落的矩形座標**

使用 [IParagraph::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getrect/) 取得段落的邊界矩形。

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **取得表格儲存格文字框內段落的大小**

若要取得表格儲存格文字框中 [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 的大小與座標，請使用 [IParagraph::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getrect/)。回傳的矩形是相對於表格儲存格文字框的，因此在需要幻燈片層級座標時，需加上表格位置與儲存格偏移量。

以下範例取得表格儲存格內段落的邊界，並在幻燈片上繪製矩形以視覺化這些邊界：

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**段落座標以何種單位衡量？**

它們以點 (point) 為單位，1 英吋等於 72 點。此單位適用於幻燈片上所有座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。若為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 啟用 [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/set_wraptext/)，文字會依區域寬度斷行，從而改變段落實際的邊界。

**段落座標能可靠地映射到匯出影像的像素嗎？**

可以。使用以下公式將點轉換為像素：像素 = 點 × (DPI / 72)。結果取決於渲染或匯出時選擇的 DPI。

**如何取得「有效」的段落格式參數，並考慮樣式繼承？**

使用 [effective paragraph formatting data structure](/slides/zh-hant/cpp/shape-effective-properties/)；它會回傳縮排、間距、換行、RTL 等最終合併的值。