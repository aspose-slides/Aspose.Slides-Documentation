---
title: ปรับแต่งรูปร่างการนำเสนอใน Java
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/java/custom-shape/
keywords:
- รูปร่างกำหนดเอง
- เพิ่มรูปร่าง
- สร้างรูปร่าง
- เปลี่ยนรูปร่าง
- เรขาคณิตของรูปร่าง
- เส้นทางเรขาคณิต
- จุดของเส้นทาง
- แก้ไขจุด
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างคอมโพสท์"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปร่างในงานนำเสนอด้วย Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต แสดงวิธีการทำงานกับ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) และ [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่ ทำการแก้ไขเส้นทางพื้นฐาน เพิ่มหรือเอาจุดออก และนำเรขาคณิตที่อัปเดตกลับไปใช้กับรูปร่าง

ยังแสดงวิธีการสร้างรูปร่างแบบกำหนดเองและแบบผสม สร้างรูปร่างที่มีมุมโค้ง ตรวจสอบว่ารูปร่างเป็นปิดหรือไม่ ตรวจสอบองค์ประกอบของรูปร่าง และแปลงรูปแบบข้อความของ Java AWT ให้เป็นเส้นทางเรขาคณิต

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยม:

* ย้ายมุมไปด้านในหรือด้านนอก
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดช่วยให้คุณปรับเส้นรอบรูปของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นฐานสำหรับการสร้างรูปร่างใหม่

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปร่างใน PowerPoint โปรดจำแนวคิดเหล่านี้ไว้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนต่าง ๆ
* ส่วนสามารถเป็นเส้นตรงหรือโค้ง จุดยึดและมือควบคุมกำหนดรูปทรงของมัน
* จุดยึดมีประเภทเป็นจุดมุม จุดตรง หรือจุดลื่น:
  * ที่จุดมุม ส่วนที่ต่อกันสามารถพบกันที่มุม
  * ที่จุดลื่น มือควบคุมสองอันจะเรียงกันและอยู่ห่างจากจุดยึดเท่ากัน
  * ที่จุดตรง มือควบคุมสองอันจะเรียงกันแต่ระยะห่างจากจุดยึดอาจแตกต่างกัน
* การย้ายจุดยึดหรือปรับมือควบคุมจะเปลี่ยนเส้นรอบรูปของรูปร่าง

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) และอินเทอร์เฟซ [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/)

* ตัวอย่าง [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) แสดงเส้นทางเรขาคณิตของวัตถุ [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) จากอินสแตนซ์ [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) ให้ใช้เมธอด [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--)
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ให้กับรูปร่าง ให้ใช้เมธอด: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) สำหรับรูปร่างที่มีเส้นทางเดียวและ [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มส่วน สามารถใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/)
* ด้วยเมธอด [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) และ [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) คุณสามารถกำหนดลักษณะของเส้นทางเรขาคณิตได้
* ด้วยเมธอด [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) เป็นอาเรย์ของส่วนเส้นได้
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตเพิ่มเติมของรูปร่าง คุณสามารถอ่าน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ผ่าน [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) แล้วทำซ้ำส่วนบน [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)

## **การดำเนินการแก้ไขง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การโอเวอร์โหลดที่รับดัชนีจะใส่ส่วนที่ตำแหน่งศูนย์ฐานในอาเรย์ส่วนของเส้นทาง

| การดำเนินการ | วิธีการ |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier cubic ที่มีจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier quadratic ที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| เพิ่มส่วนโค้งรีที่มีขนาดและมุมตามองศาที่กำหนด | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| ปิดรูปปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| กำหนดจุดเริ่มต้นของรูป | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| ลบส่วนที่ตำแหน่งศูนย์ฐาน | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **เพิ่มจุดกำหนดเองไปยังรูปร่าง**

ตัวอย่างนี้ใส่สองจุดลงในรูปร่างสี่เหลี่ยมโดยใช้ [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) แล้วนำเส้นทางที่แก้ไขไปใช้กับ [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) พิกัดเป็นค่าท้องถิ่นของรูปร่าง: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลางของรูปร่าง, ห่างจากด้านซ้าย 100 จุดและจากด้านบน 50 จุด ดัชนีส่วน 1 และ 4 ทำให้จุดเหล่านี้อยู่บนขอบบนและล่าง ดึงขอบเหล่านั้นเข้าหากัน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **ลบจุดจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างหัวใจโดยลบส่วนที่ตำแหน่งศูนย์ฐาน 2 ด้วย [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) แล้วนำเส้นทางที่แก้ไขไปใช้กับ [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) เพื่ออัปเดตเส้นรอบรูปของรูปร่าง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **สร้างรูปร่างกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุดกำหนดหัวและช่องว่าง; การก้าว 72 องศา ทำให้หัวห้าแฉกกระจายเท่า ๆ กัน เส้นทางปิดด้วย [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) แล้วนำไปใช้กับรูปร่างสี่เหลี่ยมโดยใช้ [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) แทนที่โครงร่างเดิม

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **สร้างรูปร่างกำหนดเองแบบผสม**

