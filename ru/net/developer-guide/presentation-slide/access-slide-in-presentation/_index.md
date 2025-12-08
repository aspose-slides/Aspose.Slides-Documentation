---
title: Доступ к слайду в презентации
type: docs
weight: 20
url: /ru/net/access-slide-in-presentation/
keywords: "Доступ к презентации PowerPoint, Доступ к слайду, Редактирование свойств слайда, Изменение позиции слайда, Установка номера слайда, индекс, ID, позиция C#, Csharp, .NET, Aspose.Slides"
description: "Доступ к слайду PowerPoint по индексу, ID или позиции в C# или .NET. Редактирование свойств слайда"
---

Aspose.Slides позволяет получать доступ к слайдам двумя способами: по индексу и по идентификатору.

## **Доступ к слайду по индексу**

Все слайды в презентации упорядочены численно в соответствии с позицией слайда, начиная с 0. Первый слайд доступен по индексу 0; второй слайд — по индексу 1; и т.д.

Класс Presentation, представляющий файл презентации, раскрывает все слайды как коллекцию [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (коллекцию объектов [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)). Этот код на C# показывает, как получить доступ к слайду по его индексу:
```c#
// Создает объект Presentation, представляющий файл презентации
Presentation presentation = new Presentation("AccessSlides.pptx");

// Получает ссылку на слайд через его индекс
ISlide slide = presentation.Slides[0];
```


## **Доступ к слайду по идентификатору**

Каждый слайд в презентации имеет уникальный идентификатор. Вы можете использовать метод [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (предоставляемый классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) для получения слайда по этому ID. Этот код на C# показывает, как указать действительный ID слайда и получить доступ к этому слайду через метод [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid):
```c#
// Создает объект Presentation, представляющий файл презентации
Presentation presentation = new Presentation("AccessSlides.pptx");

// Получает ID слайда
uint id = presentation.Slides[0].SlideId;

// Доступ к слайду через его ID
IBaseSlide slide = presentation.GetSlideById(id);
```


## **Изменение позиции слайда**

Aspose.Slides позволяет изменять позицию слайда. Например, вы можете указать, что первый слайд должен стать вторым слайдом.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд (позицию которого вы хотите изменить) по его индексу.
1. Установите новую позицию для слайда с помощью свойства [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/).
1. Сохраните изменённую презентацию.

Этот код на C# демонстрирует операцию, при которой слайд в позиции 1 перемещается в позицию 2:
```c#
// Создает объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Получает слайд, позицию которого нужно изменить
    ISlide sld = pres.Slides[0];

    // Устанавливает новую позицию для слайда
    sld.SlideNumber = 2;

    // Сохраняет изменённую презентацию
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```


Первый слайд стал вторым; второй слайд стал первым. При изменении позиции слайда остальные слайды автоматически корректируются.

## **Установка номера слайда**

С помощью свойства [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (предоставляемого классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) вы можете задать новый номер для первого слайда в презентации. Эта операция приводит к пересчету номеров остальных слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите номер слайда.
1. Установите номер слайда.
1. Сохраните изменённую презентацию.

Этот код на C# демонстрирует операцию, при которой номер первого слайда установлен в 10:
```c#
// Создаёт объект Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Получает номер слайда
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Устанавливает номер слайда
    presentation.FirstSlideNumber=10;
    
    // Сохраняет изменённую презентацию
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```


Если вы хотите пропустить первый слайд, вы можете начать нумерацию со второго слайда (и скрыть нумерацию для первого слайда) следующим образом:
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Устанавливает номер для первого слайда презентации
    presentation.FirstSlideNumber = 0;

    // Отображает номера слайдов для всех слайдов
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Скрывает номер слайда для первого слайда
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Сохраняет изменённую презентацию
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Совпадает ли номер слайда, отображаемый пользователем, с нулевой индексацией коллекции?**

Номер, отображаемый на слайде, может начинаться с произвольного значения (например, 10) и не обязан совпадать с индексом; взаимосвязь управляется настройкой [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) презентации.

**Влияют ли скрытые слайды на индексацию?**

Да. Скрытый слайд остаётся в коллекции и учитывается при индексации; «скрытый» относится к отображению, а не к его позиции в коллекции.

**Изменяется ли индекс слайда при добавлении или удалении других слайдов?**

Да. Индексы всегда отражают текущий порядок слайдов и пересчитываются при операциях вставки, удаления и перемещения.