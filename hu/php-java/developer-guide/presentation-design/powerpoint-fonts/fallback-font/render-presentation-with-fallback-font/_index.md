---
title: Prezentációk megjelenítése helyettesítő betűtípusokkal PHP-ben
linktitle: Prezentációk megjelenítése
type: docs
weight: 30
url: /hu/php-java/render-presentation-with-fallback-font/
keywords:
- helyettesítő betűtípus
- PowerPoint megjelenítése
- prezentáció megjelenítése
- dia megjelenítése
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Prezentációk megjelenítése helyettesítő betűtípusokkal az Aspose.Slides PHP-hez Java útján - biztosítsa a szöveg konzisztenciáját PPT, PPTX és ODP formátumokban lépésről-lépésre kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy prezentációkat jelenítsen meg helyettesítő betűtípus szabályok használatával. Ez a cikk bemutatja, hogyan hozhat létre helyettesítő betűtípus szabálykészletet, módosíthatja annak szabályait betűtípusok eltávolításával vagy hozzáadásával, és hogyan rendeli hozzá a készletet a `FontsManager::setFontFallBackRulesCollection` metódushoz.

Miután a helyettesítő betűtípus szabálykészletet a bemutató `FontsManager`-éhez rendelték, a szabályok alkalmazásra kerülnek olyan műveletek során, mint a mentés, a megjelenítés és a bemutató konvertálása. A példában bemutatjuk, hogyan használhatók a konfigurált szabályok egy dia bélyegképének megjelenítésekor és PNG képként való mentésekor.

## **Dia megjelenítése helyettesítő betűtípus szabályok használatával**

A következő példa ezeket a lépéseket tartalmazza:

1. Létrehozzuk a [helyettesítő betűtípus szabálykészlet létrehozása](/slides/hu/php-java/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) egy helyettesítő betűtípus szabályt, és [addFallBackFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) egy másik szabályhoz.
1. Állítsuk be a szabálykészletet a [getFontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) metódusra.
1. A [Presentation.save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation#save-java.lang.String-int-) metódussal menthetjük a prezentációt ugyanabba a formátumba, vagy egy másikba. Miután a helyettesítő betűtípus szabálykészletet beállítottuk a [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontsManager)-ben, ezek a szabályok minden prezentáción végzett műveletnél alkalmazásra kerülnek: mentés, megjelenítés, konvertálás stb.

```php
  # Új szabálykészlet példány létrehozása
  $rulesList = new FontFallBackRulesCollection();
  # több szabály létrehozása
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Megpróbáljuk eltávolítani a "Tahoma" helyettesítő betűtípust a betöltött szabályokból
    $fallBackRule->remove("Tahoma");
    # És a szabályok frissítése a megadott tartományra
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Ezenkívül eltávolíthatunk meglévő szabályokat a listáról
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Előkészített szabálykészlet hozzárendelése használatra
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Bélyegkép renderelése az inicializált szabálykészlet használatával és JPEG formátumban mentése
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Kép mentése lemezre JPEG formátumban
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Olvasson tovább arról, hogyan [Hogyan konvertáljon PPT és PPTX JPG-re PHP-ban](/slides/hu/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}