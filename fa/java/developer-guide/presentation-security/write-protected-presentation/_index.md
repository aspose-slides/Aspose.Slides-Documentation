---
title: محافظت از نوشتن ارائه‌ها در جاوا
linktitle: محافظت از نوشتن
type: docs
weight: 25
url: /fa/java/write-protected-presentation/
keywords:
- محافظت از نوشتن
- محافظت از نوشتن PowerPoint
- رمز عبور برای ویرایش
- محدود کردن ویرایش ارائه
- حذف محافظت از نوشتن
- اعتبارسنجی رمز عبور تغییر
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "تنظیم، شناسایی، اعتبارسنجی و حذف رمزهای محافظت از نوشتن در ارائه‌های PowerPoint PPT و PPTX با استفاده از Aspose.Slides برای جاوا."
---
## **مقدمه**

یک رمز عبور حفاظت از نوشتن، تغییرات یک ارائه را محدود می‌کند اما محتوای آن را رمزنگاری نمی‌کند. کاربران می‌توانند ارائهٔ محافظت‌شده‌از‑نوشتن را بدون رمز عبور بارگذاری و مشاهده کنند. بسته به برنامه، ممکن است توانایی ویرایش محتوا و ذخیره آن با نامی دیگر را نیز داشته باشند، لذا حفاظت از نوشتن نباید به‌عنوان مکانیزم محرمانگی در نظر گرفته شود.

یک رمز عبور باز کردن هدف متفاوتی دارد: ارائه را رمزنگاری می‌کند و برای بارگذاری محتوای آن لازم است. برای رمزگذاری یک ارائه یا اعتبارسنجی رمز عبور باز کردن، به [Password‑Protect Presentations](/slides/fa/java/password-protected-presentation/) مراجعه کنید.

رویه‌های این مقاله برای ارائه‌های PPT و PPTX اعمال می‌شود. مثال‌ها از فایل‌های PPTX استفاده می‌کنند؛ هنگام ذخیره به PPT، از پسوند `.ppt` و قالب ذخیرهٔ PPT متناظر استفاده کنید.

## **تنظیم حفاظت از نوشتن برای یک ارائه**

از [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) برای اختصاص رمز عبور جهت تغییر یک ارائه استفاده کنید. ذخیرهٔ ارائه، تنظیم حفاظت را حفظ می‌کند.

مثال زیر حفاظت از نوشتن را برای یک ارائهٔ PPTX تنظیم می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **بارگذاری یک ارائهٔ محافظت‌شده‌از‑نوشتن**

از آنجا که حفاظت از نوشتن محتوای ارائه را رمزنگاری نمی‌کند، برای بارگذاری ارائه نیازی به رمز عبور نیست. رمز عبور فقط هنگام اعتبارسنجی اجازهٔ تغییر ارائهٔ محافظت‌شده مورد استفاده قرار می‌گیرد.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

رمز عبور حفاظت از نوشتن را به [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) ندهید. این متد یک رمز عبور باز کردن برای محتوای رمزنگاری‌شده را می‌پذیرد. اگر یک ارائه هر دو نوع حفاظت را داشته باشد، برای بارگذاری آن رمز عبور باز کردن را فراهم کنید و رمز عبور حفاظت از نوشتن را به‌صورت جداگانه مدیریت کنید.

## **حذف حفاظت از نوشتن از یک ارائه**

از [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) برای حذف محدودیت تغییر استفاده کنید، سپس ارائه را ذخیره کنید.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **بررسی اینکه آیا یک ارائه محافظت‌شده‌از‑نوشتن است یا خیر**

برای بررسی یک فایل بدون ایجاد یک نمونهٔ کامل از [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/)، [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) را فراخوانی کنید و [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) را بررسی نمایید. این متد از [NullableBool](https://reference.aspose.com/slides/fa/java/com.aspose.slides/nullablebool/) استفاده می‌کند و زمانی که حفاظت از نوشتن تشخیص داده شود، `NullableBool.True` برمی‌گرداند.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

بارگذاری [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) با جریان (stream) همان اطلاعات را برای ارائه‌ای که به‌صورت جریان فراهم می‌شود، ارائه می‌دهد.

## **اعتبارسنجی رمز عبور حفاظت از نوشتن**

از [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) برای اعتبارسنجی رمز عبور تغییر بدون بارگذاری کامل ارائه استفاده کنید. ابتدا [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) را بررسی کنید تا برنامه فقط زمانی که حفاظت از نوشتن موجود باشد، درخواست یا اعتبارسنجی رمز عبور انجام دهد.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) فقط رمز عبور حفاظت از نوشتن را اعتبارسنجی می‌کند. این متد رمز عبور باز کردن یا قابلیت بارگذاری محتوای رمزنگاری‌شده را اعتبارسنجی نمی‌کند. برعکس، [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) فقط یک رمز عبور باز کردن را اعتبارسنجی می‌کند. اگر یک ارائهٔ کامل قبلاً بارگذاری شده باشد، [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) بررسی معادل حفاظت از نوشتن را از طریق مدیر حفاظت فراهم می‌کند.

در برنامه‌های تولیدی، رمزهای عبور را لاگ نکنید و در پیام‌های تشخیصی گنجاننده نشود. از تلاش‌های تکراری غیرضروری برای اعتبارسنجی خودداری کنید و رمزها را در حافظه فقط به‌مدت زمان لازم نگه دارید.

{{% alert color="info" title="همچنین ببینید" %}}
- [Password‑Protect Presentations](/slides/fa/java/password-protected-presentation/)
- [Read‑Only Presentations](/slides/fa/java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/fa/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سؤالات متداول**

**آیا حفاظت از نوشتن یک ارائه را رمزنگاری می‌کند؟**

خیر. این ویژگی فقط تغییرات را محدود می‌کند ولی محتوای ارائه برای بارگذاری و مشاهده در دسترس می‌ماند.

**آیا رمز عبور حفاظت از نوشتن برای باز کردن یک ارائه لازم است؟**

خیر. فقط یک رمز عبور باز کردن برای بارگذاری محتوای رمزنگاری‌شدهٔ ارائه لازم است.

**آیا یک ارائه می‌تواند هم‌زمان یک رمز عبور باز کردن و یک رمز عبور حفاظت از نوشتن داشته باشد؟**

بله. رمز عبور باز کردن را از طریق گزینه‌های بارگذاری برای باز کردن ارائهٔ رمزنگاری‌شده فراهم کنید و رمز عبور حفاظت از نوشتن را به‌صورت جداگانه هنگام نیاز به اجازهٔ تغییر اعتبارسنجی کنید.