---
title: Gerenciar marcadores de posição de apresentação no Android
linktitle: Gerenciar marcadores
type: docs
weight: 10
url: /pt/androidjava/manage-placeholder/
keywords:
- marcador de posição
- marcador de texto
- marcador de imagem
- marcador de gráfico
- marcador de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a inspecionar e editar marcadores de texto, imagem, gráfico e de conteúdo, e entenda a herança de marcadores com Aspose.Slides para Android via Java."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são placeholders de título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

O Aspose.Slides expõe as informações de placeholder através do método [IShape.getPlaceholder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/). O método retorna um objeto [IPlaceholder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholder/) ou `null` para uma forma normal. Use [IPlaceholder.getType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholder/) para determinar o que o placeholder deve conter.

A interface da forma ainda é importante depois de conhecer o tipo de placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo geralmente é representado por um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [IPlaceholder.getType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholder/) quanto a interface de forma em tempo de execução ao invés de assumir que todo placeholder é um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholder/) descreve o papel de um placeholder; não garante o tipo em tempo de execução da forma. Sempre use uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender a herança de placeholders**

Placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders deste slide e pode herdar de seu layout.

Chame [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/) para mover um nível acima nessa hierarquia. Um placeholder de slide normalmente devolve seu placeholder de layout; um placeholder de layout pode devolver seu placeholder mestre. O método retorna `null` quando a forma não tem placeholder base.

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

Editar um placeholder em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma local comum não tem placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Alterar texto em um placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se é um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) antes de usar seu método [getTextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/).

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

Esse padrão evita converter placeholders de imagem, gráfico, tabela ou mídia para [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/). Ele também identifica o placeholder por propósito ao invés de depender de um índice de forma frágil.

## **Definir texto de sugestão em um layout**

Texto de sugestão é a instrução de design exibida em um placeholder vazio, como *Clique para adicionar título*. Defina texto de sugestão personalizado no placeholder de layout ao invés de tentar alcançá‑lo através da coleção de formas de um slide normal. Acesse o layout via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islide/) e itere sobre a coleção retornada por [ILayoutSlide.getShapes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseslide/).

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

Texto de sugestão não é conteúdo de slide normal. Ele destina‑se a placeholders vazios em aplicativos de edição como o PowerPoint. Quando um usuário ou programa fornece conteúdo real, a sugestão deixa de ser exibida. Alterar uma sugestão também não substitui texto existente nos slides que usam o layout.

## **Atualizar um placeholder de imagem**

Existem dois casos a serem tratados:

- Se o placeholder de imagem já estiver preenchido e for representado por um [IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/), substitua a imagem através de [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/) e [ISlidesPicture.setImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidespicture/).
- Se ainda for um placeholder vazio, adicione um picture frame nas coordenadas do placeholder com [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/) e remova o placeholder vazio.

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

A substituição criada para um placeholder vazio é um picture frame local, não um novo placeholder, porque [IShape.getPlaceholder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/) não fornece um setter. Ele mantém a posição reservada, mas não herda mais o comportamento específico de placeholder. Se reter o relacionamento de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, então atualize o [IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, veja [Manage Picture Frames](/slides/pt/androidjava/picture-frame/). Essas operações pertencem ao picture frame ou ao preenchimento de imagem, não aos metadados do placeholder.

## **Trabalhar com placeholders de gráfico e conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichart/). Este exemplo encontra tal gráfico tanto pelo tipo de placeholder quanto pela interface em tempo de execução, altera seu título e salva o arquivo:

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

Um placeholder de conteúdo geral costuma ter [PlaceholderType.Object](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Após ser preenchido, inspecione a interface real da forma para descobrir o que contém. Layouts especializados podem também expor [PlaceholderType.Chart](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholdertype/), ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholdertype/).

O Aspose.Slides não converte um placeholder vazio de [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) em um [IChart](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichart/) apenas alterando [IPlaceholder.getType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/placeholder/); o tipo não pode ser alterado pela interface. Para preencher programaticamente uma área de gráfico ou conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

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

O gráfico adicionado é um gráfico local comum. Ele ocupa a área do placeholder, mas não herda do placeholder de layout. Use os artigos dedicados à [chart management](/slides/pt/androidjava/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo completo: atualizar conteúdo de texto ou imagem**

O exemplo a seguir, de ponta a ponta, abre um modelo, procura no primeiro slide um placeholder de título ou imagem, verifica os tipos de placeholder e de forma, atualiza o conteúdo apropriado e salva a saída. O exemplo evita deliberadamente assumir um índice de forma ou converter todos os placeholders para a mesma interface.

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

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/) para recuperá‑lo. Uma forma local comum devolve `null` porque não faz parte da hierarquia de placeholders.

**Posso alterar todos os títulos dos slides editando um placeholder de layout?**

É possível mudar a formatação herdada ou o texto de sugestão através de um layout, mas o conteúdo de título existente está armazenado nos slides normais. Para substituir o texto real do título em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerencio placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo de slide, layout, mestre, notas ou folhetos apropriado. Consulte [Manage Presentation Header and Footer](/slides/pt/androidjava/presentation-header-and-footer/) para exemplos completos.