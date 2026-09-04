---
title: محافظت از ارائه‌ها با رمز عبور در جاوا
linktitle: حفاظت از رمز عبور
type: docs
weight: 20
url: /fa/java/password-protected-presentation/
keywords:
- ارائه محافظت‌شده با رمز عبور
- رمز عبور بازکننده
- رمزنگاری پاورپوینت
- رمزگشایی پاورپوینت
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائهٔ رمزنگاری‌شده
- حذف رمزنگاری
- پاورپوینت
- PPT
- PPTX
- ارائه
- جاوا
- Aspose.Slides
description: "رمزنگاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX محافظت‌شده با رمز عبور در جاوا با Aspose.Slides."
---
## **بررسی کلی**

یک رمز عبور بازکننده یک ارائه را رمزنگاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه باید رمز صحیح وارد شود، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

یک رمز عبور بازکننده با رمز عبور محافظت نوشتاری متفاوت است. محافظت نوشتاری تغییرات را محدود می‌کند اما محتوا را رمزنگاری نمی‌کند و از بارگذاری ارائه جلوگیری نمی‌کند. برای مدیریت رمزهای عبور برای تغییر ارائه‌ها، به [Write-Protect Presentations](/slides/fa/java/write-protected-presentation/) مراجعه کنید.

گردش‌کارهای زیر برای هر دو ارائهٔ PPT و PPTX اعمال می‌شوند. مثال‌ها از هر دو قالب استفاده می‌کنند زمانی که رفتار مبتنی بر فایل و مبتنی بر جریان مهم است.

## **رمزنگاری یک ارائه با رمز عبور بازکننده**

از [IProtectionManager.encrypt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) برای اختصاص یک رمز عبور بازکننده استفاده کنید. سپس از [IPresentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) برای ذخیرهٔ ارائهٔ رمزنگاری‌شده استفاده کنید.

مثال زیر یک ارائهٔ PPTX را رمزنگاری می‌کند:

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

## **نگه داشتن ویژگی‌های سند به‌صورت عمومی**

به‌صورت پیش‌فرض، Aspose.Slides ویژگی‌های سند را در رمزنگاری ارائه گنجانده است. متد [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) این رفتار را بطور مستقل از رمزنگاری محتوای اسلایدها کنترل می‌کند. قبل از فراخوانی [IProtectionManager.encrypt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) مقدار `false` را ارسال کنید وقتی که یک سیستم ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز دارد متادیتا را بدون رمز عبور بازکننده بخواند.

مثال زیر یک ارائهٔ PPTX رمزنگاری‌شده ایجاد می‌کند در حالی که ویژگی‌های سند داخلی آن عمومی می‌مانند:

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

ارسال `false` به [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) اسلایدها، مسترها، طرح‌ها، شکل‌ها، رسانه‌ها یا سایر محتوای ارائه را عمومی نمی‌کند. این فقط بر ویژگی‌های سند تأثیر می‌گذارد. برای خواندن آن ویژگی‌ها بدون بارگذاری محتوای رمزنگاری‌شده، به [Manage Presentation Properties](/slides/fa/java/presentation-properties/) مراجعه کنید.

## **بارگذاری یک ارائهٔ رمزنگاری‌شده**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) را روی رمز عبور بازکننده تنظیم کنید و گزینه‌ها را هنگام بارگذاری فایل به [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) پاس دهید. اگر رمز عبور بازکننده لازم باشد اما رمز ارائه‌شده غایب یا نادرست باشد، بارگذاری با شکست مواجه می‌شود.

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

## **حذف رمزنگاری از یک ارائه**

ارائه را با رمز عبور بازکننده آن بارگذاری کنید، [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) را فراخوانی کنید و نتیجه را ذخیره کنید. ارائهٔ ذخیره‌شده سپس می‌تواند بدون رمز عبور بارگذاری شود.

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

## **اعتبارسنجی یک رمز عبور بازکننده قبل از بارگذاری**

