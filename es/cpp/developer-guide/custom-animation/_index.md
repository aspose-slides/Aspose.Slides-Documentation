---
title: Crear y modificar comportamientos de animación personalizados en C++
linktitle: Animación personalizada
type: docs
weight: 151
url: /es/cpp/custom-animation/
keywords:
- animación personalizada
- comportamiento de animación
- ruta de movimiento
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Crear, inspeccionar y modificar comportamientos de animación personalizados y rutas de movimiento editables en presentaciones de PowerPoint con Aspose.Slides para C++."
---
## **Visión general**

Los comportamientos de animación personalizados le permiten controlar operaciones individuales dentro de un efecto de animación, como cambiar un color, rotar una forma o seguir una ruta de movimiento editable. Esta guía muestra cómo crear y combinar comportamientos, configurar su temporización, inspeccionar y modificar animaciones existentes y verificar que sus propiedades sobrevivan al guardar y volver a abrir una presentación.

Para efectos predefinidos y disparadores de clic, vea [Animación de forma](/slides/es/cpp/shape-animation/).

## **Comprender el modelo de animación**

Una animación se organiza como **Línea de tiempo → Secuencia → Efecto → Comportamientos**:

- La diapositiva [get_Timeline](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/get_timeline/) contiene su secuencia principal y secuencias interactivas.
- Un [ISequence](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/) contiene efectos, potencialmente dirigidos a diferentes formas.
- Un [IEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/) identifica una forma objetivo, un preset, un subtipo y la temporización del efecto.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/get_behaviors/) contiene las operaciones que implementan el efecto: cambiar color, mover, rotar, establecer una propiedad, etc.

## **Crear comportamientos individuales**

Llame a [ISequence::AddEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/isequence/addeffect/) para crear un efecto y acceder a su colección [get_Behaviors](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/get_behaviors/). Un preset puede poblar esta colección automáticamente. Mantenga sus operaciones al ampliar el preset, o use [Clear](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorcollection/clear/) cuando las reemplace deliberadamente.

