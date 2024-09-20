---
title: Получить весь текст на всех слайдах
type: docs
weight: 100
url: /net/get-all-the-text-in-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Получить весь текст на слайде.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Количество слайдов = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Слайд #{0} содержит: {1}", i + 1, slideText);

}

System.Console.ReadKey();

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

// Подсчет слайдов в презентации.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Проверка на null объект документа.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Получить часть презентации документа.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Получить количество слайдов из SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Вернуть количество слайдов в предыдущий метод.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Получить ID связи первого слайда.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Получить часть слайда по ID связи.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Создать объект StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Получить внутренний текст слайда:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Получить весь текст на слайде.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Количество слайдов = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Слайд #{0} содержит: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //Создать класс PresentationEx, который представляет PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Создать класс PresentationEx, который представляет PPTX

    using (Presentation pres = new Presentation(docName))

    {

        //Получить доступ к слайду

        ISlide sld = pres.Slides[index];

        //Итерация по фигурам для нахождения заполнителя

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //получить текст каждого заполнителя

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Скачать пример кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip)