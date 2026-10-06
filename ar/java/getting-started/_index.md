---
title: البدء
type: docs
weight: 10
url: /ar/java/getting-started/
keywords:
- البدء
- متطلبات النظام
- التثبيت
- العرض التقديمي الأول
- Maven
- معالجة PPT
- معالجة PPTX
- معالجة ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "المسار من مشروع Java جديد إلى أول عرض تقديمي محفوظ باستخدام Aspose.Slides: تحقق من المتطلبات، أضف المكتبة من مستودع Maven الخاص بـ Aspose، شغّل البرنامج الأول، واستمر في تنفيذ المهام الشائعة."
---
## **نظرة عامة**

اتبع الخطوات الأربعة أدناه بالترتيب. كل خطوة تسمي ما يجب عمله وتربط المقالة بالتفاصيل. يتم تغطية التقييم والترخيص والدعم بعد الخطوات.

## **الخطوة 1: التحقق من متطلبات النظام**

Aspose.Slides for Java هو ملف JAR واحد بدون كود أصلي، لذا يعمل على أي نظام تشغيل يحتوي على بيئة تشغيل Java مدعومة. [متطلبات النظام](/slides/ar/java/system-requirements/) تُدرج أنظمة التشغيل وإصدارات Java المدعومة. يتطلب المشروع والأوامر في الخطوات التالية JDK 11 أو أحدث، ولطريق Maven، [Apache Maven](https://maven.apache.org/install.html).

## **الخطوة 2: إضافة المكتبة إلى مشروعك**

Aspose.Slides for Java تُنشر في مستودع Maven الخاص بـ Aspose، وليس في Maven Central. اختر أحد هذه الطرق:

- مع Maven: أعلن عن المستودع `https://releases.aspose.com/java/repo/` في ملف *pom.xml* الخاص بك وأضف الاعتماد `com.aspose:aspose-slides` مع المصنف `jdk16`.
- بدون Maven: قم بتنزيل ملف JAR الذي ينتهي اسمه بـ *-jdk16.jar* من المستودع وضعه في مسار الفئة.

على نظام Linux، قم أيضاً بتثبيت مكتبة fontconfig وعلى الأقل خطًا واحدًا. بدونها، فشل حفظ العرض التقديمي مع الخطأ "Fontconfig head is null, check your fonts or fonts configuration".

[التثبيت](/slides/ar/java/installation/) يعطي إدخالات *pom.xml*، وتنزيل JAR، وأمر Linux.

## **الخطوة 3: إنشاء العرض التقديمي الأول لك**

[دليل البدء السريع على الصفحة الرئيسية لـ Aspose.Slides for Java](/slides/ar/java/#your-first-presentation) هو مشروع Maven كامل: ملف *pom.xml* وبرنامج يضيف شكل سحابة مع نص إلى شريحة ويحفظ العرض التقديمي كملف PPTX. تقوم بتشغيله باستخدام `mvn compile exec:java`. [إنشاء العروض التقديمية](/slides/ar/java/create-presentation/) يشرح نفس البرنامج خطوة بخطوة. لفتح عرض تقديمي موجود وحفظه بصيغة أخرى، راجع [فتح العروض التقديمية](/slides/ar/java/open-presentation/) و[حفظ العروض التقديمية](/slides/ar/java/save-presentation/).

## **الخطوة 4: المتابعة بمهام شائعة**

- [فتح عرض تقديمي](/slides/ar/java/open-presentation/)
- [حفظ عرض تقديمي](/slides/ar/java/save-presentation/)
- [تحويل عرض تقديمي إلى PDF](/slides/ar/java/convert-powerpoint-to-pdf/)
- [تحويل الشرائح إلى صور](/slides/ar/java/convert-slide/)
- [تحرير نص العرض التقديمي](/slides/ar/java/manage-text/)
- [أمثلة حسب عنصر الشريحة](/slides/ar/java/examples/)

## **التقييم والترخيص**

بدون ترخيص، يعمل Aspose.Slides في وضع التقييم: يضيف علامة مائية إلى كل شريحة يتم حفظها ويقص النص الذي يقرأه الكود الخاص بك من العروض التقديمية.

- [تقييم Aspose.Slides](/slides/ar/java/evaluate-aspose-slides/) يصف حدود التقييم وكيفية طلب ترخيص مؤقت.
- [الترخيص](/slides/ar/java/licensing/) يوضح كيفية تطبيق ترخيص من ملف أو تدفق.
- [الترخيص القائم على الاستخدام](/slides/ar/java/metered-licensing/) يغطي الترخيص الذي يُفوتر حسب الاستخدام.
- [تنسيقات الملفات المدعومة](/slides/ar/java/supported-file-formats/) تُدرج الصيغ التي يمكن لـ Aspose.Slides تحميلها وحفظها.

## **الحصول على المساعدة**

[الدعم الفني](/slides/ar/java/technical-support/) يشرح كيفية طرح سؤال على [منتدى الدعم المجاني](https://forum.aspose.com/c/slides/ar/11) وما يجب تضمينه عندما تبلغ عن مشكلة.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint؟**

لا. يقوم Aspose.Slides بقراءة وكتابة ملفات العروض التقديمية بنفسه ولا يستخدم PowerPoint، لذا فهو يعمل أيضًا على الخوادم وعلى Linux.

**لماذا لا يستطيع Maven العثور على Aspose.Slides for Java؟**

المكتبة ليست في Maven Central. أعلن عن مستودع Aspose في ملف *pom.xml* الخاص بك، كما هو موضح في [التثبيت](/slides/ar/java/installation/)، ثم يقوم Maven بتنزيل المكتبة من هناك.

**هل يعني المصنف `jdk16` أن المكتبة تحتاج إلى Java 16؟**

لا. يحدد المصنف نسخة Java SE من المكتبة؛ النسخة الأخرى مخصصة لـ Android. نفس النسخة تعمل على إصدارات JDK الحالية، مثل JDK 21.