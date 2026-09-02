---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية على Android
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/androidjava/managing-tags-and-custom-data
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- XML مخصص
- جزء XML مخصص
- بيانات تعريف XML
- ItemId
- إضافة علامة
- قيم زوجية
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة العلامات وبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides لنظام Android عبر Java، بما في ذلك الإضافة والقراءة والتحديث والتدقيق وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

يشرح هذا المقال كيفية عمل Aspose.Slides مع العلامات (tags) والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كعلامات أو كأجزاء XML مخصصة. العلامات هي أزواج بسيطة من السلاسل المفتاح‑القيمة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات تعريفية منظمة وحملات XML خاصة بالتطبيق.

توفر Aspose.Slides واجهات برمجة تطبيقات لإضافة وقراءة وتحديث وتدقيق وإزالة أجزاء XML المخصصة على مستوى العرض والشريحة والشكل. تُعد أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرّفات إدارة المستندات، حالة سير العمل، بيانات تعريفية للامتثال، بيانات ربط القوالب، أو أي بيانات تطبيق منظمة أخرى داخل العرض.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX — الملفات ذات الامتداد `.pptx` — تُخزن بصيغة PresentationML، وهي جزء من مواصفات Office Open XML. تُعرّف Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة به.

يتكون العرض من عدة أجزاء مرتبطة بعلاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة مع أجزاء أخرى مُعرفة وفقًا للمعيار ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITagCollection)) أو كأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection)). كلاهما متاح عبر واجهة [`ICustomData`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomData/).

{{% alert color="primary" %}}
العلامات تخزن أزواج مفتاح‑قيمة نصية بسيطة. أجزاء XML المخصصة تخزن بيانات XML منظمة ويمكن ربطها بالعرض أو الشريحة أو الشكل.
{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

تُعيد الطريقة [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) مجموعة أجزاء XML المخصصة المرتبطة لكائن عرض معين. على سبيل المثال:

- `presentation.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- `slide.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشريحة محددة.
- `shape.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشكل محدد.

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن موقع ربطها.

### **إضافة جزء XML مخصص إلى عرض**

استخدم [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) لإضافة بيانات XML إلى مجموعة أجزاء XML المخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات تعريفية منظمة إلى مجموعة البيانات المخصصة على مستوى العرض:

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

    // يضيف تعيين معرف تلقائيًا. قم بتعيين UUID محدد فقط عند الحاجة.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يمكن للطريقة `add` أيضًا قبول XML كمصفوفة بايت أو كـ InputStream، وهو ما يكون مفيدًا عندما يكون محتوى XML متاحًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصص إلى شريحة أو شكل**

يمكن ربط بيانات XML مخصصة بشريحة أو شكل محدد بدلاً من كامل العرض. يكون هذا مفيدًا عندما تصف البيانات التعريفية كائنًا واحدًا فقط، مثل مفتاح القالب أو معرّف سجل خارجي أو معلومات ربط.

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

المستوى الذي يُضاف فيه الجزء يحدد أي مجموعة `getCustomData().getCustomXmlParts()` تحتوي على العلاقة إلى ذلك الجزء. البيانات على مستوى العرض مناسبة لتعاريف المستند ككل، بينما البيانات على مستوى الشريحة تناسب المعلومات التي تخص شريحة معينة، والبيانات على مستوى الشكل تناسب التعريفات المرتبطة بشكل فردي.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) لاسترجاع جميع أجزاء XML المخصصة من العرض. كل كائن [`ICustomXmlPart`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart/) يكشف عن معرّفه ومحتوى XML ومخططات الفضاء الاسمي المرتبطة.

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

تُعيد الطريقة [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) مخططات XML المرتبطة بالجزء المخصص. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML تم إنشاؤه بواسطة أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرّف العنصر (ItemId)**

استخدم [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) و[`setXmlAsString()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) للعمل مع XML كسلسلة UTF‑8، أو استخدم [`getXmlData()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) و[`setXmlData()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) للعمل مع بايتات XML الخام.

