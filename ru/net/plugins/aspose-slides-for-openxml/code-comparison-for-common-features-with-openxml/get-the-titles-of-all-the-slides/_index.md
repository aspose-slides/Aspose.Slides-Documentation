---
title: Получить названия всех слайдов
type: docs
weight: 120
url: /ru/net/get-the-titles-of-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Получить названия всех слайдов.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Получить список названий всех слайдов в презентации.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Открыть презентацию только для чтения.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Получить список названий всех слайдов в презентации.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Получить объект PresentationPart из объекта PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Получить объект Presentation из объекта PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Получить название каждого слайда в порядке слайдов.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Получить заголовок слайда.

                string title = GetSlideTitle(slidePart);

                // Пустое название также может быть добавлено.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Получить строку заголовка слайда.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Объявить разделитель абзаца.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Найти все формы заголовков.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Получить текст в каждом абзаце этой формы.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Добавить перевод строки.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// Определяет, является ли форма заголовком.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Любая форма заголовка.

            case PlaceholderValues.Title:

            // Центрированный заголовок.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

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

// Подсчитать слайды в презентации.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Проверка на наличие объекта документа.

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

        // Получить идентификатор связи первого слайда.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Получить часть слайда по идентификатору связи.

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
## **Скачайте образец кода**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20the%20titles%20of%20all%20the%20slides%20\(Aspose.Slides\).zip)