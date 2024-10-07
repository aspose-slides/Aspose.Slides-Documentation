---
title: الموصل
type: docs
weight: 10
url: /cpp/connector/
keywords: "ربط الأشكال، الموصلات، أشكال PowerPoint، عرض PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "ربط أشكال PowerPoint باستخدام C++"
---

موصل PowerPoint هو خط خاص يربط أو يربط شكلين معًا ويظل متصلًا بالشكلين حتى عند تحريكه أو إعادة وضعه في شريحة معينة.

عادةً ما تكون الموصلات مرتبطة بـ *نقاط الاتصال* (نقاط خضراء)، التي توجد على جميع الأشكال بشكل افتراضي. تظهر نقاط الاتصال عندما يقترب المؤشر منها.

تُستخدم *نقاط الضبط* (نقاط برتقالية)، التي توجد فقط على بعض الموصلات، لتعديل مواضع وأشكال الموصلات.

## **أنواع الموصلات**

في PowerPoint، يمكنك استخدام الموصلات المستقيمة، والموصلات الزاوية (المائلة)، والموصلات المنحنية.

Aspose.Slides توفر هذه الموصلات:

| الموصل                         | الصورة                                                        | عدد نقاط الضبط |
| ------------------------------ | ------------------------------------------------------------ | ---------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                |

## **ربط الأشكال باستخدام الموصلات**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف شكلين [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) إلى الشريحة باستخدام طريقة `AddAutoShape` المعروضة بواسطة كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `AddConnector` المعروضة بواسطة كائن `Shapes` من خلال تعريف نوع الموصل.
1. اربط الأشكال باستخدام الموصل.
1. استدعاء طريقة `Reroute` لتطبيق أقصر مسار اتصال.
1. احفظ العرض التقديمي.

توضح هذه الشفرة بلغة C++ كيفية إضافة موصل (موصل منحني) بين شكلين (بيضاوي ومستطيل):

```c++
// المسار إلى دليل المستندات.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// تحميل العرض التقديمي المطلوب
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// الوصول إلى مجموعة الأشكال لشريحة معينة
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// إضافة شكل بيضاوي
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// إضافة شكل مستطيل
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// إضافة شكل موصل إلى مجموعة أشكال الشريحة
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// ربط الأشكال باستخدام الموصل
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// استدعاء reroute الذي يحدد أقصر مسار تلقائي بين الأشكال
	connector->Reroute();
	
	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="ملاحظة" color="warning" %}} 

تقوم طريقة `connector->Reroute` بإعادة توجيه الموصل وتفرض عليه اتخاذ أقصر مسار ممكن بين الأشكال. لتحقيق هدفها، قد تقوم الطريقة بتغيير نقاط `StartShapeConnectionSiteIndex` و `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **تحديد نقطة الاتصال**

إذا كنت تريد من موصل ربط شكلين باستخدام نقاط محددة على الأشكال، يجب عليك تحديد نقاط الاتصال المفضلة لديك على النحو التالي:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف شكلين  [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) إلى الشريحة باستخدام طريقة `AddAutoShape` المعروضة بواسطة كائن `Shapes`.
1. أضف موصلًا باستخدام طريقة `AddConnector` المعروضة بواسطة كائن `Shapes` من خلال تعريف نوع الموصل.
1. اربط الأشكال باستخدام الموصل.
1. عيّن نقاط الاتصال المفضلة لديك على الأشكال.
1. احفظ العرض التقديمي.

توضح هذه الشفرة بلغة C++ عملية حيث تم تحديد نقطة الاتصال المفضلة:

```c++
	// المسار إلى دليل المستندات.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// تحميل العرض التقديمي المطلوب
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// الوصول إلى مجموعة الأشكال لشريحة معينة
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// إضافة شكل بيضاوي
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// إضافة شكل مستطيل
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// إضافة شكل موصل إلى مجموعة أشكال الشريحة
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// ربط الأشكال باستخدام الموصل
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// تعيين فهرس نقطة الاتصال المفضلة على الشكل البيضاوي
	int wantedIndex = 6;

	// التحقق مما إذا كان الفهرس المفضل أقل من الحد الأقصى لعدد فهارس الموقع
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// تعيين نقطة الاتصال المفضلة على الشكل البيضاوي
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **تعديل نقطة الموصل**

يمكنك تعديل موصل موجود من خلال نقاط الضبط الخاصة به. يمكن تغيير الموصلات التي تحتوي على نقاط ضبط فقط بهذه الطريقة. راجع الجدول تحت **[أنواع الموصلات.](/slides/cpp/connector/#types-of-connectors)** 

#### **حالة بسيطة**

اعتبر حالة حيث يمر موصل بين شكلين (A و B) عبر شكل ثالث (C):

![connector-obstruction](connector-obstruction.png)

كود:

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

لتجنب أو تجاوز الشكل الثالث، يمكننا ضبط الموصل عن طريق تحريك خطه العمودي إلى اليسار على النحو التالي:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **حالات معقدة** 

لإجراء تعديلات أكثر تعقيدًا، عليك أن تأخذ في الاعتبار ما يلي:

* ترتبط نقطة ضبط الموصل ارتباطًا وثيقًا بمعادلة تحسب وتحدد موقعها. لذلك، قد تؤدي التغييرات في موقع النقطة إلى تغيير شكل الموصل.
* يتم تعريف نقاط الضبط الخاصة بالموصل بترتيب صارم في مصفوفة. يتم ترقيم نقاط الضبط من نقطة بداية الموصل إلى نهايته.
* تعكس قيم نقاط الضبط نسبة عرض/ارتفاع شكل الموصل. 
  * الشكل محدد بنقاط بداية ونهاية الموصل مضروبة في 1000. 
  * النقطة الأولى، النقطة الثانية، والنقطة الثالثة تحدد النسبة من العرض، والنسبة من الارتفاع، والنسبة من العرض (مرة أخرى) على التوالي.
* لحسابات تحديد إحداثيات نقاط ضبط الموصل، عليك أن تأخذ في الاعتبار دوران الموصل وانعكاسه. **ملاحظة** أن زاوية الدوران لجميع الموصلات المعروضة تحت **[أنواع الموصلات](/slides/cpp/connector/#types-of-connectors)** هي 0.

#### **الحالة 1**

اعتبر حالة حيث يتم ربط كائنين إطار نص معًا من خلال موصل:

![connector-shape-complex](connector-shape-complex.png)

كود:

```c++
// يقوم بإنشاء فئة عرض تقدم تمثل ملف PPTX
auto pres = System::MakeObject<Presentation>();
// يحصل على الشريحة الأولى في العرض التقديمي
auto slide = pres->get_Slides()->idx_get(0);
// الحصول على الأشكال من الشريحة الأولى
auto shapes = slide->get_Shapes();
// إضافة الأشكال التي ستتحد من خلال موصل
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"من");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"إلى");
// إضافة موصل
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// تحديد اتجاه الموصل
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// تحديد سمك خط الموصل
lineFormat->set_Width(3);
// تحديد لون الموصل
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// ربط الأشكال معًا باستخدام الموصل
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// الحصول على نقاط الضبط للموصل
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**تعديل**

يمكننا تغيير قيم نقطة الضبط للموصل من خلال زيادة النسبة المئوية للعرض والارتفاع المقابلين بنسبة 20% و 200% على التوالي:

```c++
// تغيير قيم نقاط الضبط
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

النتيجة:

![connector-adjusted-1](connector-adjusted-1.png)

لتعريف نموذج يسمح لنا بتحديد إحداثيات وشكل الأجزاء الفردية للموصل، دعنا ننشئ شكلًا يتوافق مع المكون الأفقي للموصل عند النقطة connector.Adjustments[0]:

```c++
// رسم المكون العمودي للموصل
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

النتيجة:

![connector-adjusted-2](connector-adjusted-2.png)

#### **الحالة 2**

في **الحالة 1**، أظهرنا عملية تعديل بسيطة للموصل باستخدام مبادئ أساسية. في الحالات العادية، يجب عليك أخذ دوران الموصل وعرضه (الذي يتم تعيينه بواسطة connector.Rotation و connector.Frame.FlipH و connector.Frame.FlipV) في الاعتبار. سنوضح الآن العملية.

أولاً، دعنا نضيف كائن إطار نص جديد (**إلى 1**) إلى الشريحة (لأغراض الربط) وننشئ موصلا جديدًا (أخضر) يربطه بالكائنات التي أنشأناها بالفعل.

```c++
// إنشاء كائن ربط جديد
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"إلى 1");
// إنشاء موصل جديد
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// ربط الكائنات باستخدام الموصل الذي تم إنشاؤه حديثًا
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// الحصول على نقاط ضبط الموصل
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// تغيير قيم نقاط الضبط
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

النتيجة:

![connector-adjusted-3](connector-adjusted-3.png)

ثانيًا، دعنا ننشئ شكلًا يتوافق مع المكون الأفقي للموصل الذي يمر عبر نقطة ضبط الموصل الجديدة connector.Adjustments[0]. سنستخدم القيم من بيانات الموصل ل connector.Rotation و connector.Frame.FlipH و connector.Frame.FlipV ونطبق معادلة تحويل الإحداثيات الشهيرة للدوران حول نقطة معينة x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

في حالتنا، زاوية دوران الكائن هي 90 درجة والموصل معروض عموديًا، لذا فإن الشيفرة المقابلة هي:

```c++

```

النتيجة:

![connector-adjusted-4](connector-adjusted-4.png)

لقد أظهرنا حسابات تتعلق بالتعديلات البسيطة والمعقدة (نقاط الضبط مع زوايا الدوران). باستخدام المعرفة المكتسبة، يمكنك تطوير نموذجك الخاص (أو كتابة كود) للحصول على كائن `GraphicsPath` أو حتى تعيين قيم نقاط ضبط الموصل استنادًا إلى إحداثيات الشريحة المحددة.

## **إيجاد زاوية خطوط الموصل**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. الوصول إلى شكل خط الموصل.
1. استخدم عرض الخط وطوله وارتفاع الشكل وإطار الشكل لحساب الزاوية.

توضح هذه الشفرة بلغة C++ عملية حيث قمنا بحساب الزاوية لشكل خط الموصل:

```c++
void ConnectorLineAngle()
{

	// المسار إلى دليل المستندات.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// تحميل العرض التقديمي المطلوب
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// الوصول إلى مجموعة الأشكال في الشرائح
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
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
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