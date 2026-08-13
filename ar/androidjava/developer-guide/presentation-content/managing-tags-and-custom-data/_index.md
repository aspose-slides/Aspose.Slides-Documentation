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
- بيانات وصفية XML
- ItemId
- إضافة علامة
- قيم أزواج
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة العلامات وبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides لـ Android عبر Java، بما في ذلك الإضافة والقراءة والتحديث والتدقيق وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كعلامات أو كأجزاء XML مخصصة. العلامات هي أزواج بسيطة من السلاسل المفتاحية‑القيمة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات وصفية مُهيكلة وحمولات XML مخصصة للتطبيق.

يقدم Aspose.Slides واجهات برمجة تطبيقات لإضافة وقراءة وتحديث وتدقيق وإزالة أجزاء XML المخصصة على مستوى العرض أو الشريحة أو الشكل. تُعد أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرّفات إدارة المستندات، حالة سير العمل، بيانات التوافق، بيانات ربط القوالب، أو أي بيانات تطبيق مُهيكلة أخرى داخل العرض.

## **تخزين البيانات في ملفات العروض**

ملفات PPTX — الملفات ذات الامتداد `.pptx` — تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة.

يتكوّن العرض من أجزاء متعددة مرتبطة بعلاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة مع أجزاء أخرى وفقًا لـ ISO/IEC 29500.

يمكن تخزين البيانات المخصّصة كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITagCollection)) أو كأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection)). كلاهما متاح عبر واجهة [`ICustomData`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomData/)​.

