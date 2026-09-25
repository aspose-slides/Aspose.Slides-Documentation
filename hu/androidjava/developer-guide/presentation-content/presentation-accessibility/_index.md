---
title: Prezentáció hozzáférhetőség kezelése Androidon
linktitle: Prezentáció hozzáférhetőség
type: docs
weight: 30
url: /hu/androidjava/presentation-accessibility/
keywords:
- prezentáció hozzáférhetőség
- alternatív szöveg
- alternatív szöveg cím
- alternatív szöveg leírás
- dekoratívként jelölés
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan segít az Aspose.Slides for Android via Java automatizálni a prezentációk hozzáférhetőségi ellenőrzéseit PPT, PPTX és ODP fájlokban – javítja a képernyőolvasó élményét és növeli a megfelelőséget."
---
## **Bevezetés**

Az alternatív szöveg segíti a segítő technológiákat használó embereket a képek, diagramok és egyéb információs alakzatok jelentésének megértésében. Ez a cikk bemutatja, hogyan olvassuk és frissítsük az alternatív szöveg címét és leírását az Aspose.Slides for Android via Java segítségével, hogyan különböztessük meg a hozzáférhetőségi leírásokat a kódban használt alakzatnevektől, és hogyan ellenőrizzük, hogy egy alakzat dekoratívként van-e megjelölve.

Ezek a funkciók támogatják a prezentációk hozzáférhetőségét, de nem garantálják azt. Az olvasási sorrend, színkontraszt, szövegelolvashatóság és egyéb hozzáférhetőségi követelmények szintén felülvizsgálatra szorulnak.

## **Alternatív szöveg címek és leírások kezelése**

Használjon alternatív szöveget a képek, diagramok és egyéb információs alakzatok jelentésének megmagyarázására azok számára, akik nem láthatják őket. A következő metódusok és tartalmak különböző célokat szolgálnak:

| Metódus vagy tartalom | Cél |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Egy rövid cím az alternatív leíráshoz. |
| [getAlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | A forma tartalmának vagy céljának értelmes leírása a dia kontextusában. |
| [getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getName--) | A forma neve, amelyet a kód használ a konkrét forma megtalálásához a prezentációban. |
| Látható szöveg | A dián megjelenő tartalom, például egy forma szövege vagy egy diagram címe és feliratai. Az alternatív szöveg frissítése nem változtatja meg ezt a tartalmat. |

Amikor egy prezentációt sablonként újrahasználják, a kód a [getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getName--) által visszaadott név alapján találhat egy formát, mielőtt frissítené azt. Ez a név más célt szolgál, mint az alternatív szöveg, amely azt magyarázza, hogy a vizuális elem mit kommunikál az olvasónak. A név alapján keresés lehetővé teszi a szerzők számára, hogy javítsák vagy lefordítsák a leírásokat anélkül, hogy megváltoztatnák a kód által a forma megtalálásához használt módszert. A neveket szerkeszthető, de nem garantált, hogy egyediek, ezért ellenőrizze, hogy a név a kívánt formára vonatkozik‑e; lásd a [Identify and Find Shapes](/slides/hu/androidjava/shape-manipulations/#identify-and-find-shapes) szakaszt.

Az alábbi példa a `input.pptx` fájlt feltételezi, amelynek első diáján az első alakzat egy irodai bejárat képe. A képnek nem szabad dekoratívként megjelöltnek lennie. A példa kiolvassa és kiírja az aktuális alternatív szöveg címet és leírást, frissíti mindkét értéket, majd a prezentációt `output.pptx` néven menti. Igazítsa a megfogalmazást a tényleges képhez és a közvetített információkhoz.

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

Az alternatív szöveg hozzáadása önmagában nem garantálja a prezentáció hozzáférhetőségét vagy a hozzáférhetőségi szabványoknak való megfelelést. Ellenőrizze a leírások pontosságát és relevanciáját, és vizsgálja meg az olvasási sorrendet, színkontrasztot, olvasható szöveget és egyéb hozzáférhetőségi követelményeket. Az információt közlő vizuális elemeket ne jelölje dekoratívként; a következő szakasz bemutatja, hogyan ellenőrizhető a [isDecorative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#isDecorative--) metódus.

## **Megjelölés dekoratívként**

A dekoratívként való megjelölés azt a pusztán díszítő jellegű vizuális elemet jelöli, amelyet a képernyőolvasók kihagynak, ezzel csökkentve a zajt és a figyelmet a jelentős tartalomra összpontosítva. Alkalmazza háttérképekre, díszítőelemekre és helykitöltőkre – soha diagramokra, ikonokra vagy információt közlő képekre. Az Aspose.Slides ezt a jelzőt elérhetővé teszi a detektáláshoz és az ellenőrzéshez, lehetővé téve az automatizált hozzáférhetőségi vizsgálatot és takarítást.

![Mark as Decorative](mark_as_decorative.png)

Az alábbi kódrészlet bemutatja, hogyan határozható meg, hogy egy alakzat dekoratívként van‑e megjelölve.

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

**Mit kell a alternatív szöveg címébe és leírásába írni?**

Használjon rövid címet a tárgy azonosításához, és leírást a vizuális elem által a dián közvetített információ magyarázatához. Egy diagram esetén írja le a releváns trendet vagy összehasonlítást, ne csak "diagram" legyen a leírás.

**Használjam az alternatív szöveget a formák sablonban történő megtalálásához?**

Előnyben részesítse a forma megtalálását a [getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getName--) által visszaadott név alapján, és ellenőrizze, hogy a keresett forma a várt-e. Az alternatív szöveget szerkeszthetik vagy lefordíthatják, ami megtörheti a pontos leírást kereső kódot; lásd a [Identify and Find Shapes](/slides/hu/androidjava/shape-manipulations/) szakaszt.

**Mikor kell egy alakzatot dekoratívként megjelölni?**

A dekoratív jelzőt használja olyan vizuális elemekre, amelyek nem adnak információt, például díszítő elemekre. Az információt közlő képeket és diagramokat megfelelő leírás kell, hogy kísérje.

**Megteszi, hogy a bemutató teljesen hozzáférhető lesz, ha hozzáadunk alternatív szöveget?**

Nem. Az alternatív szöveg csak az elérhetőség egy részét fedi le. Vizsgálja meg továbbá az olvasási sorrendet, színkontrasztot, szövegelolvashatóságot és egyéb alkalmazandó követelményeket; csak ezen tulajdonságok beállítása nem jelenti a megfelelőséget.