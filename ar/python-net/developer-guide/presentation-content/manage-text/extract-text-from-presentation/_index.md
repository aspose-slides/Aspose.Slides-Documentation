---
title: استخراج النص من العرض
type: docs
weight: 90
url: /python-net/extract-text-from-presentation/
keywords: "استخراج النص من الشريحة، استخراج النص من PowerPoint، بايثون، Aspose.Slides لـ Python عبر .NET"
description: "استخراج النص من الشريحة أو عرض PowerPoint في بايثون"
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال على جميع الشرائح في العرض. يشرح هذا المقال كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. يمكن استخراج النص بطرق التالية:

- [استخراج النص من شريحة واحدة](/slides/python-net/extracting-text-from-the-presentation/)
- [استخراج النص باستخدام طريقة GetAllTextBoxes](/slides/python-net/extracting-text-from-the-presentation/)
- [استخراج النص بشكل مصنف وسريع](/slides/python-net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **استخراج النص من الشريحة**
تقدم Aspose.Slides لـ Python عبر .NET مساحة الأسماء Aspose.Slides.Util التي تشمل فئة SlideUtil. تكشف هذه الفئة عن عدد من الطرق الثابتة المفرطة لتحميل لاستخراج النص بالكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، 
استخدم طريقة [GetAllTextBoxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) الثابتة المفرطة المقدمة من فئة SlideUtil. تقبل هذه الطريقة كائن الشريحة كمعامل.
عند التنفيذ، تقوم طريقة الشريحة بمسح النص بالكامل من الشريحة الممررة كمعامل وتعيد مصفوفة من كائنات TextFrame. هذا يعني أن أي تنسيق نصي متعلق بالنص متوفر. الكود التالي يستخرج جميع النصوص من الشريحة الأولى في العرض:

```py
import aspose.slides as slides

#instantiate فئة العرض التي تمثل ملف PPTX
with slides.Presentation("pres.pptx") as pptxPresentation:
    # احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_boxes(pptxPresentation.slides[0])
    
    # تكرار عبر مصفوفة TextFrames
    for i in range(len(textFramesPPTX)):
	    # تكرار عبر الفقرات في ITextFrame الحالي
        for para in textFramesPPTX[i].paragraphs:
            # تكرار عبر الأجزاء في IParagraph الحالي
            for port in para.portions:
			    # عرض النص في الجزء الحالي
                print(port.text)

    			# عرض ارتفاع خط النص
                print(port.portion_format.font_height)

			    # عرض اسم خط النص
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **استخراج النص من العرض**
لمسح النص من العرض الكامل، استخدم
 [GetAllTextFrames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) طريقة ثابتة مقدمة من فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن Presentation الذي يمثل عرض PPTX الذي يتم استخراج النص منه.
2. ثانياً، قيمة Boolean تحدد ما إذا كان ينبغي تضمين الشريحة الرئيسية عند مسح النص من العرض.
   تعيد الطريقة مصفوفة من كائنات TextFrame، كاملة بمعلومات تنسيق النص. الكود أدناه يمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

```py
import aspose.slides as slides

#instantiate فئة العرض التي تمثل ملف PPTX
with slides.Presentation("pres.pptx") as pptxPresentation:
    # احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_frames(pptxPresentation, True)
    
    # تكرار عبر مصفوفة TextFrames
    for i in range(len(textFramesPPTX)):
	    # تكرار عبر الفقرات في ITextFrame الحالي
        for para in textFramesPPTX[i].paragraphs:
            # تكرار عبر الأجزاء في IParagraph الحالي
            for port in para.portions:
			    # عرض النص في الجزء الحالي
                print(port.text)

    			# عرض ارتفاع خط النص
                print(port.portion_format.font_height)

			    # عرض اسم خط النص
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **استخراج نص مصنف وسريع**
تمت إضافة طريقة ثابتة جديدة GetPresentationText إلى فئة Presentation. هناك عمليتين مفرطتين لهذه الطريقة:

```py
slides.Presentation.get_presentation_text(stream)
slides.Presentation.get_presentation_text(stream, mode)      
```

تشير وسيطة enum ExtractionMode إلى الوضع لتنظيم نتيجة النص ويمكن تعيينها للقيم التالية:
غير مرتبة - النص الخام دون اعتبار للموقع على الشريحة
مرتبة - يتم وضع النص بنفس ترتيب الشريحة

يمكن استخدام الوضع غير المرتب عندما تكون السرعة حرجة، فهو أسرع من الوضع المرتب.

يمثل PresentationText النص الخام المستخرج من العرض. يحتوي على خاصية `slides_text` من مساحة Aspose.Slides.Util والتي تعيد مصفوفة من كائنات SlideText. يمثل كل كائن النص على الشريحة المقابلة. تحتوي كائنات SlideText على الخصائص التالية:

SlideText.text - النص على أشكال الشريحة
SlideText.master_text - النص على أشكال الصفحة الرئيسية لهذه الشريحة
SlideText.layout_text - النص على أشكال صفحة التخطيط لهذه الشريحة
SlideText.notes_text - النص على أشكال صفحة الملاحظات لهذه الشريحة


يمكن استخدام واجهة برمجة التطبيقات الجديدة بهذه الطريقة:

```py
import aspose.slides as slides

text1 = slides.PresentationFactory().get_presentation_text("pres.pptx", slides.TextExtractionArrangingMode.UNARRANGED)
print(text1.slides_text[0].text)
print(text1.slides_text[0].layout_text)
print(text1.slides_text[0].master_text)
print(text1.slides_text[0].notes_text)
```