---
title: Применение анимаций фигур в презентациях на .NET
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и настраивать анимацию фигур в презентациях PowerPoint с помощью Aspose.Slides для .NET. Выделяйтесь!"
---

Анимация — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](/slides/ru/net/animated-charts/). Они оживляют презентации и их составляющие. 

## **Зачем использовать анимацию в презентациях?**

* контролировать поток информации
* подчеркивать важные моменты
* повышать интерес или участие аудитории
* облегчать чтение, усвоение или обработку контента
* привлекать внимание читателей или зрителей к важным частям в презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент** и **траектории движения**. 

## **Анимация в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имен [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) , 
* Aspose.Slides предлагает более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Эти эффекты по сути одинаковы (или эквивалентны) тем, что используются в PowerPoint.

## **Применить анимацию к TextBox**

Aspose.Slides для .NET позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. Установите свойство [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) в значение из [перечисления BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Запишите презентацию на диск в виде файла PPTX.

Этот C# код показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста в значение *By 1st Level Paragraphs*:
```c#
// Создает экземпляр класса презентации, представляющего файл презентации.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Добавляет новую автофигуру с текстом
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Получает основную последовательность слайда.
    ISequence sequence = sld.Timeline.MainSequence;

    // Добавляет эффект анимации Fade к фигуре
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Анимирует текст фигуры по абзацам первого уровня
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Сохраняет файл PPTX на диск
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). См. [**Animated Text**](/slides/ru/net/animated-text/).

{{% /alert %}} 

## **Применить анимацию к PictureFrame**

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) на слайде. 
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. Запишите презентацию на диск в виде файла PPTX.

Этот C# код показывает, как применить эффект `Fly` к picture frame:
```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации.
using (Presentation pres = new Presentation())
{
    // Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Добавляет рамку изображения на слайд
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Получает основную последовательность слайда.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Добавляет эффект анимации «Вылет» слева к рамке изображения
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **Применить анимацию к Shape**

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (когда этот объект щелкается, анимация воспроизводится).
5. Создайте последовательность эффектов для формы bevel.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды перемещения к `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот C# код показывает, как применить эффект `PathFootball` (path football) к shape:
```c#
// Создаёт экземпляр класса Presentation, представляющего файл презентации.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Создаёт эффект PathFootball для существующей фигуры с нуля.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Добавляет анимационный эффект PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Создаёт некую "кнопку".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создаёт последовательность эффектов для кнопки.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Создаёт пользовательский путь. Наш объект будет перемещён только после нажатия кнопки.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Добавляет команды перемещения, поскольку созданный путь пуст.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Записывает файл PPTX на диск
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```


## **Получить анимационные эффекты, применённые к Shape**

Следующие примеры показывают, как использовать метод `GetEffectsByShape` из интерфейса [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получить анимационные эффекты, применённые к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Следующий пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде в презентации `AnimExample_out.pptx`.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Получает основную последовательность анимации слайда.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Получает первую фигуру на первом слайде.
    IShape shape = firstSlide.Shapes[0];

    // Получает анимационные эффекты, применённые к фигуре.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**Пример 2: Получить все анимационные эффекты, включая унаследованные от заполнителей**

Если у фигуры на обычном слайде есть заполнители, находящиеся на слайде макета и/или главном слайде, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигуры будут воспроизводиться во время показа слайдов, включая унаследованные от заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только форму нижнего колонтитула с текстом "Made with Aspose.Slides", и к этой форме применён эффект **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Также предположим, что эффект **Split** применён к заполнителю нижнего колонтитула на слайде **layout**.

![Layout shape animation effect](layout-shape-animation.png)

И, наконец, эффект **Fly In** применён к заполнителю нижнего колонтитула на слайде **master**.

![Master shape animation effect](master-shape-animation.png)

Следующий пример кода показывает, как использовать метод `GetBasePlaceholder` из интерфейса [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) для доступа к заполнителям фигур и получения анимационных эффектов, применённых к форме нижнего колонтитула, включая унаследованные от заполнителей, расположенных на слайдах макета и главного слайда.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получить анимационные эффекты фигуры на обычном слайде.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Получить анимационные эффекты заполнителя на слайде макета.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Получить анимационные эффекты заполнителя на главном слайде.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```

```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```


```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Изменить свойства синхронизации анимационного эффекта**

Aspose.Slides для .NET позволяет изменять свойства Timing (тайминга) анимационного эффекта.

This is the Animation Timing pane and extended menu in Microsoft PowerPoint:
![example1_image](shape-animation.png)

- Выпадающий список PowerPoint Timing **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype) .
- PowerPoint Timing **Duration** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration) . Длительность анимации (в секундах) — это общее время, за которое анимация завершает один цикл. 
- PowerPoint Timing **Delay** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime) .
- Выпадающий список PowerPoint Timing **Repeat** соответствует следующим свойствам: 
  * свойство [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) , описывающее *количество* повторений эффекта; 
  * флаг [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) , указывающий, повторяется ли эффект до конца слайда; 
  * флаг [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) , указывающий, повторяется ли эффект до следующего щелчка. 
- Флажок PowerPoint Timing **Rewind when done playing** соответствует свойству [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) .

Так изменяются свойства Effect Timing:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите новые значения нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) .
3. Сохраните измененный файл PPTX.

```c#
 // Создаёт экземпляр класса презентации, представляющего файл презентации.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Получает основную последовательность слайда.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence[0];

    // Изменяет TriggerType эффекта, чтобы он запускался по щелчку
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Изменяет длительность эффекта
    effect.Timing.Duration = 3f;

    // Изменяет TriggerDelayTime эффекта
    effect.Timing.TriggerDelayTime = 0.5f;

    // Если значение Repeat эффекта равно "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Изменяет Repeat эффекта на "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Изменяет Repeat эффекта на "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Включает Rewind эффекта
        effect.Timing.Rewind = true;
    
    // Сохраняет файл PPTX на диск
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **Звук анимационного эффекта**

Aspose.Slides предоставляет следующие свойства для работы со звуками в анимационных эффектах: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Добавить звук анимационного эффекта**

Этот C# код показывает, как добавить звук к анимационному эффекту и остановить его при начале следующего эффекта:
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Добавляет аудио в коллекцию аудио презентации
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Получает основную последовательность слайда.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Получает первый эффект основной последовательности
	IEffect firstEffect = sequence[0];

	// Проверяет, что у эффекта нет звука
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Добавляет звук к первому эффекту
		firstEffect.Sound = effectSound;
	}

	// Получает первую интерактивную последовательность слайда.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Устанавливает флаг эффекта «Остановить предыдущий звук»
	interactiveSequence[0].StopPreviousSound = true;

	// Записывает файл PPTX на диск
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **Извлечь звук анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на слайд по его индексу.
3. Получите основную последовательность эффектов.
4. Извлеките [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) , встроенный в каждый анимационный эффект.

Этот C# код показывает, как извлечь звук, встроенный в анимационный эффект:
```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получает основную последовательность слайда.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Извлекает звук эффекта в массив байтов
        byte[] audio = effect.Sound.BinaryData;
    }
}
```


## **После анимации**

Aspose.Slides для .NET позволяет менять свойство After animation (после анимации) анимационного эффекта.

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint Effect **After animation** соответствует следующим свойствам:

- Свойство [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) описывает тип After animation :
  * PowerPoint **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (тип по умолчанию) ;
  * PowerPoint **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
- Свойство [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) определяет формат цвета After animation. Это свойство работает в совокупности с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). Если изменить тип на другой, цвет After animation будет очищен.

