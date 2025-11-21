---
title: 声明
type: docs
weight: 110
url: /zh/net/declaration/
keywords:
- 声明
- 组件
- Full Trust 权限
- 注册表设置
- 系统文件
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 的信任要求、权限和托管限制，以便您能够安全地在服务器上部署处理 PPT、PPTX 和 ODP 的应用程序。"
---

{{% alert color="primary" %}}
所有 Aspose .NET 组件都需要 Full Trust 权限集，因为它们有时必须访问注册表设置、系统文件以及存储在其他位置（虚拟目录之外）的文件，以执行某些操作（例如解析字体）。此外，Aspose .NET 组件基于核心 .NET 系统类，在许多情况下也需要 Full Trust 权限集。
{{% /alert %}}

Internet Service Providers（托管多家公司多个应用的服务提供商）通常强制使用 Medium Trust 安全级别。在 .NET 2.0 环境中，此安全级别会施加以下限制：

- OleDbPermission 不可用。这意味着您无法使用 ADO.NET 托管的 OLE DB 数据提供程序访问数据库。
- EventLogPermission 不可用。这意味着您无法访问 Windows 事件日志。
- ReflectionPermission 不可用。这意味着您无法使用反射。
- RegistryPermission 不可用。这意味着您无法访问注册表。
- WebPermission 受限。这意味着您的应用程序只能与您在 <trust> 元素中定义的地址或地址范围通信。
- FileIOPermission 受限。这意味着您只能访问位于应用程序虚拟目录层次结构中的文件。

{{% alert color="primary" %}}
鉴于上述原因，Aspose .NET 组件只能在授予 Full Trust 权限集的服务器上使用。
{{% /alert %}}