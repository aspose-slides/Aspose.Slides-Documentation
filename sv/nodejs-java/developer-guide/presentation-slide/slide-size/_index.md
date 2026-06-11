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
- särskild bildstorlek
- unik bildstorlek
- fullstor bild
- skärmtyp
- skalera inte
- säkra passning
- maximera
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "Lär dig hur du snabbt ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med Node.js och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildens storlek och bildförhållande i PowerPoint-presentationer, vilket är kritiskt både för utskrift och för visning på skärm. 

Populära bildstorlekar och förhållanden:

- **Standard (4:3 Bildförhållande)**: Idealiskt för äldre skärmar och enheter.
- **Bredbild (16:9 Bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela presentationen eftersom en enda bildstorlek och bildförhållande gäller för alla bilder. För optimala resultat, ange bildens dimensioner i början av skapandeprocessen för din presentation för att undvika komplikationer.

{{% alert color="primary" %}} 
Som standard använder presentationer som skapats med Aspose.Slides standardbildförhållandet 4:3.
{{% /alert %}}

## **Ändra bildstorlek i presentationer**

Detta exempel visar hur du ändrar bildstorleken i en presentation i JavaScript med Aspose.Slides:

```javascript
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

Detta exempel visar hur du använder Aspose.Slides för Node.js via Java för att ange en anpassad bildstorlek för en presentation i JavaScript:

```javascript
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

Efter att du ändrat bildstorleken för en presentation kan bildens innehåll (bilder eller objekt, till exempel) bli förvrängt. Som standard ändras objekten automatiskt för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du avser att göra eller uppnå kan du använda någon av dessa inställningar:

- `DoNotScale`

  Om du INTE vill att objekten på bilderna ska skalas om, använd denna inställning.

- `EnsureFit`

  Om du vill skala till en mindre bildstorlek och du behöver att Aspose.Slides ska minska bildens objekt för att säkerställa att de alla får plats på bilderna (så undviker du förlust av innehåll), använd denna inställning.

- `Maximize`

  Om du vill skala till en större bildstorlek och du behöver att Aspose.Slides ska förstora bildens objekt så att de blir proportionella mot den nya bildstorleken, använd denna inställning.

Detta exempel visar hur du använder inställningen `Maximize` när du ändrar storleken på en presentations bild:

```javascript
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

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (till exempel punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning vid rendering?**

Ja. Större bilddimensioner (i punkter) ihop med högre renderingsskala leder till ökat minnesbruk och längre behandlingstider. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utmatningskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå samman bilder från presentationer som har olika storlekar?**

Du kan inte [slå samman presentationer](/slides/sv/nodejs-java/merge-presentation/) när de har olika bildstorlekar — först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesizescaletype/). Efter att storlekarna har anpassats kan du slå samman bilder samtidigt som du bevarar formateringen.

**Kan jag generera miniatyrbilder för enskilda former eller specifika områden på en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrbilder för [hela bilder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage) såväl som för [valda former](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getImage). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer en konsekvent inramning och geometri.