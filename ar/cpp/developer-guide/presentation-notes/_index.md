---
title: إدارة ملاحظات العرض التقديمي في C++
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/cpp/presentation-notes/
keywords:
- ملاحظات
- شريحة ملاحظات
- إضافة ملاحظات
- إزالة ملاحظات
- نمط الملاحظات
- ملاحظات رئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides for C++. اعمل بسلاسة مع ملاحظات PowerPoint و OpenDocument لتعزيز إنتاجيتك."
---

## **إضافة وإزالة ملاحظات الشريحة**
تدعم Aspose.Slides الآن إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات بالإضافة إلى إضافة شرائح بنمط الملاحظات من أي عرض تقديمي. توفر Aspose.Slides للغة C++ ميزة إزالة الملاحظات من أي شريحة وكذلك إضافة نمط إلى الملاحظات الحالية. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة ملاحظات شريحة معينة من العرض التقديمي.
- إزالة ملاحظات جميع الشرائح من العرض التقديمي.

## **إزالة الملاحظات من شريحة محددة**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة ملاحظات جميع الشرائح في عرض تقديمي كما هو موضح في المثال أدناه:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **إضافة نمط ملاحظات**
تم إضافة الخاصية NotesStyle إلى واجهة IMasterNotesSlide وفئة MasterNotesSlide على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **الأسئلة الشائعة**

**ما الكيان API الذي يوفر الوصول إلى ملاحظات شريحة معينة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/) و[طريقة](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/) التي تُرجع كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

**هل هناك فروق في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من تنسيقات Microsoft PowerPoint (من 97 وما بعد) وODP؛ يتم دعم الملاحظات ضمن هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.