---
title: Ändra anteckningssidans storlek och orientering i Python
linktitle: Anteckningssidans storlek
type: docs
weight: 10
url: /sv/python-net/notes-size/
keywords:
- anteckningssidans storlek
- anteckningsorientering
- liggande anteckningar
- stående anteckningar
- handout‑storlek
- PowerPoint
- presentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Läs och ändra anteckningssidans dimensioner i Aspose.Slides för Python via .NET, byt orientering, verifiera sparade storlekar och exportera anteckningar eller handouts till PDF och bilder."
---
## **Översikt**

Använd [Presentation.notes_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/notes_size/) för att komma åt presentations anteckningssidoinställningar. Den returnerar ett [NotesSize](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notessize/)‑objekt vars [size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/notessize/size/)‑egenskap är skrivbar. Även om inställningsobjektet självt är skrivskyddat, kan du tilldela nya dimensioner till dess size‑egenskap.

Bredd och höjd anges i **points**, med 72 points per tum. Till exempel är 900 × 600 points 12,5 × 8⅓ tum. Dessa inställningar gäller för presentationen, snarare än för en enskild slides anteckningar.

| Inställning | Syfte |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/notes_size/) | Styr anteckningssidans dimensioner och sidans dimensioner som används för handout‑export. |
| [Presentation.slide_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slide_size/) | Styr vanliga presentationsbilders dimensioner via [SlideSize](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slidesize/). |

Att ändra någon av inställningarna ändrar inte automatiskt den andra. Att ändra anteckningssidans orientering roterar inte heller de vanliga bilderna. Se [Slide Size](/slides/sv/python-net/slide-size/) för att ändra storlek på vanliga bilder.

Exemplen nedan använder en befintlig `sample.pptx`. För exportexemplen, använd en presentation med minst en bild som innehåller talarnoter. Varje exempel kan köras oberoende.

## **Läs anteckningssidans storlek och orientering**

Läs bredden och höjden och jämför dem för att bestämma orienteringen: en bredare sida är liggande, en högre sida är stående, och lika dimensioner beskriver en kvadratisk sida. Detta exempel skriver ut de faktiska dimensionerna i points, utan att anta en standardpappersstorlek.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Byt till liggande utan att ändra pappersstorleken**

För att bara ändra orienteringen, byt plats på den befintliga bredden och höjden. Detta bevarar längderna på båda sidor, inklusive de för en anpassad pappersstorlek. Villkoret nedan förhindrar att en redan liggande sida byts tillbaka till stående och lämnar en kvadratisk sida oförändrad.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

För stående orientering, använd samma tilldelning när `size.width > size.height`. Ersätt inte A4- eller Letter-dimensioner om du inte också vill ändra pappersstorleken.

## **Ange och verifiera en anpassad anteckningssidestorlek**

Tilldela båda dimensionerna samtidigt, och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/) för att skriva presentationen. Detta exempel ställer in en 900 × 600‑points liggande sida, sparar den som PPTX och öppnar den sparade filen igen för att kontrollera de bestående värdena. Jämförelsen tillåter en tolerans på 0,01 point för flyttal; det är ingen garanti för precision för varje filformat.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Det förväntade resultatet är `900 x 600 points` och `Size preserved: True`. Att kontrollera en nyöppnad presentation verifierar den sparade filen, snarare än endast de minnes‑baserade inställningarna.

## **Exportera anteckningar och handouts**

Sidans dimensioner definierar det tillgängliga området för antecknings‑ eller handout‑layouter. De möjliggör inte dessa layouter själva: konfigurera även exportalternativen. Vanlig bildexport fortsätter att använda bildens dimensioner.

### **Exportera anteckningar till PDF och PNG**

Tilldela [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notescommentslayoutingoptions/) till [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) för att inkludera anteckningar i PDF:en. Detta exempel renderar också den första bilden med anteckningar till PNG med hjälp av [Slide.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/) och [RenderingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/renderingoptions/).

