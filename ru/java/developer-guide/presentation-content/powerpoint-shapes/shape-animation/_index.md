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
- звуковой эффект
- применить анимацию
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint с помощью Aspose.Slides для Java. Выделяйтесь!"
---

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](https://docs.aspose.com/slides/java/animated-charts/). Они оживляют презентации и их содержимое. 

## **Зачем использовать анимацию в презентациях?**

С помощью анимаций вы можете 

* контролировать поток информации
* выделять важные моменты
* повышать интерес или вовлеченность аудитории
* делать контент легче читаемым, воспринимаемым или обрабатываемым
* привлекать внимание читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество параметров и средств для анимаций и анимационных эффектов в категориях **вход**, **выход**, **выделение** и **траектории движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имён `Aspose.Slides.Animation`,
* Aspose.Slides предлагает более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype). Эти эффекты по сути такие же (или эквивалентные) как используемые в PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides for Java позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Получите главную последовательность эффектов.
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
7. Задайте свойство `TextAnimation.BuildType` значением из перечисления `BuildType`.
8. Запишите презентацию на диск в виде файла PPTX.

В этом Java‑коде показано, как применить эффект `Fade` к AutoShape и установить анимацию текста со значением *By 1st Level Paragraphs*:
```java
// Создает экземпляр класса презентации, представляющего файл презентации.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет новую AutoShape с текстом
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Получает главную последовательность слайда.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Добавляет эффект анимации Fade к фигуре
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Анимирует текст фигуры по абзацам первого уровня
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Сохраняет файл PPTX на диск
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

Помимо применения анимаций к тексту, вы можете также применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph). См. [**Animated Text**](/slides/ru/java/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) на слайде. 
4. Получите главную последовательность эффектов.
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. Запишите презентацию на диск в виде файла PPTX.

В этом Java‑коде показано, как применить эффект `Fly` к кадру изображения:
```java
// Создаёт экземпляр класса презентации, представляющего файл презентации.
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

    // Добавляет кадр изображения на слайд
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Получает главную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Добавляет эффект анимации Fly слева к кадру изображения
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Применение анимации к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) (при щелчке по этому объекту будет воспроизводиться анимация).
5. Создайте последовательность эффектов на форме Bevel.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды перемещения по `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

В этом Java‑коде показано, как применить эффект `PathFootball` (траектория football) к фигуре:
```java
// Создаёт экземпляр класса Presentation, представляющего файл PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Создаёт эффект PathFootball для существующей фигуры с нуля.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Добавляет анимационный эффект PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Создаёт некую «кнопку».
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создаёт последовательность эффектов для этой кнопки.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Создаёт пользовательский путь. Наш объект будет перемещён только после щелчка по кнопке.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Добавляет команды перемещения, так как созданный путь пуст.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Записывает файл PPTX на диск
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получение анимационных эффектов, применённых к фигуре**

Следующие примеры показывают, как использовать метод `getEffectsByShape` из интерфейса [ISequence](https://reference.aspose.com/slides/java/com.aspose.slides/isequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получение анимационных эффектов, применённых к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Приведённый ниже пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx`.
```java
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


**Пример 2: Получение всех анимационных эффектов, включая унаследованные из заполнителей**

Если фигура на обычном слайде имеет заполнители, расположенные на слайде‑шаблоне и/или слайде‑мастере, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные из заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только фигуру нижнего колонтитула с текстом «Made with Aspose.Slides», к которой применён эффект **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Также предположим, что эффект **Split** применён к заполнителю нижнего колонтитула на **layout**‑слайде.

![Layout shape animation effect](layout-shape-animation.png)

И, наконец, эффект **Fly In** применён к заполнителю нижнего колонтитула на **master**‑слайде.

![Master shape animation effect](master-shape-animation.png)

Ниже приведён пример кода, демонстрирующий, как использовать метод `getBasePlaceholder` из интерфейса [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) для доступа к заполнителям фигур и получения анимационных эффектов, применённых к фигуре нижнего колонтитула, включая унаследованные из заполнителей, расположенных на layout‑ и master‑слайдах.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```java
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


## **Изменение свойств времени анимационного эффекта**

Aspose.Slides for Java позволяет изменять свойства времени (Timing) анимационного эффекта.

Это панель Timing в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Соответствия между параметрами Timing в PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--):

