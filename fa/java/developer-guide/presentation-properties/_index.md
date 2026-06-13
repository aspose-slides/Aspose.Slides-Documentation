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
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای Java به‌صورت کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها را می‌توان به سادگی با استفاده از API Aspose.Slides دسترسی یافت و مدیریت کرد.

Aspose.Slides به شما امکان می‌دهد تا با ویژگی‌های سند ارائه از طریق اینترفیس [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این اینترفیس توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getDocumentProperties--) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="primary" %}} 
لطفاً توجه داشته باشید که فیلدهای **Application** و **Producer** قابل تغییر نیستند، زیرا این فیلدها همیشه «Aspose Ltd.» و «Aspose.Slides for Java x.x.x» را نمایش می‌دهند.
{{% /alert %}} 

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. تنها کاری که باید انجام دهید کلیک بر روی آیکون Office و سپس گزینه **Prepare | Properties | Advanced Properties** در منوی Microsoft PowerPoint 2007 همان‌طور که در زیر نشان داده شده است:

|**انتخاب گزینه Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
پس از انتخاب گزینه **Advanced Properties**، دیالوگی ظاهر می‌شود که امکان مدیریت ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر می‌بینید، فراهم می‌کند:

|**دیالوگ ویژگی‌ها**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
در **دیالوگ ویژگی‌ها** بالا، می‌توانید ببینید که صفحات تب متعددی مانند **General**, **Summary**, **Statistics**, **Contents** و **Custom** وجود دارد. همه این صفحات تب اجازه پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را می‌دهند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **کار با ویژگی‌های سند با استفاده از Aspose.Slides برای Java**

همان‌طور که پیش‌تر توضیح دادیم Aspose.Slides برای Java دو نوع ویژگی سند را پشتیبانی می‌کند: ویژگی‌های **Built-in** و **Custom**. بنابراین توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides برای Java به هر دو نوع دسترسی پیدا کنند. Aspose.Slides برای Java کلاسی به نام [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties) فراهم می‌کند که ویژگی‌های سند مربوط به یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نمایان می‌سازد.

توسعه‌دهندگان می‌توانند از ویژگی **IDocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) در دسترس قرار می‌گیرد، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در زیر توضیح داده شده است، استفاده کنند:

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties) در دسترس هستند شامل: **Creator** (نویسنده)، **Description**, **Keywords**, **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**, **SharedDoc** (آیا بین تولیدکنندگان مختلف به‌اشتراک‌گذاری شده است؟)، **PresentationFormat**, **Subject** و **Title** می‌شوند.

```java
// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر ارائه است
Presentation pres = new Presentation("Presentation.pptx");
try {
    // ایجاد مرجع به شیء IDocumentProperties مرتبط با Presentation
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

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های ساخته‌شدهٔ فایل‌های ارائه به آسانی دسترسی به آن‌ها است. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان داده شده است که چگونه می‌توان ویژگی‌های سند ساخته‌شدهٔ یک فایل ارائه را با استفاده از Aspose.Slides برای Java تغییر داد.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // ایجاد مرجعی به شیء IDocumentProperties مرتبط با Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // تنظیم ویژگی‌های داخلی
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // ذخیرهٔ ارائه شما در یک فایل
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال ویژگی‌های ساخته‌شدهٔ ارائه را که می‌تواند همان‌طور که در زیر نشان داده شده است، مشاهده کنید، تغییر می‌دهد:

|**ویژگی‌های سند Built-in پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سفارشی سند**

Aspose.Slides برای Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثالی در زیر نشان می‌دهد چگونه می‌توانید ویژگی‌های سفارشی برای یک ارائه تنظیم کنید.

```java
Presentation pres = new Presentation();
try {
    // دریافت ویژگی‌های سند
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // افزودن ویژگی‌های سفارشی
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // دریافت نام ویژگی در اندیس خاص
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // حذف ویژگی انتخاب‌شده
    dProps.removeCustomProperty(getPropertyName);
    
    // ذخیرهٔ ارائه
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**ویژگی‌های سفارشی سند اضافه شده**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides برای Java همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی پیدا کنند. مثالی در زیر نشان می‌دهد چگونه می‌توانید تمام این ویژگی‌های سفارشی برای یک ارائه را دسترسی پیدا کنید و تغییر دهید.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // ایجاد مرجع به شیء DocumentProperties مرتبط با Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // دسترسی و تغییر ویژگی‌های سفارشی
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // تغییر مقادیر ویژگی‌های سفارشی
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // ذخیرهٔ ارائه شما در یک فایل
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال ویژگی‌های سفارشی ارائهٔ [PPTX](https://docs.fileformat.com/presentation/pptx/) را تغییر می‌دهد. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از تغییر نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های پیشرفته سند**

{{% alert color="primary" %}} 
متدهای جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) به اینترفیس [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo) اضافه شده‌اند، منطق تنظیم‌کنندهٔ ویژگی [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) نیز تغییر یافته است.
{{% /alert %}} 

دو متد جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) به اینترفیس [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo) اضافه شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و امکان تغییر و به‌روزرسانی ویژگی‌ها بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمول بارگذاری ویژگی‌ها، تغییر مقدار و به‌روزرسانی سند می‌تواند به شکل زیر پیاده‌سازی شود:

```java
// خواندن اطلاعات ارائه
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

راه دیگری نیز وجود دارد که می‌توان از ویژگی‌های یک ارائهٔ خاص به‌عنوان قالب برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر استفاده کرد:

```java
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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

یک قالب جدید می‌تواند از ابتدا ایجاد شده و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تنظیم زبان تصحیح**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat افشا می‌شود) را فراهم می‌کند تا به شما اجازه دهد زبان تصحیح را برای یک سند PowerPoint تنظیم کنید. زبان تصحیح زبانی است که املا و دستور زبان در PowerPoint برای آن بررسی می‌شود.

این کد Java نشان می‌دهد چگونه زبان تصحیح برای یک PowerPoint تنظیم شود: xxx چرا LanguageId در کلاس Java PortionFormat وجود ندارد؟

```java
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

    portionFormat.setLanguageId("zh-CN"); // تنظیم شناسه زبان تصحیح

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

این کد Java نشان می‌دهد چگونه می‌توانید زبان پیش‌فرض را برای تمام ارائهٔ PowerPoint تنظیم کنید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // یک شکل مستطیل جدید با متن اضافه می‌کند
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // زبان اولین بخش را بررسی می‌کند
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **مثال زنده**

سعی کنید برنامهٔ آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توان با ویژگی‌های سند از طریق API Aspose.Slides کار کرد:

[![مشاهده و ویرایش فراداده PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***سوالات متداول**
**چگونه می‌توان یک ویژگی Built-in را از یک ارائه حذف کرد؟**

ویژگی‌های Built-in جزئی اساسی از ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. با این حال می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت اجازه ویژگی خاص، به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توان ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کرد؟**

بله، می‌توانید بدون بارگذاری کامل ارائه با استفاده از متد `getPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/) به ویژگی‌های ارائه دسترسی پیدا کنید. سپس با بهره‌گیری از متد `readDocumentProperties` ارائه‌شده توسط اینترفیس [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/) می‌توانید ویژگی‌ها را به‌صورت مؤثر بخوانید و حافظه مصرفی و عملکرد را بهبود بخشید.