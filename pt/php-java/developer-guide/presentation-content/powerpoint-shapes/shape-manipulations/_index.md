---
title: Gerenciar Formas de Apresentação em PHP
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/php-java/shape-manipulations/
keywords:
- Forma do PowerPoint
- Forma de apresentação
- Forma no slide
- Encontrar forma
- Clonar forma
- Remover forma
- Ocultar forma
- Alterar ordem da forma
- Obter ID da forma Interop
- Texto alternativo da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a criar, editar e otimizar formas no Aspose.Slides para PHP via Java e entregar apresentações PowerPoint de alto desempenho."
---
## **Visão geral**

Este artigo explica como trabalhar com formas em apresentações usando Aspose.Slides. Ele mostra como encontrar uma forma em um slide, cloná‑la, removê‑la, ocultá‑la, alterar sua ordem, obter seu ID de forma Interop e definir texto alternativo para identificação e processamento posterior.

Também aborda como acessar formatos de layout para formas, renderizar uma forma como SVG, alinhar formas em um slide e usar propriedades de espelhamento horizontal e vertical. Além disso, o artigo inclui um FAQ curto sobre combinação de formas, ordem de empilhamento e bloqueio de forma.

## **Encontrar uma forma em um slide**
Este tópico descreve uma técnica simples para facilitar a localização de uma forma específica em um slide sem usar seu Id interno. É importante saber que arquivos de apresentação do PowerPoint não possuem nenhum modo de identificar formas em um slide, exceto por um Id interno exclusivo. Parece ser difícil para os desenvolvedores encontrar uma forma usando esse Id interno exclusivo. Todas as formas adicionadas aos slides têm algum Texto Alternativo. Sugerimos que os desenvolvedores usem texto alternativo para encontrar uma forma específica. Você pode usar o MS PowerPoint para definir o texto alternativo para objetos que pretende alterar no futuro.

Depois de definir o texto alternativo de qualquer forma desejada, você pode abrir a apresentação usando Aspose.Slides for PHP via Java e iterar por todas as formas adicionadas a um slide. Em cada iteração, você pode verificar o texto alternativo da forma e a forma com o texto correspondente será a forma requerida por você. Para demonstrar essa técnica de forma mais clara, criamos o método [findShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) que faz a busca de uma forma específica em um slide e devolve simplesmente essa forma.

```php
  # Instanciar a classe Presentation que representa o arquivo da apresentação
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Texto alternativo da forma a ser encontrada
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Clonar uma forma**
Para clonar uma forma para um slide usando Aspose.Slides for PHP via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide usando seu índice.
1. Acesse a coleção de formas do slide de origem.
1. Adicione um novo slide à apresentação.
1. Clone as formas da coleção de formas do slide de origem para o novo slide.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona uma forma de grupo a um slide.

```php
  # Instanciar a classe Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Gravar o arquivo PPTX no disco
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remover uma forma**
Aspose.Slides for PHP via Java permite que os desenvolvedores removam qualquer forma. Para remover a forma de um slide, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Encontre a forma com o TextoAlternativo específico.
1. Remova a forma.
1. Salve o arquivo no disco.

```php
  # Criar objeto Presentation
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar autoshape do tipo retângulo
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Salvar a apresentação no disco
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ocultar uma forma**
Aspose.Slides for PHP via Java permite que os desenvolvedores ocultem qualquer forma. Para ocultar a forma de um slide, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Encontre a forma com o TextoAlternativo específico.
1. Oculte a forma.
1. Salve o arquivo no disco.

```php
  # Instanciar a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar autoshape do tipo retângulo
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Salvar a apresentação no disco
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alterar a ordem da forma**
Aspose.Slides for PHP via Java permite que os desenvolvedores reordenem as formas. Reordenar a forma especifica qual forma fica na frente ou qual forma fica atrás. Para reordenar a forma de um slide, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione uma forma.
1. Adicione algum texto na caixa de texto da forma.
1. Adicione outra forma com as mesmas coordenadas.
1. Reordene as formas.
1. Salve o arquivo no disco.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obter o ID da forma Interop**
Aspose.Slides for PHP via Java permite que os desenvolvedores obtenham um identificador único de forma no escopo do slide, em contraste com o método [getUniqueId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getuniqueid/), que permite obter um identificador único no escopo da apresentação. O método [getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getofficeinteropshapeid/) foi adicionado à classe [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) respectivamente. O valor retornado por [getOfficeInteropShapeId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getofficeinteropshapeid/) corresponde ao valor do Id do objeto Microsoft.Office.Interop.PowerPoint.Shape. Abaixo é apresentado um exemplo de código.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obtendo identificador de forma exclusivo no escopo do slide
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Texto Alternativo para uma Forma**
Aspose.Slides for PHP via Java permite que os desenvolvedores definam `AlternativeText` de qualquer forma. As formas em uma apresentação podem ser distinguidas pelo **Texto Alternativo** ou pelo método [Shape Name](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/setname/). Os métodos [setAlternativeText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/setalternativetext/) e [getAlternativeText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getalternativetext/) podem ser lidos ou definidos usando Aspose.Slides assim como o Microsoft PowerPoint. Usando este método, você pode marcar uma forma e executar diferentes operações, como remover, ocultar ou reordenar formas em um slide. Para definir o `AlternativeText` de uma forma, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione qualquer forma ao slide.
1. Realize algum trabalho com a forma recém‑adicionada.
1. Percorra as formas para encontrar uma forma.
1. Defina o `AlternativeText`.
1. Salve o arquivo no disco.

