---
title: Objektum előnézeti probléma OleObjectFrame hozzáadása esetén
linktitle: OLE objektum probléma
type: docs
weight: 10
url: /hu/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- beágyazott objektum
- beágyazott fájl
- objektum megváltozott
- objektum előnézet
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, miért jelenik meg az EMBEDDED OLE OBJECT, amikor OleObjectFrame-et ad hozzá az Aspose.Slides for Node.js-ben, és hogyan javíthatja a PPT, PPTX és ODP prezentációk előnézeti problémáit."
---
## **Bevezetés**

Az Aspose.Slides for Java használatával, amikor egy [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe/) keretet ad hozzá egy diára, a kimeneti dián egy "EMBEDDED OLE OBJECT" üzenet jelenik meg. Ez az üzenet szándékos, és NEM hiba.

További információkért az OLE objektumok használatáról, lásd a [Manage OLE](/slides/hu/nodejs-java/manage-ole/) oldalt. 

## **Magyarázat és megoldás**

Az Aspose.Slides a "EMBEDDED OLE OBJECT" üzenetet jeleníti meg, hogy értesítse, az OLE objektum megváltozott és a bélyegkép frissítésre szorul. 

Például, ha egy Microsoft Excel diagramot ad hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe/) keretként egy diára (a részletekért lásd a "Manage OLE" cikket), majd a prezentációt megnyitja a Microsoft PowerPointban, a dián ezt a képet fogja látni:

![OLE objektum üzenet](OLE_object_message.png)

Ha meg szeretné ellenőrizni és megerősíteni, hogy az OLE objektuma hozzá lett adva a diához, duplán kell kattintania a "EMBEDDED OLE OBJECT" üzenetre, vagy jobb‑klikkeltével a **Object > Edit** lehetőséget választhatja.

![OLE objektum > Szerkesztés](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE objektumot.

![OLE objektum adatok](OLE_object_data.png)

A dián továbbra is megmaradhat a "EMBEDDED OLE OBJECT" üzenet. Amint rákattint az OLE objektumra, a dia előnézete frissül, és a "EMBEDDED OLE OBJECT" üzenet helyére az OLE objektum tényleges képe kerül. 

![OLE objektum előnézet](OLE_object_preview.png)

Most szeretné menteni a prezentációt, hogy az OLE objektum képe helyesen frissüljön. Így a prezentáció mentése után, amikor újra megnyitja, már NEM fogja látni a "EMBEDDED OLE OBJECT" üzenetet. 

## **Egyéb megoldások**

### **Megoldás 1: A „Embedded OLE Object” üzenet cseréje képre**

Ha nem szeretné eltávolítani a "EMBEDDED OLE OBJECT" üzenetet a prezentáció PowerPointban való megnyitásával és mentésével, kicserélheti a üzenetet a kívánt előnézeti képre. Az alábbi kódsorok bemutatják a folyamatot:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Kép hozzáadása a prezentáció erőforrásaihoz.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Cím beállítása és a kép az OLE objektum előnézetéhez.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Az `OleObjectFrame`-et tartalmazó dia ezután így néz ki:

![Új OLE objektum kép](OLE_object_new_image.png)

### **Megoldás 2: Add‑on létrehozása a PowerPointhoz**

Létrehozhat egy add‑ont a Microsoft PowerPointhoz, amely a prezentációk megnyitásakor frissíti az összes OLE objektumot.