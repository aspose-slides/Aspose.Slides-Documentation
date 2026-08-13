---
title: مدیریت ویژگی‌های ارائه در Android
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
- اصلاح ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان اصلاحی
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "در Aspose.Slides برای Android از طریق Java، ویژگی‌های ارائه را به طور کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های پاورپوینت و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند از طریق API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد تا با ویژگی‌های سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این رابط توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) برگردانده می‌شود. مثال‌های زیر نحوه خواندن، تغییر و مدیریت این ویژگی‌ها را نشان می‌دهند.

{{% alert color="info" %}} 
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** قابل تغییر نیستند. Aspose.Slides در هر بار ذخیره‌سازی آن‌ها را بازنویسی می‌کند، بنابراین یک ارائه ذخیره‌شده همیشه نام محصول Aspose.Slides و نسخه کتابخانه‌ای که آن را تولید کرده است را گزارش می‌دهد. هر مقدار پاس داده شده به `setNameOfApplication` هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}} 

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. کاری که لازم است انجام دهید این است که بر روی آیکون Office کلیک کنید و سپس گزینه‌ی منوی **Prepare | Properties | Advanced Properties** در Microsoft PowerPoint 2007 را همان‌طور که در زیر نشان داده شده است، انتخاب کنید:

|**انتخاب گزینه Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد از انتخاب گزینه **Advanced Properties**، یک دیالوگ ظاهر می‌شود که به شما امکان مدیریت ویژگی‌های سند فایل PowerPoint را می‌دهد همان‌طور که در شکل زیر نشان داده شده است:

|**دیالوگ ویژگی‌ها**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

در **دیالوگ ویژگی‌ها** فوق می‌توانید ببینید که صفحات تب متعددی مانند **General**، **Summary**، **Statistics**، **Contents** و **Custom** وجود دارند. تمام این تب‌ها امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

کار با ویژگی‌های سند با استفاده از Aspose.Slides برای Android از طریق Java
همان‌طور که قبلاً توضیح دادیم Aspose.Slides برای Android از طریق Java دو نوع ویژگی سند را پشتیبانی می‌کند: ویژگی‌های **Built-in** و **Custom**. بنابراین توسعه‌دهندگان می‌توانند با استفاده از API Aspose.Slides برای Android از طریق Java به هر دو نوع ویژگی دسترسی داشته باشند. Aspose.Slides برای Android از طریق Java یک کلاس [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties) ارائه می‌دهد که ویژگی‌های سند مرتبط با یک فایل ارائه را از طریق ویژگی **Presentation.DocumentProperties** نشان می‌دهد.

توسعه‌دهندگان می‌توانند از ویژگی **IDocumentProperties** که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) در دسترس قرار می‌گیرد، برای دسترسی به ویژگی‌های سند فایل‌های ارائه همان‌طور که در زیر توضیح داده شده استفاده کنند:

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء [IDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties) در دسترس قرار می‌گیرند شامل: **Creator** (نویسنده)، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** می‌باشند.

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر ارائه است ایجاد می‌کند
Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد می‌کند
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ویژگی‌های داخلی را نمایش می‌دهد
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

تغییر ویژگی‌های Built-in فایل‌های ارائه به آسانی دسترسی به آن‌ها است. شما می‌توانید به سادگی مقدار رشته‌ای را به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نحوه تغییر ویژگی‌های سند Built-in فایل ارائه با استفاده از Aspose.Slides برای Android از طریق Java را نشان دادیم.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء IDocumentProperties مرتبط با Presentation ایجاد می‌کند
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ویژگی‌های داخلی را تنظیم می‌کند
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // ارائه خود را در یک فایل ذخیره می‌کند
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

این مثال ویژگی‌های Built-in ارائه را که می‌توان به شکل زیر مشاهده کرد، تغییر می‌دهد:

|**ویژگی‌های سند Built-in پس از تغییر**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **افزودن ویژگی‌های سفارشی سند**

Aspose.Slides برای Android از طریق Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر سه ویژگی سفارشی اضافه می‌کند، سپس نام ذخیره شده در اندیس 2 را بازیابی کرده و آن ویژگی را حذف می‌کند، به‌طوری که ارائه ذخیره‌شده دو مورد باقی می‌مانند. ویژگی‌های سفارشی به ترتیب حروف الفبا فهرست می‌شوند، نه به ترتیب افزوده شدن.

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
    
    // دریافت نام ویژگی در اندیس خاص
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

