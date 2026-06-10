---
title: Manuális integráció a Visual Studio 2005 vagy 2008 Report Designerrel
type: docs
weight: 50
url: /hu/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Ez a cikk bemutatja, hogyan integrálhatja az Aspose.Slides for Reporting Services‑t manuálisan a Visual Studio‑val. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** megköveteli a **.NET Framework 3.5** telepítését a gépre. 

{{% /alert %}}

## **Az Aspose.Slides for Reporting Services integrálása a Visual Studio-val**
Javasoljuk, hogy az MSI telepítővel telepítse az Aspose.Slides for Reporting Services‑t, mivel az automatikusan elvégzi az összes szükséges telepítési feladatot és konfigurációs folyamatot. Ha azonban az MSI telepítővel történő telepítés meghiúsul, akkor kövesse itt a útmutatót. 

Ez a cikk továbbá bemutatja, hogyan telepítheti az Aspose.Slides for Reporting Services‑t egy Business Intelligence Development Studio‑val rendelkező számítógépre. Ez lehetővé teszi, hogy a Microsoft Visual Studio 2005 vagy 2008 Report Designer‑ből tervezési időben exportálja a jelentéseket a Microsoft PowerPoint formátumokba. 

1. Másolja az Aspose.Slides.ReportingServices.dll fájlt a Visual Studio könyvtárába.

   - A Visual Studio 2005 Report Designerrel való integráláshoz másolja az **Aspose.Slides.ReportingServices.dll** fájlt a **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies** könyvtárba.
   - A Visual Studio 2008 Report Designerrel való integráláshoz másolja az **Aspose.Slides.ReportingServices.dll** fájlt a **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** könyvtárba.
2. Regisztrálja az Aspose.Slides for Reporting Services‑t renderelési kiterjesztésként. 

3. Nyissa meg a **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** fájlt (ahol a <Version> „8” a Visual Studio 2005‑höz vagy „9.0” a Visual Studio 2008‑hoz), és adja hozzá ezeket a sorokat a <Render> elemhez: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Adjon engedélyeket az Aspose.Slides for Reporting Services számára a végrehajtáshoz. 
   1. Nyissa meg a **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** fájlt (ahol a <Version> „8” a Visual Studio 2005‑höz vagy „9.0” a Visual Studio 2008‑hoz).
   1. Adja hozzá ezt a sort a második‑külső <CodeGroup> elem legutolsó elemként (ennek így kell kinéznie: <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Kezdés itt.-->

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

    <!--Vége itt.-->

  </CodeGroup>

</CodeGroup>



```

5. Ellenőrizze, hogy az Aspose.Slides for Reporting Services sikeresen települt‑e. 
6. Indítsa el vagy indítsa újra a Microsoft Visual Studio 2005 vagy 2008 Report Designer‑t. Az exportálási formátumok listájában új formátumokat kell látnia.

**Új exportálási formátumok jelennek meg a Report Designerben.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)