---
title: تحويل PPTX إلى PPT
linktitle: تحويل PPTX إلى PPT
type: docs
weight: 21
url: /ar/php-java/convert-pptx-to-ppt/
keywords: "PHP  تحويل PPTX إلى PPT, تحويل عرض PowerPoint, PPTX إلى PPT, Java, Aspose.Slides"
description: "تحويل PowerPoint PPTX إلى PPT "
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPTX إلى تنسيق PPT باستخدام PHP. يتم تناول الموضوع التالي.

- تحويل PPTX إلى PPT

## **تحويل Java من PPTX إلى PPT**

للحصول على نموذج كود Java لتحويل PPTX إلى PPT، يُرجى مراجعة القسم أدناه أي [تحويل PPTX إلى PPT](#convert-pptx-to-ppt). يقوم بتحميل ملف PPTX وحفظه بتنسيق PPT. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPTX إلى العديد من التنسيقات الأخرى مثل PDF و XPS و ODP و HTML وغيرها، كما هو موضح في هذه المقالات.

- [تحويل Java من PPTX إلى PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [تحويل Java من PPTX إلى XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [تحويل Java من PPTX إلى HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [تحويل Java من PPTX إلى ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [تحويل Java من PPTX إلى صورة](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **تحويل PPTX إلى PPT**
لتحويل PPTX إلى PPT، ببساطة قم بتمرير اسم الملف وتنسيق الحفظ إلى طريقة **Save** من فئة [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). مثال كود PHP أدناه يقوم بتحويل عرض من PPTX إلى PPT باستخدام الخيارات الافتراضية.

```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $presentation = new Presentation("template.pptx");
  # حفظ العرض كملف PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);

```