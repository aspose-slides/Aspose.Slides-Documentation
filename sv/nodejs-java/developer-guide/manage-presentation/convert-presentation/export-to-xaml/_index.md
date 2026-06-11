---
title: Exportera presentationer till XAML i JavaScript
linktitle: Presentation till XAML
type: docs
weight: 30
url: /sv/nodejs-java/export-to-xaml/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- konvertera PowerPoint
- konvertera OpenDocument
- konvertera presentation
- PowerPoint till XAML
- OpenDocument till XAML
- presentation till XAML
- PPT till XAML
- PPTX till XAML
- ODP till XAML
- spara PPT som XAML
- spara PPTX som XAML
- spara ODP som XAML
- exportera PPT till XAML
- exportera PPTX till XAML
- exportera ODP till XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-bilder till XAML i JavaScript med Aspose.Slides för Node.js—snabb, kontorsfri lösning som behåller din layout intakt."
---
## **Översikt**

Denna artikel förklarar hur du exporterar PowerPoint‑presentationer till XAML med Aspose.Slides. Den innehåller en kort introduktion till XAML, visar hur du sparar en presentation till XAML med standardinställningar och demonstrerar hur du anpassar exporten via [XamlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/), inklusive export av dolda bilder. Artikeln svarar också på några vanliga frågor om fallback‑typsnitt, XAML‑stack‑kompatibilitet och beteende för export av dolda bilder.

## **Om XAML**

XAML är ett beskrivande programmeringsspråk som låter dig bygga eller skriva användarklasser för appar, särskilt de som använder WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) och Xamarin Forms.

XAML, som är ett XML‑baserat språk, är Microsofts variant för att beskriva ett GUI. Du använder troligen en designer för att arbeta med XAML‑filer mestadels, men du kan fortfarande skriva och redigera ditt GUI. 

## **Exportera presentationer till XAML med standardalternativ**

Denna JavaScript‑kod visar hur du exporterar en presentation till XAML med standardinställningar:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exportera presentationer till XAML med anpassade alternativ**

Du kan välja alternativ från klassen [XamlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/XamlOptions) som styr exportprocessen och bestämmer hur Aspose.Slides exporterar din presentation till XAML.

Om du vill att Aspose.Slides ska lägga till dolda bilder från din presentation vid export till XAML kan du sätta metoden [setExportHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) till true. Se detta exempel i JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hur kan jag säkerställa förutsägbara typsnitt om det ursprungliga typsnittet inte finns på maskinen?**

Använd [setDefaultRegularFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) i [XamlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/) — det används som ett reservtypsnitt när det ursprungliga saknas. Detta hjälper till att undvika oväntade ersättningar.

**Är den exporterade XAML:en avsedd endast för WPF, eller kan den även användas i andra XAML‑stackar?**

 XAML är ett generellt UI‑markup‑språk som används i WPF, UWP och Xamarin.Forms. Exporten syftar till kompatibilitet med Microsofts XAML‑stackar; exakt beteende och stöd för specifika konstruktioner beror på målplattformen. Testa markupen i din miljö.

**Stöds dolda bilder, och hur kan jag förhindra att de exporteras som standard?**

Som standard inkluderas inte dolda bilder. Du kan kontrollera detta beteende via [setExportHiddenSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) i [XamlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/xamloptions/) — håll den inaktiverad om du inte behöver exportera dem.