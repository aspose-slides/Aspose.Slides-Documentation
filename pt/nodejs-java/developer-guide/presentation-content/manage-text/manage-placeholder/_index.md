---
title: Gerenciar placeholders de apresentação em JavaScript
linktitle: Gerenciar placeholders
type: docs
weight: 10
url: /pt/nodejs-java/manage-placeholder/
keywords:
- marcador de posição
- marcador de texto
- marcador de imagem
- marcador de gráfico
- marcador de conteúdo
- texto de prompt
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como inspecionar e editar placeholders de texto, imagem, gráfico e conteúdo e entender a herança de placeholders com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um tipo específico de conteúdo em um modelo de apresentação. Exemplos comuns são placeholders de título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma comum, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou slide mestre.

Aspose.Slides expõe informações de placeholder através do método [Shape.getPlaceholder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getPlaceholder). O método retorna um objeto [Placeholder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholder/) ou `null` para uma forma normal. Use [Placeholder.getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholder/#getType) para determinar o que o placeholder deve conter.

A classe da forma ainda importa depois de conhecer o tipo do placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo geralmente é representado por um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).
- Um placeholder de imagem preenchido pode ser representado por um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/).
- Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [Placeholder.getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholder/#getType) quanto a classe de forma em tempo de execução, ao invés de assumir que todo placeholder é um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholder/#getType) descreve o papel de um placeholder; ele não garante o tipo de forma em tempo de execução. Sempre use uma verificação de tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entenda a Herança de Placeholders**

Os placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define a disposição usada por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders desse slide e pode herdar de seu layout.

Chame [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getBasePlaceholder) para subir um nível nessa hierarquia. Um placeholder de slide normalmente retorna seu placeholder de layout; um placeholder de layout pode retornar seu placeholder mestre. O método retorna `null` quando a forma não possui placeholder base.

O exemplo a seguir lista os placeholders no primeiro slide e relata seus placeholders base:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Editar um placeholder em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou o mestre relacionado pode afetar todos os slides que ainda herdam essa configuração. Uma forma local comum não possui placeholder base e não passa a herdar apenas porque ocupa as mesmas coordenadas.

## **Alterar Texto em um Placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se é um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) antes de usar seu método [getTextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Este exemplo atualiza o primeiro placeholder de título no primeiro slide e salva o resultado:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esse padrão evita tratar placeholders de imagem, gráfico, tabela ou mídia como objetos [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/). Ele também identifica o placeholder por finalidade em vez de confiar em um índice de forma frágil.

## **Definir Texto de Prompt em um Layout**

Texto de prompt é a instrução exibida em tempo de design em um placeholder vazio, como *Clique para adicionar título*. Defina um texto de prompt personalizado no placeholder de layout ao invés de tentar alcançá‑lo através da coleção de formas de um slide normal. Acesse o layout por meio de [Slide.getLayoutSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getLayoutSlide) e itere sobre a coleção retornada por [BaseSlide.getShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#getShapes).

O exemplo a seguir altera os prompts de título e subtítulo no layout usado pelo primeiro slide:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Texto de prompt não é conteúdo normal de slide. Ele é destinado a placeholders vazios em aplicativos de edição como o PowerPoint. Quando um usuário ou programa fornece conteúdo real, o prompt deixa de ser exibido. Alterar um prompt também não substitui o texto existente nos slides que utilizam o layout.

## **Atualizar um Placeholder de Imagem**

Existem dois casos a serem tratados:

- Se o placeholder de imagem já estiver preenchido e representado por um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/), substitua a imagem através de [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#getPicture) e [Picture.setImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/#setImage).
- Se ainda for um placeholder vazio, adicione um picture frame nas coordenadas do placeholder com [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) e remova o placeholder vazio.

O próximo exemplo suporta ambos os casos e salva a apresentação:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A substituição criada para um placeholder vazio é um picture frame local, não um novo placeholder, porque [Shape.getPlaceholder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getPlaceholder) não fornece um setter. Ele mantém a posição reservada, mas deixa de herdar o comportamento específico de placeholder. Se reter o relacionamento de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, então atualize o [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, corte e outros efeitos específicos de picture, veja [Manage Picture Frames](/slides/pt/nodejs-java/picture-frame/). Essas operações pertencem ao picture frame ou ao picture fill, não aos metadados do placeholder.

## **Trabalhar com Placeholders de Gráfico e Conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/). Este exemplo localiza tal gráfico tanto pelo tipo de placeholder quanto pela classe em tempo de execução, altera seu título e salva o arquivo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um placeholder de conteúdo geral costuma ter [PlaceholderType.Object](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholdertype/#Object). No PowerPoint ele atua como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Depois de preenchido, inspecione a classe real da forma para descobrir o que contém. Layouts especializados podem também expor [PlaceholderType.Chart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholdertype/#Media) ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides não converte um placeholder vazio de [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) em um [Chart](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/) apenas alterando [Placeholder.getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/placeholder/#getType); o tipo não pode ser alterado via objeto. Para preencher programaticamente uma área de gráfico ou conteúdo vazia, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O gráfico adicionado é um gráfico local comum. Ele ocupa a área do placeholder, mas não herda do placeholder de layout. Use os artigos dedicados de [chart management articles](/slides/pt/nodejs-java/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo Completo: Atualizar Texto ou Conteúdo de Imagem**

O exemplo end‑to‑end a seguir abre um modelo, procura no primeiro slide por um placeholder de título ou imagem, verifica os tipos de placeholder e forma, atualiza o conteúdo adequado e salva a saída. O exemplo evita deliberadamente assumir um índice de forma ou tratar todo placeholder como a mesma classe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**O que é um placeholder base?**

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getBasePlaceholder) para recuperá‑lo. Uma forma local comum retorna `null` porque não faz parte da hierarquia de placeholders.

**Posso alterar todos os títulos dos slides editando um placeholder de layout?**

É possível mudar a formatação herdada ou o texto de prompt através de um layout, mas o conteúdo real do título já está armazenado nos slides normais. Para substituir o texto do título em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerenciar placeholders de data, número do slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo adequado: slide, layout, mestre, notas ou folheto. Consulte [Manage Presentation Header and Footer](/slides/pt/nodejs-java/presentation-header-and-footer/) para exemplos completos.