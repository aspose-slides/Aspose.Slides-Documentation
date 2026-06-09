---
title: Aplicar ou Alterar Layouts de Slides em .NET
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/net/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- espaço reservado
- design de apresentação
- design de slide
- layout não utilizado
- visibilidade de rodapé
- slide de título
- título e conteúdo
- cabeçalho de seção
- dois conteúdos
- comparação
- apenas título
- layout em branco
- conteúdo com legenda
- imagem com legenda
- título e texto vertical
- título vertical e texto
- PowerPoint
- OpenDocument
- apresentação
- C#
- .NET
- Aspose.Slides
description: "Gerencie e personalize layouts de slides no Aspose.Slides para .NET. Explore tipos de layout, controle de espaços reservados e visibilidade de rodapé através de exemplos de código C#."
---
## **Introdução**

Um layout de slide define a disposição das caixas de espaço reservado e a formatação do conteúdo em um slide. Ele controla quais espaços reservados estão disponíveis e onde eles aparecem. Os layouts de slide ajudam a criar apresentações de forma rápida e consistente — seja você criando algo simples ou mais complexo. Alguns dos layouts de slide mais comuns no PowerPoint incluem:

**Layout de Slide de Título** – Inclui dois espaços reservados de texto: um para o título e outro para o subtítulo.

**Layout de Título e Conteúdo** – Apresenta um espaço reservado de título menor no topo e um maior abaixo para o conteúdo principal (como texto, marcadores, gráficos, imagens e muito mais).

**Layout em Branco** – Não contém espaços reservados, dando total controle para desenhar o slide do zero.

Os layouts de slide fazem parte de um mestre de slide, que é o slide de nível superior que define os estilos de layout para a apresentação. Você pode acessar e modificar os slides de layout através do mestre de slide — seja por tipo, nome ou ID exclusivo. Alternativamente, pode editar um slide de layout específico diretamente na apresentação.

Para trabalhar com layouts de slide no Aspose.Slides para .NET, você pode usar:

- Propriedades como [LayoutSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/layoutslides/) e [Masters](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/masters/) na classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/)
- Tipos como [ILayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutplaceholdermanager/) e [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para saber mais sobre como trabalhar com mestres de slide, consulte o artigo [Slide Master](/slides/pt/net/slide-master/).
{{% /alert %}}

## **Adicionar Layouts de Slide às Apresentações**

Para personalizar a aparência e a estrutura dos seus slides, talvez seja necessário adicionar novos slides de layout a uma apresentação. O Aspose.Slides para .NET permite verificar se um layout específico já existe, adicioná‑lo caso necessário e usá‑lo para inserir slides com base nesse layout.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Acesse a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterlayoutslidecollection/).
1. Verifique se o slide de layout desejado já existe na coleção. Caso não exista, adicione o layout de slide necessário.
1. Adicione um slide vazio baseado no novo layout de slide.
1. Salve a apresentação.

O código C# a seguir demonstra como adicionar um layout de slide a uma apresentação PowerPoint:

```cs
// Instanciar a classe Presentation que representa um arquivo PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Percorrer os tipos de slides de layout para selecionar um slide de layout.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Uma situação em que a apresentação não contém todos os tipos de layout.
        // O arquivo de apresentação contém apenas os tipos de layout Blank e Custom.
        // No entanto, slides de layout com tipos personalizados podem ter nomes reconhecíveis,
        // como "Title", "Title and Content", etc., que podem ser usados para a seleção de slide de layout.
        // Você também pode contar com um conjunto de tipos de formas de espaço reservado.
        // Por exemplo, um slide de Título deve ter apenas o tipo de espaço reservado Title, e assim por diante.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Adicionar um slide vazio usando o slide de layout adicionado.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Salvar a apresentação no disco.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Remover Slides de Layout Não Utilizados**

O Aspose.Slides fornece o método [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) da classe [Compress](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/) para que você possa excluir slides de layout indesejados e não utilizados.

O código C# a seguir mostra como remover um slide de layout de uma apresentação PowerPoint:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Adicionar Espaços Reservados a Layouts de Slide**

O Aspose.Slides fornece a propriedade [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/placeholdermanager/), que permite acrescentar novos espaços reservados a um slide de layout.

Esse gerenciador contém métodos para os seguintes tipos de espaço reservado:

| Espaço Reservado do PowerPoint   | Método de [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutplaceholdermanager/) |
| -------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)          | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)    | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)          | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)              | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)              | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)        | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)              | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

O código C# a seguir demonstra como adicionar novas formas de espaço reservado ao slide de layout em Branco:

```cs
using (var presentation = new Presentation())
{
    // Obter o slide de layout em branco.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Obter o gerenciador de espaços reservados do slide de layout.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Adicionar diferentes espaços reservados ao slide de layout em branco.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Adicionar um novo slide com o layout em branco.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

O resultado:

![The placeholders on the layout slide](add_placeholders.png)

## **Definir Visibilidade do Rodapé para um Slide de Layout**

Em apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser exibidos ou ocultados dependendo do layout do slide. O Aspose.Slides para .NET permite controlar a visibilidade desses espaços reservados de rodapé. Isso é útil quando se deseja que determinados layouts mostrem informações de rodapé enquanto outros permanecem limpos e minimalistas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide de layout pelo seu índice.
1. Defina o espaço reservado de rodapé do slide como visível.
1. Defina o espaço reservado de número do slide como visível.
1. Defina o espaço reservado de data/hora como visível.
1. Salve a apresentação.

O código C# a seguir mostra como definir a visibilidade do rodapé de um slide e executar tarefas relacionadas:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Definir Visibilidade do Rodapé Filho para um Slide**

Em apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser controlados no nível do slide mestre para garantir consistência em todos os slides de layout. O Aspose.Slides para .NET permite definir a visibilidade e o conteúdo desses espaços reservados de rodapé no slide mestre e propagar essas configurações a todos os slides de layout filhos. Essa abordagem assegura informações de rodapé uniformes ao longo da apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide mestre pelo seu índice.
1. Defina os espaços reservados de rodapé do mestre e de todos os filhos como visíveis.
1. Defina os espaços reservados de número do slide do mestre e de todos os filhos como visíveis.
1. Defina os espaços reservados de data/hora do mestre e de todos os filhos como visíveis.
1. Salve a apresentação.

O código C# a seguir demonstra essa operação:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Qual a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema geral e a formatação padrão, enquanto os slides de layout definem arranjos específicos de espaços reservados para diferentes tipos de conteúdo.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim, você pode clonar um slide de layout da coleção [LayoutSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/layoutslides/) de uma apresentação e inseri‑lo em outra usando o método `AddClone`.

**O que acontece se eu excluir um slide de layout que ainda está sendo usado por um slide?**

Se você tentar excluir um slide de layout que ainda é referenciado por pelo menos um slide na apresentação, o Aspose.Slides lançará uma [PptxEditException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxeditexception/). Para evitar isso, use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), que remove com segurança apenas os slides de layout que não estão em uso.