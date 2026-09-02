---
title: إدارة ملصقات الحساسية في عروض PowerPoint التقديمية باستخدام JavaScript
linktitle: ملصقات الحساسية
type: docs
weight: 50
url: /ar/nodejs-java/sensitivity-labels/
keywords:
- ملصق حساسية
- Microsoft Purview
- Microsoft Information Protection
- البيانات الوصفية لـ MIP
- علامة محتوى
- حماية المعلومات
- حوكمة المستند
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل ملصقات الحساسية من Microsoft Purview في عروض PowerPoint بتنسيق PPTX باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

تساعد ملصقات الحساسية في Microsoft Purview المؤسسات على تصنيف المستندات وإدارتها. أثناء معالجة العروض التقديمية تلقائيًا، قد تحتاج تطبيقات إلى الحفاظ على ملصق موجود، أو تطبيق ملصق يحدده سياسة، أو تحديث حالته، أو نقل بيانات الميتا الخاصة بالملصق التي كتبتها سير عمل Microsoft Information Protection (MIP) أقدم.

يُظهر Aspose.Slides for Node.js via Java بيانات ملصق الحساسية الحديثة عبر [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). تُعيد هذه الطريقة مجموعة [SensitivityLabelCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض التقديمي كملف PPTX.

{{% alert color="primary" title="ملاحظة" %}}

معرفات ملصق الحساسية ومعلومات السياسة تُحددها تكوين Microsoft Purview الخاص بك. تحقق من توفر الملصق ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل البيانات الوصفية. قيم [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) تصف العلامات المرتبطة بالملصق؛ هي لا تضيف نصًا أو أشكالًا مرئية إلى الشرائح بحد ذاتها.

{{% /alert %}}

## **فهم خصائص ملصق الحساسية**

كل [SensitivityLabel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/) يحتوي على البيانات الوصفية التالية:

| الطرق | الغرض |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getId) و [SensitivityLabel.setId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#setId) | الحصول على معرف ملصق الحساسية في سياسة Purview أو تعيينه. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) و [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | الحصول على موقع الويب المرتبط بسياسة الملصق أو تعيينه. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) و [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | معرفة ما إذا كان الملصق مفعلاً أو تعيين ذلك. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) و [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | معرفة ما إذا كان الملصق قد أُزيل أو تعيين ذلك. عيّن القيمة إلى `true` عندما يجب الاحتفاظ بحالة الإزالة في البيانات الوصفية. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) و [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | معرفة ما إذا تم تطبيق الملصق تلقائيًا أو عبر قرار المستخدم أو تعيين ذلك. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | الحصول على أنواع العلامات المرتبطة بالملصق. |

تحدد الفئة [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) طريقة تعيين الملصق:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) يمثل ملصقًا افتراضيًا أو تم تطبيقه تلقائيًا.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) يمثل ملصقًا تم تطبيقه عبر قرار المستخدم، بما في ذلك الملصقات المطبقة يدويًا، والملصقات الموصى بها، والملصقات الإلزامية.

