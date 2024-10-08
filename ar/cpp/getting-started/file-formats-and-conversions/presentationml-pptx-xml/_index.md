---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /ar/cpp/presentationml-pptx-xml/
---

## **حول PresentationML**
PresentationML هو اسم لعائلة من التنسيقات المعتمدة على XML لوثائق العروض التقديمية. Office OpenXML (OOXML) هو التنسيق المعتمد على XML الذي تم تقديمه في تطبيقات Microsoft Office 2007. Office OpenXML هو تنسيق حاوية لعدة لغات ترميز XML متخصصة. PresentationML هو لغة الترميز التي تستخدمها Microsoft Office PowerPoint 2007 لتخزين وثائقها.
## **PresentationML في Aspose.Slides لـ C++**
تأتي مستندات OOXML PresentationML كملفات PPTX وهي حزم XML مضغوطة تتبع مواصفات [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). تدعم Aspose.Slides لـ C++ بشكل مكثف إنشاء وقراءة ومعالجة وكتابة مستندات PresentationML. بالإضافة إلى ذلك، يمكن لـ Aspose.Slides لـ C++ تصدير مستندات PresentationML إلى تنسيقات مستندات مستخدمة على نطاق واسع مثل PDF و TIFF و XPS. وهذا ممكن لأن Aspose.Slides لـ C++ تم تصميمه بهدف التعامل بشكل شامل مع مستندات العروض التقديمية وPresentationML أساسًا يحتوي على العرض الداخلي للمستندات كحزمة XML مضغوطة.

## **PresentationML مفتوح، لماذا استخدام Aspose.Slides لـ C++**
نظرًا لأن PresentationML يعتمد على XML، فمن الممكن تمامًا بناء تطبيقات لمعالجة وإنشاء مستندات PresentationML باستخدام فئات XML دون الاعتماد على مكتبات الفئات الخارجية مثل Aspose.Slides لـ C++. ومع ذلك، هناك العديد من المزايا لاستخدام Aspose.Slides لـ C++ بدلاً من فئات XML عند العمل مع مستندات PresentationML.

تعتبر مواصفات OOXML طويلة جدًا تصل إلى عدة آلاف من الصفحات. وهذا يعني أنه من أجل التعامل بشكل صحيح مع مستندات PresentationML، سيتعين عليك قضاء الكثير من الوقت والجهد لفهم تنسيق مثل هذه المستندات. من ناحية أخرى، عند استخدام Aspose.Slides لـ C++، كل ما عليك فعله هو استخدام الفئات المعنية وطرقها / خصائصها المعنية لأداء العمليات التي تبدو معقدة جدًا إذا تم تنفيذها عبر فئات XML.

فيما يلي بعض الميزات التي قد لا تكون متاحة حتى عند التعامل مع مستندات PresentationML عبر فئات XML:

- تصدير مستندات PPT إلى تنسيقات PDF و TIFF و XPS
- تصدير الشرائح في مستندات PPT إلى تنسيقات SVG
- عرض الشريحة إلى أي تنسيق صورة مدعوم من إطار عمل C++
- النسخ التلقائي للسيد من العروض المصدر باستخدام ميزة النسخ
- تطبيق الحماية على الأشكال

دعنا نأخذ مثالاً على مستند PresentationML يحتوي على شريحة واحدة بها مربع نص يحتوي على نص "Hello World". من أجل قراءة النص من خلال فئات XML، سيتعين عليك كتابة برنامج يمكنه تحليل هذا النص البسيط من الجزء التالي:
## **مثال**

``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```