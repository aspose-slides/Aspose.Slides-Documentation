---
title: Personalizar Formas de Apresentação em Java
linktitle: Forma Personalizada
type: docs
weight: 20
url: /pt/java/custom-shape/
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
- Java
- Aspose.Slides
description: "Crie e personalize formas em apresentações PowerPoint com Aspose.Slides para Java: caminhos de geometria, cantos curvos, formas compostas."
---
## **Visão geral**

Este artigo explica como personalizar formas em apresentações no Aspose.Slides editando a geometria das formas por meio de pontos de edição e caminhos de geometria. Ele mostra como trabalhar com [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) para modificar formas existentes, executar operações básicas de edição de caminhos, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos, determinar se a geometria de uma forma está fechada, inspecionar elementos da forma e converter contornos de texto Java AWT em caminhos de geometria.

## **Alterar uma forma usando Pontos de edição**

No PowerPoint, você pode usar **Edit Points** para modificar um quadrado:

* Mover um canto para dentro ou para fora.
* Ajustar a curvatura em um ponto.
* Adicionar novos pontos.

Editar pontos permite modificar o contorno de uma forma ou usar uma forma existente como base para uma nova.

## **Dicas de edição de formas**

![overview_image](custom_shape_0.png)

Ao editar formas do PowerPoint, mantenha estes conceitos em mente:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* O caminho de uma forma consiste em pontos de ancoragem conectados por segmentos.
* Um segmento pode ser reto ou curvo. Pontos de ancoragem e alças de controle determinam sua forma.
* Pontos de ancoragem existem como pontos de canto, pontos retos ou pontos suaves:
  * Em um ponto de canto, segmentos adjacentes podem se encontrar em um ângulo.
  * Em um ponto suave, as duas alças de controle estão alinhadas e equidistantes do ponto de ancoragem.
  * Em um ponto reto, as duas alças de controle estão alinhadas, mas podem ter distâncias diferentes do ponto de ancoragem.
* Mover os pontos de ancoragem ou ajustar suas alças altera o contorno da forma.

