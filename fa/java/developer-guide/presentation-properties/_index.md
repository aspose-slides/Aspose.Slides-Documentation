---
title: مدیریت خصوصیات ارائه در جاوا
linktitle: خصوصیات ارائه
type: docs
weight: 70
url: /fa/java/presentation-properties/
keywords:
- خصوصیات PowerPoint
- خصوصیات ارائه
- خصوصیات سند
- خصوصیات پیش‌فرض
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
- Java
- Aspose.Slides
description: "در Aspose.Slides برای Java، خصوصیات ارائه را به‌طور کامل مدیریت کنید و جستجو، برندسازی و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه کنید."
---
## **مقدمه**

Aspose.Slides for Java از ویژگی‌های **پیش‌فرض** و **سفارشی** سند پشتیبانی می‌کند. از این ویژگی‌ها برای خواندن و به‌روزرسانی متادیتای ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان کار با خصوصیات سند ارائه را از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) می‌دهد. یک نمونه از این رابط توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این خصوصیات را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="توجه" %}}
Aspose.Slides هنگام ذخیره‌سازی ارائه‌ها، متادیتای برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را ایجاد کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت خصوصیات ارائه**

خصوصیات سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کند. این خصوصیات به دو دسته تقسیم می‌شوند:

- **خصوصیات پیش‌فرض** شامل متادیتای استانداردی مانند عنوان، نویسنده و آمار سند هستند.
- **خصوصیات سفارشی** جفت نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، برای بررسی متادیتای سند، **File → Info → Properties → Advanced Properties** را انتخاب کنید. این گفت‌وگو اطلاعات را در تب‌هایی مانند **Summary**، **Statistics**، **Contents** و **Custom** گروه‌بندی می‌کند. برای مدیریت خصوصیات تعریف‌شده توسط کاربر از تب **Custom** استفاده کنید.

## **خواندن خصوصیات عمومی از یک ارائهٔ رمزگذاری‌شده**

یک رمز عبور بازکن معمولاً هم محتوای ارائه و هم خصوصیات سند را محافظت می‌کند. وقتی ارائه پس از فراخوانی [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) با مقدار `false` رمزگذاری شود، خصوصیات سند به صورت عمومی باقی می‌مانند. سپس برنامه می‌تواند با فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با مقدار `true` متادیتای عمومی را بدون ارائهٔ رمز عبور بازکن بخواند.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) تعیین می‌کند Aspose.Slides چه چیزی را بارگذاری می‌کند؛ این کار هیچ چیز را رمزگشایی نمی‌کند. اگر خصوصیات در رمزگذاری گنجانده شده باشند، بارگذاری آن‌ها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

این مثال به یک ارائهٔ رمزگذاری‌شده نیاز دارد که خصوصیات سند آن به صورت عمومی باقی مانده باشد. حالت بارگذاری از طریق [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) بررسی می‌شود و سپس خصوصیات پیش‌فرض با استفاده از [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) خوانده می‌شود:

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

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، استادها، طرح‌بندی‌ها، شکل‌ها، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که **به مدل کامل شیء ارائه نیاز دارد**، [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) را بررسی کنند.

{{% alert color="warning" title="هشدار" %}}
متادیتای عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر **سفارشی** را فاش کند. خصوصیات حساس را همراه با ارائه رمزگذاری کنید. فقط زمانی که سیستم‌های ایندکس‌سازی، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی به آن‌ها بدون رمز عبور داشته باشند، عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی خصوصیات یک ارائهٔ رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با مقدار `true` بارگذاری شود، برای خواندن متادیتای عمومی هدف دارد. Aspose.Slides نمی‌تواند خصوصیات تغییر یافتهٔ آن متادیتای فقط‑خواندنی را ذخیره کند چون خصوصیات عمومی باید با دادهٔ متناظر داخل ارائهٔ رمزگذاری‌شده سازگار بمانند. بنابراین به‌روزرسانی آن‌ها مستلزم رمز عبور صحیح بازکن و یک بارگذاری کامل است.

این مثال به یک ارائهٔ PPTX رمزگذاری‌شده با خصوصیات سند عمومی و رمز عبور بازکن شناخته‌شده نیاز دارد. ارائهٔ کامل را با استفاده از [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) باز می‌کند، خصوصیات پیش‌فرض عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) صحت حفظ رمزگذاری را تأیید می‌کند و متادیتای عمومی را بدون رمز عبور دوباره باز می‌کند تا مقادیر جدید را بررسی کند:

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

اگر برنامه مجاز به رمز‑گشایی یا بارگذاری محتوای ارائه نباشد، باید خصوصیات عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به خصوصیات پیش‌فرض**

رابط [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) متادیتای پیش‌فرض را از طریق متدهای getter مانند [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--)، [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--)، و [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) در دسترس می‌گذارد. این مثال یک ارائهٔ موجود را باز می‌کند و متادیتای ذخیره‌شدهٔ آن را در کنسول چاپ می‌نماید. مقادیر بسته به ارائهٔ ورودی متفاوت‌اند؛ برخی فیلدها ممکن است خالی باشند.

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

