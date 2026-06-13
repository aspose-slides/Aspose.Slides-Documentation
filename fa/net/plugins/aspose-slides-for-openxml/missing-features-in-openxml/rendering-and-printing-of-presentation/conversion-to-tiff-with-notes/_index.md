---
title: تبدیل به Tiff با یادداشت‌ها
type: docs
weight: 10
url: /fa/net/conversion-to-tiff-with-notes/
---
TIFF یکی از چندین فرمت تصویر پرکاربرد است که Aspose.Slides برای .NET برای تبدیل یک ارائه همراه با یادداشت‌ها به تصاویر پشتیبانی می‌کند. همچنین می‌توانید تصویرهای کوچک اسلایدها را در نمای اسلاید یادداشت‌ها ایجاد کنید. در ادامه دو قطعه کد آورده شده‌اند که نشان می‌دهند چگونه می‌توان تصاویر TIFF یک ارائه را در نمای اسلاید یادداشت‌ها تولید کرد.

متد **Save** که توسط کلاس **Presentation** ارائه شده می‌تواند برای تبدیل کل ارائه در نمای اسلاید یادداشت‌ها به فرمت TIFF استفاده شود. همچنین می‌توانید تصویر کوچک یک اسلاید را در نمای اسلاید یادداشت‌ها برای اسلایدهای جداگانه تولید کنید.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است

Presentation pres = new Presentation(srcFileName);

// ارائه را به فرمت TIFF notes ذخیره می‌کند

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **دریافت کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)