---
title: Aplicar ou Alterar Layouts de Slide em Java
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/java/slide-layout/
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
- Java
- Aspose.Slides
description: "Gerencie e personalize layouts de slide no Aspose.Slides for Java. Explore tipos de layout, controle de espaços reservados e visibilidade de rodapé através de exemplos de código Java."
---
## **Introdução**

Um layout de slide define a disposição das caixas de espaço reservado e a formatação do conteúdo em um slide. Ele controla quais espaços reservados estão disponíveis e onde eles aparecem. Os layouts de slide ajudam a criar apresentações de forma rápida e consistente—seja para algo simples ou mais complexo. Alguns dos layouts de slide mais comuns no PowerPoint incluem:

**Layout de Slide de Título** – Inclui dois espaços reservados de texto: um para o título e outro para o subtítulo.

**Layout de Título e Conteúdo** – Apresenta um espaço reservado de título menor na parte superior e um maior abaixo para o conteúdo principal (como texto, marcadores, gráficos, imagens etc.).

**Layout em Branco** – Não contém espaços reservados, dando controle total para projetar o slide do zero.

Os layouts de slide fazem parte de um slide mestre, que é o slide de nível superior que define estilos de layout para a apresentação. Você pode acessar e modificar slides de layout através do slide mestre—por tipo, nome ou ID exclusivo. Alternativamente, pode editar um slide de layout específico diretamente na apresentação.

Para trabalhar com layouts de slide no Aspose.Slides for Java, você pode usar:

- Métodos como [getLayoutSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getLayoutSlides--) e [getMasters](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getMasters--) na classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/)
- Tipos como [ILayoutSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilayoutplaceholdermanager/) e [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para saber mais sobre como trabalhar com slides mestres, consulte o artigo [Slide Master](/slides/pt/java/slide-master/).
{{% /alert %}}

## **Adicionar Layouts de Slide às Apresentações**

Para personalizar a aparência e a estrutura dos seus slides, pode ser necessário adicionar novos slides de layout a uma apresentação. O Aspose.Slides for Java permite verificar se um layout específico já existe, adicioná‑lo caso necessário e usá‑lo para inserir slides baseados nesse layout.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
1. Acesse a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Verifique se o slide de layout desejado já existe na coleção. Se não existir, adicione o layout que precisar.
1. Adicione um slide vazio baseado no novo layout.
1. Salve a apresentação.

O código Java a seguir demonstra como acrescentar um layout de slide a uma apresentação PowerPoint:

```java
// Instanciar a classe Presentation que representa um arquivo PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Percorrer os tipos de slide de layout para selecionar um slide de layout.
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
        // Você também pode basear-se em um conjunto de tipos de formas de espaço reservado.
        // Por exemplo, um slide de Título deve ter apenas o tipo de espaço reservado Title, e assim por diante.
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

    // Adicionar um slide vazio usando o slide de layout adicionado.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Salvar a apresentação no disco.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remover Slides de Layout Não Utilizados**

O Aspose.Slides fornece o método [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) da classe [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/) para permitir a exclusão de slides de layout indesejados e não utilizados.

O código Java a seguir mostra como remover um slide de layout de uma apresentação PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adicionar Espaços Reservados a Layouts de Slide**

O Aspose.Slides fornece o método [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) que permite acrescentar novos espaços reservados a um slide de layout.

Esse gerenciador contém métodos para os seguintes tipos de espaço reservado:

| Placeholder do PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilayoutplaceholdermanager/) Method |
| -------------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

O código Java a seguir demonstra como acrescentar novas formas de espaço reservado ao layout em branco:

```java
Presentation presentation = new Presentation();
try {
    // Obter o slide de layout em branco.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Obter o gerenciador de espaços reservados do slide de layout.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Adicionar diferentes espaços reservados ao slide de layout em branco.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Adicionar um novo slide com o layout em branco.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The placeholders on the layout slide](add_placeholders.png)

## **Definir Visibilidade do Rodapé em um Slide de Layout**

Nas apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser exibidos ou ocultados dependendo do layout do slide. O Aspose.Slides for Java permite controlar a visibilidade desses espaços reservados de rodapé. Isso é útil quando você deseja que determinados layouts exibam informações de rodapé enquanto outros permanecem limpos e minimalistas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
1. Obtenha uma referência ao slide de layout pelo índice.
1. Defina o espaço reservado do rodapé do slide como visível.
1. Defina o espaço reservado do número do slide como visível.
1. Defina o espaço reservado de data/hora como visível.
1. Salve a apresentação.

O código Java a seguir mostra como definir a visibilidade do rodapé de um slide e executar as tarefas relacionadas:

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

## **Definir Visibilidade do Rodapé Filho para um Slide**

​Nas apresentações PowerPoint, elementos de rodapé como data, número do slide e texto personalizado podem ser controlados no nível do slide mestre para garantir consistência em todos os slides de layout. O Aspose.Slides for Java permite definir a visibilidade e o conteúdo desses espaços reservados de rodapé no slide mestre e propagar essas configurações a todos os slides de layout filho. Essa abordagem assegura informações de rodapé uniformes em toda a apresentação.​

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
1. Obtenha uma referência ao slide mestre pelo índice.
1. Defina os espaços reservados de rodapé do mestre e de todos os filhos como visíveis.
1. Defina os espaços reservados de número do slide do mestre e de todos os filhos como visíveis.
1. Defina os espaços reservados de data/hora do mestre e de todos os filhos como visíveis.
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

**Qual a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema geral e a formatação padrão, enquanto os slides de layout definem disposições específicas de espaços reservados para diferentes tipos de conteúdo.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim, você pode clonar um slide de layout da coleção de slides de layout de uma apresentação, acessível via o método [getLayoutSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getLayoutSlides--), e inseri‑lo em outra apresentação usando o método `addClone`.

**O que acontece se eu excluir um slide de layout que ainda é usado por um slide?**

Se você tentar excluir um slide de layout que ainda é referenciado por ao menos um slide na apresentação, o Aspose.Slides lançará uma [PptxEditException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pptxeditexception/). Para evitar isso, use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) que remove com segurança apenas os slides de layout que não estão em uso.