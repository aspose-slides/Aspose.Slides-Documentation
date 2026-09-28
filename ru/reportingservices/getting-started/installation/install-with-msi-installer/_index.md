---
title: Установка с MSI‑установщиком
type: docs
weight: 20
url: /ru/reportingservices/install-with-msi-installer/
keywords:
- MSI‑установщик
- установка
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Установите Aspose.Slides for Reporting Services с помощью его MSI‑установщика: что требуется от установщика, какие изменения он вносит в каждый экземпляр сервера отчетов и как проверить результат."
---
## **Установка**

MSI‑установщик — самый простой способ установить Aspose.Slides for Reporting Services. Требуется .NET Framework 3.5 и права администратора на сервере отчетов; см. [System Requirements](/slides/ru/reportingservices/system-requirements/).

1. Скачайте MSI‑установщик *Aspose.Slides for Reporting Services XX.XX* со [download page](https://releases.aspose.com/slides/ru/reportingservices/) и скопируйте его на сервер отчетов.
2. Запустите его от имени администратора. Если .NET Framework 3.5 отсутствует, установщик останавливается с сообщением; установите компоненты .NET Framework 3.5 и запустите его снова.
3. Примите лицензионное соглашение.
4. На странице **Custom Setup** дерево функций показывает каждый экземпляр SQL Server Reporting Services и Power BI Report Server, обнаруженный установщиком на машине. Чтобы оставить экземпляр без изменений, щёлкните его значок и выберите **Entire feature will be unavailable**. В редакциях Express поддержка расширений рендеринга отсутствует, поэтому не выбирайте экземпляр Express. Установщик скрывает экземпляры Express SQL Server 2016 и более ранних версий.
5. Нажмите **Next**, а затем **Install**.
6. Опциональная функция **Rpl Export** не выбирается по умолчанию. Она добавляет скрытое расширение, сохраняющее отчёты в формате RPL, что полезно при отправке отчёта о проблеме в Aspose; см. [Exporting Reports to RPL Format](/slides/ru/reportingservices/exporting-reports-to-rpl-format/).

## **Что меняет установщик**

Установщик помещает свои файлы в *Aspose\Aspose.Slides for Reporting Services* в папке Program Files — *Program Files (x86)* на 64‑разрядных Windows, поскольку установщик является 32‑разрядным пакетом. Затем для каждого выбранного экземпляра он:

- копирует *Aspose.Slides.ReportingServices.dll* в папку *ReportServer\bin* экземпляра — сборка для SQL Server 2005, или сборка для SQL Server 2008 и более новых версий, а также Power BI Report Server;
- добавляет шесть расширений рендеринга — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS и ASODP — в элемент `<Render>` файла *rsreportserver.config*;
- добавляет группу кода, предоставляющую сборке полный доверие в *rssrvpolicy.config*;
- сохраняет копию каждого изменённого конфигурационного файла, добавляя к имени расширение *.bak*.

[Install Manually](/slides/ru/reportingservices/install-manually/) показывает эти изменения шаг за шагом.

Если экземпляр нельзя настроить, установщик указывает его в сообщении и записывает детали в файл *rserrors<date>.log* в папке установки. Установите расширение на этом экземпляре вручную.

## **Проверьте установку**

Откройте постраничный отчёт в веб‑портале (Report Manager в SQL Server 2014 и более ранних версиях) и откройте список **Export**. Теперь в нём доступны следующие форматы:

- PPT - PowerPoint Presentation через Aspose.Slides
- PPS - PowerPoint SlideShow через Aspose.Slides
- PPTX - PowerPoint 2007 Presentation через Aspose.Slides
- PPSX - PowerPoint 2007 SlideShow через Aspose.Slides
- ODP - OpenDocument Presentation через Aspose.Slides
- XPS - через Aspose.Slides

Без лицензии экспортированные файлы содержат отметку оценки; см. [Licensing](/slides/ru/reportingservices/license-aspose-slides-for-reporting-services/).

## **Когда устанавливать вручную**

Устанавливайте расширение [manually](/slides/ru/reportingservices/install-manually/) вручную, если:

- установщик не может настроить экземпляр, например из‑за настроек безопасности на сервере;
- после обновления вы хотите заменить только сборку, а не удалять старую версию и запускать новый установщик.

Удаление продукта удаляет сборку и записи конфигурации из каждого экземпляра.