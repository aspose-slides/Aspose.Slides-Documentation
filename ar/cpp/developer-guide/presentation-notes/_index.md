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
description: "خصّص ملاحظات العرض التقديمي باستخدام Aspose.Slides للغة C++. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---
## **نظرة عامة**

يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنُعرّف هذه الميزة، بما في ذلك كيفية إزالة الملاحظات وكيفية تطبيق نمط على شرائح الملاحظات في العرض التقديمي. يتيح Aspose.Slides لك إزالة الملاحظات من أي شريحة وكذلك تطبيق تنسيق على الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة الملاحظات من شريحة محددة في العرض التقديمي.
- إزالة الملاحظات من جميع الشرائح في العرض التقديمي.

لقراءة أو تغيير أبعاد صفحة الملاحظات، وتبديل الاتجاه، والتحقق من سلوك التصدير، انظر [حجم صفحة الملاحظات](/slides/ar/cpp/notes-size/).

## **إزالة الملاحظات من شريحة معينة**
يمكن إزالة الملاحظات من شريحة معينة كما هو موضح في المثال أدناه:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة الملاحظات من جميع الشرائح في العرض التقديمي كما هو موضح في المثال أدناه:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **إضافة نمط للملاحظات**
تمت إضافة الخاصية NotesStyle إلى واجهة IMasterNotesSlide وفئة MasterNotesSlide. تُحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **الأسئلة الشائعة**

### أي كيان API يوفّر الوصول إلى ملاحظات شريحة معينة؟

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/notesslidemanager/) و[الطريقة](https://reference.aspose.com/slides/ar/cpp/aspose.slides/notesslidemanager/get_notesslide/) التي تُرجع كائن الملاحظات، أو `null` إذا لم توجد ملاحظات.

### هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟

تستهدف المكتبة مجموعة واسعة من تنسيقات Microsoft PowerPoint (97‑أحدث) وODP؛ يتم دعم الملاحظات داخل هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.