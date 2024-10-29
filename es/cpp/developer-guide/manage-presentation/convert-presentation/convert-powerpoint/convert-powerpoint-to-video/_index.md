---
title: Convertir PowerPoint a Video
type: docs
weight: 130
url: /es/cpp/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Video, MP4, PPT a video, PPT a MP4, C++, Aspose.Slides"
description: "Convertir PowerPoint a Video con la API de Aspose.Slides para C++"
---

Al convertir tu presentación de PowerPoint a video, obtienes

* **Aumento en accesibilidad:** Todos los dispositivos (independientemente de la plataforma) están equipados con reproductores de video por defecto en comparación con aplicaciones para abrir presentaciones, por lo que a los usuarios les resulta más fácil abrir o reproducir videos.
* **Mayor alcance:** A través de videos, puedes alcanzar a una gran audiencia y dirigirles información que de otro modo podría parecer tediosa en una presentación. La mayoría de las encuestas y estadísticas sugieren que las personas ven y consumen videos más que otras formas de contenido, y generalmente prefieren ese tipo de contenido.

## **Conversión de PowerPoint a Video en Aspose.Slides**

En [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/), implementamos soporte para la conversión de presentaciones a video.

* Usa Aspose.Slides para generar un conjunto de fotogramas (de las diapositivas de la presentación) que correspondan a una cierta FPS (fotogramas por segundo)
* Usa una utilidad de terceros como `ffmpeg` para crear un video basado en los fotogramas.

### **Convertir PowerPoint a Video**

1. Descarga ffmpeg [aquí](https://ffmpeg.org/download.html).
2. Agrega la ruta a `ffmpeg.exe` a la variable de entorno `PATH`.
3. Ejecuta el código para convertir PowerPoint a video.

Este código en C++ te muestra cómo convertir una presentación (que contiene una figura y dos efectos de animación) a un video:

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

## **Efectos de Video**

Puedes aplicar animaciones a objetos en las diapositivas y usar transiciones entre diapositivas.

{{% alert color="primary" %}} 

Puede que desees ver estos artículos: [Animación en PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Animación de Forma](https://docs.aspose.com/slides/cpp/shape-animation/), y [Efecto de Forma](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

Las animaciones y transiciones hacen que las presentaciones sean más atractivas e interesantes—y hacen lo mismo por los videos. Agreguemos otra diapositiva y transición al código de la presentación anterior:

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

Aspose.Slides también admite animaciones para textos. Así que animamos párrafos en objetos, que aparecerán uno tras otro (con el retraso establecido en un segundo):

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
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides para C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convertir presentación de PowerPoint con texto a video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"párrafo por párrafo"));
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

    // Convierte fotogramas a video
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

## **Clases de Conversión de Video**

Para permitirte realizar tareas de conversión de PowerPoint a video, Aspose.Slides proporciona las clases [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) y [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator te permite establecer el tamaño del fotograma para el video (que será creado más tarde) a través de su constructor. Si pasas una instancia de la presentación, se utilizará `Presentation.SlideSize` y genera animaciones que usa [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

Cuando se generan las animaciones, se genera un evento `NewAnimation` para cada animación subsiguiente, que tiene el parámetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). Este último es una clase que representa un reproductor para una animación separada.

Para trabajar con [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/), se utilizan la propiedad [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (la duración total de la animación) y el método [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). Cada posición de animación se establece dentro del rango *0 a la duración*, y luego el método `GetFrame` devolverá un Bitmap que corresponde al estado de la animación en ese momento.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Duración total de la animación: {0}", animationPlayer->get_Duration());

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

Para hacer que todas las animaciones en una presentación se reproduzcan a la vez, se utiliza la clase [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). Esta clase toma una instancia de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) y FPS para los efectos en su constructor y luego llama al evento `FrameTick` para todas las animaciones para que se reproduzcan:

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

Luego, los fotogramas generados se pueden compilar para producir un video. Consulta la sección [Convertir PowerPoint a Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animaciones y Efectos Admitidos**


**Entrada**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Entrar volando** | ![soportado](v.png) | ![soportado](v.png) |
| **Flotar en** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Limpiar** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Rueda** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Crecer y girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Acercar** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Botar** | ![soportado](v.png) | ![soportado](v.png) |


**Énfasis**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulso** | ![no soportado](x.png) | ![soportado](v.png) |
| **Pulso de color** | ![no soportado](x.png) | ![soportado](v.png) |
| **Balanza** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Crecer/Encoger** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desaturar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Oscurecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Aclarar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Transparencia** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de objeto** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color complementario** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de línea** | ![no soportado](x.png) | ![soportado](v.png) |
| **Color de relleno** | ![no soportado](x.png) | ![soportado](v.png) |

**Salida**:

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![no soportado](x.png) | ![soportado](v.png) |
| **Desvanecer** | ![soportado](v.png) | ![soportado](v.png) |
| **Salir volando** | ![soportado](v.png) | ![soportado](v.png) |
| **Flotar fuera** | ![soportado](v.png) | ![soportado](v.png) |
| **Dividir** | ![soportado](v.png) | ![soportado](v.png) |
| **Limpiar** | ![soportado](v.png) | ![soportado](v.png) |
| **Forma** | ![soportado](v.png) | ![soportado](v.png) |
| **Barras aleatorias** | ![soportado](v.png) | ![soportado](v.png) |
| **Encoger y girar** | ![no soportado](x.png) | ![soportado](v.png) |
| **Acercar** | ![soportado](v.png) | ![soportado](v.png) |
| **Girar** | ![soportado](v.png) | ![soportado](v.png) |
| **Botar** | ![soportado](v.png) | ![soportado](v.png) |

**Rutas de Movimiento:**

| Tipo de Animación | Aspose.Slides | PowerPoint |
|---|---|---|
| **Líneas** | ![soportado](v.png) | ![soportado](v.png) |
| **Arcos** | ![soportado](v.png) | ![soportado](v.png) |
| **Giros** | ![soportado](v.png) | ![soportado](v.png) |
| **Formas** | ![soportado](v.png) | ![soportado](v.png) |
| **Bucles** | ![soportado](v.png) | ![soportado](v.png) |
| **Ruta personalizada** | ![soportado](v.png) | ![soportado](v.png) |