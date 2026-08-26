---
title: محافظت از ارائه‌ها با رمز عبور در اندروید
linktitle: محافظت از رمز عبور
type: docs
weight: 20
url: /fa/androidjava/password-protected-presentation/
keywords:
- ارائه‌ای که با رمز عبور محافظت می‌شود
- رمز عبور بازکردن
- رمزگذاری پاورپوینت
- رمزگشایی پاورپوینت
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائه رمزگذاری‌شده
- حذف رمزگذاری
- پاورپوینت
- PPT
- PPTX
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "رمزگذاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX که با رمز عبور محافظت شده‌اند با Aspose.Slides برای اندروید از طریق جاوا."
---
## **نمای کلی**

یک رمز عبور بازکردن ارائه را رمزگذاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

رمز عبور بازکردن با رمز عبور محافظت‌نوشت متفاوت است. محافظت‌نوشت محدودیت‌هایی برای تغییر اعمال می‌کند اما محتوای ارائه را رمزگذاری نمی‌کند و مانع بارگذاری ارائه نمی‌شود. برای مدیریت رمزهای عبور جهت تغییر ارائه‌ها، به [محافظت‌نوشتاری ارائه‌ها](/slides/fa/androidjava/write-protected-presentation/) مراجعه کنید.

روال‌های زیر برای هر دو نوع ارائه PPT و PPTX اعمال می‌شوند. مثال‌ها از هر دو فرمت استفاده می‌کنند، جایی که رفتار مبتنی بر فایل و جریان مهم است.

## **رمزگذاری یک ارائه با رمز عبور بازکردن**

از [IProtectionManager.encrypt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) برای اختصاص یک رمز عبور بازکردن استفاده کنید. سپس از [IPresentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) برای ذخیرهٔ ارائهٔ رمزگذاری‌شده استفاده کنید.

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

## **بارگذاری یک ارائهٔ رمزگذاری‌شده**

از [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) برای تنظیم رمز عبور بازکردن استفاده کنید و هنگام بارگذاری فایل، گزینه‌ها را به [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) پاس دهید. در صورتی که رمز عبور بازکردن لازم باشد ولی رمز ارائه‌شده غایب یا نادرست باشد، بارگذاری انجام نمی‌شود.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // با ارائه‌ی رمزگشایی شده کار کنید.
} finally {
    presentation.dispose();
}
```

## **حذف رمزگذاری از یک ارائه**

ارائه را با رمز عبور بازکردن آن بارگذاری کنید، [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) را فراخوانی کنید و نتیجه را ذخیره کنید. پس از آن ارائهٔ ذخیره‌شده می‌تواند بدون رمز عبور بارگذاری شود.

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

## **اعتبارسنجی یک رمز عبور بازکردن قبل از بارگذاری**

از [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) برای دریافت [IPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/) بدون ایجاد یک نمونهٔ کامل ارائه استفاده کنید. پیش از درخواست یا اعتبارسنجی رمز عبور، [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) را بررسی کنید. وقتی حفاظت موجود باشد، مقدار ارائه‌شده را با [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) اعتبارسنجی کنید.

### **جریان کاری مسیر فایل**

مثال زیر رمز عبور بازکردن یک فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) پاس می‌دهد و سپس ارائهٔ کامل را بارگذاری می‌کند:

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

### **جریان کاری استریم**

بارگذاری متد استریم از [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) همان جریان کاری را فراهم می‌کند. قبل از بارگذاری ارائهٔ کامل از آن استریم، موقعیت یک استریم جستجوپذیر را بازنشانی کنید.

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

فقط زمانی که ارائه دارای رمز عبور بازکردن باشد و رمز ارائه‌شده صحیح باشد، [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) `true` برمی‌گرداند. در هر یک از موارد زیر `false` برمی‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور بازکردن ندارد.
- رمز عبور ارائه‌شده `null` یا خالی است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی این که آیا یک ارائه بارگذاری‌شده رمزگذاری شده است**

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
رمزهای عبور بازکردن را در لاگ‌ها ثبت نکنید و در پیام‌های تشخیصی گنجانش ندهید. از تلاش‌های مکرر و غیرضروری برای اعتبارسنجی جلوگیری کنید، رمزها را در حافظه فقط به مدت لازم نگه دارید و در صورت بارگذاری فوری ارائه، نتیجهٔ موفق اعتبارسنجی را مجدداً استفاده کنید.
{{% /alert %}}

## **محافظت از یک ارائه با رمز عبور به صورت آنلاین**

1. برنامهٔ [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
2. ارائه را انتخاب یا بارگذاری کنید.
3. رمز عبوری برای حفاظت نمایشی وارد کنید.
4. در صورت تمایل، رمز عبور جداگانه‌ای برای حفاظت از ویرایش وارد کنید.
5. حفاظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [محافظت‌نوشتاری ارائه‌ها](/slides/fa/androidjava/write-protected-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **پرسش‌های متداول**

**تفاوت رمز عبور بازکردن با رمز عبور محافظت‌نوشت چیست؟**

یک رمز عبور بازکردن ارائه را رمزگذاری می‌کند و برای بارگذاری محتوای آن لازم است. رمز عبور محافظت‌نوشت محدودیت‌هایی برای تغییر اعمال می‌کند بدون اینکه محتوای ارائه را رمزگذاری کند.

**آیا می‌توانم یک رمز عبور بازکردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را دریافت کنید، بررسی کنید آیا حفاظت با رمز عبور بازکردن وجود دارد یا نه، و قبل از ایجاد یک نمونهٔ کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا جریان‌های کاری بررسی رمز عبور برای هر دو نوع PPT و PPTX پشتیبانی می‌شوند؟**

بله. کشف و اعتبارسنجی رمز عبور بر پایه مسیر فایل و جریان برای ارائه‌های PPT و PPTX به‌طور یکسان عمل می‌کند.