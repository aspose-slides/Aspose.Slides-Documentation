---
title: إدارة العلامات والبيانات المخصصة في العروض باستخدام JavaScript
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/nodejs-java/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- XML مخصص
- جزء XML مخصص
- بيانات وصفية XML
- ItemId
- إضافة علامة
- قيم مزدوجة
- PowerPoint
- عرض
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إدارة العلامات وبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides للـ Node.js عبر Java، بما في ذلك الإضافة والقراءة والتحديث والتدقيق وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كعلامات أو أجزاء XML مخصصة. العلامات هي أزواج سلاسل مفتاح‑قيمة بسيطة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات وصفية منظمة وحمولات XML خاصة بالتطبيق.

توفر Aspose.Slides واجهات برمجة تطبيقات لإضافة وقراءة وتحديث وتدقيق وإزالة أجزاء XML المخصصة على مستوى العرض، الشريحة، والشكلة. تكون أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرّفات إدارة المستندات، حالة سير العمل، البيانات الوصفية للامتثال، بيانات ربط القالب، أو أي بيانات تطبيقية منظمة أخرى داخل العرض.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX — الملفات ذات الامتداد `.pptx` — تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. تُعرّف Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة.

يحتوي العرض على أجزاء متعددة متصلة بعلاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة مع أجزاء أخرى مُعرَّفة وفق ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كعلامات ([TagCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/)) أو كأجزاء XML مخصصة ([CustomXmlPartCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpartcollection/)). كلاهما متاح عبر الفئة [`CustomData`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customdata/).

{{% alert color="primary" %}}

تخزن العلامات أزواج مفتاح‑قيمة نصية بسيطة. تخزن أجزاء XML المخصصة بيانات XML منظمة ويمكن ربطها بالعرض أو الشريحة أو الشكل.

{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

طريقة `getCustomXmlParts()` للفئة [`CustomData`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customdata/) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- `presentation.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- `slide.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشريحة معينة.
- `shape.getCustomData().getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشكل معين.

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن مكان ارتباطها.

### **إضافة جزء XML مخصص إلى عرض**

استخدم طريقة `add` للفئة [`CustomXmlPartCollection`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpartcollection/) لإضافة بيانات XML إلى مجموعة أجزاء XML مخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات وصفية منظمة إلى مجموعة البيانات المخصصة على مستوى العرض:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // تقوم add بتعيين معرف تلقائيًا. قم بتعيين UUID محدد فقط عند الحاجة.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

طريقة `add` يمكنها أيضًا قبول XML كمصفوفة بايت، وهو أمر مفيد عندما يكون محتوى XML متاحًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصص إلى شريحة أو شكل**

يمكن ربط بيانات XML مخصصة بشريحة معينة أو شكل معين بدلاً من كامل العرض. يكون هذا مفيدًا عندما تصف البيانات الوصفية كائنًا واحدًا فقط، مثل مفتاح القالب، معرّف سجل خارجي، أو معلومات ربط.

المثال التالي يضيف جزء XML مخصص إلى شريحة وآخر إلى شكل:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

المستوى الذي يُضاف فيه الجزء يحدد مجموعة `getCustomData().getCustomXmlParts()` الخاصة بأي كائن تحتوي على العلاقة إلى ذلك الجزء. بيانات على مستوى العرض مناسبة للبيانات الوصفية عبر المستند بأكمله، وبيانات على مستوى الشريحة للمعلومات التي تخص شريحة معينة، وبيانات على مستوى الشكل للبيانات المرتبطة بشكل فردي.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) لاسترجاع جميع أجزاء XML المخصصة من عرض. كل كائن [`CustomXmlPart`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpart/) يكشف عن معرّفه ومحتوى XML ومخططات المساحات الاسمية المرتبطة.

المثال التالي يسرد جميع أجزاء XML المخصصة ومخططات المساحات الاسمية الخاصة بها:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

طريقة [`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpart/) تُعيد مخططات XML المرتبطة بالجزء. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML تم إنتاجه بواسطة أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرّف العنصر**

استخدم `getXmlAsString()` و `setXmlAsString()` من الفئة [`CustomXmlPart`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpart/) للعمل مع XML كنص UTF‑8، أو `getXmlData()` و `setXmlData()` للعمل مع بايتات XML الخام.

طريقة `getItemId()` تُعيد UUID الذي يعرّف جزء XML المخصص في مستند Office Open XML. استخدم `setItemId()` عندما تتطلب عملية التكامل معرفًا جديدًا.

المثال التالي يحدث محتوى XML والمعرّف:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // قراءة XML الحالي كنص.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // تحديث XML كسلسلة UTF-8.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData يوفر نفس محتوى XML كبايتات خام.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // استبدال المعرف عندما يتطلب ذلك التكامل.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

عند استدعاء `setXmlAsString` أو `setXmlData`، قدم XML صالحًا غير فارغ. استخدم إما تمثيل النص أو تمثيل البايت حسب ما إذا كان التطبيق يعمل أساسًا مع السلاسل النصية أو البيانات الثنائية.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML مخصصة:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpart/) يزيل جزء XML المخصص من العرض.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpartcollection/) يزيل جزءًا معينًا من مجموعة أجزاء XML مخصصة.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpartcollection/) يزيل الجزء عند فهرس محدد في المجموعة.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/customxmlpartcollection/) يزيل جميع الأجزاء من مجموعة معينة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض بالإشارة إليه:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا كان لديك كائن `CustomXmlPart` وتريد إزالة هذا الجزء من العرض بدلاً من معالجة مجموعة معينة، استدعِ `customXmlPart.remove()`.

