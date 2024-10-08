---
title: 比较幻灯片
type: docs
weight: 50
url: /androidjava/compare-slides/
---

## **比较两个幻灯片**
已将 Equals 方法添加到 [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) 接口和 [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide) 类。对于结构和静态内容相同的幻灯片/布局和幻灯片/母版幻灯片，它返回 true。

如果所有形状、样式、文本、动画和其他设置等都相等，则两个幻灯片相等。比较不考虑唯一标识符值，例如 SlideId 和动态内容，例如日期占位符中的当前日期值。

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d 与 SomePresentation2 MasterSlide#%d 相等", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```