```php
  # Instanciar a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar autoshape do tipo retângulo
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Salvar a apresentação no disco
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acessar Formatos de Layout para uma Forma**
Aspose.Slides for PHP via Java fornece uma API simples para acessar formatos de layout para uma forma. Este artigo demonstra como você pode acessar esses formatos.

Abaixo é apresentado um exemplo de código.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Renderizar uma Forma como SVG**
Agora o Aspose.Slides for PHP via Java oferece suporte à renderização de uma forma como SVG. O método [writeAsSvg](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/writeassvg/) (e sua sobrecarga) foi adicionado à classe [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/). Esse método permite salvar o conteúdo da forma como um arquivo SVG. O trecho de código abaixo mostra como exportar a forma de um slide para um arquivo SVG.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alinhar uma Forma**
Aspose.Slides permite alinhar formas tanto em relação às margens do slide quanto em relação umas às outras. Para isso, foi adicionada a sobrecarga do método [SlidesUtil::alignShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/alignshapes/). A enumeração [ShapesAlignmentType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapesalignmenttype/) define as opções de alinhamento possíveis.

**Exemplo 1**

O código fonte abaixo alinha as formas com índices 1, 2 e 4 ao longo da borda superior do slide.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Exemplo 2**

O exemplo abaixo mostra como alinhar toda a coleção de formas em relação à forma mais inferior da coleção.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Propriedades de espelhamento**

No Aspose.Slides, a classe [ShapeFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapeframe/) fornece controle sobre o espelhamento horizontal e vertical das formas via suas propriedades `flipH` e `flipV`. Ambas as propriedades são do tipo [NullableBool](https://reference.aspose.com/slides/pt/php-java/aspose.slides/nullablebool/), permitindo valores `True` para indicar um espelhamento, `False` para nenhum espelhamento ou `NotDefined` para usar o comportamento padrão. Esses valores são acessíveis a partir do [Frame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getFrame) de uma forma.

Para modificar as configurações de espelhamento, cria‑se uma nova instância de [ShapeFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapeframe/) com a posição e tamanho atuais da forma, os valores desejados para `flipH` e `flipV`, e o ângulo de rotação. Atribuir essa instância ao [Frame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getFrame) da forma e salvar a apresentação aplica as transformações de espelhamento e as grava no arquivo de saída.

Suponha que tenhamos um arquivo sample.pptx no qual o primeiro slide contém uma única forma com configurações padrão de espelhamento, como mostrado abaixo.

![A forma a ser invertida](shape_to_be_flipped.png)

O exemplo de código a seguir recupera as propriedades de espelhamento atuais da forma e a inverte horizontal e verticalmente.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Recuperar a propriedade de espelhamento horizontal da forma.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Recuperar a propriedade de espelhamento vertical da forma.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Espelhar horizontalmente.
    $flipV = NullableBool::True; // Espelhar horizontalmente.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![A forma invertida](flipped_shape.png)

## **Perguntas Frequentes**

**Posso combinar formas (união/interseção/subtração) em um slide como em um editor de desktop?**

Não existe uma API de operação booleana integrada. Você pode aproximar isso construindo o contorno desejado você mesmo — por exemplo, compute a geometria resultante (via [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometrypath/)) e crie uma nova forma com esse contorno, removendo opcionalmente as originais.

**Como posso controlar a ordem de empilhamento (z‑order) para que uma forma permaneça sempre “no topo”?**

Altere a ordem de inserção/movimento dentro da coleção de [shapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getShapes) do slide. Para resultados previsíveis, finalize a ordem z‑order após todas as demais modificações do slide.

**Posso “bloquear” uma forma para impedir que usuários a editem no PowerPoint?**

Sim. Defina bandeiras de proteção ao nível da forma (por exemplo, bloquear seleção, movimentação, redimensionamento, edição de texto). Se necessário, reflita restrições no mestre ou layout. Observe que isso é proteção ao nível da UI, não um recurso de segurança; para proteção mais forte, combine com restrições ao nível do arquivo, como recomendações de somente‑leitura ou senhas ([read‑only recommendations or passwords](/slides/pt/php-java/password-protected-presentation/)).