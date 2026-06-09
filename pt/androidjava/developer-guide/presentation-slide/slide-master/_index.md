---
title: Gerenciar slides master de apresentação no Android
linktitle: Slide Master
type: docs
weight: 70
url: /pt/androidjava/slide-master/
keywords:
- slide master
- master slide
- slide master PPT
- vários slides master
- comparar slides master
- fundo
- marcador de posição
- clonar slide master
- copiar slide master
- duplicar slide master
- slide master não usado
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Gerencie slides master no Aspose.Slides para Android via Java: acesse, edite, clone, compare e remova slides master em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a forma usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

O Aspose.Slides for Android via Java oferece o mesmo modelo. Uma apresentação pode conter um ou mais master slides, e cada master slide pode conter vários layout slides. Slides normais normalmente não referenciam um master slide diretamente. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um master slide.

A hierarquia é:

1. **Slide master** – define o design e tema compartilhados.  
1. **Layout slide** – define um arranjo específico de marcadores de posição e formatação ao nível do layout.  
1. **Slide normal** – contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de master slides, layout slides e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela interface [IMasterSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslide/). Todos os master slides de uma apresentação estão disponíveis por meio da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getMasters--) , que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslidecollection/). Para conhecer toda a API Android via Java, veja a referência da API [com.aspose.slides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/).

{{% alert color="info" title="Herança" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um master slide e um layout slide definirem um fundo, os slides baseados nesse layout usarão o fundo do layout. Para mais informações sobre layout slides, veja [Aplicar ou Alterar Layout de Slide](/slides/pt/androidjava/slide-layout/).
{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização de Slide Master em **Exibir** > **Slide Master**.

![O comando Slide Master na guia Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `getMasters()` para acessar os master slides:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Você também pode obter o master slide usado por um slide normal por meio de seu layout:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **O que um Slide Master contém**

Um master slide é um objeto semelhante a um slide. Ele implementa [IBaseSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout.

Membros de master slide usados com frequência incluem:

| Membro | Propósito |
| --- | --- |
| `getBackground()` | Define o fundo do slide ao nível do master. |
| `getShapes()` | Armazena as formas colocadas no master, como logotipos, molduras de imagem e texto compartilhado. |
| `getLayoutSlides()` | Armazena os layout slides que pertencem ao master. |
| `getThemeManager()` | Fornece acesso às APIs de tema do master. |
| `getHeaderFooterManager()` | Controla cabeçalhos, rodapés, datas e números de slides para o master e seus layouts filhos. |
| `getDependingSlides()` | Retorna slides normais que dependem do master por meio de seus layouts. |

## **Adicionar uma Imagem a um Slide Master**

Quando você adiciona uma imagem a um master slide, ela aparece nos slides que utilizam layouts desse master. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro master slide:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para mais informações sobre molduras de imagem, consulte [Moldura de Imagem](/slides/pt/androidjava/picture-frame/).

## **Trabalhar com Marcadores de posição**

Marcadores de posição são normalmente definidos em layout slides. O master slide fornece o estilo e tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores estão disponíveis e onde são posicionados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização de Slide Master.

![O comando Inserir Marcador de Posição na visualização de Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o layout slide que pertence ao master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode formatar formas de marcador já existentes em um master slide. O exemplo a seguir localiza o marcador de título e aplica um preenchimento de gradiente linear:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Marcador de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores e texto, veja [Definir Texto de Prompt em Marcador](/slides/pt/androidjava/manage-placeholder/) e [Formatação de Texto](/slides/pt/androidjava/text-formatting/).

## **Alterar o Fundo de um Slide Master**

Um fundo de master é herdado por layouts e slides que não o substituem. O exemplo a seguir define uma cor de fundo sólida para o primeiro master slide:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para tópicos relacionados, veja [Fundo da Apresentação](/slides/pt/androidjava/presentation-background/) e [Tema da Apresentação](/slides/pt/androidjava/presentation-theme/).

## **Clonar um Slide Master para outra Apresentação**

Use [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) para copiar um master slide para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Se precisar clonar slides normais junto com seu master, veja [Clonar Slides](/slides/pt/androidjava/clone-slides/).

## **Adicionar Vários Slide Masters**

Uma apresentação pode conter vários master slides. Isso é útil quando diferentes seções exigem branding, estrutura de página ou configurações de tema distintas.

![Comandos do PowerPoint para inserir e gerenciar master slides](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, atribui ao clone um fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comparar Slide Masters**

Master slides podem ser comparados com o método `equals` herdado de [IBaseSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores, como a data atual.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Para mais informações, veja [Comparar Slides da Apresentação](/slides/pt/androidjava/compare-slides/).

## **Definir a Visualização de Slide Master como Visualização Padrão**

Use o método `setLastView` em [ViewProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre inicialmente. O exemplo a seguir abre a apresentação na visualização de Slide Master:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para mais configurações de visualização, veja [Salvar Apresentação](/slides/pt/androidjava/save-presentation/).

## **Remover Slide Masters Não Utilizados**

Apresentações às vezes contêm master slides que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de templates.

Use `removeUnused` para remover masters não usados da coleção `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode usar o método de low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual a diferença entre um slide master e um layout slide?**  
Um slide master define configurações de design compartilhadas, como tema, fundo, formas comuns e estilos de texto. Um layout slide pertence a um slide master e define um arranjo específico de marcadores de posição. Um slide normal usa um layout slide, herdando tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**  
Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando diferentes seções precisarem de sistemas visuais ou branding distintos.

**Devo adicionar marcadores de posição a um slide master ou a um layout slide?**  
Na maioria dos casos, adicione marcadores de posição a layout slides. Coloque os elementos visuais compartilhados e a formatação comum no slide master e, em seguida, coloque os marcadores de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um slide master que ainda está em uso?**  
Não. Um slide master que possui slides dependentes não pode ser removido com segurança. Primeiro mova esses slides para layouts sob outro master ou use um método de limpeza que remova apenas masters que não estejam em uso.