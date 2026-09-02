---
title: إدارة الوسوم والبيانات المخصصة في العروض باستخدام PHP
linktitle: الوسوم والبيانات المخصصة
type: docs
weight: 300
url: /ar/php-java/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- وسم
- بيانات مخصصة
- XML مخصص
- جزء XML مخصص
- بيانات وصفية XML
- ItemId
- إضافة وسم
- قيم زوجية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إدارة الوسوم وبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides for PHP via Java، بما في ذلك الإضافة والقراءة والتحديث والتدقيق وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية عمل Aspose.Slides مع الوسوم والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كوسوم أو كأجزاء XML مخصصة. الوسوم هي أزواج بسيطة من السلاسل المفتاحية والقيمة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات وصفية منظمة وبيانات XML خاصة بالتطبيق.

توفر Aspose.Slides واجهات برمجة تطبيقات لإضافة وقراءة وتحديث وتدقيق وإزالة أجزاء XML المخصصة على مستوى العرض، الشريحة، والكيان. تعتبر أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرفات إدارة المستندات، حالة سير العمل، بيانات التوافق، بيانات ربط القوالب، أو أي بيانات تطبيقية منظمة أخرى داخل العرض.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX — الملفات ذات الامتداد `.pptx` — تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. تُحدد Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة به.

