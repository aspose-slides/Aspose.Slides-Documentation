---
title: Personalizar Formas de Apresentação em PHP
linktitle: Forma Personalizada
type: docs
weight: 20
url: /pt/php-java/custom-shape/
keywords:
- forma personalizada
- adicionar forma
- criar forma
- alterar forma
- geometria da forma
- caminho de geometria
- pontos do caminho
- pontos de edição
- adicionar ponto
- remover ponto
- operação de edição
- canto curvo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Crie e personalize formas em apresentações PowerPoint com Aspose.Slides para PHP via Java: caminhos de geometria, cantos curvos, formas compostas."
---
## **Visão geral**

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma por meio de pontos de edição e caminhos de geometria. Ele mostra como trabalhar com `GeometryPath` para modificar formas existentes, executar operações básicas de edição de caminhos, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos, determinar se a geometria de uma forma está fechada e converter entre `GeometryPath` e `java.awt.Shape` para cenários adicionais de personalização de geometria.

## **Alterar uma forma usando pontos de edição**
Considere um quadrado. No PowerPoint, usando **pontos de edição**, você pode 

* mover o canto do quadrado para dentro ou para fora  
* especificar a curvatura de um canto ou ponto  
* adicionar novos pontos ao quadrado  
* manipular pontos no quadrado, etc.  

Essencialmente, você pode realizar as tarefas descritas em qualquer forma. Usando pontos de edição, você pode alterar uma forma ou criar uma nova forma a partir de uma forma existente. 

## **Dicas de edição de formas**

![overview_image](custom_shape_0.png)

Antes de começar a editar formas do PowerPoint por meio de pontos de edição, pode ser útil considerar estes pontos sobre formas:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.  
* Quando uma forma é fechada, não possui ponto de início ou fim. Quando uma forma é aberta, tem um início e um fim.  
* Todas as formas consistem em pelo menos 2 pontos âncora ligados entre si por linhas  
* Uma linha pode ser reta ou curva. Os pontos âncora determinam a natureza da linha.  
* Os pontos âncora podem ser cantos, pontos retos ou pontos suaves:  
  * Um ponto de canto é um ponto onde 2 linhas retas se juntam em um ângulo.  
  * Um ponto suave é um ponto onde 2 alças existem em linha reta e os segmentos da linha se unem em uma curva suave. Nesse caso, todas as alças ficam separadas do ponto âncora por uma distância igual.  
  * Um ponto reto é um ponto onde 2 alças existem em linha reta e os segmentos da linha se unem em uma curva suave. Nesse caso, as alças não precisam estar separadas do ponto âncora por uma distância igual.  
* Ao mover ou editar pontos âncora (o que altera o ângulo das linhas), você pode mudar a aparência de uma forma.  

