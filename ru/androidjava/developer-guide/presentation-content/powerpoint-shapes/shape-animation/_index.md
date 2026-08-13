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
## **Введение**

Анимации — это визуальные эффекты, которые можно применять к текстам, изображениям, фигурам или [диаграммам](https://docs.aspose.com/slides/ru/androidjava/animated-charts/). Они оживляют презентации и их элементы.

## **Зачем использовать анимацию в презентациях?**

Используя анимацию, вы можете  

* контролировать поток информации  
* выделять важные моменты  
* повышать интерес или вовлечённость аудитории  
* делать контент более лёгким для чтения, усвоения или обработки  
* привлекать внимание читателей или зрителей к важным частям презентации  

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент**, и **траектории движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет необходимые классы и типы для работы с анимациями в пространстве имён `Aspose.Slides.Animation`,  
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effecttype). Эти эффекты по сути совпадают (или эквивалентны) эффектам, используемым в PowerPoint.  

## **Применение анимации к TextBox**

Aspose.Slides для Android через Java позволяет применять анимацию к тексту в фигуре.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape).  
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Получите главную последовательность эффектов.  
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape).  
7. Установите свойство `TextAnimation.BuildType` в значение из перечисления `BuildType`.  
8. Сохраните презентацию на диск в виде файла PPTX.  

Этот Java‑код демонстрирует, как применить эффект `Fade` к AutoShape и установить анимацию текста со значением *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса презентации, который представляет файл презентации.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавляет новую AutoShape с текстом
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Получает главную последовательность слайда.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Добавляет к фигуре анимационный эффект Fade
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

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph). См. [**Animated Text**](/slides/ru/androidjava/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe) на слайде.  
4. Получите главную последовательность эффектов.  
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pictureframe).  
6. Сохраните презентацию на диск в виде файла PPTX.  

Этот Java‑код демонстрирует, как применить эффект `Fly` к рамке изображения:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса презентации, который представляет файл презентации.
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

    // Получает главную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Добавляет к рамке изображения анимационный эффект Fly из левого края
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Применение анимации к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape).  
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape) (при щелчке по этому объекту воспроизводится анимация).  
5. Создайте последовательность эффектов для формы bevel.  
6. Создайте пользовательский `UserPath`.  
7. Добавьте команды перемещения по `UserPath`.  
8. Сохраните презентацию на диск в виде файла PPTX.  

Этот Java‑код демонстрирует, как применить эффект `PathFootball` (path football) к фигуре:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Создаёт экземпляр класса Presentation, который представляет файл PPTX.
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

## **Получить анимационные эффекты, применённые к фигуре**

