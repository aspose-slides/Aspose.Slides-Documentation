---
title: Instalovat ručně
type: docs
weight: 30
url: /cs/reportingservices/install-manually/
keywords:
- ruční instalace
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Instalujte Aspose.Slides for Reporting Services ručně z balíčku ZIP obsahujícího pouze DLL: kterou sestavu zkopírovat a co přidat do rsreportserver.config a rssrvpolicy.config."
---
## **Přehled**

Postupujte podle těchto kroků pro instalaci Aspose.Slides for Reporting Services bez instalátoru MSI, z balíčku ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* na [download page](https://releases.aspose.com/slides/reportingservices/). Registrují stejná rozšíření jako [MSI installer](/slides/cs/reportingservices/install-with-msi-installer/). Opakujte je pro každou instanci serveru reportů.

Před zahájením zkontrolujte [systémové požadavky](/slides/cs/reportingservices/system-requirements/). Na serveru reportů potřebujete lokální oprávnění správce.

## **Vyberte sestavu**

Balíček ZIP obsahuje několik sestavení. Zkopírujte přesně jeden *Aspose.Slides.ReportingServices.dll* na server reportů:

| Soubor v balíčku ZIP | Použít pro |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 a novější Reporting Services a Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Ne pro server reportů: aplikace, které exportují z ovládacího prvku ReportViewer 2010 nebo 2012, viz [Použití Aspose.Slides s ReportViewer 2010 a 2012](/slides/cs/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Volitelné: ukládá reporty ve formátu RPL pro hlášení problémů, viz [Exportování reportů do formátu RPL](/slides/cs/reportingservices/exporting-reports-to-rpl-format/) |

## **Najděte složku serveru reportů**

Níže uvedené kroky odkazují na složku *ReportServer* serveru reportů, která obsahuje *rsreportserver.config* a *rssrvpolicy.config*. Ve výchozí instalaci je to:

| Server reportů | Výchozí složka *ReportServer* |
| :- | :- |
| SQL Server 2017 a novější Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 a starší Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, where the instance folder is, for example, `MSRS13.MSSQLSERVER` for SQL Server 2016 or `MSSQL.x` for SQL Server 2005 |

Pro další umístění viz článek Microsoftu [RsReportServer.config configuration file](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Instalace rozšíření**

1. Zkopírujte vybranou sestavu do podsložky *bin* ve složce *ReportServer*.

   Zkopírovaný soubor nesmí mít explicitně přiřazená oprávnění NTFS, jinak server reportů odmítne přístup při načítání sestavy a nové formáty exportu se nezobrazí. Klikněte pravým tlačítkem na soubor, vyberte **Properties**, a na kartě **Security** odstraňte všechna explicitně přiřazená oprávnění, ponechte pouze zděděná. Pokud karta **General** zobrazuje možnost **Unblock**, vyberte ji.

1. Uložte kopii *rsreportserver.config* a poté otevřete soubor v textovém editoru. Přidejte tyto položky uvnitř elementu `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Každá položka registrová jeden exportní formát; `Name` musí být jedinečný mezi vykreslovacími rozšířeními. Instalátor MSI registruje stejných šest názvů a typů. Vynechte položku, pokud nechcete její formát v seznamu exportu.

1. Uložte kopii *rssrvpolicy.config* a poté otevřete soubor v textovém editoru. Najděte skupinu kódu, jejíž `Description` je "This code group grants MyComputer code Execution permission." a přidejte tuto skupinu kódu jako její poslední podřízenou:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` je veřejný klíč sestavy Aspose.Slides.ReportingServices. Udržujte jej v jednom řádku.

1. Uložte oba soubory. Server reportů načte své konfigurační soubory znovu pokaždé, když jsou uloženy. Pokud soubor obsahuje poškozený XML, server reportů jej ignoruje nebo se nespustí, proto obnovte svou kopii, pokud se něco pokazí.

## **Zkontrolujte instalaci**

Otevřete stránkovaný report ve webovém portálu (Report Manager na SQL Server 2014 a dříve) a otevřete seznam **Export**. Nyní obsahuje následující formáty:

- PPT – PowerPoint prezentace pomocí Aspose.Slides
- PPS – PowerPoint SlideShow pomocí Aspose.Slides
- PPTX – PowerPoint 2007 prezentace pomocí Aspose.Slides
- PPSX – PowerPoint 2007 SlideShow pomocí Aspose.Slides
- ODP – OpenDocument prezentace pomocí Aspose.Slides
- XPS – pomocí Aspose.Slides

Vyberte jeden z nich pro export reportu. Soubor se otevře v aplikaci přiřazené k jeho formátu.

![Report exportovaný do PowerPointu pomocí Aspose.Slides for Reporting Services](install-manually_2.png)

Pokud se formáty nezobrazí, zkontrolujte oprávnění NTFS zkopírované sestavy. Bez licence obsahují exportované soubory vodotisk s hodnocením; viz [Licencování](/slides/cs/reportingservices/license-aspose-slides-for-reporting-services/).