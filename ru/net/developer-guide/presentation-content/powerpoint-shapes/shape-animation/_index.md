---
title: Анимация формы
type: docs
weight: 60
url: /ru/net/shape-animation/
keywords:
- форма
- анимация
- эффект
- добавить эффекты
- получить эффекты
- извлечь эффекты
- применить анимацию
- PowerPoint
- презентация
- C#
- Csharp
- Aspose.Slides для .NET
description: "Применить анимацию PowerPoint в C# или .NET"
---

Анимации — это визуальные эффекты, которые можно применять к тексту, изображениям, фигурам или [диаграммам](/slides/ru/net/animated-charts/). Они придают жизнь презентациям и их элементам. 

## **Зачем использовать анимации в презентациях?**

Используя анимации, вы можете 

* управлять потоком информации
* подчёркивать важные моменты
* повышать интерес или вовлечённость аудитории
* делать контент проще для чтения, восприятия или обработки
* привлекать внимание читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество вариантов и инструментов для анимаций и анимационных эффектов в категориях **вход**, **выход**, **акцент** и **траектории движения**. 

## **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, необходимые для работы с анимациями, в пространстве имён [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) ,
* Aspose.Slides предоставляет более **150 анимационных эффектов** в перечислении [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Эти эффекты по сути такие же (или эквивалентные) эффекты, используемые в PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides для .NET позволяет применять анимацию к тексту в фигуре. 

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. Установите свойство [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) в значение из [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Сохраните презентацию на диск в виде файла PPTX.

Этот пример кода C# показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста со значением *By 1st Level Paragraphs*:
```c#
// Создает экземпляр класса презентации, представляющего файл презентации.
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

Помимо применения анимаций к тексту, вы также можете применять анимации к отдельному [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). Смотрите [**Animated Text**](/slides/ru/net/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Получите ссылку на слайд по его индексу.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) на слайде. 
5. Получите основную последовательность эффектов.
6. Добавьте анимационный эффект к [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. Сохраните презентацию на диск в виде файла PPTX.

Этот пример кода C# показывает, как применить эффект `Fly` к рамке изображения:
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
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (при щелчке по этому объекту воспроизводится анимация).
5. Создайте последовательность эффектов на фигуре bevel.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды для перемещения по `UserPath`.
8. Сохраните презентацию на диск в виде файла PPTX.

Этот пример кода C# показывает, как применить эффект `PathFootball` (path football) к фигуре:
```c#
// Создает экземпляр класса Presentation, представляющего файл презентации.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Создает эффект PathFootball для существующей фигуры с нуля.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Добавляет анимационный эффект PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Создает некую "кнопку".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создает последовательность эффектов для кнопки.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Создает пользовательский путь. Наш объект будет перемещён только после нажатия кнопки.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Добавляет команды перемещения, так как созданный путь пуст.
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


## **Получение анимационных эффектов, применённых к Shape**

Ниже приведены примеры, показывающие, как использовать метод `GetEffectsByShape` из интерфейса [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) для получения всех анимационных эффектов, применённых к фигуре.

**Пример 1: Получение анимационных эффектов, применённых к фигуре на обычном слайде**

Ранее вы узнали, как добавлять анимационные эффекты к фигурам в презентациях PowerPoint. Следующий пример кода показывает, как получить эффекты, применённые к первой фигуре на первом обычном слайде в презентации `AnimExample_out.pptx`.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Получает основную последовательность анимаций слайда.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Получает первую фигуру на первом слайде.
    IShape shape = firstSlide.Shapes[0];

    // Получает анимационные эффекты, применённые к фигуре.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**Пример 2: Получение всех анимационных эффектов, включая наследованные из заполнителей**

Если фигура на обычном слайде имеет заполнители, которые находятся на макете и/или шаблоне, и к этим заполнителям добавлены анимационные эффекты, то все эффекты фигур будут воспроизводиться во время показа, включая наследованные из заполнителей.

Предположим, у нас есть файл презентации PowerPoint `sample.pptx` с одним слайдом, содержащим только фигуру нижнего колонтитула с текстом «Made with Aspose.Slides» и к фигуре применён эффект **Random Bars**.

![Эффект анимации фигуры на слайде](slide-shape-animation.png)

Также предположим, что к заполнителю нижнего колонтитула на **макете** применён эффект **Split**.

![Эффект анимации фигуры макета](layout-shape-animation.png)

И, наконец, к заполнителю нижнего колонтитула на **шаблоне** применён эффект **Fly In**.

![Эффект анимации фигуры шаблона](master-shape-animation.png)

Следующий пример кода показывает, как использовать метод `GetBasePlaceholder` из интерфейса [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) для доступа к заполнителям фигур и получения анимационных эффектов, применённых к фигуре нижнего колонтитула, включая наследованные из заполнителей, расположенных на макете и шаблоне.
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


## **Изменение свойств тайминга анимационного эффекта**

Aspose.Slides для .NET позволяет изменять свойства Timing анимационного эффекта.

Это панель тайминга анимации и расширенное меню в Microsoft PowerPoint:

![Панель тайминга анимации](shape-animation.png)

Это соответствия между таймингом PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing):

- Выпадающий список **Start** тайминга PowerPoint соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- **Duration** тайминга PowerPoint соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). Длительность анимации (в секундах) — это общее время, необходимое для одного цикла анимации. 
- **Delay** тайминга PowerPoint соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- Выпадающий список **Repeat** тайминга PowerPoint соответствует этим свойствам: 
  * свойство [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount), которое описывает *число* повторений эффекта;
  * флаг [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide), указывающий, повторяется ли эффект до конца слайда;
  * флаг [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick), указывающий, повторяется ли эффект до следующего клика.
