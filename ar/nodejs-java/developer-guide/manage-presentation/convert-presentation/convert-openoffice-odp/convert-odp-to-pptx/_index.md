---
title: تحويل ODP إلى PPTX
type: docs
weight: 10
url: /ar/nodejs-java/convert-odp-to-pptx/
---

## **تحويل ODP إلى عرض PPTX/PPT**
توفر Aspose.Slides لـ Node.js عبر Java فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تمثل ملف عرض تقديمي. يمكن الآن لفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) أيضًا الوصول إلى ODP عبر مُنشئ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض تقديمي ODP إلى عرض PPTX.
```javascript
// فتح ملف ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// حفظ عرض ODP إلى صيغة PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **مثال حي**
يمكنك زيارة تطبيق الويب [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) الذي تم بناؤه باستخدام **Aspose.Slides API**. يُظهر التطبيق كيفية تنفيذ تحويل ODP إلى PPTX باستخدام Aspose.Slides API.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. تعمل Aspose.Slides بشكل مستقل ولا تتطلب تطبيقات طرف ثالث لقراءة أو كتابة ODP/PPTX.

**هل يتم الحفاظ على الشرائح الرئيسية والتخطيطات والسمات أثناء التحويل؟**

نعم. تستخدم المكتبة نموذج كائن عرض تقديمي كامل وتحتفظ بالبنية، بما في ذلك الشرائح الرئيسية والتخطيطات، بحيث يبقى التصميم صحيحًا بعد التحويل.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم. تدعم Aspose.Slides اكتشاف الحماية، وفتح والعمل مع [protected presentations](/slides/ar/nodejs-java/password-protected-presentation/) (بما في ذلك ODP) عند توفير كلمة المرور، بالإضافة إلى تهيئة التشفير والوصول إلى خصائص المستند.

**هل Aspose.Slides مناسبة لخدمات التحويل السحابي أو القائمة على REST؟**

نعم. يمكنك استخدام المكتبة المحلية في الخلفية الخاصة بك أو [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API)؛ كلا الخيارين يدعمان تحويل ODP → PPTX.