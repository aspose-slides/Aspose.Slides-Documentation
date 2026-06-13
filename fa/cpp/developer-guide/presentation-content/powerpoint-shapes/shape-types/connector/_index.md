---
title: مدیریت اتصال‌دهنده‌ها در ارائه‌ها با استفاده از C++
linktitle: اتصال‌دهنده
type: docs
weight: 10
url: /fa/cpp/connector/
keywords:
- اتصال‌دهنده
- نوع اتصال‌دهنده
- نقطه اتصال‌دهنده
- خط اتصال‌دهنده
- زاویه اتصال‌دهنده
- اتصال شکل‌ها
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "به برنامه‌های C++ قدرت دهید تا خطوط را در اسلایدهای PowerPoint رسم، متصل و به‌صورت خودکار مسیردهی کنند— و کنترل کامل بر روی اتصال‌دهنده‌های مستقیم، زانو (زاویه‌دار) و منحنی داشته باشید."
---
## **معرفی**

یک وصل‌کنندهٔ پاورپوینت خطی ویژه است که دو شکل را به هم متصل یا لینک می‌کند و حتی زمانی که این اشکال جابجا یا تغییر مکان می‌یابند، به آن‌ها چسبیده می‌ماند. 

وصل‌کننده‌ها به طور معمول به *نقاط اتصال* (نقاط سبز) متصل می‌شوند که به‌صورت پیش‌فرض در تمام اشکال وجود دارند. نقاط اتصال زمانی ظاهر می‌شوند که کرسر به آن‌ها نزدیک شود.

*نقاط تنظیم* (نقاط نارنجی) که فقط در برخی وصل‌کننده‌ها وجود دارند، برای تغییر موقعیت و شکل وصل‌کننده‌ها استفاده می‌شوند.

## **انواع وصل‌کننده‌ها**

در پاورپوینت می‌توانید از وصل‌کننده‌های مستقیم، زانو (زاویه‌دار) و منحنی استفاده کنید. 

Aspose.Slides این وصل‌کننده‌ها را فراهم می‌کند:

| وصل‌کننده | تصویر | تعداد نقاط تنظیم |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **متصل کردن اشکال با استفاده از وصل‌کننده‌ها**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.  
1. از طریق شاخص آن، ارجاع اسلاید را دریافت کنید.  
1. با استفاده از متد `AddAutoShape` که در شیء `Shapes` در دسترس است، دو [AutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.auto_shape) به اسلاید اضافه کنید.  
1. با تعریف نوع وصل‌کننده، یک وصل‌کننده را با استفاده از متد `AddConnector` که در شیء `Shapes` موجود است اضافه کنید.  
1. با استفاده از وصل‌کننده، اشکال را به هم متصل کنید.  
1. متد `Reroute` را صدا بزنید تا کوتاه‌ترین مسیر اتصال اعمال شود.  
1. ارائه را ذخیره کنید.  

این کد C++ نشان می‌دهد که چگونه یک وصل‌کننده (یک وصل‌کننده خمیده) بین دو شکل (یک بیضی و یک مستطیل) اضافه کنید:

