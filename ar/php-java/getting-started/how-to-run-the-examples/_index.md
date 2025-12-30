---
title: كيفية تشغيل الأمثلة
type: docs
weight: 140
url: /ar/php-java/how-to-run-the-examples/
keywords:
- أمثلة
- متطلبات البرنامج
- GitHub
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تشغيل أمثلة Aspose.Slides for PHP via Java بسرعة: استنساخ المستودع، استعادة الحزم، ثم بناء واختبار الميزات لملفات PPT و PPTX و ODP."
---

## **التنزيل من GitHub**
جميع أمثلة Aspose.Slides for PHP via Java مستضافة على [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). يمكنك إما استنساخ المستودع باستخدام عميل Github المفضل لديك أو تحميل ملف ZIP من [هنا](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

استخراج محتويات ملف ZIP إلى أي مجلد على حاسوبك. جميع الأمثلة موجودة في مجلد **Examples**.

![todo:image_alt_text](examples_directory.png)

## **استيراد الأمثلة إلى بيئة التطوير المتكاملة**
يستخدم المشروع نظام بناء Maven. يمكن لأي بيئة تطوير متكاملة حديثة فتح المشروع أو استيراده بسهولة بالإضافة إلى تبعياته. أدناه نوضح لك كيفية استخدام بيئات التطوير الشائعة لبناء وتشغيل الأمثلة.

### **IntelliJ IDEA**
انقر على القائمة **File** واختر **Open**. استعرض إلى مجلد المشروع واختر ملف **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

سيفتح المشروع ويقوم بتحميل التبعيات تلقائيًا. من علامة تبويب Project، استعرض الأمثلة في مجلد **src/main/java**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر "Run .."، سيتم تنفيذ المثال وسيتم عرض المخرجات في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
انقر على قائمة **File** واختر **Import**. حدد **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

استعرض إلى المجلد الذي استنسخته أو حملته من GitHub واختر ملف **pom.xml**. سيفتح المشروع ويحمّل التبعيات تلقائيًا. من علامة تبويب Package Explorer، استعرض الأمثلة في مجلد **src/main/java**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر **Run As** - **Java Application**، سيتم تنفيذ المثال وسيظهر الناتج في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
انقر على قائمة **File** واختر **Open Project**. استعرض إلى المجلد الذي استنسخته أو حمّلته من GitHub. أيقونة مجلد **Examples** ستظهر أنه مشروع Maven. اختر Examples وافتحه.

![todo:image_alt_text](netbeans_openproject.png)

سيفتح المشروع ويحمّل التبعيات تلقائيًا. من علامة تبويب Projects، استعرض الأمثلة في **source packages**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر **Run File**، سيتم تنفيذ المثال وسيظهر الناتج في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](netbeans_run_example.png)

## **إضافة مكتبة Aspose.Slides إلى مستودع Maven المحلي**
عند استيراد مشروع **Aspose.Slides Examples** إلى بيئة التطوير، يقوم Maven بتنزيل ملف JAR الخاص بـ aspose.slides تلقائيًا من [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). إذا لم يكن لديك اتصال بالإنترنت، يمكنك إضافة ملف JAR يدويًا إلى المستودع المحلي.

### **mvn install**
حمّل [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/)، استخرج الملف وانسخ aspose.slides-version.jar إلى مكان آخر، على سبيل المثال إلى محرك C. نفّذ الأمر التالي:
```php

```

mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```php

```


الآن، تم نسخ ملف JAR الخاص بـ **aspose.slides** إلى مستودع Maven المحلي الخاص بك.

### **pom.xml**
بعد التثبيت، قم ببساطة بإعلان إحداثيات **aspose.slides** في pom.xml. أضف المستودع التالي في علامة تبويب repositories واعتمد الاعتماد في علامة تبويب dependencies.
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

```


### **تم**
قم ببنائه، الآن يمكن استرجاع ملف JAR الخاص بـ **aspose.slides** من مستودع Maven المحلي الخاص بك.

## **المساهمة**
إذا رغبت في إضافة مثال أو تحسينه، نشجعك على المساهمة في المشروع. جميع الأمثلة ومشاريع العرض في هذا المستودع مفتوحة المصدر ويمكن استخدامها بحرية في تطبيقاتك الخاصة.

للمساهمة، يمكنك عمل fork للمستودع، تعديل الشيفرة المصدرية وتقديم طلب سحب (Pull Request). سنراجع التغييرات ونضيفها إلى المستودع إذا وجدناها مفيدة.