---
title: Low-Code presentationsoperationer i C++
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/cpp/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- slå samman presentationer
- iterera bilder
- iterera former
- iterera text
- samla former
- komprimera presentation
- ta bort oanvända masterbilder
- ta bort oanvända layoutbilder
- komprimera inbäddade teckensnitt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Använd Aspose.Slides low-code API i C++ för att konvertera och slå samman presentationer, iterera genom innehåll, samla former och minska presentationsstorleken."
---
## **Översikt**

Namnutrymmet Aspose::Slides::LowCode tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälpare kapslar in ofta använda objektmodellsarbetsflöden i fokuserade metoder, så att du kan konvertera eller slå samman filer, bearbeta presentationselement, samla former och ta bort oanvänt innehåll med mindre kod.

Low-code‑hjälparna är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd den fullständiga Aspose.Slides‑objektmodellen när du behöver finjusterad kontroll över enskilda bilder, master‑bilder, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd den för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/foreach/) | Kör en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/collect/) | Hämta former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/) | Ta bort oanvända master‑bilder och layouter samt minska inbäddade teckensnittsdata. |

## **Konvertera en presentation**

Använd Convert::AutoByExtension när filändelsen för utdata är tillräcklig för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från sökvägen för utdata och skriver resultatet.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Convert‑klassen erbjuder också dedikerade metoder för PDF‑, SVG‑, JPEG‑, PNG‑ och TIFF‑utdata. Använd den fullständiga objektmodellen när du behöver inspektera eller ändra presentationen före export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/cpp/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Slå ihop presentationer**

Använd Merger::Process för att kombinera kompletta presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller omkartlägga dem individuellt. Använd den fullständiga objektmodellen när du behöver slå samman utvalda bilder, tillämpa ett mål‑master‑ eller layout‑objekt, bevara sektioner explicit eller anpassa olika bildstorlekar. Se [Merge Presentations](/cpp/merge-presentation/) för dessa scenarier.

## **Iterera genom presentationselement**

ForEach‑klassen anropar en callback för varje begärd typ av presentationselement. Den undviker nästlade samlingsloopar och är praktisk för inspektion eller formateringsändringar i hela presentationen.

Följande exempel använder ForEach::Slide, ForEach::Shape, ForEach::Paragraph och ForEach::Portion för att inspektera motsvarande element:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Som standard inkluderar traversering av former och text i hela presentationen vanliga, master‑ och layout‑bilder. Överlagringar med en `includeNotes`‑parameter kan också bearbeta anteckningsbilder. Använd direkta samlingsloopar när traverseringsordning, tidigt avslut, filtrering före callback‑anrop eller detaljerad föräldra‑barn‑kontroll är viktigt.

## **Samla former**

Använd Collect::Shapes när du behöver en samling av alla former i en presentation snarare än en callback för varje form. Detta är användbart när samma uppsättning kommer att filtreras, räknas eller bearbetas flera gånger.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Använd ForEach::Shape i stället när varje form kan hanteras omedelbart och du inte behöver behålla det samlade resultatet.

## **Komprimera presentationsinnehåll**

Compress‑klassen kan ta bort oanvända strukturella element och minska inbäddade teckensnittsdata:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) tar bort layout‑bilder som ingen normal bild refererar till.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) tar bort master‑bilder som inte längre används.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) tar bort oanvända tecken från inbäddade teckensnitt.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Ta bort oanvända layouter innan oanvända master‑bilder så att en master som blir orefererad efter rensning av layouter också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga master‑bilderna, layouterna eller fullständig inbäddad teckensnittsinformation senare. För mer detaljer, se [Slide Master](/cpp/slide-master/) och [Embedded Font](/cpp/embedded-font/).

## **FAQ**

**När bör jag använda low-code‑API:t istället för den fullständiga objektmodellen?**

Använd low-code‑hjälparna när en standardoperation gäller en hel fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd den fullständiga objektmodellen när du behöver välja specifika bilder, kontrollera master‑ och layout‑relationer, inspektera mellanliggande tillstånd eller konfigurera beteende som hjälparen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. Merger::Process kräver att inmatningspresentationerna har samma format. Konvertera indatafilern till ett gemensamt format först, till exempel med Convert::AutoByExtension, och slå sedan ihop de konverterade filerna.

**Bearbetar ForEach master‑, layout‑ och anteckningsbilder?**

ForEach::Slide itererar genom vanliga presentationsbilder. ForEach::Shape, ForEach::Paragraph och ForEach::Portion i hela presentationen inkluderar som standard vanliga, master‑ och layout‑bilder. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera anteckningsbilder.

**Vad är skillnaden mellan ForEach::Shape och Collect::Shapes?**

Använd ForEach::Shape för att bearbeta varje form omedelbart via en callback. Använd Collect::Shapes när du behöver ett enumererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända master‑bilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande Compress‑operationerna eventuellt inte minska filstorleken.

**Sparas ändringar som gjorts av ForEach eller Compress automatiskt?**

Nej. Dessa hjälparbeten arbetar på det inlästa Presentation‑objektet i minnet. Efter att ha ändrat element i en ForEach‑callback eller kört Compress, anropa Presentation::Save för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/cpp/convert-presentation/)
- [Slå ihop presentationer](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Hantera textruta](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)