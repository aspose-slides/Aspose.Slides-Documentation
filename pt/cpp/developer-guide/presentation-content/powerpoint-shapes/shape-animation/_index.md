---
title: Aplicar animações de formas em apresentações usando C++
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/cpp/shape-animation/
keywords:
- forma
- animação
- efeito
- forma animada
- texto animado
- adicionar animação
- obter animação
- extrair animação
- adicionar efeito
- obter efeito
- extrair efeito
- som do efeito
- aplicar animação
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Descubra como criar e personalizar animações de formas em apresentações do PowerPoint com Aspose.Slides para C++. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [gráficos](/slides/pt/cpp/animated-charts/). Elas dão vida às apresentações ou aos seus componentes. 

## **Por que usar animações em apresentações?**

Usando animações, você pode  

* controlar o fluxo de informação  
* enfatizar pontos importantes  
* aumentar o interesse ou a participação do seu público  
* tornar o conteúdo mais fácil de ler, assimilar ou processar  
* chamar a atenção de seus leitores ou espectadores para partes importantes em uma apresentação  

O PowerPoint oferece muitas opções e ferramentas para animações e efeitos de animação nas categorias de **entrada**, **saída**, **ênfase** e **caminhos de movimento**. 

## **Animações no Aspose.Slides**

* Aspose.Slides fornece as classes e tipos necessários para trabalhar com animações no namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation),  
* Aspose.Slides fornece mais de **150 efeitos de animação** na enumeração [EffectType](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.  

## **Aplicar animação a um TextBox**

Aspose.Slides para C++ permite aplicar animação ao texto em uma forma. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).  
2. Obtenha a referência de um slide pelo seu índice.  
3. Adicione uma `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape).  
4. Adicione texto ao [IAutoShape.TextFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).  
5. Obtenha a sequência principal de efeitos.  
6. Adicione um efeito de animação ao [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape).  
7. Defina a propriedade [TextAnimation.BuildType](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) para o valor da [BuildType Enumeration](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).  
8. Grave a apresentação no disco como um arquivo PPTX.  

Este código C++ mostra como aplicar o efeito `Fade` ao AutoShape e definir a animação de texto para o valor *By 1st Level Paragraphs*:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adds new AutoShape with text
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adds Fade animation effect to shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animates shape text by 1st level paragraphs
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Save the PPTX file to disk
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Paragraph](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_paragraph). Veja [**Texto animado**](/slides/pt/cpp/animated-text/).

{{% /alert %}} 

## **Aplicar animação a um PictureFrame**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).  
2. Obtenha a referência de um slide pelo seu índice.  
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_picture_frame) no slide.  
4. Obtenha a sequência principal de efeitos.  
5. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_picture_frame).  
6. Grave a apresentação no disco como um arquivo PPTX.  

Este código C++ mostra como aplicar o efeito `Fly` a um picture frame:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Carrega a imagem a ser adicionada na coleção de imagens da apresentação
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Adiciona um quadro de imagem ao slide
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Obtém a sequência principal do slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Adiciona o efeito de animação Fly da esquerda ao quadro de imagem
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Salva o arquivo PPTX no disco
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Aplicar animação a uma Shape**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).  
2. Obtenha a referência de um slide pelo seu índice.  
3. Adicione uma `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape).  
4. Adicione um `Bevel` [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape) (quando este objeto for clicado, a animação será reproduzida).  
5. Crie uma sequência de efeitos na forma bevel.  
6. Crie um `UserPath` personalizado.  
7. Adicione comandos para mover para o `UserPath`.  
8. Grave a apresentação no disco como um arquivo PPTX.  

Este código C++ mostra como aplicar o efeito `PathFootball` (caminho football) a uma forma:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// O caminho para o diretório do documento.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carrega a apresentação
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Acessa o primeiro slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Acessa a coleção de formas do slide selecionado
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Cria o efeito PathFootball para a forma existente a partir do zero.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Adiciona o efeito de animação PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Cria algum tipo de "botão".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Cria uma sequência de efeitos para este botão.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Cria um caminho de usuário personalizado. Nosso objeto será movido somente depois que o botão for clicado.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Adiciona comandos para mover, já que o caminho criado está vazio.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // Grava o arquivo PPTX no disco
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Obter os efeitos de animação aplicados a uma Shape**

Os exemplos a seguir mostram como usar o método `GetEffectsByShape` da interface [ISequence](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/isequence/) para obter todos os efeitos de animação aplicados a uma forma.

