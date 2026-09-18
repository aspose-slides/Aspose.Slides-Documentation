---
title: Crear y modificar comportamientos de animación personalizados en .NET
linktitle: Animación personalizada
type: docs
weight: 151
url: /es/net/custom-animation/
keywords:
- animación personalizada
- comportamiento de animación
- ruta de movimiento
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear, inspeccionar y modificar comportamientos de animación personalizados y rutas de movimiento editables en presentaciones de PowerPoint con Aspose.Slides para .NET."
---
## **Visión general**

Los comportamientos de animación personalizados le permiten controlar operaciones individuales dentro de un efecto de animación, como cambiar un color, rotar una forma o seguir una ruta de movimiento editable. Esta guía muestra cómo crear y combinar comportamientos, configurar su sincronización, inspeccionar y modificar animaciones existentes, y verificar que sus propiedades sobrevivan al guardar y volver a abrir una presentación.

Para efectos predefinidos y desencadenadores de clic, vea [Animación de formas](/slides/es/net/shape-animation/).

## **Comprender el modelo de animación**

- La diapositiva’s [Timeline](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/timeline/) contiene su secuencia principal y secuencias interactivas.
- Un [ISequence](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/) contiene efectos, potencialmente dirigidos a diferentes formas.
- Un [IEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/) identifica una forma objetivo, un preset, un subtipo y la sincronización del efecto.
- [IEffect.Behaviors](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/behaviors/) contiene las operaciones que implementan el efecto: cambiar color, mover, rotar, establecer una propiedad, etc.

## **Crear comportamientos individuales**

Llame a [ISequence.AddEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/isequence/addeffect/) para crear un efecto y acceder a su colección [Behaviors](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/behaviors/). Un preset puede poblar esta colección automáticamente. Mantenga sus operaciones al ampliar el preset, o use [Clear](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorcollection/clear/) cuando reemplace deliberadamente las operaciones.

