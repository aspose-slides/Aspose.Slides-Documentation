---
title: مدیریت OLE در ارائه‌ها با استفاده از JavaScript
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/nodejs-java/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی شیء
- اضافه کردن OLE
- جاسازی OLE
- اضافه کردن شیء
- جاسازی شیء
- اضافه کردن فایل
- جاسازی فایل
- شیء پیوند شده
- فایل پیوند شده
- تغییر OLE
- آیکون OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت اشیای OLE در فایل‌های PowerPoint و OpenDocument را با Aspose.Slides برای Node.js via Java بهینه کنید. محتویات OLE را به‌صورت یکپارچه جاسازی، به‌روزرسانی و خروجی بگیرید."
---
## **مقدمه**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، از طریق پیوند یا جاسازی در برنامهٔ دیگری قرار گیرند. 

{{% /alert %}} 

مثلاً یک نمودار که در MS Excel ایجاد شده است را در نظر بگیرید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel یک شیء OLE محسوب می‌شود. 

- یک شیء OLE ممکن است به‌صورت یک آیکون ظاهر شود. در این حالت، هنگام دوبار کلیک روی آیکون، نمودار در برنامهٔ مرتبط (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای را برای باز کردن یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE ممکن است محتویات واقعی خود را نمایش دهد، مانند محتویات یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را درون PowerPoint اصلاح کنید. 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/fa/nodejs-java/) به شما امکان می‌دهد OLE Objects را به اسلایدها به‌عنوان فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/OleObjectFrame)) وارد کنید.

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید پیش از این یک نمودار در Microsoft Excel ساخته‌اید و می‌خواهید آن را به‌عنوان فریم شیء OLE در یک اسلاید جاسازی کنید با استفاده از Aspose.Slides for Node.js via Java؛ می‌توانید به این شکل عمل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. فایل Excel را به‌صورت آرایه بایت بخوانید.  
4. [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/OleObjectFrame) را به اسلاید اضافه کنید به‌طوری که آرایه بایت و سایر اطلاعات شیء OLE را شامل شود.  
5. ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.  

در مثال زیر، ما یک نمودار از یک فایل Excel را به‌عنوان فریم شیء OLE به اسلاید اضافه کردیم با استفاده از Aspose.Slides for Node.js via Java.  
**Note** این که سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/OleEmbeddedDataInfo) پسوند شیء جاسازی‌شده را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint اجازه می‌دهد نوع فایل را به‌درستی تفسیر کند و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب نماید.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// داده‌ها را برای شیء OLE آماده کنید.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// فریم شیء OLE را به اسلاید اضافه کنید.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **افزودن فریم‌های شیء OLE پیوند شده**

Aspose.Slides for Node.js via Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/OleObjectFrame) را بدون جاسازی داده، تنها با یک پیوند به فایل اضافه کنید.

این کد JavaScript به شما نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/OleObjectFrame) با یک فایل Excel پیوند شده به اسلاید اضافه کنید:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// فریم شیء OLE را با یک فایل Excel پیوند شده اضافه کنید.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به‌راحتی آن را پیدا یا دسترسی پیدا کنید به این شکل:

1. یک ارائه با شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از شاخص آن دریافت کنید.  
3. شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/OleObjectFrame) را دسترسی بگیرید. در مثال ما، از PPTX قبلاً ساخته‌شده‌ای استفاده کردیم که تنها یک شکل در اسلاید اول دارد.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را بر روی آن انجام دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel که در اسلاید جاسازی شده) و داده‌های فایل آن دسترسی پیدا می‌شوند.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // دریافت داده‌های فایل جاسازی‌شده.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // دریافت پسوند فایل جاسازی‌شده.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **دسترسی به ویژگی‌های فریم شیء OLE پیوند شده**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های فریم شیء OLE پیوند شده دسترسی پیدا کنید.

