---
title: 在 C++ 中比较演示文稿幻灯片
linktitle: 比较幻灯片
type: docs
weight: 50
url: /zh/cpp/compare-slides/
keywords:
- 比较幻灯片
- 幻灯片比较
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 以编程方式比较 PowerPoint 和 OpenDocument 演示文稿。快速在代码中识别幻灯片差异。"
---

## **比较两个幻灯片**
已在 `IBaseSlide` 接口和 `BaseSlide` 类中添加 `Equals` 方法。该方法在结构和静态内容相同的幻灯片、布局幻灯片或母版幻灯片上返回 `true`。

当所有形状、样式、文本、动画及其他设置均一致时，两个幻灯片被视为相等。比较不考虑唯一标识符值，例如 `SlideId`，也不考虑动态内容，例如日期占位符中的当前日期值。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**幻灯片被隐藏是否会影响对幻灯片本身的比较？**

[Hidden status](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) 是演示/播放层级的属性，而非视觉内容。两个特定幻灯片的等价性由其结构和静态内容决定，单纯的隐藏状态并不会使幻灯片被视为不同。

**是否会考虑超链接及其参数？**

会。超链接是幻灯片静态内容的一部分。如果 URL 或超链接操作不同，通常会被视为静态内容的差异。

**如果图表引用了外部 Excel 文件，是否会考虑该文件的内容？**

不会。比较是基于幻灯片本身进行的。外部数据源通常不会在比较时读取；仅考虑幻灯片结构和静态状态中存在的内容。