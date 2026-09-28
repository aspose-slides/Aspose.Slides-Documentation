---
title: لماذا لا نستخدم الأتمتة
type: docs
weight: 170
url: /ar/net/why-not-automation/
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
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف لماذا تُعد أتمتة Office خطرة على الخوادم والخدمات، وتعرّف كيف يوفر Aspose.Slides معالجة عروض تقديمية أكثر أمانًا وسرعة لـ PowerPoint وOpenDocument."
---
## **المقدمة**

هناك عدة أسباب تجعل مكونات Aspose بديلاً أفضل للأتمتة. بعض الأسباب الرئيسية هي:

- الأمان
- الاستقرار
- القابلية للتوسع/السرعة
- السعر
- الميزات

فيما يلي شرح أكثر تفصيلاً لكل نقطة رئيسية.

## **الأسئلة المهمة**

هناك سؤالان نسمعهما كثيرًا في Aspose:

- هل تتطلب منتجاتكم تثبيت Microsoft Office لتعمل؟

الإجابة القصيرة والبسيطة هي **NO**.

- لماذا يجب أن نستخدم منتجات Aspose بدلاً من أتمتة Microsoft Office؟

أولًا، هناك many [الفوائد التي تستمتع بها عند استخدام Aspose.Slides](/slides/ar/net/product-overview/).

ثانيًا، شركة Microsoft نفسها **تنصح بشدة ضد** استخدام أتمتة Office من حلول برمجية.

## **الأمان**
> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."
> 
> "لم تُصمم تطبيقات Office للاستخدام من جانب الخادم أبداً، وبالتالي لا تأخذ في الاعتبار مشكلات الأمان التي تواجه المكونات الموزَّعة. لا يقوم Office بالمصادقة على الطلبات الواردة، ولا يحميك من تشغيل الماكروهات عن غير قصد، أو بدء خادم آخر قد يشغّل ماكروهات، من كود الخادم الخاص بك. لا تفتح ملفات تم رفعها إلى الخادم من ويب مجهول! بناءً على إعدادات الأمان التي تم تعيينها آخر مرة، يمكن للخادم تشغيل الماكروهات تحت سياق مشرف أو نظام مع صلاحيات كاملة وإضرار شبكتك! بالإضافة إلى ذلك، يستخدم Office العديد من المكونات من جانب العميل (مثل Simple MAPI، WinInet، MSDAIPP) التي يمكنها تخزين معلومات مصادقة العميل مؤقتًا لتسريع المعالجة. إذا تم أتمتة Office من جانب الخادم، قد تخدم نسخة واحدة أكثر من عميل واحد، وبما أن معلومات المصادقة تم تخزينها مؤقتًا لتلك الجلسة، فإنه من الممكن أن يستخدم عميل ما بيانات اعتماد عميل آخر مخزنة مؤقتًا، وبالتالي يحصل على صلاحيات وصول غير ممنوحة عن طريق انتحال هوية مستخدمين آخرين."

منتجات Aspose **آمنة** للغاية. مكونات Aspose تعمل في نفس سياق المستخدم مثل جميع تطبيقات ASP.NET (تحت مستخدم ASPNET). لذلك، مكونات Aspose **لا** تشكل خطر أمان. كما أنها لا تستهلك موارد نظام حرجة. علاوةً على ذلك، عندما يفتح مكوّن Aspose مستندًا، لا يتم تشغيل الماكروهات تلقائيًا. تم بناء مكونات Aspose للسماح للمطورين بإنشاء ملفات Office ومعالجتها وحفظها.

{{% alert color="info" title="Note" %}}
لا ينطبق أي من المخاطر المرتبطة حزمة Microsoft Office على مكونات Aspose.
{{% /alert %}}

