---
title: 文字方塊
type: docs
weight: 40
url: /zh-hant/cpp/examples/elements/text-box/
keywords:
- 程式碼範例
- 文字方塊
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中使用文字方塊：使用 C++ 為 PPT、PPTX 與 ODP 簡報新增、格式化、對齊、換行、自動調整大小與樣式設定文字。"
---
在 Aspose.Slides 中，**文字方塊** 以 `AutoShape` 來表示。幾乎任何形狀都可以包含文字，但一般的文字方塊沒有填充或邊框，僅顯示文字。

本指南說明如何以程式方式新增、存取和移除文字方塊。

## **新增文字方塊**

文字方塊只是一個沒有填充或邊框且包含格式化文字的 `AutoShape`。以下說明如何建立它：

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 建立一個矩形形狀（預設為有填充、含邊框且沒有文字）。
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // 移除填充與邊框，使其看起來像典型的文字方塊。
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // 設定文字格式。
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // 指定實際的文字內容。
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **注意：** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以作為文字方塊使用。

## **依內容存取文字方塊**

若要找出所有包含特定關鍵字（例如「Slide」）的文字方塊，請遍歷形狀並檢查其文字：

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // 只有 AutoShape 可以包含可編輯的文字。
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // 對符合的文字方塊執行某些操作。
            }
        }
    }

    presentation->Dispose();
}
```

## **依內容移除文字方塊**

此範例會找出並刪除第一張投影片中所有包含特定關鍵字的文字方塊：

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **提示：** 在遍歷期間修改形狀集合前，請務必先建立該集合的副本，以避免集合修改錯誤。