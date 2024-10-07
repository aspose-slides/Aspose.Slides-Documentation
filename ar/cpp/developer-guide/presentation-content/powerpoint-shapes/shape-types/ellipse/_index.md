---
title: بيضاوية
type: docs
weight: 30
url: /cpp/ellipse/
---

## **إنشاء بيضاوية**
في هذا الموضوع، سنقدم للمطورين كيفية إضافة أشكال البيضاوية إلى الشرائح باستخدام Aspose.Slides لـ C++ . يوفر Aspose.Slides لـ C++ مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال مع بضع أسطر من التعليمات البرمجية فقط. لإضافة بيضاوية بسيطة إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/)
1. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها
1. إضافة AutoShape من نوع البيضاوية باستخدام طريقة AddAutoShape المعروضة بواسطة IShapes object
1. كتابة العرض التقديمي المعدل كملف PPTX

في المثال المعطى أدناه، قمنا بإضافة بيضاوية إلى الشريحة الأولى.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **إنشاء بيضاوية بتنسيق أفضل**
لإضافة بيضاوية بتنسيق أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من نوع البيضاوية باستخدام طريقة AddAutoShape المعروضة بواسطة IShapes object.
1. تعيين نوع التعبئة للبيضاوية إلى صلب.
1. تعيين لون البيضاوية باستخدام خاصية SolidFillColor.Color المعروضة بواسطة كائن FillFormat المرتبط بكائن IShape.
1. تعيين لون خطوط البيضاوية.
1. تعيين عرض خطوط البيضاوية.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة بيضاوية بتنسيق إلى الشريحة الأولى من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}