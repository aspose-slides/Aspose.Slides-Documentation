---
title: Применить анимацию форм в презентациях на Android
linktitle: Анимация формы
type: docs
weight: 60
url: /ru/androidjava/shape-animation/
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
- звуковой эффект
- применить анимацию
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, просматривать и настраивать анимацию форм, тайминг, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides for Android через Java."
---
## **Обзор**

Для работы с отдельными поведениями внутри эффекта или редактирования сегментов траектории движения, см. [Пользовательская анимация для Java](/slides/ru/java/custom-animation/).

Aspose.Slides for Android via Java представляет анимацию слайдов в виде эффектов на временной шкале слайда. Эффект имеет целевую форму, тип и подтип анимации, триггер, параметры тайминга и необязательные свойства, такие как звук или поведение после анимации.

Временная шкала содержит два типа последовательностей:

- **Основная последовательность** воспроизводится при переходе слайда.
- **Интерактивная последовательность** начинается, когда по её триггерной форме производится клик.

Поскольку текстовые поля, изображения, диаграммы, таблицы и другие объекты слайда реализуют [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), вы используете один и тот же метод [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) для большинства содержимого слайда. Доступные эффекты перечислены в классе [EffectType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttype/).

## **Добавление анимации форм**

Чтобы добавить анимацию, получите основную последовательность слайда и вызовите [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) с целевой формой, типом эффекта, подтипом и триггером. Для эффекта, который начинается при клике по другой форме, создайте интерактивную последовательность, триггером которой будет эта другая форма.

Следующий пример создаёт оба типа анимации и сохраняет результат в `shape-animations.pptx`.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttriggertype/#OnClick) ожидает клик в основной последовательности или клик по триггерной форме в интерактивной последовательности.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) начинается одновременно с предыдущим эффектом.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) начинается после завершения предыдущего эффекта.

Чтобы анимировать изображение, диаграмму или другой тип формы, передайте этот объект в [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) вместо `targetShape`. Для параметров группировки, специфичных для диаграмм, см. [Animated Charts](/slides/ru/androidjava/animated-charts/).

## **Чтение анимации форм**

Используйте [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) когда известна целевая форма. Чтобы просмотреть каждый эффект, перечислите основную последовательность и все интерактивные последовательности. Перебор избегает предположения, что в последовательности есть эффект по индексу `0`.

Следующий пример создаёт форму с эффектами основной и интерактивной последовательностей, получает эффекты, направленные на форму, а затем перечисляет каждую последовательность на слайде.

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

Если нужны эффекты только для одной формы, сначала определите форму по имени, типу заполнителя или другому устойчивому свойству; затем вызовите [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Не следует предполагать, что [IShapeCollection.get_Item](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) по индексу `0` всегда является требуемым объектом.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать анимационное поведение от соответствующего заполнителя на слайде макета и мастер‑слайде. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) возвращает этот родительский заполнитель или `null`, если родитель не существует.

В следующей демонстрационной презентации нижний колонтитул имеет **Random Bars** на обычном слайде, **Split** на слайде макета и **Fly In** на мастер‑слайде.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде макета](layout-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на главном слайде](master-shape-animation.png)

Следующий пример использует иерархию заполнителей из новой презентации. Он добавляет эффекты к заполняющему мастер‑заполнителю, к заполнителю макета и к соответствующему заполнителю на обычном слайде. Каждый вызов [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) проверяется перед использованием возвращённой формы.

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

Диалоговое окно PowerPoint **Timing** сопоставляется со свойствами [ITiming](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/).

![Диалоговое окно PowerPoint «Тайминг» для анимационного эффекта](shape-animation.png)