## **الاستقرار**
> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."
> 
> "يستخدم Office 2000 وOffice XP وOffice 2003 تقنية Microsoft Windows Installer (MSI) لتسهيل التثبيت والإصلاح الذاتي للمستخدم النهائي. يقدم MSI مفهوم \"التثبيت عند أول استخدام\"، مما يتيح تثبيت الميزات أو تكوينها ديناميكيًا أثناء التشغيل (للنظام أو غالبًا لمستخدم معين). في بيئة الخادم، يؤدي ذلك إلى إبطاء الأداء وزيادة احتمال ظهور مربع حوار يطلب من المستخدم الموافقة على التثبيت أو توفير قرص تثبيت مناسب. رغم أنه صُمم لزيادة مرونة Office كمنتج للمستخدم النهائي، فإن تطبيق Office لإمكانات MSI يعد غير منتج في بيئة الخادم. علاوةً على ذلك، لا يمكن ضمان استقرار Office بشكل عام عند تشغيله من جانب الخادم لأنه لم يُصمم أو يُختبر لهذا النوع من الاستخدام. قد يؤدي استخدام Office كمكوّن خدمة على خادم شبكة إلى تقليل استقرار تلك الآلة وبالتالي شبكة بأكملها. إذا كنت تخطط لأتمتة Office من جانب الخادم، حاول عزل البرنامج على كمبيوتر مخصص لا يمكن أن يؤثر على الوظائف الحرجة، ويمكن إعادة تشغيله حسب الحاجة."

نظرًا لأن مكونات Aspose معبأة في DLL واحدة، لا يحتاج مستخدموها أبدًا إلى تثبيت أجزاء أو قطع إضافية لتعمل. تُستخدم مكونات Aspose فقط بواسطة تطبيقات .NET ولا يوجد أي جزء من شفرة المكوّن مُصمم لانتظار استجابة بشرية.

