---
title: Obter Propriedades Efetivas de Formas de Apresentações em .NET
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/net/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- rig de iluminação
- forma chanfrada
- moldura de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como usar Aspose.Slides para .NET para distinguir a formatação local, herdada e efetiva de formas em apresentações do PowerPoint."
---
## **Entender Propriedades Locais, Herdadas e Efetivas**

A formatação do PowerPoint pode vir de vários lugares. O valor armazenado diretamente em um objeto é seu **valor local**. Se esse valor não estiver definido, o PowerPoint procura fontes de formatação pai, como o padrão de parágrafo, um estilo de texto, um layout ou slide mestre, um tema ou padrões a nível de apresentação. Esses valores são **valores herdados**. O valor que permanece após toda a hierarquia ser resolvida é o **valor efetivo** — o valor usado para renderizar o objeto.

Por exemplo, uma parte de texto pode não definir sua própria altura de fonte. Seu [FontHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseportionformat/fontheight/) local é então `float.NaN`, que significa "não definido aqui". A parte pode herdar uma altura do seu parágrafo, do estilo de texto padrão da apresentação ou de outra fonte aplicável. Chamar [GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/geteffective/) no formato da parte retorna a altura final resolvida.

Use os dois tipos de dados de formatação para propósitos diferentes:

- Leia ou altere um objeto de formato local, como [IPortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/), quando precisar controlar onde um valor é definido.
- Leia um objeto de dados efetivo, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformateffectivedata/), quando precisar do resultado final renderizado. Dados efetivos são somente leitura.

## **Comparar Valores Locais, Herdados e Efetivos**

O exemplo completo a seguir cria uma forma e aplica alturas de fonte nos níveis de apresentação, parágrafo e parte. Cada etapa imprime os valores definidos nesses níveis e o valor efetivo resultante para a mesma parte de texto. Também demonstra por que os dados efetivos devem ser lidos novamente após alterações de formatação.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Defina valores herdados em dois níveis diferentes.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Um valor local na parte substitui ambos os valores herdados.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Alterar um valor herdado não substitui um valor local existente.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Limpe o valor local. A parte agora herda novamente do parágrafo.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Limpe o valor do parágrafo. O padrão da apresentação agora fornece o resultado.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Leia os dados efetivos após as alterações precedentes.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

A prioridade neste exemplo é a formatação local da parte, depois a formatação do parágrafo e, por fim, o padrão da apresentação. Outros objetos podem ter cadeias de herança diferentes, mas o princípio é o mesmo: um valor explícito mais específico vence, e [GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/geteffective/) retorna o resultado final.

## **Obter Propriedades de Texto Efetivas**

A formatação de texto está dividida entre vários objetos:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframeformat/geteffective/) resolve propriedades da moldura de texto, como margens, ancoragem, ajuste automático e direção vertical do texto.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/pt/net/aspose.slides/itextstyle/geteffective/) resolve a formatação de parágrafo para cada nível de estilo de texto.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraphformat/geteffective/) resolve propriedades do parágrafo, como alinhamento, recuo e marcadores.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/pt/net/aspose.slides/iportionformat/geteffective/) resolve propriedades de caractere, como altura de fonte, família, cor, negrito e itálico.

Para o próximo exemplo, `text-formatting.pptx` deve conter ao menos um slide e uma [AutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) com uma moldura de texto não vazia. A AutoShape pode estar em qualquer posição na coleção de formas; o código procura um objeto adequado e o valida antes do uso.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Obter Propriedades 3D Efetivas**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformat/geteffective/) retorna um objeto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformateffectivedata/) que agrupa todas as configurações 3D resolvidas. Suas propriedades [Camera](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformateffectivedata/beveltop/) e [BevelBottom](https://reference.aspose.com/slides/pt/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) expõem os dados efetivos correspondentes. Ler essas configurações relacionadas em conjunto facilita a compreensão da aparência 3D final de uma forma.

Para este exemplo, `shape-3d.pptx` deve conter ao menos uma forma no seu primeiro slide. Aplique configurações de câmera 3D, iluminação ou chanfradura nessa forma se desejar que a saída contenha valores diferentes dos padrões.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Obter Formatação de Tabela Efetiva**

A formatação de tabela pode vir do estilo da tabela e de formatações aplicadas à tabela inteira, a uma coluna, a uma linha ou a uma célula individual. Em conflitos entre preenchimentos explicitamente definidos, a prioridade é célula, linha, coluna e depois tabela inteira. O formato efetivo de uma célula é o formato final usado para desenhá‑la.

Para este exemplo, `table-formatting.pptx` deve conter ao menos uma tabela no seu primeiro slide. A tabela deve ter ao menos uma linha e uma coluna. O código procura um [ITable](https://reference.aspose.com/slides/pt/net/aspose.slides/itable/) em vez de assumir que `Shapes[0]` é uma tabela.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Se precisar da cor ao invés apenas do tipo de preenchimento, primeiro verifique o [FillType](https://reference.aspose.com/slides/pt/net/aspose.slides/ifillformateffectivedata/filltype/) efetivo e, em seguida, leia a propriedade que se aplica a esse tipo — por exemplo, [SolidFillColor](https://reference.aspose.com/slides/pt/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) para um preenchimento sólido.

## **Re‑ler Dados Efetivos Após Alterações**

Dados efetivos descrevem a hierarquia de formatação no momento em que são resolvidos. Chame `GetEffective` novamente após alterar qualquer coisa que possa participar dessa hierarquia, incluindo:

- a formatação local do objeto;
- padrões de parágrafo ou de moldura de texto;
- um estilo de tabela, tabela, coluna, linha ou formato de célula;
- formatação de layout ou slide mestre;
- dados de tema ou padrões a nível de apresentação;
- o layout ou mestre atribuído a um slide.

Não mantenha um objeto de dados efetivo como uma captura permanente. Aspose.Slides pode armazenar alguns dados efetivos em cache internamente, e uma chamada posterior a `GetEffective` pode atualizar esses dados. Se precisar comparar valores antes e depois de uma mudança, copie os valores escalares que precisar — como altura de fonte, cor, alinhamento ou largura da chanfradura — para suas próprias variáveis antes de fazer a alteração.

Para mudar um valor, atualize o objeto de formato local apropriado e então chame `GetEffective` para verificar o resultado. Os próprios objetos de dados efetivos são somente leitura.

## **FAQ**

**Como posso saber qual nível forneceu um valor efetivo?**

Os dados efetivos contêm o valor final, não sua origem. Inspecione os objetos locais aplicáveis do nível mais específico para fora. Para texto, isso pode incluir a parte, o parágrafo, a moldura de texto, o layout, o mestre, o tema e os padrões da apresentação. Valores indefinidos como `float.NaN` ou `null` indicam que a busca continua em outro nível.

**O que acontece quando nenhum nível define uma propriedade?**

Aspose.Slides resolve o padrão apropriado do PowerPoint ou da biblioteca. Esse valor resolvido aparece nos dados efetivos mesmo que nenhum objeto local o tenha definido explicitamente.

**Por que um valor efetivo às vezes é igual ao valor local?**

O valor local venceu o cálculo de herança. Isso é esperado quando a propriedade está explicitamente definida no objeto e nenhuma regra mais específica a sobrescreve.

**Quando devo usar dados locais em vez de dados efetivos?**

Use dados locais para inspecionar ou editar um nível específico de formatação. Use dados efetivos quando precisar da aparência final após a herança, regras de tema e estilos aplicáveis terem sido resolvidos. O [exemplo completo de comparação](#compare-local-inherited-and-effective-values) demonstra ambos no mesmo fluxo de trabalho.