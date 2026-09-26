---
title: Ändra presentationens bildstorlek i Python via Java
linktitle: Bildstorlek
type: docs
weight: 70
url: /sv/python-java/slide-size/
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
- skala inte
- säkerställ passning
- maximera
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du snabbt kan ändra storlek på bilder i PPT-, PPTX- och ODP-filer med Python via Java och Aspose.Slides, och optimera presentationer för alla skärmar utan att förlora kvalitet."
---
## **Introduktion**

Aspose.Slides erbjuder omfattande verktyg för att justera bildstorlek och bildförhållande i PowerPoint-presentationer, vilket är kritiskt både för utskrift och visning på skärm.

Populära bildstorlekar och förhållanden:

- **Standard (4:3 Aspect Ratio)**: Ideal för äldre skärmar och enheter.
- **Widescreen (16:9 Aspect Ratio)**: Rekommenderas för moderna projektorer och skärmar.

Säkerställ konsekvens i hela din presentation genom att en enda bildstorlek och bildförhållande tillämpas på alla bilder. För optimala resultat, ange bildens dimensioner i början av presentationsskapandet för att undvika komplikationer.

{{% alert color="info" title="Note" %}}
Som standard använder presentationer som skapats med Aspose.Slides det standardiserade 4:3‑förhållandet.
{{% /alert %}}

Antecknings- och utdelningssidor har separata dimensioner från vanliga bilder. Se [Anteckningssidans storlek](/slides/sv/python-java/notes-size/) för att ändra deras storlek och orientering.

## **Ändra bildstorlek i presentationer**

Det här exempelprogrammet visar hur du ändrar bildstorleken i en presentation i Python via Java med Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange anpassade bildstorlekar i presentationer**

Om du finner de vanliga bildstorlekarna (4:3 och 16:9) olämpliga för ditt arbete, kan du välja att använda en specifik eller unik bildstorlek. Till exempel, om du planerar att skriva ut bilder i full storlek från din presentation på en anpassad sidlayout eller om du avser att visa din presentation på vissa skärmtyper, kan du ha nytta av att använda en anpassad storleksinställning för din presentation.

Det här exempelprogrammet visar hur du använder Aspose.Slides för Python via Java för att ange en anpassad bildstorlek för en presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hantera bildinnehåll efter storleksändring**

När du ändrar bildstorleken för en presentation kan bildens innehåll (t.ex. bilder eller objekt) bli förvrängt. Som standard anpassas objekten automatiskt för att passa den nya bildstorleken. När du ändrar en presentations bildstorlek kan du dock ange en inställning som bestämmer hur Aspose.Slides hanterar innehållet på bilderna.

Beroende på vad du avser att göra eller uppnå kan du använda någon av dessa inställningar:

- [DoNotScale](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  Om du INTE vill att objekten på bilderna ska skalas, använd den här inställningen.

- [EnsureFit](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  Om du vill skala till en mindre bildstorlek och du behöver att Aspose.Slides skalar ner bildens objekt för att säkerställa att de alla får plats på bilderna (så undviker du att förlora innehåll), använd den här inställningen.

- [Maximize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  Om du vill skala till en större bildstorlek och du behöver att Aspose.Slides förstorar bildens objekt så att de blir proportionella mot den nya bildstorleken, använd den här inställningen.

Det här exempelprogrammet visar hur du använder [Maximize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesizescaletype/#Maximize)-inställningen när du ändrar storleken på en presentations bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag ange en anpassad bildstorlek med andra enheter än tum (t.ex. punkter eller millimeter)?**

Ja. Aspose.Slides använder punkter internt, där 1 punkt är lika med 1/72 tum. Du kan konvertera vilken enhet som helst (t.ex. millimeter eller centimeter) till punkter och använda de konverterade värdena för att definiera bildens bredd och höjd.

**Kommer en mycket stor anpassad bildstorlek att påverka prestanda och minnesanvändning under rendering?**

Ja. Större bilddimensioner (i punkter) i kombination med högre renderingsskala leder till ökad minnesförbrukning och längre bearbetningstid. Sikta på en praktisk bildstorlek och justera renderingsskalan endast vid behov för att uppnå önskad utskriftskvalitet.

**Kan jag definiera en icke‑standard bildstorlek och sedan slå ihop bilder från presentationer som har olika storlekar?**

Du kan inte [merge presentations](/slides/sv/python-java/merge-presentation/) medan de har olika bildstorlekar — först, ändra storlek på en presentation så att den matchar den andra. När du ändrar bildstorleken kan du välja hur befintligt innehåll hanteras via [SlideSizeScaleType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesizescaletype/)-alternativet. Efter att storlekarna har anpassats kan du slå ihop bilder samtidigt som formateringen bevaras.

**Kan jag generera miniatyrbilder för enskilda former eller specifika områden på en bild, och kommer de att respektera den nya bildstorleken?**

Ja. Aspose.Slides kan rendera miniatyrbilder för [entire slides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) såväl som för [selected shapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage). De resulterande bilderna speglar den aktuella bildstorleken och bildförhållandet, vilket säkerställer enhetlig inramning och geometri.