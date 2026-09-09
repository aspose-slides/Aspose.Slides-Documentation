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
description: "Skapa presentationer i Python via Java med Aspose.Slides — producera PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programmässigt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur du skapar en presentation med Aspose.Slides för Python via Java, lägger till en form med text på den första bilden och sparar resultatet som en PPTX‑fil. FAQ‑avsnittet täcker utskriftsformat, mallar, bildstorlek, minnesanvändning, trådar, licensiering, digitala signaturer och VBA‑stöd.

## **Skapa en presentation**

Att skapa en PowerPoint‑fil från grunden i Aspose.Slides för Python via Java är lika enkelt som att instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/). Konstruktorn levererar automatiskt en tom deck med en enda bild, vilket ger dig en omedelbar arbetsyta för former, text, diagram eller annat innehåll som din applikation behöver. När du har ändrat den bilden – eller lagt till nya – kan du spara resultatet som PPTX, äldre PPT eller till och med OpenDocument‑format. Koden nedan illustrerar detta arbetsflöde genom att lägga till en enkel form på den första bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta den första bilden med dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) av typen [ShapeType.Cloud](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#Cloud) med hjälp av [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape).
4. Ange formens text med [TextFrame.setText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/#setText).
5. Spara presentationen med [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) och [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Pptx).

Följande exempel kräver Aspose.Slides för Python via Java och en kompatibel Java‑runtime. Det startar JVM:n om den inte redan körs, lägger till en molnform på den första bilden och sparar presentationen:

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

    # Lägg till en molnform och ange dess text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Spara presentationen som en PPTX-fil.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Den nya presentationen](new_presentation.png)

## **Vanliga frågor**

**Vilka format kan jag spara en ny presentation till?**

Du kan spara till [PPTX, PPT, and ODP](/slides/sv/python-java/save-presentation/) och exportera till [PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/sv/python-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/python-java/convert-powerpoint-to-html/), [SVG](/slides/sv/python-java/render-slide-as-svg/) och [images](/slides/sv/python-java/convert-powerpoint-to-png/), bland annat.

**Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Ladda mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/python-java/supported-file-formats/).

**Hur styr jag bildstorlek/bildförhållande när jag skapar en presentation?**

Ange [slide size](/slides/sv/python-java/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller anpassade dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändningen?**

Använd [BLOB management strategies](/slides/sv/python-java/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer och föredra filbaserade arbetsflöden framför enbart minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/python-java/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort provvattenstämpeln och begränsningarna?**

[Tilldela en licens](/slides/sv/python-java/licensing/) en gång per process. Licens‑XML‑filen får inte modifieras, och licensinställningarna bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera PPTX‑filen jag skapar?**

Ja. [Digital signatures](/slides/sv/python-java/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [create/edit VBA projects](/slides/sv/python-java/presentation-via-vba/) och spara makro‑aktiverade filer såsom PPTM/PPSM.