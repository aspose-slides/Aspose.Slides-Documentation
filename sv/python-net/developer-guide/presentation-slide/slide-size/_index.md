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
- Python
- Aspose.Slides
description: "Lär dig hur du snabbt ändrar storlek på bilder i PPT-, PPTX- och ODP-filer med Python och Aspose.Slides, optimera presentationer för vilken skärm som helst utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides erbjuder omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint‑presentationer, vilket är kritiskt både för utskrift och visning på skärm.

Vanliga bildstorlekar och förhållanden:

- **Standard (4:3‑förhållande)**: Perfekt för äldre skärmar och enheter.
- **Widescreen (16:9‑förhållande)**: Rekommenderas för moderna projektorer och bildskärmar.

Se till att hålla enhetlighet i hela presentationen, eftersom en enda bildstorlek och ett bildförhållande gäller för alla bilder. För bästa resultat, ange bildens mått i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="primary" %}} 
Som standard använder presentationer som skapas med Aspose.Slides bildförhållandet 4:3.
{{% /alert %}}

## **Ändra bildstorlek i en presentation**

Detta exempel visar hur du ändrar bildstorleken i en presentation i Python med Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange anpassade bildstorlekar**

Om de vanliga bildstorlekarna (4:3 och 16:9) inte passar ditt arbete kan du välja en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut bilder i full storlek på ett anpassat sidlayout eller om du vill visa presentationen på vissa skärmar, kan en egen storleksinställning vara fördelaktig.

Detta exempel visar hur du med Aspose.Slides för Python via .NET anger en anpassad bildstorlek för en presentation i Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4-pappersstorlek
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera bildinnehåll efter storleksändring**

När du ändrar bildstorleken för en presentation kan bildens innehåll (bilder eller objekt, till exempel) bli förvrängt. Som standard skalas objekten automatiskt om för att passa den nya storleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du vill åstadkomma kan du använda någon av dessa inställningar:

- `DO_NOT_SCALE`

  Om du INTE vill att objekten på bilderna ska skalas, använd denna inställning.

- `ENSURE_FIT`

  Om du vill skala till en mindre bildstorlek och vill att Aspose.Slides minskar objekten så att de alla får plats på bilderna (för att undvika förlorat innehåll), använd denna inställning.

- `MAXIMIZE`

  Om du vill skala till en större bildstorlek och vill att Aspose.Slides förstorar objekten så att de är proportionella mot den nya storleken, använd denna inställning.

Detta exempel visar hur du använder `MAXIMIZE`‑inställningen när du ändrar storleken på en presentations bilder:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Kan jag ange en anpassad bildstorlek med enheter annat än tum (till exempel punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt motsvarar 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Påverkar en mycket stor anpassad bildstorlek prestanda och minnesanvändning vid rendering?**

Ja. Större bilddimensioner (i punkter) kombinerat med högre renderingsskala leder till ökat minnesutnyttjande och längre behandlingstid. Sträva efter en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?**

Du kan inte [sammanfoga presentationer](/slides/sv/python-net/merge-presentation/) när de har olika bildstorlekar – först måste du ändra storleken på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via alternativet [SlideSizeScaleType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidesizescaletype/). Efter att storlekarna har anpassats kan du slå ihop bilderna samtidigt som formateringen bevaras.

**Kan jag generera miniatyrbilder för enskilda former eller specifika områden på en bild, och respekterar de den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrbilder för [hela bilder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/) såväl som för [valda former](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/). De resulterande bilderna återspeglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.