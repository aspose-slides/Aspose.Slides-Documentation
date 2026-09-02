---
title: Gerenciar Efeitos de Transformação de Imagem em Apresentações com C++
linktitle: Efeitos de Transformação de Imagem
type: docs
weight: 11
url: /pt/cpp/image-transform-effects/
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
- efeito alpha
- cadeia de efeitos
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aplicar, encadear, inspecionar, remover e verificar efeitos de transformação de imagem para quadros de imagem com Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides representa ajustes de imagem como uma coleção ordenada de operações de transformação de imagem. Para um quadro de imagem, comece com o [ISlidesPicture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidespicture/) do quadro e acesse [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidespicture/get_imagetransform/). A [IImageTransformOperationCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/) retornada permite anexar, enumerar, inspecionar, remover e limpar efeitos sem reescrever os bytes da imagem original.

Este artigo demonstra um fluxo de trabalho completo para brilho e contraste, transformações de cor, desfoque, transparência, cadeias de efeito ordenadas, valores efetivos, remoção e verificação de ida e volta em PPTX.

## **Compreender a propriedade do efeito e a reutilização de imagens**

Um recurso de imagem e a imagem que o exibe são objetos diferentes:

- [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) armazena ou referencia os dados da imagem fonte pertencentes à apresentação.
- [ISlidesPicture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidespicture/) pertence a um preenchimento de imagem e referencia um recurso de imagem enquanto armazena a coleção de transformações de imagem.
- [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) é a forma do slide que possui o preenchimento de imagem relevante, geometria, configurações de recorte e outras formatações ao nível do quadro.

Portanto, as operações de transformação de imagem não modificam os bytes em [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/). Quando o mesmo `IPPImage` é passado para [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addpictureframe/) mais de uma vez, cada novo quadro de imagem recebe seu próprio `ISlidesPicture` e sua própria coleção de transformações. Aplicar escala de cinza a um quadro não deixa os outros quadros em escala de cinza, embora todos reutilizem o mesmo recurso de imagem incorporado.

O mesmo modelo `ISlidesPicture::get_ImageTransform` também é usado por outros preenchimentos de imagem, como forma ou plano de fundo do slide. Os exemplos abaixo concentram‑se em quadros de imagem.

## **Usar intervalos de parâmetros válidos e unidades**

Os métodos demonstrados utilizam os seguintes intervalos semânticos e unidades. Mantenha os valores nesses intervalos mesmo se uma versão específica da biblioteca não rejeitar imediatamente todos os valores fora do intervalo; o formato de apresentação de destino pode normalizar, omitir ou rejeitar dados inválidos durante a gravação ou quando o PowerPoint abrir o arquivo.

