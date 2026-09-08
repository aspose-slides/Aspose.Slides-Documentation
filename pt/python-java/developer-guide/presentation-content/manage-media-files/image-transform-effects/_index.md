---
title: Gerenciar efeitos de transformação de imagem em apresentações com Python
linktitle: Efeitos de Transformação de Imagem
type: docs
weight: 11
url: /pt/python-java/image-transform-effects/
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
- Python
- Java
- Aspose.Slides
description: "Aplicar, encadear, inspecionar, remover e verificar efeitos de transformação de imagem para molduras de imagem com Aspose.Slides para Python via Java."
---
## **Visão geral**

Aspose.Slides representa ajustes de imagem como uma coleção ordenada de operações de transformação de imagem. Para uma moldura de imagem, comece com o [Picture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/) da moldura e acesse [Picture.getImageTransform](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/#getImageTransform). A [ImageTransformOperationCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/) retornada permite anexar, enumerar, inspecionar, remover e limpar efeitos sem reescrever os bytes da imagem original.

Este artigo demonstra um fluxo de trabalho completo para brilho e contraste, transformações de cor, desfoque, transparência, cadeias de efeitos ordenadas, valores efetivos, remoção e verificação de ida e volta em PPTX.

## **Entender a Propriedade do Efeito e a Reutilização de Imagens**

Um recurso de imagem e a imagem que o exibe são objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) armazena ou referencia os dados da imagem fonte pertencentes à apresentação.
- [Picture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/) pertence a um preenchimento de imagem e refere‑se a um recurso de imagem enquanto armazena a coleção de transformações de imagem.
- [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) é a forma do slide que possui o preenchimento de imagem relevante, geometria, configurações de recorte e outras formatações ao nível da moldura.

Portanto, as operações de transformação de imagem não modificam os bytes em [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/). Quando o mesmo `PPImage` é passado para [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addPictureFrame) mais de uma vez, cada nova moldura de imagem recebe seu próprio `Picture` e sua própria coleção de transformações. Aplicar escala de cinza a uma moldura não torna as outras molduras em escala de cinza, embora todas reutilizem o mesmo recurso de imagem incorporado.

O mesmo modelo `Picture.getImageTransform` também é usado por outros preenchimentos de imagem, como uma forma ou fundo de slide. Os exemplos abaixo focam em molduras de imagem.

## **Usar Intervalos e Unidades de Parâmetro Válidos**

Os métodos demonstrados usam os seguintes intervalos semânticos e unidades. Mantenha os valores dentro desses intervalos mesmo que uma versão específica da biblioteca não rejeite imediatamente cada valor fora do intervalo; o formato de apresentação alvo pode normalizar, omitir ou rejeitar dados inválidos durante a gravação ou quando o PowerPoint abrir o arquivo.

