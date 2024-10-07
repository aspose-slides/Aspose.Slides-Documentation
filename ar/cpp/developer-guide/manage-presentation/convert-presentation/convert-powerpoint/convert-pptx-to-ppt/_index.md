---
title: تحويل PPTX إلى PPT في C++
linktitle: تحويل PPTX إلى PPT
type: docs
weight: 21
url: /cpp/convert-pptx-to-ppt/
keywords: "C++ تحويل PPTX إلى PPT، تحويل عرض PowerPoint، PPTX إلى PPT، بايثون، Aspose.Slides"
description: "تحويل عرض PowerPoint PPTX إلى PPT في C++"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام C++. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT في C++

## **C++ تحويل PPTX إلى PPT**

للحصول على مثال كود C++ لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم ببساطة بتحميل ملف PPTX ويحفظه بصيغة PPT. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX في العديد من التنسيقات الأخرى مثل PDF و XPS و ODP و HTML إلخ كما تم مناقشته في هذه المقالات.

- [C++ تحويل PPTX إلى PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ تحويل PPTX إلى XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ تحويل PPTX إلى HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ تحويل PPTX إلى ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ تحويل PPTX إلى صورة](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وتنسيق الحفظ إلى طريقة **Save** في فئة [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). مثال كود C++ أدناه يقوم بتحويل عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.

```cpp
// تحميل ملف PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// حفظ بصيغة PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```