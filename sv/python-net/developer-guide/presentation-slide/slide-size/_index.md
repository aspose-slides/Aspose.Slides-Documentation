---
title: Ändra bildstorlek i presentationer med Python
linktitle: Bildstorlek
type: docs
weight: 70
url: /sv/python-net/slide-size/
keywords:
- bildstorlek
- bildförhållande
- standard
- bredskärm
- 4:3
- 16:9
- ange bildstorlek
- ändra bildstorlek
- anpassad bildstorlek
- särskild bildstorlek
- unik bildstorlek
- fullstor bild
- skärmtyp
- skala inte
- säkerställ passning
- maximera
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
descriptions: "Lär dig snabbt hur du ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med Python och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides erbjuder omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint-presentationer, vilket är avgörande både för utskrift och för visning på skärm. 

Populära bildstorlekar och förhållanden:

- **Standard (4:3 bildförhållande)**: Idealisk för äldre skärmar och enheter.
- **Bredskärm (16:9 bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela presentationen eftersom en enda bildstorlek och bildförhållande gäller för alla bilder. För bästa resultat, ange bildens dimensioner i början av skapandeprocessen för att undvika komplikationer.

{{% alert color="primary" %}} 
Som standard använder presentationer som skapats med Aspose.Slides det vanliga 4:3‑förhållandet.
{{% /alert %}}

## **Ändra bildstorlek i en presentation**

Det här exempelprogrammet visar hur du ändrar bildstorleken i en presentation i Python med Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange anpassade bildstorlekar**

Om du anser att de vanliga bildstorlekarna (4:3 och 16:9) är olämpliga för ditt arbete, kan du välja att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut bilder i full storlek från din presentation på en anpassad sidlayout eller om du avser att visa presentationen på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för presentationen. 

Det här exempelprogrammet visar hur du använder Aspose.Slides för Python via .NET för att ange en anpassad bildstorlek för en presentation i Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4-pappersstorlek
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera bildinnehåll efter storleksändring**

Efter att du har ändrat bildstorleken för en presentation kan bildens innehåll (bilder eller objekt, till exempel) bli förvrängt. Som standard anpassas objekten automatiskt för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du avser att göra eller uppnå kan du använda någon av dessa inställningar:

- `DO_NOT_SCALE`

  Om du INTE vill att objekten på bilderna ska skalas om, använd denna inställning.

- `ENSURE_FIT`

  Om du vill skala till en mindre bildstorlek och behöver att Aspose.Slides minskar bildernas objekt för att säkerställa att de alla får plats på bilderna (så undviker du att förlora innehåll), använd denna inställning.

- `MAXIMIZE`

  Om du vill skala till en större bildstorlek och behöver att Aspose.Slides förstorar bildernas objekt så att de blir proportionella mot den nya bildstorleken, använd denna inställning.

Det här exempelprogrammet visar hur du använder `MAXIMIZE`-inställningen när du ändrar storleken på en presentations bild:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Vanliga frågor**

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (till exempel punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning vid rendering?**

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökad minnesförbrukning och längre bearbetningstid. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?**

Du kan inte [merge presentations](/slides/sv/python-net/merge-presentation/) när de har olika bildstorlekar – först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidesizescaletype/). Efter att storlekarna har justerats kan du slå ihop bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrer för enskilda former eller specifika regioner på en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrer för [entire slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/) samt för [selected shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.