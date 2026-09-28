---
title: نصب Aspose.Slides برای Android از طریق Java
type: docs
weight: 90
url: /fa/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- نصب Aspose.Slides
- دانلود Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- Gradle
- مخزن Maven
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides برای Android از طریق Java را با Gradle از مخزن Maven Aspose به یک پروژه Android Studio اضافه کنید، یا فایل JAR را به صورت دستی اضافه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه Aspose.Slides for Android via Java را به یک پروژه Android اضافه کنید. روش پیشنهادی این است که اجازه دهید Gradle کتابخانه را از مخزن Maven Aspose دانلود کند. همچنین می‌توانید فایل JAR را دانلود کرده و به صورت دستی به پروژه خود اضافه کنید.

این کتابخانه در Maven Central یا مخزن Maven گوگل منتشر نشده است. این کتابخانه از مخزن خود Aspose در دسترس است، به عنوان Artefact `aspose-slides` با classifier `android.via.java`.

## **نصب از مخزن Maven Aspose**

### **مرحله ۱: افزودن مخزن**

پروژه‌های جدید Android Studio مخازن خود را در بلوک `dependencyResolutionManagement` فایل *settings.gradle.kts* اعلام می‌کنند و Gradle مخازنی را که فایل ساخت یک ماژول اضافه می‌کند، رد می‌کند. خط `maven` زیر را به بلوک `repositories` داخل آن بلوک موجود اضافه کنید، نه اینکه یک بلوک دوم `dependencyResolutionManagement` بچسبانید:

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

### **مرحله ۲: افزودن وابستگی**

کتابخانه را به بلوک `dependencies` فایل ساخت ماژول app، *app/build.gradle.kts* اضافه کنید:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

بخش آخر مختصات، `android.via.java`، classifier‌ای است که ساخت Android کتابخانه را انتخاب می‌کند. بدون آن Gradle نمی‌تواند Artefact را پیدا کند.

سپس پروژه را با فایل‌های Gradle همگام‌سازی کنید تا Gradle کتابخانه را دانلود کند.

### **انتخاب نسخه**

Aspose.Slides for Android via Java برای تمام نسخه‌های موجود در مخزن ساخته نشده است. ساخت‌های آن تنها برای برخی نسخه‌های Aspose.Slides for Java منتشر می‌شوند و نسخه‌ای که ساخت Android ندارد، نمی‌تواند حل شود. نسخه‌ای را که در صفحه [Aspose.Slides for Android via Java download page](https://releases.aspose.com/slides/androidjava/) فهرست شده است، انتخاب کنید.

### **اسکریپت‌های ساخت Groovy**

اگر پروژه شما از اسکریپت‌های ساخت Groovy استفاده می‌کند، خط `maven` را به بلوک `repositories` داخل بلوک موجود `dependencyResolutionManagement` در *settings.gradle* اضافه کنید:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

و وابستگی را به *app/build.gradle* اضافه کنید:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **افزودن فایل JAR به صورت دستی**

اگر نمی‌توانید از مخزن Maven استفاده کنید، فایل JAR را به پروژه خود اضافه کنید:

1. فایل JAR را از پوشه نسخه در [Aspose's Maven repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) دانلود کنید. برای نسخه 26.9، این فایل *aspose-slides-26.9-android.via.java.jar* در پوشه *26.9* قرار دارد.
2. فایل را به پوشه *app/libs* پروژه خود کپی کنید. در صورت عدم وجود پوشه، آن را ایجاد کنید.
3. فایل را به بلوک `dependencies` در *app/build.gradle.kts* اضافه کنید، سپس پروژه را همگام‌سازی کنید:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **ایجاد اولین ارائه شما**

پس از همگام‌سازی پروژه، به [Create Presentations](/slides/fa/androidjava/create-presentation/) ادامه دهید. مثال اول آن یک جعبه متن را به یک اسلاید اضافه می‌کند و ارائه را در حافظه خصوصی برنامه شما ذخیره می‌سازد که نیازی به اجازه دسترسی به ذخیره‌سازی ندارد. بدون لایسنس، Aspose.Slides یک واترمارک ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌کند؛ نگاه کنید به [Licensing](/slides/fa/androidjava/licensing/).

## **نسخه‌بندی**

از سال 2018، نسخه‌بندی Aspose.Slides for Android via Java با Aspose.Slides for Java هم‌گام بوده است. ساخت‌های Android برای هر نسخه Java منتشر نمی‌شوند؛ برای جزئیات به [Choose a Version](#choose-a-version) مراجعه کنید.

## **سؤالات متداول**

### چگونه می‌توانم تأیید کنم که Aspose.Slides به درستی یکپارچه شده است؟

پروژه خود را بسازید، یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) خالی را نمونه‌سازی کنید و آن را با نام جدیدی ذخیره کنید. اگر فایل بدون پرتاب استثنا ایجاد شد، کتابخانه با موفقیت یکپارچه شده است.

### چگونه می‌توانم مصرف حافظه را هنگام پردازش ارائه‌های بزرگ محدود کنم؟

متد [dispose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#dispose--) هر نمونه [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) را در بلوک `finally` فراخوانی کنید تا منابع آن به‌سرعت آزاد شوند، و یک بار یک ارائه بزرگ را پردازش کنید. این کار به جلوگیری از خطاهای out‑of‑memory کمک می‌کند و مصرف کلی حافظه را در عملیات‌های دسته‌ای قابل پیش‌بینی نگه می‌دارد.

### آیا می‌توانم فرمت‌های خروجی ناخواسته را برای کوچک کردن اندازه نهایی JAR حذف کنم؟

نسخه‌های فعلی Aspose.Slides به‌صورت یک کتابخانه تک‌قطعه یکپارچه عرضه می‌شوند، بنابراین در زمان ساخت نمی‌توانید صادرکنندگان خاصی مانند PDF یا SVG را غیرفعال کنید.