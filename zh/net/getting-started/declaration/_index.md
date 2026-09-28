---
title: 信任级别要求
type: docs
weight: 190
url: /zh/net/declaration/
keywords:
- 信任级别
- 完全信任权限
- 部分信任
- 中等信任
- 代码访问安全
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 所需的代码访问安全信任级别：在 .NET Framework 上需要完全信任，在 .NET 6 及更高版本上无需信任设置。"
---
## **概述**

代码访问安全（CAS）信任级别仅在 .NET Framework 中存在。本文说明它们对 Aspose.Slides for .NET 的意义：该库在 .NET Framework 上需要全信任，而在 .NET 6 及更高版本上没有可配置的信任级别。

## **.NET Framework**

Aspose.Slides 在 .NET Framework 上需要全信任。它无法在部分信任环境下运行，例如配置为 Medium Trust (`<trust level="Medium" />`) 的 ASP.NET 应用程序：创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 对象会导致 `SecurityException`。

Microsoft 不再将 ASP.NET 部分信任视为将应用程序相互隔离的方式，并建议改为在独立的应用程序池中运行应用程序。参见 [ASP.NET 部分信任不能保证应用隔离](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation)。

## **.NET 6 and Later**

在 .NET 6 及更高版本上，代码访问安全不可用，因此没有可授予的信任级别。Aspose.Slides 以运行您应用程序的账户权限执行。若要限制应用程序的访问范围，Microsoft 建议使用操作系统边界，例如用户账户、容器或虚拟机。参见 [代码访问安全 (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas)。

## **FAQ**

**我可以在运行 ASP.NET 中等信任的托管提供商上使用 Aspose.Slides 吗？**

在中等信任下不可行。在 .NET Framework 上，使用 Aspose.Slides 的应用程序必须以全信任运行。