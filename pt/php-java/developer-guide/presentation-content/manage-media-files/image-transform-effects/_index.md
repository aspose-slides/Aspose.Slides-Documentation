---
title: Gerenciar efeitos de transformação de imagem em apresentações com PHP
linktitle: Efeitos de Transformação de Imagem
type: docs
weight: 11
url: /pt/php-java/image-transform-effects/
keywords:
- transformação de imagem
- efeito de imagem
- brilho
- contraste
- escala de cinza
- duotono
- tonalidade
- HSL
- substituição de cor
- desfoque
- transparência
- efeito alfa
- cadeia de efeitos
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aplicar, encadear, inspecionar, remover e verificar efeitos de transformação de imagem para quadros de imagem com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Aspose.Slides representa ajustes de imagem como uma coleção ordenada de operações de transformação de imagem. Para um quadro de imagem, comece com o [Picture](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picture/) e acesse [Picture::getImageTransform](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picture/getimagetransform/). A [ImageTransformOperationCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/) retornada permite acrescentar, enumerar, inspecionar, remover e limpar efeitos sem reescrever os bytes da imagem original.

Este artigo demonstra um fluxo de trabalho completo para brilho e contraste, transformações de cor, desfoque, transparência, cadeias de efeitos ordenadas, valores efetivos, remoção e verificação de ida e volta em PPTX.

## **Compreender a Propriedade dos Efeitos e a Reutilização de Imagens**

Um recurso de imagem e a imagem que a exibe são objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) armazena ou referencia os dados da imagem fonte pertencentes à apresentação.
- [Picture](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picture/) pertence a um preenchimento de imagem e refere-se a um recurso de imagem enquanto armazena a coleção de transformações de imagem.
- [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe/) é a forma de slide que possui o preenchimento de imagem relevante, geometria, configurações de recorte e demais formatações ao nível do quadro.

Portanto, as operações de transformação de imagem não modificam os bytes em [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/). Quando o mesmo `PPImage` é passado para [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addpictureframe/) mais de uma vez, cada novo quadro de imagem recebe seu próprio `Picture` e sua própria coleção de transformações. Aplicar escala de cinza a um quadro não torna os outros quadros em escala de cinza, mesmo que todos reutilizem o mesmo recurso de imagem incorporado.

O mesmo modelo `Picture::getImageTransform` também é usado por outros preenchimentos de imagem, como uma forma ou o plano de fundo do slide. Os exemplos abaixo focam em quadros de imagem.

## **Usar Intervalos de Parâmetros e Unidades Válidos**

Os métodos demonstrados utilizam os seguintes intervalos semânticos e unidades. Mantenha os valores dentro desses intervalos mesmo que uma determinada versão da biblioteca não rejeite imediatamente todo valor fora do intervalo; o formato de apresentação alvo pode normalizar, omitir ou rejeitar dados inválidos durante a gravação ou quando o PowerPoint abre o arquivo.

| Operação | Parâmetros | Intervalo válido e unidade |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` até `100`, em porcentagem; `0` deixa o componente inalterado. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Nenhum | Sem parâmetros numéricos. Alfa permanece inalterado. |
| [addDuotoneEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Duas cores para pixels escuros e claros. Canais RGB e alfa em `java.awt.Color` usam de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Matiz (`hue`) de `0` inclusive até `360` exclusivo, em graus; quantidade (`amount`) de `-100` a `100`, em porcentagem. |
| [addHSLEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Matiz (`hue`) de `0` inclusive até `360` exclusivo, em graus; saturação e luminância de `-100` a `100`, em porcentagem. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | A cor de substituição usa valores de canal de `0` a `255`. Valores alfa existentes permanecem inalterados. |
| [addBlurEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Raio não negativo medido em pontos; `grow` é um Boolean que controla se o conteúdo desfocado pode se estender fora dos limites originais. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Percentual não negativo. Use `0` a `100` para escala de opacidade convencional: `0` é totalmente transparente e `100` preserva o alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` a `100`, porcentagem de opacidade. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` a `100`, porcentagem de limiar alfa. Valores abaixo dele tornam-se transparentes; valores iguais ou acima tornam-se opacos. |

Para modulação alfa fixa, transparência e opacidade são complementares. Por exemplo, 35 % de transparência corresponde a um valor de modulação alfa de 65 %.

## **Aplicar Brilho e Contraste**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) retorna uma operação [Luminance](https://reference.aspose.com/slides/pt/php-java/aspose.slides/luminance/). Suas configurações escalares são fornecidas quando a operação é criada. [Luminance::getEffective](https://reference.aspose.com/slides/pt/php-java/aspose.slides/luminance/geteffective/) devolve valores calculados somente leitura que podem ser inspecionados ou registrados.

O exemplo a seguir aumenta o brilho em 15 % e o contraste em 20 %, então renderiza uma pré-visualização sem modificar a imagem incorporada:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` é o efeito padrão de brilho e contraste do DrawingML. Quando essas configurações precisam permanecer editáveis após um ciclo de ida e volta em PPTX, reabra a apresentação salva e verifique tanto o tipo da operação quanto seus valores efetivos.

