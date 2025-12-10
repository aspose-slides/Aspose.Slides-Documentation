---
title: Доступ к слайдам презентации в .NET
linktitle: Доступ к слайду
type: docs
weight: 20
url: /ru/net/access-slide-in-presentation/
keywords:
- доступ к слайду
- индекс слайда
- идентификатор слайда
- позиция слайда
- изменить позицию
- свойства слайда
- номер слайда
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как получать доступ и управлять слайдами в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Повышайте продуктивность с примерами кода."
---

Aspose.Slides позволяет получать доступ к слайдам двумя способами: по индексу и по идентификатору.

## **Доступ к слайду по индексу**

Все слайды в презентации упорядочены численно в соответствии с позицией слайда, начиная с 0. Первый слайд доступен через индекс 0; второй слайд — через индекс 1; и т.д.

Класс Presentation, представляющий файл презентации, раскрывает все слайды как коллекцию [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (коллекцию объектов [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)). Этот код на C# показывает, как получить доступ к слайду по его индексу:
```c#
// Создаёт объект Presentation, представляющий файл презентации
Presentation presentation = new Presentation("AccessSlides.pptx");

// Получает ссылку на слайд через его индекс
ISlide slide = presentation.Slides[0];
```


## **Доступ к слайду по идентификатору**

У каждого слайда в презентации есть уникальный идентификатор. Вы можете использовать метод [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (предоставляемый классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) для указания этого идентификатора. Этот код на C# показывает, как задать действительный идентификатор слайда и получить доступ к этому слайду через метод [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid):
```c#
// Создаёт объект Presentation, представляющий файл презентации
Presentation presentation = new Presentation("AccessSlides.pptx");

// Получает идентификатор слайда
uint id = presentation.Slides[0].SlideId;

// Получает доступ к слайду по его идентификатору
IBaseSlide slide = presentation.GetSlideById(id);
```


## **Изменить позицию слайда**

Aspose.Slides позволяет изменить позицию слайда. Например, вы можете указать, что первый слайд должен стать вторым.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд (позицию которого вы хотите изменить) через его индекс.
1. Установите новую позицию для слайда через свойство [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/).
1. Сохраните изменённую презентацию.

Этот код на C# демонстрирует операцию, при которой слайд в позиции 1 перемещается в позицию 2:
```c#
// Создаёт объект Presentation, представляющий файл презентации
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

## **Установить номер слайда**

С помощью свойства [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (предоставляемого классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) вы можете задать новый номер для первого слайда в презентации. Эта операция приводит к пересчёту номеров остальных слайдов.

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

    // Устанавливает номер первого слайда презентации
    presentation.FirstSlideNumber = 0;

    // Отображает номера слайдов для всех слайдов
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Скрывает номер слайда для первого слайда
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Сохраняет изменённую презентацию
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Вопросы и ответы**

**Совпадает ли номер слайда, который видит пользователь, с нулевым индексом в коллекции?**

Номер, отображаемый на слайде, может начинаться с произвольного значения (например, 10) и не обязательно совпадает с индексом; взаимосвязь контролируется настройкой [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) презентации.

**Влияют ли скрытые слайды на индексацию?**

Да. Скрытый слайд остаётся в коллекции и учитывается при индексации; «скрытый» относится к отображению, а не к его позиции в коллекции.

**Изменяется ли индекс слайда, когда добавляются или удаляются другие слайды?**

Да. Индексы всегда отражают текущий порядок слайдов и пересчитываются при вставке, удалении и перемещении.