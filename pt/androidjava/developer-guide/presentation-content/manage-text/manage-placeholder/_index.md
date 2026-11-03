---
title: Gerenciar Placeholders de Apresentação no Android
linktitle: Gerenciar Placeholders
type: docs
weight: 10
url: /pt/androidjava/manage-placeholder/
keywords:
- placeholder
- placeholder de texto
- placeholder de imagem
- placeholder de gráfico
- placeholder de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a inspecionar e editar placeholders de texto, imagem, gráfico e conteúdo e a compreender a herança de placeholders com Aspose.Slides para Android via Java."
---
## **Visão geral**

Um placeholder (marcador de posição) é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe informações de placeholder através do método [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/). O método retorna um objeto [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) ou `null` para uma forma normal. Use [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) para determinar o que o placeholder deve conter.

A interface da forma ainda é relevante depois de conhecer o tipo de placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo costuma ser representado por um [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) quanto a interface de forma em tempo de execução, em vez de assumir que todo placeholder é um [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) descreve o papel de um placeholder; ele não garante o tipo de forma em tempo de execução. Sempre use uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a herança de placeholders**

Os placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders no nível do mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders desse slide e pode herdar do seu layout.

Chame [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) para subir um nível nessa hierarquia. Um placeholder de slide normalmente retorna seu placeholder de layout; um placeholder de layout pode retornar seu placeholder de mestre. O método retorna `null` quando a forma não tem placeholder base.

O exemplo a seguir lista os placeholders no primeiro slide e relata seus placeholders base:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Editar um placeholder em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma ordinária local não tem placeholder base e não passa a herdar apenas porque ocupa as mesmas coordenadas.

## **Remover o status de placeholder**

Ao adaptar um modelo, use [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) para manter um objeto existente como uma forma comum. Seu método [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) retorna `null`, mas a forma permanece na coleção do slide. Em contraste, [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) exclui a forma dessa coleção.

O exemplo a seguir requer `template.pptx` com ao menos um slide e um placeholder de texto não vazio no primeiro slide. Use um placeholder com formatação herdada do seu layout ou mestre para ver o efeito de remover essa relação. O exemplo verifica que a mesma forma permanece, chama o método novamente na forma agora comum e salva o resultado.

{{% alert color="warning" title="Warning" %}}
Remover o status de placeholder não preserva automaticamente as configurações de aparência herdadas. O exemplo abaixo deixa propositalmente essas configurações inalteradas, de modo que a saída pode parecer diferente. Uma forma cuja posição e tamanho são totalmente herdados pode ter coordenadas e dimensões zero após a chamada e tornar‑se invisível, embora permaneça na coleção.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Chamar o método em uma forma comum não tem efeito.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Para um placeholder correspondente, as três verificações imprimem `true`. O texto permanece, mas posição, tamanho, rotação, fonte, alinhamento de parágrafo, margens da caixa de texto, ancoragem vertical, preenchimento e configurações de linha herdados podem mudar quando a relação de placeholder é removida. Por exemplo, a formatação de título herdada pode voltar à formatação de texto comum. Veja [Layout de Slide](/slides/pt/androidjava/slide-layout/) para mais informações sobre layouts.

Para preservar a aparência pretendida, capture a posição, tamanho e rotação resolvidos antes da chamada e copie os valores efetivos de formatação necessários para variáveis separadas. Recupere esses valores através de [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), e [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). Não confie apenas nos objetos de formatação efetiva, pois seus valores de formatação de texto podem mudar após a relação ser removida. Aplique explicitamente os valores capturados à forma comum posteriormente, incluindo família da fonte, tamanho, estilo, cor, configurações de parágrafo, configurações da caixa de texto, preenchimento e linha usados pelo seu modelo.

A geometria herdada da forma pode também precisar ser atribuída explicitamente via [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). Para um placeholder de texto retangular, isso significa atribuir [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle); restaurar apenas o preenchimento e a linha pode não restaurar o retângulo visível. Modelos com efeitos adicionais ou formatação mais complexa requerem que essas configurações sejam tratadas também.

