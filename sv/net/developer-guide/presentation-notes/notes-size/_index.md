---
title: Ändra anteckningssidans storlek och orientering i .NET
linktitle: Anteckningssidans storlek
type: docs
weight: 10
url: /sv/net/notes-size/
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
- C#
- Aspose.Slides
description: "Läs och ändra anteckningssidans dimensioner i Aspose.Slides för .NET, byt orientering, verifiera sparade storlekar och exportera anteckningar eller handouts till PDF och bilder."
---
## **Översikt**

Använd [Presentation.NotesSize](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/notessize/) för att komma åt inställningarna för presentationens anteckningssida. Den returnerar ett [INotesSize](https://reference.aspose.com/slides/sv/net/aspose.slides/inotessize/)‑objekt vars [Size](https://reference.aspose.com/slides/sv/net/aspose.slides/inotessize/size/)‑egenskap är skrivbar. Även om inställningsobjektet i sig är skrivskyddat kan du tilldela nya dimensioner till dess storleks‑egenskap.

Bredd och höjd anges i **punkter**, med 72 punkter per tum. Till exempel motsvarar 900 × 600 punkter 12,5 × 8⅓ tum. Dessa inställningar gäller för presentationen, snarare än för en enskild slides anteckningar.

| Inställning | Syfte |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/notessize/) | Styr dimensionerna för anteckningssidan och sidans dimensioner som används för handout‑export. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slidesize/) | Styr vanliga presentationssidors dimensioner via [ISlideSize](https://reference.aspose.com/slides/sv/net/aspose.slides/islidesize/). |

Att ändra någon av inställningarna ändrar inte automatiskt den andra. Att ändra anteckningssidans orientering roterar inte heller de vanliga bilderna. Se [Slide Size](/slides/sv/net/slide-size/) för att ändra storlek på vanliga bilder.

Exemplen nedan använder en befintlig `sample.pptx`. För exportexemplen, använd en presentation med minst en slide som innehåller talarnoter. Varje exempel kan köras oberoende.

## **Läs anteckningssidans storlek och orientering**

Läs bredd och höjd och jämför dem för att bestämma orienteringen: en bredare sida är liggande, en högre sida är stående, och lika dimensioner beskriver en kvadratisk sida. Detta exempel skriver ut de faktiska dimensionerna i punkter, utan att anta en standardpappersstorlek.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Byt till liggande utan att ändra pappersstorleken**

För att bara ändra orienteringen, byt plats på den befintliga bredden och höjden. Detta bevarar längderna på båda sidor, inklusive de för en anpassad pappersstorlek. Villkoret nedan förhindrar att en redan liggande sida byts tillbaka till stående och lämnar en kvadratisk sida oförändrad.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

För stående orientering, använd samma tilldelning när `size.Width > size.Height`. Ersätt inte A4‑ eller Letter‑dimensioner om du inte också vill ändra pappersstorleken.

## **Ställ in och verifiera en anpassad anteckningssidostorlek**

Tilldela båda dimensionerna samtidigt, och använd sedan [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) för att skriva presentationen. Detta exempel anger en 900 × 600‑punkts liggande sida, sparar den som PPTX och öppnar den sparade filen igen för att kontrollera de bestående värdena. Jämförelsen tillåter ett toleransintervall på 0,01 punkt för flyttalsvärden; det är ingen garanti för precision för alla filformat.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Det förväntade resultatet är `900 x 600 points` och `Size preserved: True`. Att kontrollera en nyöppnad presentation verifierar den sparade filen, snarare än enbart de minnesbaserade inställningarna.

## **Exportera anteckningar och handouts**

Sidans dimensioner definierar det tillgängliga området för antecknings‑ eller handout‑layouter. De aktiverar inte dessa layouter i sig själva: konfigurera även exportalternativen. Export av vanliga slides fortsätter att använda slidens dimensioner.

### **Exportera anteckningar till PDF och PNG**

Tilldela [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notescommentslayoutingoptions/) till [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) för att inkludera anteckningar i PDF‑filen. Detta exempel renderar även den första sliden med anteckningar till PNG med hjälp av [Slide.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/getimage/) och [RenderingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/renderingoptions/).

[BottomTruncated](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notespositions/)‑läget behåller anteckningarna på en sida; anteckningar som inte får plats kan trunkeras. PDF‑filen använder 900 × 600‑punktssidor. Vid bildskalan 1 × 1 som används nedan blir PNG‑filen 900 × 600 pixlar. Punkter beskriver sidans geometri; pixlar beskriver rasterutdata, vars dimensioner också beror på renderingsskalan.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

För PDF‑export med långa anteckningar tillåter [BottomFull](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notespositions/) ytterligare sidor efter behov. Använd inte det läget med anropet för enstaka slide‑bild ovan, som inte stödjer det. Efter storleksändring, inspektera resultatet för avklippta anteckningar och placeringen av befintliga notes‑master‑objekt; att bara ändra sidans dimensioner bör inte betraktas som en garanti för att allt innehåll får plats. Se [Convert PowerPoint to PDF with Notes](/slides/sv/net/convert-powerpoint-to-pdf-with-notes/) för mer om anteckningsexport.

### **Exportera handouts till PDF**

Använd [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/handoutlayoutingoptions/) för flera bildminiatyrer på en sida. Följande exempel sätter en 900 × 600‑punktssida och använder [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/sv/net/aspose.slides.export/handouttype/) för att ordna upp till fyra slides per sida. Den horisontella förinställningen styr slide‑ordningen; sidans orientering kommer från dess bredd och höjd.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Att ändra sidstorleken ändrar området som är tillgängligt för handout‑rutnätet utan att ändra källslidernas dimensioner. För handout‑bilder, använd [Presentation.GetImages](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/getimages/) med handout‑layouten, snarare än en enskild slides bildmetod. I Aspose.Slides använder rendering på presentationsnivå handout‑dimensionerna för anteckningssidan, medan det enskilda slide‑bildanropet inte producerar handout‑sidan. Se [Handout Mode](/slides/sv/net/convert-powerpoint-in-handout-mode/) för layoutalternativ.

## **Sidstorlek i visare, export och utskrift**

Håll den lagrade presentationsstorleken, den exporterade sidstorleken och den utskrivna pappersstorleken åtskilda:

- **Presentationvisare:** En visare kan visa eller skriva ut anteckningar med sina egna layoutregler. Om ett annat program sparar filen, öppna den igen och kontrollera dimensionerna på nytt; det programmets formatkonvertering kan normalisera dem.
- **Exportformat:** Antecknings‑ och handout‑PDF‑exemplen ovan använder de konfigurerade siddimensionerna. Rasterbilder använder heltalspixel‑dimensioner och en renderingsskala, så bråktalspunkter kan avrundas i bildutdata. Export av vanliga slides tillämpar inte anteckningssidans storlek.
- **Skrivardrivrutiner:** Val av papper, automatisk rotation och inställningar för anpassning till sidan kan förändra det fysiska utskriften utan att ändra dimensionerna som lagras i presentationen eller PDF‑filen. För en specifik pappersstorlek, matcha skrivarinställningarna och inspektera utskriftsförhandsgranskningen.

## **Vanliga frågor**

**Kan jag ställa in anteckningsstorleken för endast en slide?**

Anteckningssidans storlek är en inställning på presentationsnivå. Enskilda slides kan ha olika anteckningsinnehåll, men denna egenskap ger ingen separat sidstorlek för varje slide.

**Varför ändrade inte förändring av anteckningarnas orientering mina slides?**

Anteckningssidor och vanliga slides har oberoende dimensioner. Använd inställningarna för vanlig slide‑storlek när du vill ändra storlek på själva slides.

**Varför har mitt sparade eller utskrivna resultat en annan storlek?**

Öppna först den sparade presentationen igen och jämför dess anteckningsdimensioner. Om de har förändrats, kontrollera om sparandet eller konverteringen av filen i ett annat program ändrade sidinställningarna. Om de inte gjorde det, kontrollera exportlayouten, bildskalan, visarinställningarna och val av skrivarens papper.