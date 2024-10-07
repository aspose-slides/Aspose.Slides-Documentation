---
title: إدارة الخطوط - واجهة برمجة تطبيقات PowerPoint Java
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /androidjava/manage-fonts/
description: عادةً ما تحتوي العروض التقديمية على نصوص وصور. يوضح هذا المقال كيفية استخدام واجهة برمجة تطبيقات PowerPoint Java لتكوين خصائص الخطوط للفقرات النصية على الشرائح.
---

## **إدارة خصائص الخط المتعلقة بالخطوط**
{{% alert color="primary" %}} 

عادةً ما تحتوي العروض التقديمية على نصوص وصور. يمكن تنسيق النص بعدة طرق، سواء لتسليط الضوء على أقسام وكلمات معينة أو للت conform مع الأنماط التنظيمية. يساعد تنسيق النص المستخدمين في تنويع مظهر ومحتوى العرض التقديمي. يوضح هذا المقال كيفية استخدام Aspose.Slides for Android عبر Java لتكوين خصائص الخطوط للفقرات النصية على الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفصل باستخدام Aspose.Slides for Android عبر Java:

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Placeholder) في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. احصل على [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph) من [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) المعروض من قبل [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. وضح الفقرة.
1. الوصول إلى نص [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) لفقرات [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FontData) وضبط **Font** لنص [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) وفقًا لذلك.
   1. ضبط الخط ليكون غامقًا.
   1. ضبط الخط ليكون مائلًا.
1. ضبط لون الخط باستخدام [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FillFormat) المعروض من قبل كائن [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. حفظ العرض التقديمي المعدل في ملف PPTX.

تم إعطاء تنفيذ الخطوات أعلاه أدناه. يأخذ عرضًا تقديميًا بدون زخرفة ويقوم بتنسيق الخطوط في واحدة من الشرائح. تعرض لقطات الشاشة التي تليها ملف الإدخال وكيف تغيره مقتطفات الكود. يغير الكود الخط، اللون، وأسلوب الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في ملف الإدخال**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص مع التنسيق المحدث**|

```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// الوصول إلى شريحة باستخدام موضعها
	ISlide slide = pres.getSlides().get_Item(0);

	// الوصول إلى العنصر الأول والثاني في الشريحة وتحويله كـ AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// الوصول إلى الفقرة الأولى
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// وضح الفقرة
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

	// ضبط الخط ليكون غامقًا
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// ضبط الخط ليكون مائلًا
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// ضبط لون الخط
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// حفظ ملف PPTX على القرص
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تعيين خصائص الخط للنص**
{{% alert color="primary" %}} 

كما ذُكر في **إدارة خصائص الخط المتعلقة بالخطوط**، يُستخدم [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) لحفظ النص بأسلوب تنسيق مماثل في فقرة. يوضح هذا المقال كيفية استخدام Aspose.Slides for Android عبر Java لإنشاء مربع نص يحتوي على بعض النصوص ثم تعريف خط معين، وخصائص أخرى مختلفة من فئة الخط.

{{% /alert %}} 

لإنشاء مربع نص وضبط خصائص الخط للنص فيه:

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) من النوع **مستطيل** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بـ [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. إضافة نص إلى [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame).
1. الوصول إلى كائن [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) المرتبط بـ [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame).
1. تعريف الخط المراد استخدامه لـ [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. ضبط خصائص الخط الأخرى مثل الغامق، المائل، التسطير، اللون والارتفاع باستخدام الخصائص المناسبة التي كشفت عنها كائن [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. كتابة العرض التقديمي المعدل كملف PPTX.

تم إعطاء تنفيذ الخطوات أعلاه أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط التي تم تعيينها بواسطة Aspose.Slides for Android عبر Java**|

```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
	// الحصول على الشريحة الأولى
	ISlide sld = pres.getSlides().get_Item(0);
	
	// إضافة AutoShape من النوع مستطيل
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// إزالة أي نمط تعبئة مرتبطة بـ AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// الوصول إلى TextFrame المرتبطة بـ AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// الوصول إلى Portion المرتبطة بـ TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// ضبط الخط للجزء
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// ضبط خاصية الخط الغامق
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// ضبط خاصية الخط المائل
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// ضبط خاصية الخط التسطير
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// ضبط ارتفاع الخط
	port.getPortionFormat().setFontHeight(25);
	
	// ضبط لون الخط
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// حفظ العرض التقديمي على القرص
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```