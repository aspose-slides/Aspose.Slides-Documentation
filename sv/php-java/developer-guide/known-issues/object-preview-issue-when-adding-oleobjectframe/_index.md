---
title: Problem med objektförhandsgranskning vid tillägg av OleObjectFrame
linktitle: Problem med OLE-objekt
type: docs
weight: 10
url: /sv/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- förhandsgranskningsproblem
- inbäddat objekt
- inbäddad fil
- objekt ändrat
- objektförhandsgranskning
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig varför EMBEDDED OLE OBJECT visas när du lägger till OleObjectFrame i Aspose.Slides för PHP och hur du åtgärdar förhandsgranskningsproblem i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

När du använder Aspose.Slides för PHP via Java och lägger till [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/) på en bild visas ett "EMBEDDED OLE OBJECT"-meddelande på den genererade bilden. Detta meddelande är avsiktligt och INTE ett fel.

För mer information om hur du arbetar med OLE-objekt, se [Manage OLE](/slides/sv/php-java/manage-ole/). 

## **Förklaring och lösning**

Aspose.Slides visar meddelandet "EMBEDDED OLE OBJECT" för att meddela dig att OLE-objektet har ändrats och förhandsgranskningsbilden måste uppdateras. 

Till exempel, om du lägger till ett Microsoft Excel-diagram som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/oleobjectframe/) på en bild (för mer detaljer, se artikeln "Manage OLE") och sedan öppnar presentationen i Microsoft PowerPoint, kommer du att se den här bilden på bilden:

![OLE object message](OLE_object_message.png)

Om du vill kontrollera och bekräfta att ditt OLE-objekt har lagts till på bilden måste du dubbelklicka på meddelandet "EMBEDDED OLE OBJECT", eller så kan du högerklicka på det och gå till alternativet **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint öppnar sedan det inbäddade OLE-objektet.

![OLE object data](OLE_object_data.png)

Bilden kan behålla meddelandet "EMBEDDED OLE OBJECT". När du klickar på OLE-objektet uppdateras bildens förhandsgranskning och meddelandet "EMBEDDED OLE OBJECT" ersätts av den faktiska bilden för OLE-objektet. 

![OLE object preview](OLE_object_preview.png)

Nu kanske du vill spara din presentation för att säkerställa att bilden för OLE-objektet uppdateras korrekt. På så sätt, efter att du har sparat presentationen, kommer du INTE att se meddelandet "EMBEDDED OLE OBJECT" när du öppnar presentationen igen. 

## **Andra lösningar**

### **Lösning 1: Ersätt "EMBEDDED OLE OBJECT"-meddelandet med en bild**

Om du inte vill ta bort meddelandet "EMBEDDED OLE OBJECT" genom att öppna presentationen i PowerPoint och sedan spara den, kan du ersätta meddelandet med din föredragna förhandsgranskningsbild. Följande kodrader visar processen:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // Lägg till en bild i presentationens resurser.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Ange en titel och bilden för OLE-objektets förhandsgranskning.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Bilden som innehåller `OleObjectFrame` ändras sedan till detta:

![New OLE object image](OLE_object_new_image.png)

### **Lösning 2: Skapa ett tillägg för PowerPoint**

Du kan också skapa ett tillägg för Microsoft PowerPoint som uppdaterar alla OLE-objekt när du öppnar presentationer i programmet.