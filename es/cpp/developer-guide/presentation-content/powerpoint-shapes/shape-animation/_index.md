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
description: "Aprenda cómo añadir, inspeccionar y personalizar animaciones de forma, sincronización, sonidos, comportamiento después de la animación y texto animado con Aspose.Slides para C++."
---
## **Descripción general**

Aspose.Slides for C++ representa las animaciones de diapositiva como efectos en una línea de tiempo de la diapositiva. Un efecto tiene una forma objetivo, un tipo y subtipo de animación, un disparador, configuraciones de tiempo y propiedades opcionales como sonido o comportamiento después de la animación.

La línea de tiempo contiene dos tipos de secuencias:

- La **secuencia principal** se reproduce a medida que avanza la diapositiva.
- Una **secuencia interactiva** comienza cuando se hace clic en su forma disparadora.

Dado que los cuadros de texto, imágenes, gráficos, tablas y otros objetos de diapositiva implementan [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/), utilizas el mismo método [ISequence::AddEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/addeffect/) para la mayor parte del contenido de la diapositiva. Los efectos disponibles se enumeran en la enumeración [EffectType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effecttype/).

## **Agregar animaciones a formas**

Para añadir una animación, obtén la secuencia principal de la diapositiva y llama a [ISequence::AddEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/addeffect/) con la forma objetivo, el tipo de efecto, el subtipo y el disparador. Para un efecto que comienza cuando se hace clic en otra forma, crea una secuencia interactiva cuyo disparador sea esa otra forma.

El siguiente ejemplo crea ambos tipos de animación y guarda el resultado en `shape-animations.pptx`.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Click to animate this shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
auto entranceEffect = mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
entranceEffect->get_Timing()->set_Duration(1.5f);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

