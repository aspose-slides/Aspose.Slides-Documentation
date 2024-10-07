---
title: تحويل PPTX إلى PPT في جافا
linktitle: تحويل PPTX إلى PPT
type: docs
weight: 21
url: /androidjava/convert-pptx-to-ppt/
keywords: "جافا تحويل PPTX إلى PPT، تحويل عرض PowerPoint، PPTX إلى PPT، جافا، Aspose.Slides"
description: "تحويل PowerPoint PPTX إلى PPT في جافا"
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPTX إلى صيغة PPT باستخدام جافا. الموضوع التالي يتم تناوله.

- تحويل PPTX إلى PPT في جافا

## **تحويل جافا PPTX إلى PPT**

للحصول على نموذج كود جافا لتحويل PPTX إلى PPT، يرجى الاطلاع على القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). فهو يقوم بتحميل ملف PPTX وحفظه بصيغة PPT. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX في العديد من الصيغ الأخرى مثل PDF وXPS وODP وHTML وغيرها كما تم مناقشته في هذه المقالات.

- [جافا تحويل PPTX إلى PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [جافا تحويل PPTX إلى XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [جافا تحويل PPTX إلى HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [جافا تحويل PPTX إلى ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [جافا تحويل PPTX إلى صورة](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة **Save** لفئة [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). نموذج كود جافا أدناه يقوم بتحويل عرض تقديمي من PPTX إلى PPT باستخدام الخيارات الافتراضية.

```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation presentation = new Presentation("template.pptx");

// حفظ العرض التقديمي بصيغة PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```