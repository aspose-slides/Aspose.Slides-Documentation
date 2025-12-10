---
title: كيفية تشغيل الأمثلة
type: docs
weight: 140
url: /ar/java/how-to-run-the-examples/
keywords:
- أمثلة
- متطلبات البرامج
- GitHub
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بتشغيل أمثلة Aspose.Slides for Java بسرعة: استنسخ المستودع، استعد الحزم، ثم ابنِ واختبر الميزات لـ PPT و PPTX و ODP."
---

## **تنزيل Aspose.Slides من GitHub**
جميع أمثلة Aspose.Slides for Java مستضافة على [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). يمكنك إما استنساخ المستودع باستخدام عميل Github المفضل لديك أو تنزيل ملف ZIP من [هنا](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

استخرج محتويات ملف ZIP إلى أي مجلد على جهازك. جميع الأمثلة موجودة في مجلد **Examples**.

![todo:image_alt_text](examples_directory.png)

## **استيراد الأمثلة إلى IDE**
يستخدم المشروع نظام بنية Maven. يمكن لأي بيئة تطوير متكاملة حديثة فتح المشروع أو استيراده بسهولة بالإضافة إلى تبعياته. أدناه نوضح لك كيفية استخدام بيئات التطوير الشائعة لبناء وتشغيل الأمثلة.

### **IntelliJ IDEA**
انقر على قائمة **File** واختر **Open**. استعرض إلى مجلد المشروع وحدد ملف **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

سيتم فتح المشروع وتنزيل التبعيات تلقائيًا. من علامة التبويب Project، استعرض الأمثلة في مجلد **src/main/java**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر "Run .."، وسيتم تنفيذ المثال وعرض النتيجة في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
انقر على قائمة **File** واختر **Import**. حدد **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

استعرض إلى المجلد الذي استنساخته أو تنزيله من GitHub وحدد ملف **pom.xml**. سيُفتح المشروع وتُحمَّل التبعيات تلقائيًا. من علامة التبويب Package Explorer، استعرض الأمثلة في مجلد **src/main/java**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر **Run As** - **Java Application**، وسيُنفَّذ المثال وتُعرَض النتيجة في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
انقر على قائمة **File** واختر **Open Project**. استعرض إلى المجلد الذي استنساخته أو تنزيله من GitHub. ستظهر أيقونة مجلد **Examples** باعتبارها مشروع Maven. حدد Examples وافتحه.

![todo:image_alt_text](netbeans_openproject.png)

سيُفتح المشروع وتُحمَّل التبعيات تلقائيًا. من علامة التبويب Projects، استعرض الأمثلة في **source packages**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر **Run File**، وسيُنفَّذ المثال وتُعرَض النتيجة في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](netbeans_run_example.png)

## **إضافة مكتبة Aspose.Slides إلى مستودع Maven المحلي**
عند استيراد مشروع **Aspose.Slides Examples** إلى IDE، يقوم Maven بتنزيل ملف JAR الخاص بـ aspose.slides من [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). في حال عدم توفر اتصال بالإنترنت، يمكنك إضافة ملف JAR يدويًا إلى المستودع المحلي.

### **mvn install**
قم بتنزيل [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)، استخرج الملف وانسخ aspose.slides-<الإصدار>.jar إلى مكان آخر، على سبيل المثال إلى محرك C. نفّذ الأمر التالي:
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


الآن تم نسخ ملف JAR **aspose.slides** إلى مستودع Maven المحلي الخاص بك.

### **pom.xml**
بعد التثبيت، ما عليك سوى إعلان إحداثيات **aspose.slides** في pom.xml. أضف المستودع التالي في علامة التبويب repositories والاعتماد في علامة التبويب dependencies.
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
```


### **تم**
بناء المشروع، الآن يمكن استرداد ملف JAR **aspose.slides** من مستودع Maven المحلي الخاص بك.

## **المساهمة**
إذا رغبت في إضافة مثال أو تحسينه، نحثك على المساهمة في المشروع. جميع الأمثلة ومشاريع العرض في هذا المستودع مفتوحة المصدر ويمكن استخدامها بحرية في تطبيقاتك الخاصة.

للمساهمة، يمكنك عمل fork للمستودع، تعديل الشيفرة المصدرية وإرسال طلب سحب (Pull Request). سنراجع التغييرات ونضمّنها في المستودع إذا وجدناها مفيدة.