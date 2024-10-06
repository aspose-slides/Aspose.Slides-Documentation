---
title: Texte Animé
type: docs
weight: 60
url: /php-java/animated-text/
keywords: "Texte animé dans PowerPoint"
description: "Texte animé dans PowerPoint avec Java"
---

## Ajouter des Effets d'Animation aux Paragraphes

Nous avons ajouté la méthode [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) aux classes [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) et [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence). Cette méthode vous permet d'ajouter des effets d'animation à un seul paragraphe. Ce code d'exemple vous montre comment ajouter un effet d'animation à un seul paragraphe :

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # sélectionner le paragraphe à ajouter un effet
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # ajouter un effet d'animation Fly au paragraphe sélectionné
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## Obtenir les Effets d'Animation dans les Paragraphes

Vous pouvez décider de découvrir les effets d'animation ajoutés à un paragraphe—par exemple, dans un scénario, vous souhaitez obtenir les effets d'animation dans un paragraphe car vous prévoyez d'appliquer ces effets à un autre paragraphe ou forme.

Aspose.Slides pour PHP via Java vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Ce code d'exemple vous montre comment obtenir les effets d'animation dans un paragraphe :

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Le paragraphe \"" . $paragraph->getText() . "\" a un effet de type " . $effects[0]->getType() . ".");
      }
    }
  } finally {
    $pres->dispose();
  }
```