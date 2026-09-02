---
title: Exportar Equações Matemáticas de Apresentações em PHP
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/php-java/exporting-math-equations/
keywords:
- exportar equações matemáticas
- exportar equações para LaTeX
- PowerPoint para LaTeX
- MathML
- LaTeX
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Exporte equações matemáticas de apresentações PowerPoint para LaTeX ou MathML diretamente com Aspose.Slides for PHP via Java."
---
## **Introdução**

Aspose.Slides for PHP via Java permite que você exporte equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair as equações matemáticas dos slides (de uma apresentação específica) e usá‑las em outro programa ou plataforma.

{{% alert color="primary" %}} 
Você pode exportar equações diretamente para LaTeX ou para MathML, um padrão popular para conteúdo matemático usado na web e em muitas aplicações.
{{% /alert %}}

## **Exportar Equações Matemáticas para LaTeX**

Aspose.Slides pode converter uma equação matemática do PowerPoint diretamente para LaTeX; um arquivo intermediário MathML e um conversor externo não são necessários. Uma equação matemática é armazenada em um quadro de texto como um [MathPortion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathportion/). Use [MathPortion::getMathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathportion/#getMathParagraph) para obter um [MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/), e então chame [MathParagraph::toLatex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/#toLatex). O método retorna uma string que você pode salvar, exibir, enviar para outra aplicação ou processar further.

O exemplo a seguir examina cada quadro de texto em cada slide, encontra todas as partes matemáticas e grava cada equação em um arquivo `.tex` separado:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/#getAllTextBoxes) retorna todos os quadros de texto encontrados em um slide. A verificação de tipo [MathPortion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathportion/) separa equações editáveis genuínas de texto comum e imagens.

Os motores LaTeX e os modelos de documento não suportam todos os mesmos comandos, pacotes ou caracteres Unicode. Teste a string retornada com o motor LaTeX usado pela sua aplicação. Se um símbolo ou elemento Office Math não tiver representação adequada naquele ambiente, substitua‑a na string retornada por um comando específico do projeto ou ignore a equação e registre o problema para revisão.

## **Salvar Equações Matemáticas como MathML**

Embora os humanos escrevam facilmente o código para alguns formatos de equação, como LaTeX, eles têm dificuldade em escrever o código para MathML, pois este último deve ser gerado automaticamente por aplicativos. Programas leem e analisam MathML facilmente porque seu código está em XML, de modo que MathML é comumente usado como formato de saída e impressão em muitas áreas.

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

## **FAQ**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar um parágrafo matemático inteiro ([MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/)) ou um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como posso saber se um objeto em um slide é uma fórmula matemática e não texto comum ou imagem?**

Uma fórmula reside em um [MathPortion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/). Imagens e porções de texto regulares sem um [MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente usado em aplicações e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos etc. é suportada?**

Sim, se esses objetos contiverem porções de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), elas são exportadas. Se a fórmula estiver incorporada como imagem, não será exportada.

**A exportação para MathML modifica a apresentação original?**

Não. Gravar MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.