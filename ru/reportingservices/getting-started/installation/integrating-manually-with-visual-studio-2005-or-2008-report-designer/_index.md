---
title: Интеграция Aspose.Slides вручную с Visual Studio 2005 или 2008 Report Designer
type: docs
weight: 50
url: /ru/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---

{{% alert color="primary" %}} 

В этой статье вы узнаете, как вручную интегрировать Aspose.Slides для Reporting Services с Visual Studio. 

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

**Aspose.Slides для Reporting Services** требует установки **.NET Framework 3.5** на компьютер хоста. 

{{% /alert %}}

## **Интеграция Aspose.Slides для Reporting Services с Visual Studio**
Мы рекомендуем использовать MSI установщик для установки Aspose.Slides для Reporting Services, так как он выполняет все необходимые операции установки и конфигурации автоматически. Однако, если установка с использованием MSI установщика не удалась, используйте руководство здесь. 

Эта статья также показывает, как установить Aspose.Slides для Reporting Services на компьютере с Business Intelligence Development Studio. Это позволит вам экспортировать отчеты в форматы Microsoft PowerPoint на этапе разработки из Microsoft Visual Studio 2005 или 2008 Report Designer. 

1. Скопируйте Aspose.Slides.ReportingServices.dll в директорию Visual Studio.

   - Чтобы интегрироваться с Visual Studio 2005 Report Designer, скопируйте **Aspose.Slides.ReportingServices.dll** в директорию **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Чтобы интегрироваться с Visual Studio 2008 Report Designer, скопируйте **Aspose.Slides.ReportingServices.dll** в директорию **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Зарегистрируйте Aspose.Slides для Reporting Services как расширение рендеринга. 

3. Откройте **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (где <Version> это “8” для Visual Studio 2005 или “9.0” для Visual Studio 2008) и добавьте эти строки в элемент <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Дайте Aspose.Slides для Reporting Services разрешения на выполнение. 
   1. Откройте **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (где <Version> это “8” для Visual Studio 2005 или “9.0” для Visual Studio 2008).
   1. Добавьте эту строку в качестве последнего элемента во втором по внешнему <CodeGroup> элементе (который должен быть <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Эта кодовая группа предоставляет разрешение на выполнение кода для MyComputer.">) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Начинайте здесь.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="Эта кодовая группа предоставляет полный доступ к сборке AS4SSRS.">

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

5. Проверьте, что Aspose.Slides для Reporting Services была успешно установлена. 
6. Запустите или перезапустите Microsoft Visual Studio 2005 или 2008 Report Designer. Вы должны заметить новые форматы в списке форматов экспорта.

**Новые форматы экспорта появляются в Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)