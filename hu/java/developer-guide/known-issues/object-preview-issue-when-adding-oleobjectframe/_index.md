---
title: Objektum Előnézeti Probléma OleObjectFrame Hozzáadásakor
linktitle: OLE Objektum Probléma
type: docs
weight: 10
url: /hu/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- beágyazott objektum
- beágyazott fájl
- objektum módosult
- objektum előnézet
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Ismerje meg, miért jelenik meg az EMBEDDED OLE OBJECT az OleObjectFrame hozzáadásakor az Aspose.Slides for Java-ban, és hogyan javítható az előnézeti probléma PPT, PPTX és ODP bemutatókban."
---
## **Bevezetés**

Az Aspose.Slides for Java használatakor, amikor egy [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/oleobjectframe/) keretet ad hozzá egy diára, a kimeneti dián egy "EMBEDDED OLE OBJECT" üzenet jelenik meg. Ez az üzenet szándékos, és NEM hibáról van szó.

További információkért az OLE objektumok használatáról, lásd a [Manage OLE](/slides/hu/java/manage-ole/) oldalt. 

## **Magyarázat és megoldás**

Az Aspose.Slides a "EMBEDDED OLE OBJECT" üzenetet jeleníti meg, hogy jelezze, az OLE objektum módosult és a előnézeti képet frissíteni kell. 

Például, ha egy Microsoft Excel ábrát ad hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/oleobjectframe/) keretként egy diára (további részletekért lásd a "Manage OLE" cikket), és ezt követően megnyitja a bemutatót a Microsoft PowerPointban, a dián ezt a képet fogja látni:

![OLE object message](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretné, hogy az OLE objektum hozzá lett adva a diához, dupla-kattintással kell aktiválnia a "EMBEDDED OLE OBJECT" üzenetet, vagy jobb-kattintással a **Object > Edit** lehetőséget választhatja.

![OLE object > Edit](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE objektumot.

![OLE object data](OLE_object_data.png)

A dia megtarthatja a "EMBEDDED OLE OBJECT" üzenetet. Amikor rákattint az OLE objektumra, a diá előnézete frissül, és a "EMBEDDED OLE OBJECT" üzenet helyét az OLE objektum tényleges képe veszi át. 

![OLE object preview](OLE_object_preview.png)

Most érdemes menteni a bemutatót, hogy biztosítsa az OLE objektum képének helyes frissítését. Így a bemutató mentése után, amikor újból megnyitja, nem fogja látni a "EMBEDDED OLE OBJECT" üzenetet. 

## **Egyéb megoldások**

### **Megoldás 1: A "Embedded OLE Object" üzenet cseréje képre**

Ha nem szeretné eltávolítani a "EMBEDDED OLE OBJECT" üzenetet a bemutató PowerPointban való megnyitásával és mentésével, helyettesítheti az üzenetet a kívánt előnézeti képpel. Az alábbi kódsorok bemutatják a folyamatot:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Kép hozzáadása a bemutató erőforrásaihoz.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Cím és kép beállítása az OLE objektum előnézetéhez.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

A `OleObjectFrame`‑et tartalmazó dia ezután így néz ki:

![New OLE object image](OLE_object_new_image.png)

### **Megoldás 2: Kiegészítő létrehozása a PowerPointhoz**

Létrehozhat egy kiegészítőt a Microsoft PowerPointhoz, amely a bemutatók megnyitásakor frissíti az összes OLE objektumot.