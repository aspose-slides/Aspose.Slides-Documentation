---
title: الحصول على عناوين جميع الشرائح
type: docs
weight: 120
url: /ar/net/get-the-titles-of-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "الحصول على عناوين جميع الشرائح.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// الحصول على قائمة بعناوين جميع الشرائح في العرض التقديمي.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // فتح العرض التقديمي للقراءة فقط.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// الحصول على قائمة بعناوين جميع الشرائح في العرض التقديمي.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // الحصول على كائن PresentationPart من كائن PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // الحصول على كائن Presentation من كائن PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // الحصول على عنوان كل شريحة بترتيب الشرائح.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // الحصول على عنوان الشريحة.

                string title = GetSlideTitle(slidePart);

                // يمكن أيضًا إضافة عنوان فارغ.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// الحصول على سلسلة عنوان الشريحة.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // إعلان عن فاصل الفقرة.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // العثور على جميع أشكال العناوين.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // الحصول على النص في كل فقرة في هذه الشكل.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // إضافة فاصل سطر.

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

// تحديد ما إذا كانت الشكل هي شكل عنوان.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // أي شكل عنوان.

            case PlaceholderValues.Title:

            // عنوان مركزي.

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

string FileName = FilePath + "الحصول على جميع النصوص في شريحة.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("عدد الشرائح = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("الشريحة رقم #{0} تحتوي على: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // فتح العرض التقديمي للقراءة فقط.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // تمرير العرض التقديمي إلى طريقة CountSlides التالية

        // وإرجاع عدد الشرائح.

        return CountSlides(presentationDocument);

    }

}

// عد الشرائح في العرض التقديمي.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // التحقق من كائن الوثيقة الفارغ.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // الحصول على جزء العرض التقديمي من الوثيقة.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // الحصول على عدد الشرائح من SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // إرجاع عدد الشرائح إلى الطريقة السابقة.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // الحصول على معرف العلاقة للشريحة الأولى.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // الحصول على جزء الشريحة من معرف العلاقة.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // بناء كائن StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // الحصول على النص الداخلي من الشريحة:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **تنزيل نموذج الكود**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20the%20titles%20of%20all%20the%20slides%20\(Aspose.Slides\).zip)