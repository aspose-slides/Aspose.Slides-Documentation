---
title: إدارة تصنيفات الحساسية في عروض PowerPoint التقديمية باستخدام PHP
linktitle: تصنيفات الحساسية
type: docs
weight: 50
url: /ar/php-java/sensitivity-labels/
keywords:
- تصنيف حساسية
- Microsoft Purview
- حماية المعلومات من Microsoft
- بيانات تعريف MIP
- علامات المحتوى
- حماية المعلومات
- حوكمة المستندات
- PowerPoint
- PPTX
- أمان العروض التقديمية
- PHP
- Aspose.Slides
description: "قراءة، إضافة، تحديث، إزالة، وترحيل تصنيفات الحساسية من Microsoft Purview في عروض PowerPoint بصيغة PPTX باستخدام PHP."
---
## **نظرة عامة**

تساعد تصنيفات الحساسية في Microsoft Purview المؤسسات على تصنيف المستندات وإدارتها. أثناء معالجة العرض التقديمي تلقائيًا، قد يحتاج التطبيق إلى الحفاظ على تصنيف موجود، أو تطبيق تصنيف مختار بواسطة سياسة، أو تحديث حالته، أو ترحيل بيانات تعريف التصنيف التي كتبها سير عمل Microsoft Information Protection (MIP) القديم.

تُظهر Aspose.Slides for PHP عبر Java بيانات تعريف تصنيفات الحساسية الحديثة من خلال [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSensitivityLabels). تُعيد هذه الطريقة مجموعة [SensitivityLabelCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcollection/) التي يمكن فحصها وتعديلها قبل حفظ العرض التقديمي كملف PPTX.

{{% alert color="primary" title="Note" %}}
معرفات تصنيف الحساسية ومعلومات السياسة يتم تعريفها بواسطة إعدادات Microsoft Purview الخاصة بك. تحقق من توفر التصنيف ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل البيانات الوصفية. قيم [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) تصف العلامات المحتوى المرتبطة بالتصنيف؛ هي لا تضيف نصًا مرئيًا أو أشكالًا إلى الشرائح بحد ذاتها.
{{% /alert %}}

## **فهم خصائص تصنيف الحساسية**

كل [SensitivityLabel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/) يحتوي على البيانات الوصفية التالية:

| الطرق | الغرض |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getId) و [SensitivityLabel::setId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#setId) | الحصول على أو تعيين معرف تصنيف الحساسية في سياسة Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getSiteId) و [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#setSiteId) | الحصول على أو تعيين الموقع المرتبط بسياسة التصنيف. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#isEnabled) و [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#setEnabled) | الحصول على أو تعيين ما إذا كان التصنيف مفعلاً. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#isRemoved) و [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#setRemoved) | الحصول على أو تعيين ما إذا تم إزالة التصنيف. اضبط القيمة إلى `true` عندما يجب الاحتفاظ بحالة الإزالة في البيانات الوصفية. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) و [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | الحصول على أو تعيين ما إذا تم تطبيق التصنيف تلقائيًا أو عبر قرار المستخدم. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | الحصول على أنواع العلامات المحتوى المرتبطة بالتصنيف. |

تحدد فئة [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelassignmenttype/) كيفية تعيين التصنيف:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelassignmenttype/) يمثل تصنيفًا افتراضيًا أو مُطبقًا تلقائيًا.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelassignmenttype/) يمثل تصنيفًا تم تطبيقه عبر قرار المستخدم، بما في ذلك التصنيفات المطبقة يدويًا، الموصى بها، والإلزامية.

تحدد فئة [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالتصنيف:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق التصنيف افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcontenttype/) | ترتبط علامة محتوى الرأس بالتصنيف. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcontenttype/) | ترتبط علامة محتوى التذييل بالتصنيف. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcontenttype/) | ترتبط علامة محتوى العلامة المائية بالتصنيف. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcontenttype/) | ترتبط حماية التشفير بالتصنيف. |

يمكن ربط أنواع علامات متعددة بتصنيف واحد.

## **قائمة تصنيفات الحساسية الموجودة**

اقرأ مجموعة التصنيفات الحديثة من خلال [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSensitivityLabels) وابدأ في تعدادها. المثال التالي يسرد كل خاصية وعلامة محتوى مخزنة لكل تصنيف:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **إضافة تصنيف حساس مع علامة محتوى**

