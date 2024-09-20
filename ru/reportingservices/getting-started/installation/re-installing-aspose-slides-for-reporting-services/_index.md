---
title: Переустановка Aspose.Slides для Reporting Services
type: docs
weight: 40
url: /reportingservices/re-installing-aspose-slides-for-reporting-services/
---

{{% alert color="primary" %}} 

В этой статье описывается решение ситуации, когда Aspose.Slides для Reporting Services уже установлена, но по какой-либо причине необходимо выполнить переустановку.

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

**Aspose.Slides для Reporting Services** требует установки **.NET Framework 3.5** на хост-устройстве. 

{{% /alert %}}

## **Шаги по переустановке Aspose.Slides для Reporting Services**
Самое важное — полностью удалить предыдущие установки Aspose.Slides для Reporting Services. Хотя установщик MSI может успешно выполнить необходимые действия для автоматического удаления и, следовательно, переустановки Aspose.Slides для Reporting Services, необходимо выполнить следующие шаги:

1. Удалите Aspose.Slides для Reporting Services с помощью установщика MSI. 

2. Найдите каталог установки Aspose.Slides для Reporting Services, который обычно находится по следующему пути:

   **Диск корневой ОС\Program Files\Aspose\Aspose.Slides для Reporting Services** 

3. Если установщик MSI не удалил каталог “Aspose.Slides для Reporting Services” при удалении Aspose.Slides для Reporting Services, удалите папку. 

4. Найдите двоичный файл **Aspose.Slides.ReportingServices.dll** в каталоге “bin” каждого экземпляра SQL Server Reporting Service. Например, если есть экземпляр Microsoft SQL Server 2008 “MSSQLSERVER”, соответствующий каталог Reporting Service “bin” скорее всего находится по адресу: 

   **Диск корневой ОС\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Если установщик MSI не удалил двоичный файл Aspose.Slides.ReportingServices.dll из вышеназванного каталога при удалении Aspose.Slides для Reporting Services, удалите файл сейчас.

6. Найдите файл **rsreportserver.config** для каждого экземпляра SSRS. Например, если есть экземпляр Reporting Service “ **MSRS10.MSSQLSERVER** ”, файл **rsreportserver.config** будет находиться в следующем каталоге:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Откройте файл **rsreportserver.config** в любом редакторе и найдите строки, которые были добавлены для добавления расширений формата PowerPoint во время установки Aspose.Slides для Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Шаг** **8:** Если установщик MSI не удалил эти строки при удалении Aspose.Slides для Reporting Services, удалите строки из файла **rsreportserver.config** сейчас.

**Шаг** **9:** Найдите файл **rssrvpolicy.config** для каждого экземпляра SSRS. Например, если есть экземпляр Reporting Service “ MSRS10.MSSQLSERVER ”, файл **rssrvpolicy.config** будет находиться в следующем каталоге:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Шаг** **10:** Откройте файл **rssrvpolicy.config** в любом редакторе и найдите строки, которые были добавлены для предоставления разрешений на выполнение Aspose.Slides для Reporting Services во время установки Aspose.Slides для Reporting Services. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Начните здесь.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="Эта группа кода предоставляет полный доступ к сборке AS4SSRS.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

           PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Конец здесь.-->

  </CodeGroup>

</CodeGroup>



```

**Шаг** **11:** Если установщик MSI не удалил вышеприведенные строки при удалении продукта, удалите эти строки из файла **rssrvpolicy.config** сейчас. 

**Шаг** **12:** Если Aspose.Slides для Reporting Services также была установлена с использованием Microsoft Visual Studio для разработки отчетов RDL и экспорта в форматы PowerPoint в среде Microsoft Visual Studio, двоичный файл Aspose.Slides.ReportingServices.dll и файлы конфигурации ( **rsreportserver.config** и **rssrvpolicy.config** ) для Microsoft Visual Studio 2008 должны находиться по следующему пути: 

**Диск корневой ОС\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Шаг** **13:** Если установщик MSI не удалил двоичный файл **Aspose.Slides.ReportingServices.dll**, удалите его. Более того, если он не обновил файлы **rsreportserver.config** и **rssrvpolicy.config** для удаления расширений формата PowerPoint и разрешений на выполнение кода соответственно, вам нужно удалить их вручную так же, как вы делали с файлами на предыдущих шагах. 

**Шаг** **14:** Пришло время переустановить Aspose.Slides для Reporting Services. Используйте установщик MSI для автоматической установки или выполните это вручную. 