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
description: "تشغيل أمثلة Aspose.Slides لـ Java بسرعة: استنساخ المستودع، استعادة الحزم، ثم بناء واختبار الميزات لملفات PPT و PPTX و ODP."
---
## **تنزيل Aspose.Slides من GitHub**
جميع أمثلة Aspose.Slides لـ Java مستضافة على [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). يمكنك إما استنساخ المستودع باستخدام عميل Github المفضل لديك أو تنزيل ملف ZIP من [من هنا](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

استخرج محتويات ملف ZIP إلى أي مجلد على جهازك. جميع الأمثلة موجودة في المجلد **Examples**.

![todo:image_alt_text](examples_directory.png)

## **استيراد الأمثلة إلى IDE**
يستخدم المشروع نظام بناء Maven. أي بيئة تطوير حديثة يمكنها بسهولة فتح أو استيراد المشروع واعتماداته. أدناه نوضح لك كيفية استخدام بيئات التطوير الشائعة لبناء وتشغيل الأمثلة.

### **IntelliJ IDEA**
انقر على قائمة **File** واختر **Open**. استعرض إلى مجلد المشروع وحدد ملف **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

سيفتح المشروع ويقوم بتنزيل الاعتماديات تلقائيًا. من علامة تبويب Project، استعرض الأمثلة في مجلد **src/main/java**. لتشغيل مثال، انقر بزر الماوس الأيمن على الملف واختر "Run .."، سيتم تنفيذ المثال وعرض الناتج في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
انقر على قائمة **File** واختر **Import**. حدد **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

استعرض إلى المجلد الذي استننسخته أو حمّلته من GitHub وحدد ملف **pom.xml**. سيفتح المشروع ويقوم بتنزيل الاعتماديات تلقائيًا. من علامة تبويب Package Explorer، استعرض الأمثلة في مجلد **src/main/java**. لتشغيل مثال، انقر بزر الماوس الأيمن على الملف واختر **Run As** - **Java Application**، سيتم تنفيذ المثال وعرض الناتج في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
انقر على قائمة **File** واختر **Open Project**. استعرض إلى المجلد الذي استننسخته أو حمّلته من GitHub. سيظهر أيقونة مجلد **Examples** بأنه مشروع Maven. حدد **Examples** وافتحه.

![todo:image_alt_text](netbeans_openproject.png)

سيفتح المشروع ويقوم بتنزيل الاعتماديات تلقائيًا. من علامة تبويب Projects، استعرض الأمثلة في **source packages**. لتشغيل مثال، انقر بزر الماوس الأيمن على الملف واختر **Run File**، سيتم تنفيذ المثال وعرض الناتج في نافذة وحدة التحكم المدمجة.

![todo:image_alt_text](netbeans_run_example.png)

## **إضافة مكتبة Aspose.Slides إلى مستودع Maven المحلي**
عند استيراد مشروع **Aspose.Slides Examples** إلى IDE، يقوم Maven تلقائيًا بتنزيل ملف JAR الخاص بـ aspose.slides من [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). إذا لم يتوفر اتصال بالإنترنت، يمكنك إضافة ملف JAR يدويًا إلى المستودع المحلي.

### **mvn install**
قم بتنزيل [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)، استخرجه وانسخ ملف aspose.slides-version.jar إلى موقع آخر، على سبيل المثال، محرك C. نفذ الأمر التالي:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

الآن، تم نسخ ملف jar **aspose.slides** إلى مستودع Maven المحلي الخاص بك.

### **pom.xml**
بعد التثبيت، قم فقط بإعلان إحداثيات **aspose.slides** في pom.xml. أضف المستودع التالي في علامة تبويب repositories واعتماد في علامة تبويب dependencies.

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

### **انتهى**
ابنِ المشروع، الآن يمكن الحصول على ملف jar **aspose.slides** من مستودع Maven المحلي الخاص بك.

## **المساهمة**
إذا رغبت في إضافة مثال أو تحسينه، نشجعك على المساهمة في المشروع. جميع الأمثلة ومشاريع العرض في هذا المستودع مفتوحة المصدر ويمكن استخدامها بحرية في تطبيقاتك الخاصة.

للمساهمة، يمكنك تفرع المستودع، تعديل الشيفرة المصدرية وإرسال طلب سحب (Pull Request). سنراجع التغييرات ونُدرجها في المستودع إذا وجدت مفيدة.