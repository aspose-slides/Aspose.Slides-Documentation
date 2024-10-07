---
title: عد عدد الشرائح
type: docs
weight: 50
url: /net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("عدد الشرائح = {0}",

CountSlides(FileName));

Console.ReadKey();

// احصل على كائن العرض ومرره إلى طريقة CountSlides التالية.

public static int CountSlides(string presentationFile)

{

    // افتح العرض كقراءة فقط.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // مرر العرض إلى طريقة CountSlide التالية

        // وارجع عدد الشرائح.

        return CountSlides(presentationDocument);

    }

}

// عد الشرائح في العرض.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // تحقق من كائن المستند أنه غير فارغ.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // احصل على جزء العرض من المستند.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // احصل على عدد الشرائح من SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // ارجع عدد الشرائح إلى الطريقة السابقة.

    return slidesCount;

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("عدد الشرائح = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  // قم بإنشاء كائن PresentationEx الذي يمثل ملف PPTX

  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  

``` 
## **تحميل كود العينة**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Count%20the%20number%20of%20Slides%20\(Aspose.Slides\).zip)