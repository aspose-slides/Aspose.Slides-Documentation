---
title: مدیریت OLE در ارائه‌ها با استفاده از JavaScript
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/nodejs-java/manage-ole/
keywords:
- شی OLE
- پیوند و جاسازی اشیا
- افزودن OLE
- جاسازی OLE
- افزودن شی
- جاسازی شی
- افزودن فایل
- جاسازی فایل
- شی پیوندی
- فایل پیوندی
- تغییر OLE
- نماد OLE
- عنوان OLE
- استخراج OLE
- استخراج شی
- استخراج فایل
- پاورپوینت
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیای OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js via Java. به‌صورت یکپارچه OLE را جاسازی، به‌روزرسانی و صادر کنید."
---
## **مقدمه**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیایی که در یک برنامه ایجاد شده‌اند، از طریق پیوند یا جاسازی در برنامه دیگری قرار گیرند. 

{{% /alert %}} 

یک نمودار ایجاد شده در MS Excel را در نظر بگیرید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شی OLE درنظر گرفته می‌شود. 

- یک شی OLE ممکن است به صورت یک نماد ظاهر شود. در این صورت، وقتی دو بار روی نماد کلیک می‌کنید، نمودار در برنامه مرتبط (Excel) باز می‌شود، یا از شما خواسته می‌شود تا برنامه‌ای برای باز یا ویرایش شی انتخاب کنید.  
- یک شی OLE ممکن است محتوای واقعی خود را نمایش دهد، مانند محتوای یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را داخل PowerPoint تغییر دهید.  

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) به شما امکان می‌دهد اشیاء OLE را به اسلایدها به عنوان فریم‌های شی OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)) درج کنید.

## **افزودن فریم‌های شی OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به عنوان فریم شی OLE در یک اسلاید با استفاده از Aspose.Slides for Node.js via Java جاسازی کنید؛ می‌توانید این کار را به این روش انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن به دست آورید.  
3. فایل Excel را به صورت آرایه‌ای از بایت‌ها بخوانید.  
4. فریم [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) را به اسلاید اضافه کنید که شامل آرایه بایت و سایر اطلاعات درباره شی OLE باشد.  
5. ارائه تغییر یافته را به‌صورت فایل PPTX بنویسید.  

در مثال زیر، یک نمودار از فایل Excel را به یک اسلاید به‌عنوان فریم شی OLE با استفاده از Aspose.Slides for Node.js via Java اضافه کردیم. **توجه** داشته باشید که سازنده [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) یک پسوند شی قابل جاسازی را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد نوع فایل را به‌درستی تشخیص داده و برنامه مناسب برای باز کردن این شی OLE را انتخاب کند.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **افزودن فریم‌های شی OLE پیوندی**

Aspose.Slides for Node.js via Java به شما اجازه می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) را بدون جاسازی داده، بلکه فقط با پیوند به فایل اضافه کنید.  

این کد JavaScript نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) را با یک فایل Excel پیوندی به یک اسلاید اضافه کنید:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// یک فریم شی OLE را با یک فایل Excel پیوندی اضافه کنید.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **دسترسی به فریم‌های شی OLE**

اگر یک شی OLE از پیش در اسلاید جاسازی شده باشد، می‌توانید به سادگی آن را به این روش پیدا یا دسترسی پیدا کنید:

1. یک ارائه را که شامل شی OLE جاسازی شده است، با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از شاخص آن دریافت کنید.  
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده استفاده کردیم که تنها یک شکل در اولین اسلاید دارد.  
4. هنگامی که به فریم شی OLE دسترسی پیدا کرد، می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، به فریم شی OLE (یک شی نمودار Excel جاسازی شده در اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شود.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // دریافت داده‌های فایل جاسازی شده.
    // دریافت پسوند فایل جاسازی شده.
    // ...
}
```

### **دسترسی به ویژگی‌های فریم شی OLE پیوندی**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های فریم شی OLE پیوندی دسترسی پیدا کنید.  

این کد JavaScript نشان می‌دهد چگونه بررسی کنید آیا شی OLE پیوندی است و سپس مسیر فایل پیوندی را به‌دست آورید:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // بررسی اینکه آیا شی OLE پیوندی است.
    if (oleFrame.isObjectLink()) {
        // مسیر کامل فایل پیوندی را چاپ کنید.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // در صورت وجود، مسیر نسبی فایل پیوندی را چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغییر داده‌های شی OLE**

{{% alert color="info" title="Note" %}}

در این بخش، مثال کد زیر از [Aspose.Cells for Java](https://docs.aspose.com/cells/java/) استفاده می‌کند.  

{{% /alert %}}

اگر یک شی OLE از پیش در اسلاید جاسازی شده باشد، می‌توانید به سادگی آن شی را دسترسی پیدا کنید و داده‌های آن را به این روش تغییر دهید:

1. یک ارائه را که شامل شی OLE جاسازی شده است، با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق شاخص آن به دست آورید.  
3. به شکل فریم شی OLE دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده استفاده کردیم که یک شکل در اولین اسلاید دارد.  
4. هنگامی که به فریم شی OLE دسترسی پیدا کرد، می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شی `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.  
6. `Worksheet` موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روز شده را در یک جریان ذخیره کنید.  
8. داده‌های شی OLE را از جریان تغییر دهید.  