Para editar formas do PowerPoint por meio de pontos de edição, **Aspose.Slides** fornece a classe [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) e a interface [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) representa o caminho de geometria do objeto [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Para obter o [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) de uma instância de [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), você pode usar o método [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Para definir o [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) de uma forma, você pode usar estes métodos: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) para formas com um único caminho e [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) para formas com múltiplos caminhos.
* Para adicionar segmentos, você pode usar os métodos da interface [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).
* Usando os métodos [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) e [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), você pode definir a aparência de um caminho de geometria.
* Usando o método [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--), você pode obter o caminho de geometria de um [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) como um array de segmentos de caminho.
* Para acessar opções adicionais de personalização de geometria de forma, você pode ler um [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) por meio de seu [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e reproduzir os segmentos em um [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Operações simples de edição**

Use os métodos a seguir para editar um caminho de geometria. Sobrecargas que aceitam um índice inserem um segmento na posição baseada em zero no array de segmentos do caminho.

| Operação | Método |
| --- | --- |
| Anexar ou inserir uma linha reta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Anexar ou inserir uma curva Bézier cúbica com dois pontos de controle e um ponto final. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Anexar ou inserir uma curva Bézier quadrática com um ponto de controle e um ponto final. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Anexar um arco elíptico com as dimensões e ângulos especificados em graus. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Fechar a figura atual conectando seu ponto final ao ponto inicial. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Definir o ponto inicial de uma figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Remover um segmento em um índice baseado em zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Adicionar pontos personalizados a uma forma**

Este exemplo insere dois pontos em uma forma retangular usando [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) e aplica o caminho editado com [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). As coordenadas são locais à forma: ambos os novos pontos estão no centro, 100 pontos da esquerda e 50 pontos do topo. Os índices de segmento 1 e 4 posicionam‑nos nas bordas superior e inferior, puxando essas bordas para dentro.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Remover pontos de uma forma**

Este exemplo altera o contorno de um coração removendo o segmento no índice baseado em zero 2 com [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Aplicar o caminho modificado com [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) atualiza o contorno da forma.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Criar uma forma personalizada**

Este exemplo constrói uma estrela de cinco pontas com [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Raios externos e internos alternados de 100 e 50 pontos definem as pontas e as entalhes; um passo de 72 graus distribui as cinco pontas uniformemente. O caminho é fechado com [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) e aplicado a uma forma retangular usando [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), substituindo seu contorno.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Criar uma forma personalizada composta**

Este exemplo define dois objetos [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) fechados para o terço superior e inferior de uma forma. Aplicar ambos os caminhos com [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) cria uma única forma composta com uma lacuna no seu terço do meio.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Criar uma forma personalizada com cantos curvos**

Este exemplo combina segmentos retos com [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) para criar uma forma com cantos curvos para dentro. Cada tamanho de canto define a largura e a altura do arco em pontos, e o arco de -90 graus gera um quarto de elipse no sentido anti‑horário. O caminho concluído é aplicado com [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), e a apresentação é salva no formato PPTX.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Descobrir se a geometria de uma forma está fechada**

O helper a seguir verifica se cada caminho de geometria não vazio termina com um segmento de fechamento. Ele lê [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) e compara o comando da última segmento [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) com [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Retorna false quando não há caminhos não vazios. Essa verificação analisa o comando final de cada caminho; não inspeciona cada sub‑figura dentro de um caminho. O exemplo imprime `true` para um retângulo.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Extrair e inspecionar elementos da forma**

Use [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) para inspecionar uma forma existente como elementos que contêm pontos de caminho e tipos de ponto. Converta cada [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) retornado para [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) para obter as matrizes de pontos e tipos por meio dos métodos [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) e [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--). Esta representação é útil para análise de contorno ou para passar a geometria a ferramentas de desenho personalizadas.

O exemplo abre `input.pptx`, encontra a primeira forma de geometria diretamente no primeiro slide e imprime seus segmentos de caminho. Use uma apresentação que contenha uma forma com segmentos retos e curvos para ver ambos os tipos de saída. Ele não procura dentro de grupos.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Manter o tipo de segmento, excluindo as bandeiras.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

As matrizes correspondem por índice: `points[i]` é um ponto e `types[i]` descreve seu papel. Tipo `0` inicia uma figura, e tipo `1` desenha uma linha do ponto anterior ao ponto atual. Um segmento Bézier cúbico começa no ponto final anterior e usa três entradas consecutivas de tipo `3`: dois pontos de controle seguidos do novo ponto final. O laço consome essas três entradas juntas e verifica o ponto final para fechamento.

Tipos de ponto também contêm bandeiras. Mascarar com `0x07` identifica o tipo de segmento, e testar `0x80` separadamente detecta um subcaminho fechado. Por exemplo, `129` (`0x81`) significa um ponto final de linha que fecha um subcaminho, e `131` (`0x83`) significa um ponto final Bézier que fecha um subcaminho. Java armazena essas bandeiras em bytes assinados; a máscara preserva os valores de bits pretendidos. Comparar o valor bruto apenas com `1` ou `3` perderia esses casos. Outras bandeiras, como traço (`0x10`) e marcador (`0x20`), não alteram o tipo básico do segmento.

**Coordenadas e transformações.** Pontos são medidos em pontos (1/72 polegada), com X aumentando para a direita e Y aumentando para baixo. Para uma forma não agrupada, as coordenadas extraídas já incluem a posição retornada por [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) e [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) e refletem sua largura e altura atuais. Por exemplo, um retângulo não rotacionado em `(100, 200)` com tamanho `120 × 80` tem limites de contorno `(100, 200)`‑`(220, 280)`. Não adicione novamente a posição da forma. Subtraia seu X e Y para obter coordenadas relativas ao seu quadro não rotacionado.

Os pontos extraídos não aplicam a rotação da forma, retornada por [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), nem os reflexos horizontal e vertical. Para reproduzir o contorno exibido, aplique essas transformações em torno do centro da forma. Para formas agrupadas, também considere o mapeamento de coordenadas do grupo e suas transformações; não presuma que os pontos extraídos sejam as coordenadas finais renderizadas no slide nem aplique uma translação ou escala duas vezes se já estiver refletida na moldura do filho.

**Inspeção versus edição.** Matrizes extraídas descrevem o contorno; alterá‑las não atualiza a forma original. Use essa abordagem quando sua análise ou código de desenho precisar de matrizes ponto/tipo. Use [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) quando precisar de comandos de geometria no sistema de coordenadas local da forma ou quiser editar sua geometria. Aplique caminhos editados através de [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ou [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Converter um Shape Java AWT para GeometryPath**

Este exemplo combina um contorno retangular com texto convertido em geometria. O método [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) do contorno desabilita seu preenchimento. Um [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) cria o contorno de texto em um [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Seu [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornece segmentos de movimento, linha, quadrático, cúbico e fechamento, que o exemplo reproduz em um [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

O texto usa a fonte Arial de 40 pontos. O contorno é deslocado 20 pontos horizontalmente e posicionado com seu topo visual 10 pontos abaixo da borda superior da forma. O caminho do texto é preenchido, enquanto o retângulo original permanece como contorno. Aplicar ambos os caminhos com [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) produz uma única forma contendo o retângulo e o texto.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Criar nova forma
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Obter o caminho de geometria da forma
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Criar novo caminho gráfico com texto
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Converter caminho gráfico para caminho de geometria
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Definir a combinação do novo caminho de geometria e do caminho de geometria original na forma
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**O que acontecerá com o preenchimento e o contorno após substituir a geometria?**

O estilo permanece na forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como rotacionar corretamente uma forma personalizada juntamente com sua geometria?**

Use o método [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) da forma; a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em uma imagem para “travar” o resultado?**

Sim. Exporte a área da [slide](/slides/pt/java/convert-powerpoint-to-png/) necessária ou a própria [forma](/slides/pt/java/create-shape-thumbnails/) para um formato raster; isso simplifica o trabalho posterior com geometrias complexas.