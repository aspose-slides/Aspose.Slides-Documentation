---
title: الحصول على كل النص في الشريحة
type: docs
weight: 110
url: /net/get-all-the-text-in-a-slide/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// الحصول على كل النص في الشريحة.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // فتح العرض التقديمي للقراءة فقط.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // تمرير العرض التقديمي ومؤشر الشريحة

        // إلى طريقة GetAllTextInSlide التالية، ثم

        // إرجاع مصفوفة السلاسل التي تعيدها. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // التحقق من وجود مستند العرض التقديمي.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // التحقق من أن مؤشر الشريحة غير خارج النطاق.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // الحصول على جزء العرض التقديمي من مستند العرض التقديمي.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // التحقق من وجود جزء العرض التقديمي والعرض التقديمي.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // الحصول على كائن العرض التقديمي من جزء العرض التقديمي.

        Presentation presentation = presentationPart.Presentation;

        // التحقق من أن قائمة معرفات الشرائح موجودة.

        if (presentation.SlideIdList != null)

        {

            // الحصول على مجموعة من معرفات الشرائح من قائمة معرفات الشرائح.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // إذا كان معرف الشريحة ضمن النطاق...

            if (slideIndex < slideIds.Count)

            {

                // الحصول على معرف العلاقة للشريحة.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // الحصول على جزء الشريحة المحدد من معرف العلاقة.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // تمرير جزء الشريحة إلى الطريقة التالية، ثم

                // إرجاع مصفوفة السلاسل التي تعيدها الطريقة

                // إلى الطريقة السابقة.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // وإلا، إرجاع null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // التحقق من أن جزء الشريحة موجود.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // إنشاء قائمة مرتبطة جديدة من السلاسل.

    LinkedList<string> texts = new LinkedList<string>();

    // إذا كانت الشريحة موجودة...

    if (slidePart.Slide != null)

    {

        // تكرار من خلال جميع الفقرات في الشريحة.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // إنشاء بنّاء نصوص جديد.                    

            StringBuilder paragraphText = new StringBuilder();

            // تكرار من خلال سطور الفقرة.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // إضافة كل سطر إلى الأسطر السابقة.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // إضافة كل فقرة إلى القائمة المرتبطة.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // إرجاع مصفوفة من السلاسل.

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

// الحصول على كل النص في الشريحة.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// إنشاء قائمة مرتبطة جديدة من السلاسل.

List<string> texts = new List<string>();

//Instantiate PresentationEx class that represents PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    //Access the slide

    ISlide sld = pres.Slides[slideIndex];

    //Iterate through shapes to find the placeholder

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //الحصول على نص كل عنصر نائب

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// إرجاع مصفوفة من السلاسل.

return texts;

}

``` 
## **تحميل شفرة العينة**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20all%20the%20text%20in%20a%20slide%20\(Aspose.Slides\).zip)