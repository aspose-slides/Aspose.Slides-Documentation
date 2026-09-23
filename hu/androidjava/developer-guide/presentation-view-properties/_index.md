---
title: Prezentáció nézet tulajdonságainak lekérése és frissítése Androidon
linktitle: Nézet tulajdonságok
type: docs
weight: 80
url: /hu/androidjava/presentation-view-properties/
keywords:
- nézet tulajdonságok
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
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android via Java nézet tulajdonságait a PPT, PPTX és ODP formátumú diák testreszabásához – állítsa be az elrendezéseket, nagyítási szinteket és megjelenítési beállításokat."
---
## **Bevezetés**

A normál nézet három tartalmi területből áll: a dia maga, egy oldalsó tartalmi terület és egy alsó tartalmi terület. A különböző tartalmi területek elhelyezésével kapcsolatos tulajdonságok. Ez az információ lehetővé teszi az alkalmazás számára, hogy elmentse a nézetállapotot a fájlba, így újbóli megnyitáskor a nézet ugyanabban az állapotban lesz, mint amikor a bemutató legutóbb mentve lett.

A [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) metódust hozzáadtuk, hogy hozzáférést biztosítson a bemutató normál nézet tulajdonságaihoz.  

[INormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfészek és azok leszármazottai, valamint a [SplitterBarStateType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType) felsorolt típusú enumeráció hozzá lett adva.

## **Az INormalViewProperties tulajdonságai**

A normál nézet tulajdonságait reprezentálja.

A [getShowOutlineIcons](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) és a [setShowOutlineIcons](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) metódusok meghatározzák, hogy az alkalmazás ikont jelenítsen-e meg, ha a vázlat tartalmat a normál nézet bármely tartalmi régiójában jeleníti meg.

A [getSnapVerticalSplitter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) és a [setSnapVerticalSplitter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) metódusok meghatározzák, hogy a függőleges osztó a mellékleges régió elég kicsi volta esetén minimalizált állapotba ragadjon-e.

A [getPreferSingleView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) és a [setPreferSingleView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) tulajdonságok meghatározzák, hogy a felhasználó előnyben részesíti-e egy teljes ablakos, egyetlen tartalmi régió megjelenítését a három tartalmi területet tartalmazó szabványos normál nézettel szemben. Ha engedélyezve van, az alkalmazás egy tartalmi régiót teljes ablakban jeleníthet meg.

A [getVerticalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusok határozzák meg, hogy milyen állapotban jelenjen meg a vízszintes vagy függőleges elválasztó sáv. A vízszintes elválasztó sáv elválasztja a diát a dia alatti tartalmi területtől, a függőleges elválasztó sáv a diát a oldalsó tartalmi területtől. Lehetséges értékek: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) és [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

A [getRestoredLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) és a [getRestoredTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) metódusok határozzák meg a normál nézet bal vagy felső diaterületének méretét, amikor a [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SplitterBarStateType#Restored) érték a [getVerticalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) és a [getHorizontalBarState](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) metódusokra vonatkozóan alkalmazásra kerül.

## **Az INormalViewProperties helyreállítása**

Meghatározza a normál nézet diaterületének (szélesség, ha a [getRestoredTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) alá tartozik, magasság, ha a [getRestoredLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) alá tartozik) méretét, amikor a terület változó helyreállított mérettel rendelkezik (sem minimalizált, sem maximalizált).

A [getDimensionSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) metódus határozza meg a diaterület méretét (szélesség, ha a restoredTop alá tartozik, magasság, ha a restoredLeft alá tartozik).

A [getAutoAdjust](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) metódus azt határozza meg, hogy a oldalsó tartalmi terület mérete kompenzálja-e az új méretet, amikor az alkalmazáson belüli nézetet tartalmazó ablakot átméretezik.

Az alábbi példa bemutatja, hogyan lehet hozzáférni a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) tulajdonságokhoz egy bemutató esetén.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Állítsa vissza a bemutató nézet tulajdonságait
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Az alapértelmezett nagyítási érték beállítása**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java mostantól támogatja az alapértelmezett nagyítási érték beállítását a bemutatóhoz, így amikor a bemutatót megnyitják, a nagyítás már be van állítva. Ez a [ViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) beállításával érhető el egy bemutató esetén. A [getSlideViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) valamint a [getNotesViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) programozottan beállítható. Ebben a témában példával megmutatjuk, hogyan állítható be a [View Properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) számára az Aspose.Slides-ben.

{{% /alert %}} 

A nézet tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Állítsa be a [View Properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ViewProperties) a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) számára.
1. Írja a bemutatót [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.
   Az alábbi példában a dia nézet és a jegyzet nézet nagyítási értékét állítottuk be.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // A bemutató nézet tulajdonságainak beállítása
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Nagyítási érték százalékban a dia nézethez
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Nagyítási érték százalékban a jegyzet nézethez

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A rács távolságának beállítása**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) metódust a bemutató szintű nézetbeállítások eléréséhez. Az [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) és [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) metódusok olvassák vagy módosítják a háttérben levő szerkesztő rács intervallumát. Ez a beállítás az egész bemutatóra vonatkozik, nem egyetlen diára. A rács távolságát pontokban adja meg, ahol 72 pont egy hüvelyknek felel meg. Használjon pozitív értéket, ahogy az API dokumentációja előírja.

A következő példa megnyit egy meglévő `demo.pptx` fájlt, kiírja a jelenlegi rács távolságát, beállít egy negyed hüvelykes intervallumot, majd elmenti az eredményt.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A rács különbözik a [drawing guides](/slides/hu/androidjava/drawing-guides/)-tól. A rács távolság egy szabályos intervallumot szabályoz, míg a rajzvezetők egyenként elhelyezett vízszintes vagy függőleges igazító vonalak. A rajzvezetők hozzáadása, mozgatása vagy törlése nem változtatja meg a rács távolságát.

A rács és a rajzvezetők egyaránt szerkesztési segédeszközök. Nem jelennek meg dia tartalomként PDF‑ben, képekben, SVG‑ben vagy diavetítésben. A rács távolság tárolása nem garantálja, hogy egy szerkesztő megjeleníti a rácsot: annak láthatósága a megjelenítő vagy szerkesztő beállításaitól is függ.

## **Megjegyzések megjelenítése vagy elrejtése a bemutató megnyitásakor**

Használja a [Presentation.getViewProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) metódust a bemutató szintű nézetbeállítások eléréséhez. A [IViewProperties.getShowComments](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) és a [IViewProperties.setShowComments](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) segítségével olvashatja vagy módosíthatja a tárolt beállítást, hogy a megjegyzések megjelenjenek-e a bemutató megnyitásakor a PowerPointban vagy más kompatibilis szerkesztőben.

Ez a beállítás csak a tárolt nézetpreferenciát vezérli. Nem ad hozzá, nem távolít el, nem szerkeszt, és nem old meg megjegyzéseket. A megjegyzések elrejtése megőrzi azok tartalmát, szerzőit, helyzetét, válaszait és állapotát. Tekintse meg a [Presentation Comments](/slides/hu/androidjava/presentation-comments/) oldalt a megjegyzéseken végzett műveletekhez.

A következő példa egy meglévő `comments.pptx` fájlt igényel, amely megjegyzéseket tartalmaz. Kiírja a jelenlegi láthatósági beállítást, kéri a megjegyzések elrejtését, és egy új PPTX‑et ment anélkül, hogy eltávolítaná a megjegyzéseket. Emellett a [IViewProperties.setLastView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) metódust a [ViewType.SlideView](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/viewtype/#SlideView) értékkel használja az kezdeti szerkesztői nézet a megjegyzés láthatósággal együtt beállításához.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a beállítás nem határozza meg, hogy a megjegyzések szerepelnek-e a PDF, HTML, kép, jegyzet vagy szórólap exportban. A megfelelő export‑specifikus beállításokat külön kell konfigurálni.

## **GYIK**

**Miért nem látható a rács a bemutató újbóli megnyitása után?**

A fájl tárolja a rács távolságát, de a szerkesztő határozza meg, hogy a rács megjelenik‑e. Ellenőrizze a szerkesztő rács láthatósági beállításait.

**Megváltoztatja-e a rajzvezetők törlése a rács távolságát?**

Nem. A rajzvezetők és a rács távolság független beállítások. A vezetők törlése a tárolt rács intervallumot változatlanul hagyja.

**Beállíthatok‑e különböző nézetbeállításokat a bemutató különböző szakaszaihoz?**

A [view settings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) a bemutató szintjén vannak definiálva (Normal View/Slide View), nem szakaszonként, ezért egyetlen paraméterkészlet érvényes az egész dokumentumra a megnyitáskor.

**Elöre definiálhatok‑e különböző nézetállapotokat különböző felhasználók számára?**

Nem. A beállítások a fájlban tárolódnak és meg vannak osztva. A megjelenítő alkalmazások tiszteletben tarthatják a felhasználói preferenciákat, de maga a fájl csak egyetlen nézet tulajdonságkészletet tartalmaz.

**Készíthetek‑e sablont előre definiált View Properties‑szel, hogy az új bemutatók ugyanúgy nyíljanak meg?**

Igen. Mivel a [view properties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getViewProperties--) a bemutató szintjén vannak tárolva, beágyazhatók egy sablonba, és új dokumentumok létrehozásakor ugyanaz a kezdeti nézetkonfiguráció használható.