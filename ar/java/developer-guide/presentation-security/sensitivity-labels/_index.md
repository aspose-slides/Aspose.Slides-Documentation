---
title: إدارة علامات الحساسية في عروض PowerPoint التقديمية باستخدام Java
linktitle: علامات الحساسية
type: docs
weight: 50
url: /ar/java/sensitivity-labels/
keywords:
- علامة حساسية
- Microsoft Purview
- حماية المعلومات من مايكروسوفت
- بيانات تعريف MIP
- تمييز المحتوى
- حماية المعلومات
- حوكمة المستندات
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Java
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل علامات الحساسية الخاصة بـ Microsoft Purview في عروض PowerPoint بصيغة PPTX باستخدام Aspose.Slides للغة Java."
---
## **نظرة عامة**

تساعد علامات الحساسية في Microsoft Purview المؤسسات على تصنيف المستندات وإدارتها. أثناء معالجة العروض التقديمية تلقائيًا، قد تحتاج التطبيقات إلى الحفاظ على علامة موجودة، أو تطبيق علامة مختارة حسب سياسة، أو تحديث حالتها، أو ترحيل بيانات تعريف العلامة المكتوبة بواسطة سير عمل Microsoft Information Protection (MIP) القديم.

تقوم Aspose.Slides بعرض بيانات تعريف علامة الحساسية الحديثة من خلال [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). تُعيد هذه الطريقة مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض التقديمي كملف PPTX.

{{% alert color="primary" title="Note" %}}
معرّفات علامات الحساسية ومعلومات السياسة يتم تعريفها في تكوين Microsoft Purview الخاص بك. قم بالتحقق من توفر العلامة ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل البيانات الوصفية. قيم [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) تصف علامات المحتوى المرتبطة بالعلامة؛ ولا تُضيف بنفسها نصًا أو أشكالًا مرئية إلى الشرائح.
{{% /alert %}}

## **فهم خصائص علامة الحساسية**

كل [ISensitivityLabel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/) يحتوي على البيانات الوصفية التالية:

| الطرق | الغرض |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getId--) و [ISensitivityLabel.setId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | الحصول على أو تعيين مُعرّف علامة الحساسية في سياسة Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getSiteId--) و [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | الحصول على أو تعيين الموقع المرتبط بسياسة العلامة. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#isEnabled--) و [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | الحصول على أو تعيين ما إذا كانت العلامة مفعّلة. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#isRemoved--) و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | الحصول على أو تعيين ما إذا تم إزالة العلامة. عيّن القيمة إلى `true` عندما يجب الاحتفاظ بحالة الإزالة في البيانات الوصفية. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) و [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | الحصول على أو تعيين ما إذا تم تطبيق العلامة تلقائيًا أو من خلال قرار المستخدم. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | الحصول على أنواع علامات المحتوى المرتبطة بالعلامة. |

تُعرّف الفئة [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelassignmenttype/) طريقة تعيين العلامة:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelassignmenttype/) يمثل علامة افتراضية أو تم تطبيقها تلقائيًا.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelassignmenttype/) يمثل علامة تم تطبيقها عبر قرار المستخدم، بما في ذلك العلامات المُطبقة يدويًا، والمقترحة، والملزمة.

تُعرّف الفئة [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالعلامة:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق العلامة افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | تُرتبط علامة محتوى الرأس بالعلامة. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | تُرتبط علامة محتوى التذييل بالعلامة. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | تُرتبط علامة محتوى العلامة المائية بالعلامة. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ar/java/com.aspose.slides/sensitivitylabelcontenttype/) | تُرتبط حماية التشفير بالعلامة. |

يمكن ربط أنواع متعددة من العلامات بواحدة.

## **قائمة علامات الحساسية الموجودة**

اقرأ مجموعة العلامات الحديثة من [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) وقم بتعدادها. المثال التالي يعرض كل خاصية وعلامة محتوى مخزنة لكل علامة:

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

## **إضافة علامة حساسية مع تعليم المحتوى**

استخدم [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) مع معرّف العلامة، ومعرّف الموقع، وحالة التفعيل، وطريقة التعيين. بعد أن تُعيد الطريقة كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/) الجديد، أضف قيم العلامات المطلوبة عبر القائمة التي تُعيدها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

