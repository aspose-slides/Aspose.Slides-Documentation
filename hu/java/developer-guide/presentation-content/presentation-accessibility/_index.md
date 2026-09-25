---
title: Prezentáció hozzáférhetőségének kezelése Java-ban
linktitle: Prezentáció hozzáférhetősége
type: docs
weight: 30
url: /hu/java/presentation-accessibility/
keywords:
- prezentáció hozzáférhetősége
- alternatív szöveg
- alternatív szöveg cím
- alternatív szöveg leírás
- dekoratívként jelölés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan segít az Aspose.Slides for Java automatizálni a prezentációk hozzáférhetőségi ellenőrzését PPT, PPTX és ODP fájlokban – javítja a képernyőolvasó élményét és növeli a megfelelőséget."
---
## **Bevezetés**

Az alternatív szöveg segíti a segítő technológiákat használó személyeket a képek, diagramok és egyéb információs alakzatok jelentésének megértésében. Ez a cikk bemutatja, hogyan olvassuk és frissítsük az alternatív szöveg címeit és leírásait az Aspose.Slides for Java segítségével, hogyan különböztessük meg a hozzáférhetőségi leírásokat a kódban használt forma nevektől, és hogyan ellenőrizzük, hogy egy forma dekoratívként van‑e jelölve.

Ezek a funkciók támogatják a prezentáció hozzáférhetőségét, de önmagukban nem garantálják azt. A olvasási sorrend, a színkontraszt, a szöveg olvashatósága és más hozzáférhetőségi követelmények is felülvizsgálatot igényelnek.

## **Alternatív szöveg címek és leírások kezelése**

Az alternatív szöveget arra használjuk, hogy a képek, diagramok és egyéb információs alakzatok jelentését elmagyarázzuk azoknak, akik nem láthatják őket. A következő módszerek és tartalmak különböző célokat szolgálnak:

| Módszer vagy tartalom | Cél |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Az alternatív leírás rövid címe. |
| [getAlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getAlternativeText--) | Értelemszerű leírás a forma tartalmáról vagy céljáról a dia kontextusában. |
| [getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getName--) | A forma neve, amelyet a kód a prezentációban egy adott forma megtalálásához használhat. |
| Látható szöveg | A dián megjelenő tartalom, például egy forma szövege vagy egy diagram címe és feliratai. Az alternatív szöveg frissítése nem változtatja meg ezt a tartalmat. |

Amikor egy prezentációt sablonként használnak újra, a kód a [getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getName--) által visszaadott név alapján megtalálhat egy formát, mielőtt frissítené azt. Ez a név más célra szolgál, mint az alternatív szöveg, amely azt magyarázza, hogy a vizuális elem mit közvetít az olvasónak. Név alapján keresve a szerzők javíthatják vagy lefordíthatják a leírásokat anélkül, hogy megváltoztatnák, hogyan találja meg a kód a formát. A neveket szerkeszthető, és nem garantált, hogy egyediek, ezért ellenőrizni kell, hogy a név a megfelelő formára vonatkozik‑e; lásd [Azonosítás és forma keresés](/slides/hu/java/shape-manipulations/#identify-and-find-shapes).

Az alábbi példa `input.pptx` fájlt igényel, amelynek az első diájának első formája egy irodai bejárat képe. A képet nem szabad dekoratívként megjelölni. A példa beolvassa és kiírja az aktuális alternatív szöveg címet és leírást, frissíti mindkettőt, majd a prezentációt `output.pptx` néven menti. Alkalmazd a szöveget a tényleges képre és az általa közvetített információra.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alternatív szöveg önmagában nem garantálja a prezentáció hozzáférhetőségét vagy az akadálymentesítési szabványoknak való megfelelést. Ellenőrizd a leírások pontosságát és relevanciáját, valamint vizsgáld meg az olvasási sorrendet, a színkontrasztot, a olvasható szöveget és más hozzáférhetőségi követelményeket. Az információt hordozó vizuális elemeket ne jelöld dekoratívként; a következő szakasz bemutatja, hogyan ellenőrizhető a [isDecorative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#isDecorative--) állapot.

## **Dekoratívként jelölés**

A dekoratívként jelölés a pusztán díszítő elemeket jelöli meg úgy, hogy a képernyőolvasók kihagyják őket, csökkentve a zajt és a figyelmet a lényeges tartalomra irányítva. Alkalmazd háttérképekre, díszítő motívumokra és elválasztókra – soha diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides ezt a jelzőt teszi elérhetővé az észleléshez és ellenőrzéshez, lehetővé téve az automatizált hozzáférhetőségi ellenőrzéseket és tisztítást.

![Dekoratívként jelölés](mark_as_decorative.png)

Az alábbi kódrészlet bemutatja, hogyan határozható meg, hogy egy forma dekoratívként van‑e megjelölve.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mit kell tartalmaznia az alternatív szöveg címnek és leírásnak?**

Használj rövid címet a tárgy azonosításához és leírást a vizuális elem által a diában közvetített információk magyarázatához. Diagram esetén írd le a releváns trendet vagy összehasonlítást, ne csak azt, hogy „diagram”.

**Használjam az alternatív szöveget a formák sablonban történő megtalálásához?**

Előnyben részesítsd a formák megtalálását a [getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getName--) által visszaadott név alapján, és ellenőrizd, hogy a várt formáról van‑e szó. Az alternatív szöveget szerkeszthetik vagy lefordíthatják, ami megtörheti a leírásra pontosan kereső kódot; lásd [Azonosítás és forma keresés](/slides/hu/java/shape-manipulations/).

**Mikor kell egy formát dekoratívként jelölni?**

A dekoratív jelzőt olyan vizuális elemekre használjuk, amelyek nem adnak információt, például díszítő motívumokra. Az információt közvetítő képeket és diagramokat megfelelő leírással kell ellátni.

**Az alternatív szöveg hozzáadása teszi a prezentációt teljesen hozzáférhetővé?**

Nem. Az alternatív szöveg csak a hozzáférhetőség egy részét fedi le. Ellenőrizd továbbá az olvasási sorrendet, a színkontrasztot, a szöveg olvashatóságát és egyéb alkalmazandó követelményeket; e tulajdonságok beállítása önmagában nem jelenti a megfelelőséget.