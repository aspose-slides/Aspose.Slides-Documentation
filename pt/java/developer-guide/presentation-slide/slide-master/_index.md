---
title: Gerenciar Slides Masters da Apresentação em Java
linktitle: Slide Master
type: docs
weight: 70
url: /pt/java/slide-master/
keywords:
- slide master
- slide mestre
- slide mestre PPT
- vários slides mestres
- comparar slides mestres
- plano de fundo
- marcador de posição
- clonar slide mestre
- copiar slide mestre
- duplicar slide mestre
- slide mestre não utilizado
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Gerencie slides masters no Aspose.Slides for Java: acesse, edite, clone, compare e remova slides masters em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, planos de fundo, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a forma usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for Java suporta o mesmo modelo. Uma apresentação pode conter um ou mais master slides, e cada master slide pode conter vários layout slides. Slides normais normalmente não se referem a um master slide diretamente. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um master slide.

A hierarquia é:

1. **Slide master** - define o design e tema compartilhados.
1. **Layout slide** - define um arranjo específico de marcadores de posição e formatação ao nível do layout.
1. **Normal slide** - contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de master slides, layout slides e normal slides](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela interface [IMasterSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslide/). Todos os master slides em uma apresentação estão disponíveis através da coleção [Presentation.getMasters](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getMasters--) , que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um master slide e um layout slide ambos definirem um plano de fundo, os slides baseados naquele layout usarão o plano de fundo do layout. Para mais informações sobre layout slides, veja [Aplicar ou Alterar Layouts de Slides](/slides/pt/java/slide-layout/).
{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização **Slide Master** em **View** > **Slide Master**.

![O comando Slide Master na guia View do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `getMasters()` para acessar master slides:

```java
import com.aspose.slides.*;

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

Você também pode obter o master slide usado por um slide normal através de seu layout:

```java
import com.aspose.slides.*;

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

Um master slide é um objeto semelhante a um slide. Ele implementa [IBaseSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Membros específicos do master estão listados na página da API [IMasterSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslide/).

Membros de master slide comumente usados incluem:

| Membro | Propósito |
| --- | --- |
| `getBackground()` | Define o plano de fundo do slide no nível do master. |
| `getShapes()` | Armazena as formas colocadas no master, como logotipos, quadros de imagem e texto compartilhado. |
| `getLayoutSlides()` | Armazena os layout slides que pertencem ao master. |
| `getThemeManager()` | Fornece acesso às APIs de tema do master. |
| `getHeaderFooterManager()` | Controla cabeçalhos, rodapés, datas e números de slides para o master e seus layouts filhos. |
| `getDependingSlides()` | Retorna os slides normais que dependem do master através de seus layouts. |

## **Adicionar uma imagem a um Slide Master**

Ao adicionar uma imagem a um master slide, ela aparece nos slides que usam layouts desse master. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro master slide:

```java
import com.aspose.slides.*;

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

Para mais informações sobre quadros de imagem, veja [Quadro de Imagem](/slides/pt/java/picture-frame/).

## **Controlar a visibilidade de gráficos do Master**

Use [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) para ocultar gráficos herdados do master, como logotipos ou formas decorativas, sem excluí‑los do master. Passe `false` para [Slide.setShowMasterShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) no slide que deve omitir esses gráficos e mantenha `true` nos slides que devem exibí‑los.

O exemplo autônomo a seguir cria uma faixa decorativa azul em um master e dois slides que usam o mesmo layout em branco. A faixa fica visível no primeiro slide e oculta no segundo. Nenhuma apresentação de entrada ou imagem é necessária.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O exemplo usa o layout **Blank** fornecido com uma nova apresentação e remove os próprios marcadores de posição do slide inicial.

### **Escolher o escopo da configuração**

Um slide normal usa seu master através de [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islide/#getLayoutSlide--) e [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Definir a propriedade em um slide individual afeta apenas esse slide. Passar `false` para [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) oculta gráficos do master para slides que usam aquele layout compartilhado, mesmo que sua própria configuração seja `true`. Para ocultar gráficos em apenas um slide, altere a propriedade do slide e mantenha o layout compartilhado inalterado.

A configuração não é suportada como controle de visibilidade no próprio master slide. Em um master, [getShowMasterShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/masterslide/#getShowMasterShapes--) sempre retorna `false`, e passar `true` para [setShowMasterShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) gera uma exceção. Aplique‑a a um slide normal ou a um layout.

### **Distinguir gráficos do plano de fundo**

| Operação | Efeito |
| --- | --- |
| Ocultar gráficos do master | Controla a visibilidade de formas herdadas do master sem excluí‑las ou alterar as próprias formas do slide. |
| Alterar o preenchimento de fundo do slide | Altera a cor, gradiente ou imagem de fundo. Os gráficos do master são formas separadas e podem permanecer visíveis sobre esse fundo. Veja [Fundo da Apresentação](/slides/pt/java/presentation-background/). |
| Excluir uma forma do master | Remove a forma fonte compartilhada, de modo que não esteja mais disponível para nenhum slide que use aquele master. |

## **Trabalhar com marcadores de posição**

Marcadores de posição são normalmente definidos em layout slides. O master slide fornece o estilo e tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde são colocados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização Slide Master.

![O comando Insert Placeholder na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o layout slide que pertence ao master:

```java
import com.aspose.slides.*;

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

Você também pode formatar formas de marcador de posição que já existam em um master slide. O exemplo a seguir localiza o marcador de posição de título e aplica um preenchimento de gradiente linear:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

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

![Marcador de posição de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores de posição e texto, veja [Definir Texto de Prompt no Marcador de Posição](/slides/pt/java/manage-placeholder/) e [Formatação de Texto](/slides/pt/java/text-formatting/).

## **Alterar o plano de fundo de um Slide Master**

Um plano de fundo de master é herdado por layouts e slides que não o substituem. O exemplo a seguir define uma cor de fundo sólida para o primeiro master slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para tópicos relacionados, veja [Fundo da Apresentação](/slides/pt/java/presentation-background/) e [Tema da Apresentação](/slides/pt/java/presentation-theme/).

## **Clonar um Slide Master para outra apresentação**

Use [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) para copiar um master slide para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

```java
import com.aspose.slides.*;

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

Se precisar clonar slides normais junto com seu master, veja [Clonar Slides](/slides/pt/java/clone-slides/).

## **Adicionar vários Slide Masters**

Uma apresentação pode conter vários master slides. Isso é útil quando diferentes seções requerem diferentes marcas, estrutura de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar master slides](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, atribui ao clone um plano de fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

Master slides podem ser comparados com o método `equals` herdado de [IBaseSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras definições de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de marcadores, como a data atual.

```java
import com.aspose.slides.*;

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

Para mais informações, veja [Comparar Slides da Apresentação](/slides/pt/java/compare-slides/).

## **Definir a visualização Slide Master como visualização padrão**

Use o método `setLastView` em [ViewProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para mais configurações de visualização, veja [Salvar Apresentação](/slides/pt/java/save-presentation/).

## **Remover Slide Masters não utilizados**

Apresentações às vezes contêm master slides que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use `removeUnused` para remover masters não utilizados da coleção `getMasters()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode usar o método de baixo código [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual é a diferença entre um slide master e um layout slide?**

Um slide master define configurações de design compartilhadas, como tema, plano de fundo, formas comuns e estilos de texto. Um layout slide pertence a um slide master e define um arranjo específico de marcadores de posição. Um slide normal usa um layout slide, herdando tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**

Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando diferentes seções precisam de sistemas visuais ou branding diferentes.

**Devo adicionar marcadores de posição a um master slide ou a um layout slide?**

Na maioria dos casos, adicione marcadores de posição a layout slides. Coloque elementos visuais compartilhados e formatação comum no master slide e, em seguida, coloque os marcadores de posição de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um master slide que ainda está em uso?**

Não. Um master slide que possui slides dependentes não pode ser removido diretamente com segurança. Primeiro mova esses slides para layouts sob outro master ou use um método de limpeza de masters não usados que remova apenas masters que não estejam em uso.