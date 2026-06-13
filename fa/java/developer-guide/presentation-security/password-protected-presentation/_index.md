---
title: محافظت از ارائه‌ها با رمز عبور در جاوا
linktitle: حفاظت با رمز عبور
type: docs
weight: 20
url: /fa/java/password-protected-presentation/
keywords:
- قفل کردن PowerPoint
- قفل کردن ارائه
- باز کردن قفل PowerPoint
- باز کردن قفل ارائه
- محافظت از PowerPoint
- محافظت از ارائه
- تنظیم رمز عبور
- اضافه کردن رمز عبور
- رمزگذاری PowerPoint
- رمزگذاری ارائه
- رمزگشایی PowerPoint
- رمزگشایی ارائه
- حفاظت نوشتن
- امنیت PowerPoint
- امنیت ارائه
- حذف رمز عبور
- حذف حفاظت
- حذف رمزگذاری
- غیرفعال کردن رمز عبور
- غیرفعال کردن حفاظت
- حذف حفاظت نوشتن
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "بیاموزید چگونه به راحتی ارائه‌های PowerPoint و OpenDocument محافظت‌شده با رمز عبور را با Aspose.Slides برای جاوا قفل و بازقفل کنید. ارائه‌های خود را ایمن کنید."
---
## **مقدمه**

وقتی یک ارائه را با رمز عبور محافظت می‌کنید، به این معناست که رمز عبوری تنظیم می‌کنید که محدودیت‌های خاصی را بر ارائه اعمال می‌کند. برای حذف این محدودیت‌ها، باید رمز عبور وارد شود. یک ارائهٔ محافظت‌شده با رمز عبور به عنوان یک ارائهٔ قفل‌شده در نظر گرفته می‌شود.

به طور معمول می‌توانید برای اعمال این محدودیت‌ها بر یک ارائه، رمز عبوری تنظیم کنید:

- **تغییرات**

اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه شما را تغییر دهند، می‌توانید محدودیت تغییر را تنظیم کنید. این محدودیت مانع از تغییر، اصلاح یا کپی کردن عناصر در ارائه شما می‌شود مگر آنکه رمز عبور را ارائه دهند.

با این حال، حتی بدون رمز عبور، کاربر همچنان می‌تواند به سند شما دسترسی پیدا کرده و آن را باز کند. در این حالت فقط‑خواندنی، کاربر می‌تواند محتوای ارائه را مشاهده کند—including hyperlinks, animations, effects, and other elements—اما نمی‌تواند موارد را کپی کند یا ارائه را ذخیره نماید.

- **بازکردن**

اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه شما را باز کنند، می‌توانید محدودیت بازکردن را تنظیم کنید. این محدودیت مانع از حتی مشاهده محتوای ارائه می‌شود مگر این که رمز عبور را ارائه دهند.

از نظر فنی، محدودیت بازکردن همچنین مانع کاربران از تغییر ارائه‌های شما می‌شود—اگر افراد نتوانند ارائه‌ای را باز کنند، نمی‌توانند آن را تغییر دهند یا اصلاح کنند.

**توجه:** وقتی یک ارائه را برای جلوگیری از بازکردن با رمز عبور محافظت می‌کنید، فایل ارائه رمزگذاری می‌شود.

## **حفاظت با رمز عبور در Aspose.Slides**
**قالب‌های پشتیبانی‌شده**

Aspose.Slides قالب‌های زیر را برای حفاظت با رمز عبور، رمزگذاری و عملیات مشابه پشتیبانی می‌کند:

- PPTX و PPT - ارائه Microsoft PowerPoint  
- ODP - ارائه OpenDocument  
- OTP - قالب ارائه OpenDocument  

**عملیات‌های پشتیبانی‌شده**

Aspose.Slides به شما امکان می‌دهد با استفاده از حفاظت با رمز عبور، از تغییرات ارائه‌ها به روش‌های زیر جلوگیری کنید:

- رمزگذاری یک ارائه  
- تنظیم حفاظت نوشتن برای یک ارائه  

**سایر عملیات**

Aspose.Slides به شما اجازه می‌دهد کارهای دیگری مرتبط با حفاظت با رمز عبور و رمزگذاری را به روش‌های زیر انجام دهید:

