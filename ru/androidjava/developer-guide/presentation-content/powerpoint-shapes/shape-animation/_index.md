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
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint с помощью Aspose.Slides для Android через Java. Выделяйтесь!"
---

Анимация — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](https://docs.aspose.com/slides/androidjava/animated-charts/). Они оживляют презентации и их содержимое.

## **Почему использовать анимацию в презентациях?**

С помощью анимации вы можете  

* контролировать поток информации  
* выделять важные моменты  
* повышать интерес и вовлечённость аудитории  
* упрощать чтение, восприятие и обработку контента  
* привлекать внимание читателей или зрителей к важным частям презентации  

PowerPoint предоставляет множество параметров и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент** и **траектории движения**. 

## **Анимация в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имён `Aspose.Slides.Animation`,  
* Aspose.Slides предлагает более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Эти эффекты практически идентичны (или эквивалентны) тем, что использует PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides for Android via Java позволяет применять анимацию к тексту в фигуре.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Получите главную последовательность эффектов.  
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.  
8. Запишите презентацию на диск в виде файла PPTX.  

В этом Java‑коде показано, как применить эффект `Fade` к AutoShape и задать анимацию текста со значением *By 1st Level Paragraphs*:
```java
// Создает экземпляр класса презентации, представляющего файл презентации.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет новый AutoShape с текстом
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


{{% alert color="primary" %}} 

Помимо применения анимаций к тексту, вы можете анимировать отдельный [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). См. [**Анимированный текст**](/slides/ru/androidjava/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) на слайде.  
4. Получите главную последовательность эффектов.  
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).  
6. Запишите презентацию на диск в виде файла PPTX.  

В этом Java‑коде показано, как применить эффект `Fly` к рамке изображения:
```java
// Создает экземпляр класса презентации, представляющего файл презентации.
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

    // Получает основную последовательность слайда.
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) (при щелчке по этому объекту будет воспроизводиться анимация).  
5. Создайте последовательность эффектов для фигуры с фаской.  
6. Создайте пользовательский `UserPath`.  
7. Добавьте команды перемещения по `UserPath`.  
8. Запишите презентацию на диск в виде файла PPTX.  

В этом Java‑коде показано, как применить эффект `PathFootball` (трасса «футбол») к фигуре:
```java
// Создает экземпляр класса Presentation, представляющего файл PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Создает эффект PathFootball для существующей фигуры с нуля.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Добавляет анимационный эффект PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Создает некую «кнопку».
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создает последовательность эффектов для этой кнопки.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Создает пользовательский путь. Наш объект будет перемещён только после нажатия кнопки.
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


## **Получение анимационных эффектов, применённых к Shape**

Ниже приведены примеры, показывающие, как воспользоваться методом `getEffectsByShape` интерфейса [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы изучали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Следующий пример кода демонстрирует, как получить эффекты, применённые к первой фигуре на первом обычном слайде в презентации `AnimExample_out.pptx`.
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


**Пример 2: Получить все анимационные эффекты, включая унаследованные от плейсхолдеров**

Если фигура на обычном слайде имеет плейсхолдеры, находящиеся в шаблоне слайда и/или в главном слайде, и к этим плейсхолдерам добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные от плейсхолдеров.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только нижний колонтитул с текстом «Made with Aspose.Slides», к которому применён эффект **Random Bars**.

![Анимационный эффект формы на слайде](slide-shape-animation.png)

Допустим, к плейсхолдеру нижнего колонтитула на **шаблонном** слайде применён эффект **Split**.

![Анимационный эффект формы в шаблоне](layout-shape-animation.png)

И, наконец, к плейсхолдеру нижнего колонтитула на **главном** слайде применён эффект **Fly In**.

![Анимационный эффект формы в главном слайде](master-shape-animation.png)

Следующий пример кода показывает, как воспользоваться методом `getBasePlaceholder` интерфейса [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) для доступа к плейсхолдерам фигуры и получения анимационных эффектов, применённых к нижнему колонтитулу, включая унаследованные от плейсхолдеров, расположенных в шаблоне и главном слайдах.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Получить анимационные эффекты фигуры на обычном слайде.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Получить анимационные эффекты заполнителя на слайде макета.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Получить анимационные эффекты заполнителя на главном слайде.
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

Aspose.Slides for Android via Java позволяет изменять свойства Timing (время) анимационного эффекта.

Это панель Timing в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Соответствия между Timing PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--):

- Выпадающий список **Start** в PowerPoint соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- **Duration** в PowerPoint соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). Длительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла анимации.  
- **Delay** в PowerPoint соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Как изменить свойства Timing эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите новые значения свойств [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) по необходимости.  
3. Сохраните изменённый файл PPTX.  

Этот Java‑код демонстрирует указанную операцию:
```java
// Создает экземпляр класса презентации, представляющего файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Получает основную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence.get_Item(0);

    // Изменяет TriggerType эффекта, чтобы запускать по щелчку
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

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Добавление звука к анимационному эффекту**

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

    // Проверяет эффект на отсутствие звука
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Добавляет звук к первому эффекту
        firstEffect.setSound(effectSound);
    }

    // Получает первую интерактивную последовательность слайда.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Устанавливает флаг «Остановить предыдущий звук» для эффекта
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Сохраняет файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Извлечение звука из анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Получите главную последовательность эффектов.  
4. Извлеките встроенный в каждый анимационный эффект метод [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

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


## **After Animation**

Aspose.Slides for Android via Java позволяет изменять свойство After animation (после анимации) анимационного эффекта.

Это панель Animation Effect и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint соответствует следующим свойствам:  

- Свойство [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) описывает тип After animation:  
  * Пункт **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color);  
  * Пункт **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (по умолчанию);  
  * Пункт **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * Пункт **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- Свойство [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) определяет формат цвета после анимации. Оно работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color). При изменении типа на иной цвет будет сброшен.  

Этот Java‑код показывает, как изменить эффект after animation:
```java
// Создает экземпляр класса презентации, представляющего файл презентации
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип After animation на Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Устанавливает цвет затемнения After animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Сохраняет файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animate Text**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта:  

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) описывает тип анимации текста эффекта. Текст фигуры может анимироваться:  
  * Всё сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce));  
  * По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord));  
  * По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter)).  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) задаёт задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент длительности эффекта, отрицательное — задержку в секундах.  

Как изменить свойства Animate text эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите свойство [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject), чтобы отключить режим *By Paragraphs*.  
3. Установите новые значения для свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Сохраните изменённый файл PPTX.  

Этот Java‑код демонстрирует операцию:
```java
// Создает экземпляр класса презентации, представляющего файл презентации.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Меняет тип анимации текста эффекта на "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Меняет тип Animate text эффекта на "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Устанавливает задержку между словами в 20% длительности эффекта
    firstEffect.setDelayBetweenTextParts(20f);

    // Записывает файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Как гарантировать сохранение анимаций при публикации презентации в веб?**

[Экспорт в HTML5](/slides/ru/androidjava/export-to-html5/) и включение [опций](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) для анимации [shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — делает.

**Как изменение порядка слоёв (z‑order) фигур влияет на анимацию?**

Порядок анимации и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезновения, тогда как [z‑order](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) определяет, что покрывает что. Видимый результат формируется их совместным действием. (Это общее поведение PowerPoint; модель Aspose.Slides «эффекты‑и‑фигуры» следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом [анимации поддерживаются](/slides/ru/androidjava/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут быть отрендерены иначе. Рекомендуется протестировать используемые эффекты и выбранную версию библиотеки.