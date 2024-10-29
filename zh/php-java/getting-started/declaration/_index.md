---
title: 声明
type: docs
weight: 60
url: /zh/php-java/declaration/
---

{{% alert color="primary" %}} 

所有 Aspose Java 组件都需要完全信任的权限设置。原因是，Aspose Java 组件需要访问注册表设置、系统文件以及虚拟目录以外的其他文件，进行某些操作，如解析字体等。此外，Aspose Java 组件基于核心 Java 系统类，这在很多情况下也需要完全信任的权限设置。

{{% /alert %}} 

托管来自不同公司的多个应用程序的互联网服务提供商大多会强制执行中等信任安全级别：

- OleDbPermission 不可用。这意味着您无法使用 ADO.NET 受管理的 OLE DB 数据提供程序访问数据库。
- EventLogPermission 不可用。这意味着您无法访问 Windows 事件日志。
- ReflectionPermission 不可用。这意味着您无法使用反射。
- RegistryPermission 不可用。这意味着您无法访问注册表。
- WebPermission 受到限制。这意味着您的应用程序只能与您在 <trust> 元素中定义的地址或地址范围进行通信。
- FileIOPermission 受到限制。这意味着您只能访问应用程序的虚拟目录层次结构中的文件。

{{% alert color="primary" %}} 

由于上述原因，Aspose Java 组件无法在授予非完全信任权限设置的服务器上使用。

{{% /alert %}}