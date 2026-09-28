---
title: Telepítés MSI telepítővel
type: docs
weight: 20
url: /hu/reportingservices/install-with-msi-installer/
keywords:
- MSI telepítő
- telepítés
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Telepítse az Aspose.Slides for Reporting Services terméket az MSI telepítőjével: mit igényel a telepítő, mit módosít minden jelentéskiszolgáló példányon, és hogyan ellenőrizheti az eredményt."
---
## **Telepítés**

Az MSI telepítő a legegyszerűbb módja az Aspose.Slides for Reporting Services telepítésének. .NET Framework 3.5-re és rendszergazdai jogokra van szüksége a jelentéskiszolgálón; lásd a [Rendszerkövetelmények](/slides/hu/reportingservices/system-requirements/) oldalt.

1. Töltse le az MSI telepítőt, *Aspose.Slides for Reporting Services XX.XX*-t a [letöltési oldal](https://releases.aspose.com/slides/reportingservices/) oldalról, és másolja a jelentéskiszolgálóra.  
2. Futtassa rendszergazdaként. Ha a .NET Framework 3.5 hiányzik, a telepítő egy üzenettel leáll; telepítse a .NET Framework 3.5 funkciókat, és futtassa újra.  
3. Fogadja el a licencszerződést.  
4. A **Custom Setup** oldalon a funkciófa felsorolja a telepítő által a gépen észlelt minden SQL Server Reporting Services és Power BI Report Server példányt. Egy példány változatlanul hagyásához kattintson annak ikonjára, és válassza az **A teljes funkció nem lesz elérhető** lehetőséget. Az Express kiadások nem támogatják a renderelési kiegészítőket, ezért ne válasszon Express példányt. A telepítő elrejti a SQL Server 2016 és korábbi Express példányait.  
5. Válassza a **Következő**-t, majd a **Telepítés**-t.

Az opcionális **Rpl Export** funkció alapértelmezés szerint nincs kiválasztva. Egy rejtett kiegészítőt ad hozzá, amely RPL formátumban menti a jelentéseket, ami akkor hasznos, ha problémajelentést küld az Aspose-nak; lásd a [Exporting Reports to RPL Format](/slides/hu/reportingservices/exporting-reports-to-rpl-format/) oldalt.

## **A telepítő által végzett változtatások**

A telepítő a fájljait a *Aspose\Aspose.Slides for Reporting Services* mappában tárolja a Program Files könyvtár alatt – *Program Files (x86)* a 64 bites Windows esetén, mivel a telepítő egy 32 bites csomag. Ezután minden kiválasztott példányra:

- áthelyezi a *Aspose.Slides.ReportingServices.dll*-t a példány *ReportServer\bin* mappájába – a SQL Server 2005-ös verzióhoz, vagy a SQL Server 2008 és újabb, valamint a Power BI Report Server verzióhoz;  
- hat renderelési kiegészítőt ad hozzá — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS és ASODP — a `<Render>` elemhez a *rsreportserver.config* fájlban;  
- hozzáad egy kódcsoportot, amely teljes megbízhatottságot biztosít a szerelvénynek a *rssrvpolicy.config* fájlban;  
- elment egy másolatot minden módosított konfigurációs fájlról, a fájlnévhez *.bak* kiterjesztést fűzve.

[Install Manually](/slides/hu/reportingservices/install-manually/) lépésről lépésre bemutatja ezeket a változtatásokat.

Ha egy példányt nem lehet konfigurálni, a telepítő egy üzenetben megnevezi, és a részleteket az *rserrors<date>.log* fájlba írja a telepítési mappában. Telepítse a kiegészítőt az adott példányra manuálisan.

## **A telepítés ellenőrzése**

Nyisson meg egy oldalazott jelentést a webportálon (Report Manager a SQL Server 2014 és régebbi verzióiban), és nyissa meg az **Export** listát. Most már a következő formátumokat tartalmazza:

- PPT – PowerPoint Prezentáció az Aspose.Slides használatával  
- PPS – PowerPoint Diavetítés az Aspose.Slides használatával  
- PPTX – PowerPoint 2007 Prezentáció az Aspose.Slides használatával  
- PPSX – PowerPoint 2007 Diavetítés az Aspose.Slides használatával  
- ODP – OpenDocument Prezentáció az Aspose.Slides használatával  
- XPS – az Aspose.Slides használatával  

Licenc nélkül az exportált fájlok értékelési vízjelet tartalmaznak; lásd a [Licensing](/slides/hu/reportingservices/license-aspose-slides-for-reporting-services/) oldalt.

## **Mikor érdemes manuálisan telepíteni**

A kiegészítőt [manuálisan](/slides/hu/reportingservices/install-manually/) telepítse, ha:

- a telepítő nem tud egy példányt konfigurálni, például a szerveren lévő biztonsági beállítások miatt;  
- frissítés után csak a szerelvényt szeretné cserélni, a régi verzió eltávolítása és az új telepítő futtatása helyett.

A termék eltávolítása törli a szerelvényt és a konfigurációs bejegyzéseket minden példányból.