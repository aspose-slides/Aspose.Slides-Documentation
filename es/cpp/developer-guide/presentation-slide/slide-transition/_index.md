---
title: Gestionar transiciones de diapositivas en presentaciones usando C++
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/cpp/slide-transition/
keywords:
  - transición de diapositiva
  - agregar transición de diapositiva
  - aplicar transición de diapositiva
  - transición de diapositiva avanzada
  - transición Morph
  - tipo de transición
  - efecto de transición
  - PowerPoint
  - OpenDocument
  - presentación
  - C++
  - Aspose.Slides
description: "Aplicar transiciones de diapositivas, configurar el avance automático de diapositivas y personalizar Morph y otros efectos de transición con Aspose.Slides para C++."
---
## **Visión general**

Las transiciones de diapositivas controlan cómo aparecen las diapositivas durante una presentación. Con Aspose.Slides para C++, puede elegir un efecto de transición para cada diapositiva, configurar el avance mediante clic del ratón o temporizador, y ajustar opciones específicas de un efecto. Este artículo utiliza ejemplos en C++ para aplicar transiciones, establecer duraciones exactas de transición, gestionar la temporización de las diapositivas y crear una transición Morph entre dos diapositivas. Los ejemplos también muestran cómo guardar la configuración en un archivo PPTX.

## **Agregar transición de diapositiva**

Para aplicar una transición, cargue una presentación con la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y acceda a la configuración de transición de una diapositiva mediante [get_SlideShowTransition](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). Llame a [set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_type/) con un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitiontype/), y luego guarde la presentación.

El siguiente ejemplo aplica una transición Circle a la primera diapositiva y una transición Comb a la segunda. Utilice un archivo `input.pptx` con al menos dos diapositivas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Agregar transición de diapositiva avanzada**

Puede configurar cuánto tiempo permanece una diapositiva en pantalla y si un clic del ratón avanza la presentación. Los siguientes métodos controlan este comportamiento:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) permite al espectador avanzar haciendo clic con el ratón.
- [set_AdvanceAfter](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_advanceafter/) habilita el avance automático.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) especifica el retraso antes del avance automático, en milisegundos.

Active tanto el avance con clic como el temporizado para que el espectador pueda continuar con un clic o esperar al temporizador. Para usar solo el temporizador, llame a [set_AdvanceOnClick](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) con `false`. El retraso controla cuándo avanza la presentación; no establece la duración del efecto visual de transición.

Este ejemplo asigna efectos diferentes a las tres primeras diapositivas y habilita el avance automático después de 3, 5 y 7 segundos, respectivamente. Los clics del ratón también pueden avanzar estas diapositivas. Utilice un archivo `input.pptx` con al menos tres diapositivas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

Para comprobar si el avance temporizado está habilitado, llame a [get_AdvanceAfter](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/get_advanceafter/). Un retraso almacenado por sí solo no indica que el temporizador esté activo.

El siguiente ejemplo abre el archivo guardado arriba, informa de cada temporizador habilitado y deshabilita el avance automático para las diapositivas con un retraso superior a dos segundos. Habilita los clics del ratón para esas diapositivas y guarda la configuración actualizada.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Controlar el tiempo de transición con precisión**

Utilice [set_Duration](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_duration/) para especificar la longitud exacta de un efecto de transición en milisegundos. El método [get_SlideShowTransition](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) de la diapositiva expone estas configuraciones a través de [ISlideShowTransition](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/):

| Método | Propósito |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_duration/) | Establece la duración del propio efecto de transición, en milisegundos. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | Establece el retraso antes de que la diapositiva avance automáticamente, en milisegundos. Llame a [set_AdvanceAfter](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_advanceafter/) con `true` para activar este temporizador. |
| [set_Speed](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_speed/) | Selecciona una categoría de velocidad predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium o Fast. Se usa cuando no se especifica una duración exacta. |

[set_Duration](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_duration/) controla solo el efecto de transición; no determina cuánto tiempo permanece visible la diapositiva. Configure el retraso de avance automático por separado. Cuando no se establece una duración explícita, Aspose.Slides determina la duración del efecto a partir del tipo de transición y del valor devuelto por [get_Speed](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/get_speed/).

### **Aplicar la misma duración a cada diapositiva**

Para mantener un ritmo constante, aplique el mismo efecto y la misma duración exacta a cada diapositiva. Este ejemplo carga `input.pptx`, selecciona Fade de [TransitionType](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitiontype/), y asigna a cada transición una duración de 750 milisegundos. Por separado habilita el avance automático después de 5 000 milisegundos y deshabilita el avance mediante clic del ratón, luego guarda el resultado como PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // Configurar el avance automático independientemente de la duración del efecto.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Establecer diferentes duraciones para diapositivas individuales**

