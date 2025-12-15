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
description: "Узнайте, как создавать и настраивать анимации фигур в презентациях PowerPoint с помощью Aspose.Slides для Android через Java. Выделитесь!"
---

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](https://docs.aspose.com/slides/androidjava/animated-charts/). Они оживляют презентации и их составные части.

## **Зачем использовать анимации в презентациях?**

С помощью анимаций вы можете  

* контролировать поток информации  
* подчёркивать важные моменты  
* повышать интерес или вовлечённость аудитории  
* делать контент более лёгким для восприятия, усвоения или обработки  
* привлекать внимание читателей или зрителей к важным частям презентации  

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **выделение** и **траектории движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имён `Aspose.Slides.Animation`,  
* Aspose.Slides предлагает более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Эти эффекты по существу те же (или эквивалентные), что используются в PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides for Android via Java позволяет применить анимацию к тексту в фигуре.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Получите основную последовательность эффектов.  
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.  
8. Сохраните презентацию на диск в виде файла PPTX.  

Этот Java‑код показывает, как применить эффект `Fade` к AutoShape и задать анимацию текста со значением *By 1st Level Paragraphs*:
```java
// Создаёт объект класса презентации, представляющий файл презентации.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет новую AutoShape с текстом
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Получает основную последовательность слайда.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Добавляет к фигуре эффект анимации Fade
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

Помимо применения анимаций к тексту, вы можете применять их к отдельному [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). См. [**Анимированный текст**](/slides/ru/androidjava/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) на слайде.  
4. Получите основную последовательность эффектов.  
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).  
6. Сохраните презентацию на диск в виде файла PPTX.  

Этот Java‑код показывает, как применить эффект `Fly` к рамке изображения:
```java
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

    // Добавляет к рамке изображения анимацию Fly слева
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Применение анимации к фигуре**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) (при щелчке по этому объекту будет воспроизводиться анимация).  
5. Создайте последовательность эффектов для фигуры bevel.  
6. Создайте пользовательскую `UserPath`.  
7. Добавьте команды перемещения к `UserPath`.  
8. Сохраните презентацию на диск в виде файла PPTX.  

Этот Java‑код показывает, как применить эффект `PathFootball` (путь «футбол») к фигуре:
```java
// Создаёт объект класса Presentation, представляющий файл PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Создаёт эффект PathFootball для существующей фигуры с нуля.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Добавляет анимационный эффект PathFootball
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Создаёт некую "кнопку".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создаёт последовательность эффектов для этой кнопки.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Создаёт пользовательский путь. Наш объект будет перемещён только после щелчка по кнопке.
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


## **Получение анимационных эффектов, применённых к фигуре**

Ниже приведены примеры использования метода `getEffectsByShape` интерфейса [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Следующий пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx`.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Получает основную последовательность анимации слайда.
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


**Пример 2: Получить все анимационные эффекты, включая унаследованные от заполнителей**

Если фигура на обычном слайде имеет заполняющие элементы, находящиеся на макете слайда и/или на главном слайде, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные от заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только нижний колонтитул с текстом «Made with Aspose.Slides», к которому применён эффект **Random Bars**.

![Эффект анимации фигуры слайда](slide-shape-animation.png)

Также предположим, что к заполнителю нижнего колонтитула на **layout**‑слайде применён эффект **Split**.

![Эффект анимации фигуры макета](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **master**‑слайде применён эффект **Fly In**.

![Эффект анимации фигуры главного слайда](master-shape-animation.png)

Следующий пример кода показывает, как с помощью метода `getBasePlaceholder` интерфейса [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) получить доступ к заполнителям фигуры и получить анимационные эффекты, применённые к фигуре нижнего колонтитула, включая унаследованные от заполнителей, расположенных на layout‑ и master‑слайдах.
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


## **Изменение свойств времени анимационного эффекта**

Aspose.Slides for Android via Java позволяет изменять свойства времени (Timing) анимационного эффекта.

Это панель «Animation Timing» в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Соответствия между параметрами Timing в PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--):

- Выпадающий список PowerPoint Timing **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- PowerPoint Timing **Duration** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). Длительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла.  
- PowerPoint Timing **Delay** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Как изменить свойства Timing эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите новые значения нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--).  
3. Сохраните изменённый PPTX‑файл.  

Этот Java‑код демонстрирует операцию:
```java
// Создаёт объект класса презентации, представляющий файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Получает основную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence.get_Item(0);

    // Меняет TriggerType эффекта на запуск по щелчку
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Меняет длительность эффекта
    effect.getTiming().setDuration(3f);

    // Меняет время задержки запуска эффекта
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Звук анимационного эффекта**

Aspose.Slides предоставляет следующие свойства для работы со звуком в анимационных эффектах:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Добавление звука к анимационному эффекту**

Этот Java‑код показывает, как добавить звук к анимационному эффекту и остановить его при запуске следующего эффекта:
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


### **Извлечение звука из анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Получите основную последовательность эффектов.  
4. Извлеките встроенный звук из каждого анимационного эффекта с помощью [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

Этот Java‑код показывает, как извлечь звук, встроенный в анимационный эффект:
```java
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

Aspose.Slides for Android via Java позволяет изменять свойство After animation анимационного эффекта.

Это панель «Animation Effect» и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint Effect **After animation** соответствует следующим свойствам:  

- Свойство [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) описывает тип After animation:  
  * **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color);  
  * **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (тип по умолчанию);  
  * **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Свойство [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) задаёт цвет после анимации и работает вместе с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color). При смене типа цвет будет очищен.  

Этот Java‑код показывает, как изменить эффект After animation:
```java
// Создаёт объект класса презентации, представляющий файл презентации
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


## **Animate Text**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) описывает тип анимации текста эффекта. Текст фигуры можно анимировать:  
  - Всё сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce));  
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord));  
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter)).  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) задаёт задержку между частями анимированного текста (словами или буквами). Положительное значение указывает процент от длительности эффекта, отрицательное — задержку в секундах.  

Как изменить свойства Animate text эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите свойство [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject), чтобы отключить режим *By Paragraphs*.  
3. Установите новые значения для свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Сохраните изменённый PPTX‑файл.  

Этот Java‑код демонстрирует операцию:
```java
// Создаёт объект класса презентации, представляющий файл презентации.
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

    // Сохраняет файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Как обеспечить сохранение анимаций при публикации презентации в веб?**

[Экспорт в HTML5](/slides/ru/androidjava/export-to-html5/) и включение соответствующих [options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) для анимаций [shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Обычный HTML не воспроизводит анимацию слайдов, в то время как HTML5 — да.

**Как изменение порядка слоёв (z‑order) фигур влияет на анимацию?**

Порядок анимации и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезновения, а [z‑order](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) определяет, что закрывает что. Видимый результат формируется их совместным действием. (Это общее поведение PowerPoint; модель Aspose.Slides effects‑and‑shapes следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом [анимации поддерживаются](/slides/ru/androidjava/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут рендериться иначе. Рекомендуется протестировать используемые эффекты и версию библиотеки.