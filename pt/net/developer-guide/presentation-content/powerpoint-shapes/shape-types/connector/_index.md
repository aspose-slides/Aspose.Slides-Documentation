---
title: Gerenciar Conectores em Apresentações no .NET
linktitle: Conector
type: docs
weight: 10
url: /pt/net/connector/
keywords:
- conector
- tipo de conector
- ponto de conector
- linha de conector
- ângulo de conector
- ponto de conexão
- ponto de ajuste
- conectar formas
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como adicionar, anexar, redirecionar, ajustar e inspecionar conectores do PowerPoint retos, dobrados e curvos com Aspose.Slides para .NET."
---
## **Visão geral**

Um conector é uma linha que pode permanecer anexada a duas formas quando qualquer uma delas é movida. Suas extremidades se conectam a pontos de conexão, representados por pontos verdes no PowerPoint. Alguns conectores dobrados e curvos também expõem pontos de ajuste, representados por pontos laranjas, que controlam a posição de segmentos individuais do conector.

Aspose.Slides representa conectores por meio da interface [IConnector](https://reference.aspose.com/slides/pt/net/aspose.slides/iconnector/). Você pode criá‑los, anexar suas extremidades a formas, escolher pontos de conexão, redirecioná‑los e modificar a geometria de conectores que possuem pontos de ajuste.

## **Tipos de conector**

A enumeração [ShapeType](https://reference.aspose.com/slides/pt/net/aspose.slides/shapetype/) inclui predefinições de conectores retos, dobrados e curvos. A tabela a seguir mostra as geometrias de conectores disponíveis e o número de pontos de ajuste definidos por cada predefinição.

| Conector | Imagem | Número de pontos de ajuste |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

O número e o significado dos pontos de ajuste fazem parte da predefinição de conector selecionada. Não presuma que dois tipos diferentes de conector exponham a mesma estrutura de coleção.

## **Conectar duas formas**

Use [IShapeCollection.AddConnector](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addconnector/) para adicionar um conector e atribua suas propriedades [StartShapeConnectedTo](https://reference.aspose.com/slides/pt/net/aspose.slides/connector/startshapeconnectedto/) e [EndShapeConnectedTo](https://reference.aspose.com/slides/pt/net/aspose.slides/connector/endshapeconnectedto/). Depois que ambas as extremidades estiverem anexadas, [IConnector.Reroute](https://reference.aspose.com/slides/pt/net/aspose.slides/iconnector/reroute/) seleciona uma rota curta entre as formas.

O exemplo a seguir conecta uma elipse e um retângulo com um conector dobrado:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Aviso" %}}

Chamar `Reroute` pode alterar os valores de [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/pt/net/aspose.slides/connector/startshapeconnectionsiteindex/) e [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/pt/net/aspose.slides/connector/endshapeconnectionsiteindex/). Atribua pontos de conexão específicos após o redirecionamento se esses pontos precisarem permanecer fixos.

{{% /alert %}}

## **Escolher um ponto de conexão**

Cada forma conectável informa seu número de pontos por meio de [ConnectionSiteCount](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/connectionsitecount/). Valide um índice de ponto baseado em zero antes de atribuí‑lo a uma extremidade do conector; a contagem varia conforme a geometria da forma.

Este exemplo anexa o conector a um ponto específico na elipse quando esse ponto existir:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Ajustar um ponto do conector**

Conectores com pontos de ajuste os expõem por meio de [IGeometryShape.Adjustments](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometryshape/adjustments/). Inspecione cada [IAdjustValue](https://reference.aspose.com/slides/pt/net/aspose.slides/iadjustvalue/) e verifique seu [Type](https://reference.aspose.com/slides/pt/net/aspose.slides/adjustvalue/type/) antes de modificar seu [RawValue](https://reference.aspose.com/slides/pt/net/aspose.slides/adjustvalue/rawvalue/). As regras gerais para identificar ajustes de formas predefinidas estão descritas em [Shape Manipulation](/slides/pt/net/shape-manipulations/).

O número, a ordem, o significado e a faixa de valores válidos dos ajustes de conector dependem da predefinição do conector. A propriedade `Type` é somente‑leitura, enquanto o valor de ajuste pode ser escrito. A propriedade somente‑leitura [Name](https://reference.aspose.com/slides/pt/net/aspose.slides/adjustvalue/name/) fornece identificação adicional quando um conector contém mais de um ajuste do mesmo tipo semântico.

### **Roteiro ao redor de um obstáculo**

No layout a seguir, um conector `BentConnector5` entre duas formas passa por uma terceira forma:

![connector-obstruction](connector-obstruction.png)

Este código cria o conector obstruído:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

Mover a curvatura vertical altera a rota de modo que o conector contorne o obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Em vez de presumir que o índice da coleção `1` sempre representa a curvatura vertical, este exemplo procura por `ConnectorBendPositionY` e o altera somente quando o tipo semântico esperado está presente:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

Um `BentConnector5` possui dois ajustes `ConnectorBendPositionX` e um ajuste `ConnectorBendPositionY`. Se o tipo necessário aparecer mais de uma vez, inspecione `Name` e a geometria conhecida da predefinição antes de selecionar um. Se um ajuste relatar `ShapeAdjustmentType.Custom`, trate seu significado e faixa como específicos da predefinição e não o altere até que esse contrato seja conhecido.

## **Relacionar valores de ajuste à geometria do conector**

Para conectores dobrados, os valores de ajuste podem ser usados para estimar as posições de segmentos individuais. Esses cálculos são específicos da predefinição do conector:

- `BentConnector4` normalmente expõe um ajuste `ConnectorBendPositionX` e um ajuste `ConnectorBendPositionY`.
- Para essas posições, `RawValue / 100000f` produz a fração da largura ou altura da moldura do conector usada nos exemplos abaixo.
- A moldura do conector pode ser rotacionada ou invertida, portanto as coordenadas da moldura devem ser transformadas antes de serem comparadas com as coordenadas do slide.

Os exemplos a seguir utilizam `Type` para identificar primeiro os ajustes. Eles não tratam índices de coleção como identificadores portáteis.

### **Conector não rotacionado**

O layout inicial contém duas formas de texto conectadas por um `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Este exemplo inspeciona o conector e obtém seus ajustes de curvatura horizontal e vertical:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

Para alterar ambas as curvaturas, localize cada tipo esperado e modifique os valores somente depois que os dois forem encontrados:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

O resultado é um conector cujos segmentos horizontal e vertical foram movidos:

![connector-adjusted-1](connector-adjusted-1.png)

Uma vez conhecidos os tipos semânticos, seus valores podem ser convertidos em coordenadas da moldura do conector. Este exemplo desenha um retângulo fino sobre o segmento vertical controlado pelos dois ajustes de curvatura:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

A forma guia marca o segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector rotacionado ou invertido**

Quando a mesma geometria de conector está orientada verticalmente, seus valores [Frame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/pt/net/aspose.slides/shapeframe/fliph/) e [FlipV](https://reference.aspose.com/slides/pt/net/aspose.slides/shapeframe/flipv/) influenciam a conversão das coordenadas da moldura do conector para as coordenadas do slide.

Este exemplo cria e ajusta o conector orientado verticalmente:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

O conector ajustado aparece verticalmente entre as formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para um ângulo de rotação arbitrário `alpha`, rotacione um ponto da moldura do conector `(x, y)` ao redor do centro da moldura `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

O código a seguir trata da orientação de 90 graus usada neste exemplo e desenha um guia vermelho sobre o segmento correspondente do conector:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

O guia vermelho marca o segmento calculado após a transformação de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Essas fórmulas descrevem as predefinições usadas nos exemplos, não um modelo universal de conector. Valide os tipos de ajuste, a orientação da moldura e as faixas de valores antes de aplicar o mesmo cálculo a outra predefinição.

## **Encontrar o ângulo de direção de um conector**

A direção de um conector reto pode ser calculada a partir de sua largura e altura, com inversões horizontais e verticais aplicadas. O exemplo a seguir relata o ângulo horário a partir do eixo horizontal positivo nas coordenadas do slide:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **FAQ**

**Como posso saber se um conector pode ser anexado a uma forma?**

Verifique o `ConnectionSiteCount` da forma. Uma contagem positiva indica que a forma expõe pontos de conexão. Valide o índice de ponto selecionado antes de atribuí‑lo a qualquer extremidade do conector.

**Posso identificar um ajuste de conector pelo seu índice de coleção?**

Um índice só tem significado para uma predefinição de conector conhecida e sua estrutura de coleção. Verifique `IAdjustValue.Type` antes de modificar um valor e use `IAdjustValue.Name` como informação adicional quando o mesmo tipo semântico ocorrer mais de uma vez.

**O que acontece quando uma forma conectada é excluída?**

A extremidade correspondente do conector fica desanexada. O conector permanece no slide e pode ser excluído, posicionado como uma linha livre ou anexado a outra forma.

**As ligações de conector são preservadas ao copiar um slide?**

As ligações geralmente são preservadas quando as formas conectadas são copiadas com o slide. Se um conector for copiado sem uma de suas formas‑alvo, a extremidade afetada deverá ser anexada novamente.