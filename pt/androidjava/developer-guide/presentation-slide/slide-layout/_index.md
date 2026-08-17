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
  - presentation
  - Android
  - Java
  - Aspose.Slides
description: "Aplicar, criar e modificar layouts de slide no Aspose.Slides para Android via Java, adicionar marcadores de posição, remover layouts não usados e controlar a visibilidade do rodapé."
---
## **Visão geral**

Um layout de slide define as posições e formatação dos marcadores de posição, como títulos, texto, imagens, gráficos e tabelas. Aplicar um layout fornece aos slides uma estrutura consistente, permitindo que cada slide contenha seu próprio conteúdo.

Os layouts mais comuns incluem:

- **Slide de Título**: Contém marcadores de posição de título e subtítulo.
- **Título e Conteúdo**: Contém um marcador de posição de título e um marcador de posição de conteúdo de uso geral.
- **Em branco**: Não contém marcadores de posição de conteúdo e é útil quando cada forma será posicionada manualmente.

## **Entender a Herança de Layout**

Uma apresentação tem três níveis relacionados:

1. Um [master slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslide/) define o tema, formatação compartilhada, fundos e objetos comuns.
1. Um [layout slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/) pertence a um master e define um arranjo específico de marcadores de posição.
1. Um [normal slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/) usa um layout e armazena o conteúdo inserido para esse slide.

Um slide normal herda o tema e a formatação de seu layout, e o layout herda do seu master. Um valor definido diretamente em um slide normal substitui o valor herdado naquele nível. Quando um slide normal é criado, suas formas de marcador de posição são geradas a partir do layout selecionado, enquanto o conteúdo inserido nesses marcadores pertence ao slide normal.

Adicione os marcadores de posição necessários a um layout antes de criar slides a partir dele. Adicionar outro marcador de posição a um layout posteriormente não adiciona automaticamente a forma de marcador correspondente aos slides normais existentes.

Esse relacionamento tem duas consequências importantes:

- Alterar a formatação herdada ou a geometria dos marcadores de posição existentes em um layout pode atualizar todos os slides que dependem dele. Antes de editar um layout já em uso, inspecione seus slides dependentes e revise a apresentação resultante.
- Um layout que ainda está sendo usado por um slide não pode ser removido. Primeiro reatribua seus slides dependentes a outro layout, ou remova apenas layouts não utilizados.

Para obter mais informações sobre o nível superior desta hierarquia, consulte [Slide Master](/slides/pt/androidjava/slide-master/).

## **Selecionar e Aplicar um Layout de Slide**

Use um tipo de layout quando a apresentação segue as definições padrão de layout do PowerPoint. Os nomes dos layouts podem ser editados pelo usuário e localizados, portanto a seleção baseada em nome é menos confiável a menos que você controle o modelo de origem.

O exemplo a seguir procura **Título e Conteúdo** no primeiro master. Se esse layout não estiver disponível, ele recorre deliberadamente a **Em branco**. A segunda verificação de nulo é necessária porque uma apresentação pode conter apenas layouts personalizados. O layout selecionado é então aplicado ao primeiro slide normal através do método [ISlide.setLayoutSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alterar o layout de um slide não remove as formas comuns adicionadas diretamente ao slide. Entretanto, as posições dos marcadores de posição, a formatação herdada e a correspondência entre os marcadores existentes e o novo layout podem mudar, portanto inspecione o resultado ao alternar entre layouts substancialmente diferentes.

## **Adicionar um Slide de Layout**

Seleção e criação são operações separadas. O exemplo anterior seleciona um layout existente; ele não cria um. Para criar um layout, chame o método [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) na coleção de layouts do master de destino.

O exemplo a seguir sempre adiciona um novo layout **Título e Conteúdo** chamado `Report Title and Content`, depois adiciona um slide normal baseado nele. Os nomes dos layouts devem ser únicos dentro da coleção.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Adicione um layout somente quando o modelo realmente precisar de outra estrutura reutilizável. Se já existir um layout adequado, selecione‑o e reutilize‑o em vez de criar um duplicado.

## **Adicionar Marcadores de Posição a um Slide de Layout**

O método [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) fornece um [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) para adicionar formas de marcador de posição a um layout.

| Marcador de Posição do PowerPoint | Método ILayoutPlaceholderManager |
| --------------------------------- | --------------------------------- |
| ![Conteúdo](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Conteúdo (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Texto](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Texto (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Imagem](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Gráfico](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabela](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Mídia](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Imagem Online](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

O exemplo a seguir verifica se o layout **Em branco** existe, adiciona quatro marcadores de posição a ele e, em seguida, cria um slide normal que usa o layout modificado. A ordem é intencional: os marcadores são adicionados antes da criação do slide normal, de modo que o Aspose.Slides possa gerar as formas de marcador correspondentes naquele slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![Os marcadores de posição no slide de layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Alterar a formatação herdada ou a geometria dos marcadores de posição existentes em um layout pode afetar os slides dependentes. Um marcador de posição de layout recém‑adicionado não é retro‑preenchido nos slides normais existentes. Teste alterações de layout em uma cópia da apresentação e inspecione cada slide dependente.
{{% /alert %}}

## **Remover Slides de Layout Não Utilizados**

Use o método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) para remover layouts que nenhum slide normal referencia. O método mantém intactos os layouts que ainda estão em uso.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para remover um layout específico, primeiro use seu método [hasDependingSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) ou [getDependingSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Reatribua quaisquer slides dependentes antes de chamar [ILayoutSlide.remove](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/#remove--). Tentar remover um layout em uso gera uma [PptxEditException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxeditexception/).

## **Controlar Visibilidade do Rodapé em um Slide de Layout**

Um layout tem seus próprios marcadores de rodapé, número do slide e data/hora. Use o método [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) para controlar esses marcadores em um layout. Isso é útil quando, por exemplo, layouts de conteúdo devem exibir rodapés, mas layouts de título não.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar Visibilidade do Rodapé em um Master e Seus Layouts Filhos**

Para aplicar configurações de rodapé consistentes em toda a hierarquia de um master, use o método [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Os métodos de propagação de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) atuam sobre o master e seus slides de layout e slides normais dependentes; eles não visam apenas um slide normal.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**Qual é a diferença entre um Master Slide e um Layout Slide?**

Um master slide define o tema da apresentação e a formatação compartilhada. Um layout slide pertence a um master e define um arranjo reutilizável de marcadores de posição. Slides normais utilizam esses layouts e armazenam o conteúdo específico de cada slide.

**Posso copiar um Layout Slide de uma apresentação para outra?**

Sim. Adicione uma cópia à coleção de destino com o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Ao copiar entre apresentações, verifique também fontes, temas, imagens e outros recursos usados pelo layout de origem.

**O que acontece quando modifico um Layout que já está em uso?**

Slides dependentes herdam as alterações do layout, a menos que tenham substituído a formatação ou objetos localmente. Portanto, a geometria dos marcadores de posição e a estilização herdada podem mudar em muitos slides simultaneamente. Use [getDependingSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) para identificar os slides afetados antes de editar o layout.

**O que acontece se eu remover um Layout que ainda está em uso?**

O Aspose.Slides lança uma [PptxEditException](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pptxeditexception/). Reatribua primeiro os slides dependentes ou use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) para remover apenas os layouts não referenciados.