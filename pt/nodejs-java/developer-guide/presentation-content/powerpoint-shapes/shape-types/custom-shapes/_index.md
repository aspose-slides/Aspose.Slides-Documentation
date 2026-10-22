---
title: Personalizar formas de apresentação em JavaScript
linktitle: Forma personalizada
type: docs
weight: 20
url: /pt/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie e personalize formas em apresentações PowerPoint com JavaScript e Aspose.Slides para Node.js: caminhos de geometria, cantos curvos, formas compostas."
---
## **Visão geral**

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma por meio de pontos de edição e caminhos de geometria. Ele mostra como trabalhar com [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) para modificar formas existentes, executar operações básicas de edição de caminho, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Ele também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos, determinar se a geometria de uma forma está fechada, inspecionar elementos de forma e converter contornos de texto Java AWT em caminhos de geometria.

## **Alterar uma Forma Usando Pontos de Edição**

No PowerPoint, você pode usar **Edit Points** para modificar um quadrado:

* Mover um canto para dentro ou para fora.
* Ajustar a curvatura em um ponto.
* Adicionar novos pontos.

Editar pontos permite que você modifique o contorno de uma forma ou use uma forma existente como base para uma nova.

## **Dicas de Edição de Forma**

![overview_image](custom_shape_0.png)

Ao editar formas no PowerPoint, mantenha estes conceitos em mente:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* O caminho de uma forma consiste em pontos de ancoragem conectados por segmentos.
* Um segmento pode ser reto ou curvo. Pontos de ancoragem e alças de controle determinam sua forma.
* Pontos de ancoragem existem como pontos de canto, pontos retos ou pontos suaves:
  * Em um ponto de canto, segmentos adjacentes podem se encontrar em um ângulo.
  * Em um ponto suave, as duas alças de controle estão alinhadas e equidistantes do ponto de ancoragem.
  * Em um ponto reto, as duas alças de controle estão alinhadas mas podem ter distâncias diferentes do ponto de ancoragem.
* Mover pontos de ancoragem ou ajustar suas alças altera o contorno da forma.

