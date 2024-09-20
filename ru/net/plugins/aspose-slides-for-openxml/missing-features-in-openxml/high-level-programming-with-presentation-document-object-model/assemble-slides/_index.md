---
title: Собрать Слайды
type: docs
weight: 10
url: /net/sobrat-slidy/
---

Он охватывает следующие функции:
## **Добавление слайда в презентацию**
Прежде чем говорить о добавлении слайдов в презентационные файлы, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит мастер / макет слайд и другие обычные слайды. Это означает, что файл презентации содержит как минимум один или несколько слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides для .NET. Каждый слайд имеет уникальный идентификатор, и все обычные слайды упорядочены в соответствии с индексом, основанным на нуле.

Aspose.Slides для .NET позволяет разработчикам добавлять пустые слайды в свою презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса **Presentation**
- Создайте экземпляр класса **SlideCollection**, установив ссылку на свойство Slides (коллекция объектов слайдов содержимого), предоставляемое объектом Presentation.
- Добавьте пустой слайд в презентацию в конце коллекции слайдов содержимого, вызвав метод **AddEmptySlide**, предоставляемый объектом **SlideCollection**
- Выполните некоторые действия с недавно добавленным пустым слайдом
- Наконец, запишите файл презентации, используя объект **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

// Создайте экземпляр класса SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	// Добавьте пустой слайд в коллекцию Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

// Сохраните файл PPTX на диск

pres.Write("EmptySlide.pptx");

``` 
## **Доступ к слайдам презентации**
Aspose.Slides для .NET предоставляет класс Presentation, который можно использовать для поиска и доступа к любому желаемому слайду, присутствующему в презентации.

**Использование коллекции слайдов**

Класс **Presentation** представляет файл презентации и предоставляет все слайды в нем в виде коллекции **SlideCollection** (которая является коллекцией объектов **Slide**). Все эти слайды можно получить из этой коллекции **Slides**, используя индекс слайда.

``` csharp

 // Создайте экземпляр объекта Presentation, представляющего файл презентации

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

// Доступ к слайду по его индексу слайда

SlideEx slide = pres.Slides[0];

``` 
## **Удаление слайдов**
Мы знаем, что класс Presentation в **Aspose.Slides для .NET** представляет файл презентации. Класс Presentation инкапсулирует **SlideCollection**, которая действует как хранилище всех слайдов, которые являются частью презентации. Разработчики могут удалить слайд из этой коллекции Slides двумя способами:

- Используя ссылку на слайд
- Используя индекс слайда

**Используя ссылку на слайд**

Чтобы удалить слайд, используя его ссылку, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его идентификатор или индекс
- Удалите ссылку на слайд из презентации
- Запишите измененный файл презентации

``` csharp

 // Создайте экземпляр объекта Presentation, представляющего файл презентации

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

// Доступ к слайду, используя его индекс в коллекции слайдов

SlideEx slide = pres.Slides[0];

// Удаление слайда, используя его ссылку

pres.Slides.Remove(slide);

// Запись файла презентации

pres.Write("modified.pptx");

``` 
## **Изменение позиции слайда:**
Просто изменить позицию слайда в презентации очень просто. Просто выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Измените номер слайда ссылки на слайд
- Запишите измененный файл презентации

В приведенном ниже примере мы изменили позицию слайда (находящегося на нулевом индексе позиции 1) презентации на индекс 1 (позиция 2).

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

ДобавлениеСлайдаВПрезентацию();

ДоступКСлайдамПрезентации();

УдалениеСлайдов();

ИзменениеПозицииСлайда();

}

public static void ДобавлениеСлайдаВПрезентацию()

{

Presentation pres = new Presentation();

// Создайте экземпляр класса SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    // Добавьте пустой слайд в коллекцию Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

// Сохраните файл PPTX на диск

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ДоступКСлайдамПрезентации()

{

// Создайте экземпляр объекта Presentation, представляющего файл презентации

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

// Доступ к слайду по индексу слайда

ISlide slide = pres.Slides[0];

}

public static void УдалениеСлайдов()

{

// Создайте экземпляр объекта Presentation, представляющего файл презентации

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

// Доступ к слайду, используя его индекс в коллекции слайдов

ISlide slide = pres.Slides[0];

// Удаление слайда, используя его ссылку

pres.Slides.Remove(slide);

// Запись файла презентации

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ИзменениеПозицииСлайда()

{

// Создайте класс Presentation для загрузки исходного файла презентации

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    // Получите слайд, позиция которого должна быть изменена

    ISlide sld = pres.Slides[0];

    // Установите новую позицию для слайда

    sld.SlideNumber = 2;

    // Запишите презентацию на диск

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)