| Operação | Parâmetros | Intervalo e unidade válidos |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | de `-100` a `100`, porcentagem; `0` deixa o componente inalterado. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Nenhum | Sem parâmetros numéricos. Alpha permanece inalterado. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Duas cores para pixels escuros e claros. Canais RGB e alpha em `System::Drawing::Color` usam de `0` a `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue de `0` (inclusivo) a `360` (exclusivo), em graus; amount de `-100` a `100`, porcentagem. |
| [AddHSLEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue de `0` (inclusivo) a `360` (exclusivo), em graus; saturation e luminance de `-100` a `100`, porcentagem. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | A cor de substituição usa valores de canal de `0` a `255`. Valores alpha existentes permanecem inalterados. |
| [AddBlurEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Raio não negativo medido em pontos; `grow` controla se o conteúdo desfocado pode se estender fora dos limites originais. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Porcentagem não negativa. Use `0` a `100` para escala de opacidade comum: `0` é totalmente transparente e `100` preserva o alpha existente. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | De `0` a `100`, porcentagem de opacidade. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | De `0` a `100`, porcentagem de limiar alpha. Valores abaixo dele ficam transparentes; valores iguais ou acima ficam opacos. |

Para modulação fixa de alpha, transparência e opacidade são complementares. Por exemplo, 35 % de transparência corresponde a um valor de modulação alpha de 65 %.

## **Aplicar brilho e contraste**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) retorna uma operação [IBrightnessContrast](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/ibrightnesscontrast/). Seus ajustes escalares são fornecidos quando a operação é criada. O método `IBrightnessContrast::GetEffective` devolve valores calculados somente leitura que podem ser inspeccionados ou registrados.

O exemplo a seguir aumenta o brilho em 15 % e o contraste em 20 %, então gera uma pré‑visualização sem modificar a imagem incorporada:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/brightnesscontrast/) é uma extensão de efeito de imagem do Office 2010 e é menos portátil que o efeito de luminância padrão do DrawingML. Quando brilho e contraste precisam permanecer editáveis após uma ida e volta em PPTX, use [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) e verifique o resultado após reabrir o arquivo. A seção de limitações de formato explica essa distinção com mais detalhes.

## **Aplicar transformações de cor**

Efeitos de cor podem ser aplicados de forma independente a diferentes quadros de imagem que reutilizam um recurso de imagem. O exemplo a seguir cria cinco quadros e aplica escala de cinza, duotone, tonalidade, ajuste HSL e substituição de cor.

[IDuotone](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iduotone/) contém dois parâmetros de cor editáveis independentemente: `get_Color1` mapeia pixels escuros, enquanto `get_Color2` mapeia pixels claros. Isso o torna um exemplo útil de efeito cujas configurações são mais complexas que um único valor escalar.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) substitui a cor de cada pixel por uma cor fixa, preservando o alpha. É diferente de [AddColorChangeEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), que mapeia uma cor fonte para outra e expõe os formatos de cor fonte e destino.

## **Adicionar desfoque, transparência e efeitos alpha**

[AddBlurEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) afeta todos os canais de cor, inclusive alpha. Defina `grow` como `true` quando a borda desfocada puder se estender além dos limites originais da imagem.

Para transparência uniforme, use [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Ele multiplica cada valor alpha existente, de modo que pixels parcialmente transparentes permanecem proporcionalmente diferentes. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) atribui um único valor alpha a todos os pixels. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) converte alpha em dois níveis com base em um limiar.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Outras operações alpha sem parâmetros incluem [AddAlphaCeilingEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), que torna todo alpha diferente de zero completamente opaco; [AddAlphaFloorEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), que torna todo alpha abaixo de 100 % totalmente transparente; e [AddAlphaInverseEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), que altera o alpha para `100% - alpha`.

## **Construir uma cadeia de efeitos ordenada**

Cada método `Add...Effect` anexa uma nova operação ao final da coleção. O renderizador usa a coleção como um pipeline ordenado: a saída da operação 0 torna‑se a entrada da operação 1, e assim sucessivamente. Consequentemente, as mesmas operações em ordem diferente podem produzir uma imagem diferente.

Por exemplo, escala de cinza seguida de tonalidade primeiro remove a informação cromática e depois recoloriza o resultado de luminância. Tonalidade seguida de escala de cinza remove a tonalidade novamente. Da mesma forma, substituição alpha pode sobrescrever valores alpha calculados por operações anteriores, enquanto a modulação alpha preserva suas diferenças relativas.

O exemplo a seguir cria uma cadeia de quatro operações, salva‑a como PPTX, reabre a apresentação, verifica tanto os tipos de operação quanto a ordem, e renderiza o resultado reaberto:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

A coleção não impõe uma matriz de compatibilidade que restrinja operações de cor, alpha e desfoque a cadeias separadas. Elas podem ser combinadas, mas combinações nem sempre são úteis. Uma substituição de cor fixa remove variações RGB produzidas por efeitos de cor anteriores; escala de cinza após duotone elimina as duas cores selecionadas; e operações alpha de teto, piso, substituição ou bi‑nível podem descartar detalhes alpha criados anteriormente. Construa a cadeia de acordo com a sequência de processamento de pixels desejada, em vez de tratar seus itens como bandeiras de formatação não ordenadas.

## **Inspecionar valores editáveis e efetivos**

Uma operação editável é o objeto armazenado em `ISlidesPicture::get_ImageTransform`. Dependendo do efeito, ele pode expor membros graváveis diretamente. Por exemplo, [IBlur](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iblur/) expõe `set_Radius` e `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/ialphamodulatefixed/) expõe `set_Amount`, e [IAlphaBiLevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/ialphabilevel/) expõe `set_Threshold`. Efeitos de cor como [IDuotone](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iduotone/) expõem objetos mutáveis [IColorFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icolorformat/).

Algumas interfaces de operação, incluindo [IBrightnessContrast](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/itint/), e [IAlphaReplace](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/ialphareplace/), não expõem seus escalares de criação como propriedades graváveis. Para alterar essas configurações, remova a operação e adicione uma substituição na posição necessária.

