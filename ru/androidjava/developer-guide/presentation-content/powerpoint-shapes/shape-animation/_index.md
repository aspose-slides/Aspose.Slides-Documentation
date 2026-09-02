---
title: Применение анимаций фигур в презентациях на Android
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/androidjava/shape-animation/
keywords:
- фигура
- анимация
- эффект
- анимированная фигура
- анимированный текст
- добавить анимацию
- получить анимацию
- извлечь анимацию
- добавить эффект
- получить эффект
- извлечь эффект
- звук эффекта
- применить анимацию
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, просматривать и настраивать анимацию фигур, тайминг, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Aspose.Slides for Android via Java представляет анимацию слайдов в виде эффектов на временной шкале слайда. Эффект имеет целевую фигуру, тип и подтип анимации, триггер, настройки времени и необязательные свойства, такие как звук или поведение после анимации.

Временная шкала содержит два типа последовательностей:

- **Главная последовательность** воспроизводится при переходе к следующему слайду.
- **Интерактивная последовательность** начинается, когда кликают по её триггерной фигуре.

Поскольку текстовые блоки, изображения, диаграммы, таблицы и другие объекты слайда реализуют [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), вы используете один и тот же метод [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) для большинства содержимого слайда. Доступные эффекты перечислены в классе [EffectType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttype/).

## **Добавление анимаций фигур**

Чтобы добавить анимацию, получите главную последовательность слайда и вызовите [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) с целевой фигурой, типом эффекта, подтипом и триггером. Для эффекта, который начинается при щелчке по другой фигуре, создайте интерактивную последовательность, триггером которой будет эта другая фигура.

Следующий пример создаёт обе разновидности анимаций и сохраняет результат в файл `shape-animations.pptx`.

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

Триггер определяет, когда начинается эффект:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttriggertype/#OnClick) ждёт щелчка в главной последовательности или щелчка по триггерной фигуре в интерактивной последовательности.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) начинается одновременно с предыдущим эффектом.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) начинается после завершения предыдущего эффекта.

Чтобы анимировать картинку, диаграмму или другую фигуру, передайте этот объект в [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) вместо `targetShape`. Параметры группировки, специфичные для диаграмм, смотрите в разделе [Animated Charts](/slides/ru/androidjava/animated-charts/).

## **Чтение анимаций фигур**

Используйте [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) когда известна целевая фигура. Чтобы просмотреть каждый эффект, переберите главную последовательность и все интерактивные последовательности. Перебор избавляет от предположения, что в последовательности есть эффект с индексом `0`.

Следующий пример создаёт фигуру с эффектами главной и интерактивной последовательностей, получает эффекты, направленные на эту фигуру, а затем перебирает все последовательности на слайде.

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

Если нужны эффекты только для одной фигуры, сначала определите её по имени, типу заполнителя или другому стабильному свойству; затем вызовите [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Не предполагаете, что [IShapeCollection.get_Item](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) с индексом `0` всегда является нужным объектом.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать анимационное поведение от соответствующего заполнителя на макете слайда и на слайде‑шаблоне. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) возвращает родительский заполнитель или `null`, если родитель отсутствует.

В примере презентации нижний колонтитул имеет **Random Bars** на обычном слайде, **Split** на слайде‑макете и **Fly In** на слайде‑шаблоне.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде‑макете](layout-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде‑шаблоне](master-shape-animation.png)

Следующий пример использует иерархию заполнителей из новой презентации. Он добавляет эффекты к заполнителю шаблона, заполнителю макета и соответствующему заполнителю на обычном слайде. Каждый вызов [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) проверяется перед использованием возвращённой фигуры.

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

## **Изменение времени анимации**

Диалог PowerPoint **Timing** соответствует свойствам [ITiming](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/).

![Диалог Timing в PowerPoint для эффекта анимации](shape-animation.png)

