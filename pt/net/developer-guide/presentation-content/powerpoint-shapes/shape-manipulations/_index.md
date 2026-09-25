---
title: Gerenciar formas de apresentação em .NET
linktitle: Manipulação de Formas
type: docs
weight: 40
url: /pt/net/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma de apresentação
- Forma no slide
- Encontrar forma
- Clonar forma
- Remover forma
- Ocultar forma
- Alterar ordem da forma
- Obter ID de forma Interop
- Texto alternativo da forma
- Ponto de ajuste da forma
- Ajuste de forma predefinido
- Geometria da forma
- Formatos de layout da forma
- Forma como SVG
- Forma para SVG
- Alinhar forma
- Espelhar forma
- PowerPoint
- Apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como identificar, ajustar, clonar, remover, ocultar, reorganizar, exportar, alinhar e espelhar formas de apresentação com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides for .NET representa as formas em um slide como uma [IShapeCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/) ordenada. A coleção é tanto o local onde você encontra e modifica formas quanto a fonte da ordem de empilhamento: o índice `0` é a forma mais ao fundo, enquanto o último índice é a forma mais à frente.

Este artigo segue esse modelo. Primeiro explica como identificar uma forma de forma confiável e modificar pontos de ajuste predefinidos, depois mostra como clonar, remover, ocultar e reorganizar formas. As seções finais cobrem formatação em nível de layout, exportação SVG, alinhamento e configurações de espelhamento. Cada exemplo é independente, de modo que você pode usar apenas as operações que seu fluxo de trabalho requer.

## **Identificar e localizar formas**

Os índices da coleção são convenientes ao processar um arquivo conhecido, mas não são identificadores estáveis. Adicionar, remover ou reordenar uma forma pode mudar seu índice. Escolha um identificador de acordo com a forma como a apresentação é criada e mantida:

- [Name](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/name/) é útil para modelos controlados por desenvolvedor e é fácil de inspeccionar no Painel de Seleção do PowerPoint. Nomes podem ser editados e não são garantidos como únicos, portanto estabeleça uma convenção de nomenclatura se o código depender deles.
- [AlternativeText](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/alternativetext/) é útil quando uma descrição de acessibilidade ou uma etiqueta fornecida pelo autor já identifica a forma. É visível para os usuários, pode ser localizado ou reescrito para acessibilidade e não é garantido como único. Não reutilize silenciosamente texto de acessibilidade significativo como chave de banco de dados.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/officeinteropshapeid/) é um identificador somente leitura que é único dentro de um slide e corresponde ao ID de forma usado pelo interop do PowerPoint. Use-o ao integrar com o PowerPoint ou quando precisar de uma referência inequívoca durante a vida útil de uma forma. Uma forma clonada ou recriada é uma forma diferente e recebe seu próprio ID.

A propriedade relacionada [UniqueId](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/uniqueid/) tem escopo de apresentação, mas destina‑se a complementos e pode ser reatribuída. Não deve ser tratada como uma chave externa permanente. Se a identidade a longo prazo for essencial, mantenha o mapeamento nos dados da aplicação e valide se a forma esperada ainda existe.

Para um exemplo prático de leitura e atualização tanto do título quanto da descrição do texto alternativo, consulte [Manage Alternative Text Titles and Descriptions](/slides/pt/net/presentation-accessibility/). Use texto alternativo para explicar o significado visual aos leitores e mantenha‑o separado dos nomes de forma usados pelo código para localizar formas.

O exemplo a seguir pesquisa por `Name` com comparação ordinal e relata o ID de interop com escopo de slide. Quando o modelo não contém a forma esperada, o código relata esse resultado em vez de continuar com o objeto errado.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Quando uma operação é específica a um tipo de forma, verifique a interface antes de usar membros específicos do tipo. Este exemplo atualiza texto e texto alternativo apenas se o objeto nomeado for um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Identificar e modificar ajustes de forma predefinidos**

