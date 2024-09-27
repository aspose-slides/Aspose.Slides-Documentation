---
title: Анимация форм
type: docs
weight: 60
url: /ru/net/shape-animation/
keywords: "анимация PowerPoint, эффект анимации, применение анимации, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Применение анимации PowerPoint в C# или .NET"
---

Анимации — это визуальные эффекты, которые можно применять к текстам, изображениям, формам или [диаграммам](/slides/ru/net/animated-charts/). Они оживляют презентации или их элементы.

### **Почему стоит использовать анимации в презентациях?**

Используя анимации, вы можете

* контролировать поток информации
* подчеркивать важные моменты
* увеличивать интерес или участие в вашей аудитории
* облегчать чтение, усвоение или обработку контента
* привлекать внимание ваших читателей или зрителей к важным частям презентации

PowerPoint предоставляет множество опций и инструментов для анимаций и эффектов анимации в категориях **вход**, **выход**, **акцент** и **движение по пути**.

### **Анимации в Aspose.Slides**

* Aspose.Slides предоставляет классы и типы, которые вам нужны для работы с анимациями в пространстве имен [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/),
* Aspose.Slides предоставляет более **150 эффектов анимации** в перечислении [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Эти эффекты по сути такие же (или эквивалентные), как эффекты, используемые в PowerPoint.

## **Применение анимации к TextBox**

Aspose.Slides для .NET позволяет применять анимацию к тексту в форме.

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Получите ссылку на слайд через его индекс.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
4. Добавьте текст в [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. Получите основную последовательность эффектов.
6. Добавьте эффект анимации к [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. Установите свойство [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) на значение из [перечисления BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Запишите презентацию на диск в виде файла PPTX.

Этот код на C# показывает, как применить эффект `Fade` к AutoShape и установить анимацию текста на значение *По 1-му уровню абзацев*:

```c#
// Создает экземпляр класса презентации, который представляет собой файл презентации.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Добавляет новуюAutoShape с текстом
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Первый абзац \nВторой абзац \nТретий абзац";

    // Получает основную последовательность слайда.
    ISequence sequence = sld.Timeline.MainSequence;

    // Добавляет эффект анимации Fade к форме
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Анимирует текст формы по 1-му уровню абзацев
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Сохраняет файл PPTX на диск
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Кроме применения анимаций к тексту, вы также можете применять анимации к одному [абзацу](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). См. [**Анимированный текст**](/slides/ru/net/animated-text/).

{{% /alert %}} 

## **Применение анимации к PictureFrame**

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Получите ссылку на слайд через его индекс.
3. Добавьте или получите [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) на слайде. 
5. Получите основную последовательность эффектов.
6. Добавьте эффект анимации к [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. Запишите презентацию на диск в виде файла PPTX.

Этот код на C# показывает, как применить эффект `Fly` к рамке изображения:

```c#
// Создает экземпляр класса презентации, который представляет собой файл презентации.
using (Presentation pres = new Presentation())
{
    // Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    Image img = new Bitmap("aspose-logo.jpg");
    IPPImage image = pres.Images.AddImage(img);

    // Добавляет рамку изображения на слайд
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);

    // Получает основную последовательность слайда.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Добавляет эффект анимации Fly from Left к рамке изображения
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Сохраняет файл PPTX на диск
    pres.Save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Применение анимации к форме**

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Получите ссылку на слайд через его индекс.
3. Добавьте `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Добавьте `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (когда на этот объект нажимают, анимация запускается).
5. Создайте последовательность эффектов на форме Bevel.
6. Создайте пользовательский `UserPath`.
7. Добавьте команды для перемещения к `UserPath`.
8. Запишите презентацию на диск в виде файла PPTX.

Этот код на C# показывает, как применить эффект `PathFootball` (путь футбольного мяча) к форме:

```c#
// Создает экземпляр класса Presentation, который представляет собой файл презентации.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Создает эффект PathFootball для существующей формы с нуля.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Анимированный TextBox");

    // Добавляет эффект анимации PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Создает некий "кнопку".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Создает последовательность эффектов для кнопки.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Создает пользовательский маршрут. Наш объект будет перемещен только после нажатия кнопки.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Добавляет команды для перемещения, так как созданный путь пуст.
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

## **Получение эффектов анимации, примененных к форме**

Вы можете решить выяснить все эффекты анимации, примененные к одной форме.

Этот код на C# показывает, как получить все эффекты, примененные к конкретной форме:

```c#
// Создает экземпляр класса презентации, который представляет собой файл презентации.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает основную последовательность слайда.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Получает первую форму на слайде.
    IShape shape = firstSlide.Shapes[0];

    // Получает все эффекты анимации, примененные к форме.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine("Форма " + shape.Name + " имеет " + shapeEffects.Length + " эффектов анимации.");
}
```

## **Изменение временных свойств эффекта анимации**

Aspose.Slides для .NET позволяет изменять временные свойства эффекта анимации.

Это панель времени анимации и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-animation.png)

Это соответствия между временными параметрами PowerPoint и свойствами [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing):
- Выпадающий список PowerPoint Timing **Start** соответствует свойству [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- Время PowerPoint Timing **Duration** соответствует свойству [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). Продолжительность анимации (в секундах) — это общее время, которое требуется анимации для завершения одного цикла. 
- Время задержки PowerPoint Timing **Delay** соответствует свойству [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- Выпадающий список PowerPoint Timing **Repeat** соответствует следующим свойствам: 
  * Свойство [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount), которое описывает *количество* раз, которое эффект повторяется;
  * Флаг [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide), который указывает, будет ли эффект повторяться до конца слайда;
  * Флаг [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick), который указывает, будет ли эффект повторяться до следующего щелчка.
- Флажок PowerPoint Timing **Rewind when done playing** соответствует свойству [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

Вот как вы можете изменить свойства времени эффекта:

1. [Примените](#apply-animation-to-shape) или получите эффект анимации.
2. Установите новые значения для нужных вам свойств [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing). 
3. Сохраните измененный файл PPTX.

Этот код на C# демонстрирует операцию:

```c#
// Создает экземпляр класса презентации, который представляет собой файл презентации.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Получает основную последовательность слайда.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Получает первый эффект главной последовательности.
    IEffect effect = sequence[0];

    // Изменяет тип триггера эффекта на запуск по щелчку
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Изменяет продолжительность эффекта
    effect.Timing.Duration = 3f;

    // Изменяет время задержки триггера эффекта
    effect.Timing.TriggerDelayTime = 0.5f;

    // Если значение повторения эффекта "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Изменяет повторение эффекта на "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Изменяет повторение эффекта на "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Включает перемотку эффекта
    effect.Timing.Rewind = true;
    
    // Сохраняет файл PPTX на диск
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Звук эффекта анимации**

Aspose.Slides предоставляет эти свойства, чтобы вы могли работать со звуками в эффектах анимации: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Добавление звука эффекта анимации**

Этот код на C# показывает, как добавить звук эффекта анимации и остановить его, когда начинается следующий эффект:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Добавляет аудио в коллекцию аудио презентации
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Получает основную последовательность слайда.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Получает первый эффект главной последовательности
	IEffect firstEffect = sequence[0];

	// Проверяет эффект на "Без звука"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Добавляет звук для первого эффекта
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

### **Извлечение звука эффекта анимации**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на слайд через его индекс. 
3. Получите основную последовательность эффектов. 
4. Извлеките [звук](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) , встроенный в каждый эффект анимации. 

Этот код на C# показывает, как извлечь звук, встроенный в эффект анимации:

```c#
// Создает экземпляр класса презентации, который представляет собой файл презентации.
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

Aspose.Slides для .NET позволяет вам изменять свойства после анимации эффекта анимации.

Это панель эффекта анимации и расширенное меню в Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Выпадающий список PowerPoint Effect **After animation** соответствует следующим свойствам: 

- Свойство [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) , которое описывает тип после анимации :
  * PowerPoint **Дополнительные цвета** соответствует типу [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * Элемент списка PowerPoint **Не затемнять** соответствует типу [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (тип анимации по умолчанию);
  * Элемент списка PowerPoint **Скрыть после анимации** соответствует типу [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * Элемент списка PowerPoint **Скрыть при следующем щелчке мыши** соответствует типу [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
- Свойство [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) , которое определяет формат цвета после анимации. Это свойство работает в сочетании с типом [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). Если вы измените тип на другой, цвет после анимации будет очищен.

Этот код на C# показывает, как изменить эффект после анимации:

```c#
// Создает экземпляр класса презентации, который представляет собой файл презентации
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает первый эффект главной последовательности
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Изменяет тип эффекта после анимации на цвет
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Устанавливает цвет затемнения после анимации
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Записывает файл PPTX на диск
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Анимация текста**

Aspose.Slides предоставляет эти свойства, чтобы позволить вам работать с блоком *Анимация текста* эффекта анимации:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) , который описывает тип анимации текста эффекта. Текст формы может быть анимирован:
  - Все сразу ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
  - По словам ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
  - По букве ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) тип)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) устанавливает задержку между анимированными частями текста (словами или буквами). Положительное значение указывает процент от продолжительности эффекта. Отрицательное значение указывает задержку в секундах.

Вот как вы можете изменить свойства анимации эффекта текста:

1. [Примените](#apply-animation-to-shape) или получите эффект анимации.
2. Установите свойство [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) на значение [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) , чтобы отключить режим анимации *По абзацам*.
3. Установите новые значения для свойств [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) и [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Сохраните измененный файл PPTX.

Этот код на C# демонстрирует операцию:

```c#
// Создает экземпляр класса презентации, который представляет собой файл презентации.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Получает первый эффект главной последовательности
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Изменяет тип анимации текста эффекта на "Как один объект"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Изменяет тип анимации текста эффекта на "По словам"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Устанавливает задержку между словами на 20% от длительности эффекта
    firstEffect.DelayBetweenTextParts = 20f;

    // Записывает файл PPTX на диск
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```