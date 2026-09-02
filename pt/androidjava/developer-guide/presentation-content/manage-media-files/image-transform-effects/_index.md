---
title: Gerenciar efeitos de transformação de imagem em apresentações no Android
linktitle: Efeitos de transformação de imagem
type: docs
weight: 11
url: /pt/androidjava/image-transform-effects/
keywords:
- transformação de imagem
- efeito de imagem
- brilho
- contraste
- escala de cinza
- duotone
- tonalidade
- HSL
- substituição de cor
- desfoque
- transparência
- efeito alfa
- cadeia de efeitos
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aplicar, encadear, inspecionar, remover e verificar efeitos de transformação de imagem para quadros de imagem com Aspose.Slides para Android via Java."
---
## **Visão geral**

Aspose.Slides representa ajustes de imagem como uma coleção ordenada de operações de transformação de imagem. Para um quadro de imagem, comece com o [ISlidesPicture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidespicture/) e acesse [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). A [IImageTransformOperationCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/) retornada permite acrescentar, enumerar, inspecionar, remover e limpar efeitos sem reescrever os bytes da imagem original.

Este artigo demonstra um fluxo de trabalho completo para brilho e contraste, transformações de cor, desfoque, transparência, cadeias de efeitos ordenadas, valores efetivos, remoção e verificação de ida‑e‑volta em PPTX.

## **Entenda a Posse do Efeito e a Reutilização da Imagem**

Um recurso de imagem e a imagem que a exibe são objetos diferentes:

- [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) armazena ou faz referência aos dados de imagem de origem pertencentes à apresentação.
- [ISlidesPicture](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidespicture/) pertence ao preenchimento da imagem e refere‑se a um recurso de imagem enquanto armazena a coleção de transformações de imagem.
- [IPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipictureframe/) é a forma do slide que possui o preenchimento da imagem relevante, geometria, configurações de recorte e outras formatações ao nível do quadro.

Portanto, as operações de transformação de imagem não modificam os bytes em [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/). Quando o mesmo `IPPImage` é passado para [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) mais de uma vez, cada novo quadro de imagem recebe seu próprio `ISlidesPicture` e sua própria coleção de transformações. Aplicar escala de cinza a um quadro não torna os outros quadros em escala de cinza, embora todos reutilizem o mesmo recurso de imagem incorporado.

O mesmo modelo `ISlidesPicture.getImageTransform` também é usado por outros preenchimentos de imagem, como forma ou plano de fundo de slide. Os exemplos abaixo concentram‑se em quadros de imagem.

## **Use Intervalos e Unidades de Parâmetro Válidos**

Os métodos demonstrados utilizam os seguintes intervalos semânticos e unidades. Mantenha os valores dentro desses intervalos mesmo que uma versão específica da biblioteca não rejeite imediatamente valores fora do intervalo; o formato de destino da apresentação pode normalizar, omitir ou rejeitar dados inválidos ao salvar ou quando o PowerPoint abrir o arquivo.

