---
title: Animación de Formas
type: docs
weight: 60
url: /es/net/shape-animation/
keywords: 
- animación de PowerPoint
- efecto de animación
- aplicar animación
- presentación de PowerPoint
- C#
- Csharp
- Aspose.Slides para .NET
description: "Aplica animaciones de PowerPoint en C# o .NET"
---

Las animaciones son efectos visuales que se pueden aplicar a textos, imágenes, formas o [gráficos](/slides/es/net/animated-charts/). Dan vida a las presentaciones o a sus componentes.

### **¿Por Qué Usar Animaciones en Presentaciones?**

Utilizando animaciones, puedes 

* controlar el flujo de información
* enfatizar puntos importantes
* aumentar el interés o la participación entre tu audiencia
* hacer que el contenido sea más fácil de leer, asimilar o procesar
* atraer la atención de tus lectores o espectadores hacia partes importantes de una presentación

PowerPoint proporciona muchas opciones y herramientas para animaciones y efectos de animación en las categorías de **entrada**, **salida**, **énfasis** y **trayectorias de movimiento**. 

### **Animaciones en Aspose.Slides**

* Aspose.Slides proporciona las clases y tipos que necesitas para trabajar con animaciones bajo el espacio de nombres [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/),
* Aspose.Slides ofrece más de **150 efectos de animación** bajo la enumeración [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Estos efectos son esencialmente los mismos (o equivalentes) efectos utilizados en PowerPoint.

## **Aplicar Animación a un Cuadro de Texto**

Aspose.Slides para .NET te permite aplicar animación al texto en una forma. 

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una forma rectangular [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Agrega texto al [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. Obtén una secuencia principal de efectos.
6. Agrega un efecto de animación a [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. Establece la propiedad [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) al valor de [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Escribe la presentación en el disco como un archivo PPTX.

Este código C# te muestra cómo aplicar el efecto `Desvanecer` a AutoShape y configurar la animación de texto al valor de *Por párrafos de 1er nivel*:

```c#
// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Agrega una nueva AutoShape con texto
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Primer párrafo \nSegundo párrafo \nTercer párrafo";

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = sld.Timeline.MainSequence;

    // Agrega el efecto de animación Desvanecer a la forma
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima el texto de la forma por párrafos de 1er nivel
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Guarda el archivo PPTX en el disco
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Además de aplicar animaciones al texto, también puedes aplicar animaciones a un solo [Párrafo](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). Consulta [**Texto Animado**](/slides/es/net/animated-text/).

{{% /alert %}} 

## **Aplicar Animación a un Marco de Imagen**

1. Crea una instancia de la clase [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega o obtiene un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) en la diapositiva. 
5. Obtén la secuencia principal de efectos.
6. Agrega un efecto de animación a [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. Escribe la presentación en el disco como un archivo PPTX.

Este código C# te muestra cómo aplicar el efecto `Volador` a un marco de imagen:

```c#
// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation())
{
    // Carga la imagen para agregar en la colección de imágenes de la presentación
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Agrega un marco de imagen a la diapositiva
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Agrega el efecto de animación Volar desde la izquierda al marco de imagen
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Guarda el archivo PPTX en el disco
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Aplicar Animación a Forma**

1. Crea una instancia de la [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) clase.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega una forma rectangular [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Agrega un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) `Bevel` (cuando se hace clic en este objeto, se ejecuta la animación).
5. Crea una secuencia de efectos en la forma de bisel.
6. Crea un `UserPath` personalizado.
7. Agrega comandos para moverse al `UserPath`.
8. Escribe la presentación en el disco como un archivo PPTX.

Este código C# te muestra cómo aplicar el efecto `PathFootball` (camino de fútbol) a una forma:

```c#
// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Crea el efecto PathFootball para una forma existente desde cero.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Cuadro de Texto Animado");

    // Agrega el efecto de animación PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crea una especie de "botón".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crea una secuencia de efectos para el botón.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Crea un camino de usuario personalizado. Nuestro objeto se moverá solo después de hacer clic en el botón.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Agrega comandos para moverse ya que el camino creado está vacío.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Escribe el archivo PPTX en disco
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Obtener los Efectos de Animación Aplicados a una Forma**

Puedes decidir averiguar todos los efectos de animación aplicados a una sola forma. 

Este código C# te muestra cómo obtener todos los efectos aplicados a una forma específica:

```c#
// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Obtiene la primera forma en la diapositiva.
    IShape shape = firstSlide.Shapes[0];

    // Obtiene todos los efectos de animación aplicados a la forma.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine("La forma " + shape.Name + " tiene " + shapeEffects.Length + " efectos de animación.");
}
```

## **Cambiar las Propiedades de Tiempo del Efecto de Animación**

Aspose.Slides para .NET te permite cambiar las propiedades de Tiempo de un efecto de animación.

Este es el panel de Tiempo de Animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas son las correspondencias entre el Tiempo de PowerPoint y las propiedades [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing):
- La lista desplegable de inicio de PowerPoint **Inicio** coincide con la propiedad [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- El **Duración** de PowerPoint coincide con la propiedad [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). La duración de una animación (en segundos) es el tiempo total que tarda la animación en completar un ciclo. 
- El **Retraso** de PowerPoint coincide con la propiedad [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- La lista desplegable de **Repetir** de PowerPoint coincide con estas propiedades: 
  * La propiedad [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) que describe el *número* de veces que se repite el efecto;
  * La bandera [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) que especifica si el efecto se repite hasta el final de la diapositiva;
  * La bandera [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) que especifica si el efecto se repite hasta el siguiente clic.
- La casilla de verificación **Rebobinar al terminar de reproducir** de PowerPoint coincide con la propiedad [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

Así es como cambias las propiedades de Tiempo del Efecto:

1. [Aplica](#apply-animation-to-shape) o obtiene el efecto de animación.
2. Establece nuevos valores para las propiedades [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) que necesitas. 
3. Guarda el archivo PPTX modificado.

Este código C# demuestra la operación:

```c#
// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Obtiene el primer efecto de la secuencia principal.
    IEffect effect = sequence[0];

    // Cambia el TriggerType del efecto para que inicie al hacer clic
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Cambia la duración del efecto
    effect.Timing.Duration = 3f;

    // Cambia el tiempo de retraso del efecto
    effect.Timing.TriggerDelayTime = 0.5f;

    // Si el valor de Repetir del efecto es "ninguno"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Cambia la repetición del efecto a "Hasta el próximo clic"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Cambia la repetición del efecto a "Hasta el final de la diapositiva"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Enciende el rebobinado del efecto
        effect.Timing.Rewind = true;
    
    // Guarda el archivo PPTX en disco
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Sonido del Efecto de Animación**

Aspose.Slides proporciona estas propiedades para permitirte trabajar con sonidos en los efectos de animación: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Agregar Sonido al Efecto de Animación**

Este código C# te muestra cómo agregar un sonido al efecto de animación y detenerlo cuando comienza el siguiente efecto:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Agrega audio a la colección de audio de la presentación
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Obtiene la secuencia principal de la diapositiva.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Obtiene el primer efecto de la secuencia principal
	IEffect firstEffect = sequence[0];

	// Verifica el efecto para "Sin sonido"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Agrega sonido para el primer efecto
		firstEffect.Sound = effectSound;
	}

	// Obtiene la primera secuencia interactiva de la diapositiva.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Establece la bandera de efecto "Detener sonido previo"
	interactiveSequence[0].StopPreviousSound = true;

	// Escribe el archivo PPTX en disco
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extraer Sonido del Efecto de Animación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Obtén la secuencia principal de efectos. 
4. Extrae el [Sonido](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) incrustado en cada efecto de animación. 

Este código C# te muestra cómo extraer el sonido incrustado en un efecto de animación:

```c#
// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtiene la secuencia principal de la diapositiva.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrae el sonido del efecto en un array de bytes
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Después de la Animación**

Aspose.Slides para .NET te permite cambiar la propiedad Después de la animación de un efecto de animación.

Este es el panel de Efecto de Animación y el menú extendido en Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

La lista desplegable de Efecto **Después de la animación** de PowerPoint coincide con estas propiedades: 

- La propiedad [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) que describe el tipo de animación después de la animación :
  * **Más colores** de PowerPoint coincide con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * La opción **No atenuar** de PowerPoint coincide con el tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (tipo de animación después por defecto);
  * La opción **Ocultar después de la animación** coincide con el tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * La opción **Ocultar en el siguiente clic del mouse** coincide con el tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
- La propiedad [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) que define un formato de color para después de la animación. Esta propiedad funciona en conjunto con el tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). Si cambias el tipo a otro, el color de la animación después se borrará.

Este código C# te muestra cómo cambiar un efecto después de la animación:

```c#
// Instancia una clase de presentación que representa un archivo de presentación
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Cambia el tipo de animación después a Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Establece el color de atenuación después de la animación
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Escribe el archivo PPTX en disco
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animar Texto**

Aspose.Slides proporciona estas propiedades para permitirte trabajar con el bloque *Animar texto* de un efecto de animación:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) que describe un tipo de texto animado del efecto. El texto de la forma puede ser animado:
  - Todo de una vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) tipo)
  - Por palabra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) tipo)
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) tipo)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) establece un retraso entre las partes de texto animadas (palabras o letras). Un valor positivo especifica el porcentaje de duración del efecto. Un valor negativo especifica el retraso en segundos.

Así es como puedes cambiar las propiedades de Animar texto del Efecto:

1. [Aplica](#apply-animation-to-shape) o obtiene el efecto de animación.
2. Establece la propiedad [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) a un valor [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) para desactivar el modo de animación *Por párrafos*.
3. Establece nuevos valores para las propiedades [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) y [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Guarda el archivo PPTX modificado.

Este código C# demuestra la operación:

```c#
// Instancia una clase de presentación que representa un archivo de presentación.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Obtiene el primer efecto de la secuencia principal
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Cambia el tipo de animación de texto del efecto a "Como un objeto"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Cambia el tipo de texto a animar del efecto a "Por palabra"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Establece el retraso entre palabras al 20% de la duración del efecto
    firstEffect.DelayBetweenTextParts = 20f;

    // Escribe el archivo PPTX en disco
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```