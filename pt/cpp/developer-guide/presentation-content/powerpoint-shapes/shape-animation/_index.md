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
description: "Descubra como criar e personalizar animações de formas em apresentações PowerPoint com Aspose.Slides para C++. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [gráficos](/slides/pt/cpp/animated-charts/). Elas dão vida às apresentações ou seus constituintes. 

## **Por que usar animações em apresentações?**

Usando animações, você pode 

* controlar o fluxo de informações
* enfatizar pontos importantes
* aumentar o interesse ou a participação do público
* tornar o conteúdo mais fácil de ler, assimilar ou processar
* atrair a atenção dos leitores ou espectadores para partes importantes de uma apresentação

PowerPoint fornece muitas opções e ferramentas para animações e efeitos de animação nas categorias de **entrada**, **saída**, **ênfase** e **caminhos de movimento**. 

## **Animações no Aspose.Slides**

* Aspose.Slides fornece as classes e tipos que você precisa para trabalhar com animações no namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation),
* Aspose.Slides oferece mais de **150 efeitos de animação** na enumeração [EffectType](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.

## **Aplicar animação a uma TextBox**

Aspose.Slides para C++ permite que você aplique animação ao texto em uma forma. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape). 
4. Adicione texto ao [IAutoShape.TextFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Obtenha a sequência principal de efeitos.
6. Adicione um efeito de animação ao [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape). 
7. Defina a propriedade [TextAnimation.BuildType](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) para o valor da [Enumeração BuildType](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Grave a apresentação no disco como um arquivo PPTX.

Este código C++ mostra como aplicar o efeito `Fade` ao AutoShape e definir a animação de texto para o valor *By 1st Level Paragraphs*:

```c++
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Adiciona um novo AutoShape com texto
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Obtém a sequência principal do slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Adiciona o efeito de animação Fade à forma
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Anima o texto da forma por parágrafos de primeiro nível
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Salva o arquivo PPTX no disco
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Paragraph](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_paragraph). Veja **Texto animado** [/slides/pt/cpp/animated-text/].

{{% /alert %}} 

## **Aplicar animação a um PictureFrame**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_picture_frame) no slide. 
4. Obtenha a sequência principal de efeitos.
5. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_picture_frame).
6. Grave a apresentação no disco como um arquivo PPTX.

Este código C++ mostra como aplicar o efeito `Fly` a uma moldura de imagem:

```c++
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
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Aplicar animação a uma Shape**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape). 
4. Adicione um `Bevel` [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape) (quando este objeto for clicado, a animação será reproduzida).
5. Crie uma sequência de efeitos na forma bevel.
6. Crie um `UserPath` personalizado.
7. Adicione comandos para mover para o `UserPath`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código C++ mostra como aplicar o efeito `PathFootball` (caminho de futebol) a uma forma:

```c++
	// O caminho para o diretório do documento.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carrega a apresentação
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Acessa o primeiro slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Acessa a coleção de formas do slide selecionado
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Cria o efeito PathFootball para a forma existente do zero.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Adiciona o efeito de animação PathFootball
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Cria algum tipo de "botão".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Cria uma sequência de efeitos para este botão.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Cria um caminho de usuário personalizado. Nosso objeto será movido somente após o botão ser clicado.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Adiciona comandos para mover, pois o caminho criado está vazio.
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

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma do primeiro slide normal na apresentação `AnimExample_out.pptx`.

```c++
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

Se uma forma em um slide normal possui marcadores de posição que estão no slide de layout e/ou no slide mestre, e efeitos de animação foram adicionados a esses marcadores, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos marcadores.

Suponha que tenhamos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** aplicado à forma.

![Efeito de animação de forma no slide](slide-shape-animation.png)

Suponha também que o efeito **Split** esteja aplicado ao marcador de posição do rodapé no slide de **layout**.

![Efeito de animação de forma no layout](layout-shape-animation.png)

E, finalmente, que o efeito **Fly In** esteja aplicado ao marcador de posição do rodapé no slide **mestre**.

![Efeito de animação de forma no mestre](master-shape-animation.png)

O código de exemplo a seguir demonstra como usar o método `GetBasePlaceholder` da interface [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) para acessar os marcadores de posição da forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo os herdados dos marcadores localizados nos slides de layout e mestre.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
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

Saída:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Voa, Inferior
Type: 134, subtype: 45            // Dividir, EntradaVertical
Type: 126, subtype: 22            // BarrasAleatórias, Horizontal
```

## **Alterar propriedades de tempo do efeito de animação**

Aspose.Slides para C++ permite que você altere as propriedades de tempo de um efeito de animação.

Este é o painel de Tempo de Animação no Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas são as correspondências entre o Tempo do PowerPoint e as propriedades de [Effect.Timing](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- A lista suspensa **Start** do PowerPoint Timing corresponde à propriedade [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- O **Duration** do PowerPoint Timing corresponde à propriedade [Effect.Timing.Duration](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). A duração de uma animação (em segundos) é o tempo total que a animação leva para completar um ciclo. 
- O **Delay** do PowerPoint Timing corresponde à propriedade [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Como alterar as propriedades de Tempo do Efeito:

1. [Aplique](#apply-animation-to-shape) ou obtenha o efeito de animação.
2. Defina novos valores para as propriedades de [Effect.Timing](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) que precisar.
3. Salve o arquivo PPTX modificado.

Este código C++ demonstra a operação:

```c++
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

Aspose.Slides fornece estas propriedades para permitir que você trabalhe com sons em efeitos de animação: 

- [set_Sound()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Adicionar som ao efeito de animação**

Este código C++ mostra como adicionar um som ao efeito de animação e interrompê‑lo quando o próximo efeito iniciar:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Adiciona áudio à coleção de áudio da apresentação
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtém a sequência principal do slide.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtém o primeiro efeito da sequência principal
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Verifica se o efeito tem "No Sound"
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

### **Extrair som do efeito de animação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de um slide através do seu índice. 
3. Obtenha a sequência principal de efeitos. 
4. Extraia o som incorporado de cada efeito de animação usando [set_Sound()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/effect/set_sound/). 

Este código C++ demonstra como extrair o som incorporado em um efeito de animação:

```c++
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Obtém a sequência principal do slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Depois da animação**

Aspose.Slides para C++ permite que você altere a propriedade After animation de um efeito de animação.

Este é o painel de Efeito de Animação e o menu expandido no Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

A lista suspensa **After animation** do PowerPoint Effect corresponde a estas propriedades: 

- A propriedade [set_AfterAnimationType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) que descreve o tipo After animation :
  * **More Colors** corresponde ao tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** corresponde ao tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/) (tipo padrão);
  * **Hide After Animation** corresponde ao tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/);
  * **Hide on Next Mouse Click** corresponde ao tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/);
- A propriedade [set_AfterAnimationColor()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) que define um formato de cor para after animation. Essa propriedade funciona em conjunto com o tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/afteranimationtype/). Se você mudar o tipo para outro, a cor after animation será limpa.

Este código C++ mostra como alterar um efeito after animation:

```c++
// Instancia uma classe de apresentação que representa um arquivo de apresentação
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtém o primeiro efeito da sequência principal
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Altera o tipo de after animation para Cor
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Define a cor de escurecimento after animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Grava o arquivo PPTX no disco
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animar texto**

Aspose.Slides fornece estas propriedades para permitir que você trabalhe com o bloco *Animate text* de um efeito de animação:

- [set_AnimateTextType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) que descreve o tipo de animação de texto do efeito. O texto da forma pode ser animado:
  - Tudo de uma vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/animatetexttype/) )
  - Por palavra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/animatetexttype/) )
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/animatetexttype/) )
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) define um atraso entre as partes do texto animado (palavras ou letras). Um valor positivo especifica a porcentagem da duração do efeito. Um valor negativo especifica o atraso em segundos.

