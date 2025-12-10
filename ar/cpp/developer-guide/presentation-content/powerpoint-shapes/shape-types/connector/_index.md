---
title: إدارة الموصلات في العروض التقديمية باستخدام C++
linktitle: موصل
type: docs
weight: 10
url: /ar/cpp/connector/
keywords:
- موصل
- نوع الموصل
- نقطة الموصل
- خط الموصل
- زاوية الموصل
- ربط الأشكال
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تمكين تطبيقات C++ من رسم وربط وخطوط التوجيه التلقائي في شرائح PowerPoint — الحصول على تحكم كامل في الموصلات المستقيمة، والمقوسة، والمنحنية."
---

موصل PowerPoint هو خط خاص يربط شكلين معًا ويبقى ملتصقًا بالأشكال حتى عند تحريكها أو إعادة وضعها على الشريحة المحددة.

عادةً ما يتم توصيل الموصلات بـ *نقاط الاتصال* (النقاط الخضراء)، التي تتوفر على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

*نقاط الضبط* (النقاط البرتقالية)، التي تتوفر فقط على بعض الموصلات، تُستخدم لتعديل موضع وشكل الموصلات.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام الموصلات المستقيمة، والمقوسة (ذات الزاوية)، والمنحنية.

توفر Aspose.Slides هذه الموصلات:

| الموصل                         | الصورة                                                       | عدد نقاط الضبط |
| ------------------------------ | ------------------------------------------------------------ | -------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0              |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0              |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0              |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1              |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2              |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3              |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0              |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1              |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2              |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3              |

## **ربط الأشكال باستخدام الموصلات**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) إلى الشريحة باستخدام الطريقة `AddAutoShape` الموجودة في كائن `Shapes`.
1. أضف موصلًا باستخدام الطريقة `AddConnector` الموجودة في كائن `Shapes` مع تحديد نوع الموصل.
1. اربط الأشكال بالموصل.
1. استدعِ الطريقة `Reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي.

 يوضح هذا الكود C++ كيفيّة إضافة موصل (موصل منحني) بين شكلين (إهليلج ومربع):
```c++
// مسار دليل المستندات.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// يقوم بتحميل العرض التقديمي المطلوب.
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// يصل إلى الشريحة الأولى.
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// يصل إلى مجموعة الأشكال لشريحة معينة.
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// يضيف شكل أوتوشيب بيضاوي.
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// يضيف شكل أوتوشيب مستطيل.
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// يضيف شكل موصل إلى مجموعة أشكال الشريحة.
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// يربط الأشكال باستخدام الموصل.
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// يقوم باستدعاء Reroute الذي يحدد أقصر مسار تلقائي بين الأشكال.
	connector->Reroute();
	
	// يحفظ العرض التقديمي.
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 

تقوم الطريقة `connector->Reroute` بإعادة توجيه الموصل وتفرض عليه أخذ أقصر مسار ممكن بين الأشكال. لتحقيق ذلك، قد تقوم الطريقة بتغيير نقاط `StartShapeConnectionSiteIndex` و`EndShapeConnectionSiteIndex`.

{{% /alert %}} 

## **تحديد نقطة اتصال**

إذا رغبت في ربط موصل بين شكلين باستخدام نقاط محددة على الأشكال، عليك تحديد نقاط الاتصال المفضلة بهذه الطريقة:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. احصل على مرجع الشريحة عبر فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) إلى الشريحة باستخدام الطريقة `AddAutoShape` الموجودة في كائن `Shapes`.
1. أضف موصلًا باستخدام الطريقة `AddConnector` الموجودة في كائن `Shapes` مع تحديد نوع الموصل.
1. اربط الأشكال بالموصل.
1. عيّن نقاط الاتصال المفضلة على الأشكال.
1. احفظ العرض التقديمي.

 يوضح هذا الكود C++ عملية تحديد نقطة اتصال مفضلة:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// يحمل العرض التقديمي المطلوب
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// يصل إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// يصل إلى مجموعة الأشكال لشريحة محددة
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// يضيف شكل أوتوشيب بيضاوي
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// يضيف شكل أوتوشيب مستطيل
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// يضيف شكل موصل إلى مجموعة أشكال الشريحة
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// يربط الأشكال باستخدام الموصل
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// يحدد فهرس نقطة الاتصال المفضلة على شكل البيضاوي
	int wantedIndex = 6;

	// يتحقق ما إذا كان الفهرس المفضل أصغر من العدد الأقصى لنقاط الموقع
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// يحدد نقطة الاتصال المفضلة على شكل أوتوشيب البيضاوي
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// يحفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ضبط نقطة موصل**

