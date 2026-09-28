---
title: Implementatie en Activatie
type: docs
weight: 20
url: /nl/sharepoint/deployment-and-activation/
description: "Wat de Aspose.Slides for SharePoint‑oplossing installeert op de farm wanneer deze wordt geïmplementeerd, en wat de site‑collectie‑feature toevoegt wanneer deze wordt geactiveerd."
---
## **Implementatie**

Tijdens de implementatie installeert de Aspose.Slides for SharePoint‑oplossing:

- Installeert zijn assembly in de Global Assembly Cache en voegt SafeControl‑vermeldingen toe aan het **web.config**‑bestand. Op SharePoint 2010 en later is dit *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* of *Aspose.Slides.SharePoint2016.dll* (het SharePoint‑2019‑pakket installeert ook *Aspose.Slides.SharePoint2016.dll*). Op SharePoint 2007 is het *Aspose.Slides.SharePointUI.dll*, samen met *Aspose.Slides.SharePoint.Deployment.dll*.
- Kopieert de conversie‑pagina en de bijbehorende afbeeldingen en andere ondersteunende bestanden naar de SharePoint‑installatiemap­pjes.
- Installeert de feature en maakt deze beschikbaar voor activatie op site‑collecties.

## **Activatie**

Aspose.Slides for SharePoint wordt verpakt als een site‑collectie‑feature en kan geactiveerd of gedeactiveerd worden op site‑collecties. Wanneer deze geactiveerd is op een site‑collectie, voegt de feature toe:

- Op SharePoint 2010 en later:
  - het **Convert via Aspose.Slides**‑item aan het contextmenu van documenten in documentbibliotheken;
  - het linttabblad **Aspose Tools** met de knop **Convert Slides**, die de geselecteerde documenten converteert;
  - het **View Slides**‑item aan het menu van PPT-, PPTX-, PPS- en PPSX‑bestanden.
- Op SharePoint 2007:
  - het **Convert with Aspose.Slides**‑item aan het contextmenu van documenten in documentbibliotheken;
  - het **Convert All with Aspose.Slides**‑item aan het **Actions**‑menu van documentbibliotheken.

Op SharePoint 2007 brengt de activatie tevens wijzigingen aan in de virtuele map van de bovenliggende webapplicatie van de site‑collectie. Het:

- Voegt de pagina met conversie‑instellingen toe aan het sitemap‑bestand.
- Kopieert de benodigde resource‑bestanden naar de map App_GlobalResources in de virtuele map.

Het installatieprogramma activeert de feature op de site‑collecties die je selecteert tijdens de [installatie](/slides/nl/sharepoint/installing-aspose-slides-for-sharepoint/).