تُعيد الطريقة [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) الـ UUID الذي يُعرّف الجزء المخصص في مستند Office Open XML. استخدم [`setItemId()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) عندما تتطلب عملية التكامل معرّفًا جديدًا.

المثال التالي يُحدّث محتوى XML والمعرّف:

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

    // توفر getXmlData نفس محتوى XML كبايتات خام.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // استبدال المعرف عند الحاجة من قبل التكامل.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

عند استدعاء `setXmlAsString` أو `setXmlData`، قدم XML صالحًا وغير فارغ. استخدم إحدى الطريقتين بناءً على ما إذا كان التطبيق يعمل أساسًا مع سلاسل نصية أو بيانات بايت.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML مخصصة:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#remove--) يزيل الجزء المخصص من العرض.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) يزيل جزءًا محددًا من مجموعة أجزاء XML المخصصة.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) يزيل الجزء عند فهرس مجموعة محدد.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) يزيل جميع الأجزاء من مجموعة معينة.

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

إذا كان لديك كائن `ICustomXmlPart` وتريد إزالة ذلك الجزء من العرض بدلاً من استهداف مجموعة معينة، استدعِ `customXmlPart.remove()`.

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

تؤثر `clear` فقط على المجموعة المحددة. على سبيل المثال، مسح مجموعة شريحة لا يمسح مجموعات العرض أو الشكل.

لإزالة كل جزء XML مخصص في العرض، قم بالتكرار عبر `getAllCustomXmlParts()` وأزل كل جزء:

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

في عرض Office Open XML، قد يتم الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من عدة شرائح أو أشكال إلى نفس الجزء الأساسي.

يجب اعتبار الجزء المشترك ككائن بيانات واحد مع مراجع متعددة:

- تحديثه باستخدام `setXmlAsString` أو `setXmlData` أو `setItemId` يغير الجزء الأساسي، وبالتالي ينطبق التغيير أينما تم الإشارة إلى هذا الجزء.
- يمكن استخدام `getItemId()` لتحديد نفس جزء XML المخصص أثناء تدقيق مجموعات المستوى الكائن.
- إزالة جزء من مجموعة `getCustomXmlParts()` محددة يزيله فقط من تلك المجموعة. استخدم `ICustomXmlPart.remove()` عندما يجب إزالة الجزء نفسه من العرض بالكامل.
- قبل حذف أو استبدال جزء مشترك، افحص مجموعات المستوى الكائن لتحديد ما إذا كانت شرائح أو أشكال أخرى لا تزال تشير إليه.

إنّ التحميل الزائد للطريقة `add` ينشئ جزء XML مخصص جديد من محتوى XML؛ ولا يقبل جزءًا موجودًا من نوع `ICustomXmlPart`. لذا فإن العلاقات المشتركة تُلاحظ غالبًا عند تحميل عروض تحتوي عليها مسبقًا.

المثال التالي يدقق مجموعات العرض والشريحة والشكل بحسب `ItemId` ويبلغ عن الأجزاء التي تم الإشارة إليها من أكثر من موقع:

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

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML المخصصة في عروض تم إنشاؤها بواسطة أنظمة خارجية، لأن جزء البيانات التعريفية نفسه قد يشارك في أكثر من علاقة.

## **الحصول على قيم العلامات**

في الشرائح، تت对应 العلامة إلى طريقة `IDocumentProperties.getKeywords()`. يوضح هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides for Android عبر Java لـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation):

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

يسمح Aspose.Slides لك بإضافة علامات إلى العروض. تتكون العلامة عادةً من عنصرين:

- اسم الخاصية المخصصة، مثال: `MyTag`؛
- قيمة الخاصية المخصصة، مثال: `My Tag Value`.

إذا كنت تحتاج إلى تصنيف العروض وفق قاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا أردت تصنيف العروض من دول أمريكا الشمالية، يمكنك إنشاء علامة “NorthAmerican” وتعيين الدولة ذات الصلة كقيمتها.

يظهر هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) باستخدام Aspose.Slides for Android عبر Java:

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

يمكن أيضًا تعيين علامات لشريحة [Slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlide):

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

أو لشكل فردي [Shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IAutoShape):

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

العلامات التي تُضاف عبر مجموعة `getCustomData().getTags()` تُخزن فقط في ملف PowerPoint. **لا** يتم نقلها إلى بنية العلامات في PDF عند تصدير العرض إلى PDF. وبالتالي لا يمكن استرداد معرّف مخصص تم تعيينه كعلامة من ملف PDF المُعَلَّم.

**الحل**: يمكنك تخزين المعرّف المخصص في **النص البديل** للكائن (مثال: `shape.setAlternativeText("MyId")`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية العلامات الخاصة بالـ PDF.

## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو شكل بعملية واحدة؟**

نعم. يدعم [مجموعة العلامات](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#clear--) التي تحذف جميع أزواج المفتاح‑القيمة دفعة واحدة.

**كيف أحذف علامة واحدة باستخدام اسمها دون تكرار عبر كل المجموعة؟**

استخدم [remove(name)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) على [مجموعة العلامات](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرداد القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) على [مجموعة العلامات](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/)؛ تُعيد مصفوفة تحتوي على جميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن مكان تخزينها؟**

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب أن أستخدم `getXmlAsString`/`setXmlAsString` أم `getXmlData`/`setXmlData` لتحديث جزء XML مخصص؟**

استخدم `getXmlAsString` و`setXmlAsString` عندما يعمل التطبيق مع نص XML بترميز UTF‑8. استخدم `getXmlData` و`setXmlData` عندما يكون XML متاحًا بالفعل كمصفوفة بايت أو عندما يكون المعالجة الثنائية أكثر ملاءمة. كلا التمثيلين يشيران إلى محتوى XML لنفس جزء XML المخصص.