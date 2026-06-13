---
title: مدیریت ویژگی‌های ارائه در اندروید
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/androidjava/presentation-properties/
keywords:
- ویژگی‌های پاورپوینت
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های پیش‌ساخته
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- ویرایش ویژگی‌ها
- متادیتای سند
- ویرایش متادیتا
- زبان اصلاح املایی
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "بهینه‌سازی ویژگی‌های ارائه در Aspose.Slides برای اندروید از طریق جاوا و تسهیل جستجو، برندینگ و گردش کار در فایل‌های پاورپوینت و OpenDocument شما."
---
## **مقدمه**

Aspose.Slides از دو نوع ویژگی سند پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو این نوع ویژگی‌ها به‌راحتی می‌توانند از طریق API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد که با ویژگی‌های سند ارائه از طریق اینترفیس [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این اینترفیس توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، اصلاح کنید و مدیریت نمایید.

{{% alert color="primary" %}} 
لطفاً توجه داشته باشید که فیلدهای **Application** و **Producer** قابل تغییر نیستند، زیرا این فیلدها همیشه «Aspose Ltd.» و «Aspose.Slides for Android via Java x.x.x» را نشان می‌دهند.
{{% /alert %}} 

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. کافی است روی نماد Office کلیک کنید و سپس منوی **Prepare | Properties | Advanced Properties** را در Microsoft PowerPoint 2007 انتخاب کنید همان‌طور که در زیر نشان داده شده است:

|**انتخاب گزینه Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

پس از انتخاب گزینه **Advanced Properties**، دیالوگی ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر دیده می‌شود مدیریت کنید:

|**دیالوگ ویژگی‌ها**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

در این **دیالوگ ویژگی‌ها** می‌توانید تب‌های متعددی مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom** را ببینید. همه این تب‌ها امکان تنظیم انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.



کار با ویژگی‌های سند با استفاده از Aspose.Slides برای Android via Java

همان‌طور که پیشتر گفتیم Aspose.Slides برای Android via Java دو نوع ویژگی سند، یعنی **Built-in** و **Custom** را پشتیبانی می‌کند. بنابراین توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides برای Android via Java به هر دو نوع ویژگی دسترسی داشته باشند. Aspose.Slides برای Android via Java یک کلاس [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نمایش می‌دهد.

توسعه‌دهندگان می‌توانند از ویژگی **IDocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ارائه می‌شود برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در زیر شرح داده شده است، استفاده کنند:

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties) ارائه می‌شوند شامل: **Creator** (نویسنده)، **Description** (توضیح)، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ ویرایش)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** می‌باشند.

```java
// یک نمونه از کلاس Presentation که نمایانگر ارائه است ایجاد کنید
Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ویژگی‌های پیش‌ساخته را نمایش دهید
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

## **ویرایش ویژگی‌های Built-in**

ویرایش ویژگی‌های پیش‌ساخته فایل‌های ارائه به آسانی دسترسی به آن‌ها است. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نحوه ویرایش ویژگی‌های پیش‌ساخته سند یک فایل ارائه با استفاده از Aspose.Slides برای Android via Java نشان داده شده است.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ویژگی‌های پیش‌ساخته را تنظیم کنید
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // ارائهٔ خود را در فایل ذخیره کنید
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال ویژگی‌های پیش‌ساخته ارائه را که می‌توانید همان‌طور که در زیر نشان داده شده است، ببینید، تغییر می‌دهد:

|**ویژگی‌های سند Built-in پس از ویرایش**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **اضافه کردن ویژگی‌های سفارشی سند**

Aspose.Slides برای Android via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. نمونه زیر نشان می‌دهد چگونه ویژگی‌های سفارشی برای یک ارائه تنظیم شود.

```java
Presentation pres = new Presentation();
try {
    // دریافت ویژگی‌های سند
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // افزودن ویژگی‌های سفارشی
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // دریافت نام ویژگی در ایندکس معین
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

## **دسترسی و ویرایش ویژگی‌های سفارشی**

Aspose.Slides برای Android via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر ویژگی‌های سفارشی را دسترسی و ویرایش کنند. نمونه زیر نشان می‌دهد چگونه می‌توانید تمام این ویژگی‌های سفارشی را برای یک ارائه دسترسی و ویرایش کنید.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء DocumentProperties مرتبط با Presentation ایجاد کنید
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // دسترسی و اصلاح ویژگی‌های سفارشی
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // اصلاح مقادیر ویژگی‌های سفارشی
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // ارائه خود را در یک فایل ذخیره کنید
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال ویژگی‌های سفارشی [PPTX](https://docs.fileformat.com/presentation/pptx/) را ویرایش می‌کند. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از ویرایش نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از ویرایش**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی پس از ویرایش**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های پیشرفته سند**

{{% alert color="primary" %}} 
متدهای جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) به [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo) اضافه شده‌اند؛ منطق setter ویژگی [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) تغییر پیدا کرده است.
{{% /alert %}} 

دو متد جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) به اینترفیس [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo) اضافه شده‌اند. آن‌ها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و امکان تغییر و به‌روزرسانی ویژگی‌ها بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمولی بارگذاری ویژگی‌ها، تغییر مقداری و به‌روزرسانی سند می‌تواند به شکل زیر پیاده‌سازی شود:

```java
// اطلاعات ارائه را بخوانید
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ویژگی‌های جاری را به‌دست آورید
IDocumentProperties props = info.readDocumentProperties();

// مقادیر جدید فیلدهای Author و Title را تنظیم کنید
props.setAuthor("New Author");
props.setTitle("New Title");

// ارائه را با مقادیر جدید به‌روزرسانی کنید
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

راه دیگری نیز وجود دارد تا ویژگی‌های یک ارائه خاص به‌عنوان قالب برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر استفاده شوند:

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

قالب جدید می‌تواند از صفر ساخته شود و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

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

## **تنظیم زبان اصلاح املایی**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat ارائه می‌شود) را برای تنظیم زبان اصلاح املایی سند PowerPoint فراهم می‌کند. زبان اصلاح املایی زبانی است که املا و دستور زبان در PowerPoint بر روی آن بررسی می‌شود.

این کد جاوا نشان می‌دهد چگونه می‌توانید زبان اصلاح املایی برای یک PowerPoint تنظیم کنید: xxx Why is LanguageId missing from Java PortionFormat class?

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

    portionFormat.setLanguageId("zh-CN"); // تنظیم شناسه زبان اصلاح املایی

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

این کد جاوا نشان می‌دهد چگونه می‌توانید زبان پیش‌فرض برای کل ارائه PowerPoint تنظیم کنید:

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

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توان با ویژگی‌های سند از طریق API Aspose.Slides کار کرد:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***سؤالات متداول**

**چگونه می‌توان یک ویژگی Built-in را از یک ارائه حذف کرد؟**

ویژگی‌های Built-in جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توانند به‌طور کامل حذف شوند. اما می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت اجازه ویژگی، مقدار آن را خالی کنید.

**اگر ویژگی سفارشی‌ای را اضافه کنم که از قبل وجود دارد چه می‌شود؟**

اگر ویژگی سفارشی‌ای را اضافه کنید که از قبل وجود دارد، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی ویژگی نیست، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توان ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کرد؟**

بله، می‌توانید بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی پیدا کنید با استفاده از متد `getPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/). سپس با بهره‌گیری از متد `readDocumentProperties` ارائه‌شده توسط اینترفیس [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/) ویژگی‌ها را به‌صورت کارآمد بخوانید، حافظه را صرفه‌جویی کنید و عملکرد را بهبود ببخشید.