---
title: رابط عمومی API و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای جاوا 14.9.0
linktitle: Aspose.Slides برای جاوا 14.9.0
type: docs
weight: 80
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "به‌روزرسانی‌های رابط عمومی API و تغییرات ناسازگار در Aspose.Slides برای جاوا را بررسی کنید تا بتوانید به‌صورت روان برنامه‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیرهٔ [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) را فهرست می‌کند، هر محدودیت جدید و سایر [changes](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) معرفی‌شده در API Aspose.Slides for Java 14.9.0.
{{% /alert %}} 
## **Public API Changes**
### **Added Methods for Replacing Image to PPImage, IPPImage**
متدهای جدید اضافه شد:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // راه اول
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // راه دوم
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Added Methods for Saving Slides Keeping Page Numbers**
متدهای زیر اضافه شد:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

این متدها امکان ذخیره اسلایدهای مشخص شدهٔ ارائه را در فرمت‌های PDF، XPS، TIFF، HTML فراهم می‌کنند. آرایهٔ ‘slides’ اجازهٔ تعیین شماره‌های صفحه را از ۱ به بعد می‌دهد.

``` java
// افزودنی‌های overload به IPresentation (مقادیر SaveFormat در جاوا ثابت‌های int هستند):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // آرایه‌ای از موقعیت‌های اسلاید

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Added the SmartArtLayoutType.Custom Enum Value**
این نوع طرح‌بندی SmartArt نشان‌دهندهٔ دیاگرام با قالب سفارشی است. دیاگرام‌های سفارشی فقط می‌توانند از فایل ارائه بارگذاری شوند و نمی‌توانند از طریق متد ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) ساخته شوند.
### **Added the SmartArtShape Class and ISmartArtShape Interface**
کلاس Aspose.Slides.SmartArt.SmartArtShape (و اینترفیس Aspose.Slides.SmartArt.ISmartArtShape) دسترسی به اشکال فردی داخل نمودار SmartArt را فراهم می‌کند. از SmartArtShape می‌توان برای تغییر FillFormat، LineFormat، افزودن Hyperlink و غیره استفاده کرد.

{{% alert color="info" %}} 
SmartArtShape از ویژگی‌های IShape شامل RawFrame، Frame، Rotation، X، Y، Width و Height پشتیبانی نمی‌کند و هنگام دسترسی به آن‌ها System.NotSupportedException را پرتاب می‌کند.
{{% /alert %}} 

مثال استفاده:

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **SmartArtShapeCollection class, ISmartArtShapeCollection interface and ISmartArtNode.getShapes() method have been added**
کلاس Aspose.Slides.SmartArt.SmartArtShapeCollection (و اینترفیس Aspose.Slides.SmartArt.ISmartArtShapeCollection) دسترسی به اشکال فردی داخل نمودار SmartArt را فراهم می‌کند. این مجموعه شامل اشکال مرتبط با SmartArtNode است. خصوصیت SmartArtNode.Shapes مجموعهٔ تمام اشکال مرتبط با گره را برمی‌گرداند.

{{% alert color="info" %}} 
بسته به SmartArtLayoutType، یک SmartArtShape می‌تواند بین چند گره به‌اشتراک گذاشته شود.
{{% /alert %}} 

 
``` java
import com.aspose.slides.*;
import java.awt.Color;


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