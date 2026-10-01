---
title: Ändra notssidans storlek och orientering i Python via Java
linktitle: Notssidans storlek
type: docs
weight: 10
url: /sv/python-java/notes-size/
keywords:
- notssidans storlek
- notsorientering
- liggande noter
- stående noter
- utdelningsstorlek
- PowerPoint
- presentation
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Läs och ändra notssidans dimensioner i Aspose.Slides för Python via Java, byt orientering, verifiera sparade storlekar och exportera noteringar eller utdelningar till PDF och bilder."
---
## **Översikt**

Använd [Presentation.getNotesSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getNotesSize) för att komma åt presentationens inställningar för notssidan. Den returnerar ett [NotesSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notessize/)‑objekt vars [setSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notessize/#setSize)‑metod sätter sidans dimensioner. Även om inställningsobjektet självt inte kan ersättas, kan du tilldela nya dimensioner via denna metod.

Bredd och höjd anges i **punkter**, med 72 punkter per tum. Till exempel är 900 × 600 punkter 12,5 × 8⅓ tum. Dessa inställningar gäller för hela presentationen, snarare än för en enskild slides anteckningar.

| Inställning | Syfte |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getNotesSize) | Styr notssidans dimensioner och sidans dimensioner som används för handout‑export. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSlideSize) | Styr vanliga presentationssidors dimensioner via [SlideSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesize/). |

Att ändra någon av inställningarna ändrar inte automatiskt den andra. Att ändra notssidans orientering roterar inte heller de vanliga slidsarna. Se [Slide Size](/slides/sv/python-java/slide-size/) för att ändra storlek på vanliga slidsar.

Exemplen nedan använder en befintlig `sample.pptx`. För exportexemplen, använd en presentation med minst ett bild som innehåller talarnoteringar. Varje exempel kan köras oberoende.

## **Läs notssidans storlek och orientering**

Läs av bredd och höjd och jämför dem för att bestämma orienteringen: en bredare sida är liggande, en högre sida är stående, och lika dimensioner beskriver en kvadratisk sida. Detta exempel skriver ut de faktiska dimensionerna i punkter, utan att anta en standardpappersstorlek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Byt till liggande utan att ändra pappersstorleken**

För att endast ändra orienteringen, byt bredd och höjd. Detta bevarar längden på båda sidor, inklusive de för en anpassad pappersstorlek. Villkoret nedan förhindrar att en redan liggande sida byts tillbaka till stående och lämnar en kvadratisk sida oförändrad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

För stående orientering, använd samma tilldelning när `size.getWidth() > size.getHeight()`. Byt inte ut A4‑ eller Letter‑dimensioner om du inte också vill ändra pappersstorleken.

## **Ställ in och verifiera en anpassad notssidans storlek**

Tilldela båda dimensionerna samtidigt, och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för att skriva presentationen. Detta exempel sätter en 900 × 600‑punkters liggande sida, sparar den som PPTX och öppnar den sparade filen igen för att kontrollera de bestående värdena. Jämförelsen tillåter en tolerans på 0,01 punkt för flyttalsvärden; det är ingen garanti för precision för varje filformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Det förväntade resultatet är `900.0 x 600.0 points` och `Size preserved: True`. Att kontrollera en nyöppnad presentation verifierar den sparade filen, snarare än endast inställningarna i minnet.

## **Exportera noteringar och utdelningar**

Sidans dimensioner definierar det tillgängliga området för noteringar eller utdelningslayouter. De aktiverar inte dessa layouter i sig; exportalternativen måste också konfigureras. Export av vanliga bilder fortsätter att använda bildens dimensioner.

### **Exportera noteringar till PDF och PNG**

Tilldela [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notescommentslayoutingoptions/) till [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) för att inkludera noteringar i PDF‑en. Detta exempel renderar också den första bilden med noteringar till PNG med [Slide.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getImage) och [RenderingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/renderingoptions/).

