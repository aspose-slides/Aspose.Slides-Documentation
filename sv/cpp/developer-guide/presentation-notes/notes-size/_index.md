---
title: Ändra notssidans storlek och orientering i C++
linktitle: Notssidans storlek
type: docs
weight: 10
url: /sv/cpp/notes-size/
keywords:
- notssidans storlek
- notssidorientering
- liggande anteckningar
- stående anteckningar
- handoutstorlek
- PowerPoint
- presentation
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Läs och ändra notssidans dimensioner i Aspose.Slides för C++, byt orientering, verifiera sparade storlekar och exportera anteckningar eller handouts till PDF och bilder."
---
## **Översikt**

Använd [Presentation::get_NotesSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_notessize/) för att komma åt presentationens inställningar för notssidan. Den returnerar ett [INotesSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inotessize/)‑objekt vars [set_Size](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inotessize/set_size/)‑metod sätter dimensionerna. Även om objektet för notinställningar inte kan ersättas kan du ändra dess storlek.

Bredd och höjd anges i **punkter**, med 72 punkter per tum. Till exempel är 900 × 600 punkter 12,5 × 8⅓ tum. Dessa inställningar gäller för presentationen, inte för en enskild bilds anteckningar.

| Inställning | Syfte |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_notessize/) | Styr notssidans dimensioner och sidans dimensioner som används för utdragsexport. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slidesize/) | Styr vanliga presentationsbilders dimensioner via [ISlideSize](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidesize/). |

Att ändra någon av inställningarna ändrar inte automatiskt den andra. Att ändra notssidans orientering roterar inte heller de vanliga bilderna. Se [Slide Size](/slides/sv/cpp/slide-size/) för att ändra storlek på vanliga bilder.

Exemplen nedan använder en befintlig `sample.pptx`. För exportexemplen, använd en presentation med minst en bild som innehåller talarnoter. Varje exempel kan köras oberoende.

## **Läs notssidans storlek och orientering**

Läs bredden och höjden och jämför dem för att avgöra orienteringen: en bredare sida är liggande, en högre sida är stående, och lika dimensioner beskriver en kvadratisk sida. Detta exempel skriver ut de faktiska dimensionerna i punkter, utan att anta en standardpappersstorlek.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Byt till liggande utan att ändra pappersstorleken**

För att bara ändra orienteringen, byt plats på den befintliga bredden och höjden. Detta bevarar längderna på båda sidor, inklusive de för en anpassad pappersstorlek. Villkoret nedan förhindrar att en redan liggande sida byts tillbaka till stående och lämnar en kvadratisk sida oförändrad.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

För stående orientering, använd samma tilldelning när `size.get_Width() > size.get_Height()`. Ersätt inte A4- eller Letter-dimensioner om du inte också vill ändra pappersstorleken.

## **Ställ in och verifiera en anpassad notssidstorlek**

Tilldela båda dimensionerna samtidigt, och använd sedan [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) för att skriva presentationen. Detta exempel anger en 900 × 600‑punkts liggande sida, sparar den som PPTX och öppnar den sparade filen igen för att kontrollera de bestående värdena. Jämförelsen tillåter en tolerans på 0,01 punkt för flyttal; det är ingen garanti för precision för alla filformat.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Det förväntade resultatet är `900 x 600 points` och `Size preserved: True`. Att kontrollera en nyöppnad presentation verifierar den sparade filen, snarare än endast de minnesbaserade inställningarna.

## **Exportera anteckningar och utdrag**

Sidans dimensioner definierar det tillgängliga området för antecknings- eller utdragslayouter. De aktiverar inte dessa layouter själva: konfigurera också exportalternativen. Export av vanliga bilder fortsätter att använda bildens dimensioner.

### **Exportera anteckningar till PDF och PNG**

Tilldela [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notescommentslayoutingoptions/) till [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) för att inkludera anteckningar i PDF:en. Detta exempel renderar också den första bilden med anteckningar till PNG med hjälp av [Slide::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/getimage/) och [RenderingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/renderingoptions/).

