---
title: Manuální integrace s Visual Studio 2005 nebo 2008 Report Designer
type: docs
weight: 50
url: /cs/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Tento článek vás učí, jak ručně integrovat Aspose.Slides for Reporting Services ve Visual Studio. 

{{% /alert %}} 

{{% alert title="Poznámka" color="warning" %}} 

**Aspose.Slides for Reporting Services** vyžaduje instalaci **.NET Framework 3.5** na hostitelském počítači. 

{{% /alert %}}

## **Integrace Aspose.Slides for Reporting Services do Visual Studio**
Doporučujeme použít MSI instalátor k instalaci Aspose.Slides for Reporting Services, protože automaticky provádí všechny potřebné instalační úkoly a konfigurační procesy. Pokud instalace pomocí MSI instalátoru selže, použijte tento průvodce. 

Článek také ukazuje, jak nainstalovat Aspose.Slides for Reporting Services na počítač s Business Intelligence Development Studio. To vám umožní exportovat zprávy do formátů Microsoft PowerPoint během návrhu z Microsoft Visual Studio 2005 nebo 2008 Report Designer. 

1. Zkopírujte Aspose.Slides.ReportingServices.dll do adresáře Visual Studio.

   - Pro integraci s Visual Studio 2005 Report Designer zkopírujte **Aspose.Slides.ReportingServices.dll** do **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Pro integraci s Visual Studio 2008 Report Designer zkopírujte **Aspose.Slides.ReportingServices.dll** do **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Zaregistrujte Aspose.Slides for Reporting Services jako renderovací rozšíření. 

3. Otevřete **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config** (kde <Version> je “8” pro Visual Studio 2005 nebo “9.0” pro Visual Studio 2008) a přidejte tyto řádky do elementu <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Poskytněte Aspose.Slides for Reporting Services oprávnění k provádění. 
   1. Otevřete **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (kde <Version> je “8” pro Visual Studio 2005 nebo “9.0” pro Visual Studio 2008).
   1. Přidejte tento řádek jako poslední položku do druhého vnějšího <CodeGroup> elementu (který by měl být <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Začněte zde.-->

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

    <!--Zde končí.-->

  </CodeGroup>

</CodeGroup>



```

5. Ověřte, že Aspose.Slides for Reporting Services byl úspěšně nainstalován. 
6. Spusťte nebo restartujte Microsoft Visual Studio 2005 nebo 2008 Report Designer. V seznamu formátů exportu by se měly objevit nové formáty.

**Nové exportní formáty se zobrazují v Report Designeru.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)