ตัวอย่างนี้กำหนดสองอ็อบเจกต์ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ที่ปิดสำหรับส่วนบนและล่างของรูปร่าง การนำสองเส้นทางไปใช้ด้วย [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) จะสร้างรูปร่างผสมเดียวที่มีช่องว่างตรงส่วนกลางของรูปร่าง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **สร้างรูปร่างกำหนดเองที่มีมุมโค้ง**

ตัวอย่างนี้ผสานส่วนเส้นตรงกับ [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) เพื่อสร้างรูปร่างที่มุมโค้งเข้าด้านใน แต่ละขนาดมุมกำหนดความกว้างและความสูงของโค้งในหน่วยจุด และการสแกน -90 องศาจะวาดสี่เหลี่ยมรีส่วนหนึ่งตามเข็มนาฬิกาตรงกันข้าม เส้นทางที่เสร็จสมบูรณ์นำไปใช้ด้วย [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) และบันทึกงานนำเสนอในรูปแบบ PPTX

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบว่ารูปร่างเป็นเรขาคณิตแบบปิดหรือไม่**

ตัวช่วยด้านล่างตรวจสอบว่าแต่ละเส้นทางเรขาคณิตที่ไม่ว่างเปล่าจบด้วยส่วนปิดหรือไม่ มันอ่าน [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) แล้วเปรียบเทียบคำสั่งสุดท้ายของส่วนด้วย [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) กับ [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) จะคืนค่า false หากไม่มีเส้นทางที่ไม่ว่างเปล่า การตรวจสอบนี้ดูเฉพาะคำสั่งสุดท้ายของแต่ละเส้นทาง ไม่ได้ตรวจสอบทุกซับฟิกเกอร์ภายในเส้นทาง ตัวอย่างพิมพ์ค่า `true` สำหรับสี่เหลี่ยม

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบคำสั่งของเส้นทางเรขาคณิต**

ดาวน์โหลด [contour.pptx](contour.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน รูปร่างแรกบนสไลด์แรกมีขอบบนเป็นเส้นตรง, ส่วนโค้ง Bézier cubic, และขอบปิดเป็นเส้นตรง ใช้ [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) เพื่ออ่านเส้นทางของรูปร่างและ [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) เพื่ออ่านส่วนของแต่ละเส้นทางตามลำดับการวาด สำหรับแต่ละส่วน [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) จะบ่งบอกคำสั่งและกำหนดวิธีการตีความค่าที่ส่งคืนโดย [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--)

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

รูปร่างตั้งอยู่ที่ (200, 100) จุดบนสไลด์ พิกัดที่รายงานเป็นค่าท้องถิ่นของรูปร่าง โดย (0, 0) อยู่ที่มุมซ้ายบน, ค่า x เพิ่มไปทางขวา, ค่า y เพิ่มลงล่าง ส่วนปิดจะกลับไปที่จุดเริ่มต้นโดยไม่มีพิกัดเพิ่ม

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **ดึงและตรวจสอบองค์ประกอบของรูปร่าง**

ใช้ [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) เพื่อตรวจสอบรูปร่างที่มีอยู่เป็นองค์ประกอบที่บรรจุดและประเภทของจุด แคสต์แต่ละ [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) ให้เป็น [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) เพื่อดึงอาเรย์จุดและอาเรย์ประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) และ [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) การแสดงผลนี้เหมาะสำหรับการวิเคราะห์โครงร่างหรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง

ตัวอย่างเปิดไฟล์ input.pptx ค้นหารูปร่างเรขาคณิตแรกบนสไลด์แรกแล้วพิมพ์ส่วนของเส้นทาง ใช้งานการนำเสนอที่มีรูปร่างที่มีส่วนเส้นตรงและโค้งเพื่อดูผลลัพธ์ทั้งสอง ไม่ได้ค้นหาภายในกลุ่ม

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // คงประเภทส่วน, ไม่รวมแฟล็ก.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // ใช้จุดควบคุมทั้งสองจุดและจุดสิ้นสุด.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

