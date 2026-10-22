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

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma por meio de pontos de edição e caminhos de geometria. Ele mostra como trabalhar com [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) para modificar formas existentes, executar operações básicas de edição de caminho, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Ele também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos, determinar se a geometria de uma forma está fechada, inspecionar elementos da forma e converter contornos de texto Java AWT em caminhos de geometria.

## **Alterar uma Forma Usando Pontos de Edição**

No PowerPoint, você pode usar **Pontos de Edição** para modificar um quadrado:

* Mover um canto para dentro ou para fora.
* Ajustar a curvatura em um ponto.
* Adicionar novos pontos.

Editar pontos permite modificar o contorno de uma forma ou usar uma forma existente como base para uma nova.

## **Dicas de Edição de Formas**

![imagem_visao_geral](custom_shape_0.png)

Ao editar formas no PowerPoint, mantenha estes conceitos em mente:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* O caminho de uma forma consiste em pontos de ancoragem conectados por segmentos.
* Um segmento pode ser reto ou curvo. Pontos de ancoragem e alças de controle determinam sua forma.
* Pontos de ancoragem existem como pontos de canto, pontos retos ou pontos suaves:
  * Em um ponto de canto, os segmentos adjacentes podem encontrar‑se em um ângulo.
  * Em um ponto suave, as duas alças de controle estão alinhadas e a mesma distância do ponto de ancoragem.
  * Em um ponto reto, as duas alças de controle estão alinhadas, mas podem ter distâncias diferentes do ponto de ancoragem.
* Mover pontos de ancoragem ou ajustar suas alças altera o contorno da forma.