- Выпадающий список PowerPoint **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--). 
- Поле **Duration** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--). Длительность анимации (в секундах) — это общее время, за которое анимация завершает один цикл. 
- Поле **Delay** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

Как изменить свойства Timing эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите новые значения нужных свойств [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--).
3. Сохраните изменённый файл PPTX.

Пример Java‑кода, демонстрирующий эту операцию:
```java
// Создаёт экземпляр класса презентации, представляющего файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Получает главную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence.get_Item(0);

    // Изменяет тип TriggerType эффекта на запуск по щелчку
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


## **Звук анимационного эффекта**

Aspose.Slides предоставляет следующие свойства для работы со звуками в анимационных эффектах: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Добавление звука к анимационному эффекту**

Этот Java‑код показывает, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Добавляет аудио в коллекцию аудио презентации
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает главную последовательность слайда.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Получает первый эффект главной последовательности
    IEffect firstEffect = sequence.get_Item(0);

    // Проверяет эффект на отсутствие звука
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Добавляет звук к первому эффекту
        firstEffect.setSound(effectSound);
    }

    // Получает первую интерактивную последовательность слайда.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Устанавливает флаг "Остановить предыдущий звук" для эффекта
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Сохраняет файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Извлечение звука из анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу. 
3. Получите главную последовательность эффектов. 
4. Извлеките встроенный звук из каждого анимационного эффекта с помощью [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-). 

Этот Java‑код демонстрирует, как извлечь звук, встроенный в анимационный эффект:
```java
// Создаёт экземпляр класса презентации, представляющего файл презентации.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получает главную последовательность слайда.
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


## **После анимации**

Aspose.Slides for Java позволяет менять свойство After animation анимационного эффекта.

Это панель Effect и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint **After animation** соответствует следующим свойствам: 

- Свойство [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) описывает тип After animation:
  * **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color);
  * **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (значение по умолчанию);
  * **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Свойство [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) задаёт формат цвета после анимации. Оно работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color). При смене типа на другой цвет будет очищен.

Пример Java‑кода, показывающий, как изменить эффект After animation:
```java
// Создаёт экземпляр класса презентации, представляющего файл презентации
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип After animation на Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Устанавливает цвет затемнения после анимации
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Записывает файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Анимировать текст**

Aspose.Slides предоставляет свойства для работы с блоком *Animate text* анимационного эффекта:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) описывает тип анимированного текста. Текст фигуры может быть анимирован:
  - Всё сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce))
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord))
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) задаёт задержку между частями анимированного текста (словами или буквами). Положительное значение указывает процент от длительности эффекта, отрицательное — задержку в секундах.

Как изменить свойства Animate text эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите свойство [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject), чтобы отключить режим *By Paragraphs*.
3. Установите новые значения для свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Сохраните изменённый файл PPTX.

Пример Java‑кода, демонстрирующий эту операцию:
```java
// Создаёт экземпляр класса презентации, представляющего файл презентации.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
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

**Как убедиться, что анимации сохраняются при публикации презентации в веб?**

[Экспорт в HTML5](/slides/ru/java/export-to-html5/) и включите соответствующие [опции](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/), отвечающие за анимацию [shape](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [transition](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — да.

**Как изменение порядка слоёв (z‑order) фигур влияет на анимацию?**

Порядок анимации и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезновения, а [z‑order](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) определяет, что покрывает что. Видимый результат формируется их сочетанием. (Это общее поведение PowerPoint; модель Aspose.Slides — то же.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом [анимации поддерживаются](/slides/ru/java/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут быть отрендерены иначе. Рекомендуется тестировать используемые эффекты и версию библиотеки.