[BottomTruncated](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notespositions/)‑läget behåller anteckningarna på en sida; anteckningar som inte får plats kan trunkeras. PDF:en använder 900 × 600‑punkts sidor. Vid bildskalan 1 × 1 som används nedan blir PNG‑filen 900 × 600 pixlar. Punkter beskriver sidans geometri; pixlar beskriver rasterutdata, vars dimensioner också beror på renderingsskalan.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

För PDF-export med långa anteckningar tillåter [BottomFull](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/notespositions/) ytterligare sidor vid behov. Använd inte det läget med enkelsidiga bildanropet ovan, som inte stöder det. Efter storleksändring, granska utdata för avklippta anteckningar och placeringen av befintliga notes‑master‑objekt; att bara ändra sidans dimensioner bör inte betraktas som en garanti för att allt innehåll får plats. Se [Convert PowerPoint to PDF with Notes](/slides/sv/cpp/convert-powerpoint-to-pdf-with-notes/) för mer om anteckningsexport.

### **Exportera utdrag till PDF**

Använd [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/handoutlayoutingoptions/) för flera bildminiatyrer på en sida. Följande exempel ställer in en 900 × 600‑punkts sida och använder [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/handouttype/) för att placera upp till fyra bilder per sida. Det horisontella förinställningen styr bildordningen; sidans orientering kommer från dess bredd och höjd.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Att ändra sidans storlek ändrar området som är tillgängligt för utdragsrutnätet utan att ändra källbildernas dimensioner. För utdragsbilder, använd [Presentation::GetImages](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/getimages/) med utdragslayouten, snarare än en enskild bilds bildmetod. I Aspose.Slides används utdragsrendering på presentationsnivå de notssidans dimensioner, medan enskild bilds bildanrop inte skapar utdragsidan. Se [Handout Mode](/slides/sv/cpp/convert-powerpoint-in-handout-mode/) för layoutalternativ.

## **Sidstorlek i visare, export och utskrift**

Behåll den lagrade presentationsstorleken, den exporterade sidstorleken och den utskrivna pappersstorleken separata:

- **Presentation viewers:** En visare kan visa eller skriva ut anteckningar med sina egna layoutregler. Om ett annat program sparar filen, öppna den igen och kontrollera dimensionerna; det programmets formatkonvertering kan normalisera dem.
- **Export formats:** Antecknings- och utdrags‑PDF‑exemplen ovan använder de konfigurerade siddimensionerna. Rasterbilder använder heltalspixeldimensioner och en renderingsskala, så bråkdelar av punktvärden kan avrundas i bildutdata. Export av vanliga bilder använder inte notssidans storlek.
- **Printer drivers:** Pappersval, automatisk rotation och anpassa till sida‑inställningar kan ändra det fysiska resultatet utan att ändra dimensionerna som lagras i presentationen eller PDF:en. För en specifik pappersstorlek, matcha skrivarinställningarna och granska utskriftsförhandsgranskningen.

## **FAQ**

**Kan jag ange notssidans storlek för bara en bild?**

Notssidans storlek är en inställning på presentationsnivå. Enskilda bilder kan ha olika anteckningsinnehåll, men den här egenskapen ger inte en separat sidstorlek för varje bild.

**Varför ändrade inte förändring av notssidans orientering mina bilder?**

Notssidor och vanliga bilder har oberoende dimensioner. Använd inställningarna för bildstorlek när du vill ändra storlek på själva bilderna.

**Varför har mitt sparade eller utskrivna resultat en annan storlek?**

Öppna först den sparade presentationen igen och jämför dess notsdimensioner. Om de har förändrats, kontrollera om sparandet eller konverteringen av filen i ett annat program ändrade sidinställningarna. Om de inte gjorde det, kontrollera exportlayouten, bildskalan, visarens inställningar och skrivarens pappersval.