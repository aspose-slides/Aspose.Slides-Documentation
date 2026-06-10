---
title: Objektum előnézeti probléma OleObjectFrame hozzáadásakor
linktitle: OLE objektum probléma
type: docs
weight: 10
url: /hu/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti hiba
- beágyazott objektum
- beágyazott fájl
- objektum megváltozott
- objektum előnézet
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, miért jelenik meg az EMBEDDED OLE OBJECT, amikor OleObjectFrame-et ad hozzá az Aspose.Slides for C++-ban, és hogyan javíthatja a PPT, PPTX és ODP bemutatók előnézeti problémáit."
---
## **Bevezetés**

Az Aspose.Slides for C++ használatával, amikor egy [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) keretet ad egy diára, az „EMBEDDED OLE OBJECT” üzenet jelenik meg a kimeneti dián. Ez az üzenet szándékos, és NEM hiba.

További információkért az OLE‑objektumok kezeléséről, lásd a [Manage OLE](/slides/hu/cpp/manage-ole/) oldalt. 

## **Magyarázat és megoldás**

Az Aspose.Slides megjeleníti az „EMBEDDED OLE OBJECT” üzenetet, hogy jelezze, az OLE‑objektum módosult és a előnézeti képet frissíteni kell. 

Például, ha egy Microsoft Excel diagramot adsz egy [OleObjectFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/oleobjectframe/) kerethez egy dián (további részletekért lásd a „Manage OLE” cikket), majd megnyitod a bemutatót a Microsoft PowerPointban, a dián ezt a képet fogod látni:

![OLE object message](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretnéd, hogy az OLE‑objektum hozzá lett adva a diához, dupla‑kattintással kell a „EMBEDDED OLE OBJECT” üzenetre, vagy jobb‑klikkelve rá, majd a **Object > Edit** lehetőségen keresztül.

![OLE object > Edit](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE‑objektumot.

![OLE object data](OLE_object_data.png)

A dia megtarthatja a „EMBEDDED OLE OBJECT” üzenetet. Miután rákattintasz az OLE‑objektumra, a dia előnézete frissül, és a „EMBEDDED OLE OBJECT” üzenet helyére az OLE‑objektum tényleges képe kerül. 

![OLE object preview](OLE_object_preview.png)

Most lehet, hogy el szeretnéd menteni a bemutatót, hogy biztosítsd az OLE‑objektum képének helyes frissülését. Így a bemutató mentése után, amikor újra megnyitod, már NEM fogod látni a „EMBEDDED OLE OBJECT” üzenetet. 

## **Egyéb megoldások**

### **Megoldás 1: A „Embedded OLE Object” üzenet helyettesítése egy képpel**

Ha nem szeretnéd eltávolítani a „EMBEDDED OLE OBJECT” üzenetet a bemutató PowerPointban való megnyitásával és mentésével, helyettesítheted a üzenetet a kívánt előnézeti képpel. Az alábbi kódsorok bemutatják a folyamatot:

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

A `OleObjectFrame`‑t tartalmazó dia ezután erre változik:

![New OLE object image](OLE_object_new_image.png)

### **Megoldás 2: Add‑on készítése a PowerPointhoz**

Létrehozhatsz egy Microsoft PowerPoint‑bővítményt is, amely a bemutatók megnyitásakor frissíti az összes OLE‑objektumot.