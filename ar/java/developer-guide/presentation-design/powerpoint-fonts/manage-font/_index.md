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
description: "التحكم في الخطوط في Java باستخدام Aspose.Slides: تضمين الخطوط، استبدالها، وتحميل خطوط مخصصة للحفاظ على عروض PPT و PPTX و ODP واضحة، آمنة للعلامة التجارية ومتسقة."
---
## **نظرة عامة**

تتيح لك Aspose.Slides إدارة خصائص الخط في نص العروض التقديمية مباشرةً من خلال الشيفرة الخاصة بك. يمكنك الوصول إلى النص في الشرائح عبر الأشكال وإطارات النص والفقرات والجزء، ثم تطبيق التنسيق على النص المحدد.

توضح هذه المقالة كيفية تكوين خصائص الخط للنص الموجود في عرض تقديمي، بما في ذلك عائلة الخط، والأنماط الغامقة والمائلة، ومحاذاة الفقرات، ولون الخط. كما توضح كيفية إنشاء مربع نص، إضافة نص إليه، وتعيين خصائص الخط مثل عائلة الخط، الغامق، المائل، التسطير، حجم الخط، واللون قبل حفظ النتيجة كملف PPTX.

## **إدارة خصائص الخط المرتبطة**
{{% alert color="info" %}} 

عادةً ما تحتوي العروض التقديمية على كلٍ من النصوص والصور. يمكن تنسيق النص بطرق عديدة، إما لتسليط الضوء على أقسام وكلمات محددة أو للامتثال لأنماط الشركة. يساعد تنسيق النص المستخدمين على تنويع مظهر ومضمون محتوى العرض. توضح هذه المقالة كيفية استخدام Aspose.Slides for Java لتكوين خصائص الخط للفقرات النصية في الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides for Java:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. الوصول إلى أشكال [Placeholder](https://reference.aspose.com/slides/ar/java/com.aspose.slides/placeholder/) في الشريحة وتحويل نوعها إلى [AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/).
1. الحصول على الـ[Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) من الـ[TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/) الذي توفره [AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/).
1. محاذاة الفقرة.
1. الوصول إلى نص الـ[Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/paragraph/) عبر الـ[Portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portion/).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontdata/) وتعيين **Font** لنص الـ[Portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portion/) وفقًا لذلك.
   1. تعيين الخط كغامق.
   1. تعيين الخط كمائل.
1. تعيين لون الخط باستخدام الـ[FillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fillformat/) الذي توفره كائن الـ[Portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portion/).
1. حفظ العرض المعدل كملف PPTX.

يتم تقديم تنفيذ الخطوات المذكورة أعلاه أدناه. يأخذ عرض تقديمي بسيط ويقوم بتنسيق الخطوط في إحدى الشرائح. تُظهر لقطات الشاشة التالية ملف الإدخال وكيف تغير المقتطفات البرمجية مظهره. يغيّر الكود الخط واللون ونمط الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: النص في ملف الإدخال**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: النص نفسه مع تنسيق محدث**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// الوصول إلى شريحة باستخدام موضعها
	ISlide slide = pres.getSlides().get_Item(0);

	// الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويله إلى AutoShape
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

	// تعيين الخط كغامق
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// تعيين الخط كمائل
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// تعيين لون الخط
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

## **تعيين خصائص خط النص**
{{% alert color="info" %}} 

كما هو مذكور في **Managing Font Related Properties**، يُستخدم الـ[Portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portion/) لاحتواء النص ذو نمط تنسيق مماثل داخل فقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides for Java لإنشاء مربع نص يحتوي على بعض النص ثم تعريف خط معين، والعديد من الخصائص الأخرى لفئة عائلة الخط.

{{% /alert %}} 

لإنشاء مربع نص وتعيين خصائص الخط للنص فيه:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
1. الحصول على مرجع شريحة باستخدام فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/) من النوع **Rectangle** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بـ[AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/).
1. الوصول إلى الـ[TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/) الخاص بـ[AutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/autoshape/).
1. إضافة بعض النص إلى الـ[TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/).
1. الوصول إلى كائن الـ[Portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portion/) المرتبط بالـ[TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textframe/).
1. تحديد الخط الذي سيتم استخدامه للـ[Portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portion/).
1. تعيين خصائص الخط الأخرى مثل الغامق، المائل، التسطير، اللون والارتفاع باستخدام الخصائص المتعلقة التي يتيحها كائن الـ[Portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portion/).
1. كتابة العرض المعدل كملف PPTX.

يتم تقديم تنفيذ الخطوات المذكورة أعلاه أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: نص مع بعض خصائص الخط التي تم ضبطها بواسطة Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation();
try {
	// الحصول على الشريحة الأولى
	ISlide sld = pres.getSlides().get_Item(0);
	
	// إضافة AutoShape من النوع Rectangle
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
	
	// تعيين خاصية الغامق للخط
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// تعيين خاصية المائل للخط
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// تعيين خاصية التسطير للخط
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