---
title: Hantera presentationsanteckningar i JavaScript
linktitle: Presentationsanteckningar
type: docs
weight: 110
url: /sv/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Anpassa presentationsanteckningar i JavaScript med Aspose.Slides för Node.js. Arbeta sömlöst med PowerPoint- och OpenDocument-anteckningar för att förbättra din produktivitet."
---
## **Översikt**

Aspose.Slides stödjer att ta bort anteckningsbilder från en presentation. I detta ämne introducerar vi funktionen, inklusive hur man tar bort anteckningar och hur man tillämpar en stil på anteckningsbilder i en presentation. Aspose.Slides låter dig ta bort anteckningar från vilken bild som helst och även tillämpa formatering på befintliga anteckningar. Utvecklare kan ta bort anteckningar på följande sätt:

- Ta bort anteckningar från en specifik bild i en presentation.
- Ta bort anteckningar från alla bilder i en presentation.

## **Ta bort anteckningar från bild**
Anteckningar för en viss bild kan tas bort som visas i exemplet nedan:

```javascript
// Instansiera ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Tar bort anteckningar från första bilden
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Sparar presentation till disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ta bort anteckningar från presentationen**
Anteckningar för alla bilder i en presentation kan tas bort som visas i exemplet nedan:

```javascript
// Instansiera ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Tar bort anteckningar från alla bilder
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Sparar presentation till disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägg till NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) metoden har lagts till i [MasterNotesSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MasterNotesSlide) klassen och [MasterNotesSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MasterNotesSlide) klassen respektive. Denna egenskap specificerar stilen för en anteckningstext. Implementeringen demonstreras i exemplet nedan.

```javascript
// Instansiera ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Hämta MasterNotesSlide-textstil
        var notesStyle = notesMaster.getNotesStyle();
        // Ställ in symbolpunkt för stycken på första nivån
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Vilken API‑enhet ger åtkomst till anteckningarna för en specifik bild?**

Anteckningar nås via bildens notes manager: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notesslidemanager/) och en [method](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) som returnerar anteckningsobjektet, eller `null` om inga anteckningar finns.

**Finns det skillnader i stöd för anteckningar mellan de PowerPoint‑versioner som biblioteket fungerar med?**

Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint‑format (97‑nyare) och ODP; anteckningar stöds i dessa format utan att kräva en installerad kopia av PowerPoint.