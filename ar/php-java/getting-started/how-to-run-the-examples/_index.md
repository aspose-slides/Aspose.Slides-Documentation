---
title: كيفية تشغيل الأمثلة
type: docs
weight: 140
url: /ar/php-java/how-to-run-the-examples/
---

## **التنزيل من GitHub**
جميع أمثلة Aspose.Slides ل PHP عبر Java مستضافة على [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). يمكنك إما استنساخ المستودع باستخدام عميل Github المفضل لديك أو تنزيل ملف ZIP من [هنا](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

استخرج محتويات ملف ZIP إلى أي مجلد على الكمبيوتر الخاص بك. جميع الأمثلة موجودة في مجلد **الأمثلة**.

![todo:image_alt_text](examples_directory.png)

## **استيراد الأمثلة إلى IDE**
يستخدم المشروع نظام بناء Maven. يمكن لأي IDE حديث فتح أو استيراد المشروع واعتماده بسهولة. أدناه نوضح لك كيفية استخدام IDEs الشائعة لبناء وتشغيل الأمثلة.

### **IntelliJ IDEA**
انقر على قائمة **ملف** واختر **فتح**. انتقل إلى مجلد المشروع وحدد ملف **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

سيقوم بفتح المشروع وتنزيل الاعتمادات تلقائيًا. من علامة تبويب المشروع، تصفح الأمثلة في مجلد **src/main/java**. لتشغيل مثال، اضغط بزر الماوس الأيمن على الملف واختر "تشغيل .."، سيتم تنفيذ المثال وسيظهر الإخراج في نافذة إخراج وحدة التحكم المدمجة.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
انقر على قائمة **ملف** واختر **استيراد**. اختر **Maven** - مشاريع Maven الموجودة.

![todo:image_alt_text](eclipse_import.png)

انتقل إلى المجلد الذي قمت باستنساخه أو تنزيله من GitHub وحدد ملف **pom.xml**. سيقوم بفتح المشروع وتنزيل الاعتمادات تلقائيًا. من علامة تبويب Explorer الحزم، تصفح الأمثلة في مجلد **src/main/java**. لتشغيل مثال، اضغط بزر الماوس الأيمن على الملف واختر **تشغيل كـ** - **تطبيق Java**، سيتم تنفيذ المثال وسيظهر الإخراج في نافذة إخراج وحدة التحكم المدمجة.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
انقر على قائمة **ملف** واختر **فتح مشروع**. انتقل إلى المجلد الذي قمت باستنساخه أو تنزيله من GitHub. ستظهر أيقونة مجلد **الأمثلة** أنه مشروع Maven. حدد الأمثلة وافتحها.

![todo:image_alt_text](netbeans_openproject.png)

سيقوم بفتح المشروع وتنزيل الاعتمادات تلقائيًا. من علامة تبويب المشاريع، تصفح الأمثلة في **حزم المصدر**. لتشغيل مثال، اضغط بزر الماوس الأيمن على الملف واختر **تشغيل الملف**، سيتم تنفيذ المثال وسيظهر الإخراج في نافذة إخراج وحدة التحكم المدمجة.

![todo:image_alt_text](netbeans_run_example.png)

## **إضافة مكتبة Aspose.Slides إلى مستودع Maven المحلي**
عند استيراد مشروع **أمثلة Aspose.Slides** إلى IDE، تقوم Maven تلقائيًا بتنزيل ملف JAR الخاص بـ aspose.slides من [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). في حال لم يكن لديك وصول إلى الإنترنت، يمكنك إضافة JAR يدويًا إلى المستودع المحلي الخاص بك.

### **mvn install**
قم بتنزيل [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/)، واستخراجه ونسخ aspose.slides-version.jar إلى مكان آخر، على سبيل المثال، القرص C. قم بإصدار الأمر التالي:

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

الآن، يتم نسخ JAR **aspose.slides** إلى مستودع Maven المحلي الخاص بك.

### **pom.xml**
بعد التثبيت، فقط اعلن عن إحداثيات **aspose.slides** في pom.xml. أضف المستودع التالي في علامة تبويب المستودعات والاعتماد في علامة تبويب الاعتمادات.

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
قم ببنائها، الآن يمكن استرجاع JAR **aspose.slides** من مستودع Maven المحلي الخاص بك.

## **المساهمة**
إذا كنت ترغب في إضافة أو تحسين مثال، نشجعك على المساهمة في المشروع. جميع الأمثلة ومشاريع العرض التوضيحي في هذا المستودع مفتوحة المصدر ويمكن استخدامها بحرية في تطبيقاتك الخاصة.

للمساهمة، يمكنك عمل Fork للمستودع، تحرير الشيفرة المصدرية وتقديم طلب سحب. سنقوم بمراجعة التغييرات وإدراجها في المستودع إذا تم اعتبارها مفيدة.