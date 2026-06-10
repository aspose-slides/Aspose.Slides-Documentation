---
title: Objektum előnézeti probléma OleObjectFrame hozzáadásakor
linktitle: OLE objektum probléma
type: docs
weight: 10
url: /hu/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- beágyazott objektum
- beágyazott fájl
- objektum módosult
- objektum előnézet
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, miért jelenik meg az EMBEDDED OLE OBJECT az OleObjectFrame hozzáadásakor az Aspose.Slides for Node.js használatával, és hogyan javíthatja a PPT, PPTX és ODP prezentációk előnézeti problémáit."
---
## **Bevezetés**

Aspose.Slides for Java használatakor, amikor egy [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe/) keretet ad hozzá egy diára, egy "EMBEDDED OLE OBJECT" üzenet jelenik meg a kimeneti dián. Ez az üzenet szándékos, és NEM hiba.

További információkért az OLE-objektumok kezeléséről, lásd a [OLE-kezelés](/slides/hu/nodejs-java/manage-ole/) oldalt.

## **Magyarázat és Megoldás**

Az Aspose.Slides megjeleníti a "EMBEDDED OLE OBJECT" üzenetet, hogy értesítse, hogy az OLE-objektum módosult, és a előnézeti képet frissíteni kell.

Például, ha egy Microsoft Excel diagramot ad hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe/) keretként egy diára (további részletekért lásd a "Manage OLE" cikket), majd megnyitja a bemutatót a Microsoft PowerPointban, a dián ezt a képet fogja látni:

![OLE objektum üzenet](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretné, hogy az OLE-objektuma hozzá lett adva a diához, duplán kell kattintania a "EMBEDDED OLE OBJECT" üzenetre, vagy jobb gombbal kattintva a **Objektum > Szerkesztés** lehetőséget választhatja.

![OLE objektum > Szerkesztés](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE-objektumot.

![OLE objektum adatok](OLE_object_data.png)

A dia megtarthatja a "EMBEDDED OLE OBJECT" üzenetet. Miután rákattint az OLE-objektumra, a dia előnézete frissül, és a "EMBEDDED OLE OBJECT" üzenet helyét az OLE-objektum tényleges képe veszi át.

![OLE objektum előnézet](OLE_object_preview.png)

Most érdemes menteni a bemutatót, hogy az OLE-objektum képe helyesen frissüljön. Így a bemutató mentése után, amikor újból megnyitja, már NEM fogja látni a "EMBEDDED OLE OBJECT" üzenetet.

## **Egyéb megoldások**

### **Megoldás 1: A "Embedded OLE Object" üzenet cseréje egy képre**

Ha nem szeretné eltávolítani a "EMBEDDED OLE OBJECT" üzenetet a bemutató PowerPointban való megnyitásával és mentésével, helyettesítheti az üzenetet a kívánt előnézeti képpel. Az alábbi kódsorok bemutatják a folyamatot:

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

### **Megoldás 2: Kiegészítő létrehozása a PowerPointhoz**

Létrehozhat egy kiegészítőt is a Microsoft PowerPointhoz, amely a bemutatók megnyitásakor frissíti az összes OLE-objektumot.