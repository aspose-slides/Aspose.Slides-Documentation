---
title: 声明
type: docs
weight: 110
url: /net/declaration/
---

{{% alert color="primary" %}} 

所有 Aspose .NET 组件都需要完全信任权限集，因为它们有时需要访问注册表设置、系统文件以及存储在其他位置（除了虚拟目录）中的文件（例如，解析字体）。此外，Aspose .NET 组件基于核心 .NET 系统类，在许多情况下需要完全信任权限集。 

{{% /alert %}} 

托管来自不同公司的多个应用程序的互联网服务提供商大多强制执行中等信任安全级别。在 .NET 2.0 的情况下，这种安全级别适用以下限制： 

- OleDbPermission 不可用。这意味着您无法使用 ADO.NET 管理的 OLE DB 数据提供程序访问数据库。
- EventLogPermission 不可用。这意味着您无法访问 Windows 事件日志。
- ReflectionPermission 不可用。这意味着您无法使用反射。
- RegistryPermission 不可用。这意味着您无法访问注册表。
- WebPermission 受限。这意味着您的应用程序只能与您在 <trust> 元素中定义的地址或地址范围通信。
- FileIOPermission 受限。这意味着您只能访问应用程序虚拟目录层次结构中的文件。

{{% alert color="primary" %}} 

由于上述原因，Aspose .NET 组件只能在授予完全信任权限集的服务器上使用。 

{{% /alert %}}