---
title: Aspose.Slides for PHP via Java 的多线程
linktitle: 多线程
type: docs
weight: 310
url: /zh/php-java/multithreading/
keywords:
- 多线程
- 多个线程
- 并行工作
- 转换幻灯片
- 幻灯片转图片
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java 的多线程提升了 PowerPoint 和 OpenDocument 的处理性能。探索高效演示工作流的最佳实践。"
---

## **介绍**

虽然可以对演示文稿进行并行操作（除了解析/加载/克隆之外），且大多数情况下都能正常工作，但在多线程使用库时仍有小概率会得到错误的结果。

我们强烈建议您 **不要** 在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)实例，因为这可能导致不可预测的错误或故障，且不易被检测到。

在多线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例是 **不安全** 的。这类操作 **不受支持**。如果需要执行此类任务，必须使用多个单线程进程并行这些操作，并且每个进程应使用其自己的演示文稿实例。

在 PHP 中使用扩展时，我们不保证多线程的安全性。如果使用这些扩展，请自行承担风险。

## **常见问题**

**我是否需要在每个线程中调用许可证设置？**

不需要。只需在进程/应用域启动线程之前调用一次即可。如果[license setup](/slides/zh/php-java/licensing/)可能被并发调用（例如在惰性初始化期间），请对该调用进行同步，因为许可证设置方法本身不是线程安全的。

**我可以在线程之间传递 `Presentation` 或 `Slide` 对象吗？**

不建议在线程之间传递“活动”的演示文稿对象：请为每个线程使用独立实例，或为每个线程预先创建单独的演示文稿/幻灯片容器。此做法遵循不在多个线程之间共享单一演示文稿实例的一般建议。

**在每个线程拥有自己的 `Presentation` 实例的前提下，将导出并行化为不同格式（PDF、HTML、图像）是否安全？**

是的。只要使用独立的实例并指定不同的输出路径，此类任务通常可以正确并行化；请避免共享演示文稿对象和共享 I/O 流。

**在多线程环境下，全球字体设置（文件夹、替代）应如何处理？**

在启动线程之前初始化所有全局[font settings](/slides/zh/php-java/powerpoint-fonts/)，并且在并行工作期间不要更改它们。这可以消除访问共享字体资源时的竞争。