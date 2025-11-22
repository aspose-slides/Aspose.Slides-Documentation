---
title: Переход слайда
type: docs
weight: 90
url: /ru/net/slide-transition/
keywords: "Добавить переход слайда, переход слайда PowerPoint, морф‑переход, расширенный переход слайда, эффекты перехода, C#, Csharp, .NET, Aspose.Slides"
description: "Добавить переход слайда PowerPoint и эффекты перехода в C# или .NET"
---

## **Добавить переход слайда**
Чтобы упростить понимание, мы продемонстрировали использование Aspose.Slides for .NET для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты перехода на слайдах, но и настраивать поведение этих эффектов. Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Примените тип Slide Transition Type к слайду, выбрав один из эффектов перехода, предлагаемых Aspose.Slides for .NET, через перечисление TransitionType.
1. Запишите измененный файл презентации.
```c#
// Создать объект класса Presentation для загрузки исходного файла презентации
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Применить переход типа circle на слайде 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Применить переход типа comb на слайде 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Сохранить презентацию на диск
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **Добавить расширенный переход слайда**
В предыдущем разделе мы применили простой эффект перехода к слайду. Теперь, чтобы сделать этот простой эффект более мощным и контролируемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Примените тип Slide Transition Type к слайду, выбрав один из эффектов перехода, предлагаемых Aspose.Slides for .NET.
1. Вы также можете установить переход на Advance On Click, после определённого периода времени или на оба варианта.
1. Если переход слайда включён для Advance On Click, он будет происходить только при щелчке мышью. Кроме того, если свойство Advance After Time установлено, переход будет происходить автоматически после истечения указанного времени.
1. Запишите изменённую презентацию в файл презентации.
```c#
// Создать объект класса Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Применить переход типа circle на слайде 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Установить время перехода в 3 секунды
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Применить переход типа comb на слайде 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Установить время перехода в 5 секунд
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Применить переход типа zoom на слайде 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Установить время перехода в 7 секунд
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Сохранить презентацию на диск
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


Кроме того, используя свойство [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/), вы можете проверить, настроен ли переход слайда для перехода к следующему слайду или отключён.

Этот код на C# демонстрирует работу:
```c#
// Создаёт объект класса Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Получает переход слайда
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Проверяет, включена ли настройка Advance After Time
        if (slideTransition.AdvanceAfter)
        {
            // Выводит значение Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Отключает переход после определённого времени, если значение AdvanceAfterTime больше 2 секунд
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```


## **Переход Morph**
Aspose.Slides for .NET теперь поддерживает [Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). Это новый тип перехода, представленный в PowerPoint 2019. Переход Morph позволяет анимировать плавное перемещение от одного слайда к следующему. В этой статье описывается концепция и способы использования перехода Morph. Чтобы эффективно использовать Morph, вам понадобится две презентации с хотя бы одним общим объектом. Самый простой способ — дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с некоторым текстом в презентацию и установить переход [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) для второго слайда.
```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Типы перехода Morph**
Добавлен новый перечисление [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype). Оно представляет различные типы переходов Morph.

Перечисление TransitionMorphType имеет три члена:

- ByObject: переход Morph будет выполнен с учётом фигур как неделимых объектов.
- ByWord: переход Morph будет выполнен с переносом текста по словам, где это возможно.
- ByChar: переход Morph будет выполнен с переносом текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить переход Morph для слайда и изменить тип Morph:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Установить эффекты перехода**
Aspose.Slides for .NET поддерживает установку эффектов перехода, таких как «из чёрного», «слева», «справа» и т.д. Чтобы задать эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

В приведённом ниже примере мы задали эффекты перехода.
```c#
// Создать экземпляр класса Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Установить эффект
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Сохранить презентацию на диск
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Могу ли я контролировать скорость воспроизведения перехода слайда?**

Да. Установите параметр скорости перехода через [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) с помощью настройки [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) (например, медленно/средне/быстро).

**Можно ли привязать звук к переходу и заставить его зацикливаться?**

Да. Вы можете внедрить звук для перехода и управлять его поведением через параметры, такие как [Sound](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundloop/), а также метаданные, такие как [SoundIsBuiltIn](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) и [SoundName](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundname/).

**Как самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одного и того же типа ко всем слайдам даст одинаковый результат.

**Как проверить, какой переход сейчас установлен на слайде?**

Изучите [параметры перехода](https://reference.aspose.com/slides/net/aspose.slides/baseslide/slideshowtransition/) слайда и прочитайте его [тип перехода](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/type/); это значение точно указывает, какой эффект применён.