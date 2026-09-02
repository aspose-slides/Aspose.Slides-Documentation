---
title: مدیریت خصوصیات ارائه در JavaScript
linktitle: خصوصیات ارائه
type: docs
weight: 70
url: /fa/nodejs-java/presentation-properties/
keywords:
- خصوصیات PowerPoint
- خصوصیات ارائه
- خصوصیات سند
- خصوصیات داخلی
- خصوصیات سفارشی
- خصوصیات پیشرفته
- مدیریت خصوصیات
- تغییر خصوصیات
- فراداده سند
- ویرایش فراداده
- زبان بررسی
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "در Aspose.Slides برای Node.js via Java، به‌خوبی خصوصیات ارائه را مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides از دو نوع خصوصیت سند پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این خصوصیت‌ها به راحتی می‌توانند از طریق Aspose.Slides API دسترسی پیدا کرده و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد تا با خصوصیات سند ارائه از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) کار کنید. یک نمونه از این کلاس توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDocumentProperties) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه می‌توان این خصوصیت‌ها را خواند، تغییر داد و مدیریت کرد.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل ویرایش نیستند. Aspose.Slides آن‌ها را در هر ذخیره‌سازی بازنویسی می‌کند، بنابراین یک ارائه ذخیره‌شده همیشه گزارش می‌دهد «Aspose.Slides for Node.js via Java» و نسخه‌ی کتابخانه‌ای که آن را تولید کرده است. هر مقدار پاس‌شده به `setNameOfApplication` هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}} 

## **مدیریت خصوصیات ارائه**

Microsoft PowerPoint ویژگی‌ای برای افزودن برخی خصوصیات به فایل‌های ارائه فراهم می‌کند. این خصوصیات سند اجازه می‌دهند اطلاعات مفیدی همراه با اسناد (فایل‌های ارائه) ذخیره شود. دو نوع خصوصیت سند به شرح زیر وجود دارد

- خصوصیات تعریف‌شده توسط سیستم (Built-in)
- خصوصیات تعریف‌شده توسط کاربر (Custom)

خصوصیات **Built-in** شامل اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آماری سند و غیره هستند. خصوصیات **Custom** آن دسته از خصوصیت‌هایی هستند که توسط کاربران به صورت جفت‌های **Name/Value** تعریف می‌شوند، جایی که هر دو نام و مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for Node.js via Java، توسعه‌دهندگان می‌توانند به مقادیر خصوصیات داخلی و سفارشی دسترسی پیدا کرده و آن‌ها را تغییر دهند.

## **خصوصیات سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت خصوصیات سند فایل‌های ارائه را فراهم می‌کند. تنها کاری که باید انجام دهید این است که روی نماد Office کلیک کنید و سپس منوی **Prepare | Properties | Advanced Properties** در Microsoft PowerPoint 2007 را همان‌طور که در زیر نشان داده شده است، انتخاب کنید:

|**انتخاب گزینه منوی Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
پس از انتخاب گزینه منوی **Advanced Properties**، یک دیالوگ ظاهر می‌شود که به شما امکان مدیریت خصوصیات سند فایل PowerPoint را همان‌طور که در شکل زیر نشان داده شده است، می‌دهد:

|**دیالوگ خصوصیات**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
در **دیالوگ خصوصیات** بالا، می‌توانید ببینید که صفحات تب متعددی مانند **General**, **Summary**, **Statistics**, **Contents** و **Custom** وجود دارد. همه این صفحات تب اجازه پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را می‌دهند. تب **Custom** برای مدیریت خصوصیات سفارشی فایل‌های PowerPoint استفاده می‌شود.

کار با خصوصیات سند با استفاده از Aspose.Slides for Node.js via Java

همان‌طور که قبلاً توضیح دادیم، Aspose.Slides for Node.js via Java از دو نوع خصوصیات سند پشتیبانی می‌کند که **Built-in** و **Custom** هستند. بنابراین، توسعه‌دهندگان می‌توانند هر دو نوع خصوصیت را با استفاده از API Aspose.Slides for Node.js via Java دسترسی پیدا کنند. Aspose.Slides for Node.js via Java کلاسی به نام [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties) فراهم می‌کند که خصوصیات سند مرتبط با یک فایل ارائه را از طریق خصوصیت **Presentation.DocumentProperties** نشان می‌دهد.

توسعه‌دهندگان می‌توانند از خصوصیت **DocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) نمایان می‌شود، برای دسترسی به خصوصیات سند فایل‌های ارائه همان‌طور که در زیر توضیح داده شده است، استفاده کنند:

## **دسترسی به خصوصیات داخلی**

این خصوصیات که توسط شیء [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties) نمایان می‌شوند شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به‌اشتراک‌گذاری شده است؟)، **PresentationFormat**، **Subject** و **Title** هستند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که نمایانگر ارائه است
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // ایجاد مرجع به شیء IDocumentProperties مرتبط با Presentation
    var dp = pres.getDocumentProperties();
    // نمایش خصوصیات داخلی
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر خصوصیات داخلی**

تغییر خصوصیات داخلی فایل‌های ارائه به اندازه دسترسی به آن‌ها آسان است. می‌توانید به سادگی مقدار متنی را به هر خصوصیت دلخواه اختصاص دهید و مقدار خصوصیت تغییر خواهد کرد. در مثال زیر، نشان دادیم چگونه می‌توانیم خصوصیات داخلی سند ارائه را با استفاده از Aspose.Slides for Node.js via Java تغییر دهیم.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // ایجاد مرجع به شیء IDocumentProperties مرتبط با Presentation
    var dp = pres.getDocumentProperties();
    // تنظیم خصوصیات داخلی
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // ذخیره ارائه شما در یک فایل
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این مثال خصوصیات داخلی ارائه را که می‌توان به صورت زیر مشاهده کرد، تغییر می‌دهد:

