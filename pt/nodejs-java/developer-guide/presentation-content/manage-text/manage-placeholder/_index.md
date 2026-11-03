---
title: Gerenciar Marcadores de Posição de Apresentação em JavaScript
linktitle: Gerenciar Marcadores
type: docs
weight: 10
url: /pt/nodejs-java/manage-placeholder/
keywords:
- marcador de posição
- marcador de texto
- marcador de imagem
- marcador de gráfico
- marcador de conteúdo
- texto de sugestão
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a inspecionar e editar marcadores de texto, imagem, gráfico e conteúdo e a entender a herança de marcadores com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Um placeholder é uma forma que reserva uma posição para um determinado tipo de conteúdo em um modelo de apresentação. Exemplos comuns são placeholders de título, corpo, imagem, gráfico e placeholders de conteúdo de uso geral. Ao contrário de uma forma ordinária, um placeholder pode herdar sua posição, tamanho, formatação e outras configurações de um slide de layout ou de um slide mestre.

Aspose.Slides expõe informações de placeholder através do método [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). O método devolve um objeto [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) ou `null` para uma forma normal. Use [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) para determinar o que o placeholder deve conter.

A classe de forma ainda importa depois que você souber o tipo de placeholder:

- Um placeholder vazio de texto, imagem, gráfico ou conteúdo é normalmente representado por um [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Um placeholder de imagem já preenchido pode ser representado por um [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Um placeholder de gráfico já preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Um placeholder de conteúdo pode conter vários tipos de conteúdo. Verifique tanto [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) quanto a classe de forma em tempo de execução, em vez de assumir que todo placeholder é um [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) descreve o papel de um placeholder; ele não garante o tipo de forma em tempo de execução. Sempre verifique o tipo antes de acessar membros específicos de texto, imagem, gráfico, tabela ou mídia.
{{% /alert %}}

## **Entender herança de placeholder**

Os placeholders formam uma hierarquia:

1. Um slide mestre define estilos reutilizáveis e, em alguns casos, placeholders de nível mestre.
2. Um slide de layout define o arranjo usado por um ou mais slides normais e pode herdar do mestre.
3. Um slide normal contém os placeholders para esse slide e pode herdar do seu layout.

Chame [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) para subir um nível nessa hierarquia. Um placeholder de slide normalmente devolve seu placeholder de layout; um placeholder de layout pode devolver seu placeholder mestre. O método devolve `null` quando a forma não possui placeholder base.

O exemplo a seguir lista os placeholders do primeiro slide e relata seus placeholders base:

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

Editar um placeholder em um slide normal cria ou altera uma sobrescrita local para esse slide. Editar o layout ou o mestre relacionado pode afetar todos os slides que ainda herdarem essa configuração. Uma forma ordinária local não tem placeholder base e não começa a herdar apenas porque ocupa as mesmas coordenadas.

## **Remover status de placeholder**

Ao adaptar um modelo, use [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) para manter um objeto existente como uma forma ordinária. Seu método [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) devolve `null`, mas a forma permanece na coleção do slide. Em contraste, [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) exclui a forma dessa coleção.

O exemplo a seguir requer `template.pptx` com ao menos um slide e um placeholder de texto não vazio no primeiro slide. Use um placeholder com formatação herdada do seu layout ou mestre para ver o efeito de remover esse relacionamento. O exemplo verifica se a mesma forma permanece, chama o método novamente na forma agora ordinária e salva o resultado.

{{% alert color="warning" title="Warning" %}}
Remover o status de placeholder não preserva automaticamente as configurações de aparência herdadas. O exemplo abaixo deixa essas configurações intencionalmente inalteradas, portanto a saída pode parecer diferente. Uma forma cuja posição e tamanho são totalmente herdados pode ter coordenadas e dimensões zero após a chamada e tornar‑se invisível, ainda que permaneça na coleção.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Chamando o método em uma forma ordinária não tem efeito.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Para um placeholder correspondente, as três verificações imprimem `true`. O texto permanece, mas posição, tamanho, rotação, fonte, alinhamento de parágrafo, margens do quadro de texto, ancoragem vertical, preenchimento e configurações de linha herdadas podem mudar quando o relacionamento de placeholder é removido. Por exemplo, a formatação de título herdada pode voltar à formatação de texto ordinária. Veja [Layout de slide](/slides/pt/nodejs-java/slide-layout/) para mais informações sobre layouts.

Para preservar a aparência desejada, capture a posição, tamanho e rotação resolvidos antes da chamada e copie os valores de formatação efetiva necessários em variáveis separadas. Recupere esses valores através de [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) e [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Não confie apenas nos objetos de formatação efetiva, pois seus valores de formatação de texto podem mudar após a remoção do relacionamento. Aplique explicitamente os valores capturados à forma ordinária posteriormente, incluindo família, tamanho, estilo, cor da fonte, configurações de parágrafo, configurações de quadro de texto, preenchimento e linha usados pelo seu modelo.

A geometria de forma herdada também pode precisar ser atribuída explicitamente através de [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). Para um placeholder de texto retangular, isso significa atribuir [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); restaurar apenas o preenchimento e a linha pode não restaurar o retângulo visível. Modelos com efeitos adicionais ou formatação mais complexa requerem que essas configurações sejam tratadas também.

## **Alterar texto em um placeholder**

Placeholders de título, título centralizado, subtítulo, corpo e texto normalmente suportam texto. Verifique se é um [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) antes de usar seu método [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame).

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

Esse padrão evita tratar placeholders de imagem, gráfico, tabela ou mídia como objetos [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/). Ele também identifica o placeholder por finalidade em vez de depender de um índice frágil de forma.

## **Definir texto de sugestão em um layout**

O texto de sugestão é a instrução de design exibida em um placeholder vazio, como *Clique para adicionar título*. Defina texto de sugestão personalizado no placeholder de layout em vez de tentar alcançá‑lo através da coleção de formas de um slide normal. Acesse o layout por meio de [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) e itere sobre a coleção retornada por [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

O exemplo a seguir altera as sugestões de título e subtítulo no layout usado pelo primeiro slide:

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

Texto de sugestão não é conteúdo de slide normal. Ele destina‑se a placeholders vazios em aplicativos de edição como o PowerPoint. Quando um usuário ou programa fornece conteúdo real, a sugestão deixa de ser exibida. Alterar uma sugestão também não substitui texto existente em slides que usam o layout.

## **Atualizar um placeholder de imagem**

Existem dois casos a tratar:

- Se o placeholder de imagem já estiver preenchido e representado por um [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), substitua a imagem através de [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) e [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Se ainda for um placeholder vazio, adicione um quadro de imagem nas coordenadas do placeholder com [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) e remova o placeholder vazio.

O próximo exemplo dá suporte a ambos os casos e salva a apresentação:

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

A substituição criada para um placeholder vazio é um quadro de imagem local, não um novo placeholder, porque [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) não oferece um setter. Ele mantém a posição reservada, mas não herda mais o comportamento específico de placeholder. Se manter o relacionamento de placeholder for essencial, prepare e preencha o placeholder no PowerPoint primeiro, então atualize o [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) resultante com Aspose.Slides.

Para transparência de imagem, recorte e outros efeitos específicos de imagem, veja [Gerenciar quadros de imagem](/slides/pt/nodejs-java/picture-frame/). Essas operações pertencem ao quadro de imagem ou ao preenchimento da imagem, não aos metadados do placeholder.

## **Trabalhar com placeholders de gráfico e de conteúdo**

Um placeholder de gráfico preenchido pode ser representado por um [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Este exemplo encontra tal gráfico tanto pelo tipo de placeholder quanto pela classe em tempo de execução, altera seu título e salva o arquivo:

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

Um placeholder de conteúdo geral geralmente tem [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). No PowerPoint ele atua como um lançador para vários tipos de conteúdo, incluindo gráficos, tabelas, diagramas, imagens e mídia. Depois de preenchido, inspecione a classe real da forma para saber o que contém. Layouts especializados também podem expor [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides não converte um placeholder vazio de [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) em um [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) apenas alterando [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); o tipo não pode ser alterado através do objeto. Para preencher programaticamente uma área vazia de gráfico ou conteúdo, adicione o objeto necessário nas coordenadas do placeholder e então remova o placeholder vazio. O exemplo a seguir faz isso para um gráfico:

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

O gráfico adicionado é um gráfico local ordinário. Ele ocupa a área do placeholder, mas não herda do placeholder de layout. Use os artigos dedicados de [gerenciamento de gráficos](/slides/pt/nodejs-java/powerpoint-charts/) quando precisar substituir categorias, séries ou dados da planilha.

## **Exemplo completo: atualizar texto ou conteúdo de imagem**

O exemplo de ponta a ponta a seguir abre um modelo, procura no primeiro slide por um placeholder de título ou de imagem, verifica os tipos de placeholder e de forma, atualiza o conteúdo apropriado e salva o resultado. O exemplo evita deliberadamente assumir um índice de forma ou tratar todo placeholder como da mesma classe.

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

Um placeholder base é a forma correspondente no layout ou mestre da qual outro placeholder herda. Use [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) para recuperá‑lo. Uma forma local ordinária devolve `null` porque não faz parte da hierarquia de placeholders.

**Posso alterar todos os títulos de slide editando um placeholder de layout?**

Você pode alterar a formatação herdada ou o texto de sugestão através de um layout, mas o conteúdo real do título está armazenado nos slides normais. Para substituir o texto real dos títulos em toda a apresentação, itere sobre os slides e atualize cada placeholder de título.

**Como gerenciar placeholders de data, número de slide, cabeçalho e rodapé?**

Use os gerenciadores de cabeçalho e rodapé no escopo adequado de slide, layout, mestre, notas ou folheto. Consulte [Gerenciar cabeçalho e rodapé da apresentação](/slides/pt/nodejs-java/presentation-header-and-footer/) para exemplos completos.