## **Aplicar Transformações de Cor**

Os efeitos de cor podem ser aplicados independentemente a diferentes quadros de imagem que reutilizam um recurso de imagem. O exemplo a seguir cria cinco quadros e aplica escala de cinza, duotone, tonalidade, ajuste HSL e substituição de cor.

[Duotone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/duotone/) contém dois parâmetros de cor editáveis independentemente: `color1` mapeia pixels escuros, enquanto `color2` mapeia pixels claros. Isso o torna um exemplo útil de um efeito cujas configurações são mais complexas que um único valor escalar.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) substitui a cor de cada pixel por uma cor fixa, preservando o alfa. É diferente de [addColorChangeEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), que mapeia uma cor de origem para outra e expõe ambos os formatos de cor origem e destino.

## **Adicionar Desfoque, Transparência e Efeitos Alfa**

[addBlurEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) afeta todos os canais de cor, incluindo alfa. Defina `grow` como `true` quando a borda desfocada puder se estender além dos limites originais da imagem.

Para transparência uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Ele multiplica cada valor alfa existente, de modo que pixels parcialmente transparentes permanecem proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) atribui um único valor alfa a todos os pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) converte o alfa para dois níveis baseados em um limiar.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Outras operações alfa sem parâmetros incluem [addAlphaCeilingEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), que torna todo alfa diferente de zero totalmente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), que torna todo alfa abaixo de 100 % totalmente transparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), que altera o alfa para `100% - alpha`.

## **Construir uma Cadeia de Efeitos Ordenada**

Cada método `add...Effect` acrescenta uma nova operação ao final da coleção. O renderizador usa a coleção como um pipeline ordenado: a saída da operação 0 torna‑se a entrada da operação 1, e assim por diante. Consequentemente, as mesmas operações em ordem diferente podem produzir uma imagem diferente.

Por exemplo, escala de cinza seguida de tonalidade primeiro remove informações cromáticas e depois recolore o resultado de luminância. Tonalidade seguida de escala de cinza remove a tonalidade novamente. De forma semelhante, a substituição alfa pode sobrescrever valores alfa calculados por operações anteriores, enquanto a modulação alfa preserva suas diferenças relativas.

O exemplo a seguir cria uma cadeia de quatro operações, salva‑a como PPTX, reabre a apresentação, verifica tanto os tipos de operação quanto a ordem, e renderiza o resultado reaberto:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

A coleção não impõe uma matriz de compatibilidade que restrinja operações de cor, alfa e desfoque a cadeias separadas. Elas podem ser combinadas, mas as combinações nem sempre são úteis. Uma substituição de cor fixa remove a variação RGB produzida por efeitos de cor anteriores; escala de cinza após duotone remove as duas cores selecionadas; e operações de teto, piso, substituição ou bi‑nível alfa podem descartar detalhes de alfa criados anteriormente. Construa a cadeia de acordo com a sequência desejada de processamento de pixels, em vez de tratar seus itens como bandeiras de formatação desordenadas.

## **Inspecionar Valores Editáveis e Efetivos**