- **Start** соответствует [ITiming.getTriggerType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** соответствует [ITiming.getDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getDuration--), в секундах.
- **Delay** соответствует [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), в секундах.
- **Repeat** соответствует [ITiming.getRepeatCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), или [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** соответствует [ITiming.getRewind](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRewind--).

Этот отдельный пример добавляет эффект, меняет его время через объект, возвращённый [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), и сохраняет результат. Хранение ссылки на возвращённый [IEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/) избавляет от необходимости обращаться к индексу коллекции.

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

Используйте один режим повторения намеренно. Сочетание количества повторений с флагом «until» может приводить к запутанным результатам в разных средствах просмотра. При изменении режимов повторения сначала вызывайте [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) и [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-), а затем [ITiming.setRepeatCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), потому что установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков эффектов**

Эффект анимации может ссылаться на встроенный аудиофайл через [IEffect.getSound](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) указывает эффекту останавливать звук, начатый более ранним эффектом.

### **Добавление звука к эффекту**

Следующий пример ожидает локальный аудиофайл `animation-sound.wav`. Он создаёт два эффекта, встраивает этот файл как звук первого эффекта и настраивает второй эффект на остановку звука. Используются объекты, возвращённые [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), поэтому индекс последовательности не требуется.

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

### **Извлечение встроенных звуков эффектов**

Следующий пример ожидает локальную презентацию `presentation-with-animation-sounds.pptx`. Он просматривает как главные, так и интерактивные последовательности и записывает каждый встроенный звук эффекта в каталог `extracted-animation-sounds`. Расширение выбирается из MIME‑типа аудио, получаемого через [IAudio.getContentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudio/#getContentType--).

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

Для больших аудио‑объектов используйте [IAudio.getStream](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudio/#getStream--) и копируйте поток в файл вместо загрузки всего объекта в массив байтов.

## **Установка поведения после анимации**

Опция **After animation** определяет, что происходит с фигурой после завершения её эффекта.

![Диалог параметров эффекта PowerPoint, показывающий настройки After animation](shape-after-animation.png)

Класс [AfterAnimationType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/) поддерживает оставление фигуры без изменений, изменение её цвета, скрытие после анимации или скрытие при следующем щелчке. Когда тип установлен в [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#Color), также задайте [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Этот отдельный пример создаёт эффект, задаёт его поведение после анимации через полученный объект эффекта и сохраняет результат.

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Изменение типа от [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#Color) очищает настройку цвета после анимации.

## **Анимация текста**

Анимация текста имеет два связанных параметра:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextanimation/#getBuildType--) определяет, появляются ли абзацы одновременно или по отдельным абзацам.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) определяет, появляется ли текст сразу, по словам или по буквам. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) задаёт задержку между словами или буквами. Положительное значение — процент от длительности эффекта; отрицательное значение — задержка в секундах.

Следующий отдельный пример анимирует слова в текстовом поле. [BuildType.AsOneObject](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/buildtype/#AsOneObject) отключает постройку по абзацам, поэтому настройка слова применяется ко всему текстовому фрейму.

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

Для построения текстового поля по абзацам установите [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (или другой уровень абзаца). Чтобы направить отдельный абзац с собственным эффектом, используйте перегрузку [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) принимающую [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/). См. раздел [Animated Text](/slides/ru/androidjava/animated-text/) для примеров на уровне абзацев.

## **Экспорт и примечания о совместимости**

- Сохранение в PPT или PPTX сохраняет модель анимации, но окончательное воспроизведение контролируется средством просмотра презентаций.
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/androidjava/export-to-html5/), анимированный GIF или [конвертацию в видео](/slides/ru/androidjava/convert-powerpoint-to-video/) когда необходимо показать движение.
- Для HTML5 включите [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и при необходимости [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- При рендеринге видео поддерживаются многие обычные эффекты появления, акцентирования, выхода и движения, но не каждый эффект PowerPoint поддерживается. Проверьте текущий список [поддерживаемых анимаций и эффектов](/slides/ru/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критические презентации с вашей целевой версией Aspose.Slides.
- Пользовательские сложные эффекты и эффекты, импортированные из других форматов презентаций, могут сохраняться в файле, но отображаться иначе в PowerPoint, HTML5 или видео. Проверяйте экспортированный результат, а не полагайтесь только на имя эффекта.

## **FAQ**

**Почему анимация отображается в PowerPoint, но не в PDF?**

PDF — статический формат, поэтому анимации и переходы слайдов не воспроизводятся. При необходимости сохраняйте движение, экспортируя в HTML5, анимированный GIF или видео.

**Почему эффект воспроизводится иначе в видео?**

Экспорт в видео рендерит анимацию, а не сохраняет оригинальное поведение PowerPoint. Некоторые продвинутые эффекты не поддерживаются или аппроксимируются. Ознакомьтесь с таблицей поддерживаемых эффектов и протестируйте презентацию перед использованием в продакшене.

**Изменит ли перемещение фигуры вперёд или назад её порядок анимации?**

Нет. Порядок наложения фигур (z‑order) управляет их перекрытием, тогда как порядок последовательностей и триггеры управляют воспроизведением анимации. Измените временную шкалу, если требуется иной порядок воспроизведения.