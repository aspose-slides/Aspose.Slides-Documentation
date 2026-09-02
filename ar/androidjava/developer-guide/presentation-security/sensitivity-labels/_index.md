---
title: إدارة تصنيفات الحساسية في عروض PowerPoint التقديمية على Android
linktitle: تصنيفات الحساسية
type: docs
weight: 50
url: /ar/androidjava/sensitivity-labels/
keywords:
- تصنيف الحساسية
- Microsoft Purview
- Microsoft Information Protection
- بيانات تعريف MIP
- علامة المحتوى
- حماية المعلومات
- حوكمة المستند
- PowerPoint
- PPTX
- أمن العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "قراءة وإضافة وتحديث وإزالة وترحيل تصنيفات الحساسية في Microsoft Purview لعروض PowerPoint PPTX باستخدام Aspose.Slides for Android عبر Java."
---
## **نظرة عامة**

تساعد تصنيفات الحساسية في Microsoft Purview المؤسسات على تصنيف الوثائق وإدارتها. أثناء معالجة العروض التقديمية بشكل آلي، قد تحتاج التطبيق إلى الحفاظ على تصنيف موجود، أو تطبيق تصنيف مختار بواسطة سياسة، أو تحديث حالته، أو ترحيل بيانات التعريف الخاصة بالتصنيف التي كتبها سير عمل Microsoft Information Protection (MIP) الأقدم.

يُظهر Aspose.Slides for Android via Java بيانات تعريفية حديثة لتصنيفات الحساسية عبر [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). تُرجع هذه الطريقة مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/) يمكن فحصها وتعديلها قبل حفظ العرض التقديمي بصيغة PPTX.

{{% alert color="primary" title="Note" %}}

معرفات تصنيفات الحساسية ومعلومات السياسات تُحدَّد بواسطة تكوين Microsoft Purview الخاص بك. تحقق من توافر التصنيف ومتطلبات السياسة في بيئتك قبل إضافة أو ترحيل بيانات التعريف. قيم [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) تُوصف العلامات المرتبطة بالتصنيف؛ وهي لا تُضيف نصًا أو أشكالًا مرئية إلى الشرائح بحد ذاتها.

{{% /alert %}}

## **فهم خصائص تصنيف الحساسية**

كل [ISensitivityLabel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/) يحتوي على البيانات التعريفية التالية:

| الطريقة | الغرض |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getId--) و [ISensitivityLabel.setId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | الحصول على معرف تصنيف الحساسية في سياسة Purview أو ضبطه. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) و [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | الحصول على معرف الموقع المرتبط بسياسة التصنيف أو ضبطه. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) و [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | معرفة ما إذا كان التصنيف مفعَّلًا أو ضبط الحالة. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) و [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | معرفة ما إذا كان التصنيف قد أُزيل أو ضبط الحالة. اضبط القيمة إلى `true` عندما يجب الاحتفاظ بحالة الإزالة في البيانات التعريفية. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) و [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | معرفة ما إذا كان التصنيف قد طُبق تلقائيًا أو عبر قرار المستخدم أو ضبط الطريقة. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | الحصول على أنواع العلامات المرتبطة بالتصنيف. |

تُعرِّف الفئة [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) كيفية تعيين التصنيف:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) يُمثل تصنيفًا افتراضيًا أو مطبقًا تلقائيًا.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) يُمثل تصنيفًا طُبق عبر قرار المستخدم، بما في ذلك التصنيفات المطبقة يدويًا، والموصى بها، والإلزامية.

تُعرِّف الفئة [SensitivityLabelContentType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) العلامة المرتبطة بالتصنيف:

| القيمة | المعنى |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | تم تطبيق التصنيف افتراضيًا أو تلقائيًا. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | توجد علامة محتوى رأسية مرتبطة بالتصنيف. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | توجد علامة محتوى تذييلية مرتبطة بالتصنيف. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | توجد علامة محتوى شفافية (علامة مائية) مرتبطة بالتصنيف. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | توجد حماية تشفير مرتبطة بالتصنيف. |

يمكن ربط عدة أنواع علامات بتصنيف واحد.

## **قائمة تصنيفات الحساسية الحالية**

اقرأ مجموعة التصنيفات الحديثة من [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) وقم بتعدادها. المثال التالي يُظهر كل خاصية وعلامة محتوى مُخزّنة لكل تصنيف:

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

## **إضافة تصنيف حساسية مع علامة محتوى**

استخدم [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) مع معرف التصنيف، ومعرف الموقع، وحالة التفعيل، وطريقة التعيين. بعد أن تُعيد الطريقة كائن [ISensitivityLabel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/) جديد، أضف قيم العلامات المطلوبة عبر القائمة التي تُرجعها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

