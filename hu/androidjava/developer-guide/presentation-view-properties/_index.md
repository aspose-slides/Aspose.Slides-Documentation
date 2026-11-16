---
title: Prezentáció nézet tulajdonságainak lekérdezése és frissítése Androidon
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/androidjava/presentation-view-properties/
keywords:
- nézet tulajdonságok
- normál nézet
- vázlat tartalom
- vázlat ikonok
- függőleges elválasztó rögzítése
- egyszemélyes nézet
- sáv állapot
- dimenzió méret
- automatikus igazítás
- alapértelmezett nagyítás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Használja az Aspose.Slides for Android via Java-t a normál nézet elrendezésének, a dia- és jegyzet nagyításának, a rács távolságának és a megjegyzések láthatóságának beállításához a PowerPoint prezentációkban."
---
## **Bevezetés**

A PowerPoint normál nézetében a dia egy oldalsó ablaktábla (bélyegképek vagy vázlat) és egy alatti jegyzetablak között jelenik meg. Az Aspose.Slides for Android via Java a prezentáció mentett szerkesztési beállításait teszi elérhetővé a [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) segítségével. Ezek közé tartozik az ablaktábla elrendezése, a nagyítási szintek, a rácsháló távolsága és a megjegyzések láthatósága.

## **Az INormalViewProperties felületről**

Használja a [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) metódust az [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) interfész eléréséhez. A [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) szabályozza, hogy ikonok jelenjenek‑e meg a diárcímek mellett a vázlatban. A [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) lehetővé teszi, hogy az oldalsó ablaktábla a felhasználó szűkítésekor minimalizált állapotba kapcsoljon. A [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) azt jelzi, hogy egy ablaktáblát szeretne megjeleníteni a teljes ablakban.

A [setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) a oldalsó ablaktábla és a dia közötti elválasztót vezérli. A [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) a jegyzetablak feletti elválasztót szabályozza. Mindkettő a [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` vagy `Restored` értéket fogad el.

## **Az INormalViewProperties helyreállításáról**

Amikor egy elválasztó helyreáll, a [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) az oldalsó ablaktábla mentett méretét, a [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) a felső dia terület mentett méretét adja vissza. Mindkettő a [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/) felületet teszi elérhetővé. Ennek a [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) metódusának 0‑tól 100‑ig terjedő százalékot kell megadni, a [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) pedig szabályozza, hogy a szerkesztő állítsa‑e át a méretet az ablak átméretezésekor.

Ez a példa frissít egy meglévő prezentációt. Visszaállítja a vízszintes elválasztót, a [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) által visszaadott méretet 80 %-ra állítja automatikus igazítással, és maximalizálja a függőleges elválasztót. Emellett meghívja a [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) metódust, hogy ikonokat jelenítsen meg a vázlat nézetben.

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

A [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) és a [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) független nagyítási beállításokat tárolnak a szerkesztő számára. Ezek a beállítások nem befolyásolják a dia méreteit, a diavetítés lejátszását vagy a képexport felbontását.

Ez a példa megnyit egy meglévő prezentációt, és a [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) metódust hívja meg, hogy a dia illeszkedjen a szerkesztőablakhoz. A jegyzetoldalon letiltja az automatikus méretezést, és a [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) metódussal egy rögzített 80 %-os nagyítást állít be.

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

A [setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) beállítja a szerkesztési rácsvonalak közti távolságot a teljes prezentációban. Pozitív értéket fogad pontokban, 72 pont hüvelykenként. Ez a példa kiírja az aktuális távolságot egy meglévő prezentációban, és a rácsot egy negyed hüvelykes méretre állítja 18 pont intervállal.

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
A rács egy rögzített intervallumban ismétlődik. A [Drawing guides](/slides/hu/androidjava/drawing-guides/) egyéni vízszintes vagy függőleges pozíciókat jelölnek. Mindkettő szerkesztési segédeszköz, és csak azokban a szerkesztőkben jelenik meg, amelyek támogatják őket. A diavetítések és a PDF, kép vagy SVG exportok kihagyják őket.

## **Megjegyzések megjelenítése vagy elrejtése a prezentáció megnyitásakor**

A [setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) egy preferenciát tárol, amelyet a kompatibilis szerkesztők a prezentáció megnyitásakor használnak. Egy meglévő, megjegyzésekkel rendelkező prezentáció esetén ez a példa kiírja a jelenlegi beállítást, és egy másolatot ment a megjegyzések elrejtésével. Emellett meghívja a [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) metódust a [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) értékkel, hogy a másolat dianézetben nyíljon meg.

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
A megjegyzések elrejtése megőrzi a szövegüket, szerzőiket, pozícióikat, válaszaikat és állapotukat. A megjegyzések módosításához lásd a [Presentation Comments](/slides/hu/androidjava/presentation-comments/) oldalt. Az export beállítások határozzák meg, hogy a megjegyzések megjelennek‑e PDF‑ben, HTML‑ben, képekben, jegyzetekben vagy szórólapokban.

## **GYIK**

**Miért rejtőzik el a rács, amikor újra megnyitom a prezentációt?**  
A prezentáció tárolja a rács intervallumát. A rács megtekintéséhez engedélyezze a rács láthatóságát a szerkesztőben.

**A rajzoló segédvonalak törlése megváltoztatja a rács távolságát?**  
Nem. A segédvonalak hozzáadása, mozgatása vagy törlése semmilyen változást nem okoz a rács intervallumában.

**Lehetnek a prezentáció különböző szekciói különböző nézetbeállításokkal?**  
Nem. A [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) a teljes prezentációra érvényes.

**Menthetek különböző nézetbeállításokat különböző felhasználóknak?**  
A fájl egyetlen nézetbeállítást tárol mindenki számára. A szerkesztő továbbá alkalmazhatja a felhasználó helyi beállításait.

**Menthetek nézetbeállításokat sablonba?**  
Igen. A sablonból létrehozott prezentációk öröklik a sablon mentett nézetbeállításait.