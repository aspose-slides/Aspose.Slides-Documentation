---
title: امن سازی ارائه‌ها با رمز عبور در جاوا
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
- محافظت نوشتاری
- امنیت PowerPoint
- امنیت ارائه
- حذف رمز عبور
- حذف محافظت
- حذف رمزگذاری
- غیرفعال کردن رمز عبور
- غیرفعال کردن محافظت
- حذف محافظت نوشتاری
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint و OpenDocument محافظت‌شده با رمز عبور را قفل و بازقفل کنید با Aspose.Slides برای Java. ارائه‌های خود را ایمن کنید."
---
## **معرفی**

زمانی که یک ارائه را با رمز عبور محافظت می‌کنید، به این معنی است که رمز عبوری تنظیم می‌کنید که محدودیت‌های خاصی بر ارائه اعمال می‌کند. برای حذف این محدودیت‌ها باید رمز عبور وارد شود. یک ارائه‌ی محافظت‌شده با رمز عبور به‌عنوان یک ارائه‌ی قفل‌شده در نظر گرفته می‌شود.

به طور معمول می‌توانید برای اعمال این محدودیت‌ها بر یک ارائه، رمز عبور تنظیم کنید:

- **تغییر**

اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه‌ی شما را ویرایش کنند، می‌توانید محدودیت تغییر را تنظیم کنید. این محدودیت مانع از ویرایش، تغییر یا کپی عناصر در ارائه شما می‌شود مگر اینکه رمز عبور وارد شود.  

با این حال، حتی بدون رمز عبور، کاربر می‌تواند به سند شما دسترسی پیدا کرده و آن را باز کند. در این حالت فقط‑خواندنی، کاربر می‌تواند محتوای ارائه—including لینک‌ها، انیمیشن‌ها، افکت‌ها و سایر عناصر—را مشاهده کند، اما نمی‌تواند موارد را کپی کرده یا ارائه را ذخیره کند.

- **باز کردن**

اگر می‌خواهید فقط کاربران خاصی بتوانند ارائه‌ی شما را باز کنند، می‌توانید محدودیت باز کردن را تنظیم کنید. این محدودیت مانع افراد حتی از مشاهده محتویات ارائه می‌شود مگر اینکه رمز عبور وارد شود.  

در واقع، محدودیت باز کردن همچنین مانع کاربران از ویرایش ارائه‌های شما می‌شود—اگر افراد نتوانند ارائه‌ای را باز کنند، نمی‌توانند آن را ویرایش یا تغییر دهند.

**توجه:** زمانی که یک ارائه را با رمز عبور محافظت می‌کنید تا باز کردن آن را منع کنید، فایل ارائه رمزگذاری می‌شود.

## **حفاظت با رمز عبور در Aspose.Slides**
**فرمت‌های پشتیبانی‌شده**

Aspose.Slides ارائه، رمزگذاری، و عملیات مشابه را برای ارائه‌ها در این فرمت‌ها پشتیبانی می‌کند: 

- PPTX و PPT - ارائه Microsoft PowerPoint 
- ODP - ارائه OpenDocument 
- OTP - قالب ارائه OpenDocument 

**عملیات‌های پشتیبانی‌شده**

Aspose.Slides به شما امکان می‌دهد با استفاده از این روش‌ها از تغییرات در یک ارائه جلوگیری کنید:

- رمزگذاری یک ارائه
- تنظیم محافظت نوشتاری برای یک ارائه

**سایر عملیات**

Aspose.Slides به شما امکان انجام کارهای دیگری مرتبط با حفاظت با رمز عبور و رمزگذاری را به این شکل می‌دهد:

- رمزگشایی یک ارائه؛ باز کردن یک ارائه‌ی رمزگذاری‌شده
- حذف رمزگذاری؛ غیرفعال‌سازی حفاظت با رمز عبور
- حذف محافظت نوشتاری از یک ارائه
- دریافت ویژگی‌های یک ارائه‌ی رمزگذاری‌شده
- بررسی اینکه آیا یک ارائه رمزگذاری شده است
- بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است. 

## **محافظت از یک ارائه با رمز عبور**

می‌توانید با تنظیم رمز عبور، یک ارائه را رمزگذاری کنید. سپس، برای تغییر ارائه‌ی قفل‌شده، کاربر باید رمز عبور را ارائه دهد. 

برای رمزگذاری یا محافظت با رمز عبور یک ارائه، باید از متد encrypt (از [IProtectionManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager)) برای تنظیم رمز عبور برای ارائه استفاده کنید. رمز عبور را به متد encrypt پاس می‌دهید و از متد save برای ذخیره ارائه‌ی اکنون رمزگذاری‌شده استفاده می‌کنید. 

