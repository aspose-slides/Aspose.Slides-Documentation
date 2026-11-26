---
title: مدیریت ویژگی‌های ارائه در Android
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/androidjava/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های درون‌ساخت
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
- Android
- Java
- Aspose.Slides
description: "ویژگی‌های اصلی ارائه در Aspose.Slides برای Android از طریق Java را مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides برای Android از طریق Java از ویژگی‌های سند **درون‌ساخت** و **سفارشی** پشتیبانی می‌کند. از این ویژگی‌ها برای خواندن و به‌روزرسانی فرادادهٔ ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان می‌دهد با ویژگی‌های سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این رابط توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیرهٔ ارائه‌ها، فرادادهٔ برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را ایجاد کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

ویژگی‌های سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آن‌ها به دو دسته تقسیم می‌شوند:

- **ویژگی‌های درون‌ساخت** شامل فرادادهٔ استاندارد، مانند عنوان، نویسنده و آمار سند هستند.
- **ویژگی‌های سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides برای Android از طریق Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، برای بررسی فرادادهٔ سند، **File → Info → Properties → Advanced Properties** را انتخاب کنید. این گفت‌وگو اطلاعات را در برگه‌های **Summary**، **Statistics**، **Contents** و **Custom** گروه‌بندی می‌کند. برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر، از برگهٔ **Custom** استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائهٔ رمزگذاری‌شده**

یک گذرواژهٔ باز کردن معمولاً هم محتویات ارائه و هم ویژگی‌های سند را محافظت می‌کند. وقتی یک ارائه پس از فراخوانی [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) با مقدار `false` رمزگذاری می‌شود، ویژگی‌های سند آن عمومی باقی می‌مانند. سپس یک برنامه می‌تواند با فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با مقدار `true`، فرادادهٔ عمومی را بدون ارائهٔ گذرواژهٔ باز کردن بخواند.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) تعیین می‌کند Aspose.Slides چه چیزی را بارگذاری می‌کند؛ این متد هیچ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شده باشند، بارگذاری آن‌ها بدون گذرواژه شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته شده و تمام ارائه بارگذاری می‌شود.

این مثال به ارائه‌ای رمزگذاری‌شده نیاز دارد که ویژگی‌های سند آن عمومی باقی مانده باشند. حالت بارگذاری را از طریق [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) بررسی می‌کند و سپس ویژگی‌های درون‌ساخت را با استفاده از [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) می‌خواند:

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

