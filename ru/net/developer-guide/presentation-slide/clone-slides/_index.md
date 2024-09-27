---
title: Клонирование слайдов
type: docs
weight: 40
url: /ru/net/clone-slides/
keywords: "Клонировать слайд, Копировать слайд, Сохранить копию слайда, PowerPoint, Презентация, C#, Csharp, .NET, Aspose.Slides"
description: "Клонирование слайдов PowerPoint на C# или .NET"
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего-либо. Aspose.Slides для .NET также позволяет создавать копию или клонировать любой слайд и затем вставлять этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайдов создает новый слайд, который может быть изменен разработчиками без изменения оригинального слайда. Существует несколько возможных способов клонирования слайда:

- Клонировать в конец в рамках презентации.
- Клонировать в другое положение в рамках презентации.
- Клонировать в конец в другой презентации.
- Клонировать в другое положение в другой презентации.
- Клонировать в определенное положение в другой презентации.

В Aspose.Slides для .NET (коллекция объектов [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)), предоставляемая объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержит методы [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) и [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) для выполнения вышеуказанных типов клонирования слайдов.
## **Клонировать в конец в рамках презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) согласно приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд, который необходимо клонировать, в качестве параметра метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Сохраните измененный файл презентации.

В приведенном ниже примере мы клонировали слайд (стоящий на первом месте — нулевой индекс — презентации) в конец презентации.

```c#
// Создание экземпляра класса Presentation, который представляет файл презентации
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Клонирование нужного слайда в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Запись измененной презентации на диск
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Клонировать в другое положение в рамках презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом положении, используйте метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Создайте экземпляр класса, ссылающегося на коллекцию **Slides**, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Вызовите метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд, который необходимо клонировать, вместе с индексом для нового положения в качестве параметра метода [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Сохраните измененную презентацию в файле PPTX.

В приведенном ниже примере мы клонировали слайд (стоящий на нулевом индексе — позиция 1 — презентации) в индекс 1 — позиция 2 — презентации.

```c#
// Создание экземпляра класса Presentation, который представляет файл презентации
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Клонирование нужного слайда в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.Slides;

    // Клонирование нужного слайда на указанном индексе в той же презентации
    slds.InsertClone(2, pres.Slides[1]);

    // Запись измененной презентации на диск
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Клонировать в конец в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего целевую презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию **Slides**, предоставляемую объектом Presentation целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации в качестве параметра метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Сохраните измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд (с первого индекса исходной презентации) в конец целевой презентации.

```c#
// Создание экземпляра класса Presentation для загрузки исходного файла презентации
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Создание экземпляра класса Presentation для целевой PPTX (куда слайд будет клонирован)
    using (Presentation destPres = new Presentation())
    {
        // Клонирование нужного слайда из исходной презентации в конец коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Запись целевой презентации на диск
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Клонировать в другое положение в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в определенное положение:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего исходную презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию Slides, предоставляемую объектом Presentation целевой презентации.
1. Вызовите метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметра метода [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Сохраните измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд (с нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```c#
// Создание экземпляра класса Presentation для загрузки исходного файла презентации
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Создание экземпляра класса Presentation для целевой PPTX (куда слайд будет клонирован)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Запись целевой презентации на диск
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Клонировать в определенное положение в другой презентации**
Если вам нужно клонировать слайд с мастер-слайдом из одной презентации и использовать его в другой презентации, вам нужно сначала клонировать нужный мастер-слайд из исходной презентации в целевую презентацию. Затем вам необходимо использовать этот мастер-слайд для клонирования слайда с мастер-слайдом. Метод **AddClone(ISlide, IMasterSlide)** ожидает мастер-слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер-слайдом, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего исходную презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего целевую презентацию, в которую будет клонирован слайд.
1. Получите слайд, который необходимо клонировать вместе с мастер-слайдом.
1. Создайте экземпляр класса [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), ссылку на коллекцию мастеров, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), и передайте мастер из исходного PPTX, который нужно клонировать, в качестве параметра метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), установив ссылку на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) целевой презентации.
1. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации, который необходимо клонировать, и мастер-слайд в качестве параметра для метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Сохраните измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд с мастер-слайдом (стоящий на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер из исходного слайда.

```c#
// Создание экземпляра класса Presentation для загрузки исходного файла презентации

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Создание экземпляра класса Presentation для целевой презентации (куда слайд будет клонирован)
    using (Presentation destPres = new Presentation())
    {

        // Создание экземпляра ISlide из коллекции слайдов в исходной презентации вместе с
        // Мастер-слайдом
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Клонирование нужного мастер-слайда из исходной презентации в коллекцию мастеров в
        // Целевой презентации
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Клонирование нужного мастер-слайда из исходной презентации в коллекцию мастеров в
        // Целевой презентации
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Клонирование нужного слайда из исходной презентации с нужным мастером в конец
        // Коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Клонирование нужного мастер-слайда из исходной презентации в коллекцию мастеров в
        // Целевой презентации
        // Сохранение целевой презентации на диск
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```



## Клонировать в конец в указанном разделе

С помощью Aspose.Slides для .NET вы можете клонировать слайд из одного раздела презентации и вставить этот слайд в другой раздел в той же презентации. В этом случае вам нужно использовать метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) из интерфейса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

Эта C# программа показывает, как клонировать слайд и вставить клонированный слайд в указанный раздел:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // для клонирования
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```