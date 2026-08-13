---
title: إدارة تسميات الحساسية في عروض PowerPoint التقديمية على Android
linktitle: تسميات الحساسية
type: docs
weight: 50
url: /ar/androidjava/sensitivity-labels/
keywords:
- تسمية حساسية
- Microsoft Purview
- Microsoft Information Protection
- بيانات تعريف MIP
- علامة المحتوى
- حماية المعلومات
- حوكمة المستندات
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل تسميات الحساسية من Microsoft Purview في عروض PowerPoint بصيغة PPTX باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **نظرة عامة**

تساعد تسميات الحساسية في Microsoft Purview المؤسسات على تصنيف الوثائق وإدارتها. أثناء معالجة العرض التقديمي تلقائيًا، قد يحتاج التطبيق إلى الحفاظ على تسمية موجودة، أو تطبيق تسمية مختارة بواسطة سياسة، أو تحديث حالتها، أو ترحيل بيانات تعريف التسمية التي كتبها سير عمل Microsoft Information Protection (MIP) أقدم.

تقوم Aspose.Slides for Android via Java بتوفير بيانات تعريف تسميات الحساسية الحديثة من خلال [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). تُعيد هذه الطريقة مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض التقديمي بصيغة PPTX.

{{% alert color="info" title="Note" %}}
معرفات تسميات الحساسية ومعلومات السياسة تُعرّفها تكوينات Microsoft Purview الخاصة بك. تحقق من توفر التسميات ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل البيانات الوصفية. قيم [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) تصف علامات المحتوى المرتبطة بتسمية؛ وهي لا تضيف نصًا مرئيًا أو أشكالًا إلى الشرائح بحد ذاتها.
{{% /alert %}}

## **فهم خصائص تسمية الحساسية**

كل [ISensitivityLabel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/) يحتوي على البيانات الوصفية التالية:

| الطرق | الغرض |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getId--) و[ISensitivityLabel.setId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | الحصول على معرف تسمية الحساسية في سياسة Purview أو تعيينه. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) و[ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | الحصول على معرف الموقع المرتبط بسياسة التسمية أو تعيينه. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) و[ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | معرفة ما إذا كانت التسمية مفعّلة أو تعيين هذا الحالة. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) و[ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | معرفة ما إذا كانت التسمية قد أُزيلت أو تعيين ذلك. اضبط القيمة إلى `true` عندما يجب احتفاظ حالة الإزالة في البيانات الوصفية. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) و[ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | معرفة ما إذا تم تطبيق التسمية تلقائيًا أو من خلال قرار المستخدم. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | الحصول على أنواع علامات المحتوى المرتبطة بالتسمية. |

تعرف فئة [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) كيفية تعيين التسمية:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) تمثّل تسمية افتراضية أو مطبقة تلقائيًا.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) تمثّل تسمية مطبقة عبر قرار المستخدم، بما في ذلك التسمية المطبقة يدويًا، والمقترحة، والملزمة.

تعرف فئة [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالتسمية:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق التسمية افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى الرأس مرتبطة بالتسمية. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى التذييل مرتبطة بالتسمية. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | علامة محتوى العلامة المائية مرتبطة بالتسمية. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | حماية التشفير مرتبطة بالتسمية. |

يمكن ربط أنواع علامات متعددة بتسمية واحدة.

## **قائمة تسميات الحساسية الموجودة**

اقرأ مجموعة التسميات الحديثة من [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) وقم بتعدادها. المثال التالي يسرد كل خاصية وعلامة محتوى مخزّنة لكل تسمية:

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

## **إضافة تسمية حساسية مع علامة محتوى**

استخدم [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) مع معرف التسمية، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين. بعد عودة الطريقة كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/)، أضف قيم العلامة المطلوبة عبر القائمة التي تُرجعها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

المثال التالي يضيف تسمية مختارة يدويًا مرتبطة بعلامات التذييل والعلامة المائية، ثم يحفظ النتيجة بصيغة PPTX:

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

## **تحديث تسمية حساسية**

