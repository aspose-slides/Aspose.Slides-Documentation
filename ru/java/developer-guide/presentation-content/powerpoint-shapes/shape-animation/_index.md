---
title: Применение анимации форм в презентациях с использованием Java
linktitle: Анимация формы
type: docs
weight: 60
url: /ru/java/shape-animation/
keywords:
- форма
- анимация
- эффект
- анимированная форма
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
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, просматривать и настраивать анимацию форм, тайминг, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides для Java."
---
## **Обзор**

Aspose.Slides for Java представляет анимацию слайдов в виде эффектов на временной шкале слайда. Эффект имеет целевую форму, тип и подтип анимации, триггер, настройки тайминга и необязательные свойства, такие как звук или поведение после анимации.

Временная шкала содержит два типа последовательностей:

- **Основная последовательность** воспроизводится при переходе к следующему слайду.
- **Интерактивная последовательность** запускается, когда по её триггерной форме происходит клик.

Поскольку текстовые поля, изображения, диаграммы, таблицы и другие объекты слайда реализуют [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/), вы используете один и тот же метод [ISequence.addEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) для большинства содержимого слайда. Доступные эффекты перечислены в классе [EffectType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effecttype/).

## **Добавление анимации к формам**

Чтобы добавить анимацию, получите основную последовательность слайда и вызовите [ISequence.addEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) с целевой формой, типом эффекта, подтипом и триггером. Для эффекта, который начинается при клике по другой форме, создайте интерактивную последовательность, триггером которой будет эта другая форма.

Следующий пример создаёт обе типы анимации и сохраняет результат в файл `shape-animations.pptx`.

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

Триггер определяет, когда эффект начинается:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effecttriggertype/#OnClick) ждёт клика в основной последовательности или клика по триггерной форме в интерактивной последовательности.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effecttriggertype/#WithPrevious) начинается одновременно с предыдущим эффектом.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effecttriggertype/#AfterPrevious) начинается после завершения предыдущего эффекта.

Чтобы анимировать изображение, диаграмму или другой тип формы, передайте соответствующий объект в [ISequence.addEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) вместо `targetShape`. Для параметров группировки, специфичных для диаграмм, см. раздел [Animated Charts](/slides/ru/java/animated-charts/).

## **Чтение анимации форм**

Используйте [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) когда известна целевая форма. Чтобы просмотреть каждый эффект, перебирайте основную последовательность и все интерактивные последовательности. Перебор позволяет не полагаться на наличие эффекта по индексу `0`.

Следующий пример создаёт форму с эффектами основной и интерактивной последовательностей, получает эффекты, направленные на форму, а затем перебирает каждую последовательность на слайде.

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