```c++
// مسیر پوشه اسناد.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// ارائه مورد نظر را بارگذاری می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اولین اسلاید دسترسی پیدا می‌کند
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// مجموعهٔ اشکال یک اسلاید خاص را دریافت می‌کند
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// یک شکل خودکار بیضی را اضافه می‌کند
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// یک شکل خودکار مستطیل را اضافه می‌کند
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// یک شکل اتصال‌دهنده را به مجموعهٔ اشکال اسلاید اضافه می‌کند
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// اشکال را با استفاده از اتصال‌دهنده متصل می‌کند
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// متد Reroute را صدا می‌زند که کوتاه‌ترین مسیر خودکار بین اشکال را تنظیم می‌کند
	connector->Reroute();
	
	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
متد `connector->Reroute` یک وصل‌کننده را باز مسیر می‌کند و آن را مجبور می‌سازد تا کوتاه‌ترین مسیر ممکن بین اشکال را انتخاب کند. برای رسیدن به این هدف، ممکن است این متد مقادیر `StartShapeConnectionSiteIndex` و `EndShapeConnectionSiteIndex` را تغییر دهد. 
{{% /alert %}} 

## **مشخص کردن نقطه اتصال**

اگر می‌خواهید یک وصل‌کننده دو شکل را با استفاده از نقاط خاص روی اشکال متصل کند، باید نقاط اتصال دلخواه خود را به این صورت مشخص کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.  
1. از طریق شاخص آن، ارجاع اسلاید را دریافت کنید.  
1. با استفاده از متد `AddAutoShape` که در شیء `Shapes` در دسترس است، دو [AutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.auto_shape) به اسلاید اضافه کنید.  
1. با تعریف نوع وصل‌کننده، یک وصل‌کننده را با استفاده از متد `AddConnector` که در شیء `Shapes` موجود است اضافه کنید.  
1. با استفاده از وصل‌کننده، اشکال را به هم متصل کنید.  
1. نقاط اتصال دلخواه خود را بر روی اشکال تنظیم کنید.  
1. ارائه را ذخیره کنید.  

این کد C++ عملیاتی را نشان می‌دهد که در آن یک نقطه اتصال دلخواه مشخص می‌شود:

```c++
	// مسیر پوشه اسناد.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// ارائه مورد نظر را بارگذاری می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اولین اسلاید دسترسی پیدا می‌کند
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// مجموعهٔ اشکال یک اسلاید خاص را دریافت می‌کند
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// یک شکل خودکار بیضی اضافه می‌کند
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// یک شکل خودکار مستطیل اضافه می‌کند
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// یک شکل اتصال‌دهنده را به مجموعهٔ اشکال اسلاید اضافه می‌کند
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// اشکال را با استفاده از اتصال‌دهنده متصل می‌کند
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// اندیس نقطهٔ اتصال دلخواه را بر روی شکل بیضی تنظیم می‌کند
	int wantedIndex = 6;

	// بررسی می‌کند که آیا اندیس دلخواه کمتر از حداکثر تعداد سایت‌ها است یا خیر
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// نقطهٔ اتصال دلخواه را بر روی شکل خودکار بیضی تنظیم می‌کند
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// ارائه را ذخیره می‌کند
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنظیم یک نقطهٔ وصل‌کننده**

