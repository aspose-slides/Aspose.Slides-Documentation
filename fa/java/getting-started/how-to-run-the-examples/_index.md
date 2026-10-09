---
title: چگونه نمونه‌ها را اجرا کنیم
type: docs
weight: 140
url: /fa/java/how-to-run-the-examples/
keywords:
- مثال‌ها
- نیازمندی‌های نرم‌افزاری
- GitHub
- پاورپوینت
- سند باز
- ارائه
- جاوا
- Aspose.Slides
description: "نمونه‌های Aspose.Slides برای Java را به سرعت اجرا کنید: مخزن را کلون کنید، بسته‌ها را بازیابی کنید، سپس ویژگی‌های PPT، PPTX و ODP را بسازید و تست کنید."
---
## **دانلود Aspose.Slides از GitHub**
تمام نمونه‌های Aspose.Slides برای Java در [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) میزبانی می‌شوند. می‌توانید مخزن را با کلاینت محبوب GitHub خود کلون کنید یا فایل ZIP را از [here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) دانلود کنید.

محتویات فایل ZIP را در هر پوشه‌ای از کامپیوتر خود استخراج کنید. تمام نمونه‌ها در پوشه **Examples** قرار دارند.

![todo:image_alt_text](examples_directory.png)

## **وارد کردن نمونه‌ها به IDE**
پروژه از سیستم ساخت Maven استفاده می‌کند. هر IDE مدرنی می‌تواند به راحتی پروژه و وابستگی‌های آن را باز یا وارد کند. در ادامه نشان می‌دهیم چطور با IDEهای محبوب نمونه‌ها را بسازید و اجرا کنید.

### **IntelliJ IDEA**
در منوی **File** گزینه **Open** را انتخاب کنید. به پوشه پروژه بروید و فایل **pom.xml** را انتخاب کنید.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

IDE پروژه را باز می‌کند و وابستگی‌ها را به‌صورت خودکار دانلود می‌کند. از تب Project به پوشه **src/main/java** رفته و نمونه‌ها را مرور کنید. برای اجرای یک نمونه فقط روی فایل راست‑کلیک کنید و **Run ..** را انتخاب کنید؛ نمونه اجرا می‌شود و خروجی در پنجره کنسول داخلی نمایش داده می‌شود.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
در منوی **File** گزینه **Import** را انتخاب کنید. **Maven** ‑ Existing Maven Projects را برگزینید.

![todo:image_alt_text](eclipse_import.png)

به پوشه‌ای که مخزن را کلون یا دانلود کرده‌اید بروید و فایل **pom.xml** را انتخاب کنید. پروژه باز می‌شود و وابستگی‌ها به‌صورت خودکار دانلود می‌شوند. از تب Package Explorer به پوشه **src/main/java** رفته و نمونه‌ها را مرور کنید. برای اجرای یک نمونه راست‑کلیک کنید و **Run As** ‑ **Java Application** را انتخاب کنید؛ نمونه اجرا می‌شود و خروجی در پنجره کنسول داخلی نمایش داده می‌شود.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
در منوی **File** گزینه **Open Project** را انتخاب کنید. به پوشه‌ای که مخزن را کلون یا دانلود کرده‌اید بروید. آیکون پوشه **Examples** نشان می‌دهد که این یک پروژه Maven است. پوشه Examples را انتخاب و باز کنید.

![todo:image_alt_text](netbeans_openproject.png)

پروژه باز می‌شود و وابستگی‌ها به‌صورت خودکار دانلود می‌شوند. از تب Projects به **source packages** رفته و نمونه‌ها را مرور کنید. برای اجرای یک نمونه راست‑کلیک کنید و **Run File** را انتخاب کنید؛ نمونه اجرا می‌شود و خروجی در پنجره کنسول داخلی نمایش داده می‌شود.

![todo:image_alt_text](netbeans_run_example.png)

## **افزودن کتابخانه Aspose.Slides به مخزن محلی Maven**
هنگامی که پروژه **Aspose.Slides Examples** را به IDE وارد می‌کنید، Maven به‌صورت خودکار فایل JAR aspose.slides را از [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) دانلود می‌کند. در صورتی که دسترسی به اینترنت ندارید، می‌توانید به‌صورت دستی JAR را به مخزن محلی خود اضافه کنید.

### **mvn install**
فایل [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) را دانلود، استخراج و فایل aspose.slides-version.jar را به مسیری دیگر (به‌عنوان مثال در درایو C) کپی کنید. سپس دستور زیر را اجرا کنید:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

حال فایل JAR **aspose.slides** در مخزن محلی Maven شما کپی شده است.

### **pom.xml**
بعد از نصب، کافی است مختصات **aspose.slides** را در pom.xml اعلان کنید. مخزن زیر را در تب repositories و وابستگی زیر را در تب dependencies اضافه کنید.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>26.10</version>
    <classifier>jdk8</classifier>
</dependency>
```

### **تمام شد**
پروژه را بسازید؛ اکنون فایل JAR **aspose.slides** می‌تواند از مخزن محلی Maven شما بازیابی شود.

## **مشارکت**
اگر مایل به افزودن یا بهبود یک نمونه هستید، شما را تشویق می‌کنیم که به پروژه کمک کنید. تمام نمونه‌ها و پروژه‌های نمایشی در این مخزن منبع باز هستند و می‌توانند به‌صورت آزاد در برنامه‌های شما استفاده شوند.

برای مشارکت می‌توانید مخزن را فورک کنید، کد منبع را ویرایش کنید و یک Pull Request ارسال کنید. ما تغییرات را بررسی کرده و در صورت مفید بودن، به مخزن اضافه خواهیم کرد.