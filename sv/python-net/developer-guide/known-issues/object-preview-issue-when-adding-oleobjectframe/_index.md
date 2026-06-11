---
title: Problem med förhandsgranskning av objekt när OleObjectFrame läggs till
linktitle: Problem med OLE-objekt
type: docs
weight: 10
url: /sv/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- förhandsgranskningsproblem
- inbäddat objekt
- inbäddad fil
- objekt ändrat
- objektsförhandsgranskning
- presentation
- PowerPoint
- Python
- Aspose.Slides
description: "Lär dig varför EMBEDDED OLE OBJECT visas när OleObjectFrame läggs till i Aspose.Slides för Python och hur du åtgärdar förhandsgranskningsproblem i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

När du använder Aspose.Slides för Python via .NET och lägger till [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) på en bild visas meddelandet "EMBEDDED OLE OBJECT" på den resulterande bilden. Detta meddelande är avsiktligt och är INTE ett fel.

För mer information om hur du arbetar med OLE‑objekt, se [Hantera OLE](/slides/sv/python-net/manage-ole/). 

## **Förklaring och lösning**

Aspose.Slides visar meddelandet "EMBEDDED OLE OBJECT" för att meddela att OLE‑objektet har ändrats och förhandsgranskningsbilden måste uppdateras. 

Till exempel, om du lägger till ett Microsoft Excel‑diagram som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) på en bild (för mer information, se artikeln "Hantera OLE") och sedan öppnar presentationen i Microsoft PowerPoint, kommer du att se denna bild på bilden:

![OLE‑objekt meddelande](OLE_object_message.png)

Om du vill kontrollera och bekräfta att ditt OLE‑objekt har lagts till på bilden, måste du dubbelklicka på meddelandet "EMBEDDED OLE OBJECT", eller så kan du högerklicka på det och gå via **Object > Edit**‑alternativet.

![OLE‑objekt > Redigera](OLE_object_edit.png)

PowerPoint öppnar då det inbäddade OLE‑objektet.

![OLE‑objekt data](OLE_object_data.png)

Bilden kan behålla meddelandet "EMBEDDED OLE OBJECT". När du klickar på OLE‑objektet uppdateras förhandsgranskningen av bilden och meddelandet "EMBEDDED OLE OBJECT" ersätts av den faktiska bilden för OLE‑objektet. 

![OLE‑objekt förhandsgranskning](OLE_object_preview.png)

Nu kanske du vill spara presentationen för att försäkra dig om att bilden för OLE‑objektet uppdateras korrekt. På så sätt, efter att du sparat presentationen, kommer du INTE att se meddelandet "EMBEDDED OLE OBJECT" när du öppnar presentationen igen. 

## **Andra lösningar**

### **Lösning 1: Ersätt meddelandet "Inbäddat OLE‑objekt" med en bild**

Om du inte vill ta bort meddelandet "EMBEDDED OLE OBJECT" genom att öppna presentationen i PowerPoint och sedan spara den, kan du ersätta meddelandet med din föredragna förhandsgranskningsbild. Följande kodrader visar processen:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Lägg till en bild i presentationens resurser.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Ställ in en titel och bilden för OLE-objektets förhandsgranskning.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

Bilden som innehåller `OleObjectFrame` ändras då till detta:

![Ny OLE‑objektbild](OLE_object_new_image.png)

### **Lösning 2: Skapa ett tillägg för PowerPoint**

Du kan också skapa ett tillägg för Microsoft PowerPoint som uppdaterar alla OLE‑objekt när du öppnar presentationer i programmet.