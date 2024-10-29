---
title: 比较幻灯片
type: docs
weight: 50
url: /zh/cpp/compare-slides/
---

## **比较两个幻灯片**
IBaseSlide 接口和 BaseSlide 类中添加了 Equals 方法。对于结构和静态内容相同的幻灯片 / 布局幻灯片 / 母版幻灯片，它返回 true。

如果所有形状、样式、文本、动画和其他设置等都相同，则两个幻灯片相等。比较不考虑唯一标识符值，例如 SlideId 和动态内容，例如日期占位符中的当前日期值。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}