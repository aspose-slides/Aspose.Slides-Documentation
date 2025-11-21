---
title: Анимация фигур
type: docs
weight: 60
url: /ru/nodejs-java/shape-animation/
keywords:
- фигура
- анимация
- эффект
- добавить эффекты
- получить эффекты
- извлечь эффекты
- применить анимацию
- PowerPoint
- презентация
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "Применить анимацию PowerPoint в JavaScript"
---

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](/slides/ru/nodejs-java/animated-charts/). Они оживляют презентации и их составляющие.

## **Почему использовать анимацию в презентациях?**

Используя анимации, вы можете 

* контролировать поток информации
* подчёркивать важные моменты
* повышать интерес или вовлечённость аудитории
* делать содержимое более читаемым, усваиваемым или обрабатываемым
* привлекать внимание читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество параметров и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **выделение** и **траектории движения**.

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имён `Aspose.Slides.Animation`,
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype). Эти эффекты по сути такие же (или эквивалентные) эффектам, используемым в PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides for Node.js via Java позволяет применять анимацию к тексту в фигуре.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape).
4. Добавьте текст с помощью [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape).
7. Вызовите метод `TextAnimation.setBuildType` со значением из перечисления `BuildType`.
8. Запишите презентацию на диск в формате PPTX.

Этот код Javascript демонстрирует, как применить эффект `Fade` к AutoShape и установить анимацию текста со значением *By 1st Level Paragraphs*:
```javascript
// Создает экземпляр класса презентации, представляющего файл презентации.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Добавляет новую автофигуру с текстом
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Получает основную последовательность слайда.
    var sequence = sld.getTimeline().getMainSequence();
    // Добавляет эффект анимации Fade к фигуре
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Анимирует текст фигуры по абзацам первого уровня
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Сохраняет файл PPTX на диск
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert color="primary"  %}} 

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph). Смотрите [**Animated Text**](/slides/ru/nodejs-java/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) на слайде.
4. Получите основную последовательность эффектов.
5. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe).
6. Запишите презентацию на диск в формате PPTX.

Этот код Javascript демонстрирует, как применить эффект `Fly` к кадру изображения:
```javascript
// Создает экземпляр класса презентации, представляющего файл презентации.
var pres = new aspose.slides.Presentation();
try {
    // Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет кадр изображения на слайд
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Получает основную последовательность слайда.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Добавляет анимацию Fly слева к кадру изображения
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Сохраняет файл PPTX на диск
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Применить анимацию к Shape**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape).
4. Добавьте `Bevel` [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) (при щелчке по этому объекту анимация будет воспроизводиться).
5. Создайте последовательность эффектов для bevel фигуры.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды перемещения к `UserPath`.
8. Запишите презентацию на диск в формате PPTX.

Этот код Javascript демонстрирует, как применить эффект `PathFootball` (путь футбола) к фигуре:
```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Создает эффект PathFootball для существующей фигуры с нуля.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Добавляет анимационный эффект PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Создает некоторую кнопку.
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Создает последовательность эффектов для этой кнопки.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Создает пользовательский путь. Наш объект будет перемещён только после щелчка по кнопке.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Добавляет команды перемещения, так как созданный путь пуст.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Записывает файл PPTX на диск
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получить анимационные эффекты, применённые к Shape**

Следующие примеры показывают, как использовать метод `getEffectsByShape` из класса [Sequence](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Следующий образец кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде в презентации `AnimExample_out.pptx`.
```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Получает основную последовательность анимации слайда.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Получает первую фигуру на первом слайде.
    var shape = firstSlide.getShapes().get_Item(0);

    // Получает анимационные эффекты, применённые к фигуре.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


**Пример 2: Получить все анимационные эффекты, включая унаследованные из заполнителей**

Если фигура на обычном слайде имеет заполнители, расположенные на слайде‑макете и/или слайде‑образце, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа, включая унаследованные из заполнителей.

Предположим, что у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только фигурку нижнего колонтитула с текстом «Made with Aspose.Slides» и к ней применён эффект **Random Bars**.

![Эффект анимации фигуры на слайде](slide-shape-animation.png)

Предположим также, что эффект **Split** применён к заполнителю нижнего колонтитула на слайде‑макете.

![Эффект анимации фигуры на макете](layout-shape-animation.png)

И, наконец, эффект **Fly In** применён к заполнителю нижнего колонтитула на слайде‑образце.

![Эффект анимации фигуры на образце](master-shape-animation.png)

Следующий образец кода показывает, как использовать метод `getBasePlaceholder` из класса [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) для доступа к заполнителям фигуры и получения анимационных эффектов, применённых к фигуре нижнего колонтитула, включая унаследованные из заполнителей, расположенных на макете и образце.
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Получить анимационные эффекты фигуры на обычном слайде.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Получить анимационные эффекты заполнителя на слайде‑макете.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Получить анимационные эффекты заполнителя на мастер‑слайде.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```


Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Полёт, снизу
Type: 134, subtype: 45            // Разделение, вертикальный вход
Type: 126, subtype: 22            // Случайные полосы, горизонтально
```


