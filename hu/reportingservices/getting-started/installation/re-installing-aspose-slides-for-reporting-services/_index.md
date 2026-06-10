---
title: Aspose.Slides for Reporting Services újratelepítése
type: docs
weight: 40
url: /hu/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Ez a cikk leírja a megoldást egy olyan helyzetre, amikor az Aspose.Slides for Reporting Services már telepítve van, de valamilyen okból újra kell telepíteni.

{{% /alert %}} 

{{% alert title="Megjegyzés" color="warning" %}} 

**Aspose.Slides for Reporting Services** megköveteli a **.NET Framework 3.5** telepítését a gazdagépen. 

{{% /alert %}}

## **Az Aspose.Slides for Reporting Services újratelepítésének lépései**
A legfontosabb, hogy a korábbi Aspose.Slides for Reporting Services telepítéseket teljesen eltávolítsuk. Bár az MSI telepítő képes automatikusan elvégezni a szükséges műveleteket a termék eltávolításához és ezáltal újratelepítéséhez, ezeket a lépéseket be kell tartani:

1. Az Aspose.Slides for Reporting Services eltávolítása MSI telepítő használatával. 

2. Keresse meg az Aspose.Slides for Reporting Services telepítési könyvtárát, amely általában a következő helyen található:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. Ha az MSI telepítő nem távolította el az „Aspose.Slides for Reporting Services” könyvtárat az Aspose.Slides for Reporting Services eltávolítása során, törölje a mappát. 

4. Keresse meg az **Aspose.Slides.ReportingServices.dll** bináris fájlt minden SQL Server Reporting Service példány „bin” könyvtárában. Például, ha van egy Microsoft SQL Server 2008 példány „MSSQLSERVER”, a megfelelő Reporting Service „bin” könyvtár valószínűleg a következő helyen van: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Ha az MSI telepítő nem távolította el a fenti könyvtárból az Aspose.Slides.ReportingServices.dll bináris fájlt az Aspose.Slides for Reporting Services eltávolítása során, most törölje a fájlt. 

6. Keresse meg a **rsreportserver.config** fájlt minden SSRS példányhoz. Például, ha van egy Reporting Service példány „**MSRS10.MSSQLSERVER**”, a **rsreportserver.config** fájl ebben a könyvtárban lesz: 

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Nyissa meg a **rsreportserver.config** fájlt bármely szövegszerkesztőben, és keresse meg azokat a sorokat, amelyeket a PowerPoint formátumkiterjesztések hozzáadásához hoztak létre az Aspose.Slides for Reporting Services telepítése során. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** Ha az MSI telepítő nem távolította el ezeket a sorokat az Aspose.Slides for Reporting Services eltávolítása során, most törölje a sorokat a **rsreportserver.config** fájlból.

**Step** **9:** Keresse meg a **rssrvpolicy.config** fájlt minden SSRS példányhoz. Például, ha van egy Reporting Service példány „MSRS10.MSSQLSERVER”, a **rssrvpolicy.config** fájl ebben a könyvtárban lesz: 

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** Nyissa meg a **rssrvpolicy.config** fájlt bármely szerkesztőben, és keresse meg azokat a sorokat, amelyeket az Aspose.Slides for Reporting Services végrehajtási engedélyeinek megadására hoztak létre a telepítés során. 

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

**Step** **11:** Ha az MSI telepítő nem távolította el a fenti sorokat a termék eltávolítása során, most távolítsa el ezeket a sorokat a **rssrvpolicy.config** fájlból. 

**Step** **12:** Ha az Aspose.Slides for Reporting Services telepítve lett a Microsoft Visual Studio-val RDL jelentésfejlesztéshez és a PowerPoint formátumokba való exportáláshoz a Microsoft Visual Studio környezetben, akkor a Microsoft Visual Studio 2008 esetén az Aspose.Slides.ReportingServices.dll bináris fájlnak és a konfigurációs fájloknak (**rsreportserver.config** és **rssrvpolicy.config**) a következő helyen kell lenniük: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** Ha az MSI telepítő nem távolította el a **Aspose.Slides.ReportingServices.dll** bináris fájlt, törölje azt. Ezenkívül, ha nem frissítette a **rsreportserver.config** és **rssrvpolicy.config** fájlokat a PowerPoint formátumkiterjesztések és a kódvégrehajtási engedélyek eltávolítása érdekében, manuálisan kell ezeket a fájlokat is eltávolítania, ahogy az előző lépésekben tette. 

**Step** **14:** Itt az ideje újratelepíteni az Aspose.Slides for Reporting Services-t. Használja az MSI telepítőt az automatikus telepítéshez, vagy végezze el manuálisan.