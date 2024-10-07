---
title: كيفية تشغيل الأمثلة
type: docs
weight: 140
url: /java/how-to-run-the-examples/
---

## **تنزيل من جيثب**
جميع أمثلة Aspose.Slides لـ Java مستضافة على [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). يمكنك إما استنساخ المستودع باستخدام عميل جيثب المفضل لديك أو تنزيل ملف ZIP من [هنا](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

استخرج محتويات ملف ZIP إلى أي مجلد على جهاز الكمبيوتر الخاص بك. جميع الأمثلة موجودة في مجلد **Examples**.

![todo:image_alt_text](examples_directory.png)

## **استيراد الأمثلة إلى IDE**
يستخدم المشروع نظام بناء Maven. يمكن لأي IDE حديث فتح المشروع أو استيراده بسهولة مع الاعتمادات الخاصة به. أدناه نوضح لك كيفية استخدام IDEs الشائعة لبناء وتشغيل الأمثلة.

### **IntelliJ IDEA**
انقر على قائمة **ملف** واختر **فتح**. انتقل إلى مجلد المشروع وحدد ملف **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

سوف يفتح المشروع ويقوم بتنزيل الاعتمادات تلقائيًا. من علامة التبويب المشروع، انتقل إلى الأمثلة في مجلد **src/main/java**. لتشغيل مثال، فقط انقر بزر الفأرة الأيمن على الملف واختر "تشغيل .."، سيتم تنفيذ المثال وعرض المخرجات في نافذة إخراج وحدة التحكم المدمجة.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
انقر على قائمة **ملف** واختر **استيراد**. اختر **Maven** - مشاريع Maven الموجودة.

![todo:image_alt_text](eclipse_import.png)

انتقل إلى المجلد الذي قمت باستنساخه أو تنزيله من جيثب وحدد ملف **pom.xml**. سوف يفتح المشروع ويقوم بتنزيل الاعتمادات تلقائيًا. من علامة التبويب Package Explorer، انتقل إلى الأمثلة في مجلد **src/main/java**. لتشغيل مثال، فقط انقر بزر الفأرة الأيمن على الملف واختر **تشغيل كـ** - **تطبيق جافا**، سيتم تنفيذ المثال وعرض المخرجات في نافذة إخراج وحدة التحكم المدمجة.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
انقر على قائمة **ملف** واختر **فتح المشروع**. انتقل إلى المجلد الذي قمت باستنساخه أو تنزيله من جيثب. سيظهر أيقونة مجلد **Examples** لتفيد بأنه مشروع Maven. حدد Examples وافتحه.

![todo:image_alt_text](netbeans_openproject.png)

سوف يفتح المشروع ويقوم بتنزيل الاعتمادات تلقائيًا. من علامة التبويب المشاريع، انتقل إلى الأمثلة في **حزم المصدر**. لتشغيل مثال، فقط انقر بزر الفأرة الأيمن على الملف واختر **تشغيل الملف**، سيتم تنفيذ المثال وعرض المخرجات في نافذة إخراج وحدة التحكم المدمجة.

![todo:image_alt_text](netbeans_run_example.png)

## **إضافة مكتبة Aspose.Slides إلى مستودع Maven المحلي**
عندما تقوم باستيراد مشروع **أمثلة Aspose.Slides** إلى IDE، يقوم Maven تلقائيًا بتنزيل ملف JAR الخاص بـ aspose.slides من [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). في حالة عدم وجود اتصال بالإنترنت، يمكنك إضافة ملف JAR يدويًا إلى مستودعك المحلي.

### **mvn install**
قم بتنزيل [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)، استخرجه وانسخ ملف aspose.slides-version.jar إلى مكان آخر، على سبيل المثال، القرص C. نفذ الأمر التالي:

```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```

الآن، تم نسخ ملف JAR الخاص بـ **aspose.slides** إلى مستودع Maven المحلي لديك.

### **pom.xml**
بعد التثبيت، فقط أعلن عن إحداثيات **aspose.slides** في pom.xml. أضف المستودع التالي في علامة التبويب repositories والاعتماد في علامة التبويب dependencies.

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

### **انتهى**
قم ببناء المشروع، الآن يمكن استرداد ملف JAR الخاص بـ **aspose.slides** من مستودع Maven المحلي لديك.

## **مساهمات**
إذا كنت ترغب في إضافة أو تحسين مثال، نشجعك على المساهمة في المشروع. جميع الأمثلة والمشاريع النموذجية في هذا المستودع مفتوحة المصدر ويمكن استخدامها بحرية في تطبيقاتك الخاصة.

للمساهمة، يمكنك عمل فورك للمستودع، تحرير الشيفرة المصدرية وتقديم طلب ضم. سنقوم بمراجعة التغييرات وإدراجها في المستودع إذا وجدناها مفيدة.