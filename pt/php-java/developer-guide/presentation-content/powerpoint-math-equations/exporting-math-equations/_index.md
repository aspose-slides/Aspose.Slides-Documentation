---
title: Exportar Equações Matemáticas de Apresentações em PHP
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/php-java/exporting-math-equations/
keywords:
- exportar equações matemáticas
- MathML
- LaTeX
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Desbloqueie a exportação perfeita de equações matemáticas do PowerPoint para MathML usando Aspose.Slides for PHP via Java — preserve a formatação e aumente a compatibilidade."
---
## **Introdução**

Aspose.Slides for PHP via Java permite exportar equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair as equações matemáticas dos slides (de uma apresentação específica) e usá-las em outro programa ou plataforma.

{{% alert color="primary" %}} 

Você pode exportar equações para MathML, um formato popular ou padrão para equações matemáticas e conteúdo semelhante visto na web e em muitas aplicações. 

{{% /alert %}}

## **Salvar Equações Matemáticas como MathML**

Embora humanos escrevam facilmente o código para alguns formatos de equação como LaTeX, eles têm dificuldade em escrever o código para MathML porque este último deve ser gerado automaticamente por aplicativos. Programas leem e analisam MathML facilmente porque seu código está em XML, portanto MathML é comumente usado como formato de saída e impressão em muitos campos. 

Este código de exemplo mostra como exportar uma equação matemática de uma apresentação para MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas Frequentes**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo matemático inteiro ([MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como posso identificar se um objeto em um slide é uma fórmula matemática em vez de texto comum ou uma imagem?**

Uma fórmula está dentro de uma [MathPortion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/). Imagens e trechos de texto comuns sem um [MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). A Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente utilizado em aplicativos e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos etc. é suportada?**

Sim, se esses objetos contiverem trechos de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), eles serão exportados. Se uma fórmula estiver embutida como imagem, não será.

**A exportação para MathML modifica a apresentação original?**

Não. Gerar MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.