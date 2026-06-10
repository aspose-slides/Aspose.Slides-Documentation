---
title: Diaátmenetek kezelése prezentációkban Java használatával
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/java/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- haladó diaátmenet
- Morph átmenet
- átmenet típusa
- átmeneti hatás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan szabhatja testre a diaátmeneteket az Aspose.Slides for Java-ban, részletes, lépésről-lépésre útmutatóval a PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetőek a diaátmenetek prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan alkalmazhatók átmenet típusok a diákra, hogyan konfigurálható az átmenet viselkedése, például kattintásra vagy meghatározott idő után történő előrehaladás, az automatikus előrehaladás ellenőrzése és letiltása, a Morph átmenet és típusainak használata, valamint az átmeneti hatás beállításai. A példák bemutatják, hogyan töltsön be vagy hozzon létre egy prezentációt, módosítsa a kiválasztott diák átmeneti beállításait, és mentse az eredményt PPTX fájlként. A cikk továbbá válaszol gyakori kérdésekre az átmenet sebességéről, hangokról, ugyanannak az átmenetnek a több diára történő alkalmazásáról és arról, hogyan ellenőrizhető a dián jelenleg beállított átmenet.

## **Diaátmenet hozzáadása**
Egyszerű diaátmenet‑hatás létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
1. Alkalmazzon egy Diaátmenet típust a diára az Aspose.Slides for Java által kínált átmeneti hatások egyikéből a TransitionType felsoroló segítségével.  
1. Írja ki a módosított prezentáció fájlt.

```java
// A Presentation osztály példányosítása a forrás prezentáció betöltéséhez
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Kör típusú átmenet alkalmazása az 1. dián
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Comb típusú átmenet alkalmazása a 2. dián
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // A prezentáció mentése a lemezre
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Haladó diaátmenet hozzáadása**
Az előző szakaszban egyszerű átmenet‑hatást alkalmaztunk a diára. Most, hogy ez az egyszerű átmenet még jobb és irányítható legyen, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
1. Alkalmazzon egy Diaátmenet típust a diára az Aspose.Slides for Java által kínált átmeneti hatások egyikéből.  
1. Beállíthatja, hogy az átmenet kattintásra lépjen tovább, egy adott időszak után, vagy mindkettő.  
1. Ha a diaátmenet engedélyezve van a Kattintásra léptetésre, az átmenet csak akkor lép tovább, amikor valaki rákattint az egérre. Továbbá, ha az Idő után léptetés tulajdonság be van állítva, az átmenet automatikusan lép tovább a megadott idő elteltével.  
1. Írja ki a módosított prezentációt egy prezentációfájlként.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Kör típusú átmenet alkalmazása az 1. dián
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Átmeneti idő beállítása 3 másodpercre
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Comb típusú átmenet alkalmazása a 2. dián
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Átmeneti idő beállítása 5 másodpercre
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zoom típusú átmenet alkalmazása a 3. dián
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Átmeneti idő beállítása 7 másodpercre
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // A prezentáció mentése a lemezre
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph átmenet**
{{% alert color="primary" %}} 

Az Aspose.Slides for Java most támogatja a [Morph Transition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMorphTransition)-t. Ezek a PowerPoint 2019‑ben bevezetett új morph átmenetet képviselik.

{{% /alert %}} 

A Morph átmenet lehetővé teszi a sima mozgás animálását az egyik diáról a következőre. Ez a cikk bemutatja a koncepciót és a Morph átmenet használatát. A Morph átmenet hatékony használatához két diára van szükség, amelyeknek legalább egy közös objektumuk van. A legegyszerűbb módja a dia duplikálása, majd a második dián az objektum áthelyezése egy másik helyre.

Az alábbi kódrészlet megmutatja, hogyan adjon egy klónt a diáról szöveggel a prezentációhoz, és hogyan állítson be egy [morph type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TransitionType) átmenetet a második diára.

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
Új [TransitionMorphType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TransitionMorphType) felsoroló került hozzáadásra. Különböző Morph diaátmenet típusokat képvisel.

A TransitionMorphType felsoroló három taggal rendelkezik:

- ByObject: A Morph átmenet a formákat megoszthatatlan objektumokként kezeli.  
- ByWord: A Morph átmenet a szöveget szavakra bontva, ahol lehetséges, továbbítja.  
- ByChar: A Morph átmenet a szöveget karakterenként, ahol lehetséges, továbbítja.

Az alábbi kódrészlet megmutatja, hogyan állítsa be a morph átmenetet a diára és hogyan változtassa meg a morph típust:

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
Az Aspose.Slides for Java támogatja az átmeneti hatások beállítását, például feketéről, balról, jobbról stb. Az átmeneti hatás beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
- Szerezze meg a dia referenciáját.  
- Állítsa be az átmeneti hatást.  
- Írja ki a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi példa mutatja, hogyan állítottuk be az átmeneti hatásokat.

```java
// A Presentation osztály egy példányának létrehozása
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Effektus beállítása
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // A prezentáció mentése a lemezre
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Módosíthatom a diaátmenet lejátszási sebességét?**

Igen. Állítsa be az átmenet [speed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) értékét a [TransitionSpeed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionspeed/) beállítással (pl. lassú/közepes/gyors).

**Csatolhatok hangot egy átmenethez, és ismételhetem azt?**

Igen. Beágyazhatsz hangot az átmenethez, és a viselkedést szabályozhatod olyan beállításokkal, mint a hang mód és a loop (pl. [setSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), valamint metaadatok, például [setSoundIsBuiltIn](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) és [setSoundName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzam minden diára?**

Állítsa be a kívánt átmenet típust minden dia átmeneti beállításában; az átmenetek diánként tárolódnak, így ugyanazon típus alkalmazása az összes dián konzisztens eredményt ad.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Vizsgálja meg a dia [transition settings](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslide/#getSlideShowTransition--) beállításait, és olvassa ki a [transition type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setType-int-) értékét; ez pontosan megmutatja, melyik effektus van alkalmazva.