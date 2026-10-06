---
title: الأمان
type: docs
weight: 160
url: /ar/java/security/
keywords:
- أمان
- تبعيات
- مكونات الطرف الثالث
- Maven
- توقيع JAR
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استعراض كيفية معالجة Aspose.Slides for Java للعروض التقديمية، وما الذي يضيفه إلى تبعيات مشروعك، وكيفية التحقق من ملف JAR، وأي مكونات طرف ثالث يتضمنها."
---
## **المقدمة**

هذه المقالة تجمع المعلومات التي عادةً ما يحتاجها مراجعة الأمان لتطبيق يستخدم Aspose.Slides for Java: كيف تعالج المكتبة العروض التقديمية، ما الذي تضيفه إلى تبعيات مشروعك، كيفية التحقق من أن ملف JAR يأتي من Aspose، وأي مكونات طرف ثالث يحتويها ملف JAR.

## **الأمان في Aspose.Slides**

* يُستخدم Aspose.Slides for Java لإنشاء العروض التقديمية وتعديلها وتحويلها. لا يقوم بتشغيل السكريبتات داخل العروض. يقوم Aspose.Slides بتحليل بنية العرض ويسمح لبرمجيتك بالعمل مع نموذج الكائنات.
* يعمل Aspose.Slides كمكتبة تحلل وتفسر المستندات دون تنفيذ شفرة عن بُعد. جميع منتجات Aspose تعمل على أجهزتك ولا ترسل أي بيانات إلى Aspose. الاستثناء الوحيد هو [metered licensing](/slides/ar/java/metered-licensing/): إذا استخدمته، تُعالج فقط معلومات استخدام الـ API الخاصة بك.
* تُنفذ مكوّنات Aspose في نفس سياق المستخدم مثل التطبيقات العادية، لذا لا تُشكل خطرًا على موارد النظام الحيوية. بالإضافة إلى ذلك، عند فتح مكوّن Aspose لمستند، لا تُنفّذ الماكرو تلقائيًا.

## **اعتمادات Maven**

حزمة Maven الخاصة بـ Aspose.Slides for Java، `com.aspose:aspose-slides`، لا تعلن عن أي تبعيات: يحتوي ملف POM الخاص بها فقط على إحداثيات الحزمة نفسها. عند إضافتها إلى مشروع، يقوم Maven بإضافة ملف JAR هذا فقط ولا شيئًا آخر. لسرد جميع الحزم التي يحلها مشروعك، بما في ذلك التبعيات المتعاقبة، نفّذ الأمر التالي في مجلد المشروع:

```bash
mvn dependency:tree
```

في المشروع الموجود في [Installation](/slides/ar/java/installation/)، تُظهر المخرجات Aspose.Slides كالتبعية الوحيدة:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **تحقق من ملف JAR**

تُوقع Aspose ملف JAR. للتحقق من التوقيع، نفّذ أداة `jarsigner` من JDK في المجلد الذي يحتوي على ملف JAR:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

تطبع الأداة `jar verified.` عندما يكون التوقيع صالحًا ولم يتغير أي مدخل منذ توقيع الملف. لا تُظهر هذه الرسالة اسم المُوقع. لتأكيد أن Aspose هي التي وقعت الملف، أضف الخيارات `-verbose` و `-certs` وتأكد من أن شهادة المُوقع مُصدرة إلى `CN=ASPOSE PTY LTD`. عندما يقوم Maven بتحميل ملف JAR، يتحقق أيضًا من مجموع تحقق SHA-1 الذي ينشره المستودع بجانب الملف.

## **مكونات الطرف الثالث**

يتضمن Aspose.Slides for Java شفرة وبيانات من مكونات طرف ثالث. هي جزء من ملف JAR وليست حزم Maven منفصلة، لذا لا تُدرجها أدوات مثل `mvn dependency:tree` التي تقرأ تبعيات Maven. يحتوي ملف JAR على الإشعار *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*، الذي يسرد المكونات وتراخيصها:

| المكوّن | الترخيص المذكور في الإشعار |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

لاستخراج الإشعار من ملف JAR، نفّذ أداة `jar` من JDK في المجلد الذي يحتوي على ملف JAR:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **الأسئلة المتكررة**

**هل يستخدم Aspose.Slides for Java حزمًا خارجية؟**

ليس لديه تبعيات Maven، كما يُظهر قسم [اعتمادات Maven](#maven-dependencies)، لكنه يتضمن مكونات الطرف الثالث المذكورة في قسم [مكونات الطرف الثالث](#third-party-components). يجب تضمين كل من ملف JAR وهذه المكونات في مراجعة الأمان.

**هل يحتاج Aspose.Slides for Java إلى الوصول إلى الشبكة؟**

لا. إنشاء العروض، حفظها، وعرضها يعمل على نظام دون أي اتصال شبكة. الميزة الوحيدة التي تُرسل بيانات إلى Aspose هي [metered licensing](/slides/ar/java/metered-licensing/)، والتي تُبلغ عن استخدام الـ API.

**هل يحتوي Aspose.Slides for Java على شفرة أصلية؟**

لا. يحتوي ملف JAR فقط على فئات Java والموارد، لذا لا يضيف مكتبات أصلية إلى تطبيقك. على نظام Linux، تحتاج بيئة تشغيل Java إلى مكتبة fontconfig والخطوط من نظام التشغيل؛ راجع [System Requirements](/slides/ar/java/system-requirements/#linux).