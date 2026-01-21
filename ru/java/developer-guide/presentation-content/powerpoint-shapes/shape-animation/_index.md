---
title: Применение анимаций фигур в презентациях с использованием Java
linktitle: Анимация фигуры
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

Анимация — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [charts](https://docs.aspose.com/slides/java/animated-charts/). Они оживляют презентации или их составляющие. 

## **Зачем использовать анимацию в презентациях?**

* контролировать поток информации
* выделять важные моменты
* повышать интерес или вовлечённость аудитории
* делать контент более лёгким для чтения, усвоения или обработки
* привлекать внимание читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество параметров и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент** и **путь движения**. 

## **Анимация в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имён `Aspose.Slides.Animation`,
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype). Эти эффекты по сути такие же (или эквивалентные) эффекты, используемые в PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides for Java позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Получите главную последовательность эффектов.
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот Java‑код показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста значение *By 1st Level Paragraphs*:
```java
// Создаёт экземпляр класса презентации, представляющего файл презентации.
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
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph). См. [**Animated Text**](/slides/ru/java/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) на слайде. 
4. Получите главную последовательность эффектов.
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. Запишите презентацию на диск в виде файла PPTX.

Этот Java‑код показывает, как применить эффект `Fly` к кадру изображения:
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

    // Добавляет рамку изображения на слайд
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Получает основную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Добавляет анимационный эффект Fly слева к рамке изображения
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Применить анимацию к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) (когда этот объект щёлкнут, анимация воспроизводится).
5. Создайте последовательность эффектов для формы bevel.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды перемещения к `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот Java‑код показывает, как применить эффект `PathFootball` (path football) к фигуре:
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

    // Создаёт некую кнопку.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создаёт последовательность эффектов для этой кнопки.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Создаёт пользовательский путь. Наш объект будет перемещён только после нажатия кнопки.
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


## **Получить анимационные эффекты, применённые к Shape**

В следующих примерах показано, как использовать метод `getEffectsByShape` из интерфейса [ISequence](https://reference.aspose.com/slides/java/com.aspose.slides/isequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Ниже приведён пример кода, показывающий, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx`.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Получает основную последовательность анимаций слайда.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Получает первую фигуру на первом слайде.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Получает анимационные эффекты, применённые к фигуре.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**Пример 2: Получить все анимационные эффекты, включая унаследованные из заполнителей**

Если у фигуры на обычном слайде есть заполнители, находящиеся на слайде шаблона и/или мастера, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные из заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только форму нижнего колонтитула с текстом «Made with Aspose.Slides», к которой применён эффект **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Также предположим, что к заполнителю нижнего колонтитула на **layout**‑слайде применён эффект **Split**.

![Layout shape animation effect](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **master**‑слайде применён эффект **Fly In**.

![Master shape animation effect](master-shape-animation.png)

Следующий пример кода показывает, как использовать метод `getBasePlaceholder` из интерфейса [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) для доступа к заполнителям фигур и получения анимационных эффектов, применённых к форме нижнего колонтитула, включая унаследованные из заполнителей, расположенных на слайдах шаблона и мастера.
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


Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Изменить свойства тайминга анимационного эффекта**

Aspose.Slides for Java позволяет изменять свойства Timing (тайминг) анимационного эффекта.

Это панель тайминга анимации в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Соответствия между параметрами PowerPoint Timing и свойствами [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) :

- Выпадающий список PowerPoint Timing **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--).
- PowerPoint Timing **Duration** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--). Длительность анимации (в секундах) — это общее время, за которое анимация завершает один цикл.
- PowerPoint Timing **Delay** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--).

Как изменить свойства тайминга эффекта:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите новые значения для нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--).
3. Сохраните изменённый файл PPTX.

```java
// Создаёт экземпляр класса презентации, представляющего файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Получает основную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence.get_Item(0);

    // Изменяет тип триггера эффекта на запуск по щелчку
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Изменяет длительность эффекта
    effect.getTiming().setDuration(3f);

    // Изменяет задержку триггера эффекта
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

### **Добавить звук анимационного эффекта**

Этот Java‑код показывает, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Добавляет аудио в коллекцию аудио презентации
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает основную последовательность слайда.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности
    IEffect firstEffect = sequence.get_Item(0);

    // Проверяет эффект на отсутствие звука "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Добавляет звук к первому эффекту
        firstEffect.setSound(effectSound);
    }

    // Получает первую интерактивную последовательность слайда.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Устанавливает флаг эффекта "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Записывает файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Извлечь звук анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Получите главную последовательность эффектов. 
4. Извлеките встроенный в каждый анимационный эффект звук с помощью метода [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-). 

Этот Java‑код показывает, как извлечь звук, встроенный в анимационный эффект:
```java
// Создаёт экземпляр класса презентации, представляющего файл презентации.
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


## **После анимации**

Aspose.Slides for Java позволяет изменять свойство After animation (после анимации) анимационного эффекта.

Это панель свойства анимационного эффекта и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint Effect **After animation** соответствует следующим свойствам: 

- Свойство [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) описывает тип After animation :
  * PowerPoint **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (тип After animation по умолчанию);
  * PowerPoint **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Свойство [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) определяет формат цвета после анимации. Это свойство работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color). При смене типа на другой цвет после анимации будет очищен.

```java
// Создаёт экземпляр класса презентации, представляющего файл презентации
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип After animation на Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Устанавливает цвет после анимации
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Записывает файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Анимировать текст**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта:

- Свойство [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) описывает тип анимации текста. Текст фигуры может анимироваться:
  - Всё одновременно ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) тип)
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) тип)
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) тип)
- Свойство [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) задаёт задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное значение указывает задержку в секундах.

Как изменить свойства Animate text эффекта:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите свойство [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject), чтобы отключить режим анимации *By Paragraphs*.
3. Установите новые значения для свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Сохраните изменённый файл PPTX.

```java
// Создаёт экземпляр класса презентации, представляющего файл презентации.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Меняет тип анимации текста эффекта на "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Меняет тип анимации текста эффекта на "By word"
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

**Как гарантировать сохранение анимаций при публикации презентации в веб?**

[Export to HTML5](/slides/ru/java/export-to-html5/) и включите [options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) для анимаций [shape](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [transition](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Обычный HTML не воспроизводит анимацию слайдов, а HTML5 — воспроизводит.

**Как изменение порядка слоёв (z-order) фигур влияет на анимацию?**

Порядок анимации и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезания, тогда как [z-order](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) определяет, что что покрывает. Видимый результат задаётся их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides effects‑and‑shapes следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом [анимации поддерживаются](/slides/ru/java/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отображаться иначе. Рекомендуется протестировать используемые эффекты и используемую версию библиотеки.