---
title: Objektum előnézeti probléma OleObjectFrame hozzáadása esetén
linktitle: OLE objektum probléma
type: docs
weight: 10
url: /hu/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- beágyazott objektum
- beágyazott fájl
- objektum módosítva
- objektum előnézet
- prezentáció
- PowerPoint
- Python
- Aspose.Slides
description: "Ismerje meg, miért jelenik meg az EMBEDDED OLE OBJECT az OleObjectFrame hozzáadásakor az Aspose.Slides for Python-ban, és hogyan javíthatja a PPT, PPTX és ODP prezentációk előnézeti problémáit."
---
## **Bevezetés**

Az Aspose.Slides for Python via .NET használatakor, amikor a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) elemet ad hozzá egy diára, egy "EMBEDDED OLE OBJECT" üzenet jelenik meg a kimeneti dián. Ez az üzenet szándékos, és NEM hiba.

További információk az OLE objektumok kezeléséről a [OLE kezelése](/slides/hu/python-net/manage-ole/) oldalon találhatók. 

## **Magyarázat és megoldás**

Az Aspose.Slides megjeleníti az "EMBEDDED OLE OBJECT" üzenetet, hogy jelezze, hogy az OLE objektum megváltozott, és a nézeti képet frissíteni kell. 

Például, ha egy Microsoft Excel diagramot ad hozzá [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/)ként a diára (további részletekért lásd a "Manage OLE" cikket), majd megnyitja a prezentációt a Microsoft PowerPointban, a dián ezt a képet fogja látni:

![OLE objektum üzenet](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretné, hogy az OLE objektum a diára került, dupla kattintással kell az "EMBEDDED OLE OBJECT" üzenetre, vagy jobb‑kattintással, majd a **Object > Edit** lehetőséget választva.

![OLE objektum > Szerkesztés](OLE_object_edit.png)

A PowerPoint ezután megnyitja a beágyazott OLE objektumot.

![OLE objektum adatok](OLE_object_data.png)

A dia megtarthatja az "EMBEDDED OLE OBJECT" üzenetet. Ha rákattint az OLE objektumra, a dia előnézete frissül, és az "EMBEDDED OLE OBJECT" üzenet helyére az OLE objektum tényleges képe kerül. 

![OLE objektum előnézet](OLE_object_preview.png)

Most érdemes lehet a prezentációt menteni, hogy az OLE objektum képe megfelelően frissüljön. Így a prezentáció mentése után, amikor újra megnyitja, már NEM fogja látni az "EMBEDDED OLE OBJECT" üzenetet. 

## **Egyéb megoldások**

### **Megoldás 1: Az "Embedded OLE Object" üzenet cseréje egy képre**

Ha nem szeretné eltávolítani az "EMBEDDED OLE OBJECT" üzenetet a prezentáció PowerPointban való megnyitásával és mentésével, helyettesítheti az üzenetet a kívánt előnézeti képpel. A következő kódsorok bemutatják a folyamatot:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Kép hozzáadása a prezentáció erőforrásaihoz.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Cím és kép beállítása az OLE objektum előnézetéhez.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

A `OleObjectFrame`‑t tartalmazó dia ezután ezt a képet mutatja:

![Új OLE objektum kép](OLE_object_new_image.png)

### **Megoldás 2: Kiegészítő létrehozása a PowerPointhoz**

Létrehozhat egy kiegészítőt a Microsoft PowerPointhoz, amely a prezentációk megnyitásakor frissíti az összes OLE objektumot.