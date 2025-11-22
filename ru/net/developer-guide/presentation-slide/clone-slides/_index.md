---
title: Клонирование слайдов
type: docs
weight: 40
url: /ru/net/clone-slides/
keywords: "Клонировать слайд, Копировать слайд, Сохранить копию слайда, PowerPoint, Презентация, C#, Csharp, .NET, Aspose.Slides"
description: "Клонирование слайда PowerPoint на C# или .NET"
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for .NET также позволяет создать копию или клон любого слайда и затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который можно изменять разработчикам, не меняя оригинальный слайд. Существует несколько способов клонирования слайда:

- Клонирование в конце внутри презентации.  
- Клонирование в другой позиции внутри презентации.  
- Клонирование в конце в другой презентации.  
- Клонирование в другой позиции в другой презентации.  
- Клонирование в определённой позиции в другой презентации.  

В Aspose.Slides for .NET (коллекция объектов [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)), предоставляемая объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), предоставляет методы [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) и [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) для выполнения указанных выше типов клонирования слайдов.

## **Клонирование в конце внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) согласно перечисленным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
3. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте в него слайд, который следует клонировать, в качестве параметра метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
4. Сохраните изменённый файл презентации.

В приведённом ниже примере мы клонировали слайд (находящийся на первой позиции – нулевой индекс – презентации) в конец презентации.
```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Клонируйте нужный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Сохраните изменённую презентацию на диск
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **Клонирование в другой позиции внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом месте, используйте метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Создайте экземпляр, ссылаясь на коллекцию **Slides**, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
3. Вызовите метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте в него слайд, который следует клонировать, вместе с индексом новой позиции в качестве параметра метода [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
4. Сохраните изменённую презентацию в формате PPTX.

В приведённом ниже примере мы клонировали слайд (находящийся на нулевом индексе – позиция 1 – презентации) в индекс 1 – позицию 2 – презентации.
```c#
// Создайте экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Клонируйте нужный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.Slides;

    // Клонируйте нужный слайд в указанный индекс в той же презентации
    slds.InsertClone(2, pres.Slides[1]);

    // Сохраните изменённую презентацию на диск
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **Клонирование в конце в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий целевую презентацию, в которую будет добавлен слайд.
3. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию **Slides**, предоставляемую объектом Presentation целевой презентации.
4. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте в него слайд из исходной презентации в качестве параметра метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
5. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.
```c#
// Создайте объект класса Presentation для загрузки исходного файла презентации
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Создайте объект класса Presentation для конечного PPTX (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {
        // Клонировать нужный слайд из исходной презентации в конец коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Сохранить целевую презентацию на диск
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Клонирование в другой позиции в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации в определённой позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий презентацию, в которую будет добавлен слайд.
3. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), ссылаясь на коллекцию Slides, предоставляемую объектом Presentation целевой презентации.
4. Вызовите метод [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте в него слайд из исходной презентации вместе с желаемой позицией в качестве параметра метода [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
5. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.
```c#
// Создайте объект класса Presentation для загрузки исходного файла презентации
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Создайте объект класса Presentation для целевого PPTX (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Сохраните целевую презентацию на диск
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **Клонирование в определённой позиции в другой презентации**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать нужный мастер‑слайд из исходной презентации в целевую. Затем следует использовать этот мастер‑слайд для клонирования слайда с мастер‑слайдом. Метод **AddClone(ISlide, IMasterSlide)** ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), содержащий целевую презентацию, в которую будет клонироваться слайд.
3. Получите доступ к слайду, который будет клонироваться, вместе с мастер‑слайдом.
4. Создайте экземпляр класса [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), ссылаясь на коллекцию Masters, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) целевой презентации.
5. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), и передайте в него мастер‑слайд из исходного PPTX в качестве параметра метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
6. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), задав ссылку на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) целевой презентации.
7. Вызовите метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), и передайте в него слайд из исходной презентации, который необходимо клонировать, и мастер‑слайд в качестве параметра метода [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
8. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд с мастер‑слайдом (находящийся на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.
```c#
// Создайте объект класса Presentation для загрузки исходного файла презентации

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Создайте объект класса Presentation для целевой презентации (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {

        // Создайте объект ISlide из коллекции слайдов в исходной презентации вместе с
        // мастер‑слайдом
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Клонировать нужный слайд из исходной презентации с нужным мастером в конец
        // коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров в // целевой презентации
        // Сохранить целевую презентацию на диск
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **Клонирование в конце в указанном разделе**
С помощью Aspose.Slides for .NET можно клонировать слайд из одного раздела презентации и вставить его в другой раздел той же презентации. В этом случае необходимо использовать метод [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) из интерфейса [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

Этот код на C# показывает, как клонировать слайд и вставить клонированный слайд в указанный раздел:
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

**Клонируются ли заметки докладчика и комментарии рецензентов?**

Да. Страницы заметок и комментарии рецензентов включаются в клон. Если вы не хотите их, [удалите их](/slides/ru/net/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/net/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Могу ли я управлять позицией вставки и разделами клона?**

Да. Вы можете вставить клон в определённый индекс слайда и разместить его в выбранном [разделе](/slides/ru/net/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд туда.