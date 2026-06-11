---
title: Problem med förhandsgranskning av objekt vid tillägg av OleObjectFrame
linktitle: OLE-objektproblem
type: docs
weight: 10
url: /sv/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- förhandsgranskningsproblem
- inbäddat objekt
- inbäddad fil
- objekt ändrat
- objektförhandsgranskning
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig varför EMBEDDED OLE OBJECT visas när du lägger till OleObjectFrame i Aspose.Slides för Node.js och hur du åtgärdar förhandsgranskningsproblem i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

När du använder Aspose.Slides för Java och lägger till [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleobjectframe/) på en bild visas ett meddelande "EMBEDDED OLE OBJECT" på den resulterande bilden. Detta meddelande är avsiktligt och INTE en bugg.

För mer information om att arbeta med OLE-objekt, se [Hantera OLE](/slides/sv/nodejs-java/manage-ole/).

## **Förklaring och Lösning**

Aspose.Slides visar meddelandet "EMBEDDED OLE OBJECT" för att meddela dig att OLE-objektet har ändrats och förhandsgranskningsbilden måste uppdateras. 

Till exempel, om du lägger till ett Microsoft Excel-diagram som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleobjectframe/) på en bild (för mer information, se artikeln "Hantera OLE") och sedan öppnar presentationen i Microsoft PowerPoint, kommer du att se den här bilden på bilden:

![OLE object message](OLE_object_message.png)

Om du vill kontrollera och bekräfta att ditt OLE-objekt har lagts till på bilden, måste du dubbelklicka på meddelandet "EMBEDDED OLE OBJECT", eller så kan du högerklicka på det och gå via alternativet **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint öppnar sedan det inbäddade OLE-objektet.

![OLE object data](OLE_object_data.png)

Bilden kan behålla meddelandet "EMBEDDED OLE OBJECT". När du klickar på OLE-objektet uppdateras bildförhandsgranskningen och meddelandet "EMBEDDED OLE OBJECT" ersätts av den faktiska bilden för OLE-objektet. 

![OLE object preview](OLE_object_preview.png)

Nu kanske du vill spara presentationen för att säkerställa att bilden för OLE-objektet uppdateras korrekt. På så sätt, efter att du har sparat presentationen, kommer du INTE att se meddelandet "EMBEDDED OLE OBJECT" när du öppnar den igen. 

## **Andra Lösningar**

### **Lösning 1: Ersätt meddelandet "Embedded OLE Object" med en bild**

Om du inte vill ta bort meddelandet "EMBEDDED OLE OBJECT" genom att öppna presentationen i PowerPoint och sedan spara den, kan du ersätta meddelandet med din föredragna förhandsgranskningsbild. Följande kodrader demonstrerar processen:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Lägg till en bild i presentationens resurser.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Ange en titel och bilden för OLE-objektets förhandsgranskning.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Bilden som innehåller `OleObjectFrame` ändras då till detta:

![New OLE object image](OLE_object_new_image.png)

### **Lösning 2: Skapa ett tillägg för PowerPoint**

Du kan också skapa ett tillägg för Microsoft PowerPoint som uppdaterar alla OLE-objekt när du öppnar presentationer i programmet.