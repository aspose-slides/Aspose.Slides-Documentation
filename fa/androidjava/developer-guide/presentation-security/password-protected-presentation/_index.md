---
title: حفاظت از ارائه‌ها با رمز عبور در Android
linktitle: محافظت با رمز عبور
type: docs
weight: 20
url: /fa/androidjava/password-protected-presentation/
keywords:
- قفل PowerPoint
- قفل ارائه
- باز کردن قفل PowerPoint
- باز کردن قفل ارائه
- محافظت PowerPoint
- محافظت ارائه
- تنظیم رمز عبور
- افزودن رمز عبور
- رمزگذاری PowerPoint
- رمزگذاری ارائه
- رمزگشایی PowerPoint
- رمزگشایی ارائه
- محافظت نوشتن
- امنیت PowerPoint
- امنیت ارائه
- حذف رمز عبور
- حذف حفاظت
- حذف رمزگذاری
- غیرفعال سازی رمز عبور
- غیرفعال سازی حفاظت
- حذف محافظت نوشتن
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint و OpenDocument محافظت‌شده با رمز عبور را با Aspose.Slides برای Android از طریق Java قفل و بازقفل کنید. ارائه‌های خود را ایمن کنید."
---
## **معرفی**

وقتی یک ارائه را با رمز عبور محافظت می‌کنید، به این معناست که رمز عبوری تنظیم می‌کنید که محدودیت‌های خاصی بر ارائه اعمال می‌کند. برای حذف این محدودیت‌ها، باید رمز عبور وارد شود. یک ارائه‌ٔ محافظت‌شده با رمز عبور به عنوان یک ارائهٔ قفل‌شده در نظر گرفته می‌شود.

به‌طور معمول، می‌توانید یک رمز عبور تنظیم کنید تا این محدودیت‌ها را بر یک ارائه اعمال کنید:

- **تغییر**

  اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه‌ی شما را تغییر دهند، می‌توانید محدودیت تغییر را تنظیم کنید. این محدودیت مانع از تغییر، اصلاح یا کپی‌کردن موارد در ارائه شما می‌شود (مگر اینکه رمز عبور را ارائه دهند). 

  با این حال، در این حالت، حتی بدون رمز عبور، کاربر می‌تواند به سند شما دسترسی پیدا کرده و آن را باز کند. در این حالت فقط-خواندنی، کاربر می‌تواند محتواها یا موارد—پیوندها، انیمیشن‌ها، افکت‌ها و غیره—در داخل ارائه را مشاهده کند، اما نمی‌تواند موارد را کپی یا ارائه را ذخیره کند. 

- **بازکردن**

  اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه‌ی شما را باز کنند، می‌توانید یک محدودیت بازکردن تنظیم کنید. این محدودیت مانع از حتی مشاهده محتواهای ارائه توسط افراد می‌شود (مگر اینکه رمز عبور را ارائه دهند).

  از نظر فنی، محدودیت بازکردن همچنین از تغییر ارائه توسط کاربران جلوگیری می‌کند: وقتی افراد نمی‌توانند یک ارائه را باز کنند، نمی‌توانند آن را تغییر دهند یا اصلاحاتی روی آن انجام دهند. 

  **نکته** زمانی که یک ارائه را با رمز عبور برای جلوگیری از بازکردن محافظت می‌کنید، فایل ارائه رمزگذاری می‌شود.

## **حفاظت با رمز عبور برای ارائه‌ها در Aspose.Slides**
**فرمت‌های پشتیبانی‌شده**

Aspose.Slides از حفاظت با رمز عبور، رمزگذاری، و عملیات مشابه برای ارائه‌ها در این فرمت‌ها پشتیبانی می‌کند: 

- PPTX and PPT - ارائه Microsoft PowerPoint 
- ODP - ارائه OpenDocument 
- OTP - قالب ارائه OpenDocument 

**عملیات پشتیبانی‌شده**

Aspose.Slides به شما اجازه می‌دهد از حفاظت با رمز عبور بر روی ارائه‌ها برای جلوگیری از تغییرات به این روش‌ها استفاده کنید:

