---
title: Alapértelmezett bemutató betűtípusok megadása PHP-ben
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/php-java/default-font/
keywords:
- alapértelmezett betűtípus
- rendszeres betűtípus
- normál betűtípus
- ázsiai betűtípus
- PDF export
- XPS export
- kép export
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Az Aspose.Slides for PHP via Java alapértelmezett betűtípusaának beállítása a megfelelő PowerPoint (PPT, PPTX) és OpenDocument (ODP) konverzió biztosításához PDF, XPS és képek formátumba."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy megadja az alapértelmezett betűtípusokat, amelyeket a bemutató renderelésekor használnak. Ez hasznos dia előnézetek létrehozásakor vagy a bemutató PDF és XPS formátumokba exportálásakor. Az alapértelmezett betűtípusok a `LoadOptions` segítségével konfigurálhatók, mielőtt a bemutató betöltődik.

`setDefaultRegularFont` metódus meghatározza az alapértelmezett betűtípust a normál szöveghez, míg a `setDefaultAsianFont` meghatározza az alapértelmezett betűtípust az ázsiai szöveghez. Miután ezek a beállítások meg vannak adva, a bemutató betölthető és renderelhető a megadott betűtípusokkal.

## **Alapértelmezett betűtípusok használata egy bemutató rendereléséhez**
Az Aspose.Slides lehetővé teszi, hogy beállítsa az alapértelmezett betűtípust a bemutató PDF, XPS vagy előnézeti képekre való rendereléséhez. Ez a cikk bemutatja, hogyan definiálja a DefaultRegularFont és a DefaultAsianFont értékeit alapértelmezett betűtípusokként. Kérjük, kövesse az alábbi lépéseket a betűtípusok külső könyvtárakból való betöltéséhez az Aspose.Slides for PHP via Java API használatával:

1. Hozzon létre egy példányt a [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a kívánt betűtípusra. Az alábbi példában a Wingdings-et használtam.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a kívánt betűtípusra. A következő példában a Wingdings-et használtam.
1. Töltse be a bemutatót a Presentation osztály és a betöltési beállítások segítségével.
1. Ezután generálja a dia előnézetet, a PDF-et és az XPS-et a eredmények ellenőrzéséhez.

A fenti megvalósítás a következőképpen néz ki.

```php
  # Használja a betöltési beállításokat az alapértelmezett normál és ázsiai betűtípusok meghatározásához
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Töltse be a bemutatót
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Készítsen dia előnézetet
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # mentse a képet a lemezen.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Készítsen PDF-et
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Készítsen XPS-et
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**A DefaultRegularFont és a DefaultAsianFont pontosan mire hatnak – csak az exportálásra, vagy a előnézetekre, PDF-re, XPS-re, HTML-re és SVG-re is?**

Részt vesznek a renderelési csővezetékben minden támogatott kimenetnél. Ez magában foglalja a dia előnézeteket, a [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), a [XPS](/slides/hu/php-java/convert-powerpoint-to-xps/), a [raszteres képek](/slides/hu/php-java/convert-powerpoint-to-png/), a [HTML](/slides/hu/php-java/convert-powerpoint-to-html/), és a [SVG](/slides/hu/php-java/render-a-slide-as-an-svg-image/) formátumokat, mivel az Aspose.Slides ugyanazt a elrendezési és glif feloldási logikát használja ezeken a célokon.

**Az alapértelmezett betűtípusok alkalmazásra kerülnek, ha egyszerűen csak beolvassuk és elmentjük a PPTX-et, anélkül hogy renderelnénk?**

Nem. Az alapértelmezett betűtípusok csak akkor számítanak, ha a szöveget mérni és rajzolni kell. Egy egyszerű nyitás‑mentés nem változtatja meg a tárolt betűtípussorozatokat vagy a fájl felépítését. Az alapértelmezett betűtípusok azokban a műveletekben lépnek működésbe, amelyek renderelik vagy újrarendezik a szöveget.

**Ha saját betűtípus mappákat adok hozzá, vagy memóriából biztosítok betűtípusokat, figyelembe veszik ezeket az alapértelmezett betűtípusok kiválasztásakor?**

Igen. A [Custom font sources](/slides/hu/php-java/custom-font/) bővíti a rendelkezésre álló családok és glifek katalógusát, amelyet a motor használhat. Az alapértelmezett betűtípusok és minden [fallback rules](/slides/hu/php-java/fallback-font/) először ezekhez a forrásokhoz fognak visszanyúlni, ami megbízhatóbb lefedettséget biztosít a szervereken és konténerekben.

**Az alapértelmezett betűtípusok befolyásolják a szövegmérőket (kerning, advance), és ezáltal a sortöréseket és a sortördelést?**

Igen. A betűtípus megváltoztatása módosítja a glifmetrikát, és befolyásolhatja a sorok tördelését, a szövegcsomagolást és a lapozást a renderelés során. A stabil elrendezés érdekében [embed the original fonts](/slides/hu/php-java/embedded-font/) vagy válasszon metrikailag kompatibilis alapértelmezett és tartalék családokat.

**Van értelme alapértelmezett betűtípusokat beállítani, ha a bemutatóban használt összes betűtípus be van ágyazva?**

Gyakran nincs rá szükség, mivel a [embedded fonts](/slides/hu/php-java/embedded-font/) már biztosítja a következetes megjelenést. Az alapértelmezett betűtípusok továbbra is hasznosak védőhálóként az olyan karakterek esetén, amelyeket a beágyazott részhalmaz nem fed le, vagy amikor egy fájl vegyesen tartalmaz beágyazott és nem beágyazott szöveget.