{{% alert color="info" title="Note" %}}
تم اختبار مكونات Aspose بدقة وتأكيد أنها مستقرة جدًا. تُستخدم مكونات Aspose من قبل [الشركات](https://about.aspose.com/customers/) مثل **Bank of America** والعديد من المؤسسات الرائدة في عدة صناعات ومجالات.
{{% /alert %}}

## **القابلية للتوسع/السرعة**
> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.
> 
> "تحتاج المكونات من جانب الخادم إلى أن تكون قابلة لإعادة الدخول بشكل عالي، مكونات COM متعددة الخيوط مع الحد الأدنى من العبء العالي وإنتاجية مرتفعة لعدة عملاء. تطبيقات Office هي عكس ذلك تقريبًا. فهي خوادم أتمتة غير قابلة لإعادة الدخول، تعتمد على STA ومصممة لتوفير وظائف متنوعة ولكنها تتطلب موارد كثيرة لعميل واحد. تقدم قابلية توسع قليلة كحل من جانب الخادم، وتملك حدودًا ثابتة لعناصر هامة مثل الذاكرة لا يمكن تغييرها عبر الإعدادات. الأهم من ذلك، أنها تستخدم موارد عالمية (مثل ملفات الذاكرة المشتركة، الإضافات أو القوالب العامة، والخوادم المشتركة)، مما قد يحد من عدد النسخ التي يمكن تشغيلها متزامنًا ويؤدي إلى ظروف سباق إذا تم تكوينها في بيئة متعددة العملاء. يجب على المطورين الذين يخططون لتشغيل أكثر من نسخة واحدة من أي تطبيق Office في نفس الوقت أن ينظروا في التجميع أو تسلسل الوصول إلى تطبيق Office لتجنب احتمالية حدوث إغلاق دائم أو فساد البيانات."
 
مكونات Aspose قابلة للتوسع بشكل لا يُصدق وسريعة كالبرق. لم تُصمم تطبيقات Office لتُستخدم في نفس الوقت من قبل مئات أو آلاف المستخدمين، لكن مكونات Aspose صُممت لهذا بالذات. مكوناتنا حل .NET حقيقي.

{{% alert color="info" title="Note" %}}
أداء مكونات Aspose لا تشوبه شائبة على خادم واحد (يخدم تطبيقًا واحدًا) أو على نموذج ويب موزَّع (يخدم تطبيقًا على مستوى المؤسسة).
{{% /alert %}}

## **السعر**
عند استخدام تطبيق لأتمتة Microsoft Office، يجب شراء نسخة من Microsoft Office لكل جهاز يشغل التطبيق. هناك العديد من الحالات التي قد يحتاج فيها التطبيق إلى إنشاء أو تعديل ملف Office، لكن العملية لا تتطلب Microsoft Office.

{{% alert color="info" title="Note" %}}
توفر Aspose رخصة توزيع [فعّال من حيث التكلفة](https://purchase.aspose.com/) وخالية من العوائد الملكية، تسمح بالنشر لعدد غير محدود من المستخدمين دون همّ تراخيص.
{{% /alert %}}

عند إنشاء تطبيقات ويب، من المهم أن نتذكر أن مكونات أتمتة Microsoft Office لا تُسعر ولا تُرخص للحلول من جانب الخادم. لذلك، لا توجد حل ترخيص جيد لنشر تطبيقات الويب التي تستخدم مكونات Microsoft Office. من ناحية أخرى، تقدم Aspose حلًا [فعّال من حيث التكلفة](https://purchase.aspose.com/) للتطبيقات القائمة على الخادم أيضًا.

## **الميزات**
توفر مكونات Aspose كل ما يلزم لإدارة ملفات Office والكثير أكثر. صممناها بناءً على فلسفتنا في مساعدة المطورين على تحقيق أعظم النتائج الممكنة بأقل جهد.

{{% alert color="info" title="Note" %}}
على عكس أتمتة Office، تقدم مكونات Aspose العديد من الدوال القوية والموفرة للوقت.
{{% /alert %}}

على سبيل المثال، [Aspose.Cells](https://products.aspose.com/cells/net/) يتيح للمطورين إمكانية استيراد البيانات من **DataTable** أو **DataView** مباشرةً إلى ملف Excel. [Aspose.Words](https://products.aspose.com/words/net/) يوفر ميزة مشابهة تسمح للمطورين بملء مستند Word (أي دمج المراسلات) مباشرةً من أي كائن بيانات .NET. [كل مكوّن](https://products.aspose.com/total/net/) في عائلة Aspose يقدم مجموعة فريدة وقوية من الميزات الخاصة به.

أفضل جزء في شراء مكوّن Aspose هو الحصول على وصول إلى فرق التطوير لدينا. على سبيل المثال، إذا كنت تستخدم كائنات أتمتة Office وتحتاج إلى ميزات معينة، فإن فرص إضافتها تكون منخفضة جدًا. ومع ذلك، الأمر مختلف مع مكونات Aspose.

{{% alert color="info" title="Note" %}}
فرق التطوير لدينا تدرك أنه إذا كانت هناك ميزة تحتاجها شركتك، فهناك فرصة جيدة أن شركات أخرى تحتاج نفس الميزة. بينما نعلم أننا لا نستطيع تنفيذ كل ميزة مطلوبة، نسعى لإضافة أكبر عدد ممكن من الميزات استنادًا إلى ملاحظات عملائنا.
{{% /alert %}}

فريقنا دائمًا منفتح ومرن عند تقديم المساعدة—وهذا هو السبب في أن مكونات Aspose نمت لتصبح قوية كما هي الآن.

## **الخلاصة**
{{% alert color="info" title="Note" %}}
بينما تناولت هذه المقالة بعض النقاط الرئيسية التي تجعل مكونات Aspose خيارًا أفضل من أتمتة Office، عليك أن تدرك أن هناك العديد، العديد من الفوائد الأخرى. لقد استعرضنا فقط بعض المزايا الرئيسية.

علاوةً على ذلك، جميع منتجات ومكونات Aspose تقدم نسخة تقييمية خالية من المخاطر ولا تتطلب أي التزام [Evaluation Version](https://releases.aspose.com/slides/ar/net/). نشجعك على الاستفادة من التقييم لرؤية ما يمكن أن تفعله Aspose لتطبيقاتك أو عملك.
{{% /alert %}}