[IBehaviorFactory](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/) crea los ocho tipos de comportamiento ilustrados a continuación. El movimiento se trata en [Build a Motion Path](#build-a-motion-path). Cada ejemplo de creación es código autónomo para ejecutarse dentro de una función; los ejemplos de edición posteriores indican el archivo de salida que utilizan.

### **Rotación**

Use [CreateRotationEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) para crear una rotación. [get_By](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/irotationeffect/get_by/) especifica un ángulo relativo en grados; [get_From](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/irotationeffect/get_from/) y [get_To](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/irotationeffect/get_to/) especifican los puntos finales.

El ejemplo comienza con un efecto Spin, reemplaza sus operaciones de preset con un comportamiento de rotación y asigna a esa operación una duración de dos segundos. Un ángulo relativo de 90 grados representa un cuarto de vuelta a partir de la orientación inicial de la forma, por lo que no se necesita un ángulo inicial explícito.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` contiene una forma y un comportamiento de rotación. La colección, la temporización y los ejemplos de edición de rotación a continuación utilizan este archivo.

### **Escala**

Use [CreateScaleEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) con porcentajes X/Y: [get_From](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/iscaleeffect/get_from/) y [get_To](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/iscaleeffect/get_to/) describen el tamaño inicial y final, mientras que [get_By](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/iscaleeffect/get_by/) describe un cambio relativo. Aquí, 100 significa el tamaño original.

El ejemplo aumenta ambas dimensiones de 100 % a 125 % en dos segundos. Usar porcentajes horizontales y verticales iguales mantiene las proporciones de la forma; porcentajes diferentes estirarían una dimensión más que la otra.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Color**

Use [CreateColorEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) para cambiar el relleno de azul a naranja. [get_From](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/icoloreffect/get_from/) y [get_To](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/icoloreffect/get_to/) son colores; [get_By](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/icoloreffect/get_by/) es un desplazamiento de color. [IBehavior::get_Properties](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehavior/get_properties/) identifica el atributo que se anima.

El relleno sólido de la forma se inicializa en azul, coincidiendo con el color inicial de la animación. Seleccionar el atributo de color de relleno indica al comportamiento qué parte de la forma cambiar; los puntos de color por sí solos no identifican ese atributo. El efecto guardado describe una transición de dos segundos a naranja.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Filtro**

Use [CreateFilterEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) para seleccionar un borrado. [get_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), y [get_Reveal](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) especifican el filtro, la dirección y si revelar o ocultar la forma.

Este ejemplo configura un borrado de dos segundos que revela la forma usando el subtipo de dirección derecha. La configuración del filtro pertenece al comportamiento dentro del efecto, por lo que se configura después de eliminar las operaciones originales del preset.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Propiedad**

Use [CreatePropertyEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) para animar la opacidad. [get_From](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ipropertyeffect/get_to/), y [get_By](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ipropertyeffect/get_by/) son cadenas interpretadas mediante [get_ValueType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) y [get_CalcMode](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). Elija puntos finales o un desplazamiento relativo en lugar de establecer los tres indiscriminadamente.

Aquí, el atributo seleccionado es opacidad, y las cadenas numéricas representan un cambio del 25 % de opacidad a opacidad total. La interpolación lineal describe un cambio gradual entre esos valores. Al adaptar este ejemplo a otro atributo, elija un tipo de valor y valores de punto final apropiados para ese atributo.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Asignación**

Use [CreateSetEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) para asignar la visibilidad mediante [get_To](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/iseteffect/get_to/). Un comportamiento de asignación no interpola entre puntos finales.

El ejemplo selecciona el atributo de visibilidad y asigna la cadena `visible` cuando se ejecuta el comportamiento. En C++, encapsule la cadena como un objeto antes de asignarla al comportamiento de asignación. El rectángulo ya es visible en esta presentación mínima, por lo que la asignación puede no producir un cambio visual evidente por sí sola. Esta operación es útil como parte de un efecto mayor que también controla cuándo la forma se oculta o se muestra.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **Comando**

Use [CreateCommandEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) y configure [get_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), y [get_ShapeTarget](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). Coloque una grabación WAV denominada `sample.wav` en el directorio de trabajo. Este ejemplo la incrusta con [AddAudioFrameEmbedded](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) y adjunta un comando de reproducción al marco de audio.

El marco de audio es tanto el objetivo del efecto como el objetivo del comando. Esto conecta la solicitud de reproducción con la grabación incrustada; una cadena de comando por sí sola no identifica qué objeto multimedia controlar. El efecto se configura para iniciarse con un clic durante la presentación.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

Guardar almacena el comando en `command.pptx`; no reproduce la grabación. La reproducción requiere un reproductor de presentaciones que admita el comando y su objetivo multimedia.

## **Administrar la colección de comportamientos**

[IBehaviorCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorcollection/) admite [Add](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorcollection/remove/), y [RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). Este ejemplo abre `rotation.pptx`, añade escalado, lo mueve antes de la rotación y elimina la rotación. Eliminar y volver a insertar el mismo objeto cambia su posición almacenada sin crear una copia.

La secuencia de ediciones cambia la colección de rotación‑escala a escala‑rotación y, finalmente, a solo escala. Los índices se refieren a la colección actual, por lo que la eliminación usa el nuevo índice de la rotación tras el reordenamiento. La enumeración final confirma qué comportamiento será guardado.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

La salida es `ScaleEffect`: solo queda el escalado. El orden de la colección no programa, por sí mismo, los comportamientos uno tras otro. Vacíe la colección solo cuando reemplace todas sus operaciones.

## **Configurar la temporización del comportamiento**

[IBehavior::get_Timing](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehavior/get_timing/) expone [ITiming](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/), de forma independiente de [IEffect::get_Timing](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/get_timing/). La temporización del efecto programa el efecto contenedor; la temporización del comportamiento describe una operación dentro de él.

### **Establecer duración, retraso, repetición y aceleración**

Abra `rotation.pptx` y establezca [get_Duration](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_duration/) y [get_TriggerDelayTime](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) en segundos, luego configure [get_RepeatCount](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_accelerate/) y [get_Decelerate](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_decelerate/) son fracciones de la duración; mantenga su suma como máximo 1.

El archivo de entrada es el creado en el ejemplo de rotación, donde se sabe que el primer comportamiento es una rotación. Este ejemplo cambia solo la temporización de ese comportamiento; su ángulo de 90 ° permanece intacto. Mantener ángulo y temporización separados facilita ajustar el ritmo sin reconstruir la animación.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

El comportamiento usa una duración de dos segundos, medio segundo de retraso y un recuento de repeticiones de 3. El primer y último 20 % de su duración se usan para aceleración y desaceleración.

Otras políticas de repetición incluyen [get_RepeatDuration](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), y [get_RepeatUntilNextClick](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); elija una política en lugar de habilitarlas todas a la vez. [get_AutoReverse](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/itiming/get_autoreverse/) reproduce la animación al revés después de la pasada directa. La aceleración y desaceleración se aplican a cambios continuos, no a asignaciones o comandos discretos.

## **Crear una ruta de movimiento**

Use [CreateMotionEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) para crear movimiento. Sus [get_From](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioneffect/get_to/), y [get_By](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioneffect/get_by/) describen coordenadas o desplazamientos basados en porcentajes. Para una ruta editable, cree un [MotionPath](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/motionpath/) y asígnelo a [IMotionEffect::get_Path](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioneffect/get_path/). [IMotionPath](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotionpath/) almacena los comandos de la ruta.

[MotionCommandPathType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/motioncommandpathtype/) selecciona la operación:

| Comando | Puntos | Significado |
| --- | --- | --- |
| MoveTo | Uno | Establecer la posición inicial. |
| LineTo | Uno | Moverse a lo largo de un segmento recto hasta su punto final. |
| CurveTo | Tres | Seguir una curva cúbica definida por dos puntos de control y un punto final. |
| CloseLoop | Ninguno | Volver a la posición inicial. |
| End | Ninguno | Finalizar la ruta. |

[MotionPathPointsType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/motionpathpointstype/) describe características de edición de puntos, como puntos de esquina o suaves. No sustituye al tipo de comando. Use un tipo de punto de curva para el ejemplo de curva más abajo y un tipo de punto de esquina para los segmentos rectos.

Las coordenadas de la ruta están normalizadas a las dimensiones de la diapositiva: un desplazamiento X de 0.25 representa un cuarto del ancho de la diapositiva, no 0.25 puntos. Y positivo avanza hacia abajo. Los comandos absolutos especifican posiciones en el sistema de coordenadas de la ruta; los comandos relativos especifican desplazamientos respecto a la posición actual. Esto es independiente de [get_Origin](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioneffect/get_origin/), que selecciona el marco de referencia de la ruta, y de [get_PathEditMode](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/), que controla cómo se mueve la ruta cuando se mueve la forma.

### **Crear una ruta recta**

Cree un comportamiento de movimiento con un punto inicial, un segmento recto y un comando de fin. [IMotionPath::Add](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotionpath/add/) recibe el tipo de comando, sus puntos, el tipo de punto y una bandera de coordenada relativa.

El comando inicial establece (0, 0), y la línea termina en (0.25, 0), proporcionando un desplazamiento horizontal de un cuarto del ancho de la diapositiva. El comando final no tiene puntos de coordenada. Una vez asignada la ruta, añadir el comportamiento de movimiento al efecto conecta esa ruta al rectángulo.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` contiene un comportamiento de movimiento con tres comandos de ruta. Los siguientes ejemplos de edición de archivo utilizan esta estructura conocida.

### **Comparar coordenadas absolutas y relativas**

Estos dos objetos de ruta describen la misma trayectoria. El comando absoluto termina en (0.3, 0.1); el comando relativo añade (0.1, 0.1) a la posición actual, (0.2, 0).

Ambas rutas comienzan en la misma posición. Para la línea relativa, sume sus desplazamientos X y Y a la posición actual para obtener el punto final; para la línea absoluta, lea directamente el punto final. Cambiar la bandera sin convertir las coordenadas describiría una ruta diferente.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

Asigne cualquiera de las rutas a un comportamiento de movimiento para usarla en una presentación. El argumento booleano final selecciona coordenadas relativas para ese comando.

### **Reemplazar una línea por una curva**

Abra `motion.pptx` y reemplace su comando de línea por una curva cúbica. Proporcione primero los dos puntos de control y, a continuación, el punto final.

La posición inicial se suministra mediante el comando precedente. Los dos primeros puntos dan forma a la curva, mientras que el tercero es su destino; no son tres destinos sucesivos. Actualizar simultáneamente el tipo de comando, el tipo de edición de puntos y el arreglo de puntos mantiene el segmento coherente con su nueva geometría.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

La ruta en `curve.pptx` sigue teniendo tres comandos; su comando intermedio ahora define una curva.

## **Inspeccionar y editar una ruta guardada**

Cada [IMotionCmdPath](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioncmdpath/) expone [get_Points](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), y [get_IsRelative](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). Los siguientes ejemplos usan la ruta conocida de tres comandos en `motion.pptx`. Para entrada arbitraria, localice el efecto deseado y verifique los tipos de comando y el recuento de puntos antes de editar por índice.

### **Leer comandos y coordenadas**

Lea la ruta sin modificarla. Los comandos de fin y de cierre de bucle no requieren puntos, así que permita un arreglo de puntos nulo.

La salida empareja cada comando con su bandera de coordenada relativa antes de enumerar sus puntos. Esto le permite distinguir un punto final de un desplazamiento antes de modificar la ruta. Una curva listaría tres puntos, mientras que la línea recta en este archivo lista solo uno.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

El listado contiene un punto inicial, una línea absoluta que termina en (0.25, 0) y un comando de fin.

### **Cambiar un punto final**

Abra `motion.pptx` y reemplace el arreglo de puntos de la línea para mover su punto final.

En el archivo de entrada, el índice 0 es el comando de inicio y el índice 1 es la línea. Reemplazar el único punto de la línea cambia su destino sin alterar el tipo de comando, la temporización o la posición en la colección. Como el comando usa coordenadas absolutas, el nuevo par especifica una posición en lugar de un desplazamiento añadido.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

La línea en `motion-endpoint.pptx` termina en (0.4, 0.1); el archivo original permanece sin cambios.

### **Reemplazar un segmento**

Use [Insert](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotionpath/insert/) y [RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/imotionpath/removeat/) para sustituir la línea en `motion.pptx`. Insertar desplaza la línea antigua al índice 2.

Esto demuestra cómo reemplazar un objeto de comando en lugar de editar sus coordenadas existentes. Tras la inserción, la colección contiene temporalmente el comando de inicio, la nueva línea, la línea antigua y el comando de fin. Eliminar el índice 2 descarta la línea antigua y deja la nueva ruta en su sitio.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

La ruta guardada sigue teniendo tres comandos, con la nueva línea terminando en (0.2, 0.1) y el comando de fin al final.

## **Modificar y verificar un comportamiento existente**

Cuando el índice del comportamiento es desconocido, selecciónelo por tipo. Este ejemplo abre `rotation.pptx`, encuentra su [IRotationEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/irotationeffect/), cambia el ángulo y comprueba el valor guardado tras volver a abrir.

La comprobación de tipo permite que el bucle omita comportamientos que no son rotaciones. La segunda carga lee el archivo guardado en un objeto de presentación separado, de modo que la comparación verifica los datos persistentes en lugar del valor que aún está en memoria. Este ejemplo asume que el efecto conocido es el primero en la secuencia principal; seleccionar un comportamiento por tipo no localiza el efecto correcto en una presentación arbitraria.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

La salida es `Rotation preserved: True`. Aplique el mismo patrón de comprobación de tipo a otros comportamientos. Para una verificación completa de preservación, compare la forma objetivo, el efecto, los tipos y el orden de los comportamientos, la temporización y los comandos de ruta. Use una tolerancia numérica para valores de punto flotante. Para una presentación con una disposición de animación desconocida, vea [Read Shape Animations](/slides/es/cpp/shape-animation/#read-shape-animations) para recorrer las secuencias principal e interactiva.

## **Orden de los comportamientos, presets y reproducción**

El orden en [IBehaviorCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehaviorcollection/) es el orden almacenado de las operaciones de un efecto. No es una lista de reproducción en la que cada comportamiento espere automáticamente al anterior. La temporización y el efecto contenedor determinan la programación. Los comportamientos pueden solaparse, y las operaciones sobre la misma propiedad pueden interactuar mediante [get_Additive](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehavior/get_additive/) y [get_Accumulate](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ibehavior/get_accumulate/). No utilice solo el reordenamiento de la colección para programar “mover, luego rotar”; emplee temporizaciones explícitas o efectos separados como se describe en [Animación de forma](/slides/es/cpp/shape-animation/).

El [get_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/get_type/) y el [get_Subtype](https://reference.aspose.com/slides/es/cpp/aspose.slides.animation/ieffect/get_subtype/) del efecto describen su preset. No constituyen una descripción completa de un árbol de comportamientos editado. Elija el preset y el subtipo antes de personalizar los comportamientos: cambiar el preset puede reconstruir la colección y descartar sus operaciones personalizadas. Por ejemplo, cambiar un efecto Spin personalizado a Fade puede sustituir su comportamiento de rotación por comportamientos de asignación y filtro. Inspeccione la colección nuevamente después de cambiar un preset o subtipo. Vaciar los comportamientos del preset también puede eliminar operaciones de visibilidad o inicialización que el preset necesita. Los ejemplos usan deliberadamente formas visibles y reemplazan los comportamientos; no reconstruyen la implementación de cada preset.

## **Compatibilidad de formatos**

Un árbol de comportamientos preservado no garantiza una reproducción idéntica en todos los visores o motores de exportación. Verifique los datos guardados y la salida renderizada por separado.

| Formato o salida | Qué verificar |
| --- | --- |
| PPTX | Úselo como formato principal para estos ejemplos. Vuelva a abrirlo para verificar el árbol de comportamientos editable y luego compruebe la reproducción en la versión de PowerPoint deseada. |
| PPT | La representación binaria heredada puede diferir de PPTX. Pruebe un ciclo separado de guardar‑y‑reabrir y la reproducción; no deduzca soporte para cada combinación personalizada a partir del éxito en PPTX. |
| PDF, PNG, JPEG y otras imágenes estáticas de diapositivas | Contienen una representación estática de la diapositiva, no una línea de tiempo reproducible ni un fotograma final garantizado de la animación. |
| [HTML5](/slides/es/cpp/export-to-html5/) | Puede reproducir animaciones admitidas cuando la animación de forma está activada en las opciones de exportación. Pruebe combinaciones personalizadas en el navegador. |
| [GIF animado](/slides/es/cpp/convert-powerpoint-to-animated-gif/) | Almacena fotogramas renderizados, no comportamientos editables ni interacción por clic. Compruebe el movimiento renderizado real. |
| [Vídeo](/slides/es/cpp/convert-powerpoint-to-video/) | Renderiza fotogramas de animación y los codifica como vídeo. El soporte está limitado a las [animaciones y efectos admitidos](/slides/es/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) del motor de renderizado; los comandos y eventos interactivos no se convierten en una línea de tiempo editable. |

## **Preguntas frecuentes**

**¿Por qué mi efecto contiene comportamientos antes de añadir ninguno?**

Crear un efecto predefinido puede generar sus operaciones subyacentes. Inspecciónelas antes de decidir si ampliar el preset o reemplazar sus comportamientos.

**¿Mover un comportamiento al principio hace que se reproduzca primero?**

No necesariamente. El orden de la colección no sustituye a la temporización. Verifique retrasos, duraciones e interacciones entre operaciones sobre la misma propiedad.

**¿Por qué un comando de fin no tiene puntos?**

Marca el final de la ruta y no necesita coordenadas. Compruebe un arreglo de puntos nulo al inspeccionar una ruta leída de un archivo.

**¿Es suficiente un ciclo completo exitoso para confirmar la reproducción?**

No. Volver a abrir confirma la preservación de las propiedades que verificó. Pruebe el reproductor de presentaciones o la exportación animada por separado para confirmar su comportamiento visual.