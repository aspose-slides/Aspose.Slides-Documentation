---
title: Применение анимаций фигур в презентациях с использованием Java
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint с помощью Aspose.Slides для Java. Выделяйтесь!"
---
## **Введение**

Анимации — это визуальные эффекты, которые могут применяться к тексту, изображениям, фигурам или [диаграммам](https://docs.aspose.com/slides/ru/java/animated-charts/). Они оживляют презентации и их составные части. 

## **Почему использовать анимацию в презентациях?**

* контролировать поток информации
* выделять важные пункты
* повышать интерес или вовлечённость аудитории
* делать контент более лёгким для чтения, усвоения или обработки
* привлекать внимание читателей или зрителей к важным частям в презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **entrance**, **exit**, **emphasis** и **motion paths**. 

## **Анимация в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имён `Aspose.Slides.Animation`,
* Aspose.Slides предоставляет более **150 эффектов анимации** в перечислении [EffectType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effecttype). Эти эффекты по сути те же (или эквивалентные) эффекты, что используются в PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides для Java позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape).
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Получите основную последовательность эффектов.
6. Добавьте эффект анимации к [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape).
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код Java демонстрирует, как применить эффект `Fade` к AutoShape и установить анимацию текста со значением *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Создаёт объект презентации, представляющий файл презентации.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет новую AutoShape с текстом
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Получает основную последовательность слайда.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Добавляет эффект анимации Fade к фигуре
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Анимирует текст фигуры по абзацам первого уровня
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Сохраняет файл PPTX на диск
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 
Помимо применения анимации к тексту, вы также можете применять анимацию к отдельному [Paragraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph). Смотрите [**Animated Text**](/slides/ru/java/animated-text/).
{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe) на слайде. 
4. Получите основную последовательность эффектов.
5. Добавьте эффект анимации к [PictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pictureframe).
6. Запишите презентацию на диск в виде файла PPTX.

Этот код Java демонстрирует, как применить эффект `Fly` к рамке изображения:

```java
import com.aspose.slides.*;

// Создаёт объект класса презентации, представляющий файл презентации.
Presentation pres = new Presentation();
try {
    // Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Добавляет рамку изображения на слайд
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Получает основную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Добавляет эффект анимации Fly слева к рамке изображения
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Применить анимацию к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape). 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iautoshape) (когда этот объект будет щёлкнут, анимация запускается).
5. Создайте последовательность эффектов для формы bevel.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды перемещения к `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код Java демонстрирует, как применить эффект `PathFootball` (path football) к фигуре:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Создаёт объект класса Presentation, представляющий файл PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Создаёт эффект PathFootball для существующей фигуры с нуля.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Добавляет анимационный эффект PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Создаёт некую "кнопку".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создаёт последовательность эффектов для этой кнопки.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Создаёт пользовательский путь. Наш объект будет перемещён только после нажатия кнопки.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Добавляет команды перемещения, так как созданный путь пуст.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Записывает файл PPTX на диск
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получить эффекты анимации, применённые к Shape**

В следующих примерах показано, как использовать метод `getEffectsByShape` из интерфейса [ISequence](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isequence/) для получения всех эффектов анимации, применённых к фигуре.

**Пример 1: Получить эффекты анимации, применённые к фигуре на обычном слайде**

Ранее вы изучали, как добавлять эффекты анимации к фигурам в презентациях PowerPoint. Следующий пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде в презентации `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Получает основную последовательность анимации слайда.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Получает первую фигуру на первом слайде.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Получает эффекты анимации, применённые к фигуре.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Пример 2: Получить все эффекты анимации, включая унаследованные от заполнителей**

Если у формы на обычном слайде есть заполнители, находящиеся на слайде макета и/или мастер‑слайде, и к этим заполнителям добавлены эффекты анимации, то все эффекты формы будут воспроизводиться во время показа слайдов, включая унаследованные от заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только форму нижнего колонтитула с текстом «Made with Aspose.Slides», к которой применён эффект **Random Bars**.

![Эффект анимации формы слайда](slide-shape-animation.png)

Также предположим, что к заполнителю нижнего колонтитула на слайде **layout** применён эффект **Split**.

![Эффект анимации формы макета](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **master** слайде применён эффект **Fly In**.

![Эффект анимации формы мастера](master-shape-animation.png)

Следующий пример кода показывает, как использовать метод `getBasePlaceholder` из интерфейса [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) для получения доступа к заполнителям формы и получения эффектов анимации, применённых к форме нижнего колонтитула, включая унаследованные от заполнителей, расположенных на слайдах макета и мастера.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Получить эффекты анимации фигуры на обычном слайде.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Получить эффекты анимации заполнителя на слайде макета.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Получить эффекты анимации заполнителя на мастер‑слайде.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Вывод:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Изменить свойства тайминга эффекта анимации**

Aspose.Slides для Java позволяет изменять свойства Timing (времени) анимационного эффекта.

![Панель настройки времени анимации в Microsoft PowerPoint](shape-animation.png)

Это соответствия между настройками Timing в PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IEffect#getTiming--):

- Выпадающий список **Start** в PowerPoint соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITiming#getTriggerType--).
- Параметр **Duration** в PowerPoint соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITiming#getDuration--). Длительность анимации (в секундах) — это общее время, за которое анимация завершает один цикл.
- Параметр **Delay** в PowerPoint соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ITiming#getTriggerDelayTime--).

Так вы меняете свойства Timing эффекта:

1. [Apply](#apply-animation-to-shape) или получите эффект анимации.
2. Установите новые значения необходимых свойств [Effect.Timing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IEffect#getTiming--).
3. Сохраните изменённый файл PPTX.

Этот код Java демонстрирует операцию:

```java
import com.aspose.slides.*;

