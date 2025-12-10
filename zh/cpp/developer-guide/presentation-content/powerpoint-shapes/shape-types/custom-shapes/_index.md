---
title: 在 C++ 中自定义演示文稿形状
linktitle: 自定义形状
type: docs
weight: 20
url: /zh/cpp/custom-shape/
keywords:
- 自定义形状
- 添加形状
- 创建形状
- 更改形状
- 形状几何
- 几何路径
- 路径点
- 编辑点
- 添加点
- 删除点
- 编辑操作
- 弧形拐角
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中创建和自定义形状：几何路径、弧形拐角、复合形状。"
---

## **使用编辑点更改形状**
考虑一个正方形。在 PowerPoint 中，使用 **编辑点**，你可以

* 将正方形的角向内或向外移动
* 指定角或点的曲率
* 向正方形添加新点
* 操作正方形上的点，等等

本质上，你可以对任何形状执行上述任务。使用编辑点，你可以更改形状或从现有形状创建新形状。

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

在通过编辑点编辑 PowerPoint 形状之前，你可能想要考虑以下关于形状的要点：

* 形状（或其路径）可以是闭合的，也可以是开放的。
* 当形状闭合时，它没有起始点或结束点。 当形状开放时，它有起始点和结束点。
* 所有形状至少由 2 个锚点通过线段相连组成
* 线段可以是直的或曲的。锚点决定线段的性质。
* 锚点可以是拐角点、直点或平滑点：
  * 拐角点是两条直线在一个角度处相交的点。
  * 平滑点是两个控制柄位于同一直线上，且线段以平滑曲线相连的点。在这种情况下，所有控制柄与锚点的距离相等。
  * 直点是两个控制柄位于同一直线上，且该线段以平滑曲线相连的点。在这种情况下，控制柄与锚点的距离不必相等。
* 通过移动或编辑锚点（这会改变线段的角度），可以改变形状的外观。

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 类和 [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path) 接口。

* 一个 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 实例表示 [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape) 对象的几何路径。
* 要从 `IGeometryShape` 实例检索 `GeometryPath`，可以使用 [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1) 方法。
* 要为形状设置 `GeometryPath`，可以使用以下方法：针对*实心形状*使用 [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986)；针对*复合形状*使用 [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750)。
* 要添加段，可以使用 [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path) 下的方法。
* 使用 [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) 和 [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) 方法，可以设置几何路径的外观。
* 使用 [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) 方法，可以将 `GeometryShape` 的几何路径作为路径段数组检索。
* 若要访问其他形状几何定制选项，可将 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 转换为 [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path)。
* 使用 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) 和 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) 方法（来自 [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util) 类）在 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 与 [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) 之间相互转换。

## **简单编辑操作**

以下 C++ 代码演示了如何

**在路径末尾添加直线**  
``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**在路径的指定位置添加直线**：  
``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```

**在路径末尾添加三次贝塞尔曲线**：  
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**在路径的指定位置添加三次贝塞尔曲线**：  
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```

**在路径末尾添加二次贝塞尔曲线**：  
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**在路径的指定位置添加二次贝塞尔曲线**：  
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```

**向路径追加给定弧段**：  
``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**关闭路径的当前图形**：  
``` cpp
void CloseFigure();
```

**设置下一个点的位置**：  
``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**删除指定索引处的路径段**：  
``` cpp
void RemoveAt(int32_t index);
```


## **向形状添加自定义点**
1. 创建 [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) 类的实例并将其类型设置为 [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5)。
2. 从形状获取 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 类的实例。
3. 在路径的两个顶部点之间添加一个新点。
4. 在路径的两个底部点之间添加一个新点。
5. 将路径应用于形状。

以下 C++ 代码演示了如何向形状添加自定义点：  
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

## **从形状中移除点**
1. 创建 [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) 类的实例并将其类型设置为 [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5)。
2. 从形状获取 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 类的实例。
3. 删除路径的段。
4. 将路径应用于形状。

以下 C++ 代码演示了如何从形状中移除点：  
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```


![example2_image](custom_shape_2.png)

##  **创建自定义形状**
1. 计算形状的点。
2. 创建 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 类的实例。
3. 用这些点填充路径。
4. 创建 [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) 类的实例。
5. 将路径应用于形状。

以下 C++ 代码演示了如何创建自定义形状：  
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

## **创建复合自定义形状**
1. 创建 [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) 类的实例。
2. 创建第一个 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 类的实例。
3. 创建第二个 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 类的实例。
4. 将这些路径应用于形状。

以下 C++ 代码演示了如何创建复合自定义形状：  
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

## **创建带有弧形角的自定义形状**
以下 C++ 代码演示了如何创建带有内凹弧形角的自定义形状；  
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


## **判断形状几何是否闭合**
闭合形状被定义为其所有边相连，形成没有间隙的单一边界的形状。此类形状可以是简单的几何形状，也可以是复杂的自定义轮廓。下面的代码示例展示了如何检查形状几何是否闭合：  
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


## **将 GeometryPath 转换为 GraphicsPath**
1. 创建 [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) 类的实例。
2. 创建 [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d) 命名空间下的 [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) 类的实例。
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util) 将 [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) 实例转换为 [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) 实例。
4. 将路径应用于形状。

以下 C++ 代码——上述步骤的实现——演示了 **GeometryPath** 到 **GraphicsPath** 的转换过程：  
``` cpp
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

**替换几何后填充和轮廓会怎样？**  
样式仍然保留在形状上；仅轮廓会改变。填充和轮廓会自动应用到新的几何上。

**如何正确地旋转自定义形状及其几何？**  
使用形状的[rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/)属性；几何会随形状一起旋转，因为它绑定在形状自己的坐标系上。

**我可以将自定义形状转换为图像以“锁定”结果吗？**  
可以。将所需的[slide](/slides/zh/cpp/convert-powerpoint-to-png/)区域或[shape](/slides/zh/cpp/create-shape-thumbnails/)本身导出为光栅格式；这简化了对复杂几何的后续处理。