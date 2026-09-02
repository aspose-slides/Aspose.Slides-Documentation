---
title: ارائه‌های امن با رمز عبور در جاوا
linktitle: محافظت با رمز عبور
type: docs
weight: 20
url: /fa/java/password-protected-presentation/
keywords:
- قفل PowerPoint
- قفل ارائه
- باز کردن قفل PowerPoint
- باز کردن قفل ارائه
- محافظت PowerPoint
- محافظت ارائه
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
- حذف محافظت
- حذف رمزگذاری
- غیرفعال‌سازی رمز عبور
- غیرفعال‌سازی محافظت
- حذف حفاظت نوشتن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه به سادگی ارائه‌های PowerPoint و OpenDocument محافظت‌شده با رمز عبور را قفل و بازقفل کنید با Aspose.Slides برای جاوا. ارائه‌های خود را امن کنید."
---
## **مقدمه**

زمانی که یک ارائه را با رمز عبور محافظت می‌کنید، به این معناست که رمز عبوری را تنظیم می‌کنید که محدودیت‌های خاصی بر روی ارائه اعمال می‌کند. برای حذف این محدودیت‌ها، باید رمز عبور وارد شود. ارائه‌ای که با رمز عبور محافظت شده است، به عنوان ارائه قفل‌گذاری شده در نظر گرفته می‌شود.

به‌طور معمول می‌توانید برای اعمال این محدودیت‌ها روی یک ارائه، رمز عبور تنظیم کنید:

- **Modification**

اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه شما را ویرایش کنند، می‌توانید محدودیت ویرایش را تنظیم کنید. این محدودیت از ویرایش، تغییر یا کپی‌کردن عناصر در ارائه شما جلوگیری می‌کند مگر اینکه رمز عبور ارائه شود.

با این حال، حتی بدون رمز عبور، کاربر همچنان می‌تواند سند شما را باز کند و به آن دسترسی داشته باشد. در این حالت فقط‑خواندنی، کاربر می‌تواند محتوا شامل پیوندها، انیمیشن‌ها، افکت‌ها و سایر عناصر داخل ارائه را ببینند، اما نمی‌تواند موارد را کپی یا ارائه را ذخیره کند.

- **Opening**

اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه شما را باز کنند، می‌توانید محدودیت باز کردن را تنظیم کنید. این محدودیت از مشاهده محتویات ارائه شما جلوگیری می‌کند مگر اینکه رمز عبور ارائه شود.

از نظر فنی، محدودیت باز کردن همچنین مانع کاربران از ویرایش ارائه‌های شما می‌شود—اگر افراد نتوانند ارائه را باز کنند، نمی‌توانند آن را ویرایش یا تغییر دهند.

**Note:** وقتی یک ارائه را به‌منظور جلوگیری از باز کردن با رمز عبور محافظت می‌کنید، فایل ارائه رمزگذاری می‌شود.

## **حفاظت با رمز عبور در Aspose.Slides**
**قالب‌های پشتیبانی شده**

Aspose.Slides از حفاظت با رمز عبور، رمزگذاری و عملیات مشابه برای ارائه‌ها در این قالب‌ها پشتیبانی می‌کند:

- PPTX و PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP - OpenDocument Presentation Template

**عملیات پشتیبانی شده**

Aspose.Slides به شما اجازه می‌دهد تا با استفاده از رمز عبور از تغییرات ارائه‌ها جلوگیری کنید به‌صورت‌های زیر:

- رمزگذاری یک ارائه
- تنظیم حفاظت نوشتن برای یک ارائه

**سایر عملیات**

Aspose.Slides امکان انجام کارهای دیگر مرتبط با حفاظت با رمز عبور و رمزگذاری را به‌صورت‌های زیر فراهم می‌کند:

- رمزگشایی یک ارائه؛ باز کردن یک ارائه رمزگذاری شده
- حذف رمزگذاری؛ غیرفعال سازی حفاظت با رمز عبور
- حذف حفاظت نوشتن از یک ارائه
- دریافت ویژگی‌های یک ارائه رمزگذاری شده
- بررسی اینکه آیا یک ارائه رمزگذاری شده است
- بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است.

## **محافظت از یک ارائه با رمز عبور**

می‌توانید یک ارائه را با تنظیم رمز عبور رمزگذاری کنید. سپس برای ویرایش ارائه قفل‌گذاری شده، کاربر باید رمز عبور را وارد کند.