المثال التالي يضيف تصنيفًا مُختارًا يدويًا مرتبطًا بعلامتي تذييل وشفافية، ثم يحفظ النتيجة بصيغة PPTX:

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

## **تحديث تصنيف الحساسية**

قِيَم [ISensitivityLabel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/) قابلة للقراءة والكتابة، باستثناء القائمة التي تُرجعها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) والتي تُعدَّل عبر عمليات القائمة. بعد تحديد التصنيف المطلوب، يمكنك تحديث معرّفه، ومعرّف الموقع، وحالة التفعيل، وطريقة التعيين، وحالة الإزالة، وأنواع علامات المحتوى. احفظ العرض التقديمي لتثبيت التغييرات.

المثال التالي يحدث حالة التفعيل وطريقة التعيين للتصنيف الأول:

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

## **وضع علامة على تصنيف حساسية كـ "مُزال"**

للحفاظ على حقيقة أن تصنيفًا ما تم إزالته، ابحث عن التصنيف واستدعِ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) مع `true`. سيبقى الإدخال موجودًا مع تسجيل حالة الإزالة. إذا كنت تحتاج إلى حذف الإدخال من المجموعة الحديثة، استخدم [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); واستخدم [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) لحذف جميع الإدخالات.

المثال التالي يضع علامة "مُزال" على تصنيف محدد ويُحفظ العرض التقديمي المحدث:

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

## **قراءة وترحيل تصنيفات الحساسية القديمة من MIP**

يمكن لسير العمل القائم على MIP تخزين بيانات تعريف تصنيف الحساسية في خصائص مستند مخصصة بدلاً من مجموعة التصنيفات الحديثة. اقرأ تلك البيانات باستخدام [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). تقوم الطريقة بتحليل الخصائص المخصصة القديمة وتُرجع مصفوفة من كائنات [ISensitivityLabel](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/).

لترحيل البيانات، أضف كل تصنيف مسترجع إلى مجموعة [ISensitivityLabelCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/) الحديثة عبر [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). لأن إضافة معرف تصنيف مكرر يُثير استثناءً، يتحقق المثال من المجموعة الوجهة قبل نسخ كل تصنيف. يمكنك إضافة تحقق إضافي للتأكد من أن كل تصنيف قديم لا يزال موجودًا في سياسة Purview الحالية.

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

تقوم عملية الترحيل بنسخ كائنات التصنيف المُحلَّلة إلى المجموعة الحديثة. لا يتطلب ذلك مسح جميع الخصائص المخصصة للمستند، لذا تظل البيانات التعريفية غير ذات الصلة سليمة. استخدم [IPresentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/) لكتابة بيانات تعريف التصنيف الحديثة إلى ملف PPTX.

## **الأسئلة الشائعة**

**هل يؤدي إضافة نوع علامة محتوى إلى إنشاء رأس أو تذييل أو علامة مائية مرئية على الشرائح؟**

لا. القيم التي تُضاف عبر القائمة التي تُرجعها [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) تصف العلامات المرتبطة بتصنيف الحساسية. هي لا تُنشئ نصًا أو أشكالًا مرئية في العرض التقديمي. أضف محتوى الشرائح المناسب منفصلًا إذا كان سير العمل يتطلب عرض تلك العلامات.

**ما الفرق بين وضع علامة "مُزال" على التصنيف وحذفها من المجموعة؟**

استدعاء [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) مع `true` يُبقي إدخال التصنيف ويسجل حالة الإزالة. استدعاء [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) يحذف الإدخال من المجموعة الحديثة. اختر العملية التي تتطابق مع متطلبات الاحتفاظ بالبيانات في مؤسستك.

**هل يمكن للعرض التقديمي أن يحتوي على كل من بيانات MIP القديمة وتصنيفات الحساسية الحديثة؟**

نعم. يمكن أن تظل التصنيفات القديمة في خصائص المستند المخصصة بينما تكون التصنيفات الحديثة متاحة عبر [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). استخدم [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) لقراءة البيانات القديمة وترحيل التصنيفات الصالحة فقط التي ليست موجودة بالفعل في المجموعة الحديثة.

**ماذا يحدث إذا تم إضافة تصنيف بنفس المعرف أكثر من مرة؟**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) يطرح استثناءً عندما تحتوي المجموعة بالفعل على تصنيف بنفس المعرف. تحقق من القيم الموجودة التي تُرجعها [ISensitivityLabel.getId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isensitivitylabel/#getId--) قبل إضافة أو ترحيل التصنيفات.

**أي تنسيق إخراج ينبغي استخدامه للحفاظ على التصنيفات المحدثة؟**

احفظ العرض التقديمي بصيغة PPTX عبر استدعاء [IPresentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/)، كما هو موضح في الأمثلة أعلاه.