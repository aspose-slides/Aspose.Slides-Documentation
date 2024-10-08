---
title: 可中断库支持
type: docs
weight: 120
url: /php-java/support-for-interruptable-library/
---

## **可中断库**
现在在 Aspose.Slides 中添加了 InterruptionToken 结构和 InterruptionTokenSource 类。这些类型支持对长时间运行任务的中断，例如反序列化、序列化或渲染。InterruptionTokenSource 代表传递给 **ILoadOptions.InterruptionToken** 的令牌或多个令牌的源。当设置 ILoadOptions.InterruptionToken 并将此 LoadOptions 实例传递给 Presentation 构造函数时，与此 Presentation 相关的任何长时间运行任务将在调用 InterruptionTokenSource.Interrupt 方法时被中断。

以下代码片段演示了正在运行的任务的中断。

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}