---
title: Anpassa diagramlegender i presentationer med C++
linktitle: Diagramlegend
type: docs
url: /sv/cpp/chart-legend/
keywords:
- diagramlegend
- legendposition
- teckenstorlek
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Anpassa diagramlegender med Aspose.Slides för C++ för att optimera PowerPoint-presentationer med skräddarsydd legendformatering."
---
## **Översikt**

Aspose.Slides erbjuder alternativ för att anpassa diagramlegender i PowerPoint‑presentationer. Denna artikel visar hur man placerar och storlekar en legend, anger teckenstorlek för hela legenden och tillämpar formatering på ett enskilt legendobjekt.

Den täcker också flera relaterade beteenden i FAQ, inklusive att använda icke‑overlayläge så att ritytan ger plats åt legenden, tillåter långa legendetiketter att radbrytas eller använda radbrytningar, samt låter legendens formatering ärva från presentationens tema när explicita text‑ och fyllningsinställningar inte används.

## **Placering av legend**
För att ställa in legendens egenskaper. Följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-klassen.
- Hämta referensen till bilden.
- Lägg till ett diagram på bilden.
- Ställ in legendens egenskaper.
- Skriv presentationen som en PPTX‑fil.

I exemplet nedan har vi angett position och storlek för diagramlegend.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Ange teckenstorlek för en legend**
Aspose.Slides för C++ låter utvecklare ange teckenstorlek för legenden. Följ stegen nedan:

- Instansiera Presentation‑klassen.
- Skapa standarddiagrammet.
- Ange teckenstorlek.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Skriv presentationen till disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Ange teckenstorlek för en enskild legend**
Aspose.Slides för C++ låter utvecklare ange teckenstorlek för enskilda legendposter. Följ stegen nedan:

- Instansiera Presentation‑klassen.
- Skapa standarddiagrammet.
- Åtkomst till legendpost.
- Ange teckenstorlek.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Skriv presentationen till disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Kan jag aktivera legenden så att diagrammet automatiskt avsätter utrymme för den i stället för att överlappa den?**

Ja. Använd icke‑overlayläget ([set_Overlay(false)](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/legend/set_overlay/)); i så fall krymper diagramområdet för att rymma legenden.

**Kan jag skapa flerradiga legendetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stöds via nyradstecken i seriens namn.

**Hur får jag legenden att följa presentationens temafärgschema?**

Ange inte explicita färger/fyllningar/teckensnitt för legenden eller dess text. De kommer då att ärva från temat och uppdateras korrekt när designen ändras.