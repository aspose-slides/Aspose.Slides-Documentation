---
title: إدارة خصائص العرض التقديمي في جافا
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/java/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- خصائص مدمجة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات تعريف المستند
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إتقان خصائص العرض التقديمي في Aspose.Slides for Java وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides for Java الخصائص **المدمجة** و **المخصصة** للمستندات. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف، العنوان، والقيم المعرفة من قبل المستخدم.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي من خلال واجهة [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) . يتم إرجاع مثيل من هذه الواجهة بواسطة [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). توضح الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يدير Aspose.Slides بيانات التعريف الخاصة بالتطبيق والمنتج عند حفظ العروض التقديمية؛ هذه الحقول تحدد البرنامج الذي أنشأ الناتج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية جنبًا إلى جنب مع محتوى العرض التقديمي. تنقسم إلى فئتين:

- **الخصائص المدمجة** تحتوي على بيانات تعريف قياسية، مثل العنوان، المؤلف، وإحصائيات المستند.
- **الخصائص المخصصة** تخزن أزواج اسم/قيمة يحددها المستخدم.

يوفر Aspose.Slides for Java إمكانية الوصول إلى كلا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لتفحص بيانات تعريف المستند. يجمع الحوار المعلومات في علامات تبويب مثل **Summary** و **Statistics** و **Contents** و **Custom**. استخدم علامة التبويب **Custom** لإدارة الخصائص التي يحددها المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة المرور المفتوحة كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي بعد استدعاء [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) بالقيمة `false`، تبقى خصائص المستند عامة. يمكن للتطبيق بعد ذلك استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) بالقيمة `true` وقراءة بيانات التعريف العامة دون تزويد كلمة المرور المفتوحة.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) يتحكم فيما يقوم Aspose.Slides بتحميله؛ ولا يقوم بفك التشفير. إذا كانت الخصائص مشمولة في التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض مشفرًا، يتم تجاهل الخيار ويتم تحميل العرض بالكامل.

يتطلب المثال عرض تقديمي مشفر تُركت فيه خصائص المستند عامة. يتحقق من وضع التحميل عبر [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ثم يقرأ الخصائص المدمجة عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا التحقق من [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين والعناوين والمواضيع والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تكون هناك حاجة من أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات للوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة إلى ملف PPTX مشفر، يتم تحميل عرض تقديمي بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) بالقيمة `true` لقراءة البيانات العامة فقط. لا يمكن لـ Aspose.Slides حفظ الخصائص التي تم تغييرها من كائن يقتصر على البيانات العامة لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب تحديثها كلمة المرور المفتوحة الصحيحة وتحميلًا كاملاً.

يتطلب المثال عرض PPTX مشفر يحتوي على خصائص مستند عامة وكلمة مرور مفتوحة معروفة. يفتح العرض الكامل باستخدام [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)، ثم يحدّث الخصائص المدمجة العامة، ويحفظ النتيجة. بعد ذلك يستخدم [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) للتحقق من بقاء التشفير، ويعيد فتح البيانات العامة دون كلمة مرور للتحقق من القيم الجديدة:
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض التقديمي، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر كقابلة للقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

توفر واجهة [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) البيانات المدمجة عبر طرق getter، بما في ذلك [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--)، [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--)، و [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع بياناته المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المُدخل؛ قد تكون بعض الحقول فارغة.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **تعديل الخصائص المدمجة**

لتحديث البيانات المدمجة، استخدم طرق setter على الكائن الذي تُرجعه [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). يفتح هذا المثال عرضًا تقديميًا موجودًا، ويستدعي [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)، [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)، [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-)، و [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-)، ثم يحفظ العرض المحدث باستخدام [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). يحتوي ملف PPTX المحفوظ على البيانات الجديدة.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إدارة القاعدة الأساسية للروابط التشعبية**

تُعيد الدالة [IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) القاعدة على مستوى المستند للروابط التشعبية النسبية. استخدم [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) لتغييرها أو مسحها. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. إنها منفصلة عن [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) الخاص بأي رابط تشعبي فردي: تغيير القاعدة لا يعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلب المثال عرضًا تقديميًا يحتوي على رابط نسبي، مثل `target.html`، ورابط مطلق، مثل `https://example.org/absolute.html`. يقرأ القاعدة الحالية، يعيّن عنوان قاعدة جديد، ويحفظ العرض ثم يعيد فتحه للتحقق من القيمة. ثم يمسح القاعدة بسلسلة فارغة ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان القاعدة في المثال بموقع ملفاتك المرتبطة.
```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

يجب أن تطبع رسالتا التحقق القيمتين `true`. مسح القاعدة يترك عناوين الروابط الفردية دون تغيير.

رابط نسبي إلى `target.pptx` كان يفتح `old/target.pptx` عندما كانت القاعدة تشير إلى مجلد `old`. بعد تغيير القاعدة إلى مجلد `new`، وحفظ العرض وإعادة فتحه، فتح الرابط نفسه `new/target.pptx`. استمر الرابط المطلق في فتح نفس الملف. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص مخصصة للعرض التقديمي**

تخزن الخصائص المخصصة بيانات تعريف لا يوجد لها حقل مدمج مكافئ. تسمح طريقة [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) بتعيين قيمة حسب اسم الخاصية. ينشئ هذا المثال عرضًا تقديميًا، ويضيف قيمتي نص وإصدار عدد صحيح، ويحفظ العرض باستخدام [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الوصول إلى وتعديل الخصائص المخصصة**

يفتح هذا المثال عرضًا تقديميًا يحتوي على خصائص مخصصة ويستخدم [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) لتكرارها. يستقبل [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) فهرسًا قائمًا على الصفر ويعيد الاسم المستخدم بواسطة [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). يطبع المثال كل اسم وقيمة أصليين، يستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ويحفظ التغييرات. إذا لم تكن هناك خصائص مخصصة، فلن يقوم الحلقة بأي تغييرات.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مثال حي**

جرّب التطبيق على الإنترنت [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لمعرفة كيفية العمل مع خصائص المستند باستخدام Aspose.Slides API:
[![عرض وتعديل بيانات PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**  
الخصائص المدمجة هي جزء أساسي من العرض التقديمي ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو ضبطها كخانية إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**  
إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الموجودة بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**  
نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ثم [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة بيانات تعريف المستند المخزنة دون إنشاء نسخة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/java/examine-presentation/) للحصول على مثال تقرير كامل وقيود خاصة بالتنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة المرور المفتوحة؟**  
نعم. يجب أن يكون العرض تم تشفيره بعد استدعاء [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) بالقيمة `false`، ويجب تحميله بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) بالقيمة `true`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع الخصائص-المستند فقط؟**  
لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض الكامل باستخدام كلمة المرور المفتوحة الصحيحة.