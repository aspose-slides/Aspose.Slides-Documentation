---
title: Personalizar Formas de Apresentação em .NET
linktitle: Forma Personalizada
type: docs
weight: 20
url: /pt/net/custom-shape/
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
- .NET
- C#
- Aspose.Slides
description: "Crie e personalize formas em apresentações PowerPoint com Aspose.Slides para .NET: caminhos de geometria, cantos curvos, formas compostas."
---
## **Visão geral**

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma por meio de pontos de edição e caminhos de geometria. Ele mostra como trabalhar com `GeometryPath` e `IGeometryPath` para modificar formas existentes, executar operações básicas de edição de caminho, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Ele também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos, determinar se a geometria de uma forma está fechada e converter entre `GeometryPath` e `GraphicsPath` para cenários adicionais de personalização de geometria.

## **Alterar uma Forma Usando Pontos de Edição**

Considere um quadrado. No PowerPoint, usando **pontos de edição**, você pode 

* mover o canto do quadrado para dentro ou para fora
* especificar a curvatura de um canto ou ponto
* adicionar novos pontos ao quadrado
* manipular pontos no quadrado, etc. 

Essencialmente, você pode executar as tarefas descritas em qualquer forma. Usando pontos de edição, você pode alterar uma forma ou criar uma nova forma a partir de uma forma existente. 

## **Dicas de Edição de Forma**

![overview_image](custom_shape_0.png)

Antes de começar a editar formas do PowerPoint através de pontos de edição, você pode querer considerar estes pontos sobre formas:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* Todas as formas consistem de pelo menos 2 pontos de ancoragem ligados entre si por linhas.
* Uma linha pode ser reta ou curva. Os pontos de ancoragem determinam a natureza da linha. 
* Os pontos de ancoragem existem como pontos de canto, pontos retos ou pontos suaves:
  * Um ponto de canto é um ponto onde 2 linhas retas se juntam em um ângulo. 
  * Um ponto suave é um ponto onde 2 alças existem em uma linha reta e os segmentos da linha se juntam em uma curva suave. Nesse caso, todas as alças são separadas do ponto de ancoragem por uma distância igual. 
  * Um ponto reto é um ponto onde 2 alças existem em uma linha reta e os segmentos dessa linha se juntam em uma curva suave. Nesse caso, as alças não precisam ser separadas do ponto de ancoragem por uma distância igual. 
* Ao mover ou editar pontos de ancoragem (que alteram o ângulo das linhas), você pode mudar a aparência de uma forma. 

Para editar formas do PowerPoint através de pontos de edição, **Aspose.Slides** fornece a classe [**GeometryPath**](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath) e a interface [**IGeometryPath**](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometrypath).

* Uma [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath) instância representa um caminho de geometria do objeto [IGeometryShape](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometryshape).
* Para obter o`GeometryPath` da instância `IGeometryShape`, você pode usar o método [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* Para definir o `GeometryPath` para uma forma, você pode usar estes métodos: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometryshape/methods/setgeometrypath) para *formas sólidas* e [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometryshape/methods/setgeometrypaths) para *formas compostas*.
* Para adicionar segmentos, você pode usar os métodos em [IGeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometrypath).
* Usando as propriedades [IGeometryPath.Stroke](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometrypath/properties/stroke) e [IGeometryPath.FillMode](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometrypath/properties/fillmode), você pode definir a aparência de um caminho de geometria.
* Usando a propriedade [IGeometryPath.PathData](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometrypath/properties/pathdata), você pode recuperar o caminho de geometria de um `GeometryShape` como um array de segmentos de caminho.
* Para acessar opções adicionais de personalização da geometria da forma, você pode converter [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath) para [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* Use [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/pt/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) e [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) métodos (da classe [ShapeUtil](https://reference.aspose.com/slides/pt/net/aspose.slides.util/shapeutil)) para converter [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath) para [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) e vice‑versa. 

## **Operações Simples de Edição**

Este código C# mostra como

**Adicionar uma linha** ao final de um caminho

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Adicionar uma linha** a uma posição especificada em um caminho:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Adicionar uma curva Bézier cúbica** ao final de um caminho:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Adicionar uma curva Bézier cúbica** à posição especificada em um caminho:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Adicionar uma curva Bézier quadrática** ao final de um caminho:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Adicionar curva Bézier quadrática** a uma posição especificada em um caminho:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Anexar um arco especificado** a um caminho:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Fechar a figura atual** de um caminho:

``` csharp
void CloseFigure();
```
**Definir a posição para o próximo ponto**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Remover o segmento de caminho** em um índice específico:

``` csharp
void RemoveAt(int index);
```

## **Adicionar Pontos Personalizados a uma Forma**

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/net/aspose.slides/geometryshape) e defina o tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/pt/net/aspose.slides/shapetype).
2. Obtenha uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath) a partir da forma.
3. Adicione um novo ponto entre os dois pontos superiores no caminho.
4. Adicione um novo ponto entre os dois pontos inferiores no caminho.
5. Aplique o caminho à forma.

