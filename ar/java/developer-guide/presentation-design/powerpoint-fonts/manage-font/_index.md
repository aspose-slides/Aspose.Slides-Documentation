---
title: إدارة الخطوط في العروض التقديمية باستخدام Java
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /ar/java/manage-fonts/
keywords:
- إدارة الخطوط
- خصائص الخط
- فقرة
- تنسيق النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحكم في الخطوط في Java باستخدام Aspose.Slides: دمج الخطوط، استبدالها، وتحميل خطوط مخصصة للحفاظ على وضوح عروض PPT و PPTX و ODP وسلامة العلامة التجارية واتساقها."
---

## **إدارة خصائص الخط ذات الصلة**
{{% alert color="primary" %}} 

عادةً ما تحتوي العروض التقديمية على نصوص وصور. يمكن تنسيق النص بطرق مختلفة، إما لتسليط الضوء على أقسام وكلمات معينة أو للامتثال لأنماط الشركة. يساعد تنسيق النص المستخدمين على تنويع مظهر ومظهر محتوى العرض. توضح هذه المقالة كيفية استخدام Aspose.Slides for Java لتكوين خصائص الخط للفقرات النصية على الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides for Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) في الشريحة وتحويل نوعها إلى [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. الحصول على [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) من [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) المعروض بواسطة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. محاذاة الفقرة إلى الضبط.
1. الوصول إلى [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) النصية في [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) وتعيين **Font** لجزء النص [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) وفقًا لذلك.
   1. ضبط الخط إلى غامق.
   1. ضبط الخط إلى مائل.
1. ضبط لون الخط باستخدام [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
1. حفظ العرض المُعدَّل إلى ملف PPTX.

التنفيذ للخطوات المذكورة أعلاه موضح أدناه. يأخذ عرضًا غير مزخرف ويُنسق الخطوط في إحدى الشرائح. تُظهر اللقطات الشاشة التي تلي ذلك ملف الإدخال وكيف تغيّر مقتطفات الشفرة ذلك. تُغيّر الشفرة الخط واللون ونمط الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في الملف الإدخالي**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص مع تنسيق محدث**|
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// الوصول إلى شريحة باستخدام موقعها
	ISlide slide = pres.getSlides().get_Item(0);

	// الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويل النوع إلى AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// الوصول إلى الفقرة الأولى
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// محاذاة الفقرة
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// الوصول إلى الجزء الأول
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// تعريف خطوط جديدة
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// تعيين خطوط جديدة للجزء
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// تعيين الخط إلى غامق
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// تعيين الخط إلى مائل
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// تعيين لون الخط
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// حفظ ملف PPTX إلى القرص
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```


## **تعيين خصائص خط النص**
{{% alert color="primary" %}} 

كما هو مذكور في **إدارة خصائص الخط ذات الصلة**، يُستخدم [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) للاحتفاظ بالنص ذو نمط تنسيق مشابه في فقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides for Java لإنشاء مربع نص يحتوي على بعض النص ثم تعريف خط معين، وغيرها من خصائص فئة عائلة الخط.

{{% /alert %}} 

لإنشاء مربع نص وتعيين خصائص خط النص فيه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) من النوع **Rectangle** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بـ [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) الخاص بـ [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/).
1. إضافة بعض النص إلى [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
1. الوصول إلى كائن [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) المرتبط بـ [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
1. تعريف الخط المستخدم لـ [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
1. ضبط خصائص الخط الأخرى مثل الغامق والمائل والتسطير واللون والارتفاع باستخدام الخصائص المناسبة المعروضة بواسطة كائن [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/portion/).
1. كتابة العرض المُعدَّل كملف PPTX.

التنفيذ للخطوات المذكورة أعلاه موضح أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط التي تم ضبطها بواسطة Aspose.Slides for Java**|
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
	// الحصول على الشريحة الأولى
	ISlide sld = pres.getSlides().get_Item(0);
	
	// إضافة AutoShape من النوع Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// إزالة أي نمط تعبئة مرتبط بالـ AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// الوصول إلى TextFrame المرتبط بالـ AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// الوصول إلى Portion المرتبط بالـ TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// تعيين الخط للـ Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// تعيين خاصية الخط الغامق
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// تعيين خاصية الخط المائل
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// تعيين خاصية تسطير الخط
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// تعيين ارتفاع الخط
	port.getPortionFormat().setFontHeight(25);
	
	// تعيين لون الخط
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// حفظ العرض على القرص
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
