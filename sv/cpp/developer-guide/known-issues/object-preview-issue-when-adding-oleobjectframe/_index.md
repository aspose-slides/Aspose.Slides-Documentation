---
title: Problem med förhandsgranskning av objekt när OleObjectFrame läggs till
linktitle: OLE-objektproblem
type: docs
weight: 10
url: /sv/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- förhandsgranskningsproblem
- inbäddat objekt
- inbäddad fil
- objekt ändrat
- objektförhandsgranskning
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig varför EMBEDDED OLE OBJECT visas när OleObjectFrame läggs till i Aspose.Slides för C++ och hur du åtgärdar förhandsgranskningsproblem i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

När du använder Aspose.Slides för C++ och lägger till [OleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/) till en bild visas ett "EMBEDDED OLE OBJECT"-meddelande på utskriftsbilden. Detta meddelande är avsiktligt och INTE ett fel.

För mer information om hur du arbetar med OLE-objekt, se [Hantera OLE](/slides/sv/cpp/manage-ole/).

## **Förklaring och lösning**

Aspose.Slides visar meddelandet "EMBEDDED OLE OBJECT" för att meddela dig att OLE-objektet har ändrats och förhandsgranskningsbilden måste uppdateras. 

Till exempel, om du lägger till ett Microsoft Excel-diagram som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/oleobjectframe/) till en bild (för mer detaljer, se artikeln "Manage OLE") och sedan öppnar presentationen i Microsoft PowerPoint, kommer du att se den här bilden på bilden:

![OLE-objektmeddelande](OLE_object_message.png)

Om du vill kontrollera och bekräfta att ditt OLE-objekt har lagts till på bilden, måste du dubbelklicka på meddelandet "EMBEDDED OLE OBJECT", eller så kan du högerklicka på det och gå via alternativet **Object > Edit**.

![OLE-objekt > Redigera](OLE_object_edit.png)

PowerPoint öppnar sedan det inbäddade OLE-objektet.

![OLE-objektdata](OLE_object_data.png)

Bilden kan behålla meddelandet "EMBEDDED OLE OBJECT". När du klickar på OLE-objektet uppdateras förhandsgranskningen av bilden och meddelandet "EMBEDDED OLE OBJECT" ersätts av den faktiska bilden för OLE-objektet. 

![OLE-objektförhandsgranskning](OLE_object_preview.png)

Nu kanske du vill spara presentationen för att säkerställa att bilden för OLE-objektet uppdateras korrekt. På så sätt, efter att du sparat presentationen, kommer du INTE att se meddelandet "EMBEDDED OLE OBJECT" när du öppnar presentationen igen. 

## **Andra lösningar**

### **Lösning 1: Ersätt meddelandet "EMBEDDED OLE OBJECT" med en bild**

Om du inte vill ta bort meddelandet "EMBEDDED OLE OBJECT" genom att öppna presentationen i PowerPoint och sedan spara den, kan du ersätta meddelandet med din föredragna förhandsgranskningsbild. Dessa kodrader demonstrerar processen:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bilden som innehåller `OleObjectFrame` ändras sedan till detta:

![Ny OLE-objektbild](OLE_object_new_image.png)

### **Lösning 2: Skapa ett tillägg för PowerPoint**

Du kan också skapa ett tillägg för Microsoft PowerPoint som uppdaterar alla OLE-objekt när du öppnar presentationer i programmet.