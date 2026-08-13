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
- ویژگی‌های پیش‌ساخته
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان بررسی املایی
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "درک کامل ویژگی‌های ارائه در Aspose.Slides برای جاوا و ساده‌سازی جستجو، برندسازی و جریان کار در فایل‌های پاورپوینت و OpenDocument."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **ویژگی‌های پیش‌ساخته** و **ویژگی‌های سفارشی**. هر دو نوع ویژگی می‌توانند به‌راحتی با استفاده از API Aspose.Slides دسترسی یافته و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties/) می‌دهد. یک نمونه از این رابط توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getDocumentProperties--) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" %}} 

لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل ویرایش نیستند. Aspose.Slides آن‌ها را در هر بار ذخیره‌سازی بازنویسی می‌کند، به‌طوری که یک ارائه ذخیره‌شده همیشه «Aspose.Slides for Java» و نسخه کتابخانه‌ای که آن را تولید کرده است را گزارش می‌دهد. هر مقداری که به `setNameOfApplication` پاس داده شود هنگام نوشتن ارائه نادیده گرفته می‌شود.

{{% /alert %}} 

## **ویژگی‌های سند در پاورپوینت**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. کافی است روی آیکون Office کلیک کنید و سپس منوی **Prepare | Properties | Advanced Properties** را در Microsoft PowerPoint 2007 به‌صورت زیر انتخاب کنید:

|**انتخاب گزینه Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
پس از انتخاب گزینه **Advanced Properties**، دیالوگی ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر نشان داده شده است، مدیریت کنید:

|**دیالوگ ویژگی‌ها**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
در **دیالوگ ویژگی‌ها** می‌توانید ببینید که صفحه‌های برگه متعددی مانند **General**, **Summary**, **Statistics**, **Contents** و **Custom** وجود دارد. همه این برگه‌ها اجازه پیکربندی انواع مختلف اطلاعات مربوط به فایل‌های PowerPoint را می‌دهند. برگه **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

### کار با ویژگی‌های سند با Aspose.Slides برای Java

همان‌طور که قبلاً توضیح دادیم، Aspose.Slides برای Java دو نوع ویژگی سند—**ویژگی‌های پیش‌ساخته** و **ویژگی‌های سفارشی**—را پشتیبانی می‌کند. بنابراین، توسعه‌دهندگان می‌توانند هر دو نوع ویژگی را با استفاده از API Aspose.Slides برای Java دسترسی پیدا کنند. Aspose.Slides برای Java کلاسی به نام [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نشان می‌دهد.

توسعه‌دهندگان می‌توانند از ویژگی **IDocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) افشا می‌شود، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در زیر شرح داده شده است، استفاده کنند:

## **دسترسی به ویژگی‌های پیش‌ساخته**

این ویژگی‌ها که توسط شیء [IDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties) افشا می‌شوند عبارتند از: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ساخت)، **Modified** (تاریخ اصلاح)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title**

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر ارائه است
Presentation pres = new Presentation("Presentation.pptx");
try {
    // ایجاد مرجع به شیء IDocumentProperties مرتبط با Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // نمایش ویژگی‌های پیش‌ساخته
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

## **تغییر ویژگی‌های پیش‌ساخته**

تغییر ویژگی‌های پیش‌ساخته فایل‌های ارائه به سادگی دسترسی به آن‌ها است. می‌توانید به سادگی مقدار رشته‌ای را به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان داده شده است که چگونه می‌توان ویژگی‌های پیش‌ساخته سند ارائه را با استفاده از Aspose.Slides برای Java تغییر داد.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // ایجاد مرجع به شیء IDocumentProperties مرتبط با Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // تنظیم ویژگی‌های پیش‌ساخته
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

این مثال ویژگی‌های پیش‌ساخته ارائه را تغییر می‌دهد که می‌توانید خروجی آن را همان‌طور که در زیر نشان داده شده است، مشاهده کنید:

|**ویژگی‌های سند پیش‌ساخته پس از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سفارشی سند**

Aspose.Slides برای Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر سه ویژگی سفارشی اضافه می‌کند، سپس نام ذخیره شده در ایندکس ۲ را جستجو و آن ویژگی را حذف می‌کند، به‌طوری که ارائه ذخیره‌شده دو ویژگی باقی‌مانده را نگه می‌دارد. ویژگی‌های سفارشی به ترتیب حروف الفبا ایندکس می‌شوند، نه بر پایه ترتیب افزودن.

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

|**ویژگی‌های سفارشی افزودن‌شده**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides برای Java همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی پیدا کنند. مثال زیر نشان می‌دهد چگونه می‌توانید تمام این ویژگی‌های سفارشی یک ارائه را دسترسی و تغییر دهید.

```java
import com.aspose.slides.*;

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

این مثال ویژگی‌های سفارشی [PPTX](https://docs.fileformat.com/presentation/pptx/) را تغییر می‌دهد. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از تغییر نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی بعد از تغییر**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های پیشرفته سند**

{{% alert color="info" %}} 

روش‌های جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) به [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo) افزوده شده‌اند، منطق setter ویژگی [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) نیز تغییر کرده است.

{{% /alert %}} 

دو روش جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) به رابط [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentationInfo) اضافه شده‌اند. این روش‌ها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و امکان تغییر و بروز رسانی ویژگی‌ها بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمول بارگذاری ویژگی‌ها، تغییر مقداری و بروز رسانی سند به‌صورت زیر قابل پیاده‌سازی است:

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

روش دیگری نیز وجود دارد که ویژگی‌های یک ارائه خاص را به‌عنوان قالب استفاده کرده و ویژگی‌ها را در ارائه‌های دیگر بروز رسانی کنید:

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

قالب جدید می‌تواند از ابتدا ساخته شود و سپس برای بروز رسانی چندین ارائه استفاده شود:

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

## **تنظیم زبان-proofing**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat افشا می‌شود) را فراهم می‌کند تا بتوانید زبان proofing یک سند PowerPoint را تنظیم کنید. زبان proofing زبانی است که املاء و قواعد آن در PowerPoint بررسی می‌شود.

این کد Java نشان می‌دهد چگونه زبان proofing را برای یک PowerPoint تنظیم کنید:

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

    portionFormat.setLanguageId("zh-CN"); // شناسهٔ زبان proofing را تنظیم کنید

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

این کد Java نشان می‌دهد چگونه زبان پیش‌فرض را برای تمام ارائه PowerPoint تنظیم کنید:

```java
import com.aspose.slides.*;

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

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را استفاده کنید تا ببینید چطور می‌توانید از طریق API Aspose.Slides با ویژگی‌های سند کار کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***پرسش‌های متداول**

### چگونه می‌توان یک ویژگی پیش‌ساخته را از یک ارائه حذف کرد؟

ویژگی‌های پیش‌ساخته جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توانند به‌صورت کامل حذف شوند. با این حال، می‌توانید مقدار آن‌ها را تغییر دهید یا در صورت اجازه ویژگی خاص، آن را به مقدار خالی تنظیم کنید.

### اگر ویژگی سفارشی‌ای که از قبل وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟

اگر ویژگی سفارشی‌ای که از قبل وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی ویژگی نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

### آیا می‌توانم بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی داشته باشم؟

بله، می‌توانید بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی پیدا کنید با استفاده از متد `getPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/). سپس متد `readDocumentProperties` ارائه‌شده توسط رابط [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/) را برای خواندن کارآمد ویژگی‌ها به کار ببرید؛ این کار باعث صرفه‌جویی در حافظه و بهبود عملکرد می‌شود.