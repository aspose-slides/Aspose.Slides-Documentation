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
- macOS
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بتثبيت Aspose.Slides for Java من مستودع Maven الخاص بـ Aspose أو كملف JAR، وقم بإعداد المتطلبات المسبقة لنظام Linux، وتحقق من التثبيت باستخدام برنامج أول."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إضافة Aspose.Slides for Java إلى مشروع. يتم نشر Aspose.Slides for Java في مستودع Maven الخاص بـ Aspose، وليس في Maven Central، لذا يجب على مشروع Maven أن يعلن عن هذا المستودع. يمكنك أيضًا تنزيل ملف JAR ووضعه على مسار الفئة بنفسك. كلا المسارين ينتهي ببرنامج قصير يثبت أن المكتبة تعمل.

لا يتطلب Aspose.Slides for Java وجود Microsoft PowerPoint. فهو يولد ملفات العرض التقديمي المطلوبة برمجياً. ومع ذلك، لعرض العروض التي تم إنشاؤها، قد تحتاج إلى Microsoft PowerPoint أو عارض عروض تقديمية آخر.

## **المتطلبات المسبقة**

- مجموعة تطوير جافا (JDK). يحتاج المشروع والأوامر في هذه المقالة إلى JDK 11 أو أحدث. في JDK 11، يطبع البرنامج الذي يتحقق من التثبيت تحذيراً يبدأ بعبارة "WARNING: An illegal reflective access operation has occurred"; لا يؤثر ذلك على النتيجة ويمكن تجاهله.
- [Apache Maven](https://maven.apache.org/install.html)، إذا كنت تستخدم مسار Maven.
- على Linux، مكتبة fontconfig وعلى الأقل خط واحد مثبت. راجع [Linux](#linux).

## **التثبيت من مستودع Maven**

تستضيف Aspose مكتبات Java الخاصة بها في [مستودع Maven](https://releases.aspose.com/java/repo/com/aspose/) الخاص بها. لاستخدام [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) في مشروع Maven، أضف مدخلين إلى *pom.xml* الخاص بك.

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
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

المصنف `jdk16` مطلوب: فهو يختار بنية Java SE للمكتبة. استبدل `26.9` بأحدث نسخة مدرجة في [المستودع](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). ينشر المستودع ملف تحقق SHA-1 بجانب كل JAR، والذي يتحقق منه Maven عند تنزيل المكتبة.

### **تحقق من التثبيت**

للتحقق من إعداد المشروع الجديد:

1. أنشئ مجلدًا للمشروع واحفظ هذا *pom.xml* داخله:

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

   بالإضافة إلى المستودع والتبعية، يحدد هذا *pom.xml* إصدار Java للترجمة، ويسمي الفئة التي ينفذها `mvn exec:java`، ويثبت إضافة المترجم، لأن الإضافة القديمة التي يستخدمها بعض تثبيتات Maven افتراضيًا تتجاهل إعداد `maven.compiler.release`.

2. احفظ المثال الأول في [Create Presentations](/slides/ar/java/create-presentation/) كملف *src/main/java/HelloSlides.java*.

3. في مجلد المشروع، نفّذ:

   ```bash
   mvn compile exec:java
   ```

يقوم Maven بتنزيل Aspose.Slides for Java، ويترجم البرنامج، ويشغّله. يقوم البرنامج بحفظ *new_presentation.pptx* في مجلد المشروع.

## **استخدام ملف JAR بدون Maven**

1. قم بتنزيل *aspose-slides-26.9-jdk16.jar* من [مجلد الإصدار](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) في المستودع. للحصول على نسخة أخرى، افتح مجلده في [المستودع](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) ونزل الملف الذي ينتهي بـ *-jdk16.jar*.

2. احفظ المثال الأول في [Create Presentations](/slides/ar/java/create-presentation/) كملف *HelloSlides.java* في نفس المجلد مع ملف JAR.

3. في ذلك المجلد، نفّذ:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

يقوم JDK بترجمة وتشغيل ملف المصدر الواحد، ويحفظ البرنامج *new_presentation.pptx* في المجلد. في تطبيقك الخاص، أضف ملف JAR إلى مسار الفئة في أداة البناء أو بيئة التطوير المتكاملة.

## **لينكس**

يستخدم Aspose.Slides for Java دعم الخطوط في Java، والذي على لينكس يحتاج إلى مكتبة fontconfig وعلى الأقل خط واحد مثبت. بدونهما، سيؤدي حفظ العرض إلى فشل مع الخطأ "Fontconfig head is null, check your fonts or fonts configuration". قد تفتقر صور الخوادم والحاويات الق Minimum إلى كليهما؛ على سبيل المثال، لا تتضمن صورة الحاوية الرسمية لـ Ubuntu أيًا منهما.

على Debian وUbuntu، يقوم هذا الأمر بتثبيت JDK وMaven وfontconfig وخطوط DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

يجب أيضًا تثبيت الخطوط المستخدمة في عروضك التقديمية، أو بدائل مناسبة، لتظهر النصوص بشكل صحيح.

## **الأسئلة الشائعة**

### كيف يمكنني التحقق من دمج Aspose.Slides بشكل صحيح؟

قم ببناء مشروعك، وأنشئ نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) فارغة، واحفظها باسم جديد. إذا تم إنشاء الملف دون رمي استثناءات، فقد تم دمج المكتبة بنجاح.

### كيف يمكنني تقليل استهلاك الذاكرة عند معالجة عروض تقديمية كبيرة؟

زد حدود ذاكرة JVM فقط إلى الحد المطلوب، واستدعِ [dispose](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#dispose--) على كل نسخة من [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) داخل كتلة `finally` لإخلاء الذاكرة بسرعة. يمنع هذا حدوث أخطاء نفاد الذاكرة ويحافظ على استهلاك الذاكرة الكلي متوقعًا أثناء عمليات الدفعات.

### هل يمكنني استبعاد صيغ تصدير غير مرغوب فيها لتقليل حجم ملف JAR النهائي؟

إصدارات Aspose.Slides الحالية تُوزّع كمكتبة موحدّة واحدة، لذا لا يمكنك إيقاف تشغيل مُصدّرات محددة مثل PDF أو SVG في وقت البناء.