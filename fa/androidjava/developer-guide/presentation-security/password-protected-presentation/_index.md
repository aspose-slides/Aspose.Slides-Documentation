---
title: ارائه‌های امن با رمز عبور در اندروید
linktitle: محافظت با رمز عبور
type: docs
weight: 20
url: /fa/androidjava/password-protected-presentation/
keywords:
- قفل کردن PowerPoint
- قفل کردن ارائه
- باز کردن قفل PowerPoint
- باز کردن قفل ارائه
- محافظت از PowerPoint
- محافظت از ارائه
- تنظیم رمز عبور
- افزودن رمز عبور
- رمزنگاری PowerPoint
- رمزنگاری ارائه
- رمزگشایی PowerPoint
- رمزگشایی ارائه
- حفاظت نوشتن
- امنیت PowerPoint
- امنیت ارائه
- حذف رمز عبور
- حذف حفاظت
- حذف رمزنگاری
- غیرفعال‌سازی رمز عبور
- غیرفعال‌سازی حفاظت
- حذف حفاظت نوشتن
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint و OpenDocument محافظت‌شده با رمز عبور را با Aspose.Slides برای اندروید از طریق Java قفل یا باز کنید. ارائه‌های خود را امن کنید."
---
## **مقدمه**

هنگامی که یک ارائه را با رمز عبور محافظت می‌کنید، به این معنی است که رمز عبوری تنظیم می‌کنید که محدودیت‌های خاصی را بر ارائه اعمال می‌کند. برای حذف محدودیت‌ها، باید رمز عبور را وارد کنید. یک ارائهٔ محافظت‌شده با رمز عبور به عنوان یک ارائهٔ قفل‌شده در نظر گرفته می‌شود.

به طور معمول، می‌توانید یک رمز عبور تنظیم کنید تا این محدودیت‌ها را بر یک ارائه اعمال کنید:

- **تغییر**

  اگر می‌خواهید فقط برخی کاربران بتوانند ارائهٔ شما را ویرایش کنند، می‌توانید یک محدودیت ویرایش تنظیم کنید. این محدودیت مانع مردم از ویرایش، تغییر یا کپی کردن موارد در ارائهٔ شما می‌شود (مگر اینکه رمز عبور را ارائه دهند).

  با این حال، در این حالت حتی بدون وارد کردن رمز عبور، کاربر می‌تواند به سند شما دسترسی پیدا کرده و آن را باز کند. در این حالت فقط‑خواندنی، کاربر می‌تواند محتوا یا موارد —پیوندها، انیمیشن‌ها، افکت‌ها و سایر موارد— داخل ارائهٔ شما را ببیند، اما نمی‌تواند موارد را کپی کند یا ارائه را ذخیره کند.

- **بازکردن**

  اگر می‌خواهید فقط برخی کاربران بتوانند ارائهٔ شما را باز کنند، می‌توانید یک محدودیت بازکردن تنظیم کنید. این محدودیت مانع افراد از حتی مشاهده محتویات ارائهٔ شما می‌شود (مگر اینکه رمز عبور را ارائه دهند).

  از نظر فنی، محدودیت بازکردن همچنین از ویرایش ارائه‌ها توسط کاربران جلوگیری می‌کند: هنگامی که افراد نمی‌توانند یک ارائه را باز کنند، نمی‌توانند آن را ویرایش یا تغییر دهند.

  **توجه** داشته باشید که وقتی یک ارائه را با رمز عبور برای جلوگیری از باز کردن محافظت می‌کنید، فایل ارائه رمزنگاری می‌شود.

## **محافظت با رمز عبور برای ارائه‌ها در Aspose.Slides**
**قالب‌های پشتیبانی‌شده**

Aspose.Slides حفاظت با رمز عبور، رمزگذاری و عملیات مشابه را برای ارائه‌ها در قالب‌های زیر پشتیبانی می‌کند:

- PPTX و PPT - ارائهٔ Microsoft PowerPoint
- ODP - ارائهٔ OpenDocument
- OTP - قالب ارائهٔ OpenDocument

**عملیات پشتیبانی‌شده**

Aspose.Slides به شما امکان می‌دهد از حفاظت با رمز عبور بر روی ارائه‌ها برای جلوگیری از تغییرات به روش‌های زیر استفاده کنید:

- رمزنگاری یک ارائه
- تنظیم حفاظت نوشتن برای یک ارائه

**عملیات دیگر**

Aspose.Slides به شما اجازه می‌دهد وظایف دیگری که شامل حفاظت با رمز عبور و رمزگذاری هستند را به روش‌های زیر انجام دهید:

