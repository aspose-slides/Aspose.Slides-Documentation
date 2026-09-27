---
title: Skapa presentationer i Python via Java
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/python-java/create-presentation/
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
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa presentationer i Python via Java med Aspose.Slides — producera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programatiskt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur du skapar en presentation med Aspose.Slides för Python via Java, lägger till en form med text på den första bilden och sparar resultatet som en PPTX‑fil. FAQ:n täcker utdataformat, mallar, bildstorlek, minnesanvändning, trådad körning, licensiering, digitala signaturer och VBA‑stöd.

Innan du börjar, installera Python, ett JDK, JPype och Aspose.Slides för Python via Java. Se [Installation](/slides/sv/python-java/installation/) för stegen på Windows, Linux och macOS.

## **Skapa en presentation**

Att skapa en PowerPoint‑fil från grunden i Aspose.Slides för Python via Java är lika enkelt som att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Konstruktorn levererar automatiskt en tom presentation med en enda bild, vilket ger dig en omedelbar duk för former, text, diagram eller annat innehåll som din applikation kräver. När du har ändrat den bilden — eller lagt till nya — kan du spara resultatet som PPTX, äldre PPT eller till och med OpenDocument‑format. Kodexemplet nedan visar detta arbetsflöde genom att lägga till en enkel form på den första bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta den första bilden genom dess index, 0.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) av typen [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) med hjälp av [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Ange formens text med [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText).
1. Spara presentationen med [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) och [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx).

Följande exempel startar Java Virtual Machine (JVM) om den inte redan körs, lägger till en molnform med text på den första bilden och sparar presentationen. Spara den som *create_presentation.py*:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Skapa en presentation med en tom bild.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en molnform och sätt dess text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Spara presentationen som en PPTX-fil.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kör skriptet i den miljö där du installerade paketen:

```sh
python create_presentation.py
```

Molnets övre vänstra hörn ligger 20 punkter från bildens vänstra och övre kanter, och molnet är 200 punkter brett och 80 punkter högt. Skriptet sparar *new_presentation.pptx* i den aktuella arbetskatalogen, med en bild som innehåller molnet och dess text. JVM fortsätter att köras tills Python‑processen avslutas; se [Limitations and API Differences](/slides/sv/python-java/limitations-and-api-differences/#import-the-library). Utan licens lägger Aspose.Slides också till en utvärderingsvattenstämpel‑textruta på varje bild den sparar; se [Licensing](/slides/sv/python-java/licensing/).

Resultatet:

![Den nya presentationen](new_presentation.png)

## **FAQ**

**Vilka format kan jag spara en ny presentation i?**

Du kan spara till [PPTX, PPT och ODP](/slides/sv/python-java/save-presentation/), och exportera till [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/python-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/python-java/convert-powerpoint-to-html/), [SVG](/slides/sv/python-java/render-a-slide-as-an-svg-image/) och [bilder](/slides/sv/python-java/convert-powerpoint-to-png/), bland annat.

**Kan jag börja med en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Läs in mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/python-java/supported-file-formats/).

**Hur styr jag bildstorlek/bildförhållande när jag skapar en presentation?**

Ange [bildstorlek](/slides/sv/python-java/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändning?**

Använd [BLOB-hanteringsstrategier](/slides/sv/python-java/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer och föredra filbaserade arbetsflöden framför rena minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta med samma [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/python-java/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort utvärderingsvattenstämpeln och begränsningarna?**

[Applicera en licens](/slides/sv/python-java/licensing/) en gång per process. Licens‑XML‑filen får inte ändras, och licensinställningen bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera PPTX‑filen jag skapar?**

Ja. [Digitala signaturer](/slides/sv/python-java/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [skapa/redigera VBA‑projekt](/slides/sv/python-java/presentation-via-vba/) och spara makro‑aktiverade filer såsom PPTM/PPSM.