อาเรย์สอดคล้องตามดัชนี: `points[i]` คือจุดและ `types[i]` บ่งบอกบทบาทของจุดนั้น ประเภท `0` เริ่มฟิกเกอร์, ประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน ส่วน Bézier cubic เริ่มที่จุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` ต่อเนื่องสามรายการ: จุดควบคุมสองจุดแล้วตามด้วยจุดสิ้นสุดใหม่ ลูปจะรับสามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดเพื่อดูว่าปิดหรือไม่

ประเภทจุดยังมีแฟล็กด้วย การใช้มาสก์ `0x07` เพื่อระบุประเภทส่วนและทดสอบ `0x80` แยกต่างหากเพื่อจับซับพาธที่ปิด ตัวอย่าง `129` (`0x81`) หมายถึงจุดสิ้นสุดของเส้นที่ปิดซับพาธ, `131` (`0x83`) หมายถึงจุดสิ้นสุดของ Bézier ที่ปิด Java เก็บแฟล็กเหล่านี้ในไบต์ที่เป็น signed;การมาสก์จะคงค่าบิตตามที่ตั้งใจ การเปรียบเทียบค่าเดิมกับ `1` หรือ `3` อย่างเดียวจะพลาดกรณีเหล่านี้ แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทส่วนพื้นฐาน

**พิกัดและการแปลง** จุดวัดเป็นหน่วยจุด (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงล่าง สำหรับรูปร่างที่ไม่ได้อยู่ในกลุ่ม พิกัดที่ดึงแล้วรวมตำแหน่งที่คืนจาก [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) และ [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) พร้อมกับความกว้างและความสูง ตัวอย่างสี่เหลี่ยมที่ไม่หมุนที่ `(100, 200)` ขนาด `120 × 80` มีขอบโค้ง `(100, 200)`–`(220, 280)` อย่าเพิ่มตำแหน่งของรูปร่างอีกครั้ง ให้ลบ X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่ได้หมุน

จุดที่ดึงไม่รวมการหมุนของรูปร่างที่คืนจาก [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) หรือการพลิกแนวนอนและแนวตั้ง เพื่อให้ได้โครงร่างที่แสดงบนหน้าจอ ต้องนำการแปลงเหล่านี้มาปรับรอบศูนย์กลางของรูปร่าง สำหรับรูปร่างที่อยู่ในกลุ่ม ต้องคำนึงถึงการแมปพิกัดของกลุ่มและการแปลง; อย่าสมมติว่าจุดที่ดึงคือพิกัดสุดท้ายบนสไลด์หรือทำการแปลหรือสเกลซ้ำหากมันได้สะท้อนในกรอบของลูกอยู่แล้ว

**การตรวจสอบเทียบกับการแก้ไข** อาเรย์ที่ดึงอธิบายโครงร่าง; การเปลี่ยนแปลงอาเรย์เหล่านี้จะไม่อัปเดตรูปร่างเดิม ใช้วิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดต้องการอาเรย์จุด/ประเภท ใช้ [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปร่างหรืออยากแก้ไขเรขาคณิตของมัน ใช้เส้นทางที่แก้ไขผ่าน [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) หรือ [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)

## **แปลง Java AWT Shape ให้เป็น GeometryPath**

ตัวอย่างนี้ผสานโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต วิธี `setFillMode` ของ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) ปิดการเติมโครงร่าง [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) สร้างโครงร่างข้อความใน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) โดย [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) จะส่งส่วน move, line, quadratic, cubic, และ closing ซึ่งตัวอย่างทำซ้ำบน [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)

ข้อความใช้ฟอนต์ Arial ขนาด 40 จุด โครงรอบออฟเซ็ต 20 จุดในแนวนอนและวางตำแหน่งโดยให้ด้านบนของข้อความอยู่ 10 จุดต่ำกว่าขอบบนของรูปร่าง เส้นทางข้อความถูกเติมสี ในขณะที่สี่เหลี่ยมเดิมยังคงเป็นโครงรอบ การนำสองเส้นทางไปใช้ด้วย [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) จะสร้างรูปร่างเดียวที่บรรจุสี่เหลี่ยมและข้อความ

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // สร้างรูปร่างใหม่
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // ดึงเส้นทางเรขาคณิตของรูปร่าง
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // สร้างเส้นทางกราฟิกใหม่ด้วยข้อความ
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // แปลงเส้นทางกราฟิกเป็นเส้นทางเรขาคณิต
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // ตั้งค่าการรวมของเส้นทางเรขาคณิตใหม่และเส้นทางเรขาคณิตต้นฉบับให้กับรูปร่าง
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **คำถามที่พบบ่อย**

**จะเกิดอะไรขึ้นกับการเติมและโครงรอบหลังจากแทนที่เรขาคณิต?**

สไตล์จะยังคงอยู่กับรูปร่าง; เพียงแค่เส้นรอบรูปเปลี่ยนไป การเติมและโครงรอบจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตได้อย่างถูกต้องอย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) ของรูปร่าง; เรขาคณิตจะหมุนตามรูปร่างเนื่องจากถูกผูกไว้กับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ “ล็อค” ผลลัพธ์ได้ไหม?**

ได้. ส่งออก [สไลด์](/slides/th/java/convert-powerpoint-to-png/) ที่ต้องการหรือ [รูปร่าง](/slides/th/java/create-shape-thumbnails/) เองเป็นรูปแบบเรสเตอร์; วิธีนี้ทำให้การทำงานต่อไปกับเรขาคณิตที่ซับซ้อนง่ายขึ้น