Läget [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notespositions/) behåller anteckningarna på en sida; anteckningar som inte får plats kan trunkeras. PDF‑filen använder 900 × 600‑points sidor. Vid bildskalan 1 × 1 som används nedan blir PNG‑filen 900 × 600 pixlar. Points beskriver sidans geometri; pixlar beskriver rasterutdata, vars dimensioner också beror på renderingsskalan.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

För PDF‑export med långa anteckningar tillåter [BOTTOM_FULL](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/notespositions/) ytterligare sidor vid behov. Använd inte det läget med den enkelslides‑bild‑anropet ovan, som inte stödjer det. Efter storleksändring, granska utdata för avklippta anteckningar och placeringen av befintliga notes‑master‑objekt; att bara ändra sidans dimensioner bör inte betraktas som en garanti för att allt innehåll får plats. Se [Convert PowerPoint to PDF with Notes](/slides/sv/python-net/convert-powerpoint-to-pdf-with-notes/) för mer om anteckningsexport.

### **Exportera handouts till PDF**

Använd [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/handoutlayoutingoptions/) för flera bild‑miniatyrer på en sida. Följande exempel ställer in en 900 × 600‑points sida och använder [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/handouttype/) för att ordna upp till fyra bilder per sida. Det horisontella förinställningen styr bildordningen; sidans orientering kommer från dess bredd och höjd.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Att ändra sidans storlek förändrar området som är tillgängligt för handout‑rutnätet utan att ändra källbildernas dimensioner. För handout‑bilder, använd [Presentation.get_images](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/get_images/) med handout‑layouten, snarare än en enskild bilds bildmetod. I Aspose.Slides använder rendering på presentationsnivå handout‑dimensionerna för anteckningssidan, medan den enskilda bild‑anropet inte genererar handout‑sidan. Se [Handout Mode](/slides/sv/python-net/convert-powerpoint-in-handout-mode/) för layoutalternativ.

## **Sidstorlek i visare, export och utskrift**

Behåll den lagrade presentationsstorleken, den exporterade sidstorleken och den utskrivna pappersstorleken åtskilda:

- **Presentation viewers:** En visare kan visa eller skriva ut anteckningar med sina egna layoutregler. Om ett annat program sparar filen, öppna den igen och kontrollera dimensionerna på nytt; den applikationens formatkonvertering kan normalisera dem.
- **Export formats:** Antecknings‑ och handout‑PDF‑exemplen ovan använder de konfigurerade siddimensionerna. Rasterbilder använder heltals‑pixeldimensioner och en renderingsskala, så bråkdelar av point‑värden kan avrundas i bildutdata. Export av vanliga bilder använder inte anteckningssidans storlek.
- **Printer drivers:** Pappersval, automatisk rotation och anpassning‑till‑sida‑inställningar kan ändra den fysiska utskriften utan att ändra dimensionerna som lagras i presentationen eller PDF‑filen. För en specifik pappersstorlek, matcha skrivarinställningarna och granska utskriftsförhandsvisningen.

## **FAQ**

**Kan jag ställa in anteckningsstorleken för bara en bild?**

Anteckningssidans storlek är en inställning på presentationsnivå. Enskilda bilder kan ha olika anteckningsinnehåll, men denna egenskap ger ingen separat sidstorlek för varje bild.

**Varför ändrade inte ändring av anteckningsorienteringen mina bilder?**

Anteckningssidor och vanliga bilder har oberoende dimensioner. Använd de vanliga bildstorleksinställningarna när du vill ändra storlek på själva bilderna.

**Varför har mitt sparade eller utskrivna resultat en annan storlek?**

Öppna först den sparade presentationen igen och jämför dess anteckningsdimensioner. Om de har förändrats, kontrollera om sparande eller konvertering av filen i ett annat program ändrade sidinställningarna. Om de inte gjorde det, kontrollera exportlayouten, bildskalan, visarens inställningar och skrivarens pappersval.