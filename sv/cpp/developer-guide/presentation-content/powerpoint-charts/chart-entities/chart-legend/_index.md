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
description: Anpassa diagramlegender med Aspose.Slides för C++ för att optimera PowerPoint-presentationer med skräddarsydd legendformatering.
---
## **Översikt**

Aspose.Slides erbjuder alternativ för att anpassa diagramlegender i PowerPoint‑presentationer. Denna artikel visar hur man placerar och storlekar en legend, anger teckenstorleken för hela legenden och tillämpar formatering på ett enskilt legend‑element.

Den behandlar också flera relaterade beteenden i FAQ, inklusive att använda icke‑överlappningsläge så att plotområdet ger plats åt legenden, låter långa legendetiketter radbrytas eller använda radbrytningar, samt låter legendens formatering ärva från presentationens tema när inga explicita text‑ och fyllningsinställningar har angetts.

## **Placering av legend**
För att ställa in legend‑egenskaperna, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) klass.
- Hämta referensen till bilden.
- Lägg till ett diagram på bilden.
- Ställ in egenskaperna för legenden.
- Skriv presentationen som en PPTX‑fil.

I exemplet nedan har vi angett position och storlek för diagramlegend.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Ställ in teckenstorlek för en legend**
Aspose.Slides för C++ låter utvecklare ange teckenstorleken för legenden. Följ stegen nedan:

- Instansiera Presentation‑klassen.
- Skapa standarddiagrammet.
- Ange teckenstorleken.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Skriv en presentation till disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Ställ in teckenstorlek för en enskild legend**
Aspose.Slides för C++ låter utvecklare ange teckenstorleken för enskilda legend‑element. Följ stegen nedan:

- Instansiera Presentation‑klassen.
- Skapa standarddiagrammet.
- Åtkomst till legend‑elementet.
- Ange teckenstorleken.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Skriv en presentation till disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **Vanliga frågor**

**Kan jag aktivera legenden så att diagrammet automatiskt avsätter utrymme för den istället för att överlappa den?**

Ja. Använd icke‑överlappningsläget ([set_Overlay(false)](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/legend/set_overlay/)); i detta fall minskar plotområdet för att rymma legenden.

**Kan jag skapa flerradiga legendetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stöds via nyrader i serienamnet.

**Hur får jag legenden att följa presentationens färgschema?**

Ange inte explicita färger/fyllningar/typsnitt för legenden eller dess text. De ärver då från temat och uppdateras korrekt när designen ändras.