يمكنك أيضًا إزالة عنصر حسب الفهرس:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **مسح جميع أجزاء XML المخصصة من مجموعة**

استخدم `clear` عندما يجب إزالة جميع أجزاء XML المخصصة المرتبطة بكائن عرض معين.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` يؤثر فقط على المجموعة المحددة. على سبيل المثال، مسح مجموعة شريحة لا يمسح مجموعات العرض أو الشكل.

لإزالة كل جزء XML مخصص في العرض، تكرّر عبر `getAllCustomXmlParts()` وأزل كل جزء:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **معالجة أجزاء XML مخصصة مرتبطة أو مشتركة**

في عرض Office Open XML، يمكن الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من شرائح أو أشكال متعددة إلى نفس جزء XML المخصص الأساسي.

يجب التعامل مع الجزء المشترك ككائن بيانات واحد له مراجع متعددة:

- تحديثه باستخدام `setXmlAsString` أو `setXmlData` أو `setItemId` يغيّر الجزء الأساسي، وبالتالي تنطبق التغييرات في كل مكان يُشار إليه.
- يمكن استخدام `getItemId()` لتحديد نفس جزء XML المخصص أثناء تدقيق مجموعات المستويات الفردية.
- إزالة جزء من مجموعة `getCustomXmlParts()` معينة يزيله من تلك المجموعة فقط. استخدم `CustomXmlPart.remove()` عندما يجب إزالة الجزء نفسه من العرض.
- قبل حذف أو استبدال جزء مشترك، افحص مجموعات المستويات الفردية لتحديد ما إذا كانت شرائح أو أشكال أخرى لا تزال تشير إليه.

إنّ تحميلات `add` تنشئ جزء XML مخصص جديد من محتوى XML؛ ولا تقبل `CustomXmlPart` موجودًا. لذلك تُواجه العلاقات المشتركة غالبًا عند تحميل عروض تحتوي عليها مسبقًا.

المثال التالي يدقق مجموعات العرض، الشريحة، والشكل عبر `ItemId` ويبلغ عن الأجزاء التي يُشار إليها من أكثر من مكان:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML مخصصة في عروض أنشأتها أنظمة خارجية، لأن جزء البيانات الوصفية نفسه قد يشارك في أكثر من علاقة.

## **جلب قيم العلامات**

في الشرائح، تُقابل العلامة الطريقة `DocumentProperties.getKeywords()`. يُظهر هذا المثال البرمجي كيفية جلب قيمة علامة باستخدام Aspose.Slides للـ Node.js عبر Java للـ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **إضافة علامات إلى العروض**

تسمح Aspose.Slides لك بإضافة علامات إلى العروض. عادةً ما تتكون العلامة من عنصرين:

- اسم الخاصية المخصصة، على سبيل المثال `MyTag`.
- قيمة الخاصية المخصصة، على سبيل المثال `My Tag Value`.

إذا كنت بحاجة إلى تصنيف العروض بناءً على قاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا أردت تصنيف العروض من دول أمريكا الشمالية، يمكنك إنشاء علامة “North American” وتعيين الدولة ذات الصلة كقيمة لها.

يعرض هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) باستخدام Aspose.Slides للـ Node.js عبر Java:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

يمكن أيضًا تعيين علامات لـ [Slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

أو لكائن [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) فردي:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **القيود**

العلامات المضافة عبر مجموعة `getCustomData().getTags()` تُخزن فقط في ملف PowerPoint. لا يتم **نقلها** إلى بنية العلامات في PDF عند تصدير العرض إلى PDF. وبالتالي لا يمكن استرجاع معرف مخصص تم تعيينه كعلامة من الـ PDF الموسوم.

**الحل**: يمكنك تخزين معرف مخصص في **نص بديل** للكائن (على سبيل المثال `shape.setAlternativeText("MyId")`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية علامات PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو شكل بعملية واحدة؟**

نعم. مجموعة [tag collection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/) تدعم عملية [clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/) التي تحذف جميع أزواج المفتاح‑قيمة دفعة واحدة.

**كيف أحذف علامة واحدة بحسب اسمها دون iterating عبر المجموعة بالكامل؟**

استخدم `remove(name)` على [tag collection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع قائمة كاملة بأسماء العلامات للتحليلات أو التصفية؟**

استخدم `getNamesOfTags()` على [tag collection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/tagcollection/); تُعيد مصفوفة بجميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن مكان تخزينها؟**

استخدم [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب أن أستخدم `getXmlAsString`/`setXmlAsString` أم `getXmlData`/`setXmlData` لتحديث جزء XML مخصص؟**

استخدم `getXmlAsString` و `setXmlAsString` عندما يعمل التطبيق مع نص XML بترميز UTF‑8. استخدم `getXmlData` و `setXmlData` عندما يتوفر XML مسبقًا كمصفوفة بايت أو عندما يكون التعامل الثنائي أكثر ملاءمة. كلا التمثيلين يشيران إلى محتوى XML لنفس جزء XML المخصص.