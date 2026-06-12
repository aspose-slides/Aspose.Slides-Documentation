---
title: Handmatig installeren
type: docs
weight: 30
url: /nl/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

Volg deze stappen alleen als je van plan bent Aspose.Slides for Reporting Services handmatig te installeren. In dit geval heb je het ZIP‑pakket met de assembly‑bestanden gedownload. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** vereist dat **.NET Framework 3.5** op de hostmachine geïnstalleerd is. 

{{% /alert %}}

### **Handmatige installatie**
Deze instructies laten zien hoe je bestanden kunt kopiëren en aanpassen in de map waar Microsoft SQL Server Reporting Services is geïnstalleerd:

1. Zoek de installatie‑map van de Report Server.  
   De hoofdmap voor Microsoft SQL Server staat meestal hier: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 en 2008**: Er kunnen meerdere Microsoft SQL Server‑instances op de machine geconfigureerd zijn en ze kunnen zich in verschillende MSSQL.x‑submappen bevinden, zoals MSSQL.1, MSSQL.2 enzovoort. Je moet de juiste ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** map vinden voordat je doorgaat naar de volgende stap.
   
   {{% /alert %}} Alle onderstaande paden verwijzen naar deze map als <Instance>. 

2. Kopieer **Aspose.Slides.ReportingServices.dll** naar de map **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.  
   Het **Aspose.Slides.ReportingServices.zip**‑bestand bevat de **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

In sommige gevallen, wanneer je de DLL naar de **ReportServer\bin**‑map kopieert, kan deze worden gekopieerd met de expliciet toegewezen NTFS‑bestandsrechten. Deze NTFS‑rechten zorgen ervoor dat Microsoft SQL Server Reporting Services geen toegang krijgt bij het laden van **Aspose.Slides.ReportingServices.dll**. Als dit gebeurt, worden de nieuwe exportformaten niet beschikbaar. Controleer en bevestig dat de juiste NTFS‑rechten aanwezig zijn :

   1. Klik met de rechtermuisknop op **Aspose.Slides.ReportingServices.dll**.  
   1. Kies **Eigenschappen** en ga naar het tabblad **Beveiliging**.  
   1. Verwijder alle expliciet toegekende NTFS‑rechten en laat alleen de geërfde rechten staan.

{{% /alert %}}

3. Registreer Aspose.Slides for Reporting Services als render‑extensie:  
   1. Open *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   1. Voeg deze regels toe aan het <Render>-element:  

**<Render>**

``` xml

   ...

  <!--Start hier.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Einde hier.-->

</Render>



```

4. Geef Aspose.Slides for Reporting Services rechten om uit te voeren:  
   1. Open **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   1. Voeg het volgende toe als laatste item in het tweede buitenste <CodeGroup>-element (dat moet zijn `<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">`).  

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

    <!--Einde hier.-->

  </CodeGroup>

</CodeGroup>



```

5. Controleer of Aspose.Slides for Reporting Services succesvol is geïnstalleerd:  
   1. Open Report Manager en controleer de lijst met beschikbare exporttypen voor een rapport.  

   {{% alert color="primary" %}} Je kunt Report Manager starten door een browser (Microsoft Internet Explorer 6.0 of nieuwer) te openen en de Report Manager‑URL in de adresbalk te typen (standaard is dit http://<ComputerName>/Reports).  

   {{% /alert %}}

1. Selecteer een rapport op de server.  
1. Open de lijst **Select Format**.  
   Je zou een lijst met exportformaten moeten zien die door Aspose.Slides for Reporting Services worden aangeboden.  
1. Selecteer **PPT – PowerPoint‑presentatie via Aspose.Slides**.  

   **Aspose.Slides for Reporting Services succesvol geïnstalleerd en nieuwe exportformaten zijn beschikbaar.**  

![todo:image_alt_text](install-manually_1.png)




6. Klik op de link **Export**.  
   Het rapport wordt gegenereerd in het gekozen formaat, naar de client verzonden en vervolgens geopend in een geschikt programma. In ons geval werd het rapport geopend in Microsoft PowerPoint.  

   **Een PPT‑rapport gegenereerd door Aspose.Slides for Reporting Services.**  

![todo:image_alt_text](install-manually_2.png)

Je hebt Aspose.Slides for Reporting Services succesvol geïnstalleerd en een rapport gegenereerd als Microsoft PowerPoint‑presentatie!