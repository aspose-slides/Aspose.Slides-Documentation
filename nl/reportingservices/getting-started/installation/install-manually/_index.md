---
title: Handmatig installeren
type: docs
weight: 30
url: /nl/reportingservices/install-manually/
keywords:
- handmatige installatie
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installeer Aspose.Slides for Reporting Services handmatig vanuit het ZIP-pakket met uitsluitend DLL’s: welke assembly te kopiëren en wat toe te voegen aan rsreportserver.config en rssrvpolicy.config."
---
## **Overzicht**

Volg deze stappen om Aspose.Slides for Reporting Services te installeren zonder de MSI‑installer, vanuit het ZIP‑pakket *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* op de [downloadpagina](https://releases.aspose.com/slides/reportingservices/). Ze registreren dezelfde extensies als de [MSI‑installer](/slides/nl/reportingservices/install-with-msi-installer/). Herhaal ze voor elke rapportserverinstantie.

Voordat u begint, controleer de [systeemvereisten](/slides/nl/reportingservices/system-requirements/). U hebt lokale beheerdersrechten nodig op de rapportserver.

## **Kies de assembly**

Het ZIP‑pakket bevat verschillende builds. Kopieer exact één *Aspose.Slides.ReportingServices.dll* naar de rapportserver:

| Bestand in het ZIP‑pakket | Gebruik voor |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 en latere Reporting Services, en Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Niet voor een rapportserver: applicaties die exporteren vanuit de ReportViewer 2010‑ of 2012‑control, zie [Aspose.Slides gebruiken met ReportViewer 2010 en 2012](/slides/nl/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Optioneel: slaat rapporten op in RPL‑formaat voor probleemrapporten, zie [Rapporten exporteren naar RPL‑formaat](/slides/nl/reportingservices/exporting-reports-to-rpl-format/) |

## **Vind de rapportservermap**

De onderstaande stappen verwijzen naar de *ReportServer*-map van de rapportserver, die *rsreportserver.config* en *rssrvpolicy.config* bevat. In een standaardinstallatie is dit:

| Rapportserver | Standaard *ReportServer*‑map |
| :- | :- |
| SQL Server 2017 en latere Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 en eerdere Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, waarbij de instance‑map bijvoorbeeld `MSRS13.MSSQLSERVER` is voor SQL Server 2016 of `MSSQL.x` voor SQL Server 2005 |

Voor meer locaties zie Microsoft’s [RsReportServer.config‑configuratiebestand](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Installeer de extensie**

1. Kopieer de gekozen assembly naar de *bin*‑submap van de *ReportServer*‑map.

   Het gekopieerde bestand mag geen expliciet toegewezen NTFS‑rechten hebben, anders wordt de rapportserver de toegang geweigerd bij het laden van de assembly en verschijnen de nieuwe exportformaten niet. Klik met de rechtermuisknop op het bestand, kies **Eigenschappen**, en verwijder op het tabblad **Beveiliging** alle expliciet toegewezen rechten, zodat alleen geërfde rechten overblijven. Als het tabblad **Algemeen** een optie **Deblokkeren** toont, selecteer die dan.

2. Maak een kopie van *rsreportserver.config* en open het bestand in een teksteditor. Voeg deze items toe binnen het `<Render>`‑element:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Elk item registreert één exportformaat; `Name` moet uniek zijn onder de render‑extensies. De MSI‑installer registreert dezelfde zes namen en types. Laat een item weg als u dat formaat niet in de exportlijst wilt.

3. Maak een kopie van *rssrvpolicy.config* en open het bestand in een teksteditor. Zoek de code‑groep waarvan `Description` is “This code group grants MyComputer code Execution permission.” en voeg deze code‑groep toe als laatste onderliggend element:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` is de publieke sleutel van de Aspose.Slides.ReportingServices‑assembly. Houd deze op één regel.

4. Sla beide bestanden op. De rapportserver leest zijn configuratiebestanden opnieuw zodra ze worden opgeslagen. Als een bestand ongeldige XML bevat, negeert de rapportserver het of start hij niet, dus herstel uw kopie als er iets misgaat.

## **Controleer de installatie**

Open een gepagineerd rapport in het webportaal (Report Manager op SQL Server 2014 en eerder) en open de **Export**‑lijst. Deze bevat nu de volgende formaten:

- PPT - PowerPoint‑presentatie via Aspose.Slides
- PPS - PowerPoint‑diavoorstelling via Aspose.Slides
- PPTX - PowerPoint 2007‑presentatie via Aspose.Slides
- PPSX - PowerPoint 2007‑diavoorstelling via Aspose.Slides
- ODP - OpenDocument‑presentatie via Aspose.Slides
- XPS - via Aspose.Slides

Selecteer er één om het rapport te exporteren. Het bestand wordt geopend in de toepassing die aan dat formaat is gekoppeld.

![Een rapport geëxporteerd naar PowerPoint door Aspose.Slides for Reporting Services](install-manually_2.png)

Als de formaten niet verschijnen, controleer dan de NTFS‑rechten van de gekopieerde assembly. Zonder licentie bevatten geëxporteerde bestanden een evaluatiewatermerk; zie [Licenties](/slides/nl/reportingservices/license-aspose-slides-for-reporting-services/).