presentation->Save(u"shape-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El disparador controla cuándo inicia un efecto:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effecttriggertype/) espera un clic en la secuencia principal, o un clic en la forma disparadora en una secuencia interactiva.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effecttriggertype/) inicia con el efecto precedente.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/effecttriggertype/) inicia cuando el efecto precedente finaliza.

Para animar una imagen, un gráfico u otro tipo de forma, pasa ese objeto a [ISequence::AddEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/addeffect/) en lugar de `targetShape`. Para opciones de agrupamiento específicas de gráficos, consulta [Animated Charts](/slides/es/cpp/animated-charts/).

## **Leer animaciones de formas**

Utiliza [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) cuando conozcas la forma objetivo. Para inspeccionar cada efecto, recorre la secuencia principal y todas las secuencias interactivas. La enumeración evita asumir que una secuencia contiene un efecto en el índice `0`.

El siguiente ejemplo crea una forma con efectos de secuencia principal e interactiva, obtiene los efectos que apuntan a la forma y luego recorre cada secuencia en la diapositiva.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto printSequence = [](const String& label, const SharedPtr<ISequence>& sequence)
{
    Console::WriteLine(String::Format(u"  {0}: {1} effect(s)", label, sequence->get_Count()));

    for (const auto& effect : sequence)
    {
        auto targetName = effect->get_TargetShape() == nullptr ? u"unknown" : effect->get_TargetShape()->get_Name();
        auto effectDescription = String::Format(u"{0} {1}; target: {2}; trigger: {3}", effect->get_Type(), effect->get_Subtype(), targetName, effect->get_Timing()->get_TriggerType());
        Console::WriteLine(u"    " + effectDescription);
    }
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Animated shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

auto targetEffects = mainSequence->GetEffectsByShape(targetShape);
Console::WriteLine(String::Format(u"The main sequence contains {0} effect(s) for {1}.", targetEffects->get_Length(), targetShape->get_Name()));

printSequence(u"Main sequence", mainSequence);

int32_t interactiveIndex = 1;
for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
{
    auto triggerName = sequence->get_TriggerShape() == nullptr ? u"unknown" : sequence->get_TriggerShape()->get_Name();
    auto sequenceLabel = String::Format(u"Interactive sequence {0}, trigger: {1}", interactiveIndex, triggerName);
    printSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

presentation->Dispose();
```

Si solo necesitas los efectos para una forma, primero identifica la forma por nombre, tipo de marcador de posición u otra propiedad estable; a continuación, llama a [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/geteffectsbyshape/). No asumas que [IShapeCollection::idx_get](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/idx_get/) en el índice `0` sea siempre el objeto deseado.

## **Trabajar con efectos heredados de marcadores de posición**

Un marcador de posición en una diapositiva normal puede heredar el comportamiento de animación del marcador de posición correspondiente en su diapositiva maestra y en su diapositiva de diseño. [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/getbaseplaceholder/) devuelve ese marcador de posición padre, o `nullptr` cuando no existe padre.

En la presentación del siguiente ejemplo, el pie de página tiene **Random Bars** en la diapositiva normal, **Split** en la diapositiva de diseño y **Fly In** en la diapositiva maestra.

![Efecto de animación del pie de página en la diapositiva normal](slide-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva de diseño](layout-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva maestra](master-shape-animation.png)

El siguiente ejemplo construye la jerarquía de marcadores de posición. Añade efectos a un marcador de posición maestro, a un marcador de posición de diseño y al marcador de posición correspondiente en una diapositiva normal. Cada llamada a [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/getbaseplaceholder/) se verifica antes de usar la forma devuelta.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto findPlaceholderWithBase = [](const SharedPtr<ISlide>& slide) -> SharedPtr<IShape>
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (shape->GetBasePlaceholder() != nullptr)
            return shape;
    }

    return nullptr;
};

auto printEffects = [](const String& source, const ArrayPtr<SharedPtr<IEffect>>& effects)
{
    Console::WriteLine(String::Format(u"{0}: {1} effect(s)", source, effects->get_Length()));

    for (const auto& effect : effects)
        Console::WriteLine(String::Format(u"  {0} {1}", effect->get_Type(), effect->get_Subtype()));
};

auto presentation = MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto layoutPlaceholder = layoutSlide->get_PlaceholderManager()->AddTextPlaceholder(100.0f, 100.0f, 400.0f, 80.0f);
layoutSlide->get_Timeline()->get_MainSequence()->AddEffect(layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
if (masterPlaceholder != nullptr)
{
    auto masterSequence = layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence();
    masterSequence->AddEffect(masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
}

auto slide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto slidePlaceholder = findPlaceholderWithBase(slide);

if (slidePlaceholder == nullptr)
    throw InvalidOperationException(u"The slide does not contain a placeholder linked to its layout slide.");

slide->get_Timeline()->get_MainSequence()->AddEffect(slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
printEffects(u"Normal slide", slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(slidePlaceholder));

auto baseLayoutPlaceholder = slidePlaceholder->GetBasePlaceholder();
if (baseLayoutPlaceholder != nullptr)
{
    printEffects(u"Layout slide", layoutSlide->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseLayoutPlaceholder));

    auto baseMasterPlaceholder = baseLayoutPlaceholder->GetBasePlaceholder();
    if (baseMasterPlaceholder != nullptr)
        printEffects(u"Master slide", layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseMasterPlaceholder));
}

presentation->Save(u"placeholder-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Cambiar la sincronización de la animación**

El cuadro de diálogo **Timing** de PowerPoint se corresponde con los métodos de [ITiming](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/).

![Cuadro de diálogo Timing de PowerPoint para un efecto de animación](shape-animation.png)

- **Start** se corresponde con [ITiming::set_TriggerType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_triggertype/).
- **Duration** se corresponde con [ITiming::set_Duration](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_duration/), en segundos.
- **Delay** se corresponde con [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/), en segundos.
- **Repeat** se corresponde con [ITiming::set_RepeatCount](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) o [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/).
- **Rewind when done playing** se corresponde con [ITiming::set_Rewind](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_rewind/).

Este ejemplo independiente añade un efecto, cambia su sincronización mediante el objeto devuelto por [ISequence::AddEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/addeffect/) y guarda el resultado. Mantener la referencia devuelta a [IEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/) evita un índice de colección innecesario.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Timed animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Timing()->set_TriggerType(EffectTriggerType::OnClick);
effect->get_Timing()->set_Duration(2.0f);
effect->get_Timing()->set_TriggerDelayTime(0.5f);
effect->get_Timing()->set_RepeatUntilNextClick(false);
effect->get_Timing()->set_RepeatUntilEndSlide(false);
effect->get_Timing()->set_RepeatCount(2.0f);
effect->get_Timing()->set_Rewind(true);

presentation->Save(u"shape-animation-timing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utiliza un modo de repetición de forma intencional. Combinar un recuento de repeticiones con una bandera “until” puede producir resultados confusos en diferentes visores. Cuando cambies los modos de repetición, llama a [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) y a [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) antes de [ITiming::set_RepeatCount](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/set_repeatcount/), porque establecer cualquiera de esas banderas también cambia el modo de repetición activo.

## **Agregar y extraer sonidos de animación**

Un efecto de animación puede hacer referencia a audio incrustado mediante [IEffect::set_Sound](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_sound/). [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) indica a un efecto que detenga el audio iniciado por un efecto anterior.

### **Agregar un sonido a un efecto**

El siguiente ejemplo espera un archivo de audio local llamado `animation-sound.wav`. Crea dos efectos, incrusta ese archivo como sonido del primer efecto y configura el segundo efecto para que detenga el sonido. Utiliza los objetos devueltos por [ISequence::AddEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/addeffect/), por lo que no se necesita un índice de secuencia.

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 100.0f, 240.0f, 80.0f);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 400.0f, 100.0f, 240.0f, 80.0f);
firstShape->get_TextFrame()->set_Text(u"Starts sound");
secondShape->get_TextFrame()->set_Text(u"Stops sound");

auto sequence = slide->get_Timeline()->get_MainSequence();
auto firstEffect = sequence->AddEffect(firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
auto secondEffect = sequence->AddEffect(secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto audioData = File::ReadAllBytes(u"animation-sound.wav");
auto effectSound = presentation->get_Audios()->AddAudio(audioData);
firstEffect->set_Sound(effectSound);
secondEffect->set_StopPreviousSound(true);

presentation->Save(u"shape-animation-sound.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Extraer sonidos incrustados de efectos**

El siguiente ejemplo espera una presentación local llamada `presentation-with-animation-sounds.pptx`. Examina tanto las secuencias principales como las interactivas y escribe cada sonido de efecto incrustado en el directorio `extracted-animation-sounds`. La extensión se selecciona a partir del tipo MIME de audio expuesto por [IAudio::get_ContentType](https://reference.aspose.com/slides/es/cpp/aspose.slides/iaudio/get_contenttype/).

```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::IO;

auto getAudioExtension = [](const String& contentType)
{
    auto normalizedType = String::IsNullOrEmpty(contentType) ? String::Empty : contentType.ToLowerInvariant();

    if (normalizedType == u"audio/mpeg")
        return String(u".mp3");

    if (normalizedType == u"audio/mp4")
        return String(u".m4a");

    if (normalizedType == u"audio/ogg")
        return String(u".ogg");

    if (normalizedType == u"audio/wav" || normalizedType == u"audio/x-wav")
        return String(u".wav");

    return String(u".bin");
};

auto saveSounds = [&getAudioExtension](const SharedPtr<ISequence>& sequence, const String& outputDirectory, int32_t& soundIndex)
{
    for (const auto& effect : sequence)
    {
        if (effect->get_Sound() == nullptr)
            continue;

        auto extension = getAudioExtension(effect->get_Sound()->get_ContentType());
        auto outputPath = Path::Combine(outputDirectory, String::Format(u"effect-sound-{0}{1}", soundIndex, extension));
        File::WriteAllBytes(outputPath, effect->get_Sound()->get_BinaryData());
        soundIndex++;
    }
};

auto inputPath = String(u"presentation-with-animation-sounds.pptx");
auto outputDirectory = String(u"extracted-animation-sounds");

Directory::CreateDirectory_(outputDirectory);

auto presentation = MakeObject<Presentation>(inputPath);
int32_t soundIndex = 1;

for (const auto& slide : presentation->get_Slides())
{
    saveSounds(slide->get_Timeline()->get_MainSequence(), outputDirectory, soundIndex);

    for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
        saveSounds(sequence, outputDirectory, soundIndex);
}

Console::WriteLine(String::Format(u"Extracted {0} sound file(s) to {1}.", soundIndex - 1, Path::GetFullPath(outputDirectory)));
presentation->Dispose();
```

Para objetos de audio grandes, utiliza [IAudio::GetStream](https://reference.aspose.com/slides/es/cpp/aspose.slides/iaudio/getstream/) y copia el flujo a un archivo en lugar de cargar todo el objeto en una matriz de bytes.

## **Establecer el comportamiento después de la animación**

La opción **After animation** controla qué ocurre con una forma después de que su efecto finaliza.

![Cuadro de diálogo de opciones de efecto de PowerPoint que muestra la configuración After animation](shape-after-animation.png)

La enumeración [AfterAnimationType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/afteranimationtype/) permite dejar la forma sin cambios, cambiar su color, ocultarla después de la animación o ocultarla en el siguiente clic. Cuando el tipo es [AfterAnimationType::Color](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/afteranimationtype/), llama a [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) para establecer también el color.

Este ejemplo independiente crea un efecto, establece su comportamiento después de la animación mediante el objeto efecto devuelto y guarda el resultado.

```cpp
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Dim after animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->set_AfterAnimationType(AfterAnimationType::Color);
effect->get_AfterAnimationColor()->set_Color(Color::get_LightGray());

presentation->Save(u"shape-animation-after-effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Cambiar el tipo a algo distinto de [AfterAnimationType::Color](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/afteranimationtype/) borra la configuración del color después de la animación.

## **Animar texto**

La animación de texto tiene dos controles relacionados:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itextanimation/set_buildtype/) controla si los párrafos aparecen juntos o por nivel de párrafo.
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) controla si el texto aparece de una vez, por palabra o por letra. [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) establece el retardo entre palabras o letras. Un valor positivo es un porcentaje de la duración del efecto; un valor negativo es un retardo en segundos.

El siguiente ejemplo independiente anima las palabras en un cuadro de texto. [BuildType::AsOneObject](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/buildtype/) desactiva la construcción párrafo a párrafo de modo que la configuración de palabras se aplique a todo el marco de texto.

```cpp
#include <DOM/Animation/AnimateTextType.h>
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

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 80.0f, 560.0f, 100.0f);
textBox->get_TextFrame()->set_Text(u"Aspose.Slides animates this sentence word by word.");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);
effect->set_AnimateTextType(AnimateTextType::ByWord);
effect->set_DelayBetweenTextParts(20.0f);

presentation->Save(u"animated-text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para construir un cuadro de texto por párrafo, utiliza [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itextanimation/set_buildtype/) con [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/buildtype/) u otro nivel de párrafo. Para dirigir un solo párrafo con su propio efecto, utiliza la sobrecarga de [ISequence::AddEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/addeffect/) que acepta un [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/). Consulta [Animated Text](/slides/es/cpp/animated-text/) para ejemplos a nivel de párrafo.

## **Exportar y notas de compatibilidad**

- Guardar en PPT o PPTX conserva el modelo de animación, pero la reproducción final está controlada por el visor de presentaciones.
- PDF e imágenes estáticas no reproducen animaciones. Utiliza [HTML5 export](/slides/es/cpp/export-to-html5/), GIF animado o [video conversion](/slides/es/cpp/convert-powerpoint-to-video/) cuando la salida debe mostrar movimiento.
- Para HTML5, habilita [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/html5options/set_animateshapes/) y, cuando sea necesario, [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/html5options/set_animatetransitions/).
- La renderización de video admite muchos efectos de entrada, énfasis, salida y trayectoria de movimiento comunes, pero no todos los efectos de PowerPoint son compatibles. Consulta la lista actual de [supported animations and effects](/slides/es/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) y prueba presentaciones críticas con tu versión objetivo de Aspose.Slides.
- Los efectos personalizados avanzados y los efectos importados de otros formatos de presentación pueden conservarse en el archivo pero mostrarse de forma diferente en PowerPoint, HTML5 o video. Valida el resultado exportado en lugar de confiar solo en el nombre del efecto.

## **FAQ**

**¿Por qué una animación se muestra en PowerPoint pero no en un PDF?**

PDF es un formato estático, por lo que las animaciones y transiciones de diapositiva no se reproducen. Exporta a HTML5, GIF animado o video cuando se debe conservar el movimiento.

**¿Por qué un efecto se reproduce de forma distinta en un video?**

La exportación a video renderiza las animaciones en lugar de almacenar el comportamiento original de PowerPoint. Algunos efectos avanzados no son compatibles o se aproximan. Revisa la tabla de efectos compatibles y prueba la presentación real antes de usarla en producción.

**¿Mover una forma hacia adelante o atrás cambia su orden de animación?**

No. El orden Z de la forma controla la superposición, mientras que el orden de la secuencia y los disparadores controlan la reproducción de la animación. Cambia la línea de tiempo si necesitas un orden de reproducción diferente.