---
title: Trust Level Requirements
type: docs
weight: 190
url: /net/declaration/
keywords:
- trust level
- Full Trust permission
- partial trust
- Medium Trust
- code access security
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Which code access security trust level Aspose.Slides for .NET needs: full trust on .NET Framework, and no trust setting on .NET 6 and later."
---

## **Overview**

Code access security (CAS) trust levels exist only in .NET Framework. This article explains what they mean for Aspose.Slides for .NET: the library needs full trust on .NET Framework, and on .NET 6 and later there is no trust level to configure.

## **.NET Framework**

Aspose.Slides requires full trust on .NET Framework. It does not run under partial trust, such as an ASP.NET application configured for Medium Trust (`<trust level="Medium" />`): creating a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object fails with a `SecurityException`.

Microsoft no longer treats ASP.NET partial trust as a way to isolate applications from each other, and recommends running applications in separate application pools instead. See [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

Code access security is not available on .NET 6 and later, so there is no trust level to grant. Aspose.Slides runs with the permissions of the account that runs your application. To restrict what an application can access, Microsoft recommends operating-system boundaries, such as user accounts, containers, or virtual machines. See [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Can I use Aspose.Slides with a hosting provider that runs ASP.NET applications in Medium Trust?**

Not in Medium Trust. On .NET Framework, the application that uses Aspose.Slides must run with full trust.
