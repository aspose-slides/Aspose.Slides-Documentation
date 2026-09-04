---
title: مدیریت ویژگی‌های ارائه در جاوااسکریپت
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/nodejs-java/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های درون‌ساخته
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- اصلاح ویژگی‌ها
- متادیتای سند
- ویرایش متادیتا
- زبان اصلاحیه
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "در Aspose.Slides برای Node.js via Java، ویژگی‌های ارائه را به‌طور کامل مدیریت کنید و جستجو، برندسازی و جریان کار را در فایل‌های PowerPoint و OpenDocument خود ساماندهی کنید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو این نوع ویژگی‌ها می‌توانند به راحتی با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد تا با ویژگی‌های سند ارائه از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties/) کار کنید. یک نمونه از این کلاس توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDocumentProperties) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، اصلاح کنید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل تغییر نیستند. Aspose.Slides در هر بار ذخیره آنها را بازنویسی می‌کند، بنابراین یک ارائهٔ ذخیره‌شده همیشه گزارش می‌دهد «Aspose.Slides for Node.js via Java» و نسخهٔ کتابخانه‌ای که آن را تولید کرده است. هر مقداری که به `setNameOfApplication` پاس داده شود هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی‌ای برای افزودن برخی ویژگی‌ها به فایل‌های ارائه ارائه می‌دهد. این ویژگی‌های سند اجازه می‌دهند اطلاعات مفیدی همراه با اسناد (فایل‌های ارائه) ذخیره شود. دو نوع ویژگی سند به شرح زیر وجود دارد