Para editar formas do PowerPoint por meio de pontos de edição, **Aspose.Slides** fornece a classe [**GeometryPath**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryPath).

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryPath) representa um caminho de geometria do objeto [GeometryShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometryshape/).  
* Para obter o `GeometryPath` da instância `GeometryShape`, você pode usar o método [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometryshape/#getGeometryPaths).  
* Para definir o `GeometryPath` de uma forma, você pode usar estes métodos: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometryshape/#setGeometryPath) para *formas sólidas* e [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometryshape/#setGeometryPaths) para *formas compostas*.  
* Para adicionar segmentos, você pode usar os métodos em [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometrypath/).  
* Usando os métodos [GeometryPath::setStroke](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometrypath/setstroke/) e [GeometryPath::setFillMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometrypath/setfillmode/), você pode definir a aparência de um caminho de geometria.  
* Usando o método [GeometryPath::getPathData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometrypath/getpathdata/), você pode recuperar o caminho de geometria de um `GeometryShape` como um array de segmentos de caminho.  
* Para acessar opções adicionais de personalização da geometria da forma, você pode converter [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometrypath/) para [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).  
* Use os métodos [geometryPathToGraphicsPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) e [graphicsPathToGeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (da classe [ShapeUtil](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ShapeUtil)) para converter [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/geometrypath/) em [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) e vice‑versa.

## **Operações de edição simples**

Este código PHP mostra como

**Adicionar uma linha** ao final de um caminho

```php

```
**Adicionar uma linha** a uma posição especificada em um caminho:

```php

```
**Adicionar uma curva Bézier cúbica** ao final de um caminho:

```php

```
**Adicionar uma curva Bézier cúbica** a uma posição especificada em um caminho:

```php

```
**Adicionar uma curva Bézier quadrática** ao final de um caminho:

```php

```
**Adicionar uma curva Bézier quadrática** a uma posição especificada em um caminho:

```php

```
**Anexar um arco especificado** a um caminho:

```php

```
**Fechar a figura atual** de um caminho:

```php

```
**Definir a posição para o próximo ponto**:

```php

```
**Remover o segmento do caminho** em um índice especificado:

```php

```

## **Adicionar pontos personalizados a uma forma**
1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryShape) e defina o tipo [ShapeType::Rectangle](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ShapeType).  
2. Obtenha uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryPath) a partir da forma.  
3. Adicione um novo ponto entre os dois pontos superiores do caminho.  
4. Adicione um novo ponto entre os dois pontos inferiores do caminho.  
5. Aplique o caminho à forma.  

Este código PHP mostra como adicionar pontos personalizados a uma forma:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **Remover pontos de uma forma**

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryShape) e defina o tipo [ShapeType::Heart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ShapeType).  
2. Obtenha uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryPath) a partir da forma.  
3. Remova o segmento do caminho.  
4. Aplique o caminho à forma.  

Este código PHP mostra como remover pontos de uma forma:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

##  **Criar uma forma personalizada**

1. Calcule os pontos da forma.  
2. Crie uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryPath).  
3. Preencha o caminho com os pontos.  
4. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryShape).  
5. Aplique o caminho à forma.  

Este Java mostra como criar uma forma personalizada:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **Criar uma forma personalizada composta**

  1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryShape).  
  2. Crie a primeira instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryPath).  
  3. Crie a segunda instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryPath).  
  4. Aplique os caminhos à forma.  

Este código PHP mostra como criar uma forma personalizada composta:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **Criar uma forma personalizada com cantos curvos**

Este código PHP mostra como criar uma forma personalizada com cantos curvos (para dentro);

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Descobrir se a geometria de uma forma está fechada**

Uma forma fechada é definida como aquela cujo todos os lados se conectam, formando um único contorno sem lacunas. Essa forma pode ser uma forma geométrica simples ou um contorno customizado complexo. O exemplo de código a seguir mostra como verificar se a geometria de uma forma está fechada:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **Converter GeometryPath para java.awt.Shape** 

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryShape).  
2. Crie uma instância da classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).  
3. Converta a instância [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) para a instância [GeometryPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/GeometryPath) usando o [ShapeUtil](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ShapeUtil).  
4. Aplique os caminhos à forma.  

Este código PHP — uma implementação dos passos acima — demonstra o processo de conversão de **GeometryPath** para **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Criar nova forma
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Obter caminho de geometria da forma
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Criar novo caminho gráfico com texto
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Converter caminho gráfico para caminho de geometria
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Definir combinação do novo caminho de geometria e do caminho de geometria original na forma
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **Perguntas Frequentes**

**O que acontecerá ao preenchimento e contorno após substituir a geometria?**

O estilo permanece associado à forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como girar corretamente uma forma personalizada junto com sua geometria?**

Use o método [setRotation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/setrotation/) da forma; a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em uma imagem para “travar” o resultado?**

Sim. Exporte a área do [slide](/slides/pt/php-java/convert-powerpoint-to-png/) necessária ou o próprio [shape](/slides/pt/php-java/create-shape-thumbnails/) para um formato raster; isso simplifica trabalhos posteriores com geometrias complexas.