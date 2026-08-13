---
title: لماذا لا نستخدم الأتمتة
type: docs
weight: 50
url: /ar/cpp/why-not-automation/
keywords:
- الأتمتة
- مايكروسوفت أوفيس
- المقارنة
- الأمان
- الاستقرار
- القابلية للتوسع
- الميزات
- باوربوينت
- مستند مفتوح
- العرض التقديمي
- C++
- Aspose.Slides
description: "اكتشف لماذا تعتبر أتمتة Office محفوفة بالمخاطر على الخوادم والخدمات، وتعرف على كيف يقدم Aspose.Slides معالجة عروض تقديمية أكثر أمانًا وسرعة لباوربوينت ومستندات OpenDocument."
---
## **مقدمة**

هناك عدة أسباب تجعل مكونات Aspose بديلاً أفضل للأتمتة. بعض الأسباب الرئيسية هي:

- الأمان
- الاستقرار
- القابلية للتوسع/السرعة
- السعر
- الميزات

فيما يلي شرح أكثر تفصيلاً لكل نقطة رئيسية.

## **أسئلة مهمة**
- لماذا تُعد مكونات Aspose خيارًا أفضل بكثير من أتمتة Microsoft Office؟

هناك سؤالان نسمعهما كثيرًا هنا في Aspose :

- هل تتطلب منتجاتكم تثبيت Microsoft Office لكي تعمل؟

الإجابة القصيرة والبسيطة هي **لا**. Aspose ومكوّنات Aspose مستقلة تمامًا وغير مرتبطة بـ Microsoft Corporation ولا تُعتمد أو تُرعى أو تُعتمد بأي شكل من الأشكال.

- لماذا يجب علينا استخدام منتجات Aspose بدلاً من الاستفادة من أتمتة Microsoft Office؟

أقصر إجابة يمكننا تقديمها هي أن هناك العديد من الأسباب، وأهمها أن *Microsoft نفسها توصي بشدة بعدم استخدام أتمتة Office في حلول البرمجيات: [Microsoft Article

## **الأمان**
النص التالي هو اقتباس مباشر من مقالة Microsoft المشار إليها أعلاه :
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

منتجات Aspose آمنة للغاية. لذلك، لا تشكل مكونات Aspose خطرًا محتملًا على موارد النظام الحيوية. علاوةً على ذلك، عندما يفتح مكوّن Aspose مستندًا، لا يتم تشغيل الماكرو تلقائيًا. تم بناء مكونات Aspose بهدف تمكين المطورين من إنشاء ملفات Office ومعالجتها وحفظها. لا تحمل مكونات Aspose أيًا من المخاطر المرتبطة بحزمة Microsoft Office.

## **الاستقرار**
النص التالي هو اقتباس مباشر من مقالة Microsoft المشار إليها أعلاه :
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

نظرًا لأن مكونات Aspose تُعبَّأ في ملف DLL واحد، لن تحتاج أبدًا إلى تثبيت أية أجزاء إضافية لتعمل. تُستَخدم مكونات Aspose فقط من قبل تطبيقات C++ ولا توجد أي جزء من كود المكوّن مصمم للانتظار استجابة من إنسان. تم اختبار مكونات Aspose بصورة شاملة وهي مستقرة للغاية. تُستَخدم مكونات Aspose من قبل [الشركات](https://about.aspose.com/customers) مثل: **IBM**، **Hilton**، **Reader's Digest**، **Bank of America** والعديد الكثير غيرها.

## **القابلية للتوسع/السرعة**
النص التالي هو اقتباس مباشر من مقالة Microsoft المشار إليها أعلاه :

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

مكونات Aspose قابلة للتوسع بشكل كبير وسريعة جدًا. لم تُصمم تطبيقات Office لتُستخدم في وقت واحد من قِبل مئات أو آلاف المستخدمين. ومع ذلك، صُمِّمت مكونات Aspose لهذا الغرض. مكوناتنا حل C++ حقيقي وتعمل بلا خطأ سواء على خادم واحد، يدعم تطبيقًا واحدًا أو على نموذج ويب موزّع يدعم تطبيقًا مؤسسيًا واسع النطاق.

## **السعر**
عند استخدام تطبيق لأتمتة Microsoft Office، يجب شراء نسخة من Microsoft Office لكل جهاز يُشغَّل عليه التطبيق. هناك العديد من الحالات التي قد يحتاج فيها التطبيق إلى إنشاء أو تعديل ملف Office دون الحاجة إلى امتلاك المستخدم لـ Microsoft Office. تقدم Aspose ترخيصًا **فعّال من حيث التكلفة** وبدون حقوق ملكية يتيح النشر لعدد غير محدود من المستخدمين دون قلق الترخيص. عند إنشاء تطبيقات ويب، من المهم معرفة أن مكونات أتمتة Microsoft Office ليست مُسعَّرة ولا مُرخَّصة لحلول الخادم؛ وبالتالي لا توجد حلول ترخيص جيدة لنشر تطبيقات الويب التي تستخدم مكونات Microsoft Office. تقدم Aspose حلًا **فعّالًا من حيث التكلفة** للتطبيقات القائمة على الخادم أيضًا.

## **الميزات**
توفر مكونات Aspose كل ما يلزم لإدارة ملفات Office وأكثر من ذلك. صُمِّمت بفلسفة تمكين المطورين من تحقيق أكبر النتائج بأقل جهد. على عكس أتمتة Office، توفر مكونات Aspose العديد من الدوال القوية والموفرة للوقت. على سبيل المثال، [Aspose.Cells](https://products.aspose.com/cells/cpp/) يتيح للمطورين استيراد البيانات من **DataTable** أو **DataView** مباشرةً إلى ملف Excel. [Aspose.Words](https://products.aspose.com/words/net/) يقدم ميزة مماثلة تسمح للمطورين بملء مستند Word (الدمج البريدي) مباشرةً من أي كائن بيانات C++. كل مكوّن في عائلة Aspose يقدم مجموعة فريدة وقوية من الميزات. أفضل جزء في شراء مكوّن Aspose هو الحصول على وصول إلى فرق التطوير لدينا. تدرك فرقنا أنه إذا كان هناك ميزة تحتاجها شركتك، فمن المرجح أن شركات أخرى تحتاجها أيضًا. رغم أنه لا يمكن إضافة كل طلب ميزة، إلا أن فرقنا تحاول أن تكون مرنة ومنفتحة عند تقديم المساعدة. هذا النهج هو ما ساعد مكونات Aspose على أن تكون قوية كما هي. إذا كانت هناك ميزات إضافية تحتاجها من كائنات أتمتة Office، فإن فرص إضافتها منخفضة جدًا.

## **الخلاصة**
{{% alert color="info" %}} 

بينما يغطي هذا المقال العديد من النقاط الرئيسية التي تجعل مكونات Aspose اختيارًا أفضل من أتمتة Office، هناك الكثير والكثير غير ذلك. يركز هذا المقال أساسًا على أهم النقاط فقط. جميع مكونات Aspose المختلفة تقدم نسخة تقييم خالية من المخاطر ولا تتطلب أي التزام من خلال [نسخة تقييم](https://downloads.aspose.com/slides/ar/cpp). نُشجّعكم على الاستفادة من هذه [النسخة التقييمية](https://downloads.aspose.com/slides/ar/cpp) لتُدركوا بشكل أفضل ما يمكن لـ Aspose تقديمه لتطبيقاتكم. 
{{% /alert %}}