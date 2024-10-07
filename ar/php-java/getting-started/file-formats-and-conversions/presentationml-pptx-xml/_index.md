---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /php-java/presentationml-pptx-xml/
---

{{% alert color="primary" %}} 

PresentationML هو اسم لعائلة من التنسيقات المعتمدة على XML لوثائق العروض التقديمية. Office OpenXML (OOXML) هو تنسيق يعتمد على XML تم تقديمه في تطبيقات Microsoft Office 2007. Office OpenXML هو تنسيق حاوية لعدة لغات ترميز متخصصة تعتمد على XML. PresentationML هي لغة الترميز المستخدمة من قبل Microsoft Office PowerPoint 2007 لتخزين الوثائق.

{{% /alert %}} 

## **PresentationML في Aspose.Slides لـ PHP عبر Java**
تأتي وثائق OOXML PresentationML كملفات PPTX، حزم XML مضغوطة تتبع مواصفات [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). يدعم Aspose.Slides لـ PHP عبر Java بشكل شامل إنشاء وقراءة ومعالجة وكتابة وثائق PresentationML. بالإضافة إلى ذلك، فإن Aspose.Slides لـ PHP عبر Java قادر على تصدير وثائق PresentationML إلى تنسيق وثيقة مستخدم على نطاق واسع مثل PDF. ويعود ذلك إلى أن Aspose.Slides لـ PHP عبر Java تم تصميمه بهدف التعامل بشكل شامل مع وثائق العروض التقديمية وPresentationML يحتفظ فعليًا بعرض الوثائق الداخلي كحزمة XML مضغوطة.

**وثيقة PPTX تم إنشاؤها بواسطة Aspose.Slides لـ PHP عبر Java وتم فتحها في Microsoft PowerPoint**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**عرض نفس وثيقة PPTX التي تم إنشاؤها بواسطة Aspose.Slides لـ PHP عبر Java في ملف ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML مفتوح، لماذا تستخدم Aspose.Slides لـ PHP عبر Java؟**
نظرًا لأن PresentationML يعتمد على XML، فإنه من الممكن تمامًا بناء تطبيقات لمعالجة وتوليد وثائق PresentationML باستخدام فئات XML دون الاعتماد على مكتبة فئات طرف ثالث مثل Aspose.Slides لـ PHP عبر Java. ومع ذلك، هناك عدة مزايا لاستخدام Aspose.Slides لـ PHP عبر Java على فئات XML عند العمل مع وثائق PresentationML.

مواصفة OOXML تحتوي على عدة آلاف من الصفحات، لذا للتعامل بشكل صحيح مع وثائق PresentationML، عليك أن تقضي الكثير من الوقت والجهد لفهم التنسيق. من جهة أخرى، مع Aspose.Slides لـ PHP عبر Java، يمكنك ببساطة استخدام الفئات وطرقها وخصائصها لتنفيذ العمليات التي تبدو معقدة إذا تمت عبر فئات XML.

بعض الميزات التي تقدمها Aspose.Slides غير متوفرة حتى عند العمل مع وثائق PresentationML من خلال فئات XML:

- تصدير وثائق PPT إلى تنسيق PDF.
- عرض شريحة إلى أي تنسيق صورة مدعوم من إطار عمل Java.
- نسخ الماسترز تلقائيًا من عروض المصدر باستخدام ميزة النسخ.
- تطبيق الحماية على الأشكال.

فيما يلي مثال على وثيقة PresentationML تحتوي على شريحة واحدة تحتوي على مربع نص مع النص "مرحبا بالعالم". لقراءة النص باستخدام فئات XML، تحتاج إلى كتابة برنامج يمكنه تحليل هذا النص البسيط من الجزء التالي. Aspose.Slides يقوم بذلك من أجلك.

**XML**

``` xml
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
                <a:t>مرحبا بالعالم
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
```php

```