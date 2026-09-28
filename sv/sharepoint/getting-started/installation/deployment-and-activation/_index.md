---
title: Distribution och Aktivering
type: docs
weight: 20
url: /sv/sharepoint/deployment-and-activation/
description: "Vad Aspose.Slides for SharePoint-lösningen installerar på farmen när den distribueras, och vad dess webbplatskollektionsfunktion lägger till när den aktiveras."
---
## **Distribution**

Under distribution installeras Aspose.Slides for SharePoint-lösningen:

- Installerar dess assembly i Global Assembly Cache och lägger till SafeControl-poster för den i **web.config**-filen. På SharePoint 2010 och senare är detta *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* eller *Aspose.Slides.SharePoint2016.dll* (paketet för SharePoint 2019 installerar också *Aspose.Slides.SharePoint2016.dll*). På SharePoint 2007 är det *Aspose.Slides.SharePointUI.dll*, tillsammans med *Aspose.Slides.SharePoint.Deployment.dll*.
- Kopierar konverteringssidan samt dess bilder och andra stödjande filer till SharePoints installationskataloger.
- Installerar funktionen och gör den tillgänglig för aktivering i webbplatskollektioner.

## **Aktivering**

Aspose.Slides for SharePoint är paketerad som en webbplatskollektionsfunktion och kan aktiveras eller inaktiveras i webbplatskollektioner. När den aktiveras i en webbplatskollektion lägger funktionen till:

- På SharePoint 2010 och senare:
  - **Convert via Aspose.Slides**‑objektet till dokumentmenyn i dokumentbibliotek;
  - fliken **Aspose Tools** i menyfliksområdet med knappen **Convert Slides**, som konverterar de valda dokumenten;
  - **View Slides**‑objektet till menyn för PPT‑, PPTX‑, PPS‑ och PPSX‑filer.
- På SharePoint 2007:
  - **Convert with Aspose.Slides**‑objektet till dokumentmenyn i dokumentbibliotek;
  - **Convert All with Aspose.Slides**‑objektet till **Actions**‑menyn i dokumentbibliotek.

På SharePoint 2007 gör aktivering också ändringar i den virtuella katalogen för den överordnade webbapplikationen till webbplatskollektionen. Den:

- Lägger till konverteringsinställningssidan i sitemap‑filen.
- Kopierar de nödvändiga resursfilerna till mappen App_GlobalResources i den virtuella katalogen.

Setup‑programmet aktiverar funktionen i de webbplatskollektioner du väljer under [installation](/slides/sv/sharepoint/installing-aspose-slides-for-sharepoint/).