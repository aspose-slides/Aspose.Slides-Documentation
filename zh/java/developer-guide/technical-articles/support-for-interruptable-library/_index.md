---
title: 可中断库的支持
type: docs
weight: 120
url: /zh/java/support-for-interruptable-library/
---

## **可中断库**
现在在 Aspose.Slides 中添加了 InterruptionToken 结构和 InterruptionTokenSource 类。这些类型支持中断长时间运行的任务，例如反序列化、序列化或渲染。InterruptionTokenSource 表示传递给 **ILoadOptions.InterruptionToken** 的令牌或多个令牌的来源。当 ILoadOptions.InterruptionToken 被设置并且此 LoadOptions 实例传递给 Presentation 构造函数时，与此 Presentation 相关的任何长时间运行的任务将在调用 InterruptionTokenSource.Interrupt 方法时被中断。

下面的代码片段演示了如何中断运行中的任务。

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}