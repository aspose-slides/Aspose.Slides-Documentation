---
title: Переход между слайдами
type: docs
weight: 90
url: /net/slide-transition/
keywords: "Добавить переход между слайдами, переход слайда PowerPoint, морфинг, продвинутый переход между слайдами, эффекты перехода, C#, Csharp, .NET, Aspose.Slides"
description: "Добавьте переход между слайдами PowerPoint и эффекты перехода на C# или .NET"
---

## **Добавить переход между слайдами**
Чтобы облегчить понимание, мы продемонстрировали использование Aspose.Slides для .NET для управления простыми переходами между слайдами. Разработчики могут не только применять различные эффекты перехода между слайдами, но и настраивать поведение этих эффектов перехода. Чтобы создать простой эффект перехода между слайдами, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Примените тип перехода к слайду из одного из эффектов перехода, предлагаемых Aspose.Slides для .NET, через перечисление TransitionType.
1. Запишите изменённый файл презентации.

```c#
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Примените переход типа круг на слайд 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Примените переход типа гребешок на слайд 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Запишите презентацию на диск
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **Добавить продвинутый переход между слайдами**
В предыдущем разделе мы просто применили простой эффект перехода на слайд. Теперь, чтобы сделать этот простой эффект перехода еще лучше и более управляемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Примените тип перехода к слайду из одного из эффектов перехода, предлагаемых Aspose.Slides для .NET.
1. Вы также можете установить переход на "Продвигать по клику", после определенного времени или и то, и другое.
1. Если переход между слайдами настроен на "Продвигать по клику", переход будет осуществляться только при нажатии мыши. Более того, если установлено свойство "Продвигать после времени", переход будет автоматически осуществляться после истечения заданного времени.
1. Запишите изменённую презентацию как файл презентации.

```c#
// Создайте экземпляр класса Presentation, который представляет файл презентации
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Примените переход типа круг на слайд 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Установите время перехода на 3 секунды
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Примените переход типа гребешок на слайд 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Установите время перехода на 5 секунд
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Примените переход типа приближение на слайд 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Установите время перехода на 7 секунд
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Запишите презентацию на диск
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Кроме того, используя свойство [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/), вы можете проверить, настроен ли переход слайда на переход к следующему слайду или отключить эту настройку.

Этот код C# демонстрирует работу:

```c#
// Создаёт экземпляр класса Presentation, который представляет файл презентации
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Получает переход слайда
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Проверяет, включена ли настройка "Продвигать после времени"
        if (slideTransition.AdvanceAfter)
        {
            // Выводит значение "Продвигать после времени"
            Console.WriteLine("Слайд #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Отключает переход после определенного времени, если значение AdvancedAfterTime больше 2 секунд
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Переход морфинг**
Aspose.Slides для .NET теперь поддерживает [Переход морфинг](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). Это новый эффект морфинга, введенный в PowerPoint 2019. Переход морфинга позволяет анимировать плавное движение от одного слайда к следующему. Эта статья описывает концепцию и то, как использовать переход морфинг. Чтобы эффективно использовать переход морфинг, вам нужно иметь два слайда с по крайней мере одним общим объектом. Самый простой способ - это дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с текстом в презентацию и установить переход типа [mорфинг](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) к другому слайду.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Переход морфинг в презентациях PowerPoint";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Типы перехода морфинг**
Добавлено новое перечисление [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype), представляющее различные типы перехода морфинг.

Перечисление TransitionMorphType имеет три члена:

- ByObject: Переход морфинг будет выполняться с учетом фигур как неделимых объектов.
- ByWord: Переход морфинг будет выполняться с передачей текста по словам, где это возможно.
- ByChar: Переход морфинг будет выполняться с передачей текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить переход морфинг для слайда и изменить тип морфинга:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```



## **Установить эффекты перехода**
Aspose.Slides для .NET поддерживает установку эффектов перехода, таких как, из черного, слева, справа и т.д. Чтобы установить эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд.
- Настройте эффект перехода.
- Запишите презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

В приведённом ниже примере мы задали эффекты перехода.

```c#
// Создайте экземпляр класса Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Установите эффект
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Запишите презентацию на диск
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```