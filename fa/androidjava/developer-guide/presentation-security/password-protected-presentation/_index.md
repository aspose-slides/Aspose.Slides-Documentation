---
title: "محافظت از ارائه‌ها با رمز عبور در اندروید"
linktitle: "حفاظت با رمز عبور"
type: docs
weight: 20
url: /fa/androidjava/password-protected-presentation/
keywords:
- "ارائهٔ محافظت‌شده با رمز عبور"
- "رمز عبور بازکردن"
- "رمزگذاری پاورپوینت"
- "رمزگشایی پاورپوینت"
- "اعتبارسنجی رمز عبور ارائه"
- "بررسی رمز عبور ارائه"
- "باز کردن ارائه رمزگذاری‌شده"
- "حذف رمزگذاری"
- "پاورپوینت"
- PPT
- PPTX
- "ارائه"
- "اندروید"
- "جاوا"
- "Aspose.Slides"
description: "رمزگذاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX که با رمز عبور محافظت شده‌اند با Aspose.Slides برای اندروید از طریق جاوا."
---
## **نمای کلی**

یک رمز عبور بازکردن یک ارائه را رمزگذاری می‌کند. برای بارگیری و مشاهده محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این محافظت محرمانگی را فراهم می‌کند.

یک رمز عبور بازکردن با رمز عبور حفاظت نوشتن متفاوت است. حفاظت نوشتن تغییرات را محدود می‌کند اما محتوا را رمزگذاری نمی‌کند و یا از بارگذاری ارائه جلوگیری نمی‌کند. برای مدیریت رمزهای عبور برای ویرایش ارائه‌ها، به [محافظت نوشتن ارائه‌ها](/slides/fa/androidjava/write-protected-presentation/) مراجعه کنید.

جریان‌های کاری زیر برای هر دو نوع ارائه PPT و PPTX اعمال می‌شوند. نمونه‌ها از هر دو قالب استفاده می‌کنند که رفتار مبتنی بر فایل و مبتنی بر جریان برای آن‌ها مهم است.

## **رمزگذاری یک ارائه با رمز عبور بازکردن**

از [IProtectionManager.encrypt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) برای اختصاص یک رمز عبور بازکردن استفاده کنید. سپس از [IPresentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) برای ذخیره ارائه رمزگذاری شده استفاده کنید.

مثال زیر یک ارائه PPTX را رمزگذاری می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ عمومی بودن ویژگی‌های سند**

به طور پیش‌فرض، Aspose.Slides ویژگی‌های سند را در رمزگذاری ارائه گنجانده است. متد [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) این رفتار را به طور مستقل از رمزگذاری محتوای اسلاید کنترل می‌کند. هنگامیکه یک سیستم فهرست‌گذاری، طبقه‌بندی، جستجو یا مدیریت اسناد نیاز دارد متادیتا را بدون رمز عبور بازکردن بخواند، قبل از فراخوانی [IProtectionManager.encrypt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) مقدار `false` را پاس دهید.

مثال زیر یک ارائه PPTX رمزگذاری شده را ایجاد می‌کند در حالی که ویژگی‌های سند داخلی آن عمومی می‌مانند:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ارسال `false` به [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) اسلایدها، مسترها، طرح‌بندی‌ها، اشکال، رسانه‌ها یا سایر محتوای ارائه را عمومی نمی‌کند. این فقط بر ویژگی‌های سند تأثیر می‌گذارد. برای خواندن این ویژگی‌ها بدون بارگذاری محتوای رمزگذاری شده، به [مدیریت ویژگی‌های ارائه](/slides/fa/androidjava/presentation-properties/) مراجعه کنید.

## **بارگذاری یک ارائه رمزگذاری شده**

