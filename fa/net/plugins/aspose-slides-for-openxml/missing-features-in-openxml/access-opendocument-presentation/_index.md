---
title: دسترسی به ارائه OpenDocument
type: docs
weight: 10
url: /fa/net/access-opendocument-presentation/
---
Aspose.Slides برای .NET کلاس **Presentation** را ارائه می‌دهد که نمایانگر یک فایل ارائه است. کلاس **Presentation** اکنون می‌تواند از طریق سازنده **Presentation** هنگام ایجاد شیء، به **ODP** نیز دسترسی پیدا کند.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است

using (Presentation pres = new Presentation(srcFileName))

{

    //ذخیرهٔ ارائه PPTX به فرمت PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

```
## **دانلود کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **دانلود مثال اجرا شده**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)