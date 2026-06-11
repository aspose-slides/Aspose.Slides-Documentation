---
title: Hantera presentationsanteckningar i C++
linktitle: Presentationsanteckningar
type: docs
weight: 110
url: /sv/cpp/presentation-notes/
keywords:
- anteckningar
- anteckningsbild
- lägg till anteckningar
- ta bort anteckningar
- anteckningsstil
- masteranteckningar
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Anpassa presentationsanteckningar med Aspose.Slides för C++. Arbeta smidigt med PowerPoint- och OpenDocument-anteckningar för att öka din produktivitet."
---
## **Översikt**

Aspose.Slides stöder att ta bort anteckningsbilder från en presentation. I detta ämne presenterar vi funktionen, inklusive hur man tar bort anteckningar och hur man tillämpar en stil på anteckningsbilder i en presentation. Aspose.Slides låter dig ta bort anteckningar från vilken bild som helst och även applicera formatering på befintliga anteckningar. Utvecklare kan ta bort anteckningar på följande sätt:

- Ta bort anteckningar från en specifik bild i en presentation.
- Ta bort anteckningar från alla bilder i en presentation.

## **Ta bort anteckningar från en specifik bild**
Anteckningarna för en specifik bild kan tas bort som visas i exemplet nedan:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Ta bort anteckningar från alla bilder**
Anteckningarna för alla bilder i en presentation kan tas bort som visas i exemplet nedan:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Lägg till en anteckningsstil**
Egenskapen NotesStyle har lagts till i IMasterNotesSlide‑gränssnittet och MasterNotesSlide‑klassen. Denna egenskap specificerar stilen för en anteckningstext. Implementeringen demonstreras i exemplet nedan.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **Vanliga frågor**

**Vilken API‑enhet ger åtkomst till anteckningarna för en specifik bild?**

Anteckningar nås via bildens anteckningshanterare: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/notesslidemanager/) och en [method](https://reference.aspose.com/slides/sv/cpp/aspose.slides/notesslidemanager/get_notesslide/) som returnerar anteckningsobjektet, eller `null` om det inte finns några anteckningar.

**Finns det skillnader i stöd för anteckningar mellan de PowerPoint‑versioner som biblioteket fungerar med?**

Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint‑format (97–nyare) och ODP; anteckningar stöds i dessa format utan att bero på en installerad kopia av PowerPoint.