برای رمزگذاری یا محافظت با رمز عبور یک ارائه، باید از متد encrypt (از [IProtectionManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager)) برای تنظیم رمز عبور استفاده کنید. رمز عبور را به متد encrypt می‌گذرانید و با استفاده از متد save ارائه اکنون رمزگذاری‌شده را ذخیره می‌کنید.

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

می‌توانید یک علامت «ویرایش نشود» به یک ارائه اضافه کنید. به این ترتیب به کاربران می‌گویید که نمی‌خواهید آن‌ها تغییراتی در ارائه ایجاد کنند.

**Note** فرآیند حفاظت نوشتن ارائه را رمزگذاری نمی‌کند. بنابراین، کاربران—اگر واقعاً بخواهند—می‌توانند ارائه را ویرایش کنند، اما برای ذخیره تغییرات باید ارائه‌ای با نام متفاوت ایجاد کنند.

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

## **بارگذاری یک ارائه رمزگذاری‌شده**

Aspose.Slides به شما اجازه می‌دهد یک فایل رمزگذاری‌شده را با عبور دادن رمز عبور آن بارگذاری کنید. برای رمزگشایی یک ارائه، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#removeEncryption--) را بدون پارامتر فراخوانی کنید. سپس باید رمز عبور صحیح را وارد کنید تا ارائه بارگذاری شود.

این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگشایی کنید:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // کار با ارائه رمزگشایی شده
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **حذف رمزگذاری از یک ارائه**

می‌توانید رمزگذاری یا حفاظت با رمز عبور یک ارائه را حذف کنید. به این ترتیب کاربران می‌توانند بدون محدودیت به ارائه دسترسی داشته یا آن را ویرایش کنند.

برای حذف رمزگذاری یا حفاظت با رمز عبور، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#removeEncryption--) را فراخوانی کنید. این کد نمونه نشان می‌دهد چگونه رمزگذاری یک ارائه را حذف کنید:

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

می‌توانید با استفاده از Aspose.Slides حفاظت نوشتن اعمال‌شده بر یک فایل ارائه را حذف کنید. به این ترتیب کاربران می‌توانند هرگونه تغییری که می‌خواهند انجام دهند و هنگام انجام این کار هشدار دریافت نخواهند کرد.

می‌توانید حفاظت نوشتن را با استفاده از متد [removeWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) حذف کنید. این کد نمونه نشان می‌دهد چگونه حفاظت نوشتن را از یک ارائه حذف کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **دریافت ویژگی‌های یک ارائه رمزگذاری‌شده**

به‌طور معمول کاربران برای بازیابی ویژگی‌های سند یک ارائه رمزگذاری‌شده یا با رمز عبور محافظت شده مشکل دارند. با این حال، Aspose.Slides مکانیزمی ارائه می‌دهد که به شما اجازه می‌دهد یک ارائه را با رمز عبور محافظت کنید و در عین حال توانایی دسترسی کاربران به ویژگی‌های آن را حفظ کنید.

**Note:** به‌صورت پیش‌فرض، وقتی Aspose.Slides یک ارائه را رمزگذاری می‌کند، ویژگی‌های سند ارائه نیز با رمز عبور محافظت می‌شوند. اگر نیاز دارید ویژگی‌های سند حتی پس از رمزگذاری در دسترس باشند، Aspose.Slides این امکان را به‌دقت برای شما فراهم می‌کند.

اگر می‌خواهید کاربران بتوانند ویژگی‌های یک ارائه رمزگذاری‌شده را دسترسی داشته باشند، مقدار `false` را به [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) پاس دهید. این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگذاری کنید و در عین حال به کاربران دسترسی به ویژگی‌های سند آن را بدهید:

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

## **بارگذاری فقط ویژگی‌های سند از یک ارائه رمزگذاری‌شده**

برای بررسی متادیتای یک ارائه رمزگذاری‌شده بدون بارگذاری اسلایدها یا سایر محتوا، یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) ایجاد کنید و مقدار `true` را به [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) پاس دهید. در این حالت، Aspose.Slides رمز عبور را نادیده می‌گیرد و فقط ویژگی‌های سندی که به‌صورت عمومی قابل دسترسی هستند را بارگذاری می‌کند.

کد زیر ویژگی‌های سند پیش‌ساخته و سفارشی را از طریق [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDocumentProperties--) می‌خواند:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // خواندن ویژگی‌های پیش‌ساخته سند.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // خواندن ویژگی‌های سفارشی سند.
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

