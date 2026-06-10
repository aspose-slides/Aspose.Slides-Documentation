---
title: Objektum előnézeti probléma OleObjectFrame hozzáadásakor
linktitle: OLE objektum probléma
type: docs
weight: 10
url: /hu/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- előnézeti probléma
- beágyazott objektum
- beágyazott fájl
- objektum módosult
- objektum előnézet
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Tudja meg, miért jelenik meg az EMBEDDED OLE OBJECT, amikor OleObjectFrame-et ad hozzá az Aspose.Slides for PHP-ban, és hogyan javíthatja az előnézeti problémákat PPT, PPTX és ODP bemutatókban."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java használatakor, amikor egy [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) keretet adunk egy diára, egy „EMBEDDED OLE OBJECT” üzenet jelenik meg a kimeneti dián. Ez az üzenet szándékos és NEM hiba.

További információk az OLE objektumok kezeléséről a [Manage OLE](/slides/hu/php-java/manage-ole/) oldalon találhatók. 

## **Magyarázat és megoldás**

Az Aspose.Slides a „EMBEDDED OLE OBJECT” üzenetet jeleníti meg, hogy jelezze, az OLE objektum módosult és a előnézeti kép frissítésre szorul. 

Például, ha egy Microsoft Excel diagramot adunk hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/oleobjectframe/) keretként a diára (a „Manage OLE” cikkben részletezve), majd megnyitjuk a bemutatót a Microsoft PowerPointban, a következő képet látjuk a dián:

![OLE objektum üzenet](OLE_object_message.png)

Ha ellenőrizni és megerősíteni szeretnénk, hogy az OLE objektum valóban a diára került, duplán kell kattintani a „EMBEDDED OLE OBJECT” üzenetre, vagy jobb‑klikk után a **Object > Edit** lehetőséget választani.

![OLE objektum > Szerkesztés](OLE_object_edit.png)

A PowerPoint ekkor megnyitja a beágyazott OLE objektumot.

![OLE objektum adatok](OLE_object_data.png)

A dia megtarthatja a „EMBEDDED OLE OBJECT” üzenetet. Amint rákattintunk az OLE objektumra, a dia előnézete frissül, és a „EMBEDDED OLE OBJECT” üzenet helyett megjelenik az OLE objektum tényleges képe. 

![OLE objektum előnézet](OLE_object_preview.png)

Most érdemes elmenteni a bemutatót, hogy az OLE objektum képe helyesen frissüljön. Így a mentés után a bemutató újbóli megnyitásakor már nem jelenik meg a „EMBEDDED OLE OBJECT” üzenet. 

## **Egyéb megoldások**

### **Megoldás 1: A „Embedded OLE Object” üzenet cseréje képre**

Ha nem szeretnénk a PowerPointban megnyitni és menteni a bemutatót a „EMBEDDED OLE OBJECT” üzenet eltávolításához, helyettesíthetjük az üzenetet a kívánt előnézeti képpel. A következő kódsorok bemutatják a folyamatot:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // Kép hozzáadása a prezentáció erőforrásaihoz.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Cím és a kép beállítása az OLE objektum előnézetéhez.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Ezután a `OleObjectFrame`‑et tartalmazó dia így módosul:

![Új OLE objektum kép](OLE_object_new_image.png)

### **Megoldás 2: PowerPoint kiegészítő készítése**

Készíthetünk egy Microsoft PowerPoint kiegészítőt is, amely a bemutatók megnyitásakor frissíti az összes OLE objektumot.