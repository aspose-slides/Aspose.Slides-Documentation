---
title: Gerenciar Fundos de Apresentação em C++
linktitle: Fundo de Slide
type: docs
weight: 20
url: /pt/cpp/presentation-background/
keywords:
- fundo de apresentação
- fundo de slide
- cor sólida
- cor gradiente
- fundo de imagem
- transparência do fundo
- propriedades do fundo
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a definir fundos dinâmicos em arquivos PowerPoint e OpenDocument usando Aspose.Slides para C++, com dicas de código para melhorar suas apresentações."
---
## **Introdução**

Cores sólidas, gradientes e imagens são comumente usadas como fundos de slide. Você pode definir o fundo para um **slide normal** (um único slide) ou um **slide mestre** (aplicado a vários slides ao mesmo tempo).

![Fundo do PowerPoint](powerpoint-background.png)

## **Definir um fundo de cor sólida para um slide normal**

Aspose.Slides permite definir uma cor sólida como fundo de um slide específico em uma apresentação — mesmo que a apresentação use um slide mestre. A alteração se aplica apenas ao slide selecionado.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) do fundo do slide como `Solid`.
4. Use o método [get_SolidFillColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/get_solidfillcolor/) em [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo C++ a seguir mostra como definir uma cor sólida azul como fundo de um slide normal:

```cpp
// Crie uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Defina a cor de fundo do slide como azul.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Salve a apresentação no disco.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir um fundo de cor sólida para um slide mestre**

Aspose.Slides permite definir uma cor sólida como fundo do slide mestre em uma apresentação. O slide mestre atua como um modelo que controla a formatação de todos os slides, portanto, ao escolher uma cor sólida para o fundo do slide mestre, ela será aplicada a cada slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/backgroundtype/) do slide mestre (via `get_Masters`) como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) do fundo do slide mestre como `Solid`.
4. Use o método [get_SolidFillColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/get_solidfillcolor/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo C++ a seguir mostra como definir uma cor sólida (verde floresta) como fundo de um slide mestre:

```cpp
// Crie uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Defina a cor de fundo do slide Mestre como Verde Floresta.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Salve a apresentação no disco.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir um fundo gradiente para um slide**

Um gradiente é um efeito gráfico criado por uma mudança gradual de cor. Quando usado como fundo de slide, gradientes podem tornar as apresentações mais artísticas e profissionais. Aspose.Slides permite definir uma cor gradiente como fundo dos slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) do fundo do slide como `Gradient`.
4. Use o método [get_GradientFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/get_gradientformat/) em [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/) para configurar as opções de gradiente desejadas.
5. Salve a apresentação modificada.

O exemplo C++ a seguir mostra como definir uma cor gradiente como fundo de um slide:

```cpp
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

## **Definir uma imagem como fundo de slide**

Além de preenchimentos sólidos e gradientes, Aspose.Slides permite usar imagens como fundos de slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) do fundo do slide como `Picture`.
4. Carregue a imagem que você deseja usar como fundo do slide.
5. Adicione a imagem à coleção de imagens da apresentação.
6. Use o método [get_PictureFillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/get_picturefillformat/) em [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/) para atribuir a imagem como fundo.
7. Salve a apresentação modificada.

O exemplo C++ a seguir mostra como definir uma imagem como fundo de um slide:

```cpp
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

O exemplo de código a seguir mostra como definir o tipo de preenchimento de fundo como uma imagem em ladrilhos e modificar as propriedades de ladrilhamento:

```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
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

{{% alert color="primary" %}}
Leia mais: [**Imagem em Ladrilhos Como Textura**](/slides/pt/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Alterar a transparência da imagem de fundo**

Você pode querer ajustar a transparência da imagem de fundo de um slide para que o conteúdo do slide se destaque. O código C++ a seguir mostra como alterar a transparência da imagem de fundo de um slide:

```cpp
auto transparencyValue = 30; // Por exemplo.

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
```

## **Obter o valor de fundo do slide**

Aspose.Slides fornece a interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibackgroundeffectivedata/) para recuperar os valores efetivos do fundo de um slide. Essa interface expõe o [FillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) e o [EffectFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) efetivos.

Usando o método `get_Background` da classe [BaseSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseslide/), você pode obter o fundo efetivo de um slide.

O exemplo C++ a seguir mostra como obter o valor efetivo do fundo de um slide:

```cpp
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

## **FAQ**

**Posso redefinir um fundo personalizado e restaurar o fundo do tema/layout?**

Sim. Remova o preenchimento personalizado do slide e o fundo será novamente herdado do slide de [layout](/slides/pt/cpp/slide-layout/)/[master](/slides/pt/cpp/slide-master/) correspondente (ou seja, o [fundo do tema](/slides/pt/cpp/presentation-theme/)).

**O que acontece com o fundo se eu mudar o tema da apresentação mais tarde?**

Se um slide tem seu próprio preenchimento, ele permanecerá inalterado. Se o fundo for herdado do [layout](/slides/pt/cpp/slide-layout/)/[master](/slides/pt/cpp/slide-master/), ele será atualizado para corresponder ao [novo tema](/slides/pt/cpp/presentation-theme/).