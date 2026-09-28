---
title: Instalovat pomocí MSI instalátoru
type: docs
weight: 20
url: /cs/reportingservices/install-with-msi-installer/
keywords:
- MSI instalátor
- instalace
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Instalujte Aspose.Slides for Reporting Services pomocí jeho MSI instalátoru: co instalátor potřebuje, co mění na každé instanci serveru zpráv, a jak zkontrolovat výsledek."
---
## **Instalace**

Instalátor MSI je nejsnazší způsob, jak nainstalovat Aspose.Slides for Reporting Services. Vyžaduje .NET Framework 3.5 a administrátorská práva na serveru zpráv; viz [Systémové požadavky](/slides/cs/reportingservices/system-requirements/).

1. Stáhněte MSI instalátor, *Aspose.Slides for Reporting Services XX.XX*, ze [stránky ke stažení](https://releases.aspose.com/slides/cs/reportingservices/) a zkopírujte jej na server zpráv.
2. Spusťte jej jako administrátor. Pokud chybí .NET Framework 3.5, instalátor se zastaví zprávou; nainstalujte funkce .NET Framework 3.5 a spusťte jej znovu.
3. Přijměte licenční ujednání.
4. Na stránce **Custom Setup** strom funkcí zobrazuje každou instanci SQL Server Reporting Services a Power BI Report Server, kterou instalátor na počítači detekuje. Pro zachování instance beze změny klikněte na její ikonu a vyberte **Entire feature will be unavailable**. Edice Express nepodporují vykreslovací rozšíření, proto nevybírejte instanci Express. Instalátor skryje Express instance SQL Serveru 2016 a starší.
5. Vyberte **Next**, a poté **Install**.
6. Volitelná funkce **Rpl Export** není ve výchozím nastavení vybrána. Přidává skryté rozšíření, které ukládá zprávy ve formátu RPL, což je užitečné při odesílání hlášení o problému společnosti Aspose; viz [Exportování zpráv do formátu RPL](/slides/cs/reportingservices/exporting-reports-to-rpl-format/).

## **Co instalátor mění**

Instalátor ukládá své soubory do *Aspose\Aspose.Slides for Reporting Services* ve složce Program Files — *Program Files (x86)* na 64‑bitovém Windows, protože instalátor je 32‑bitový balíček. Poté pro každou vybranou instanci:

- kopíruje *Aspose.Slides.ReportingServices.dll* do složky *ReportServer\bin* instance — sestavení pro SQL Server 2005 nebo sestavení pro SQL Server 2008 a novější a Power BI Report Server;
- přidává šest vykreslovacích rozšíření — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS a ASODP — do elementu `<Render>` souboru *rsreportserver.config*;
- přidává skupinu kódu, která uděluje sestavení plnou důvěru v souboru *rssrvpolicy.config*;
- ukládá kopii každého konfiguračního souboru, který mění, s příponou *.bak* připojenou k názvu souboru.

[Instalovat ručně](/slides/cs/reportingservices/install-manually/) ukazuje tyto změny krok za krokem.

Pokud nelze instanci nakonfigurovat, instalátor ji uvede ve zprávě a zapíše podrobnosti do *rserrors<date>.log* ve složce instalace. Rozšíření nainstalujte na tuto instanci ručně.

## **Kontrola instalace**

Otevřete stránkovanou zprávu ve webovém portálu (Report Manager na SQL Serveru 2014 a starším) a otevřete seznam **Export**. Nyní obsahuje následující formáty:

- PPT – PowerPoint prezentace přes Aspose.Slides
- PPS – PowerPoint SlideShow přes Aspose.Slides
- PPTX – PowerPoint 2007 prezentace přes Aspose.Slides
- PPSX – PowerPoint 2007 SlideShow přes Aspose.Slides
- ODP – OpenDocument prezentace přes Aspose.Slides
- XPS – přes Aspose.Slides

Bez licence obsahují exportované soubory vodotisk hodnocení; viz [Licencování](/slides/cs/reportingservices/license-aspose-slides-for-reporting-services/).

## **Kdy instalovat ručně**

Rozšíření nainstalujte [ručně](/slides/cs/reportingservices/install-manually/) místo toho, když:

- instalátor nemůže nakonfigurovat instanci, například kvůli nastavením zabezpečení na serveru;
- po upgradu chcete nahradit pouze sestavení místo odinstalace staré verze a spuštění nového instalátoru.

Odinstalace produktu odstraní sestavení a konfigurační položky z každé instance.