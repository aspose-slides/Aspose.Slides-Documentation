---
title: Manuell integration med Visual Studio 2005 eller 2008 Report Designer
type: docs
weight: 50
url: /sv/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Den här artikeln visar hur du integrerar Aspose.Slides for Reporting Services manuellt med Visual Studio. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** kräver installation av **.NET Framework 3.5** på värddatorn. 

{{% /alert %}}

## **Integrera Aspose.Slides for Reporting Services med Visual Studio**
Vi rekommenderar att du använder MSI‑installationsprogrammet för att installera Aspose.Slides for Reporting Services eftersom det automatiskt utför alla nödvändiga installationsuppgifter och konfigurationsprocesser. Om installationen med MSI‑installationsprogrammet misslyckas, använd guiden här. 

Den här artikeln visar också hur du installerar Aspose.Slides for Reporting Services på en dator med Business Intelligence Development Studio. Detta gör att du kan exportera rapporter till Microsoft PowerPoint‑format vid designtid från Microsoft Visual Studio 2005 eller 2008 Report Designer. 

1. Kopiera Aspose.Slides.ReportingServices.dll till Visual Studio‑katalogen.

   - För att integrera med Visual Studio 2005 Report Designer, kopiera **Aspose.Slides.ReportingServices.dll** till katalogen **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - För att integrera med Visual Studio 2008 Report Designer, kopiera **Aspose.Slides.ReportingServices.dll** till katalogen **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Registrera Aspose.Slides for Reporting Services som en rendering‑extension. 

3. Öppna **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (där <Version> är “8” för Visual Studio 2005 eller “9.0” för Visual Studio 2008) och lägg till dessa rader i <Render>-elementet: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Ge Aspose.Slides for Reporting Services behörighet att köras. 
   1. Öppna **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (där <Version> är “8” för Visual Studio 2005 eller “9.0” för Visual Studio 2008).
   1. Lägg till den här raden som det sista elementet i det näst yttre <CodeGroup>-elementet (som bör vara <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Börja här.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Avsluta här.-->

  </CodeGroup>

</CodeGroup>



```

5. Verifiera att Aspose.Slides for Reporting Services har installerats framgångsrikt. 
6. Kör eller starta om Microsoft Visual Studio 2005 eller 2008 Report Designer. Du bör märka nya format i listan över exportformat.

**Nya exportformat visas i Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)