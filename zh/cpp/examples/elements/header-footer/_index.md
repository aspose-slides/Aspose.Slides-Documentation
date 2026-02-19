---
title: 页眉页脚
type: docs
weight: 220
url: /zh/cpp/examples/elements/header-footer/
keywords:
- 代码示例
- 页眉
- 页脚
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 控制幻灯片的页眉和页脚：在 PPT、PPTX 和 ODP 中通过 C++ 示例添加日期、幻灯片编号和自定义文本。"
---
本文演示如何使用 **Aspose.Slides for C++** 添加页脚并更新日期和时间占位符。

## **添加页脚**

向幻灯片的页脚区域添加文本并使其可见。

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

## **更新日期和时间**

修改幻灯片上的日期和时间占位符。

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