---
title: Анимация Форм
type: docs
weight: 60
url: /androidjava/shape-animation/
keywords: "Анимация PowerPoint, Эффект анимации, Применить анимацию, Презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Применить анимацию PowerPoint на Java"
---

Анимации — это визуальные эффекты, которые могут быть применены к текстам, изображениям, формам или [диаграммам](https://docs.aspose.com/slides/androidjava/animated-charts/). Они придают жизнь презентациям или их компонентам.

### **Почему стоит использовать анимации в презентациях?**

Используя анимации, вы можете 

* контролировать поток информации
* подчеркивать важные моменты
* увеличивать интерес или вовлеченность среди вашей аудитории
* делать контент более читаемым, усваиваемым или обрабатываемым
* привлекать внимание читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество возможностей и инструментов для анимаций и эффектов анимации в категориях **вход**, **выход**, **подчеркнуть** и **движение по траекториям**.

### **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имен `Aspose.Slides.Animation`,
* Aspose.Slides предлагает более **150 эффектов анимации** в перечислении [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Эти эффекты в основном такие же (или эквивалентные) эффекты, используемые в PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides для Android через Java позволяет вам применять анимацию к тексту в форме.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Получите основную последовательность эффектов.
6. Добавьте эффект анимации к [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код на Java показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста на значение *По 1-му уровню абзацев*:

```java
// Создает экземпляр класса презентации, представляющий файл презентации.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет новую AutoShape с текстом
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Первый абзац \nВторой абзац \n Третий абзац");

    // Получает основную последовательность слайда.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Добавляет эффект анимации Fade к форме
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Анимирует текст формы по 1-му уровню абзацев
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Сохраняет PPTX файл на диск
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Абзацу](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). См. [**Анимированный текст**](/slides/androidjava/animated-text/).

{{% /alert %}} 

## **Примените анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) на слайде.
4. Получите основную последовательность эффектов.
5. Добавьте эффект анимации к [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).
6. Запишите презентацию на диск в виде файла PPTX.

Этот код на Java показывает, как применить эффект `Fly` к рамке изображения:

```java
// Создает экземпляр класса презентации, представляющий файл презентации.
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

    // Добавляет эффект анимации Fly from Left к рамке изображения
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет PPTX файл на диск
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Применение анимации к форме**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) (когда этот объект будет нажат, анимация будет проигрываться).
5. Создайте последовательность эффектов на форме с закругленными углами.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды для перемещения по `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код на Java показывает, как применить эффект `PathFootball` (путь футбольного мячика) к форме:

```java
// Создает экземпляр класса Презентации, представляющий PPTX файл.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Создает эффект PathFootball для существующей формы с нуля.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Анимированный TextBox");

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

    // Записывает PPTX файл на диск
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получить эффекты анимации, применяемые к форме**

Вы можете решить узнать все эффекты анимации, применяемые к одной форме. 

Этот код на Java показывает, как получить все эффекты, применяемые к определенной форме:

```java
// Создает экземпляр класса презентации, представляющий файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает основную последовательность слайда.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Получает первую форму на слайде.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Получает все эффекты анимации, примененные к форме.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("Форма " + shape.getName() + " имеет " + shapeEffects.length + " эффекта анимации.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменить свойства времени эффекта анимации**

Aspose.Slides для Android через Java позволяет вам изменять свойства времени эффекта анимации.

Это панель времени анимации в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Вот соответствия между временем PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) :

- Выпадающий список времени PowerPoint **Начало** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) .
- Время PowerPoint **Длительность** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) . Длительность анимации (в секундах) — это общее время, необходимое для завершения анимации одного цикла.
- Время PowerPoint **Задержка** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) .

Вот как вы можете изменить свойства времени эффекта:

1. [Примените](#apply-animation-to-shape) или получите эффект анимации.
2. Установите новые значения для свойств [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) , которые вам нужны.
3. Сохраните измененный PPTX файл.

Этот код на Java демонстрирует операцию:

```java
// Создает экземпляр класса презентации, представляющий файл презентации.
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

    // Изменяет время задержки триггера эффекта
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Сохраняет PPTX файл на диск
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Звук эффекта анимации**

Aspose.Slides предоставляет эти свойства, чтобы вы могли работать со звуками в эффектах анимации: 

- [setSound(IAudio значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Добавить звук эффекта анимации**

Этот код на Java показывает, как добавить звук эффекта анимации и остановить его, когда начинается следующий эффект:

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

    // Проверяет эффект на "Без звука"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Добавляет звук для первого эффекта
        firstEffect.setSound(effectSound);
    }

    // Получает первую интерактивную последовательность слайда.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Устанавливает флаг эффекта "Остановить предыдущий звук"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Записывает PPTX файл на диск
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Извлечение звука эффекта анимации**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките [setSound(IAudio значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) встроенный в каждый эффект анимации.

Этот код на Java показывает, как извлечь звук, встроенный в эффект анимации:

```java
// Создает экземпляр класса презентации, представляющий файл презентации.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Получает основную последовательность слайда.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Извлекает звук эффекта в байтовый массив
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **После анимации**

Aspose.Slides для Android через Java позволяет вам изменять свойство после анимации эффектов анимации.

Это панель эффекта анимации и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список **После анимации** эффекта PowerPoint соответствует следующим свойствам: 

- [setAfterAnimationType(int значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) свойство, которое описывает тип после анимации :
  * PowerPoint **Больше цветов** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) ;
  * Элемент списка PowerPoint **Не затемнять** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (тип после анимации по умолчанию);
  * Элемент PowerPoint **Скрыть после анимации** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * Элемент PowerPoint **Скрыть по следующему щелчку мыши** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- [setAfterAnimationColor(IColorFormat значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) свойство, которое определяет цветовой формат после анимации. Это свойство работает в сочетании с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) . Если вы измените тип на другой, цвет после анимации будет очищен.

Этот код на Java показывает, как изменить эффект после анимации:

```java
// Создает экземпляр класса презентации, представляющий файл презентации
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип после анимации на Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Устанавливает цвет затенения после анимации
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Записывает PPTX файл на диск
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Анимировать текст**

Aspose.Slides предоставляет эти свойства, чтобы вы могли работать с блоком *Анимировать текст* эффекта анимации:

- [setAnimateTextType(int значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) который описывает тип анимации текста эффекта. Текст формы может быть анимирован:
  - Все сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) тип)
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) тип)
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) тип)
- [setDelayBetweenTextParts(float значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) устанавливает задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное значение указывает задержку в секундах.

Вот как вы можете изменить свойства эффекта Анимировать текст:

1. [Примените](#apply-animation-to-shape) или получите эффект анимации.
2. Установите свойство [setBuildType(int значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) , чтобы отключить режим анимации *По абзацам*.
3. Установите новые значения для свойств [setAnimateTextType(int значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float значение)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. Сохраните измененный PPTX файл.

Этот код на Java демонстрирует операцию:

```java
// Создает экземпляр класса презентации, представляющий файл презентации.
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

    // Записывает PPTX файл на диск
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```