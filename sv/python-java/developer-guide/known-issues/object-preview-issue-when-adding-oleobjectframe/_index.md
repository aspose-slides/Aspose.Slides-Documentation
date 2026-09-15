---
title: Problem med objektförhandsgranskning när OleObjectFrame läggs till
linktitle: Problem med OLE-objekt
type: docs
weight: 10
url: /sv/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- förhandsgranskningsproblem
- inbäddat objekt
- inbäddad fil
- objekt förändrat
- objektförhandsgranskning
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig varför EMBEDDED OLE OBJECT visas när du lägger till OleObjectFrame i Aspose.Slides för Python via Java och hur du åtgärdar förhandsgranskningsproblem i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

När du använder Aspose.Slides för Python via Java för att lägga till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) på en bild visas ett meddelande "EMBEDDED OLE OBJECT" på den genererade bilden. Detta meddelande är avsiktligt och är ingen bugg.

För mer information om att arbeta med OLE-objekt, se [Manage OLE](/slides/sv/python-java/manage-ole/).

## **Förklaring och lösning**

Aspose.Slides visar meddelandet "EMBEDDED OLE OBJECT" för att meddela att OLE-objektet har ändrats och förhandsgranskningsbilden måste uppdateras.

Till exempel, om du lägger till ett Microsoft Excel-diagram som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) på en bild (för mer detaljer, se artikeln "Manage OLE") och sedan öppnar presentationen i Microsoft PowerPoint, kommer du att se den här bilden på bilden:

![OLE object message](OLE_object_message.png)

För att bekräfta att ditt OLE-objekt har lagts till på bilden, dubbelklicka på meddelandet "EMBEDDED OLE OBJECT", eller högerklicka på det och välj **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint öppnar sedan det inbäddade OLE-objektet.

![OLE object data](OLE_object_data.png)

Bilden kan behålla meddelandet "EMBEDDED OLE OBJECT". När du klickar på OLE-objektet uppdateras bildens förhandsgranskning och meddelandet "EMBEDDED OLE OBJECT" ersätts av den faktiska bilden för OLE-objektet.

![OLE object preview](OLE_object_preview.png)

Spara din presentation för att bevara den uppdaterade förhandsgranskningsbilden för OLE-objektet. När du öppnar presentationen igen kommer du inte längre att se meddelandet "EMBEDDED OLE OBJECT".

## **Annan lösning**

Om du inte vill ta bort meddelandet "EMBEDDED OLE OBJECT" genom att öppna presentationen i PowerPoint och sedan spara den, kan du ersätta meddelandet med din föredragna förhandsgranskningsbild. Följande kod demonstrerar processen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Lägg till en bild i presentationens resurser.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Ställ in en titel och bilden för OLE-objektets förhandsgranskning.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bilden som innehåller [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) ändras sedan till detta:

![New OLE object image](OLE_object_new_image.png)

## **Vanliga frågor**

**Varför visas meddelandet "EMBEDDED OLE OBJECT"?**

Meddelandet indikerar att OLE-objektet har ändrats och dess förhandsgranskningsbild måste uppdateras. Detta beteende är avsiktligt.

**Hur kan jag uppdatera förhandsgranskningen i PowerPoint?**

Dubbelklicka på meddelandet eller välj **Object > Edit** för att öppna det inbäddade OLE-objektet. Klicka på OLE-objektet för att uppdatera förhandsgranskningen och spara sedan presentationen.

**Kan jag ersätta meddelandet utan att öppna presentationen i PowerPoint?**

Ja. Du kan tilldela en föredragen förhandsgranskningsbild till OLE-objektet, som visas i kodexemplet ovan.