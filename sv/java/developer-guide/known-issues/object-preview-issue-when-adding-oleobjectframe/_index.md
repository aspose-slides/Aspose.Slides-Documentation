---
title: Problem med förhandsgranskning av objekt när OleObjectFrame läggs till
linktitle: Problem med OLE-objekt
type: docs
weight: 10
url: /sv/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem med förhandsgranskning
- inbäddat objekt
- inbäddad fil
- objekt förändrat
- objektförhandsgranskning
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig varför EMBEDDED OLE OBJECT visas när OleObjectFrame läggs till i Aspose.Slides för Java och hur du åtgärdar förhandsgranskningsproblem i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

Använd Aspose.Slides för Java, när du lägger till [OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/oleobjectframe/) på en bild visas ett "EMBEDDED OLE OBJECT"-meddelande på den färdiga bilden. Detta meddelande är avsiktligt och INTE en bugg.

För mer information om hur du arbetar med OLE‑objekt, se [Manage OLE](/slides/sv/java/manage-ole/). 

## **Förklaring och Lösning**

Aspose.Slides visar meddelandet "EMBEDDED OLE OBJECT" för att meddela dig att OLE‑objektet har ändrats och förhandsgranskningsbilden måste uppdateras. 

Till exempel, om du lägger till ett Microsoft Excel‑diagram som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/oleobjectframe/) på en bild (för mer detaljer, se artikeln "Manage OLE") och sedan öppnar presentationen i Microsoft PowerPoint, kommer du att se den här bilden på bilden:

![OLE‑objektmeddelande](OLE_object_message.png)

Om du vill kontrollera och bekräfta att ditt OLE‑objekt har lagts till på bilden, måste du dubbelklicka på meddelandet "EMBEDDED OLE OBJECT", eller så kan du högerklicka på det och gå via alternativet **Object > Edit**.

![OLE‑objekt > Redigera](OLE_object_edit.png)

PowerPoint öppnar sedan det inbäddade OLE‑objektet.

![OLE‑objektdata](OLE_object_data.png)

Bilden kan behålla meddelandet "EMBEDDED OLE OBJECT". När du klickar på OLE‑objektet uppdateras förhandsgranskningen och meddelandet "EMBEDDED OLE OBJECT" ersätts av den faktiska bilden för OLE‑objektet. 

![OLE‑objektförhandsgranskning](OLE_object_preview.png)

Nu kanske du vill spara din presentation för att säkerställa att bilden för OLE‑objektet uppdateras korrekt. På så sätt, efter att du sparat presentationen, när du öppnar den igen, kommer du INTE att se meddelandet "EMBEDDED OLE OBJECT". 

## **Andra lösningar**

### **Lösning 1: Ersätt meddelandet "Embedded OLE Object" med en bild**

Om du inte vill ta bort meddelandet "EMBEDDED OLE OBJECT" genom att öppna presentationen i PowerPoint och sedan spara den, kan du ersätta meddelandet med din föredragna förhandsgranskningsbild. Dessa kodrader demonstrerar processen:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Lägg till en bild i presentationens resurser.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Ange en titel och bilden för OLE‑objektets förhandsgranskning.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Bilden som innehåller `OleObjectFrame` ändras sedan till detta:

![Ny OLE‑objektsbild](OLE_object_new_image.png)

### **Lösning 2: Skapa ett tillägg för PowerPoint**

Du kan också skapa ett tillägg för Microsoft PowerPoint som uppdaterar alla OLE‑objekt när du öppnar presentationer i programmet.