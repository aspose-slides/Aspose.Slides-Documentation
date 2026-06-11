---
title: Problem med förhandsgranskning av objekt när OleObjectFrame läggs till
linktitle: OLE-objektproblem
type: docs
weight: 10
url: /sv/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- förhandsgranskningsproblem
- inbäddat objekt
- inbäddad fil
- objekt ändrat
- objektförhandsgranskning
- presentation
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Lär dig varför EMBEDDED OLE OBJECT visas när du lägger till OleObjectFrame i Aspose.Slides för .NET och hur du åtgärdar förhandsgranskningsproblem i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

När du använder Aspose.Slides för .NET och lägger till [OleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe) på en bild visas meddelandet "EMBEDDED OLE OBJECT" på den resulterande bilden. Detta meddelande är avsiktligt och INTE ett fel.

För mer information om hur du arbetar med OLE-objekt, se [Manage OLE](/slides/sv/net/manage-ole/).

## **Förklaring och lösning**

Aspose.Slides visar meddelandet "EMBEDDED OLE OBJECT" för att meddela dig att OLE-objektet har ändrats och förhandsgranskningsbilden måste uppdateras. 

Till exempel, om du lägger till ett Microsoft Excel-diagram som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/oleobjectframe) på en bild (för mer detaljer, se artikeln "Manage OLE") och sedan öppnar presentationen i Microsoft PowerPoint, kommer du att se den här bilden på bilden:

![OLE-objektmeddelande](OLE_object_message.png)

Om du vill kontrollera och bekräfta att ditt OLE-objekt har lagts till på bilden måste du dubbelklicka på meddelandet "EMBEDDED OLE OBJECT", eller så kan du högerklicka på det och gå via alternativet **Object > Edit**.

![OLE-objekt > Redigera](OLE_object_edit.png)

PowerPoint öppnar då det inbäddade OLE-objektet.

![OLE-objektsdata](OLE_object_data.png)

Bilden kan behålla meddelandet "EMBEDDED OLE OBJECT". När du klickar på OLE-objektet uppdateras förhandsgranskningen av bilden och meddelandet "EMBEDDED OLE OBJECT" ersätts av den faktiska bilden för OLE-objektet. 

![OLE-objektförhandsgranskning](OLE_object_preview.png)

Nu kanske du vill spara presentationen för att säkerställa att bilden för OLE-objektet uppdateras korrekt. På så sätt, efter att du sparat presentationen, kommer du INTE att se meddelandet "EMBEDDED OLE OBJECT" när du öppnar presentationen igen. 

## **Andra lösningar**

### **Lösning 1: Ersätt meddelandet "Embedded OLE Object" med en bild**

Om du inte vill ta bort meddelandet "EMBEDDED OLE OBJECT" genom att öppna presentationen i PowerPoint och sedan spara den, kan du ersätta meddelandet med din föredragna förhandsgranskningsbild. Följande kodrader demonstrerar processen:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Lägg till en bild till presentationens resurser.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Ange en titel och bilden för OLE-objektets förhandsgranskning.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Bilden som innehåller `OleObjectFrame` ändras sedan till detta:

![Ny OLE-objektbild](OLE_object_new_image.png)

### **Lösning 2: Skapa ett tillägg för PowerPoint**

Du kan också skapa ett tillägg för Microsoft PowerPoint som uppdaterar alla OLE-objekt när du öppnar presentationer i programmet.