---
title: Prezentációs diák elérése Androidon
linktitle: Dia elérése
type: docs
weight: 20
url: /hu/androidjava/access-slide-in-presentation/
keywords:
- dia elérése
- dia index
- dia azonosító
- dia pozíció
- pozíció módosítása
- dia tulajdonságok
- dia száma
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan érheti el és kezelheti a diákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android segítségével. Növelje a hatékonyságot Java kódpéldákkal."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet elérni és kezelni a diákot egy prezentációban az Aspose.Slides használatával. Bemutatja, hogyan lehet lekérni a diákat a nulla alapú indexük alapján a diák gyűjteményéből, valamint hogyan lehet egy diát elérni egyedi azonosítójával a `getSlideById` metódus segítségével.

Megtanulja, hogyan lehet megváltoztatni egy dia pozícióját a `setSlideNumber` metódus használatával, illetve hogyan lehet meghatározni a prezentáció első dia számát a `setFirstSlideNumber` metódus segítségével. A példák bemutatják egy prezentáció betöltését, a dia referenciák lekérését, a dia sorrend vagy számozás frissítését, valamint a módosított prezentáció mentését.

## **Dia elérése index szerint**

A prezentáció minden diája numerikusan van elrendezve a dia pozíciója szerint, 0‑tól kezdve. Az első dia a 0‑s indexen érhető el; a második dia az 1‑es indexen; stb.

A Presentation osztály, amely egy prezentációs fájlt képvisel, az összes diát egy [ISlideCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidecollection/) (azaz [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/) objektumok gyűjteménye) formájában biztosítja. Ez a Java kód megmutatja, hogyan lehet egy diát elérni az indexe alapján:

```java
// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("demo.pptx");
try {
    // Elér egy diát a dia indexe használatával
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Dia elérése azonosító szerint**

Minden diához egy egyedi azonosító tartozik. A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály által kiadott [getSlideById](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlideById-long-) metódussal célozhatja meg ezt az azonosítót. Ez a Java kód megmutatja, hogyan adjon meg egy érvényes diaazonosítót, és hogyan érje el azt a [getSlideById](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlideById-long-) metódussal:

```java
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("demo.pptx");
try {
    // Lekér egy diaazonosítót
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Eléri a diát az azonosítója segítségével
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Dia pozíciójának módosítása**

Az Aspose.Slides lehetővé teszi egy dia pozíciójának módosítását. Például megadhatja, hogy az első dia a második diává váljon.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze meg a módosítandó dia referenciáját az indexe alapján.
1. Állítson be egy új pozíciót a diához a [setSlideNumber](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) tulajdonság segítségével.
1. Mentse a módosított prezentációt.

Ez a Java kód egy olyan műveletet mutat be, amelyben az 1‑es pozícióban lévő diát a 2‑es pozícióba mozgatja:

```java
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Lekéri a diát, amelynek a pozíciója módosulni fog
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Beállítja a dia új pozícióját
    sld.setSlideNumber(2);
    
    // Elmenti a módosított prezentációt
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Az első dia a másodikká, a második dia az elsővé vált. Amikor egy dia pozícióját megváltoztatja, a többi dia automatikusan igazodik.

## **Dia számának beállítása**

A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály által kiadott [setFirstSlideNumber](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) tulajdonság segítségével megadhat egy új számot az első diához egy prezentációban. Ez a művelet a többi dia számát újraszámolja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia számát.
1. Állítsa be a dia számát.
1. Mentse a módosított prezentációt.

Ez a Java kód egy olyan műveletet mutat be, ahol az első dia száma 10‑re van állítva:

```java
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Lekéri a dia számát
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Beállítja a dia számát
    pres.setFirstSlideNumber(10);
	
    // Elmenti a módosított prezentációt
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Ha azt szeretné, hogy az első diát kihagyja, a számozást a második diától kezdheti (és elrejtheti az első dia számozását) a következő módon:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Beállítja az első prezentációs dia számát
    presentation.setFirstSlideNumber(0);

    // Megjeleníti a dia számokat az összes dián
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Elrejti az első dia számát
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Elmenti a módosított prezentációt
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **GYIK**

**A felhasználó által látott dia száma megegyezik a gyűjtemény nulla alapú indexével?**

A dián megjelenő szám tetszőleges értékről indulhat (például 10), és nem kell, hogy megegyezzen az indexszel; a kapcsolat a prezentáció **first slide number** beállításával szabályozható.

**A rejtett diák befolyásolják az indexelést?**

Igen. A rejtett dia továbbra is része a gyűjteménynek, és számít az indexelésben; a „rejtett” a megjelenítésre vonatkozik, nem a gyűjteményben elfoglalt helyére.

**Módosul-e egy dia indexe, amikor más diák kerülnek hozzáadásra vagy eltávolításra?**

Igen. Az indexek mindig a jelenlegi sorrendet tükrözik, és beszúrás, törlés vagy áthelyezés esetén újraszámításra kerülnek.