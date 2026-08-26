---
title: محافظت از ارائه‌ها با رمز عبور در جاوا
linktitle: حفاظت با رمز عبور
type: docs
weight: 20
url: /fa/java/password-protected-presentation/
keywords:
- ارائه محافظت‌شده با رمز عبور
- رمز باز کردن
- رمزگذاری پاورپوینت
- رمزگشایی پاورپوینت
- اعتبارسنجی رمز ارائه
- بررسی رمز ارائه
- باز کردن ارائه رمزگذاری‌شده
- حذف رمزگذاری
- پاورپوینت
- PPT
- PPTX
- ارائه
- جاوا
- Aspose.Slides
description: "رمزگذاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX محافظت‌شده با رمز عبور در جاوا با Aspose.Slides."
---
## **بررسی کلی**

یک رمز باز کردن، ارائه را رمزگذاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز صحیح لازم است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

رمز باز کردن متفاوت از رمز حفاظت نوشتاری است. حفاظت نوشتاری فقط امکان تغییر را محدود می‌کند ولی محتوا را رمزگذاری نمی‌کند و ارائه را از بارگذاری منع نمی‌کند. برای مدیریت رمزها جهت ویرایش ارائه‌ها، به [Write-Protect Presentations](/slides/fa/java/write-protected-presentation/) مراجعه کنید.

جریان‌های کاری زیر برای هر دو نوع ارائه PPT و PPTX اعمال می‌شوند. مثال‌ها هر دو قالب را استفاده می‌کنند هنگامی که رفتار مبتنی بر فایل و مبتنی بر جریان اهمیت دارد.

## **رمزگذاری یک ارائه با رمز باز کردن**

از [IProtectionManager.encrypt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) برای اختصاص رمز باز کردن استفاده کنید. سپس از [IPresentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) برای ذخیرهٔ ارائهٔ رمزگذاری‌شده استفاده کنید.

مثال زیر یک ارائهٔ PPTX را رمزگذاری می‌کند:

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

## **بارگذاری یک ارائهٔ رمزگذاری‌شده**

دستور [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) را به رمز باز کردن تنظیم کنید و هنگام بارگذاری فایل این گزینه‌ها را به کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) منتقل کنید. اگر رمز باز کردن لازم باشد اما رمز ارائه‌شده وجود نداشته باشد یا نادرست باشد، بارگذاری ناموفق خواهد بود.

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

ارائه را با رمز باز کردن آن بارگذاری کنید، متد [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) را فراخوانی کنید و نتیجه را ذخیره کنید. پس از آن می‌توان ارائه ذخیره‌شده را بدون نیاز به رمز بارگذاری کرد.

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

## **اعتبارسنجی یک رمز باز کردن پیش از بارگذاری**

از [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) برای بدست آوردن [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/) بدون ایجاد یک نمونهٔ کامل از ارائه استفاده کنید. پیش از درخواست یا اعتبارسنجی رمز، متد [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) را بررسی کنید. زمانی که محافظت وجود دارد، مقدار ارائه‌شده را با متد [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) اعتبارسنجی کنید.

### **جریان کاری مسیر فایل**

مثال زیر یک رمز باز کردن برای یک فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) می‌گذارد و سپس ارائهٔ کامل را بارگذاری می‌کند:

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

نسخهٔ جریان‌دار [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) همان جریان کاری را فراهم می‌کند. قبل از بارگذاری ارائهٔ کامل از آن جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

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

### **مقادیر بازگشتی checkPassword**

متد [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) فقط زمانی که ارائه دارای رمز باز کردن باشد و رمز ارائه‌شده صحیح باشد، `true` برمی‌گرداند. در هر یک از موارد زیر `false` برمی‌گرداند:

- رمز نادرست است.
- ارائه دارای رمز باز کردن نیست.
- رمز ارائه‌شده `null` یا خالی است.

این رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزگذاری شده است**

پس از بارگذاری یک ارائه با رمز صحیح، متد [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) را بررسی کنید تا تأیید کنید که ارائهٔ منبع رمزگذاری شده است. برای شناسایی محافظت با رمز باز کردن پیش از بارگذاری، همان‌طور که در بالا نشان داده شد، از `IPresentationInfo.isPasswordProtected` استفاده کنید.

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

## **پیشنهادات امنیتی**

{{% alert color="warning" title="Security" %}}
رمزهای باز کردن را در لاگ‌ها ثبت نکنید و در پیام‌های تشخیصی گنجانده نشوند. از تلاش‌های مکرر و غیرضروری برای اعتبارسنجی خودداری کنید، رمزها را در حافظه تنها به مدت لازم نگه دارید و در زمان بارگذاری فوری ارائه، نتیجهٔ اعتبارسنجی موفق را باز استفاده کنید.
{{% /alert %}}

## **رمزگذاری یک ارائه به صورت آنلاین**

1. برنامهٔ [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. رمز برای حفاظت از نمایش را وارد کنید.
1. در صورت نیاز، رمز جداگانه‌ای برای حفاظت از ویرایش وارد کنید.
1. حفاظت را اعمال کنید و فایل حاصل را بارگیری کنید.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/fa/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/fa/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **پرسش‌های متداول**

**تفاوت رمز باز کردن با رمز حفاظت نوشتاری چیست؟**

یک رمز باز کردن ارائه را رمزگذاری می‌کند و برای بارگذاری محتوا لازم است. یک رمز حفاظت نوشتاری فقط امکان ویرایش را محدود می‌کند بدون اینکه محتوا را رمزگذاری کند.

**آیا می‌توان رمز باز کردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کرد؟**

بله. اطلاعات ارائه را به دست آورید، بررسی کنید آیا محافظت با رمز باز کردن وجود دارد یا نه، و قبل از ایجاد یک نمونهٔ کامل از ارائه، رمز را اعتبارسنجی کنید.

**آیا جریان‌های کاری بررسی رمز برای هر دو قالب PPT و PPTX پشتیبانی می‌شوند؟**

بله. شناسایی و اعتبارسنجی رمز مبتنی بر مسیر فایل و جریان برای ارائه‌های PPT و PPTX به همان شکل عمل می‌کند.