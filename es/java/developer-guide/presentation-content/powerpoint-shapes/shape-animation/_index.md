---
title: Aplicar animaciones de forma en presentaciones usando Java
linktitle: Animación de forma
type: docs
weight: 60
url: /es/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Aprenda cómo añadir, inspeccionar y personalizar animaciones de forma, temporización, sonidos, comportamiento después de la animación y texto animado con Aspose.Slides para Java."
---
## **Visión general**

Aspose.Slides for Java representa las animaciones de diapositiva como efectos en una línea de tiempo de la diapositiva. Un efecto tiene una forma objetivo, un tipo y subtipo de animación, un disparador, ajustes de temporización y propiedades opcionales como sonido o comportamiento después de la animación.

La línea de tiempo contiene dos tipos de secuencias:

- La **secuencia principal** se reproduce al avanzar la diapositiva.  
- Una **secuencia interactiva** comienza cuando se hace clic en su forma disparadora.

Debido a que los cuadros de texto, imágenes, gráficos, tablas y otros objetos de diapositiva implementan [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/), se utiliza el mismo método [ISequence.addEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) para la mayor parte del contenido de la diapositiva. Los efectos disponibles se enumeran en la clase [EffectType](https://reference.aspose.com/slides/es/java/com.aspose.slides/effecttype/).

## **Añadir animaciones a formas**

Para añadir una animación, obtenga la secuencia principal de la diapositiva y llame a [ISequence.addEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) con la forma objetivo, el tipo de efecto, el subtipo y el disparador. Para un efecto que comienza cuando se hace clic en otra forma, cree una secuencia interactiva cuyo disparador sea esa otra forma.

El siguiente ejemplo crea ambos tipos de animación y guarda el resultado en `shape-animations.pptx`.

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

El disparador controla cuándo comienza un efecto:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/es/java/com.aspose.slides/effecttriggertype/#OnClick) espera a un clic en la secuencia principal, o a un clic en la forma disparadora en una secuencia interactiva.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/es/java/com.aspose.slides/effecttriggertype/#WithPrevious) comienza con el efecto anterior.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/es/java/com.aspose.slides/effecttriggertype/#AfterPrevious) comienza cuando termina el efecto anterior.

Para animar una imagen, un gráfico u otro tipo de forma, pase ese objeto a [ISequence.addEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) en lugar de `targetShape`. Para opciones de agrupación específicas de gráficos, consulte [Gráficos animados](/slides/es/java/animated-charts/).

## **Leer animaciones de formas**

Utilice [ISequence.getEffectsByShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) cuando conozca la forma objetivo. Para inspeccionar cada efecto, recorra la secuencia principal y cada secuencia interactiva. Recorrer evita asumir que una secuencia contiene un efecto en el índice `0`.

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

Si solo necesita los efectos para una forma, primero identifique la forma por nombre, tipo de marcador de posición u otra propiedad estable; luego llame a [ISequence.getEffectsByShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). No asuma que [IShapeCollection.get_Item](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#get_Item-int-) en el índice `0` sea siempre el objeto deseado.

## **Trabajar con efectos de marcadores de posición heredados**

Un marcador de posición en una diapositiva normal puede heredar el comportamiento de animación del marcador de posición correspondiente en su diapositiva de diseño y en la diapositiva maestra. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getBasePlaceholder--) devuelve ese marcador de posición padre, o `null` cuando no existe padre.

En la presentación de ejemplo siguiente, el pie de página tiene **Random Bars** en la diapositiva normal, **Split** en la diapositiva de diseño y **Fly In** en la diapositiva maestra.

![Efecto de animación del pie de página en la diapositiva normal](slide-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva de diseño](layout-shape-animation.png)

![Efecto de animación del marcador de posición del pie de página en la diapositiva maestra](master-shape-animation.png)

El siguiente ejemplo utiliza una jerarquía de marcadores de posición de una nueva presentación. Añade efectos a un marcador de posición maestro, a un marcador de posición de diseño y al marcador de posición correspondiente en una diapositiva normal. Cada llamada a [IShape.getBasePlaceholder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getBasePlaceholder--) se verifica antes de usar la forma devuelta.

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **Cambiar la temporización de la animación**

El cuadro de diálogo **Timing** de PowerPoint se corresponde con las propiedades de [ITiming](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/).

![Diálogo de temporización de PowerPoint para un efecto de animación](shape-animation.png)

- **Start** se corresponde con [ITiming.getTriggerType](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getTriggerType--).  
- **Duration** se corresponde con [ITiming.getDuration](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getDuration--), en segundos.  
- **Delay** se corresponde con [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getTriggerDelayTime--), en segundos.  
- **Repeat** se corresponde con [ITiming.getRepeatCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), o [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).  
- **Rewind when done playing** se corresponde con [ITiming.getRewind](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#getRewind--).

Este ejemplo independiente añade un efecto, cambia su temporización mediante el objeto devuelto por [ISequence.addEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), y guarda el resultado. Mantener la referencia devuelta de [IEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/) evita un índice de colección innecesario.

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Utilice un solo modo de repetición de manera intencionada. Combinar un recuento de repeticiones con una bandera “hasta” puede producir resultados confusos en diferentes visores. Al cambiar los modos de repetición, establezca [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) y [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) antes de [ITiming.setRepeatCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/itiming/#setRepeatCount-float-), porque activar cualquiera de esas banderas también cambia el modo de repetición activo.

## **Agregar y extraer sonidos de animación**

Un efecto de animación puede referenciar audio incrustado mediante [IEffect.getSound](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) indica a un efecto que detenga el audio iniciado por un efecto anterior.

### **Añadir un sonido a un efecto**

El siguiente ejemplo supone que existe un archivo de audio local llamado `animation-sound.wav`. Crea dos efectos, incrusta ese archivo como sonido del primer efecto y configura el segundo efecto para que detenga el sonido. Utiliza los objetos devueltos por [ISequence.addEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), por lo que no se requiere un índice de secuencia.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **Extraer sonidos incrustados en los efectos**

El siguiente ejemplo supone que existe una presentación local llamada `presentation-with-animation-sounds.pptx`. Analiza tanto las secuencias principales como las interactivas y escribe cada sonido de efecto incrustado en el directorio `extracted-animation-sounds`. La extensión se selecciona a partir del tipo MIME de audio expuesto por [IAudio.getContentType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaudio/#getContentType--).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

Para objetos de audio grandes, utilice [IAudio.getStream](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaudio/#getStream--) y copie el flujo a un archivo en lugar de cargar todo el objeto en una matriz de bytes.

## **Establecer el comportamiento después de la animación**

La opción **After animation** controla qué ocurre con una forma después de que su efecto finaliza.

![Diálogo de opciones de efecto de PowerPoint que muestra la configuración Después de la animación](shape-after-animation.png)

La clase [AfterAnimationType](https://reference.aspose.com/slides/es/java/com.aspose.slides/afteranimationtype/) permite dejar la forma sin cambios, cambiar su color, ocultarla después de la animación o ocultarla en el siguiente clic. Cuando el tipo es [AfterAnimationType.Color](https://reference.aspose.com/slides/es/java/com.aspose.slides/afteranimationtype/#Color), también establezca [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Este ejemplo independiente crea un efecto, establece su comportamiento después de la animación mediante el objeto de efecto devuelto y guarda el resultado.

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Cambiar el tipo fuera de [AfterAnimationType.Color] borra la configuración del color después de la animación.

## **Animar texto**

La animación de texto tiene dos controles relacionados:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextanimation/#getBuildType--) controla si los párrafos aparecen juntos o por nivel de párrafo.  
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getAnimateTextType--) controla si el texto aparece todo a la vez, por palabra o por letra. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/es/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) establece el retraso entre palabras o letras. Un valor positivo es un porcentaje de la duración del efecto; un valor negativo es un retraso en segundos.

El siguiente ejemplo independiente anima las palabras en un cuadro de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/es/java/com.aspose.slides/buildtype/#AsOneObject) desactiva la construcción párrafo a párrafo para que la configuración de palabras se aplique a todo el marco de texto.

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Para construir un cuadro de texto por párrafo, establezca [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/es/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (u otro nivel de párrafo). Para dirigirse a un solo párrafo con su propio efecto, utilice la sobrecarga de [ISequence.addEffect](https://reference.aspose.com/slides/es/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) que acepta un [IParagraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/). Consulte [Texto animado](/slides/es/java/animated-text/) para ejemplos a nivel de párrafo.

## **Notas de exportación y compatibilidad**

- Guardar en PPT o PPTX preserva el modelo de animación, pero la reproducción final está controlada por el visor de presentaciones.  
- PDF e imágenes estáticas no reproducen animaciones. Utilice [exportación a HTML5](/slides/es/java/export-to-html5/), GIF animado o [conversión a vídeo](/slides/es/java/convert-powerpoint-to-video/) cuando la salida deba mostrar movimiento.  
- Para HTML5, habilite [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) y, cuando sea necesario, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/es/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).  
- La renderización de vídeo admite muchos efectos comunes de entrada, énfasis, salida y trayectorias de movimiento, pero no todos los efectos de PowerPoint están soportados. Consulte la tabla actual de [animaciones y efectos soportados](/slides/es/java/convert-powerpoint-to-video/#supported-animations-and-effects) y pruebe presentaciones críticas con la versión de Aspose.Slides que vaya a usar.  
- Los efectos personalizados avanzados y los efectos importados de otros formatos pueden preservarse en el archivo pero mostrarse de manera diferente en PowerPoint, HTML5 o vídeo. Valide el resultado exportado en lugar de confiar únicamente en el nombre del efecto.

## **Preguntas frecuentes**

**¿Por qué una animación aparece en PowerPoint pero no en un PDF?**

PDF es un formato estático, por lo que las animaciones y transiciones de diapositiva no se reproducen. Exporte a HTML5, GIF animado o vídeo cuando sea necesario conservar el movimiento.

**¿Por qué un efecto se reproduce de forma distinta en un vídeo?**

La exportación a vídeo renderiza las animaciones en lugar de almacenar el comportamiento original de PowerPoint. Algunos efectos avanzados no están soportados o se aproximan. Revise la tabla de efectos soportados y pruebe la presentación real antes de su uso en producción.

**¿Mover una forma hacia delante o hacia atrás cambia su orden de animación?**

No. El orden Z de la forma controla la superposición, mientras que el orden de la secuencia y los disparadores controlan la reproducción de la animación. Cambie la línea de tiempo si necesita un orden de reproducción diferente.