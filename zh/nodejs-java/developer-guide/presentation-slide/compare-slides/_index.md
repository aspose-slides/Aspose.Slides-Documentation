---
title: 比较幻灯片
type: docs
weight: 50
url: /zh/nodejs-java/compare-slides/
---

## **比较两个幻灯片**
已向 [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) 类和 [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) 类添加了 Equals 方法。当幻灯片/布局以及幻灯片/母版幻灯片在结构和静态内容上完全相同时，返回 true。

当所有形状、样式、文本、动画以及其他设置等全部相等时，两张幻灯片被视为相等。比较时不考虑唯一标识符的值，例如 SlideId，亦不考虑动态内容，例如日期占位符中的当前日期值。
```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **常见问题**

**幻灯片被隐藏会影响幻灯片本身的比较吗？**

[Hidden status](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) 是演示/播放层面的属性，而非视觉内容。两个特定幻灯片的相等性由其结构和静态内容决定；仅仅因为幻灯片被隐藏并不会导致幻灯片不同。

**超链接及其参数会被考虑吗？**

会。超链接是幻灯片静态内容的一部分。如果 URL 或超链接动作不同，通常会被视为静态内容的差异。

**如果图表引用了外部 Excel 文件，是否会考虑该文件的内容？**

不会。比较仅基于幻灯片本身进行。外部数据源通常不会在比较时读取；只考虑幻灯片结构和静态状态中包含的内容。