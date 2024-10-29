---
title: تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint
type: docs
weight: 10
url: /ar/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **حول تحديث كائنات OLE تلقائيًا**
أحد أبرز الأسئلة التي يطرحها عملاء Aspose.Slides هو كيفية إنشاء أو تغيير المخططات القابلة للتحرير أو أي كائنات OLE أخرى وتحديثها تلقائيًا عند فتح العرض التقديمي. للأسف، لا يدعم PowerPoint أي ماكرو تلقائي، المتوفر في Excel و Word. الوحيدان المتوفران هما ماكرو Auto_Open و Auto_Close. ومع ذلك، فإنهما يعملان تلقائيًا فقط من مكون إضافي. تُظهر هذه النصيحة التقنية القصيرة كيفية تحقيق ذلك.

أولاً، هناك العديد من المكونات الإضافية المجانية المتاحة التي تضيف ميزة ماكرو Auto_Open إلى PowerPoint على سبيل المثال [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) و [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

بعد تثبيت مثل هذا المكون الإضافي، أضف فقط ماكرو Auto_Open() (OnPresentationOpen() في حالة "Event Generator") إلى عرضك التقديمي النموذجي كما هو موضح أدناه:

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}


{{% alert color="primary" %}} 

أي تغيير تم إجراؤه على كائنات OLE باستخدام Aspose.Slides سيتم تحديثه تلقائيًا عند فتح PowerPoint العرض التقديمي. إذا كان لديك العديد من كائنات OLE في عرض تقديمي ولا تريد تحديثها جميعًا، فقط أضف علامة مخصصة إلى الأشكال التي تحتاج إلى معالجتها وتحقق منها في الماكرو.

{{% /alert %}}