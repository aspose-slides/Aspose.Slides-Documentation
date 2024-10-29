---
title: Применение темы к презентации
type: docs
weight: 30
url: /ru/net/apply-a-theme-to-a-presentation/
---

## **OpenXML Презентация:**
``` csharp

 string FilePath = @"..\..\..\..\Примеры Файлы\";

string FileName = FilePath + "Применение темы к презентации.pptx";

string ThemeFileName = FilePath + "Тема.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Применить новую тему к презентации. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Применить новую тему к презентации. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Получите часть презентации документа презентации.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Получите существующую часть мастер-слайда.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Получите новую часть мастер-слайда.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Удалите существующую часть темы.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Удалите старую часть мастер-слайда.

    presentationPart.DeletePart(slideMasterPart);

    // Импортируйте новую часть мастер-слайда и повторно используйте старый идентификатор отношения.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Смените на новую часть темы.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Вставьте код для компоновки для этого примера.

    string defaultLayoutType = "Заголовок и содержимое";

    // Удалите отношение компоновки слайдов на всех слайдах. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Определите тип компоновки слайда для каждого слайда.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Удалите старую часть компоновки.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Примените новую часть компоновки.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Примените новую часть компоновки по умолчанию.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Получите тип компоновки слайда.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Примечания: если это используется в продуктивном коде, проверьте на наличие нулевой ссылки.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Чтобы применить тему, нам нужно клонировать слайд с мастером, пожалуйста, следуйте приведенным ниже шагам:

- Создайте экземпляр класса Presentation, содержащий исходную презентацию, из которой слайд будет клонироваться.
- Создайте экземпляр класса Presentation, содержащий целевую презентацию, в которую слайд будет клонироваться.
- Получите слайд, который нужно клонировать, вместе с мастер-слайдом.
- Создайте экземпляр класса IMasterSlideCollection, ссылаясь на коллекцию Masters, предоставляемую объектом Presentation целевой презентации.
- Вызовите метод AddClone, предоставленный объектом IMasterSlideCollection, и передайте мастер из исходного PPTX, который нужно клонировать, в качестве параметра метода AddClone.
- Создайте экземпляр класса ISlideCollection, установив ссылку на коллекцию Slides, предоставляемую объектом Presentation целевой презентации.
- Вызовите метод AddClone, предоставленный объектом ISlideCollection, и передайте слайд из исходной презентации для клонирования и мастер-слайд в качестве параметра метода AddClone.
- Запишите измененный файл целевой презентации.

``` csharp

 string FilePath = @"..\..\..\..\Примеры Файлы\";

string FileName = FilePath + "Применение темы к презентации.pptx";

string ThemeFileName = FilePath + "Тема.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Создайте экземпляр класса Presentation для загрузки файла исходной презентации

    Presentation srcPres = new Presentation(presentationFile);

    //Создайте экземпляр класса Presentation для целевой презентации (где слайд должен быть клонирован)

    Presentation destPres = new Presentation(outputFile);

    //Создайте ISlide из коллекции слайдов в исходной презентации вместе с

    //мастер-слайдом

    ISlide SourceSlide = srcPres.Slides[0];

    //Клонируйте желаемый мастер-слайд из исходной презентации в коллекцию мастеров в

    //целевой презентации

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //Клонируйте желаемый мастер-слайд из исходной презентации в коллекцию мастеров в

    //целевой презентации

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //Клонируйте желаемый слайд из исходной презентации с желаемым мастером в конец коллекции

    //слайдов в целевой презентации

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //Клонируйте желаемый мастер-слайд из исходной презентации в коллекцию мастеров в 

    //целевой презентации

    //Сохраните целевую презентацию на диск

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Скачайте пример работающего кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)