- ویژگی‌های تعریف‌شده توسط سیستم (Built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (Custom)

**Built-in** ویژگی‌های کلی دربارهٔ سند مانند عنوان سند، نام نویسنده، آمار سند و غیره را شامل می‌شود. **Custom** ویژگی‌هایی هستند که توسط کاربران به صورت جفت‌های **Name/Value** تعریف می‌شوند، به طوری که هم نام و هم مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for Node.js via Java، توسعه‌دهندگان می‌توانند به مقادیر ویژگی‌های درون‌ساخته و سفارشی دسترسی پیدا کنند و آنها را اصلاح کنند.

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. برای این کار کافی است روی نماد Office کلیک کنید و سپس گزینهٔ **Prepare | Properties | Advanced Properties** منوی Microsoft PowerPoint 2007 را همان‌طور که در زیر نشان داده شده است انتخاب کنید:

|**انتخاب گزینهٔ Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

پس از انتخاب گزینهٔ **Advanced Properties**، دیالوگی ظاهر می‌شود که امکان مدیریت ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر نشان داده شده است، فراهم می‌کند:

|**دیالوگ ویژگی‌ها**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

در **دیالوگ ویژگی‌ها** بالا، می‌توانید ببینید که چندین صفحهٔ برگه مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom** وجود دارد. همه این برگه‌ها امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. برگهٔ **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **کار با ویژگی‌های سند با استفاده از Aspose.Slides for Node.js via Java**

همان‌طور که قبلاً توضیح دادیم Aspose.Slides برای Node.js via Java از دو نوع ویژگی سند پشتیبانی می‌کند که **Built-in** و **Custom** هستند. بنابراین، توسعه‌دهندگان می‌توانند به هر دو نوع ویژگی با استفاده از API Aspose.Slides برای Node.js via Java دسترسی داشته باشند. Aspose.Slides برای Node.js via Java یک کلاس به نام [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نشان می‌دهد.

توسعه‌دهندگان می‌توانند از ویژگی **DocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) در دسترس است، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در ادامه توضیح داده شده است، استفاده کنند:

## **خواندن ویژگی‌های عمومی از یک ارائهٔ رمزگذاری شده**

یک رمز عبور باز کردن معمولاً محتوای ارائه و ویژگی‌های سند را محافظت می‌کند. وقتی یک ارائه با عبور `false` به [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) رمزگذاری می‌شود، ویژگی‌های سند آن عمومی می‌مانند. سپس یک برنامه می‌تواند `true` را به [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) پاس دهد و متادیتای عمومی را بدون وارد کردن رمز عبور باز کردن بخواند.

گزینهٔ بارگذاری فقط‑ویژگی‌های‑سند، آنچه Aspose.Slides بارگذاری می‌کند را کنترل می‌کند؛ هیچ چیزی را رمزگشایی نمی‌کند. اگر این ویژگی‌ها در رمزنگاری گنجانده شوند، بارگذاری آنها بدون رمز عبور ناموفق می‌شود. اگر ارائه رمزگذاری شده نباشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

مثال زیر حالت بارگذاری را از طریق [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) بررسی می‌کند و سپس ویژگی‌های درون‌ساخته را از طریق [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDocumentProperties) می‌خواند:

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، چیدمان‌ها، شکل‌ها، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید قبل از انجام عملیاتی که به مدل کامل شیء ارائه نیاز دارد، همیشه [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
متادیتای عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساس را به همراه ارائه رمزگذاری کنید. فقط زمانی که سیستم‌های نمایه‌سازی، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون رمز عبور داشته باشند، آنها را عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائهٔ رمزگذاری شده**

برای یک فایل PPTX رمزگذاری‌شده، یک ارائه که در حالت فقط‑ویژگی‌های‑سند بارگذاری شود برای خواندن متادیتای عمومی منظور شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متادیتا ذخیره کند، زیرا ویژگی‌های عمومی باید با داده‌های متناظر داخل ارائهٔ رمزگذاری شده هم‌خوانی داشته باشند. بنابراین به‌روزرسانی آنها نیاز به رمز عبور باز کردن صحیح و بارگذاری کامل دارد.

مثال زیر ارائه را با [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) باز می‌کند، ویژگی‌های عمومی درون‌ساخته را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) صحت رمزنگاری را بررسی می‌کند و متادیتای عمومی را بدون رمز عبور دوباره باز می‌کند تا مقادیر جدید را تأیید کند:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

اگر یک برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های درون‌ساخته**

این ویژگی‌ها که توسط شیء [DocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties) افشا می‌شوند شامل: **Creator** (Author)، **Description**، **Keywords**، **Created** (Creation Date)، **Modified** (Modification Date)، **Printed** (Last Print Date)، **LastModifiedBy**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده؟)، **PresentationFormat**، **Subject** و **Title** می‌باشند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// نمونه‌سازی کلاس Presentation که نمایانگر ارائه است
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // ایجاد یک ارجاع به شیء IDocumentProperties مربوط به Presentation
    var dp = pres.getDocumentProperties();
    // نمایش ویژگی‌های درون‌ساخته
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

## **اصلاح ویژگی‌های درون‌ساخته**

اصلاح ویژگی‌های درون‌ساختهٔ فایل‌های ارائه به سادگی همانند دسترسی به آنهاست. می‌توانید به سادگی مقدار رشته‌ای را به هر ویژگی مورد نظر اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان داده‌ایم چگونه می‌توان ویژگی‌های درون‌ساختهٔ سند ارائه را با استفاده از Aspose.Slides for Node.js via Java اصلاح کرد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // ایجاد یک ارجاع به شیء IDocumentProperties مرتبط با Presentation
    var dp = pres.getDocumentProperties();
    // تنظیم ویژگی‌های درون‌ساخته
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // ذخیرهٔ ارائهٔ خود به یک فایل
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این مثال ویژگی‌های درون‌ساختهٔ ارائه را که می‌توانید همان‌طور که در زیر آمده است مشاهده کنید، اصلاح می‌کند:

|**ویژگی‌های سند درون‌ساخته پس از اصلاح**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سند سفارشی**

Aspose.Slides for Node.js via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر نشان می‌دهد چگونه ویژگی‌های سفارشی را برای یک ارائه تنظیم کنیم.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
    // ذخیره‌سازی ارائه
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**ویژگی‌های سند سفارشی افزوده شده**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و اصلاح ویژگی‌های سفارشی**