می‌توانید یک وصل‌کنندهٔ موجود را از طریق نقاط تنظیم آن تنظیم کنید. فقط وصل‌کننده‌هایی که نقاط تنظیم دارند می‌توانند به این روش تغییر یابند. جدول زیر را در **[انواع وصل‌کننده‌ها](/slides/fa/cpp/connector/#types-of-connectors)** ببینید.

### **مورد ساده**

در نظر بگیرید حالتی که یک وصل‌کننده بین دو شکل (A و B) از یک شکل سوم (C) عبور می‌کند:

![connector-obstruction](connector-obstruction.png)

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

برای اجتناب یا دور زدن شکل سوم، می‌توانیم وصل‌کننده را با جابه‌جایی خط عمودی‌اش به سمت چپ این‌گونه تنظیم کنیم:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **موارد پیچیده** 

برای انجام تنظیمات پیچیده‌تر، باید موارد زیر را در نظر بگیرید:

* نقطهٔ قابل تنظیم یک وصل‌کننده به‌ شدت به فرمولی که موقعیت آن را محاسبه و تعیین می‌کند مرتبط است. بنابراین تغییر مکان نقطه ممکن است شکل وصل‌کننده را تغییر دهد.  
* نقاط تنظیم یک وصل‌کننده در یک آرایه به‌ ترتیب دقیق تعریف می‌شوند. نقاط تنظیم از نقطهٔ شروع وصل‌کننده تا انتهای آن شماره‌گذاری می‌شوند.  
* مقادیر نقاط تنظیم درصد عرض/ارتفاع شکل وصل‌کننده را نشان می‌دهند.  
  * شکل توسط نقاط شروع و پایان وصل‌کننده ضرب در 1000 محدود می‌شود.  
  * نقطهٔ اول، دوم و سوم به ترتیب درصد از عرض، درصد از ارتفاع و دوباره درصد از عرض را تعیین می‌کنند.  
* برای محاسبهٔ مختصات نقاط تنظیم یک وصل‌کننده، باید چرخش و بازتاب آن را در نظر بگیرید. **توجه** داشته باشید که زاویهٔ چرخش تمام وصل‌کننده‌های نشان داده شده در **[انواع وصل‌کننده‌ها](/slides/fa/cpp/connector/#types-of-connectors)** برابر با ۰ است.

#### **مورد 1**

یک مورد را در نظر بگیرید که در آن دو شیء قاب متن از طریق یک وصل‌کننده به هم متصل شده‌اند:

![connector-shape-complex](connector-shape-complex.png)

```c++
// یک شیء از کلاس ارائه را می‌سازد که نمایانگر فایل PPTX است
auto pres = System::MakeObject<Presentation>();
// اولین اسلاید موجود در ارائه را دریافت می‌کند
auto slide = pres->get_Slides()->idx_get(0);
// اشکال را از اولین اسلاید دریافت می‌کند
auto shapes = slide->get_Shapes();
// اشکالی را اضافه می‌کند که از طریق یک اتصال‌دهنده به هم ملحق می‌شوند
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// یک اتصال‌دهنده اضافه می‌کند
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// جهت اتصال‌دهنده را مشخص می‌کند
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// ضخامت خط اتصال‌دهنده را تعیین می‌کند
lineFormat->set_Width(3);
// رنگ اتصال‌دهنده را تعیین می‌کند
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// اشکال را با استفاده از اتصال‌دهنده به هم متصل می‌کند
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// نقاط تنظیم اتصال‌دهنده را دریافت می‌کند
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**تنظیم**

می‌توانیم مقادیر نقاط تنظیم وصل‌کننده را با افزایش درصد عرض و ارتفاع مربوطه به ترتیب ۲۰٪ و ۲۰۰٪ تغییر دهیم:

```c++
// مقادیر نقاط تنظیم را تغییر می‌دهد
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

نتیجه:

![connector-adjusted-1](connector-adjusted-1.png)

برای تعریف مدلی که به ما امکان تعیین مختصات و شکل اجزای فردی وصل‌کننده را بدهد، بیایید شکلی بسازیم که به مؤلفهٔ افقی وصل‌کننده در نقطهٔ `connector.Adjustments[0]` متناظر باشد:

```c++
// رسم مؤلفه عمودی اتصال‌دهنده
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

نتیجه:

![connector-adjusted-2](connector-adjusted-2.png)

#### **مورد 2**

در **مورد 1**، یک عملیات سادهٔ تنظیم وصل‌کننده را با استفاده از اصول پایه نشان دادیم. در شرایط عادی، باید چرخش وصل‌کننده و نمایش آن (که توسط `connector.Rotation`، `connector.Frame.FlipH` و `connector.Frame.FlipV` تنظیم می‌شود) را در نظر بگیرید. اکنون روند را نشان می‌دهیم.

ابتدا یک شیء قاب متن جدید (**To 1**) به اسلاید اضافه کنیم (برای اتصال) و یک وصل‌کنندهٔ جدید (سبز) بسازیم که آن را به اشیائی که قبلاً ایجاد کرده‌ایم متصل می‌کند.

```c++
// یک شی بایندینگ جدید ایجاد می‌کند
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// یک اتصال‌دهنده جدید ایجاد می‌کند
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// اشیاء را با استفاده از اتصال‌دهندهٔ تازه ایجاد شده متصل می‌کند
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// نقاط تنظیم اتصال‌دهنده را دریافت می‌کند
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// مقادیر نقاط تنظیم را تغییر می‌دهد
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

نتیجه:

![connector-adjusted-3](connector-adjusted-3.png)

دوم، بیایید شکلی بسازیم که به مؤلفهٔ افقی وصل‌کننده که از نقطهٔ تنظیم جدید `connector.Adjustments[0]` می‌گذرد، متناظر باشد. مقادیر `connector.Rotation`، `connector.Frame.FlipH` و `connector.Frame.FlipV` را استفاده می‌کنیم و فرمول تبدیل مختصات مشهور برای چرخش دور یک نقطهٔ داده شده x0 را اعمال می‌کنیم:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

در مورد ما، زاویهٔ چرخش شیء ۹۰ درجه است و وصل‌کننده به صورت عمودی نمایش داده می‌شود، بنابراین کد متناظر به صورت زیر است:

```c++

```

نتیجه:

![connector-adjusted-4](connector-adjusted-4.png)

ما محاسباتی شامل تنظیمات ساده و نقاط تنظیم پیچیده (نقاط تنظیم با زاویهٔ چرخش) را نمایش دادیم. با استفاده از دانش به دست آمده، می‌توانید مدل خود را توسعه دهید (یا کدی بنویسید) تا یک شیء `GraphicsPath` دریافت کنید یا حتی مقادیر نقاط تنظیم وصل‌کننده را بر اساس مختصات خاص اسلاید تنظیم کنید.

## **یافتن زاویهٔ خطوط وصل‌کننده**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.  
1. از طریق شاخص آن، ارجاع اسلاید را دریافت کنید.  
1. به شکل خطی وصل‌کننده دسترسی پیدا کنید.  
1. از عرض خط، ارتفاع، ارتفاع فریم شکل و عرض فریم شکل برای محاسبهٔ زاویه استفاده کنید.  

این کد C++ عملیاتی را نشان می‌دهد که در آن زاویهٔ یک شکل خطی وصل‌کننده را محاسبه کردیم:

```c++
void ConnectorLineAngle()
{

	// مسیر پوشه اسناد.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// ارائه مورد نظر را بارگذاری می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// به اولین اسلاید دسترسی پیدا می‌کند
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// مجموعهٔ اشکال اسلایدها را دریافت می‌کند
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
	//float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که آیا یک وصل‌کننده می‌تواند به یک شکل خاص «چسبانده» شود؟**

بررسی کنید که شکل [نقاط اتصال](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/get_connectionsitecount/) را ارائه می‌دهد. اگر هیچ نقطه‌ای وجود نداشته باشد یا تعدادشان صفر باشد، قابلیت چسباندن موجود نیست؛ در این صورت از نقاط انتهایی آزاد استفاده کنید و آنها را به‌صورت دستی موقعیت‌دهی کنید. منطقی است قبل از اتصال، تعداد نقاط را بررسی کنید.

**اگر یک از اشکال متصل را حذف کنم، چه اتفاقی برای وصل‌کننده می‌افتد؟**

شابک‌های آن جدا می‌شوند؛ وصل‌کننده به عنوان یک خط عادی با شروع/پایان آزاد در اسلاید باقی می‌ماند. می‌توانید آن را حذف کنید یا اتصالات را دوباره اختصاص دهید و در صورت نیاز، [بازمسیر کردن](https://reference.aspose.com/slides/fa/cpp/aspose.slides/connector/reroute/) را انجام دهید.

**آیا پیوندهای وصل‌کننده هنگام کپی اسلاید به ارائهٔ دیگر حفظ می‌شوند؟**

عموماً بله، به شرطی که شکل‌های هدف نیز کپی شوند. اگر اسلاید بدون اشکال متصل به فایل دیگری وارد شود، انتهاها آزاد می‌شوند و شما باید آنها را مجدداً متصل کنید.