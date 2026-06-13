---
title: ปรับแต่งรูปร่างการนำเสนอบน Android
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/androidjava/custom-shape/
keywords:
- รูปร่างกำหนดเอง
- เพิ่มรูปร่าง
- สร้างรูปร่าง
- เปลี่ยนรูปร่าง
- เรขาคณิตของรูปร่าง
- เส้นทางเรขาคณิต
- จุดของเส้นทาง
- จุดแก้ไข
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในการนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างแบบผสม"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งรูปร่างการนำเสนอใน Aspose.Slides ด้วยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต มันแสดงวิธีการทำงานกับ `GeometryPath` และ `IGeometryPath` เพื่อแก้ไขรูปร่างที่มีอยู่, ทำการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือลบจุด, และนำเรขาคณิตที่อัปเดตกลับไปใช้กับรูปร่าง

นอกจากนี้ยังสาธิตวิธีสร้างรูปร่างแบบกำหนดเองและแบบผสม, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่, และแปลงระหว่าง `GeometryPath` กับ `java.awt.Shape` สำหรับสถานการณ์การปรับแต่งเรขาคณิตเพิ่มเติม

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**
พิจารณาสี่เหลี่ยมจัตุรัส ใน PowerPoint โดยใช้ **จุดแก้ไข** คุณสามารถ

* ย้ายมุมของสี่เหลี่ยมเข้าไปหรือออกไป
* ระบุความโค้งสำหรับมุมหรือจุด
* เพิ่มจุดใหม่ลงในสี่เหลี่ยม
* จัดการจุดบนสี่เหลี่ยม เป็นต้น

โดยสรุป คุณสามารถทำงานที่อธิบายไว้กับรูปร่างใดก็ได้ ด้วยการใช้จุดแก้ไข คุณสามารถเปลี่ยนรูปร่างหรือสร้างรูปร่างใหม่จากรูปร่างที่มีอยู่

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

ก่อนที่คุณจะเริ่มแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข คุณอาจต้องพิจารณาประเด็นต่อไปนี้เกี่ยวกับรูปร่าง:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เมื่อรูปร่างเป็นแบบปิด จะไม่มีจุดเริ่มต้นหรือจุดสิ้นสุด เมื่อรูปร่างเป็นแบบเปิด จะมีจุดเริ่มต้นและจุดสิ้นสุด
* รูปร่างทั้งหมดประกอบด้วยจุดยึด (anchor points) อย่างน้อย 2 จุดที่เชื่อมต่อกันด้วยเส้น
* เส้นสามารถเป็นเส้นตรงหรือเส้นโค้ง จุดยึดกำหนดลักษณะของเส้น
* จุดยึดมีอยู่ในรูปแบบจุดมุม, จุดตรง, หรือจุดเรียบ:
  * จุดมุมคือจุดที่เส้นตรง 2 เส้นมาบรรจบกันที่มุม
  * จุดเรียบคือจุดที่มีมือ (handle) 2 ตัวอยู่ในเส้นตรงและส่วนของเส้นเชื่อมต่อกันเป็นโค้งเรียบ ในกรณีนี้มือทั้งหมดห่างจากจุดยึดเท่ากัน
  * จุดตรงคือจุดที่มีมือ 2 ตัวอยู่ในเส้นตรงและส่วนของเส้นเชื่อมต่อกันเป็นโค้งเรียบ ในกรณีนี้มือไม่จำเป็นต้องห่างจากจุดยึดเท่ากัน
* ด้วยการย้ายหรือแก้ไขจุดยึด (ซึ่งเปลี่ยนมุมของเส้น) คุณสามารถเปลี่ยนลักษณะของรูปร่างได้

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** ให้บริการคลาส [**GeometryPath**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath) และอินเตอร์เฟส [**IGeometryPath**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryPath)

