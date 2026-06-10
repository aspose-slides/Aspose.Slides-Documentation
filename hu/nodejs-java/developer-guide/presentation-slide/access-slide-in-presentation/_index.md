---
title: Prezentációs diák elérése JavaScript-ben
linktitle: Dia elérése
type: docs
weight: 20
url: /hu/nodejs-java/access-slide-in-presentation/
keywords:
- dia elérése
- dia index
- dia azonosító
- dia pozíció
- pozíció módosítása
- dia tulajdonságai
- dia száma
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet elérni és kezelni a diákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js segítségével. Növelje a hatékonyságot kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet elérni és kezelni a diákat egy prezentációban az Aspose.Slides segítségével. Megmutatja, hogyan lehet lekérni a diákat a nulla alapú indexük szerint a diák gyűjteményéből, illetve hogyan lehet egy diát elérni az egyedi azonosítója segítségével a `getSlideById` metódussal.

Megtanulja továbbá, hogyan lehet megváltoztatni egy dia pozícióját a `setSlideNumber` metódus használatával, illetve hogyan lehet definiálni a prezentáció kezdő dia számát a `setFirstSlideNumber` metódussal. A példák bemutatják a prezentáció betöltését, a diahivatkozások lekérését, a dia sorrend vagy számozás frissítését, valamint a módosított prezentáció mentését.

## **Dia elérése index szerint**

A prezentáció összes diája numerikusan van elrendezve a dia pozíciója alapján, 0-tól kezdve. Az első dia a 0 indexen érhető el; a második dia az 1 indexen; stb.

A Presentation osztály, amely egy prezentációs fájlt reprezentál, az összes diát egy [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/) gyűjteményként (a [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) objektumok gyűjteménye) teszi elérhetővé. Ez a JavaScript kód megmutatja, hogyan lehet egy diához az indexe alapján hozzáférni:

```javascript
// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Elér egy diát a dia indexe alapján
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Dia elérése ID szerint**

Minden diához egy egyedi ID tartozik a prezentációban. A [getSlideById](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSlideById-long-) metódust (amely a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályban érhető el) használhatja az ID eléréséhez. Ez a JavaScript kód megmutatja, hogyan adjon meg egy érvényes dia ID-t, és hogyan érje el azt a [getSlideById](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSlideById-long-) metódussal:

```javascript
// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Lekéri egy dia azonosítóját
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Eléri a diát az azonosítója alapján
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Dia pozíciójának módosítása**

Az Aspose.Slides lehetővé teszi egy dia pozíciójának megváltoztatását. Például megadhatja, hogy az első dia a második diá legyen.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezze be a dia hivatkozását (amelynek a pozícióját változtatni kívánja) az indexe alapján
3. Állítson be egy új pozíciót a diának a [setSlideNumber](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#setSlideNumber-int-) tulajdonságon keresztül.
4. Mentse el a módosított prezentációt.

Ez a JavaScript kód egy olyan műveletet mutat be, amelyben az 1. pozícióban lévő dia a 2. pozícióba kerül:

```javascript
// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Lekéri azt a diát, amelynek a pozíciója módosulni fog
    var sld = pres.getSlides().get_Item(0);
    // Beállítja a dia új pozícióját
    sld.setSlideNumber(2);
    // Elmenti a módosított prezentációt
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Az első dia a másodikká vált; a második dia az elsővé. Amikor egy dia pozícióját megváltoztatja, a többi dia automatikusan igazodik.

## **Dia számának beállítása**

A [setFirstSlideNumber](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) tulajdonság (amely a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályban érhető el) használatával megadhat egy új számot a prezentáció első diájának. Ez a művelet az összes többi dia számát újraszámolja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg a dia számát.
3. Állítsa be a dia számát.
4. Mentse el a módosított prezentációt.

Ez a JavaScript kód egy olyan műveletet mutat be, ahol az első dia száma 10-re van beállítva:

```javascript
// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Lekéri a dia számát
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Beállítja a dia számát
    pres.setFirstSlideNumber(10);
    // Elmenti a módosított prezentációt
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Ha szeretné kihagyni az első diát, a számozást a második diával is elkezdheti (és elrejtheti az első dia számozását) így:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Beállítja az első prezentációs dia számát
    presentation.setFirstSlideNumber(0);
    // Megjeleníti a dia számát minden dián
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Elrejti az első dia számát
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Elmenti a módosított prezentációt
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **GYIK**

**A felhasználó által látott dia száma egyezik a gyűjtemény nulla alapú indexével?**

A dián megjelenő szám tetszőleges értékkel (például 10) indulhat, és nem kell, hogy megegyezzen az indexszel; a kapcsolatot a prezentáció [first slide number](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) beállítása határozza meg.

**A rejtett diák befolyásolják az indexelést?**

Igen. A rejtett dia a gyűjteményben marad, és az indexelés során is számít; a "rejtett" a megjelenést jelenti, nem a gyűjteményben elfoglalt helyét.

**Megváltozik egy dia indexe, amikor más diák kerülnek hozzáadásra vagy eltávolításra?**

Igen. Az indexek mindig a jelenlegi sorrendet tükrözik a diákban, és beszúrás, törlés vagy áthelyezés során újraszámolásra kerülnek.