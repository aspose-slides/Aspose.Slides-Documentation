---
title: Skapa presentationer i Python
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/python-net/create-presentation/
keywords:
- skapa presentation
- ny presentation
- skapa PPT
- ny PPT
- skapa PPTX
- ny PPTX
- skapa ODP
- ny ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Skapa PowerPoint-presentationer i Python med Aspose.Slides—generera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programatiskt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur du skapar en presentation med Aspose.Slides för Python via .NET, lägger till en form med text på dess första bild och sparar resultatet som en PPTX‑fil. Samma API kan också spara presentationer som PPT och ODP, så du kan rikta dig mot både PowerPoint‑ och OpenDocument‑format från en kodbas, utan Microsoft Office. En kort FAQ i slutet täcker vanliga frågor om format, mallar, bildstorlek, enheter, minnesanvändning, trådar, licensiering, digitala signaturer och VBA‑stöd.

Innan du börjar, installera paketet från PyPI med `pip install aspose.slides`. Se [Installation](/slides/sv/python-net/installation/) för de bibliotek som Linux och macOS också behöver, och för den virtuella miljö som system‑Python för Debian och Ubuntu kräver.

## **Skapa en presentation**

För att skapa en presentation och placera en form med text på dess första bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). En ny presentation innehåller redan en tom bild.  
2. Hämta den bilden från samlingen [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) med dess index, 0.  
3. Lägg till en molnformad [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) med metoden [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) för bildens [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)‑samling, och sätt dess [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/).  
4. Spara presentationen som en PPTX‑fil med metoden [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Spara presentationen som en PPTX-fil.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Molnets övre vänstra hörn är 20 punkter från bildens vänstra kant och 20 punkter från bildens övre kant, och molnet är 200 punkter brett och 80 punkter högt. `with`‑satsen frigör presentationens resurser när blocket avslutas. Skriptet sparar *new_presentation.pptx* i den aktuella mappen, med en bild som innehåller molnet och dess text. Utan licens lägger Aspose.Slides även till en utvärderingsvattenstämpel på varje bild den sparar; se [Licensing](/slides/sv/python-net/licensing/).

Resultatet:

![Den nya presentationen](new_presentation.png)

## **Vanliga frågor**

### Vilka format kan jag spara en ny presentation till?

Du kan spara till [PPTX, PPT och ODP](/slides/sv/python-net/save-presentation/), och exportera till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/sv/python-net/convert-powerpoint-to-xps/), [HTML](/slides/sv/python-net/convert-powerpoint-to-html/), [SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/), och [bilder](/slides/sv/python-net/convert-powerpoint-to-png/), bland annat.

### Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?

Ja. Ladda mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/python-net/supported-file-formats/).

### Hur styr jag bildstorlek/bildförhållande när jag skapar en presentation?

Ställ in [slide size](/slides/sv/python-net/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller anpassade dimensioner) och välj hur innehåll ska skalas.

### I vilka enheter mäts storlekar och koordinater?

I punkter: 1 tum motsvarar 72 enheter.

### Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändningen?

Använd [BLOB management strategies](/slides/sv/python-net/manage-blob/), begränsa in‑minne‑lagring genom att utnyttja temporära filer, och föredra fil‑baserade arbetsflöden framför rena minnesströmmar.

### Kan jag skapa/spara presentationer parallellt?

Du kan inte arbeta med samma [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/python-net/multithreading/). Kör separata, isolerade instanser per tråd eller process.

### Hur tar jag bort provvattenstämpeln och begränsningarna?

[Apply a license](/slides/sv/python-net/licensing/) en gång per process. Licens‑XML‑filen får inte ändras, och licensinställningen bör synkroniseras om flera trådar är involverade.

### Kan jag digitalt signera den PPTX jag skapar?

Ja. [Digital signatures](/slides/sv/python-net/digital-signature-in-powerpoint/) (lägg till och verifiera) stöds för presentationer.

### Stöds makron (VBA) i skapade presentationer?

Ja. Du kan [create/edit VBA projects](/slides/sv/python-net/presentation-via-vba/) och spara makro‑aktiverade filer som PPTM/PPSM.