## **Alterar texto em um placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se é um [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) antes de usar seu método [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

Este exemplo atualiza o primeiro placeholder de título no primeiro slide e salva o resultado:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esse padrão evita converter placeholders de imagem, gráfico, tabela ou mídia para [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Também identifica o placeholder por finalidade em vez de depender de um índice de forma frágil.

## **Definir texto de sugestão em um layout**

Texto de sugestão é a instrução exibida em tempo de design em um placeholder vazio, como *Clique para adicionar título*. Defina texto de sugestão personalizado no placeholder do layout em vez de tentar alcançá‑lo através da coleção de formas de um slide normal. Acesse o layout via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) e itere sobre a coleção retornada por [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

O exemplo a seguir altera as sugestões de título e subtítulo no layout usado pelo primeiro slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Texto de sugestão não é conteúdo normal de slide. Ele se destina a placeholders vazios em aplicações de edição como PowerPoint. Quando um usuário ou programa fornece conteúdo real, a sugestão deixa de ser exibida. Alterar uma sugestão também não substitui o texto existente em slides que utilizam o layout.

## **Atualizar um placeholder de imagem**

Existem dois casos a serem tratados:

- Se o placeholder de imagem já estiver preenchido e representado por um [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), substitua a imagem via [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) e [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Se ainda for um placeholder vazio, adicione uma caixa de imagem nas coordenadas do placeholder com [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) e remova o placeholder vazio.

O próximo exemplo suporta ambos os casos e salva a apresentação:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A substituição criada para um placeholder vazio é uma caixa de imagem local, não um novo placeholder, porque [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) não fornece um setter. Ela mantém a posição reservada, mas deixa de herdar o comportamento específico de placeholder. Se manter a relação de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, depois atualize o [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, veja [Manage Picture Frames](/slides/pt/androidjava/picture-frame/). Essas operações pertencem à caixa de imagem ou ao preenchimento da imagem, não aos metadados do placeholder.

## **Trabalhar com placeholders de gráfico e conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). Este exemplo localiza tal gráfico tanto pelo tipo de placeholder quanto pela interface em tempo de execução, altera seu título e salva o arquivo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um placeholder de conteúdo geral geralmente tem [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Após ser preenchido, inspecione a interface real da forma para descobrir o que contém. Layouts especializados também podem expor [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides não converte um placeholder vazio de [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) em um [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) apenas alterando [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); o tipo não pode ser alterado pela interface. Para preencher programaticamente um gráfico ou área de conteúdo vazia, adicione o objeto requerido nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O gráfico adicionado é um gráfico local comum. Ele ocupa a área do placeholder, mas não herda do placeholder de layout. Use os artigos dedicados à [chart management articles](/slides/pt/androidjava/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da pasta de trabalho.

## **Exemplo completo: atualizar conteúdo de texto ou imagem**

O exemplo de ponta a ponta a seguir abre um modelo, procura no primeiro slide um placeholder de título ou imagem, verifica os tipos de placeholder e forma, atualiza o conteúdo apropriado e salva o resultado. O exemplo evita deliberadamente assumir um índice de forma ou converter todos os placeholders para a mesma interface.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**O que é um placeholder base?**

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) para recuperá‑lo. Uma forma local comum retorna `null` porque não faz parte da hierarquia de placeholders.

**Posso mudar todos os títulos dos slides editando um placeholder de layout?**

É possível mudar a formatação herdada ou o texto de sugestão através de um layout, mas o conteúdo de título existente está armazenado nos slides normais. Para substituir o texto real dos títulos em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerencio placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo apropriado de slide, layout, mestre, notas ou folhetos. Consulte [Manage Presentation Header and Footer](/slides/pt/androidjava/presentation-header-and-footer/) para exemplos completos.