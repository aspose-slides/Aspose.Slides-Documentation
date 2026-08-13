---
title: إدارة الخطوط في العروض التقديمية على Android
linktitle: إدارة الخطوط
type: docs
weight: 10
url: /ar/androidjava/manage-fonts/
keywords:
- إدارة الخطوط
- خصائص الخط
- فقرة
- تنسيق النص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "التحكم في الخطوط في Java باستخدام Aspose.Slides للـ Android: تضمين الخطوط، استبدالها، وتحميل خطوط مخصصة لضمان وضوح عروض PPT، PPTX و ODP وأمان العلامة التجارية واتساقها."
---
## **نظرة عامة**

يتيح Aspose.Slides لك إدارة خصائص الخط في نص العرض مباشرةً من خلال التعليمات البرمجية. يمكنك الوصول إلى النص في الشرائح عبر الأشكال، إطارات النص، الفقرات، والجزء (Portion)، ثم تطبيق التنسيق على النص المختار.

توضح هذه المقالة كيفية تكوين خصائص الخط للنص الموجود في عرض تقديمي، بما في ذلك عائلة الخط، الأنماط الغامقة (Bold) والمائلة (Italic)، محاذاة الفقرة، ولون الخط. كما توضح كيفية إنشاء مربع نص، إضافة نص إليه، وتعيين خصائص الخط مثل عائلة الخط، الغامق، المائل، تحت الخط، حجم الخط، واللون قبل حفظ النتيجة كملف PPTX.

## **إدارة خصائص الخط المرتبطة**
{{% alert color="info" %}} 
عادةً ما تحتوي العروض التقديمية على نصوص وصور. يمكن تنسيق النص بطرق مختلفة، إما لتسليط الضوء على أقسام وكلمات محددة أو للالتزام بالأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تغيير مظهر محتوى العرض التقديمي. تُظهر هذه المقالة كيفية استخدام Aspose.Slides for Android عبر Java لتكوين خصائص الخط للفقرة على الشرائح.

{{% /alert %}} 

لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides for Android عبر Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى الأشكال [Placeholder](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/placeholder/) في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/).
1. الحصول على الـ[Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/) من الـ[TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframe/) المعروض عبر [AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/).
1. تعديل محاذاة الفقرة لتكون مبررة.
1. الوصول إلى نص الـ[Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/paragraph/) عبر الـ[Portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portion/).
1. تعريف الخط باستخدام [FontData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontdata/) وتعيين **Font** للـ[Portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portion/) وفقاً لذلك.
   1. ضبط الخط كغامق.
   1. ضبط الخط كمائل.
1. تعيين لون الخط باستخدام الـ[FillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fillformat/) المعروض عبر كائن الـ[Portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portion/).
1. حفظ العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه. يأخذ عرضًا تقديميًا بسيطًا ويقوم بتنسيق الخطوط في إحدى الشرائح. تُظهر لقطات الشاشة التالية ملف الإدخال وكيفية تغيير الشيفرة له. تقوم الشيفرة بتغيير الخط، اللون، ونمط الخط.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**الشكل: النص في ملف الإدخال**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**الشكل: نفس النص بعد تحديث التنسيق**|

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

	// ضبط الخط كغامق
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// ضبط الخط كمائل
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// ضبط لون الخط
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

## **ضبط خصائص خط النص**
{{% alert color="info" %}} 
كما ذُكر في **إدارة خصائص الخط المرتبطة**، يُستخدم الـ[Portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portion/) للاحتفاظ بنص ذات تنسيق موحد داخل الفقرة. تُظهر هذه المقالة كيفية استخدام Aspose.Slides for Android عبر Java لإنشاء مربع نص يحتوي على بعض النصوص ثم تعريف خط معين، بالإضافة إلى خصائص أخرى من فئة عائلة الخط.

{{% /alert %}} 

لإنشاء مربع نص وتعيين خصائص الخط للنص الموجود فيه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/) من النوع **Rectangle** إلى الشريحة.
1. إزالة نمط التعبئة المرتبط بالـ[AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/).
1. الوصول إلى الـ[TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframe/) الخاص بالـ[AutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/autoshape/).
1. إضافة بعض النص إلى الـ[TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframe/).
1. الوصول إلى كائن الـ[Portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portion/) المرتبط بالـ[TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textframe/).
1. تعريف الخط الذي سيُستخدم للـ[Portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portion/).
1. تعيين خصائص أخرى للخط مثل الغامق، المائل، تحت الخط، اللون والارتفاع باستخدام الخصائص المتاحة في كائن الـ[Portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portion/).
1. كتابة العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**الشكل: نص مع بعض خصائص الخط التي تم تعيينها بواسطة Aspose.Slides for Android عبر Java**|

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
	
	// حفظ العرض التقديمي إلى القرص
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```