استخدم [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcollection/#add) مع معرف التصنيف، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين. بعد أن تُعيد الطريقة كائن [SensitivityLabel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/) الجديد، أضف قيم العلامات المطلوبة عبر القائمة التي تُعيدها [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

المثال التالي يضيف تصنيفًا مختارًا يدويًا مرتبطًا بعلامتي التذييل والعلامة المائية، ثم يحفظ النتيجة كملف PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تحديث تصنيف حساس**

قِيَم [SensitivityLabel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/) قابلة للقراءة والكتابة، باستثناء القائمة التي تُعيدها [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) والتي تُعدَّل عبر عمليات القائمة الخاصة بها. بعد تحديد التصنيف المطلوب، يمكنك تحديث معرفه، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين، وحالة الإزالة، وأنواع العلامات المحتوى. احفظ العرض التقديمي لتطبيق التغييرات.

المثال التالي يحدّث حالة التفعيل وطريقة التعيين للتصنيف الأول:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تمييز تصنيف حساس كمُزالة**

للحفاظ على حقيقة أن التصنيف قد تمت إزالته، ابحث عن التصنيف واستدعِ [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#setRemoved) مع القيمة `true`. هذا يحتفظ بمدخل التصنيف مع تسجيل حالة إزالته. إذا كنت تحتاج بدلاً من ذلك إلى حذف مدخل من المجموعة الحديثة، استخدم [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcollection/#removeAt)؛ واستخدم [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcollection/#clear) لحذف جميع المدخلات.

المثال التالي يضع علامة على تصنيف محدد كمرَجع ويحفظ العرض التقديمي المحدث:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **قراءة وترحيل تصنيفات الحساسية القديمة من MIP**

يمكن لتدفقات العمل القديمة القائمة على MIP تخزين بيانات تعريف تصنيفات الحساسية في خصائص المستند المخصصة بدلاً من مجموعة التصنيفات الحديثة. اقرأ تلك البيانات باستخدام [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getSensitivityLabels). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وتعيد مصفوفة جافا من كائنات [SensitivityLabel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/).

للترحيل، أضف كل تصنيف تم إرجاعه إلى مجموعة [SensitivityLabelCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcollection/) الحديثة عبر [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcollection/#add). نظرًا لأن إضافة معرف تصنيف مكرر يسبب استثناءً، يتحقق المثال من المجموعة الوجهة قبل نسخ كل تصنيف. يمكنك إضافة تحقق إضافي للتأكد من أن كل تصنيف قديم لا يزال موجودًا في سياسة Purview الحالية.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تنقل النسخة المستخرجة من الكائنات إلى المجموعة الحديثة. لا يتطلب ذلك مسح جميع خصائص المستند المخصصة، لذا تظل البيانات الوصفية غير المتعلقة بالمستند سليمة. استخدم [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/) لكتابة بيانات تعريف التصنيفات الحديثة إلى ملف PPTX.

## **الأسئلة الشائعة**

**هل يؤدي إضافة نوع علامة محتوى إلى إنشاء رأس أو تذييل أو علامة مائية مرئية على الشرائح؟**

لا. القيم المضافة عبر القائمة التي تُعيدها [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) تصف العلامات المرتبطة بتصنيف الحساسية. هي لا تُنشئ نصًا أو أشكالًا مرئية في العرض التقديمي. أضف محتوى الشريحة المقابل بشكل منفصل إذا كان سير عملك يتوجب عرض تلك العلامات.

**ما الفرق بين وضع علامة على تصنيف كمُزالة وحذفّه من المجموعة؟**

استدعاء [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#setRemoved) مع القيمة `true` يحافظ على مدخل التصنيف ويسجل حالة إزالته. استدعاء [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) يحذف المدخل من المجموعة الحديثة. اختر العملية التي تتوافق مع متطلبات مؤسستك للاحتفاظ بالبيانات الوصفية.

**هل يمكن أن يحتوي عرض تقديمي على كلٍ من بيانات MIP القديمة وتصنيفات الحساسية الحديثة؟**

نعم. يمكن أن تظل التصنيفات القديمة في خصائص المستند المخصصة بينما تكون التصنيفات الحديثة متاحة عبر [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSensitivityLabels). استخدم [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getSensitivityLabels) لقراءة البيانات الوصفية القديمة وترحيل التصنيفات الصالحة فقط التي لا توجد بالفعل في المجموعة الحديثة.

**ماذا يحدث عندما يُضاف تصنيف بنفس المعرف أكثر من مرة؟**

يرفع [SensitivityLabelCollection::add](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabelcollection/#add) استثناءً عندما تحتوي المجموعة بالفعل على تصنيف بنفس المعرف. تحقق من القيم الموجودة التي تُعيدها [SensitivityLabel::getId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sensitivitylabel/#getId) قبل إضافة أو ترحيل التصنيفات.

**ما هو تنسيق الإخراج الذي يجب استخدامه للحفاظ على تصنيفات الحساسية المحدثة؟**

احفظ العرض التقديمي كملف PPTX عن طريق استدعاء [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/)، كما هو موضح في الأمثلة أعلاه.