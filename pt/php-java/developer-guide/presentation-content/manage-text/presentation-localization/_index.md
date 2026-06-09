---
title: Automatizar a localização de apresentações em PHP
linktitle: Localização de Apresentações
type: docs
weight: 100
url: /pt/php-java/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- id de idioma
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Automatize a localização de slides PowerPoint e OpenDocument com Aspose.Slides para PHP via Java, usando exemplos de código práticos e dicas para uma implantação global mais rápida."
---
## **Visão geral**

Este artigo explica como definir o `LanguageId` para texto em uma apresentação usando o Aspose.Slides. Ele demonstra como abrir uma apresentação, adicionar uma forma com texto, atribuir um identificador de idioma a uma parte do texto e salvar o resultado como um arquivo PPTX.

## **Alterar idioma de uma apresentação e texto de forma**
- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) do tipo [Rectangle](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ShapeType#Rectangle) ao slide.
- Adicione algum texto ao TextFrame.
- [Definir Language Id](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) no texto.
- Grave a apresentação como um arquivo PPTX.

A implementação das etapas acima é demonstrada abaixo em um exemplo.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**O ID de idioma aciona tradução automática de texto?**

Não. O [Language ID](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) no Aspose.Slides armazena o idioma para verificação ortográfica e correção gramatical, mas não traduz nem altera o conteúdo do texto. É um metadado que o PowerPoint entende para revisão.

**O ID de idioma afeta a hifenização e quebras de linha durante a renderização?**

No Aspose.Slides, o [language ID](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) é usado para revisão. A qualidade da hifenização e a quebra de linha dependem principalmente da disponibilidade de [proper fonts](/slides/pt/php-java/powerpoint-fonts/) e das configurações de layout/quebra de linha para o sistema de escrita. Para garantir a renderização correta, disponibilize as fontes necessárias, configure [font substitution rules](/slides/pt/php-java/font-substitution/) e/ou [embed fonts](/slides/pt/php-java/embedded-font/) na apresentação.

**Posso definir idiomas diferentes dentro de um único parágrafo?**

Sim. O [Language ID](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) é aplicado ao nível da parte do texto, portanto um único parágrafo pode mesclar vários idiomas com configurações de revisão distintas.