[IBehaviorFactory](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/) crea los ocho tipos de comportamiento ilustrados a continuación. El movimiento se cubre en [Build a Motion Path](#build-a-motion-path). Cada ejemplo de creación es un programa completo; los ejemplos de edición posteriores indican el archivo de salida que utilizan.

### **Rotación**

Utilice [CreateRotationEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) para crear una rotación. [By](https://reference.aspose.com/slides/es/net/aspose.slides.animation/irotationeffect/by/) especifica un ángulo relativo en grados; [From](https://reference.aspose.com/slides/es/net/aspose.slides.animation/irotationeffect/from/) y [To](https://reference.aspose.com/slides/es/net/aspose.slides.animation/irotationeffect/to/) especifican los puntos finales.

El ejemplo comienza con un efecto Spin, sustituye sus operaciones de preset por un único comportamiento de rotación y da a esa operación una duración de dos segundos. Un ángulo relativo de 90 grados representa un cuarto de vuelta desde la orientación inicial de la forma, por lo que no se necesita un ángulo inicial explícito.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` contiene una forma y un comportamiento de rotación. La colección, la sincronización y los ejemplos de edición de rotación a continuación usan este archivo.

### **Escala**

Utilice [CreateScaleEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) con porcentajes X/Y: [From](https://reference.aspose.com/slides/es/net/aspose.slides.animation/iscaleeffect/from/) y [To](https://reference.aspose.com/slides/es/net/aspose.slides.animation/iscaleeffect/to/) describen el tamaño inicial y final, mientras que [By](https://reference.aspose.com/slides/es/net/aspose.slides.animation/iscaleeffect/by/) describe un cambio relativo. Aquí, 100 significa el tamaño original.

El ejemplo aumenta ambas dimensiones del 100 % al 125 % en dos segundos. Usar porcentajes horizontales y verticales iguales mantiene las proporciones de la forma; porcentajes diferentes la estirarían más en una dimensión que en la otra.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Color**

Utilice [CreateColorEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) para cambiar el relleno de azul a naranja. [From](https://reference.aspose.com/slides/es/net/aspose.slides.animation/icoloreffect/from/) y [To](https://reference.aspose.com/slides/es/net/aspose.slides.animation/icoloreffect/to/) son colores; [By](https://reference.aspose.com/slides/es/net/aspose.slides.animation/icoloreffect/by/) es un desplazamiento de color. [IBehavior.Properties](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehavior/properties/) identifica el atributo que se anima.

El relleno sólido de la forma se inicializa a azul, coincidiendo con el color inicial de la animación. Seleccionar el atributo de color de relleno indica al comportamiento qué parte de la forma cambiar; los colores finales por sí solos no identifican ese atributo. El efecto guardado describe una transición de dos segundos a naranja.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Filtro**

Utilice [CreateFilterEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) para seleccionar una transición de borrado. [Type](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ifiltereffect/subtype/) y [Reveal](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ifiltereffect/reveal/) especifican el filtro, la dirección y si se revela o oculta la forma.

Este ejemplo configura una transición de borrado de dos segundos que revela la forma usando el subtipo de dirección derecha. La configuración del filtro pertenece al comportamiento dentro del efecto, por lo que se configura después de haber eliminado las operaciones originales del preset.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Propiedad**

Utilice [CreatePropertyEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) para animar la opacidad. [From](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ipropertyeffect/to/) y [By](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ipropertyeffect/by/) son cadenas interpretadas mediante [ValueType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ipropertyeffect/valuetype/) y [CalcMode](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ipropertyeffect/calcmode/). Elija puntos finales o un desplazamiento relativo en lugar de establecer los tres indiscriminadamente.

Aquí, el atributo seleccionado es opacidad, y las cadenas numéricas representan un cambio del 25 % de opacidad a opacidad completa. La interpolación lineal describe un cambio gradual entre esos valores. Al adaptar este ejemplo a otro atributo, elija un tipo de valor y valores finales apropiados para ese atributo.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Establecer**

Utilice [CreateSetEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) para asignar visibilidad mediante [To](https://reference.aspose.com/slides/es/net/aspose.slides.animation/iseteffect/to/). Un comportamiento de tipo set no interpola entre puntos finales.

El ejemplo selecciona el atributo de visibilidad y asigna la cadena `visible` cuando se ejecuta el comportamiento. El rectángulo ya es visible en esta presentación mínima, por lo que la asignación puede no producir un cambio visual obvio por sí sola. Esta operación es útil como parte de un efecto mayor que también controla cuándo la forma se oculta o se muestra.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Comando**

Utilice [CreateCommandEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) y configure [Type](https://reference.aspose.com/slides/es/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/es/net/aspose.slides.animation/icommandeffect/commandstring/) y [ShapeTarget](https://reference.aspose.com/slides/es/net/aspose.slides.animation/icommandeffect/shapetarget/). Coloque una grabación WAV llamada `sample.wav` en el directorio de trabajo. Este ejemplo la incrusta con [AddAudioFrameEmbedded](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addaudioframeembedded/) y adjunta un comando de reproducción al fotograma de audio.

El fotograma de audio es tanto el objetivo del efecto como el objetivo del comando. Esto conecta la solicitud de reproducción con la grabación incrustada; una cadena de comando por sí sola no identifica qué objeto multimedia controlar. El efecto está configurado para iniciarse con un clic durante la presentación.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Guardar almacena el comando en `command.pptx`; no reproduce la grabación. La reproducción requiere un reproductor de presentaciones que admita el comando y su objetivo multimedia.

## **Administrar la colección de comportamientos**

[IBehaviorCollection](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorcollection/) admite [Add](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorcollection/remove/), y [RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorcollection/removeat/). Este ejemplo abre `rotation.pptx`, añade escalado, lo mueve antes de la rotación y elimina la rotación. Eliminar e insertar de nuevo el mismo objeto cambia su posición almacenada sin crear una copia.

La secuencia de ediciones cambia la colección de rotación‑escala a escala‑rotación y luego a solo escala. Los índices se refieren a la colección actual, por lo que la eliminación usa el nuevo índice de la rotación tras el reordenamiento. La enumeración final confirma qué comportamiento se guardará.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

La salida es `ScaleEffect`: solo queda el escalado. El orden de la colección no programa por sí mismo los comportamientos uno tras otro. Vacíe la colección solo cuando reemplace todas sus operaciones.

## **Configurar el tiempo de los comportamientos**

[IBehavior.Timing](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehavior/timing/) expone [ITiming](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/), independientemente de [IEffect.Timing](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/timing/). La sincronización del efecto programa el efecto contenedor; la sincronización del comportamiento describe una operación dentro de él.

### **Establecer duración, retraso, repetición y aceleración**

Abra `rotation.pptx` y establezca [Duration](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/duration/) y [TriggerDelayTime](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/triggerdelaytime/) en segundos, luego configure [RepeatCount](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/accelerate/) y [Decelerate](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/decelerate/) son fracciones de la duración; mantenga su suma como máximo 1.

El archivo de entrada es el creado en el ejemplo de rotación, donde se sabe que el primer comportamiento es una rotación. Este ejemplo cambia solo la sincronización de ese comportamiento; su ángulo de 90 ° permanece intacto. Mantener el ángulo y la sincronización separados facilita ajustar el ritmo sin rehacer la animación.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

El comportamiento usa una duración de dos segundos, un retraso de medio segundo y un recuento de repeticiones de 3. El 20 % inicial y final de su duración se usan para aceleración y desaceleración.

Otras políticas de repetición incluyen [RepeatDuration](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatuntilendslide/), y [RepeatUntilNextClick](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/repeatuntilnextclick/); elija una política en lugar de habilitarlas todas a la vez. [AutoReverse](https://reference.aspose.com/slides/es/net/aspose.slides.animation/itiming/autoreverse/) reproduce la animación al revés después del paso hacia adelante. La aceleración y desaceleración se aplican a cambios continuos, no a asignaciones discretas ni a comandos.

## **Crear una ruta de movimiento**

Utilice [CreateMotionEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) para crear movimiento. Sus [From](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioneffect/to/), y [By](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioneffect/by/) describen coordenadas o desplazamientos basados en porcentajes. Para una ruta editable, cree un [MotionPath](https://reference.aspose.com/slides/es/net/aspose.slides.animation/motionpath/) y asígnele a [IMotionEffect.Path](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotionpath/) almacena los comandos de la ruta.

[MotionCommandPathType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/motioncommandpathtype/) selecciona la operación:

| Comando | Puntos | Significado |
| --- | --- | --- |
| MoveTo | Uno | Establecer la posición inicial. |
| LineTo | Uno | Moverse a lo largo de un segmento recto hasta su punto final. |
| CurveTo | Tres | Seguir una curva cúbica definida por dos puntos de control y un punto final. |
| CloseLoop | Ninguno | Volver a la posición inicial. |
| End | Ninguno | Finalizar la ruta. |

[MotionPathPointsType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/motionpathpointstype/) describe características de edición de puntos, como puntos de esquina o suaves. No reemplaza al tipo de comando. Use un tipo de punto de curva para el ejemplo de curva más abajo, y un tipo de punto de esquina para los segmentos rectos.

Las coordenadas de la ruta se normalizan a las dimensiones de la diapositiva: un desplazamiento X de 0.25 representa un cuarto del ancho de la diapositiva, no 0.25 puntos. Y positivo avanza hacia abajo. Los comandos absolutos especifican posiciones en el sistema de coordenadas de la ruta; los comandos relativos especifican desplazamientos desde la posición actual. Esto es independiente de [Origin](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioneffect/origin/), que selecciona el marco de referencia de la ruta, y de [PathEditMode](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioneffect/patheditmode/), que controla cómo se mueve la ruta cuando se mueve la forma.

### **Crear una ruta recta**

Cree un comportamiento de movimiento con un punto inicial, un segmento recto y un comando final. [IMotionPath.Add](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotionpath/add/) recibe el tipo de comando, sus puntos, el tipo de punto y una bandera de coordenada relativa.

El comando inicial establece (0, 0), y la línea termina en (0.25, 0), dando a la ruta un desplazamiento horizontal de un cuarto del ancho de la diapositiva. El comando final no tiene puntos coordenados. Una vez asignada la ruta, al añadir el comportamiento de movimiento al efecto se conecta esa ruta al rectángulo.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` contiene un comportamiento de movimiento con tres comandos de ruta. Los siguientes ejemplos de edición de archivos usan esta estructura conocida.

### **Comparar coordenadas absolutas y relativas**

Estos dos objetos de ruta describen la misma trayectoria. El comando absoluto termina en (0.3, 0.1); el comando relativo añade (0.1, 0.1) a la posición actual, (0.2, 0).

Ambas rutas empiezan en la misma posición. Para la línea relativa, sume sus desplazamientos X y Y a la posición actual para obtener el punto final; para la línea absoluta, lea directamente el punto final. Cambiar la bandera sin convertir las coordenadas describiría una ruta diferente.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Asigne cualquiera de las rutas a un comportamiento de movimiento para usarla en una presentación. El argumento booleano final selecciona coordenadas relativas para ese comando.

### **Reemplazar una línea con una curva**

Abra `motion.pptx` y reemplace su comando de línea por una curva cúbica. Proporcione primero los dos puntos de control y, a continuación, el punto final.

La posición inicial la proporciona el comando anterior. Los dos primeros puntos dan forma a la curva, mientras que el tercero es su destino; no son tres destinos sucesivos. Actualizar simultáneamente el tipo de comando, el tipo de edición de puntos y la matriz de puntos mantiene el segmento coherente con su nueva geometría.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

La ruta en `curve.pptx` sigue teniendo tres comandos; su comando intermedio ahora define una curva.

## **Inspeccionar y editar una ruta guardada**

Cada [IMotionCmdPath](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioncmdpath/) expone [Points](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioncmdpath/pointstype/), y [IsRelative](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotioncmdpath/isrelative/). Los siguientes ejemplos usan la ruta conocida de tres comandos en `motion.pptx`. Para entrada arbitraria, localice el efecto deseado y verifique los tipos de comando y la cantidad de puntos antes de editar por índice.

### **Leer comandos y coordenadas**

Lea la ruta sin modificarla. Los comandos de fin y cierre no necesitan puntos, por lo que debe permitir una matriz de puntos nula.

La salida empareja cada comando con su bandera de coordenada relativa antes de enumerar sus puntos. Esto le permite distinguir un punto final de un desplazamiento antes de modificar la ruta. Una curva listaría tres puntos, mientras que la línea recta en este archivo lista solo uno.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

El listado contiene un punto de inicio, una línea absoluta que termina en (0.25, 0) y un comando de fin.

### **Cambiar un punto final**

Abra `motion.pptx` y reemplace la matriz de puntos de la línea para mover su punto final.

En el archivo de entrada, el índice 0 es el comando de inicio y el índice 1 es la línea. Reemplazar el único punto de la línea cambia su destino sin alterar el tipo de comando, la sincronización o la posición en la colección. Como el comando usa coordenadas absolutas, el nuevo par especifica una posición en lugar de un desplazamiento añadido.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

La línea en `motion-endpoint.pptx` termina en (0.4, 0.1); el archivo original permanece sin cambios.

### **Reemplazar un segmento**

Utilice [Insert](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotionpath/insert/) y [RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides.animation/imotionpath/removeat/) para sustituir la línea en `motion.pptx`. Insertar desplaza la línea antigua al índice 2.

Esto demuestra cómo reemplazar un objeto de comando en lugar de editar sus coordenadas existentes. Tras la inserción, la colección contiene temporalmente el comando de inicio, la nueva línea, la línea antigua y el comando de fin. Eliminar el índice 2 descarta la línea antigua y deja la nueva ruta en su lugar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

La ruta guardada sigue teniendo tres comandos, con la nueva línea terminando en (0.2, 0.1) y el comando de fin al final.

## **Modificar y verificar un comportamiento existente**

Cuando se desconoce el índice del comportamiento, selecciónelo por tipo. Este ejemplo abre `rotation.pptx`, encuentra su [IRotationEffect](https://reference.aspose.com/slides/es/net/aspose.slides.animation/irotationeffect/), modifica el ángulo y comprueba el valor guardado después de volver a abrir.

La comprobación de tipo permite que el bucle omita comportamientos que no son rotaciones. La segunda carga lee el archivo guardado en un objeto de presentación separado, de modo que la comparación verifica los datos persistentes en lugar del valor que aún está en memoria. Este ejemplo asume que el efecto conocido es el primero en la secuencia principal; seleccionar un comportamiento por tipo no localiza el efecto correcto en una presentación arbitraria.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

La salida es `Rotation preserved: True`. Aplique el mismo patrón de comprobación de tipo a otros comportamientos. Para una verificación completa de preservación, compare la forma objetivo, el efecto, los tipos y el orden de los comportamientos, la sincronización y los comandos de ruta. Use una tolerancia numérica para valores de punto flotante. Para una presentación con una disposición de animación desconocida, consulte [Read Shape Animations](/slides/es/net/shape-animation/#read-shape-animations) para recorrer secuencias principales e interactivas.

## **Orden de los comportamientos, preajustes y reproducción**

El orden en [IBehaviorCollection](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehaviorcollection/) es el orden almacenado de las operaciones de un efecto. No es una lista de reproducción en la que cada comportamiento espere automáticamente al anterior. La sincronización y el efecto contenedor determinan la programación. Los comportamientos pueden solaparse, y las operaciones sobre la misma propiedad pueden interactuar mediante [Additive](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehavior/additive/) y [Accumulate](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ibehavior/accumulate/). No utilice solo el reordenamiento de la colección para programar “mover, luego rotar”; use sincronización explícita o efectos separados como se describe en [Animación de formas](/slides/es/net/shape-animation/).

El [Type](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/type/) y [Subtype](https://reference.aspose.com/slides/es/net/aspose.slides.animation/ieffect/subtype/) del efecto describen su preset. No son una descripción completa de un árbol de comportamientos editado. Elija el preset y el subtipo antes de personalizar comportamientos: cambiar el preset puede reconstruir la colección y descartar sus operaciones personalizadas. Por ejemplo, cambiar un efecto Spin personalizado a Fade puede reemplazar su comportamiento de rotación con comportamientos set y filter. Inspeccione la colección nuevamente después de cambiar un preset o subtipo. Vaciar los comportamientos del preset también puede eliminar operaciones de visibilidad o inicialización que el preset necesita. Los ejemplos usan deliberadamente formas visibles y sustituyen los comportamientos; no reconstruyen la implementación de cada preset.

## **Compatibilidad de formatos**

Una árbol de comportamientos preservado no garantiza una reproducción idéntica en todos los visualizadores o motores de exportación. Verifique los datos guardados y la salida renderizada por separado.

| Formato o salida | Qué verificar |
| --- | --- |
| PPTX | Úselo como formato principal para estos ejemplos. Vuelva a abrirlo para confirmar el árbol de comportamientos editable y, a continuación, compruebe la reproducción en la versión de PowerPoint prevista. |
| PPT | La representación binaria heredada puede diferir de PPTX. Pruebe un ciclo independiente de guardar‑y‑reabrir y la reproducción; no inferir soporte para cada combinación personalizada a partir de una salida PPTX exitosa. |
| PDF, PNG, JPEG y otras imágenes estáticas de diapositivas | Contienen una representación estática de la diapositiva, no una línea de tiempo de comportamiento reproducible ni un fotograma final de animación garantizado. |
| [HTML5](/slides/es/net/export-to-html5/) | Puede reproducir animaciones compatibles cuando la animación de formas está habilitada en las opciones de exportación. Pruebe combinaciones personalizadas en el navegador. |
| [Animated GIF](/slides/es/net/convert-powerpoint-to-animated-gif/) | Almacena fotogramas renderizados, no comportamientos editables ni interacción activada por clic. Verifique el movimiento renderizado real. |
| [Video](/slides/es/net/convert-powerpoint-to-video/) | Renderiza fotogramas de animación y los codifica como vídeo. El soporte está limitado a las [animaciones y efectos compatibles](/slides/es/net/convert-powerpoint-to-video/#supported-animations-and-effects) del motor; los comandos y eventos interactivos no se convierten en una línea de tiempo editable. |

## **Preguntas frecuentes**

**¿Por qué mi efecto contiene comportamientos antes de que añada alguno?**

Crear un efecto predefinido puede crear sus operaciones subyacentes. Inspecciónelas antes de decidir si ampliar el preset o reemplazar sus comportamientos.

**¿Mover un comportamiento al principio hace que se reproduzca primero?**

No necesariamente. El orden de la colección no sustituye a la sincronización. Revise retrasos, duraciones e interacciones entre operaciones sobre la misma propiedad.

**¿Por qué un comando de fin no tiene puntos?**

Marca el final de la ruta y no necesita coordenadas. Verifique una matriz de puntos nula al inspeccionar una ruta leída de un archivo.

**¿Es suficiente un ciclo de guardado‑y‑reapertura exitoso para confirmar la reproducción?**

No. Reabrir confirma la preservación de las propiedades verificadas. Pruebe el reproductor de diapositivas o la exportación animada por separado para confirmar su comportamiento visual.