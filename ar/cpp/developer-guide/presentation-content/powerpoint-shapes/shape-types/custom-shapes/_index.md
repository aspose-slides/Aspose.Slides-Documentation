---
title: شكل مخصص
type: docs
weight: 20
url: /ar/cpp/custom-shape/
keywords: "شكل PowerPoint, شكل مخصص, عرض PowerPoint, C++, Aspose.Slides for C++"
description: "أضف شكل مخصص في عرض PowerPoint باستخدام C++"
---

# تغيير شكل باستخدام نقاط التعديل
اعتبر مربعًا. في PowerPoint، باستخدام **نقاط التعديل**، يمكنك 

* نقل زاوية المربع إلى الداخل أو الخارج
* تحديد انحناء لزاوية أو نقطة
* إضافة نقاط جديدة إلى المربع
* التلاعب بالنقاط على المربع، إلخ. 

بشكل أساسي، يمكنك تنفيذ المهام الموصوفة على أي شكل. باستخدام نقاط التعديل، يمكنك تغيير شكل أو إنشاء شكل جديد من شكل موجود. 

## **نصائح لتحرير الأشكال**

![overview_image](custom_shape_0.png)

قبل البدء في تحرير أشكال PowerPoint من خلال نقاط التعديل، قد ترغب في النظر في هذه النقاط حول الأشكال:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* عندما يكون الشكل مغلقًا، فإنه يفتقر إلى نقطة بداية أو نهاية. عندما يكون الشكل مفتوحًا، فإنه يحتوي على بداية ونهاية. 
* جميع الأشكال تتكون من نقطتي ربط على الأقل مرتبطة ببعضها بواسطة خطوط.
* الخط يمكن أن يكون إما مستقيمًا أو منحنيًا. تحدد نقاط الربط طبيعة الخط. 
* توجد نقاط الربط كنقاط زوايا، أو نقاط مستقيمة، أو نقاط ناعمة:
  * نقطة الزاوية هي نقطة حيث تلتقي خطين مستقيمين بزاوية. 
  * النقطة الناعمة هي نقطة حيث توجد يدان في خط مستقيم وينضم مقاطع الخط إلى منحنى سلس. في هذه الحالة، تبتعد جميع الأيدي عن نقطة الربط بنفس المسافة. 
  * النقطة المستقيمة هي نقطة حيث توجد يدان في خط مستقيم وتنضم مقاطع ذلك الخط إلى منحنى سلس. في هذه الحالة، لا تحتاج الأيدي إلى الابتعاد عن نقطة الربط بنفس المسافة. 
* من خلال تحريك أو تحرير نقاط الربط (التي تغير زاوية الخطوط)، يمكنك تغيير كيفية ظهور الشكل. 

لتحرير أشكال PowerPoint من خلال نقاط التعديل، توفر **Aspose.Slides** فئة [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) وواجهة [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 

* تمثل مثيل [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) مسارًا هندسيًا لشيء [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape). 
* لاسترداد `GeometryPath` من مثيل `IGeometryShape`، يمكنك استخدام طريقة [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* لتعيين `GeometryPath` لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) للأشكال *الصلبة* و [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) للأشكال *المركبة*.
* لإضافة مقاطع، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path). 
* باستخدام [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) و [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) الطرق، يمكنك تعيين مظهر لمسار هندسي.
* باستخدام [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) الطريقة، يمكنك استرداد المسار الهندسي لشكل `GeometryShape` كمصفوفة من مقاطع المسار. 
* للوصول إلى خيارات تخصيص الشكل الهندسي الإضافية، يمكنك تحويل [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) إلى [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path)
* استخدم [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) و [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) الطرق (من فئة [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)) لتحويل [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) إلى [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) مرة أخرى.

## **عمليات تحرير بسيطة**

يوضح كود C++ هذا كيف يمكنك

**إضافة خط** إلى نهاية مسار

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**إضافة خط** إلى موضع محدد على مسار:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**إضافة منحنى بيزير مكعب** في نهاية مسار:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**إضافة منحنى بيزير مكعب** إلى الموضع المحدد على مسار:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**إضافة منحنى بيزير تربيعي** في نهاية مسار:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**إضافة منحنى بيزير تربيعي** لموضع محدد على مسار:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**إلحاق قوس معين** إلى مسار:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**إغلاق الشكل الحالي** لمسار:

``` cpp
void CloseFigure();
```
**تعيين الموضع للنقطة التالية**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**إزالة مقطع المسار** في مؤشر معين:

``` cpp
void RemoveAt(int32_t index);
```
## **إضافة نقاط مخصصة إلى الشكل**
1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) واضبط نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) من الشكل.
3. أضف نقطة جديدة بين النقطتين العلويتين على المسار.
4. أضف نقطة جديدة بين النقطتين السفليتين على المسار.
5. طبق المسار على الشكل.

يوضح كود C++ هذا كيفية إضافة نقاط مخصصة إلى شكل:

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

##  إزالة نقاط من الشكل

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) واضبط نوع [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5). 
2. احصل على مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) من الشكل.
3. أزل المقطع للمسار.
4. طبق المسار على الشكل.

يوضح كود C++ هذا كيفية إزالة نقاط من شكل:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

##  **إنشاء شكل مخصص**

1. احسب النقاط للشكل.
2. أنشئ مثيلًا من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path). 
3. املأ المسار بالنقاط.
4. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape). 
5. طبق المسار على الشكل.

يوضح كود C++ هذا كيفية إنشاء شكل مخصص:

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

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
2. أنشئ أول مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
3. أنشئ ثانٍ مثيل من فئة [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
4. طبق المسارات على الشكل.

يوضح كود C++ هذا كيفية إنشاء شكل مخصص مركب:

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

## **إنشاء شكل مخصص مع زوايا منحنية**

يوضح كود C++ هذا كيفية إنشاء شكل مخصص مع زوايا منحنية (للداخل);

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

## **تحويل GeometryPath إلى GraphicsPath** 

1. أنشئ مثيلًا من فئة [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
2. أنشئ مثيلًا من فئة [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) من مساحة أسماء [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).
3. تحويل مثيل [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) إلى مثيل [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) باستخدام [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).
4. طبق المسارات على الشكل.

يوضح كود C++—وهو تنفيذ للخطوات أعلاه—عملية التحويل من **GeometryPath** إلى **GraphicsPath**:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"نص داخل الشكل", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)