Uma operação editável é o objeto armazenado em `Picture::getImageTransform`. Dependendo do efeito, ele pode expor membros graváveis diretamente. Por exemplo, [Blur](https://reference.aspose.com/slides/pt/php-java/aspose.slides/blur/) expõe valores graváveis `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/pt/php-java/aspose.slides/alphamodulatefixed/) expõe um `amount` gravável, e [AlphaBiLevel](https://reference.aspose.com/slides/pt/php-java/aspose.slides/alphabilevel/) expõe um `threshold` gravável. Efeitos de cor como [Duotone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/duotone/) expõem objetos [ColorFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/colorformat/) mutáveis.

Algumas operações, incluindo [Luminance](https://reference.aspose.com/slides/pt/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/pt/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tint/), e [AlphaReplace](https://reference.aspose.com/slides/pt/php-java/aspose.slides/alphareplace/), não expõem seus escalares de criação como propriedades graváveis. Para alterar essas configurações, remova a operação e adicione uma substituição na posição requerida.

Os dados efetivos retornados por `getEffective()` são calculados e somente leitura. Eles são úteis para resolver cores dependentes de tema e ler os valores normalizados que o renderizador usa, mas não constituem outra superfície de edição. O exemplo a seguir enumera a cadeia e inspeciona valores efetivos onde a API correspondente os fornece:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Efeitos sem parâmetros, como escala de cinza, teto alfa e inverso alfa, ainda possuem um objeto de dados efetivo, porém não há configurações escalares para imprimir. Sua presença e posição na coleção são as informações importantes.

## **Remover ou Limpar Transformações de Imagem**

Use [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/removeat/) para remover uma operação pelo índice. Como os índices mudam após a remoção, procure o alvo primeiro e remova‑o depois da enumeração. Use [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagetransformoperationcollection/clear/) para remover toda a cadeia.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Remover ou limpar transformações altera apenas a formatação da imagem. Não exclui, recomprime ou altera de outra forma o recurso [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/) reutilizado.

## **Considerar Formatos de Apresentação e Destinos de Exportação**

As transformações de imagem originam‑se no DrawingML, portanto PPTX é o formato editável preferido para cadeias de efeitos. Mesmo com PPTX, nem toda operação tem portabilidade idêntica:

- Operações padrão do DrawingML, como luminância, escala de cinza, duotone, tonalidade, HSL, desfoque e operações alfa comuns, têm a maior chance de sobreviver a um ciclo de ida e volta em PPTX. Sempre reabra o arquivo gerado e inspecione a coleção quando a preservação for requisito.
- O formato binário PPT precede o modelo completo de efeitos do DrawingML. Salvar em PPT pode omitir operações não suportadas, reduzir uma cadeia a um subconjunto suportado ou aproximar a aparência. Não use PPT como formato de verificação para uma cadeia editável complexa.
- Renderizar para PNG, JPEG, TIFF, PDF, SVG, HTML ou outra saída visual aplica a cadeia suportada à aparência renderizada. Essas saídas não contêm uma `ImageTransformOperationCollection` editável; formatos raster planos resultam em pixels, e exportações de documento ou vetor armazenam sua própria representação de renderização.
- Os efeitos não tornam uma imagem vinculada autossuficiente. Renderizar uma imagem vinculada ainda depende que o recurso vinculado esteja disponível quando a apresentação for carregada.

Consumidores diferentes de apresentações podem renderizar casos limites de forma distinta, especialmente quando várias operações alfa ou de quantização de cor são combinadas. Para saída crítica, teste tanto o ciclo editável quanto o formato de exportação final com a mesma versão do Aspose.Slides usada em produção.

## **Perguntas frequentes**

**Os efeitos de transformação de imagem modificam os dados da imagem incorporada?**

Não. As operações pertencem ao `Picture` usado pelo preenchimento de imagem. Os bytes subjacentes do `PPImage` permanecem inalterados.

**Do dois quadros de imagem que reutilizam a mesma imagem compartilharão seus efeitos?**

Não. Reutilizar um `PPImage` evita dados de imagem duplicados, mas cada quadro de imagem normalmente possui um `Picture` separado e sua própria coleção de transformações de imagem.

**Os efeitos de cor, desfoque e alfa podem ser combinados?**

Sim. A coleção aceita‑os em uma única cadeia ordenada. Considere o que cada operação faz com a saída da anterior, pois operações de substituição e limiar podem descartar detalhes de cor ou alfa produzidos anteriormente.

**Por que os valores efetivos são somente leitura?**

Os dados efetivos representam valores calculados usados para renderização, incluindo cores resolvidas. Edite a operação armazenada na coleção de transformações onde existirem membros graváveis; caso contrário, remova‑a e adicione uma substituição com novos parâmetros de criação.

**Qual formato devo usar para preservar uma cadeia de transformações?**

Use PPTX e verifique o arquivo reabrindo‑o. O legado PPT não pode representar o modelo completo de efeitos do DrawingML, e os formatos de exportação renderizados preservam apenas a aparência, não as operações de transformação editáveis.