---
title: Aspose.Slides中的多线程
type: docs
weight: 310
url: /zh/php-java/multithreading/
keywords:
- PowerPoint
- 演示文稿
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片到图像
- PHP
- Java
- Aspose.Slides for PHP via Java
---

## **介绍**

虽然在演示文稿中进行并行工作是可能的（除了解析/加载/克隆），并且大多数时候一切进展顺利，但在多个线程中使用该库时，您可能会得到不正确结果的可能性很小。

我们强烈建议您**不要**在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)实例，因为这可能导致不可预测的错误或无法轻易检测到的故障。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例是**不安全**的。这些操作**不**被支持。如果您需要执行此类任务，必须使用多个单线程进程并行操作——每个进程都应该使用其自己的演示文稿实例。

我们不保证在使用扩展时PHP中的多线程。如果您使用它们，风险自负。