Para editar formas do PowerPoint por meio de pontos de edição, **Aspose.Slides** fornece a classe [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) representa um caminho de geometria do objeto [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Para obter o [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) a partir da instância de [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), você pode usar o método [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Para definir o [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) de uma forma, você pode usar estes métodos: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) para formas com um único caminho e [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) para formas com múltiplos caminhos.
* Para adicionar segmentos, você pode usar os métodos sob [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Usando os métodos [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) e [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), você pode definir a aparência de um caminho de geometria.
* Usando o método [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), você pode recuperar o caminho de geometria de um [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) como um array de segmentos de caminho.
* Para acessar opções adicionais de personalização da geometria da forma, você pode ler um [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) por meio de seu [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e reproduzir os segmentos em um [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Operações Simples de Edição**

Use os seguintes métodos para editar um caminho de geometria. Sobrecargas que aceitam um índice inserem um segmento naquela posição baseada em zero no array de segmentos do caminho.

| Operação | Método |
| --- | --- |
| Anexar ou inserir uma linha reta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Anexar ou inserir uma curva cúbica Bézier com dois pontos de controle e um ponto final. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Anexar ou inserir uma curva quadrática Bézier com um ponto de controle e um ponto final. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Anexar um arco elíptico com as dimensões e ângulos especificados em graus. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Fechar a figura atual conectando seu ponto final ao ponto inicial. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Definir o ponto inicial de uma figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Remover um segmento em um índice baseado em zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Adicionar Pontos Personalizados a uma Forma**

Este exemplo insere dois pontos em uma forma retangular usando [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) e aplica o caminho editado com [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). As coordenadas são locais à forma: ambos os novos pontos estão em seu centro, 100 pontos a partir da esquerda e 50 pontos a partir do topo. Os índices de segmento 1 e 4 os posicionam nas bordas superior e inferior, puxando essas bordas para dentro.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Remover Pontos de uma Forma**

Este exemplo altera o contorno em forma de coração removendo o segmento no índice baseado em zero 2 com [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Aplicar o caminho modificado com [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) atualiza o contorno da forma.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Criar uma Forma Personalizada**

Este exemplo cria uma estrela de cinco pontas com [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Raios externos e internos alternados de 100 e 50 pontos definem as pontas e as reentrâncias; um passo de 72 graus espaça as cinco pontas uniformemente. O caminho é fechado com [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) e aplicado a uma forma retangular usando [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), substituindo seu contorno.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Criar uma Forma Personalizada Composta**

Este exemplo define dois objetos [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) fechados para o terço superior e inferior de uma forma. Aplicar ambos os caminhos com [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) cria uma única forma composta com uma lacuna atravessando seu terço central.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Criar uma Forma Personalizada com Cantos Curvos**

Este exemplo combina segmentos retos com [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) para criar uma forma com cantos curvos para dentro. Cada tamanho de canto define a largura e a altura do arco em pontos, e o varrimento de -90 graus desenha um quarto de elipse no sentido anti-horário. O caminho concluído é aplicado com [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) e a apresentação é salva no formato PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Descobrir Se a Geometria de uma Forma Está Fechada**

O auxiliar a seguir verifica se cada caminho de geometria não vazio termina com um segmento de fechamento. Ele lê [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) e compara o comando do segmento final [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) com [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Retorna false quando não há caminhos não vazios. Isso verifica o comando final de cada caminho; não inspeciona cada subfigura dentro de um caminho. O exemplo imprime `true` para um retângulo.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Extrair e Inspecionar Elementos de Forma**

Use [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) para inspecionar uma forma existente como elementos que contêm pontos de caminho e tipos de ponto. Use cada [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) retornado para recuperar os arrays de pontos e tipos por meio dos métodos [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) e [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Essa representação é útil para análise de contorno ou passagem de geometria para ferramentas de desenho personalizadas.

O exemplo abre input.pptx, encontra a primeira forma de geometria diretamente no primeiro slide e imprime seus segmentos de caminho. Use uma apresentação que contenha uma forma com segmentos retos e curvos para ver ambos os tipos de saída. Ele não pesquisa dentro de grupos.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Manter o tipo do segmento, excluindo sinalizadores.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consumir ambos os pontos de controle e o ponto final.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Os arrays correspondem por índice: `points[i]` é um ponto e `types[i]` descreve seu papel. O tipo `0` inicia uma figura, e o tipo `1` desenha uma linha do ponto anterior ao ponto atual. Um segmento cúbico Bézier começa no ponto final anterior e usa três entradas consecutivas de tipo `3`: dois pontos de controle seguidos do novo ponto final. O loop consome essas três entradas juntas e verifica o ponto final para fechamento.

Os tipos de ponto também contêm sinalizadores. Use a máscara `0x07` para identificar o tipo de segmento e teste `0x80` separadamente para detectar um subcaminho fechado. Por exemplo, `129` (`0x81`) significa um ponto final de linha que fecha um subcaminho, e `131` (`0x83`) significa um ponto final Bézier que fecha um. O Java armazena esses sinalizadores em bytes assinados; a máscara preserva os valores de bits pretendidos. Comparar o valor bruto apenas com `1` ou `3` perderia esses casos. Outros sinalizadores, como traço (`0x10`) e marcador (`0x20`), não alteram o tipo base do segmento.

**Coordenadas e transformações.** Os pontos são medidos em pontos (1/72 polegada), com X aumentando para a direita e Y aumentando para baixo. Para uma forma não agrupada, as coordenadas extraídas já incluem a posição retornada por [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) e [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) e refletem sua largura e altura atuais. Por exemplo, um retângulo não rotacionado em `(100, 200)` com tamanho `120 × 80` tem limites de contorno `(100, 200)`–`(220, 280)`. Não adicione novamente a posição da forma. Subtraia seu X e Y para obter coordenadas relativas ao seu quadro não rotacionado.

Os pontos extraídos não aplicam a rotação da forma, retornada por [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), nem os espelhamentos horizontal e vertical. Para reproduzir o contorno exibido, aplique essas transformações ao redor do centro da forma. Para formas agrupadas, também considere o mapeamento de coordenadas do grupo e transformações; não presuma que os pontos extraídos são as coordenadas finais renderizadas no slide ou aplique uma translação ou escala duas vezes se já estiver refletida no quadro do filho.

**Inspeção versus edição.** Os arrays extraídos descrevem o contorno; alterá‑los não atualiza a forma original. Escolha esta abordagem quando sua análise ou código de desenho precisar de arrays de ponto/tipo. Use [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) quando precisar de comandos de geometria no sistema de coordenadas local da forma ou quiser editar sua geometria. Aplique caminhos editados através de [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ou [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Converter uma Forma Java AWT para GeometryPath**

Este exemplo combina um contorno retangular com texto convertido em geometria. O método [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) do contorno desativa seu preenchimento. Um [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) cria o contorno do texto em um [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Seu [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornece segmentos de movimento, linha, quadrático, cúbico e fechamento, que o exemplo reproduz em um [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

A ponte Java usa valores explícitos de float e byte para os parâmetros Java correspondentes. O iterador grava coordenadas em um array de float Java; a reflexão lê seus valores atualizados de volta para JavaScript. O texto usa a fonte Arial de 40 pontos. O contorno é deslocado 20 pontos horizontalmente e posicionado com seu topo visual 10 pontos abaixo da borda superior da forma. O caminho de texto é preenchido, enquanto o retângulo original permanece como contorno. Aplicar ambos os caminhos com [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) produz uma única forma contendo o retângulo e o texto.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Mover para.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Linha para.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Curva Bézier quadrática.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Curva Bézier cúbica.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Fechar figura.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**O que acontecerá ao preenchimento e ao contorno após substituir a geometria?**

O estilo permanece na forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como girar corretamente uma forma personalizada junto com sua geometria?**

Use o método [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) da forma; a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em uma imagem para “travar” o resultado?**

Sim. Exporte a área de [slide](/slides/pt/nodejs-java/convert-powerpoint-to-png/) necessária ou a própria [forma](/slides/pt/nodejs-java/create-shape-thumbnails/) para um formato raster; isso simplifica o trabalho posterior com geometrias complexas.