Os dados efetivos retornados por `GetEffective()` são calculados e somente leitura. Eles são úteis para resolver cores dependentes de tema e ler os valores normalizados que o renderizador usa, mas não constituem outra superfície de edição. O exemplo a seguir enumera a cadeia e inspeciona valores efetivos para várias operações comuns:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Efeitos sem parâmetros, como escala de cinza, teto alpha e inversão alpha, ainda possuem um objeto de dados efetivo, porém não há configurações escalares para imprimir. Sua presença e posição na coleção são as informações importantes.

## **Remover ou limpar transformações de imagem**

Use [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) para remover uma operação por índice. Como os índices mudam após a remoção, procure o alvo primeiro e remova‑o após a enumeração. Use `Clear()` para remover toda a cadeia.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Remover ou limpar transformações altera apenas a formatação da imagem. Não apaga, recomprime ou altera de outra forma o recurso [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) reutilizado.

## **Considerar formatos de apresentação e destinos de exportação**

As transformações de imagem originam‑se no DrawingML, portanto PPTX é o formato editável preferido para cadeias de efeito. Mesmo com PPTX, nem toda operação possui portabilidade idêntica:

- Operações padrão do DrawingML como luminância, escala de cinza, duotone, tonalidade, HSL, desfoque e operações alpha comuns têm a maior chance de sobreviver a uma ida e volta em PPTX. Sempre reabra o arquivo gerado e inspecione a coleção quando a preservação for exigida.
- [BrightnessContrast](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/brightnesscontrast/) é uma extensão do Office 2010, não a operação padrão de luminância do DrawingML. Pode ser usado para renderização em memória, mas não há garantia de que permanecerá como um [IBrightnessContrast](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/ibrightnesscontrast/) editável após salvar e reabrir o PPTX. Prefira [AddLuminanceEffect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) para ajustes persistentes de brilho e contraste.
- O formato binário PPT antecede o modelo completo de efeitos DrawingML. Salvar em PPT pode omitir operações não suportadas, reduzir a cadeia a um subconjunto compatível ou aproximar a aparência. Não use PPT como formato de verificação para uma cadeia editável complexa.
- Renderizar para PNG, JPEG, TIFF, PDF, SVG, HTML ou outra saída visual aplica a cadeia suportada à aparência renderizada. Essas saídas não contêm uma [IImageTransformOperationCollection] editável; formatos rasterizados achatam o resultado em pixels, e exportações de documento ou vetor armazenam sua própria representação de renderização.
- Efeitos não tornam uma imagem vinculada autônoma. Renderizar uma imagem vinculada ainda depende da disponibilidade do recurso vinculado quando a apresentação for carregada.

Consumidores diferentes de apresentações podem renderizar casos limites de forma distinta, especialmente quando várias operações alpha ou de quantização de cor são combinadas. Para saída crítica, teste tanto a ida e volta editável quanto o formato de exportação final com a mesma versão do Aspose.Slides usada em produção.

## **FAQ**

**Os efeitos de transformação de imagem modificam os dados da imagem incorporada?**

Não. As operações pertencem ao `ISlidesPicture` usado pelo preenchimento da imagem. Os bytes subjacentes de `IPPImage` permanecem inalterados.

**Dois quadros de imagem que reutilizam a mesma imagem compartilham seus efeitos?**

Não. Reutilizar um `IPPImage` evita dados de imagem duplicados, mas cada quadro de imagem normalmente tem um `ISlidesPicture` e uma coleção de transformações de imagem separados.

**É possível combinar efeitos de cor, desfoque e alpha?**

Sim. A coleção aceita todos em uma única cadeia ordenada. Considere o que cada operação faz à saída da anterior, pois operações de substituição e limiar podem descartar detalhes de cor ou alpha anteriores.

**Por que os valores efetivos são somente leitura?**

Os dados efetivos representam valores calculados usados para renderização, incluindo cores resolvidas. Edite a operação armazenada na coleção de transformações onde existirem membros graváveis; caso contrário, remova‑a e adicione uma substituição com novos parâmetros de criação.

**Qual formato devo usar para preservar uma cadeia de transformações?**

Use PPTX e verifique o arquivo reabrindo‑o. O legacy PPT não pode representar o modelo completo de efeitos DrawingML, e formatos de exportação renderizados preservam apenas a aparência, não as operações de transformação editáveis.