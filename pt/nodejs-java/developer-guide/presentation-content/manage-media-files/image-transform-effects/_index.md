---
title: Gerenciar efeitos de transformação de imagem em apresentações com JavaScript
linktitle: Efeitos de Transformação de Imagem
type: docs
weight: 11
url: /pt/nodejs-java/image-transform-effects/
keywords:
- transformação de imagem
- efeito de imagem
- brilho
- contraste
- escala de cinza
- duotone
- matiz
- HSL
- substituição de cor
- desfoque
- transparência
- efeito alfa
- cadeia de efeitos
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar, encadear, inspecionar, remover e verificar efeitos de transformação de imagem para quadros de imagem com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides representa ajustes de imagem como uma coleção ordenada de operações de transformação de imagem. Para um quadro de imagem, comece com o [Picture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/) do quadro e acesse [Picture.getImageTransform](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/). A [ImageTransformOperationCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) retornada permite acrescentar, enumerar, inspecionar, remover e limpar efeitos sem regravar os bytes da imagem original.

Este artigo demonstra um fluxo de trabalho completo para brilho e contraste, transformações de cor, desfoque, transparência, cadeias de efeitos ordenadas, valores efetivos, remoção e verificação de ida e volta de PPTX.

## **Compreender a Propriedade do Efeito e a Reutilização de Imagens**

Um recurso de imagem e a imagem que o exibe são objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) armazena ou referencia os dados da imagem de origem pertencentes à apresentação.
- [Picture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/) pertence a um preenchimento de imagem e refere-se a um recurso de imagem enquanto armazena a coleção de transformações de imagem.
- [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) é a forma do slide que possui o preenchimento de imagem relevante, geometria, configurações de corte e outras formatações ao nível do quadro.

Portanto, as operações de transformação de imagem não modificam os bytes em [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/). Quando o mesmo [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) é passado para [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/) mais de uma vez, cada novo quadro de imagem recebe seu próprio [Picture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/) e sua própria coleção de transformações. Aplicar escala de cinza a um quadro não deixa os outros quadros em escala de cinza, embora todos reutilizem o mesmo recurso de imagem incorporado.

O mesmo modelo [Picture.getImageTransform](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/) também é usado por outros preenchimentos de imagem, como uma forma ou plano de fundo de slide. Os exemplos abaixo focam em quadros de imagem.

## **Usar Intervalos e Unidades de Parâmetro Válidos**

Os métodos demonstrados utilizam os seguintes intervalos semânticos e unidades. Mantenha os valores dentro desses intervalos mesmo que uma versão específica da biblioteca não rejeite imediatamente cada valor fora do intervalo; o formato de apresentação alvo pode normalizar, omitir ou rejeitar dados inválidos ao salvar ou quando o PowerPoint abrir o arquivo.

