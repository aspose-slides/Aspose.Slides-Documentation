---
title: مدیریت خصوصیات ارائه در اندروید
linktitle: خصوصیات ارائه
type: docs
weight: 70
url: /fa/androidjava/presentation-properties/
keywords:
- خصوصیات PowerPoint
- خصوصیات ارائه
- خصوصیات سند
- خصوصیات توکار
- خصوصیات سفارشی
- خصوصیات پیشرفته
- مدیریت خصوصیات
- تغییر خصوصیات
- متادیتای سند
- ویرایش متادیتا
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "در Aspose.Slides برای اندروید از طریق جاوا، خصوصیات ارائه را به‌صورت جامع مدیریت کنید و جستجو، برندینگ و جریان کار در فایل‌های PowerPoint و OpenDocument خود را بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides for Android via Java از ویژگی‌های **توکار** و **سفارشی** برای خصوصیات سند پشتیبانی می‌کند. از این خصوصیات برای خواندن و به‌روزرسانی متادیتای ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان می‌دهد با خصوصیات سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این رابط توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این خصوصیات را بخوانید، اصلاح کنید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیره‌سازی ارائه‌ها، متادیتای برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را تولید کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت خصوصیات ارائه**

خصائص سند اطلاعات توصیفی را همراه با محتوای ارائه ذخیره می‌کنند. آنها به دو دسته تقسیم می‌شوند:

- **خصوصیات توکار** شامل متادیتای استانداردی مانند عنوان، نویسنده و آمارهای سند هستند.
- **خصوصیات سفارشی** جفت نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for Android via Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، برای بررسی متادیتای سند، **File → Info → Properties → Advanced Properties** را انتخاب کنید. این دیالوگ اطلاعات را در برگه‌هایی مانند **Summary**، **Statistics**، **Contents** و **Custom** گروه‌بندی می‌کند. برای مدیریت خصوصیات تعریف‌شده توسط کاربر، از برگه **Custom** استفاده کنید.

## **خواندن خصوصیات عمومی از یک ارائه رمزگذاری‌شده**

یک رمز عبور باز‌کن معمولاً هم محتوای ارائه و هم خصوصیات سند را محافظت می‌کند. وقتی یک ارائه پس از فراخوانی [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) با `false` رمزنگاری می‌شود، خصوصیات سند آن به حالت عمومی باقی می‌مانند. سپس یک برنامه می‌تواند با فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با `true`، متادیتای عمومی را بدون وارد کردن رمز عبور باز‌کن بخواند.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) تعیین می‌کند Aspose.Slides چه چیزی را بارگذاری کند؛ این متد هیچ چیز را رمزگشایی نمی‌کند. اگر خصوصیات در رمزنگاری گنجانده شده باشند، بارگذاری آنها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌گردد.

این مثال به نمایه‌ای رمزگذاری‌شده نیاز دارد که خصوصیات سند آن به صورت عمومی باقی مانده باشد. حالت بارگذاری از طریق [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) بررسی می‌شود و سپس خصوصیات توکار از طریق [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) خوانده می‌شود:

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

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، لایه‌ها، شکل‌ها، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید پیش از انجام عملی که نیاز به مدل کامل شیء ارائه دارد، همیشه با استفاده از [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) بررسی کنند.

{{% alert color="warning" title="Warning" %}}
متادیتای عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. خصوصیات حساس را به همراه ارائه رمزنگاری کنید. آنها را به صورت عمومی فقط زمانی بگذارید که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز مشخصی به دسترسی بدون رمز عبور داشته باشند.
{{% /alert %}}

## **به‌روزرسانی خصوصیات یک ارائه رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با `true` بارگذاری می‌شود، هدف خواندن متادیتای عمومی است. Aspose.Slides نمی‌تواند خصوصیات تغییر یافته را از این شیء فقط-متادیتا ذخیره کند زیرا خصوصیات عمومی باید با داده‌های مربوطه در داخل ارائه رمزگذاری‌شده سازگار بمانند. بنابراین به‌روزرسانی آنها نیاز به رمز عبور باز‌کن صحیح و بارگذاری کامل دارد.

