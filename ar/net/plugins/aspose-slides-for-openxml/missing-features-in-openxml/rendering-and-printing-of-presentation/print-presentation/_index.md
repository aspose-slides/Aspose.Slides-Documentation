---
title: طباعة العرض التقديمي
type: docs
url: /ar/net/print-the-presentation/
---

توفر Aspose.Slides for .NET أربع طرق محملة للطبعات الخاصة بالعروض التقديمية. هذه الطرق مرنة بما يكفي لطباعة العرض على الطابعة الافتراضية أو على أي طابعة متاحة مع إعدادات مخصصة. كل ما عليك هو اختيار طريقة الطباعة المناسبة وفقًا للمطلب.

## **الطباعة إلى الطابعة الافتراضية**
الطباعة إلى الطابعة الافتراضية في Aspose.Slides for .NET بسيطة جدًا. اتبع الخطوات التالية لطباعة العرض على الطابعة الافتراضية:

- إنشاء كائن من فئة Presentation لتحميل العرض الذي سيتم طباعته
- استدعاء طريقة Print بدون معاملات كما هو متاح في كائن Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the default printer

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");


``` 
## **الطباعة إلى طابعة محددة**
الطباعة إلى طابعة محددة تتطلب اسم الطابعة كمعامل لطريقة Print في فئة Presentation. اتبع الخطوات التالية لطباعة العرض على الطابعة المطلوبة:

- إنشاء كائن من فئة Presentation لتحميل العرض الذي سيتم طباعته
- استدعاء طريقة Print في فئة Presentation مع اسم الطابعة كمعامل نصي

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");

}

``` 
## **تحميل كود العينة**
- [كودبلكس](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [جيتهاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [كود.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [بيتباكت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)