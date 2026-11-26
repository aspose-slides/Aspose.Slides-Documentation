---
title: مدیریت ویژگی‌های ارائه در Java
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/java/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های پیش‌ساخته
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان پیش‌نگار
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای Java به‌صورت کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides برای Java از ویژگی‌های سند **پیش‌ساخته** و **سفارشی** پشتیبانی می‌کند. از این ویژگی‌ها برای خواندن و به‌روزرسانی فراداده ارائه استفاده کنید، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر.

Aspose.Slides به شما امکان می‌دهد با ویژگی‌های سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این رابط توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، اصلاح کنید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیره ارائه‌ها، فراداده‌های برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را ایجاد کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

ویژگی‌های سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آن‌ها به دو دسته تقسیم می‌شوند:

- **ویژگی‌های پیش‌ساخته** شامل فراداده‌های استاندارد هستند، مانند عنوان، نویسنده و آمار سند.
- **ویژگی‌های سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides برای Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، **File → Info → Properties → Advanced Properties** را انتخاب کنید تا فراداده سند را بررسی کنید. دیالوگ اطلاعات را در برگه‌هایی مانند **Summary**، **Statistics**، **Contents** و **Custom** گروه‌بندی می‌کند. برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر، برگه **Custom** را استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائهٔ رمزنگاری‌شده**

یک رمز عبور بازکننده معمولاً هم محتوای ارائه و هم ویژگی‌های سند را محافظت می‌کند. وقتی یک ارائه پس از فراخوانی [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) با مقدار `false` رمزنگاری شود، ویژگی‌های سند آن به‌صورت عمومی باقی می‌مانند. سپس برنامه می‌تواند [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) را با مقدار `true` صدا بزند و فراداده عمومی را بدون ارائهٔ رمز عبور بازکننده بخواند.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) کنترل می‌کند که Aspose.Slides چه چیزی را بارگذاری کند؛ این کار هیچ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزنگاری گنجانده شده باشند، بارگذاری آن‌ها بدون رمز عبور با شکست مواجه می‌شود. اگر ارائه رمزنگاری نشده باشد، این گزینه نادیده گرفته می‌شود و ارائهٔ کامل بارگذاری می‌گردد.

این مثال به یک ارائهٔ رمزنگاری‌شده نیاز دارد که ویژگی‌های سند آن به‌صورت عمومی باقی مانده باشند. حالت بارگذاری را از طریق [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) بررسی می‌کند و سپس ویژگی‌های پیش‌ساخته را با استفاده از [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) می‌خواند:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، چیدمان‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که به مدل اشیای کامل ارائه نیاز دارد، [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
فراداده عمومی ممکن است نام‌های نویسنده، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساس را همراه با ارائه رمزنگاری کنید. آن‌ها را به‌صورت عمومی فقط زمانی باقی بگذارید که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت اسناد نیاز خاصی برای دسترسی بدون رمز عبور داشته باشند.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائهٔ رمزنگاری‌شده**

برای یک فایل PPTX رمزنگاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با مقدار `true` بارگذاری شود، برای خواندن فراداده عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء تنها حاوی فراداده ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های مربوطه داخل ارائهٔ رمزنگاری‌شده سازگار بمانند. به‌روزرسانی آن‌ها به‌همین دلیل نیاز به رمز عبور بازکننده صحیح و یک بارگذاری کامل دارد.

این مثال به یک ارائهٔ PPTX رمزنگاری‌شده با ویژگی‌های سند عمومی و یک رمز عبور بازکننده شناخته‌شده نیاز دارد. ابتدا ارائهٔ کامل را با [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) باز می‌کند، ویژگی‌های پیش‌ساخته عمومی را به‌روز می‌کند و نتیجه را ذخیره می‌نماید. سپس از [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) برای تأیید حفظ رمزنگاری استفاده می‌کند و فراداده عمومی را بدون رمز عبور باز می‌کند تا مقادیر جدید را بررسی کند:

```java
import com.aspose.slides.IDocumentProperties;
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
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

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

اگر یک برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزنگاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های پیش‌ساخته**

رابطه [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) متادیتای پیش‌ساخته را از طریق متدهای getter افشا می‌کند، از جمله [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--)، [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) و [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--). این مثال یک ارائهٔ موجود را باز می‌کند و متادیتای ذخیره‌شده آن را در کنسول چاپ می‌نماید. مقادیر بسته به ارائهٔ ورودی متفاوت است؛ برخی فیلدها ممکن است خالی باشند.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **گزارش شماره بازبینی و زمان ویرایش**

برای گزارش یک سطر برای هر فایل PPTX در پوشهٔ `presentations`، [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) را فراخوانی کنید تا [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) آن را بدون بارگذاری اسلایدها برای ویرایش بخوانید. API جاوا مدت زمان ویرایش را به میلی‌ثانیه برمی‌گرداند. مثال آن را به صورت ساعت، دقیقه و ثانیه قالب‌بندی می‌کند و برای مدت‌های برابر یا بیشتر از ۲۴ ساعت، تعداد روز را نیز اضافه می‌کند.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

System.out.println("File | RevisionNumber | TotalEditingTime");
try (DirectoryStream<Path> files = Files.newDirectoryStream(Paths.get("presentations"), "*.pptx")) {
    for (Path path : files) {
        if (!Files.isRegularFile(path)) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(path.toString());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format("%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf("%s | %d | %s%n", path.getFileName(), properties.getRevisionNumber(), editingTime);
    }
}
```

برای ارائه‌ای که زمان ویرایشی ثبت‌شدهٔ ۱ روز، ۲ ساعت و ۵ دقیقه دارد، گزارش خروجی زیر را نشان می‌دهد.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getRevisionNumber--) مقدار را می‌خواند که برنامه‌ها می‌توانند با [setRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) تغییر دهند. تنها شماره بازبینی نمی‌تواند تعداد دفعات ذخیرهٔ ارائه یا تاریخچه نسخهٔ آن را تعیین کند.

[getTotalEditingTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) مدت زمان ویرایشی ثبت‌شده در فایل را می‌خواند. مقدار `00:00:00` به این معنی است که مدت زمان ذخیره‌شده صفر است، حتی اگر کسی ارائه را ویرایش کرده باشد.

## **تغییر ویژگی‌های پیش‌ساخته**

برای به‌روزرسانی متادیتای پیش‌ساخته، از متدهای setter روی شیء بازگردانده‌شده توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) استفاده کنید. این مثال یک ارائهٔ موجود را باز می‌کند، [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)، [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)، [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)، [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-)، و [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) را فراخوانی می‌کند، سپس ارائهٔ به‌روزرسانی‌شده را با [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌نماید. PPTX ذخیره‌شده حاوی متادیتای جدید است.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مدیریت پایهٔ ابرپیوند**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) پایهٔ سطح سند را برای ابرپیوندهای نسبی برمی‌گرداند. برای تغییر یا پاک کردن آن از [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) استفاده کنید. این زمانی مفید است که یک ارائه و فایل‌های پیوندی آن را به مکان دیگری منتقل می‌کنید. این مقدار جدا از [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) یک ابرپیوند منفرد است: تغییر پایه باعث بازنویسی آدرس‌های ذخیره‌شده یا تغییر مقصدهای مطلق نمی‌شود.

این مثال به یک ارائهٔ حاوی هر دو لینک نسبی، مانند `target.html`، و لینک مطلق، مانند `https://example.org/absolute.html` نیاز دارد. پایهٔ موجود را می‌خواند، یک آدرس پایهٔ جدید اختصاص می‌دهد و ارائه را ذخیره و دوباره باز می‌کند تا مقدار را بررسی کند. سپس پایه را با یک رشتهٔ خالی پاک می‌کند و مقدار خالی را در فایلی ذخیره‌شده جداگانه تأیید می‌نماید. آدرس پایهٔ مثال را با مکان فایل‌های پیوندی خود جایگزین کنید.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

دو پیام تأیید باید `true` چاپ کنند. پاک کردن پایه آدرس‌های ابرپیوندهای منفرد را دست‌نخورده می‌گذارد.

یک لینک نسبی به `target.pptx` هنگامیکه پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازگشایی ارائه، همان لینک `new/target.pptx` را باز می‌کرد. یک لینک مطلق همچنان همان فایل را باز می‌کرد. لینک‌های نسبی خود را در PowerPoint قبل و بعد از انتقال ارائه یا تغییر پایه تست کنید.

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی متادیتایی را ذخیره می‌کنند که فیلد پیش‌ساخته‌ای متناظر برای آن وجود ندارد. متد [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) به شما اجازه می‌دهد مقدار را بر اساس نام ویژگی اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متن و یک مقدار عددی نسخه اضافه می‌کند و ارائه را با [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌نماید. اختصاص مقدار به یک نام موجود، مقدار آن ویژگی را جایگزین می‌کند.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

این مثال یک ارائه حاوی ویژگی‌های سفارشی را باز می‌کند و از [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) برای پیمایش آن‌ها استفاده می‌نماید. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) یک ایندکس صفر مبنی می‌پذیرد و نامی که توسط [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) استفاده می‌شود را برمی‌گرداند. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با یک رشته عددی جایگزین می‌نماید، صرف‌نظر از نوع اصلی آن، و تغییرات را ذخیره می‌کند. اگر ویژگی سفارشی‌ای وجود نداشته باشد، حلقه تغییری ایجاد نمی‌کند.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مثال زنده**

Try the [**مشاهده و ویرایش فراداده پاورپوینت**](https://products.aspose.app/slides/metadata) online app to see how to work with document properties using the Aspose.Slides API:

[![مشاهده و ویرایش فراداده پاورپوینت](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **پرسش‌های متداول**

**چگونه می‌توان یک ویژگی پیش‌ساخته را از یک ارائه حذف کرد؟**

ویژگی‌های پیش‌ساخته بخشی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را به‌تمامی حذف کرد. اما می‌توانید مقادیرشان را تغییر دهید یا در صورت امکان توسط ویژگی خاص، به مقدار خالی تنظیم کنید.

**چه اتفاقی می‌افتد اگر یک ویژگی سفارشی که از پیش موجود است اضافه کنم؟**

اگر یک ویژگی سفارشی که از پیش وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی پیش‌ازاین ویژگی ندارید، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی داشته باشم؟**

بله. از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) استفاده کنید و سپس [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) برای خواندن متادیتای ذخیره‌شدهٔ سند بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) استفاده کنید. برای مثال کامل گزارش و محدودیت‌های خاص فرمت، به [ساخت موجودی ارائهٔ کم‌حجم](/slides/fa/java/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائهٔ رمزنگاری‌شده را بدون رمز عبور بازکننده آن بخوانم؟**

بله. ارائه باید پس از فراخوانی [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) با مقدار `false` رمزنگاری شده باشد و سپس پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با مقدار `true` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزنگاری‌شده را در حالت فقط‑ویژگی‑های‑سند به‌روز کنم؟**

خیر. داده‌های ویژگی عمومی و رمزنگاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزنگاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور بازکنندهٔ صحیح است.