Este código C# mostra como adicionar pontos personalizados a uma forma:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

## **Remover Pontos de uma Forma**

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/net/aspose.slides/geometryshape) e defina o tipo [ShapeType.Heart](https://reference.aspose.com/slides/pt/net/aspose.slides/shapetype).
2. Obtenha uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath) a partir da forma.
3. Remova o segmento do caminho.
4. Aplique o caminho à forma.

Este código C# mostra como remover pontos de uma forma:

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

## **Criar uma Forma Personalizada**

1. Calcule os pontos da forma.
2. Crie uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath).
3. Preencha o caminho com os pontos.
4. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/net/aspose.slides/geometryshape).
5. Aplique o caminho à forma.

Este C# mostra como criar uma forma personalizada:

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![example3_image](custom_shape_3.png)

## **Criar uma Forma Personalizada Composta**

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/net/aspose.slides/geometryshape).
2. Crie a primeira instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath).
3. Crie a segunda instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath).
4. Aplique os caminhos à forma.

Este código C# mostra como criar uma forma personalizada composta:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![example4_image](custom_shape_4.png)

## **Criar uma Forma Personalizada com Cantos Curvos**

Este código C# mostra como criar uma forma personalizada com cantos curvos (para dentro);

```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Descobrir se a Geometria de uma Forma Está Fechada**

Uma forma fechada é definida como aquela em que todos os seus lados se conectam, formando um único contorno sem lacunas. Essa forma pode ser uma forma geométrica simples ou um contorno personalizado complexo. O exemplo de código a seguir mostra como verificar se a geometria de uma forma está fechada:

```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **Converter GeometryPath para GraphicsPath (System.Drawing.Drawing2D)** 

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/net/aspose.slides/geometryshape).
2. Crie uma instância da classe [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) do namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Converta a instância [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) para a instância [GeometryPath](https://reference.aspose.com/slides/pt/net/aspose.slides/geometrypath) usando [ShapeUtil](https://reference.aspose.com/slides/pt/net/aspose.slides.util/shapeutil).
4. Aplique os caminhos à forma.

Este código C# — uma implementação dos passos acima — demonstra o processo de conversão de **GeometryPath** para **GraphicsPath**:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**O que acontecerá com o preenchimento e o contorno após substituir a geometria?**

O estilo permanece com a forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como rotacionar corretamente uma forma personalizada juntamente com sua geometria?**

Use a propriedade de [rotation](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/rotation/) da forma; a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em uma imagem para “travar” o resultado?**

Sim. Exporte a área de [slide](/slides/pt/net/convert-powerpoint-to-png/) requerida ou a própria [shape](/slides/pt/net/create-shape-thumbnails/) para um formato raster; isso simplifica o trabalho posterior com geometrias pesadas.