---
title: التثبيت
type: docs
weight: 70
url: /ar/java/installation/
keywords:
- تثبيت Aspose.Slides
- تنزيل Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- ويندوز
- لينكس
- ماك أو إس
- باوربوينت
- OpenDocument
- عرض تقديمي
- جافا
- Aspose.Slides
description: "قم بتثبيت Aspose.Slides for Java من مستودع Maven الخاص بـ Aspose أو كملف JAR، قم بإعداد المتطلبات الأساسية لنظام Linux، وتحقق من التثبيت باستخدام برنامج أول."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إضافة Aspose.Slides for Java إلى مشروع. يتم نشر Aspose.Slides for Java في مستودع Maven الخاص بـ Aspose، وليس في Maven Central، لذا يجب على مشروع Maven الإعلان عن ذلك المستودع. يمكنك أيضًا تنزيل ملف JAR ووضعه على مسار الفئات بنفسك. كلا المسارين ينتهيان ببرنامج قصير يؤكد أن المكتبة تعمل.

لا يتطلب Aspose.Slides for Java برنامج Microsoft PowerPoint. فهو يولد ملفات العرض التقديمي اللازمة برمجياً. ومع ذلك، لمشاهدة العروض التقديمية المُولَّدة قد تحتاج إلى Microsoft PowerPoint أو عارض عروض تقديمية آخر.

## **المتطلبات الأساسية**

- مجموعة تطوير جافا (JDK). يحتاج المشروع والأوامر في هذه المقالة إلى JDK 11 أو أحدث. في JDK 11، يطبع البرنامج الذي يتحقق من التثبيت تحذيرًا يبدأ بـ "WARNING: An illegal reflective access operation has occurred"; لا يؤثر ذلك على النتيجة ويمكن تجاهله.
- [أباتشي مافن](https://maven.apache.org/install.html), إذا كنت تستخدم مسار Maven.
- على نظام Linux، مكتبة fontconfig وعلى الأقل خط واحد مثبت. انظر [Linux](#linux).

## **التثبيت من مستودع Maven**

يستضيف Aspose مكتباته لجافا في [مستودع Maven](https://releases.aspose.com/java/repo/com/aspose/) الخاص به. لاستخدام [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) في مشروع Maven، أضف مدخلين إلى ملف *pom.xml* الخاص بك.

1. **الإعلان عن مستودع Maven الخاص بـ Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **إضافة تبعية Aspose.Slides for Java.**

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

المُصنِّف `jdk8` مطلوب: يحدِّد إصدار Java SE من المكتبة. استبدل `26.10` بأحدث إصدار مدرج في [المستودع](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). ينشر المستودع ملف SHA-1 checksum بجانب كل JAR، الذي يتحقق منه Maven عند تنزيل المكتبة.

### **التحقق من التثبيت**

للتحقق من الإعداد مع مشروع جديد:

1. أنشئ مجلدًا للمشروع واحفظ هذا *pom.xml* فيه:

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

   بالإضافة إلى المستودع والتبعية، يحدد هذا *pom.xml* إصدارة Java التي تُجمّع لها، ويسمّي الصنف الذي يُنفّذ `mvn exec:java`، ويثبت ملحق المجمِّع، لأن الملحق القديم الذي يستخدمه بعض تثبيات Maven بشكل افتراضي يتجاهل إعداد `maven.compiler.release`.

2. احفظ المثال الأول في [إنشاء عروض تقديمية](/slides/ar/java/create-presentation/) كملف *src/main/java/HelloSlides.java*.

3. في مجلد المشروع، شغّل:

   ```bash
   mvn compile exec:java
   ```

يقوم Maven بتنزيل Aspose.Slides for Java، يجمع البرنامج، ويشغّله. يحفظ البرنامج *new_presentation.pptx* في مجلد المشروع.

## **استخدام ملف JAR بدون Maven**

1. قم بتنزيل *aspose-slides-26.10-jdk8.jar* من [مجلد الإصدار](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) في المستودع. لإصدار آخر، افتح مجلده في [المستودع](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) وقم بتنزيل الملف الذي ينتهي بـ *-jdk8.jar*.

2. احفظ المثال الأول في [إنشاء عروض تقديمية](/slides/ar/java/create-presentation/) كملف *HelloSlides.java* في نفس المجلد الذي يوجد فيه ملف JAR.

3. في ذلك المجلد، شغّل:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

يقوم JDK بتجميع وتشغيل ملف المصدر الوحيد، ويحفظ البرنامج *new_presentation.pptx* في المجلد. في تطبيقك الخاص، أضف ملف JAR إلى مسار الفئات في أداة البناء أو بيئة التطوير المتكاملة الخاصة بك.

## **لينكس**

يستخدم Aspose.Slides for Java دعم الخطوط في جافا، والذي على لينكس يحتاج مكتبة fontconfig وعلى الأقل خط واحد مثبت. بدونهما، يفشل حفظ العرض التقديمي مع الخطأ "Fontconfig head is null, check your fonts or fonts configuration". قد تفتقر صور الخوادم والحاويات الأصغر إلى كليهما؛ على سبيل المثال، لا تحتوي صورة الحاوية الرسمية لـ Ubuntu على أي منهما.

على Debian وUbuntu، يقوم الأمر التالي بتثبيت JDK وMaven وfontconfig وخطوط DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

يجب أيضًا تثبيت الخطوط المستخدمة في عروضك التقديمية، أو بدائل مناسبة، لضمان عرض النص بشكل صحيح.

## **الأسئلة الشائعة**

### كيف يمكنني التحقق من أن Aspose.Slides مدمجة بشكل صحيح؟

بنِ مشروعك، أنشئ كائنًا فارغًا من نوع [العرض التقديمي](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) واحفظه باسم جديد. إذا تم إنشاء الملف دون إلقاء استثناءات، فقد تم دمج المكتبة بنجاح.

### كيف يمكنني تقليل استهلاك الذاكرة عند معالجة عروض تقديمية كبيرة؟

ارفع حدود ذاكرة JVM فقط إلى المستوى المطلوب، واستدعِ [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) على كل كائن من نوع [العرض التقديمي](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) داخل كتلة `finally` لتحرير الذاكرة مؤقتًا. يمنع ذلك أخطاء نفاد الذاكرة ويحافظ على استهلاك الذاكرة الكلي بشكل متوقع أثناء عمليات الدفعات.

### هل يمكنني استبعاد صيغ تصدير غير مرغوب فيها لتقليل حجم JAR النهائي؟

الإصدارات الحالية من Aspose.Slides تُوزَّع كمكتبة موحدة واحدة، لذا لا يمكنك تعطيل مُصدِّرات محددة مثل PDF أو SVG أثناء وقت البناء.