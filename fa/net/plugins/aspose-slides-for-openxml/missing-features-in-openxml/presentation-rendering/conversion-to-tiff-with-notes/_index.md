---
title: تبدیل به Tiff همراه با یادداشت‌ها
type: docs
weight: 10
url: /fa/net/conversion-to-tiff-with-notes/
---
TIFF یکی از چندین فرمت تصویر پرکاربرد است که Aspose.Slides برای .NET برای تبدیل یک ارائه همراه با یادداشت‌ها به تصویر پشتیبانی می‌کند. همچنین می‌توانید تصاویر بندانگشتی اسلاید را در نمای اسلاید یادداشت‌ها تولید کنید. در زیر دو قطعه کد آورده شده است که نشان می‌دهد چگونه می‌توان تصاویر TIFF یک ارائه را در نمای اسلاید یادداشت‌ها تولید کرد.

متد **Save** که توسط کلاس **Presentation** ارائه شده است می‌تواند برای تبدیل کل ارائه در نمای اسلاید یادداشت‌ها به فرمت TIFF استفاده شود. همچنین می‌توانید برای اسلایدهای منفرد، تصویر بندانگشتی اسلاید را در نمای اسلاید یادداشت‌ها تولید کنید.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//یک شی Presentation ایجاد کنید که نمایانگر فایل ارائه است
using (Presentation pres = new Presentation(srcFileName))
{
    //یادداشت‌های گوینده را زیر هر اسلاید رندر شده قرار دهید
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //ذخیرهٔ ارائه به فرمت TIFF همراه با یادداشت‌ها
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **کد نمونه را بارگیری کنید**
- [گیتهاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)