---
title: لماذا لا نستخدم الأتمتة
type: docs
weight: 50
url: /ar/php-java/why-not-automation/
---

{{% alert color="primary" %}} 

هناك سؤالان نسمعهما غالبًا هنا في Aspose: 

الأول هو **هل تتطلب منتجاتكم أن يتم تثبيت Microsoft Office لتعمل؟** 

الإجابة القصيرة والواضحة هي **لا**. Aspose ومكونات Aspose مستقلون تمامًا وليسوا مرتبطين بـ Microsoft Corporation، ولا هم مصرح لهم أو مدعومين أو معتمدين من قبلها. 

السؤال الثاني الذي عادة ما يتبع هو **لماذا يجب علينا استخدام منتجات Aspose بدلاً من الاستفادة من أتمتة Microsoft Office؟** 

لا يمكن الإجابة على هذا السؤال بسهولة. أقصر إجابة يمكن أن نقدمها هي أن هناك العديد من الأسباب، وأهمها أن **Microsoft نفسها توصي بشدة بعدم استخدام أتمتة Office من حلول البرمجيات** 

{{% /alert %}} 
## **نظرة عامة**
كما ذُكر أعلاه، هناك عدة أسباب تجعل مكونات Aspose بديلًا أفضل للأتمتة. بعض من الأسباب الرئيسية هي: 

- الأمان
- الاستقرار
- قابلية التوسع/السرعة
- السعر
- الميزات

فيما يلي توضيح أفضل لكل من النقاط الرئيسية. تأكد أيضًا من زيارة قسم **معلومات إضافية** الذي يوفر روابط لتقييمات المستخدمين المستقلة. 
## **الأمان**
الاقتباس التالي هو اقتباس مباشر من مقال مايكروسوفت: 

*"لم تكن تطبيقات Office مخصصة أبدًا للاستخدام على الخادم، وبالتالي لا تأخذ بعين الاعتبار مشاكل الأمان التي تواجه المكونات الموزعة. لا يقوم Office بالتحقق من صحة الطلبات الواردة، ولا يحميك من تشغيل الماكروز عن غير قصد، أو بدء خادم آخر قد يقوم بتشغيل الماكروز، من كود الخادم الخاص بك. لا تفتح الملفات التي تم رفعها إلى الخادم من ويب مجهول! استنادًا إلى إعدادات الأمان التي تم تعيينها آخر مرة، يمكن للخادم تشغيل الماكروز تحت صلاحيات المسؤول أو النظام مما يعرض شبكتك للخطر! بالإضافة إلى ذلك، يستخدم Office العديد من المكونات التي تعمل على جانب العميل (مثل Simple MAPI، WinInet، MSDAIPP) التي يمكن أن تخزن معلومات تحقق العميل لتسريع المعالجة. إذا تم أتمتة Office على الخادم، فقد يخدم مثيل واحد أكثر من عميل واحد، ونظرًا لأنه تم تخزين معلومات التحقق لتلك الجلسة، فمن الممكن أن يستخدم عميل واحد بيانات الاعتماد المخزنة لعميل آخر، وبالتالي يحصل على أذونات وصول غير مصرح بها من خلال انتحال هوية مستخدمين آخرين."* 

تعتبر منتجات Aspose آمنة جدًا. لا تشكل مكونات Aspose خطرًا محتملاً على موارد النظام الحيوية. علاوة على ذلك، عندما يتم فتح مستند بواسطة مكون Aspose، لا يتم تشغيل الماكروز تلقائيًا. تم بناء مكونات Aspose بهدف السماح للمطورين بإنشاء وتعديل وحفظ ملفات Office. لا توجد أي من المخاطر المرتبطة بحزمة Microsoft Office كجزء من مكونات Aspose. 
## **الاستقرار**
الاقتباس التالي هو اقتباس مباشر من مقال مايكروسوفت: 

*"تستخدم Office 2000 وOffice XP وOffice 2003 تقنية Microsoft Windows Installer (MSI) لتسهيل التثبيت وإصلاح الذات للمستخدم النهائي. يقدم MSI مفهوم "التثبيت عند الاستخدام الأول"، مما يسمح بتثبيت أو تكوين الميزات ديناميكيًا أثناء وقت التشغيل (بالنسبة للنظام، أو غالبًا لمستخدم معين). في بيئة الخادم، يؤدي هذا إلى إبطاء الأداء وزيادة احتمالية ظهور مربع حوار يطلب من المستخدم الموافقة على التثبيت أو تقديم قرص التثبيت المناسب. على الرغم من أنه مصمم لزيادة مرونة Office كمنتج نهائي، إلا أن تنفيذ Office لقدرات MSI غير فعال في بيئة الخادم. علاوة على ذلك، لا يمكن ضمان استقرار Office بشكل عام عند تشغيله على الخادم لأنه لم يتم تصميمه أو اختباره لهذا النوع من الاستخدام. قد يؤدي استخدام Office كمكون خدمة على خادم الشبكة إلى تقليل استقرار ذلك الجهاز، وبالتالي شبكتك ككل. إذا كنت تخطط لأتمتة Office على الخادم، حاول عزل البرنامج في جهاز مخصص لا يمكنه التأثير على الوظائف الحرجة، والذي يمكن إعادة تشغيله حسب الحاجة."* 

