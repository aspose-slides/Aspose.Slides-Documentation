---
title: به صورت Tiff رندر شده
type: docs
weight: 30
url: /fa/net/rendered-as-tiff/
---
فرمت TIFF به‌خاطر انعطاف‌پذیری‌اش در پشتیبانی از تصاویر چندصفحه‌ای و داده‌ها شناخته شده است. با در نظر گرفتن اهمیت و محبوبیت فرمت TIFF، Aspose.Slides برای .NET پشتیبانی از تبدیل ارائه‌ها به سند TIFF را فراهم می‌کند.
این مقاله توضیح می‌دهد که گزینه‌های مختلف صادرات TIFF چگونه هستند:

- تبدیل ارائه به TIFF با اندازه پیش‌فرض.
- تبدیل ارائه به TIFF با اندازه سفارشی.

متد **Save** که توسط کلاس **Presentation** ارائه می‌شود، می‌تواند توسط توسعه‌دهندگان برای تبدیل کل ارائه به سند **TIFF** فراخوانی شود. علاوه بر این، کلاس TiffOptions ویژگی ImageSize را نمایش می‌دهد که به توسعه‌دهنده امکان تعریف اندازه تصویر را در صورت نیاز می‌دهد.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//یک شی Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند

using (Presentation pres = new Presentation(srcFileName))

{

    //ذخیره ارائه به سند TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)