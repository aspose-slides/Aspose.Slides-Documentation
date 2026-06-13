---
title: چگونه نمونه‌ها را اجرا کنیم
type: docs
weight: 140
url: /fa/java/how-to-run-the-examples/
keywords:
  - مثال‌ها
  - نیازمندی‌های نرم‌افزاری
  - GitHub
  - PowerPoint
  - OpenDocument
  - ارائه
  - Java
  - Aspose.Slides
description: "نمونه‌های Aspose.Slides برای Java را به‌سرعت اجرا کنید: مخزن را کلون کنید، بسته‌ها را بازیابی کنید، سپس ویژگی‌های PPT، PPTX و ODP را بسازید و تست کنید."
---
## **دانلود Aspose.Slides از GitHub**
تمام نمونه‌های Aspose.Slides برای Java در [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) میزبانی می‌شوند. می‌توانید مخزن را با استفاده از کلاینت مورد علاقهٔ GitHub خود کلون کنید یا فایل ZIP را از [این‌جا](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) دانلود کنید.

محتویات فایل ZIP را به هر پوشه‌ای در رایانه‌تان استخراج کنید. تمام نمونه‌ها در پوشه **Examples** قرار دارند.

![todo:image_alt_text](examples_directory.png)

## **وارد کردن نمونه‌ها به IDE**
این پروژه از سیستم ساخت Maven استفاده می‌کند. هر IDE مدرن می‌تواند به راحتی پروژه و وابستگی‌های آن را باز یا وارد کند. در ادامه نحوه استفاده از IDEهای محبوب برای ساخت و اجرای نمونه‌ها را نشان می‌دهیم.

### **IntelliJ IDEA**
بر روی منوی **File** کلیک کنید و **Open** را انتخاب کنید. به پوشه پروژه بروید و فایل **pom.xml** را انتخاب کنید.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

پروژه باز شده و وابستگی‌ها به‌صورت خودکار دانلود می‌شوند. از برگه Project، نمونه‌ها را در پوشه **src/main/java** مرور کنید. برای اجرای یک نمونه، روی فایل کلیک راست کنید و «Run ..» را انتخاب کنید؛ نمونه اجرا می‌شود و خروجی در پنجرهٔ داخلی کنسول نمایش داده می‌شود.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
بر روی منوی **File** کلیک کنید و **Import** را انتخاب کنید. گزینه **Maven** - Existing Maven Projects را برگزینید.

![todo:image_alt_text](eclipse_import.png)

به پوشه‌ای که مخزن را کلون یا دانلود کرده‌اید بروید و فایل **pom.xml** را انتخاب کنید. پروژه باز شده و وابستگی‌ها به‌صورت خودکار دانلود می‌شوند. از برگه Package Explorer، نمونه‌ها را در پوشه **src/main/java** مرور کنید. برای اجرای یک نمونه، روی فایل کلیک راست کنید و **Run As** - **Java Application** را انتخاب کنید؛ نمونه اجرا می‌شود و خروجی در پنجرهٔ داخلی کنسول نمایش داده می‌شود.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
بر روی منوی **File** کلیک کنید و **Open Project** را انتخاب کنید. به پوشه‌ای که مخزن را کلون یا دانلود کرده‌اید بروید. آیکون پوشه **Examples** نشان می‌دهد که یک پروژه Maven است. پوشه **Examples** را انتخاب و باز کنید.

![todo:image_alt_text](netbeans_openproject.png)

پروژه باز شده و وابستگی‌ها به‌صورت خودکار دانلود می‌شوند. از برگه Projects، نمونه‌ها را در **source packages** مرور کنید. برای اجرای یک نمونه، روی فایل کلیک راست کنید و **Run File** را انتخاب کنید؛ نمونه اجرا می‌شود و خروجی در پنجرهٔ داخلی کنسول نمایش داده می‌شود.

![todo:image_alt_text](netbeans_run_example.png)

## **افزودن کتابخانه Aspose.Slides به مخزن محلی Maven**
زمانی که پروژه **Aspose.Slides Examples** را به IDE وارد می‌کنید، Maven به‌صورت خودکار فایل JAR aspose.slides را از [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) دانلود می‌کند. در صورتی که دسترسی به اینترنت ندارید، می‌توانید JAR را به‌صورت دستی به مخزن محلی خود اضافه کنید.

### **mvn install**
فایل [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) را دانلود کنید، آن را استخراج کنید و فایل aspose.slides-version.jar را به مکانی دیگر، مثلاً در درایو C، کپی کنید. دستور زیر را اجرا کنید:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

اکنون فایل JAR **aspose.slides** به مخزن محلی Maven شما کپی شد.

### **pom.xml**
پس از نصب، کافی است مختصات **aspose.slides** را در pom.xml اعلام کنید. مخزن زیر را در تب repositories و وابستگی زیر را در تب dependencies اضافه کنید.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```

### **Done**
پروژه را بسازید؛ اکنون فایل JAR **aspose.slides** می‌تواند از مخزن محلی Maven شما بارگیری شود.

## **مشارکت**
اگر می‌خواهید یک نمونه را اضافه یا بهبود دهید، شما را تشویق می‌کنیم تا به پروژه مشارکت کنید. تمام نمونه‌ها و پروژه‌های نمایش در این مخزن منبع باز هستند و می‌توانید به‌صورت آزادانه در برنامه‌های خود استفاده کنید.

برای مشارکت، می‌توانید مخزن را fork کنید، کد منبع را ویرایش کنید و Pull Request ارسال کنید. ما تغییرات را بررسی کرده و در صورت مفید بودن، در مخزن گنجانده خواهند شد.