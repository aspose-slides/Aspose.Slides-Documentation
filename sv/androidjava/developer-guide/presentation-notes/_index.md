---
title: Hantera presentationsanteckningar på Android
linktitle: Presentationsanteckningar
type: docs
weight: 110
url: /sv/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Anpassa presentationsanteckningar med Aspose.Slides för Android via Java. Arbeta sömlöst med anteckningar i PowerPoint och OpenDocument för att öka din produktivitet."
---
## **Översikt**

Aspose.Slides stöder att ta bort anteckningsbilder från en presentation. I det här avsnittet presenterar vi den här funktionen, inklusive hur man tar bort anteckningar och hur man applicerar en stil på anteckningsbilder i en presentation. Aspose.Slides låter dig ta bort anteckningar från vilken bild som helst och också tillämpa formatering på befintliga anteckningar. Utvecklare kan ta bort anteckningar på följande sätt:

- Ta bort anteckningar från en specifik bild i en presentation.
- Ta bort anteckningar från alla bilder i en presentation.

## **Ta bort anteckningar från en bild**
Anteckningarna för en viss bild kan tas bort enligt exemplet nedan:

```java
// Skapa ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Tar bort anteckningar från den första bilden
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Sparar presentationen till disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort anteckningar från en presentation**
Anteckningarna för alla bilder i en presentation kan tas bort enligt exemplet nedan:

```java
// Instansiera ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Tar bort anteckningar från alla bilder
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Sparar presentationen till disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till en anteckningsstil**
[getNotesStyle](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) metoden har lagts till i gränssnittet [IMasterNotesSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IMasterNotesSlide) och klassen [MasterNotesSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/MasterNotesSlide) respektive. Denna egenskap specificerar stilen för en anteckningstext. Implementeringen demonstreras i exempel nedan.

```java
    // Instansiera ett Presentation-objekt som representerar en presentationsfil
    Presentation pres = new Presentation("demo.pptx");
    try {
        IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
        
        if (notesMaster != null)
        {
            // Hämta MasterNotesSlide textstil
            ITextStyle notesStyle = notesMaster.getNotesStyle();
        
            //Set Sätt symbolpunkt för stycken på första nivån
            IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
            paragraphFormat.getBullet().setType(BulletType.Symbol);
        }
        pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **FAQ**

**Vilken API-enhet ger åtkomst till anteckningarna för en specifik bild?**

Anteckningar nås via bildens anteckningshanterare: bilden har en [NotesSlideManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notesslidemanager/) och en [method](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) som returnerar anteckningsobjektet, eller `null` om det inte finns några anteckningar.

**Finns det skillnader i stöd för anteckningar mellan de PowerPoint-versioner som biblioteket fungerar med?**

Biblioteket riktar sig mot ett brett spektrum av Microsoft PowerPoint-format (97 och senare) och ODP; anteckningar stöds i dessa format utan att vara beroende av en installerad kopia av PowerPoint.