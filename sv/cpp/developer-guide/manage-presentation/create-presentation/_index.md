---
title: Skapa presentationer i C++
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Skapa presentationer i C++ med Aspose.Slides - generera PPT, PPTX och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programmässigt för pålitliga resultat."
---
## **Översikt**

Denna artikel visar hur man skapar en presentation i Aspose.Slides, lägger till en textruta på dess första bild och sparar resultatet som en fil. En kort FAQ i slutet täcker vanliga frågor om format, mallar, bildstorlek, enheter, minnesanvändning, trådad körning, licensiering, digitala signaturer och VBA-stöd.

Innan du börjar, lägg till Aspose.Slides i ditt projekt: från NuGet i ett Visual Studio‑projekt på Windows, eller från ZIP‑paketet med CMake på Linux. Se [Installation](/slides/sv/cpp/installation/).

## **Skapa en PowerPoint‑presentation**

För att skapa en presentation och lägga till en textruta på dess första bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/). En ny presentation innehåller redan en tom bild.
1. Hämta den bilden med metoden [Presentation::get_Slide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slide/) och dess index, 0.
1. Lägg till en rektangel med metoden [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addautoshape/) och sätt dess text med metoden [ITextFrame::set_Text](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/set_text/).
1. Spara presentationen som en PPTX‑fil med metoden [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Rektangelns övre vänstra hörn ligger 50 punkter från vänsterkant och 50 punkter från övre kant på bilden, och rektangeln är 400 punkter bred och 100 punkter hög. Programmet sparar *hello.pptx* i sin arbetskatalog, med en bild som innehåller rektangeln och dess text. Utan licens lägger Aspose.Slides också till en utvärderingsvattenstämpel på varje bild den sparar; se [Licensiering](/slides/sv/cpp/licensing/).

## **FAQ**

### Vilka format kan jag spara en ny presentation till?

Du kan spara till [PPTX, PPT och ODP](/slides/sv/cpp/save-presentation/), och exportera till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/sv/cpp/convert-powerpoint-to-xps/), [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), [SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/) och [bilder](/slides/sv/cpp/convert-powerpoint-to-png/), bland annat.

### Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?

Ja. Ladda mallen och spara till önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/cpp/supported-file-formats/).

### Hur styr jag bildstorlek/bildförhållande när jag skapar en presentation?

Ställ in [bildstorlek](/slides/sv/cpp/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna dimensioner) och välj hur innehållet ska skalas.

### I vilka enheter mäts storlekar och koordinater?

I punkter: 1 tum motsvarar 72 enheter.

### Hur hanterar jag mycket stora presentationer (med många mediefiler) för att minska minnesanvändningen?

Använd [BLOB‑hanteringsstrategier](/slides/sv/cpp/manage-blob/), begränsa lagring i minnet genom att utnyttja temporära filer, och föredra filbaserade arbetsflöden framför rena minnesströmmar.

### Kan jag skapa/spara presentationer parallellt?

Du kan inte arbeta med samma [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans från [flera trådar](/slides/sv/cpp/multithreading/). Kör separata, isolerade instanser per tråd eller process.

### Hur tar jag bort provvattenstämpeln och begränsningarna?

[Tilldela en licens](/slides/sv/cpp/licensing/) en gång per process. Licens‑XML‑filen måste förbli oförändrad, och licensinställningen bör synkroniseras om flera trådar är inblandade.

### Kan jag digitalt signera den PPTX jag skapar?

Ja. [Digitala signaturer](/slides/sv/cpp/digital-signature-in-powerpoint/) (tillläggning och verifiering) stöds för presentationer.

### Stöds makron (VBA) i skapade presentationer?

Ja. Du kan [skapa/redigera VBA‑projekt](/slides/sv/cpp/presentation-via-vba/) och spara makroaktiverade filer såsom PPTM/PPSM.