تحدد الفئة [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالملصق:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق الملصق افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | هناك علامة محتوى رأسية مرتبطة بالملصق. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | هناك علامة محتوى تذييل مرتبطة بالملصق. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | هناك علامة محتوى علامة مائية مرتبطة بالملصق. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | هناك حماية تشفير مرتبطة بالملصق. |

يمكن ربط أنواع علامات متعددة بملصق واحد.

## **قائمة ملصقات الحساسية الموجودة**

اقرأ مجموعة الملصقات الحديثة من [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) وقم بتعدادها. المثال التالي يسرد كل خاصية وعلامة محتوى مخزنة لكل ملصق:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **إضافة ملصق حساسية مع علامة محتوى**

استخدم [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) مع معرّف الملصق، ومعرّف الموقع، وحالة التفعيل، وطريقة التعيين. بعد إرجاع الطريقة كائن [SensitivityLabel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/) الجديد، أضف قيم العلامات المطلوبة عبر القائمة التي تُعيدها [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

المثال التالي يضيف ملصقًا تم اختياره يدويًا مرتبطًا بعلامات تذييل وعلامة مائية، ثم يحفظ النتيجة كملف PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تحديث ملصق الحساسية**

قِيَم [SensitivityLabel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/) قابلة للقراءة والكتابة، باستثناء القائمة التي تُعيدها [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) التي تُعدَّل عبر عمليات القائمة الخاصة بها. بعد تحديد الملصق المطلوب، يمكنك تحديث معرفه، ومعرّف الموقع، وحالة التفعيل، وطريقة التعيين، وحالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يُحدِّث حالة التفعيل وطريقة التعيين للملصق الأول:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **وضع علامة إزالة على ملصق الحساسية**

للحفاظ على حقيقة أن الملصق أُزيل، ابحث عن الملصق واستدعِ [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) مع `true`. سيبقى الإدخال موجودًا مع تسجيل حالة الإزالة. إذا أردت حذف إدخال من المجموعة الحديثة، استخدم [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt)؛ واستخدم [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) لحذف جميع الإدخالات.

المثال التالي يضع علامة إزالة على ملصق محدد ويحفظ العرض المحدث:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قراءة وترحيل ملصقات حساسية MIP القديمة**

يمكن لسير عمل MIP القديم تخزين بيانات ملصق الحساسية في خصائص مستند مخصصة بدلاً من مجموعة الملصقات الحديثة. اقرأ تلك البيانات عبر [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وإرجاع مصفوفة من كائنات [SensitivityLabel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/).

لترحيل البيانات الوصفية، أضف كل ملصق تم إرجاعه إلى مجموعة [SensitivityLabelCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcollection/) الحديثة عبر [SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). نظرًا لأن إضافة معرف ملصق مكرر يرفع استثناءً، يتحقق المثال من المجموعة الوجهة قبل نسخ كل ملصق. يمكنك إضافة تحقق إضافي للتأكد من أن كل ملصق قديم لا يزال موجودًا في سياسة Purview الحالية.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الترحيل ينسخ كائنات الملصق التي تم تحليلها إلى المجموعة الحديثة. لا يتطلب مسح جميع الخصائص المخصصة للمستند، لذا تبقى البيانات الوصفية غير ذات الصلة سليمة. استخدم [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/) لكتابة بيانات الملصق الحديثة إلى ملف PPTX.

## **الأسئلة المتكررة**

**هل إنشاء نوع علامة محتوى يضيف رأسًا أو تذييلًا أو علامة مائية مرئية إلى الشرائح؟**

لا. القيم التي تُضاف عبر القائمة التي تُعيدها [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) تصف العلامات المرتبطة بملصق الحساسية. هي لا تُنشئ نصًا أو أشكالًا مرئية في العرض التقديمي. أضف محتوى الشريحة المناسب منفصلًا إذا كان سير عملك بحاجة إلى عرض تلك العلامات.

**ما الفرق بين وضع علامة إزالة على الملصق وحذفّه من المجموعة؟**

استدعاء [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) مع `true` يُبقي إدخال الملصق ويسجل حالة الإزالة. استدعاء [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) يحذف الإدخال من المجموعة الحديثة. اختر العملية التي تتماشى مع متطلبات احتفاظ مؤسستك بالبيانات الوصفية.

**هل يمكن للعرض التقديمي أن يحتوي على بيانات ميتا MIP قديمة وملصقات حساسية حديثة في آن واحد؟**

نعم. يمكن أن تبقى الملصقات القديمة في خصائص المستند المخصصة بينما تتوفر الملصقات الحديثة عبر [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). استخدم [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) لقراءة البيانات القديمة وترحيل الملصقات الصالحة التي لا توجد بالفعل في المجموعة الحديثة.

**ماذا يحدث إذا أُضيف ملصق بنفس المعرف أكثر من مرة؟**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) يرفع استثناءً عندما تكون المجموعة تحتوي بالفعل على ملصق بنفس المعرف. تحقق من القيم الموجودة التي تُعيدها [SensitivityLabel.getId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sensitivitylabel/#getId) قبل إضافة أو ترحيل الملصقات.

**أي تنسيق إخراج يجب استخدامه للحفاظ على ملصقات الحساسية المحدثة؟**

احفظ العرض التقديمي كملف PPTX باستدعاء [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/)، كما هو موضح في الأمثلة أعلاه.