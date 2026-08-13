---
title: PresentationML (PPTX، XML)
type: docs
weight: 20
url: /ar/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 
PresentationML هو اسم لعائلة من الصيغ المستندة إلى XML للمستندات التقديمية. Office OpenXML (OOXML) هو الصيغة المستندة إلى XML التي تم تقديمها في تطبيقات Microsoft Office 2007. Office OpenXML هو صيغة حاوية لعدة لغات توصيف مستندات متخصصة مبنية على XML. PresentationML هي لغة التوصيف التي تستخدمها Microsoft Office PowerPoint 2007 لتخزين المستندات.
{{% /alert %}} 

## **PresentationML في Aspose.Slides for Java**
تأتي مستندات OOXML PresentationML كملفات PPTX، وهي حزم XML مضغوطة تتبع مواصفة [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). يدعم Aspose.Slides for Java بشكل واسع إنشاء وقراءة وتعديل وكتابة مستندات PresentationML. بالإضافة إلى ذلك، يستطيع Aspose.Slides for Java تصدير مستندات PresentationML إلى صيغة مستند شائعة الاستخدام مثل PDF. وهذا ممكن لأن Aspose.Slides for Java تم تصميمه بهدف التعامل الشامل مع مستندات العرض، حيث تحتفظ PresentationML أساسًا بالعرض الداخلي للمستندات كحزمة XML مضغوطة.

**مستند PPTX تم إنشاؤه بواسطة Aspose.Slides for Java وفتح في Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**عرض نفس مستند PPTX المُنشأ بواسطة Aspose.Slides for Java في ملف ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML مفتوح، لماذا تستخدم Aspose.Slides for Java؟**
نظرًا لأن PresentationML يعتمد على XML، فمن الممكن تمامًا بناء تطبيقات لمعالجة وإنشاء مستندات PresentationML باستخدام فئات XML دون الاعتماد على مكتبة فئات طرف ثالث مثل Aspose.Slides for Java. ومع ذلك، هناك عدة مزايا لاستخدام Aspose.Slides for Java مقارنة بفئات XML عند العمل مع مستندات PresentationML.

مواصفة OOXML تتكون من عدة آلاف من الصفحات، لذا للتعامل بشكل صحيح مع مستندات PresentationML، يجب أن تقضي الكثير من الوقت والجهد لفهم الصيغة. من ناحية أخرى، مع Aspose.Slides for Java، تستخدم فقط الفئات وطرقها وخصائصها لأداء عمليات قد تبدو معقدة إذا تم تنفيذها عبر فئات XML.

بعض الميزات التي يقدمها Aspose.Slides غير متوفرة حتى عندما تعمل مع مستندات PresentationML عبر فئات XML:

- تصدير مستندات PPT إلى صيغة PDF.
- تحويل شريحة إلى أي صيغة صورة يدعمها إطار عمل Java.
- نسخ القوالب الرئيسية تلقائيًا من عرض مصدر باستخدام ميزة الاستنساخ.
- تطبيق الحماية على الأشكال.

فيما يلي مثال على مستند PresentationML يحتوي على شريحة واحدة تضم مربع نص بالكلمة “Hello World”. لقراءة النص باستخدام فئات XML، يجب عليك كتابة برنامج يمكنه تحليل هذا النص البسيط من الجزء التالي. يقوم Aspose.Slides بذلك نيابة عنك.

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