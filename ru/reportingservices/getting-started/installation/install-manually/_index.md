---
title: Установить вручную
type: docs
weight: 30
url: /ru/reportingservices/install-manually/
keywords:
- ручная установка
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Установите Aspose.Slides for Reporting Services вручную из ZIP‑пакета только с DLL: какую сборку скопировать и что добавить в rsreportserver.config и rssrvpolicy.config."
---
## **Обзор**

Выполните эти шаги, чтобы установить Aspose.Slides for Reporting Services без MSI‑установщика, из ZIP‑пакета *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* на [странице загрузки](https://releases.aspose.com/slides/reportingservices/). Они регистрируют те же расширения, что и [MSI installer](/slides/ru/reportingservices/install-with-msi-installer/). Повторите их для каждого экземпляра сервера отчётов.

Перед началом проверьте [system requirements](/slides/ru/reportingservices/system-requirements/). Вам нужны права локального администратора на сервере отчётов.

## **Выбор сборки**

ZIP‑пакет содержит несколько сборок. Скопируйте ровно один *Aspose.Slides.ReportingServices.dll* на сервер отчётов:

| Файл в ZIP‑пакете | Назначение |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 и новее Reporting Services, а также Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Не для сервера отчётов: приложения, экспортирующие из элемента управления ReportViewer 2010 или 2012, см. [Using Aspose.Slides with ReportViewer 2010 and 2012](/slides/ru/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | При желании: сохраняет отчёты в формате RPL для отладки, см. [Exporting Reports to RPL Format](/slides/ru/reportingservices/exporting-reports-to-rpl-format/) |

## **Поиск папки сервера отчётов**

Ниже указаны шаги, относящиеся к папке *ReportServer* сервера отчётов, где находятся *rsreportserver.config* и *rssrvpolicy.config*. В типичной установке это:

| Сервер отчётов | Папка *ReportServer* по умолчанию |
| :- | :- |
| SQL Server 2017 и новее Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 и старее Reporting Services | `C:\Program Files\Microsoft SQL Server\<папка экземпляра>\Reporting Services\ReportServer`, где <папка экземпляра> может быть, например, `MSRS13.MSSQLSERVER` для SQL Server 2016 или `MSSQL.x` для SQL Server 2005 |

Для других расположений см. статью Microsoft [RsReportServer.config configuration file](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Установка расширения**

1. Скопируйте выбранную сборку в подпапку *bin* папки *ReportServer*.

   Скопированный файл не должен иметь явно назначенных прав NTFS, иначе сервер отчётов не сможет загрузить сборку и новые форматы экспорта не появятся. Щёлкните файл правой кнопкой, выберите **Properties**, на вкладке **Security** удалите любые явно назначенные права, оставив только унаследованные. Если на вкладке **General** отображается кнопка **Unblock**, нажмите её.

2. Сохраните копию *rsreportserver.config*, затем откройте файл в текстовом редакторе. Добавьте следующие элементы внутри тега `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Каждый элемент регистрирует один формат экспорта; `Name` должно быть уникальным среди рендеринговых расширений. MSI‑установщик регистрирует те же шесть имён и типов. Опустите элемент, если не хотите, чтобы его формат отображался в списке экспорта.

3. Сохраните копию *rssrvpolicy.config*, затем откройте файл в текстовом редакторе. Найдите группу кода, чьё `Description` равно «This code group grants MyComputer code Execution permission.» и добавьте следующую группу кода как её последний дочерний элемент:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` – это открытый ключ сборки Aspose.Slides.ReportingServices. Оставьте его в одной строке.

4. Сохраните оба файла. Сервер отчётов перечитывает файлы конфигурации каждый раз после их сохранения. Если файл содержит некорректный XML, сервер игнорирует его или не запускается, поэтому при проблемах восстановите свою копию.

## **Проверка установки**

Откройте постраничный отчёт в веб‑портале (Report Manager в SQL Server 2014 и старее) и откройте список **Export**. Теперь в нём присутствуют следующие форматы:

- PPT — PowerPoint Presentation через Aspose.Slides
- PPS — PowerPoint SlideShow через Aspose.Slides
- PPTX — PowerPoint 2007 Presentation через Aspose.Slides
- PPSX — PowerPoint 2007 SlideShow через Aspose.Slides
- ODP — OpenDocument Presentation через Aspose.Slides
- XPS — через Aspose.Slides

Выберите любой из них, чтобы экспортировать отчёт. Файл откроется в приложении, ассоциированном с его форматом.

![Отчет, экспортированный в PowerPoint с помощью Aspose.Slides for Reporting Services](install-manually_2.png)

Если форматы не отображаются, проверьте права NTFS скопированной сборки. Без лицензии экспортированные файлы содержат водяной знак оценки; см. [Licensing](/slides/ru/reportingservices/license-aspose-slides-for-reporting-services/).