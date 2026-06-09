---
title: Gerenciar Fontes em Apresentações Usando PHP
linktitle: Gerenciar Fontes
type: docs
weight: 10
url: /pt/php-java/manage-fonts/
keywords:
- gerenciar fontes
- propriedades de fonte
- parágrafo
- formatação de texto
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Controle fontes em PHP com Aspose.Slides: incorpore, substitua e carregue fontes personalizadas para manter apresentações PPT, PPTX e ODP claras, seguras para a marca e consistentes."
---
## **Gerenciar Propriedades Relacionadas à Fonte**
{{% alert color="primary" %}} 

As apresentações geralmente contêm texto e imagens. O texto pode ser formatado de várias maneiras, seja para destacar seções e palavras específicas ou para adequar-se aos estilos corporativos. A formatação de texto ajuda os usuários a variar a aparência do conteúdo da apresentação. Este artigo mostra como usar Aspose.Slides for PHP via Java para configurar as propriedades de fonte de parágrafos de texto nos slides.

{{% /alert %}} 

Para gerenciar as propriedades de fonte de um parágrafo usando Aspose.Slides for PHP via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse as formas [Placeholder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/placeholder/) no slide e faça o type cast para [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
1. Recupere o [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) a partir do [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) exposto por [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
1. Justifique o parágrafo.
1. Acesse a [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) de texto de um [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/).
1. Defina a fonte usando [FontData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontdata/) e ajuste a **Font** da [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) de texto de acordo.
   1. Defina a fonte como negrito.
   1. Defina a fonte como itálico.
1. Defina a cor da fonte usando o [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/) exposto pelo objeto [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/).
1. Salve a apresentação modificada em um arquivo PPTX.

A implementação das etapas acima é apresentada a seguir. Ela recebe uma apresentação sem formatação e altera as fontes em um dos slides. As capturas de tela a seguir mostram o arquivo de entrada e como os trechos de código o modificam. O código altera a fonte, a cor e o estilo da fonte.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: O texto no arquivo de entrada**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: O mesmo texto com formatação atualizada**|

```php
  # Instanciar um objeto Presentation que representa um arquivo PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Acessar um slide usando sua posição
    $slide = $pres->getSlides()->get_Item(0);
    # Acessar o primeiro e o segundo placeholder no slide e fazer typecast para AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Acessar o primeiro Parágrafo
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Justificar o parágrafo
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Acessar a primeira porção
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definir novas fontes
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Atribuir novas fontes à porção
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Definir fonte como Negrito
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Definir fonte como Itálico
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Definir cor da fonte
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Salvar o PPTX no disco
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Propriedades de Fonte do Texto**
{{% alert color="primary" %}} 

Conforme mencionado em **Gerenciar Propriedades Relacionadas à Fonte**, uma [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) é usada para armazenar texto com estilo de formatação semelhante em um parágrafo. Este artigo mostra como usar Aspose.Slides for PHP via Java para criar uma caixa de texto com algum conteúdo e, em seguida, definir uma fonte específica e várias outras propriedades da categoria de família de fontes.

{{% /alert %}} 

Para criar uma caixa de texto e definir as propriedades de fonte do texto nela:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) do tipo **Rectangle** ao slide.
1. Remova o estilo de preenchimento associado ao [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
1. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) do [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
1. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/).
1. Acesse o objeto [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) associado ao [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/).
1. Defina a fonte a ser usada para a [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/).
1. Defina outras propriedades da fonte, como negrito, itálico, sublinhado, cor e altura, usando as propriedades relevantes expostas pelo objeto [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/).
1. Escreva a apresentação modificada como um arquivo PPTX.

A implementação das etapas acima é apresentada a seguir.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto com algumas propriedades de fonte definidas pelo Aspose.Slides for PHP via Java**|

```php
  # Instanciar um objeto Presentation que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar um AutoShape do tipo Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Remover qualquer estilo de preenchimento associado ao AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Acessar o TextFrame associado ao AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Acessar a Portion associada ao TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Definir a Fonte para a Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Definir a propriedade Negrito da Fonte
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Definir a propriedade Itálico da Fonte
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Definir a propriedade Sublinhado da Fonte
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Definir a Altura da Fonte
    $port->getPortionFormat()->setFontHeight(25);
    # Definir a cor da Fonte
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Salvar a apresentação no disco
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```