- رمزگشایی یک ارائه؛ باز کردن یک ارائهٔ رمزنگاری‌شده
- حذف رمزگذاری؛ غیرفعال‌سازی حفاظت با رمز عبور
- حذف حفاظت نوشتن از یک ارائه
- دریافت ویژگی‌های یک ارائهٔ رمزنگاری‌شده
- بررسی اینکه آیا یک ارائه رمزنگاری شده است
- بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است.

## **رمزنگاری یک ارائه**

می‌توانید یک ارائه را با تنظیم یک رمز عبور رمزنگاری کنید. سپس برای ویرایش ارائهٔ قفل‌شده، کاربر باید رمز عبور را وارد کند.

برای رمزنگاری یا حفاظت با رمز عبور یک ارائه، باید از متد encrypt (از [IProtectionManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager)) برای تنظیم رمز عبور برای ارائه استفاده کنید. رمز عبور را به متد encrypt می‌گیرید و از متد save برای ذخیرهٔ ارائهٔ اکنون رمزنگاری‌شده استفاده می‌کنید.

این کد نمونه نحوهٔ رمزنگاری یک ارائه را نشان می‌دهد:

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

می‌توانید علامتی با متن «تغییر نکنید» به یک ارائه اضافه کنید. به این ترتیب می‌توانید به کاربران بگویید که نمی‌خواهید آنها تغییراتی در ارائه ایجاد کنند.

**توجه** داشته باشید که فرآیند حفاظت نوشتن ارائه را رمزنگاری نمی‌کند. بنابراین کاربران—اگر واقعاً بخواهند—می‌توانند ارائه را ویرایش کنند، اما برای ذخیرهٔ تغییرات باید ارائه‌ای با نام متفاوت ایجاد کنند.

برای تنظیم حفاظت نوشتن، باید از متد [setWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) استفاده کنید. این کد نمونه نشان می‌دهد که چگونه حفاظت نوشتن را برای یک ارائه تنظیم کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بارگذاری یک ارائهٔ رمزنگاری‌شده**

Aspose.Slides به شما اجازه می‌دهد فایلی رمزنگاری‌شده را با وارد کردن رمز عبور آن بارگذاری کنید. برای رمزگشایی یک ارائه، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) را بدون پارامتر صدا بزنید. سپس باید رمز عبور صحیح را وارد کنید تا ارائه بارگذاری شود.

این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگشایی کنید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // کار با ارائهٔ رمزگشایی‌شده
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **حذف رمزگذاری از یک ارائه**

می‌توانید رمزگذاری یا حفاظت با رمز عبور یک ارائه را حذف کنید. به این ترتیب کاربران می‌توانند بدون محدودیت به ارائه دسترسی داشته یا آن را ویرایش کنند.

برای حذف رمزگذاری یا حفاظت با رمز عبور، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) را فراخوانی کنید. این کد نمونه نحوهٔ حذف رمزگذاری از یک ارائه را نشان می‌دهد:

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

می‌توانید با Aspose.Slides حفاظت نوشتن اعمال‌شده بر روی یک فایل ارائه را حذف کنید. به این ترتیب، کاربران می‌توانند همان‌طور که می‌خواهند ویرایش کنند—و هنگام انجام این کار هیچ هشداری دریافت نمی‌کنند.

می‌توانید حفاظت نوشتن را از یک ارائه با استفاده از متد [removeWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) حذف کنید. این کد نمونه نشان می‌دهد که چگونه حفاظت نوشتن را از یک ارائه حذف کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **دریافت ویژگی‌های یک ارائهٔ رمزنگاری‌شده**

به طور معمول، کاربران برای دریافت ویژگی‌های سند یک ارائهٔ رمزنگاری‌شده یا محافظت‌شده با رمز عبور مشکل دارند. با این حال، Aspose.Slides مکانیزمی ارائه می‌دهد که به شما امکان می‌دهد یک ارائه را با رمز عبور محافظت کنید در حالی که همچنان کاربران می‌توانند به ویژگی‌های آن دسترسی داشته باشند.

**توجه:** به طور پیش‌فرض، وقتی Aspose.Slides یک ارائه را رمزنگاری می‌کند، ویژگی‌های سند ارائه نیز با رمز عبور محافظت می‌شوند. اگر نیاز دارید که ویژگی‌های سند حتی پس از رمزگذاری در دسترس باشند، Aspose.Slides این امکان را به شما می‌دهد.

اگر می‌خواهید کاربران همچنان توانایی دسترسی به ویژگی‌های یک ارائهٔ رمزنگاری‌شده را داشته باشند، مقدار `false` را به [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) پاس دهید. این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزنگاری کنید در حالی که همچنان دسترسی کاربران به ویژگی‌های سند آن فراهم است:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بارگذاری فقط ویژگی‌های سند از یک ارائهٔ رمزنگاری‌شده**