این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگذاری کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تنظیم محافظت نوشتاری برای یک ارائه**

می‌توانید علامت «عدم ویرایش» را به یک ارائه اضافه کنید. به این ترتیب، به کاربران می‌گویید که نمی‌خواهید آنها تغییراتی در ارائه ایجاد کنند.  

**توجه** داشته باشید که فرایند محافظت نوشتاری ارائه را رمزگذاری نمی‌کند. بنابراین، کاربران—اگر بخواهند—می‌توانند ارائه را ویرایش کنند، اما برای ذخیره تغییرات، باید ارائه را با نام دیگری ذخیره کنند. 

برای تنظیم محافظت نوشتاری، باید از متد [setWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) استفاده کنید. این کد نمونه نشان می‌دهد چگونه یک محافظت نوشتاری برای یک ارائه تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بارگذاری یک ارائه‌ی رمزگذاری‌شده**

Aspose.Slides به شما امکان می‌دهد یک ارائه‌ی رمزگذاری‌شده را با عبور دادن رمز عبور صحیح از طریق [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) بارگذاری کنید. 

این کد نمونه نشان می‌دهد چگونه یک ارائه‌ی رمزگذاری‌شده را بارگذاری کنید: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // کار با ارائه رمزگشایی‌شده
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **حذف رمزگذاری از یک ارائه**

می‌توانید رمزگذاری یا حفاظت با رمز عبور یک ارائه را حذف کنید. به این ترتیب، کاربران می‌توانند بدون محدودیت به ارائه دسترسی داشته و آن را ویرایش کنند. 