این جریان کاری فقط زمانی کار می‌کند که ویژگی‌های سند هنگام رمزگذاری ارائه به‌صورت عمومی (غیر رمزگذاری‌شده) باقی مانده باشند. اگر ویژگی‌های سند رمزگذاری شوند، پاس دادن `true` به `loadOptions.setOnlyLoadDocumentProperties` باعث بروز استثنا می‌شود زیرا در این حالت رمز عبور نادیده گرفته می‌شود. برای دسترسی به ویژگی‌های سند رمزگذاری‌شده یا بارگذاری کامل ارائه شامل اسلایدها و سایر محتوا، رمز عبور صحیح را از طریق [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) فراهم کنید.

## **بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است**

قبل از بارگذاری یک ارائه، ممکن است بخواهید بررسی کنید و تأیید کنید که ارائه با رمز عبور محافظت نشده است. به این ترتیب می‌توانید از خطاها و مسائلی که هنگام بارگذاری ارائه‌ای با رمز عبور بدون وارد کردن آن رخ می‌دهد، جلوگیری کنید.

این کد Java نشان می‌دهد چگونه یک ارائه را بررسی کنید تا ببینید آیا با رمز عبور محافظت شده است (بدون بارگذاری خود ارائه):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **بررسی اینکه آیا یک ارائه رمزگذاری شده است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید که آیا یک ارائه رمزگذاری شده است یا نه. برای انجام این کار می‌توانید از ویژگی [isEncrypted](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#isEncrypted--) استفاده کنید که در صورت رمزگذاری بودن ارائه مقدار `true` و در غیر این صورت مقدار `false` برمی‌گرداند.

این کد نمونه نشان می‌دهد چگونه بررسی کنید که آیا یک ارائه رمزگذاری شده است:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بررسی اینکه آیا یک ارائه حفاظت‌نوشتن شده است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید که آیا یک ارائه حفاظت‌نوشتن شده است یا نه. برای انجام این کار می‌توانید از ویژگی [isWriteProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#isWriteProtected--) استفاده کنید که در صورت محافظت نوشتن بودن ارائه مقدار `true` و در غیر این صورت مقدار `false` برمی‌گرداند.

این کد نمونه نشان می‌دهد چگونه بررسی کنید که آیا یک ارائه حفاظت‌نوشتن شده است:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **اعتبارسنجی یا تأیید استفاده از رمز عبور خاص**

ممکن است بخواهید بررسی کنید و تأیید کنید که رمز عبور خاصی برای محافظت از یک سند ارائه استفاده شده است. Aspose.Slides ابزارهایی برای اعتبارسنجی رمز عبور فراهم می‌کند.

این کد نمونه نشان می‌دهد چگونه یک رمز عبور را اعتبارسنجی کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // بررسی می‌کند که آیا "pass" با ... مطابقت دارد
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

این مقدار `true` برمی‌گرداند اگر ارائه با رمز عبور مشخص شده رمزگذاری شده باشد. در غیر این صورت مقدار `false` برمی‌گردد.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fa/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**متدهای رمزگذاری پشتیبانی‌شده توسط Aspose.Slides کدامند؟**

Aspose.Slides از متدهای رمزگذاری مدرن، از جمله الگوریتم‌های مبتنی بر AES، پشتیبانی می‌کند تا امنیت بالایی برای ارائه‌های شما فراهم آورد.

**اگر رمز عبور نادرست هنگام تلاش برای باز کردن یک ارائه وارد شود چه اتفاقی می‌افتد؟**

در صورت استفاده از رمز عبور نادرست، یک استثنا پرتاب می‌شود و به شما اطلاع داده می‌شود که دسترسی به ارائه رد شده است. این امر به جلوگیری از دسترسی غیرمجاز و حفاظت از محتوای ارائه کمک می‌کند.

**آیا استفاده از ارائه‌های با رمز عبور محافظت‌شده تأثیراتی بر عملکرد دارد؟**

فرآیند رمزگذاری و رمزگشایی ممکن است کمی بار اضافی در عملیات باز کردن و ذخیره‌سازی ایجاد کند. در بیشتر موارد، این تأثیر عملکردی کم است و به‌طور قابل‌توجهی زمان کلی پردازش کارهای ارائه شما را تحت‌تاثیر قرار نمی‌دهد.