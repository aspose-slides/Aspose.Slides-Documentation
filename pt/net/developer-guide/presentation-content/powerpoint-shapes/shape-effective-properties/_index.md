---
title: Obter propriedades efetivas de formas de apresentações em .NET
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/net/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- rig de luz
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como o Aspose.Slides para .NET calcula e aplica propriedades efetivas de forma para renderização precisa no PowerPoint."
---
## **Visão geral**

Este tópico explica a diferença entre propriedades **local** e **efetivas**. Valores locais são valores definidos diretamente em um nível específico de formatação, como:

1. Propriedades de porção em um slide.
1. Estilos de texto de forma de protótipo em um layout ou slide mestre, quando a forma de quadro de texto da porção possui um.
1. Configurações de texto globais em uma apresentação.

Valores locais podem ser definidos ou omitidos em qualquer nível. Quando o Aspose.Slides precisa da formatação final "como renderizada", ele resolve a cadeia de herança e retorna valores **efetivos**. Você pode obtê-los chamando o método `GetEffective` no objeto de formato local.

O exemplo a seguir mostra como obter valores efetivos. Ele assume que a primeira forma no primeiro slide é um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) com um quadro de texto e ao menos uma porção.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Os dados de formatação efetiva representam a formatação calculada atual após a aplicação da herança. Na implementação atual, alguns objetos de dados eficazes, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformateffectivedata/), podem ser armazenados em cache internamente. Chamar `GetEffective` novamente após alterar a formatação pai ou herdada pode atualizar o cache, e um objeto obtido anteriormente pode não representar mais o estado anterior. Se precisar preservar valores efetivos para reutilização posterior, copie as propriedades necessárias, como altura da fonte, cor de preenchimento, estilo da fonte ou alinhamento, para o seu próprio objeto de dados.
{{% /alert %}}

## **Obter propriedades efetivas de uma câmera**

O Aspose.Slides permite obter propriedades efetivas de uma câmera. A interface [ICameraEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/icameraeffectivedata/) representa um objeto imutável que contém propriedades efetivas da câmera. Uma instância de [ICameraEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/icameraeffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas para a câmera. Ele assume que a primeira forma no primeiro slide possui formatação 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Obter propriedades efetivas de um rig de luz**

O Aspose.Slides permite obter propriedades efetivas de um rig de luz. A interface [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ilightrigeffectivedata/) representa um objeto imutável que contém propriedades efetivas do rig de luz. Uma instância de [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ilightrigeffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas para o rig de luz. Ele assume que a primeira forma no primeiro slide possui formatação 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Obter propriedades efetivas de um chanfro de forma**

O Aspose.Slides permite obter propriedades efetivas de um chanfro de forma. A interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapebeveleffectivedata/) representa um objeto imutável que contém propriedades de relevo de faces efetivas para uma forma. Uma instância de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapebeveleffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/).

O exemplo de código a seguir mostra como obter propriedades efetivas para o chanfro superior de uma forma. Ele assume que a primeira forma no primeiro slide possui formatação 3D.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Obter propriedades efetivas de um quadro de texto**

O Aspose.Slides permite obter propriedades efetivas de um quadro de texto. A interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformateffectivedata/) contém propriedades de formatação efetiva do quadro de texto.

O exemplo de código a seguir mostra como obter propriedades de formatação efetiva do quadro de texto. Ele assume que a primeira forma no primeiro slide é um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) com um quadro de texto.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Obter propriedades efetivas de um estilo de texto**

O Aspose.Slides permite obter propriedades efetivas de um estilo de texto. A interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/itextstyleeffectivedata/) contém propriedades de estilo de texto efetivas.

O exemplo de código a seguir mostra como obter propriedades de estilo de texto efetivas. Ele assume que a primeira forma no primeiro slide é um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/) com um quadro de texto.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Obter o valor efetivo da altura da fonte**

O Aspose.Slides permite obter a altura da fonte efetiva. O código a seguir demonstra como a altura da fonte efetiva de uma porção muda após valores de altura de fonte locais serem definidos em diferentes níveis da estrutura da apresentação.

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Obter o formato de preenchimento efetivo para uma tabela**

O Aspose.Slides permite obter formatação de preenchimento efetiva para diferentes partes de uma tabela. A interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ifillformateffectivedata/) contém propriedades de formatação de preenchimento efetivas. A formatação de célula tem prioridade maior que a formatação de linha, que tem prioridade maior que a formatação de coluna, que tem prioridade maior que a formatação de tabela inteira.

Como resultado, as propriedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/icellformateffectivedata/) são usadas para desenhar a célula da tabela. O exemplo de código a seguir mostra como obter formatação de preenchimento efetiva para diferentes partes da tabela. Ele assume que a primeira forma no primeiro slide é um [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/).

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

**`GetEffective` retorna um instantâneo?**

Nem sempre. Dados efetivos representam a formatação calculada após a aplicação da herança, mas alguns objetos de dados efetivos podem ser armazenados em cache internamente. Uma chamada subsequente a `GetEffective` pode recalcular a formatação e atualizar o cache, portanto um objeto obtido anteriormente não deve ser tratado como um instantâneo permanente.

**Quando devo ler as propriedades efetivas novamente?**

Chame `GetEffective` novamente após alterar a formatação local, estilos pai, formatação de layout, formatação mestre ou padrões ao nível da apresentação. A chamada seguinte reavalia a hierarquia de formatação e retorna o resultado efetivo atual.

**Alterar ou remover um slide de layout/mestre afeta as propriedades efetivas que já foram obtidas?**

Sim, mas a alteração só se reflete na próxima chamada a `GetEffective`. Se uma fonte de formatação pai for alterada ou removida, os dados efetivos obtidos anteriormente podem estar desatualizados. Quando `GetEffective` for chamado novamente, o Aspose.Slides reavalia a árvore de formatação e as fontes, cores, tamanhos ou outros valores resultantes podem mudar.

**Posso modificar valores através de objetos de dados efetivos?**

Não. Objetos de dados efetivos expõem apenas valores calculados. Faça alterações nos objetos de formatação local e, em seguida, obtenha os valores efetivos novamente.

**O que acontece se uma propriedade não estiver definida no nível da forma, nem no layout/mestre, nem nas configurações globais?**

O valor efetivo é determinado pelo mecanismo padrão, que inclui os padrões do PowerPoint e do Aspose.Slides. Esse valor resolvido passa a fazer parte dos dados efetivos atuais.

**A partir de um valor de fonte efetivo, posso saber qual nível forneceu o tamanho ou a família?**

Não diretamente. Os dados efetivos retornam o valor final. Para descobrir a origem, verifique os valores locais na porção, parágrafo, quadro de texto e estilos de texto nos níveis de layout, mestre e apresentação para identificar onde aparece a primeira definição explícita.

**Por que os valores efetivos às vezes parecem idênticos aos locais?**

Porque o valor local acabou sendo final (não foi necessária herança de nível superior). Nestes casos, o valor efetivo corresponde ao local.

**Quando devo usar propriedades efetivas e quando devo trabalhar apenas com as locais?**

Use dados efetivos quando precisar do resultado "como renderizado" após todas as heranças serem aplicadas, como para alinhar cores, recuos ou tamanhos. Se precisar preservar esses valores independentemente de mudanças de formatação posteriores, copie as propriedades necessárias para seu próprio objeto. Se precisar alterar a formatação em um nível específico, modifique as propriedades locais e, se necessário, leia os dados efetivos novamente para verificar o resultado.