---
title: Aplicar animaciones de forma en presentaciones usando C++
linktitle: Animación de forma
type: docs
weight: 60
url: /es/cpp/shape-animation/
keywords:
- forma
- animación
- efecto
- forma animada
- texto animado
- añadir animación
- obtener animación
- extraer animación
- añadir efecto
- obtener efecto
- extraer efecto
- sonido del efecto
- aplicar animación
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Descubra cómo crear y personalizar animaciones de forma en presentaciones de PowerPoint con Aspose.Slides para C++. ¡Destaque!"
---
## **Introducción**

Las animaciones son efectos visuales que pueden aplicarse a textos, imágenes, formas o [gráficos](/slides/es/cpp/animated-charts/). Dan vida a las presentaciones o a sus componentes. 

## **¿Por qué usar animaciones en presentaciones?**

Usando animaciones, puedes 

* controlar el flujo de información
* resaltar puntos importantes
* aumentar el interés o la participación de la audiencia
* facilitar la lectura, asimilación o procesamiento del contenido
* atraer la atención de los lectores o espectadores a las partes importantes de una presentación

PowerPoint ofrece muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

## **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesita para trabajar con animaciones bajo el espacio de nombres [Aspose.Slides.Animation](https://reference.aspose.com/slides/es/cpp/namespace/aspose.slides.animation),
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/es/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Estos efectos son esencialmente los mismos (o equivalentes) que se utilizan en PowerPoint.

## **Aplicar animación a un TextBox**

Aspose.Slides para C++ le permite aplicar animación al texto de una forma. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Añada una `rectangle` [IAutoShape](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_auto_shape). 
4. Añada texto a [IAutoShape.TextFrame](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Obtenga la secuencia principal de efectos.
6. Añada un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_auto_shape). 
7. Establezca la propiedad [TextAnimation.BuildType](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) al valor de la [Enumeración BuildType](https://reference.aspose.com/slides/es/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Guarde la presentación en disco como un archivo PPTX.

Este código C++ muestra cómo aplicar el efecto `Fade` a AutoShape y establecer la animación de texto al valor *By 1st Level Paragraphs*:

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

// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Añade una nueva AutoShape con texto
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Añade el efecto de animación Desvanecer a la forma
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Anima el texto de la forma por párrafos de primer nivel
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Guarda el archivo PPTX en disco
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Además de aplicar animaciones al texto, también puede aplicar animaciones a un único [Paragraph](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_paragraph). Consulte [**Texto animado**](/slides/es/cpp/animated-text/).

{{% /alert %}} 

## **Aplicar animación a un PictureFrame**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Añada o obtenga un [PictureFrame](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_picture_frame) en la diapositiva. 
4. Obtenga la secuencia principal de efectos.
5. Añada un efecto de animación al [PictureFrame](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_picture_frame).
6. Guarde la presentación en disco como un archivo PPTX.

Este código C++ muestra cómo aplicar el efecto `Fly` a un marco de imagen:

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

// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Cargar imagen para añadirla a la colección de imágenes de la presentación
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Añade un marco de imagen a la diapositiva
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Añade el efecto de animación Volar desde la izquierda al marco de imagen
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Guarda el archivo PPTX en disco
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Aplicar animación a una forma**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Añada una `rectangle` [IAutoShape](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_auto_shape). 
4. Añada una `Bevel` [IAutoShape](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_auto_shape) (cuando se haga clic en este objeto, se reproducirá la animación).
5. Cree una secuencia de efectos sobre la forma `Bevel`.
6. Cree un `UserPath` personalizado.
7. Añada comandos para mover al `UserPath`.
8. Guarde la presentación en disco como un archivo PPTX.

Este código C++ muestra cómo aplicar el efecto `PathFootball` (ruta fútbol) a una forma:

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

    // La ruta al directorio de documentos.
    const String outPath = u"../out/AnimationsOnShapes_out.pptx";
    const String templatePath = u"../templates/ConnectorLineAngle.pptx";

    // Carga la presentación
    SharedPtr<Presentation> pres = MakeObject<Presentation>();

    // Accede a la primera diapositiva
    SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

    // Accede a la colección de formas de la diapositiva seleccionada
    SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

    // Crea el efecto PathFootball para la forma existente desde cero.
    SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

    ashp->AddTextFrame(u"Animated TextBox");

    // Añade el efecto de animación PathFootBall
    slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
        EffectSubtype::None, EffectTriggerType::AfterPrevious);

    // Crea una especie de "botón".
    SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

    // Crea una secuencia de efectos para este botón.
    SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
    
     // Crea una ruta de usuario personalizada. Nuestro objeto se moverá sólo después de que se haga clic en el botón.
    SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

    // Añade comandos para mover ya que la ruta creada está vacía.
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
     
     // Escribe el archivo PPTX en disco
     pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Obtener los efectos de animación aplicados a una forma**