| Operação | Parâmetros | Intervalo válido e unidade |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` a `100`, percentual; `0` deixa o componente inalterado. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Nenhum | Sem parâmetros numéricos. Alpha permanece inalterado. |
| [addDuotoneEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Duas cores para pixels escuros e claros. Os canais RGB e alfa em `java.awt.Color` usam de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Matiz (`hue`) de `0` (inclusivo) a `360` (exclusivo), em graus; quantidade (`amount`) de `-100` a `100`, percentual. |
| [addHSLEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Matiz (`hue`) de `0` (inclusivo) a `360` (exclusivo), em graus; saturação e luminância de `-100` a `100`, percentual. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | A cor de substituição usa valores de canal de `0` a `255`. Os valores alfa existentes permanecem inalterados. |
| [addBlurEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Raio (`radius`) é não negativo e medido em pontos; `grow` é um Boolean que controla se o conteúdo desfocado pode se estender além dos limites originais. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Percentual não negativo. Use de `0` a `100` para dimensionamento normal de opacidade: `0` é totalmente transparente e `100` preserva o alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` a `100`, percentual de opacidade. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` a `100`, percentual de limiar alfa. Valores abaixo dele tornam-se transparentes; valores iguais ou acima tornam-se opacos. |

Para modulação alfa fixa, transparência e opacidade são complementares. Por exemplo, 35% de transparência corresponde a um valor de modulação alfa de 65%.

## **Aplicar Brilho e Contraste**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) devolve uma operação [BrightnessContrast](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/brightnesscontrast/). Suas configurações escalares são fornecidas quando a operação é criada. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/brightnesscontrast/) retorna valores calculados somente leitura que podem ser inspecionados ou registrados.

O exemplo a seguir aumenta o brilho em 15% e o contraste em 20%, então renderiza uma pré‑visualização sem modificar a imagem incorporada:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/brightnesscontrast/) é uma extensão de efeito de imagem do Office 2010 e é menos portável que o efeito padrão de luminância DrawingML. Quando brilho e contraste precisam permanecer editáveis após uma ida e volta de PPTX, use [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) e verifique o resultado após reabrir o arquivo. A seção de limitações de formato explica essa distinção em mais detalhes.

## **Aplicar Transformações de Cor**

Efeitos de cor podem ser aplicados independentemente a diferentes quadros de imagem que reutilizam um recurso de imagem. O exemplo a seguir cria cinco quadros e aplica escala de cinza, duotone, matiz, ajuste HSL e substituição de cor.

[Duotone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/duotone/) contém dois parâmetros de cor editáveis independentemente: `color1` mapeia pixels escuros, enquanto `color2` mapeia pixels claros. Isso faz dele um exemplo útil de um efeito cujas configurações são mais complexas que um único valor escalar.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) substitui a cor de cada pixel por uma cor fixa, preservando o alfa. É diferente de [addColorChangeEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/), que mapeia uma cor de origem para outra e expõe ambos os formatos de cor origem e destino.

## **Adicionar Desfoque, Transparência e Efeitos Alfa**

[addBlurEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) afeta todos os canais de cor, incluindo alfa. Defina `grow` como `true` quando a borda desfocada puder se estender além dos limites da imagem original.

Para transparência uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/). Ele multiplica cada valor alfa existente, de modo que pixels parcialmente transparentes permanecem proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) atribui um único valor alfa a todos os pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) converte o alfa para dois níveis com base em um limiar.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Outras operações alfa sem parâmetros incluem [addAlphaCeilingEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/), que torna todo alfa diferente de zero completamente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/), que torna todo alfa abaixo de 100% totalmente transparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/), que altera o alfa para `100% - alpha`.

## **Construir uma Cadeia de Efeitos Ordenada**

Cada método `add...Effect` acrescenta uma nova operação ao final da coleção. O renderizador usa a coleção como um pipeline ordenado: a saída da operação 0 torna‑se a entrada da operação 1 e assim sucessivamente. Consequentemente, as mesmas operações em ordem diferente podem produzir uma imagem diferente.

Por exemplo, escala de cinza seguida de matiz primeiro remove a informação cromática e depois recolore o resultado de luminância. Matiz seguida de escala de cinza remove novamente a matiz. De forma similar, a substituição alfa pode sobrescrever valores alfa calculados por operações anteriores, enquanto a modulação alfa preserva suas diferenças relativas.

O exemplo a seguir cria uma cadeia de quatro operações, salva como PPTX, reabre a apresentação, verifica tanto os tipos de operação quanto sua ordem e renderiza o resultado reaberto:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

A coleção não impõe uma matriz de compatibilidade que restrinja operações de cor, alfa e desfoque a cadeias separadas. Elas podem ser combinadas, mas combinações nem sempre são úteis. Uma substituição de cor fixa remove a variação RGB produzida por efeitos de cor anteriores; escala de cinza após duotone remove as duas cores selecionadas; e operações de teto, piso, substituição ou bi‑nível alfa podem descartar detalhes de alfa criados anteriormente. Construa a cadeia de acordo com a sequência desejada de processamento de pixels, em vez de tratar seus itens como bandeiras de formatação desordenadas.

## **Inspecionar Valores Editáveis e Efetivos**

Uma operação editável é o objeto armazenado em [Picture.getImageTransform](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/). Dependendo do efeito, ele pode expor membros graváveis diretamente. Por exemplo, [Blur](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/blur/) expõe os valores graváveis `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/alphamodulatefixed/) expõe um `amount` gravável e [AlphaBiLevel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/alphabilevel/) expõe um `threshold` gravável. Efeitos de cor como [Duotone](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/duotone/) expõem objetos mutáveis [ColorFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/colorformat/).

Algumas operações, incluindo [BrightnessContrast](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tint/) e [AlphaReplace](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/alphareplace/), não expõem seus escalares de criação como propriedades graváveis. Para alterar essas configurações, remova a operação e adicione uma substituição na posição necessária.

