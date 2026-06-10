---
title: OLE objektumok automatikus frissítése PowerPoint kiegészítővel
type: docs
weight: 10
url: /hu/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE objektum
- OLE frissítése
- automatikusan
- kiegészítő
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet automatikusan frissíteni az OLE diagramokat és objektumokat a PowerPointban egy kiegészítő és az Aspose.Slides for Java segítségével, gyakorlati kóddal és optimalizálási tippekkel."
---
## **Bevezetés**

Az Aspose.Slides for Java ügyfelei által a leggyakrabban feltett kérdések egyike, hogy hogyan hozhatók létre vagy módosíthatók a szerkeszthető diagramok (vagy egyéb OLE objektumok), hogy a bemutató megnyitásakor automatikusan frissüljenek. Sajnos a PowerPoint nem támogatja az automatikus makrókat ugyanúgy, mint az Excel és a Word. Az egyetlen elérhető makrók a `Auto_Open` és a `Auto_Close`, és ezek csak egy kiegészítőből futnak automatikusan. Ez a rövid technikai tipp bemutatja, hogyan érhető el ez.

## **OLE objektumok automatikus frissítése**

Először is több ingyenes kiegészítő is elérhető, amelyek hozzáadják a Auto_Open makró funkciót a PowerPointhoz, például az [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) és az [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Az egyik kiegészítő telepítése után egyszerűen adja hozzá a `Auto_Open()` makrót (vagy `OnPresentationOpen()`-t, ha a Event Generator-t használja) a sablon bemutatójához, ahogyan az alább látható:

```java
// Végigmenet a bemutató minden dián.
for (var oSlide : ActivePresentation.Slides) {
    // Végigmenet az aktuális dián lévő összes alakzaton.
    for (var oShape : oSlide.Shapes) {
        // Ellenőrzi, hogy az alakzat OLE objektum-e.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // OLE objektumot talált. Szerezze be az objektumhivatkozást, majd frissítse.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Most kilép az OLE kiszolgáló programból.
            // Ez felszabadítja a memóriát, és megelőzi a problémákat.
            // Emellett állítsa az oObject-et Nothing-ra az objektum felszabadításához.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Az Aspose.Slides for Java-val készített OLE objektumok bármilyen módosítása automatikusan frissülni fog, amikor a PowerPoint megnyitja a bemutatót. Ha sok OLE objektuma van, és nem szeretné mindet frissíteni, egyszerűen adjon egy egyedi címkét a feldolgozni kívánt alakzatokhoz, és ellenőrizze azt a makróban.