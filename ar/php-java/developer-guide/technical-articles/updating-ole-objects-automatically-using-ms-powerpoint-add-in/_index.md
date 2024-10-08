---
title: تحديث كائنات OLE تلقائيًا باستخدام إضافة MS PowerPoint
type: docs
weight: 10
url: /ar/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **حول تحديث كائنات OLE تلقائيًا**
أحد الأسئلة الأكثر تكرارًا التي يطرحها عملاء Aspose.Slides هو كيفية إنشاء أو تغيير الرسوم البيانية القابلة للتحرير أو أي كائنات OLE أخرى وجعلها تتحدث تلقائيًا عند فتح العرض التقديمي. للأسف، PowerPoint لا يدعم أي وحدات ماكرو تلقائية، والتي تتوفر في Excel وWord. الوحيدة المتاحة هي وحدات الماكرو Auto_Open وAuto_Close. ومع ذلك، فإنها تعمل تلقائيًا فقط من إضافة. توضح هذه النصيحة الفنية القصيرة كيفية تحقيق ذلك. 

أولاً، هناك العديد من الإضافات المجانية التي تضيف ميزة وحدة الماكرو Auto_Open إلى PowerPoint مثل [إضافة AutoEvents](http://skp.mvps.org/autoevents.htm) و [مولد الأحداث](https://www.officeoneonline.com/eventgen/eventgen.html).

بعد تثبيت مثل هذه الإضافة، فقط أضف وحدة الماكرو Auto_Open() (OnPresentationOpen() في حالة "مولد الأحداث") إلى العرض التقديمي الخاص بك كما هو موضح أدناه:

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}

{{% alert color="primary" %}} 

أي تغيير يتم إجراؤه على كائنات OLE باستخدام Aspose.Slides، سيتم تحديثه تلقائيًا عندما يفتح PowerPoint العرض التقديمي. إذا كان لديك العديد من كائنات OLE في عرض تقديمي ولا تريد تحديثها جميعًا، فقط أضف علامة مخصصة إلى الأشكال التي تحتاج إلى معالجتها وتحقق منها في وحدة الماكرو. 

{{% /alert %}}