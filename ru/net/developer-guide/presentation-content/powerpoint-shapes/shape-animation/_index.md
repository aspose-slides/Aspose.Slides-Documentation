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

Анимации — это визуальные эффекты, которые можно применять к текстам, изображениям, формам или [диаграммам](/slides/ru/net/animated-charts/). Они придают жизнь презентациям и их элементам. 

## **Зачем использовать анимацию в презентациях?**

Используя анимации, вы можете 

* контролировать поток информации
* подчеркивать важные моменты
* повышать интерес или вовлеченность аудитории
* делать контент легче читаемым, усваиваемым или обрабатываемым
* привлекать внимание читателей или зрителей к важным частям в презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент** и **пути движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями в пространстве имен [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/),
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Эти эффекты по сути идентичны (или эквивалентны) эффектам, используемым в PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides for .NET позволяет применить анимацию к тексту в форме. 

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. Установите свойство [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) в значение из перечисления [BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Запишите презентацию на диск в файл PPTX.

```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Добавляет новый AutoShape с текстом
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

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). Смотрите [**Анимированный текст**](/slides/ru/net/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) на слайде. 
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. Запишите презентацию на диск в файл PPTX.

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

    // Добавляет эффект анимации Fly слева к рамке изображения
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **Применение анимации к Shape**

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (при щелчке по этому объекту будет воспроизводиться анимация).
5. Создайте последовательность эффектов для формы с фаской.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды для перемещения по `UserPath`.
8. Запишите презентацию на диск в файл PPTX.

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

    // Создаёт некую "button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создаёт последовательность эффектов для кнопки.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Создаёт пользовательский путь. Наш объект будет перемещён только после щелчка по кнопке.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Добавляет команды перемещения, так как созданный путь пустой.
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


## **Получение анимационных эффектов, примененных к форме**

Следующие примеры показывают, как использовать метод `GetEffectsByShape` из интерфейса [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) для получения всех анимационных эффектов, применённых к форме.

**Пример 1: Получить анимационные эффекты, примененные к форме на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к формам в презентациях PowerPoint. Ниже приведён пример кода, показывающий, как получить эффекты, применённые к первой форме на первом обычном слайде презентации `AnimExample_out.pptx`.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Получает основную последовательность анимации слайда.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Получает первую форму на первом слайде.
    IShape shape = firstSlide.Shapes[0];

    // Получает анимационные эффекты, применённые к форме.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**Пример 2: Получить все анимационные эффекты, включая унаследованные из заполнителей**

Если форма на обычном слайде имеет заполнители, находящиеся на макете и/или на образце, и к этим заполнителям добавлены анимационные эффекты, то во время показа будут воспроизводятся все эффекты формы, включая унаследованные из заполнителей.

Предположим, что в файле презентации PowerPoint `sample.pptx` есть один слайд, содержащий только форму нижнего колонтитула с текстом «Made with Aspose.Slides» и к форме применён эффект **Random Bars**.

![Эффект анимации формы на слайде](slide-shape-animation.png)

Допустим, что к заполнителю нижнего колонтитула на **макете** применён эффект **Split**.

![Эффект анимации формы на макете](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **шаблоне** применён эффект **Fly In**.

![Эффект анимации формы на шаблоне](master-shape-animation.png)

Ниже приведён пример кода, показывающий, как использовать метод `GetBasePlaceholder` из интерфейса [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) для доступа к заполнителям формы и получения анимационных эффектов, применённых к форме нижнего колонтитула, включая унаследованные из заполнителей, находящихся на макете и образце.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получить анимационные эффекты формы на обычном слайде.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Получить анимационные эффекты заполнителя на слайде макета.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Получить анимационные эффекты заполнителя на слайде шаблона.
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


Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Изменение свойств времени анимационного эффекта**

Aspose.Slides for .NET позволяет изменять свойства времени анимационного эффекта.

Это панель настройки времени анимации и расширенное меню в Microsoft PowerPoint:

![Панель настройки времени анимации в Microsoft PowerPoint](shape-animation.png)

Это соответствия между настройками времени в PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing):

- Выпадающий список **Start** в PowerPoint Timing соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- Параметр **Duration** в PowerPoint Timing соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). Длительность анимации (в секундах) — это общее время, необходимое для завершения одного цикла анимации. 
- Параметр **Delay** в PowerPoint Timing соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- Выпадающий список **Repeat** в PowerPoint Timing соответствует следующим свойствам: 
  * свойство [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount), описывающее *количество* повторений эффекта;
  * флаг [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide), указывающий, повторяется ли эффект до конца слайда;
  * флаг [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick), указывающий, повторяется ли эффект до следующего щелчка.
- Флажок **Rewind when done playing** в PowerPoint Timing соответствует свойству [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

Вот как изменить свойства времени эффекта:

1. [Применить](#apply-animation-to-shape) или получить анимационный эффект.
2. Установите новые значения свойств [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing), которые вам нужны. 
3. Сохраните изменённый файл PPTX.

```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Получает основную последовательность слайда.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence[0];

    // Изменяет тип триггера эффекта на запуск по щелчку
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Изменяет продолжительность эффекта
    effect.Timing.Duration = 3f;

    // Изменяет время задержки триггера эффекта
    effect.Timing.TriggerDelayTime = 0.5f;

    // Если значение Repeat эффекта равно "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Изменяет повтор эффекта на "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Изменяет повтор эффекта на "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Включает Rewind для эффекта
        effect.Timing.Rewind = true;
    
    // Сохраняет файл PPTX на диск
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **Звук анимационного эффекта**

Aspose.Slides предоставляет эти свойства для работы со звуками в анимационных эффектах: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Добавить звук анимационного эффекта**

Этот код C# демонстрирует, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект:
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

	// Проверяет эффект на отсутствие звука
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Добавляет звук к первому эффекту
		firstEffect.Sound = effectSound;
	}

	// Получает первую интерактивную последовательность слайда.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Устанавливает флаг эффекта "Остановить предыдущий звук"
	interactiveSequence[0].StopPreviousSound = true;

	// Записывает файл PPTX на диск
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **Извлечь звук анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките встроенный [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) каждого анимационного эффекта. 

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

