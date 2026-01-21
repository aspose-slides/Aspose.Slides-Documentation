---
title: كيف تشغّل الأمثلة
type: docs
weight: 140
url: /ar/java/how-to-run-the-examples/
keywords:
- أمثلة
- متطلبات البرنامج
- GitHub
- PowerPoint
- OpenDocument
- عرض
- Java
- Aspose.Slides
description: "تشغيل أمثلة Aspose.Slides for Java بسرعة: استنساخ المستودع، استعادة الحزم، ثم بناء واختبار الميزات لـ PPT، PPTX و ODP."
---

## **تنزيل Aspose.Slides من GitHub**
جميع أمثلة Aspose.Slides for Java مستضافة على [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). يمكنك إما استنساخ المستودع باستخدام عميل Github المفضل لديك أو تنزيل ملف ZIP من [هنا](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

استخرج محتويات ملف ZIP إلى أي مجلد على جهازك. جميع الأمثلة موجودة في مجلد **Examples**.

![todo:image_alt_text](examples_directory.png)

## **استيراد الأمثلة إلى IDE**
يستخدم المشروع نظام بناء Maven. يمكن لأي IDE حديث فتح أو استيراد المشروع واعتمادياته بسهولة. أدناه نوضح لك كيفية استخدام IDEs الشهيرة لبناء وتشغيل الأمثلة.

### **IntelliJ IDEA**
انقر على قائمة **File** واختر **Open**. تصفح إلى مجلد المشروع وحدد ملف **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

سيتم فتح المشروع وتنزيل الاعتماديات تلقائيًا. من علامة تبويب **Project**، تصفح الأمثلة في مجلد **src/main/java**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر "Run .."، سيتم تنفيذ المثال وسيتم عرض الناتج في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
انقر على قائمة **File** واختر **Import**. حدد **Maven** - مشاريع Maven الموجودة.

![todo:image_alt_text](eclipse_import.png)

تصفح إلى المجلد الذي استنسختَه أو حمّلته من GitHub وحدد ملف **pom.xml**. سيتم فتح المشروع وتنزيل الاعتماديات تلقائيًا. من علامة تبويب **Package Explorer**، تصفح الأمثلة في مجلد **src/main/java**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر **Run As** - **Java Application**، سيتم تنفيذ المثال وسيظهر الناتج في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
انقر على قائمة **File** واختر **Open Project**. تصفح إلى المجلد الذي استنسختَه أو حمّلته من GitHub. أيقونة مجلد **Examples** ستظهر أنه مشروع Maven. حدد **Examples** وافتحه.

![todo:image_alt_text](netbeans_openproject.png)

سيتم فتح المشروع وتنزيل الاعتماديات تلقائيًا. من علامة تبويب **Projects**، تصفح الأمثلة في **source packages**. لتشغيل مثال، انقر بزر الفأرة الأيمن على الملف واختر **Run File**، سيتم تنفيذ المثال وسيظهر الناتج في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](netbeans_run_example.png)

## **إضافة مكتبة Aspose.Slides إلى مستودع Maven المحلي**
عند استيراد مشروع **Aspose.Slides Examples** إلى IDE، يقوم Maven تلقائيًا بتنزيل ملف JAR الخاص بـ aspose.slides من [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). في حالة عدم توفر الإنترنت، يمكنك إضافة ملف JAR يدويًا إلى المستودع المحلي.

### **mvn install**
قم بتنزيل [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)، استخرج الملف وانسخ ملف aspose.slides-version.jar إلى موقع آخر، على سبيل المثال، قرص C. نفّذ الأمر التالي:
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


الآن، تم نسخ ملف JAR **aspose.slides** إلى مستودع Maven المحلي الخاص بك.

### **pom.xml**
بعد التثبيت، فقط أعلن عن إحداثيات **aspose.slides** في pom.xml. أضف المستودع التالي في علامة تبويب repositories واعتماد في علامة تبويب dependencies.
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


### **انتهى**
قم ببنائه، الآن يمكن استرجاع ملف JAR **aspose.slides** من مستودع Maven المحلي الخاص بك.

## **المساهمة**
إذا رغبت في إضافة مثال أو تحسينه، نشجعك على المساهمة في المشروع. جميع الأمثلة ومشاريع العرض في هذا المستودع مفتوحة المصدر ويمكن استخدامها بحرية في تطبيقاتك الخاصة.

للمساهمة، يمكنك تفرع المستودع، تعديل الكود المصدر وتقديم طلب سحب (Pull Request). سنقوم بمراجعة التغييرات وإدراجها في المستودع إذا كانت مفيدة.