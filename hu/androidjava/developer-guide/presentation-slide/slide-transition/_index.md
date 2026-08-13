---
title: "Diaátmenetek kezelése prezentációkban Androidon"
linktitle: "Diaátmenet"
type: docs
weight: 80
url: /hu/androidjava/slide-transition/
keywords:
- "diaátmenet"
- "diaátmenet hozzáadása"
- "diaátmenet alkalmazása"
- "fejlett diaátmenet"
- "Morph átmenet"
- "átmenettípus"
- "átmeneti hatás"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan testre szabhatja a diaátmeneteket az Aspose.Slides for Android via Java segítségével, részletes lépésről‑lépésre útmutatóval PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a diák átmenetei a prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan alkalmazhatók átmenettípusok a diákra, hogyan konfigurálhatók az átmenet viselkedései, például a kattintásra vagy megadott idő után történő előrehaladás, hogyan használható a Morph átmenet és annak típusai, valamint hogyan állíthatók be az átmenet effektus opciói. A példák bemutatják, hogyan töltsünk be vagy hozzunk létre egy prezentációt, hogyan módosítsuk a kiválasztott diák átmenet‑beállításait, és hogyan mentsük az eredményt PPTX fájlként. A cikk emellett válaszol a gyakori kérdésekre az átmenet sebességével, hangjával, ugyanazon átmenet több diára történő alkalmazásával és a dián jelenleg beállított átmenet ellenőrzésével kapcsolatban.

## **Diákátmenet hozzáadása**
Egyszerű diákátmenet hatás létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation)osztályból.
1. Az Aspose.Slides for Android via Java által kínált átmeneti hatások közül egy Diákátmenet típust alkalmazzon a diára aTransitionTypefelsoroló típuson keresztül.
1. Írja ki a módosított prezentációfájlt.

```java
import com.aspose.slides.*;

// A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Kör típusú átmenet alkalmazása az első dián
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Comb típusú átmenet alkalmazása a második dián
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // A prezentáció mentése a lemezre
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fejlett diákátmenet hozzáadása**
Az előző szakaszban egyszerű átmeneti hatást alkalmaztunk a diára. Most, hogy ezt az egyszerű átmenetet még jobbá és irányíthatóbbá tegyük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation)osztályból.
1. Alkalmazzon egy Diákátmenet típust a diára az Aspose.Slides for Android via Java által kínált átmeneti hatások egyikéből.
1. Beállíthatja az átmenetet, hogy kattintásra haladjon, egy adott idő után, vagy mindkettő.
1. Ha a diákátmenet be van állítva Kattintásra haladni, az átmenet csak akkor lép tovább, ha valaki a egérre kattint. Továbbá, ha az'Advance After Time' (Idő után haladás) tulajdonság be van állítva, az átmenet automatikusan a megadott idő letelte után lép tovább.
1. Írja ki a módosított prezentációt prezentációfájlként.

```java
import com.aspose.slides.*;

// Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Kör típusú átmenet alkalmazása az 1. dián
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Haladás kattintásra vagy automatikusan 3 másodperc után
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Comb típusú átmenet alkalmazása a 2. dián
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Haladás kattintásra vagy automatikusan 5 másodperc után
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zoom típusú átmenet alkalmazása a 3. dián
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Haladás kattintásra vagy automatikusan 7 másodperc után
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // A prezentáció mentése a lemezre
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph átmenet**
{{% alert color="info" %}} 
Az Aspose.Slides for Android via Java most már támogatja a[Morph átmenet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMorphTransition)átmenetet. Ez a PowerPoint 2019‑ben bevezetett új morph átmenet. 
{{% /alert %}} 

A Morph átmenet lehetővé teszi a sima mozgás animálását az egyik diáról a következőre. Ez a cikk bemutatja a koncepciót és a Morph átmenet használatát. A Morph átmenet hatékony használatához két diára van szükség, amelyeknek legalább egy közös objektuma van. A legegyszerűbb módja a dia duplikálása, majd a második dián lévő objektum áthelyezése egy másik helyre.

A következő kódrészlet megmutatja, hogyan adhatunk a prezentációhoz egy szöveggel rendelkező dia klónt, és állíthatunk be egy[morph típus](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TransitionType)átmenetet a második diára.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Morph átmenet típusok**
Új[TransitionMorphType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TransitionMorphType)felsoroló típus került hozzáadásra. Ez a Morph diákátmenet különböző típusait képviseli.

A TransitionMorphType felsoroló típus három taggal rendelkezik:

- ByObject: A Morph átmenet a formákat oszthatatlan objektumokként veszi figyelembe.
- ByWord: A Morph átmenet szöveget szavak szerint továbbít, ahol lehetséges.
- ByChar: A Morph átmenet szöveget karakterek szerint továbbít, ahol lehetséges.

A következő kódrészlet megmutatja, hogyan állítható be a morph átmenet a diára és hogyan változtatható meg a morph típus:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Átmenet hatások beállítása**
Az Aspose.Slides for Android via Java támogatja az átmenet hatások beállítását, például feketéből, balról, jobbról stb. Az átmenet hatás beállításához kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation)osztályból.
- Szerezze meg a dia hivatkozását.
- Állítsa be az átmenet hatást.
- Írja ki a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/)fájlként.

Az alább bemutatott példában beállítottuk az átmenet hatásokat.

```java
import com.aspose.slides.*;

// A Presentation osztály példányosítása
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Hatás beállítása
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // A prezentáció mentése a lemezre
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

### Irányíthatom a diákátmenet lejátszási sebességét?
Igen. Állítsa be az átmenet [sebesség](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) a[TransitionSpeed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionspeed/)beállítással (pl. lassú/közepes/gyors).

### Csatolhatok hangot az átmenethez, és beállíthatom a hurok módot?
Igen. Beágyazhat egy hangot az átmenethez, és a viselkedést szabályozhatja olyan beállításokkal, mint a hang mód és a hurok (pl. [setSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), valamint olyan metaadatokkal, mint a [setSoundIsBuiltIn](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) és a [setSoundName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzuk minden diára?
Állítsa be a kívánt átmenettípust minden dia átmenet‑beállításában; az átmenetek diánként vannak tárolva, így az azonos típus minden diára való alkalmazása konzisztens eredményt ad.

### Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?
Ellenőrizze a dia[transition settings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) és olvassa ki a[transition type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setType-int-)értékét; ez az érték pontosan megmondja, melyik effektus van alkalmazva.