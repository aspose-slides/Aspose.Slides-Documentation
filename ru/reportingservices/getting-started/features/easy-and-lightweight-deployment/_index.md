---
title: Лёгкое и экономичное развертывание
type: docs
weight: 50
url: /ru/reportingservices/easy-and-lightweight-deployment/
description: "Узнайте, как развертывается Aspose.Slides for Reporting Services: одна сборка в папке bin сервера отчетов, зарегистрированная в конфигурации сервера отчетов."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services — это [расширение визуализации](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) для Microsoft SQL Server Reporting Services и Power BI Report Server.
Aspose.Slides for Reporting Services поставляется в виде одного MSI‑установщика, который можно установить на компьютеры с поддерживаемым сервером отчетов, 32‑битным или 64‑битным; см. [Системные требования](/slides/ru/reportingservices/system-requirements/).

Также легко развернуть и управлять Aspose.Slides for Reporting Services вручную, поскольку он состоит только из одной .NET‑сборки *Aspose.Slides* *.ReportingServices.dll* , полностью написанной на C#, совместимой с CLS и содержащей только безопасный управляемый код.

{{% /alert %}}

ZIP‑файл содержит две сборки Aspose.Slides.ReportingServices.dll для серверов отчетов:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll — построена для Microsoft SQL Server 2005 и .NET Framework 2.0 (для x86 и x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll — построена для Microsoft SQL Server 2008 и новее, Power BI Report Server и .NET Framework 2.0 (для x86 и x64)

MSI‑установщик устанавливает те же две сборки и выбирает нужную для каждого экземпляра сервера отчетов. [Установить вручную](/slides/ru/reportingservices/install-manually/) перечисляет каждый файл в ZIP‑загрузке.

При установке Aspose.Slides.ReportingServices.dll копируется в каталог ReportServer\bin, а конфигурационный файл обновляется, чтобы Reporting Services знал о новом расширении рендеринга. Эти действия выполняет установщик Aspose.Slides for Reporting Services, но их также можно выполнить вручную, как описано далее в этой документации.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Рисунок**: Aspose.Slides.ReportingServices.dll копируется в каталог **ReportServer\bin**.