مقدار [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) را به رمز عبور بازکردن تنظیم کنید و هنگام بارگذاری فایل این گزینه‌ها را به [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) پاس دهید. بارگذاری در صورتی که رمز عبور بازکردن مورد نیاز باشد ولی رمز ارائه‌شده موجود نباشد یا نادرست باشد، شکست می‌خورد.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // کار با ارائهٔ رمزگشایی‌شده.
} finally {
    presentation.dispose();
}
```

## **حذف رمزگذاری از یک ارائه**

ارائه را با رمز عبور بازکردن آن بارگذاری کنید، متد [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) را فراخوانی کنید و نتیجه را ذخیره کنید. سپس می‌توان ارائه ذخیره‌شده را بدون رمز عبور بارگذاری کرد.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **اعتبارسنجی رمز عبور بازکردن قبل از بارگذاری**

از [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) برای دریافت [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/) بدون ایجاد یک نمونه کامل ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی یک رمز عبور، [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) را بررسی کنید. هنگامی که حفاظت وجود دارد، مقدار ارائه‌شده را با [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) اعتبارسنجی کنید.

### **جریان کاری مسیر فایل**

مثال زیر یک رمز عبور بازکردن برای فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) پاس می‌دهد و سپس ارائه کامل را بارگذاری می‌کند:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **جریان کاری جریان**

نسخه‌ی جریان‌دار [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) همان جریان کاری را فراهم می‌کند. قبل از بارگذاری ارائه کامل از آن جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

مثال زیر از یک فایل PPT استفاده می‌کند:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **مقدارهای برگشتی checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) فقط زمانی که ارائه یک رمز عبور بازکردن داشته باشد و رمز ارائه‌شده صحیح باشد `true` برمی‌گرداند. در هر یک از موارد زیر `false` برمی‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور بازکردن ندارد.
- رمز ارائه‌شده `null` یا خالی است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزگذاری شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) را بررسی کنید تا تأیید شود که ارائه منبع رمزگذاری شده است. برای شناسایی حفاظت با رمز عبور بازکردن قبل از بارگذاری، همان‌طور که در بالا نشان داده شد، از `IPresentationInfo.isPasswordProtected` استفاده کنید.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **توصیه‌های امنیتی**

{{% alert color="warning" title="Security" %}}
رمزهای عبور بازکردن را در لاگ‌ها ثبت نکنید و در پیام‌های تشخیصی گنجانده نکنید. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی اجتناب کنید، رمزها را در حافظه تنها به مدت زمان نیاز نگه دارید و نتیجه‌ی اعتبارسنجی موفق را هنگام بارگذاری فوری ارائه مجدداً استفاده کنید.

ویژگی‌های عمومی سند ممکن است نام نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را حتی اگر محتوای ارائه رمزگذاری شده باشد، فاش کنند. متادیتای حساس را همراه با ارائه رمزگذاری کنید. عمومی نگه داشتن ویژگی‌ها باید تصمیم صریحی باشد که فقط در زمانی اتخاذ می‌شود که سیستم‌ها برای فهرست‌گذاری، طبقه‌بندی، جستجو یا مدیریت فایل بدون رمز عبور بازکردن نیاز داشته باشند.
{{% /alert %}}

## **حفاظت از یک ارائه با رمز عبور به‌صورت آنلاین**

1. برنامه [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. رمز عبوری برای حفاظت از نمایش وارد کنید.
1. در صورت لزوم رمز عبور جداگانه‌ای برای حفاظت از ویرایش وارد کنید.
1. حفاظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [محافظت نوشتن ارائه‌ها](/slides/fa/androidjava/write-protected-presentation/)
- [امضا دیجیتال در پاورپوینت](/slides/fa/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **پرسش‌های متداول**

**تفاوت رمز عبور بازکردن با رمز عبور حفاظت نوشتن چیست؟**

یک رمز عبور بازکردن ارائه را رمزگذاری می‌کند و برای بارگذاری محتوای آن لازم است. یک رمز عبور حفاظت نوشتن تغییرات را محدود می‌کند بدون اینکه محتوا را رمزگذاری کند.

**آیا می‌توانم یک رمز عبور بازکردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را دریافت کنید، بررسی کنید آیا حفاظت با رمز عبور بازکردن وجود دارد یا خیر، و قبل از ایجاد یک نمونه کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا یک برنامه می‌تواند متادیتا را بدون رمز عبور بازکردن بخواند؟**

بله، اما فقط زمانی که ارائه با غیرفعال کردن رمزگذاری ویژگی‌های سند رمزگذاری شده باشد. در این صورت برنامه باید از حالت بارگذاری فقط ویژگی‌های سند استفاده کند که در [مدیریت ویژگی‌های ارائه](/slides/fa/androidjava/presentation-properties/) توضیح داده شده است.

**آیا جریان‌های کاری بررسی رمز عبور برای هر دو PPT و PPTX پشتیبانی می‌شود؟**

بله. شناسایی و اعتبارسنجی رمز عبور بر پایه مسیر فایل و بر پایه جریان برای هر دو ارائه PPT و PPTX به همان شکل رفتار می‌کند.