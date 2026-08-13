---
title: 声明
type: docs
weight: 60
url: /zh/java/declaration/
keywords:
- 声明
- 组件
- Full Trust 权限
- 注册表设置
- 系统文件
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的信任要求、权限和托管限制，以便您能够安全地在服务器上部署处理 PPT、PPTX 和 ODP 的应用程序。"
---
{{% alert color="info" %}} 

所有 Aspose Java 组件都需要 Full Trust 权限集。原因是 Aspose Java 组件需要访问注册表设置、除虚拟目录之外的系统文件，以执行诸如解析字体等特定操作。此外，Aspose Java 组件基于核心 Java 系统类，在许多情况下也需要 Full Trust 权限集。 

{{% /alert %}} 

托管多个不同公司应用的互联网服务提供商通常执行 Medium Trust 安全级别： 

- OleDbPermission 不可用。这意味着您无法使用 ADO.NET 托管的 OLE DB 数据提供程序访问数据库。  
- EventLogPermission 不可用。这意味着您无法访问 Windows 事件日志。  
- ReflectionPermission 不可用。这意味着您无法使用反射。  
- RegistryPermission 不可用。这意味着您无法访问注册表。  
- WebPermission 受限。这意味着您的应用程序只能与您在 <trust> 元素中定义的地址或地址范围进行通信。  
- FileIOPermission 受限。这意味着您只能访问应用程序虚拟目录层次结构中的文件。  

{{% alert color="info" %}} 

鉴于上述原因，Aspose Java 组件不能在授予除 Full Trust 之外的权限集的服务器上使用。 

{{% /alert %}}