---
title: Сборка слайдов
type: docs
weight: 10
url: /ru/net/assemble-slides/
---

## **Добавить слайд в презентацию**
Пока мы обсуждаем добавление слайдов в файлы презентаций, давайте рассмотрим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит мастер/макетный слайд и другие обычные слайды. Это означает, что файл презентации содержит как минимум один или более слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides for .NET. Каждый слайд имеет уникальный Id, а все обычные слайды упорядочены в порядке, указанном нулевым индексом.

Aspose.Slides for .NET позволяет разработчикам добавлять пустые слайды в их презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса **Presentation**
- Создайте экземпляр класса **SlideCollection**, установив ссылку на свойство Slides (коллекция объектов Slide), предоставляемое объектом Presentation
- Добавьте пустой слайд в презентацию в конце коллекции слайдов контента, вызвав методы **AddEmptySlide**, предоставляемые объектом **SlideCollection**
- Выполните необходимые операции с только что добавленным пустым слайдом
- Наконец запишите файл презентации, используя объект **Presentation**

``` csharp
 PresentationEx pres = new PresentationEx();

 //Создать экземпляр класса SlideCollection
 SlideExCollection slds = pres.Slides;

 for (int i = 0; i < pres.LayoutSlides.Count; i++)
 {
     //Добавить пустой слайд в коллекцию Slides
     slds.AddEmptySlide(pres.LayoutSlides[i]);
 }

 //Сохранить файл PPTX на диск
 pres.Write("EmptySlide.pptx");
``` 
## **Доступ к слайдам презентации**
Aspose.Slides for .NET предоставляет класс Presentation, который можно использовать для поиска и доступа к любому нужному слайду в презентации.

**Использование коллекции Slides**

Класс **Presentation** представляет файл презентации и раскрывает все слайды в нём как коллекцию **SlideCollection** (это коллекция объектов **Slide**). Все эти слайды могут быть получены из этой коллекции **Slides** с использованием индекса слайда.

``` csharp
 //Создать объект Presentation, представляющий файл презентации
 PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

 //Получить слайд по его индексу
 SlideEx slide = pres.Slides[0];
``` 
## **Удалить слайды**
Мы знаем, что класс Presentation в **Aspose.Slides for .NET** представляет файл презентации. Класс Presentation инкапсулирует **SlideCollection**, который выступает в роли хранилища всех слайдов, входящих в презентацию. Разработчики могут удалить слайд из этой коллекции Slides двумя способами:

- Использование ссылки на слайд
- Использование индекса слайда

**Использование ссылки на слайд**

Чтобы удалить слайд, используя его ссылку, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его Id или Index
- Удалите ссылочный слайд из презентации
- Запишите изменённый файл презентации

``` csharp
 //Создать объект Presentation, представляющий файл презентации
 PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

 //Получить слайд по его индексу в коллекции слайдов
 SlideEx slide = pres.Slides[0];

 //Удалить слайд, используя его ссылку
 pres.Slides.Remove(slide);

 //Записать файл презентации
 pres.Write("modified.pptx");
``` 
## **Изменить позицию слайда**
Очень просто изменить позицию слайда в презентации. Просто выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его Index
- Измените свойство SlideNumber у выбранного слайда
- Запишите изменённый файл презентации

В приведённом ниже примере мы изменили позицию слайда (расположенного в позиции с нулевым индексом 1) презентации на индекс 1 (позиция 2).

``` csharp
 private static string MyDir = @"..\..\..\Sample Files\";
static void Main(string[] args)
{
    AddingSlidetoPresentation();
    AccessingSlidesOfPresentation();
    RemovingSlides();
    ChangingPositionOfSlide();
}

public static void AddingSlidetoPresentation()
{
    Presentation pres = new Presentation();

    //Создать экземпляр класса SlideCollection
    ISlideCollection slds = pres.Slides;

    for (int i = 0; i < pres.LayoutSlides.Count; i++)
    {
        //Добавить пустой слайд в коллекцию Slides
        slds.AddEmptySlide(pres.LayoutSlides[i]);
    }

    //Сохранить файл PPTX на диск
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

public static void AccessingSlidesOfPresentation()
{
    //Создать объект Presentation, представляющий файл презентации
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

    //Получить слайд по его индексу
    ISlide slide = pres.Slides[0];
}

public static void RemovingSlides()
{
    //Создать объект Presentation, представляющий файл презентации
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

    //Получить слайд по его индексу в коллекции слайдов
    ISlide slide = pres.Slides[0];

    //Удалить слайд, используя его ссылку
    pres.Slides.Remove(slide);

    //Сохранить файл презентации
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

public static void ChangingPositionOfSlide()
{
    //Создать объект Presentation для загрузки исходного файла презентации
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");
    {
        //Получить слайд, позицию которого нужно изменить
        ISlide sld = pres.Slides[0];

        //Установить новую позицию для слайда
        sld.SlideNumber = 2;

        //Сохранить презентацию на диск
        pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
    }
}
``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)