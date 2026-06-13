---
title: چاپ ارائه
type: docs
url: /fa/net/print-the-presentation/
---
Aspose.Slides for .NET چهار overload متد برای چاپ ارائه‌ها فراهم می‌کند. این متدها به اندازه کافی انعطاف‌پذیر هستند تا ارائه را به چاپگر پیش‌فرض یا هر چاپگر موجود با تنظیمات سفارشی چاپ کنند. فقط کافی است مطابق نیاز، متد چاپ مناسب را انتخاب کنید.
## **Print to the Default Printer**
چاپ ارائه به چاپگر پیش‌فرض در Aspose.Slides for .NET بسیار ساده است. برای چاپ ارائه به چاپگر پیش‌فرض مراحل زیر را انجام دهید:

- یک نمونه از کلاس Presentation ایجاد کنید تا ارائه‌ای که باید چاپ شود را بارگذاری کنید
- متد Print را بدون هیچ پارامتری که توسط شی Presentation ارائه شده، فراخوانی کنید

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //بارگذاری ارائه

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //متد چاپ را صدا بزنید تا کل ارائه را به چاپگر پیش‌فرض چاپ کند

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //بارگذاری ارائه

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //متد چاپ را صدا بزنید تا کل ارائه را به چاپگر مورد نظر چاپ کند

    asposePresentation.Print("LaserJet1100");


``` 
## **Print to a Specific Printer**
چاپ ارائه به چاپگر خاص نیاز به نام چاپگر به عنوان پارامتر به متد Print کلاس Presentation دارد. برای چاپ ارائه به چاپگر مورد نظر مراحل زیر را انجام دهید:

- یک نمونه از کلاس Presentation ایجاد کنید تا ارائه‌ای که باید چاپ شود را بارگذاری کنید
- متد Print کلاس Presentation را با نام چاپگر به عنوان پارامتر رشته‌ای فراخوانی کنید

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //بارگذاری ارائه

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //متد چاپ را صدا بزنید تا کل ارائه را به چاپگر مورد نظر چاپ کند

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)