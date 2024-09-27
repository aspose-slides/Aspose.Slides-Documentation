---
title: Получить весь текст на слайде
type: docs
weight: 110
url: /ru/net/get-all-the-text-in-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Получить весь текст на слайде.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Открыть презентацию только для чтения.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Передать презентацию и индекс слайда

        // в следующий метод GetAllTextInSlide, и

        // затем вернуть массив строк, который он возвращает. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Проверить, существует ли документ презентации.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Проверить, находится ли индекс слайда в допустимых пределах.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Получить часть презентации документа презентации.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Проверить, существует ли часть презентации и сама презентация.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Получить объект Presentation из части презентации.

        Presentation presentation = presentationPart.Presentation;

        // Проверить, существует ли список ID слайдов.

        if (presentation.SlideIdList != null)

        {

            // Получить коллекцию ID слайдов из списка ID слайдов.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Если ID слайда в диапазоне...

            if (slideIndex < slideIds.Count)

            {

                // Получить ID отношения слайда.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Получить указанную часть слайда по ID отношения.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Передать часть слайда в следующий метод, и

                // затем вернуть массив строк, который этот метод

                // возвращает в предыдущий метод.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // В противном случае вернуть null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Проверить, существует ли часть слайда.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Создать новый связный список строк.

    LinkedList<string> texts = new LinkedList<string>();

    // Если слайд существует...

    if (slidePart.Slide != null)

    {

        // Перебирать все абзацы на слайде.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Создать новый объект StringBuilder.                    

            StringBuilder paragraphText = new StringBuilder();

            // Перебирать строки абзаца.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Добавить каждую строку к предыдущим строкам.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Добавить каждый абзац в связный список.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Вернуть массив строк.

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Получить весь текст на слайде.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Создать новый связный список строк.

List<string> texts = new List<string>();

//Создать экземпляр класса PresentationEx, который представляет PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Получить доступ к слайду

    ISlide sld = pres.Slides[slideIndex];

    //Перебирать формы, чтобы найти заполнитель

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //получить текст каждого заполнителя

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Вернуть массив строк.

return texts;

}

``` 
## **Скачать образец кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20all%20the%20text%20in%20a%20slide%20\(Aspose.Slides\).zip)