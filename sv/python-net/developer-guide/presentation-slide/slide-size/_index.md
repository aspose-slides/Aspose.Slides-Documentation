---
title: Ändra bildstorleken i presentationer med Python
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
description: "Lär dig snabbt ändra storlek på bilder i PPT-, PPTX- och ODP-filer med Python och Aspose.Slides, optimera presentationer för valfri skärm utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides tillhandahåller omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint-presentationer, vilket är kritiskt både för utskrift och för visning på skärm. 

Populära bildstorlekar och förhållanden:

- **Standard (4:3 bildförhållande)**: Idealiskt för äldre skärmar och enheter.
- **Bredskärm (16:9 bildförhållande)**: Rekommenderas för moderna projektorer och skärmar.

Se till att ha konsekvens i hela presentationen eftersom en enda bildstorlek och bildförhållande gäller för alla bilder. För bästa resultat, ange bildens dimensioner i början av skapandeprocessen för presentationen för att undvika problem.

{{% alert color="info" title="Note" %}}
Som standard använder presentationer som skapas med Aspose.Slides det vanliga 4:3‑bildförhållandet.
{{% /alert %}}

Antecknings- och utdelningssidor har separata dimensioner från vanliga bilder. Se [Notes Page Size](/slides/sv/python-net/notes-size/) för att ändra deras storlek och orientering.

## **Ändra bildstorlek i en presentation**

Det här exempelprogrammet visar hur du ändrar bildstorleken i en presentation i Python med Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange anpassade bildstorlekar**

Om du anser att de vanliga bildstorlekarna (4:3 och 16:9) inte passar för ditt arbete kan du välja att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut fullstora bilder från din presentation på en anpassad sidlayout eller om du avser att visa din presentation på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för presentationen. 

Det här exempelprogrammet visar hur du använder Aspose.Slides för Python via .NET för att ange en anpassad bildstorlek för en presentation i Python:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4-pappersstorlek
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera bildinnehåll efter storleksändring**

När du ändrar bildstorleken för en presentation kan bildens innehåll (bilder eller objekt, till exempel) bli förvrängt. Som standard får objekten automatiskt en storleksändring för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du vill göra eller uppnå kan du använda någon av dessa inställningar:

- `DO_NOT_SCALE`

  Om du INTE vill att objekten på bilderna ska storleksändras, använd denna inställning.

- `ENSURE_FIT`

  Om du vill skala till en mindre bildstorlek och du behöver att Aspose.Slides skalär ner bildens objekt för att säkerställa att de alla får plats på bilderna (så undviker du förlust av innehåll), använd denna inställning.

- `MAXIMIZE`

  Om du vill skala till en större bildstorlek och du behöver att Aspose.Slides förstorar bildens objekt så att de blir proportionerliga mot den nya bildstorleken, använd denna inställning.

Det här exempelprogrammet visar hur du använder `MAXIMIZE`‑inställningen när du ändrar storleken på en presentations bild:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (till exempel punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (till exempel millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning under rendering?**

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökad minnesförbrukning och längre bearbetningstider. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utmatningskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå samman bilder från presentationer som har olika storlekar?**

Du kan inte [slå samman presentationer](/slides/sv/python-net/merge-presentation/) medan de har olika bildstorlekar — först, ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidesizescaletype/). Efter att storlekarna har justerats kan du slå samman bilder samtidigt som formatet bevaras.

**Kan jag generera miniatyrbilder för enskilda former eller specifika områden i en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrbilder för [hela bilder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/) samt för [valda former](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer konsekvent inramning och geometri.