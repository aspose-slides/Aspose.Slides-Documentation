---
title: به صورت Tiff رندر شده
type: docs
weight: 30
url: /fa/net/rendered-as-tiff/
---
قالب TIFF به خاطر انعطاف‌پذیری‌اش در پشتیبانی از تصاویر چندصفحه‌ای و داده‌ها شناخته شده است. با در نظر گرفتن اهمیت و محبوبیت قالب TIFF، Aspose.Slides برای .NET پشتیبانی از تبدیل ارائه‌ها به سند TIFF را فراهم می‌کند.
این مقاله توضیح می‌دهد که چگونه گزینه‌های مختلف خروجی TIFF:

- تبدیل ارائه به TIFF با اندازه پیش‌فرض.
- تبدیل ارائه به TIFF با اندازه سفارشی.

متد **Save** که توسط کلاس **Presentation** ارائه شده است، می‌تواند توسط توسعه‌دهندگان برای تبدیل کل ارائه به سند **TIFF** فراخوانی شود. علاوه بر این، کلاس TiffOptions ویژگی ImageSize را در دسترس قرار می‌دهد که به توسعه‌دهنده امکان تعریف اندازه تصویر را در صورت نیاز می‌دهد.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است

using (Presentation pres = new Presentation(srcFileName))

{

    //ذخیره‌سازی ارائه به سند TIFF
    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **کد نمونه را دانلود کنید**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)