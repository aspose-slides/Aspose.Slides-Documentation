---
title: Convertir presentaciones de PowerPoint a video en C++
linktitle: PowerPoint a video
type: docs
weight: 130
url: /es/cpp/convert-powerpoint-to-video/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir PPT
- convertir PPTX
- PowerPoint a video
- presentación a video
- PPT a video
- PPTX a video
- PowerPoint a MP4
- presentación a MP4
- PPT a MP4
- PPTX a MP4
- guardar PPT como MP4
- guardar PPTX como MP4
- exportar PPT a MP4
- exportar PPTX a MP4
- conversión de video
- PowerPoint
- C++
- Aspose.Slides
description: "Aprenda cómo convertir presentaciones de PowerPoint a video en C++. Descubra código de ejemplo y técnicas de automatización para optimizar su flujo de trabajo."
---

## **Visión general**

Al convertir su presentación de PowerPoint a video, obtiene 

* **Aumento de la accesibilidad:** Todos los dispositivos (independientemente de la plataforma) vienen equipados con reproductores de video de forma predeterminada, a diferencia de las aplicaciones de apertura de presentaciones, por lo que a los usuarios les resulta más fácil abrir o reproducir videos.
* **Mayor alcance:** A través de videos, puede llegar a una gran audiencia y dirigirse a ella con información que de otro modo podría resultar tediosa en una presentación. La mayoría de encuestas y estadísticas indican que las personas ven y consumen videos más que otras formas de contenido, y generalmente prefieren ese tipo de contenido.

En [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), implementamos soporte para la conversión de presentaciones a video. 

* Utilice Aspose.Slides para generar un conjunto de fotogramas (a partir de las diapositivas de la presentación) que correspondan a una cierta FPS (cuadros por segundo)
* Utilice una utilidad de terceros como `ffmpeg` para crear un video basado en los fotogramas.

## **Convertir una presentación de PowerPoint a video**

