---
title: مدیریت ویژگی‌های ارائه در JavaScript
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/nodejs-java/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- اصلاح ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مهارت در مدیریت ویژگی‌های ارائه در Aspose.Slides برای Node.js via Java و بهینه‌سازی جستجو، برندسازی و جریان کار در فایل‌های PowerPoint و OpenDocument شما."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع ویژگی به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDocumentProperties) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="primary" %}} 

لطفاً توجه داشته باشید که نمی‌توانید مقادیر فیلدهای **Application** و **Producer** را تنظیم کنید، زیرا Aspose Ltd. و Aspose.Slides for Node.js via Java x.x.x در این فیلدها نمایش داده می‌شوند.

{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint قابلیت افزودن برخی ویژگی‌ها به فایل‌های ارائه را فراهم می‌کند. این ویژگی‌های سند اجازه می‌دهند اطلاعات مفیدی همراه با اسناد (فایل‌های ارائه) ذخیره شود. دو نوع ویژگی سند به شرح زیر وجود دارد:

- ویژگی‌های سیستم (Built-in)
- ویژگی‌های کاربر (Custom)

ویژگی‌های **Built-in** شامل اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره هستند. ویژگی‌های **Custom** آن دسته از ویژگی‌هایی هستند که توسط کاربران به صورت جفت **Name/Value** تعریف می‌شوند، که هر دو نام و مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for Node.js via Java، توسعه‌دهندگان می‌توانند مقادیر ویژگی‌های Built-in و همچنین ویژگی‌های Custom را دسترسی و تغییر دهند.

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. تنها کافی است روی نماد Office کلیک کنید و سپس منوی **Prepare | Properties | Advanced Properties** را در Microsoft PowerPoint 2007 همان‌طور که در زیر نشان داده شده انتخاب کنید:

|**انتخاب منوی Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

پس از انتخاب منوی **Advanced Properties**، دیالوگی ظاهر می‌شود که به شما امکان مدیریت ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر آمده است، می‌دهد:

|**دیالوگ ویژگی‌ها**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

در **دیالوگ ویژگی‌ها** بالا، می‌توانید ببینید که صفحات تب متعددی مانند **General**, **Summary**, **Statistics**, **Contents** و **Custom** وجود دارد. همه این تب‌ها امکان پیکربندی انواع مختلف اطلاعات مربوط به فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

### کار با ویژگی‌های سند با استفاده از Aspose.Slides for Node.js via Java

همان‌طور که در بخش قبل توضیح دادیم Aspose.Slides for Node.js via Java دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. بنابراین، توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides for Node.js via Java به هر دو نوع ویژگی دسترسی داشته باشند. Aspose.Slides for Node.js via Java کلاسی به نام [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نماینده می‌شود.

توسعه‌دهندگان می‌توانند از ویژگی **DocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) در دسترس است، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در ادامه توضیح داده می‌شود، استفاده کنند:

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌های که توسط شیء [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties) نمایش داده می‌شوند شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ اصلاح)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** هستند.

