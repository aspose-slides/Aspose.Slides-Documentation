---
title: A prezentáció nézetbeállításainak lekérdezése és frissítése Java-ban
linktitle: Nézetbeállítások
type: docs
weight: 80
url: /hu/java/presentation-view-properties/
keywords:
- nézetbeállítások
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges osztó rögzítése
- egyetlen nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides for Java-t a PowerPoint prezentációk normál nézetelrendezésének, dia- és jegyzetnagyításának, rácstávolságának és a megjegyzések láthatóságának beállításához."
---
## **Bevezetés**

A PowerPoint normál nézetében a dia egy oldalsó ablaktábla között jelenik meg, amely bélyegképeket vagy vázlatot tartalmaz, és alul egy jegyzetablaktábla. Az Aspose.Slides for Java a prezentáció mentett szerkesztési beállításait a [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) segítségével teszi elérhetővé. Ezek közé tartozik az ablaktábla elrendezése, a nagyítási szintek, a rács távolsága és a megjegyzések láthatósága.

## **Az INormalViewProperties-ról**

Használja a [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) a [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/) felület eléréséhez. A [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) szabályozza, hogy ikonok jelenjenek-e meg a dia címek mellett a vázlatban. A [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) lehetővé teszi, hogy az oldalsó ablaktábla a felhasználó szűkítésekor a minimalizált állapotba ragadjon. A [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) egy olyan preferenciát jelöl, hogy egy ablaktáblát jelenítsenek meg a teljes ablakban.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) szabályozza az oldalsó ablaktábla és a dia közötti elválasztót. A [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) szabályozza a jegyzetablaktábla feletti elválasztót. Mindkettő egy [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) értéket fogad el, amely lehet `Minimized`, `Maximized` vagy `Restored`.

## **Az INormalViewProperties visszaállításáról**

Amikor egy elválasztót visszaállítanak, a [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) a side pane mentett méretét, a [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) pedig a felső dia terület mentett méretét adja meg. Mindkettő a [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/) felületet teszi elérhetővé. Ennek a [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) metódusnak 0‑tól 100‑ig terjedő százalékot kell megadni, a [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) pedig szabályozza, hogy a szerkesztő módosítsa‑e a méretet az ablak átméretezésekor.

Ez a példa egy meglévő prezentációt frissít. Visszaállítja a vízszintes elválasztót, a [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) által visszaadott méretet 80%‑ra állítja be automatikus igazítással, és maximalizálja a függőleges elválasztót. Emellett meghívja a [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) metódust, hogy ikonok jelenjenek meg a vázlat nézetben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az alapértelmezett nagyítási érték beállítása**

A [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) független nagyítási beállításokat tárolnak a szerkesztő számára. Ezek a beállítások nem befolyásolják a dia méreteit, a diavetítés lejátszását vagy a kép export felbontását.

Ez a példa megnyit egy meglévő prezentációt, és meghívja a [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) metódust, hogy a dia illeszkedjen a szerkesztési ablakhoz. A jegyzetoldal esetében letiltja az automatikus méretezést, és a [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) segítségével 80%‑os fix nagyítást állít be.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A rács távolságának beállítása**

A [setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) beállítja a szerkesztési rácsvonalak közötti távolságot a teljes prezentációban. Pozitív értéket vesz fel pontban, 72 pont hüvelykenként. Ez a példa kiírja a jelenlegi távolságot egy meglévő prezentációban, és egy negyed hüvelykes rácsot ment úgy, hogy az intervallumot 18 pontra állítja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);
    
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A rács egy fix intervallumon ismétlődik. A [Drawing guides](/slides/hu/java/drawing-guides/) egyedi vízszintes vagy függőleges pozíciókat jelölnek. Mindkettő a szerkesztést segíti, és csak azokban a szerkesztőkben jelenik meg, ahol engedélyezett. A diavetítések és a PDF, kép vagy SVG exportok kihagyják őket.

## **Megjegyzések megjelenítése vagy elrejtése prezentáció megnyitásakor**

A [setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) egy olyan preferenciát tárol, amelyet a kompatibilis szerkesztők a prezentáció megnyitásakor használnak. Egy megjegyzésekkel ellátott meglévő prezentáció esetén ez a példa kiírja a jelenlegi beállítást, és egy példányt ment, amelynek a megjegyzései el vannak rejtve. Emellett meghívja a [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) metódust a [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) értékkel, hogy a másolat dia nézetben nyíljon meg.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A megjegyzések elrejtése megőrzi a szövegüket, szerzőiket, pozícióikat, válaszaikat és állapotaikat. A megjegyzések módosításához lásd a [Presentation Comments](/slides/hu/java/presentation-comments/) oldalt. Az exportálási beállítások határozzák meg, hogy a megjegyzések megjelennek‑e PDF‑ben, HTML‑ben, képekben, jegyzetekben vagy szórólapokon.

## **GYIK**

**Miért van a rács elrejtve, amikor újra megnyitom a prezentációt?**

A prezentáció tárolja a rács intervallumát. A rács megtekintéséhez engedélyezze a rács láthatóságát a szerkesztőben.

**A rajzsegélyek törlése módosítja a rács távolságát?**

Nem. A segédvonalak hozzáadása, mozgatása vagy törlése nem változtatja meg a rács intervallumát.

**Lehetnek a prezentáció egyes szakaszai különböző nézetbeállításokkal?**

Nem. A [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) az egész prezentációra érvényes.

**Menthetek különböző nézetbeállításokat különböző felhasználóknak?**

A fájl mindenki számára egyetlen nézetbeállítást tárol. A szerkesztő továbbiakban alkalmazhatja a felhasználó helyi preferenciáit.

**Menthetek nézetbeállításokat egy sablonba?**

Igen. A sablonból létrehozott prezentációk öröklik a sablon mentett nézetbeállításait.