| Operação | Parâmetros | Intervalo válido e unidade |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` a `100`, porcentagem; `0` deixa o componente inalterado. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Nenhum | Sem parâmetros numéricos. Alpha permanece inalterado. |
| [addDuotoneEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Duas cores para pixels escuros e claros. Valores RGB e do canal alfa usados por `android.graphics.Color` variam de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Matiz de `0` (inclusive) a `360` (exclusive), em graus; quantidade de `-100` a `100`, porcentagem. |
| [addHSLEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Matiz de `0` (inclusive) a `360` (exclusive), em graus; saturação e luminância de `-100` a `100`, porcentagem. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | A cor de substituição usa valores de canal de `0` a `255`. Valores alfa existentes permanecem inalterados. |
| [addBlurEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Raio não negativo medido em pontos; `grow` é um Boolean que controla se o conteúdo desfocado pode se estender fora dos limites originais. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Porcentagem não negativa. Use `0` a `100` para escala de opacidade comum: `0` é totalmente transparente e `100` preserva o alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` a `100`, porcentagem de opacidade. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` a `100`, porcentagem de limiar alfa. Valores abaixo dele tornam‑se transparentes; valores iguais ou acima tornam‑se opacos. |

Para modulação de alfa fixa, transparência e opacidade são complementares. Por exemplo, 35 % de transparência corresponde a uma quantidade de modulação alfa de 65 %.

## **Aplicar Brilho e Contraste**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) retorna uma operação [IBrightnessContrast](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibrightnesscontrast/). Suas configurações escalares são fornecidas quando a operação é criada. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) devolve valores calculados somente de leitura que podem ser inspecionados ou registrados.

O exemplo a seguir aumenta o brilho em 15 % e o contraste em 20 %, então renderiza uma pré‑visualização sem modificar a imagem incorporada:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/brightnesscontrast/) é uma extensão de efeito de imagem do Office 2010 e é menos portátil que o efeito de luminância padrão do DrawingML. Quando brilho e contraste precisam permanecer editáveis após uma ida‑e‑volta em PPTX, use [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) e verifique o resultado após reabrir o arquivo. A seção de limitações de formato explica essa distinção com mais detalhes.

## **Aplicar Transformações de Cor**

Efeitos de cor podem ser aplicados independentemente a diferentes quadros de imagem que reutilizam um mesmo recurso de imagem. O exemplo a seguir cria cinco quadros e aplica escala de cinza, duotone, tonalidade, ajuste HSL e substituição de cor.

[IDuotone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iduotone/) contém dois parâmetros de cor editáveis independentemente: `color1` mapeia pixels escuros, enquanto `color2` mapeia pixels claros. Isso o torna um exemplo útil de efeito cujas configurações são mais complexas que um único valor escalar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) substitui a cor de cada pixel por uma cor fixa, preservando o alfa. É diferente de [addColorChangeEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), que mapeia uma cor de origem para outra e expõe ambos os formatos de cor de origem e destino.

## **Adicionar Desfoque, Transparência e Efeitos Alfa**

[addBlurEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) afeta todos os canais de cor, incluindo alfa. Defina `grow` como `true` quando a borda desfocada puder se estender além dos limites originais da imagem.

Para transparência uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Ele multiplica cada valor alfa existente, de modo que pixels parcialmente transparentes permanecem proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) atribui um único valor alfa a todos os pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) converte o alfa em dois níveis com base em um limiar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Outras operações alfa sem parâmetros incluem [addAlphaCeilingEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), que torna todo alfa diferente de zero totalmente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), que torna todo alfa abaixo de 100 % totalmente transparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), que altera o alfa para `100% - alfa`.

## **Construir uma Cadeia de Efeitos Ordenada**

Cada método `add...Effect` acrescenta uma nova operação ao final da coleção. O renderizador usa a coleção como um pipeline ordenado: a saída da operação 0 torna‑se a entrada da operação 1, e assim sucessivamente. Consequentemente, as mesmas operações em uma ordem diferente podem produzir uma imagem diferente.

Por exemplo, escala de cinza seguida de tonalidade primeiro remove a informação cromática e depois recoloriza o resultado de luminância. Tonalidade seguida de escala de cinza remove a tonalidade novamente. De forma semelhante, a substituição alfa pode sobrescrever valores alfa calculados por operações anteriores, enquanto a modulação alfa preserva suas diferenças relativas.

O exemplo a seguir constrói uma cadeia de quatro operações, salva como PPTX, reabre a apresentação, verifica tanto os tipos de operação quanto a ordem, e renderiza o resultado reaberto:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

A coleção não impõe uma matriz de compatibilidade que restrinja operações de cor, alfa e desfoque a cadeias separadas. Elas podem ser combinadas, embora nem todas as combinações sejam úteis. Uma substituição de cor fixa elimina a variação RGB produzida por efeitos de cor anteriores; escala de cinza após duotone elimina as duas cores selecionadas; e as operações alfa de teto, piso, substituição ou bi‑nível podem descartar detalhes alfa criados anteriormente. Construa a cadeia de acordo com a sequência desejada de processamento de pixels, em vez de tratar seus itens como sinalizadores de formatação sem ordem.

## **Inspecionar Valores Editáveis e Efetivos**

Uma operação editável é o objeto armazenado em `ISlidesPicture.getImageTransform`. Dependendo do efeito, ele pode expor membros graváveis diretamente. Por exemplo, [IBlur](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iblur/) expõe valores graváveis `radius` e `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ialphamodulatefixed/) expõe um gravável `amount`, e [IAlphaBiLevel](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ialphabilevel/) expõe um gravável `threshold`. Efeitos de cor como [IDuotone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iduotone/) expõem objetos mutáveis [IColorFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icolorformat/).

Algumas interfaces de operação, incluindo [IBrightnessContrast](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itint/) e [IAlphaReplace](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ialphareplace/), não expõem seus escalares de criação como propriedades graváveis. Para alterar essas configurações, remova a operação e adicione uma substituta na posição necessária.