```javascript
// کلاس Presentation که نمایانگر ارائه است را ایجاد می‌کند
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // یک ارجاع به شیء IDocumentProperties مرتبط با ارائه ایجاد می‌کند
    var dp = pres.getDocumentProperties();
    // ویژگی‌های داخلی را نمایش می‌دهد
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

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های Built-in فایل‌های ارائه به اندازه دسترسی به آن‌ها ساده است. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان دادیم چگونه می‌توان ویژگی‌های سند Built-in یک فایل ارائه را با استفاده از Aspose.Slides for Node.js via Java تغییر داد.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // یک ارجاع به شیء IDocumentProperties مرتبط با ارائه ایجاد می‌کند
    var dp = pres.getDocumentProperties();
    // ویژگی‌های داخلی را تنظیم می‌کند
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // ارائه خود را در یک فایل ذخیره کنید
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این مثال ویژگی‌های Built-in ارائه را تغییر می‌دهد که می‌توانید نتیجه را همان‌طور که در زیر نشان داده شده است، مشاهده کنید:

|**ویژگی‌های سند Built-in پس از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سفارشی سند**

Aspose.Slides for Node.js via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر نشان می‌دهد چگونه ویژگی‌های سفارشی برای یک ارائه تنظیم می‌شود.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // دریافت ویژگی‌های سند
    var dProps = pres.getDocumentProperties();
    // افزودن ویژگی‌های سفارشی
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // دریافت نام ویژگی در اندیس مشخص
    var getPropertyName = dProps.getCustomPropertyName(2);
    // حذف ویژگی انتخاب‌شده
    dProps.removeCustomProperty(getPropertyName);
    // ذخیره ارائه
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**ویژگی‌های سفارشی سند اضافه شده**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for Node.js via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر ویژگی‌های سفارشی را دسترسی و تغییر دهند. مثال زیر نشان می‌دهد چگونه می‌توانید تمام این ویژگی‌های سفارشی یک ارائه را دسترسی و تغییر کنید.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // یک ارجاع به شیء DocumentProperties مرتبط با ارائه ایجاد می‌کند
    var dp = pres.getDocumentProperties();
    // دسترسی و تغییر ویژگی‌های سفارشی
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // تغییر مقادیر ویژگی‌های سفارشی
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // ارائه خود را در یک فایل ذخیره کنید
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این مثال ویژگی‌های سفارشی [PPTX](https://docs.fileformat.com/presentation/pptx/) را تغییر می‌دهد. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از تغییر نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی پس از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های پیشرفته سند**

{{% alert color="primary" %}} 

متدهای جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo) اضافه شده‌اند؛ منطق setter ویژگی [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) نیز تغییر یافته است.

{{% /alert %}} 

دو متد جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo) افزوده شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم کرده و امکان تغییر و به‌روزرسانی آنها بدون بارگذاری کامل یک ارائه را می‌دهند.

سناریوی معمول بارگذاری ویژگی‌ها، تغییر مقداری و به‌روزرسانی سند می‌تواند به شکل زیر پیاده‌سازی شود:

```javascript
// اطلاعات ارائه را بخوانید
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

روش دیگری نیز برای استفاده از ویژگی‌های یک ارائه خاص به‌عنوان الگو برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر وجود دارد:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

یک الگوی جدید می‌تواند از صفر ساخته شده و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تنظیم زبان بررسی املایی**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat ارائه می‌شود) را فراهم می‌کند تا بتوانید زبان بررسی املایی یک سند PowerPoint را تنظیم کنید. زبان بررسی املایی زبان برای بررسی املا و گرامر در PowerPoint است.

این کد JavaScript نشان می‌دهد چگونه زبان بررسی املایی برای یک PowerPoint تنظیم شود: xxx چرا LanguageId در کلاس JavaScript PortionFormat موجود نیست؟

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
    portionFormat.setLanguageId("zh-CN");// تنظیم شناسه زبان تصحیح
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم زبان پیش‌فرض**

این کد JavaScript نشان می‌دهد چگونه می‌توانید زبان پیش‌فرض یک ارائه کامل PowerPoint را تنظیم کنید:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // افزودن یک شکل مستطیلی جدید با متن
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // بررسی زبان اولین بخش
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مثال زنده**

اپلیکیشن آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توانید با ویژگی‌های سند از طریق API Aspose.Slides کار کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***سوالات متداول**

**چگونه می‌توان یک ویژگی Built-in را از یک ارائه حذف کرد؟**

ویژگی‌های Built-in جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توانند به‌طور کامل حذف شوند. با این حال می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت اجازه ویژگی، مقدار آن را خالی کنید.

**اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی ویژگی نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کنم؟**

بله، می‌توانید بدون بارگذاری کامل ارائه، با استفاده از متد `getPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/) به ویژگی‌های ارائه دسترسی پیدا کنید. سپس با استفاده از متد `readDocumentProperties` ارائه شده توسط کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) ویژگی‌ها را به‑صورت مؤثر بخوانید که باعث صرفه‌جویی در حافظه و بهبود عملکرد می‌شود.