يمكنك ضبط موصل موجود عبر نقاط الضبط الخاصة به. لا يمكن تعديل سوى الموصلات التي تمتلك نقاط ضبط. راجع الجدول تحت **[أنواع الموصلات.](/slides/ar/cpp/connector/#types-of-connectors)**

### **حالة بسيطة**

تخيّل حالة حيث يمر موصل بين شكلين (A و B) عبر شكل ثالث (C):

![connector-obstruction](connector-obstruction.png)

الكود:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```


لتجنب أو تجاوز الشكل الثالث، يمكننا ضبط الموصل بنقل خطه العمودي إلى اليسار بهذه الطريقة:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```


### **حالات معقّدة** 

لإجراء تعديلات أكثر تعقيدًا، عليك مراعاة الأمور التالية:

* نقطة الضبط في الموصل مرتبطة ارتباطًا وثيقًا بمعادلة تحسب وتحدد موقعها. لذا قد يتغيّر شكل الموصل عند تعديل موقع النقطة.
* تُعرّف نقاط الضبط بترتيب صارم داخل مصفوفة. تُرقم النقاط من نقطة بداية الموصل إلى نهايته.
* تعكس قيم نقاط الضبط النسبة المئوية لعرض/ارتفاع شكل الموصل. 
  * يُحدّد الشكل بنقطة البداية والنهاية مضروبة في 1000. 
  * النقطة الأولى، الثانية، والثالثة تُحدّد النسبة من العرض، النسبة من الارتفاع، والنسبة من العرض مرة أخرى على التوالي.
* لحساب إحداثيات نقاط الضبط، يجب أخذ دوران الموصل وانعكاسه في الاعتبار. **ملاحظة** أن زاوية الدوران لجميع الموصلات الموضحة تحت **[أنواع الموصلات](/slides/ar/cpp/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

تخيّل حالة يتم فيها ربط كائني إطار نصي معًا عبر موصل:

![connector-shape-complex](connector-shape-complex.png)

الكود:
```c++
// ينشئ فئة العرض التقديمي التي تمثل ملف PPTX
auto pres = System::MakeObject<Presentation>();
// يحصل على الشريحة الأولى في العرض التقديمي
auto slide = pres->get_Slides()->idx_get(0);
// يحصل على الأشكال من الشريحة الأولى
auto shapes = slide->get_Shapes();
// يضيف أشكالًا سيتم ربطها معًا عبر موصل
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// يضيف موصلًا
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// يحدد اتجاه الموصل
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// يحدد سمك خط الموصل
lineFormat->set_Width(3);
// يحدد لون الموصل
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// يربط الأشكال معًا باستخدام الموصل
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// يحصل على نقاط الضبط للموصل
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```


**الضبط**

يمكننا تغيير قيم نقاط الضبط بزيادة النسبة المئوية للعرض والارتفاع المقابلة بنسبة 20% و200% على التوالي:
```c++
// يغيّر قيم نقاط الضبط
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```


النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يتيح لنا تحديد إحداثيات وشكل الأجزاء الفردية للموصل، لننشئ شكلاً يطابق المكوّن الأفقي للموصل عند النقطة `connector.Adjustments[0]`:
```c++
// ارسم المكوّن العمودي للموصل
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```


النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، عرضنا عملية ضبط موصل بسيطة باستخدام مبادئ أساسية. في الحالات العادية، يجب مراعاة دوران الموصل وعرضه (واللذين يتم تعيينهما عبر `connector.Rotation`، `connector.Frame.FlipH`، و`connector.Frame.FlipV`). الآن سنوضح العملية.

أولاً، أضف كائن إطار نصي جديد (**To 1**) إلى الشريحة (لغرض الاتصال) وأنشئ موصلًا (أخضر) يربطه بالكائنات التي أُنشئت مسبقًا.
```c++
// ينشئ كائن ربط جديد
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// ينشئ موصلًا جديدًا
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// يربط الكائنات باستخدام الموصل الذي تم إنشاؤه حديثًا
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// يحصل على نقاط الضبط للموصل
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// يغيّر قيم نقاط الضبط
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```


النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، لننشئ شكلاً يطابق المكوّن الأفقي للموصل الذي يمر عبر نقطة الضبط الجديدة `connector.Adjustments[0]`. سنستخدم القيم المستخرجة من `connector.Rotation`، `connector.Frame.FlipH`، و`connector.Frame.FlipV` ونطبق صيغة تحويل الإحداثيات للدوران حول نقطة معينة x₀:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل معروض عموديًا، لذا يكون الكود المقابل:
```c++

```


النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد عرضنا حسابات تشمل تعديلات بسيطة ونقاط ضبط معقدة (نقاط ضبط ذات زوايا دوران). باستخدام المعرفة المكتسبة، يمكنك إنشاء نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى ضبط قيم نقاط ضبط الموصل بناءً على إحداثيات شريحة معينة.

## **إيجاد زاوية خطوط الموصل**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. احصل على مرجع الشريحة عبر فهرسها.
1. الوصول إلى شكل خط الموصل.
1. استخدم عرض الخط، ارتفاعه، ارتفاع إطار الشكل، وعرض إطار الشكل لحساب الزاوية.

يُظهر هذا الكود C++ عملية حساب زاوية شكل خط الموصل:
```c++
void ConnectorLineAngle()
{

	// مسار دليل المستندات.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// يحمّل العرض التقديمي المطلوب
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// يصل إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// يصل إلى مجموعة الأشكال في الشريحة
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
// الدالة getDirection الخاصة بـ ConnectorLineAngle(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان يمكن "اللصق" بالموصل إلى شكل معين؟**

تحقق مما إذا كان الشكل يوفّر [نقاط اتصال](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_connectionsitecount/). إذا لم تكن هناك نقاط أو كان عددها صفرًا، فإن اللصق غير متاح؛ في هذه الحالة استخدم نقاط النهاية الحرة وضعها يدويًا. من المنطقي فحص عدد المواقع قبل الإرفاق.

**ماذا يحدث للموصل إذا حذفت أحد الأشكال المرتبطة؟**

ستنفصل نهاياته؛ يظل الموصل على الشريحة كخط عادي بنقطة بداية/نهاية حرة. يمكنك إما حذفه أو إعادة تعيين الاتصالات، وإذا لزم الأمر، [إعادة توجيه](https://reference.aspose.com/slides/cpp/aspose.slides/connector/reroute/).

**هل تُحافظ ربطات الموصل عند نسخ شريحة إلى عرض تقديمي آخر؟**

عمومًا نعم، بشرط نسخ الأشكال المستهدفة أيضًا. إذا أُدخلت الشريحة في ملف آخر دون الأشكال المتصلة، تصبح النهايات حرة وستحتاج إلى إرفاقها مرة أخرى.