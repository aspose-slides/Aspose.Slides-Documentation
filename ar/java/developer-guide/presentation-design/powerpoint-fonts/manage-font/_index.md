---
title: إدارة الخطوط - واجهة برمجة تطبيقات PowerPoint لـ Java
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /java/manage-fonts/
description: تحتوي العروض التقديمية عادةً على نصوص وصور. تُظهر هذه المقالة كيفية استخدام واجهة برمجة تطبيقات PowerPoint لـ Java لتكوين خصائص الخط للفقرات النصية على الشريحة.
---

## **إدارة خصائص الخط المتعلقة**
{{% alert color="primary" %}} 

تحتوي العروض التقديمية عادةً على نصوص وصور. يمكن تنسيق النص بعدة طرق، إما لتسليط الضوء على أقسام وكلمات معينة أو ليتوافق مع الأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تغيير شكل ومظهر محتوى العرض التقديمي. تُظهر هذه المقالة كيفية استخدام Aspose.Slides لـ Java لتكوين خصائص الخط للفقرات النصية على الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفقرات باستخدام Aspose.Slides لـ Java:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Placeholder) في الشريحة وقم بتحويلها إلى [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. احصل على [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph) من [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) المعروضة بواسطة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. قم بمساواة الفقرة.
1. الوصول إلى نص [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph) [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. عرّف الخط باستخدام [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FontData) واضبط **Font** لنص [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) وفقًا لذلك.
   1. اضبط الخط على غامق.
   1. اضبط الخط على مائل.
1. اضبط لون الخط باستخدام [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FillFormat) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. احفظ العرض التقديمي المعدل في ملف PPTX.

توضح الشيفرة أدناه تنفيذ الخطوات أعلاه. تأخذ عرضًا تقديميًا عاديًا وتنسق الخطوط في واحدة من الشرائح. تظهر لقطات الشاشة التالية ملف الإدخال وكيف تغيره مقتطفات الشيفرة. تقوم الشيفرة بتغيير الخط، اللون، وأسلوب الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في ملف الإدخال**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص بتنسيق محدث**|

```java
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accessing a slide using its slide position
	ISlide slide = pres.getSlides().get_Item(0);

	// Accessing the first and second placeholder in the slide and typecasting it as AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Accessing the first Paragraph
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justify the paragraph
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Accessing the first portion
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Define new fonts
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Assign new fonts to portion
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Set font to Bold
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Set font to Italic
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Set font color
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Save the PPTX to disk
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تعيين خصائص خط النص**
{{% alert color="primary" %}} 

كما تم ذكره في **إدارة خصائص الخط المتعلقة**، يتم استخدام [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) للاحتفاظ بالنص بالتنسيق المشابه في فقرة. تُظهر هذه المقالة كيفية استخدام Aspose.Slides لـ Java لإنشاء مربع نص مع بعض النصوص ثم تحديد خط معين، وعدة خصائص أخرى لفئة الخط.

{{% /alert %}} 

لإنشاء مربع نص وتعيين خصائص الخط للنص فيه:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. احصل على مرجع شريحة باستخدام فهرسها.
1. أضف [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) من نوع **Rectangle** إلى الشريحة.
1. أزل نمط التعبئة المرتبط بـ [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. أضف بعض النصوص إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. الوصول إلى كائن [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) المرتبط بـ [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. حدد الخط المراد استخدامه لـ [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. اضبط خصائص الخط الأخرى مثل الغامق، المائل، التسطير، اللون والارتفاع باستخدام الخصائص ذات الصلة المعروضة بواسطة كائن [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. اكتب العرض التقديمي المعدل كملف PPTX.

توضح الشيفرة أدناه تنفيذ الخطوات أعلاه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط المحددة بواسطة Aspose.Slides لـ Java**|

```java
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation();
try {
	// Get first slide
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Add an AutoShape of Rectangle type
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Remove any fill style associated with the AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Access the TextFrame associated with the AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Access the Portion associated with the TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Set the Font for the Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Set Bold property of the Font
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Set Italic property of the Font
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Set Underline property of the Font
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Set the Height of the Font
	port.getPortionFormat().setFontHeight(25);
	
	// Set the color of the Font
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Save the presentation to disk
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```