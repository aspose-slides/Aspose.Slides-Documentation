---
title: 版面投影片
type: docs
weight: 20
url: /zh-hant/cpp/examples/elements/layout-slide/
keywords:
- 程式碼範例
- 版面投影片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中精通版面投影片：選取、套用及自訂投影片版面、佔位元及母片，並提供 PPT、PPTX 與 ODP 簡報的 C++ 範例。"
---
本文示範如何在 Aspose.Slides for C++ 中使用 **Layout Slides**。版面投影片定義了普通投影片所繼承的設計與格式。您可以新增、存取、克隆與移除版面投影片，亦可清除未使用的版面以減少簡報檔案大小。

## **新增版面投影片**

您可以建立自訂版面投影片，以定義可重複使用的格式。例如，您可以加入一個文字方塊，讓使用此版面的所有投影片都顯示該文字方塊。

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // 建立一個使用空白版面類型且具自訂名稱的版面投影片。
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // 新增一個文字方塊至版面投影片。
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // 使用此版面新增兩張投影片；兩者皆會繼承版面的文字。
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡**Note 1:** 版面投影片充當個別投影片的範本。您只需定義一次共用元素，即可在多張投影片中重複使用。

> 💡**Note 2:** 當您在版面投影片上加入形狀或文字時，所有基於該版面的投影片將自動顯示這些共用內容。  
> 以下螢幕截圖顯示兩張投影片，各自繼承同一版面投影片中的文字方塊。

![版面投影片繼承內容](layout-slide-result.png)

## **存取版面投影片**

版面投影片可透過索引或版面類型（例如 `Blank`、`Title`、`SectionHeader` 等）取得。

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 依索引存取版面投影片。
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // 依類型存取版面投影片。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **移除版面投影片**

若版面投影片不再需要，可將其移除。

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 依類型取得版面投影片並將其移除。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **移除未使用的版面投影片**

為了降低簡報檔案大小，您可能需要移除未被任何普通投影片使用的版面投影片。

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // 自動移除所有未被任何投影片參照的版面投影片。
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **克隆版面投影片**

您可以使用 `AddClone` 方法複製版面投影片。

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // 依類型取得現有的版面投影片。
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // 將版面投影片克隆至版面投影片集合的末端。
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅**Summary:** 版面投影片是管理投影片一致格式的強大工具。Aspose.Slides 提供完整的建立、管理與最佳化版面投影片的控制能力。