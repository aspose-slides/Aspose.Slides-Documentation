---
title: 節
type: docs
weight: 90
url: /zh-hant/cpp/examples/elements/section/
keywords:
- 程式碼範例
- 節
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理投影片節：建立、重新命名、重新排序與分組投影片，並提供 PPT、PPTX 與 ODP 的 C++ 範例。"
---
示範如何以程式方式使用 **Aspose.Slides for C++** 來管理簡報的節—新增、存取、移除與重新命名。

## **新增節**

建立一個從特定投影片開始的節。

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 指定標記此節開始的投影片。
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **存取節**

從簡報中讀取節的資訊。

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // 依索引存取節。
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **移除節**

刪除先前新增的節。

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // 移除第一個節。
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **重新命名節**

變更現有節的名稱。

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```