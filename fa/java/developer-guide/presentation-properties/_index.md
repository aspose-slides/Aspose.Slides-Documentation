---
title: مدیریت ویژگی‌های ارائه در جاوا
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/java/presentation-properties/
keywords:
- ویژگی‌های پاورپوینت
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان تصحیح
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای جاوا مدیریت کنید و جستجو، برندینگ و جریان کار در فایل‌های پاورپوینت و OpenDocument خود را بهبود بخشید."
---
## **معرفی**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو این نوع ویژگی به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق رابط کاربری [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/) می‌دهد. یک نمونه از این رابط توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDocumentProperties--) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه می‌توانید این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="تذکر" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل تغییر نیستند. Aspose.Slides در هر بار ذخیره‌سازی آنها را بازنویسی می‌کند، بنابراین یک ارائه ذخیره‌شده همیشه «Aspose.Slides for Java» و نسخه کتابخانه‌ای که آن را تولید کرده است را گزارش می‌دهد. هر مقدار پاس داده شده به `setNameOfApplication` هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}}

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. تنها کاری که باید انجام دهید این است که روی آیکون Office کلیک کنید و سپس گزینه منوی **Prepare | Properties | Advanced Properties** در Microsoft PowerPoint 2007 را همان‌طور که در زیر نشان داده شده است انتخاب کنید:

|**انتخاب گزینه منوی Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

پس از انتخاب گزینه منوی **Advanced Properties**، یک دیالوگ ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر نشان داده شده است، مدیریت کنید:

|**دیالوگ ویژگی‌ها**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

در **دیالوگ ویژگی‌ها** بالا می‌توانید ببینید که صفحه‌های تب مختلفی مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom** وجود دارند. همه این تب‌ها امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

### کار با ویژگی‌های سند با استفاده از Aspose.Slides for Java

همان‌طور که پیشتر توضیح دادیم، Aspose.Slides for Java دو نوع ویژگی سند را پشتیبانی می‌کند: ویژگی‌های **Built-in** و **Custom**. بنابراین توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides for Java به هر دو نوع ویژگی دسترسی داشته باشند. Aspose.Slides for Java کلاسی به نام [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نمایان می‌کند.

توسعه‌دهندگان می‌توانند از ویژگی **IDocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) در دسترس است، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در زیر شرح داده شده است، استفاده کنند:

## **خواندن ویژگی‌های عمومی از یک ارائهٔ رمزنگاری‌شده**

یک گذرواژهٔ باز کردن معمولاً محتوای ارائه و ویژگی‌های سند را محافظت می‌کند. وقتی یک ارائه با عبور `false` به [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) رمزنگاری می‌شود، ویژگی‌های سند آن عمومی می‌مانند. سپس برنامه می‌تواند `true` را به [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) پاس دهد و متادیتای عمومی را بدون ارائهٔ گذرواژه بخواند.

گزینهٔ بارگذاری فقط ویژگی‌های سند کنترل می‌کند که Aspose.Slides چه چیزی را بارگذاری می‌کند؛ هیچ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزنگاری گنجانده شده باشند، بارگذاری آنها بدون گذرواژه شکست می‌خورد. اگر ارائه رمزنگاری نشده باشد، گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

مثال زیر حالت بارگذاری را از طریق [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) بررسی می‌کند و سپس ویژگی‌های داخلی را از طریق [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDocumentProperties--) می‌خواند:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

در این حالت محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، لایه‌ها، اشکال، رسانه و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که به مدل شیء کامل ارائه نیاز دارد، از [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) بررسی کنند.

{{% alert color="warning" title="هشدار" %}}
متادیتای عمومی ممکن است نام‌های نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را افشا کند. ویژگی‌های حساس را به همراه ارائه رمزنگاری کنید. فقط زمانی که سیستم‌های ایندکس، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون گذرواژه داشته باشند، آنها را عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائهٔ رمزنگاری‌شده**

برای یک فایل PPTX رمزنگاری‌شده، ارائه‌ای که در حالت فقط‑ویژگی‑سند بارگذاری می‌شود، برای خواندن متادیتای عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متادیتا ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های متناظر داخل ارائهٔ رمزنگاری‌شده سازگار بمانند. بنابراین به‌روزرسانی آنها نیاز به گذرواژهٔ صحیح باز کردن و بارگذاری کامل دارد.

مثال زیر ارائه را با [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) باز می‌کند، ویژگی‌های داخلی عمومی را به‌روزرسانی می‌نماید و نتیجه را ذخیره می‌کند. سپس با استفاده از [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) بررسی می‌کند که رمزنگاری حفظ شده و متادیتای عمومی را بدون گذرواژه دوباره می‌خواند تا مقادیر جدید را تأیید کند:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

اگر برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزنگاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های داخلی**