- رمزگذاری یک ارائه
- تنظیم حفاظت نوشتن بر یک ارائه

**عملیات دیگر**

Aspose.Slides به شما امکان انجام کارهای دیگر مربوط به حفاظت با رمز عبور و رمزگذاری را به این روش‌ها می‌دهد:

- رمزگشایی یک ارائه؛ باز کردن یک ارائه رمزگذاری‌شده
- حذف رمزگذاری؛ غیر فعال کردن حفاظت با رمز عبور
- حذف حفاظت نوشتن از یک ارائه
- دریافت ویژگی‌های یک ارائه رمزگذاری‌شده
- بررسی اینکه آیا یک ارائه رمزگذاری شده است
- بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است.

## **رمزگذاری یک ارائه**

می‌توانید یک ارائه را با تنظیم یک رمز عبور رمزگذاری کنید. سپس برای تغییر ارائه‌ی قفل‌شده، کاربر باید رمز عبور را فراهم کند.

برای رمزگذاری یا محافظت با رمز عبور یک ارائه، باید از متد encrypt (از [IProtectionManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager)) برای تنظیم رمز عبور برای ارائه استفاده کنید. رمز عبور را به متد encrypt می‌گذارید و با استفاده از متد save، ارائه‌ی اکنون رمزگذاری‌شده را ذخیره می‌کنید.

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

می‌توانید علامتی با متن «تغییر نکنید» به یک ارائه اضافه کنید. به این ترتیب، به کاربران می‌گویید که نمی‌خواهید آنها تغییراتی در ارائه ایجاد کنند.  

**نکته** این است که فرآیند حفاظت نوشتن ارائه را رمزگذاری نمی‌کند. بنابراین، کاربران—اگر واقعاً بخواهند—می‌توانند ارائه را تغییر دهند، اما برای ذخیره‌ی تغییرات، باید یک ارائه با نام متفاوت ایجاد کنند. 

برای تنظیم حفاظت نوشتن، باید از متد [setWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) استفاده کنید. این کد نمونه نشان می‌دهد چگونه یک حفاظت نوشتن برای یک ارائه تنظیم کنید:

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

Aspose.Slides به شما اجازه می‌دهد یک فایل رمزگذاری‌شده را با وارد کردن رمز عبور آن بارگذاری کنید. برای رمزگشایی یک ارائه، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) را بدون پارامتر فراخوانی کنید. سپس باید رمز عبور صحیح را وارد کنید تا ارائه بارگذاری شود.

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

می‌توانید رمزگذاری یا حفاظت با رمز عبور یک ارائه را حذف کنید. به این ترتیب، کاربران می‌توانند بدون محدودیت به ارائه دسترسی پیدا کرده یا آن را تغییر دهند. 

برای حذف رمزگذاری یا حفاظت با رمز عبور، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) را فراخوانی کنید. این کد نمونه نشان می‌دهد چگونه رمزگذاری را از یک ارائه حذف کنید:

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

می‌توانید با استفاده از Aspose.Slides حفاظت نوشتن اعمال‌شده بر یک فایل ارائه را حذف کنید. به این ترتیب، کاربران می‌توانند به دلخواه تغییر دهند—و هنگام انجام این کار هشدار ندارند.

می‌توانید با استفاده از متد [removeWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) حفاظت نوشتن را از یک ارائه حذف کنید. این کد نمونه نشان می‌دهد چگونه حفاظت نوشتن را از یک ارائه حذف کنید:

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

به‌طور معمول، کاربران در دریافت ویژگی‌های سند یک ارائه رمزگذاری‌شده یا محافظت‌شده با رمز عبور مشکل دارند. اما Aspose.Slides مکانیسمی را ارائه می‌دهد که به شما امکان می‌دهد یک ارائه را با رمز عبور محافظت کنید در حالی که راهی برای دسترسی کاربران به ویژگی‌های آن ارائه حفظ می‌شود.