{{% alert color="info" %}}
العلامات تخزن أزواج مفتاح‑قيمة نصية بسيطة. أجزاء XML المخصصة تخزن بيانات XML مُهيكلة ويمكن ربطها بعرض أو شريحة أو شكل.
{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

طريقة [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- `presentation.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- `slide.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشريحة محددة.
- `shape.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشكل محدد.

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن مكان ربطها.

### **إضافة جزء XML مخصص إلى عرض**

استخدم [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) لإضافة بيانات XML إلى مجموعة أجزاء XML المخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات وصفية مُهيكلة إلى مجموعة البيانات المخصصة على مستوى العرض:

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

    // add يقوم بتعيين معرف تلقائيًا. عيّن UUID محدد فقط عند الحاجة.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

طريقة `add` يمكنها أيضًا قبول XML كمصفوفة بايت أو تدفق إدخال، وهو ما يكون مفيدًا عندما يكون محتوى XML متاحًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصص إلى شريحة أو شكل**

يمكن ربط بيانات XML المخصصة بشريحة أو شكل محدد بدلاً من ربطها بالعرض كاملًا. يكون هذا مفيدًا عندما تصف البيانات الوصفية كائنًا واحدًا فقط، مثل مفتاح قالب، معرّف سجل خارجي، أو معلومات ربط.

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

المستوى الذي يُضاف فيه الجزء يحدد أي مجموعة `getCustomData().getCustomXmlParts()` ستحتوي على العلاقة إلى ذلك الجزء. البيانات على مستوى العرض مناسبة للبيانات الوصفية العامة للوثيقة، بينما البيانات على مستوى الشريحة تخص معلومات تابعة لتلك الشريحة، والبيانات على مستوى الشكل تخص شكلًا معينًا.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) لاسترجاع جميع أجزاء XML المخصصة من العرض. كل [`ICustomXmlPart`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart/) يُظهر معرّفه ومحتوى XML ومخططات الفضاء الاسمية المرتبطة به.

المثال التالي يدرج جميع أجزاء XML المخصصة ومخططات الفضاء الاسمية الخاصة بها:

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

طريقة [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) تُعيد مخططات XML المرتبطة بالجزء المخصص. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML تم إنشاؤه بواسطة أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرّف العنصر**

استخدم [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) و[`setXmlAsString()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) للعمل مع XML كنص UTF‑8، أو استخدم [`getXmlData()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) و[`setXmlData()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) للعمل مع بايتات XML الخام.

طريقة [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) تُعيد UUID الذي يُعرّف الجزء المخصص في مستند Office Open XML. استخدم [`setItemId()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) عندما تتطلب عملية التكامل معرّفًا جديدًا.

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

    // getXmlData يوفر نفس محتوى XML كبايتات خام.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // استبدال المعرف عندما يتطلب ذلك التكامل.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

عند استدعاء `setXmlAsString` أو `setXmlData`، قدّم XML صالحًا وغير فارغ. استخدم إما تمثيل النص أو تمثيل البايت حسب ما إذا كان التطبيق يعمل أساسًا مع سلاسل أو بيانات بايت.

### **إزالة جزء XML مخصص**

يوفر Aspose.Slides عدة طرق لإزالة بيانات XML المخصصة:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPart#remove--) يزيل الجزء المخصص من العرض.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) يزيل جزءًا محددًا من مجموعة أجزاء XML المخصصة.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) يزيل الجزء في فهرس مجموعة معين.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) يزيل جميع الأجزاء من مجموعة معينة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض عن طريق المرجع:

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

إذا كان لديك بالفعل `ICustomXmlPart` وتريد إزالة ذلك الجزء من العرض بدلاً من معالجة مجموعة معينة، استدعِ `customXmlPart.remove()`.

يمكنك أيضًا إزالة عنصر حسب الفهرس:

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

`clear` يؤثر فقط على المجموعة المختارة. على سبيل المثال، مسح مجموعة شريحة لا يمسح مجموعات العرض أو الشكل.

لإزالة كل جزء XML مخصص في العرض، قم بتكرار `getAllCustomXmlParts()` وأزل كل جزء:

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

### **معالجة الأجزاء XML المخصصة المرتبطة أو المشتركة**

في عرض Office Open XML، يمكن الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من شرائح أو أشكال متعددة إلى نفس الجزء المخصص الأساسي.

يجب التعامل مع الجزء المشترك ككائن بيانات واحد مع مراجع متعددة:

- تحديثه باستخدام `setXmlAsString` أو `setXmlData` أو `setItemId` يغيّر الجزء الأساسي، لذا ينطبق التغيير أينما تم الإشارة إلى ذلك الجزء.
- يمكن استخدام `getItemId()` لتحديد نفس الجزء أثناء تدقيق مجموعات المستوى الكائن.
- إزالة جزء من مجموعة `getCustomXmlParts()` معينة يزيله فقط من تلك المجموعة. استخدم `ICustomXmlPart.remove()` عندما يجب إزالة الجزء نفسه من العرض.
- قبل حذف أو استبدال جزء مشترك، افحص مجموعات المستوى الكائن لتحديد ما إذا كانت شرائح أو أشكال أخرى لا تزال تشير إليه.

إنشاء overloads `add` ينشئ جزء XML مخصص جديد من محتوى XML؛ ولا يقبل `ICustomXmlPart` موجود مسبقًا. لذلك، تُواجه العلاقات المشتركة غالبًا عند تحميل عروض تحتوي عليها بالفعل.

المثال التالي يدقق مجموعات العرض والشرائح والأشكال حسب `ItemId` ويُبلغ عن الأجزاء المشار إليها من أكثر من مكان:

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

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML المخصصة في عروض أنشأتها أنظمة خارجية، لأن الجزء الوصفي قد يشارك في أكثر من علاقة.

## **الحصول على قيم العلامات**

في الشرائح، تت对应 العلامة إلى طريقة `IDocumentProperties.getKeywords()`. يوضح هذا الكود العيني كيفية الحصول على قيمة علامة باستخدام Aspose.Slides لـ Android عبر Java لـ [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation):

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

يسمح Aspose.Slides بإضافة علامات إلى العروض. عادةً ما تتكون العلامة من عنصرين:

- اسم الخاصية المخصّصة، على سبيل المثال `MyTag`؛
- قيمة الخاصية المخصّصة، على سبيل المثال `My Tag Value`.

إذا كنت بحاجة إلى تصنيف العروض وفقًا لقاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا أردت تصنيف العروض من دول أمريكا الشمالية، يمكنك إنشاء علامة أمريكا الشمالية وتعيين الدولة ذات الصلة كقيمتها.

يوضح هذا الكود العيني كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) باستخدام Aspose.Slides لـ Android عبر Java:

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

يمكن أيضًا ضبط العلامات لـ [Slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlide):

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

أو لكائن [Shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IAutoShape) فردي:

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

العلامات التي تُضاف من خلال مجموعة `getCustomData().getTags()` تُخزن فقط في ملف PowerPoint. ولا تُنقل إلى بنية العلامات في ملف PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرداد مُعرّف مخصّص مُعين كعلامة من PDF المُعَلَّم.

**طريقة التجاوز**: يمكنك تخزين مُعرّف مخصّص في **النص البديل** للكائن (مثال `shape.setAlternativeText("MyId")`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية العلامات الخاصة بـ PDF.

## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [مجموعة العلامات](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#clear--) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة حسب اسمها دون الت iterating عبر المجموعة بأكملها؟**

استخدم [remove(name)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) على [مجموعة العلامات](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/) لحذف العلامة بناءً على مفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) على [مجموعة العلامات](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tagcollection/)؛ فهي تُعيد مصفوفة بجميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن مكان تخزينها؟**

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب عليّ استخدام `getXmlAsString`/`setXmlAsString` أم `getXmlData`/`setXmlData` لتحديث جزء XML مخصص؟**

استخدم `getXmlAsString` و `setXmlAsString` عندما يعمل التطبيق مع نص XML بترميز UTF‑8. استخدم `getXmlData` و `setXmlData` عندما يكون XML متوفرًا بالفعل كمصفوفة بايت أو عندما تكون المعالجة الثنائية أكثر ملاءمة. كلا التمثيلين يشيران إلى محتوى XML لنفس الجزء المخصص.