Aspose.Slides برای Android از طریق Java همچنین به توسعه‌دهندگان امکان دسترسی به مقادیر ویژگی‌های سفارشی را می‌دهد. مثال زیر نشان می‌دهد چگونه می‌توانید به تمام این ویژگی‌های سفارشی یک ارائه دسترسی داشته و آن‌ها را تغییر دهید.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // یک مرجع به شیء DocumentProperties مرتبط با Presentation ایجاد می‌کند
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // دسترسی و اصلاح ویژگی‌های سفارشی
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // اصلاح مقادیر ویژگی‌های سفارشی
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // ارائه خود را در یک فایل ذخیره می‌کند
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

{{% alert color="info" %}} 
متدهای جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و [WriteBindedPresentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) به [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo) اضافه شدند، منطق setter ویژگی [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) تغییر یافت.
{{% /alert %}} 

دو متد جدید [ReadDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) به رابط [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPresentationInfo) اضافه شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم می‌کنند و امکان تغییر و به‌روزرسانی ویژگی‌ها بدون بارگذاری کل ارائه را می‌دهند.

سناریوی معمولی که ویژگی‌ها را بارگذاری، مقداری را تغییر داده و سند را به‌روزرسانی می‌کند، می‌تواند به شکل زیر پیاده‌سازی شود:

```java
import com.aspose.slides.*;

// اطلاعات ارائه را بخوانید
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// دریافت ویژگی‌های فعلی
IDocumentProperties props = info.readDocumentProperties();

// تنظیم مقادیر جدید فیلدهای نویسنده و عنوان
props.setAuthor("New Author");
props.setTitle("New Title");

// به‌روزرسانی ارائه با مقادیر جدید
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

راه دیگری برای استفاده از ویژگی‌های یک ارائه خاص به عنوان قالب برای به‌روزرسانی ویژگی‌ها در دیگر ارائه‌ها وجود دارد:

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

یک قالب جدید می‌تواند از ابتدا ساخته شود و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

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

## **تنظیم زبان اصلاحی**

Aspose.Slides ویژگی LanguageId (که توسط کلاس PortionFormat عرضه می‌شود) را فراهم می‌کند تا بتوانید زبان اصلاحی یک سند PowerPoint را تنظیم کنید. زبان اصلاحی زبانی است که املا و گرامر در PowerPoint برای آن بررسی می‌شود.

این کد Java نشان می‌دهد چگونه زبان اصلاحی یک PowerPoint را تنظیم کنید:

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

    portionFormat.setLanguageId("zh-CN"); // تنظیم شناسه زبان اصلاحی

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

این کد Java نشان می‌دهد چگونه زبان پیش‌فرض را برای کل یک ارائه PowerPoint تنظیم کنید:

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

سعی کنید برنامه‌ی آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توانید با ویژگی‌های سند از طریق API Aspose.Slides کار کنید:

[![نمایش و ویرایش فراداده PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***سوالات متداول***
### چگونه می‌توان یک ویژگی Built-in را از یک ارائه حذف کرد؟

ویژگی‌های Built-in جزء جدایی‌ناپذیر ارائه هستند و نمی‌توان آنها را به طور کامل حذف کرد. با این حال می‌توانید مقدار آنها را تغییر دهید یا اگر ویژگی اجازه دهد، به مقدار خالی تنظیم کنید.

### اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم چه می‌شود؟

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی ویژگی پیش از اضافه کردن نیست، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

### آیا می‌توانم بدون بارگذاری کامل ارائه به ویژگی‌های ارائه دسترسی پیدا کنم؟

بله، می‌توانید بدون بارگذاری کامل ارائه به ویژگی‌های ارائه دسترسی پیدا کنید با استفاده از متد `getPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentationfactory/). سپس از متد `readDocumentProperties` ارائه شده توسط رابط [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/) برای خواندن کارآمد ویژگی‌ها استفاده کنید، که حافظه را صرفه‌جویی کرده و عملکرد را بهبود می‌بخشد.