این ویژگی‌ها که توسط شیء [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties) ارائه می‌شود شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ اصلاح)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده؟)، **PresentationFormat**، **Subject** و **Title** می‌باشند.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر ارائه است
Presentation pres = new Presentation("Presentation.pptx");
try {
    // ایجاد یک ارجاع به شیء IDocumentProperties مرتبط با Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // نمایش ویژگی‌های داخلی
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر ویژگی‌های داخلی**

تغییر ویژگی‌های داخلی فایل‌های ارائه به اندازهٔ دسترسی به آنها ساده است. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نحوهٔ تغییر ویژگی‌های داخلی سند یک فایل ارائه با استفاده از Aspose.Slides for Java نشان داده شده است.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک ارجاع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ویژگی‌های داخلی را تنظیم کنید
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // ارائه خود را در یک فایل ذخیره کنید
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال ویژگی‌های داخلی ارائه را که پس از تغییر به صورت زیر مشاهده می‌شوند، به‌روزرسانی می‌کند:

|**ویژگی‌های سند داخلی پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سفارشی سند**

Aspose.Slides for Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر سه ویژگی سفارشی اضافه می‌کند، سپس نام ذخیره‌شده در ایندکس 2 را جستجو کرده و آن ویژگی را حذف می‌کند، بنابراین ارائه ذخیره‌شده دو ویژگی را نگه می‌دارد. ویژگی‌های سفارشی به ترتیب حروف الفبا ایندکس می‌شوند، نه به ترتیبی که افزوده شدند.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // دریافت ویژگی‌های سند
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // افزودن ویژگی‌های سفارشی
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // دریافت نام ویژگی در ایندکس مشخص
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // حذف ویژگی انتخاب‌شده
    dProps.removeCustomProperty(getPropertyName);
    
    // ذخیره ارائه
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**ویژگی‌های سفارشی سند اضافه شده**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for Java همچنین به توسعه‌دهندگان امکان دسترسی به مقادیر ویژگی‌های سفارشی را می‌دهد. مثال زیر نشان می‌دهد چگونه می‌توانید همهٔ این ویژگی‌های سفارشی یک ارائه را دسترسی و تغییر دهید.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک ارجاع به شیء DocumentProperties مرتبط با Presentation ایجاد کنید
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // دسترسی و تغییر ویژگی‌های سفارشی
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // تغییر مقادیر ویژگی‌های سفارشی
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // ارائه خود را در یک فایل ذخیره کنید
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال ویژگی‌های سفارشی [PPTX](https://docs.fileformat.com/presentation/pptx/) را تغییر می‌دهد. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از تغییر نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های پیشرفته سند**

{{% alert color="info" title="تذکر" %}}
متدهای جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) به [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo) اضافه شده‌اند؛ منطق setter ویژگی [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) نیز تغییر یافته است.
{{% /alert %}}

دو متد جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) به رابط [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo) افزوده شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و اجازه می‌دهند بدون بارگذاری کل ارائه، ویژگی‌ها را تغییر و به‌روزرسانی کنید.

سناریوی معمول بارگذاری ویژگی‌ها، تغییر مقداری و به‌روزرسانی سند می‌تواند به شکل زیر پیاده‌سازی شود:

```java
import com.aspose.slides.*;

// اطلاعات ارائه را بخوانید
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// دریافت ویژگی‌های جاری
IDocumentProperties props = info.readDocumentProperties();

// تنظیم مقادیر جدید فیلدهای نویسنده و عنوان
props.setAuthor("New Author");
props.setTitle("New Title");

// به‌روزرسانی ارائه با مقادیر جدید
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

راه دیگری نیز وجود دارد که ویژگی‌های یک ارائه خاص را به‌عنوان قالب استفاده کنید تا ویژگی‌ها را در ارائه‌های دیگر به‌روزرسانی کنید:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

یک قالب جدید می‌تواند از صفر ایجاد شود و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تنظیم زبان تصحیح املایی**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat فراهم می‌شود) را ارائه می‌دهد تا بتوانید زبان تصحیح املایی یک سند PowerPoint را تنظیم کنید. زبان تصحیح املایی زبانی است که املا و قواعد گرامری آن در PowerPoint بررسی می‌شود.

این کد Java نشان می‌دهد چگونه زبان تصحیح املایی را برای یک PowerPoint تنظیم کنید:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // شناسه زبان تصحیح املایی را تنظیم کنید

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

این کد Java نشان می‌دهد چگونه زبان پیش‌فرض را برای تمام ارائهٔ PowerPoint تنظیم کنید:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // یک شکل مستطیلی جدید با متن اضافه می‌کند
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // زبان اولین قسمت را بررسی می‌کند
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال زنده**

سعی کنید برنامهٔ آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توانید با ویژگی‌های سند از طریق API Aspose.Slides کار کنید:

[![نمایش و ویرایش فراداده PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **پرسش‌های متداول**

**چگونه می‌توانم یک ویژگی داخلی را از یک ارائه حذف کنم؟**

ویژگی‌های داخلی جزئی اجتناب‌ناپذیر ارائه هستند و نمی‌توان آنها را به‌طور کامل حذف کرد. اما می‌توانید مقدار آنها را تغییر داده یا (در صورتی که ویژگی اجازه دهد) به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی را اضافه کنم که از قبل وجود داشته باشد، چه اتفاقی می‌افتد؟**

اگر ویژگی سفارشی که از قبل موجود است را اضافه کنید، مقدار قبلی آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید؛ Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی پیدا کنم؟**

بله. می‌توانید از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) سپس [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) استفاده کنید تا متادیتای ذخیره‌شده سند را بدون ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بخوانید. برای مثال کامل به گزارش‌سازی سبک سبک‌دار به آدرس [Build a Lightweight Presentation Inventory](/slides/fa/java/examine-presentation/) نگاه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائهٔ رمزنگاری‌شده را بدون گذرواژهٔ باز کردن آن بخوانم؟**

بله. رمزنگاری ویژگی‌های سند باید قبل از رمزنگاری ارائه غیرفعال شده باشد و ارائه باید در حالت فقط‑ویژگی‑سند بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزنگاری‌شده را در حالت فقط‑ویژگی‑سند به‌روزرسانی کنم؟**

خیر. داده‌های ویژگی عمومی و رمزنگاری‌شده باید سازگار بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزنگاری‌شده نیاز به بارگذاری کامل ارائه با گذرواژهٔ صحیح باز کردن دارد.