---
title: PHP-ban a prezentációhelyettesítők kezelése
linktitle: Helyettesítők kezelése
type: docs
weight: 10
url: /hu/php-java/manage-placeholder/
keywords:
- helyettesítő
- szöveghelyettesítő
- képhelyettesítő
- diagramhelyettesítő
- utasító szöveg
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Könnyedén kezelje a helyettesítőket az Aspose.Slides for PHP via Java-ban: cserélje a szöveget, testreszabja az útmutatókat és állítsa be a képek átlátszóságát PowerPoint és OpenDocument formátumokban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan kezelje a bemutatóhelyettesítőket. Ez a cikk bemutatja, hogyan találhatók meg a helyettesítők a diákon, hogyan módosítható a szövegük, hogyan állítható be egyéni útmutató szöveg a helyettesítő elrendezésekhez, és hogyan állítható be egy kép átlátszósága, amely helyettesítő háttérként szolgál. Emellett tartalmaz egy rövid GYIK-ot, amely tisztázza az alapterületi helyettesítők és a helyi alakzatok közötti különbséget, ismerteti, hogyan alkalmazhatók a helyettesítő módosítások elrendezéseken vagy mesteroldalakon keresztül, és hivatkozik a fejléc és lábléc helyettesítőinek kezelésére.

## **Szöveg módosítása egy helyettesítőben**
A [Aspose.Slides for PHP via Java](/slides/hu/php-java/) használatával megtalálhatja és módosíthatja a helyettesítőket a prezentációk diáin. Az Aspose.Slides lehetővé teszi, hogy változtatásokat végezzen a helyettesítő szövegén.

**Előfeltétel**: Szüksége van egy olyan prezentációra, amely tartalmaz helyettesítőt. Ilyen prezentációt létrehozhat a standard Microsoft PowerPoint alkalmazásban.

Így használhatja az Aspose.Slides-t a helyettesítő szövegének cseréjére a prezentációban:

1. Példányosítsa a [`Presentation`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályt, és adja át a prezentációt argumentumként.  
2. Szerezzen be egy diára hivatkozást az indexén keresztül.  
3. Iterálja végig az alakzatokat a helyettesítő megtalálásához.  
4. A helyettesítő alakzatot castolja egy [`AutoShape`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/AutoShape) típusra, és módosítsa a szöveget a [`AutoShape`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/AutoShape)hez tartozó [`TextFrame`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/TextFrame) használatával.  
5. Mentse a módosított prezentációt.

```php
  # Az Presentation osztály példányosítása
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Az első dia elérése
    $sld = $pres->getSlides()->get_Item(0);
    # A alakzatokon iterál a helyettesítő megtalálásához
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # A helyettesítő szövegének módosítása
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # A prezentáció mentése lemezre
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Útmutató szöveg beállítása egy helyettesítőben**
A standard és előre elkészített elrendezések helyettesítő útmutató szövegeket tartalmaznak, például ***Kattintson a cím hozzáadásához*** vagy ***Kattintson az alkategória hozzáadásához***. Az Aspose.Slides használatával beillesztheti a kívánt útmutató szövegeket a helyettesítő elrendezésekbe.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # A dia bejárása
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # A PowerPoint a "Click to add title" szöveget jeleníti meg
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Alfelirat hozzáadása
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Helyettesítő kép átlátszóságának beállítása**

Az Aspose.Slides lehetővé teszi a háttérkép átlátszóságának beállítását egy szöveghelyettesítőben. A kép átlátszóságának módosításával ebben a keretben kiemelheti a szöveget vagy a képet (a szöveg és a kép színeitől függően).

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Mi az alapterületi helyettesítő, és miben különbözik egy helyi alakzattól egy dián?**  
Az alapterületi helyettesítő az a kiindulási alakzat egy elrendezésen vagy mesteren, amelyből a dia alakzata örökli a típust, pozíciót és egyes formázásokat. A helyi alakzat független; ha nincs alapterületi helyettesítő, az öröklődés nem lép életbe.

**Hogyan frissíthetek minden címet vagy feliratot egy prezentációban anélkül, hogy minden diához iterálnék?**  
Szerkessze a megfelelő helyettesítőt az elrendezésen vagy a mesteren. A azok alapján készült diák automatikusan öröklik a módosítást.

**Hogyan szabályozhatom a standard fejléc/lábléc helyettesítőket — dátum és idő, dia szám, valamint lábléc szöveg?**  
Használja a HeaderFooter kezelőket a megfelelő hatókörben (normál diák, elrendezések, mester, jegyzetek/handoutok) a helyettesítők be- vagy kikapcsolásához és a tartalmuk beállításához.