Ниже приведённые примеры показывают, как использовать метод `getEffectsByShape` из интерфейса [ISequence](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isequence/) чтобы получить все анимационные эффекты, применённые к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Приведённый ниже пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде презентации `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

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

**Пример 2: Получить все анимационные эффекты, включая наследованные из заполнителей**

Если у фигуры на обычном слайде есть заполнители, которые находятся на макете слайда и/или на слайде‑шаблоне, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа слайдов, включая наследованные из заполнителей.

Допустим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только форму нижнего колонтитула с текстом "Made with Aspose.Slides", к которой применён эффект **Random Bars**.

![Эффект анимации формы слайда](slide-shape-animation.png)

Предположим также, что к заполнителю нижнего колонтитула на **layout** слайде применён эффект **Split**.

![Эффект анимации формы макета](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **master** слайде применён эффект **Fly In**.

![Эффект анимации формы мастер‑слайда](master-shape-animation.png)

Ниже приведённый пример кода показывает, как использовать метод `getBasePlaceholder` из интерфейса [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) чтобы получить доступ к заполнителям формы и получить анимационные эффекты, применённые к форме нижнего колонтитула, включая наследованные из заполнителей, расположенных на слайдах макета и шаблона.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Получить анимационные эффекты фигуры на обычном слайде.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Получить анимационные эффекты заполнителя на макетном слайде.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Получить анимационные эффекты заполнителя на мастер-слайде.
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

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Изменение свойств тайминга анимационных эффектов**

Aspose.Slides для Android через Java позволяет изменять свойства Timing анимационного эффекта.

Это панель тайминга анимации в Microsoft PowerPoint:

![Панель тайминга анимации](shape-animation.png)

Это соответствия между таймингом PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IEffect#getTiming--) :

- Выпадающий список **Start** в PowerPoint соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- **Duration** в PowerPoint соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITiming#getDuration--). Длительность анимации (в секундах) — это общее время, за которое анимация завершает один цикл.  
- **Delay** в PowerPoint соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Так изменяются свойства Effect Timing:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите новые значения нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IEffect#getTiming--).  
3. Сохраните изменённый файл PPTX.  

Этот Java‑код демонстрирует операцию:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса презентации, который представляет файл презентации.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Получает главную последовательность слайда.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence.get_Item(0);

    // Изменяет TriggerType эффекта, чтобы он запускался по щелчку
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Изменяет длительность эффекта
    effect.getTiming().setDuration(3f);

    // Изменяет TriggerDelayTime эффекта
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Звук анимационного эффекта**

Aspose.Slides предоставляет следующие свойства, позволяющие работать со звуками в анимационных эффектах: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Добавить звук к анимационному эффекту**

Этот Java‑код показывает, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Добавляет аудио в коллекцию аудио презентации
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает главную последовательность слайда.
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

    // Записывает файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Извлечь звук из анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/).  
2. Получите ссылку на слайд по его индексу.  
3. Получите главную последовательность эффектов.  
4. Извлеките встроенный в каждый анимационный эффект [setSound(IAudio value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

Этот Java‑код показывает, как извлечь звук, встроенный в анимационный эффект:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса презентации, который представляет файл презентации.
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

Aspose.Slides для Android через Java позволяет изменять свойство After animation анимационного эффекта.

Это панель эффекта анимации и расширенное меню в Microsoft PowerPoint:

![Панель эффекта анимации и расширенное меню](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint соответствует следующим свойствам:

- Свойство [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) описывает тип After animation:  
  * **More Colors** в PowerPoint соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#Color);  
  * **Don't Dim** в PowerPoint соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (тип анимации по умолчанию);  
  * **Hide After Animation** в PowerPoint соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * **Hide on Next Mouse Click** в PowerPoint соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);  
- Свойство [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) определяет формат цвета After animation. Это свойство работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/afteranimationtype/#Color). При изменении типа на другой цвет After animation будет очищен.  

Этот Java‑код показывает, как изменить эффект after animation:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создаёт экземпляр класса презентации, который представляет файл презентации
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип after animation на Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Устанавливает цвет затемнения after animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Сохраняет файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Анимировать текст**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта:

- Свойство [setAnimateTextType(int value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) описывает тип анимации текста эффекта. Текст фигуры можно анимировать:  
  * Все сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) тип)  
  * По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/animatetexttype/#ByWord) тип)  
  * По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/animatetexttype/#ByLetter) тип)  
- Свойство [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) устанавливающее задержку между частями анимированного текста (словами или буквами). Положительное значение задаёт процент от длительности эффекта. Отрицательное значение задаёт задержку в секундах.  

Так можно изменить свойства Effect Animate text:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.  
2. Установите свойство [setBuildType(int value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/buildtype/#AsOneObject), чтобы отключить режим анимации *By Paragraphs*.  
3. Установите новые значения свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Сохраните изменённый файл PPTX.  

Этот Java‑код демонстрирует операцию:

```java
import com.aspose.slides.*;

// Создаёт экземпляр класса презентации, который представляет файл презентации.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Изменяет тип анимации текста эффекта на "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Изменяет тип анимации текста эффекта на "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Устанавливает задержку между словами на 20% от длительности эффекта
    firstEffect.setDelayBetweenTextParts(20f);

    // Сохраняет файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Как обеспечить сохранение анимаций при публикации презентации в веб?

[Export to HTML5](/slides/ru/androidjava/export-to-html5/) и включите [options](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/html5options/) , отвечающие за анимацию [shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) и [transition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Обычный HTML не воспроизводит анимацию слайдов, в то время как HTML5 — да.

### Как изменение порядка слоёв (z-order) фигур влияет на анимацию?

Анимация и порядок отрисовки независимы: эффект определяет тайминг и тип появления/исчезновения, а [z-order](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getZOrderPosition--) определяет, что покрывает что. Видимый результат задаётся их сочетанием. (Это общее поведение PowerPoint; модель эффектов и фигур Aspose.Slides следует той же логике.)

### Есть ли ограничения при конвертации анимаций в видео для определённых эффектов?

В целом [анимации поддерживаются](/slides/ru/androidjava/convert-powerpoint-to-video/), но редкие случаи или конкретные эффекты могут отображаться иначе. Рекомендуется протестировать используемые эффекты и версию библиотеки.