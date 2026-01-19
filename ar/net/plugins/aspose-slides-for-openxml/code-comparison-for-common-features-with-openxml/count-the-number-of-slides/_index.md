---
title: عد عدد الشرائح
type: docs
weight: 50
url: /ar/net/count-the-number-of-slides/
---

## **OpenXML SDK**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

// الحصول على كائن العرض وتوجيهه إلى الدالة CountSlides التالية.
public static int CountSlides(string presentationFile)

{

    // فتح العرض للقراءة فقط.
    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // تمرير العرض إلى الدالة CountSlide التالية
        // وإرجاع عدد الشرائح.
        return CountSlides(presentationDocument);

    }

}

// حساب عدد الشرائح في العرض.
public static int CountSlides(PresentationDocument presentationDocument)

{

    // التحقق من كائن مستند فارغ (null).
    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // الحصول على جزء العرض من المستند.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // الحصول على عدد الشرائح من SlideParts.
    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // إرجاع عدد الشرائح إلى الدالة السابقة.
    return slidesCount;

} 
```
## **Aspose.Slides**
``` csharp
 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",

CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  // إنشاء كائن PresentationEx يمثل ملف PPTX
  using (Presentation pres = new Presentation(presentationFile))

  {

     return pres.Slides.Count;

  }

}  
```
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)