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
description: "Skapa presentationer i C++ med Aspose.Slides—skapa PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programatiskt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur man skapar en presentation i Aspose.Slides, lägger till enkelt innehåll på en bild och sparar resultatet som en fil.

## **Skapa en PowerPoint-presentation**
För att lägga till en enkel rak linje på en vald bild i presentationen, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) klass.
2. Hämta referensen till en bild genom att använda dess Index.
3. Lägg till en AutoShape av typ Linje med hjälp av metoden AddAutoShape som tillhandahålls av objektet Shapes.
4. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**Vilka format kan jag spara en ny presentation i?**

Du kan spara till [PPTX, PPT och ODP](/slides/sv/cpp/save-presentation/), och exportera till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/sv/cpp/convert-powerpoint-to-xps/), [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), [SVG](/slides/sv/cpp/convert-powerpoint-to-png/) och [bilder](/slides/sv/cpp/convert-powerpoint-to-png/), med flera.

**Kan jag börja från en mall (POTX/POTM) och spara som en vanlig PPTX?**

Ja. Läs in mallen och spara i önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/cpp/supported-file-formats/).

**Hur styr jag bildstorlek/bildförhållande när jag skapar en presentation?**

Ställ in [bildstorlek](/slides/sv/cpp/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna dimensioner) och välj hur innehållet ska skalas.

**I vilka enheter mäts storlekar och koordinater?**

I punkter: 1 tum motsvarar 72 enheter.

**Hur hanterar jag mycket stora presentationer (med många mediefiler) för att minska minnesanvändningen?**

Använd [BLOB-hanteringsstrategier](/slides/sv/cpp/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer, och föredra filbaserade arbetsflöden framför rena minnesströmmar.

**Kan jag skapa/spara presentationer parallellt?**

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) instans från [flera trådar](/slides/sv/cpp/multithreading/). Kör separata, isolerade instanser per tråd eller process.

**Hur tar jag bort provversionens vattenstämpel och begränsningar?**

[Applicera en licens](/slides/sv/cpp/licensing/) en gång per process. Licensens XML måste förbli oförändrad, och licensinställningen bör synkroniseras om flera trådar är inblandade.

**Kan jag digitalt signera PPTX-filen jag skapar?**

Ja. [Digitala signaturer](/slides/sv/cpp/digital-signature-in-powerpoint/) (tillägg och verifiering) stöds för presentationer.

**Stöds makron (VBA) i skapade presentationer?**

Ja. Du kan [skapa/redigera VBA-projekt](/slides/sv/cpp/presentation-via-vba/) och spara makroaktiverade filer som PPTM/PPSM.