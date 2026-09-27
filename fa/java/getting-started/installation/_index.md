---
title: نصب
type: docs
weight: 70
url: /fa/java/installation/
keywords:
- نصب Aspose.Slides
- دانلود Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "Aspose.Slides for Java را از مخزن Maven Aspose یا به صورت فایل JAR نصب کنید، پیش‌نیازهای لینوکس را تنظیم کنید، و نصب را با یک برنامهٔ اولیه بررسی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه Aspose.Slides for Java را به یک پروژه اضافه کنید. Aspose.Slides for Java در مخزن Maven خود Aspose منتشر می‌شود، نه در Maven Central، بنابراین یک پروژه Maven باید آن مخزن را اعلام کند. همچنین می‌توانید فایل JAR را دانلود کنید و خودتان آن را در مسیر کلاس قرار دهید. هر دو روش با یک برنامه کوتاه که کارکرد کتابخانه را تأیید می‌کند، پایان می‌یابند.

Aspose.Slides for Java نیازی به Microsoft PowerPoint ندارد. این کتابخانه به‌صورت برنامه‌نویسی فایل‌های ارائه موردنیاز را تولید می‌کند. با این حال، برای مشاهده ارائه‌های تولید شده ممکن است به Microsoft PowerPoint یا یک مشاهده‌گر ارائه دیگر نیاز داشته باشید.

## **پیش‌نیازها**

- یک کیت توسعه جاوا (JDK). پروژه و دستورات این مقاله به JDK 11 یا بالاتر نیاز دارند. در JDK 11، برنامه‌ای که نصب را بررسی می‌کند هشداری با متن «WARNING: An illegal reflective access operation has occurred» چاپ می‌کند؛ این هشدار بر نتیجه تأثیر نمی‌گذارد و می‌توان آن را نادیده گرفت.
- [Apache Maven](https://maven.apache.org/install.html) در صورتی که از مسیر Maven استفاده کنید.
- در لینوکس، کتابخانه fontconfig و حداقل یک قلم نصب شده. برای جزئیات بیشتر به بخش [Linux](#linux) نگاه کنید.

## **نصب از مخزن Maven**

Aspose کتابخانه‌های جاوای خود را در [مخزن Maven](https://releases.aspose.com/java/repo/com/aspose/) خود میزبانی می‌کند. برای استفاده از [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) در یک پروژه Maven، دو ورودی به *pom.xml* خود اضافه کنید.

1. **اعلام مخزن Maven Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **افزودن وابستگی Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

دسته‌بند `jdk16` لازم است: این دسته‌بند نسخه Java SE کتابخانه را انتخاب می‌کند. `26.9` را با آخرین نسخه موجود در [مخزن](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) جایگزین کنید. مخزن یک فایل checksum SHA‑1 در کنار هر JAR منتشر می‌کند که Maven هنگام دانلود کتابخانه آن را بررسی می‌کند.

### **بررسی نصب**

برای بررسی تنظیمات با یک پروژه جدید:

1. یک پوشه برای پروژه ایجاد کنید و این *pom.xml* را در آن ذخیره کنید:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   علاوه بر مخزن و وابستگی، این *pom.xml* نسخه Java را برای کامپایل تنظیم می‌کند، نام کلاس را که `mvn exec:java` اجرا می‌کند مشخص می‌سازد و افزونه کامپایلر را قفل می‌کند، چون افزونه قدیمی که بعضی نصب‌های Maven به‌صورت پیش‌فرض استفاده می‌کنند تنظیم `maven.compiler.release` را نادیده می‌گیرد.

2. مثال اول موجود در [Create Presentations](/slides/fa/java/create-presentation/) را به عنوان *src/main/java/HelloSlides.java* ذخیره کنید.

3. در پوشه پروژه، اجرا کنید:

   ```bash
   mvn compile exec:java
   ```

Maven Aspose.Slides for Java را دانلود، برنامه را کامپایل و اجرا می‌کند. برنامه *new_presentation.pptx* را در پوشه پروژه ذخیره می‌سازد.

## **استفاده از فایل JAR بدون Maven**

1. فایل *aspose-slides-26.9-jdk16.jar* را از [پوشه نسخه](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) در مخزن دانلود کنید. برای نسخه دیگر، پوشه آن را در [مخزن](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) باز کنید و فایل منتهی به *-jdk16.jar* را دانلود کنید.
2. مثال اول موجود در [Create Presentations](/slides/fa/java/create-presentation/) را به عنوان *HelloSlides.java* در همان پوشه‌ای که فایل JAR قرار دارد ذخیره کنید.
3. در همان پوشه، اجرا کنید:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK فایل منبع تک را کامپایل و اجرا می‌کند و برنامه *new_presentation.pptx* را در پوشه ذخیره می‌کند. در برنامهٔ خود، فایل JAR را به مسیر کلاس در ابزار ساخت یا IDE خود اضافه کنید.

## **Linux**

Aspose.Slides for Java از پشتیبانی قلم‌های جاوا استفاده می‌کند که در لینوکس به کتابخانه fontconfig و حداقل یک قلم نصب شده نیاز دارد. بدون این موارد، ذخیرهٔ یک ارائه با خطای «Fontconfig head is null, check your fonts or fonts configuration» شکست می‌خورد. تصاویر سرور و کانتینر حداقل ممکن ممکن است هر دو را نداشته باشند؛ به عنوان مثال، تصویر رسمی Ubuntu این دو را ندارد.

در Debian و Ubuntu، این فرمان یک JDK، Maven، fontconfig و قلم‌های DejaVu را نصب می‌کند:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

قلم‌های استفاده‌شده در ارائه‌های شما یا جایگزین‌های مناسب آن‌ها نیز باید برای رندر صحیح متن نصب شوند.

## **سؤالات متداول**

### چگونه می‌توانم تأیید کنم که Aspose.Slides به‌درستی یکپارچه شده است؟

پروژه‌تان را بسازید، یک شیء خالی [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) را نمونه‌سازی کنید و تحت نام جدیدی ذخیره کنید. اگر فایل بدون ایجاد استثنا ایجاد شد، کتابخانه با موفقیت یکپارچه شده است.

### چگونه می‌توانم مصرف حافظه را هنگام پردازش ارائه‌های بزرگ محدود کنم؟

محدودیت‌های حافظه JVM را فقط تا حدی که نیاز است افزایش دهید و در یک بلوک `finally` بر هر نمونه [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) متد [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) را صدا بزنید تا کش به‌سرعت آزاد شود. این کار از خطاهای کمبود حافظه جلوگیری می‌کند و استفاده کلی حافظه را در عملیات‌های دسته‌ای پیش‌بینی‌پذیر نگه می‌دارد.

### آیا می‌توانم فرمت‌های خروجی ناخواسته را حذف کنم تا اندازه نهایی JAR کوچک‌تر شود؟

نسخه‌های جاری Aspose.Slides به‌عنوان یک کتابخانه تک‌پیکره توزیع می‌شوند، بنابراین نمی‌توانید در زمان ساخت Exporterهای خاصی مانند PDF یا SVG را غیرفعال کنید.