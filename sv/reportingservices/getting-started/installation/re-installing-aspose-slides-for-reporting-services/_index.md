---
title: Ominstallation av Aspose.Slides för Reporting Services
type: docs
weight: 40
url: /sv/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Den här artikeln beskriver lösningen för en situation där Aspose.Slides for Reporting Services redan är installerat, men av någon anledning måste det installeras om.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** kräver installation av **.NET Framework 3.5** på värddatorn. 

{{% /alert %}}

## **Steg för ominstallation av Aspose.Slides for Reporting Services**
Det viktigaste är att ta bort tidigare installationer av Aspose.Slides for Reporting Services helt och hållet. Även om MSI‑installationsprogrammet kan utföra de nödvändiga åtgärderna för att avinstallera och därmed automatiskt installera om Aspose.Slides for Reporting Services, måste dessa steg följas:

1. Avinstallera Aspose.Slides for Reporting Services med MSI‑installationsprogrammet. 

2. Leta upp installationskatalogen för Aspose.Slides for Reporting Services som vanligen finns på:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3.  Om MSI‑installationsprogrammet inte har tagit bort mappen “Aspose.Slides for Reporting Services” när det avinstallerade Aspose.Slides for Reporting Services, radera mappen. 

4. Leta upp binärfilen **Aspose.Slides.ReportingServices.dll** i “bin”-katalogen för varje SQL Server Reporting Service‑instans. Till exempel, om det finns en Microsoft SQL Server 2008‑instans “MSSQLSERVER”, är den motsvarande Reporting Service “bin”-katalogen sannolikt på: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Om MSI‑installationsprogrammet inte har tagit bort binärfilen Aspose.Slides.ReportingServices.dll från katalogen ovan när det avinstallerade Aspose.Slides for Reporting Services, radera filen nu.

6. Leta upp **rsreportserver.config**‑filen för varje SSRS‑instans. Till exempel, om det finns en Reporting Service‑instans “**MSRS10.MSSQLSERVER**”, kommer **rsreportserver.config**‑filen att finnas i denna katalog:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Öppna **rsreportserver.config**‑filen i någon redigerare och hitta raderna som skapades för att lägga till PowerPoint‑format‑tillägg under installationen av Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** Om MSI‑installationsprogrammet inte har tagit bort de raderna när det avinstallerade Aspose.Slides for Reporting Services, radera raderna från **rsreportserver.config**‑filen nu.

**Step** **9:** Leta upp **rssrvpolicy.config**‑filen för varje SSRS‑instans. Till exempel, om det finns en Reporting Service‑instans “MSRS10.MSSQLSERVER”, kommer **rssrvpolicy.config**‑filen att finnas i denna katalog:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** Öppna **rssrvpolicy.config**‑filen i någon redigerare och hitta raderna som skapades för att bevilja körningsbehörigheter till Aspose.Slides for Reporting Services under installationen av Aspose.Slides for Reporting Services. 

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

    <!--Sluta här.-->

  </CodeGroup>

</CodeGroup>



```

**Step** **11:** Om MSI‑installationsprogrammet inte har tagit bort raderna ovan när det avinstallerade produkten, ta bort dessa rader från **rssrvpolicy.config**‑filen nu. 

**Step** **12:** Om Aspose.Slides for Reporting Services också installerades med Microsoft Visual Studio för RDL‑rapportutveckling och export till PowerPoint‑format inom Microsoft Visual Studio‑miljön, bör binärfilen Aspose.Slides.ReportingServices.dll och konfigurationsfilerna (**rsreportserver.config** och **rssrvpolicy.config**) för Microsoft Visual Studio 2008 finnas i: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** Om MSI‑installationsprogrammet inte har tagit bort binärfilen **Aspose.Slides.ReportingServices.dll**, radera den. Dessutom, om det inte har uppdaterat filerna **rsreportserver.config** och **rssrvpolicy.config** för att ta bort PowerPoint‑format‑tillägg respektive kodexekveringsbehörigheter, måste du ta bort dem manuellt på samma sätt som du gjorde med filerna i tidigare steg. 

**Step** **14:** Det är dags att installera om Aspose.Slides for Reporting Services. Använd MSI‑installationsprogrammet för automatisk installation eller gör det manuellt.