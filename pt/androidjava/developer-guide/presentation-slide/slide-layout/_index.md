---
title: Aplicar ou Alterar Layouts de Slide no Android
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/androidjava/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- marcador de posição
- design de apresentação
- design de slide
- layout não usado
- visibilidade do rodapé
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
- Android
- Java
- Aspose.Slides
description: "Gerencie e personalize layouts de slide no Aspose.Slides para Android. Explore tipos de layout, controle de marcadores de posição e visibilidade do rodapé por meio de exemplos de código Java."
---
## **Introdução**

Um layout de slide define a disposição das caixas de espaço reservado e a formatação do conteúdo em um slide. Ele controla quais espaços reservados estão disponíveis e onde eles aparecem. Os layouts de slides ajudam você a criar apresentações rapidamente e de forma consistente — seja para algo simples ou mais complexo. Alguns dos layouts de slide mais comuns no PowerPoint incluem:

**Layout de Slide de Título** – Inclui dois espaços reservados de texto: um para o título e outro para o subtítulo.

**Layout de Título e Conteúdo** – Apresenta um espaço reservado de título menor no topo e um maior abaixo para o conteúdo principal (como texto, marcadores, gráficos, imagens etc.).

**Layout em Branco** – Não contém espaços reservados, permitindo total controle para projetar o slide do zero.

Os layouts de slides fazem parte de um slide mestre, que é o slide de nível superior que define estilos de layout para a apresentação. Você pode acessar e modificar slides de layout através do slide mestre — seja pelo tipo, nome ou ID exclusivo. Alternativamente, é possível editar um layout de slide específico diretamente na apresentação.

Para trabalhar com layouts de slides no Aspose.Slides para Android, você pode usar:

- Métodos como [getLayoutSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) e [getMasters](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getMasters--) na classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/)
- Tipos como [ILayoutSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) e [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para saber mais sobre como trabalhar com slides mestres, consulte o artigo [Slide Master](/slides/pt/androidjava/slide-master/).
{{% /alert %}}

## **Adicionar Layouts de Slides às Apresentações**

Para personalizar a aparência e a estrutura dos seus slides, pode ser necessário adicionar novos layouts de slide a uma apresentação. O Aspose.Slides para Android permite verificar se um layout específico já existe, adicioná‑lo caso necessário e usá‑lo para inserir slides com base nesse layout.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Acesse a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Verifique se o layout de slide desejado já existe na coleção. Caso não exista, adicione o layout de slide necessário.
1. Adicione um slide vazio baseado no novo layout de slide.
1. Salve a apresentação.

O código Java a seguir demonstra como adicionar um layout de slide a uma apresentação PowerPoint:

```java
// Instanciar a classe Presentation que representa um arquivo PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Percorra os tipos de slide de layout para selecionar um slide de layout.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Uma situação em que a apresentação não contém todos os tipos de layout.
        // O arquivo de apresentação contém apenas os tipos de layout Blank e Custom.
        // No entanto, slides de layout com tipos personalizados podem ter nomes reconhecíveis,
        // como "Title", "Title and Content", etc., que podem ser usados para a seleção de slide de layout.
        // Você também pode confiar em um conjunto de tipos de formas de espaço reservado.
        // Por exemplo, um slide de Title deve ter apenas o tipo de espaço reservado Title, e assim por diante.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Adicione um slide vazio usando o slide de layout adicionado.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Salve a apresentação no disco.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remover Layouts de Slides Não Utilizados**

O Aspose.Slides fornece o método [removeUnusedLayoutSlides](httpshttps://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) da classe [Compress](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/) para permitir que você exclua layouts de slide indesejados e não utilizados.

O código Java a seguir mostra como remover um layout de slide de uma apresentação PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Marcadores de Posição aos Layouts de Slides**

O Aspose.Slides fornece o método [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) que permite adicionar novos marcadores de posição a um layout de slide.

Esse gerenciador contém métodos para os seguintes tipos de marcadores de posição:

| Marcador de Posição do PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) Método |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

O código Java a seguir demonstra como adicionar novas formas de marcador de posição ao layout em Branco:

```java
Presentation presentation = new Presentation();
try {
    // Obter o slide de layout Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Obter o gerenciador de marcadores de posição do slide de layout.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Adicionar diferentes marcadores de posição ao slide de layout Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Adicionar um novo slide com o layout Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os marcadores de posição no layout do slide](add_placeholders.png)

## **Definir Visibilidade do Rodapé para um Layout de Slide**

Em apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser exibidos ou ocultados dependendo do layout do slide. O Aspose.Slides para Android permite controlar a visibilidade desses marcadores de posição de rodapé. Isso é útil quando você deseja que certos layouts exibam informações de rodapé enquanto outros permanecem limpos e minimalistas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência ao layout de slide pelo seu índice.
1. Defina o marcador de posição do rodapé do slide como visível.
1. Defina o marcador de posição do número do slide como visível.
1. Defina o marcador de posição da data/hora como visível.
1. Salve a apresentação.

O código Java a seguir mostra como definir a visibilidade do rodapé de um slide e realizar tarefas relacionadas:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Definir Visibilidade do Rodapé para Slides Filhos**

Em apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser controlados no nível do slide mestre para garantir consistência em todos os layouts de slide. O Aspose.Slides para Android permite definir a visibilidade e o conteúdo desses marcadores de posição de rodapé no slide mestre e propagar essas configurações para todos os layouts filhos. Essa abordagem assegura informações de rodapé uniformes em toda a apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência ao slide mestre pelo seu índice.
1. Defina os marcadores de posição de rodapé do mestre e de todos os filhos como visíveis.
1. Defina os marcadores de posição de número do slide do mestre e de todos os filhos como visíveis.
1. Defina os marcadores de posição de data/hora do mestre e de todos os filhos como visíveis.
1. Salve a apresentação.

O código Java a seguir demonstra essa operação:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual é a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema geral e a formatação padrão, enquanto os slides de layout definem arranjos específicos de espaços reservados para diferentes tipos de conteúdo.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim, você pode clonar um slide de layout da coleção de slides de layout de uma apresentação, acessível via o método [getLayoutSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getLayoutSlides--), e inseri‑lo em outra apresentação usando o método `addClone`.

**O que acontece se eu excluir um slide de layout que ainda está sendo usado por um slide?**

Se você tentar excluir um slide de layout que ainda é referenciado por ao menos um slide na apresentação, o Aspose.Slides lançará uma [PptxEditException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxeditexception/). Para evitar isso, use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) que remove com segurança apenas os layouts de slide que não estão em uso.