Los siguientes ejemplos le muestran cómo usar el método `GetEffectsByShape` de la interfaz [ISequence](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/) para obtener todos los efectos de animación aplicados a una forma.

**Ejemplo 1: Obtener los efectos de animación aplicados a una forma en una diapositiva normal**

Anteriormente, aprendió cómo añadir efectos de animación a formas en presentaciones de PowerPoint. El siguiente código de ejemplo muestra cómo obtener los efectos aplicados a la primera forma de la primera diapositiva normal de la presentación `AnimExample_out.pptx`.

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

// Obtiene la secuencia principal de animación de la diapositiva.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtiene la primera forma de la primera diapositiva.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Obtiene los efectos de animación aplicados a la forma.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Ejemplo 2: Obtener todos los efectos de animación, incluidos los heredados de marcadores de posición**

Si una forma en una diapositiva normal tiene marcadores de posición que están en la diapositiva de diseño y/o en la diapositiva maestra, y se han añadido efectos de animación a esos marcadores de posición, entonces todos los efectos de la forma se reproducirán durante la presentación, incluidos los heredados de los marcadores de posición.

Supongamos que tenemos un archivo de presentación PowerPoint `sample.pptx` con una diapositiva que contiene solo una forma de pie de página con el texto "Made with Aspose.Slides" y se ha aplicado el efecto **Random Bars** a la forma.

![Slide shape animation effect](slide-shape-animation.png)

Supongamos también que el efecto **Split** se ha aplicado al marcador de posición del pie de página en la diapositiva **de diseño**.

![Layout shape animation effect](layout-shape-animation.png)

Y, por último, el efecto **Fly In** se ha aplicado al marcador de posición del pie de página en la diapositiva **maestra**.

![Master shape animation effect](master-shape-animation.png)

El siguiente código de ejemplo muestra cómo usar el método `GetBasePlaceholder` de la interfaz [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) para acceder a los marcadores de posición de la forma y obtener los efectos de animación aplicados a la forma de pie de página, incluidos los heredados de los marcadores de posición situados en las diapositivas de diseño y maestra.

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

