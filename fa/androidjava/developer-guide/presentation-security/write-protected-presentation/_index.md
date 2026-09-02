---
title: محافظت نوشتاری ارائه‌ها در Android
linktitle: محافظت نوشتاری
type: docs
weight: 25
url: /fa/androidjava/write-protected-presentation/
keywords:
- محافظت نوشتاری
- محافظت نوشتاری PowerPoint
- کلمه عبور برای ویرایش
- محدود کردن ویرایش ارائه
- حذف محافظت نوشتاری
- اعتبارسنجی کلمه عبور ویرایش
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "تنظیم، شناسایی، اعتبارسنجی و حذف کلمات عبور محافظت نوشتاری در ارائه‌های PowerPoint PPT و PPTX با استفاده از Aspose.Slides برای Android از طریق Java."
---
## **مقدمه**

کلمه عبور حفاظت نوشتاری، تغییرات ارائه را محدود می‌کند اما محتوای آن را رمزگذاری نمی‌کند. کاربران می‌توانند یک ارائه محافظت‌شده‌نویس را بدون کلمه عبور بارگذاری و مشاهده کنند. بسته به برنامه، ممکن است بتوانند محتوای آن را ویرایش کرده و تحت نامی متفاوت ذخیره کنند، بنابراین حفاظت نوشتاری نباید به‌عنوان یک مکانیزم محرمانگی تلقی شود.

کلمه عبور باز کردن هدف متفاوتی دارد: ارائه را رمزگذاری می‌کند و برای بارگذاری محتوای آن لازم است. برای رمزگذاری یک ارائه یا اعتبارسنجی کلمه عبور باز کردن، به [Password-Protect Presentations](/slides/fa/androidjava/password-protected-presentation/) مراجعه کنید.

گردش‌کارهای این مقاله برای ارائه‌های PPT و PPTX اعمال می‌شود. مثال‌ها از فایل‌های PPTX استفاده می‌کنند؛ هنگام ذخیره به PPT، پسوند `.ppt` و فرمت ذخیره‌سازی PPT مربوطه را به کار ببرید.

## **تنظیم حفاظت نوشتاری بر روی یک ارائه**

از [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) برای اختصاص کلمه عبور جهت اصلاح یک ارائه استفاده کنید. ذخیرهٔ ارائه، تنظیمات حفاظت را نگه می‌دارد.

مثال زیر حفاظت نوشتاری را بر روی یک ارائه PPTX تنظیم می‌کند:

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

## **بارگذاری یک ارائه محافظت‌شده‌نویس**

از آنجا که حفاظت نوشتاری محتوای ارائه را رمزگذاری نمی‌کند، برای بارگذاری ارائه نیازی به کلمه عبور نیست. این کلمه عبور فقط هنگام اعتبارسنجی مجوز اصلاح ارائه محافظت‌شده مورد استفاده قرار می‌گیرد.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

کلمه عبور حفاظت نوشتاری را به [ILoadOptions.setPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) ارسال نکنید. این متد یک کلمه عبور باز کردن برای محتوای رمزگذاری‌شده می‌پذیرد. اگر یک ارائه هر دو نوع حفاظت را داشته باشد، برای بارگذاری آن کلمه عبور باز کردن را فراهم کنید و کلمه عبور حفاظت نوشتاری را به‌صورت جداگانه مدیریت کنید.

## **حذف حفاظت نوشتاری از یک ارائه**

از [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) برای حذف محدودیت اصلاح استفاده کنید، سپس ارائه را ذخیره کنید.

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

## **بررسی اینکه آیا یک ارائه حفاظت نوشتاری دارد یا خیر**

برای بررسی یک فایل بدون ایجاد یک نمونهٔ کامل [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/)، به‌کارگیرید [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) و [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) را بررسی کنید. این متد از [NullableBool](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/nullablebool/) استفاده می‌کند و زمانی که حفاظت نوشتاری تشخیص داده شود، `NullableBool.True` برمی‌گرداند.

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

بارگذاری جریان overload از [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) همان اطلاعات را برای ارائه‌ای که به‌صورت جریان ارائه می‌شود، فراهم می‌کند.

## **اعتبارسنجی کلمه عبور حفاظت نوشتاری**

از [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) برای اعتبارسنجی کلمه عبور اصلاح بدون بارگذاری کامل ارائه استفاده کنید. ابتدا [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) را بررسی کنید تا برنامه فقط وقتی حفاظت نوشتاری موجود باشد، کلمه عبور را درخواست یا اعتبارسنجی کند.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) فقط کلمه عبور حفاظت نوشتاری را اعتبارسنجی می‌کند. این متد کلمه عبور باز کردن را اعتبارسنجی نمی‌کند و تعیین نمی‌کند که آیا محتوای رمزگذاری‌شده می‌تواند بارگذاری شود یا نه. در مقابل، [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) فقط یک کلمه عبور باز کردن را اعتبارسنجی می‌کند. اگر یک ارائهٔ کامل پیش از این بارگذاری شده باشد، [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) بررسی معادل حفاظت نوشتاری را از طریق مدیر حفاظت خود ارائه می‌دهد.

در برنامه‌های تولیدی، کلمات عبور را لاگ نکنید یا در پیام‌های تشخیصی گنجانده ندهید. از تلاش‌های پرهزینهٔ تکراری برای اعتبارسنجی خودداری کنید و کلمات عبور را در حافظه فقط به‌مدت زمان مورد نیاز نگه دارید.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/fa/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/fa/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/fa/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**آیا حفاظت نوشتاری یک ارائه را رمزگذاری می‌کند؟**

خیر. این فقط اصلاحات را محدود می‌کند ولی محتوای ارائه برای بارگذاری و مشاهده در دسترس می‌ماند.

**آیا کلمه عبور حفاظت نوشتاری برای باز کردن یک ارائه لازم است؟**

خیر. فقط یک کلمه عبور باز کردن برای بارگذاری محتوای رمزگذاری‌شدهٔ ارائه مورد نیاز است.

**آیا یک ارائه می‌تواند همزمان یک کلمه عبور باز کردن و یک کلمه عبور حفاظت نوشتاری داشته باشد؟**

بله. کلمه عبور باز کردن را از طریق گزینه‌های بارگذاری برای باز کردن ارائهٔ رمزگذاری‌شده فراهم کنید، و کلمه عبور حفاظت نوشتاری را جداگانه هنگام نیاز به مجوز اصلاح اعتبارسنجی کنید.