در مثال زیر، به فریم شی OLE (یک شی نمودار Excel جاسازی شده در اسلاید) دسترسی پیدا می‌شود و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شوند.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // داده‌های شی OLE را به عنوان یک شی Workbook بخوانید.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // داده‌های کتاب‌کار را اصلاح کنید.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // داده‌های شی فریم OLE را تغییر دهید.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **جاسازی انواع فایل‌های دیگر در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides for Node.js via Java به شما اجازه می‌دهد انواع دیگر فایل‌ها را به اسلایدها جاسازی کنید. به‌عنوان مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء درج کنید. وقتی کاربر دو بار روی شی درج‌شده کلیک می‌کند، به‌صورت خودکار در برنامه مربوطه باز می‌شود یا از کاربر خواسته می‌شود برنامه مناسب را برای باز کردن آن انتخاب کند.  

این کد JavaScript نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید جاسازی کنید:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

## **تنظیم نوع فایل برای اشیاء جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با جدیدهایشان جایگزین کنید یا شی OLE پشتیبانی‌نشده‌ای را با یک شی پشتیبانی‌شده عوض کنید. Aspose.Slides for Node.js via Java به شما امکان می‌دهد نوع فایل برای یک شی جاسازی‌شده را تنظیم کنید تا بتوانید داده‌های فریم OLE یا پسوند آن را به‌روزرسانی کنید.  

این کد JavaScript نشان می‌دهد چگونه نوع فایل برای یک شی OLE جاسازی‌شده به `zip` تنظیم شود:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// تغییر نوع فایل به ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **تنظیم تصاویر نماد و عناوین برای اشیاء جاسازی‌شده**

پس از جاسازی یک شی OLE، پیش‌نمایشی متشکل از یک تصویر نماد به‌طور خودکار افزوده می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شی OLE می‌بینند. اگر بخواهید تصویر و متن خاصی را به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر نماد و عنوان را با استفاده از Aspose.Slides for Node.js via Java تنظیم کنید.  

این کد JavaScript نشان می‌دهد چگونه تصویر نماد و عنوان را برای یک شی جاسازی‌شده تنظیم کنید:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// یک تصویر را به منابع ارائه اضافه کنید.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// یک عنوان و تصویر را برای پیش‌نمایش OLE تنظیم کنید.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت فریم شی OLE**

پس از افزودن یک شی OLE پیوندی به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیامی ببینید که از شما می‌خواهد پیوندها را بروزرسانی کنید. کلیک بر دکمه «Update Links» می‌تواند اندازه و موقعیت فریم شی OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شی OLE پیوندی به‌روز کرده و پیش‌نمایش شی را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای بروزرسانی داده‌های شی، متد [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) کلاس [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) را با مقدار `false` فراخوانی کنید:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for Node.js via Java به شما اجازه می‌دهد فایل‌های جاسازی‌شده در اسلایدها را به‌عنوان اشیاء OLE به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) ایجاد کنید که شامل اشیاء OLE مورد نظر برای استخراج باشد.  
2. از طریق تمام اشکال در ارائه پیمایش کنید و به اشکال [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe) دسترسی پیدا کنید.  
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های شی OLE دسترسی پیدا کنید و به دیسک بنویسید.  

این کد JavaScript نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

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

## **سوالات متداول**

**آیا محتوای OLE هنگام استخراج اسلایدها به PDF/تصاویر رندر می‌شود؟**  

آنچه در اسلاید قابل رؤیت است رندر می‌شود — نماد/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش دلخواه خود را تنظیم کنید تا ظاهر مورد انتظار در PDF استخراج‌شده حفظ شود.  

برای حفظ فایل جاسازی‌شده به‌عنوان پیوست PDF، متد [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) را با مقدار `true` فراخوانی کنید. این گزینه به‌طور پیش‌فرض غیرفعال است. برای مثال و دستورالعمل‌های بررسی پیوست، به [حفظ فایل‌های OLE جاسازی‌شده به عنوان پیوست‌های PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) مراجعه کنید.  

**چگونه می‌توانم یک شی OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابه‌جا/ویرایش کنند؟**  

قفل کردن شکل: Aspose.Slides قفل‌های سطح شکل را فراهم می‌کند. این قفل‌گذاری رمزگذاری نیست، اما به‌طور مؤثری از ویرایش‌ها و جابه‌جایی‌های تصادفی جلوگیری می‌کند.  

**آیا مسیرهای نسبی برای اشیاء OLE پیوندی در فرمت PPTX حفظ می‌شوند؟**  

در PPTX، اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در فرمت قدیمی PPT یافت می‌شوند. برای قابلیت حمل، استفاده از مسیرهای مطلق قابل اطمینان/URIهای در دسترس یا جاسازی را ترجیح دهید.