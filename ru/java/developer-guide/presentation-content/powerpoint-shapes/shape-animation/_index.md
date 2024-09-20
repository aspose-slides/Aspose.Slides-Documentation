---
title: Анимация форм
type: docs
weight: 60
url: /java/shape-animation/
keywords: "Анимация PowerPoint, Эффект анимации, Применить анимацию, Презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Примените анимацию PowerPoint в Java"
---

Анимации — это визуальные эффекты, которые можно применять к текстам, изображениям, формам или [диаграммам](https://docs.aspose.com/slides/java/animated-charts/). Они придают жизнь презентациям или их элементам.

### **Почему стоит использовать анимации в презентациях?**

С помощью анимаций вы можете

* контролировать поток информации
* подчеркивать важные моменты
* увеличить интерес или участие вашей аудитории
* упростить чтение, усвоение или обработку контента
* привлекать внимание ваших читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **подчеркивание** и **попутные пути**.

### **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имен `Aspose.Slides.Animation`,
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype). Эти эффекты по сути такие же (или эквивалентные) как эффекты, используемые в PowerPoint.

## **Применить анимацию к текстовому полю**

Aspose.Slides для Java позволяет вам применять анимацию к тексту в форме.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `прямоугольник` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
7. Установите свойство `TextAnimation.BuildType` на значение из перечисления `BuildType`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот Java-код показывает, как применить эффект `Скрытие` к AutoShape и установить анимацию текста на значение *По 1-му уровню абзацев*:

```java
// Создает экземпляр класса презентации, который представляет файл презентации.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет новую AutoShape с текстом
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Первый абзац \nВторой абзац \nТретий абзац");

    // Получает основную последовательность слайда.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Добавляет эффект анимации Скрытие к форме
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Анимирует текст формы по 1-му уровню абзацев
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Сохраняет файл PPTX на диск
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Кроме применения анимаций к тексту, вы также можете применять анимации к отдельному [абзацу](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph). См. [**Анимированный текст**](/slides/java/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) на слайде.
4. Получите основную последовательность эффектов.
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. Запишите презентацию на диск в виде файла PPTX.

Этот Java-код показывает, как применить эффект `Лететь` к рамке изображения:

```java
// Создает экземпляр класса презентации, который представляет файл презентации.
Presentation pres = new Presentation();
try {
    // Загружает изображение для добавления в коллекцию изображений презентации
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

    // Добавляет эффект анимации Лететь слева к рамке изображения
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Применить анимацию к форме**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `прямоугольник` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) (когда на этот объект нажимают, анимация воспроизводится).
5. Создайте последовательность эффектов на форме с закругленными углами.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды для перемещения к `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот Java-код показывает, как применить эффект `PathFootball` (путь футбольного мяча) к форме:

```java
// Создает экземпляр класса Presentation, который представляет файл PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Создает эффект PathFootball для существующей формы с нуля.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Анимированный текстовое поле");

    // Добавляет эффект анимации PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Создает некий "кнопку".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создает последовательность эффектов для этой кнопки.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Создает пользовательский путь. Наш объект будет перемещаться только после нажатия кнопки.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Добавляет команды для перемещения, так как созданный путь пуст.
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

## **Получить анимационные эффекты, примененные к форме**

Вы можете узнать все анимационные эффекты, примененные к определенной форме.

Этот Java-код показывает, как получить все эффекты, примененные к конкретной форме:

```java
// Создает экземпляр класса презентации, который представляет файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает основную последовательность слайда.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Получает первую форму на слайде.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Получает все анимационные эффекты, примененные к форме.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("У формы " + shape.getName() + " есть " + shapeEffects.length + " анимационных эффекта.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменение свойств времени анимационного эффекта**

Aspose.Slides для Java позволяет изменять свойства времени анимационного эффекта.

Это панель времени анимации в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Вот соответствия между временем PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) :

- Выпадающий список времени PowerPoint **Начало** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--) . 
- Время PowerPoint **Длительность** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--) . Длительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла анимации. 
- Время PowerPoint **Задержка** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--) .

Вот как изменить свойства времени эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите новые значения для нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) . 
3. Сохраните измененный файл PPTX.

Этот Java-код демонстрирует операцию:

```java
// Создает экземпляр класса презентации, который представляет файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Получает основную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence.get_Item(0);

    // Изменяет тип триггера эффекта, чтобы он начинался по щелчку
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Изменяет длительность эффекта
    effect.getTiming().setDuration(3f);

    // Изменяет время задержки триггера эффекта
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Звук анимационного эффекта**

Aspose.Slides предоставляет эти свойства, чтобы позволить вам работать со звуками в анимационных эффектах:

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Добавить звук анимационного эффекта**

Этот Java-код показывает, как добавить звук анимационного эффекта и остановить его, когда начинается следующий эффект:

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

    // Проверяет эффект на "Нет звука"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Добавляет звук к первому эффекту
        firstEffect.setSound(effectSound);
    }

    // Получает первую интерактивную последовательность слайда.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Устанавливает флаг эффекта "Остановить предыдущий звук"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Записывает файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Извлечь звук анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) , встроенный в каждый анимационный эффект.

Этот Java-код показывает, как извлечь звук, встроенный в анимационный эффект:

```java
// Создает экземпляр класса презентации, который представляет файл презентации.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получает основную последовательность слайда.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Извлекает звук эффекта в виде байтового массива
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **После анимации**

Aspose.Slides для Java позволяет изменять свойство после анимации анимационного эффекта.

Это панель анимационных эффектов и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список **После анимации** в PowerPoint соответствует следующим свойствам:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) свойству, которое описывает тип после анимации:
  * PowerPoint **Дополнительные цвета** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) ;
  * Элемент списка PowerPoint **Не затуманивать** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (тип после анимации по умолчанию);
  * Элемент PowerPoint **Скрыть после анимации** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * Элемент PowerPoint **Скрыть при следующем щелчке мыши** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) свойству, которое определяет формат цвета после анимации. Это свойство работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) . Если вы измените тип на другой, цвет после анимации будет очищен.

Этот Java-код показывает, как изменить эффект после анимации:

```java
// Создает экземпляр класса презентации, который представляет файл презентации
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип анимации эффекта на Цвет
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Устанавливает цвет тускления после анимации
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Записывает файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Анимация текста**

Aspose.Slides предоставляет эти свойства, которые позволяют вам работать с блоком анимации текста анимационного эффекта:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) который описывает тип анимации текста эффекта. Текст формы может быть анимирован:
  - Все сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) тип)
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) тип)
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) тип)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) устанавливает задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент длительности эффекта. Отрицательное значение указывает задержку в секундах.

Вот как вы можете изменить свойства анимации текста эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите свойство [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) на значение [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) , чтобы отключить режим анимации *По абзацам*.
3. Установите новые значения для свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. Сохраните измененный файл PPTX.

Этот Java-код демонстрирует операцию:

```java
// Создает экземпляр класса презентации, который представляет файл презентации.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип анимации текста эффекта на "Как один объект"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Изменяет тип анимации текста эффекта на "По словам"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Устанавливает задержку между словами на 20% от длительности эффекта
    firstEffect.setDelayBetweenTextParts(20f);

    // Записывает файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```