Formas de geometria predefinida podem expor pontos de ajuste que controlam recursos como tamanho de cantos, proporções de setas ou ângulos de arcos. Acesse‑os através da coleção somente leitura [IGeometryShape.Adjustments](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometryshape/adjustments/). A própria coleção é fornecida pela forma, mas cada [IAdjustValue](https://reference.aspose.com/slides/pt/net/aspose.slides/iadjustvalue/) contém um valor que pode ser alterado.

Não confie apenas em um índice de coleção fixo. Itere pelos ajustes e inspecione a propriedade somente leitura [Type](https://reference.aspose.com/slides/pt/net/aspose.slides/adjustvalue/type/), cujo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/pt/net/aspose.slides/shapeadjustmenttype/) descreve o que o ajuste controla. A propriedade somente leitura [Name](https://reference.aspose.com/slides/pt/net/aspose.slides/adjustvalue/name/) fornece informações adicionais de identificação e é especialmente útil quando um preset contém mais de um ajuste com o mesmo tipo semântico.

Use a propriedade de valor que corresponde ao significado do ajuste:

| Tipo de ajuste | Propósito | Valor a alterar |
|---|---|---|
| `CornerSize` | Tamanho dos cantos arredondados | [RawValue](https://reference.aspose.com/slides/pt/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Espessura da cauda da seta | `RawValue` |
| `ArrowheadLength` | Comprimento da ponta da seta | `RawValue` |
| `ArrowheadWidth` | Largura da ponta da seta | `RawValue` |
| `StartAngle` | Ângulo inicial de uma fatia ou arco | [AngleValue](https://reference.aspose.com/slides/pt/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Ângulo final de uma fatia ou arco | `AngleValue` |

`Type` e `Name` não podem ser atribuídos. `RawValue` é um inteiro de leitura/escrita nas unidades nativas da geometria do preset, enquanto `AngleValue` é um ângulo de leitura/escrita em graus. O número, a ordem, o significado e o intervalo válido de ajustes dependem do preset [ShapeType](https://reference.aspose.com/slides/pt/net/aspose.slides/igeometryshape/shapetype/). Um valor válido para um preset pode ser inválido ou ter efeito diferente para outro.

Quando `Type` for `ShapeAdjustmentType.Custom`, a API não reconhece um significado semântico padrão. Inspecione `Name`, o tipo do preset e o valor existente, e deixe o ajuste inalterado a menos que o significado e o intervalo esperados sejam conhecidos. Mesmo para tipos reconhecidos, verifique se o mesmo tipo ocorre mais de uma vez antes de selecionar um valor. O artigo [Connector](/slides/pt/net/connector/) demonstra essa situação com ajustes de curvatura de conectores.

O exemplo completo a seguir cria versões padrão e modificadas de três formas predefinidas. Ele itera por cada ajuste, relata seu `Name` e `Type`, altera valores relacionados ao tamanho via `RawValue`, altera ângulos via `AngleValue` e salva o resultado. A coluna da esquerda mantém a geometria padrão; a coluna da direita mostra o retângulo arredondado ajustado, a seta de quatro direções e a fatia.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Adds headers for the default and adjusted shape columns.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Verificar o tipo semântico antes de mudar um valor deixa o código explícito quanto à sua intenção e evita assumir que um determinado índice de coleção tem o mesmo significado entre diferentes formas predefinidas.

## **Modificar a coleção de formas**

Os métodos de adicionar, clonar, remover e reordenar operam na coleção imediatamente. Se uma operação altera o número ou a ordem das formas, não continue a confiar em índices capturados antes dessa operação.

### **Clonar uma forma**

[AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addclone/) cria uma cópia independente e a anexa à coleção de destino. [InsertClone](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/insertclone/) também cria uma cópia, mas a posiciona em um índice de ordem z especificado. As sobrecargas que aceitam coordenadas movem o clone sem alterar seu tamanho; sobrecargas com largura e altura podem redimensioná‑lo também.

O exemplo cria um slide de destino, clona um retângulo rotulado para a frente e insere um segundo clone no fundo. Alterações em qualquer clone não modificam a forma origem.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Clonar copia o conteúdo e a formatação da forma, incluindo seu nome e texto alternativo. Atribua novos identificadores lógicos ao clone quando esses valores precisarem ser únicos. Recursos usados por formas complexas são tratados pela apresentação, mas um clone permanece um novo item da coleção com uma nova identidade de forma.

### **Remover formas**

[Remove](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/remove/) exclui um objeto de forma específico da sua coleção. Ao remover várias correspondências durante iteração indexada, percorra do final para que cada índice restante continue válido.

Este exemplo remove toda forma com um nome designado. Ele lê `slide.Shapes[i]`, não um item de coleção fixo, e não faz cast desnecessário da forma.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Após a remoção, a contagem de formas e os índices das formas posteriores mudam. Referências a formas não afetadas permanecem mais confiáveis que índices armazenados. Considere também conectores, animações e outros recursos da apresentação que possam referenciar o objeto removido; remover uma forma visível pode mudar mais do que a aparência do slide.

### **Ocultar uma forma**

Definir [Hidden](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/hidden/) como `true` mantém a forma na coleção, mas impede que ela apareça na apresentação normal. Seu índice, formatação e conteúdo permanecem disponíveis ao código, portanto ocultar é apropriado para elementos opcionais que podem ser restaurados posteriormente.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Ocultar não é exclusão nem segurança. O objeto ainda pode ser descoberto e desocultado por um usuário ou pelo código, e continua fazendo parte do arquivo da apresentação.

### **Alterar a ordem Z**

Formas sobrepostas são pintadas na ordem da coleção. [Reorder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/reorder/) move uma forma existente para um índice alvo sem cloná‑la. O índice `0` está atrás; `Count - 1` está à frente.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

O retângulo é criado primeiro e inicialmente fica atrás da elipse. Movê‑lo para o índice final coloca‑o à frente. Finalize a ordem Z após adicionar ou clonar todas as formas relacionadas, porque essas operações adicionam ou inserem novos itens na coleção e podem alterar a pilha pretendida.

## **Inspecionar formas em slides de layout**

Slides normais, slides de layout e slides mestre têm coleções de formas separadas. Uma forma em uma coleção de layout não é o mesmo objeto que uma forma posicionada de forma semelhante em um slide normal. Inspecione as formas de layout quando precisar entender ou mudar a formatação fornecida por um layout.

O exemplo a seguir lê o [FillFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/fillformat/) e o [LineFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/lineformat/) de cada forma de layout sem assumir que toda forma seja um `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Editar um layout pode afetar múltiplos slides que o utilizam. Antes de mudar uma forma de layout, determine se um slide normal herda o objeto ou contém uma sobrescrição local, e teste cada slide que usa aquele layout.

## **Exportar uma forma para SVG**

[WriteAsSvg](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/writeassvg/) grava o conteúdo renderizado de uma forma em um fluxo. O resultado contém a forma, não o fundo completo do slide ou formas vizinhas.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Mantenha a apresentação aberta durante a renderização. A saída depende da formatação da forma e de recursos como fontes e imagens. Se precisar de toda a composição, exporte o slide em vez de uma forma individual. O chamador possui o fluxo e deve descartá‑lo.

## **Alinhar formas**

Os overloads [SlideUtil.AlignShapes](https://reference.aspose.com/slides/pt/net/aspose.slides.util/slideutil/alignshapes/) alinham ou todas as formas ou índices de coleção selecionados. [ShapesAlignmentType](https://reference.aspose.com/slides/pt/net/aspose.slides/shapesalignmenttype/) especifica a borda, linha central ou modo de distribuição. Defina `alignToSlide` como `true` para usar as bordas do slide; defina como `false` para alinhar as formas selecionadas entre si.

Este exemplo alinha três formas à borda superior do slide. As referências de forma retornadas são convertidas para seus índices atuais imediatamente antes do alinhamento.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Alinhamento altera posições, não a ordem Z. Alinhamento relativo normalmente requer pelo menos duas formas, enquanto distribuição horizontal ou vertical requer formas suficientes para definir espaçamento. Recalcule os índices se modificar a coleção antes de chamar o método.

## **Espelhar uma forma**

A classe [ShapeFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/shapeframe/) armazena posição, tamanho, configurações de espelhamento horizontal e vertical e rotação. Seus valores `FlipH` e `FlipV` usam [NullableBool](https://reference.aspose.com/slides/pt/net/aspose.slides/nullablebool/): `True` habilita o espelhamento, `False` o desabilita e `NotDefined` preserva o estado não especificado/padrão.

A apresentação de entrada abaixo contém uma forma não espelhada.

![The shape before flipping](shape_to_be_flipped.png)

O exemplo preserva todos os demais valores de frame e substitui apenas as duas configurações de espelhamento. Isso é importante porque atribuir um novo [Frame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/frame/) substitui o frame completo.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

A forma salva é espelhada horizontal e verticalmente, mantendo sua posição, tamanho e rotação.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usar um índice de coleção como identificador de forma?**

Somente para processamento de curta duração quando a coleção não mudará antes do uso do índice. Prefira uma convenção validada de `Name` ou `AlternativeText` para modelos criados, ou `OfficeInteropShapeId` para trabalho de interop com escopo de slide.

**Ocultar uma forma a remove da ordem Z?**

Não. Uma forma ocultada permanece na coleção no mesmo índice. Ela pode ser encontrada, reordenada, editada ou tornada visível novamente.

**Por que uma forma clonada apareceu à frente de outra forma?**

`AddClone` anexa o clone ao final da coleção, que é a frente da ordem Z. Use `InsertClone` para escolher o índice inicial ou `Reorder` após todas as formas terem sido adicionadas.

**Posso usar um índice fixo para identificar um ajuste de forma predefinido?**

Somente após validar o preset exato e o layout da coleção. Prefira iterar por `IGeometryShape.Adjustments` e verificar `IAdjustValue.Type`; use `IAdjustValue.Name` como informação adicional quando o mesmo tipo semântico aparece mais de uma vez.