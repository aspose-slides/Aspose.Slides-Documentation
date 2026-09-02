---
title: "إدارة العلامات والبيانات المخصصة في العروض التقديمية باستخدام Java"
linktitle: "العلامات والبيانات المخصصة"
type: docs
weight: 300
url: /ar/java/managing-tags-and-custom-data/
keywords:
- "خصائص المستند"
- "علامة"
- "بيانات مخصصة"
- "XML مخصص"
- "جزء XML مخصص"
- "بيانات وصفية XML"
- ItemId
- "إضافة علامة"
- "قيم مزدوجة"
- PowerPoint
- "عرض تقديمي"
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة العلامات والبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides for Java، بما في ذلك الإضافة، القراءة، التحديث، التدقيق، وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

هذه المقالة توضح كيفية عمل Aspose.Slides مع العلامات (tags) والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كعلامات أو كأجزاء XML مخصصة. العلامات هي أزواج مفتاح‑قيمة نصية بسيطة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات وصفية منظمة وحمولات XML خاصة بالتطبيق.

توفر Aspose.Slides واجهات برمجة تطبيقات لإضافة، قراءة، تحديث، تدقيق، وإزالة أجزاء XML المخصصة على مستوى العرض، الشريحة، والشكل. تُعد أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرفات إدارة المستندات، حالة سير العمل، بيانات الوصف المتوافق، بيانات ربط القوالب، أو أي بيانات تطبيق منظمة أخرى داخل العرض.

## **تخزين البيانات في ملفات العروض التقديمية**

ملفات PPTX — الملفات ذات الامتداد `.pptx` — تُخزن بصيغة PresentationML، وهي جزء من مواصفة Office Open XML. تُعرف Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة به.

يحتوي العرض على عدة أجزاء متصلة عبر علاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة مع أجزاء أخرى محددة وفقًا لـ ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITagCollection)) أو كأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPartCollection)). كلاهما متاح عبر واجهة [`ICustomData`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomData/) .

