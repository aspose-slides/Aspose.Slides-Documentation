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
## **Введение**

Клонирование — это процесс создания точной копии или реплики чего‑то. Aspose.Slides также позволяет копировать (клонировать) любой слайд, а затем вставлять клонированный слайд в текущую презентацию или любую другую открытую презентацию. Клонирование слайда создаёт новый слайд, который разработчики могут изменять, не затрагивая оригинальный слайд. Существует несколько способов клонировать слайд:

- Клонировать в конец презентации.  
- Клонировать в другое положение внутри презентации.  
- Клонировать в конец другой презентации.  
- Клонировать в другое положение в другой презентации.  
- Клонировать вместе с его мастер‑слайдом в другую презентацию.  

В Aspose.Slides for .NET коллекция слайдов (коллекция объектов [ISlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/) ) , предоставляемая объектом [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) , предоставляет методы [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/addclone/) и [InsertClone](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/insertclone/) для выполнения описанных выше операций клонирования слайда.

## **Клонирование слайда в конец презентации**

Если нужно клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index) согласно шагам ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).  
2. Создайте объект [ISlideCollection], ссылаясь на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).  
3. Вызовите метод [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection), и передайте слайд, который требуется склонировать, в качестве параметра метода [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index).  
4. Сохраните изменённый файл презентации.  

В приведённом ниже примере мы склонировали слайд (расположенный на первой позиции — ноль‑индекс — в презентации) в конец презентации.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Клонируйте выбранный слайд в конец коллекции слайдов той же презентации
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Запишите изменённую презентацию на диск
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Клонирование слайда в другое положение внутри презентации**

Если нужно клонировать слайд и затем использовать его в том же файле презентации, но в другом месте, используйте метод [InsertClone](https://reference.aspose.com/slides/ru/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).  
2. Создайте объект, ссылаясь на коллекцию **Slides**, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).  
3. Вызовите метод [InsertClone](https://reference.aspose.com/slides/ru/net/aspose.slides.ishapecollection/insertclone/methods/1), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection), и передайте слайд, который требуется склонировать, вместе с индексом новой позиции в качестве параметра метода [InsertClone](https://reference.aspose.com/slides/ru/net/aspose.slides.ishapecollection/insertclone/methods/1).  
4. Сохраните изменённую презентацию в формате PPTX.  

В приведённом ниже примере мы склонировали слайд (расположенный по индексу 1 — позиция 2 в презентации) в индекс 2 — позиция 3 презентации.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Клонируйте выбранный слайд в конец коллекции слайдов той же презентации
    ISlideCollection slds = pres.Slides;

    // Клонируйте выбранный слайд в указанный индекс в той же презентации
    slds.InsertClone(2, pres.Slides[1]);

    // Запишите изменённую презентацию на диск
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Клонирование слайда в конец другой презентации**

Если нужно клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), содержащего презентацию, из которой будет клонирован слайд.  
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), содержащего целевую презентацию, в которую будет добавлен слайд.  
3. Создайте объект [ISlideCollection], ссылаясь на коллекцию **Slides**, предоставляемую объектом Presentation целевой презентации.  
4. Вызовите метод [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации в качестве параметра метода [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index).  
5. Сохраните изменённый файл целевой презентации.  

В приведённом ниже примере мы склонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {
        // Клонируйте выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Сохраните целевую презентацию на диск
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Клонирование слайда в другое положение в другой презентации**

Если нужно клонировать слайд из одной презентации и использовать его в другой презентации в конкретном положении:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), содержащего исходную презентацию, из которой будет клонирован слайд.  
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), содержащего презентацию, в которую будет добавлен слайд.  
3. Создайте объект [ISlideCollection], ссылаясь на коллекцию Slides, предоставляемую объектом Presentation целевой презентации.  
4. Вызовите метод [InsertClone](https://reference.aspose.com/slides/ru/net/aspose.slides.ishapecollection/insertclone/methods/1), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации вместе с требуемой позицией в качестве параметра метода [InsertClone](https://reference.aspose.com/slides/ru/net/aspose.slides.ishapecollection/insertclone/methods/1).  
5. Сохраните изменённый файл целевой презентации.  

В приведённом ниже примере мы склонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Сохраните целевую презентацию на диск
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Клонирование слайда вместе с его мастер‑слайдом в другую презентацию**

Если нужно клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой, сначала необходимо клонировать требуемый мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд для клонирования слайда с мастер‑слайдом. Метод **AddClone(ISlide, IMasterSlide)** ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), содержащего исходную презентацию, из которой будет клонирован слайд.  
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), содержащего целевую презентацию, в которую будет клонирован слайд.  
3. Получите доступ к клонируемому слайду вместе с его мастер‑слайдом.  
4. Создайте объект [IMasterSlideCollection], ссылаясь на коллекцию Masters, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) целевой презентации.  
5. Вызовите метод [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [IMasterSlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection), и передайте мастер‑слайд из исходного PPTX в качестве параметра метода [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index).  
6. Создайте объект [ISlideCollection], установив ссылку на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation) целевой презентации.  
7. Вызовите метод [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index), предоставляемый объектом [ISlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection), и передайте слайд из исходной презентации, который нужно клонировать, и мастер‑слайд в качестве параметров метода [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index).  
8. Сохраните изменённый файл целевой презентации.  

В приведённом ниже примере мы склонировали слайд вместе с мастер‑слайдом (расположенный в нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создайте экземпляр класса Presentation для загрузки исходного файла презентации

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Создайте экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    using (Presentation destPres = new Presentation())
    {

        // Получите ISlide из коллекции слайдов исходной презентации
        // Мастер‑слайд
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров
        // целевой презентации
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров
        // целевой презентации
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Клонировать нужный слайд из исходной презентации с нужным мастер‑слайдом в конец
        // коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров в целевой презентации
        // Сохраните целевую презентацию на диск
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Клонирование слайда в конец указанного раздела**

С помощью Aspose.Slides for .NET можно клонировать слайд из одного раздела презентации и вставить его в другой раздел той же презентации. В этом случае необходимо использовать метод [AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/methods/addclone/index) из интерфейса [ISlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection).

Следующий код C# демонстрирует, как клонировать слайд и вставить его в указанный раздел:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Обеспечение соответствующего размера слайда**

При клонировании слайдов в другую презентацию убедитесь, что у целевой презентации такой же размер слайда, как у исходной. Если размеры слайдов различаются, Aspose.Slides не масштабирует автоматически склонированные фигуры — их исходные координаты и размеры сохраняются, что может привести к смещению содержимого или выходу за пределы слайда.

Перед клонированием мастер‑слайда и слайда можно установить размер слайда целевой презентации, соответствующий исходному:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Сделайте это до клонирования мастер‑слайда и слайда.

## **FAQ**

**Клонируются ли заметки выступающего и комментарии рецензентов?**

Да. Страница заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/net/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/net/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Можно ли управлять позицией вставки и разделами для клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и поместить его в выбранный [раздел](/slides/ru/net/slide-section/). Если целевой раздел не существует, создайте его сначала, а затем переместите слайд в него.