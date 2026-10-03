---
title: Objektum előnézeti helyőrző OleObjectFrame hozzáadásakor
linktitle: OLE előnézeti helyőrző
type: docs
weight: 10
url: /hu/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- előnézeti helyőrző
- tervezési szándék
- beágyazott objektum
- beágyazott fájl
- objektum megváltozott
- objektum előnézet
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Miért jelenik meg egy Aspose.Slides for Java-val hozzáadott OLE objektum esetén egy EMBEDDED OLE OBJECT helyőrző, amíg az előnézete nem frissül, és hogyan állíthatja be a saját előnézeti képét."
---
## **Bevezetés**

Az Aspose.Slides for Java használatával, amikor egy [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/oleobjectframe/) elemet ad egy diára, egy "EMBEDDED OLE OBJECT" üzenet jelenik meg a kimeneti dián. Ez az üzenet szándékos, és NEM hiba.

További információért az OLE objektumok kezeléséről, lásd a [Manage OLE](/slides/hu/java/manage-ole/) cikket.

## **Magyarázat és megoldás**

Az Aspose.Slides megjeleníti a "EMBEDDED OLE OBJECT" üzenetet, hogy jelezze, hogy az OLE objektum megváltozott, és a bélyegkép frissítésre szorul.

Például, ha egy Microsoft Excel diagramot [OleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/oleobjectframe/) elemként ad egy diára (további részletekért lásd a "Manage OLE" cikket), majd a prezentációt megnyitja a Microsoft PowerPointban, akkor ezt a képet fogja látni a dián:

![OLE objektum üzenet](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretné, hogy az OLE objektum hozzá lett adva a diához, dupla kattintással kell a "EMBEDDED OLE OBJECT" üzeneten, vagy jobb‑klikkel rá, majd a **Object > Edit** lehetőséget választva.

![OLE objektum > Szerkesztés](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE objektumot.

![OLE objektum adatok](OLE_object_data.png)

A dia megtarthatja a "EMBEDDED OLE OBJECT" üzenetet. Ha rákattint az OLE objektumra, a dia előnézete frissül, és a "EMBEDDED OLE OBJECT" üzenet helyére az OLE objektum tényleges képe kerül.

![OLE objektum előnézet](OLE_object_preview.png)

Most el szeretné menteni a prezentációt, hogy biztosítsa az OLE objektum képének helyes frissülését. Így a prezentáció mentése után, amikor újból megnyitja, már NEM fogja látni a "EMBEDDED OLE OBJECT" üzenetet.

## **Egyéb megoldás**

Ha nem szeretné eltávolítani a "EMBEDDED OLE OBJECT" üzenetet a prezentáció PowerPointban történő megnyitásával és mentésével, helyettesítheti az üzenetet a kívánt előnézeti képpel. Az alábbi kódsorok bemutatják a folyamatot. Feltételezik, hogy az *embeddedOLE.pptx* első diájának első alakzata az OLE objektum keret, és hogy a *myImage.png* tartalmazza a megjelenítendő képet, a végeredményt pedig az *embeddedOLE-newImage.pptx* fájlba menti:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Adjon hozzá egy képet a prezentáció erőforrásaihoz.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Állítsa be a képet az OLE objektum előnézeti képéhez.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az a dia, amely a `OleObjectFrame` elemet tartalmazza, ezután így néz ki:

![Új OLE objektum kép](OLE_object_new_image.png)