Os dados efetivos retornados por `getEffective()` são calculados e somente leitura. Eles são úteis para resolver cores dependentes de tema e ler os valores normalizados que o renderizador usa, mas não constituem outra superfície de edição. O exemplo a seguir enumera a cadeia e inspeciona valores efetivos onde a API correspondente os fornece:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efeitos sem parâmetros, como escala de cinza, teto alfa e inversão alfa, ainda possuem um objeto de dados efetivo, porém não há configurações escalares para imprimir. Sua presença e posição na coleção são as informações importantes.

## **Remover ou Limpar Transformações de Imagem**

Use [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) para remover uma operação por índice. Como os índices mudam após a remoção, procure o alvo primeiro e remova‑o após a enumeração. Use [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) para remover toda a cadeia.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Remover ou limpar transformações altera apenas a formatação da imagem. Não exclui, recomprime ou altera de outra forma o recurso [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) reutilizado.

## **Considerar Formatos de Apresentação e Destinos de Exportação**

Transformações de imagem originam‑se no DrawingML, por isso o PPTX é o formato editável preferido para cadeias de efeitos. Mesmo com PPTX, nem toda operação tem portabilidade idêntica:

- Operações padrão do DrawingML, como luminância, escala de cinza, duotone, matiz, HSL, desfoque e operações alfa comuns, têm maior chance de sobreviver a uma ida e volta de PPTX. Sempre reabra o arquivo gerado e inspecione a coleção quando a preservação for exigida.
- [BrightnessContrast](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/brightnesscontrast/) é uma extensão do Office 2010, não a operação padrão de luminância DrawingML. Pode ser usado para renderização em memória, mas não há garantia de que permanecerá como uma operação editável [BrightnessContrast](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/brightnesscontrast/) após salvar e reabrir o PPTX. Prefira [addLuminanceEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) para ajustes persistentes de brilho e contraste.
- O formato binário PPT antecede o modelo completo de efeitos DrawingML. Salvar em PPT pode omitir operações não suportadas, reduzir a cadeia a um subconjunto suportado ou aproximar a aparência. Não use PPT como formato de verificação para uma cadeia editável complexa.
- Renderizar para PNG, JPEG, TIFF, PDF, SVG, HTML ou outra saída visual aplica a cadeia suportada à aparência renderizada. Essas saídas não contêm uma [ImageTransformOperationCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/imagetransformoperationcollection/) editável; formatos raster planificam o resultado em pixels, e exportações de documento/vetor armazenam sua própria representação de renderização.
- Efeitos não tornam uma imagem vinculada autocontida. Renderizar uma imagem vinculada ainda depende de o recurso vinculado estar disponível quando a apresentação for carregada.

Consumidores diferentes de apresentações podem renderizar casos‑limite de forma distinta, especialmente quando várias operações alfa ou de quantização de cor são combinadas. Para resultados críticos, teste tanto a ida e volta editável quanto o formato de exportação final com a mesma versão do Aspose.Slides usada em produção.

## **FAQ**

**Os efeitos de transformação de imagem modificam os dados da imagem incorporada?**

Não. As operações pertencem ao [Picture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/) usado pelo preenchimento da imagem. Os bytes subjacentes de [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) permanecem inalterados.

**Dois quadros de imagem que reutilizam a mesma imagem compartilham seus efeitos?**

Não. Reutilizar um [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) evita dados duplicados de imagem, mas cada quadro de imagem normalmente tem um [Picture](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picture/) e uma coleção de transformações de imagem separados.

**Efeitos de cor, desfoque e alfa podem ser combinados?**

Sim. A coleção aceita todos em uma única cadeia ordenada. Considere o que cada operação faz à saída da anterior, pois operações de substituição e limiar podem descartar detalhes de cor ou alfa anteriores.

**Por que os valores efetivos são somente leitura?**

Os dados efetivos representam valores calculados usados para renderização, incluindo cores resolvidas. Edite a operação armazenada na coleção de transformações onde houver membros graváveis; caso contrário, remova‑a e adicione uma substituição com novos parâmetros de criação.

**Qual formato devo usar para preservar uma cadeia de transformações?**

Use PPTX e verifique o arquivo reabrindo‑o. O PPT legado não pode representar o modelo completo de efeitos DrawingML, e os formatos de exportação renderizados preservam apenas a aparência, não as operações de transformação editáveis.