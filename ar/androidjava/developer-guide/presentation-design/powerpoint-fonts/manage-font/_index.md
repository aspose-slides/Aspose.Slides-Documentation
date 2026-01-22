---
title: إدارة الخطوط في العروض التقديمية على Android
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /ar/androidjava/manage-fonts/
keywords:
- إدارة الخطوط
- خصائص الخط
- الفقرة
- تنسيق النص
- PowerPoint
- OpenDocument
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تحكم في الخطوط في Java باستخدام Aspose.Slides للـ Android: دمج، استبدال، وتحميل خطوط مخصصة لضمان وضوح عروض PPT و PPTX و ODP، وضمان سلامة العلامة التجارية والاتساق."
---

## **إدارة الخصائص المتعلقة بالخط**
{{% alert color="primary" %}} 

عادةً ما تحتوي العروض التقديمية على كل من النصوص والصور. يمكن تنسيق النص بطرق مختلفة، إما لتسليط الضوء على أقسام وكلمات معينة أو للامتثال لأنماط الشركة. يساعد تنسيق النص المستخدمين على تغيير مظهر ومضمون محتوى العرض. يوضح هذا المقال كيفية استخدام Aspose.Slides for Android عبر Java لتكوين خصائص الخط للفقرة النصية على الشريحة.

{{% /alert %}} 

لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides for Android عبر Java:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. الحصول على الـ [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) من الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) المعروض بواسطة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. محاذاة الفقرة.
1. الوصول إلى نص الـ [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) عبر الـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) وتعيين **Font** للنص في الـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) وفقًا لذلك.
   1. جعل الخط غامقًا.
   1. جعل الخط مائلًا.
1. تعيين لون الخط باستخدام [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) المعروض من كائن الـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. حفظ العرض المعدل كملف PPTX.

التنفيذ للخطوات المذكورة موضح أدناه. يأخذ عرضًا غير مُنسيق ويُطبق تنسيقات الخط على إحدى الشرائح. توضح اللقطات التالية ملف الإدخال وكيفية تعديل الشيفرة له. تقوم الشيفرة بتغيير الخط، واللون، ونمط الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في ملف الإدخال**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص مع تنسيق محدث**|
```java
	// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
		// الوصول إلى شريحة باستخدام موضعها
	ISlide slide = pres.getSlides().get_Item(0);

		// الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلهما إلى AutoShape
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

		// تعيين خطوط جديدة إلى الجزء
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

كما هو مذكور في **إدارة الخصائص المتعلقة بالخط**، يُستخدم الـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) لحفظ النص الذي له نمط تنسيق مشابه داخل الفقرة. يوضح هذا المقال كيفية استخدام Aspose.Slides for Android عبر Java لإنشاء مربع نص يحتوي على بعض النصوص ثم تعريف خط معين، والخصائص الأخرى لفئة عائلة الخط.

{{% /alert %}} 

لإنشاء مربع نص وتعيين خصائص الخط للنص داخلها:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) من النوع **Rectangle** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بالـ [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) الخاص بالـ [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. إضافة بعض النص إلى الـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
1. الوصول إلى كائن الـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) المرتبط بالـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
1. تعريف الخط الذي سيُستخدم للـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. تعيين خصائص أخرى للخط مثل الغامق، المائل، تحت الخط، اللون والارتفاع باستخدام الخصائص المتاحة في كائن الـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. كتابة العرض المعدل كملف PPTX.

التنفيذ للخطوات المذكورة موضح أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط التي تم تعيينها بواسطة Aspose.Slides for Android عبر Java**|
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
	// الحصول على الشريحة الأولى
	ISlide sld = pres.getSlides().get_Item(0);
	
	// إضافة AutoShape من نوع Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// إزالة أي نمط تعبئة مرتبط بـ AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// الوصول إلى TextFrame المرتبط بـ AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// الوصول إلى Portion المرتبط بـ TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// تعيين الخط للـ Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// تعيين الخط إلى غامق
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// تعيين الخط إلى مائل
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// تعيين الخط إلى مسطر
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// تعيين ارتفاع الخط
	port.getPortionFormat().setFontHeight(25);
	
	// تعيين لون الخط
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// حفظ العرض إلى القرص
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