|**خصوصیات داخلی سند پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن خصوصیات سفارشی سند**

Aspose.Slides for Node.js via Java همچنین به توسعه‌دهندگان امکان می‌دهد مقادیر سفارشی برای خصوصیات سند ارائه اضافه کنند. مثال زیر نشان می‌دهد چگونه می‌توان خصوصیات سفارشی را برای یک ارائه تنظیم کرد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // دریافت خصوصیات سند
    var dProps = pres.getDocumentProperties();
    // افزودن خصوصیات سفارشی
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // دریافت نام خصوصیت در شاخص خاص
    var getPropertyName = dProps.getCustomPropertyName(2);
    // حذف خصوصیت انتخاب‌شده
    dProps.removeCustomProperty(getPropertyName);
    // ذخیره ارائه
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**خصوصیات سفارشی سند افزوده شد**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و تغییر خصوصیات سفارشی**

Aspose.Slides for Node.js via Java همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر خصوصیات سفارشی دسترسی پیدا کنند. مثال زیر نشان می‌دهد چگونه می‌توانید به تمام این خصوصیات سفارشی برای یک ارائه دسترسی پیدا کنید و آن‌ها را تغییر دهید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // ایجاد مرجع به شیء DocumentProperties مرتبط با Presentation
    var dp = pres.getDocumentProperties();
    // دسترسی و تغییر خصوصیات سفارشی
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // نمایش نام‌ها و مقادیر خصوصیات سفارشی
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // تغییر مقادیر خصوصیات سفارشی
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // ذخیره ارائه شما در یک فایل
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این مثال خصوصیات سفارشی ارائه [PPTX](https://docs.fileformat.com/presentation/pptx/) را تغییر می‌دهد. شکل‌های زیر خصوصیات سفارشی ارائه را قبل و بعد از تغییر نشان می‌دهند:

|**خصوصیات سفارشی قبل از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**خصوصیات سفارشی پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصوصیات پیشرفته سند**

{{% alert color="info" title="Note" %}}
متدهای جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo) اضافه شده‌اند، منطق setter خصوصیت [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) تغییر یافته است.
{{% /alert %}} 

دو متد جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo) اضافه شده‌اند. آن‌ها دسترسی سریع به خصوصیات سند را فراهم می‌کنند و امکان تغییر و به‌روز رسانی خصوصیات بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمول که خصوصیات را بارگذاری، مقداری را تغییر داده و سند را به‌روز می‌کند، می‌تواند به شکل زیر پیاده‌سازی شود:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// خواندن اطلاعات ارائه
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// دریافت خصوصیات فعلی
var props = info.readDocumentProperties();
// تنظیم مقادیر جدید فیلدهای Author و Title
props.setAuthor("New Author");
props.setTitle("New Title");
// به‌روزرسانی ارائه با مقادیر جدید
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

راه دیگری نیز وجود دارد که با استفاده از خصوصیات یک ارائه خاص به عنوان قالب، خصوصیات در ارائه‌های دیگر را به‌روز کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

یک قالب جدید می‌تواند از ابتدا ایجاد شود و سپس برای به‌روز کردن چندین ارائه استفاده شود:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تنظیم زبان بررسی**

Aspose.Slides خصوصیت LanguageId (نمایان شده توسط کلاس PortionFormat) را فراهم می‌کند تا به شما امکان تنظیم زبان بررسی برای یک سند PowerPoint را بدهد. زبان بررسی زبانی است که املا و دستور زبان در PowerPoint برای آن بررسی می‌شود.

این کد JavaScript نشان می‌دهد چگونه زبان بررسی برای PowerPoint تنظیم شود: xxx چرا LanguageId در کلاس JavaScript PortionFormat موجود نیست؟

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// تنظیم شناسه زبان بررسی
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم زبان پیش‌فرض**

این کد JavaScript نشان می‌دهد چگونه زبان پیش‌فرض برای کل ارائه PowerPoint تنظیم شود:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // یک شکل مستطیل جدید با متن اضافه می‌کند
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // زبان اولین بخش را بررسی می‌کند
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مثال تعاملی**

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توان با خصوصیات سند از طریق API Aspose.Slides کار کرد:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سؤالات متداول**

**چگونه می‌توان یک خصوصیت داخلی را از یک ارائه حذف کرد؟**

خصوصیات داخلی بخش جدایی‌ناپذیری از ارائه هستند و نمی‌توانند به‌ طور کامل حذف شوند. اما می‌توانید مقادیر آن‌ها را تغییر دهید یا اگر خصوصیت اجازهٔ مقدار خالی را می‌دهد، آن را خالی تنظیم کنید.

**اگر یک خصوصیت سفارشی که قبلاً وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک خصوصیت سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی خصوصیت نیست، زیرا Aspose.Slides به‌صورت خودکار مقدار خصوصیت را به‌روز می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه به خصوصیات آن دسترسی پیدا کنم؟**

بله. از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) و سپس [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) استفاده کنید تا متادیتای ذخیره‌شده سند را بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به [Build a Lightweight Presentation Inventory](/slides/fa/nodejs-java/examine-presentation/) مراجعه کنید.