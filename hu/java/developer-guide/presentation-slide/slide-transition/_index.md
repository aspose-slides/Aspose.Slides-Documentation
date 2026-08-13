---
title: Diaváltások kezelése prezentációkban Java használatával
linktitle: Diaváltás
type: docs
weight: 80
url: /hu/java/slide-transition/
keywords:
- diaváltás
- diaváltás hozzáadása
- diaváltás alkalmazása
- fejlett diaváltás
- morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan testreszabhatja a diaváltásokat az Aspose.Slides for Java-ban, lépésről lépésre útmutatóval a PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan kezelhetők a diaváltások a prezentációkban az Aspose.Slides használatával. Bemutatja, hogyan alkalmazhatók átmenettípusok a diákra, hogyan konfigurálható az átmenet viselkedése, például a kattintásra vagy egy meghatározott idő után történő előrehaladás, hogyan ellenőrizhető és letiltható az automatikus előrehaladás, a Morph átmenet és annak típusainak használata, valamint az átmeneti effektusok beállítása. A példák bemutatják, hogyan tölthető be vagy hozható létre egy prezentáció, hogyan módosíthatók a kiválasztott diák átmenetbeállításai, és hogyan menthető az eredmény PPTX fájlként. A cikk válaszol a gyakori kérdésekre is, mint az átmenet sebessége, az átmeneti hangok, ugyanaznak az átmenetnek a több diára való alkalmazása, és hogyan ellenőrizhető a dián jelenleg beállított átmenet.

## **Diaváltás hozzáadása**
Egyszerű diaváltási effektus létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Alkalmazzon egy diaváltás típust a diára az Aspose.Slides for Java által a TransitionType enumon keresztül kínált átmeneti hatások egyikéből.  
3. Írja ki a módosított prezentációfájlt.

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt a forrásprezentáció betöltéséhez
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Alkalmazza a kör típusú átmenetet az 1. dián
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Alkalmazza a füttön típusú átmenetet a 2. dián
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Mentse a prezentációt a lemezre
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fejlett diaváltás hozzáadása**
Az előző részben csak egy egyszerű átmeneti effektust alkalmaztunk a diára. Most, hogy ezt a egyszerű átmenetet még jobbá és szabályozhatóbbá tegyük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Alkalmazzon egy diaváltás típust a diára az Aspose.Slides for Java által kínált átmeneti hatások egyikéből.  
3. Beállíthatja továbbá, hogy az átmenet kattintásra előrehaladjon, egy meghatározott idő elteltével vagy mindkettő.  
4. Ha a diaváltás az „Advance On Click” (kattintásra előrehaladás) beállítással van engedélyezve, az átmenet csak akkor halad tovább, ha valaki rákattint az egérre. Ha az „Advance After Time” (idő után előrehaladás) tulajdonság be van állítva, az átmenet automatikusan a megadott idő letelte után továbbhalad.  
5. Írja ki a módosított prezentációt prezentációfájlként.

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Alkalmazza a kör típusú átmenetet az 1. dián
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Állítsa be az átmenet időtartamát 3 másodpercre
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Alkalmazza a füttön típusú átmenetet a 2. dián
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Állítsa be az átmenet időtartamát 5 másodpercre
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Alkalmazza a zoom típusú átmenetet a 3. dián
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Állítsa be az átmenet időtartamát 7 másodpercre
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Mentse a prezentációt a lemezre
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph átmenet**
{{% alert color="info" %}} 

Aspose.Slides for Java most már támogatja a [Morph Transition](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMorphTransition)‑t. Ezek a PowerPoint 2019‑ben bevezetett új morph átmenetek.

{{% /alert %}} 

A Morph átmenet lehetővé teszi a sima mozgás animálását egy dia és a következő között. Ez a cikk leírja a koncepciót és a Morph átmenet használatát. A Morph átmenet hatékony használatához két diára van szükség, amelyek legalább egy közös objektummal rendelkeznek. A legegyszerűbb módja ennek, ha duplikálja a diát, majd a második dián áthelyezi az objektumot egy másik helyre.

Az alábbi kódrészlet bemutatja, hogyan adhat hozzá egy klónton a szöveggel ellátott diát a prezentációhoz, és állíthat be egy [morph type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TransitionType) átmenetet a második diára.

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
Új [TransitionMorphType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TransitionMorphType) enum lett hozzáadva. Különböző Morph diaváltás típusokat képvisel.

A TransitionMorphType enum három taggal rendelkezik:

- ByObject: A Morph átmenet úgy lesz végrehajtva, hogy a alakzatokat oszthatatlan objektumokként veszi figyelembe.  
- ByWord: A Morph átmenet a szavakra bontott szöveg átadásával történik, ahol lehetséges.  
- ByChar: A Morph átmenet a karakterekre bontott szöveg átadásával történik, ahol lehetséges.

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

## **Átmeneti effektusok beállítása**
Az Aspose.Slides for Java támogatja az átmeneti effektusok beállítását, például „from black”, „from left”, „from right” stb. Az átmeneti effektus beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
- Szerezze meg a dia hivatkozását.  
- Állítsa be az átmeneti effektust.  
- Írja ki a prezentációt egy [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi példában beállítottuk az átmeneti effektusokat.

```java
import com.aspose.slides.*;

// Példányosít egy Presentation osztályt
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Állítsa be a hatást
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Mentse a prezentációt a lemezre
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GyIK**

### Kezelhetem a diaváltás lejátszási sebességét?

Igen. Az átmenet [speed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) beállítását a [TransitionSpeed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/transitionspeed/) használatával állíthatja be (például slow/medium/fast).

### Csatolhatok hangot egy átmenethez, és lehetővé tehetem a hurkolást?

Igen. Beágyazhat egy hangot az átmenethez, és a viselkedést hangmód és hurkolás beállításokkal szabályozhatja (például [setSound](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), valamint metaadatok, mint a [setSoundIsBuiltIn](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) és a [setSoundName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet alkalmazzuk minden diára?

Állítsa be a kívánt átmenettípust minden dia átmenetbeállításában; az átmenetek diánként tárolódnak, így az azonos típus alkalmazása az összes dián egységes eredményt ad.

### Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?

Vizsgálja meg a dia [transition settings](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslide/#getSlideShowTransition--) és olvassa ki a [transition type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideshowtransition/#setType-int-) értékét; ez pontosan megmondja, melyik effektus van alkalmazva.