## **تغییر خصوصیات پیش‌فرض**

برای به‌روزرسانی متادیتای پیش‌فرض، از متدهای setter بر روی شیئی که توسط [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) برگردانده می‌شود، استفاده کنید. این مثال یک ارائهٔ موجود را باز می‌کند، [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)، [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)، [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)، [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-)، و [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) را فراخوانی می‌کند و سپس ارائهٔ به‌روزشده را با [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌کند. فایل PPTX ذخیره‌شده شامل متادیتای جدید خواهد بود.

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

## **مدیریت پایهٔ پیوندهای ابرمتن**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) پایهٔ سطری برای پیوندهای نسبی سطح سند را برمی‌گرداند. برای تغییر یا پاک‌سازی آن از [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) استفاده کنید. این کار هنگام جابجایی یک ارائه و فایل‌های پیوندی آن به مکان دیگری مفید است. این ویژگی مستقل از [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) یک پیوند جداگانه است: تغییر پایه، آدرس‌های ذخیره‌شدهٔ پیوندها را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

این مثال به یک ارائهٔ حاوی هر دو پیوند نسبی (مانند `target.html`) و پیوند مطلق (مانند `https://example.org/absolute.html`) نیاز دارد. ابتدا پایهٔ موجود را می‌خواند، یک پایهٔ جدید اختصاص می‌دهد و ارائه را ذخیره و دوباره باز می‌کند تا مقدار را بررسی کند. سپس پایه را با رشتهٔ خالی پاک می‌کند و مقدار خالی را در فایلی جداگانه تأیید می‌نماید. آدرس پایهٔ مثال را با مکان فایل‌های پیوندی خود جایگزین کنید.

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

دو پیام تأیید باید `true` چاپ کنند. پاک‌سازی پایه، آدرس‌های پیوندهای جداگانه را دست‌نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` هنگام داشتن پایه به پوشهٔ `old`، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و باز کردن دوبارهٔ ارائه، همان پیوند `new/target.pptx` را باز می‌کند. یک پیوند مطلق همچنان همان فایل را باز می‌کند. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابجایی ارائه یا تغییر پایه تست کنید.

## **افزودن خصوصیات سفارشی به ارائه**

خصوصیات سفارشی متادیتایی را ذخیره می‌کنند که فیلد پیش‌فرضی برای آن موجود نیست. متد [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) به شما اجازه می‌دهد مقدار را بر اساس نام خصوصیت تعیین کنید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و ارائه را با [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌نماید. اختصاص مقدار به یک نام موجود مقدار همان خصوصیت را جایگزین می‌کند.

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

این مثال یک ارائه حاوی خصوصیات سفارشی را باز می‌کند و با استفاده از [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) بر روی آن‌ها تکرار می‌نماید. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) یک شاخص صفر‑پایه می‌گیرد و نام مورد استفاده توسط [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) را برمی‌گرداند. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با یک رشتهٔ شماره‌دار جایگزین می‌کند و تغییرات را ذخیره می‌نماید. اگر خصوصیات سفارشی وجود نداشته باشند، حلقه هیچ تغییری نمی‌سازد.

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

سعی کنید برنامهٔ آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) را برای مشاهدهٔ نحوه کار با خصوصیات سند با استفاده از API Aspose.Slides امتحان کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توان یک خصوصیت پیش‌فرض را از یک ارائه حذف کرد؟**

خصوصیات پیش‌فرض جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورتی که خصوصیت اجازهٔ خالی بودن را بدهد، مقدار آن را خالی کنید.

**اگر یک خصوصیت سفارشی که از قبل وجود دارد را اضافه کنم چه می‌شود؟**

اگر یک خصوصیت سفارشی که از قبل وجود دارد را اضافه کنید، مقدار قبلی آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی خصوصیت نیست، زیرا Aspose.Slides به‌طور خودکار مقدار خصوصیت را به‌روزرسانی می‌کند.

**آیا می‌توان بدون بارگذاری کامل ارائه، به خصوصیات آن دسترسی داشت؟**

بله. می‌توانید با استفاده از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) و سپس [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) متادیتای ذخیره‌شدهٔ سند را بدون ایجاد نمونه‌ای از [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) بخوانید. برای یک مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به [Build a Lightweight Presentation Inventory](/slides/fa/java/examine-presentation/) مراجعه کنید.

**آیا می‌توان خصوصیات عمومی یک ارائهٔ رمزگذاری‌شده را بدون رمز عبور بازکن آن خواند؟**

بله. ارائه باید پس از فراخوانی [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) با مقدار `false` رمزگذاری شده باشد و سپس با فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) با مقدار `true` بارگذاری شود.

**آیا می‌توان یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑بارگذاری‑خصوصیات‑سند به‌روزرسانی کرد؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید سازگار بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور صحیح بازکن است.