**نکته** این است که وقتی Aspose.Slides یک ارائه را رمزگذاری می‌کند، ویژگی‌های سند ارائه نیز به‌صورت پیش‌فرض با رمز عبور محافظت می‌شوند. اما اگر نیاز داشته باشید ویژگی‌های ارائه را در دسترس قرار دهید (حتی پس از رمزگذاری ارائه)، Aspose.Slides به شما امکان انجام دقیقاً این کار را می‌دهد. 

اگر می‌خواهید کاربران توانایی دسترسی به ویژگی‌های یک ارائه‌ای که شما رمزگذاری کرده‌اید را حفظ کنند، می‌توانید ویژگی [encryptDocumentProperties](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) را روی `true` تنظیم کنید. این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگذاری کنید در حالی که به کاربران امکان دسترسی به ویژگی‌های سند آن را می‌دهد:

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

قبل از بارگذاری یک ارائه، ممکن است بخواهید بررسی و تأیید کنید که ارائه با رمز عبور محافظت نشده است. به این ترتیب، می‌توانید از خطاها و مشکلات مشابهی که وقتی یک ارائه محافظت‌شده با رمز عبور بدون رمز آن بارگذاری می‌شود، پیش می‌آید، جلوگیری کنید.

این کد Java نشان می‌دهد چگونه یک ارائه را بررسی کنید تا ببینید آیا با رمز عبور محافظت شده است (بدون بارگذاری خود ارائه):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **بررسی اینکه آیا یک ارائه رمزگذاری شده است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه رمزگذاری شده است یا نه. برای انجام این کار، می‌توانید از ویژگی [isEncrypted](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) استفاده کنید که اگر ارائه رمزگذاری شده باشد `true` و اگر نیست `false` برمی‌گرداند.

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه رمزگذاری شده است یا نه:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بررسی اینکه آیا یک ارائه حفاظت نوشتن دارد**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه حفاظت نوشتن دارد یا نه. برای انجام این کار، می‌توانید از ویژگی [isWriteProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) استفاده کنید که اگر ارائه حفاظت نوشتن داشته باشد `true` و اگر نداشته باشد `false` برمی‌گرداند.

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه حفاظت نوشتن دارد یا نه:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **اعتبارسنجی یا تأیید اینکه یک رمز عبور خاص استفاده شده است**

ممکن است بخواهید بررسی و تأیید کنید که یک رمز عبور خاص برای محافظت از سند ارائه استفاده شده است. Aspose.Slides ابزارهایی را برای اعتبارسنجی یک رمز عبور فراهم می‌کند. 

این کد نمونه نشان می‌دهد چگونه یک رمز عبور را اعتبارسنجی کنید:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // بررسی اینکه آیا "pass" تطبیق دارد
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

اگر ارائه با رمز عبور مشخص رمزگذاری شده باشد، `true` برمی‌گردد. در غیر این صورت، `false` برمی‌گردد. 

{{% alert color="primary" title="همچنین ببینید" %}} 
- [امضای دیجیتال در PowerPoint](/slides/fa/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سؤالات متداول**

**کدام روش‌های رمزگذاری توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides از روش‌های رمزگذاری مدرن، از جمله الگوریتم‌های مبتنی بر AES، پشتیبانی می‌کند و سطح بالایی از امنیت داده‌ها برای ارائه‌های شما تضمین می‌نماید.

**چه اتفاقی می‌افتد اگر هنگام تلاش برای باز کردن یک ارائه، رمز عبور نادرست وارد شود؟**

اگر رمز عبور نادرست استفاده شود، یک استثنا صادر می‌شود که به شما اطلاع می‌دهد دسترسی به ارائه رد شده است. این کمک می‌کند تا از دسترسی غیرمجاز جلوگیری شود و محتویات ارائه محافظت شود.

**آیا کار با ارائه‌های محافظت‌شده با رمز عبور تأثیری بر عملکرد دارد؟**

فرآیند رمزگذاری و رمزگشایی ممکن است در هنگام عملیات باز کردن و ذخیره‌سازی کمی زمان اضافه کند. در بیشتر موارد، این تأثیر بر عملکرد کم بوده و به‌طور قابل توجهی زمان کلی پردازش کارهای ارائه شما را تحت‌تاثیر قرار نمی‌دهد.