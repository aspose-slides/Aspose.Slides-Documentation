---
title: Animar texto do PowerPoint em PHP
linktitle: Texto animado
type: docs
weight: 60
url: /pt/php-java/animated-text/
keywords:
- texto animado
- animação de texto
- parágrafo animado
- animação de parágrafo
- efeito de animação
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Crie texto animado dinâmico em apresentações PowerPoint e OpenDocument usando Aspose.Slides para PHP via Java, com exemplos de código otimizados e fáceis de seguir."
---
## **Visão geral**

Este artigo explica como trabalhar com texto animado no Aspose.Slides aplicando efeitos de animação a parágrafos individuais e recuperando os efeitos já atribuídos a parágrafos em uma caixa de texto. Ele se concentra nos métodos da API usados para adicionar animação ao nível de parágrafo e inspecionar os efeitos de animação de parágrafo existentes em uma apresentação.

## **Adicionar efeitos de animação aos parágrafos**

Adicionamos o método [**addEffect()**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) à classe [**Sequence**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Sequence). Esse método permite adicionar efeitos de animação a um único parágrafo. O código de exemplo a seguir mostra como adicionar um efeito de animação a um único parágrafo:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # selecione o parágrafo para adicionar o efeito
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # adicione o efeito de animação Fly ao parágrafo selecionado
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Obter efeitos de animação dos parágrafos**

Você pode decidir descobrir os efeitos de animação adicionados a um parágrafo — por exemplo, em um cenário, pode querer obter os efeitos de animação em um parágrafo porque pretende aplicar esses efeitos a outro parágrafo ou forma.  

O Aspose.Slides for PHP via Java permite obter todos os efeitos de animação aplicados aos parágrafos contidos em uma caixa de texto (forma). O código de exemplo a seguir mostra como obter os efeitos de animação em um parágrafo:

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

## **Perguntas frequentes**

**Como as animações de texto diferem das transições de slide e podem ser combinadas?**

As animações de texto controlam o comportamento do objeto ao longo do tempo em um slide, enquanto as [transições](/slides/pt/php-java/slide-transition/) controlam como os slides mudam. Elas são independentes e podem ser usadas juntas; a ordem de reprodução é governada pela linha do tempo da animação e pelas configurações de transição.

**As animações de texto são preservadas ao exportar para PDF ou imagens?**

Não. PDFs e imagens raster são estáticos, portanto você verá um único estado do slide sem movimento. Para manter a animação, use a exportação para [vídeo](/slides/pt/php-java/convert-powerpoint-to-video/) ou [HTML](/slides/pt/php-java/export-to-html5/).

**As animações de texto funcionam em layouts e no mestre de slides?**

Os efeitos aplicados a objetos de layout/mestre são herdados pelos slides, mas seu tempo e interação com animações ao nível de slide dependem da sequência final no slide.