Если нужны эффекты только для одной формы, сначала определите форму по имени, типу заполнителя или другому стабильному свойству; затем вызовите [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Не следует предполагать, что [IShapeCollection.get_Item](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#get_Item-int-) с индексом `0` всегда возвращает нужный объект.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать анимацию от соответствующего заполнителя на слайде‑шаблоне и на мастер‑слайде. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getBasePlaceholder--) возвращает родительский заполнитель или `null`, если родителя нет.

В примере презентации нижний колонтитул имеет **Random Bars** на обычном слайде, **Split** на слайде‑шаблоне и **Fly In** на мастер‑слайде.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде‑шаблоне](layout-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на мастер‑слайде](master-shape-animation.png)

Следующий пример использует иерархию заполнителей из новой презентации. Он добавляет эффекты к заполнителю мастера, заполнителю шаблона и соответствующему заполнителю на обычном слайде. Каждый вызов [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getBasePlaceholder--) проверяется перед использованием возвращённой формы.

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

## **Изменение тайминга анимации**

Диалог PowerPoint **Timing** соответствует свойствам [ITiming](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/).

![Диалог Timing в PowerPoint для анимационного эффекта](shape-animation.png)

- **Start** соответствует [ITiming.getTriggerType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** соответствует [ITiming.getDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getDuration--), в секундах.
- **Delay** соответствует [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getTriggerDelayTime--), в секундах.
- **Repeat** соответствует [ITiming.getRepeatCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), или [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** соответствует [ITiming.getRewind](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#getRewind--).

Этот независимый пример добавляет эффект, изменяет его тайминг через объект, возвращённый [ISequence.addEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), и сохраняет результат. Сохранение ссылки на возвращённый [IEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/) избавляет от необходимости использовать индекс коллекции.

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

Используйте один режим повторения намеренно. Комбинация количества повторений с флагом «until» может приводить к непредсказуемым результатам в разных проигрывателях. При изменении режимов повторения сначала вызывайте [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) и [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-), а затем [ITiming.setRepeatCount](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itiming/#setRepeatCount-float-), потому что установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков анимации**

Эффект анимации может ссылаться на встроенный аудиофайл через [IEffect.getSound](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) указывает эффекту остановить звук, запущенный предыдущим эффектом.

### **Добавление звука к эффекту**

Следующий пример ожидает локальный аудиофайл `animation-sound.wav`. Он создаёт два эффекта, встраивает этот файл как звук для первого эффекта и настраивает второй эффект на остановку звука. Для этого используются объекты, возвращённые [ISequence.addEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), поэтому индекс последовательности не требуется.

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

Следующий пример ожидает локальную презентацию `presentation-with-animation-sounds.pptx`. Он сканирует как основную, так и интерактивные последовательности и записывает каждый встроенный звук эффекта в каталог `extracted-animation-sounds`. Расширение выбирается на основе MIME‑типа аудио, получаемого через [IAudio.getContentType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaudio/#getContentType--).

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

Для больших аудио‑объектов используйте [IAudio.getStream](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iaudio/#getStream--) и копируйте поток в файл вместо загрузки всего объекта в массив байтов.

## **Установка поведения после анимации**

Опция **After animation** определяет, что происходит с формой после завершения её эффекта.

![Диалог параметров эффекта PowerPoint, показывающий настройки After animation](shape-after-animation.png)

Класс [AfterAnimationType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/afteranimationtype/) поддерживает варианты: оставить форму без изменений, изменить её цвет, скрыть её после анимации или скрыть её по следующему клику. Когда тип равен [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/java/com.aspose.slides/afteranimationtype/#Color), также задайте [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Этот независимый пример создаёт эффект, задаёт его поведение после анимации через полученный объект эффекта и сохраняет результат.

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

Смена типа с [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/java/com.aspose.slides/afteranimationtype/#Color) очищает настройку цвета после анимации.

## **Анимация текста**

Анимация текста имеет два связанных параметра:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextanimation/#getBuildType--) определяет, появляются ли параграфы одновременно или поочерёдно.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getAnimateTextType--) определяет, появляется ли текст целиком, по словам или по буквам. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) задаёт задержку между словами или буквами. Положительное значение — процент от длительности эффекта; отрицательное — задержка в секундах.

Следующий независимый пример анимирует слова в текстовом поле. [BuildType.AsOneObject](https://reference.aspose.com/slides/ru/java/com.aspose.slides/buildtype/#AsOneObject) отключает построение по параграфам, поэтому настройка слов применяется ко всему текстовому кадру.

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

Чтобы построить текстовое поле по параграфам, установите [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ru/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (или другой уровень параграфа). Чтобы применить отдельный эффект к отдельному параграфу, используйте перегрузку [ISequence.addEffect](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) с параметром [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/). См. раздел [Animated Text](/slides/ru/java/animated-text/) для примеров на уровне параграфов.

## **Экспорт и замечания о совместимости**

- Сохранение в форматы PPT или PPTX сохраняет модель анимации, но окончательное воспроизведение контролируется средством просмотра презентаций.
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/java/export-to-html5/), анимированные GIF или [конвертацию в видео](/slides/ru/java/convert-powerpoint-to-video/), когда необходимо показать движение.
- Для HTML5 включите [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и, при необходимости, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- При рендеринге видео поддерживается множество обычных эффектов входа, акцента, выхода и перемещения, но не каждый эффект PowerPoint поддерживается. Проверьте текущий список [поддерживаемых анимаций и эффектов](/slides/ru/java/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критические презентации с вашей версией Aspose.Slides.
- Сложные пользовательские эффекты и эффекты, импортированные из других форматов презентаций, могут сохраняться в файле, но отображаться иначе в PowerPoint, HTML5 или видео. Проверяйте экспортированный результат, а не только название эффекта.

## **FAQ**

**Почему анимация отображается в PowerPoint, но не в PDF?**

PDF — статический формат, поэтому анимации и переходы слайдов не воспроизводятся. Экспортируйте в HTML5, анимированный GIF или видео, если необходимо сохранить движение.

**Почему эффект воспроизводится иначе в видео?**

Экспорт в видео рендерит анимацию, а не сохраняет оригинальное поведение PowerPoint. Некоторые продвинутые эффекты не поддерживаются или приблизительно имитируются. Ознакомьтесь с таблицей поддерживаемых эффектов и протестируйте презентацию перед производством.

**Изменяет ли перемещение формы вперёд или назад порядок её анимации?**

Нет. Порядок наложения форм (z‑order) контролирует перекрытие, а порядок последовательностей и триггеры управляют воспроизведением анимации. Измените временную шкалу, если требуется иной порядок воспроизведения.