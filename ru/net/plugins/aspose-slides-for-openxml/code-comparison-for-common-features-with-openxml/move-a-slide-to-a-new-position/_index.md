---
title: Перемещение слайда на новую позицию
type: docs
weight: 140
url: /ru/net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Перемещение слайда на новую позицию.pptx";

MoveSlide(FileName, 1, 2);

// Подсчет слайдов в презентации.

public static int CountSlides(string presentationFile)

{

    // Открываем презентацию только для чтения.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Передаем презентацию в следующий метод CountSlides

        // и возвращаем количество слайдов.

        return CountSlides(presentationDocument);

    }

}

// Подсчет слайдов в презентации.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Проверяем объект документа на null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Получаем часть презентации документа.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Получаем количество слайдов из SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Возвращаем количество слайдов в предыдущий метод.

    return slidesCount;

}

// Перемещение слайда на другую позицию в порядке слайдов в презентации.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Перемещение слайда на другую позицию в порядке слайдов в презентации.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Вызываем метод CountSlides, чтобы получить количество слайдов в презентации.

    int slidesCount = CountSlides(presentationDocument);

    // Проверяем, чтобы позиции from и to находились в пределах диапазона и были различными.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Получаем часть презентации из документа презентации.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Количество слайдов не равно нулю, следовательно, презентация должна содержать слайды.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Получаем ID слайда исходного слайда.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Определяем позицию целевого слайда, после которой нужно переместить исходный слайд.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // Удаляем исходный слайд из его текущей позиции.

    sourceSlide.Remove();

    // Вставляем исходный слайд на его новую позицию после целевого слайда.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Сохраняем измененную презентацию.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Перемещение слайда на новую позицию.pptx";

MoveSlide(FileName, 1, 2);

// Перемещение слайда на другую позицию в порядке слайдов в презентации.

public static void MoveSlide(string presentationFile, int from, int to)

{

    //Создаем экземпляр класса PresentationEx для загрузки исходного файла PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        // Получаем слайд, позиция которого будет изменена

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // Устанавливаем новую позицию для слайда

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // Сохраняем PPTX на диск

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **Скачать пример кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Перемещение%20слайда%20на%20новую%20позицию%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Перемещение%20слайда%20на%20новую%20позицию%20\(Aspose.Slides\).zip)