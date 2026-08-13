---
title: إدارة علامات الحساسية في عروض PowerPoint التقديمية باستخدام Java
linktitle: علامات الحساسية
type: docs
weight: 50
url: /ar/java/sensitivity-labels/
keywords:
- علامة حساسية
- Microsoft Purview
- Microsoft Information Protection
- بيانات تعريفية MIP
- تمييز المحتوى
- حماية المعلومات
- حوكمة المستندات
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Java
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل علامات الحساسية في Microsoft Purview في عروض PowerPoint بتنسيق PPTX باستخدام Aspose.Slides لـ Java."
---
## **نظرة عامة**

تساعد علامات الحساسية في Microsoft Purview المؤسسات على تصنيف المستندات وحكمتها. أثناء معالجة العروض التقديمية تلقائيًا، قد تحتاج تطبيقات إلى الحفاظ على علامة موجودة، أو تطبيق علامة مختارة بواسطة سياسة، أو تحديث حالتها، أو ترحيل بيانات علامة مكتوبة بواسطة سير عمل Microsoft Information Protection (MIP) أقدم.

تُظهر Aspose.Slides بيانات علامات الحساسية الحديثة من خلال [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). تُعيد هذه الطريقة مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض التقديمي كملف PPTX.

{{% alert color="info" title="Note" %}}
معرفات علامات الحساسية ومعلومات السياسة تُحدد بواسطة تكوين Microsoft Purview الخاص بك. تحقق من توفر العلامة ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل البيانات الوصفية. قيم [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) تصف علامات المحتوى المرتبطة بالعلامة؛ فهي لا تُضيف نصًا مرئيًا أو أشكالًا إلى الشرائح بحد ذاتها.
{{% /alert %}}

## **فهم خصائص علامة الحساسية**

كل [ISensitivityLabel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/) يحتوي على البيانات الوصفية التالية:

| الطرق | الغرض |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getId--) و [ISensitivityLabel.setId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | الحصول على معرف علامة الحساسية في سياسة Purview أو تعيينه. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getSiteId--) و [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | الحصول على موقع الويب المرتبط بسياسة العلامة أو تعيينه. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#isEnabled--) و [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | معرفة ما إذا كانت العلامة مفعَّلة أو تعيين ذلك. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#isRemoved--) و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | معرفة ما إذا كانت العلامة قد أزيلت أو تعيين ذلك. اضبط القيمة على `true` عندما يجب الاحتفاظ بحالة الإزالة في البيانات الوصفية. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) و [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | معرفة ما إذا تم تطبيق العلامة تلقائيًا أو عن طريق قرار المستخدم أو تعيين ذلك. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | الحصول على أنواع علامات المحتوى المرتبطة بالعلامة. |

تُعرِّف الفئة [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelassignmenttype/) طريقة تعيين العلامة:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelassignmenttype/) تمثّل علامة افتراضية أو مُطبَّقة تلقائيًا.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelassignmenttype/) تمثّل علامة مُطبَّقة عبر قرار المستخدم، بما في ذلك العلامات المُطبَّقة يدويًا، المقترحة، والإلزامية.

تُعرِّف الفئة [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالعلامة:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق العلامة افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى رأس مرتبطة بالعلامة. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى تذييل مرتبطة بالعلامة. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى علامة مائية مرتبطة بالعلامة. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | حماية تشفير مرتبطة بالعلامة. |

يمكن ربط أنواع علامات متعددة بعلامة واحدة.

## **قائمة علامات الحساسية الموجودة**

اقرأ مجموعة العلامات الحديثة من [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) وقم بتعدادها. المثال التالي يُظهر كل خاصية وعلامة محتوى مخزَّنة لكل علامة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **إضافة علامة حساسية مع علامة محتوى**

استخدم [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) مع معرف العلامة، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين. بعد أن تُعيد الطريقة الـ[ISensitivityLabel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/) الجديد، أضف قيم العلامات المطلوبة عبر القائمة التي تُعيدها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

المثال التالي يضيف علامة مختارة يدويًا مرتبطة بعلامات تذييل وعلامة مائية، ثم يحفظ النتيجة كملف PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تحديث علامة الحساسية**

القيم في [ISensitivityLabel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/) قابلة للقراءة والكتابة، باستثناء القائمة التي تُعيدها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) التي يتم تعديلها عبر عمليات القائمة. بعد تحديد العلامة المطلوبة، يمكنك تحديث معرفها، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين، وحالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يُحدِّث حالة التفعيل وطريقة التعيين للعلامة الأولى:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **وضع علامة حساسية كمزالة**

