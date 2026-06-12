---
title: Herinstallatie van Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /nl/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Dit artikel beschrijft de oplossing voor een situatie waarin Aspose.Slides for Reporting Services al geïnstalleerd is, maar om welke reden dan ook opnieuw moet worden geïnstalleerd.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** vereist de installatie van **.NET Framework 3.5** op de hostmachine. 

{{% /alert %}}

## **Stappen voor het opnieuw installeren van Aspose.Slides for Reporting Services**
Het belangrijkste is het volledig verwijderen van eerdere installaties van Aspose.Slides for Reporting Services. Terwijl de MSI‑installer de noodzakelijke acties kan uitvoeren om Aspose.Slides for Reporting Services automatisch te deïnstalleren en daardoor opnieuw te installeren, moeten deze stappen worden gevolgd:

1. Deïnstalleer Aspose.Slides for Reporting Services met behulp van de MSI‑installer. 

2. Zoek de installatie‑directory van Aspose.Slides for Reporting Services, meestal te vinden op:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3.  Als de MSI‑installer de map “Aspose.Slides for Reporting Services” niet heeft verwijderd toen het product werd gedeïnstalleerd, verwijder de map. 

4. Zoek het binair bestand **Aspose.Slides.ReportingServices.dll** in de “bin”‑directory van elke SQL Server Reporting Service‑instantie. Bijvoorbeeld, als er een Microsoft SQL Server 2008‑instantie “MSSQLSERVER” is, bevindt de corresponderende Reporting Service “bin”‑directory zich waarschijnlijk op: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Als de MSI‑installer het bestand Aspose.Slides.ReportingServices.dll niet heeft verwijderd uit de bovenstaande directory toen het product werd gedeïnstalleerd, verwijder het bestand nu.

6. Zoek het **rsreportserver.config**‑bestand voor elke SSRS‑instantie. Bijvoorbeeld, als er een Reporting Service‑instantie “ **MSRS10.MSSQLSERVER** ” is, bevindt het **rsreportserver.config**‑bestand zich in deze directory:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Open het **rsreportserver.config**‑bestand in een editor en zoek de regels die zijn aangemaakt om PowerPoint Format Extensions toe te voegen tijdens de installatie van Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** Als de MSI‑installer die regels niet heeft verwijderd toen het product werd gedeïnstalleerd, verwijder de regels nu uit het **rsreportserver.config**‑bestand.

**Step** **9:** Zoek het **rssrvpolicy.config**‑bestand voor elke SSRS‑instantie. Bijvoorbeeld, als er een Reporting Service‑instantie “ MSRS10.MSSQLSERVER ” is, bevindt het **rssrvpolicy.config**‑bestand zich in deze directory:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** Open het **rssrvpolicy.config**‑bestand in een editor en zoek de regels die zijn aangemaakt om uitvoeringsrechten te verlenen aan Aspose.Slides for Reporting Services tijdens de installatie van Aspose.Slides for Reporting Services. 

**<CodeGroup>**

``` xml

   ...

  <CodeGroup>

    ...

    <!--Begin hier.-->

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

    <!--Einde hier.-->

  </CodeGroup>

</CodeGroup>



```

**Step** **11:** Als de MSI‑installer de bovenstaande regels niet heeft verwijderd toen het product werd gedeïnstalleerd, verwijder die regels nu uit het **rssrvpolicy.config**‑bestand. 

**Step** **12:** Als Aspose.Slides for Reporting Services ook is geïnstalleerd met Microsoft Visual Studio voor RDL‑rapportontwikkeling en export naar PowerPoint‑formaten binnen de Microsoft Visual Studio‑omgeving, moet het binair bestand Aspose.Slides.ReportingServices.dll en de configuratiebestanden (**rsreportserver.config** en **rssrvpolicy.config**) in het geval van Microsoft Visual Studio 2008 zich bevinden in: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** Als de MSI‑installer het **Aspose.Slides.ReportingServices.dll**‑bestand niet heeft verwijderd, verwijder het dan. Bovendien, als het de bestanden **rsreportserver.config** en **rssrvpolicy.config** niet heeft bijgewerkt om respectievelijk de PowerPoint Format Extensions en code‑uitvoeringsrechten te verwijderen, moet je ze handmatig verwijderen, op dezelfde manier als je dat in de eerdere stappen deed. 

**Step** **14:** Het is tijd om Aspose.Slides for Reporting Services opnieuw te installeren. Gebruik de MSI‑installer voor automatische installatie of voer de installatie handmatig uit.