در این حالت، محتویات اسلاید بارگذاری نمی‌شود. اسلایدها، استادها، چیدمان‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که به مدل کامل شیء ارائه نیاز دارد، [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
فرادادهٔ عمومی ممکن است نام‌های نویسنده، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساس را همراه با ارائه رمزگذاری کنید. فقط زمانی که سیستم‌های ایندکس‌سازی، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی به آن‌ها بدون گذرواژه داشته باشند، آن‌ها را عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائهٔ رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با مقدار `true` بارگذاری شده باشد، برای خواندن فرادادهٔ عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑metadata ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های مربوطه درون ارائهٔ رمزگذاری‌شده سازگار باقی بمانند. بنابراین به‌روزرسانی آن‌ها نیاز به گذرواژهٔ صحیح باز کردن و بارگذاری کامل دارد.

این مثال به ارائهٔ PPTX رمزگذاری‌شده‌ای نیاز دارد که ویژگی‌های سند عمومی داشته باشد و گذرواژهٔ باز کردن آن شناخته شده باشد. با استفاده از [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ارائهٔ کامل را باز می‌کند، ویژگی‌های درون‌ساخت عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) اطمینان حاصل می‌کند که رمزگذاری حفظ شده و فرادادهٔ عمومی را بدون گذرواژه باز می‌کند تا مقادیر جدید را بررسی سازد:

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

اگر برنامه مجاز به رمزگشایی یا بارگذاری محتوای ارائه نباشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌ عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های درون‌ساخت**

رابط [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) ویژگی‌های درون‌ساخت را از طریق روش‌های getter، از جمله [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--)، [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) و [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) در دسترس قرار می‌دهد. این مثال یک ارائه موجود را باز می‌کند و فرادادهٔ ذخیره‌شدهٔ آن را در کنسول چاپ می‌نماید. مقادیر بستگی به ارائهٔ ورودی دارد؛ برخی فیلدها ممکن است خالی باشند.

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

### **گزارش شمارهٔ بازنگری و زمان ویرایش**

برای گزارش یک ردیف برای هر فایل PPTX در پوشه‌ای که برنامهٔ Android شما می‌تواند بخواند، از [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) برای خواندن [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) آن بدون بارگذاری اسلایدها برای ویرایش استفاده کنید. API Android از طریق Java مدت زمان ویرایش را بر حسب میلی‌ثانیه بر می‌گرداند. مسیر پوشهٔ نمونه را با مسیر فایل‌های خود جایگزین کنید. مثال مدت زمان را به ساعت، دقیقه و ثانیه قالب‌بندی می‌کند و برای مدت‌های ۲۴ ساعت یا بیشتر، تعداد روزها را نیز نشان می‌دهد.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.File;
import java.util.Locale;

File folder = new File("/path/to/presentations");
File[] files = folder.listFiles();
if (files == null) {
    System.out.println("Cannot list files in " + folder);
} else {
    System.out.println("File | RevisionNumber | TotalEditingTime");
    for (File file : files) {
        if (!file.isFile() || !file.getName().toLowerCase(Locale.ROOT).endsWith(".pptx")) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(file.getAbsolutePath());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format(Locale.ROOT, "%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf(Locale.ROOT, "%s | %d | %s%n", file.getName(), properties.getRevisionNumber(), editingTime);
    }
}
```

برای ارائه‌ای که زمان ویرایش ۱ روز، ۲ ساعت و ۵ دقیقه ثبت شده باشد، گزارش خروجی زیر را نشان می‌دهد.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getRevisionNumber--) مقدارى می‌خواند که برنامه‌ها می‌توانند با [setRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) تغییر دهند. تنها شمارهٔ بازنگری نمی‌تواند تعداد دفعات ذخیرهٔ ارائه یا تاریخچهٔ نسخهٔ آن را تعیین کند.

[getTotalEditingTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) مدت زمان ویرایش ثبت‌شده در فایل را می‌خواند. مقدار `00:00:00` به این معنی است که مدت زمان ذخیره‌شده صفر است، حتی اگر کسی ارائه را ویرایش کرده باشد.

## **تغییر ویژگی‌های درون‌ساخت**

برای به‌روزرسانی فرادادهٔ درون‌ساخت، از روش‌های setter بر روی شیء بازگردانده‌شده توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) استفاده کنید. این مثال یک ارائه موجود را باز می‌کند، [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)، [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)، [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)، [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) و [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) را فراخوانی می‌کند و سپس ارائهٔ به‌روز شده را با [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌نماید. فایل PPTX ذخیره‌شده حاوی فرادادهٔ جدید است.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مدیریت پایهٔ پیوندهای ابرمتنی**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) پایهٔ سطح سند برای پیوندهای نسبی را برمی‌گرداند. برای تغییر یا پاک کردن آن از [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) استفاده کنید. این موارد هنگام جابجایی یک ارائه و فایل‌های لینک‌شده‌اش به مکان دیگری مفید است. این ویژگی از [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) یک پیوند ابرمتنی جداست: تغییر پایه آدرس‌های ذخیره‌شدهٔ پیوند را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

این مثال به ارائه‌ای نیاز دارد که شامل هر دو پیوند نسبی مانند `target.html` و پیوند مطلق مانند `https://example.org/absolute.html` باشد. ابتدا پایهٔ موجود را می‌خواند، آدرس پایهٔ جدیدی اختصاص می‌دهد و پس از ذخیره و بازگشایی ارائه مقدار را بررسی می‌کند. سپس پایه را با یک رشتهٔ خالی پاک می‌کند و مقدار خالی را در فایل ذخیره‌شدهٔ جداگانه تأیید می‌نماید. آدرس پایهٔ مثال را با مکان فایل‌های لینک‌شدهٔ خود جایگزین کنید.

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

دو پیام تأیید باید `true` چاپ کنند. پاک کردن پایه آدرس‌های پیوندهای ابرمتنی منفرد را دست نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` وقتی پایه به پوشهٔ `old` اشاره داشت، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازگشایی ارائه، همان پیوند `new/target.pptx` را باز کرد. یک پیوند مطلق به همان فایل ادامه داد. لینک‌های نسبی خود را در PowerPoint قبل و بعد از جابجایی ارائه یا تغییر پایه آزمایش کنید.

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی فراداده‌ای را ذخیره می‌کنند که فیلد درون‌ساختی متناظر ندارند. روش [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) به شما امکان می‌دهد مقدار را بر اساس نام ویژگی اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار نسخه عددی اضافه می‌نماید و ارائه را با [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌کند. اختصاص مقدار به یک نام موجود، مقدار آن ویژگی را جایگزین می‌کند.

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

این مثال یک ارائه شامل ویژگی‌های سفارشی را باز می‌کند و از [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) برای پیمایش آن‌ها استفاده می‌کند. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) یک اندیس صفر‑پایه می‌گیرد و نامی که توسط [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) استفاده شده را برمی‌گرداند. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با یک رشتهٔ عددی جایگزین می‌کند بدون توجه به نوع اصلی آن، و تغییرات را ذخیره می‌نماید. اگر ویژگی سفارشی وجود نداشته باشد، حلقه هیچ تغییری ایجاد نمی‌کند.

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

برای مشاهده نحوه کار با ویژگی‌های سند با استفاده از API Aspose.Slides، برنامهٔ آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) را امتحان کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک ویژگی درون‌ساخت را از یک ارائه حذف کنم؟**

ویژگی‌های درون‌ساخت بخشی جدایی‌ناپذیر از ارائه هستند و نمی‌توانند به‌ طور کامل حذف شوند. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورتی که ویژگی خاص اجازه دهد، به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی اضافه کنم که قبلاً وجود دارد چه می‌شود؟**

اگر یک ویژگی سفارشی که از پیش وجود دارد اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید، زیرا Aspose.Slides به‌ طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی پیدا کنم؟**

بله. از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و سپس [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) استفاده کنید تا فرادادهٔ ذخیره‌شدهٔ سند را بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص قالب، به [Build a Lightweight Presentation Inventory](/slides/fa/androidjava/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائهٔ رمزگذاری‌شده را بدون گذرواژهٔ باز کردن آن بخوانم؟**

بله. ارائه باید پس از فراخوانی [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) با مقدار `false` رمزگذاری شده باشد و پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با مقدار `true` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑ویژگی‌های‑سند به‌روز کنم؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده مستلزم بارگذاری کامل ارائه با گذرواژهٔ صحیح باز کردن است.