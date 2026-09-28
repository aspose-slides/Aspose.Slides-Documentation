---
title: Objektum Előnézet Helyőrző OleObjectFrame Hozzáadásakor
linktitle: OLE Előnézet Helyőrző
type: docs
weight: 10
url: /hu/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- előnézeti helyőrző
- terv szerint
- beágyazott objektum
- beágyazott fájl
- objektum módosult
- objektum előnézet
- prezentáció
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Miért jelenik meg egy Aspose.Slides for .NET‑vel hozzáadott OLE objektumnál beágyazott OLE OBJECT helyőrző, amíg az előnézet nincs frissítve, és hogyan állíthatja be saját előnézeti képét."
---
## **Bevezetés**

Az Aspose.Slides for .NET használatával, amikor egy [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe/) elemet ad egy diára, egy "EMBEDDED OLE OBJECT" üzenet jelenik meg a kimeneti dián. Ez az üzenet szándékos, és NEM hiba.

Az OLE objektumokkal való munkáról további információkért lásd a [Manage OLE](/slides/hu/net/manage-ole/) oldalt.

## **Magyarázat és megoldás**

Az Aspose.Slides megjeleníti a "EMBEDDED OLE OBJECT" üzenetet, hogy jelezze, hogy az OLE objektum módosult, és a előnézeti képet frissíteni kell.

Például, ha egy Microsoft Excel diagramot ad egy [OleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/oleobjectframe/) elemmel egy diára (további részletekért lásd a "Manage OLE" cikket), majd megnyitja a prezentációt a Microsoft PowerPointban, a dián ezt a képet fogja látni:

![OLE objektum üzenet](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretné, hogy az OLE objektum hozzá lett adva a diához, duplán kell kattintania a "EMBEDDED OLE OBJECT" üzenetre, vagy jobb-clickeltetve rá, a **Object > Edit** lehetőségen keresztül.

![OLE objektum > Szerkesztés](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE objektumot.

![OLE objektum adatok](OLE_object_data.png)

A dia megtarthatja a "EMBEDDED OLE OBJECT" üzenetet. Amint ráklikkel az OLE objektumra, a dia előnézete frissül, és a "EMBEDDED OLE OBJECT" üzenet helyére az OLE objektum tényleges képe kerül.

![OLE objektum előnézet](OLE_object_preview.png)

Most előfordulhat, hogy menteni szeretné a prezentációt, hogy biztosítsa az OLE objektum képének megfelelő frissítését. Így a prezentáció mentése után, amikor újra megnyitja, már NEM fogja látni a "EMBEDDED OLE OBJECT" üzenetet.

## **Egyéb megoldások**

### **Megoldás 1: A "Embedded OLE Object" üzenet cseréje képre**

Ha nem szeretné eltávolítani a "EMBEDDED OLE OBJECT" üzenetet úgy, hogy megnyitja a prezentációt a PowerPointban, majd elmenti, akkor helyettesítheti az üzenetet a kívánt előnézeti képpel. Az alábbi kódsorok bemutatják a folyamatot:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

A `OleObjectFrame` elemet tartalmazó dia ezután ilyen lesz:

![Új OLE objektum kép](OLE_object_new_image.png)

### **Megoldás 2: Kiegészítő létrehozása a PowerPointhoz**

Létrehozhat egy kiegészítőt is a Microsoft PowerPointhoz, amely frissíti az összes OLE objektumot, amikor megnyitja a prezentációkat a programban.