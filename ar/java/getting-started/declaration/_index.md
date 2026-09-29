---
title: متطلبات مدير الأمان
type: docs
weight: 190
url: /ar/java/declaration/
keywords:
- مدير الأمان
- سياسة الأمان
- AllPermission
- الأذونات
- صندوق الرمل
- JDK 24
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "ما هي أذونات مدير الأمان التي تحتاجها Aspose.Slides for Java والكود الذي يستدعيه على Java 23 والإصدارات السابقة، ولماذا لا يوجد ما يلزم تكوينه على Java 24 وما بعدها."
---
## **نظرة عامة**

يقوم مدير أمان Java بتقييد ما يمكن أن يفعله الكود وفقًا لسياسة أمان. تم إهمال هذه الميزة في Java 17 لتتم إزالتها لاحقًا ([JEP 411](https://openjdk.org/jeps/411))، وفي Java 24 تم تعطيلها نهائيًا ([JEP 486](https://openjdk.org/jeps/486)). يشرح هذا المقال ما تحتاجه Aspose.Slides for Java عندما لا يزال التطبيق يعمل مع مدير أمان. إذا لم يقم تطبيقك بتمكينه، وهو الإعداد الافتراضي، فلا شيء يحتاج إلى تكوين.

## **Java 23 والإصدارات السابقة**

عند تمكين مدير الأمان، يجب أن تسمح سياسة الأمان بالأذونات التالية لملف JAR الخاص بـ Aspose.Slides وللكود الذي يستدعيه:

- `java.util.PropertyPermission "*", "read"`: يقرأ Aspose.Slides خصائص النظام.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: يقرأ Aspose.Slides ملفات الخطوط وغيرها من الملفات.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: يبدأ Aspose.Slides برامج نظام التشغيل، مثل `reg` على Windows و`fc-match` على Linux.
- `java.io.FilePermission` مع الإجراء `write` للمجلدات التي يحفظ فيها تطبيقك الملفات.

منح الأذونات لملف JAR فقط غير كافٍ: يحتاج الكود الذي يستدعي Aspose.Slides إلى هذه الأذونات أيضًا. كذلك، يمكن منح `java.security.AllPermission` لكليهما.

بدون إذن لقراءة خصائص النظام أو لبدء البرامج، يفشل Aspose.Slides عند أول استخدام: إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) يرمي استثناء `ExceptionInInitializerError`. بدون إمكانية قراءة ملفات الخطوط، يفشل حفظ العرض كملف PDF مع الخطأ "Cannot find any fonts installed on the system".

## **Java 24 وما بعده**

لا يمكن تمكين مدير الأمان في Java 24 وما بعده، لذا لا توجد أذونات لتمنحها. يعمل Aspose.Slides بالأذونات الخاصة بالحساب الذي يشغل تطبيقك. لتقييد ما يمكن للتطبيق الوصول إليه، يوصي مشروع OpenJDK باستخدام تقنيات خارج الـ JDK، مثل الحاويات، والهايبرڤايزر، وميزات عزل نظام التشغيل. راجع [JEP 486](https://openjdk.org/jeps/486).

## **الأسئلة المتكررة**

**هل يمكنني استخدام Aspose.Slides في بيئة تشغّل التطبيقات تحت سياسة مدير أمان مقيدة؟**

فقط إذا كانت السياسة تمنح الأذونات المذكورة أعلاه لكل من Aspose.Slides والكود الذي يستدعيه. وتشمل هذه الأذونات قراءة جميع الملفات وبدء أي برنامج.