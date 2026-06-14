---
title: 在 C++ 簡報中取得段落邊界
linktitle: 段落
type: docs
weight: 60
url: /zh-hant/cpp/paragraph/
keywords:
- 段落邊界
- 文字區塊邊界
- 段落座標
- 區塊座標
- 段落大小
- 文字區塊大小
- 文字框
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中取得段落與文字區塊的邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概觀**

本文說明如何取得 Aspose.Slides 中段落與文字區塊的邊界、大小與座標。它展示了如何使用 `GetRect()` 取得 `TextFrame` 中段落的矩形、如何取得表格儲存格文字框內段落與區塊的座標，並強調了測量單位、文字換列對邊界的影響、像素轉換以及有效段落格式化值等重要細節。

## **在 TextFrame 中取得段落與區塊座標**
使用 Aspose.Slides for C++，開發人員現在可以取得 TextFrame 的段落集合中段落的矩形座標。它也允許取得段落的區塊集合中區塊的座標。在本主題中，我們將透過範例說明如何取得段落的矩形座標以及段落內區塊的位置。

## **取得段落的矩形座標**
已新增方法 **GetRect()**，可取得段落的邊界矩形。

``` cpp
// 實例化一個代表簡報檔案的 Presentation 物件
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **取得表格儲存格 TextFrame 中段落與區塊的大小**
若要取得表格儲存格文字框中[Portion](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.portion)或[Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.paragraph)的大小與座標，可使用[IPortion::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9)與[IParagraph::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t)方法。

以下範例程式碼示範上述操作：

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **常見問題**

**段落與文字區塊的座標以何種單位返回？**

以點 (points) 為單位，1 英吋 = 72 點。此單位適用於投影片上的所有座標與尺寸。

**文字換列會影響段落的邊界嗎？**

是。若在[TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframe/)中啟用[wrapping](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframeformat/set_wraptext/)，文字會依區域寬度斷行，從而改變段落的實際邊界。

**段落座標能可靠地映射到匯出影像的像素嗎？**

可以。可使用以下公式將點轉換為像素：pixels = points × (DPI / 72)。結果取決於渲染/匯出時所選擇的 DPI。

**如何取得「有效」的段落格式參數，並考慮樣式繼承？**

使用[effective paragraph formatting data structure](/slides/zh-hant/cpp/shape-effective-properties/)，它會回傳縮排、間距、換列、RTL 等最終合併的值。