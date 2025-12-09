---
title: مقارنة الشرائح
type: docs
weight: 50
url: /ar/nodejs-java/compare-slides/
---

## **مقارنة شريحتين**
تمت إضافة طريقة Equals إلى فئة [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) وفئة [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide). تُرجع true للشرائح/التخطيطات والشرائح الرئيسية التي تكون متطابقة من حيث بنائها والمحتوى الثابت.  

تكون الشريحتان متساويتين إذا كانت جميع الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى إلخ متساوية. لا يأخذ المقارنة في الاعتبار قيم المعرفات الفريدة، مثل SlideId، ولا المحتوى الديناميكي، مثل قيمة التاريخ الحالية في عنصر النائب Date Placeholder.
```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **الأسئلة المتكررة**

**هل يؤثر كون الشريحة مخفية على مقارنة الشرائح نفسها؟**  
[Hidden status](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) هي خاصية مستوى العرض/التشغيل، ليست محتوى بصريًا. يتم تحديد مساواة شريحتين محددتين بناءً على هيكلهما والمحتوى الثابت؛ فمجرد كون الشريحة مخفية لا يجعل الشرائح مختلفة.

**هل يتم أخذ الروابط التشعبية ومعلماتها في الاعتبار؟**  
نعم. الروابط هي جزء من المحتوى الثابت للشريحة. إذا اختلف عنوان URL أو إجراء الرابط التشعيبي، فإن ذلك يُعامل عادةً كاختلاف في المحتوى الثابت.

**إذا كان المخطط يشير إلى ملف Excel خارجي، هل سيتم أخذ محتويات ذلك الملف في الاعتبار؟**  
لا. يتم إجراء المقارنة بناءً على الشرائح نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية عند المقارنة؛ فقط ما هو موجود في بنية الشريحة وحالتها الثابتة يُؤخذ بعين الاعتبار.