---
title: استخراج الصور من أشكال العرض التقديمي
linktitle: صورة من الشكل
type: docs
weight: 100
url: /ar/php-java/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- خلفية الشريحة
- خلفية الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides ل PHP عبر Java — حل سريع وسهل الكتابة."
---

## **استخراج الصور من الأشكال**

{{% alert color="primary" %}} 
غالبًا ما يتم إضافة الصور إلى الأشكال وتستخدم أيضًا بشكل متكرر كخلفيات للشرائح. يتم إضافة كائنات الصورة عبر [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/)، وهي مجموعة من كائنات [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).

تشرح هذه المقالة كيفية استخراج الصور المضافة إلى العروض التقديمية. 
{{% /alert %}} 

لاستخراج صورة من عرض تقديمي، عليك تحديد موقع الصورة أولاً عبر المرور على كل شريحة ثم المرور على كل شكل. بمجرد العثور على الصورة أو تحديدها، يمكنك استخراجها وحفظها كملف جديد. 
```php

```


## **الأسئلة الشائعة**

**هل يمكنني استخراج الصورة الأصلية دون أي قص أو تأثيرات أو تحويلات للشكل؟**

نعم. عندما تصل إلى صورة الشكل، تحصل على كائن الصورة من [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/)، مما يعني الحصول على البكسلات الأصلية دون قص أو تأثيرات تنسيق. تمر عملية العمل عبر مجموعة الصور في العرض التقديمي وكائنات [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) التي تخزن البيانات الأولية.

**هل هناك خطر تكرار ملفات متماثلة عند حفظ العديد من الصور دفعة واحدة؟**

نعم، إذا حفظت كل شيء دون تمييز. يمكن أن تحتوي [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) في العرض التقديمي على بيانات ثنائية متماثلة يتم الإشارة إليها من قبل أشكال أو شرائح مختلفة. لتجنب التكرار، قارن التجزئات أو الأحجام أو محتويات البيانات المستخرجة قبل الكتابة.

**كيف يمكنني تحديد أي الأشكال مرتبطة بصورة معينة من مجموعة الصور في العرض التقديمي؟**

Aspose.Slides لا يخزن روابط عكسية من [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) إلى الأشكال. قم ببناء خريطة يدويًا أثناء الاستعراض: كلما وجدت إشارة إلى [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)، سجّل أي الأشكال تستخدمها.

**هل يمكنني استخراج الصور المضمنة داخل كائنات OLE، مثل المستندات المرفقة؟**

ليس مباشرة، لأن كائن OLE هو حاوية. يجب عليك استخراج حزمة OLE نفسها ثم تحليل محتوياتها باستخدام أدوات منفصلة. تعمل أشكال الصور في العرض التقديمي عبر [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)؛ OLE نوع كائن مختلف.