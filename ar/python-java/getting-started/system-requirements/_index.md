---
title: متطلبات النظام
type: docs
weight: 60
url: /ar/python-java/system-requirements/
keywords:
- متطلبات النظام
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "تحقق من متطلبات نظام التشغيل، Python، Java، و JPype لتشغيل Aspose.Slides for Python via Java على أنظمة Windows و Linux و macOS."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يُنشئ، يعدّل، يحوّل، ويعرض العروض التقديمية دون الحاجة إلى تثبيت Microsoft PowerPoint. يستخدم JPype للوصول إلى مكتبة Java من Python، لذا يجب أن يدعم البيئة كلًّا من Python و Java و JPype معًا.

## **أنظمة التشغيل المدعومة**

يدعم [حزمة Aspose.Slides](https://pypi.org/project/aspose-slides-java/) عائلات أنظمة التشغيل التالية:

- Windows
- Linux
- macOS

اختر نسخة نظام التشغيل التي يدعمها إصدارات Python و Java و JPype التي حددتها. مجرد توفر Java لا يضمن التوافق مع حزمة Python وجسرها.

## **متطلبات Python و Java و JPype**

| المكوّن | المتطلب |
| --- | --- |
| Python | تعلن حزمة Aspose.Slides عن دعم Python 3.7 إلى 3.14. يجب أن يدعم إصدار JPype المختار نفس نسخة Python؛ على سبيل المثال، [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) يتطلب Python 3.8 أو أحدث. |
| Java | ثبّت بيئة تشغيل Java أو JDK متوافقة مع إصدار JPype المختار. توضح [متطلبات JPype الحالية](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) أن Java 11 أو أحدث مطلوب. لا يمكن لـ Java 8 تشغيل JPype1 1.7.1. |
| JPype | ثبّت حزمة JPype1 لمفسّر Python الخاص بك، نظام التشغيل، وبنية المعالج. |
| بنية المعالج | يجب أن تستخدم كل من Python و Java Virtual Machine (JVM) بنية متطابقة. على سبيل المثال، مفسّر Python 64‑بت يتطلب JVM 64‑بت متوافق. |

على Apple Silicon، يجب أن يستخدم كل من Python و Java إما ARM64 أو كلاهما x64. قد يفشل تحميل JVM عبر JPype إذا كانت بنيته مختلفة عن بنية Python، حتى وإن كان يعمل بشكل مستقل.

لبناء بيئة جديدة، يعتبر Python 3.12 و JDK 17 و JPype1 1.7.1 نقطة انطلاق مناسبة. تم التحقق من هذا التكوين مع Aspose.Slides for Python via Java 26.6.0 على Windows. يجب على التركيبات الأخرى أن تلبي متطلبات المكوّنات الثلاثة.

لإعداد البيئة ومثال التحقق العملي، راجع [التثبيت](/slides/ar/python-java/installation/).

## **الاعتمادات الإضافية**

العجلة المجمعة مسبقًا المتوافقة مع JPype لا تتطلب مترجم C++. إذا كان لا بد من بناء JPype من المصدر، فقم بتثبيت مترجم C++ متوافق وملفات تطوير Python المطلوبة لمنصتك. راجع [تعليمات تثبيت JPype](https://jpype.readthedocs.io/en/latest/install.html) لمعرفة متطلبات البناء وحل المشكلات.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint؟**

لا. يقوم Aspose.Slides بمعالجة العروض التقديمية بشكل مستقل عن PowerPoint. لا يزال يتطلب Python و Java و JPype.

**هل يمكنني استخدام Python 3.7 مع أي إصدار من JPype؟**

لا. على الرغم من أن حزمة Aspose.Slides تعلن عن دعم Python 3.7، يتطلب JPype1 1.7.1 Python 3.8 أو أحدث. اختر الإصدارات التي تتقاطع متطلباتها.

**هل يمكنني خلط Python 32‑بت مع Java 64‑بت؟**

لا. يقوم JPype بتحميل JVM داخل عملية Python، لذا يجب أن تكون بنية Python و Java متطابقة. ينطبق نفس المتطلب على ARM64 و x64 في macOS.