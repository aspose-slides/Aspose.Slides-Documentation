---
title: Nasazení a aktivace
type: docs
weight: 20
url: /cs/sharepoint/deployment-and-activation/
description: "Co řešení Aspose.Slides pro SharePoint nainstaluje na farmu při nasazení a co přidá jeho funkce kolekce webů při aktivaci."
---
## **Nasazení**

Během nasazení řešení Aspose.Slides pro SharePoint:

- Instaluje jeho sestavu do Global Assembly Cache a přidá položky SafeControl do souboru **web.config**. Na SharePoint 2010 a novějších je to *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* nebo *Aspose.Slides.SharePoint2016.dll* (balíček pro SharePoint 2019 také instaluje *Aspose.Slides.SharePoint2016.dll*). Na SharePoint 2007 je to *Aspose.Slides.SharePointUI.dll* spolu s *Aspose.Slides.SharePoint.Deployment.dll*.
- Zkopíruje stránku pro konverzi, její obrázky a další podpůrné soubory do instalačních složek SharePoint.
- Instaluje funkci a zpřístupní ji pro aktivaci v kolekcích webů.

## **Aktivace**

Aspose.Slides pro SharePoint je balíčkován jako funkce kolekce webů a může být v kolekcích webů aktivován nebo deaktivován. Když je v kolekci webů aktivována, funkce přidá:

- Na SharePoint 2010 a novějších:
  - položku **Convert via Aspose.Slides** do nabídky dokumentů v knihovnách dokumentů;
  - záložku pásu karet **Aspose Tools** s tlačítkem **Convert Slides**, které převede vybrané dokumenty;
  - položku **View Slides** do nabídky souborů PPT, PPTX, PPS a PPSX.
- Na SharePoint 2007:
  - položku **Convert with Aspose.Slides** do nabídky dokumentů v knihovnách dokumentů;
  - položku **Convert All with Aspose.Slides** do nabídky **Actions** v knihovnách dokumentů.

Na SharePoint 2007 aktivace také provádí změny ve virtuálním adresáři nadřazené webové aplikace kolekce webů. Provádí to:

- Přidá stránku nastavení konverze do souboru sitemap.
- Zkopíruje potřebné soubory zdrojů do složky App_GlobalResources ve virtuálním adresáři.

Instalační program aktivuje funkci v kolekcích webů, které vyberete během [instalace](/slides/cs/sharepoint/installing-aspose-slides-for-sharepoint/).