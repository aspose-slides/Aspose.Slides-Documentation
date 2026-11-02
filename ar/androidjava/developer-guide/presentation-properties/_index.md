---
title: إدارة خصائص العرض التقديمي على Android
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/androidjava/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- الخصائص المدمجة
- الخصائص المخصصة
- الخصائص المتقدمة
- إدارة الخصائص
- تعديل الخصائص
- البيانات التعريفية للمستند
- تحرير البيانات التعريفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إتقان خصائص العرض التقديمي في Aspose.Slides لنظام Android عبر Java وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **مقدمة**

يدعم Aspose.Slides for Android عبر Java **الخصائص المدمجة** و **الخصائص المخصصة** للمستند. استخدم هذه الخصائص لقراءة وتحديث بيانات التعريف للعرض التقديمي، مثل المؤلف، العنوان، والقيم المعرفة من قبل المستخدم.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي من خلال واجهة [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/). يتم إرجاع مثال من هذه الواجهة عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). توضح الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}
يدير Aspose.Slides بيانات تعريف التطبيق والمنتج عند حفظ العروض التقديمية؛ هذه الحقول تحدد البرنامج الذي أنشأ الملف الناتج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية بجانب محتوى العرض التقديمي. تنقسم إلى فئتين:

- **الخصائص المدمجة** تحتوي على بيانات تعريف معيارية، مثل العنوان، المؤلف، وإحصاءات المستند.
- **الخصائص المخصصة** تخزن أزواج اسم/قيمة يحددها المستخدم.

يوفر Aspose.Slides for Android عبر Java الوصول إلى كلتا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لاستعراض بيانات تعريف المستند. يجمع الحوار المعلومات في علامات تبويب مثل **Summary**، **Statistics**، **Contents**، و **Custom**. استخدم علامة تبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير العرض التقديمي بعد استدعاء [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) مع `false`، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) مع `true` وقراءة البيانات العامة دون توفير كلمة مرور الفتح.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) يحدد ما يقوم Aspose.Slides بتحميله؛ ولا يفك تشفير أي شيء. إذا تم تضمين الخصائص في التشفير، فسيؤدي تحميلها بدون كلمة المرور إلى فشل. إذا لم يكن العرض التقديمي مشفرًا، يتم تجاهل الخيار وتُحمَّل النسخة الكاملة من العرض.

يتطلب المثال عرضًا تقديميًا مشفرًا تُترك خصائص المستند فيه عامة. يتحقق من وضع التحميل عبر [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ثم يقرأ الخصائص المدمجة عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

في هذا الوضع، لا يتم تحميل محتوى الشرائح. تكون الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا التحقق من [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تتطلب أنظمة الفهرسة أو التصنيف أو البحث أو إدارة الوثائق الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، يُقصد من العرض المحمَّل بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) مع `true` قراءة البيانات العامة فقط. لا يستطيع Aspose.Slides حفظ الخصائص المتغيِّرة من ذلك الكائن الذي يحمل بيانات تعريف عامة فقط لأن الخصائص العامة يجب أن تظل متطابقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب التحديث كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

يتطلب المثال عرضًا تقديميًا PPTX مشفرًا بخصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض الكامل عبر [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)، يحدث الخصائص المدمجة العامة، ويحفظ النتيجة. ثم يستخدم [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) للتحقق من استمرار التشفير ويعيد فتح البيانات العامة بدون كلمة مرور للتحقق من القيم الجديدة:

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

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب التعامل مع الخصائص العامة لملف PPTX مشفر كقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

تُظهر واجهة [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) البيانات المدمجة عبر طرق getter، بما في ذلك [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--)، [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--)، و [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع بيانات التعريف المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المدخل؛ قد تكون بعض الحقول فارغة.

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

لتحديث البيانات المدمجة، استخدم طرق setter على الكائن المسترجع من [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). يفتح هذا المثال عرضًا تقديميًا موجودًا، يستدعي [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)، [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)، [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)، [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-)، و [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-)، ثم يحفظ العرض المحدث عبر [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). يحتوي ملف PPTX المحفوظ على البيانات التعريفية الجديدة.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إدارة أساس الارتباط التشعبي**

تُعيد [IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) أساس المستند للروابط التشعبية النسبية. استخدم [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) لتغييره أو مسحه. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) للارتباط الفردي: تغييره لا يعيد كتابة عناوين الروابط المخزنة ولا يغير الوجهات المطلقة.

يتطلب المثال عرضًا يحتوي على كل من رابط نسبي مثل `target.html` ورابط مطلق مثل `https://example.org/absolute.html`. يقرأ الأساس الحالي، يعيّن أساسًا جديدًا، ثم يحفظ ويعيد فتح العرض للتحقق من القيمة. بعد ذلك يمسح الأساس بسلسلة فارغة ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان الأساس المثال بموقع ملفاتك المرتبطة.

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

يجب أن تطبع رسائل التحقق الاثنين `true`. مسح الأساس يترك عناوين الروابط الفردية دون تغير.

رابط نسبي إلى `target.pptx` كان يفتح `old/target.pptx` عندما كان الأساس يشير إلى المجلد `old`. بعد تغيير الأساس إلى المجلد `new`، وحفظ وإعادة فتح العرض، يفتح نفس الرابط `new/target.pptx`. الرابط المطلق استمر في فتح نفس الملف. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير أسسه.

## **إضافة خصائص عرض تقديمي مخصصة**

تخزن الخصائص المخصصة بيانات تعريف لا يوجد لها حقل مدمج مقابل. تسمح طريقة [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) بتعيين قيمة بحسب اسم الخاصية. يخلق هذا المثال عرضًا تقديميًا، يضيف قيمتي نص وإصدار عدد صحيح، ويحفظ العرض عبر [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية الحالية.

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

## **الوصول إلى الخصائص المخصصة وتعديلها**

يفتح هذا المثال عرضًا يحتوي على خصائص مخصصة ويستخدم [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) للتنقل بينها. تُعيد [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) اسمًا بناءً على الفهرس الصفري وتُطابق الاسم المستخدم في [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). يطبع المثال كل اسم وقيمة أصلية، يستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ويحفظ التغييرات. إذا لم توجد خصائص مخصصة، لا يُجري الحلقة أي تعديل.

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

جرّب تطبيق الويب [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لتوضح كيفية العمل مع خصائص المستند باستخدام Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. مع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سُمِح بذلك للخاصية المحددة.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، ستُستبدل قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) ثم [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) لقراءة بيانات تعريف المستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) كامل. راجع [_Build a Lightweight Presentation Inventory_](/slides/ar/androidjava/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بكل تنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض مشفر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون العرض قد تم تشفيره بعد استدعاء [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) مع `false`، ويجب تحميله بعد استدعاء [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) مع `true`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع تحميل خصائص المستند فقط؟**

لا. يجب أن تظل البيانات العامة والمشفرة متطابقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل مع كلمة مرور الفتح الصحيحة.