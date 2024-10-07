---
title: مستطيل
type: docs
weight: 80
url: /cpp/rectangle/
---


## **إنشاء مستطيل بسيط**
مثل الموضوعات السابقة، هذا الموضوع أيضًا يتعلق بإضافة شكل وهذه المرة الشكل الذي سنناقشه هو المستطيل. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو منسقة إلى الشرائح الخاصة بهم باستخدام Aspose.Slides لـ C++. لإضافة مستطيل بسيط إلى الشريحة المحددة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [فئة Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
1. احصل على مرجع لشريحة باستخدام مؤشرها.
1. أضف IAutoShape من نوع مستطيل باستخدام طريقة AddAutoShape المعروضة بواسطة كائن IShapes.
1. اكتب العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **إنشاء مستطيل منسق**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [فئة Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
1. احصل على مرجع لشريحة باستخدام مؤشرها.
1. أضف IAutoShape من نوع مستطيل باستخدام طريقة AddAutoShape المعروضة بواسطة كائن IShapes.
1. قم بتعيين نوع التعبئة للمستطيل إلى صلب.
1. قم بتعيين لون المستطيل باستخدام خاصية SolidFillColor.Color المعروضة بواسطة كائن FillFormat المرتبط بكائن IShape.
1. قم بتعيين لون خطوط المستطيل.
1. قم بتعيين عرض خطوط المستطيل.
1. اكتب العرض التقديمي المعدل كملف PPTX.
   يتم تنفيذ الخطوات أعلاه في المثال أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}