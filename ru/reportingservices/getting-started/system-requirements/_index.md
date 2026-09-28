---
title: Системные требования
type: docs
weight: 15
url: /ru/reportingservices/system-requirements/
keywords:
- системные требования
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Узнайте, какие серверы отчетов, издания и версия .NET Framework требуются Aspose.Slides for Reporting Services перед установкой."
---
## **Обзор**

Aspose.Slides for Reporting Services работает внутри сервера отчетов как расширение рендеринга. Эта страница перечисляет, что необходимо установить на машине сервера отчетов перед [install](/slides/ru/reportingservices/installing-aspose-slides-for-reporting-services/). Microsoft PowerPoint и Microsoft Office не требуются.

## **Поддерживаемые серверы отчетов**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, для постраничных (RDL) отчетов

Поддерживаются как 32‑битные, так и 64‑битные серверы отчетов. SQL Server 2005 использует собственную сборку расширения; все более поздние версии и Power BI Report Server используют одну и ту же сборку. [Install Manually](/slides/ru/reportingservices/install-manually/) показывает, какой файл нужно скопировать.

Если версия вашего сервера отчетов отсутствует в этом списке, задайте вопрос на [free support forum](https://forum.aspose.com/c/slides/ru/11) перед развертыванием.

## **Издания сервера отчетов**

Для SQL Server 2016 Reporting Services и более новых версий, а также для Power BI Report Server, Microsoft поддерживает расширения рендеринга в изданиях Enterprise, Standard, Developer и Evaluation; издания Web и Express их не поддерживают. См. [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Установщик MSI пропускает экземпляры Express издания SQL Server 2016 и более ранних.

## **.NET Framework**

.NET Framework 3.5 должен быть установлен на машине сервера отчетов. Сборки расширения построены для среды выполнения .NET Framework 2.0, и установщик MSI прекращает работу с сообщением, если .NET Framework 3.5 отсутствует. В Windows Server добавьте **.NET Framework 3.5 Features** в мастере добавления ролей и компонентов; см. [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Разрешения**

Установка расширения изменяет файлы в папке сервера отчетов, поэтому оба пути установки требуют прав локального администратора. Если запустить установщик MSI без этих прав, он предложит перезапуститься с привилегиями администратора.

## **ЧаВо**

**Нужен ли Microsoft PowerPoint на сервере отчетов?**

Нет. Расширение создает презентации самостоятельно; ни PowerPoint, ни Microsoft Office не нужно устанавливать.

**Могу ли я установить расширение на издание Express?**

Нет. Издания Express не поддерживают расширения рендеринга. Установщик MSI скрывает экземпляры Express SQL Server 2016 и более ранних; в более новых версиях не выбирайте экземпляр Express.

**Какие форматы расширение добавляет в список экспорта?**

PPT, PPS, PPTX, PPSX, ODP и XPS. Смотрите [Supported File Formats](/slides/ru/reportingservices/supported-file-formats/).