- **Запуск** сопоставляется с [ITiming.getTriggerType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Продолжительность** сопоставляется с [ITiming.getDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getDuration--), в секундах.
- **Задержка** сопоставляется с [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), в секундах.
- **Повтор** сопоставляется с [ITiming.getRepeatCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), или [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Перемотать после завершения** сопоставляется с [ITiming.getRewind](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#getRewind--).

Этот независимый пример добавляет эффект, изменяет его тайминг через объект, возвращённый [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), и сохраняет результат. Хранение ссылки на возвращённый [IEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/) предотвращает необходимость обращения к индексу коллекции.

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

Используйте один режим повторения преднамеренно. Комбинация количества повторов с флагом «until» может приводить к непредсказуемым результатам в разных проигрывателях. При смене режимов повторения сначала вызывайте [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) и [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) до вызова [ITiming.setRepeatCount](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), так как установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков анимации**

Анимационный эффект может ссылаться на встроенный аудио‑файл через [IEffect.getSound](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) указывает эффекту остановить звук, начатый предыдущим эффектом.

### **Добавить звук к эффекту**

Следующий пример ожидает локальный аудиофайл с именем `animation-sound.wav`. Он создает два эффекта, встраивает этот файл как звук для первого эффекта и настраивает второй эффект на остановку звука. Он использует объекты, возвращённые [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), поэтому индекс последовательности не требуется.

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

### **Извлечь встроенные звуки эффектов**

Следующий пример ожидает локальную презентацию с именем `presentation-with-animation-sounds.pptx`. Он просматривает как основную, так и интерактивную последовательности и записывает каждый встроенный звуковой файл эффекта в каталог `extracted-animation-sounds`. Расширение выбирается исходя из MIME‑типа аудио, предоставляемого [IAudio.getContentType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudio/#getContentType--).

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

Параметр **After animation** управляет тем, что происходит с формой после завершения её эффекта.

![Диалоговое окно PowerPoint «Опции эффекта», показывающее настройки «After animation»](shape-after-animation.png)

Класс [AfterAnimationType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/) поддерживает оставление формы без изменений, изменение её цвета, скрытие после анимации или скрытие при следующем клике. Когда тип равен [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#Color), также задавайте [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Этот независимый пример создаёт эффект, задаёт его поведение после анимации через возвращённый объект эффекта и сохраняет результат.

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

Изменение типа от [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#Color) сбрасывает настройку цвета после анимации.

## **Анимация текста**

Анимацию текста контролируют два связанных параметра:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextanimation/#getBuildType--) определяет, появляются ли абзацы вместе или последовательно по уровням абзацев.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) определяет, отображается ли текст сразу полностью, по словам или по буквам. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) задаёт задержку между словами или буквами. Положительное значение — процент от длительности эффекта; отрицательное — задержка в секундах.

Следующий независимый пример анимирует слова в текстовом поле. [BuildType.AsOneObject](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/buildtype/#AsOneObject) отключает построение по абзацам, поэтому настройка слова применяется к всему текстовому кадру.

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

Чтобы построить текстовое поле по абзацам, задайте [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (или иной уровень абзаца). Чтобы применить отдельный эффект к конкретному абзацу, используйте перегрузку [ISequence.addEffect](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) с параметром [IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/). См. [Animated Text](/slides/ru/androidjava/animated-text/) для примеров на уровне абзацев.

## **Экспорт и примечания о совместимости**

- Сохранение в PPT или PPTX сохраняет модель анимации, но окончательное воспроизведение контролируется проигрывателем презентаций.
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/androidjava/export-to-html5/), анимированные GIF или [video conversion](/slides/ru/androidjava/convert-powerpoint-to-video/), когда необходимо показать движение.
- Для HTML5 включите [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и при необходимости [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Видеорендеринг поддерживает многие распространённые эффекты появления, акцентирования, выхода и движения по траектории, но не каждый эффект PowerPoint поддерживается. Проверьте текущий список [supported animations and effects](/slides/ru/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критические презентации с выбранной версией Aspose.Slides.
- Продвинутые пользовательские эффекты и эффекты, импортированные из других форматов презентаций, могут сохраняться в файле, но отображаться иначе в PowerPoint, HTML5 или видео. Проверяйте экспортированный результат, а не только название эффекта.

## **FAQ**

**Почему анимация отображается в PowerPoint, но не в PDF?**

PDF — статический формат, поэтому анимация и переходы слайдов не воспроизводятся. Экспортируйте в HTML5, анимированный GIF или видео, когда необходимо сохранить движение.

**Почему эффект воспроизводится по‑другому в видео?**

Экспорт в видео рендерит анимацию, а не сохраняет исходное поведение PowerPoint. Некоторые сложные эффекты не поддерживаются или приближенно реализуются. Ознакомьтесь с таблицей поддерживаемых эффектов и протестируйте презентацию перед использованием в производстве.

**Изменяет ли перемещение формы вперёд или назад порядок её анимации?**

Нет. Порядок наложения форм определяет их перекрытие, а порядок последовательности и триггеры управляют воспроизведением анимации. Меняйте временную шкалу, если нужен иной порядок воспроизведения.