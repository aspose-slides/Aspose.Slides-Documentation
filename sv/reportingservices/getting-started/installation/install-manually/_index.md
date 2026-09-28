---
title: Installera manuellt
type: docs
weight: 30
url: /sv/reportingservices/install-manually/
keywords:
- manuell installation
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installera Aspose.Slides for Reporting Services för hand från ZIP-paketet som endast innehåller DLL-filer: vilken assembly som ska kopieras och vad som ska läggas till i rsreportserver.config och rssrvpolicy.config."
---
## **Översikt**

Följ dessa steg för att installera Aspose.Slides for Reporting Services utan MSI‑installationsprogrammet, från ZIP‑paketet *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* på den [nedladdningssidan](https://releases.aspose.com/slides/reportingservices/). De registrerar samma tillägg som [MSI‑installationsprogrammet](/slides/sv/reportingservices/install-with-msi-installer/). Upprepa dem för varje rapportserverinstans.

Innan du börjar, kontrollera [systemkraven](/slides/sv/reportingservices/system-requirements/). Du behöver lokala administratörsrättigheter på rapportservern.

## **Välj Assembly**

ZIP‑paketet innehåller flera versioner. Kopiera exakt en *Aspose.Slides.ReportingServices.dll* till rapportservern:

| Fil i ZIP‑paketet | Använd den för |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 och senare Reporting Services samt Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Inte för en rapportserver: program som exporterar från ReportViewer 2010 eller 2012‑kontrollen, se [Använda Aspose.Slides med ReportViewer 2010 och 2012](/slides/sv/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Valfritt: sparar rapporter i RPL‑format för felrapporter, se [Exportera rapporter till RPL‑format](/slides/sv/reportingservices/exporting-reports-to-rpl-format/) |

## **Hitta rapportserverns mapp**

Stegen nedan hänvisar till rapportserverns *ReportServer*-mapp, som innehåller *rsreportserver.config* och *rssrvpolicy.config*. I en standardinstallation är den:

| Report server | Default *ReportServer* folder |
| :- | :- |
| SQL Server 2017 och senare Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 och tidigare Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, where the instance folder is, for example, `MSRS13.MSSQLSERVER` for SQL Server 2016 or `MSSQL.x` for SQL Server 2005 |

För fler platser, se Microsofts artikel om [RsReportServer.config‑konfigurationsfilen](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Installera tillägget**

1. Kopiera den valda assemblyn till *bin*-undermappen i *ReportServer*-mappen.

   Den kopierade filen får inte ha explicit tilldelade NTFS‑behörigheter, annars nekas rapportservern åtkomst när den laddar assemblyn och de nya exportformaten visas inte. Högerklicka på filen, välj **Properties**, och på fliken **Security** ta bort alla explicit tilldelade behörigheter, så att endast ärvda behörigheter finns kvar. Om fliken **General** visar ett alternativ **Unblock**, välj det.

2. Spara en kopia av *rsreportserver.config* och öppna sedan filen i en textredigerare. Lägg till dessa poster inom `<Render>`‑elementet:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Varje post registrerar ett exportformat; `Name` måste vara unik bland renderingtilläggena. MSI‑installationsprogrammet registrerar samma sex namn och typer. Utelämna en post om du inte vill ha dess format i exportlistan.

3. Spara en kopia av *rssrvpolicy.config* och öppna sedan filen i en textredigerare. Hitta kodgruppen vars `Description` är "This code group grants MyComputer code Execution permission." och lägg till denna kodgrupp som dess sista undergrupp:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` är den offentliga nyckeln för Aspose.Slides.ReportingServices‑assemblyn. Behåll den på en rad.

4. Spara båda filerna. Rapportservern läser sina konfigurationsfiler igen varje gång de sparas. Om en fil innehåller felaktig XML ignorerar rapportservern den eller startar inte, så återställ din kopia om något går fel.

## **Kontrollera installationen**

Öppna en paginerad rapport i webbportalen (Report Manager på SQL Server 2014 och tidigare) och öppna **Export**‑listan. Den innehåller nu följande format:

- PPT – PowerPoint‑presentation via Aspose.Slides
- PPS – PowerPoint‑bildspel via Aspose.Slides
- PPTX – PowerPoint 2007‑presentation via Aspose.Slides
- PPSX – PowerPoint 2007‑bildspel via Aspose.Slides
- ODP – OpenDocument‑presentation via Aspose.Slides
- XPS – via Aspose.Slides

Välj ett av dem för att exportera rapporten. Filen öppnas i det program som är associerat med dess format.

![En rapport exporterad till PowerPoint av Aspose.Slides for Reporting Services](install-manually_2.png)

Om formaten inte visas, kontrollera NTFS‑behörigheterna för den kopierade assemblyn. Utan licens har exporterade filer ett utvärderingsvattenstämpel; se [Licensiering](/slides/sv/reportingservices/license-aspose-slides-for-reporting-services/).