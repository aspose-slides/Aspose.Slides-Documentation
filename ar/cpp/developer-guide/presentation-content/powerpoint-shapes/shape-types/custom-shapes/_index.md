---
title: تخصيص أشكال العرض التقديمي في C++
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/cpp/custom-shape/
keywords:
- شكل مخصص
- إضافة شكل
- إنشاء شكل
- تغيير الشكل
- هندسة الشكل
- مسار هندسي
- نقاط المسار
- نقاط تحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ C++: مسارات هندسية، زوايا منحنية، أشكال مركبة."
---

## **تغيير شكل باستخدام نقاط التحرير**
تخيل مربعًا. في PowerPoint، باستخدام **نقاط التحرير**، يمكنك  

* نقل زاوية المربع إلى الداخل أو الخارج
* تحديد الانحناء للزاوية أو النقطة
* إضافة نقاط جديدة إلى المربع
* التعامل مع النقاط على المربع، إلخ.  

بشكل أساسي، يمكنك تنفيذ المهام الموضحة على أي شكل. باستخدام نقاط التحرير، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود.  

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

قبل أن تبدأ في تحرير أشكال PowerPoint عبر نقاط التحرير، قد ترغب في النظر في هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، لا يحتوي على نقطة بداية أو نهاية. عندما يكون الشكل مفتوحًا، يكون له بداية ونهاية. 
* تتكون جميع الأشكال من نقطتي تثبيت على الأقل مرتبطتين ببعضهما عبر خطوط
* الخط إما مستقيم أو منحني. تحدد نقاط التثبيت طبيعة الخط. 
* نقاط التثبيت توجد ك نقاط زاوية، نقاط مستقيمة، أو نقاط ناعمة:
  * نقطة الزاوية هي نقطة يلتقي فيها خطان مستقيمان بزاوية. 
  * نقطة ناعمة هي نقطة يكون فيها مقبضان في خط مستقيم وتلتقي أجزاء الخط بمنحنى ناعم. في هذه الحالة، يتم فصل جميع المقابض عن نقطة التثبيت بمسافة متساوية. 
  * نقطة مستقيمة هي نقطة يكون فيها مقبضان في خط مستقيم وتلتقي أجزاء الخط بمنحنى ناعم. في هذه الحالة، لا يلزم أن تكون المقابض منفصلة عن نقطة التثبيت بمسافة متساوية. 
* عن طريق نقل أو تحرير نقاط التثبيت (التي تغير زاوية الخطوط)، يمكنك تغيير مظهر الشكل. 

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) والواجهة [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 

* تمثل نسخة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) مسارًا هندسيًا لكائن [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape). 
* لإسترجاع `GeometryPath` من نسخة `IGeometryShape`، يمكنك استخدام الطريقة [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* لتحديد `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) للـ*أشكال الصلبة* و[IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) للـ*الأشكال المركبة*. 
* لإضافة أجزاء، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 
* باستخدام الطرق [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) و[IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) يمكنك ضبط مظهر مسار هندسي. 
* باستخدام الطريقة [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) يمكنك استرجاع مسار هندسي لكائن `GeometryShape` كمصفوفة من أجزاء المسار. 
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) إلى [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path). 
* استخدم طرق [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) و[GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (من فئة [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)) لتحويل [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) إلى [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) والعودة بالعكس. 

## **عمليات تحرير بسيطة**

يظهر لك هذا الكود C++ كيفية  

**إضافة خط** إلى نهاية المسار:
``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**إضافة خط** إلى موقع محدد على المسار:
``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```

**إضافة منحنى بيزيه مكعب** إلى نهاية المسار:
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**إضافة منحنى بيزيه مكعب** إلى الموقع المحدد على المسار:
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```

**إضافة منحنى بيزيه رباعي** إلى نهاية المسار:
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**إضافة منحنى بيزيه رباعي** إلى موقع محدد على المسار:
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```

**إلحاق قوس محدد** إلى مسار:
``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**إغلاق الشكل الحالي** للمسار:
``` cpp
void CloseFigure();
```

**تحديد الموضع للنقطة التالية**:
``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**إزالة جزء المسار** عند فهرس معين:
``` cpp
void RemoveAt(int32_t index);
```


## **إضافة نقاط مخصصة إلى شكل**
1. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) وتحديد النوع [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. الحصول على نسخة من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) من الشكل.  
3. إضافة نقطة جديدة بين النقطتين العلويتين على المسار.  
4. إضافة نقطة جديدة بين النقطتين السفليتين على المسار.  
5. تطبيق المسار على الشكل.  

يظهر لك هذا الكود C++ كيفية إضافة نقاط مخصصة إلى شكل:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```


![example1_image](custom_shape_1.png)

## **إزالة نقاط من شكل**

1. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) وتحديد النوع [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. الحصول على نسخة من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) من الشكل.  
3. إزالة الجزء من المسار.  
4. تطبيق المسار على الشكل.  

يظهر لك هذا الكود C++ كيفية إزالة نقاط من شكل:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```


![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

1. احسب النقاط للشكل.  
2. إنشاء نسخة من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
3. املأ المسار بالنقاط.  
4. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
5. تطبيق المسار على الشكل.  

يظهر لك هذا الكود C++ كيفية إنشاء شكل مخصص:
``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```


![example3_image](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

1. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
2. إنشاء النسخة الأولى من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
3. إنشاء النسخة الثانية من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).  
4. تطبيق المسارات على الشكل.  

يظهر لك هذا الكود C++ كيفية إنشاء شكل مخصص مركب:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```


![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

يظهر لك هذا الكود C++ كيفية إنشاء شكل مخصص بزوايا منحنية (للداخل);
```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **اكتشف ما إذا كان شكل الهندسة مغلقًا**

يُعرّف الشكل المغلق بأنه الشكل الذي تتصل جميع جهاته لتكوّن حدًا واحدًا دون فراغات. يمكن أن يكون هذا الشكل شكلًا هندسيًا بسيطًا أو مخططًا مخصصًا معقدًا. يوضح المثال البرمجي التالي كيفية التحقق مما إذا كان شكل الهندسة مغلقًا:
```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```


## **تحويل GeometryPath إلى GraphicsPath** 

1. إنشاء نسخة من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).  
2. إنشاء نسخة من فئة [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) في مساحة الأسماء [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).  
3. تحويل نسخة [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) إلى نسخة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) باستخدام [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).  
4. تطبيق المسارات على الشكل.  

هذا الكود C++—تنفيذ للخطوات أعلاه—يُظهر عملية التحويل من **GeometryPath** إلى **GraphicsPath**:
```cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```


![example5_image](custom_shape_5.png)

## **FAQ**

**ماذا سيحدث للملء والمخطط بعد استبدال الهندسة؟**  
تبقى الأنماط مع الشكل؛ يتغير الحد فقط. يتم تطبيق الملء والمخطط تلقائيًا على الهندسة الجديدة.

**كيف أدوّر الشكل المخصص مع الهندسة بشكل صحيح؟**  
استخدم خاصية [rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) لل形؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة لتثبيت النتيجة؟**  
نعم. صدّر الشريحة المطلوبة [slide](/slides/ar/cpp/convert-powerpoint-to-png/) أو [shape](/slides/ar/cpp/create-shape-thumbnails/) نفسها إلى تنسيق نقطي؛ هذا يُبسّط العمل اللاحق مع الهندسات الثقيلة.