تم اختبار مكونات Aspose بدقة وهي مستقرة جدًا. تُستخدم مكونات Aspose من قبل [شركات](https://about.aspose.com/customers) مثل: **IBM** و**هيلتون** و**Reader's Digest** و**Bank of America** والعديد من الشركات الأخرى. 
## **قابلية التوسع/السرعة**
الاقتباس التالي هو اقتباس مباشر من مقال مايكروسوفت: 

*"تحتاج المكونات التي تعمل على الخادم إلى أن تكون مكونات COM قابلة لإعادة الاستخدام، متعددة الخيوط، بأقل حد من الحمل ومرتفع في الإنتاجية لتلبية احتياجات العملاء المتعددين. تعتبر تطبيقات Office في جميع النواحي تقريبًا على النقيض تمامًا. فهي خوادم أتمتة غير قابلة لإعادة الاستخدام، معتمدة على STA، مصممة لتوفير وظائف متنوعة ولكنها كثيفة الاستخدام للموارد لعميل واحد. توفر قابلية تصميم منخفضة كحل للخادم، ولها حدود ثابتة لعناصر مهمة، مثل الذاكرة، والتي لا يمكن تغييرها من خلال التكوين. والأهم من ذلك، أنها تستخدم موارد عالمية (مثل الملفات المخصصة في الذاكرة، المكونات الإضافية العامة أو القوالب، وخوادم الأتمتة المشتركة)، مما يمكن أن يقيد عدد المثيلات التي يمكن تشغيلها في وقت واحد ويؤدي إلى حدوث ظروف تنافسية إذا تم تكوينها في بيئة متعددة العملاء. يجب على المطورين الذين يخططون لتشغيل أكثر من مثيل واحد من أي تطبيق Office في نفس الوقت أخذ في الاعتبار* ***تجميع*** *أو* ***ترتيب الوصول*** *إلى تطبيق Office لتجنب حدوث محتمل* ***تعقيدات*** *أو* ***فساد بيانات*** *.* 

مكونات Aspose قابلة للتوسع للغاية وسريعة جدًا. لم تُصمم تطبيقات Office لتُستخدم في نفس الوقت من قبل مئات وآلاف المستخدمين. ومع ذلك، فإن مكونات Aspose مصممة لمثل هذه الاستخدامات. تؤدي مكوناتنا بشكل ممتاز سواء على خادم واحد يدعم تطبيقًا واحدًا أو على نموذج ويب متوازن الأحمال يدعم تطبيقًا على مستوى المؤسسة. 
## **السعر**
عند استخدام تطبيق لأتمتة Microsoft Office، يجب شراء نسخة من Microsoft Office لكل جهاز يقوم بتشغيل التطبيق. هناك أوقات عديدة قد يحتاج فيها التطبيق إلى إنشاء أو تعديل ملف Office ولكنه لا يتطلب من المستخدم أن يكون لديه Microsoft Office. تقدم Aspose ترخيصًا [فعالًا من حيث التكلفة](https://purchase.aspose.com/) ومجاني من حقوق الملكية الذي يسمح بالتوزيع إلى عدد غير محدود من المستخدمين دون أي مخاوف تتعلق بالترخيص. 

عند إنشاء تطبيقات مستندة إلى الويب، من المهم معرفة أن مكونات أتمتة Microsoft Office ليست مُسعّرة ولا مُرخّصة لحلول الخادم؛ لذلك، لا توجد حلول ترخيص جيدة لنشر تطبيقات الويب التي تستخدم مكونات Microsoft Office. تقدم Aspose أيضًا حلاً فعالًا من حيث التكلفة للتطبيقات المستندة إلى الخادم. 
## **الميزات**
توفر مكونات Aspose كل ما تحتاجه لإدارة ملفات Office بالإضافة إلى الكثير. تم تصميمها بفلسفة السماح للمطورين بتحقيق أفضل النتائج بأقل جهد ممكن. بالمقارنة مع أتمتة Office، توفر مكونات Aspose العديد من الوظائف القوية والتي تساهم في توفير الوقت. على سبيل المثال، [Aspose.Cells](https://products.aspose.com/cells/php-java/) يمنح المطورين القدرة على استيراد البيانات من **DataTable** أو **DataView** مباشرة إلى ملف Excel. [Aspose.Words](https://products.aspose.com/words/php-java/) يشمل ميزة مماثلة تسمح للمطورين بملء مستند Word (Mail Merge). [كل مكون](https://products.aspose.com/total/php-java/) في عائلة Aspose يقدم مجموعته الخاصة من الميزات الفريدة والقوية. 

أفضل جزء من شراء مكون Aspose (أو مجموعة مكونات مثل [Aspose.Total](https://products.aspose.com/total/php-java/)) هو الوصول إلى فرق التطوير لدينا. تدرك فرق التطوير لدينا أنه إذا كان هناك ميزة تحتاجها شركتك، فمن المحتمل أن تحتاجها شركات أخرى أيضًا. على الرغم من أنه لا يمكن إضافة جميع طلبات الميزات، تحاول فرقنا أن تكون منفتحة ومرنة عند تقديم المساعدة. هذه العقلية هي ما ساعد مكونات Aspose على أن تصبح قوية كما هي. إذا كانت هناك ميزات إضافية تحتاجها من كائنات أتمتة Office، فإن فرص إضافتها هي منخفضة جدًا.
## **الخاتمة**
{{% alert color="primary" %}} 

بينما تغطي هذه المقالة العديد من النقاط الرئيسية التي توضح لماذا تعتبر مكونات Aspose خيارًا أفضل من أتمتة Office، هناك العديد من الأسباب الأخرى. تتناول هذه المقالة أساسًا النقاط الأكثر أهمية. جميع مكونات Aspose المختلفة توفر نسخة [تقييم خالية من المخاطر وبدون التزام](https://downloads.aspose.com/slides/java). نشجعك على الاستفادة من تلك النسخة التجريبية للحصول على فكرة أوضح عن ما يمكن أن تقدمه Aspose لتطبيقاتك. 

{{% /alert %}} 