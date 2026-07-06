---
title: 從 C++ 簡報取得文字片段邊界
linktitle: 片段邊界
type: docs
weight: 47
url: /zh-hant/cpp/portion-bounds/
keywords:
- 文字片段邊界
- 文字片段
- 文字部分
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中取得文字片段的邊界。"
---
## **概述**

文字片段代表段落內的特定文字子串，並允許您獨立於周圍內容對該子串進行操作。在 Aspose.Slides 中，當您需要取得文字子串的邊界、僅對段落的一部分套用格式，或在更細緻的層級控制文字行為時，可使用片段。

本文說明如何使用 [IPortion::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/getrect/) 取得片段的邊界矩形，亦說明如何使用 [IPortion::GetCoordinates](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/getcoordinates/) 取得片段起始位置的座標。此外，還闡述了常見的片段相關情境，例如將超連結套用至單一文字子串、瞭解格式如何透過片段、段落、文字框與佈景主題的繼承而解析，以及處理指定字型不存在的情況。

## **取得文字片段的邊界**

使用 [IPortion::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/getrect/) 取得文字片段的邊界矩形：

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **取得文字片段的座標**

使用 [IPortion::GetCoordinates](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/getcoordinates/) 取得文字片段起始位置的座標：

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **常見問題**

**我可以只在單一段落中的文字部分套用超連結嗎？**

是的，您可以將[指派超連結](/slides/zh-hant/cpp/manage-hyperlinks/)給單一片段；只有該子串可點擊，而不是整個段落。

**樣式繼承如何運作：片段會覆寫什麼，而段落或文字框會提供什麼？**

片段層級的屬性具有最高優先權。如果屬性未在 [IPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/) 上設定，Aspose.Slides 會從 [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 取得。若該處亦未設定，則會使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 或 [theme](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.theme/theme/) 的樣式。

**如果片段指定的字型在目標機器或伺服器上不存在，會發生什麼？**

會套用[字型替代規則](/slides/zh-hant/cpp/font-selection-sequence/)。文字可能重新排版：度量、斷字與寬度都可能改變，這對精確定位很重要。

**我能為片段設定特定的文字填充透明度或漸層，而不影響段落的其他部分嗎？**

是的，於 [IPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/) 層級的文字顏色、填充與透明度可與相鄰的片段不同。