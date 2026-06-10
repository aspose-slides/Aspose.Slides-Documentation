---
title: Objektum előnézeti probléma OleObjectFrame hozzáadásakor
linktitle: OLE objektum probléma
type: docs
weight: 10
url: /hu/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- beágyazott objektum
- beágyazott fájl
- objektum módosult
- objektum előnézet
- prezentáció
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, miért jelenik meg az EMBEDDED OLE OBJECT, amikor OleObjectFrame-et ad hozzá az Aspose.Slides for .NET-ben, és hogyan javíthatja az előnézeti problémákat PPT, PPTX és ODP prezentációkban."
---
## **Bevezetés**

Az Aspose.Slides for .NET használatával, amikor egy [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe)-t adsz egy diára, a kimeneti dián megjelenik egy „EMBEDDED OLE OBJECT” üzenet. Ez az üzenet szándékos, és NEM hiba.

További információk az OLE objektumokkal való munkavégzésről: [OLE kezelése](/slides/hu/net/manage-ole/). 

## **Magyarázat és megoldás**

Az Aspose.Slides megjeleníti a „EMBEDDED OLE OBJECT” üzenetet, hogy jelezze, az OLE objektum módosult, és a előnézeti képet frissíteni kell. 

Például, ha egy Microsoft Excel diagramot adsz egy [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe)-ként a diára (további részletek a „OLE kezelése” cikkben), majd megnyitod a prezentációt a Microsoft PowerPointban, a dián ezt a képet látod:

![OLE objektum üzenet](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretnéd, hogy az OLE objektum hozzá lett adva a diához, duplán kattints a „EMBEDDED OLE OBJECT” üzenetre, vagy jobb‑kattintással válaszd a **Object > Edit** lehetőséget.

![OLE objektum > Szerkesztés](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE objektumot.

![OLE objektum adat](OLE_object_data.png)

A dia megtarthatja a „EMBEDDED OLE OBJECT” üzenetet. Amint rákattintasz az OLE objektumra, a dia előnézete frissül, és a „EMBEDDED OLE OBJECT” üzenet helyére az OLE objektum tényleges képe kerül. 

![OLE objektum előnézet](OLE_object_preview.png)

Most el szeretnéd menteni a prezentációt, hogy az OLE objektum képe helyesen frissüljön. Így a mentés után, amikor újra megnyitod a prezentációt, már nem lesz látható a „EMBEDDED OLE OBJECT” üzenet. 

## **Egyéb megoldások**

### **Megoldás 1: A „Embedded OLE Object” üzenet cseréje képre**

Ha nem akarod eltávolítani a „EMBEDDED OLE OBJECT” üzenetet a PowerPointban történő megnyitás és mentés útján, kicserélheted az üzenetet a kívánt előnézeti képre. Az alábbi kódsorok bemutatják a folyamatot:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

A `OleObjectFrame`‑et tartalmazó dia ezután így néz ki:

![Új OLE objektum kép](OLE_object_new_image.png)

### **Megoldás 2: Bővítmény készítése a PowerPointhoz**

Készíthetsz egy bővítményt a Microsoft PowerPointhoz, amely a prezentációk megnyitásakor frissíti az összes OLE objektumot.