{{% alert color="primary" %}}
العلامات تخزن أزواج مفتاح‑قيمة نصية بسيطة. أجزاء XML المخصصة تخزن بيانات XML منظمة ويمكن ربطها بالعرض أو الشريحة أو الشكل.
{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

طريقة [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomData#getCustomXmlParts--) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- `presentation.getCustomData().getCustomXmlParts()` تحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- `slide.getCustomData().getCustomXmlParts()` تحتوي على أجزاء XML المخصصة المرتبطة بشريحة محددة.
- `shape.getCustomData().getCustomXmlParts()` تحتوي على أجزاء XML المخصصة المرتبطة بشكل معين.

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن مكان ربطها.

### **إضافة جزء XML مخصص إلى عرض**

استخدم [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) لإضافة بيانات XML إلى مجموعة أجزاء XML المخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات وصفية منظمة إلى مجموعة البيانات المخصصة على مستوى العرض:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // تقوم الدالة add بتعيين معرف تلقائيًا. عيّن UUID محدد فقط عند الحاجة.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكن لطريقة `add` أيضًا قبول XML كمصفوفة بايت أو تيار إدخال، وهو ما يكون مفيدًا عندما يكون محتوى XML متوفرًا بالفعل في شكل ثنائي.

### **إضافة جزء XML مخصص إلى شريحة أو شكل**

يمكن ربط بيانات XML مخصصة بشريحة أو شكل معين بدلاً من ربطها بالعرض كله. هذا مفيد عندما تصف البيانات الوصفية كائنًا واحدًا فقط، مثل مفتاح قالب، معرف سجل خارجي، أو معلومات ربط.

المثال التالي يضيف جزء XML مخصص إلى شريحة وآخر إلى شكل:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المستوى الذي يُضاف فيه الجزء يحدّد أي مجموعة `getCustomData().getCustomXmlParts()` ستحتوي على العلاقة بالجزء. البيانات على مستوى العرض مناسبة للبيانات الوصفية على مستوى المستند بأكمله، وبيانات مستوى الشريحة للمعلومات التي تخص شريحة معينة، وبيانات مستوى الشكل للبيانات المرتبطة بصورة فردية.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) لاسترجاع جميع أجزاء XML المخصصة من العرض. كل كائن [`ICustomXmlPart`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart/) يكشف عن مُعرّفه، محتوى XML، ومخططات الفضاء الاسمي المرتبطة به.

المثال التالي يسرد جميع أجزاء XML المخصصة ومخططات الفضاء الاسمي الخاصة بها:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

تُعيد طريقة [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) مخططات XML المرتبطة بالجزء المخصص. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML تم إنشاؤه بواسطة أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرف العنصر (ItemId)**

استخدم [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) و[`setXmlAsString()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) للعمل مع XML كسلسلة UTF‑8، أو استخدم [`getXmlData()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart#getXmlData--) و[`setXmlData()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) للعمل مع بايتات XML الخام.

تُعيد طريقة [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart#getItemId--) معرف UUID الذي يحدد الجزء المخصص في مستند Office Open XML. استخدم [`setItemId()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) عندما تتطلب عملية التكامل معرفًا جديدًا.

المثال التالي يُحدّث محتوى XML والمعرف:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // قراءة XML الحالي كنص.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // تحديث XML كسلسلة UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // توفر getXmlData نفس محتوى XML كـ بايتات خام.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // استبدال المعرف عندما يتطلب ذلك التكامل.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

عند استدعاء `setXmlAsString` أو `setXmlData`، قدم XML صالحًا وغير فارغ. استخدم تمثيلًا واحدًا أو آخر حسب ما إذا كان التطبيق يعمل أساسًا مع سلاسل نصية أو بيانات بايت.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML المخصصة:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPart#remove--) يزيل الجزء المخصص من العرض.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) يزيل جزءًا محددًا من مجموعة أجزاء XML المخصصة.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) يزيل الجزء عند فهرس مجموعة محدد.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ICustomXmlPartCollection#clear--) يزيل جميع الأجزاء من مجموعة معينة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض بواسطة الإشارة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كان لديك بالفعل كائن `ICustomXmlPart` وتريد إزالة هذا الجزء من العرض بدلاً من استهداف مجموعة معينة، استدعِ `customXmlPart.remove()`.

يمكنك أيضًا إزالة عنصر بواسطة الفهرس:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **مسح جميع أجزاء XML المخصصة من مجموعة**

استخدم `clear` عندما يجب إزالة جميع أجزاء XML المخصصة المرتبطة بكائن عرض معين.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` يؤثر فقط على المجموعة المختارة. على سبيل المثال، مسح مجموعة شريحة لا يمسح مجموعات مستوى العرض أو مستوى الشكل.

لإزالة كل جزء XML مخصص في العرض، كرّر عبر `getAllCustomXmlParts()` وأزل كل جزء:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **معالجة أجزاء XML مخصصة مرتبطة أو مشتركة**

في عرض Office Open XML، يمكن الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف قائم على علاقات من عدة شرائح أو أشكال إلى نفس الجزء الأساسي.

يجب اعتبار الجزء المشترك ككائن بيانات واحد مع مراجع متعددة:

- تحديثه باستخدام `setXmlAsString` أو `setXmlData` أو `setItemId` يغيّر الجزء الأساسي، فتنتقل التغييرات إلى كل الأماكن التي تُشير إليه.
- يمكن استخدام `getItemId()` لتحديد نفس جزء XML المخصص أثناء تدقيق مجموعات الكائنات.
- إزالة جزء من مجموعة `getCustomXmlParts()` معينة يزيله فقط من تلك المجموعة. استخدم `ICustomXmlPart.remove()` عندما يجب إزالة الجزء نفسه من العرض بالكامل.
- قبل حذف أو استبدال جزء مشترك، افحص مجموعات الكائنات لتحديد ما إذا كانت شرائح أو أشكال أخرى لا تزال تشير إليه.

إنّ تحميل أزور `add` ينشئ جزء XML مخصص جديد من محتوى XML؛ لا يقبل جزءًا موجودًا من نوع `ICustomXmlPart`. لذلك تُظهر العلاقات المشتركة غالبًا عند تحميل عروض تحتوي عليها مسبقًا.

المثال التالي يدقق مجموعات العرض، الشريحة، والشكل حسب `ItemId` ويُبلّغ عن الأجزاء التي تُشير إليها أكثر من موضع:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML المخصصة في عروض تم إنشاؤها بواسطة أنظمة خارجية، لأن جزء الوصف نفسه قد يشارك في أكثر من علاقة.

## **الحصول على قيم العلامات**

في الشرائح، تمثل العلامة الطريقة `IDocumentProperties.getKeywords()`. يُظهر هذا المثال البرمجي كيفية الحصول على قيمة العلامة باستخدام Aspose.Slides for Java لـ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **إضافة علامات إلى العروض**

تسمح لك Aspose.Slides بإضافة علامات إلى العروض. تتكون العلامة عادةً من عنصرين:

- اسم الخاصية المخصصة، على سبيل المثال `MyTag`؛
- قيمة الخاصية المخصصة، على سبيل المثال `My Tag Value`.

إذا كنت بحاجة إلى تصنيف العروض وفق قاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا أردت تصنيف العروض حسب دول أمريكا الشمالية، يمكنك إنشاء علامة "North American" وتعيين البلد المناسب كقيمة لها.

هذا المثال البرمجي يوضح كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) باستخدام Aspose.Slides for Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

يمكن أيضًا تعيين علامات لـ [Slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlide):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

أو لكائن [Shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape) فردي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **القيود**

العلامات التي تُضاف عبر مجموعة `getCustomData().getTags()` تُخزن فقط في ملف PowerPoint. **لا** تُنقل إلى بنية العلامات في PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع معرف مخصص تم تعيينه كعلامة من ملف PDF الموسوم.

**حل**: يمكنك تخزين معرف مخصص في **النص البديل** للكائن (مثلاً `shape.setAlternativeText("MyId")`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية العلامات في PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [مجموعة العلامات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tagcollection/#clear--) التي تحذف جميع أزواج المفتاح‑قيمة دفعة واحدة.

**كيف أحذف علامة واحدة باستخدام اسمها دون iterating عبر المجموعة بأكملها؟**

استخدم `remove(name)` على [مجموعة العلامات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات لأغراض التحليل أو التصفية؟**

استخدم `getNamesOfTags` على [مجموعة العلامات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tagcollection/); تُعيد مصفوفة تضم جميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن مكان تخزينها؟**

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب علي استخدام `getXmlAsString`/`setXmlAsString` أم `getXmlData`/`setXmlData` لتحديث جزء XML مخصص؟**

استخدم `getXmlAsString` و `setXmlAsString` عندما يعمل التطبيق مع نص XML بترميز UTF‑8. استخدم `getXmlData` و `setXmlData` عندما يكون XML متوفرًا مسبقًا كمصفوفة بايت أو عندما تكون المعالجة الثنائية أكثر ملاءمة. تشير كلتا الطريقتين إلى محتوى XML لنفس الجزء المخصص.