Os dados efetivos retornados por `getEffective()` são calculados e somente de leitura. Eles são úteis para resolver cores dependentes de tema e ler os valores normalizados que o renderizador usa, mas não constituem outra superfície de edição. O exemplo a seguir enumera a cadeia e inspeciona valores efetivos onde a API correspondente os fornece:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efeitos sem parâmetros, como escala de cinza, teto alfa e inversão alfa, ainda possuem um objeto de dados efetivo, porém não há configurações escalares para imprimir. Sua presença e posição na coleção são as informações importantes.

## **Remover ou Limpar Transformações de Imagem**

Use [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) para remover uma operação por índice. Como os índices mudam após a remoção, procure o alvo primeiro e remova‑o depois da enumeração. Use [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) para remover toda a cadeia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Remover ou limpar transformações altera apenas a formatação da imagem. Não exclui, recomprime ou altera de outra forma o recurso reutilizado [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/).

## **Considere Formatos de Apresentação e Destinos de Exportação**

As transformações de imagem originam‑se no DrawingML, portanto PPTX é o formato editável preferido para cadeias de efeito. Mesmo com PPTX, nem toda operação tem portabilidade idêntica:

- Operações padrão do DrawingML como luminância, escala de cinza, duotone, tonalidade, HSL, desfoque e operações alfa comuns têm a maior chance de sobreviver a uma ida‑e‑volta em PPTX. Sempre reabra o arquivo gerado e inspecione a coleção quando a preservação for necessária.
- [BrightnessContrast](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/brightnesscontrast/) é uma extensão do Office 2010, não a operação padrão de luminância do DrawingML. Pode ser usada para renderização em memória, mas não há garantia de que permaneça como um [IBrightnessContrast](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibrightnesscontrast/) editável após salvar e reabrir o PPTX. Prefira [addLuminanceEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) para ajustes persistentes de brilho e contraste.
- O formato binário PPT precede o modelo completo de efeitos DrawingML. Salvar em PPT pode omitir operações não suportadas, reduzir uma cadeia a um subconjunto suportado ou aproximar a aparência. Não use PPT como formato de verificação para uma cadeia editável complexa.
- Renderizar para PNG, JPEG, TIFF, PDF, SVG, HTML ou outra saída visual aplica a cadeia suportada à aparência renderizada. Essas saídas não contêm uma `IImageTransformOperationCollection` editável; formatos raster nivelam o resultado em pixels, e exportações de documento/vetor armazenam sua própria representação de renderização.
- Efeitos não tornam uma imagem vinculada autônoma. Renderizar uma imagem vinculada ainda depende que o recurso vinculado esteja disponível quando a apresentação for carregada.

Consumidores diferentes de apresentações podem renderizar casos de borda de forma distinta, especialmente quando várias operações alfa ou de quantização de cor são combinadas. Para resultados críticos, teste tanto a ida‑e‑volta editável quanto o formato de exportação final com a mesma versão do Aspose.Slides usada em produção.

## **FAQ**

**Os efeitos de transformação de imagem modificam os dados da imagem incorporada?**

Não. As operações pertencem ao `ISlidesPicture` usado pelo preenchimento da imagem. Os bytes subjacentes de `IPPImage` permanecem inalterados.

**Dois quadros de imagem que reutilizam a mesma imagem compartilham seus efeitos?**

Não. Reutilizar um `IPPImage` evita dados de imagem duplicados, mas cada quadro de imagem normalmente tem seu próprio `ISlidesPicture` e sua própria coleção de transformações.

**É possível combinar efeitos de cor, desfoque e alfa?**

Sim. A coleção aceita todos em uma única cadeia ordenada. Considere o que cada operação faz à saída da anterior, pois operações de substituição e limiar podem descartar detalhes de cor ou alfa produzidos anteriormente.

**Por que os valores efetivos são somente de leitura?**

Os dados efetivos representam valores calculados usados para renderização, incluindo cores resolvidas. Edite a operação armazenada na coleção de transformações onde existirem membros graváveis; caso contrário, remova‑a e adicione uma substituta com novos parâmetros de criação.

**Qual formato devo usar para preservar uma cadeia de transformações?**

Use PPTX e verifique o arquivo reabrindo‑o. O PPT legado não pode representar o modelo completo de efeitos DrawingML, e os formatos de exportação renderizados preservam apenas a aparência, não as operações de transformação editáveis.