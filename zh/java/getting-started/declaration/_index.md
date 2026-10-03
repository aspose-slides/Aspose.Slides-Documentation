---
title: 安全管理器要求
type: docs
weight: 190
url: /zh/java/declaration/
keywords:
- 安全管理器
- 安全策略
- AllPermission
- 权限
- 沙箱
- JDK 24
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Java 23 及更早版本中，Aspose.Slides for Java 以及调用它的代码需要哪些安全管理器权限，以及为何在 Java 24 及以后无需进行任何配置。"
---
## **概述**

Java 安全管理器根据安全策略限制代码的行为。Java 17 已将其标记为过时以便移除（[JEP 411](https://openjdk.org/jeps/411)），而 Java 24 已永久禁用它（[JEP 486](https://openjdk.org/jeps/486)）。本文说明当应用程序仍在使用安全管理器时 Aspose.Slides for Java 需要哪些设置。如果您的应用程序未启用安全管理器（默认情况），则无需进行任何配置。

## **Java 23 及更早版本**

当启用安全管理器时，安全策略必须将以下权限授予 Aspose.Slides JAR 文件以及调用它的应用程序代码：

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides 读取系统属性。
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides 读取字体文件和其他文件。
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides 启动操作系统程序，例如 Windows 上的 `reg` 和 Linux 上的 `fc-match`。
- 对应用程序保存文件的文件夹，使用 `java.io.FilePermission` 并指定 `write` 动作。

仅为 JAR 文件授予这些权限还不够：调用 Aspose.Slides 的代码也需要这些权限。为两者都授予 `java.security.AllPermission` 也可行。

如果没有读取系统属性或启动程序的权限，Aspose.Slides 在首次使用时会失败：创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 对象时会抛出 `ExceptionInInitializerError`。如果没有读取字体文件的权限，将演示文稿保存为 PDF 时会出现错误 “Cannot find any fonts installed on the system”。

## **Java 24 及以后版本**

在 Java 24 及以后版本，无法启用安全管理器，因此无需授予权限。Aspose.Slides 以运行您应用程序的账户权限执行。若需限制应用程序的访问范围，OpenJDK 项目建议使用 JDK 之外的技术，如容器、hypervisor 和操作系统沙箱功能。参见 [JEP 486](https://openjdk.org/jeps/486)。

## **常见问题**

**我可以在使用受限安全管理器策略运行应用程序的环境中使用 Aspose.Slides 吗？**

仅当策略同时授予上述权限给 Aspose.Slides 以及调用它的代码时才可以。这些权限包括读取所有文件和启动任何程序。