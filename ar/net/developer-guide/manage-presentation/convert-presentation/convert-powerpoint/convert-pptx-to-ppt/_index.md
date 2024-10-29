---
title: تحويل PPTX إلى PPT في C#
linktitle: تحويل PPTX إلى PPT
type: docs
weight: 21
url: /ar/net/convert-pptx-to-ppt/
keywords: "تحويل PPTX إلى PPT C#، تحويل عرض باوربوينت، PPTX إلى PPT، C#، Aspose.Slides"
description: "تحويل باوربوينت PPTX إلى PPT في C#"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض باوربوينت بتنسيق PPTX إلى تنسيق PPT باستخدام C#. الموضوع التالي مغطى.

- تحويل PPTX إلى PPT في C#

## **C# تحويل PPTX إلى PPT**

لشفرة C# نموذجية لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بتنسيق PPT. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX في العديد من التنسيقات الأخرى مثل PDF وXPS وODP وHTML إلخ، كما هو موضح في هذه المقالات.

- [C# تحويل PPTX إلى PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# تحويل PPTX إلى XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# تحويل PPTX إلى HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# تحويل PPTX إلى ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# تحويل PPTX إلى صورة](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT ببساطة، مرر اسم الملف وتنسيق الحفظ إلى طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) لفئة [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). عينة الشيفرة C# أدناه تقوم بتحويل عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.

```c#
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("presentation.pptx");

// حفظ عرض PPTX بتنسيق PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```