يتكون العرض من عدة أجزاء مترابطة عبر علاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة مع أجزاء أخرى كما هو محدد في ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كوسوم ([TagCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/)) أو كأجزاء XML مخصصة ([CustomXmlPartCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpartcollection/)). كلاهما متوفر عبر فئة [`CustomData`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
الوسوم تخزن أزواج سلاسل بسيطة المفتاح‑القيمة. أجزاء XML المخصصة تخزن بيانات XML منظمة ويمكن ربطها بالعرض أو الشريحة أو الكيان.
{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

طريقة [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customdata/#getCustomXmlParts) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- `$presentation->getCustomData()->getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- `$slide->getCustomData()->getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بشريحة محددة.
- `$shape->getCustomData()->getCustomXmlParts()` يحتوي على أجزاء XML المخصصة المرتبطة بكيان محدد.

استخدم [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getAllCustomXmlParts) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن مكان ارتباطها.

### **إضافة جزء XML مخصص إلى العرض**

استخدم [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpartcollection/#add) لإضافة بيانات XML إلى مجموعة أجزاء XML مخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات وصفية منظمة إلى مجموعة البيانات المخصصة على مستوى العرض:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // تقوم add تلقائيًا بتعيين معرف. عيّن UUID محدد فقط عند الحاجة.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يمكن للطريقة `add` أيضًا قبول XML كمصفوفة بايت أو تدفق إدخال، وهو مفيد عندما يكون محتوى XML متاحًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصص إلى شريحة أو كيان**

يمكن ربط بيانات XML مخصصة بشريحة أو كيان معين بدلاً من ربطها بالعرض بالكامل. يكون ذلك مفيدًا عندما تصف البيانات الوصفية كائنًا واحدًا فقط، مثل مفتاح قالب، معرف سجل خارجي، أو معلومات ربط.

المثال التالي يضيف جزء XML مخصص إلى شريحة وآخر إلى كيان:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المستوى الذي يُضاف فيه الجزء يحدد أي مجموعة `getCustomData()->getCustomXmlParts()` تحتوي على العلاقة لهذا الجزء. تُستخدم البيانات على مستوى العرض للبيانات الوصفية العامة للمستند، وعلى مستوى الشريحة للمعلومات الخاصة بشريحة معينة، وعلى مستوى الكيان للبيانات المرتبطة بكيان فردي.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getAllCustomXmlParts) لاسترجاع جميع أجزاء XML المخصصة من العرض. كل كائن [`CustomXmlPart`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/) يعرض مُعرّفه، محتوى XML، ومخططات الأسماء المرتبطة.

المثال التالي يسرد جميع أجزاء XML المخصصة ومخططات الأسماء الخاصة بها:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

طريقة [`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) تُعيد مخططات XML المرتبطة بالجزء. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML تم إنتاجه من أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرّف العنصر (ItemId)**

استخدم [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/#getXmlAsString) و[`setXmlAsString()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/#setXmlAsString) للعمل مع XML كسلسلة UTF‑8، أو استخدم [`getXmlData()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/#getXmlData) و[`setXmlData()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/#setXmlData) للعمل مع بايتات XML الخام.

طريقة [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/#getItemId) تُعيد UUID الذي يحدد الجزء داخل مستند Office Open XML. استخدم [`setItemId()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/#setItemId) عندما تتطلب التكاملة معرفًا جديدًا.

المثال التالي يحدث محتوى XML والمعرّف:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // قراءة XML الحالي كنص.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // تحديث XML كسلسلة UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData يوفر نفس محتوى XML كبايتات خام.
    $customXmlData = $customXmlPart->getXmlData();

    // استبدل المعرف عند طلب التكامل.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

عند استدعاء `setXmlAsString` أو `setXmlData`، قدّم XML صالحًا وغير فارغ. استخدم إحدى الطريقتين بحسب ما إذا كان التطبيق يتعامل أساسًا مع سلاسل نصية أو بيانات بايت.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML مخصصة:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpart/#remove) يزيل الجزء من العرض.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpartcollection/#remove) يزيل جزءًا محددًا من مجموعة الأجزاء.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpartcollection/#removeAt) يزيل الجزء عند فهرس مجموعة معين.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpartcollection/#clear) يزيل جميع الأجزاء من مجموعة محددة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض عبر المرجع:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

إذا كان لديك كائن `CustomXmlPart` وتريد إزالة هذا الجزء من العرض بدلاً من التعامل مع مجموعة معينة، استدعِ `$customXmlPart->remove()`.

يمكنك أيضًا إزالة عنصر وفق الفهرس:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **مسح جميع أجزاء XML المخصصة من مجموعة**

استخدم `clear` عندما يجب إزالة جميع أجزاء XML المخصصة المرتبطة بكائن عرض معين.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` يؤثر فقط على المجموعة المحددة. على سبيل المثال، مسح مجموعة شريحة لا يمسح مجموعات العرض أو الكيان.

لإزالة كل جزء XML مخصص في العرض، كرّر عبر `getAllCustomXmlParts()` وأزل كل جزء:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **معالجة أجزاء XML مخصصة مرتبطة أو مشتركة**

في عرض Office Open XML، يمكن إشارة نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من عدة شرائح أو كيانات إلى نفس الجزء الأساسي.

يجب معاملة الجزء المشترك ككائن بيانات واحد مع مراجع متعددة:

- تحديثه باستخدام `setXmlAsString` أو `setXmlData` أو `setItemId` يغيّر الجزء الأساسي، وبالتالي ينطبق التغيير في جميع المواضع التي يشار إليه فيها.
- يمكن استخدام `getItemId()` لتحديد نفس جزء XML المخصص أثناء تدقيق المجموعات على مستوى الكائن.
- إزالة الجزء من مجموعة `getCustomXmlParts()` معينة يزيله من تلك المجموعة فقط. استخدم `CustomXmlPart::remove()` عندما يجب حذف الجزء نفسه من العرض.
- قبل حذف أو استبدال جزء مشترك، افحص مجموعات الكائنات لتحديد ما إذا كانت شرائح أو كيانات أخرى لا تزال تشير إليه.

إنّ التحميل الزائد للطريقة `add` يخلق جزء XML مخصص جديد من محتوى XML؛ لا يقبل جزءًا موجودًا مسبقًا من نوع `CustomXmlPart`. لذا، غالبًا ما تُصادف العلاقات المشتركة عند تحميل عروض تحتوي عليها مسبقًا.

المثال التالي يدقق مجموعات العرض، الشريحة، والكيان حسب `ItemId` ويُظهر الأجزاء التي تُشار إليها من أكثر من موقع:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML مخصصة في عروض أنشأتها أنظمة خارجية، لأن جزء البيانات الوصفية نفسه قد يشارك في أكثر من علاقة.

## **الحصول على قيم الوسوم**

في الشرائح، يُقابل الوسم طريقة `DocumentProperties::getKeywords()`. يُظهر هذا المثال البرمجي كيفية الحصول على قيمة وسم باستخدام Aspose.Slides for PHP via Java لـ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **إضافة وسوم إلى العروض**

يسمح Aspose.Slides بإضافة وسوم إلى العروض. يتكون الوسم عادةً من عنصرين:

- اسم الخاصية المخصصة، على سبيل المثال `MyTag`؛
- قيمة الخاصية المخصصة، على سبيل المثال `My Tag Value`.

إذا كنت بحاجة إلى تصنيف العروض وفق قاعدة أو خاصية معينة، يمكنك إضافة وسوم لهذا الغرض. على سبيل المثال، لتصنيف العروض من دول أمريكا الشمالية، يمكنك إنشاء وسم “North American” وتعيين البلد المناسب كقيمته.

يعرض هذا المثال البرمجي كيفية إضافة وسم إلى [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) باستخدام Aspose.Slides for PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

يمكن أيضًا تعيين وسوم لـ [Slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

أو لـ [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **القيود**

الوسوم التي تُضاف عبر مجموعة `getCustomData()->getTags()` تُخزن فقط في ملف PowerPoint. لا يتم نقلها إلى هيكل وسوم PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع معرف مخصص تم تعيينه كوسم من PDF الموسوم.

**حل بديل**: يمكنك تخزين معرف مخصص في **النص البديل** للكيان (مثال `$shape->setAlternativeText("MyId")`). بعد تصدير إلى PDF، قد يظهر النص البديل في هيكل وسوم PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع الوسوم من عرض أو شريحة أو كيان بعملية واحدة؟**

نعم. يدعم [tag collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/#clear) التي تحذف جميع أزواج المفتاح‑القيمة دفعة واحدة.

**كيف أحذف وسمًا واحدًا باسمه دون iterating عبر المجموعة بالكامل؟**

استخدم [remove(name)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/#remove) على [tag collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/) لحذف الوسم بمفتاحه.

**كيف يمكنني استرجاع قائمة كاملة بأسماء الوسوم لأغراض التحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/#getNamesOfTags) على [tag collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/)؛ تُعيد مصفوفة بجميع أسماء الوسوم.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن مكان تخزينها؟**

استخدم [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getAllCustomXmlParts) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب أن أستخدم `getXmlAsString`/`setXmlAsString` أم `getXmlData`/`setXmlData` لتحديث جزء XML مخصص؟**

استخدم `getXmlAsString` و`setXmlAsString` عندما يعمل التطبيق مع نص XML بصيغة UTF‑8. استخدم `getXmlData` و`setXmlData` عندما يكون XML متوفرًا مسبقًا كمصفوفة بايت أو عندما يكون المعالجة الثنائية أكثر ملاءمة. كلا الطريقتين تشير إلى محتوى XML لنفس الجزء المخصص.