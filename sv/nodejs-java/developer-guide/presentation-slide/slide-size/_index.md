---
title: Ändra presentationens bildstorlek i JavaScript
linktitle: Bildstorlek
type: docs
weight: 70
url: /sv/nodejs-java/slide-size/
keywords:
- bildstorlek
- bildförhållande
- standard
- bredbild
- 4:3
- 16:9
- ange bildstorlek
- ändra bildstorlek
- anpassad bildstorlek
- speciell bildstorlek
- unik bildstorlek
- fullstor bild
- skärmtyp
- skala inte
- säkerställ passning
- maximera
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig snabbt hur du ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med Node.js och Aspose.Slides, optimera presentationer för alla skärmar utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint-presentationer, vilket är avgörande både för utskrift och skärmvisning.

Populära bildstorlekar och förhållanden:

- **Standard (4:3 bildförhållande)**: Ideal för äldre skärmar och enheter.
- **Bredbild (16:9 bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela din presentation eftersom en enda bildstorlek och bildförhållande gäller för alla bilder. För optimala resultat, ange dina bilddimensioner i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="info" title="Note" %}}
Som standard använder presentationer som skapas med Aspose.Slides det standardiserade 4:3 bildförhållandet.
{{% /alert %}}

Antecknings- och utdelningssidor har separata dimensioner från vanliga bilder. Se [Anteckningssidans storlek](/slides/sv/nodejs-java/notes-size/) för att ändra deras storlek och orientering.

## **Ändra bildstorlek i presentationer**

Denna exempel kod visar hur du ändrar bildstorlek i en presentation i JavaScript med Aspose.Slides:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange anpassade bildstorlekar i presentationer**

Om du finner de vanliga bildstorlekarna (4:3 och 16:9) olämpliga för ditt arbete, kan du välja att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut bilder i full storlek från din presentation på en anpassad sidlayout eller om du avser att visa din presentation på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för din presentation.

Denna exempel kod visar hur du använder Aspose.Slides för Node.js via Java för att ange en anpassad bildstorlek för en presentation i JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4-pappersstorlek
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hantera problem vid ändring av bildstorlek i presentationer**

Efter att du har ändrat bildstorleken för en presentation kan bildens innehåll (t.ex. bilder eller objekt) bli förvrängt. Som standard blir objekten automatiskt storleksändrade för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du avser att göra eller uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna ska storleksändras, använd denna inställning.

- `EnsureFit`

  Om du vill skala till en mindre bildstorlek och du behöver att Aspose.Slides skalär ner bildens objekt för att säkerställa att de alla får plats på bilderna (så att du undviker att förlora innehåll), använd denna inställning.

- `Maximize`

  Om du vill skala till en större bildstorlek och du behöver att Aspose.Slides förstorar bildens objekt så att de blir proportionella mot den nya bildstorleken, använd denna inställning.

Denna exempel kod visar hur du använder `Maximize`-inställningen när du ändrar storleken på en presentations bild:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (t.ex. punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning under rendering?**

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökat minnesbruk och längre bearbetningstid. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke-standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?**

Du kan inte [slå ihop presentationer](/slides/sv/nodejs-java/merge-presentation/) när de har olika bildstorlekar — först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesizescaletype/). Efter att storlekarna justerats kan du slå ihop bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrbilder för enskilda former eller specifika områden på en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrbilder för [hela bilder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage) lika väl som för [utvalda former](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getImage). De resulterande bilderna återger den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.