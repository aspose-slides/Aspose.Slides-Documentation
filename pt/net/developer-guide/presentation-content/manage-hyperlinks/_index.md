---
title: Gerenciar hyperlinks de apresentação em .NET
linktitle: Gerenciar hyperlinks
type: docs
weight: 20
url: /pt/net/manage-hyperlinks/
keywords:
- adicionar URL
- adicionar hyperlink
- criar hyperlink
- formatar hyperlink
- remover hyperlink
- atualizar hyperlink
- hyperlink de texto
- hyperlink de slide
- hyperlink de forma
- hyperlink de imagem
- hyperlink de vídeo
- hyperlink mutável
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Adicionar, formatar, atualizar e remover hyperlinks em apresentações PowerPoint e OpenDocument com Aspose.Slides para .NET, usando exemplos em C#."
---
## **Introdução**

Um hyperlink conecta o conteúdo da apresentação a um site ou a um local dentro da apresentação. No PowerPoint, os hyperlinks normalmente servem a dois propósitos:

* Abrir um site a partir de texto, forma ou moldura de mídia.
* Navegar para outro slide, por exemplo, a partir de um índice.

Aspose.Slides for .NET permite adicionar esses links, controlar sua aparência e som, atualizar suas propriedades e removê-los. Os exemplos abaixo mostram como trabalhar com hyperlinks em elementos individuais e como acessar hyperlinks no nível da apresentação, slide ou quadro de texto.