Läget [BottomTruncated](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/) behåller noteringarna på en sida; noteringar som inte får plats kan trunkeras. PDF‑en använder 900 × 600‑punkts sidor. Vid bildskalan 1 × 1 som används nedan blir PNG‑filen 900 × 600 pixlar. Punkter beskriver sidans geometri; pixlar beskriver rasterutdata, vars dimensioner också beror på renderingsskalan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

För PDF‑export med långa noteringar tillåter [BottomFull](https://reference.aspose.com/slides/sv/python-java/aspose.slides/notespositions/) extra sidor vid behov. Använd inte det läget med bildanropet för en enskild slide ovan, som inte stödjer det. Efter storleksändring, granska utdata för beskurna noteringar och placeringen av befintliga notes‑master‑objekt; att enbart ändra sidans dimensioner bör inte betraktas som en garanti för att allt innehåll får plats. Se [Convert PowerPoint to PDF with Notes](/slides/sv/python-java/convert-powerpoint-to-pdf-with-notes/) för mer om export av noteringar.

### **Exportera utdelningar till PDF**

Använd [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/handoutlayoutingoptions/) för flera bildminiaturer på en sida. Följande exempel sätter en 900 × 600‑punkts sida och använder [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/sv/python-java/aspose.slides/handouttype/) för att ordna upp till fyra bilder per sida. Den horisontella förinställningen styr bildordningen; sidans orientering kommer från dess bredd och höjd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Att ändra sidstorleken förändrar det tillgängliga området för utdelningsrutnätet utan att förändra källbildernas dimensioner. För utdelningsbilder, använd [Presentation.getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) med utdelningslayouten, snarare än en enskild bilds bildmetod. I Aspose.Slides använder rendering på presentationsnivå notssidans dimensioner, medan den enskilda bildens bildanrop inte producerar utdelningssidan. Se [Handout Mode](/slides/sv/python-java/convert-powerpoint-in-handout-mode/) för layoutalternativ.

## **Sidstorlek i visare, export och utskrift**

Behåll den lagrade presentationsstorleken, den exporterade sidstorleken och den utskrivna pappersstorleken åtskilda:

- **Presentationvisare:** En visare kan visa eller skriva ut noteringar med sina egna layoutregler. Om ett annat program sparar filen, öppna den igen och kontrollera dimensionerna igen; det programmets formatkonvertering kan normalisera dem.
- **Exportformat:** Not‑ och utdelnings‑PDF‑exemplen ovan använder de konfigurerade siddimensionerna. Rasterbilder använder heltalspixeldimensioner och en renderingsskala, så bråkdelar av punktvärden kan avrundas i bildutdata. Export av vanliga bilder använder inte notssidans storlek.
- **Skrivardrivrutiner:** Pappersval, automatisk rotation och anpassa‑till‑sida‑inställningar kan ändra det fysiska resultatet utan att ändra dimensionerna som lagras i presentationen eller PDF‑n. För en specifik pappersstorlek, matcha skrivarinställningarna och granska utskriftsförhandsvisningen.

## **FAQ**

**Kan jag ange notssidans storlek för bara en slide?**

Notssidans storlek är en inställning på presentationsnivå. Enskilda slides kan ha olika noteringar, men den här egenskapen ger ingen separat sidstorlek för varje slide.

**Varför ändrade inte förändring av notssidans orientering mina slides?**

Notssidor och vanliga slides har oberoende dimensioner. Använd inställningarna för vanliga bildstorlekar när du vill ändra storlek på själva slides.

**Varför har mitt sparade eller utskrivna resultat en annan storlek?**

Öppna först den sparade presentationen igen och jämför dess notssidans dimensioner. Om de har ändrats, kontrollera om sparandet eller konverteringen av filen i ett annat program ändrade sidinställningarna. Om de inte gjorde det, granska exportlayouten, bildskalan, visarens inställningar och skrivarens pappersval.