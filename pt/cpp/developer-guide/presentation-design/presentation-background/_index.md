---
title: Gerenciar Fundos de Apresentação em C++
linktitle: Fundo do Slide
type: docs
weight: 20
url: /pt/cpp/presentation-background/
keywords:
- fundo de apresentação
- fundo de slide
- cor sólida
- cor em gradiente
- fundo de imagem
- transparência de fundo
- propriedades de fundo
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a definir fundos dinâmicos em arquivos PowerPoint e OpenDocument usando Aspose.Slides para C++, com dicas de código para melhorar suas apresentações."
---
## **Introdução**

Cores sólidas, gradientes e imagens são comumente usadas como fundos de slides. Você pode definir o fundo para um **slide normal** (um único slide) ou um **slide mestre** (aplica‑se a vários slides de uma vez).

![PowerPoint background](powerpoint-background.png)

## **Definir um Fundo de Cor Sólida para um Slide Normal**

Aspose.Slides permite definir uma cor sólida como fundo para um slide específico em uma apresentação — mesmo que a apresentação use um slide mestre. A alteração aplica‑se apenas ao slide selecionado.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) do fundo do slide como `Solid`.
4. Use o método [get_SolidFillColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/get_solidfillcolor/) em [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/) para especificar a cor sólida de fundo.
5. Salve a apresentação modificada.

O exemplo C++ a seguir demonstra como definir uma cor azul sólida como fundo para um slide normal:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Crie uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Defina a cor de fundo do slide para azul.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Salve a apresentação no disco.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir um Fundo de Cor Sólida para um Slide Mestre**

Aspose.Slides permite definir uma cor sólida como fundo para o slide mestre em uma apresentação. O slide mestre atua como um modelo que controla a formatação de todos os slides, portanto, ao escolher uma cor sólida para o fundo do slide mestre, ela será aplicada a todos os slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/backgroundtype/) do slide mestre (via `get_Masters`) como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) do fundo do slide mestre como `Solid`.
4. Use o método [get_SolidFillColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/get_solidfillcolor/) para especificar a cor sólida de fundo.
5. Salve a apresentação modificada.

O exemplo C++ a seguir demonstra como definir uma cor sólida (verde floresta) como fundo para um slide mestre:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Crie uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Defina a cor de fundo do slide mestre para Verde Floresta.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Salve a apresentação no disco.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir um Fundo em Gradiente para um Slide**

Um gradiente é um efeito gráfico criado por uma mudança gradual de cor. Quando usado como fundo de slide, gradientes podem tornar as apresentações mais artísticas e profissionais. Aspose.Slides permite definir uma cor em gradiente como fundo para slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) do fundo do slide como `Gradient`.
4. Use o método [get_GradientFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/get_gradientformat/) em [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/) para configurar as configurações de gradiente desejadas.
5. Salve a apresentação modificada.

O exemplo C++ a seguir demonstra como definir uma cor em gradiente como fundo para um slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Crie uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Aplique um efeito de gradiente ao fundo.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Salve a apresentação no disco.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir uma Imagem como Fundo de Slide**

Além de preenchimentos sólidos e em gradiente, Aspose.Slides permite usar imagens como fundos de slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) do fundo do slide como `Picture`.
4. Carregue a imagem que você deseja usar como fundo do slide.
5. Adicione a imagem à coleção de imagens da apresentação.
6. Use o método [get_PictureFillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/get_picturefillformat/) em [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/) para atribuir a imagem como fundo.
7. Salve a apresentação modificada.

O exemplo C++ a seguir demonstra como definir uma imagem como fundo para um slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Crie uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Defina as propriedades da imagem de fundo.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Carregue a imagem.
auto image = Images::FromFile(u"Tulips.jpg");
// Adicione a imagem à coleção de imagens da apresentação.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Salve a apresentação no disco.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O exemplo de código a seguir demonstra como definir o tipo de preenchimento de fundo como uma imagem em padrão ladrilho e modificar as propriedades de ladrilhamento:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Defina a imagem usada para o preenchimento de fundo.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Defina o modo de preenchimento da imagem como Tile e ajuste as propriedades do ladrilho.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}
Saiba mais: [**Ladrilhar Imagem como Textura**](/slides/pt/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Alterar a Transparência da Imagem de Fundo**

Você pode querer ajustar a transparência da imagem de fundo de um slide para fazer o conteúdo do slide sobressair. O código C++ a seguir mostra como alterar a transparência de uma imagem de fundo de slide:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Por exemplo.

// Crie uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Save the presentation to disk.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obter o Valor de Fundo do Slide**

Aspose.Slides fornece a interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibackgroundeffectivedata/) para recuperar os valores efetivos de fundo de um slide. Essa interface expõe o [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) e o [EffectFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) efetivos.

Usando o método `get_Background` da classe [BaseSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseslide/), você pode obter o fundo efetivo de um slide.

O exemplo C++ a seguir demonstra como obter o valor de fundo efetivo de um slide:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Crie uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Recupere o fundo efetivo, levando em conta mestre, layout e tema.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **Perguntas Frequentes**

### Posso redefinir um fundo personalizado e restaurar o fundo do tema/layout?

Sim. Remova o preenchimento personalizado do slide, e o fundo será herdado novamente do slide de [layout](/slides/pt/cpp/slide-layout/)/[master](/slides/pt/cpp/slide-master/) correspondente (ou seja, o [fundo do tema](/slides/pt/cpp/presentation-theme/)).

### O que acontece com o fundo se eu mudar o tema da apresentação mais tarde?

Se um slide tem seu próprio preenchimento, ele permanecerá inalterado. Se o fundo for herdado do [layout](/slides/pt/cpp/slide-layout/)/[master](/slides/pt/cpp/slide-master/), ele será atualizado para combinar com o [novo tema](/slides/pt/cpp/presentation-theme/).