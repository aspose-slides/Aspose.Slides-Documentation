---
title: Клонирование слайдов презентации в .NET
linktitle: Клонировать слайды
type: docs
weight: 40
url: /ru/net/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранить слайд
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides для .NET. Следуйте нашим понятным примерам кода, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for .NET также позволяет создать копию или клон любого слайда и затем вставить этот клон в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который разработчики могут изменять, не меняя исходный слайд. Существует несколько способов клонировать слайд:

- Клонировать в конец в пределах текущей презентации.
- Клонировать в другое положение в пределах презентации.
- Клонировать в конец в другой презентации.
- Клонировать в другое положение в другой презентации.
- Клонировать в указанное положение в другой презентации.

В Aspose.Slides for .NET (коллекция объектов [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)), доступная через объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), предоставляет методы [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) и [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) для выполнения указанных типов клонирования слайдов
## **Клонирование слайда в конец презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) согласно перечисленным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Создайте объект [ISlideCollection], ссылаясь на коллекцию Slides, доступную через объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Вызовите метод [AddClone], доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд, который нужно клонировать, в качестве параметра методу [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Сохраните изменённый файл презентации.

В приведённом ниже примере мы клонировали слайд (находящийся на первой позиции — индекс 0 — презентации) в конец презентации.
```c#
// Создать экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Клонировать нужный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Сохранить изменённую презентацию на диск
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Клонирование слайда в другое положение в пределах презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом положении, используйте метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Создайте объект, ссылаясь на коллекцию **Slides**, доступную через объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Вызовите метод [InsertClone], доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд, который нужно клонировать, вместе с индексом новой позиции в качестве параметра методу [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Сохраните изменённую презентацию в формате PPTX.

В приведённом ниже примере мы клонировали слайд (находящийся на индексе 0 — позиция 1 — презентации) в индекс 1 — позиция 2 — презентации.
```c#
// Создать экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Клонировать нужный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.Slides;

    // Клонировать нужный слайд в указанный индекс в той же презентации
    slds.InsertClone(2, pres.Slides[1]);

    // Сохранить изменённую презентацию на диск
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Клонирование слайда в конец другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего целевую презентацию, в которую будет добавлен слайд.
1. Создайте объект [ISlideCollection], ссылаясь на коллекцию **Slides**, доступную через объект Presentation целевой презентации.
1. Вызовите метод [AddClone], доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации в качестве параметра методу [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.
```c#
// Создать экземпляр класса Presentation для загрузки исходного файла презентации
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {
        // Клонировать нужный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Сохранить целевую презентацию на диск
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Клонирование слайда в другое положение в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в указанном положении:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего презентацию, в которую будет добавлен слайд.
1. Создайте объект [ISlideCollection], ссылаясь на коллекцию Slides, доступную через объект Presentation целевой презентации.
1. Вызовите метод [InsertClone], доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметра методу [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.
```c#
// Создать экземпляр класса Presentation для загрузки исходного файла презентации
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Сохранить целевую презентацию на диск
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Клонирование слайда в указанное положение в другой презентации**
Если вам необходимо клонировать слайд с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать нужный мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд для клонирования слайда с мастер‑слайдом. Метод **AddClone(ISlide, IMasterSlide)** ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащего целевую презентацию, в которую будет клонироваться слайд.
1. Доступ к слайду, который будет клонироваться, вместе с мастер‑слайдом.
1. Создайте объект [IMasterSlideCollection], ссылаясь на коллекцию Masters, доступную через объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) целевой презентации.
1. Вызовите метод [AddClone], доступный у объекта [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), и передайте мастер‑слайд из исходного PPTX в качестве параметра методу [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Создайте объект [ISlideCollection], ссылаясь на коллекцию Slides, доступную через объект [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) целевой презентации.
1. Вызовите метод [AddClone], доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации вместе с мастер‑слайдом в качестве параметра методу [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд с мастер‑слайдом (находящийся на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.
```c#
// Создать экземпляр класса Presentation для загрузки исходного файла презентации

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Создать экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {

        // Создать объект ISlide из коллекции слайдов исходной презентации вместе с
        // Мастер‑слайдом
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастер‑слайдов в
        // Целевой презентации
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастер‑слайдов в
        // Целевой презентации
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Клонировать нужный слайд из исходной презентации с нужным мастер‑слайдом в конец
        // Коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастер‑слайдов в // Целевой презентации
        // Сохранить целевую презентацию на диск
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **Клонирование слайда в конец указанного раздела**
С помощью Aspose.Slides for .NET можно клонировать слайд из одного раздела презентации и вставить его в другой раздел той же презентации. В этом случае необходимо использовать метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) из интерфейса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

Этот код C# демонстрирует, как клонировать слайд и вставить клонированный слайд в указанный раздел:
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


## **FAQ**

**Клонируются ли заметки выступающего и комментарии рецензента?**

Да. Страницы заметок и комментарии включаются в клон. Если они не нужны, [удалить их](/slides/ru/net/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, его форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/net/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Могу ли я управлять позицией вставки и разделами для клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и разместить его в выбранном [разделе](/slides/ru/net/slide-section/). Если целевой раздел не существует, создайте его сначала и затем переместите слайд в него.