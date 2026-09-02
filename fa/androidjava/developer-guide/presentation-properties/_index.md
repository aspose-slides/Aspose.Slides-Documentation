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
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان اصلاح‌املا
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای اندروید از طریق جاوا به‌صورت حرفه‌ای مدیریت کنید و جستجو، برندینگ و جریان کاری را در فایل‌های پاورپوینت و OpenDocument خود تسهیل نمایید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو این نوع ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی یافته و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد با ویژگی‌های سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این رابط توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، اصلاح کنید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل اصلاح نیستند. Aspose.Slides آنها را در هر ذخیره‌سازی دوباره می‌نویسد، بنابراین یک ارائه ذخیره‌شده همیشه نام محصول Aspose.Slides و نسخه کتابخانه‌ای که آن را تولید کرده است گزارش می‌دهد. هر مقداری که به `setNameOfApplication` ارسال شود هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}} 

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. کافی است روی نماد Office کلیک کنید و سپس گزینه **Prepare | Properties | Advanced Properties** منوی Microsoft PowerPoint 2007 را همان‌طور که در زیر نشان داده شده است، انتخاب کنید:

|**انتخاب گزینه منوی Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

پس از انتخاب گزینه **Advanced Properties**، دیالوگی ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را همان‌طور که در شکل زیر نشان داده شده است، مدیریت کنید:

|**دیالوگ ویژگی‌ها**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
در **دیالوگ ویژگی‌ها** بالا می‌توانید ببینید که صفحات تب متعددی مانند **General**, **Summary**, **Statistics**, **Contents** و **Custom** وجود دارد. همه این صفحات تب امکان پیکربندی انواع مختلف اطلاعات مربوط به فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint به کار می‌رود.



کار با ویژگی‌های سند با استفاده از Aspose.Slides for Android via Java

همان‌طور که قبلاً توضیح دادیم، Aspose.Slides for Android via Java دو نوع ویژگی سند، یعنی **Built-in** و **Custom** را پشتیبانی می‌کند. بنابراین، توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides for Android via Java به هر دو نوع ویژگی دسترسی پیدا کنند. Aspose.Slides for Android via Java کلاسی به نام [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نشان می‌دهد.

توسعه‌دهندگان می‌توانند از ویژگی **IDocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) در دسترس قرار گرفته است، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در ادامه توصیف شده است، استفاده کنند:

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties) نمایان می‌شوند شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ اصلاح)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده؟)، **PresentationFormat**، **Subject** و **Title** می‌باشند.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که نمایانگر ارائه است
Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک ارجاع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
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

## **اصلاح ویژگی‌های Built-in**

اصلاح ویژگی‌های Built-in فایل‌های ارائه به همان سادگی دسترسی به آن‌هاست. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی اصلاح می‌شود. در مثال زیر نشان دادیم چگونه می‌توانیم ویژگی‌های سند Built-in فایل ارائه را با استفاده از Aspose.Slides for Android via Java اصلاح کنیم.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک ارجاع به شیء IDocumentProperties مرتبط با Presentation ایجاد کنید
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // تنظیم ویژگی‌های داخلی
    dp.setAuthor("Aspose.Slides for Android via Java");
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

این مثال ویژگی‌های Built-in ارائه را که پس از اصلاح به شکل زیر نمایش داده می‌شوند، تغییر می‌دهد:

|**ویژگی‌های سند Built-in پس از اصلاح**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سفارشی سند**

Aspose.Slides for Android via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر سه ویژگی سفارشی اضافه می‌کند، سپس نام ذخیره‌شده در شاخص ۲ را پیدا کرده و آن ویژگی را حذف می‌کند، به طوری که ارائه ذخیره‌شده دو ویژگی باقی‌مانده را نگه می‌دارد. ویژگی‌های سفارشی به ترتیب حروف الفبا ایندکس می‌شوند، نه به ترتیب اضافه شدن.

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
    
    // ذخیره‌سازی ارائه
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**ویژگی‌های سفارشی سند اضافه شده**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **دسترسی و اصلاح ویژگی‌های سفارشی**

Aspose.Slides for Android via Java همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی پیدا کنند. مثال زیر نشان می‌دهد چگونه می‌توانید به تمام این ویژگی‌های سفارشی برای یک ارائه دسترسی پیدا کنید و آن‌ها را اصلاح کنید.

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

این مثال ویژگی‌های سفارشی ارائه [PPTX](https://docs.fileformat.com/presentation/pptx/) را اصلاح می‌کند. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از اصلاح نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از اصلاح**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**ویژگی‌های سفارشی پس از اصلاح**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **ویژگی‌های پیشرفته سند**

{{% alert color="info" title="Note" %}}
متدهای جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) به [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo) افزوده شده‌اند، منطق setter ویژگی [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) تغییر یافته است.
{{% /alert %}} 

دو متد جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) به رابط [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo) اضافه شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و امکان تغییر و به‌روزرسانی ویژگی‌ها بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمول بارگذاری ویژگی‌ها، تغییر مقداری و به‌روزرسانی سند می‌تواند به شکل زیر پیاده‌سازی شود:

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

روش دیگری نیز وجود دارد که ویژگی‌های یک ارائه خاص به عنوان قالب برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر استفاده شود:

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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

یک قالب جدید می‌تواند از ابتدا ایجاد شود و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **تنظیم زبان اصلاح‌املا**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat ارائه می‌شود) را فراهم می‌کند تا بتوانید زبان اصلاح‌املا برای یک سند PowerPoint را تنظیم کنید. زبان اصلاح‌املا زبانی است که املا و دستور زبان در PowerPoint برای آن بررسی می‌شود.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // شناسه زبان اصلاح املایی را تنظیم کنید

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

این کد Java نشان می‌دهد چگونه زبان پیش‌فرض برای کل یک ارائه PowerPoint تنظیم شود:

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

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه با ویژگی‌های سند از طریق API Aspose.Slides کار می‌کنید:

[![مشاهده و ویرایش متادیتای PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک ویژگی Built-in را از یک ارائه حذف کنم؟**

ویژگی‌های Built-in جزء اجزای اساسی ارائه هستند و نمی‌توان آن‌ها را به طور کامل حذف کرد. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت اجازه ویژگی خاص، آن را خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم، چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی ویژگی قبل از افزودن نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون لود کامل ارائه دسترسی پیدا کنم؟**

بله. از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) استفاده کنید و سپس [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) برای خواندن متادیتای ذخیره‌شده سند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) استفاده کنید. برای یک مثال کامل گزارش‌گیری و محدودیت‌های مخصوص فرمت به مقاله [Build a Lightweight Presentation Inventory](/slides/fa/androidjava/examine-presentation/) مراجعه کنید.