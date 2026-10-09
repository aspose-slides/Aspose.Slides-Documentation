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
- ویندوز
- لینوکس
- macOS
- PowerPoint
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "Aspose.Slides for Java را از مخزن Maven Aspose یا به‌صورت فایل JAR نصب کنید، پیش‌نیازهای لینوکس را تنظیم کنید و نصب را با برنامهٔ اولیه بررسی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه Aspose.Slides for Java را به یک پروژه اضافه کنید. Aspose.Slides for Java در مخزن Maven اختصاصی Aspose منتشر می‌شود و در Maven Central موجود نیست، بنابراین یک پروژه Maven باید آن مخزن را اعلام کند. شما همچنین می‌توانید فایل JAR را دانلود کنید و به‌صورت دستی به مسیر کلاس اضافه کنید. هر دو مسیر در نهایت با یک برنامه کوتاه که تأیید می‌کند کتابخانه کار می‌کند، پایان می‌یابند.

Aspose.Slides for Java نیازی به Microsoft PowerPoint ندارد. این کتابخانه به‌صورت برنامه‌ای فایل‌های ارائه لازم را تولید می‌کند. اما برای مشاهده ارائه‌های تولید شده ممکن است به Microsoft PowerPoint یا یک نمایشگر ارائه دیگر نیاز داشته باشید.

## **پیش‌نیازها**

- یک کیت توسعه جاوا (JDK). پروژه و دستورات این مقاله به JDK 11 یا بالاتر نیاز دارند. در JDK 11، برنامه‌ای که نصب را بررسی می‌کند هشدار «WARNING: An illegal reflective access operation has occurred» را چاپ می‌کند؛ این هشدار بر نتیجه تأثیری ندارد و می‌توان آن را نادیده گرفت.
- [Apache Maven](https://maven.apache.org/install.html)، اگر از مسیر Maven استفاده می‌کنید.
- در لینوکس، کتابخانه fontconfig و حداقل یک فونت نصب‌شده. برای جزئیات بیشتر به بخش [Linux](#linux) مراجعه کنید.

## **نصب از مخزن Maven**

Aspose کتابخانه‌های جاوای خود را در [مخزن Maven خود](https://releases.aspose.com/java/repo/com/aspose/) میزبانی می‌کند. برای استفاده از [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) در یک پروژه Maven، دو ورودی به *pom.xml* خود اضافه کنید.

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
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

طبقه‌بند `jdk8` ضروری است: این مقدار نسخه Java SE کتابخانه را انتخاب می‌کند. `26.10` را با آخرین نسخه موجود در [مخزن](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) جایگزین کنید. مخزن یک فایل checksum نوع SHA‑1 در کنار هر JAR منتشر می‌کند که Maven هنگام دانلود کتابخانه آن را بررسی می‌کند.

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   به جز مخزن و وابستگی، این *pom.xml* نسخه Java را برای کامپایل تنظیم می‌کند، کلاس مورد اجرا توسط `mvn exec:java` را نام‌گذاری می‌کند و پلاگین کامپایلر را ثابت می‌کند، زیرا پلاگین قدیمی‌تری که برخی نصب‌های Maven به‌صورت پیش‌فرض استفاده می‌کنند، تنظیم `maven.compiler.release` را نادیده می‌گیرد.

2. مثال اول را در [Create Presentations](/slides/fa/java/create-presentation/) به عنوان *src/main/java/HelloSlides.java* ذخیره کنید.

3. در پوشه پروژه، اجرا کنید:

   ```bash
   mvn compile exec:java
   ```

Maven Aspose.Slides for Java را دانلود می‌کند، برنامه را کامپایل می‌کند و اجرا می‌گیرد. برنامه فایل *new_presentation.pptx* را در پوشه پروژه ذخیره می‌کند.

## **استفاده از فایل JAR بدون Maven**

1. فایل *aspose-slides-26.10-jdk8.jar* را از [پوشه نسخه](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) در مخزن دانلود کنید. برای نسخه دیگر، پوشهٔ مربوطه را در [مخزن](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) باز کنید و فایلی که با *-jdk8.jar* پایان می‌یابد را دانلود کنید.
2. مثال اول را در [Create Presentations](/slides/fa/java/create-presentation/) به عنوان *HelloSlides.java* در همان پوشهٔ فایل JAR ذخیره کنید.
3. در همان پوشه، اجرا کنید:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK فایل منبع تک را کامپایل و اجرا می‌کند و برنامه *new_presentation.pptx* را در پوشه ذخیره می‌سازد. در برنامهٔ خود، فایل JAR را به مسیر کلاس در ابزار ساخت یا IDE خود اضافه کنید.

## **Linux**

Aspose.Slides for Java از پشتیبانی فونت‌های Java استفاده می‌کند که در لینوکس به کتابخانه fontconfig و حداقل یک فونت نصب‌شده نیاز دارد. بدون این‌ها ذخیرهٔ ارائه با خطای «Fontconfig head is null, check your fonts or fonts configuration» شکست می‌خورد. تصاویر سرویس‌دهنده و کانتینرهای مینیمال ممکن است هر دو را نداشته باشند؛ برای مثال، تصویر رسمی کانتینر Ubuntu هیچ‌یک از این موارد را شامل نمی‌شود.

در Debian و Ubuntu، این دستور یک JDK، Maven، fontconfig و فونت‌های DejaVu را نصب می‌کند:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

فونت‌هایی که در ارائه‌های شما استفاده می‌شوند یا جایگزین‌های مناسب آن‌ها نیز باید نصب شوند تا متن به‌درستی رندر شود.

## **FAQ**

### چگونه می‌توانم تأیید کنم که Aspose.Slides به‌درستی یکپارچه شده است؟

پروژه خود را بسازید، یک شیء خالی از نوع [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و آن را با نام جدیدی ذخیره کنید. اگر فایل بدون استثنای خطا ایجاد شد، کتابخانه با موفقیت یکپارچه شده است.

### چگونه می‌توانم مصرف حافظه را هنگام پردازش ارائه‌های بزرگ محدود کنم؟

حدود حافظه JVM را فقط به‌اندازهٔ لازم افزایش دهید و در یک بلوک `finally` بر هر نمونهٔ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) متد [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) را فراخوانی کنید تا کش به‌سرعت آزاد شود. این کار از خطاهای کمبود حافظه جلوگیری می‌کند و مصرف کلی حافظه را در عملیات دسته‑ای می‌تواند پیش‌بینی‌پذیر نگه دارد.

### آیا می‌توانم قالب‌های خروجی غیرضروری را حذف کنم تا اندازهٔ نهایی JAR کوچک‌تر شود؟

نسخه‌های فعلی Aspose.Slides به‌صورت یک کتابخانهٔ تک‌تکه ارائه می‌شوند، بنابراین نمی‌توانید خروجی‌های خاص مانند PDF یا SVG را در زمان ساخت غیرفعال کنید.