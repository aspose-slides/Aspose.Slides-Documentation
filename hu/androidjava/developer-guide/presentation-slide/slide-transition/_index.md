---
title: Diaátmenetek kezelése Androidos prezentációkban
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/androidjava/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- fejlett diaátmenet
- morph átmenet
- átmenettípus
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan testreszabhatja a diaátmeneteket az Aspose.Slides for Android via Java segítségével, lépésről lépésre útmutatóval PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a diaátmenetek a prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan alkalmazhatók átmenettípusok a diákra, hogyan konfigurálható az átmenet viselkedése, például a kattintásra vagy meghatározott idő után való előrehaladás, hogyan ellenőrizhető és letiltható az automatikus előrehaladás, hogyan használható a Morph átmenet és típusai, valamint hogyan állíthatók be az átmenet hatásbeállításai. A példák bemutatják, hogyan töltsünk be vagy hozzunk létre egy prezentációt, módosítsuk a kiválasztott diák átmenet beállításait, és mentse az eredményt PPTX fájlként. A cikk emellett válaszol gyakori kérdésekre az átmenet sebességéről, átmenet hangokról, ugyanazon átmenet több diára való alkalmazásáról, valamint arra vonatkozóan, hogyan ellenőrizhető a diához jelenleg beállított átmenet.

## **Diaátmenet hozzáadása**
Egyszerű diaátmenet‑hatás létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Alkalmazzon egy Diaátmenet típust a diára az Aspose.Slides for Android via Java által kínált átmeneti hatások közül a TransitionType felsoroltán keresztül.
1. Írja ki a módosított prezentáció fájlt.

```java
// Példányosítsa a Presentation osztályt a forrás prezentációs fájl betöltéséhez
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Alkalmazzon kör típusú átmenetet az 1. diára
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Alkalmazzon fésű típusú átmenetet a 2. diára
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Írja a prezentációt a lemezre
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fejlett diaátmenet hozzáadása**
Az előző szakaszban csak egy egyszerű átmeneti hatást alkalmaztunk a diára. Most, hogy ezt az egyszerű átmenetet még jobbá és irányíthatóbbá tegyük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Alkalmazzon egy Diaátmenet típust a diára az Aspose.Slides for Android via Java által kínált átmeneti hatások közül.
1. Azt is beállíthatja, hogy az átmenet kattintásra, egy adott idő elteltével vagy mindkettőre haladjon előre.
1. Ha a diaátmenet a „Haladjon előre kattintásra” beállítással van engedélyezve, az átmenet csak akkor halad előre, ha valaki rákattint az egérre. Ezenkívül, ha az „Advance After Time” (Idő után előrehaladás) tulajdonság be van állítva, az átmenet automatikusan halad előre a megadott idő letelte után.
1. Írja ki a módosított prezentációt prezentáció fájlként.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Alkalmazzon kör típusú átmenetet az 1. diára
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Állítsa be az átmenet időt 3 másodpercre
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Alkalmazzon fésű típusú átmenetet a 2. diára
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Állítsa be az átmenet időt 5 másodpercre
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Alkalmazzon zoom típusú átmenetet a 3. diára
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Állítsa be az átmenet időt 7 másodpercre
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Írja a prezentációt a lemezre
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph átmenet**
{{% alert color="primary" %}} 

Az Aspose.Slides for Android via Java most már támogatja a [Morph Transition](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMorphTransition) funkciót. Ezek a PowerPoint 2019‑ben bevezetett új morph átmenetet képviselik.

{{% /alert %}} 

A Morph átmenet lehetővé teszi, hogy sima mozgást animáljon az egyik diáról a következőre. Ez a cikk leírja a koncepciót és a Morph átmenet használatát. A Morph átmenet hatékony használatához két diára van szükség, amelyeknek legalább egy közös objektuma van. A legegyszerűbb módja, ha megkettőzzük a diát, majd a második dián a objektumot egy másik helyre helyezzük.

Az alábbi kódrészlet bemutatja, hogyan adhatunk egy klónozott diát szöveggel a prezentációhoz, és állíthatunk be egy [morph type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TransitionType) átmenetet a második diára.

```java
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
Új [TransitionMorphType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TransitionMorphType) felsorolt került hozzáadásra. Különböző Morph diaátmenet típusokat képvisel.

A TransitionMorphType felsorolt három taggal rendelkezik:

- ByObject: A Morph átmenet úgy lesz végrehajtva, mintha a formákat elválaszthatatlan objektumoknak tekintenénk.
- ByWord: A Morph átmenet szöveget szavak szerint továbbítja, ahol lehetséges.
- ByChar: A Morph átmenet szöveget karakterek szerint továbbítja, ahol lehetséges.

Az alábbi kódrészlet bemutatja, hogyan állítható be a morph átmenet egy diára, és hogyan módosítható a morph típus:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Átmeneti hatások beállítása**
Az Aspose.Slides for Android via Java támogatja az átmeneti hatások beállítását, mint például a feketéből, balról, jobbról stb. Az átmeneti hatás beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
- Szerezze meg a dia hivatkozását.
- Állítsa be az átmeneti hatást.
- Írja ki a prezentációt [PPTX ](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi példában beállítottuk az átmeneti hatásokat.

```java
// Példányosítsa a Presentation osztályt
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Állítsa be a hatást
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Írja a prezentációt a lemezre
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Módosíthatom a diaátmenet lejátszási sebességét?**

Igen. Állítsa be az átmenet [sebesség](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) paraméterét a [TransitionSpeed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/transitionspeed/) beállítással (pl. lassú/közepes/gyors).

**Csatolhatok hangot egy átmenethez, és ismételhetem azt?**

Igen. Hangot ágyazhatsz be az átmenethez, és a viselkedést beállíthatod olyan opciókkal, mint a hang mód és a hurok (pl. [setSound](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), valamint metaadatok, mint a [setSoundIsBuiltIn](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) és a [setSoundName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzam?**

Állítsa be a kívánt átmenettípust minden dia átmenetbeállításában; az átmenetek diánként vannak tárolva, ezért ugyanazt a típust az összes diára alkalmazva konzisztens eredményt kap.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Vizsgálja meg a dia [transition settings](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) beállításait, és olvassa ki a [transition type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) értékét; ez az érték pontosan megmutatja, melyik hatás van alkalmazva.