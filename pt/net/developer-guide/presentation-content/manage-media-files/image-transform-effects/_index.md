---
title: Gerenciar Efeitos de Transformação de Imagem em Apresentações com .NET
linktitle: Efeitos de Transformação de Imagem
type: docs
weight: 11
url: /pt/net/image-transform-effects/
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
- .NET
- C#
- Aspose.Slides
description: "Aplicar, encadear, inspecionar, remover e verificar efeitos de transformação de imagem para quadros de imagem com Aspose.Slides para .NET."
---
## **Visão Geral**

Aspose.Slides representa ajustes de imagem como uma coleção ordenada de operações de transformação de imagem. Para um quadro de imagem, comece com o [ISlidesPicture](https://reference.aspose.com/slides/pt/net/aspose.slides/islidespicture/) do quadro e acesse [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/pt/net/aspose.slides/islidespicture/imagetransform/). A [IImageTransformOperationCollection](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/) retornada permite acrescentar, enumerar, inspecionar, remover e limpar efeitos sem reescrever os bytes da imagem original.

Este artigo demonstra um fluxo de trabalho completo para brilho e contraste, transformações de cor, desfoque, transparência, cadeias de efeitos ordenadas, valores efetivos, remoção e verificação de ida e volta em PPTX.

## **Entendendo a Propriedade dos Efeitos e a Reutilização de Imagens**

Um recurso de imagem e a imagem que o exibe são objetos diferentes:

- [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) armazena ou referencia os dados de imagem de origem pertencentes à apresentação.
- [ISlidesPicture](https://reference.aspose.com/slides/pt/net/aspose.slides/islidespicture/) pertence a um preenchimento de imagem e refere‑se a um recurso de imagem enquanto armazena a coleção de transformações da imagem.
- [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/) é a forma do slide que possui o preenchimento de imagem relevante, a geometria, as configurações de recorte e outras formatações ao nível do quadro.

Portanto, as operações de transformação de imagem não modificam os bytes em [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/). Quando o mesmo `IPPImage` é passado para [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addpictureframe/) mais de uma vez, cada novo quadro de imagem recebe seu próprio `ISlidesPicture` e sua própria coleção de transformações. Aplicar escala de cinza a um quadro não deixa os outros quadros em escala de cinza, mesmo que todos reutilizem o mesmo recurso de imagem incorporado.

O mesmo modelo `ISlidesPicture.ImageTransform` também é usado por outros preenchimentos de imagem, como um preenchimento de forma ou de slide. Os exemplos abaixo concentram‑se em quadros de imagem.

## **Usar Intervalos e Unidades de Parâmetro Válidos**

Os métodos demonstrados utilizam os seguintes intervalos semânticos e unidades. Mantenha os valores dentro desses intervalos mesmo que uma versão específica da biblioteca não rejeite imediatamente todo valor fora do intervalo; o formato de apresentação de destino pode normalizar, omitir ou rejeitar dados inválidos ao salvar ou quando o PowerPoint abrir o arquivo.

| Operação | Parâmetros | Faixa válida e unidade |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | de `-100` a `100`, por cento; `0` deixa o componente inalterado. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Nenhum | Sem parâmetros numéricos. Alfa permanece inalterado. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Duas cores para pixels escuros e claros. Canais RGB e alfa em `System.Drawing.Color` usam valores de `0` a `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Matiz de `0` (inclusivo) a `360` (exclusivo), em graus; quantidade de `-100` a `100`, por cento. |
| [AddHSLEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Matiz de `0` (inclusivo) a `360` (exclusivo), em graus; saturação e luminância de `-100` a `100`, por cento. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | A cor de substituição usa valores de canal de `0` a `255`. Valores alfa existentes permanecem inalterados. |
| [AddBlurEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Raio não negativo medido em pontos; `grow` é um Boolean que controla se o conteúdo desfocado pode estender‑se fora dos limites originais. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Por cento não negativo. Use `0` a `100` para escala de opacidade comum: `0` é totalmente transparente e `100` preserva o alfa existente. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | De `0` a `100`, por cento de opacidade. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | De `0` a `100`, por cento de limite alfa. Valores abaixo dele tornam‑se transparentes; valores iguais ou superiores tornam‑se opacos. |

Para modulação alfa fixa, transparência e opacidade são complementares. Por exemplo, 35 % de transparência corresponde a um valor de modulação alfa de 65 %.

## **Aplicar Brilho e Contraste**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) devolve uma operação [IBrightnessContrast](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/ibrightnesscontrast/). Suas configurações escalares são fornecidas quando a operação é criada. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/brightnesscontrast/geteffective/) devolve valores calculados somente leitura que podem ser inspecionados ou registrados.

O exemplo a seguir aumenta o brilho em 15 % e o contraste em 20 %, então renderiza uma pré‑visualização sem modificar a imagem incorporada:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/brightnesscontrast/) é uma extensão de efeito de imagem do Office 2010 e é menos portátil que o efeito padrão DrawingML de luminância. Quando brilho e contraste precisam permanecer editáveis após uma ida e volta em PPTX, use [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) e verifique o resultado após reabrir o arquivo. A seção de limitações de formato explica essa distinção com mais detalhes.

## **Aplicar Transformações de Cor**

Os efeitos de cor podem ser aplicados independentemente a diferentes quadros de imagem que reutilizam um mesmo recurso de imagem. O exemplo a seguir cria cinco quadros e aplica escala de cinza, duotone, matiz, ajuste HSL e substituição de cor.

[IDuotone](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iduotone/) contém dois parâmetros de cor editáveis independentemente: `Color1` mapeia pixels escuros, enquanto `Color2` mapeia pixels claros. Isso o torna um exemplo útil de efeito cujas configurações são mais complexas que um único valor escalar.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) substitui a cor de cada pixel por uma cor fixa, preservando o alfa. É diferente de [AddColorChangeEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), que mapeia uma cor de origem para outra e expõe ambos os formatos de cor de origem e destino.

## **Adicionar Desfoque, Transparência e Efeitos Alfa**

[AddBlurEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) afeta todos os canais de cor, incluindo alfa. Defina `grow` como `true` quando a borda desfocada puder se estender além dos limites da imagem original.

Para transparência uniforme, use [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Ele multiplica cada valor alfa existente, de modo que pixels parcialmente transparentes permanecem proporcionalmente diferentes. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) atribui um único valor alfa a todos os pixels. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) converte o alfa para dois níveis com base em um limite.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Outras operações alfa sem parâmetros incluem [AddAlphaCeilingEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), que torna todo alfa não zero totalmente opaco; [AddAlphaFloorEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), que torna todo alfa abaixo de 100 % totalmente transparente; e [AddAlphaInverseEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), que altera o alfa para `100% - alpha`.

## **Construir uma Cadeia de Efeitos Ordenada**

Todo método `Add...Effect` acrescenta uma nova operação ao final da coleção. O renderizador usa a coleção como um pipeline ordenado: a saída da operação 0 torna‑se a entrada da operação 1 e assim sucessivamente. Consequentemente, as mesmas operações em ordem diferente podem produzir imagens diferentes.

Por exemplo, escala de cinza seguida de matiz primeiro remove informações cromáticas e depois recolore o resultado de luminância. Matiz seguida de escala de cinza remove a matiz novamente. Da mesma forma, a substituição alfa pode sobrescrever valores alfa calculados por operações anteriores, enquanto a modulação alfa preserva suas diferenças relativas.

O exemplo a seguir constrói uma cadeia de quatro operações, salva-a como PPTX, reabre a apresentação, verifica tanto os tipos de operação quanto sua ordem e renderiza o resultado reaberto:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

A coleção não impõe uma matriz de compatibilidade que restrinja operações de cor, alfa e desfoque a cadeias separadas. Elas podem ser combinadas, porém as combinações nem sempre são úteis. Uma substituição de cor fixa remove variações RGB produzidas por efeitos de cor anteriores; escala de cinza após duotone elimina as duas cores selecionadas; e operações alfa de teto, piso, substituição ou bi‑nível podem descartar detalhes alfa criados anteriormente. Construa a cadeia de acordo com a sequência desejada de processamento de pixels, em vez de tratar seus itens como bandeiras de formatação não ordenadas.

## **Inspecionar Valores Editáveis e Efetivos**

Uma operação editável é o objeto armazenado em `ISlidesPicture.ImageTransform`. Dependendo do efeito, ele pode expor membros graváveis diretamente. Por exemplo, [IBlur](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iblur/) expõe `Radius` e `Grow` graváveis, [IAlphaModulateFixed](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/ialphamodulatefixed/) expõe `Amount` gravável e [IAlphaBiLevel](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/ialphabilevel/) expõe `Threshold` gravável. Efeitos de cor como [IDuotone](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iduotone/) expõem objetos mutáveis [IColorFormat](https://reference.aspose.com/slides/pt/net/aspose.slides/icolorformat/).

Algumas interfaces de operação, incluindo [IBrightnessContrast](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/itint/) e [IAlphaReplace](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/ialphareplace/), não expõem seus escalares de criação como propriedades graváveis. Para alterar essas configurações, remova a operação e adicione uma substituição na posição requerida.

Os dados efetivos devolvidos por `GetEffective()` são calculados e somente leitura. Eles são úteis para resolver cores dependentes de tema e ler os valores normalizados que o renderizador usa, mas não constituem outra superfície de edição. O exemplo a seguir enumera a cadeia e inspeciona valores efetivos onde a API correspondente os fornece:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Efeitos sem parâmetros como escala de cinza, teto alfa e inversão alfa ainda possuem um objeto de dados efetivo, porém não há configurações escalares a imprimir. Sua presença e posição na coleção são as informações importantes.

## **Remover ou Limpar Transformações de Imagem**

Use [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) para remover uma operação pelo índice. Como os índices mudam após a remoção, procure o alvo primeiro e remova‑o após a enumeração. Use `Clear()` para remover toda a cadeia.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Remover ou limpar transformações altera apenas a formatação da imagem. Não exclui, recomprime ou altera de outra forma o recurso [IPPImage](https://reference.aspose.com/slides/pt/net/aspose.slides/ippimage/) reutilizado.

## **Considerar Formatos de Apresentação e Destinos de Exportação**

Transformações de imagem originam‑se em DrawingML, portanto PPTX é o formato editável preferido para cadeias de efeito. Mesmo com PPTX, nem toda operação tem portabilidade idêntica:

- Operações padrão DrawingML como luminância, escala de cinza, duotone, matiz, HSL, desfoque e operações alfa comuns têm maior chance de sobreviver a uma ida e volta em PPTX. Sempre reabra o arquivo gerado e inspecione a coleção quando a preservação for requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/brightnesscontrast/) é uma extensão do Office 2010, não a operação padrão DrawingML de luminância. Pode ser usado para renderização em memória, mas não há garantia de que permaneça como um [IBrightnessContrast](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/ibrightnesscontrast/) editável após salvar e reabrir PPTX. Prefira [AddLuminanceEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) para ajustes persistentes de brilho e contraste.
- O formato binário PPT antecede o modelo completo de efeitos DrawingML. Salvar em PPT pode omitir operações não suportadas, reduzir uma cadeia a um subconjunto suportado ou aproximar a aparência. Não use PPT como formato de verificação para uma cadeia editável complexa.
- Renderizar para PNG, JPEG, TIFF, PDF, SVG, HTML ou outro output visual aplica a cadeia suportada à aparência renderizada. Essas saídas não contêm uma `IImageTransformOperationCollection` editável; formatos raster achatam o resultado em pixels, e exportações de documento/vetor armazenam sua própria representação de renderização.
- Os efeitos não tornam uma imagem vinculada autônoma. Renderizar uma imagem vinculada ainda depende de o recurso vinculado estar disponível quando a apresentação for carregada.

Consumidores diferentes de apresentações podem renderizar casos‑limite de forma distinta, especialmente quando várias operações alfa ou de quantização de cor são combinadas. Para saída crítica, teste tanto a ida e volta editável quanto o formato de exportação final com a mesma versão do Aspose.Slides usada em produção.

## **FAQ**

**Os efeitos de transformação de imagem modificam os dados da imagem incorporada?**

Não. As operações pertencem ao `ISlidesPicture` usado pelo preenchimento de imagem. Os bytes subjacentes de `IPPImage` permanecem inalterados.

**Dois quadros de imagem que reutilizam a mesma imagem compartilham seus efeitos?**

Não. Reutilizar um `IPPImage` evita dados de imagem duplicados, mas cada quadro de imagem normalmente tem seu próprio `ISlidesPicture` e sua própria coleção de transformações de imagem.

**É possível combinar efeitos de cor, desfoque e alfa?**

Sim. A coleção aceita todos em uma única cadeia ordenada. Considere o que cada operação faz à saída da anterior, pois operações de substituição e limiar podem descartar detalhes de cor ou alfa anteriores.

**Por que os valores efetivos são somente leitura?**

Os dados efetivos representam valores calculados usados para renderização, incluindo cores resolvidas. Edite a operação armazenada na coleção de transformações onde existam membros graváveis; caso contrário, remova‑a e adicione uma substituição com novos parâmetros de criação.

**Qual formato devo usar para preservar uma cadeia de transformações?**

Use PPTX e verifique o arquivo reabrindo‑o. O legado PPT não pode representar todo o modelo de efeitos DrawingML, e formatos de exportação renderizados preservam apenas a aparência, não as operações de transformação editáveis.