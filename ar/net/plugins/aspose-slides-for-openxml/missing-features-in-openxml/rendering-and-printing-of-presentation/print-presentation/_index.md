---
title: طباعة العرض التقديمي
type: docs
url: /ar/net/print-the-presentation/
---

توفر Aspose.Slides for .NET أربع طرق محملة لطباعة العروض التقديمية. هذه الطرق مرنة بما يكفي لطباعة العرض إلى الطابعة الافتراضية أو إلى أي من الطابعات المتاحة مع إعدادات مخصصة. تحتاج فقط إلى اختيار طريقة الطباعة المناسبة وفقًا للمتطلب.

## **الطباعة إلى الطابعة الافتراضية**
طباعة العرض إلى الطابعة الافتراضية بسيطة جدًا في Aspose.Slides for .NET. قم بتنفيذ الخطوات التالية لطباعة العرض إلى الطابعة الافتراضية:

- إنشاء نسخة من فئة Presentation لتحميل العرض الذي سيتم طباعته
- استدعاء طريقة Print دون أي معلمات كما هو معروض في كائن Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    // تحميل العرض
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    // استدعاء طريقة الطباعة لطباعة العرض بالكامل إلى الطابعة الافتراضية
    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    // تحميل العرض
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    // استدعاء طريقة الطباعة لطباعة العرض بالكامل إلى الطابعة المطلوبة
    asposePresentation.Print("LaserJet1100");


``` 
## **الطباعة إلى طابعة معينة**
طباعة العرض إلى طابعة معينة تتطلب اسم الطابعة كمعامل لطريقة Print في فئة Presentation. قم بتنفيذ الخطوات التالية لطباعة العرض إلى الطابعة المطلوبة:

- إنشاء نسخة من فئة Presentation لتحميل العرض الذي سيتم طباعته
- استدعاء طريقة Print في فئة Presentation مع اسم الطابعة كسلسلة نصية كمعامل

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    // تحميل العرض
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    // استدعاء طريقة الطباعة لطباعة العرض بالكامل إلى الطابعة المطلوبة
    asposePresentation.Print("LaserJet1100");

}

``` 
## **تحميل عينة الشيفرة**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)