Aspose.Slides for Node.js via Java همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی پیدا کنند. مثال زیر نشان می‌دهد چگونه می‌توانید تمام این ویژگی‌های سفارشی یک ارائه را دسترسی و اصلاح کنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // ایجاد یک ارجاع به شیء DocumentProperties مرتبط با Presentation
    var dp = pres.getDocumentProperties();
    // دسترسی و اصلاح ویژگی‌های سفارشی
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // اصلاح مقادیر ویژگی‌های سفارشی
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // ذخیرهٔ ارائهٔ شما به یک فایل
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این مثال ویژگی‌های سفارشی پرونده [PPTX](https://docs.fileformat.com/presentation/pptx/) را اصلاح می‌کند. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از اصلاح نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از اصلاح**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی پس از اصلاح**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های سند پیشرفته**

{{% alert color="info" title="Note" %}}
متدهای جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) به [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo) اضافه شده‌اند، منطق setter ویژگی [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) تغییر یافته است.
{{% /alert %}} 

دو متد جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PresentationInfo) اضافه شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم می‌کند و اجازه می‌دهد بدون بارگذاری کل ارائه، ویژگی‌ها را تغییر و به‌روزرسانی کنید.

سناریوی معمول بارگذاری ویژگی‌ها، تغییر مقداری و به‌روزرسانی سند می‌تواند به شکل زیر پیاده‌سازی شود:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// اطلاعات ارائه را بخوانید
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

راه دیگری برای استفاده از ویژگی‌های یک ارائه خاص به عنوان الگو برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر وجود دارد:

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

یک الگوی جدید می‌تواند از ابتدا ایجاد شود و سپس برای به‌روزرسانی چندین ارائه استفاده گردد:

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

## **تنظیم زبان اصلاحیه**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat افشا می‌شود) را فراهم می‌کند تا بتوانید زبان اصلاحیه را برای یک سند PowerPoint تنظیم کنید. زبان اصلاحیه زبانی است که املا و گرامر در PowerPoint برای آن بررسی می‌شود.

این کد JavaScript نشان می‌دهد چگونه زبان اصلاحیه را برای یک PowerPoint تنظیم کنید: xxx چرا LanguageId در کلاس JavaScript PortionFormat موجود نیست؟

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
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم زبان پیش‌فرض**

این کد JavaScript نشان می‌دهد چگونه زبان پیش‌فرض را برای یک ارائهٔ PowerPoint کامل تنظیم کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // افزودن یک شکل مستطیلی جدید با متن
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // بررسی زبان اولین قسمت
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مثال زنده**

برای مشاهدهٔ نحوه کار با ویژگی‌های سند از طریق Aspose.Slides API، برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سؤالات متداول**

**چگونه می‌توان یک ویژگی درون‌ساخته را از یک ارائه حذف کرد؟**

ویژگی‌های درون‌ساخته بخشی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را به‌طور کامل حذف کرد. با این حال می‌توانید مقادیر آنها را تغییر دهید یا در صورت امکان به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که قبلاً وجود داشته باشد اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی ویژگی پیش از افزودن نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی داشته باشم؟**

بله. از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) استفاده کنید و سپس [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) را برای خواندن متادیتای ذخیره‌شدهٔ سند بدون ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) فراخوانی کنید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به [Build a Lightweight Presentation Inventory](/slides/fa/nodejs-java/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائهٔ رمزگذاری‌شده را بدون رمز عبور باز کردن بخوانم؟**

بله. رمزنگاری ویژگی‌های سند باید پیش از رمزگذاری ارائه غیرفعال شده باشد و ارائه باید در حالت فقط‑ویژگی‌های‑سند بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑ویژگی‌های‑سند به‌روزرسانی کنم؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید هماهنگ بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور صحیح باز کردن است.