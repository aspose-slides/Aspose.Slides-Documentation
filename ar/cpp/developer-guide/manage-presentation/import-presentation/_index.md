---
title: استيراد العرض التقديمي - واجهة برمجة تطبيقات PowerPoint لـ C++
linktitle: استيراد العرض التقديمي
type: docs
weight: 60
url: /cpp/import-presentation/
keywords: "استيراد PowerPoint، PDF إلى عرض تقديمي، PDF إلى PPTX، PDF إلى PPT، C++، Aspose.Slides لـ C++"
description: "استيراد عرض PowerPoint من PDF. تحويل PDF إلى PowerPoint"
---

باستخدام [**Aspose.Slides لـ C++**](https://products.aspose.com/slides/cpp/)، يمكنك استيراد العروض التقديمية من ملفات بتنسيقات أخرى. توفر Aspose.Slides فئة [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) للسماح لك باستيراد العروض التقديمية من PDF، والمستندات HTML، وما إلى ذلك.

## **استيراد PowerPoint من PDF**

في هذه الحالة، يمكنك تحويل PDF إلى عرض تقديمي PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. قم بإنشاء كائن من فئة العرض التقديمي.
2. استدعِ طريقة [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) ومرر ملف PDF.
3. استخدم طريقة [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) لحفظ الملف بتنسيق PowerPoint.

هذا الكود بلغة C++ يوضح عملية تحويل PDF إلى PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="نصيحة" color="primary" %}} 

قد ترغب في تجربة **Aspose المجانية** [PDF إلى PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لأنها تطبيق حي للعملية الموضحة هنا. 

{{% /alert %}} 

## **استيراد PowerPoint من HTML**

في هذه الحالة، يمكنك تحويل مستند HTML إلى عرض تقديمي PowerPoint.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. استدعِ طريقة [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) ومرر ملف HTML.
3. استخدم طريقة [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) لحفظ الملف بتنسيق PowerPoint.

هذا الكود بلغة C++ يوضح عملية تحويل HTML إلى PowerPoint:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="ملاحظة" color="warning" %}} 

يمكنك أيضًا استخدام Aspose.Slides لتحويل HTML إلى تنسيقات ملفات شائعة أخرى: 

* [HTML إلى صورة](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML إلى JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML إلى XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML إلى TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}