## **Изменить свойства тайминга анимационного эффекта**

Aspose.Slides for Node.js via Java позволяет изменять свойства тайминга анимационного эффекта.

Это панель Animation Timing в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Это соответствия между PowerPoint Timing и свойствами [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--):

- Выпадающий список PowerPoint Timing **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerType--).
- PowerPoint Timing **Duration** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getDuration--). Длительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла.
- PowerPoint Timing **Delay** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).

Как изменить свойства тайминга эффекта:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите новые значения для нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--).
3. Сохраните изменённый файл PPTX.

Этот код Javascript демонстрирует операцию:
```javascript
// Создает экземпляр класса презентации, представляющего файл презентации.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Получает основную последовательность слайда.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Получает первый эффект основной последовательности.
    var effect = sequence.get_Item(0);
    // Изменяет TriggerType эффекта на запуск по клику
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Изменяет длительность эффекта
    effect.getTiming().setDuration(3.0);
    // Изменяет задержку запуска эффекта
    effect.getTiming().setTriggerDelayTime(0.5);
    // Сохраняет файл PPTX на диск
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Animation Effect Sound**

Aspose.Slides предоставляет следующие свойства для работы со звуками в анимационных эффектах: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Add Animation Effect Sound**

Этот код Javascript демонстрирует, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект:
```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Добавляет аудио в коллекцию аудио презентации
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Получает основную последовательность слайда.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Получает первый эффект основной последовательности
    var firstEffect = sequence.get_Item(0);
    // Проверяет эффект на отсутствие звука
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Добавляет звук к первому эффекту
        firstEffect.setSound(effectSound);
    }
    // Получает первую интерактивную последовательность слайда.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Устанавливает флаг эффекта "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Записывает файл PPTX на диск
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Extract Animation Effect Sound**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) , встроенный в каждый анимационный эффект.

Этот код Javascript демонстрирует, как извлечь звук, встроенный в анимационный эффект:
```javascript
// Создает экземпляр класса презентации, представляющего файл презентации.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Получает основную последовательность слайда.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Извлекает звук эффекта в виде байтового массива
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **После анимации**

Aspose.Slides for Node.js via Java позволяет изменять свойство After animation анимационного эффекта.

Это панель Animation Effect и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint Effect **After animation** соответствует следующим свойствам: 

- Метод [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) описывает тип After animation;
  * Пункт **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color);
  * Пункт **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (тип After animation по умолчанию);
  * Пункт **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * Пункт **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Метод [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) задаёт формат цвета After animation. Этот метод работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color). При смене типа цвет After animation будет очищен.

Этот код Javascript показывает, как изменить эффект After animation:
```javascript
// Создает экземпляр класса презентации, представляющего файл презентации
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Получает первый эффект основной последовательности
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Изменяет тип after animation на Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Устанавливает цвет after animation
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Сохраняет файл PPTX на диск
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Анимировать текст**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) определяет тип анимированного текста эффекта. Текст фигуры может анимироваться:
  - Все сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) тип)
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByWord) тип)
  - По буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByLetter) тип)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) задаёт задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное значение указывает задержку в секундах.

Как изменить свойства Animate text эффекта:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите метод [setBuildType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/buildtype/#AsOneObject), чтобы отключить режим анимации *By Paragraphs*.
3. Установите новые значения для свойств [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) и [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).
4. Сохраните изменённый файл PPTX.

Этот код Javascript демонстрирует операцию:
```javascript
// Создает экземпляр класса презентации, представляющего файл презентации.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Получает первый эффект основной последовательности
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Изменяет тип анимации текста эффекта на "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Изменяет тип анимации текста эффекта на "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Устанавливает задержку между словами в 20% от длительности эффекта
    firstEffect.setDelayBetweenTextParts(20.0);
    // Записывает файл PPTX на диск
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Как убедиться, что анимации сохраняются при публикации презентации в веб?**

[Export to HTML5](/slides/ru/nodejs-java/export-to-html5/) и включите [options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) для анимаций [shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) и [transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — воспроизводит.

**Как изменение порядка слоёв (z-order) фигур влияет на анимацию?**

Анимация и порядок отрисовки независимы: эффект управляет таймингом и типом появления/исчезновения, а [z-order](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) определяет, что покрывает что. Видимый результат формируется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides effects‑and‑shapes следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В общем случае [animations are supported](/slides/ru/nodejs-java/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отображаться иначе. Рекомендуется протестировать используемые эффекты и версию библиотеки.