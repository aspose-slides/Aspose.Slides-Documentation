---
title: PowerPoint szöveg animálása PHP-ben
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/php-java/animated-text/
keywords:
- animált szöveg
- szöveganimáció
- animált bekezdés
- bekezdés animáció
- animációs effektus
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Készíts dinamikus animált szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for PHP via Java használatával, könnyen követhető, optimalizált kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk animált szöveggel az Aspose.Slides-ben animációs effektusok alkalmazásával az egyes bekezdésekre, valamint a már egy szövegkeretben bekezdésekhez rendelt effektusok lekérésével. Az API metódusokra összpontosít, amelyekkel bekezdés‑szintű animációkat adhatunk hozzá, illetve a meglévő bekezdés‑animációs effektusokat vizsgálhatjuk egy prezentációban.

## **Animációs effektusok hozzáadása bekezdésekhez**

Hozzáadtuk a [**addEffect()**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) metódust a [**Sequence**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Sequence) osztályhoz. Ez a metódus lehetővé teszi, hogy animációs effektusokat adjunk egyetlen bekezdéshez. Ez a példakód bemutatja, hogyan adhatunk animációs effektust egyetlen bekezdéshez:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # a bekezdés kiválasztása az effektus hozzáadásához
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # Fly animációs effektus hozzáadása a kiválasztott bekezdéshez
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Animációs effektusok lekérése bekezdésekből**

Előfordulhat, hogy meg szeretné tudni, milyen animációs effektusok lettek egy bekezdéshez hozzáadva – például egy helyzetben azt szeretné lekérni, hogy milyen effektusok vannak egy bekezdésben, mert ezeket másik bekezdésre vagy alakzatra kívánja alkalmazni.

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy lekérje az összes animációs effektust, amely egy szövegkeretben (alakzat) lévő bekezdésekre van alkalmazva. Ez a példakód bemutatja, hogyan kérhetők le az animációs effektusok egy bekezdésben:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **GYIK**

**Hogyan különböznek a szöveganimációk a diaátmenetektől, és kombinálhatók-e?**

A szöveganimációk a objektum viselkedését szabályozzák egy dián belül időben, míg a [transitions](/slides/hu/php-java/slide-transition/) a diák váltását irányítják. Különállóak, de együtt is használhatók; a lejátszási sorrendet az animációs idővonal és a átmenet beállításai szabályozzák.

**Megmaradnak a szöveganimációk PDF vagy képek exportálásakor?**

Nem. A PDF és a raszteres képek statikusak, így csak egyetlen állapotot látsz a diáról mozgás nélkül. A mozgás megtartásához használj [video](/slides/hu/php-java/convert-powerpoint-to-video/) vagy [HTML](/slides/hu/php-java/export-to-html5/) exportálást.

**Működnek a szöveganimációk elrendezésekben és a diamesterben?**

Az elrendezés/mester objektumokra alkalmazott effektusok öröklődnek a diákra, de azok időzítése és a diá‑szintű animációkkal való kölcsönhatása a diasor végső sorrendjétől függ.