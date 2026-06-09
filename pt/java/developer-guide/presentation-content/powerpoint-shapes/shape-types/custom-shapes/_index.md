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
description: "Crie e personalize formas em apresentações do PowerPoint com Aspose.Slides for Java: caminhos de geometria, cantos curvos, formas compostas."
---
## **Visão geral**

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma por meio de pontos de edição e caminhos de geometria. Ele mostra como trabalhar com `GeometryPath` e `IGeometryPath` para modificar formas existentes, realizar operações básicas de edição de caminhos, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos, determinar se a geometria de uma forma está fechada e converter entre `GeometryPath` e `java.awt.Shape` para cenários adicionais de personalização de geometria.

## **Alterar uma forma usando pontos de edição**

Considere um quadrado. No PowerPoint, usando **pontos de edição**, você pode

* mover o canto do quadrado para dentro ou para fora
* especificar a curvatura de um canto ou ponto
* adicionar novos pontos ao quadrado
* manipular pontos no quadrado, etc.

Essencialmente, você pode executar as tarefas descritas em qualquer forma. Usando pontos de edição, você pode mudar uma forma ou criar uma nova forma a partir de uma forma existente.

## **Dicas de edição de formas**

![overview_image](custom_shape_0.png)

Antes de começar a editar formas do PowerPoint por meio de pontos de edição, considere estes pontos sobre formas:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* Quando uma forma está fechada, não possui ponto inicial ou final. Quando está aberta, tem um início e um fim. 
* Todas as formas consistem em pelo menos 2 pontos âncora ligados entre si por linhas
* Uma linha pode ser reta ou curva. Os pontos âncora determinam a natureza da linha. 
* Os pontos âncora existem como pontos de canto, pontos retos ou pontos suaves:
  * Um ponto de canto é um ponto onde 2 linhas retas se unem em um ângulo. 
  * Um ponto suave é um ponto onde 2 alças existem em linha reta e os segmentos da linha se unem em uma curva suave. Nesse caso, todas as alças são separadas do ponto âncora por uma distância igual. 
  * Um ponto reto é um ponto onde 2 alças existem em linha reta e os segmentos da linha se unem em uma curva suave. Nesse caso, as alças não precisam estar separadas do ponto âncora por uma distância igual. 
* Movendo ou editando os pontos âncora (o que altera o ângulo das linhas), você pode mudar a aparência da forma. 

Para editar formas do PowerPoint por meio de pontos de edição, **Aspose.Slides** fornece a [**GeometryPath**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath) e a interface [**IGeometryPath**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryPath).

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath) representa o caminho de geometria do objeto [IGeometryShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryShape). 
* Para obter o `GeometryPath` da instância `IGeometryShape`, use o método [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryShape#getGeometryPaths--). 
* Para definir o `GeometryPath` de uma forma, use estes métodos: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) para *formas sólidas* e [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) para *formas compostas*.
* Para adicionar segmentos, use os métodos da interface [IGeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryPath). 
* Usando os métodos [IGeometryPath.setStroke](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) e [IGeometryPath.setFillMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryPath#setFillMode-byte-), você pode definir a aparência de um caminho de geometria.
* Usando o método [IGeometryPath.getPathData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IGeometryPath#getPathData--), você pode recuperar o caminho de geometria de um `GeometryShape` como um array de segmentos de caminho. 
* Para acessar opções adicionais de personalização de geometria de forma, você pode converter [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath) para [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Use os métodos [geometryPathToGraphicsPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) e [graphicsPathToGeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (da classe [ShapeUtil](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapeUtil)) para converter [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath) para [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) e vice‑versa. 

## **Operações simples de edição**

Este código Java mostra como

**Adicionar uma linha** ao final de um caminho

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Adicionar uma linha** em uma posição especificada no caminho:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Adicionar uma curva Bézier cúbica** ao final de um caminho:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Adicionar uma curva Bézier cúbica** na posição especificada do caminho:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Adicionar uma curva Bézier quadrática** ao final de um caminho:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Adicionar uma curva Bézier quadrática** na posição especificada do caminho:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Anexar um arco** ao caminho:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Fechar a figura atual** do caminho:

``` java
public void closeFigure();
```
**Definir a posição para o próximo ponto**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Remover o segmento do caminho** em um índice específico:

``` java
public void removeAt(int index);
```

## **Adicionar pontos personalizados a uma forma**
1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryShape) e defina o tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapeType).  
2. Obtenha uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath) a partir da forma.  
3. Adicione um novo ponto entre os dois pontos superiores no caminho.  
4. Adicione um novo ponto entre os dois pontos inferiores no caminho.  
5. Aplique o caminho à forma.

Este código Java mostra como adicionar pontos personalizados a uma forma:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **Remover pontos de uma forma**

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryShape) e defina o tipo [ShapeType.Heart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapeType).  
2. Obtenha uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath) a partir da forma.  
3. Remova o segmento do caminho.  
4. Aplique o caminho à forma.

Este código Java mostra como remover pontos de uma forma:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

##  **Criar uma forma personalizada**

1. Calcule os pontos da forma.  
2. Crie uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath).  
3. Preencha o caminho com os pontos.  
4. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryShape).  
5. Aplique o caminho à forma.

Este Java mostra como criar uma forma personalizada:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}

```
![example3_image](custom_shape_3.png)


## **Criar uma forma personalizada composta**

  1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryShape).  
  2. Crie a primeira instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath).  
  3. Crie a segunda instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath).  
  4. Aplique os caminhos à forma.

Este código Java mostra como criar uma forma personalizada composta:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Criar uma forma personalizada com cantos curvos**

Este código Java mostra como criar uma forma personalizada com cantos curvos (para dentro);

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.closeFigure();

    childShape.setGeometryPath(geometryPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **Descobrir se a geometria de uma forma está fechada**

Uma forma fechada é definida como aquela cujos lados se conectam, formando um único contorno sem lacunas. Essa forma pode ser uma figura geométrica simples ou um contorno personalizado complexo. O exemplo de código a seguir mostra como verificar se a geometria de uma forma está fechada:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **Converter GeometryPath para java.awt.Shape** 

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryShape).  
2. Crie uma instância da classe [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
3. Converta a instância de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) para a instância de [GeometryPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/GeometryPath) usando a classe [ShapeUtil](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ShapeUtil).  
4. Aplique os caminhos à forma.

Este código Java—uma implementação das etapas acima—demonstra o processo de conversão de **GeometryPath** para **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Criar nova forma
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Obter o caminho de geometria da forma
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Criar novo caminho gráfico com texto
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Converter caminho gráfico para caminho de geometria
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Definir combinação do novo caminho de geometria e do caminho de geometria original na forma
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**O que acontecerá com o preenchimento e o contorno após substituir a geometria?**

O estilo permanece associado à forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como girar corretamente uma forma personalizada junto com sua geometria?**

Use o método da forma [setRotation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#setRotation-float-); a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em imagem para “travar” o resultado?**

Sim. Exporte a área da [slide](/slides/pt/java/convert-powerpoint-to-png/) requerida ou a própria [shape](/slides/pt/java/create-shape-thumbnails/) para um formato raster; isso simplifica trabalhos posteriores com geometrias complexas.