Aspose.Slides for .NET позволяет изменить свойство After animation анимационного эффекта.

Это панель параметров эффекта после анимации и расширенное меню в Microsoft PowerPoint:

![Панель параметров эффекта после анимации в Microsoft PowerPoint](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint соответствует этим свойствам: 

- свойство [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) описывает тип после анимации:
  * PowerPoint **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/).
  * PowerPoint **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (тип по умолчанию).
  * PowerPoint **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/).
  * PowerPoint **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/).
- свойство [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) определяет формат цвета после анимации. Это свойство работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). При изменении типа на другой цвет после анимации будет очищен.

```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Меняет тип после анимации на Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Устанавливает цвет затемнения после анимации
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Сохраняет файл PPTX на диск
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **Анимировать текст**

Aspose.Slides предоставляет эти свойства для работы с блоком *Animate text* анимационного эффекта:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) описывает тип анимации текста эффекта. Текст формы может анимироваться:
  - одновременно ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
  - по словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
  - по буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) задаёт задержку между анимируемыми частями текста (словами или буквами). Положительное значение указывает процент от длительности эффекта. Отрицательное значение задаёт задержку в секундах.

Вот как можно изменить свойства анимации текста эффекта:

1. [Применить](#apply-animation-to-shape) или получить анимационный эффект.
2. Установите свойство [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/), чтобы отключить режим анимации *By Paragraphs*.
3. Установите новые значения свойств [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) и [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Сохраните изменённый файл PPTX.

```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Изменяет тип текстовой анимации эффекта на "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Изменяет тип анимации текста эффекта на "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Устанавливает задержку между словами в 20% от длительности эффекта
    firstEffect.DelayBetweenTextParts = 20f;

    // Сохраняет файл PPTX на диск
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Как гарантировать сохранение анимаций при публикации презентации в веб?**

Экспортируйте в HTML5 [/slides/net/export-to-html5/] и включите параметры, отвечающие за анимацию [shape](/reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) и [transition](/reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — воспроизводит.

**Как изменение порядка слоёв (z-order) фигур влияет на анимацию?**

Анимация и порядок рисования независимы: эффект управляет временем и типом появления/исчезновения, тогда как [z-order](/reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) определяет, что покрывает что. Видимый результат задаётся их комбинацией. (Это общее поведение PowerPoint; модель эффектов и фигур Aspose.Slides следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для определённых эффектов?**

В целом анимации поддерживаются [/slides/net/convert-powerpoint-to-video/], но в редких случаях или для специфических эффектов они могут отображаться иначе. Рекомендуется протестировать используемые эффекты и версию библиотеки.