- رمزگشایی یک ارائه؛ باز کردن یک ارائهٔ رمزگذاری‌شده  
- حذف رمزگذاری؛ غیرفعال کردن حفاظت با رمز عبور  
- حذف حفاظت نوشتن از یک ارائه  
- دریافت ویژگی‌های یک ارائهٔ رمزگذاری‌شده  
- بررسی اینکه آیا یک ارائه رمزگذاری شده است یا خیر  
- بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است یا خیر.  

## **محافظت از یک ارائه با رمز عبور**

می‌توانید با تنظیم یک رمز عبور، یک ارائه را رمزگذاری کنید. سپس برای تغییر ارائهٔ قفل‌شده، کاربر باید رمز عبور را ارائه دهد.

برای رمزگذاری یا محافظت با رمز عبور یک ارائه، باید از متد encrypt (از [IProtectionManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager)) برای تنظیم رمز عبور استفاده کنید. رمز عبور را به متد encrypt می‌دهید و با استفاده از متد save ارائهٔ حالا رمزگذاری‌شده را ذخیره می‌ کنید.

این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگذاری کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تنظیم حفاظت نوشتن برای یک ارائه**

می‌توانید علامتی با متن «Do not modify» به یک ارائه اضافه کنید. به این ترتیب به کاربران می‌گویید که نمی‌خواهید آنها تغییراتی در ارائه ایجاد کنند.

**توجه** که فرآیند حفاظت نوشتن، ارائه را رمزگذاری نمی‌کند. بنابراین کاربران—اگر بخواهند—می‌توانند ارائه را تغییر دهند، اما برای ذخیره تغییرات باید یک ارائه با نام متفاوت ایجاد کنند.

برای تنظیم حفاظت نوشتن، باید از متد [setWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) استفاده کنید. این کد نمونه نشان می‌دهد چگونه یک حفاظت نوشتن برای یک ارائه تنظیم کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بارگذاری یک ارائهٔ رمزگذاری‌شده**

Aspose.Slides به شما امکان می‌دهد فایل رمزگذاری‌شده را با عبور دادن رمز عبور آن بارگذاری کنید. برای رمزگشایی یک ارائه، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#removeEncryption--) را بدون پارامتر صدا بزنید. سپس باید رمز عبور صحیح را وارد کنید تا ارائه بارگذاری شود.

این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگشایی کنید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // کار با ارائه رمزگشایی‌شده
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **حذف رمزگذاری از یک ارائه**

می‌توانید رمزگذاری یا حفاظت با رمز عبور یک ارائه را حذف کنید. به این ترتیب کاربران می‌توانند بدون محدودیت به ارائه دسترسی پیدا کنند یا آن را تغییر دهند.

برای حذف رمزگذاری یا حفاظت با رمز عبور، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#removeEncryption--) را صدا بزنید. این کد نمونه نشان می‌دهد چگونه رمزگذاری را از یک ارائه حذف کنید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **حذف حفاظت نوشتن از یک ارائه**

می‌توانید با استفاده از Aspose.Slides، حفاظت نوشتن استفاده شده بر روی یک فایل ارائه را حذف کنید. به این ترتیب کاربران می‌توانند به دلخواه اصلاحات کنند—و هنگام انجام این کار هیچ هشدار یا اخطاری دریافت نمی‌کنند.

برای حذف حفاظت نوشتن از یک ارائه، می‌توانید از متد [removeWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) استفاده کنید. این کد نمونه نشان می‌دهد چگونه حفاظت نوشتن را از یک ارائه حذف کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **دریافت ویژگی‌های یک ارائهٔ رمزگذاری‌شده**

به طور معمول کاربران برای دریافت ویژگی‌های سند یک ارائهٔ رمزگذاری‌شده یا با رمز عبور محافظت‌شده مشکل دارند. با این حال، Aspose.Slides یک مکانیزم فراهم می‌کند که به شما امکان می‌دهد ارائه را با رمز عبور محافظت کنید در حالی که همچنان کاربران می‌توانند به ویژگی‌های آن دسترسی داشته باشند.

