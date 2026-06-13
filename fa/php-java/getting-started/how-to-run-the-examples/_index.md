---
title: چگونه مثال‌ها را اجرا کنیم
type: docs
weight: 140
url: /fa/php-java/how-to-run-the-examples/
keywords:
- مثال‌ها
- پیش‌نیازهای نرم‌افزاری
- گیت‌هاب
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "مثال‌های Aspose.Slides برای PHP از طریق Java را به سرعت اجرا کنید: مخزن را کلون کنید، بسته‌ها را بازگردانید، سپس ویژگی‌های PPT، PPTX و ODP را بسازید و تست کنید."
---
## **Download from GitHub**
تمام مثال‌های Aspose.Slides برای PHP از طریق Java در [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) میزبانی می‌شوند. می‌توانید مخزن را با استفاده از کلاینت مورد علاقه‌تان در Github کلون کنید یا فایل ZIP را از [اینجا](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) دانلود کنید.

محتویات فایل ZIP را به هر پوشه‌ای روی کامپیوتر خود استخراج کنید. تمام مثال‌ها در پوشه **Examples** قرار دارند.

![todo:image_alt_text](examples_directory.png)

## **Import Examples into the IDE**
پروژه از سیستم ساخت Maven استفاده می‌کند. هر IDE مدرن می‌تواند به راحتی پروژه و وابستگی‌های آن را باز یا وارد کند. در ادامه نشان می‌دهیم چطور با IDEهای پرطرفدار مثال‌ها را بیلد و اجرا کنید.

### **IntelliJ IDEA**
بر روی منوی **File** کلیک کنید و **Open** را انتخاب کنید. به پوشه پروژه بروید و فایل **pom.xml** را انتخاب کنید.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

پروژه باز می‌شود و به‌صورت خودکار وابستگی‌ها را دانلود می‌کند. از تب Project، مثال‌ها را در پوشه **src/main/java** مرور کنید. برای اجرای یک مثال، فقط روی فایل راست‌کلیک کنید و «Run ..» را انتخاب کنید؛ مثال اجرا می‌شود و خروجی در پنجرهٔ کنسول داخلی نمایش داده می‌شود.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
بر روی منوی **File** کلیک کنید و **Import** را انتخاب کنید. گزینه **Maven** - Existing Maven Projects را برگزینید.

![todo:image_alt_text](eclipse_import.png)

به پوشه‌ای که مخزن را کلون یا دانلود کرده‌اید بروید و فایل **pom.xml** را انتخاب کنید. پروژه باز می‌شود و به‌صورت خودکار وابستگی‌ها را دانلود می‌کند. از تب Package Explorer، مثال‌ها را در پوشه **src/main/java** مرور کنید. برای اجرای یک مثال، فقط روی فایل راست‌کلیک کنید و **Run As** - **Java Application** را انتخاب کنید؛ مثال اجرا می‌شود و خروجی در پنجرهٔ کنسول داخلی نمایش داده می‌شود.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
بر روی منوی **File** کلیک کنید و **Open Project** را انتخاب کنید. به پوشه‌ای که مخزن را کلون یا دانلود کرده‌اید بروید. آیکون پوشه **Examples** نشان می‌دهد که یک پروژه Maven است. پوشه Examples را انتخاب و باز کنید.

![todo:image_alt_text](netbeans_openproject.png)

پروژه باز می‌شود و به‌صورت خودکار وابستگی‌ها را دانلود می‌کند. از تب Projects، مثال‌ها را در **source packages** مرور کنید. برای اجرای یک مثال، فقط روی فایل راست‌کلیک کنید و **Run File** را انتخاب کنید؛ مثال اجرا می‌شود و خروجی در پنجرهٔ کنسول داخلی نمایش داده می‌شود.

![todo:image_alt_text](netbeans_run_example.png)

## **Add Aspose.Slides Library into Maven Local Repository**
زمانی که پروژه **Aspose.Slides Examples** را به IDE وارد می‌کنید، Maven به‌صورت خودکار فایل JAR aspose.slides را از [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) دانلود می‌کند. در صورتی که دسترسی به اینترنت ندارید، می‌توانید به‌صورت دستی JAR را به مخزن محلی خود اضافه کنید.

### **mvn install**
فایل [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/) را دانلود کنید، استخراج کنید و فایل aspose.slides-version.jar را به مسیری دیگر، برای مثال در درایو C، کپی کنید. سپس دستور زیر را اجرا کنید:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

اکنون فایل JAR **aspose.slides** به مخزن محلی Maven شما کپی شده است.

### **pom.xml**
پس از نصب، به سادگی مختصات **aspose.slides** را در pom.xml اعلام کنید. مخزن زیر را در تب repositories و وابستگی را در تب dependencies اضافه کنید.

``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php

### **Done**
آن را بیلد کنید، اکنون فایل JAR **aspose.slides** می‌تواند از مخزن محلی Maven شما بازیابی شود.

## **Contribute**
اگر مایل به افزودن یا بهبود یک مثال هستید، شما را تشویق می‌کنیم که به پروژه کمک کنید. تمام مثال‌ها و پروژه‌های نمایشی در این مخزن منبع باز هستند و می‌توانید به‌راحتی در برنامه‌های خود استفاده کنید.

برای مشارکت می‌توانید مخزن را فورک کنید، کد منبع را ویرایش کنید و یک Pull Request ارسال کنید. ما تغییرات را بررسی می‌کنیم و در صورت مفید بودن، آنها را در مخزن ادغام می‌کنیم.