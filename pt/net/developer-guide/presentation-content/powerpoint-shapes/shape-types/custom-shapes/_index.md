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
- editar pontos
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

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma por meio de pontos de edição e caminhos de geometria. Ele mostra como trabalhar com [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) para modificar formas existentes, executar operações básicas de edição de caminho, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Ele também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos, determinar se a geometria de uma forma está fechada e usar a conversão legada entre [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) para cenários adicionais de personalização de geometria.

## **Alterar uma Forma Usando Pontos de Edição**

No PowerPoint, você pode usar **Pontos de Edição** para modificar um quadrado:

* Mover um canto para dentro ou para fora.
* Ajustar a curvatura em um ponto.
* Adicionar novos pontos.

Editar pontos permite que você modifique o contorno de uma forma ou use uma forma existente como base para uma nova.

## **Dicas de Edição de Forma**

![overview_image](custom_shape_0.png)

Ao editar formas do PowerPoint, tenha em mente estes conceitos:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* O caminho de uma forma consiste em pontos âncora conectados por segmentos.
* Um segmento pode ser reto ou curvo. Pontos âncora e alças de controle determinam sua forma.
* Pontos âncora existem como pontos de canto, pontos retos ou pontos suaves:
  * Em um ponto de canto, os segmentos adjacentes podem se encontrar em um ângulo.
  * Em um ponto suave, as duas alças de controle ficam alinhadas e a mesma distância do ponto âncora.
  * Em um ponto reto, as duas alças de controle ficam alinhadas, mas podem ter distâncias diferentes do ponto âncora.
* Mover pontos âncora ou ajustar suas alças altera o contorno da forma.

