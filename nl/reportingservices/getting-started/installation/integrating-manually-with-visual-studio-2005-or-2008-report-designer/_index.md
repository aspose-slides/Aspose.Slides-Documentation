---
title: Handmatig integreren met Visual Studio 2005 of 2008 Report Designer
type: docs
weight: 50
url: /nl/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Dit artikel leert u hoe u Aspose.Slides for Reporting Services handmatig kunt integreren met Visual Studio. 

{{% /alert %}} 

{{% alert title="Opmerking" color="warning" %}} 

**Aspose.Slides for Reporting Services** vereist de installatie van **.NET Framework 3.5** op de hostmachine. 

{{% /alert %}}

## **Aspose.Slides for Reporting Services integreren met Visual Studio**
We raden u aan de MSI‑installer te gebruiken om Aspose.Slides for Reporting Services te installeren, omdat deze alle noodzakelijke installatie‑taken en configuratieprocessen automatisch uitvoert. Als de installatie met de MSI‑installer echter mislukt, kunt u de onderstaande gids volgen. 

Dit artikel laat u ook zien hoe u Aspose.Slides for Reporting Services kunt installeren op een computer met Business Intelligence Development Studio. Hierdoor kunt u rapporten exporteren naar Microsoft PowerPoint‑formaten tijdens het ontwerpen vanuit de Microsoft Visual Studio 2005‑ of 2008‑Report Designer. 

1. Kopieer Aspose.Slides.ReportingServices.dll naar de Visual Studio‑map.

   - Om te integreren met Visual Studio 2005 Report Designer, kopieer **Aspose.Slides.ReportingServices.dll** naar de **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies** map.
   - Om te integreren met Visual Studio 2008 Report Designer, kopieer **Aspose.Slides.ReportingServices.dll** naar de **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** map.
2. Registreer Aspose.Slides for Reporting Services als een rendering‑extensie. 

3. Open **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (waar <Version> “8” is voor Visual Studio 2005 of “9.0” voor Visual Studio 2008) en voeg deze regels toe aan het <Render>‑element: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Geef Aspose.Slides for Reporting Services toestemming om uit te voeren. 
   1. Open **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (waar <Version> “8” is voor Visual Studio 2005 of “9.0” voor Visual Studio 2008).
   1. Voeg deze regel toe als het laatste item in het tweede tot buitenste <CodeGroup>‑element (dat moet zijn <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Start hier.-->

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

    <!--End hier.-->

  </CodeGroup>

</CodeGroup>



```

5. Controleer of Aspose.Slides for Reporting Services succesvol is geïnstalleerd. 
6. Start of herstart Microsoft Visual Studio 2005 of 2008 Report Designer. U zou nieuwe formaten moeten zien in de lijst met exportformaten.

**Nieuwe exportformaten verschijnen in Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)