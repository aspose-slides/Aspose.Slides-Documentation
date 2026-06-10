---
title: Diaátmenetek kezelése prezentációkban JavaScript segítségével
linktitle: Diaátmenet
type: docs
weight: 80
url: /hu/nodejs-java/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet alkalmazása
- speciális diaátmenet
- Morph átmenet
- átmenettípus
- átmeneti effektus
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Testreszabhatja a diaátmeneteket JavaScript-ben az Aspose.Slides for Node.js via Java segítségével, lépésről-lépésre útmutatóval PowerPoint és OpenDocument prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a diák átmenetei prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan lehet alkalmazni az átmenettípusokat a diákra, beállítani az átmenet viselkedését, például az előrehaladást kattintásra vagy egy megadott idő után, ellenőrizni és letiltani az automatikus előrehaladást, használni a Morph átmenetet és annak típusait, valamint beállítani az átmenet effektus opciókat. A példák demonstrálják, hogyan tölthető be vagy hozható létre egy prezentáció, hogyan módosíthatók a kiválasztott diák átmenet beállításai, és hogyan menthető el az eredmény PPTX fájlként. A cikk válaszol a gyakori kérdésekre az átmenet sebességéről, hangjairól, a ugyanazon átmenet több diára való alkalmazásáról, valamint arra, hogy hogyan ellenőrizhető az aktuálisan egy dián beállított átmenet.

## **Diaátmenet hozzáadása**

Egyszerű diaátmenet effektus létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
2. Alkalmazzon egy diaátmenet típust a diára az Aspose.Slides for Node.js via Java által kínált átmeneti hatások közül a TransitionType felsorolt segítségével.
3. Írja ki a módosított prezentáció fájlt.

```javascript
// Példányosítsa a Presentation osztályt a forrás prezentáció fájl betöltéséhez
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Kör típusú átmenet alkalmazása az 1. dián
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Fésű típusú átmenet alkalmazása a 2. dián
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Mentse a prezentációt lemezre
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Speciális diaátmenet hozzáadása**

Az előző szakaszban csak egy egyszerű átmenet effektust alkalmaztunk a diára. Most, hogy ezt az egyszerű átmenetet még jobbá és irányíthatóbbá tegyük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
2. Alkalmazzon egy diaátmenet típust a diára az Aspose.Slides for Node.js via Java által kínált átmeneti hatások közül.
3. Beállíthatja az átmenetet, hogy kattintásra, egy meghatározott idő után vagy mindkettőre haladjon.
4. Ha a diaátmenet a kattintásra való előrehaladásra van beállítva, az átmenet csak akkor halad tovább, amikor valaki rákattint az egérre. Továbbá, ha az Advanc után idő (Advance After Time) tulajdonság be van állítva, az átmenet automatikusan a megadott idő elteltével továbbhalad.
5. Írja ki a módosított prezentációt egy prezentáció fájlként.

```javascript
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Kör típusú átmenet alkalmazása az 1. dián
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Állítsa be a 3 másodperces átmeneti időt
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Fésű típusú átmenet alkalmazása a 2. dián
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Állítsa be az 5 másodperces átmeneti időt
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Nagyítás típusú átmenet alkalmazása a 3. dián
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Állítsa be a 7 másodperces átmeneti időt
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Mentse a prezentációt lemezre
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph átmenet**

{{% alert color="primary" %}} 

Az Aspose.Slides for Node.js via Java most már támogatja a [Morph átmenetet](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MorphTransition). Ez egy új morph átmenetet jelent, amelyet a PowerPoint 2019 bevezetett.

{{% /alert %}} 

A Morph átmenet lehetővé teszi, hogy sima mozgást animáljon az egyik dia és a következő között. Ez a cikk leírja a koncepciót és a Morph átmenet használatát. A Morph átmenet hatékony használatához két diára van szükség, amelyek legalább egy közös objektummal rendelkeznek. A legegyszerűbb módja, ha duplikálja a diát, majd a második dián a objektumot egy másik helyre helyezi.

Az alábbi kódrészlet megmutatja, hogyan adhat egy diaklónt szöveggel a prezentációhoz, és hogyan állíthat be egy [morph típusú](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TransitionType) átmenetet a második diára.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph átmenet típusok**

Új [TransitionMorphType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TransitionMorphType) felsorolt került hozzáadásra. Különböző Morph diaátmenet típusokat képvisel.

A TransitionMorphType felsorolt három elemet tartalmaz:

- ByObject: A morph átmenet a formákat elválaszthatatlan objektumokként veszi figyelembe.
- ByWord: A morph átmenet a szöveget szavakra bontva továbbítja, ahol lehetséges.
- ByChar: A morph átmenet a szöveget karakterenként továbbítja, ahol lehetséges.

Az alábbi kódrészlet megmutatja, hogyan állítható be a morph átmenet egy diára, és hogyan változtatható a morph típus:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Átmenet hatások beállítása**

Az Aspose.Slides for Node.js via Java támogatja az átmenet hatások beállítását, például feketéből, balról, jobbról stb. Az átmenet hatás beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
- Szerezze meg a dia referenciáját.
- Állítsa be az átmenet hatást.
- Írja ki a prezentációt egy [PPTX ](https://docs.fileformat.com/presentation/pptx/) fájlként.

Az alábbi példában beállítottuk az átmenet hatásokat.

```javascript
// Presentation osztály példányosítása
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Effektus beállítása
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // A prezentáció mentése lemezre
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le tudom-e szabályozni egy diaátmenet lejátszási sebességét?**

Igen. Állítsa be az átmenet [sebességét](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/setspeed/) a [TransitionSpeed](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/transitionspeed/) beállítással (pl. lassú/közepes/gyors).

**Csatolhatok hangot egy átmenethez, és beállíthatom a loopolást?**

Igen. Beágyazhatsz egy hangot az átmenethez, és a viselkedést szabályozhatod beállításokkal, például hangmóddal és loopolással (pl. [setSound](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), valamint metaadatok, mint a [setSoundIsBuiltIn](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) és a [setSoundName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Mi a leggyorsabb módja annak, hogy ugyanazt az átmenetet minden diára alkalmazzuk?**

Állítsa be a kívánt átmenettípust minden dia átmenetbeállításánál; az átmenetek diánként tárolódnak, így ugyanazt a típust minden diára alkalmazva egységes eredményt kap.

**Hogyan ellenőrizhetem, hogy melyik átmenet van jelenleg beállítva egy dián?**

Vizsgálja meg a dia [átmenet beállításait](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition), és olvassa le a [átmenettípust](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideshowtransition/gettype/); ez az érték pontosan megmutatja, melyik effektus van alkalmazva.