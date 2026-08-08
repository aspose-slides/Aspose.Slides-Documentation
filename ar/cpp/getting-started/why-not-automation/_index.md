---
title: لماذا لا الأتمتة
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
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف لماذا تُعد أتمتة Office مخاطرة على الخوادم والخدمات، وتعرف على كيفية تقديم Aspose.Slides معالجة عروض تقديمية أكثر أمانًا وسرعة لـ PowerPoint و OpenDocument."
---
## **المقدمة**

هناك عدة أسباب تجعل مكونات Aspose بديلاً أفضل للأتمتة. بعض الأسباب الرئيسية هي:

- الأمن
- الاستقرار
- القابلية للتوسع/السرعة
- السعر
- الميزات

فيما يلي شرح أكثر تفصيلاً لكل نقطة رئيسية.

## **أسئلة مهمة**
- لماذا تعتبر مكونات Aspose خيارًا أفضل بكثير من أتمتة Microsoft Office؟

هناك سؤالان نسمعهما كثيرًا هنا في Aspose:

- هل تحتاج منتجاتكم إلى تثبيت Microsoft Office لكي تعمل؟

الإجابة المختصرة هي **لا**. مكونات Aspose مستقلة تمامًا ولا ترتبط بشركة Microsoft ولا تُعتمد أو تُرعى أو تُصدق من قبلها.

- لماذا يجب أن نستخدم منتجات Aspose بدلاً من أتمتة Microsoft Office؟

أقصر إجابة يمكننا إعطاؤها هي أن هناك العديد من الأسباب، وأهمها أن *Microsoft نفسها توصي بشدة بعدم استخدام أتمتة Office من حلول البرمجيات: [مقال مايكروسوفت]*

## **الأمن**
الاقتباس التالي مباشرة من مقال Microsoft المشار إليه أعلاه:
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non‑granted access permissions by impersonating other users."*

منتجات Aspose آمنة للغاية. لذلك لا تشكل مكونات Aspose خطرًا محتملًا على موارد النظام الحيوية. علاوة على ذلك، عندما يفتح مستند مكون Aspose، لا يتم تشغيل الماكرو تلقائيًا. صُنعت مكونات Aspose بهدف تمكين المطورين من إنشاء ملفات Office ومعالجتها وحفظها. لا تنطبق المخاطر المرتبطة بحزمة Microsoft Office على مكونات Aspose.

## **الاستقرار**
الاقتباس التالي مباشرة من مقال Microsoft المشار إليه أعلاه:
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

نظرًا لأن مكونات Aspose تُعبَّأ في ملف DLL واحد، لن تحتاج إلى تثبيت أي أجزاء إضافية لتعمل. تُستَخدم مكونات Aspose فقط بواسطة تطبيقات C++ ولا يوجد أي جزء من الكود يتطلب استجابة بشرية. تم اختبار مكونات Aspose بدقة وهي مستقرة للغاية. تُستخدم مكونات Aspose من قبل [Companies](https://about.aspose.com/customers) مثل: **IBM**، **Hilton**، **Reader's Digest**، **Bank of America** والعديد غيرها.

## **القابلية للتوسع/السرعة**
الاقتباس التالي مباشرة من مقال Microsoft المشار إليه أعلاه:
*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

مكونات Aspose قابلة للتوسع بدرجة عالية وسريعة للغاية. تطبيقات Office لم تُصمم لتُستخدم في وقت واحد من قبل مئات أو آلاف المستخدمين. ومع ذلك، صُممت مكونات Aspose لهذا الغرض. مكوناتنا حل C++ حقيقي وتعمل بلا أخطاء سواء على خادم واحد، أو تطبيق واحد، أو على نموذج ويب موزَّع يُدعم تطبيقًا مؤسسيًا واسع النطاق.

## **السعر**
عند استخدام أتمتة Microsoft Office، يجب شراء نسخة من Microsoft Office لكل جهاز يُشغَّل عليه التطبيق. في كثير من الأحيان يحتاج التطبيق إلى إنشاء أو تعديل ملف Office دون الحاجة إلى أن يمتلك المستخدم Microsoft Office. تقدم Aspose ترخيصًا [Cost Effective](https://purchase.aspose.com/) وخاليًا من العوائد يُتيح النشر لعدد غير محدود من المستخدمين دون القلق بشأن الترخيص. عند إنشاء تطبيقات ويب، من المهم معرفة أن مكونات أتمتة Microsoft Office لا تُسعَّر ولا تُرخص لحلول الخادم؛ لذلك لا توجد حل ترخيصي جيد لنشر تطبيقات ويب تستخدم مكونات Microsoft Office. تقدم Aspose حلًا [Cost Effective](https://purchase.aspose.com/) لتطبيقات الخادم كذلك.

## **الميزات**
توفر مكونات Aspose كل ما يلزم لإدارة ملفات Office وأكثر من ذلك. صُممت بمعايير تمكّن المطورين من تحقيق أفضل النتائج بأقل جهد. بخلاف أتمتة Office، تقدم مكونات Aspose وظائف قوية وموفرة للوقت. على سبيل المثال، يقدم [Aspose.Cells](https://products.aspose.com/cells/cpp/) للمطورين إمكانية استيراد البيانات من **DataTable** أو **DataView** مباشرة إلى ملف Excel. يقدم [Aspose.Words](https://products.aspose.com/words/net/) ميزة مماثلة تُتيح للمطورين ملء مستند Word (دمج البريد) مباشرةً من أي كائن بيانات C++. كل [Component](https://products.aspose.com/total/cpp/) في عائلة Aspose يقدم مجموعة فريدة وقوية من الميزات. أفضل ما في شراء مكون Aspose هو الحصول على دعم فرق التطوير لدينا. تدرك فرقنا أنه إذا كان هناك ميزة تحتاجها شركتكم، فمن المحتمل أن تحتاجها شركات أخرى أيضًا. رغم أن ليس كل طلب ميزة يمكن إضافته، فإن فرقنا تحافظ على عقلية منفتحة ومرنة عند تقديم المساعدة. هذه العقلية هي التي مكّنت مكونات Aspose من أن تصبح قوية كما هي. إذا كانت هناك ميزات إضافية تحتاجها من كائنات أتمتة Office، فاحتمالية إضافتها منخفضة جدًا.

## **الخاتمة**
{{% alert color="primary" %}} 

بينما يغطي هذا المقال العديد من النقاط الرئيسية التي تجعل مكونات Aspose خيارًا أفضل من أتمتة Office، هناك الكثير غير ذلك. يركز هذا المقال على أهم النقاط فقط. جميع مكونات Aspose المختلفة تُقدم نسخة تقييم مجانية بدون مخاطر ولا التزام من خلال [Evaluation Version](https://downloads.aspose.com/slides/ar/cpp). نشجعكم على الاستفادة من تلك [Evaluation](https://downloads.aspose.com/slides/ar/cpp) لتجربة ما يمكن أن تقدمه Aspose لتطبيقاتكم. 
{{% /alert %}}