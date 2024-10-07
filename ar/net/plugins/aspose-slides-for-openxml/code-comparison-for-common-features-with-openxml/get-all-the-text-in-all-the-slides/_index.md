---
title: الحصول على كل النصوص في كل الشرائح
type: docs
weight: 100
url: /net/get-all-the-text-in-all-the-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "الحصول على كل النصوص في شريحة.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("عدد الشرائح = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("الشريحة #{0} تحتوي على: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // افتح العرض كقراءة فقط.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // مرر العرض إلى طريقة CountSlides التالية

        // وأرجع عدد الشرائح.

        return CountSlides(presentationDocument);

    }

}

// احسب عدد الشرائح في العرض.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // تحقق من وجود كائن وثيقة null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // احصل على الجزء الخاص بالعروض من الوثيقة.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // احصل على عدد الشرائح من SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // أعد عدد الشرائح إلى الطريقة السابقة.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // احصل على معرّف العلاقة للشريحة الأولى.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // احصل على جزء الشريحة من معرّف العلاقة.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // أنشئ كائن StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // احصل على النص الداخلي للشريحة:

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

string FileName = FilePath + "الحصول على كل النصوص في شريحة.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("عدد الشرائح = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("الشريحة #{0} تحتوي على: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //إنشاء فئة PresentationEx التي تمثل PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //إنشاء فئة PresentationEx التي تمثل PPTX

    using (Presentation pres = new Presentation(docName))

    {

        //الوصول إلى الشريحة

        ISlide sld = pres.Slides[index];

        //التكرار خلال الأشكال للعثور على عنصر النائب

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //احصل على نص كل عنصر نائب

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **تحميل مثال للكود**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Get%20all%20the%20text%20in%20all%20slides%20\(Aspose.Slides\).zip)