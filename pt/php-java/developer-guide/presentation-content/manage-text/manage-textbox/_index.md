---
title: Gerenciar Caixas de Texto em Apresentações Usando PHP
linktitle: Gerenciar Caixa de Texto
type: docs
weight: 20
url: /pt/php-java/manage-textbox/
keywords:
- caixa de texto
- quadro de texto
- adicionar texto
- atualizar texto
- criar caixa de texto
- verificar caixa de texto
- adicionar coluna de texto
- adicionar hyperlink
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "O Aspose.Slides for PHP facilita a criação, edição e clonagem de caixas de texto em arquivos PowerPoint e OpenDocument, aprimorando a automação de suas apresentações."
---
## **Introdução**

Os textos nos slides normalmente existem em caixas de texto ou formas. Portanto, para adicionar um texto a um slide, você precisa adicionar uma caixa de texto e então colocar algum texto dentro da caixa de texto. Aspose.Slides for PHP via Java fornece a classe [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) que permite adicionar uma forma contendo algum texto.

{{% alert title="Info" color="info" %}}
Aspose.Slides também fornece a classe [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) que permite adicionar formas aos slides. No entanto, nem todas as formas adicionadas através da classe `Shape` podem conter texto. Mas as formas adicionadas através da classe [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) podem conter texto.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Portanto, ao lidar com uma forma à qual você deseja adicionar texto, pode ser necessário verificar e confirmar que ela foi convertida através da classe `AutoShape`. Só então você poderá trabalhar com [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/), que é uma propriedade de `AutoShape`. Consulte a seção [Update Text](/slides/pt/php-java/manage-textbox/#update-text) nesta página.
{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Obtenha uma referência para o primeiro slide da apresentação recém‑criada. 
3. Adicione um objeto [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) com o tipo de forma definido como [Rectangle](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapetype/#Rectangle) em uma posição especificada no slide e obtenha a referência para o objeto `AutoShape` recém‑adicionado.
4. Adicione um `TextFrame` ao objeto `AutoShape` que conterá um texto. No exemplo abaixo, adicionamos este texto: *Aspose TextBox*
5. Por fim, grave o arquivo PPTX através do objeto `Presentation`. 

Este código PHP—uma implementação das etapas acima—mostra como adicionar texto a um slide:

```php
  # Instancia a Presentation
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide da apresentação
    $sld = $pres->getSlides()->get_Item(0);
    # Adiciona um AutoShape com o tipo definido como Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Adiciona TextFrame ao retângulo
    $ashp->addTextFrame(" ");
    # Acessa o quadro de texto
    $txtFrame = $ashp->getTextFrame();
    # Cria o objeto Paragraph para o quadro de texto
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Cria um objeto Portion para o parágrafo
    $portion = $para->getPortions()->get_Item(0);
    # Define o texto
    $portion->setText("Aspose TextBox");
    # Salva a apresentação no disco
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verificar se é uma Forma de Caixa de Texto**

Aspose.Slides fornece o método [isTextBox](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/istextbox/) da classe [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/), permitindo examinar formas e identificar caixas de texto.

![Text box and shape](istextbox.png)

Este código PHP mostra como verificar se uma forma foi criada como caixa de texto:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Observe que, se você simplesmente adicionar uma auto‑shape usando o método `addAutoShape` da classe [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/), o método `isTextBox` da auto‑shape retornará `false`. Contudo, depois de adicionar texto à auto‑shape usando o método `addTextFrame` ou o método `setText`, a propriedade `isTextBox` retornará `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() retorna false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() retorna true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() retorna false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() retorna true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() retorna false
$shape3->addTextFrame("");
// shape3->isTextBox() retorna false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() retorna false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() retorna false
```

## **Adicionar Colunas a uma Caixa de Texto**

Aspose.Slides fornece os métodos [setColumnCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/setcolumncount/) e [setColumnSpacing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/setcolumnspacing/) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/) que permitem adicionar colunas a caixas de texto. Você pode especificar o número de colunas em uma caixa de texto e definir o espaçamento em pontos entre as colunas.

Este código demonstra a operação descrita:

```php
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide da apresentação
    $slide = $pres->getSlides()->get_Item(0);
    # Adiciona um AutoShape com o tipo definido como Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Adiciona TextFrame ao retângulo
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Obtém o formato de texto do TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Especifica o número de colunas no TextFrame
    $format->setColumnCount(3);
    # Especifica o espaçamento entre colunas
    $format->setColumnSpacing(10);
    # Salva a apresentação
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar Colunas a um Texto Frame**

Aspose.Slides for PHP via Java fornece o método [setColumnCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/setcolumncount/) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/) que permite adicionar colunas em quadros de texto. Por meio dessa propriedade, você pode especificar o número desejado de colunas em um quadro de texto.

Este código PHP mostra como adicionar uma coluna dentro de um texto frame:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atualizar Texto**

Aspose.Slides permite mudar ou atualizar o texto contido em uma caixa de texto ou todos os textos contidos em uma apresentação. 

Este código PHP demonstra uma operação onde todos os textos em uma apresentação são atualizados ou alterados:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Verifica se a forma suporta quadro de texto (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Itera pelos parágrafos no quadro de texto
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Itera por cada porção no parágrafo
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Altera o texto

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Altera a formatação

            }
          }
        }
      }
    }
    # Salva a apresentação modificada
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar uma Caixa de Texto com um Hyperlink** 

Você pode inserir um link dentro de uma caixa de texto. Quando a caixa de texto é clicada, os usuários são direcionados para abrir o link. 

Para adicionar uma caixa de texto contendo um link, siga estas etapas:

1. Crie uma instância da classe `Presentation`. 
2. Obtenha uma referência para o primeiro slide da apresentação recém‑criada. 
3. Adicione um objeto `AutoShape` com `ShapeType` definido como `Rectangle` em uma posição especificada no slide e obtenha a referência do objeto AutoShape recém‑adicionado.
4. Adicione um `TextFrame` ao objeto `AutoShape` que contém *Aspose TextBox* como texto padrão. 
5. Instancie a classe `HyperlinkManager`. 
6. Atribua um hyperlink usando o método [setExternalHyperlinkClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) associado à porção desejada do `TextFrame`.
7. Por fim, grave o arquivo PPTX através do objeto `Presentation`. 

Este código PHP—uma implementação das etapas acima—mostra como adicionar uma caixa de texto com um hyperlink a um slide:

```php
  # Instancia uma classe Presentation que representa um PPTX
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide da apresentação
    $slide = $pres->getSlides()->get_Item(0);
    # Adiciona um objeto AutoShape com o tipo definido como Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Faz cast da forma para AutoShape
    $pptxAutoShape = $shape;
    # Acessa a propriedade ITextFrame associada ao AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Adiciona algum texto ao frame
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Define o Hyperlink para o texto da porção
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Salva a apresentação PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Qual é a diferença entre uma caixa de texto e um placeholder de texto ao trabalhar com slides mestres?**

Um [placeholder](/slides/pt/php-java/manage-placeholder/) herda estilo/posição do [master](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/) e pode ser sobrescrito nos [layouts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/), enquanto uma caixa de texto normal é um objeto independente em um slide específico e não muda quando você troca de layout.

**Como posso fazer uma substituição em massa de texto em toda a apresentação sem alterar o texto dentro de gráficos, tabelas e SmartArt?**

Limite sua iteração a auto‑shapes que possuem quadros de texto e exclua objetos incorporados ([charts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/pt/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartart/)) percorrendo suas coleções separadamente ou ignorando esses tipos de objeto.