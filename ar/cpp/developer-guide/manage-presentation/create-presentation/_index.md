---
title: إنشاء عرض تقديمي - واجهة برمجة تطبيقات PowerPoint لـ C++
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/cpp/create-presentation/
description: لإنشاء عرض تقديمي في واجهة برمجة تطبيقات PowerPoint لـ C++، يرجى اتباع الخطوات المذكورة في هذه المقالة. يقوم الكود بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
---

## **إنشاء عرض تقديمي لـ PowerPoint**
لإضافة خط بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. احصل على مرجع شريحة باستخدام فهرسها.
1. أضف شكل تلقائي من نوع خط باستخدام طريقة AddAutoShape المعروضة بواسطة كائن Shapes.
1. اكتب العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}