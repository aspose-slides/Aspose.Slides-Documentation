---
title: Problem med objektförhandsgranskning när OleObjectFrame läggs till
linktitle: OLE-objektproblem
type: docs
weight: 10
url: /sv/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem med förhandsgranskning
- inbäddat objekt
- inbäddad fil
- objekt ändrat
- objektförhandsgranskning
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig varför EMBEDDED OLE OBJECT visas när du lägger till OleObjectFrame i Aspose.Slides för Android via Java och hur du åtgärdar förhandsgranskningsproblem i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

När du använder Aspose.Slides för Android via Java och lägger till [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/oleobjectframe/) på en bildruta visas meddelandet "EMBEDDED OLE OBJECT" på den resulterande bildrutan. Detta meddelande är avsiktligt och INTE ett fel.

För mer information om att arbeta med OLE-objekt, se [Hantera OLE](/slides/sv/androidjava/manage-ole/). 

## **Förklaring och lösning**

Aspose.Slides visar meddelandet "EMBEDDED OLE OBJECT" för att meddela att OLE-objektet har ändrats och förhandsgranskningsbilden måste uppdateras. 

Till exempel, om du lägger till ett Microsoft Excel-diagram som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/oleobjectframe/) på en bildruta (för mer information, se artikeln "Manage OLE") och sedan öppnar presentationen i Microsoft PowerPoint, kommer du att se den här bilden på bildrutan:

![OLE object message](OLE_object_message.png)

Om du vill kontrollera och bekräfta att ditt OLE-objekt har lagts till på bildrutan måste du dubbelklicka på meddelandet "EMBEDDED OLE OBJECT", eller så kan du högerklicka på det och gå till alternativet **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint öppnar sedan det inbäddade OLE-objektet.

![OLE object data](OLE_object_data.png)

Bildrutan kan behålla meddelandet "EMBEDDED OLE OBJECT". När du klickar på OLE-objektet uppdateras förhandsgranskningen av bildrutan och meddelandet "EMBEDDED OLE OBJECT" ersätts av den faktiska bilden för OLE-objektet. 

![OLE object preview](OLE_object_preview.png)

Nu kanske du vill spara presentationen för att säkerställa att bilden för OLE-objektet uppdateras korrekt. På så sätt, efter att ha sparat presentationen, kommer du INTE att se meddelandet "EMBEDDED OLE OBJECT" när du öppnar presentationen igen. 

## **Andra lösningar**

### **Lösning 1: Ersätt meddelandet "Embedded OLE Object" med en bild**

Om du inte vill ta bort meddelandet "EMBEDDED OLE OBJECT" genom att öppna presentationen i PowerPoint och sedan spara den, kan du ersätta meddelandet med din föredragna förhandsgranskningsbild. Följande kodrader demonstrerar processen:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Lägg till en bild i presentationens resurser.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Ange en titel och bilden för OLE-objektets förhandsgranskning.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Bildrutan som innehåller `OleObjectFrame` ändras sedan till detta:

![New OLE object image](OLE_object_new_image.png)

### **Lösning 2: Skapa ett tillägg för PowerPoint**

Du kan också skapa ett tillägg för Microsoft PowerPoint som uppdaterar alla OLE-objekt när du öppnar presentationer i programmet.