این مثال به یک ارائه PPTX رمزگذاری‌شده نیاز دارد که خصوصیات سند آن عمومی بوده و رمز عبور باز‌کن آن شناخته شده باشد. با استفاده از [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ارائه کامل باز می‌شود، خصوصیات توکار عمومی به‌روزرسانی می‌شوند و نتیجه ذخیره می‌گردد. سپس با استفاده از [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) صحت رمزنگاری بررسی می‌شود و متادیتای عمومی بدون رمز عبور باز می‌شود تا مقادیر جدید را تأیید کند:

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

اگر برنامه‌ای اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید خصوصیات عمومی یک فایل PPTX رمزگذاری‌شده را به صورت فقط‑خواندنی در نظر بگیرد.

## **دسترسی به خصوصیات توکار**

رابط [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) متادیتای توکار را از طریق متدهای getter مانند [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--)، [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) و [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) نمایان می‌کند. این مثال یک ارائه موجود را باز می‌کند و متادیتای ذخیره‌شدهٔ آن را در کنسول چاپ می‌کند. مقادیر بسته به ارائهٔ ورودی متفاوت هستند؛ برخی فیلدها ممکن است خالی باشند.

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

## **تغییر خصوصیات توکار**

برای به‌روزرسانی متادیتای توکار، از متدهای setter بر روی شیء بازگردانده شده توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) استفاده کنید. این مثال یک ارائه موجود را باز می‌کند، متدهای [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)، [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)، [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)، [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) و [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) را فراخوانی می‌کند و سپس ارائه به‌روزرسانی‌شده را با [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌نماید. فایل PPTX ذخیره‌شده شامل متادیتای جدید خواهد بود.

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

## **مدیریت پایهٔ پیوندهای داخلی**

متد [IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) مقدار پایهٔ سطح سند برای پیوندهای نسبی را برمی‌گرداند. برای تغییر یا پاک کردن آن از [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) استفاده کنید. این کار زمانی مفید است که یک ارائه و فایل‌های پیوندی آن را به مکان دیگری منتقل می‌کنید. این ویژگی با [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) یک پیوند جداگانه متفاوت است: تغییر پایه باعث بازنویسی آدرس‌های ذخیره‌شده یا تغییر مقصدهای مطلق نمی‌شود.

این مثال به ارائه‌ای نیاز دارد که هم یک پیوند نسبی مانند `target.html` و هم یک پیوند مطلق مانند `https://example.org/absolute.html` داشته باشد. پایهٔ موجود خوانده می‌شود، آدرس پایهٔ جدید اختصاص داده می‌شود و سپس ارائه ذخیره و مجدداً باز می‌شود تا مقدار بررسی شود. سپس پایه با رشتهٔ خالی پاک می‌شود و مقدار خالی در فایلی ذخیره‌شدهٔ جداگانه تأیید می‌گردد. آدرس پایهٔ مثال را با مکان فایل‌های پیوندی خود جایگزین کنید.

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

دو پیام تأیید باید `true` چاپ کنند. پاک کردن پایهٔ پیوندها، آدرس‌های فردی پیوندها را دست نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` وقتی پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازگشایی ارائه، همان پیوند `new/target.pptx` را باز می‌کند. یک پیوند مطلق همچنان همان فایل را باز می‌کرد. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابه‌جایی ارائه یا تغییر پایه تست کنید.

## **افزودن خصوصیات سفارشی به ارائه**

خصوصیات سفارشی متادیتایی را ذخیره می‌کنند که فیلد توکار مربوطه‌ای ندارند. متد [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) به شما امکان می‌دهد مقدار را بر اساس نام خصوصیت اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و سپس ارائه را با [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌نماید. اختصاص یک مقدار به نام موجود، مقدار آن خصوصیت را جایگزین می‌کند.

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

## **دسترسی و تغییر خصوصیات سفارشی**

این مثال یک ارائه حاوی خصوصیات سفارشی را باز می‌کند و با استفاده از [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) بر روی آنها پیمایش می‌کند. متد [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) یک ایندکس صفر‑پایه می‌گیرد و نامی را برمی‌گرداند که توسط [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) استفاده می‌شود. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با یک رشتهٔ عددی جایگزین می‌نماید بدون توجه به نوع اصلی آن و تغییرات را ذخیره می‌کند. اگر خصوصیات سفارشی وجود نداشته باشند، حلقه هیچ تغییری ایجاد نمی‌کند.

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

برای مشاهدهٔ نحوه کار با خصوصیات سند با استفاده از API Aspose.Slides، برنامهٔ آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) را امتحان کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **پرسش‌های متداول**

**چگونه می‌توان یک خصوصیت توکار را از ارائه حذف کرد؟**

خصوصیات توکار جزء اجزای جدایی‌ناپذیر ارائه هستند و نمی‌توان آنها را به‌طور کامل حذف کرد. با این حال می‌توانید مقدار آنها را تغییر دهید یا در صورتی که اجازهٔ خصوصیت خاصی باشد، به مقدار خالی تنظیم کنید.

**اگر یک خصوصیت سفارشی که از قبل وجود دارد را اضافه کنم چه می‌شود؟**

اگر یک خصوصیت سفارشی که از قبل وجود دارد را اضافه کنید، مقدار فعلی آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی خصوصیت نیست، زیرا Aspose.Slides به‌صورت خودکار مقدار خصوصیت را به‌روز می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه به خصوصیات آن دسترسی پیدا کنم؟**

بله. می‌توانید از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) سپس [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) استفاده کنید تا متادیتای ذخیره‌شدهٔ سند را بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌دهی و محدودیت‌های خاص فرمت، به مقالهٔ [Build a Lightweight Presentation Inventory](/slides/fa/androidjava/examine-presentation/) مراجعه کنید.

**آیا می‌توانم خصوصیات عمومی یک ارائه رمزگذاری‌شده را بدون رمز عبور باز‌کن آن بخوانم؟**

بله. ارائه باید پس از فراخوانی [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) با `false` رمزنگاری شده باشد و پس از آن با فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با `true` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑خصوصیات‑سند به‌روزرسانی کنم؟**

خیر. داده‌های عمومی و رموزنگاری‌شده باید سازگار بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور باز‌کن صحیح است.