از [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) برای به‌دست‌آوردن [IPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/) بدون ایجاد یک نمونهٔ کامل ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی یک رمز عبور، [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) را بررسی کنید. زمانی که حفاظت وجود داشته باشد، مقدار ارائه‌شده را با [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) اعتبارسنجی کنید.

### **گردش‌کار مسیر فایل**

مثال زیر یک رمز عبور بازکننده برای یک فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) می‌فرستد و سپس ارائهٔ کامل را بارگذاری می‌کند:

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

### **گردش‌کار جریان**

بارگذاری به‌صورت جریان از [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) همان گردش‌کار را فراهم می‌کند. قبل از بارگذاری ارائهٔ کامل از آن جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) فقط زمانی `true` برمی‌گرداند که ارائه دارای رمز عبور بازکننده باشد و رمز ارائه‌شده صحیح باشد. در هر یک از موارد زیر `false` برمی‌گردد:

- رمز عبور نادرست است.
- ارائه رمز عبور بازکننده ندارد.
- رمز عبور ارائه‌شده `null` یا خالی است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائهٔ بارگذاری‌شده رمزنگاری شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) را بررسی کنید تا تأیید کنید که ارائهٔ منبع رمزنگاری شده است. برای تشخیص حفاظت رمز عبور بازکننده قبل از بارگذاری، همان‌طور که در بالا نشان داده شد از `IPresentationInfo.isPasswordProtected` استفاده کنید.

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
رمزهای عبور بازکننده را در لاگ‌ها ثبت نکنید یا در پیام‌های تشخیصی قرار ندهید. از تلاش‌های تکراری غیرضروری برای اعتبارسنجی خودداری کنید، رمزها را فقط به اندازهٔ نیاز در حافظه نگه دارید و در صورت بارگذاری فوری ارائه، از نتیجهٔ اعتبارسنجی موفق استفاده مجدد کنید.

ویژگی‌های عمومی سند ممکن است نام‌نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کنند حتی اگر محتوای ارائه رمزنگاری شده باشد. متادیتای حساس را به همراه ارائه رمزنگاری کنید. گذاشتن ویژگی‌ها به‌صورت عمومی باید تصمیم صریحی باشد که فقط زمانی اتخاذ می‌شود که سیستم‌ها باید بدون رمز عبور بازکننده فایل را ایندکس، طبقه‌بندی، جستجو یا مدیریت کنند.
{{% /alert %}}

## **محافظت با رمز عبور از یک ارائه به‌صورت آنلاین**

1. برنامه Aspose.Slides Lock را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. یک رمز عبور برای محافظت از نمایش وارد کنید.
1. در صورت تمایل یک رمز عبور جداگانه برای محافظت از ویرایش وارد کنید.
1. محافظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/fa/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/fa/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سؤالات متداول**

**تفاوت بین رمز عبور بازکننده و رمز عبور محافظت نوشتاری چیست؟**

یک رمز عبور بازکننده ارائه را رمزنگاری می‌کند و برای بارگذاری محتوای آن لازم است. یک رمز عبور محافظت نوشتاری بدون رمزنگاری محتوا، تغییرات را محدود می‌کند.

**آیا می‌توانم رمز عبور بازکننده را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را به‌دست آورده، بررسی کنید آیا حفاظت رمز عبور بازکننده وجود دارد و قبل از ایجاد یک نمونهٔ کامل ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا برنامه می‌تواند متادیتا را بدون رمز عبور بازکننده بخواند؟**

بله، اما فقط زمانی که ارائه با رمزنگاری ویژگی‌های سند غیرفعال شده باشد. برنامه سپس باید از حالت بارگذاری فقط ویژگی‌های سند که در [Manage Presentation Properties](/slides/fa/java/presentation-properties/) توضیح داده شده استفاده کند.

**آیا گردش‌کارهای بررسی رمز عبور برای هر دو PPT و PPTX پشتیبانی می‌شوند؟**

بله. تشخیص و اعتبارسنجی رمز عبور بر پایه مسیر فایل و جریان برای ارائه‌های PPT و PPTX به‌صورت یکسان رفتار می‌کند.