| Operação | Parâmetros | Intervalo válido e unidade |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` a `100`, porcento; `0` deixa o componente inalterado. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Nenhum | Sem parâmetros numéricos. Alfa permanece inalterado. |
| [addDuotoneEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Duas cores para pixels escuros e claros. Canais RGB e alfa em `java.awt.Color` usam de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Matiz de `0` (inclusivo) a `360` (exclusivo), em graus; quantidade de `-100` a `100`, porcento. |
| [addHSLEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Matiz de `0` (inclusivo) a `360` (exclusivo), em graus; saturação e luminância de `-100` a `100`, porcento. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | A cor de substituição usa valores de canal de `0` a `255`. Valores alfa existentes permanecem inalterados. |
| [addBlurEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Raio não negativo medido em pontos; `grow` é um Boolean que controla se o conteúdo desfocado pode se estender fora dos limites originais. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Porcento não negativo. Use de `0` a `100` para escala de opacidade comum: `0` é totalmente transparente e `100` preserva o alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` a `100`, porcento de opacidade. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` a `100`, porcento de limiar alfa. Valores abaixo dele tornam‑se transparentes; valores iguais ou acima tornam‑se opacos. |

Para modulação alfa fixa, transparência e opacidade são complementares. Por exemplo, 35% de transparência corresponde a um valor de modulação alfa de 65%.

## **Aplicar Brilho e Contraste**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) retorna uma operação [BrightnessContrast](https://reference.aspose.com/slides/pt/python-java/aspose.slides/brightnesscontrast/). Suas configurações escalares são fornecidas quando a operação é criada. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/pt/python-java/aspose.slides/brightnesscontrast/#getEffective) retorna valores calculados somente leitura que podem ser inspecionados ou registrados.

O exemplo a seguir aumenta o brilho em 15% e o contraste em 20%, depois gera uma visualização sem modificar a imagem incorporada:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/pt/python-java/aspose.slides/brightnesscontrast/) é uma extensão de efeito de imagem do Office 2010 e é menos portável que o efeito de luminância padrão do DrawingML. Quando brilho e contraste precisam permanecer editáveis após uma ida e volta em PPTX, use [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) e verifique o resultado depois de reabrir o arquivo. A seção de limitações de formato explica essa distinção com mais detalhes.

## **Aplicar Transformações de Cor**

Efeitos de cor podem ser aplicados independentemente a diferentes molduras de imagem que reutilizam um recurso de imagem. O exemplo a seguir cria cinco molduras e aplica escala de cinza, duotone, tonalidade, ajuste HSL e substituição de cor.

[Duotone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/duotone/) contém dois parâmetros de cor editáveis independentemente: `color1` mapeia pixels escuros, enquanto `color2` mapeia pixels claros. Isso o torna um exemplo útil de efeito cujas configurações são mais complexas que um único valor escalar.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) substitui a cor de cada pixel por uma cor fixa, preservando o alfa. É diferente de [addColorChangeEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), que mapeia uma cor fonte para outra e expõe os formatos de cor origem e destino.

## **Adicionar Desfoque, Transparência e Efeitos Alfa**

[addBlurEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) afeta todos os canais de cor, incluindo alfa. Defina `grow` como `True` quando a borda desfocada puder se estender além dos limites originais da imagem.

Para transparência uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Ele multiplica cada valor alfa existente, de modo que pixels parcialmente transparentes permanecem proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) atribui um único valor alfa a todos os pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) converte o alfa em dois níveis baseados em um limiar.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Outras operações alfa sem parâmetros incluem [addAlphaCeilingEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), que torna todo alfa diferente de zero totalmente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), que torna todo alfa abaixo de 100% totalmente transparente; e [addAlphaInverseEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), que altera o alfa para `100% - alfa`.

## **Construir uma Cadeia de Efeitos Ordenada**

Cada método `add...Effect` anexa uma nova operação ao final da coleção. O renderizador usa a coleção como um pipeline ordenado: a saída da operação 0 torna‑se a entrada da operação 1 e assim por diante. Consequentemente, as mesmas operações em ordem diferente podem produzir uma imagem distinta.

Por exemplo, escala de cinza seguida de tonalidade primeiro remove informações cromáticas e depois recoloriza o resultado de luminância. Tonalidade seguida de escala de cinza remove a tonalidade novamente. De forma similar, substituição alfa pode sobrescrever valores alfa calculados por operações anteriores, enquanto a modulação alfa preserva suas diferenças relativas.

O exemplo a seguir cria uma cadeia de quatro operações, salva como PPTX, reabre a apresentação, verifica os tipos de operação e sua ordem, e renderiza o resultado reaberto:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

A coleção não impõe uma matriz de compatibilidade que restrinja operações de cor, alfa e desfoque a cadeias separadas. Elas podem ser combinadas, mas combinações nem sempre são úteis. Uma substituição de cor fixa elimina variações RGB produzidas por efeitos de cor anteriores; escala de cinza após duotone elimina as duas cores selecionadas; e operações alfa de teto, piso, substituição ou nível bi‑nível podem descartar detalhes alfa criados antes. Construa a cadeia de acordo com a sequência desejada de processamento de pixels ao invés de tratar seus itens como sinalizadores de formatação desordenados.

## **Inspecionar Valores Editáveis e Efetivos**

Uma operação editável é o objeto armazenado em `Picture.getImageTransform`. Dependendo do efeito, ele pode expor membros graváveis diretamente. Por exemplo, [Blur](https://reference.aspose.com/slides/pt/python-java/aspose.slides/blur/) expõe valores graváveis `radius` e `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/alphamodulatefixed/) expõe um gravável `amount`, e [AlphaBiLevel](https://reference.aspose.com/slides/pt/python-java/aspose.slides/alphabilevel/) expõe um gravável `threshold`. Efeitos de cor como [Duotone](https://reference.aspose.com/slides/pt/python-java/aspose.slides/duotone/) expõem objetos mutáveis [ColorFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/colorformat/).

Algumas classes de operação, incluindo [BrightnessContrast](https://reference.aspose.com/slides/pt/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/pt/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tint/), e [AlphaReplace](https://reference.aspose.com/slides/pt/python-java/aspose.slides/alphareplace/), não expõem seus escalares de criação como propriedades graváveis. Para alterar essas configurações, remova a operação e adicione uma substituta na posição necessária.

Os dados efetivos retornados por `getEffective` são calculados e somente leitura. Eles são úteis para resolver cores dependentes de tema e ler os valores normalizados que o renderizador usa, mas não constituem outra superfície de edição. O exemplo a seguir enumera a cadeia e inspeciona valores efetivos onde a API correspondente os fornece:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Efeitos sem parâmetros como escala de cinza, teto alfa e inverso alfa ainda possuem um objeto de dados efetivo, porém não há configurações escalares para imprimir. Sua presença e posição na coleção são as informações importantes.

## **Remover ou Limpar Transformações de Imagem**

Use [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) para remover uma operação por índice. Como os índices mudam após a remoção, procure o alvo primeiro e remova‑o depois da enumeração. Use [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#clear) para remover toda a cadeia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Remover ou limpar transformações altera apenas a formatação da imagem. Não exclui, recomprime ou altera de outra forma o recurso [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) reutilizado.

## **Considerar Formatos de Apresentação e Destinos de Exportação**

Transformações de imagem originam‑se no DrawingML, por isso PPTX é o formato editável preferido para cadeias de efeito. Mesmo com PPTX, nem toda operação tem portabilidade idêntica:

- Operações padrão do DrawingML como luminância, escala de cinza, duotone, tonalidade, HSL, desfoque e operações alfa comuns têm a maior chance de sobreviver a uma ida e volta em PPTX. Sempre reabra o arquivo gerado e inspecione a coleção quando a preservação for um requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/pt/python-java/aspose.slides/brightnesscontrast/) é uma extensão do Office 2010, não a operação padrão de luminância do DrawingML. Pode ser usado para renderização em memória, mas não há garantia de que permanecerá como um [BrightnessContrast](https://reference.aspose.com/slides/pt/python-java/aspose.slides/brightnesscontrast/) editável após salvar e reabrir PPTX. Prefira [addLuminanceEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) para ajustes persistentes de brilho e contraste.
- O formato binário PPT precede o modelo completo de efeitos DrawingML. Salvar em PPT pode omitir operações não suportadas, reduzir uma cadeia a um subconjunto suportado ou aproximar a aparência. Não use PPT como formato de verificação para uma cadeia editável complexa.
- Renderizar para PNG, JPEG, TIFF, PDF, SVG, HTML ou outro saída visual aplica a cadeia suportada à aparência renderizada. Essas saídas não contêm uma `ImageTransformOperationCollection` editável; formatos raster planificam o resultado em pixels, e exportações de documento/vetor armazenam sua própria representação de renderização.
- Efeitos não tornam uma imagem vinculada autônoma. Renderizar uma imagem vinculada ainda depende de o recurso vinculado estar disponível quando a apresentação for carregada.

Consumidores diferentes de apresentações podem renderizar casos limites de forma diversa, especialmente quando várias operações alfa ou de quantização de cor são combinadas. Para saída crítica, teste tanto a ida e volta editável quanto o formato de exportação final com a mesma versão do Aspose.Slides usada em produção.

## **FAQ**

**Os efeitos de transformação de imagem modificam os dados da imagem incorporada?**

Não. As operações pertencem ao `Picture` usado pelo preenchimento de imagem. Os bytes subjacentes do `PPImage` permanecem inalterados.

**Dois quadros de imagem que reutilizam a mesma imagem compartilham seus efeitos?**

Não. Reutilizar um `PPImage` evita dados de imagem duplicados, mas cada quadro de imagem normalmente tem um `Picture` separado e uma coleção de transformações de imagem distinta.

**É possível combinar efeitos de cor, desfoque e alfa?**

Sim. A coleção aceita-os em uma única cadeia ordenada. Considere o que cada operação faz ao resultado da anterior, pois operações de substituição e limiar podem descartar detalhes de cor ou alfa anteriores.

**Por que os valores efetivos são somente leitura?**

Os dados efetivos representam valores calculados usados para renderização, incluindo cores resolvidas. Edite a operação armazenada na coleção de transformações onde os membros graváveis existirem; caso contrário, remova‑a e adicione uma substituta com novos parâmetros de criação.

**Qual formato devo usar para preservar uma cadeia de transformações?**

Use PPTX e verifique o arquivo reabrindo‑o. O PPT legado não pode representar o modelo completo de efeitos DrawingML, e formatos de exportação renderizados preservam apenas a aparência, não as operações de transformação editáveis.