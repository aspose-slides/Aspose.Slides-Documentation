---
title: Требования к уровню доверия
type: docs
weight: 190
url: /ru/net/declaration/
keywords:
- уровень доверия
- разрешение полного доверия
- частичное доверие
- Medium Trust
- безопасность кода доступа
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Какой уровень доверия Code Access Security требуется Aspose.Slides for .NET: полный доверие в .NET Framework и отсутствие настройки доверия в .NET 6 и более новых версиях."
---
## **Обзор**

Уровни доверия Code Access Security (CAS) существуют только в .NET Framework. В этой статье объясняется, что они означают для Aspose.Slides для .NET: библиотека требует полного доверия в .NET Framework, а в .NET 6 и более новых версиях уровень доверия не настраивается.

## **.NET Framework**

Aspose.Slides требует полного доверия в .NET Framework. Она не работает в режиме частичного доверия, например в ASP.NET‑приложении, настроенном на Medium Trust (`<trust level="Medium" />`): создание объекта [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) приводит к `SecurityException`.

Microsoft больше не рассматривает частичное доверие ASP.NET как способ изоляции приложений друг от друга и рекомендует запускать приложения в отдельных пулах приложений. См. [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 и позже**

Code Access Security недоступен в .NET 6 и более новых версиях, поэтому уровень доверия не предоставляется. Aspose.Slides работает с разрешениями учетной записи, под которой запущено ваше приложение. Чтобы ограничить доступ приложения, Microsoft рекомендует использовать границы операционной системы, такие как учетные записи пользователей, контейнеры или виртуальные машины. См. [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Могу ли я использовать Aspose.Slides у хостинг‑провайдера, который запускает ASP.NET‑приложения в режиме Medium Trust?**

Нет, в режиме Medium Trust. В .NET Framework приложение, использующее Aspose.Slides, должно работать с полным доверием.