// Obtener los efectos de animación de la forma en la diapositiva normal.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Obtener los efectos de animación del marcador de posición en la diapositiva de diseño.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Obtener los efectos de animación del marcador de posición en la diapositiva maestra.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Volar, Inferior
Type: 134, subtype: 45            // Dividir, EntradaVertical
Type: 126, subtype: 22            // Barras aleatorias, Horizontal
```

## **Cambiar propiedades de temporización del efecto de animación**

Aspose.Slides para C++ le permite cambiar las propiedades de temporización de un efecto de animación.

Este es el panel de temporización de animación en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre la temporización de PowerPoint y las propiedades de [Effect.Timing](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- La lista desplegable **Start** de temporización de PowerPoint coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duration** de temporización de PowerPoint coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo. 
- **Delay** de temporización de PowerPoint coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Así es como cambia las propiedades de temporización del efecto:

1. [Apply](#apply-animation-to-shape) o obtenga el efecto de animación.
2. Establezca nuevos valores para las propiedades [Effect.Timing](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) que necesite. 
3. Guarde el archivo PPTX modificado.

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

// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Obtiene el primer efecto de la secuencia principal.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Cambia el TriggerType del efecto para que inicie al hacer clic
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Cambia la duración del efecto
effect->get_Timing()->set_Duration(3.f);

// Cambia el TriggerDelayTime del efecto
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Guarda el archivo PPTX en disco
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Sonido del efecto de animación**

Aspose.Slides proporciona estas propiedades para trabajar con sonidos en los efectos de animación: 

- [set_Sound()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Añadir sonido a un efecto de animación**

Este código C++ muestra cómo añadir un sonido a un efecto de animación y detenerlo cuando comienza el siguiente efecto:

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

// Añade audio a la colección de audio de la presentación
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Obtiene el primer efecto de la secuencia principal
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Comprueba si el efecto no tiene sonido
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Añade sonido al primer efecto
    firstEffect->set_Sound(effectSound);
}

// Obtiene la primera secuencia interactiva de la diapositiva.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Establece la bandera del efecto "Stop previous sound"
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Escribe el archivo PPTX en disco
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Extraer sonido de un efecto de animación**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Obtenga la secuencia principal de efectos. 
4. Extraiga el [set_Sound()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effect/set_sound/) incrustado en cada efecto de animación. 

Este código C++ muestra cómo extraer el sonido incrustado en un efecto de animación:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Obtiene la secuencia principal de la diapositiva.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Después de la animación**

Aspose.Slides para C++ le permite cambiar la propiedad After animation de un efecto de animación.

Este es el panel de efectos de animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable **After animation** del efecto de PowerPoint coincide con estas propiedades: 

- La propiedad [set_AfterAnimationType()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) que describe el tipo After animation :
  * PowerPoint **More Colors** coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/afteranimationtype/) (tipo predeterminado);
  * PowerPoint **Hide After Animation** coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/afteranimationtype/);
- La propiedad [set_AfterAnimationColor()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) que define un formato de color After animation. Esta propiedad funciona junto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/afteranimationtype/). Si cambia el tipo a otro, el color after animation se borrará.

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

// Instancia una clase de presentación que representa un archivo de presentación
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtiene el primer efecto de la secuencia principal
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Cambia el tipo de After animation a Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Establece el color de atenuación after animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Escribe el archivo PPTX en disco
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animar texto**

Aspose.Slides proporciona estas propiedades para trabajar con el bloque *Animate text* de un efecto de animación:

- La propiedad [set_AnimateTextType()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) que describe el tipo de animación de texto del efecto. El texto de la forma puede animarse:
  - Todo a la vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/animatetexttype/) tipo)
  - Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/animatetexttype/) tipo)
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/animatetexttype/) tipo)
- La propiedad [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) establece un retraso entre las partes del texto animado (palabras o letras). Un valor positivo especifica el porcentaje de la duración del efecto. Un valor negativo especifica el retraso en segundos.

Así es como puede cambiar las propiedades Animate text del efecto:

1. [Apply](#apply-animation-to-shape) o obtenga el efecto de animación.
2. Establezca la propiedad [set_BuildType()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itextanimation/set_buildtype/) al valor [BuildType.AsOneObject](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/buildtype/) para desactivar el modo de animación *By Paragraphs*.
3. Establezca nuevos valores para las propiedades [set_AnimateTextType()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) y [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Guarde el archivo PPTX modificado.

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

// Instancia una clase de presentación que representa un archivo de presentación.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Obtiene el primer efecto de la secuencia principal
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Cambia el tipo de animación de texto del efecto a "Como un solo objeto"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Cambia el tipo de animación de texto del efecto a "Por palabra"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Establece el retraso entre palabras al 20% de la duración del efecto
firstEffect->set_DelayBetweenTextParts(20.0f);

// Escribe el archivo PPTX en disco
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### ¿Cómo puedo asegurar que las animaciones se conserven al publicar la presentación en la web?

[Exportar a HTML5](/slides/es/cpp/export-to-html5/) y habilite las [opciones](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/html5options/) responsables de las animaciones de [shape](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/html5options/set_animateshapes/) y [transition](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/html5options/set_animatetransitions/). El HTML plano no reproduce animaciones de diapositivas, mientras que HTML5 sí.

### ¿Cómo afecta el cambio del orden Z (orden de capas) de las formas a la animación?

El orden de animación y el orden de dibujo son independientes: un efecto controla la temporización y el tipo de aparición/desaparición, mientras que el [z-order](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/get_zorderposition/) determina qué cubre a qué. El resultado visible está definido por su combinación. (Este es el comportamiento general de PowerPoint; el modelo de efectos y formas de Aspose.Slides sigue la misma lógica.)

### ¿Existen limitaciones al convertir animaciones a video para ciertos efectos?

En general, [las animaciones son compatibles](/slides/es/cpp/convert-powerpoint-to-video/), pero en casos raros o con efectos específicos pueden renderizarse de forma distinta. Se recomienda probar con los efectos que use y con la versión de la biblioteca.