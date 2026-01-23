---
title: Animer le texte PowerPoint en PHP
linktitle: Texte animé
type: docs
weight: 60
url: /fr/php-java/animated-text/
keywords:
- texte animé
- animation de texte
- paragraphe animé
- animation de paragraphe
- effet d'animation
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créez du texte animé dynamique dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java, avec des exemples de code faciles à suivre et optimisés."
---

## **Ajouter des effets d'animation aux paragraphes**

Nous avons ajouté la méthode [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) à la classe [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence). Cette méthode vous permet d'ajouter des effets d'animation à un paragraphe unique. Ce code d'exemple vous montre comment ajouter un effet d'animation à un paragraphe unique :
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # sélectionner le paragraphe pour ajouter l'effet
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # ajouter l'effet d'animation Fly au paragraphe sélectionné
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Obtenir les effets d'animation des paragraphes**

Vous pouvez décider de connaître les effets d'animation ajoutés à un paragraphe — par exemple, dans un scénario, vous souhaitez récupérer les effets d'animation d'un paragraphe parce que vous prévoyez d'appliquer ces effets à un autre paragraphe ou à une forme.

Aspose.Slides for PHP via Java vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Ce code d'exemple vous montre comment récupérer les effets d'animation d'un paragraphe :
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


## **FAQ**

**Comment les animations de texte diffèrent-elles des transitions de diapositive, et peuvent-elles être combinées ?**

Les animations de texte contrôlent le comportement d’un objet au fil du temps sur une diapositive, tandis que les [transitions](/slides/fr/php-java/slide-transition/) contrôlent la façon dont les diapositives changent. Elles sont indépendantes et peuvent être utilisées ensemble ; l’ordre de lecture est régi par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont-elles conservées lors de l’exportation vers PDF ou images ?**

Non. Les PDF et les images raster sont statiques, vous verrez donc un seul état de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l’exportation en [vidéo](/slides/fr/php-java/convert-powerpoint-to-video/) ou en [HTML](/slides/fr/php-java/export-to-html5/).

**Les animations de texte fonctionnent-elles dans les dispositions et le masque des diapositives ?**

Les effets appliqués aux objets de disposition/masque sont hérités par les diapositives, mais leur chronologie et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.