Para editar formas do PowerPoint através de pontos de edição, **Aspose.Slides** fornece a classe [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) representa um caminho de geometria do objeto [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Para obter o [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) a partir da instância [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), você pode usar o método [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Para definir o [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) de uma forma, você pode usar estes métodos: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) para formas com um único caminho e [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) para formas com múltiplos caminhos.
* Para adicionar segmentos, você pode usar os métodos em [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Usando os métodos [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) e [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), você pode definir a aparência de um caminho de geometria.
* Usando o método [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), você pode obter o caminho de geometria de um [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) como um array de segmentos de caminho.
* Para acessar opções adicionais de personalização de geometria de forma, você pode ler um [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) através de seu [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e reproduzir os segmentos em um [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Operações Simples de Edição**

Use os métodos a seguir para editar um caminho de geometria. Sobrecargas que aceitam um índice inserem um segmento naquela posição baseada em zero no array de segmentos do caminho.

| Operação | Método |
| --- | --- |
| Anexar ou inserir uma linha reta. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Anexar ou inserir uma curva Bézier cúbica com dois pontos de controle e um ponto final. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Anexar ou inserir uma curva Bézier quadrática com um ponto de controle e um ponto final. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Anexar um arco elíptico com as dimensões e ângulos especificados em graus. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Fechar a figura atual conectando seu ponto final ao ponto inicial. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Definir o ponto inicial de uma figura. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Remover um segmento em um índice baseado em zero. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Adicionar Pontos Personalizados a uma Forma**

Este exemplo insere dois pontos em uma forma retangular usando [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) e aplica o caminho editado com [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). As coordenadas são locais à forma: ambos os novos pontos estão em seu centro, 100 pontos da esquerda e 50 pontos do topo. Os índices de segmento 1 e 4 os posicionam nas bordas superior e inferior, puxando essas bordas para dentro.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![exemplo1_imagem](custom_shape_1.png)

## **Remover Pontos de uma Forma**

Este exemplo altera o contorno de uma forma em forma de coração removendo o segmento no índice baseado em zero 2 com [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Aplicar o caminho modificado com [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) atualiza o contorno da forma.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![exemplo2_imagem](custom_shape_2.png)

## **Criar uma Forma Personalizada**

Este exemplo constrói uma estrela de cinco pontas com [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Raios externos e internos alternados de 100 e 50 pontos definem as pontas e as entalhes; um passo de 72 graus espaça uniformemente as cinco pontas. O caminho é fechado com [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) e aplicado a uma forma retangular usando [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), substituindo seu contorno.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![exemplo3_imagem](custom_shape_3.png)

## **Criar uma Forma Personalizada Composta**

Este exemplo define dois objetos [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) fechados para o terço superior e inferior de uma forma. Aplicar ambos os caminhos com [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) cria uma única forma composta com um espaço em seu terço central.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![exemplo4_imagem](custom_shape_4.png)

## **Criar uma Forma Personalizada com Cantos Curvos**

Este exemplo combina segmentos retos com [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) para criar uma forma com cantos curvos para dentro. Cada tamanho de canto define a largura e a altura do arco em pontos, e o varrimento de -90 graus desenha um quarto de elipse no sentido anti‑horário. O caminho concluído é aplicado com [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), e a apresentação é salva no formato PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Descobrir se a Geometria de uma Forma Está Fechada**

O auxiliar a seguir verifica se todo caminho de geometria não vazio termina com um segmento de fechamento. Ele lê [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) e compara o comando do segmento final [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) com [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Retorna false quando não há caminhos não vazios. Esta verificação analisa o comando final de cada caminho; não inspeciona cada sub‑figura dentro de um caminho. O exemplo imprime `true` para um retângulo.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Extrair e Inspecionar Elementos da Forma**

Use [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) para inspecionar uma forma existente como elementos contendo pontos de caminho e tipos de ponto. Use cada [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) retornado para recuperar os arrays de pontos e tipos por meio dos métodos [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) e [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Esta representação é útil para análise de contorno ou para passar a geometria a ferramentas de desenho personalizadas.

O exemplo abre input.pptx, encontra a primeira forma de geometria diretamente no primeiro slide e imprime seus segmentos de caminho. Use uma apresentação que contenha uma forma com segmentos retos e curvos para ver ambos os tipos de saída. Não procura dentro de grupos.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Manter o tipo de segmento, excluindo flags.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Os arrays correspondem por índice: `$points[$i]` é um ponto e `$types[$i]` descreve seu papel. O tipo `0` inicia uma figura, e o tipo `1` desenha uma linha do ponto anterior ao ponto atual. Um segmento Bézier cúbico inicia no ponto final anterior e usa três entradas consecutivas do tipo `3`: dois pontos de controle seguidos pelo novo ponto final. O loop consome essas três entradas juntas e verifica o ponto final para fechamento.

Tipos de ponto também contêm flags. Mascarar com `0x07` para identificar o tipo de segmento, e testar `0x80` separadamente para detectar um subcaminho fechado. Por exemplo, `129` (`0x81`) significa um ponto final de linha que fecha um subcaminho, e `131` (`0x83`) significa um ponto final Bézier que fecha um. A ponte PHP/Java devolve o array de bytes como string binária; desempacotar com "C*" produz valores de byte sem sinal. A máscara preserva os bits pretendidos. Comparar o valor bruto apenas com `1` ou `3` perderia esses casos. Outras flags, como traço (`0x10`) e marcador (`0x20`), não alteram o tipo básico do segmento.

**Coordenadas e transformações.** Os pontos são medidos em pontos (1/72 polegada), com X aumentando para a direita e Y aumentando para baixo. Para uma forma não agrupada, as coordenadas extraídas já incluem a posição retornada por [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) e [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) e refletem sua largura e altura atuais. Por exemplo, um retângulo não rotacionado em `(100, 200)` com tamanho `120 × 80` tem limites de contorno `(100, 200)`–`(220, 280)`. Não adicione a posição da forma novamente. Subtraia seu X e Y para obter coordenadas relativas ao seu quadro não rotacionado.

Os pontos extraídos não aplicam a rotação da forma, retornada por [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), nem as inversões horizontal e vertical. Para reproduzir o contorno exibido, aplique essas transformações em torno do centro da forma. Para formas agrupadas, considere também o mapeamento de coordenadas do grupo e as transformações; não presuma que os pontos extraídos sejam as coordenadas finais renderizadas no slide nem aplique uma translação ou escala duas vezes se já estiver refletida no quadro do filho.

**Inspeção versus edição.** Os arrays extraídos descrevem o contorno; alterá‑los não atualiza a forma original. Escolha esta abordagem quando sua análise ou código de desenho precisar dos arrays de ponto/tipo. Use [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) quando precisar de comandos de geometria no sistema de coordenadas local da forma ou quiser editar sua geometria. Aplique caminhos editados através de [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ou [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Converter uma Forma Java AWT para GeometryPath**

Este exemplo combina um contorno retangular com texto convertido em geometria. O método [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) do contorno desabilita seu preenchimento. Um [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) cria o contorno do texto em um [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Seu [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornece segmentos de movimento, linha, quadrático, cúbico e fechamento, que o exemplo reproduz em um [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

O exemplo usa um array de float Java para que a ponte PHP/Java mantenha as coordenadas escritas pelo iterador. O texto usa fonte Arial de 40 pontos. O contorno é deslocado 20 pontos horizontalmente e posicionado com seu topo visual 10 pontos abaixo da borda superior da forma. O caminho de texto é preenchido, enquanto o retângulo original permanece como contorno. Aplicar ambos os caminhos com [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) produz uma única forma contendo o retângulo e o texto.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![exemplo5_imagem](custom_shape_5.png)

## **FAQ**

**O que acontecerá com o preenchimento e contorno após substituir a geometria?**

O estilo permanece na forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como rotacionar corretamente uma forma personalizada juntamente com sua geometria?**

Use o método [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) da forma; a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em uma imagem para “travar” o resultado?**

Sim. Exporte a área da [slide](/slides/pt/php-java/convert-powerpoint-to-png/) necessária ou a própria [shape](/slides/pt/php-java/create-shape-thumbnails/) para um formato raster; isso simplifica trabalhos posteriores com geometrias complexas.