Las diapositivas pueden usar duraciones de efecto distintas. Por ejemplo, use una transición breve para una diapositiva de título y una más larga para la introducción de una sección. Este ejemplo establece 500 milisegundos para la primera diapositiva y 1 200 milisegundos para la segunda. Utilice un archivo `input.pptx` con al menos dos diapositivas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **Coordinar transiciones con salida animada**

Al preparar un [animated GIF](/slides/es/cpp/convert-powerpoint-to-animated-gif/), una [HTML5 presentation](/slides/es/cpp/export-to-html5/) o un [video](/slides/es/cpp/convert-powerpoint-to-video/), establezca duraciones exactas de transición antes de la exportación para que coincidan con el ritmo deseado. Por ejemplo, use una fundido de 600 milisegundos entre escenas y ajuste el retraso de avance de cada diapositiva por separado para permitir tiempo a su narración o contenido.

Para GIF y video, coordine la velocidad de fotogramas de salida con la duración del efecto: 600 milisegundos corresponden a 18 fotogramas a 30 fps. En HTML5, habilite transiciones animadas en la configuración de exportación. Consulte los efectos y opciones de temporización compatibles con el formato de exportación elegido y previsualice la salida para confirmar la sincronización.

### **Leer una duración de transición existente**

Llame a [get_Duration](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/get_duration/) antes de modificar la transición para determinar si se almacena un valor explícito. Un valor de `-1` indica que no se ha establecido una duración explícita; un valor no negativo especifica la duración almacenada en milisegundos. El valor no establecido no es la duración calculada de reproducción: Aspose.Slides usa el tipo de transición y el valor devuelto por [get_Speed](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/get_speed/) para determinar esa duración. Establecer un tipo de transición puede inicializar una duración, por lo que primero inspeccione la configuración original.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Transición Morph**

La transición Morph anima los cambios entre objetos en diapositivas consecutivas. Para crear un efecto Morph sencillo, clone una diapositiva, mueva o cambie el tamaño de un objeto en el clon y aplique la transición Morph a la segunda diapositiva. Esto permite que la transición anime los objetos correspondientes entre sus estados original y modificado.

El siguiente ejemplo crea una diapositiva con un rectángulo de texto, clona la diapositiva y cambia la posición y el tamaño del rectángulo en el clon. Luego selecciona Morph en la enumeración [TransitionType](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitiontype/) para la segunda diapositiva. Abra el archivo guardado en un visor de presentaciones que admita Morph para ver el efecto durante la presentación.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Tipos de transición Morph**

La enumeración [TransitionMorphType](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitionmorphtype/) controla cómo Morph empareja y anima el contenido:

- [ByObject](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitionmorphtype/) trata cada forma como un objeto completo.
- [ByWord](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitionmorphtype/) anima el texto emparejando palabras siempre que sea posible.
- [ByChar](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitionmorphtype/) anima el texto emparejando caracteres siempre que sea posible.

Llame a [set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_type/) con Morph antes de acceder a [get_Value](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/get_value/). El valor proporciona la interfaz [IMorphTransition](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/imorphtransition/), cuyo método [set_MorphType](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) selecciona el modo de emparejamiento.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **Establecer efectos de transición**

Algunas transiciones exponen opciones adicionales, como la dirección o si el efecto comienza desde una pantalla negra. Las opciones disponibles dependen del tipo de transición seleccionado. Establezca el tipo primero, luego use la interfaz adecuada devuelta por [get_Value](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/get_value/).

El siguiente ejemplo aplica una transición Cut a la primera diapositiva de `input.pptx`. Llama a [set_FromBlack](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) con `true` a través de [IOptionalBlackTransition](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/ioptionalblacktransition/) para que la transición comience desde una pantalla negra.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Prefiera [set_Duration](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_duration/) cuando necesite una duración exacta del efecto en milisegundos. Use [set_Speed](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_speed/) cuando una categoría predefinida de [TransitionSpeed](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitionspeed/) – Slow, Medium o Fast – sea suficiente y no se haya establecido una duración explícita. Estas configuraciones controlan el efecto de transición independientemente del retraso de avance automático.

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Asigne audio incrustado con [set_Sound](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_sound/), llame a [set_SoundMode](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_soundmode/) con StartSound de la enumeración [TransitionSoundMode](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitionsoundmode/), y habilite la repetición con [set_SoundLoop](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_soundloop/). El audio se repetirá hasta el siguiente evento de sonido en la presentación.

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Recorra la colección devuelta por el método [get_Slides](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_slides/) de la presentación y llame a [set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/set_type/) con el mismo valor para la transición de cada diapositiva. Establezca cualquier opción de temporización y efecto dentro del mismo bucle para mantener el comportamiento coherente en todas las diapositivas.

**¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?**

Llame a [get_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/islideshowtransition/get_type/) sobre la transición devuelta por el método [get_SlideShowTransition](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) de la diapositiva. Devuelve un valor de la enumeración [TransitionType](https://reference.aspose.com/slides/es/cpp/aspose.slides.slideshow/transitiontype/); None indica que no se ha aplicado ningún efecto de transición.