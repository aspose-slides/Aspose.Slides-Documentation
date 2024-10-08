---
title: تحويل PPTX إلى PPT في جافا
linktitle: تحويل PPTX إلى PPT
type: docs
weight: 21
url: /ar/java/convert-pptx-to-ppt/
keywords: "جافا تحويل PPTX إلى PPT, تحويل عرض PowerPoint, PPTX إلى PPT, جافا, Aspose.Slides"
description: "تحويل PowerPoint PPTX إلى PPT في جافا"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام جافا. الموضوعات التالية مغطاة.

- تحويل PPTX إلى PPT في جافا

## **تحويل Java PPTX إلى PPT**

للحصول على كود جافا كمثال لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم ببساطة بتحميل ملف PPTX وحفظه بصيغة PPT. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX في العديد من الصيغ الأخرى مثل PDF، XPS، ODP، HTML، إلخ كما تمت مناقشته في هذه المقالات.

- [Java Convert PPTX to PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convert PPTX to XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convert PPTX to HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convert PPTX to ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convert PPTX to Image](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** لفئة [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). كود جافا أدناه يقوم بتحويل عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.

```java
// instantiate a Presentation object that represents a PPTX file
Presentation presentation = new Presentation("template.pptx");

// save the presentation as PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```