**Exemplo 1: Obter efeitos de animação aplicados a uma forma em um slide normal**

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma no primeiro slide normal da apresentação `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Exemplo 2: Obter todos os efeitos de animação, incluindo os herdados de marcadores de posição**

Se uma forma em um slide normal possui marcadores de posição que estão no slide de layout e/ou slide mestre, e efeitos de animação foram adicionados a esses marcadores de posição, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos marcadores de posição.

Suponha que temos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** aplicado à forma.

![Efeito de animação de forma de slide](slide-shape-animation.png)

Vamos também supor que o efeito **Split** seja aplicado ao marcador de posição de rodapé no slide de **layout**.

![Efeito de animação de forma de layout](layout-shape-animation.png)

E, finalmente, o efeito **Fly In** é aplicado ao marcador de posição de rodapé no slide de **master**.

![Efeito de animação de forma mestre](master-shape-animation.png)

O código de exemplo a seguir mostra como usar o método `GetBasePlaceholder` da interface [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) para acessar os marcadores de posição da forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo os herdados de marcadores de posição localizados nos slides de layout e mestre.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Get animation effects of the shape on the normal slide.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

```text
Sequência principal de efeitos da forma:
Type: 47, subtype: 2              // Fly, Inferior
Type: 134, subtype: 45            // Split, EntradaVertical
Type: 126, subtype: 22            // RandomBars, Horizontal
```

## **Alterar propriedades de temporização do efeito de animação**

Aspose.Slides para C++ permite alterar as propriedades de temporização de um efeito de animação.

Este é o painel de temporização de animação no Microsoft PowerPoint:

![Painel de temporização de animação no Microsoft PowerPoint](shape-animation.png)

Estas são as correspondências entre a temporização do PowerPoint e as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- A lista suspensa **Start** da temporização do PowerPoint corresponde à propriedade [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).  
- O **Duration** da temporização do PowerPoint corresponde à propriedade [Effect.Timing.Duration](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). A duração de uma animação (em segundos) é o tempo total que ela leva para concluir um ciclo.  
- O **Delay** da temporização do PowerPoint corresponde à propriedade [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).  

Esta é a forma de alterar as propriedades de temporização do efeito:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.  
2. Defina novos valores para as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) necessárias.  
3. Salve o arquivo PPTX modificado.  

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Obtém a sequência principal do slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Obtém o primeiro efeito da sequência principal.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Altera o TriggerType do efeito para iniciar ao clicar
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Altera a Duração do efeito
effect->get_Timing()->set_Duration(3.f);

// Altera o TriggerDelayTime do efeito
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Salva o arquivo PPTX no disco
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Som do efeito de animação**

Aspose.Slides fornece estas propriedades para permitir trabalhar com sons em efeitos de animação: 

- [set_Sound()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Adicionar um som ao efeito de animação**

Este código C++ mostra como adicionar um som ao efeito de animação e pará-lo quando o próximo efeito iniciar:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Adiciona áudio à coleção de áudios da apresentação
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtém a sequência principal do slide.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtém o primeiro efeito da sequência principal
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Verifica o efeito para "No Sound"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Adiciona som ao primeiro efeito
    firstEffect->set_Sound(effectSound);
}

// Obtém a primeira sequência interativa do slide.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Define a bandeira "Stop previous sound" do efeito
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Grava o arquivo PPTX no disco
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Extrair o som de um efeito de animação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).  
2. Obtenha a referência de um slide pelo seu índice.  
3. Obtenha a sequência principal de efeitos.  
4. Extraia o [set_Sound()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effect/set_sound/) incorporado a cada efeito de animação.  

Este código C++ mostra como extrair o som incorporado em um efeito de animação:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Após a animação**

Aspose.Slides para C++ permite alterar a propriedade After animation de um efeito de animação.

Este é o painel de efeito de animação e menu expandido no Microsoft PowerPoint:

![Painel de efeito de animação e menu expandido no Microsoft PowerPoint](shape-after-animation.png)

A lista suspensa **After animation** do efeito PowerPoint corresponde a estas propriedades:

- A propriedade [set_AfterAnimationType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) que descreve o tipo After animation :
  * PowerPoint **More Colors** corresponde ao tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** corresponde ao tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/) (tipo padrão de after animation);
  * PowerPoint **Hide After Animation** corresponde ao tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** corresponde ao tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/);
- A propriedade [set_AfterAnimationColor()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) que define um formato de cor de after animation. Esta propriedade funciona em conjunto com o tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/). Se você mudar o tipo para outro, a cor after animation será limpa.

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Instancia uma classe de apresentação que representa um arquivo de apresentação
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtém o primeiro efeito da sequência principal
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Altera o tipo de after animation para Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Define a cor de escurecimento after animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Grava o arquivo PPTX no disco
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animar texto**

Aspose.Slides fornece estas propriedades para permitir trabalhar com o bloco *Animate text* de um efeito de animação:

- [set_AnimateTextType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) que descreve um tipo de animação de texto do efeito. O texto da forma pode ser animado:
  - Tudo de uma vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/animatetexttype/) tipo)
  - Por palavra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/animatetexttype/) tipo)
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/animatetexttype/) tipo)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) define um atraso entre as partes do texto animado (palavras ou letras). Um valor positivo especifica a porcentagem da duração do efeito. Um valor negativo especifica o atraso em segundos.

Esta é a forma de mudar as propriedades de animação de texto do efeito:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.  
2. Defina a propriedade [set_BuildType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/itextanimation/set_buildtype/) para o valor [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/buildtype/) para desativar o modo de animação *By Paragraphs*.  
3. Defina novos valores para as propriedades [set_AnimateTextType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) e [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).  
4. Salve o arquivo PPTX modificado.  

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtém o primeiro efeito da sequência principal
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Altera o tipo de animação de texto do efeito para "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Altera o tipo de animação de texto do efeito para "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Define o atraso entre palavras para 20% da duração do efeito
firstEffect->set_DelayBetweenTextParts(20.0f);

// Grava o arquivo PPTX no disco
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **Perguntas frequentes**

### Como posso garantir que as animações sejam preservadas ao publicar a apresentação na web?

[Exportar para HTML5](/slides/pt/cpp/export-to-html5/) e habilite as [opções](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/) responsáveis por animações de [shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/set_animateshapes/) e [transition](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/set_animatetransitions/). HTML simples não reproduz animações de slides, enquanto o HTML5 reproduz.

### Como a alteração da ordem z (ordem de camada) das formas afeta a animação?

A ordem de animação e a ordem de desenho são independentes: um efeito controla o tempo e o tipo de aparição/desaparecimento, enquanto [z-order](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/get_zorderposition/) determina o que cobre o quê. O resultado visível é definido pela combinação de ambos. (Esse é o comportamento geral do PowerPoint; o modelo de efeitos e formas do Aspose.Slides segue a mesma lógica.)

### Existem limitações ao converter animações em vídeo para certos efeitos?

Em geral, [as animações são suportadas](/slides/pt/cpp/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.