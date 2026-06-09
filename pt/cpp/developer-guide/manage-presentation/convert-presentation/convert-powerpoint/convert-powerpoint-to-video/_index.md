---
title: Converter apresentações PowerPoint em vídeo em C++
linktitle: PowerPoint para vídeo
type: docs
weight: 130
url: /pt/cpp/convert-powerpoint-to-video/
keywords:
- converter PowerPoint
- converter apresentação
- converter PPT
- converter PPTX
- PowerPoint para vídeo
- apresentação para vídeo
- PPT para vídeo
- PPTX para vídeo
- PowerPoint para MP4
- apresentação para MP4
- PPT para MP4
- PPTX para MP4
- salvar PPT como MP4
- salvar PPTX como MP4
- exportar PPT para MP4
- exportar PPTX para MP4
- conversão de vídeo
- PowerPoint
- C++
- Aspose.Slides
description: "Aprenda como converter apresentações PowerPoint em vídeo em C++. Descubra códigos de exemplo e técnicas de automação para simplificar seu fluxo de trabalho."
---
## **Introdução**

Ao converter sua apresentação PowerPoint em vídeo, você obtém 

* **Aumento da acessibilidade:** Todos os dispositivos (independentemente da plataforma) vêm equipados com reprodutores de vídeo por padrão, ao contrário dos aplicativos de abertura de apresentação, portanto os usuários acham mais fácil abrir ou reproduzir vídeos.
* **Maior alcance:** Por meio de vídeos, você pode alcançar um grande público e direcioná‑lo com informações que de outra forma poderiam parecer cansativas em uma apresentação. A maioria das pesquisas e estatísticas sugere que as pessoas assistem e consomem vídeos mais do que outras formas de conteúdo, e geralmente preferem esse tipo de conteúdo.

No [Aspose.Slides 22.11](https://docs.aspose.com/slides/pt/cpp/aspose-slides-for-cpp-22-11-release-notes/), implementamos suporte à conversão de apresentações em vídeo. 

* Use o Aspose.Slides para gerar um conjunto de quadros (a partir dos slides da apresentação) que correspondam a um determinado FPS (quadros por segundo)
* Use um utilitário de terceiros como `ffmpeg` para criar um vídeo baseado nos quadros.

## **Converter uma Apresentação PowerPoint em Vídeo**

1. Baixe o ffmpeg [aqui](https://ffmpeg.org/download.html).
2. Adicione o caminho para `ffmpeg.exe` à variável de ambiente `PATH`.
3. Execute o código de conversão de PowerPoint para vídeo.

Este código C++ mostra como converter uma apresentação (contendo uma figura e dois efeitos de animação) em um vídeo:

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adiciona uma forma de sorriso e então anima-a
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Efeitos de Vídeo**

Você pode aplicar animações a objetos nos slides e usar transições entre os slides.

{{% alert color="primary" %}} 
Você pode querer ver estes artigos: [Animação PowerPoint](https://docs.aspose.com/slides/pt/cpp/powerpoint-animation/), [Animação de Forma](https://docs.aspose.com/slides/pt/cpp/shape-animation/), e [Efeito de Forma](https://docs.aspose.com/slides/pt/cpp/shape-effect/).
{{% /alert %}} 

Animações e transições tornam as apresentações de slides mais envolventes e interessantes — e fazem o mesmo com vídeos. Vamos adicionar outro slide e transição ao código da apresentação anterior:

```c++
// Adiciona uma forma de sorriso e a anima

// ...

// Adiciona um novo slide e transição animada

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

O Aspose.Slides também suporta animação para textos. Assim, animamos parágrafos em objetos, que aparecerão um após o outro (com o atraso definido em um segundo):

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adiciona texto e animações
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // Converte quadros em vídeo
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **Classes de Conversão de Vídeo**

Para permitir que você execute tarefas de conversão de PowerPoint para vídeo, o Aspose.Slides fornece as classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.presentation_animations_generator/) e [PresentationPlayer](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator permite definir o tamanho do quadro para o vídeo (que será criado posteriormente) por meio de seu construtor. Se você passar uma instância da apresentação, `Presentation.SlideSize` será usada e ele gera animações que [PresentationPlayer](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.presentation_player/) utiliza. 

Quando as animações são geradas, um evento `NewAnimation` é disparado para cada animação subsequente, que tem o parâmetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.i_presentation_animation_player/). Este último é uma classe que representa um reprodutor para uma animação separada.

Para trabalhar com [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.i_presentation_animation_player/), são usados a propriedade [get_Duration](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (a duração total da animação) e o método [SetTimePosition](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Cada posição de animação é definida dentro da faixa *0 to duration*, e então o método `GetFrame` retornará um Bitmap que corresponde ao estado da animação naquele momento.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // estado inicial da animação
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap do estado inicial da animação

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // estado final da animação
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // último quadro da animação
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adiciona uma forma de sorriso e a anima
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

Para fazer com que todas as animações de uma apresentação sejam reproduzidas simultaneamente, usa‑se a classe [PresentationPlayer](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.presentation_player/). Essa classe recebe uma instância de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.export.presentation_animations_generator/) e FPS para os efeitos em seu construtor e, em seguida, chama o evento `FrameTick` para todas as animações, permitindo que sejam reproduzidas:

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```

Então, os quadros gerados podem ser compilados para produzir um vídeo. Veja a seção [Convert PowerPoint to Video](https://docs.aspose.com/slides/pt/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animações e Efeitos Compatíveis**


**Entrada**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |


**Ênfase**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Saída**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Caminhos de Movimento**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**É possível converter apresentações protegidas por senha?**

Sim, o Aspose.Slides permite trabalhar com [apresentações protegidas por senha](/slides/pt/cpp/password-protected-presentation/). Ao processar esses arquivos, você precisa fornecer a senha correta para que a biblioteca possa acessar o conteúdo da apresentação.

**O Aspose.Slides oferece suporte ao uso em soluções de nuvem?**

Sim, o Aspose.Slides pode ser integrado a aplicativos e serviços em nuvem. A biblioteca foi projetada para operar em ambientes de servidor, garantindo alto desempenho e escalabilidade para o processamento em lote de arquivos.

**Existem limitações de tamanho para apresentações durante a conversão?**

O Aspose.Slides é capaz de lidar com apresentações de praticamente qualquer tamanho. No entanto, ao trabalhar com arquivos muito grandes, recursos adicionais do sistema podem ser necessários, e às vezes é recomendado otimizar a apresentação para melhorar o desempenho.