للحفاظ على حقيقة أن العلامة أزيلت، اعثر على العلامة واستدعِ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) مع `true`. هذا يُبقي سجل العلامة مع تسجيل حالتها كـ مُزالة. إذا كنت بحاجة إلى حذف سجل من مجموعة العلامات الحديثة، استخدم [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); واستخدم [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#clear--) لحذف جميع السجلات.

المثال التالي يضع علامة محددة كمزالة ويحفظ العرض التقديمي المحدث:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قراءة وترحيل علامات الحساسية القديمة من MIP**

يمكن لتدفقات العمل القديمة القائمة على MIP تخزين بيانات علامة الحساسية في خصائص المستند المخصصة بدلًا من مجموعة العلامات الحديثة. اقرأ تلك البيانات باستخدام [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وتُعيد مصفوفة من كائنات [ISensitivityLabel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/).

لترحيل البيانات الوصفية، أضف كل علامة تم إرجاعها إلى مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/) الحديثة عبر [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). نظرًا لأن إضافة معرف علامة مكرَّر يثير استثناءً، يتحقق المثال من المجموعة المستهدفة قبل نسخ كل علامة. يمكنك إضافة تحقق إضافي للتأكد من أن كل علامة قديمة لا تزال موجودة في سياسة Purview الحالية.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تنسخ عملية الترحيل كائنات العلامات التي تم تحليلها إلى المجموعة الحديثة. لا تتطلب مسح جميع خصائص المستند المخصصة، لذا تبقى البيانات الوصفية غير المتعلقة بالمستند كما هي. استخدم [IPresentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/) لكتابة بيانات العلامات الحديثة إلى ملف PPTX.

## **الأسئلة المتكررة**

**هل إنشاء نوع علامة محتوى يُنشئ عنوانًا مرئيًا أو تذييلًا أو علامة مائية على الشرائح؟**

لا. القيم التي تُضاف عبر القائمة التي تُعيدها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) تصف العلامات المرتبطة بعلامة الحساسية. هي لا تُنشئ نصًا مرئيًا أو أشكالًا في العرض التقديمي. أضف محتوى الشريحة المقابل بشكل منفصل إذا كان سير العمل الخاص بك يحتاج إلى عرض تلك العلامات.

**ما الفرق بين وضع علامة كـ مُزالة وحذفها من المجموعة؟**

استدعاء [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) مع `true` يحافظ على سجل العلامة ويسجل حالتها كمزالة. استدعاء [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) يحذف السجل من المجموعة الحديثة. اختر العملية التي تتماشى مع متطلبات احتفاظ مؤسستك بالبيانات الوصفية.

**هل يمكن للعرض التقديمي أن يحتوي على بيانات MIP القديمة وعلامات حساسية حديثة في آنٍ واحد؟**

نعم. يمكن أن تبقى العلامات القديمة في خصائص المستند المخصصة بينما تكون العلامات الحديثة متاحة عبر [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). استخدم [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) لقراءة البيانات القديمة وترحيل العلامات الصالحة التي لا توجد بالفعل في المجموعة الحديثة.

**ماذا يحدث إذا أضيفت علامة بنفس المعرف أكثر من مرة؟**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) يثير استثناءً عندما تحتوي المجموعة بالفعل على علامة بنفس المعرف. تحقق من القيم الموجودة التي تُعيدها [ISensitivityLabel.getId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getId--) قبل إضافة أو ترحيل العلامات.

**أي تنسيق إخراج ينبغي استخدامه للحفاظ على علامات الحساسية المحدثة؟**

احفظ العرض التقديمي كملف PPTX عبر استدعاء [IPresentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/)، كما هو موضح في الأمثلة أعلاه.