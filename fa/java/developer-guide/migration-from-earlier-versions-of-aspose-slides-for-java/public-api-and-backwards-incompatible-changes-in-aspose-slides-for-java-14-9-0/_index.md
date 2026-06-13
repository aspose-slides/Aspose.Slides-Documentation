---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای جاوا 14.9.0
linktitle: Aspose.Slides برای جاوا 14.9.0
type: docs
weight: 80
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- سند باز
- ارائه
- جاوا
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای جاوا را مرور کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائه پاورپوینت PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}}
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره، محدودیت‌های جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) معرفی‌شده با API Aspose.Slides برای جاوا 14.9.0 را فهرست می‌کند.
{{% /alert %}}
## **تغییرات API عمومی**
### **متدهای اضافه‌شده برای جایگزینی تصویر به PPImage، IPPImage**
متدهای جدید اضافه شد:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//روش اول

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//روش دوم

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **متدهای اضافه‌شده برای ذخیره اسلایدها با حفظ شماره صفحات**
متدهای زیر اضافه شده‌اند:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

این متدها امکان ذخیره اسلایدهای مشخص‌شده ارائه را به فرمت‌های PDF، XPS، TIFF، HTML را فراهم می‌کنند. آرایهٔ 'slides' امکان تعیین شماره صفحات، با شروع از 1 را می‌دهد.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //آرایه‌ای از موقعیت‌های اسلایدها

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **مقدار Enum SmartArtLayoutType.Custom اضافه شد**
این نوع طرح‌بندی SmartArt نمایانگر نموداری با الگوی سفارشی است. نمودارهای سفارشی فقط می‌توانند از فایل ارائه بارگذاری شوند و نمی‌توانند از طریق متد ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) ایجاد شوند.
### **کلاس SmartArtShape و اینترفیس ISmartArtShape اضافه شد**
کلاس Aspose.Slides.SmartArt.SmartArtShape (و اینترفیس Aspose.Slides.SmartArt.ISmartArtShape) دسترسی به اشکال منفرد داخل نمودار SmartArt را فراهم می‌کند. SmartArtShape می‌تواند برای تغییر FillFormat، LineFormat، اضافه کردن پیوندها و غیره استفاده شود.

{{% alert color="primary" %}}
SmartArtShape از ویژگی‌های IShape شامل RawFrame، Frame، Rotation، X، Y، Width، Height پشتیبانی نمی‌کند و هنگام دسترسی به آن‌ها استثنای System.NotSupportedException تولید می‌کند.
{{% /alert %}}

مثال استفاده:

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **کلاس SmartArtShapeCollection، اینترفیس ISmartArtShapeCollection و متد ISmartArtNode.getShapes() اضافه شده‌اند**
کلاس Aspose.Slides.SmartArt.SmartArtShapeCollection (و اینترفیس Aspose.Slides.SmartArt.ISmartArtShapeCollection) دسترسی به اشکال منفرد داخل نمودار SmartArt را فراهم می‌کند. این مجموعه شامل اشکال مرتبط با SmartArtNode است. ویژگی SmartArtNode.Shapes مجموعه‌ای از تمام اشکال مرتبط با گره را برمی‌گرداند.

{{% alert color="primary" %}}
بسته به SmartArtLayoutType، یک SmartArtShape می‌تواند بین چند گره به اشتراک گذاشته شود.
{{% /alert %}}

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```