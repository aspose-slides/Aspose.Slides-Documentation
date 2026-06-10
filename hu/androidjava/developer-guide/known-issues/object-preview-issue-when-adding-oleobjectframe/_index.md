---
title: OleObjectFrame hozzáadása esetén objektum előnézeti probléma
linktitle: OLE objektum hiba
type: docs
weight: 10
url: /hu/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- beágyazott objektum
- beágyazott fájl
- objektum módosítva
- objektum előnézet
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, miért jelenik meg az EMBEDDED OLE OBJECT, amikor OleObjectFrame-et ad hozzá az Aspose.Slides for Android Java segítségével, és hogyan javíthatja az előnézeti problémákat PPT, PPTX és ODP prezentációkban."
---
## **Bevezetés**

Az Aspose.Slides for Android Java-n keresztül történő használatakor, ha egy [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/oleobjectframe/) keretet adsz egy diára, egy "EMBEDDED OLE OBJECT" üzenet jelenik meg a kimeneti dián. Ez az üzenet szándékos, és NEM hibáról van szó.

További információért az OLE objektumok kezeléséről lásd a [OLE kezelés](/slides/hu/androidjava/manage-ole/) oldalon. 

## **Magyarázat és megoldás**

Az Aspose.Slides a "EMBEDDED OLE OBJECT" üzenetet jeleníti meg, hogy jelezze, az OLE objektum megváltozott, és a bélyegkép frissítése szükséges. 

Például, ha egy Microsoft Excel diagramot adsz egy [OleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/oleobjectframe/) keretként egy diára (további részletekért lásd a "Manage OLE" cikket), majd megnyitod a bemutatót a Microsoft PowerPointban, a dián ezt a képet fogod látni:

![OLE objektum üzenet](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretnéd, hogy az OLE objektum hozzá lett adva a diához, duplán kell kattintanod a "EMBEDDED OLE OBJECT" üzenetre, vagy jobb gombbal kattintva a **Object > Edit** lehetőséget válaszd.

![OLE objektum > Szerkesztés](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE objektumot.

![OLE objektum adatok](OLE_object_data.png)

A dia megtarthatja a "EMBEDDED OLE OBJECT" üzenetet. Ha rákattintasz az OLE objektumra, a dia előnézete frissül, és a "EMBEDDED OLE OBJECT" üzenet helyére az OLE objektum tényleges képe kerül. 

![OLE objektum előnézet](OLE_object_preview.png)

Most érdemes elmenteni a bemutatót, hogy az OLE objektum képe helyesen frissüljön. Így a bemutató mentése után, amikor újra megnyitod, nem fogod látni a "EMBEDDED OLE OBJECT" üzenetet. 

## **Egyéb megoldások**

### **Megoldás 1: A "Embedded OLE Object" üzenet helyettesítése egy képpel**

Ha nem akarod eltávolítani a "EMBEDDED OLE OBJECT" üzenetet a bemutató PowerPointban történő megnyitásával és mentésével, helyettesítheted az üzenetet a kívánt előnézeti képpel. Az alábbi kódsorok bemutatják a folyamatot:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Képet ad a bemutató erőforrásaihoz.
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

A `OleObjectFrame`-et tartalmazó dia ezután így néz ki:

![Új OLE objektum kép](OLE_object_new_image.png)

### **Megoldás 2: Add-on készítése a PowerPointhoz**

Létrehozhatsz egy add-ont a Microsoft PowerPointhoz, amely a bemutatók megnyitásakor frissíti az összes OLE objektumot.