* ตัว [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath) แทนเส้นทางเรขาคณิตของอ็อบเจกต์ [IGeometryShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryShape)
* เพื่อดึง `GeometryPath` จากอินสแตนซ์ `IGeometryShape` ให้ใช้เมธอด [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--)
* เพื่อกำหนด `GeometryPath` ให้กับรูปร่าง ให้ใช้เมธอดเหล่านี้: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) สำหรับ *solid shapes* และ [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) สำหรับ *composite shapes*
* เพื่อเพิ่มเซกเมนต์ ให้ใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryPath)
* ด้วยเมธอด [IGeometryPath.setStroke](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) และ [IGeometryPath.setFillMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิตได้
* ด้วยเมธอด [IGeometryPath.getPathData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IGeometryPath#getPathData--) คุณสามารถดึงเส้นทางเรขาคณิตของ `GeometryShape` เป็นอาเรย์ของเซกเมนต์เส้นทาง
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตของรูปร่างเพิ่มเติม คุณสามารถแปลง [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath) เป็น [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* ใช้เมธอด [geometryPathToGraphicsPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) และ [graphicsPathToGeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (จากคลาส [ShapeUtil](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapeUtil)) เพื่อแปลง [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath) ไปเป็น [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) และกลับกัน

## **การดำเนินการแก้ไขอย่างง่าย**

โค้ด Java นี้แสดงวิธี

**เพิ่มเส้น** ที่ปลายของเส้นทาง

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**เพิ่มเส้น** ที่ตำแหน่งที่ระบุบนเส้นทาง:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**เพิ่มเส้นโค้ง Bezier cubic** ที่ปลายของเส้นทาง:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**เพิ่มเส้นโค้ง Bezier cubic** ที่ตำแหน่งที่ระบุบนเส้นทาง:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**เพิ่มเส้นโค้ง Bezier quadratic** ที่ปลายของเส้นทาง:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**เพิ่มเส้นโค้ง Bezier quadratic** ที่ตำแหน่งที่ระบุบนเส้นทาง:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**ต่อเติมส่วนโค้ง** ที่กำหนดให้กับเส้นทาง:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**ปิดรูปทรงปัจจุบัน** ของเส้นทาง:

``` java
public void closeFigure();
```
**กำหนดตำแหน่งสำหรับจุดต่อไป**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**ลบเซกเมนต์ของเส้นทาง** ที่ดัชนีที่ระบุ:

``` java
public void removeAt(int index);
```

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**
1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryShape) และกำหนดประเภทเป็น [ShapeType.Rectangle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapeType)
2. ดึงอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath) จากรูปร่าง
3. เพิ่มจุดใหม่ระหว่างจุดบนสุด 2 จุดของเส้นทาง
4. เพิ่มจุดใหม่ระหว่างจุดล่างสุด 2 จุดของเส้นทาง
5. นําเส้นทางไปใช้กับรูปร่าง

โค้ด Java นี้แสดงวิธีเพิ่มจุดกำหนดเองให้กับรูปร่าง:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **ลบจุดจากรูปร่าง**

1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryShape) และกำหนดประเภทเป็น [ShapeType.Heart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapeType)
2. ดึงอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath) จากรูปร่าง
3. ลบเซกเมนต์ของเส้นทาง
4. นําเส้นทางไปใช้กับรูปร่าง

โค้ด Java นี้แสดงวิธีลบจุดจากรูปร่าง:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

## **สร้างรูปร่างกำหนดเอง**

1. คำนวณจุดสำหรับรูปร่าง
2. สร้างอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath)
3. เติมเส้นทางด้วยจุดต่าง ๆ
4. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryShape)
5. นําเส้นทางไปใช้กับรูปร่าง

โค้ด Java นี้แสดงวิธีสร้างรูปร่างกำหนดเอง:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}

```
![example3_image](custom_shape_3.png)

## **สร้างรูปร่างกำหนดเองแบบผสม**

  1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryShape)
  2. สร้างอินสแตนซ์แรกของคลาส [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath)
  3. สร้างอินสแตนซ์ที่สองของคลาส [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath)
  4. นําเส้นทางไปใช้กับรูปร่าง

โค้ด Java นี้แสดงวิธีสร้างรูปร่างกำหนดเองแบบผสม:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **สร้างรูปร่างกำหนดเองพร้อมมุมโค้ง**

โค้ด Java นี้แสดงวิธีสร้างรูปร่างกำหนดเองพร้อมมุมโค้ง (ด้านใน);

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.closeFigure();

    childShape.setGeometryPath(geometryPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

รูปร่างแบบปิดหมายถึงรูปร่างที่ทุกด้านเชื่อมต่อกัน形成เส้นขอบเดียวโดยไม่มีช่องว่าง รูปร่างเช่นนี้อาจเป็นรูปทรงเรขาคณิตง่ายหรือโม่งเส้นแนวกำหนดเองที่ซับซ้อน ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **แปลง GeometryPath เป็น java.awt.Shape** 

1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryShape)
2. สร้างอินสแตนซ์ของคลาส [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
3. ใช้ [ShapeUtil](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapeUtil) แปลงอินสแตนซ์ [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ให้เป็นอินสแตนซ์ [GeometryPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/GeometryPath)
4. นําเส้นทางไปใช้กับรูปร่าง

โค้ด Java นี้—การนำขั้นตอนข้างต้นไปใช้—แสดงกระบวนการแปลง **GeometryPath** ไปเป็น **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // สร้างรูปร่างใหม่
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // รับเส้นทางเรขาคณิตของรูปร่าง
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // สร้างเส้นกราฟิกใหม่พร้อมข้อความ
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // แปลงเส้นกราฟิกเป็นเส้นทางเรขาคณิต
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // กำหนดการรวมของเส้นทางเรขาคณิตใหม่และเส้นทางเรขาคณิตเดิมให้กับรูปร่าง
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **คำถามที่พบบ่อย**

**การแทนที่เรขาคณิตจะส่งผลต่อการเติมสีและเส้นขอบอย่างไร?**

สไตล์ยังคงอยู่กับรูปร่าง; เพียงแค่โครงร่างเปลี่ยนไป การเติมสีและเส้นขอบจะถูกนำไปใช้กับเรขาคณิตใหม่โดยอัตโนมัติ

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#setRotation-float-) ของรูปร่าง; เรขาคณิตจะหมุนพร้อมกับรูปร่างเพราะเชื่อมโยงกับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ "ล็อก" ผลลัพธ์ได้หรือไม่?**

ได้. ให้ส่งออก [slide](/slides/th/androidjava/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/androidjava/create-shape-thumbnails/) เองเป็นรูปแบบแรสเตอร์; วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น