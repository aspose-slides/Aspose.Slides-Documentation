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
description: "از اینجا شروع کنید: Aspose.Slides برای Android از طریق Java را به برنامهٔ خود اضافه کنید، اولین ارائه را ایجاد کنید و راهنماهای کارهای رایج، مرجع API و پشتیبانی را بیابید."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides برای Android از طریق Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides برای Android از طریق Java یک کتابخانهٔ کلاس برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Android است، بدون نیاز به Microsoft PowerPoint.

این کتابخانه قابلیت بارگذاری و ذخیرهٔ فایل‌های PPT، PPTX، PPS، POT و ODP را دارد، از جمله نسخه‌های دارای ماکرو و قالب، و می‌تواند به PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر خروجی دهد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/androidjava/install-aspose-slides-for-android-via-java/">نصب</a></li>
<li><a href="/slides/fa/androidjava/create-presentation/">ایجاد اولین ارائه</a></li>
<li><a href="/slides/fa/androidjava/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/androidjava/supported-file-formats/">فرمت‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/androidjava/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/androidjava/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>کارهای رایج</p>
<ul>
<li><a href="/slides/fa/androidjava/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/androidjava/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/androidjava/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/androidjava/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/androidjava/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان‌های کاری Slides</p>
<ul>
<li><a href="/slides/fa/androidjava/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/androidjava/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/androidjava/manage-media-files/">صدا و ویدیو</a></li>
<li><a href="/slides/fa/androidjava/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/androidjava/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>مثال‌ها</p>
<ul>
<li><a href="/slides/fa/androidjava/examples/">مثال‌ها بر اساس عنصر اسلاید</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/fa/androidjava/">مستندات API</a></li>
<li><a href="https://releases.aspose.com/slides/fa/androidjava/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="/slides/fa/androidjava/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="https://releases.aspose.com/slides/fa/androidjava/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/fa/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی پولی</a></li>
</ul>
</div>
</div>

------

## **اولین ارائه شما**

کتابخانه از مخزن Maven شرکت Aspose می‌آید. پروژه‌های جدید Android Studio از قبل یک بلوک `dependencyResolutionManagement` در *settings.gradle.kts* دارند. خط `maven` نشان‌داده‌شده در زیر را به بلوک `repositories` داخل آن اضافه کنید، به جای این‌که بلوک دوم را بچسبانید:

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

[nنصب](/slides/fa/androidjava/install-aspose-slides-for-android-via-java/) شامل اسکریپت‌های ساخت Groovy، فایل JAR دستی و نحوهٔ انتخاب نسخه است. کد اولین ارائه شما در [ایجاد ارائه‌ها](/slides/fa/androidjava/create-presentation/) قرار دارد: این کد یک جعبهٔ متنی به اسلاید اضافه می‌کند و ارائه را در حافظهٔ برنامهٔ شما ذخیره می‌کند. این نمونه کامپایل شده و به یک APK تبدیل شده است؛ اما هنوز روی دستگاه اجرا نشده است. بدون مجوز، ارائه‌های ذخیره‌شده یک نشان‌چهرهٔ ارزیابی دارند — برای جزئیات به [مجوزدهی](/slides/fa/androidjava/licensing/) مراجعه کنید.