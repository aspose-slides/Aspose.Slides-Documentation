---
title: مدیریت ویژگی‌های ارائه در جاوا
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/java/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان بازخوانی
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای جاوا به‌طور کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه اجازه می‌دهد از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/) . یک نمونه از این رابط توسط روش [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getDocumentProperties--) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه می‌توان این ویژگی‌ها را خواند، تغییر داد و مدیریت کرد.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل تغییر نیستند. Aspose.Slides آنها را در هر بار ذخیره بازنویسی می‌کند، بنابراین یک ارائه ذخیره‌شده همیشه «Aspose.Slides for Java» و نسخه کتابخانه‌ای که آن را تولید کرده است را گزارش می‌دهد. هر مقدار پاس داده شده به `setNameOfApplication` هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}} 

## **ویژگی‌های سند در پاورپوینت**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. تمام کاری که باید انجام دهید این است که روی آیکون Office کلیک کنید و سپس گزینه **Prepare | Properties | Advanced Properties** منوی Microsoft PowerPoint 2007 را همان‌طور که در زیر نشان داده شده است انتخاب کنید:

|**انتخاب گزینه Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
پس از انتخاب گزینه **Advanced Properties**، دیالوگی ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر نشان داده شده مدیریت کنید:

|**دیالوگ ویژگی‌ها**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
در **دیالوگ ویژگی‌ها** بالا می‌توانید ببینید که صفحات تب متعددی مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom** وجود دارد. همه این صفحات تب امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **کار با ویژگی‌های سند با Aspose.Slides for Java**

همان‌طور که پیشتر توضیح دادیم Aspose.Slides for Java دو نوع ویژگی سند را پشتیبانی می‌کند: ویژگی‌های **Built-in** و **Custom**. بنابراین، توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides for Java به هر دو نوع ویژگی دسترسی داشته باشند. Aspose.Slides for Java یک کلاس [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نمایان می‌کند.

توسعه‌دهندگان می‌توانند از ویژگی **IDocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) افشا شده است استفاده کنند تا به ویژگی‌های سند فایل‌های ارائه دسترسی پیدا کنند همان‌طور که در زیر شرح داده شده است:

## **دسترسی به ویژگی‌های داخلی**

این ویژگی‌ها که توسط شیء [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties) ظاهر می‌شوند شامل **Creator** (Author)، **Description**، **Keywords**، **Created** (Creation Date)، **Modified** (Modification Date)، **Printed** (Last Print Date)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** می‌باشند.

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر ارائه است را ایجاد می‌کند
Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
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

تغییر ویژگی‌های داخلی فایل‌های ارائه به همان سادگی دسترسی به آنهاست. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان داده‌ایم چگونه می‌توانیم ویژگی‌های سند داخلی فایل ارائه را با استفاده از Aspose.Slides for Java تغییر دهیم.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
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

این مثال ویژگی‌های داخلی ارائه را تغییر می‌دهد که می‌توان آنها را همان‌طور که در زیر نشان داده شده مشاهده کرد:

|**ویژگی‌های سند داخلی پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سفارشی سند**

Aspose.Slides for Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی را برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر سه ویژگی سفارشی اضافه می‌کند، سپس نام ذخیره‌شده در ایندکس ۲ را جستجو کرده و آن ویژگی را حذف می‌کند، بنابراین ارائه ذخیره‌شده دو ویژگی باقی می‌گذارد. ویژگی‌های سفارشی بر اساس ترتیب الفبایی ایندکس می‌شوند، نه بر حسب ترتیب افزودن.

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
    
    // دریافت نام ویژگی در ایندکس خاص
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // حذف ویژگی انتخاب‌شده
    dProps.removeCustomProperty(getPropertyName);
    
    // ذخیرهٔ ارائه
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**ویژگی‌های سفارشی سند اضافه‌شده**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر ویژگی‌های سفارشی را دسترسی و تغییر دهند. مثال زیر نشان می‌دهد چگونه می‌توانید به تمام این ویژگی‌های سفارشی برای یک ارائه دسترسی پیدا کنید و آنها را تغییر دهید.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء DocumentProperties مرتبط با Presentation ایجاد کنید
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // دسترسی و تغییر ویژگی‌های سفارشی
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // نام‌ها و مقادیر ویژگی‌های سفارشی را نمایش دهید
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // مقادیر ویژگی‌های سفارشی را تغییر دهید
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

{{% alert color="info" title="Note" %}}
روش‌های جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) به [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo) اضافه شده‌اند، منطق setter ویژگی [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) تغییر یافته است.
{{% /alert %}} 

دو روش جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) به رابط [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo) اضافه شده‌اند. آنها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و اجازه می‌دهند بدون بارگذاری کل ارائه، ویژگی‌ها را تغییر و به‌روزرسانی کنید.

سناریوی معمولی بارگذاری ویژگی‌ها، تغییر مقداری و به‌روزرسانی سند می‌تواند به شکل زیر پیاده‌سازی شود:

```java
import com.aspose.slides.*;

// اطلاعات ارائه را بخوانید
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

راه دیگر استفاده از ویژگی‌های یک ارائه خاص به‌عنوان قالب برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر است:

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

یک قالب جدید می‌تواند از صفر ساخته شود و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

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

## **تنظیم زبان بازخوانی**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat افشا می‌شود) را ارائه می‌دهد تا بتوانید زبان بازخوانی برای یک سند PowerPoint را تنظیم کنید. زبان بازخوانی زبانی است که املا و دستور زبان در PowerPoint برای آن بررسی می‌شود.

این کد Java نشان می‌دهد چگونه زبان بازخوانی را برای یک PowerPoint تنظیم کنید:

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

    portionFormat.setLanguageId("zh-CN"); // تنظیم شناسه زبان بازخوانی

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

این کد Java نشان می‌دهد چگونه زبان پیش‌فرض را برای کل ارائه PowerPoint تنظیم کنید:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // یک شکل مستطیلی جدید با متن اضافه می‌کند
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

[![مشاهده و ویرایش Metadata پاورپوینت](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **پرسش‌های متداول**

**چگونه می‌توان یک ویژگی داخلی را از ارائه حذف کرد؟**

ویژگی‌های داخلی بخشی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را به‌طور کامل حذف کرد. با این حال می‌توانید مقدار آنها را تغییر داده یا (در صورت اجازه ویژگی) به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که از قبل وجود دارد اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که از قبل وجود دارد اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کنم؟**

بله. از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) استفاده کنید و سپس [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) را فراخوانی کنید تا متادیتای ذخیره‌شده سند را بدون ایجاد نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های فرمت‑خاص به [Build a Lightweight Presentation Inventory](/slides/fa/java/examine-presentation/) مراجعه کنید.