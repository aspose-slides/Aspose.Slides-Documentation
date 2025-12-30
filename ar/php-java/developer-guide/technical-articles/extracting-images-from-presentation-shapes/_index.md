---
title: استخراج الصور من أشكال العرض التقديمي
linktitle: صورة من الشكل
type: docs
weight: 100
url: /ar/php-java/extracting-images-from-presentation-shapes/
keywords:
- استخراج الصورة
- استرجاع الصورة
- خلفية الشريحة
- خلفية الشكل
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لPHP عبر Java — حل سريع ومناسب للشفرة."
---

## **استخراج الصور من الأشكال**

{{% alert color="primary" %}} 

غالبًا ما تُضاف الصور إلى الأشكال وتُستخدم أيضًا كخلفيات للشرائح. تُضاف كائنات الصورة من خلال [IImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/iimagecollection/)، وهي مجموعة من كائنات [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).

تشرح هذه المقالة كيفية استخراج الصور التي أضيفت إلى العروض التقديمية. 

{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، يجب عليك أولاً تحديد موقع الصورة من خلال المرور على كل شريحة ثم المرور على كل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. 
```php

```


## **الأسئلة الشائعة**

**هل يمكنني استخراج الصورة الأصلية دون أي قص، أو تأثيرات، أو تحولات الشكل؟**

نعم. عندما تصل إلى صورة الشكل، تحصل على كائن الصورة من [مجموعة الصور](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) الخاصة بالعرض التقديمي، ما يعني الحصول على البكسلات الأصلية دون قص أو تأثيرات تنسيقية. يتنقل سير العمل عبر مجموعة صور العرض التقديمي وكائنات [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)، التي تخزن البيانات الأولية.

**هل هناك خطر من تكرار الملفات المتطابقة عند حفظ العديد من الصور دفعة واحدة؟**

نعم، إذا قمت بحفظ كل شيء دون تمييز. قد تحتوي [مجموعة الصور](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) للعرض التقديمي على بيانات ثنائية متطابقة مشاركة بين أشكال أو شرائح مختلفة. لتجنب التكرار، قارن التجزئات أو الأحجام أو محتويات البيانات المستخرجة قبل الكتابة.

**كيف يمكنني تحديد أي الأشكال مرتبطة بصورة معينة من مجموعة الصور في العرض التقديمي؟**

Aspose.Slides لا تخزن روابط عكسية من [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) إلى الأشكال. قم بإنشاء خريطة يدوية أثناء التجول: كلما وجدت إشارة إلى [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)، سجل أي الأشكال تستخدمها.

**هل يمكنني استخراج الصور المدمجة داخل كائنات OLE، مثل المستندات المرفقة؟**

ليس مباشرة، لأن كائن OLE هو حاوية. تحتاج إلى استخراج حزمة OLE نفسها ثم تحليل محتوياتها باستخدام أدوات منفصلة. تعمل الأشكال الصورية في العروض التقديمية عبر [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/); OLE هو نوع كائن مختلف.