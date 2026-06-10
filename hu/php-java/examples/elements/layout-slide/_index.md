---
title: Elrendezési dia
type: docs
weight: 20
url: /hu/php-java/examples/elements/layout-slide/
keywords:
- elrendezési dia
- elrendezési dia hozzáadása
- elrendezési dia elérése
- elrendezési dia eltávolítása
- használaton kívüli elrendezési dia
- elrendezési dia klónozása
- kódpéldák
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Használja a PHP-t az elrendezési diák kezelésére az Aspose.Slides segítségével: létrehozás, alkalmazás, klónozás, átnevezés és helyőrzők valamint sablonok testreszabása a PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet **Layout Slides** használni az Aspose.Slides for PHP via Java esetén. Egy elrendezési dia meghatározza a normál diák által örökölt tervezést és formázást. Hozzáadhat, elérhet, klónozhat és eltávolíthat elrendezési diákat, valamint tisztíthatja a nem használtakat a bemutató méretének csökkentése érdekében.

## **Elrendezési dia hozzáadása**

Létrehozhat egy egyéni elrendezési diát az újrahasználható formázás meghatározásához. Például hozzáadhat egy szövegdobozt, amely minden, ezt az elrendezést használó dián megjelenik.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Hozzon létre egy elrendezési diát üres elrendezés típussal és egy egyéni névvel.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Elrendezési diák sablonként működnek az egyes diákhoz. A közös elemeket egyszer definiálhatja, és sok dián újra felhasználhatja.

> 💡 **Tip 2:** Amikor alakzatokat vagy szöveget ad hozzá egy elrendezési diához, a rá épülő összes dia automatikusan megjeleníti ezt a megosztott tartalmat.  
> Az alábbi képernyőkép két diát mutat, amelyek mindegyike ugyanabból az elrendezési diából örököl egy szövegdobozt.

![Elrendezési tartalmat öröklő diák](layout-slide-result.png)


## **Elrendezési dia elérése**

Az elrendezési diák elérhetők index szerint vagy elrendezés típusa alapján (például `Blank`, `Title`, `SectionHeader` stb.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Elérés index alapján.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Elérés elrendezés típusa alapján.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Elrendezési dia eltávolítása**

Eltávolíthat egy adott elrendezési diát, ha már nincs rá szükség.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Szerezzen be egy elrendezési diát típus alapján és távolítsa el.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Nem használt elrendezési diák eltávolítása**

A bemutató méretének csökkentése érdekében érdemes eltávolítani azokat az elrendezési diákat, amelyeket egyetlen normál dia sem használ.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Automatikusan eltávolítja az összes olyan elrendezési diát, amelyet egyetlen dia sem hivatkozik.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Elrendezési dia klónozása**

Megkettőzheti egy elrendezési diát az `addClone` metódus használatával.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Szerezzen be egy meglévő elrendezési diát típus alapján.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Klónozza az elrendezési diát a gyűjtemény végére.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Összegzés:** Az elrendezési diák hatékony eszközök a diák közötti konzisztens formázás kezelésére. Az Aspose.Slides teljes irányítást biztosít az elrendezési diák létrehozása, kezelése és optimalizálása felett.