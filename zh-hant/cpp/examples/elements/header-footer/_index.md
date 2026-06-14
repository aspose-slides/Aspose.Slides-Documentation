---
title: 頁眉頁腳
type: docs
weight: 220
url: /zh-hant/cpp/examples/elements/header-footer/
keywords:
- 程式碼範例
- 頁眉
- 頁腳
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 控制投影片的頁眉與頁腳：在 PPT、PPTX 與 ODP 中加入日期、投影片編號和自訂文字，並提供 C++ 範例。"
---
本篇文章示範如何使用 **Aspose.Slides for C++** 新增頁腳並更新日期與時間佔位符。

## **新增頁腳**

在投影片的頁腳區域加入文字並使其可見。

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **更新日期與時間**

修改投影片上的日期與時間佔位符。

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```