// Создаёт объект класса презентации, представляющий файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Получает основную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence.get_Item(0);

    // Изменяет TriggerType эффекта, чтобы запускался по щелчку
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Изменяет длительность эффекта
    effect.getTiming().setDuration(3f);

    // Изменяет время задержки TriggerDelayTime эффекта
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Звук эффекта анимации**

Aspose.Slides предоставляет следующие свойства для работы со звуком в эффектах анимации: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ru/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Добавить звук к эффекту анимации**

Этот код Java демонстрирует, как добавить звук к эффекту анимации и остановить его, когда начинается следующий эффект:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Добавляет аудио в коллекцию аудио презентации
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает основную последовательность слайда.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности
    IEffect firstEffect = sequence.get_Item(0);

    // Проверяет эффект на отсутствие звука
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Добавляет звук к первому эффекту
        firstEffect.setSound(effectSound);
    }

    // Получает первую интерактивную последовательность слайда.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Устанавливает флаг эффекта "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Сохраняет файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Извлечь звук из эффекта анимации**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките встроенный [setSound(IAudio value)] из каждого эффекта анимации. 

Этот код Java демонстрирует, как извлечь звук, встроенный в эффект анимации:

```java
import com.aspose.slides.*;

// Создаёт объект класса презентации, представляющий файл презентации.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получает основную последовательность слайда.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Извлекает звук эффекта в массив байтов
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **After Animation**

Aspose.Slides для Java позволяет менять свойство After animation (после анимации) эффекта анимации.

![Панель эффекта анимации и расширенное меню в Microsoft PowerPoint](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint соответствует следующим свойствам: 

- Свойство [setAfterAnimationType(int value)] описывает тип After animation:
  * PowerPoint **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ru/java/com.aspose.slides/afteranimationtype/#DoNotDim) (тип анимации по умолчанию);
  * PowerPoint **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Свойство [setAfterAnimationColor(IColorFormat value)] определяет формат цвета после анимации. Это свойство работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/java/com.aspose.slides/afteranimationtype/#Color). Если изменить тип на другой, цвет после анимации будет сброшен.

Этот код Java показывает, как изменить эффект After animation:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создаёт объект класса презентации, представляющий файл презентации
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип после анимации на Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Устанавливает цвет затемнения после анимации
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Записывает файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animate Text**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* эффекта анимации:

- [setAnimateTextType(int value)] определяет тип анимированного текста эффекта. Текст фигуры может анимироваться:
  - Все сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ru/java/com.aspose.slides/animatetexttype/#AllAtOnce))
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ru/java/com.aspose.slides/animatetexttype/#ByWord))
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)] задаёт задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта, отрицательное — задержку в секундах.

Так можно изменить свойства Animate text эффекта:

1. [Apply](#apply-animation-to-shape) или получите эффект анимации.
2. Установите свойство [setBuildType(int value)] в значение [BuildType.AsOneObject], чтобы отключить режим анимации *By Paragraphs*.
3. Установите новые значения для свойств [setAnimateTextType(int value)] и [setDelayBetweenTextParts(float value)].
4. Сохраните изменённый файл PPTX.

Этот код Java демонстрирует операцию:

```java
import com.aspose.slides.*;

// Создаёт объект класса презентации, представляющий файл презентации.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип анимации текста эффекта на "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Изменяет тип анимации текста эффекта на "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Устанавливает задержку между словами в 20% от длительности эффекта
    firstEffect.setDelayBetweenTextParts(20f);

    // Записывает файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Как гарантировать, что анимации сохраняются при публикации презентации в веб?

[Export to HTML5](/slides/ru/java/export-to-html5/) и включите [options](https://reference.aspose.com/slides/ru/java/com.aspose.slides/html5options/) , отвечающие за анимацию [shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [transition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — воспроизводит.

### Как изменение порядка слоёв (z‑order) фигур влияет на анимацию?

Порядок анимации и порядок рисования независимы: эффект определяет время и тип появления/исчезновения, а [z-order](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getZOrderPosition--) определяет, что покрывает что. Видимый результат определяется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides effects-and-shapes следует той же логике.)

### Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?

В целом [animations are supported](/slides/ru/java/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отобразиться иначе. Рекомендуется протестировать используемые эффекты и версию библиотеки.