Como alterar as propriedades Animate text do Efeito:

1. [Aplique](#apply-animation-to-shape) ou obtenha o efeito de animação.
2. Defina a propriedade [set_BuildType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation.itextanimation/set_buildtype/) para o valor [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/buildtype/) para desativar o modo de animação *By Paragraphs*.
3. Defina novos valores para as propriedades [set_AnimateTextType()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) e [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Salve o arquivo PPTX modificado.

Este código C++ demonstra a operação:

```c++
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtém o primeiro efeito da sequência principal
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Altera o tipo de animação de texto do efeito para "Como um único objeto"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Altera o tipo de animação de texto do efeito para "Por palavra"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Define o atraso entre palavras para 20% da duração do efeito
firstEffect->set_DelayBetweenTextParts(20.0f);

// Grava o arquivo PPTX no disco
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Como garantir que as animações sejam preservadas ao publicar a apresentação na web?**

[Exportar para HTML5](/slides/pt/cpp/export-to-html5/) e habilitar as [opções](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/) responsáveis por animações de [shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/set_animateshapes/) e de [transition](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/set_animatetransitions/). HTML simples não reproduz animações de slides, enquanto HTML5 sim.

**Como a mudança da ordem Z (ordem de camadas) das formas afeta a animação?**

Ordem de animação e ordem de desenho são independentes: um efeito controla o tempo e o tipo de aparição/desaparecimento, enquanto a [z-order](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/get_zorderposition/) determina o que cobre o que. O resultado visível é definido pela combinação de ambos. (Esse é o comportamento geral do PowerPoint; o modelo de efeitos e formas do Aspose.Slides segue a mesma lógica.)

**Existem limitações ao converter animações para vídeo para certos efeitos?**

Em geral, [as animações são suportadas](/slides/pt/cpp/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.