این کد JavaScript نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE پیوند شده است و سپس مسیر فایل پیوند شده را به‌دست آورید:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // بررسی کنید آیا شیء OLE پیوند شده است.
    if (oleFrame.isObjectLink()) {
        // مسیر کامل فایل پیوند شده را چاپ کنید.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // اگر موجود باشد مسیر نسبی فایل پیوند شده را چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغییر داده‌های شیء OLE**

{{% alert color="primary" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells for Java](/cells/java/) استفاده می‌کند.  

{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به‌راحتی به آن شیء دسترسی پیدا کنید و داده‌های آن را به این شکل اصلاح کنید:

1. یک ارائه با شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. شکل فریم شیء OLE را دسترسی بگیرید. در مثال ما، از PPTX قبلاً ساخته‌شده‌ای استفاده کردیم که یک شکل در اسلاید اول دارد.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را بر روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.  
6. `Worksheet` موردنظر را دسترسی بگیرید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روز شده را در یک جریان (stream) ذخیره کنید.  
8. داده‌های شیء OLE را از جریان تغییر دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel که در اسلاید جاسازی شده) دسترسی پیدا می‌کند و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // داده‌های شیء OLE را به‌عنوان یک شیء Workbook بخوانید.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // داده‌های کتاب‌کار (Workbook) را اصلاح کنید.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // داده‌های شیء فریم OLE را تغییر دهید.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides for Node.js via Java به شما امکان می‌دهد انواع دیگر فایل‌ها را در اسلایدها جاسازی کنید. برای مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء درج کنید. زمانی که کاربر روی شیء درج‌شده دوبار کلیک می‌کند، به‌طور خودکار در برنامهٔ مربوطه باز می‌شود یا از کاربر خواسته می‌شود برنامهٔ مناسبی برای باز کردن آن انتخاب کند.

این کد JavaScript نشان می‌دهد چگونه HTML و ZIP را در اسلاید جاسازی کنید:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **تنظیم نوع فایل برای اشیای جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیای OLE قدیمی را با اشیای جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for Node.js via Java به شما اجازه می‌دهد نوع فایل برای یک شیء جاسازی‌شده تنظیم شود، که امکان به‌روزرسانی داده‌های فریم OLE یا پسوند آن را فراهم می‌کند.

این کد JavaScript نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده را به `zip` تنظیم کنید:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **تنظیم تصویر آیکون و عنوان برای اشیای جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی که متشکل از یک تصویر آیکون است به‌طور خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با استفاده از Aspose.Slides for Node.js via Java تنظیم کنید.

این کد JavaScript نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// افزودن یک تصویر به منابع ارائه.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **جلوگیری از تغییر اندازه و مکان فریم شیء OLE**

پس از افزودن یک شیء OLE پیوند شده به اسلاید ارائه، هنگام باز کردن ارائه در PowerPoint ممکن است پیغامی ببینید که از شما می‌خواهد پیوندها را به‌روز کنید. کلیک روی دکمهٔ "Update Links" ممکن است اندازه و مکان فریم شیء OLE را تغییر دهد؛ زیرا PowerPoint داده‌ها را از شیء OLE پیوند شده به‌روز می‌کند و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، از متد `setUpdateAutomatic` کلاس [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe/) با مقدار `false` استفاده کنید:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for Node.js via Java به شما اجازه می‌دهد فایل‌های جاسازی‌شده در اسلایدها به‌عنوان اشیاء OLE را به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید که شامل اشیای OLE موردنظر برای استخراج باشد.  
2. در تمام اشکال موجود در ارائه حلقه بزنید و اشکال [OLEObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe) را دسترسی بگیرید.  
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های OLEObject استخراج کنید و روی دیسک بنویسید.  

این کد JavaScript نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟**  

آنچه در اسلاید قابل‌مشاهده است رندر می‌شود—آیکون/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در زمان رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر موردنظر در PDF خروجی تضمین شود.

**چگونه می‌توانم یک شیء OLE را روی اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابه‌جا یا ویرایش کنند؟**  

قفل کردن شکل: Aspose.Slides قفل‌های سطح شکل را فراهم می‌کند. این قفل‌ها رمزگذاری نیستند، اما به‌طور مؤثر از ویرایش و جابه‌جایی تصادفی جلوگیری می‌کنند.

**آیا مسیرهای نسبی برای اشیای OLE پیوند شده در فرمت PPTX حفظ می‌شوند؟**  

در PPTX اطلاعات «مسیر نسبی» موجود نیست—فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در فرمت قدیمی PPT یافت می‌شوند. برای قابلیت حمل، بهتر است از مسیرهای مطلق قابل‌اعتماد یا URIهای در دسترس یا جاسازی استفاده کنید.