1. Descargue ffmpeg [aquí](https://ffmpeg.org/download.html).
2. Agregue la ruta a `ffmpeg.exe` a la variable de entorno `PATH`.
3. Ejecute el código de conversión de PowerPoint a video.

Este código C++ le muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a un video:
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

    // Agrega una forma de sonrisa y luego la anima
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


## **Efectos de video**

Puede aplicar animaciones a objetos en las diapositivas y usar transiciones entre diapositivas.

{{% alert color="primary" %}} 

Puede que desee ver estos artículos: [Animación de PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Animación de forma](https://docs.aspose.com/slides/cpp/shape-animation/), y [Efecto de forma](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes—y hacen lo mismo con los videos. Añadamos otra diapositiva y transición al código de la presentación anterior:
```c++
// Agrega una forma de sonrisa y la anima

// ...

// Agrega una nueva diapositiva y transición animada

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


Aspose.Slides también admite animación para textos. Así animamos párrafos en objetos, que aparecerán uno tras otro (con el retraso configurado a un segundo):
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

    // Agrega texto y animaciones
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

    // Convierte los fotogramas a video
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


## **Clases de conversión de video**

Para permitirle realizar tareas de conversión de PowerPoint a video, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) y [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator le permite establecer el tamaño de fotograma para el video (que se creará más adelante) a través de su constructor. Si pasa una instancia de la presentación, se utilizará `Presentation.SlideSize` y genera animaciones que [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) usa. 

Cuando se generan animaciones, se genera un evento `NewAnimation` para cada animación subsiguiente, que tiene como parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). Este último es una clase que representa un reproductor para una animación separate.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/), se utilizan la propiedad [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (la duración total de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Cada posición de animación se establece dentro del rango *0 a duration*, y luego el método `GetFrame` devolverá un Bitmap que corresponde al estado de la animación en ese momento.
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // estado inicial de la animación
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // bitmap del estado inicial de la animación

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // estado final de la animación
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // último fotograma de la animación
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Agrega una forma de sonrisa y la anima
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


Para que todas las animaciones en una presentación se reproduzcan a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) y FPS para los efectos en su constructor y luego llama al evento `FrameTick` para todas las animaciones para que se reproduzcan:
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


Luego los fotogramas generados pueden compilarse para producir un video. Consulte la sección [Convertir PowerPoint a video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y efectos compatibles**


**Entrada**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![no compatible](x.png) | ![compatible](v.png) |
| **Desvanecer** | ![compatible](v.png) | ![compatible](v.png) |
| **Desplazar entrada** | ![compatible](v.png) | ![compatible](v.png) |
| **Flotar entrada** | ![compatible](v.png) | ![compatible](v.png) |
| **Dividir** | ![compatible](v.png) | ![compatible](v.png) |
| **Borrar** | ![compatible](v.png) | ![compatible](v.png) |
| **Forma** | ![compatible](v.png) | ![compatible](v.png) |
| **Rueda** | ![compatible](v.png) | ![compatible](v.png) |
| **Barras aleatorias** | ![compatible](v.png) | ![compatible](v.png) |
| **Crecer y girar** | ![no compatible](x.png) | ![compatible](v.png) |
| **Acercar** | ![compatible](v.png) | ![compatible](v.png) |
| **Giratorio** | ![compatible](v.png) | ![compatible](v.png) |
| **Rebotar** | ![compatible](v.png) | ![compatible](v.png) |


**Énfasis**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulso** | ![no compatible](x.png) | ![compatible](v.png) |
| **Pulso de color** | ![no compatible](x.png) | ![compatible](v.png) |
| **Tambaleo** | ![compatible](v.png) | ![compatible](v.png) |
| **Giro** | ![compatible](v.png) | ![compatible](v.png) |
| **Crecer/Reducir** | ![no compatible](x.png) | ![compatible](v.png) |
| **Desaturar** | ![no compatible](x.png) | ![compatible](v.png) |
| **Oscurecer** | ![no compatible](x.png) | ![compatible](v.png) |
| **Aclarar** | ![no compatible](x.png) | ![compatible](v.png) |
| **Transparencia** | ![no compatible](x.png) | ![compatible](v.png) |
| **Color del objeto** | ![no compatible](x.png) | ![compatible](v.png) |
| **Color complementario** | ![no compatible](x.png) | ![compatible](v.png) |
| **Color de línea** | ![no compatible](x.png) | ![compatible](v.png) |
| **Color de relleno** | ![no compatible](x.png) | ![compatible](v.png) |

**Salida**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![no compatible](x.png) | ![compatible](v.png) |
| **Desvanecer** | ![compatible](v.png) | ![compatible](v.png) |
| **Desplazar salida** | ![compatible](v.png) | ![compatible](v.png) |
| **Flotar salida** | ![compatible](v.png) | ![compatible](v.png) |
| **Dividir** | ![compatible](v.png) | ![compatible](v.png) |
| **Borrar** | ![compatible](v.png) | ![compatible](v.png) |
| **Forma** | ![compatible](v.png) | ![compatible](v.png) |
| **Barras aleatorias** | ![compatible](v.png) | ![compatible](v.png) |
| **Reducir y girar** | ![no compatible](x.png) | ![compatible](v.png) |
| **Acercar** | ![compatible](v.png) | ![compatible](v.png) |
| **Giratorio** | ![compatible](v.png) | ![compatible](v.png) |
| **Rebotar** | ![compatible](v.png) | ![compatible](v.png) |

**Rutas de movimiento**:

| Tipo de animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Líneas** | ![compatible](v.png) | ![compatible](v.png) |
| **Arcos** | ![compatible](v.png) | ![compatible](v.png) |
| **Giros** | ![compatible](v.png) | ![compatible](v.png) |
| **Formas** | ![compatible](v.png) | ![compatible](v.png) |
| **Bucles** | ![compatible](v.png) | ![compatible](v.png) |
| **Ruta personalizada** | ![compatible](v.png) | ![compatible](v.png) |

## **Preguntas frecuentes**

**¿Es posible convertir presentaciones protegidas con contraseña?**

Sí, Aspose.Slides permite trabajar con [presentaciones protegidas con contraseña](/slides/es/cpp/password-protected-presentation/). Al procesar dichos archivos, debe proporcionar la contraseña correcta para que la biblioteca pueda acceder al contenido de la presentación.

**¿Aspose.Slides admite su uso en soluciones en la nube?**

Sí, Aspose.Slides puede integrarse en aplicaciones y servicios en la nube. La biblioteca está diseñada para trabajar en entornos de servidor, garantizando alto rendimiento y escalabilidad para el procesamiento por lotes de archivos.

**¿Existen limitaciones de tamaño para las presentaciones durante la conversión?**

Aspose.Slides es capaz de manejar presentaciones de prácticamente cualquier tamaño. Sin embargo, al trabajar con archivos muy grandes, pueden requerirse recursos del sistema adicionales, y a veces se recomienda optimizar la presentación para mejorar el rendimiento.