---
title: Gerenciar placeholders de apresentação em Java
linktitle: Gerenciar placeholders
type: docs
weight: 10
url: /pt/java/manage-placeholder/
keywords:
- marcador de posição
- marcador de texto
- marcador de imagem
- marcador de gráfico
- marcador de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como inspecionar e editar placeholders de texto, imagem, gráfico e conteúdo e entender a herança de placeholders com Aspose.Slides para Java."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou de um slide mestre.

Aspose.Slides expõe informações de placeholder através do método [IShape.getPlaceholder](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/). O método retorna um objeto [IPlaceholder](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholder/) ou `null` para uma forma normal. Use [IPlaceholder.getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholder/) para determinar o que o placeholder deve conter.

A interface da forma ainda é relevante depois de conhecer o tipo de placeholder:

- Um placeholder de texto, imagem, gráfico ou conteúdo vazio costuma ser representado por um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/).
- Um placeholder de imagem já preenchido pode ser representado por um [IPictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipictureframe/).
- Um placeholder de gráfico já preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [IPlaceholder.getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholder/) quanto a interface de forma em tempo de execução em vez de assumir que todo placeholder é um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Aviso" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholder/) descreve o papel de um placeholder; ele não garante o tipo de forma em tempo de execução. Sempre faça uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Compreender a herança de placeholder**

Placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders desse slide e pode herdar do seu layout.

Chame [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) para subir um nível nessa hierarquia. Um placeholder de slide normalmente devolve seu placeholder de layout; um placeholder de layout pode devolver seu placeholder mestre. O método devolve `null` quando a forma não tem placeholder base.

O exemplo a seguir lista os placeholders do primeiro slide e relata seus placeholders base:

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

Editar um placeholder em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou o mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma ordinary local não tem placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Alterar texto em um placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se a forma é um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) antes de usar seu método [getTextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/).

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

Esse padrão evita converter placeholders de imagem, gráfico, tabela ou mídia para [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/). Ele também identifica o placeholder por finalidade em vez de depender de um índice de forma frágil.

## **Definir texto de prompt em um layout**

O texto de prompt é a instrução exibida em tempo de design em um placeholder vazio, como *Clique para adicionar título*. Defina texto de prompt personalizado no placeholder de layout em vez de tentar acessá‑lo através da coleção de formas de um slide normal. Acesse o layout por meio de [ISlide.getLayoutSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islide/) e itere sobre a coleção retornada por [ILayoutSlide.getShapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/).

O exemplo a seguir altera os prompts de título e subtítulo no layout usado pelo primeiro slide:

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

Texto de prompt não é conteúdo de slide normal. Ele destina‑se a placeholders vazios em aplicativos de edição como o PowerPoint. Quando um usuário ou programa fornece conteúdo real, o prompt deixa de ser exibido. Alterar um prompt também não substitui texto existente em slides que utilizam o layout.

## **Atualizar um placeholder de imagem**

Existem dois casos a tratar:

- Se o placeholder de imagem já estiver preenchido e for representado por um [IPictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipictureframe/), substitua a imagem através de [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/) e [ISlidesPicture.setImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidespicture/).
- Se ainda for um placeholder vazio, adicione um picture frame nas coordenadas do placeholder com [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/) e remova o placeholder vazio.

O próximo exemplo suporta ambos os casos e salva a apresentação:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

A substituição criada para um placeholder vazio é um picture frame local, não um novo placeholder, porque [IShape.getPlaceholder](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) não fornece um setter. Ela mantém a posição reservada, mas deixa de herdar comportamento específico de placeholder. Se manter o relacionamento de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, depois atualize o [IPictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de picture, veja [Manage Picture Frames](/slides/pt/java/picture-frame/). Essas operações pertencem ao picture frame ou ao picture fill, não aos metadados do placeholder.

## **Trabalhar com placeholders de gráfico e conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [IChart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/). Este exemplo encontra tal gráfico tanto pelo tipo de placeholder quanto pela interface em tempo de execução, altera seu título e salva o arquivo:

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

Um placeholder de conteúdo geral costuma ter [PlaceholderType.Object](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholdertype/). No PowerPoint ele funciona como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Depois de preenchido, inspecione a interface de forma real para descobrir o que contém. Layouts especializados também podem expor [PlaceholderType.Chart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholdertype/), ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholdertype/).

Aspose.Slides não converte um placeholder vazio de [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) em um [IChart](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/) apenas alterando [IPlaceholder.getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/placeholder/); o tipo não pode ser alterado pela interface. Para preencher programaticamente uma área de gráfico ou conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

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

O gráfico adicionado é um gráfico local comum. Ele ocupa a área do placeholder, mas não herda do placeholder de layout. Use os artigos dedicados à [chart management](/slides/pt/java/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo completo: atualizar conteúdo de texto ou imagem**

O exemplo end‑to‑end a seguir abre um modelo, procura o primeiro slide por um placeholder de título ou imagem, verifica os tipos de placeholder e forma, atualiza o conteúdo apropriado e salva a saída. O exemplo evita deliberadamente assumir um índice de forma ou converter todos os placeholders para a mesma interface.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

## **Perguntas frequentes**

**O que é um placeholder base?**

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) para recuperá‑lo. Uma forma local ordinary devolve `null` porque não faz parte da hierarquia de placeholders.

**Posso mudar todos os títulos de slides editando um placeholder de layout?**

Você pode alterar a formatação herdada ou o texto de prompt através de um layout, mas o conteúdo de título existente está armazenado nos slides normais. Para substituir o texto real do título em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerenciar placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo apropriado (slide, layout, mestre, notas ou folheto). Consulte [Manage Presentation Header and Footer](/slides/pt/java/presentation-header-and-footer/) para exemplos completos.