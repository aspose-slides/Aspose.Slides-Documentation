---
title: Переместить слайд в новое положение
type: docs
weight: 140
url: /ru/net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Подсчёт слайдов в презентации.

public static int CountSlides(string presentationFile)

{

    // Открыть презентацию только для чтения.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Передать презентацию в следующий метод CountSlides

        // и вернуть количество слайдов.

        return CountSlides(presentationDocument);

    }

}

// Подсчёт слайдов в презентации.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Проверка на объект null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Получить часть презентации из документа.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Получить количество слайдов из SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Вернуть количество слайдов вызывающему методу.

    return slidesCount;

}

// Переместить слайд в новое положение в порядке слайдов презентации.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// Переместить слайд в новое положение в порядке слайдов презентации.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Вызвать метод CountSlides, чтобы получить количество слайдов в презентации.

    int slidesCount = CountSlides(presentationDocument);

    // Проверить, что оба положения находятся в диапазоне и различаются.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // Получить часть презентации из документа.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Количество слайдов не равно нулю, значит презентация содержит слайды.

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // Получить идентификатор исходного слайда.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // Определить позицию целевого слайда, после которой будет вставлен исходный слайд.

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

    // Удалить исходный слайд из текущей позиции.

    sourceSlide.Remove();

    // Вставить исходный слайд в новую позицию после целевого слайда.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // Сохранить изменённую презентацию.

    presentation.Save();

}
``` 
## **Aspose.Slides**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// Переместить слайд в новое положение в порядке слайдов презентации.

public static void MoveSlide(string presentationFile, int from, int to)

{

    // Инстанциировать класс PresentationEx для загрузки исходного файла PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        // Получить слайд, позицию которого нужно изменить

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // Установить новую позицию для слайда

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // Записать PPTX на диск

        pres.Save(presentationFile, Aspose.Slides.Export.SaveFormat.Pptx);

    }

}
``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)