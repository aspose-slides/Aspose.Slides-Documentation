---
title: Gerenciar Mestres de Slides de Apresentação em .NET
linktitle: Mestre de Slide
type: docs
weight: 80
url: /pt/net/slide-master/
keywords:
- mestre de slide
- slide mestre
- slide mestre PPT
- vários slides mestres
- comparar slides mestres
- fundo
- marcador de posição
- clonar slide mestre
- copiar slide mestre
- duplicar slide mestre
- slide mestre não usado
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie mestres de slides no Aspose.Slides para .NET: acesse, edite, clone, compare e remova slides mestres em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide mestre** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide mestre é a forma usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for .NET oferece o mesmo modelo. Uma apresentação pode conter um ou mais slides mestres, e cada slide mestre pode conter vários slides de layout. Slides normais geralmente não referenciam um slide mestre diretamente. Em vez disso, um slide normal usa um slide de layout, e esse slide de layout pertence a um slide mestre.

A hierarquia é:

1. **Slide mestre** – define o design e tema compartilhados.  
1. **Slide de layout** – define um arranjo específico de marcadores de posição e formatação ao nível do layout.  
1. **Slide normal** – contém o conteúdo real da apresentação e usa um slide de layout.

![A hierarquia de slides mestres, slides de layout e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide mestre é representado pela interface [IMasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/). Todos os slides mestres de uma apresentação estão disponíveis através da coleção [Presentation.Masters](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide mestre e um slide de layout definirem um fundo, os slides baseados naquele layout usarão o fundo do layout. Para mais informações sobre slides de layout, veja [Aplicar ou Alterar Layouts de Slides](/slides/pt/net/slide-layout/).

{{% /alert %}}

## **Acessar Slides Mestres**

No PowerPoint, você pode abrir a visualização de Slide Mestre em **Exibir** > **Slide Mestre**.

![O comando Slide Mestre na guia Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `Masters` para acessar os slides mestres:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Você também pode obter o slide mestre usado por um slide normal através de seu layout:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **O que um Slide Mestre Contém**

Um slide mestre é um objeto semelhante a um slide. Ele implementa [IBaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Os membros específicos do mestre estão listados na página da API [IMasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/).

Membros de slide mestre usados com frequência incluem:

| Membro | Finalidade |
| --- | --- |
| `Background` | Define o fundo do slide ao nível do mestre. |
| `Shapes` | Armazena as formas colocadas no mestre, como logotipos, quadros de imagem e texto compartilhado. |
| `LayoutSlides` | Armazena os slides de layout que pertencem ao mestre. |
| `ThemeManager` | Fornece acesso às APIs de tema do mestre. |
| `HeaderFooterManager` | Controla cabeçalhos, rodapés, datas e numeração de slides para o mestre e seus layouts filhos. |
| `GetDependingSlides` | Retorna os slides normais que dependem do mestre por meio de seus layouts. |

## **Adicionar uma Imagem a um Slide Mestre**

Quando você adiciona uma imagem a um slide mestre, ela aparece nos slides que usam layouts desse mestre. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide mestre:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Para mais informações sobre quadros de imagem, veja [Quadro de Imagem](/slides/pt/net/picture-frame/).

## **Trabalhar com Marcadores de Posição**

Marcadores de posição são normalmente definidos em slides de layout. O slide mestre fornece o estilo e o tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde são colocados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização de Slide Mestre.

![O comando Inserir Marcador de Posição na visualização de Slide Mestre do PowerPoint](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o slide de layout que pertence ao mestre:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Você também pode formatar formas de marcador de posição que já existam em um slide mestre. O exemplo a seguir encontra o marcador de posição de título e aplica um preenchimento de gradiente linear:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Marcador de posição de título formatado, herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores de posição e texto, veja [Definir Texto de Prompt em Marcador de Posição](/slides/pt/net/manage-placeholder/) e [Formatação de Texto](/slides/pt/net/text-formatting/).

## **Alterar o Fundo de um Slide Mestre**

Um fundo de mestre é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de fundo sólida para o primeiro slide mestre:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Para assuntos relacionados, veja [Fundo da Apresentação](/slides/pt/net/presentation-background/) e [Tema da Apresentação](/slides/pt/net/presentation-theme/).

## **Clonar um Slide Mestre para Outra Apresentação**

Use [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection/addclone/) para copiar um slide mestre para outra apresentação. O mestre copiado pode então ser usado por layouts e slides na apresentação de destino.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Se precisar clonar slides normais junto com seu mestre, veja [Clonar Slides](/slides/pt/net/clone-slides/).

## **Adicionar Vários Slides Mestres**

Uma apresentação pode conter múltiplos slides mestres. Isso é útil quando diferentes seções exigem branding, estrutura de página ou configurações de tema distintas.

![Comandos do PowerPoint para inserir e gerenciar slides mestres](slide-master_9.jpg)

O exemplo a seguir clona o mestre padrão, atribui ao clone um fundo diferente, cria um layout sob esse mestre clonado e adiciona um novo slide baseado naquele layout:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Comparar Slides Mestres**

Slides mestres podem ser comparados com o método `Equals` herdado de [IBaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores de posição, como a data atual.

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Para mais informações, veja [Comparar Slides da Apresentação](/slides/pt/net/compare-slides/).

## **Definir a Visualização de Slide Mestre como Visualização Padrão**

Use a propriedade `LastView` em [ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização de Slide Mestre:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Para mais configurações de visualização, veja [Salvar Apresentação](/slides/pt/net/save-presentation/).

## **Remover Slides Mestres Não Utilizados**

Apresentações às vezes contêm slides mestres que não são mais usados por nenhum slide normal. Remover mestres não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/pt/net/aspose.slides/masterslidecollection/removeunused/) para remover mestres não utilizados da coleção `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Você também pode usar o método de low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Qual a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define configurações de design compartilhadas, como tema, fundo, formas comuns e estilos de texto. Um slide de layout pertence a um slide mestre e define um arranjo específico de marcadores de posição. Um slide normal usa um slide de layout, herdando tanto do layout quanto do mestre.

**Uma apresentação pode conter vários slides mestres?**

Sim. Uma apresentação pode conter vários slides mestres. Use múltiplos mestres quando diferentes seções precisam de sistemas visuais ou branding distintos.

**Devo adicionar marcadores de posição a um slide mestre ou a um slide de layout?**

Na maioria dos casos, adicione marcadores de posição a slides de layout. Coloque elementos visuais compartilhados e formatação comum no slide mestre e, em seguida, coloque os marcadores de posição de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um slide mestre que ainda está em uso?**

Não. Um slide mestre que tem slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro mestre ou use um método de limpeza de mestres não usados que remova apenas mestres que não estejam em uso.