Para editar formas do PowerPoint por meio de pontos de edição, o **Aspose.Slides** fornece a classe [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e a interface [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) representa o caminho de geometria do objeto [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Para obter o [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a partir da instância de [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), você pode usar o método [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Para definir o [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) de uma forma, você pode usar estes métodos: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) para formas com um único caminho e [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) para formas com múltiplos caminhos.
* Para adicionar segmentos, você pode usar os métodos da [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Usando as propriedades [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) e [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), você pode definir a aparência de um caminho de geometria.
* Usando a propriedade [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), você pode obter o caminho de geometria de um [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) como um array de segmentos de caminho.
* Em versões legadas que suportam os métodos de conversão abaixo, você pode converter [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) para [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Use os métodos [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) e [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (da classe [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) para converter entre [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) e [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Operações Simples de Edição**

Use os métodos a seguir para editar um caminho de geometria. Sobrecargas que aceitam um índice inserem um segmento naquela posição baseada em zero no array de segmentos do caminho.

| Operação | Método |
| --- | --- |
| Anexar ou inserir uma linha reta. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Anexar ou inserir uma curva de Bézier cúbica com dois pontos de controle e um ponto final. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Anexar ou inserir uma curva de Bézier quadrática com um ponto de controle e um ponto final. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Anexar um arco elíptico com as dimensões e ângulos especificados em graus. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Fechar a figura atual conectando seu ponto final ao ponto inicial. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Definir o ponto inicial de uma figura. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Remover um segmento em um índice baseado em zero. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Adicionar Pontos Personalizados a uma Forma**

Este exemplo insere dois pontos em uma forma retangular usando [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) e aplica o caminho editado com [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). As coordenadas são locais à forma: ambos os novos pontos ficam em seu centro, 100 pontos da esquerda e 50 pontos do topo. Os índices de segmento 1 e 4 os posicionam nas bordas superior e inferior, puxando essas bordas para dentro.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Remover Pontos de uma Forma**

Este exemplo altera o contorno de um coração removendo o segmento no índice baseado em zero 2 com [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Aplicar o caminho modificado com [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) atualiza o contorno da forma.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Criar uma Forma Personalizada**

Este exemplo constrói uma estrela de cinco pontas com [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Raios externo e interno alternados de 100 e 50 pontos definem as pontas e as entalhes; um passo de 72 graus espaça uniformemente as cinco pontas. O caminho é fechado com [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) e aplicado a uma forma retangular usando [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), substituindo seu contorno.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Criar uma Forma Personalizada Composta**

Este exemplo define dois [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) fechados para o terço superior e inferior de uma forma. Aplicar ambos os caminhos com [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) cria uma única forma composta com um vão no terço do meio.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Criar uma Forma Personalizada com Cantos Curvos**

Este exemplo combina segmentos retos com [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) para criar uma forma com cantos curvos para dentro. Cada tamanho de canto define a largura e altura do arco em pontos, e o varrimento de -90 graus desenha um quarto de elipse no sentido anti‑horário. O caminho concluído é aplicado com [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), e a apresentação é salva no formato PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Descobrir Se a Geometria de uma Forma Está Fechada**

O helper a seguir verifica se cada caminho de geometria não vazio termina com um segmento de fechamento. Ele lê [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) e compara o comando do segmento final [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) com [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Retorna **false** quando não há caminhos não vazios. Essa verificação considera apenas o comando final de cada caminho; não inspeciona cada sub‑figura dentro de um caminho. O exemplo imprime `True` para um retângulo.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Extrair e Inspecionar Elementos da Forma**

Use [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) para inspecionar uma forma existente como elementos que contêm pontos de caminho e tipos de ponto. Converta cada [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) retornado para [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) a fim de ler seus arrays [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) e [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Essa representação é útil para análise de contorno ou para passar a geometria a ferramentas de desenho personalizadas.

O exemplo abre uma apresentação, encontra a primeira forma de geometria diretamente no primeiro slide e imprime seus segmentos de caminho. Use uma apresentação que contenha uma forma com segmentos retos e curvos para ver ambos os tipos de saída. Ele não pesquisa dentro de grupos.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Mantenha o tipo do segmento, excluindo flags.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Os arrays correspondem por índice: `points[i]` é um ponto e `types[i]` descreve seu papel. O tipo `0` inicia uma figura, e o tipo `1` desenha uma linha do ponto anterior ao ponto atual. Um segmento de Bézier cúbica inicia no ponto final anterior e usa três entradas consecutivas de tipo `3`: dois pontos de controle seguidos pelo novo ponto final. O loop consome essas três entradas juntas e verifica o ponto final para fechamento.

Tipos de ponto também contêm flags. Mascare com `0x07` para identificar o tipo de segmento e teste `0x80` separadamente para detectar um subcaminho fechado. Por exemplo, `129` (`0x81`) significa um ponto final de linha que fecha um subcaminho, e `131` (`0x83`) significa um ponto final de Bézier que o fecha. Comparar o valor bruto apenas com `1` ou `3` perderia esses casos. Outras flags, como dash (`0x10`) e marker (`0x20`), não alteram o tipo base do segmento.

**Coordenadas e transformações.** Os pontos são medidos em pontos (1/72 polegada), com X aumentando para a direita e Y aumentando para baixo. Para uma forma não agrupada, as coordenadas extraídas já incluem sua posição [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) e [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) e refletem sua largura e altura atuais. Por exemplo, um retângulo não rotacionado em `(100, 200)` com tamanho `120 × 80` tem limites de contorno `(100, 200)`–`(220, 280)`. Não adicione novamente a posição da forma. Subtraia seu X e Y para obter coordenadas relativas ao seu quadro não rotacionado.

Os pontos extraídos não aplicam a [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) da forma nem inversões horizontais ou verticais. Para reproduzir o contorno exibido, aplique essas transformações em torno do centro da forma. Para formas agrupadas, também leve em conta o mapeamento de coordenadas do grupo e suas transformações; não assume que os pontos extraídos são as coordenadas finais renderizadas no slide nem aplique uma translação ou escala duas vezes se já estiver refletida na moldura do filho.

**Inspeção versus edição.** Arrays extraídos descrevem o contorno; alterá‑los não atualiza a forma original. Use essa abordagem quando sua análise ou código de desenho precisar de arrays de ponto/tipo. Use [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) quando precisar de comandos de geometria no sistema de coordenadas local da forma ou quiser editar sua geometria. Aplique caminhos editados através de [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) ou [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Converter GeometryPath para GraphicsPath (System.Drawing.Drawing2D)**

O exemplo a seguir requer um assembly legado do Aspose.Slides for .NET que suporte [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), como a versão 25.10, e um ambiente Windows com `System.Drawing.Common`. Os métodos de conversão foram removidos na [versão 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Este exemplo combina um contorno retangular com texto convertido em geometria. O [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) do contorno é definido para desativar o preenchimento. Um [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) armazena o contorno do texto, que [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) converte em um caminho de geometria preenchido. Aplicar ambos os caminhos com [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) produz uma única forma contendo o retângulo e o texto. Para conversão no sentido oposto, use [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **Perguntas Frequentes**

**O que acontecerá com o preenchimento e o contorno após substituir a geometria?**

O estilo permanece associado à forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como rotacionar corretamente uma forma personalizada juntamente com sua geometria?**

Use a propriedade [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) da forma; a geometria rotaciona com a forma porque está vinculada ao seu próprio sistema de coordenadas.

**Posso converter uma forma personalizada em uma imagem para “travar” o resultado?**

Sim. Exporte a área da [slide](/slides/pt/net/convert-powerpoint-to-png/) necessária ou a própria [forma](/slides/pt/net/create-shape-thumbnails/) para um formato raster; isso simplifica trabalhos posteriores com geometrias complexas.