المثال التالي يضيف علامة مختارة يدويًا مرتبطة بعلامات التذييل والعلامة المائية، ثم يحفظ النتيجة كملف PPTX:

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

## **تحديث علامة حساسية**

القيم في [ISensitivityLabel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/) قابلة للقراءة والكتابة، باستثناء القائمة التي تُعيدها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) والتي تُعدَّل من خلال عمليات القائمة. بعد تحديد العلامة المطلوبة، يمكنك تحديث معرّفها، ومعرّف الموقع، وحالة التفعيل، وطريقة التعيين، وحالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يُحدّث حالة التفعيل وطريقة التعيين للعلامة الأولى:

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

للحفاظ على حقيقة أن علامة ما تم إزالتها، ابحث عن العلامة واستدعِ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) بـ `true`. هذا يحتفظ بمدخل العلامة مع تسجيل حالة الإزالة. إذا كنت بحاجة إلى حذف مدخل من المجموعة الحديثة، استخدم [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); واستخدم [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#clear--) لحذف جميع المدخلات.

المثال التالي يضع علامة معينة كـ مُزالة ويحفظ العرض التقديمي المحدث:

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

## **قراءة وترحيل علامات الحساسية القديمة في MIP**

يمكن للتدفقات العاملة القديمة القائمة على MIP تخزين بيانات تعريف علامة الحساسية في خصائص مستند مخصصة بدلاً من مجموعة العلامات الحديثة. اقرأ تلك البيانات باستخدام [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وتعيد مصفوفة من كائنات [ISensitivityLabel](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/).

لترحيل البيانات الوصفية، أضف كل علامة تم إرجاعها إلى مجموعة العلامات الحديثة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/) عبر [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). نظرًا لأن إضافة معرّف علامة مكرر يثير استثناءً، يتحقق المثال من المجموعة الوجهة قبل نسخ كل علامة. يمكنك إضافة مزيد من التحقق للتأكد من أن كل علامة قديمة لا تزال موجودة في سياسة Purview الحالية.

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

تنقل العملية نسخ كائنات العلامة التي تم تحليلها إلى المجموعة الحديثة. لا يتطلب ذلك مسح جميع خصائص المستند المخصصة، لذا تظل البيانات الوصفية غير المتعلقة بالمستند سليمة. استخدم [IPresentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/) لكتابة بيانات تعريف العلامة الحديثة إلى ملف PPTX.

## **الأسئلة الشائعة**

**هل إنشاء نوع علامة محتوى يضيف رأسًا أو تذيلاً أو علامة مائية مرئية على الشرائح؟**

لا. القيم المضافة عبر القائمة التي تُعيدها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) تصف العلامات المرتبطة بعلامة الحساسية. لا تُنشئ نصًا أو أشكالًا مرئية في العرض التقديمي. أضف محتوى الشريحة المقابل بصورة منفصلة إذا كان سير عملك يتطلب عرض هذه العلامات.

**ما الفرق بين وضع علامة على العلامة كمزالة وحذفها من المجموعة؟**

استدعاء [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) بـ `true` يحافظ على مدخل العلامة ويسجل حالة الإزالة. استدعاء [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) يحذف المدخل من المجموعة الحديثة. اختر العملية التي تتوافق مع متطلبات مؤسستك للاحتفاظ بالبيانات الوصفية.

**هل يمكن للعرض التقديمي أن يحتوي على كلٍّ من بيانات MIP القديمة وعلامات الحساسية الحديثة؟**

نعم. يمكن أن تبقى العلامات القديمة في خصائص المستند المخصصة بينما تكون العلامات الحديثة متاحة عبر [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). استخدم [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) لقراءة البيانات الوصفية القديمة وترحيل فقط العلامات الصالحة التي لا توجد بالفعل في المجموعة الحديثة.

**ماذا يحدث عندما يتم إضافة علامة ذات معرّف متطابق أكثر من مرة؟**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) يثير استثناءً عندما تحتوي المجموعة بالفعل على علامة بنفس المعرّف. تحقق من القيم الموجودة التي تُعيدها [ISensitivityLabel.getId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isensitivitylabel/#getId--) قبل إضافة أو ترحيل العلامات.

**أي تنسيق إخراج يجب استخدامه للحفاظ على علامات الحساسية المحدثة؟**

احفظ العرض التقديمي كملف PPTX عن طريق استدعاء [IPresentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/)، كما هو موضح في الأمثلة أعلاه.