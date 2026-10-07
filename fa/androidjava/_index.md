---
title: Aspose.Slides برای Android از طریق Java
second_title: Aspose.Slides برای Android
type: docs
weight: 40
url: /fa/androidjava/
keywords:
- مستندات
- پردازش ارائه
- تبدیل ارائه
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "از اینجا شروع کنید: Aspose.Slides برای Android از طریق Java را به برنامه خود اضافه کنید، اولین ارائه را ایجاد کنید و راهنماهای وظایف عمومی، مرجع API و پشتیبانی را بیابید."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java یک کتابخانهٔ کلاس برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Android است، بدون نیاز به Microsoft PowerPoint.

این کتابخانه فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره می‌کند، از جمله نسخه‌های ماکرو‌دار و قالب، و به فرمت‌های PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر صادر می‌شود.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع به کار</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/androidjava/install-aspose-slides-for-android-via-java/">نصب</a></li>
<li><a href="/slides/fa/androidjava/create-presentation/">ساخت اولین ارائه</a></li>
<li><a href="/slides/fa/androidjava/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/androidjava/supported-file-formats/">قالب‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/androidjava/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/androidjava/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>وظایف رایج</p>
<ul>
<li><a href="/slides/fa/androidjava/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/androidjava/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/androidjava/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/androidjava/convert-slide/">تبدیل اسلایدها به تصویر</a></li>
<li><a href="/slides/fa/androidjava/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان‌های کاری Slides</p>
<ul>
<li><a href="/slides/fa/androidjava/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/androidjava/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/androidjava/manage-media-files/">صوت و تصویر</a></li>
<li><a href="/slides/fa/androidjava/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/androidjava/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>نمونه‌ها</p>
<ul>
<li><a href="/slides/fa/androidjava/examples/">نمونه‌ها بر حسب عنصر اسلاید</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع &amp; پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">دفترچه تغییرات</a></li>
<li><a href="/slides/fa/androidjava/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">صفحه محصول</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی پولی</a></li>
</ul>
</div>
</div>

------

## **اولین ارائه شما**

این کتابخانه از مخزن Maven شرکت Aspose آمده است. پروژه‌های جدید Android Studio از پیش یک بلوک `dependencyResolutionManagement` در *settings.gradle.kts* دارند. به جای افزودن یک بلوک دوم، خط `maven` نشان داده شده در زیر را به بلوک `repositories` داخل آن اضافه کنید:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

سپس کتابخانه را به *app/build.gradle.kts* اضافه کنید و پروژه را همگام‌سازی کنید:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[نصب](/slides/fa/androidjava/install-aspose-slides-for-android-via-java/) شامل اسکریپت‌های ساخت Groovy، فایل JAR دستی، و نحوه انتخاب نسخه است. کد اولین ارائه شما در [ساخت ارائه‌ها](/slides/fa/androidjava/create-presentation/) قرار دارد: این کد یک جعبه متن به یک اسلاید اضافه می‌کند و ارائه را در ذخیره‌سازی برنامه شما ذخیره می‌نماید. این نمونه کامپایل شده و به یک APK ساخته شده است؛ هنوز روی دستگاه اجرا نشده است. بدون داشتن لایسنس، ارائه‌های ذخیره‌شده دارای واتردار ارزیابی هستند — برای اطلاعات بیشتر به [مجوزدهی](/slides/fa/androidjava/licensing/) مراجعه کنید.