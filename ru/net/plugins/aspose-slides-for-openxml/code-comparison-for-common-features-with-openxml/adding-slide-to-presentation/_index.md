---
title: Добавление слайда в презентацию
type: docs
weight: 20
url: /ru/net/adding-slide-to-presentation/
---

## **OpenXML Презентация**
В приведенной ниже функциональности по умолчанию слайд добавляется в презентацию. Здесь мы добавляем новый слайд с индексом 2, имеющий некоторый текст в нем.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Добавление слайда в презентацию.pptx";

InsertNewSlide(FileName, 1, "Мой новый слайд");

// Вставить слайд в указанную презентацию.

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // Открываем исходный документ для чтения/записи. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // Передаем исходный документ, позицию и заголовок слайда в следующий метод.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// Вставить указанный слайд в презентацию в указанной позиции.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Убедитесь, что презентация не пуста.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("Документ презентации пуст.");

    }

    // Объявите и создайте новый слайд.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // Создайте содержимое слайда.            

    // Укажите невизуальные свойства нового слайда.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // Укажите свойства группы фигуры нового слайда.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // Объявите и создайте фигуру заголовка нового слайда.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Укажите необходимые свойства фигуры для фигуры заголовка. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Заголовок" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // Укажите текст фигуры заголовка.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // Объявите и создайте фигуру основного текста нового слайда.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // Укажите необходимые свойства фигуры для фигуры основного текста.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Заполнитель содержимого" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // Укажите текст фигуры основного текста.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // Создайте часть слайда для нового слайда.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // Сохраните новую часть слайда.

    slide.Save(slidePart);

    // Измените список идентификаторов слайдов в части презентации.

    // Список идентификаторов слайдов не должен быть равен null.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // Найдите максимальный идентификатор слайда в текущем списке.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // Получите идентификатор предыдущего слайда.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // Используйте тот же макет слайда, что и у предыдущего слайда.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // Вставьте новый слайд в список слайдов после предыдущего слайда.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // Сохраните изменённую презентацию.

    presentationPart.Presentation.Save();

}

}

``` 
## **Aspose.Slides**
Каждый файл презентации PowerPoint содержит один **Главный мастер слайд** и другие **Обычные слайды**. Это означает, что файл презентации содержит по крайней мере один или более слайдов. Важно знать, что файлы презентации без слайдов не поддерживаются Aspose.Slides для .NET. У каждого слайда есть определённая позиция и **уникальный идентификатор**. **Идентификатор слайда** может варьироваться от 0 до 255 для мастер-слайдов и от 256 до 65535 для обычных слайдов.

Aspose.Slides для .NET позволяет разработчикам добавлять пустые слайды в презентации с помощью метода **AddEmptySlide**, доступного в объекте **Presentation**. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Вызовите метод AddEmptySlide, доступный в объекте Presentation
- Выполните некоторые действия с только что добавленным пустым слайдом
- Добавьте ещё один слайд и вставьте текст на него.
- Наконец, запишите файл PPT, используя метод Write, доступный в объекте Presentation.

``` csharp

 string FileName = FilePath + "Добавление слайда в презентацию.pptx";

//Создайте экземпляр класса PresentationEx, который представляет файл PPT

Presentation pres = new Presentation();

//Пустой слайд добавляется по умолчанию, когда вы создаете

//презентацию из конструктора по умолчанию

//Добавление пустого слайда в презентацию и получение ссылки на

//этот пустой слайд

ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//Запишите вывод на диск

pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Скачать образец кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)