- Флажок **Rewind when done playing** тайминга PowerPoint соответствует свойству [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

Так изменяются свойства тайминга эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите новые значения для нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing). 
3. Сохраните изменённый файл PPTX.

Этот пример кода C# демонстрирует операцию:
```c#
// Создаёт экземпляр класса Presentation, представляющего файл презентации.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Получает основную последовательность слайда.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Получает первый эффект основной последовательности.
    IEffect effect = sequence[0];

    // Изменяет TriggerType эффекта на запуск по щелчку
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Изменяет длительность эффекта
    effect.Timing.Duration = 3f;

    // Изменяет время задержки TriggerDelayTime эффекта
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

### **Добавление звука анимационного эффекта**

Этот пример кода C# показывает, как добавить звук к анимационному эффекту и остановить его, когда начинается следующий эффект:
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

	// Устанавливает флаг "Stop previous sound" для эффекта
	interactiveSequence[0].StopPreviousSound = true;

	// Сохраняет файл PPTX на диск
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **Извлечение звука анимационного эффекта**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу. 
3. Получите основную последовательность эффектов. 
4. Извлеките [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/), встроенный в каждый анимационный эффект. 

Этот пример кода C# показывает, как извлечь звук, встроенный в анимационный эффект:
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

Aspose.Slides для .NET позволяет изменять свойство After animation анимационного эффекта.

Это панель свойства After animation и расширенное меню в Microsoft PowerPoint:

![Панель свойства After animation](shape-after-animation.png)

Выпадающий список **After animation** в PowerPoint соответствует этим свойствам: 

- свойство [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) описывает тип After animation:
  * PowerPoint **More Colors** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (значение по умолчанию);
  * PowerPoint **Hide After Animation** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
- свойство [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) определяет формат цвета после анимации. Это свойство работает совместно с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). Если изменить тип на другой, цвет After animation будет очищен.

Этот пример кода C# показывает, как изменить эффект After animation:
```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Изменяет тип after animation на Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Устанавливает цвет затухания after animation
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Сохраняет файл PPTX на диск
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **Анимация текста**

Aspose.Slides предоставляет следующие свойства для работы с блоком *Animate text* анимационного эффекта:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) описывает тип анимации текста эффекта. Текст фигуры может анимироваться:
  - сразу полностью ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
  - по словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
  - по буквам ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) задаёт задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент длительности эффекта. Отрицательное значение указывает задержку в секундах.

Так можно изменить свойства анимации текста эффекта:

1. [Примените](#apply-animation-to-shape) или получите анимационный эффект.
2. Установите свойство [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) в значение [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) для отключения режима анимации *By Paragraphs*.
3. Установите новые значения для свойств [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) и [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Сохраните изменённый файл PPTX.

Этот пример кода C# демонстрирует операцию:
```c#
// Создаёт экземпляр класса презентации, представляющего файл презентации.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает первый эффект основной последовательности
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Меняет тип TextAnimation эффекта на "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Меняет тип AnimateText эффекта на "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Устанавливает задержку между словами в 20% длительности эффекта
    firstEffect.DelayBetweenTextParts = 20f;

    // Сохраняет файл PPTX на диск
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Как обеспечить сохранение анимаций при публикации презентации в веб?**

[Экспорт в HTML5](/slides/ru/net/export-to-html5/) и включение [опций](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) для анимации [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) и [transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/). Обычный HTML не воспроизводит анимацию слайдов, тогда как HTML5 — воспроизводит.

**Как изменение порядка слоёв (z-order) фигур влияет на анимацию?**

Анимация и порядок отрисовки независимы: эффект управляет временем и типом появления/исчезновения, тогда как [z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) определяет, что покрывает что. Видимый результат определяется их комбинацией. (Это общее поведение PowerPoint; модель Aspose.Slides effects-and-shapes следует той же логике.)

**Есть ли ограничения при конвертации анимаций в видео для некоторых эффектов?**

В целом [анимации поддерживаются](/slides/ru/net/convert-powerpoint-to-video/), но в редких случаях или для специфических эффектов результат может отличаться. Рекомендуется тестировать используемые эффекты и версию библиотеки.