**توجه** که وقتی Aspose.Slides یک ارائه را رمزگذاری می‌کند، ویژگی‌های سند ارائه به‌صورت پیش‌فرض نیز با رمز عبور محافظت می‌شوند. اما اگر نیاز دارید ویژگی‌های ارائه حتی پس از رمزگذاری در دسترس باشند، Aspose.Slides این امکان را فراهم می‌کند.

اگر می‌خواهید کاربران همچنان بتوانند به ویژگی‌های یک ارائهٔ رمزگذاری‌شده دسترسی داشته باشند، می‌توانید خاصیت [encryptDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) را روی `true` تنظیم کنید. این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگذاری کنید در حالی که امکان دسترسی کاربران به ویژگی‌های سند آن فراهم می‌شود:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است**

قبل از بارگذاری یک ارائه، ممکن است بخواهید تأیید کنید که ارائه با رمز عبور محافظت نشده است. به این ترتیب می‌توانید از خطاها و مشکلات مشابهی که هنگام بارگذاری یک ارائهٔ محافظت‌شده بدون داشتن رمز عبور رخ می‌دهد، جلوگیری کنید.

این کد Java نشان می‌دهد چگونه یک ارائه را بررسی کنید تا ببینید آیا با رمز عبور محافظت شده است (بدون بارگذاری خود ارائه):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **بررسی اینکه آیا یک ارائه رمزگذاری شده است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه رمزگذاری شده است یا نه. برای انجام این کار، می‌توانید از خاصیت [isEncrypted](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#isEncrypted--) استفاده کنید که مقدار `true` را برمی‌گرداند اگر ارائه رمزگذاری شده باشد و `false` اگر نه.

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه رمزگذاری شده است:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بررسی اینکه آیا یک ارائه حفاظت نوشتن دارد**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه حفاظت نوشتن دارد یا نه. برای انجام این کار، می‌توانید از خاصیت [isWriteProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#isWriteProtected--) استفاده کنید که مقدار `true` را برمی‌گرداند اگر ارائه محافظت نوشتن داشته باشد و `false` اگر نه.

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه حفاظت نوشتن دارد:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **اعتبارسنجی یا تأیید اینکه رمز عبور خاصی استفاده شده است**

ممکن است بخواهید بررسی کنید و تأیید کنید که یک رمز عبور خاص برای محافظت از سند ارائه استفاده شده است. Aspose.Slides ابزارهایی برای اعتبارسنجی یک رمز عبور فراهم می‌کند.

این کد نمونه نشان می‌دهد چگونه یک رمز عبور را اعتبارسنجی کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // بررسی کنید آیا "pass" مطابقت دارد
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

اگر ارائه با رمز عبور مشخص شده رمزگذاری شود، مقدار `true` برگردانده می‌شود؛ در غیر این صورت مقدار `false` برگردانده می‌شود.

{{% alert color="primary" title="همچنین ببینید" %}} 
- [Digital Signature in PowerPoint](/slides/fa/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**روش‌های رمزگذاری پشتیبانی‌شده توسط Aspose.Slides چیست؟**

Aspose.Slides از روش‌های رمزگذاری مدرن شامل الگوریتم‌های مبتنی بر AES پشتیبانی می‌کند و سطح بالایی از امنیت داده‌ها را برای ارائه‌های شما تضمین می‌نماید.

**اگر هنگام تلاش برای باز کردن یک ارائه، رمز عبور نادرستی وارد شود چه اتفاقی می‌افتد؟**

در این صورت یک استثنا ایجاد می‌شود که به شما اطلاع می‌دهد دسترسی به ارائه رد شده است. این امر از دسترسی غیرمجاز جلوگیری می‌کند و محتوای ارائه را محافظت می‌نماید.

**آیا کار با ارائه‌های محافظت‌شده با رمز عبور تأثیری بر عملکرد دارد؟**

فرآیند رمزگذاری و رمزگشایی ممکن است کمی زمان اضافی هنگام باز کردن و ذخیره‌سازی ایجاد کند. در اکثر موارد این تأثیر بر عملکرد کم است و زمان کلی پردازش وظایف ارائه شما را به‌طور قابل‌توجهی تحت تأثیر قرار نمی‌دهد.