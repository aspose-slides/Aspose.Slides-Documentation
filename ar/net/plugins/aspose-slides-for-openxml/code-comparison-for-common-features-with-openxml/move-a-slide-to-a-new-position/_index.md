---
title: نقل شريحة إلى موضع جديد
type: docs
weight: 140
url: /net/move-a-slide-to-a-new-position/
---

## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "نقل شريحة إلى موضع جديد.pptx";

MoveSlide(FileName, 1, 2);

// حساب عدد الشرائح في العرض.

public static int CountSlides(string presentationFile)

{

    // فتح العرض فقط للقراءة.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // تمرير العرض إلى دالة CountSlides التالية

        // وإرجاع عدد الشرائح.

        return CountSlides(presentationDocument);

    }

}

// حساب عدد الشرائح في العرض.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // التحقق من وجود كائن وثيقة غير فارغ.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // الحصول على جزء العرض من الوثيقة.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // الحصول على عدد الشرائح من SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // إرجاع عدد الشرائح إلى الدالة السابقة.

    return slidesCount;

}

// نقل شريحة إلى موضع مختلف في ترتيب الشرائح في العرض.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// نقل شريحة إلى موضع مختلف في ترتيب الشرائح في العرض.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // استدعاء دالة CountSlides للحصول على عدد الشرائح في العرض.

    int slidesCount = CountSlides(presentationDocument);

    // التحقق من أن الموضعين from و to ضمن النطاق ومختلفان عن بعضهما.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // الحصول على جزء العرض من وثيقة العرض.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // عدد الشرائح ليس صفرًا، لذا يجب أن يحتوي العرض على شرائح.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // الحصول على ID الشريحة المصدر.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // تحديد موضع الشريحة الهدف بعده لنقل الشريحة المصدر.

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

    // إزالة الشريحة المصدر من موضعها الحالي.

    sourceSlide.Remove();

    // إدراج الشريحة المصدر في موضعها الجديد بعد الشريحة الهدف.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // حفظ العرض المعدل.

    presentation.Save();

} 

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "نقل شريحة إلى موضع جديد.pptx";

MoveSlide(FileName, 1, 2);

// نقل شريحة إلى موضع مختلف في ترتيب الشرائح في العرض.

public static void MoveSlide(string presentationFile, int from, int to)

{

    // إنشاء كائن من فئة PresentationEx لتحميل ملف PPTX المصدر

    using (Presentation pres = new Presentation(presentationFile))

    {

        // الحصول على الشريحة التي سيتم تغيير موضعها

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // تعيين الموضع الجديد للشريحة

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // كتابة ملف PPTX إلى القرص

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **تنزيل كود العينة**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/نقل%20شريحة%20إلى%20موضع%20جديد%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/نقل%20شريحة%20إلى%20موضع%20جديد%20\(Aspose.Slides\).zip)