برای حذف رمزگذاری یا حفاظت با رمز عبور، باید متد [removeEncryption](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#removeEncryption--) را فراخوانی کنید. این کد نمونه نشان می‌دهد چگونه رمزگذاری را از یک ارائه حذف کنید:

```java
import com.aspose.slides.*;

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

## **حذف محافظت نوشتاری از یک ارائه**

می‌توانید با استفاده از Aspose.Slides، محافظت نوشتاری اعمال‌شده بر یک فایل ارائه را حذف کنید. بدین ترتیب، کاربران می‌توانند به دلخواه ویرایش کنند—و هنگام انجام این کار هیچ هشداردهی دریافت نمی‌کنند.

می‌توانید محافظت نوشتاری را از یک ارائه با استفاده از متد [removeWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) حذف کنید. این کد نمونه نشان می‌دهد چگونه محافظت نوشتاری را از یک ارائه حذف کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **دریافت ویژگی‌های یک ارائه‌ی رمزگذاری‌شده**

به طور معمول کاربران در بازیابی ویژگی‌های سند یک ارائه‌ی رمزگذاری‌شده یا محافظت‌شده با رمز عبور مشکل دارند. با این حال، Aspose.Slides مکانیزمی ارائه می‌دهد که به شما اجازه می‌دهد یک ارائه را با رمز عبور محافظت کنید و در عین حال توانایی دسترسی کاربران به ویژگی‌های آن را حفظ کنید.

**توجه**: به‌طور پیش‌فرض، زمانی که Aspose.Slides یک ارائه را رمزگذاری می‌کند، ویژگی‌های سند ارائه نیز با رمز عبور محافظت می‌شوند. اگر نیاز داشته باشید ویژگی‌های سند حتی پس از رمزگذاری قابل دسترسی باشند، Aspose.Slides این امکان را برای شما فراهم می‌کند.

اگر می‌خواهید کاربران توانایی دسترسی به ویژگی‌های یک ارائه‌ی رمزگذاری‌شده را حفظ کنند، مقدار `false` را به [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) پاس دهید. این کد نمونه نشان می‌دهد چگونه یک ارائه را رمزگذاری کنید در حالی که همچنان دسترسی کاربران به ویژگی‌های سند آن فراهم باشد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **فقط بارگذاری ویژگی‌های سند از یک ارائه‌ی رمزگذاری‌شده**

برای بررسی متادیتای یک ارائه‌ی رمزگذاری‌شده بدون بارگذاری اسلایدها یا سایر محتوا، یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) ایجاد کنید و مقدار `true` را به [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) پاس دهید. در این حالت، Aspose.Slides رمز عبور را نادیده می‌گیرد و فقط ویژگی‌های سندی که عمومی هستند را بارگذاری می‌کند.

کد زیر ویژگی‌های سند داخلی و سفارشی را از طریق [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getDocumentProperties--) می‌خواند:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // خواندن ویژگی‌های سند پیش‌فرض.
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

این روند فقط زمانی کار می‌کند که ویژگی‌های سند هنگام رمزگذاری ارائه به صورت رمزنگاری‌نشده (عمومی) باقی مانده باشند. اگر ویژگی‌های سند رمزگذاری شوند، پاس دادن `true` به `loadOptions.setOnlyLoadDocumentProperties` منجر به استثنا می‌شود زیرا در این حالت رمز عبور نادیده گرفته می‌شود. برای دسترسی به ویژگی‌های سند رمزگذاری‌شده یا بارگذاری کامل ارائه، شامل اسلایدها و سایر محتوا، رمز عبور صحیح را از طریق [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) ارائه دهید.

## **بررسی اینکه آیا یک ارائه با رمز عبور محافظت شده است**

قبل از بارگذاری یک ارائه، ممکن است بخواهید بررسی و تأیید کنید که ارائه با رمز عبور محافظت نشده است. به این ترتیب می‌توانید از خطاها و مشکلات مشابهی که هنگام بارگذاری یک ارائه‌ی محافظت‌شده با رمز عبور بدون داشتن رمز عبور رخ می‌دهد، جلوگیری کنید.

این کد جاوا نشان می‌دهد چگونه یک ارائه را بررسی کنید تا ببینید آیا با رمز عبور محافظت شده است (بدون بارگذاری خود ارائه):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **بررسی اینکه آیا یک ارائه رمزگذاری شده است**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه رمزگذاری شده است یا خیر. برای انجام این کار می‌توانید از ویژگی [isEncrypted](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#isEncrypted--) استفاده کنید که در صورتی که ارائه رمزگذاری شده باشد `true` و در غیر این صورت `false` برمی‌گرداند. 

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه رمزگذاری شده است یا نه:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بررسی اینکه آیا یک ارائه محافظت نوشتاری دارد**

Aspose.Slides به شما امکان می‌دهد بررسی کنید آیا یک ارائه محافظت نوشتاری دارد یا نه. برای این کار می‌توانید از ویژگی [isWriteProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IProtectionManager#isWriteProtected--) استفاده کنید که در صورت داشتن محافظت نوشتاری `true` و در غیر این صورت `false` برمی‌گرداند. 

این کد نمونه نشان می‌دهد چگونه بررسی کنید آیا یک ارائه محافظت نوشتاری دارد یا نه:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **اعتبارسنجی یا تأیید اینکه یک رمز عبور خاص استفاده شده است**

ممکن است بخواهید بررسی و تأیید کنید که یک رمز عبور خاص برای محافظت از سند ارائه استفاده شده است. Aspose.Slides وسایلی برای اعتبارسنجی رمز عبور در اختیار شما قرار می‌دهد. 

این کد نمونه نشان می‌دهد چگونه یک رمز عبور را اعتبارسنجی کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // بررسی کنید آیا "pass" مطابقت دارد
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

اگر ارائه با رمز عبور مشخصی محافظت نوشتاری شده باشد، `true` برمی‌گرداند؛ در غیر این صورت، `false` برمی‌گرداند. 

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fa/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سؤالات متداول**

**کدام روش‌های رمزگذاری توسط Aspose.Slides پشتیبانی می‌شوند؟**

Aspose.Slides از روش‌های رمزگذاری مدرن، از جمله الگوریتم‌های مبتنی بر AES، پشتیبانی می‌کند تا سطح بالایی از امنیت داده‌ها برای ارائه‌های شما فراهم شود.

**چه اتفاقی می‌افتد اگر هنگام تلاش برای باز کردن یک ارائه، رمز عبور نادرست وارد شود؟**

اگر رمز عبور نادرست استفاده شود، یک استثنا پرتاب می‌شود که به شما اطلاع می‌دهد دسترسی به ارائه رد شده است. این کمک می‌کند از دسترسی غیرمجاز جلوگیری شود و محتویات ارائه محافظت شوند.

**آیا هنگام کار با ارائه‌های محافظت‌شده با رمز عبور، اثرات عملکردی وجود دارد؟**

فرایند رمزگذاری و رمزگشایی ممکن است در حین عملیات باز کردن و ذخیره‌سازی کمی بار اضافی ایجاد کند. در بیشتر موارد، این تأثیر عملکردی کم‌اهمیت است و به‌طور قابل‌توجهی زمان کلی پردازش کارهای ارائه شما را تحت‌تأثیر قرار نمی‌دهد.