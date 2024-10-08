---
title: طباعة العرض التقديمي
type: docs
url: /ar/net/print-the-presentation/
---

توفر Aspose.Slides لـ .NET أربعة طرق تحميل لطباعة العروض التقديمية. هذه الطرق مرنة بما يكفي لطباعة العرض التقديمي إلى الطابعة الافتراضية أو إلى أي طابعة متاحة مع إعدادات مخصصة. تحتاج فقط إلى اختيار طريقة الطباعة المناسبة وفقًا للمتطلبات.
## **الطباعة إلى الطابعة الافتراضية**
طباعة العرض التقديمي إلى الطابعة الافتراضية بسيطة للغاية في Aspose.Slides لـ .NET. قم بالخطوات التالية لطباعة العرض التقديمي إلى الطابعة الافتراضية:

- قم بإنشاء مثيل من فئة Presentation لتحميل عرض تقديمي سيتم طباعته
- استدعِ طريقة Print بدون معلمات كما هو موضح من قبل كائن Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //تحميل العرض التقديمي

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //استدعِ طريقة الطباعة لطباعة العرض التقديمي بالكامل إلى الطابعة الافتراضية

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //تحميل العرض التقديمي

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //استدعِ طريقة الطباعة لطباعة العرض التقديمي بالكامل إلى الطابعة المطلوبة

    asposePresentation.Print("LaserJet1100");


``` 
## **الطباعة إلى طابعة معينة**
تتطلب طباعة العرض التقديمي إلى الطابعة المحددة اسم الطابعة كمعامل لطريقة Print في Presentation. قم بالخطوات التالية لطباعة العرض التقديمي إلى الطابعة المطلوبة:

- قم بإنشاء مثيل من فئة Presentation لتحميل عرض تقديمي سيتم طباعته
- استدعِ طريقة Print من فئة Presentation مع اسم الطابعة كمعامل نصي لطريقة Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //تحميل العرض التقديمي

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //استدعِ طريقة الطباعة لطباعة العرض التقديمي بالكامل إلى الطابعة المطلوبة

    asposePresentation.Print("LaserJet1100");

}

``` 
## **تحميل شفرة العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)