{{% alert color="info" title="Nota" %}}
Você também pode editar apresentações com o [editor online gratuito do Aspose PowerPoint](https://products.aspose.app/slides/pt/editor).
{{% /alert %}} 

## **Adicionar hyperlinks de URL**

Você pode atribuir uma URL de site a texto, forma ou moldura de mídia. O elemento ao qual você atribui o hyperlink determina a área clicável: uma parte de texto vincula o texto selecionado, enquanto uma forma ou moldura vincula o objeto do slide.

### **Adicionar hyperlinks de URL ao texto**

Para vincular texto a um site, atribua um [Hyperlink](https://reference.aspose.com/slides/pt/net/aspose.slides/hyperlink/) à propriedade [HyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/portionformat/hyperlinkclick/) da parte de texto, conforme mostrado abaixo. Apenas essa parte do texto se torna clicável.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Adicionar hyperlinks de URL a formas e molduras de mídia**

Para tornar uma forma ou moldura clicável, defina sua propriedade [HyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/hyperlinkclick/). O hyperlink pertence ao próprio objeto, e não a uma parte de texto dentro dele.

A mesma abordagem se aplica a molduras de imagem, áudio e vídeo: atribua o hyperlink à moldura e, se necessário, defina o [Tooltip](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/tooltip/) do link.

O exemplo a seguir torna um retângulo clicável:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Usar hyperlinks para criar um índice**

Hyperlinks internos permitem que o leitor pule de um índice para um slide específico. O exemplo a seguir usa [SetInternalHyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) para vincular o texto “Page 2” no primeiro slide ao segundo slide.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Formatar hyperlinks**

### **Cor**

A propriedade [ColorSource](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/colorsource/) de [IHyperlink](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/) determina se um hyperlink usa a cor de hyperlink da apresentação ou a formatação da parte de texto. Para aplicar uma cor de texto personalizada, selecione [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/hyperlinkcolorsource/) e defina a cor de preenchimento da parte. Esse recurso foi introduzido no PowerPoint 2019; versões mais antigas não aplicam essa configuração.

O exemplo a seguir adiciona dois hyperlinks de texto ao mesmo slide. O primeiro usa preenchimento de texto vermelho, enquanto o segundo mantém a cor padrão de hyperlink.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **Som**

Um hyperlink pode reproduzir um som ao ser ativado ou parar um som que já esteja sendo reproduzido. Use as propriedades abaixo para configurar esses comportamentos:

- [IHyperlink.Sound](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/sound/) especifica o áudio associado ao hyperlink.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/stopsoundonclick/) controla se a ativação do hyperlink interrompe o som anterior.

#### **Adicionar um som ao hyperlink**

O exemplo a seguir carrega `sampleaudio.wav` e o associa a um botão no primeiro slide. Clicar no botão reproduz o som e navega para o próximo slide. Uma segunda forma naquele slide interrompe o som anterior quando clicada, sem executar nenhuma ação de navegação.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Extrair o som de um hyperlink**

O exemplo a seguir abre a apresentação criada acima e lê o áudio do hyperlink da primeira forma para a memória através de [Sound](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/sound/) e [BinaryData](https://reference.aspose.com/slides/pt/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Configurações de Tooltip e Interação**

Você pode atualizar as propriedades a seguir de [IHyperlink] após atribuir um hyperlink a texto ou forma:

- [Tooltip](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/tooltip/) define o texto que o visualizador pode exibir como dica para o link.
- [TargetFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/targetframe/) especifica o quadro de destino dentro de um frameset HTML pai, quando aplicável.
- [History](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/history/) controla se a ativação do link adiciona seu destino à lista de hyperlinks visualizados.
- [HighlightClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/highlightclick/) controla se o hyperlink é destacado ao ser clicado.

## **Remover hyperlinks de apresentações**

Use [GetAnyHyperlinks](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) para coletar contêineres de hyperlink, incluindo links de partes de texto, antes de alterá‑los. O exemplo a seguir remove ambos os tipos de ativação do primeiro slide. Para remover apenas um tipo, chame somente [RemoveHyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ou [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); remover a ação de clique não remove seu equivalente mouse‑over.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Para remoção incondicional, [RemoveAllHyperlinks](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) elimina ambos os tipos de ativação no escopo selecionado em uma única chamada. Para limpeza seletiva e cobertura de mestres, layouts e notas, veja [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Criar um inventário completo de hyperlinks**

Antes de distribuir uma apresentação, faça um inventário de suas ações interativas e de seus links web. [GetAnyHyperlinks](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) devolve objetos [IHyperlinkContainer](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkcontainer/), não uma lista plana de strings de URL. Inspecione tanto [HyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) quanto [HyperlinkMouseOver](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) em cada contêiner. Eles são independentes: o mesmo contêiner pode expor ambas as ações, portanto um relatório completo precisa de até duas linhas por contêiner.

Escanear apenas hyperlinks em nível de forma pode deixar de detectar links anexados a partes de texto. Consulte o escopo apropriado e retenha os contêineres devolvidos para que você possa atualizar ou remover suas ações posteriormente.

### **Consultar escopos de apresentação, slide e quadro de texto**

A interface [IHyperlinkQueries](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/) está disponível através de [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/hyperlinkqueries/) e [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/hyperlinkqueries/). Cada escopo oferece as mesmas consultas:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) retorna contêineres com uma ação de clique.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) retorna contêineres com uma ação de mouse‑over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retorna contêineres com uma ou ambas as ações.

O exemplo a seguir cria `hyperlink-audit-input.pptx` com um link externo de clique, um link de mouse‑over de arquivo, navegação interna de slide, um link de mouse‑over de texto e uma ação de macro. Ele não executa nenhuma dessas ações. As três consultas funcionam em todos os escopos; as contagens descrevem contêineres, não o total de ações. O escopo de quadro de texto exclui os próprios links da forma que o contém.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Para este exemplo, as consultas de apresentação e slide relatam três contêineres de clique, dois de mouse‑over e três contêineres com qualquer ação. A consulta de quadro de texto relata um contêiner em cada categoria.

### **Classificar ações e destinos**

Use [IHyperlink.ActionType](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/actiontype/) para interpretar uma ação antes de interpretar seu destino. Os valores de [HyperlinkActionType](https://reference.aspose.com/slides/pt/net/aspose.slides/hyperlinkactiontype/) cobrem mais que navegação web:

| Valores | Significado para auditoria |
| --- | --- |
| `Hyperlink` | Hyperlink externo; inspecione a URL e seu esquema. |
| `JumpSpecificSlide` | Navegação interna para um slide específico. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navegação de slideshow incorporada, resolvida no contexto da apresentação. |
| `JumpEndShow`, `StartCustomSlideShow` | Encerrar a apresentação atual ou iniciar uma apresentação personalizada. |
| `StartMacro` | Executar uma macro. |
| `StartProgram` | Iniciar um programa. |
| `OpenFile`, `OpenPresentation` | Abrir um arquivo ou outra apresentação; revisar separadamente de URLs web. |
| `StartStopMedia` | Iniciar ou parar a reprodução de mídia. |
| `NoAction`, `Unknown` | Nenhuma ação de navegação, ou ação não reconhecida que requer revisão. |

Leia destinos externos de [ExternalUrl](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/externalurl/) e destinos internos específicos de [TargetSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/targetslide/). Ações internas e comandos incorporados podem não ter URL externa; uma URL vazia não significa que o contêiner não possua ação. Preserve [ExternalUrlOriginal](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/externalurloriginal/) quando for diferente da URL normalizada e inclua o [Tooltip](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlink/tooltip/) quando disponível.

### **Relatar, sanitizar e verificar hyperlinks**

O exemplo .NET 6+ a seguir lê uma apresentação existente (use o arquivo criado acima), grava `hyperlink-audit.json`, aplica uma política, salva `hyperlink-sanitized.pptx` e o reabre para verificar novamente ambos os tipos de ativação. Ele coleta contêineres antes de alterá‑los e usa igualdade de referência para evitar processar o mesmo contêiner duas vezes. Consultas de apresentação cobrem slides ordinários; para um inventário de todo o pacote, ele também consulta explicitamente mestres, layouts, notas e os mestres de notas e folhetos quando presentes.

O relatório registra um índice de slide baseado em 1 e [SlideId](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/slideid/) onde disponível. [ISlideComponent.Slide](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecomponent/slide/) fornece o slide proprietário para contêineres suportados. Mestres, layouts e notas não têm índice de slide ordinário e são identificados pelo seu escopo. Contêineres de forma e de formatação de parte de texto recebem rótulos separados; outros tipos de contêiner retêm seu nome de tipo em tempo de execução. Cada contêiner recebe um ID local ao relatório para que suas duas ações possam ser correlacionadas.

Esta política de aplicação deliberadamente restritiva permite apenas URLs HTTPS absolutas e destinos internos de slide válidos. Ela rejeita macros, programas, ações de arquivo, outras ações de slideshow, ações desconhecidas e outros esquemas de URL. Essas rejeições são decisões de política, não um veredicto de segurança do Aspose.Slides. HTTPS por si só não estabelece confiança: adicione listas de permissões de host e outras verificações para sua aplicação. Tanto URLs externas originais quanto normalizadas são verificadas. O exemplo audita metadados sem seguir links ou executar ações.

Para remediação, o [HyperlinkManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) do contêiner suporta [SetExternalHyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) e [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Aqui, links externos de clique proibidos são substituídos por uma página de destino HTTPS fixa; outros cliques proibidos e ações de mouse‑over proibidas são removidos independentemente. Defina `replaceExternalClicks` como `false` para remover todas as violações de política. Escolha uma página de substituição controlada pela aplicação antes da implantação.

A flag de exportação do relatório usa uma política conservadora de revisão PDF: sinaliza ações de mouse‑over e tudo que não seja um link externo ou salto de slide específico como potencialmente não suportado. É uma dica de revisão, não um teste de capacidade ou garantia de que links não sinalizados sobreviverão à exportação. Exportações suportadas para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/) e [HTML](/slides/pt/net/convert-powerpoint-to-html/) podem preservar hyperlinks, dependendo da ação, opções de exportação e visualizador. Imagens raster [images](/slides/pt/net/convert-powerpoint-to-png/) e [video](/slides/pt/net/convert-powerpoint-to-video/) não podem preservar hyperlinks interativos; sinalize toda ação ao auditar para esses resultados.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Com a entrada criada acima, o relatório contém cinco linhas de ação. O link de mouse‑over de arquivo e a macro de clique são removidos, enquanto os links HTTPS e a navegação interna de slide permanecem. A verificação imprime zero ações proibidas. Uma entrada contendo uma URL externa de clique proibida também exercita a ramificação de substituição. Um contêiner com clique permitido e mouse‑over proibido mantém sua ação de clique.

Essa limpeza seletiva difere de [RemoveAllHyperlinks](https://reference.aspose.com/slides/pt/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), que remove ambos os tipos de ativação em todo o escopo selecionado independentemente da política. A verificação aqui checa apenas as ações de hyperlink; não remove projetos VBA incorporados, objetos OLE ou outro conteúdo ativo, nem valida um PDF ou HTML exportado.

## **FAQ**

**Como posso vincular a uma seção ou ao seu primeiro slide?**

Seções no PowerPoint agrupam slides, mas um hyperlink interno aponta para um slide individual. Para criar navegação para uma seção, vincule ao primeiro slide dessa seção.

**Posso anexar um hyperlink a elementos do slide mestre para que funcione em todos os slides?**

Sim. Elementos de slide mestre e de layout suportam hyperlinks. Links nesses elementos ficam disponíveis durante a apresentação nos slides que utilizam o mestre ou layout correspondente.

**Os hyperlinks serão preservados ao exportar para PDF, HTML, imagens ou vídeo?**

Exportações de PDF e HTML suportadas podem preservar hyperlinks; imagens raster e vídeo não podem. Consulte as considerações de exportação em [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).