برای بررسی متادیتای یک ارائهٔ رمزنگاری‌شده بدون بارگذاری اسلایدها یا سایر محتویات آن، یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/) ایجاد کنید و مقدار `true` را به [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) پاس دهید. در این حالت، Aspose.Slides رمز عبور را نادیده می‌گیرد و فقط ویژگی‌های سندی که به‌صورت عمومی در دسترس هستند را بارگذاری می‌کند.

کد زیر ویژگی‌های سند داخلی و سفارشی را از طریق [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) می‌خواند:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // خواندن ویژگی‌های سند داخلی.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // خواندن ویژگی‌های سند سفارشی.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

این جریان کار تنها زمانی کار می‌کند که ویژگی‌های سند هنگام رمزگذاری ارائه به صورت نا رمزگذاری‌شده (عمومی) باقی مانده باشند. اگر ویژگی‌های سند رمزگذاری شده باشند، پاس دادن مقدار `true` به `loadOptions.setOnlyLoadDocumentProperties` منجر به رخداد استثنا می‌شود زیرا در این حالت رمز عبور نادیده گرفته می‌شود. برای دسترسی به ویژگی‌های سند رمزگذاری‌شده یا بارگذاری کامل ارائه، شامل اسلایدها و سایر محتویات, رمز عبور صحیح را از طریق [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) فراهم کنید.

## **بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است**

قبل از بارگذاری یک ارائه، ممکن است بخواهید بررسی و تأیید کنید که ارائه با رمز عبور محافظت نشده است. به این ترتیب می‌توانید از خطاها و مشکلات مشابهی که هنگام بارگذاری یک ارائهٔ محافظت‌شده با رمز عبور بدون داشتن رمز عبور رخ می‌دهد، جلوگیری کنید.

این کد Java نشان می‌دهد چگونه یک ارائه را بررسی کنید تا ببینید آیا با رمز عبور محافظت شده است (بدون بارگذاری خود ارائه):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **بررسی اینکه آیا یک ارائه رمزنگاری شده است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه رمزنگاری شده است یا نه. برای انجام این کار می‌توانید از ویژگی [isEncrypted](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) استفاده کنید که اگر ارائه رمزنگاری شود `true` و در غیر این صورت `false` برمی‌گرداند.

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه رمزنگاری شده است:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بررسی اینکه آیا یک ارائه حفاظت نوشتن دارد**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه حفاظت نوشتن دارد یا خیر. برای انجام این کار می‌توانید از ویژگی [isWriteProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) استفاده کنید که اگر ارائه حفاظت نوشتن داشته باشد `true` و در غیر این صورت `false` برمی‌گرداند.

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

ممکن است بخواهید بررسی و تأیید کنید که رمز عبور خاصی برای محافظت از سند یک ارائه استفاده شده است. Aspose.Slides ابزاری را برای اعتبارسنجی رمز عبور در اختیار شما قرار می‌دهد.

این کد نمونه نشان می‌دهد چگونه یک رمز عبور را اعتبارسنجی کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // بررسی کنید که آیا "pass" مطابقت دارد
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

اگر ارائه با رمز عبور مشخص رمزنگاری شده باشد `true` برمی‌گرداند. در غیر این صورت `false` برمی‌گرداند.

{{% alert color="primary" title="همچنین ببینید" %}} 
- [امضای دیجیتال در PowerPoint](/slides/fa/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**کدام روش‌های رمزگذاری توسط Aspose.Slides پشتیبانی می‌شوند؟**  
Aspose.Slides روش‌های رمزگذاری مدرن، از جمله الگوریتم‌های مبتنی بر AES را پشتیبانی می‌کند و سطح بالایی از امنیت داده‌ها را برای ارائه‌های شما فراهم می‌سازد.

**در صورتی که رمز عبور نادرست هنگام تلاش برای باز کردن یک ارائه وارد شود، چه اتفاقی می‌افتد؟**  
اگر رمز عبور نادرست استفاده شود، یک استثنا پرتاب می‌شود که به شما اطلاع می‌دهد دسترسی به ارائه رد شده است. این باعث جلوگیری از دسترسی غیرمجاز و محافظت از محتوای ارائه می‌شود.

**آیا کار با ارائه‌های محافظت‌شده با رمز عبور تأثیرات عملکردی دارد؟**  
فرآیند رمزگذاری و رمزگشایی ممکن است بار کمی را در طول عملیات باز کردن و ذخیره‌سازی ایجاد کند. در اکثر موارد، این تأثیر عملکردی حداقل است و به طور قابل توجهی زمان کلی پردازش وظایف ارائه شما را تحت تأثیر قرار نمی‌دهد.