Этот C# код показывает, как изменить эффект After animation:
```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Меняет тип анимации после завершения на Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Устанавливает цвет затемнения после анимации
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Сохраняет файл PPTX на диск
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **Анимировать текст**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) , описывающий тип анимации текста эффекта. Текст фигуры может анимироваться:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) , задаёт задержку между частями анимированного текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное значение задаёт задержку в секундах.

Так можно изменить свойства Effect Animate text:

1. [Apply](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите свойство [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) , чтобы отключить режим анимации *By Paragraphs*.
3. Установите новые значения свойств [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) и [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) .
4. Сохраните изменённый файл PPTX.

```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Меняет тип анимации текста эффекта на "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Меняет тип анимации текста эффекта на "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Устанавливает задержку между словами в 20% длительности эффекта
    firstEffect.DelayBetweenTextParts = 20f;

    // Сохраняет файл PPTX на диск
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Как обеспечить сохранение анимаций при публикации презентации в веб?**

[Export to HTML5](/slides/ru/net/export-to-html5/) и включите [options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) , отвечающие за [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) и [transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) анимации. Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 делает.

**Как изменение порядка слоёв (z-order) фигур влияет на анимацию?**

Порядок слоёв и порядок анимации независимы: эффект определяет время и тип появления/исчезновения, а [z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) определяет, что что перекрывает. Видимый результат формируется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом [анимации поддерживаются](/slides/ru/net/convert-powerpoint-to-video/), но редкие случаи или специфические эффекты могут отрисовываться иначе. Рекомендуется протестировать используемые эффекты и версию библиотеки.