قِيَم [ISensitivityLabel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/) قابلة للقراءة/الكتابة، باستثناء القائمة التي تُرجعها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) التي تُعدَّل عبر عمليات القائمة الخاصة بها. بعد تحديد التسمية المطلوبة، يمكنك تحديث معرفها، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين، وحالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يحدث حالة التفعيل وطريقة التعيين للتسمية الأولى:

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

## **وضع علامة إزالة على تسمية حساسية**

للحفاظ على حقيقة أن التسمية قد أُزيلت، ابحث عن التسمية واستدعِ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) مع `true`. سيبقى السجل موجودًا مع تسجيل حالة الإزالة. إذا كنت تحتاج إلى حذف إدخال من المجموعة الحديثة، استخدم [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); واستخدم [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) لحذف جميع الإدخالات.

المثال التالي يضع علامة إزالة على تسمية معينة ويحفظ العرض المحدث:

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

## **قراءة وترحيل تسميات حساسية MIP القديمة**

يمكن أن تُخزن سير عمل MIP الأقدم بيانات تعريف تسميات الحساسية في خصائص المستند المخصصة بدلًا من مجموعة التسميات الحديثة. اقرأ تلك البيانات باستخدام [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وترجع مصفوفة من كائنات [ISensitivityLabel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/).

لترحيل البيانات الوصفية، أضف كل تسمية مُسترجَعة إلى [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/) الحديثة عبر [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). لأن إضافة معرف تسمية مكرر يثير استثناءً، يتحقق المثال من المجموعة الوجهة قبل نسخ كل تسمية. يمكنك إضافة مزيد من التحقق للتأكد من أن كل تسمية قديمة لا تزال موجودة في سياسة Purview الحالية.

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

تنقل العملية كائنات التسمية التي تم تحليلها إلى المجموعة الحديثة. لا تحتاج إلى مسح جميع الخصائص المخصصة للمستند، لذا تبقى البيانات الوصفية غير المتعلقة سليمة. استخدم [IPresentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/) لكتابة بيانات تعريف التسميات الحديثة إلى ملف PPTX.

## **الأسئلة المتكررة**

**هل يؤدي إضافة نوع علامة محتوى إلى إنشاء رأس أو تذييل أو علامة مائية مرئية في الشرائح؟**

لا. القيم التي تُضاف عبر القائمة التي تُرجعها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) تصف العلامات المرتبطة بتسمية الحساسية. لا تُنشئ نصًا أو أشكالًا مرئية في العرض التقديمي. أضف المحتوى المقابل للشرائح بشكل منفصل إذا كان سير عملك يتطلب عرض تلك العلامات.

**ما الفرق بين وضع علامة إزالة على تسمية وحذفها من المجموعة؟**

استدعاء [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) مع `true` يحافظ على سجل التسمية ويسجل حالة الإزالة. استدعاء [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) يحذف السجل من المجموعة الحديثة. اختر العملية التي تتماشى مع متطلبات احتفاظ منظمتك بالبيانات الوصفية.

**هل يمكن أن يحتوي عرض تقديمي على كلٍ من بيانات MIP القديمة وتسميات حساسية حديثة؟**

نعم. يمكن أن تبقى التسميات القديمة في خصائص المستند المخصصة بينما تكون التسميات الحديثة متاحة عبر [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). استخدم [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) لقراءة البيانات الوصفية القديمة وترحيل التسميات الصالحة فقط التي ليست موجودة بالفعل في المجموعة الحديثة.

**ماذا يحدث عندما تُضاف تسمية بنفس المعرف أكثر من مرة؟**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) يثير استثناءً إذا كانت المجموعة déjà تحتوي على تسمية بنفس المعرف. تحقق من القيم الموجودة التي تُرجعها [ISensitivityLabel.getId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getId--) قبل إضافة أو ترحيل التسميات.

**أي تنسيق إخراج يجب استخدامه للحفاظ على التسميات الحساسية المحدثة؟**

احفظ العرض التقديمي بصيغة PPTX عبر استدعاء [IPresentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/)، كما هو موضح في الأمثلة أعلاه.