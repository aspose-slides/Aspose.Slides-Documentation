---
title: Manuális telepítés
type: docs
weight: 30
url: /hu/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

Csak akkor kövesse ezeket a lépéseket, ha manuálisan szeretné telepíteni az Aspose.Slides for Reporting Services‑t. Ebben az esetben a ZIP csomagot töltötte le, amely a szerelvény fájlokat tartalmazza. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** megköveteli a **.NET Framework 3.5** telepítését a gazdagépen. 

{{% /alert %}}

### **Manuális telepítés**
Ez az útmutató bemutatja, hogyan másolhat és módosíthat fájlokat abban a könyvtárban, ahol a Microsoft SQL Server Reporting Services telepítve van:

1. Keresse meg a Report Server telepítési könyvtárát.  
   A Microsoft SQL Server gyökérkönyvtára általában itt található: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 és 2008**: Lehet, hogy a gépen több Microsoft SQL Server példány is konfigurálva van, és különböző MSSQL.x alkönyvtárakban (például MSSQL.1, MSSQL.2 stb.) találhatók. A következő lépés folytatása előtt meg kell találnia a helyes ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** könyvtárat.  
   
   {{% /alert %}} Az alább használt összes útvonal erre a könyvtárra hivatkozik <Instance> néven. 

2. Másolja az Aspose.Slides.ReportingServices.dll fájlt a **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin** mappába.  
   A **Aspose.Slides.ReportingServices.zip** letöltés tartalmazza az **Aspose.Slides.ReportingServices.dll** fájlt. {{% alert color="primary" %}} 

Néhány esetben, ha a DLL-t a **ReportServer\bin** könyvtárba másolja, a fájlhoz rendelt explicit NTFS jogosultságok is átmásolódhatnak. Az NTFS jogosultságok miatt a Microsoft SQL Server Reporting Services megtagadhatja a hozzáférést a **Aspose.Slides.ReportingServices.dll** betöltésekor. Ha ez megtörténik, az új exportformátumok nem lesznek elérhetők. Ellenőrizze és erősítse meg, hogy a megfelelő NTFS jogosultságok be vannak állítva:

   1. Kattintson jobb gombbal az **Aspose.Slides.ReportingServices.dll** fájlra.  
   1. Válassza a **Tulajdonságok** menüpontot, és nyissa meg a **Biztonság** fület.  
   1. Távolítsa el az explicit NTFS jogosultságokat, és hagyja csak az örökölt jogosultságokat.  

{{% /alert %}}

3. Regisztrálja az Aspose.Slides for Reporting Services‑t renderelő kiterjesztésként:  
   1. Nyissa meg a *C:\Program  
      Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config* fájlt.  
   1. Adja hozzá a következő sorokat a <Render> elemhez:  

**<Render>**

``` xml

   ...

  <!--Kezdés itt.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Vége itt.-->

</Render>



```

4. Adjon engedélyt az Aspose.Slides for Reporting Services‑nek a végrehajtáshoz:  
   1. Nyissa meg a **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config** fájlt.  
   1. Adja hozzá a következőt a második legkülső <CodeGroup> elem legutolsó eleméhez (eznek így kell kinéznie: <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">).  

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

5. Ellenőrizze, hogy az Aspose.Slides for Reporting Services sikeresen települt-e:  
   1. Nyissa meg a Report Manager‑t, és ellenőrizze a jelentéshez elérhető exportálási típusok listáját.  
   
   {{% alert color="primary" %}} A Report Manager‑t a böngésző (Microsoft Internet Explorer 6.0 vagy újabb) megnyitásával, majd a Report Manager URL‑jének beírásával indíthatja (alapértelmezés szerint ez http://< ComputerName >/Reports ).  
   
   {{% /alert %}}

1. Válasszon ki egy jelentést a szerveren.  
1. Nyissa meg a **Select Format** listát.  
   Az Aspose.Slides for Reporting Services által biztosított export formátumok listáját kell látnia.  
1. Válassza ki a **PPT – PowerPoint Presentation via Aspose.Slides** elemet.  

   **Az Aspose.Slides for Reporting Services sikeresen telepítve lett, és az új export formátumok elérhetők**  

![todo:image_alt_text](install-manually_1.png)




6. Kattintson az **Export** hivatkozásra.  
   A jelentés a kiválasztott formátumban kerül legenerálásra, elküldésre a kliensnek, majd egy megfelelő alkalmazásban nyílik meg. Ebben az esetben a jelentést a Microsoft PowerPoint nyitotta meg.  

   **Az Aspose.Slides for Reporting Services által generált PPT jelentés.**  

![todo:image_alt_text](install-manually_2.png)

Sikeresen telepítette az Aspose.Slides for Reporting Services‑t, és egy jelentést generált Microsoft PowerPoint prezentációként !