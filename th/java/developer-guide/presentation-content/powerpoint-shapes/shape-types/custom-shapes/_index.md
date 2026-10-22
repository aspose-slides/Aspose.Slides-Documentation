---
title: ปรับแต่งรูปร่างการนำเสนอใน Java
linktitle: รูปร่างแบบกำหนดเอง
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
description: "สร้างและปรับแต่งรูปร่างในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างคอมโพสิต."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการกำหนดรูปร่างการนำเสนอใน Aspose.Slides โดยการแก้ไขรูปทรงเรขาคณิตผ่านจุดแก้ไขและเส้นทางเรขาคณิต แสดงวิธีทำงานกับ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) และ [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่, ทำการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปใช้กับรูปร่าง

นอกจากนี้ยังสาธิตวิธีสร้างรูปร่างแบบกำหนดเองและคอมโพสิต, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่, ตรวจสอบองค์ประกอบของรูปร่าง, และแปลงเค้าโครงข้อความของ Java AWT ให้เป็นเส้นทางเรขาคณิต

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยม:

* ย้ายมุมเข้าไปหรือออกไป
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดช่วยให้คุณเปลี่ยนโครงร่างของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นพื้นฐานสำหรับรูปร่างใหม่

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปร่างใน PowerPoint ให้คำนึงถึงแนวคิดต่อไปนี้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนต่าง ๆ
* ส่วนอาจเป็นเส้นตรงหรือโค้ง จุดยึดและตัวควบคุมกำหนดรูปทรงของมัน
* จุดยึดมีอยู่ในรูปแบบจุดมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม, ส่วนที่เชื่อมต่ออาจมุมกันได้
  * ที่จุดเรียบ, ตัวควบคุมสองตัวจะจัดเรียงตรงกันและห่างจากจุดยึดเท่า ๆ กัน
  * ที่จุดตรง, ตัวควบคุมสองตัวจัดเรียงตรงกันแต่ระยะห่างจากจุดยึดอาจแตกต่างกัน
* การย้ายจุดยึดหรือปรับตัวควบคุมจะเปลี่ยนโครงร่างของรูปร่าง

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) และอินเทอร์เฟซ [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/)

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) แสดงเส้นทางเรขาคณิตของอ็อบเจ็กต์ [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) จากอินสแตนซ์ของ [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), คุณสามารถใช้เมธอด [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) ได้
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ให้กับรูปร่าง, คุณสามารถใช้เมธอดเหล่านี้: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) สำหรับรูปร่างที่มีเส้นทางเดียวและ [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มส่วน, คุณสามารถใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/)
* ด้วยเมธอด [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) และ [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิตได้
* ด้วยเมธอด [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) คุณสามารถดึงข้อมูลเส้นทางของ [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) เป็นอาเรย์ของส่วนเส้นได้
* เพื่อเข้าถึงตัวเลือกการกำหนดค่ารูปทรงเพิ่มเติม, คุณสามารถอ่าน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ผ่าน [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) แล้วทำซ้ำส่วนต่าง ๆ บน [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)

## **การดำเนินการแก้ไขง่าย ๆ**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การอ็อเวอร์โหลดที่รับดัชนีจะใส่ส่วนที่ตำแหน่งศูนย์ฐานในอาเรย์ส่วนของเส้นทาง

| การดำเนินการ | วิธีการ |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบพาราเมทรศน์ที่มีจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบกำลังสองที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| เพิ่มส่วนโค้งรูปวงรีด้วยขนาดและมุมที่กำหนดเป็นองศา | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| ปิดรูปแบบปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| กำหนดจุดเริ่มต้นของรูปแบบ | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| ลบส่วนที่ตำแหน่งศูนย์ฐาน | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**

ตัวอย่างนี้แทรกสองจุดเข้าไปในรูปร่างสี่เหลี่ยมโดยใช้ [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) และนำเส้นทางที่แก้ไขไปใช้ด้วย [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) พิกัดเป็นค่าท้องถิ่นของรูปร่าง: ทั้งสองจุดใหม่อยู่ที่ศูนย์กลาง, ห่าง 100 จุดจากด้านซ้ายและ 50 จุดจากด้านบน ดัชนีส่วน 1 และ 4 ทำให้จุดนั้นอยู่บนขอบบนและล่าง, ดึงขอบเหล่านั้นเข้าด้านใน

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

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยลบส่วนที่ตำแหน่งศูนย์ฐาน 2 ด้วย [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) การนำเส้นทางที่แก้ไขไปใช้ด้วย [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) จะอัปเดตเส้นรอบรูปของรูปร่าง

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

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุดกำหนดหัวและร่องลึก; ขั้นตอน 72 องศาจัดตำแหน่งหัวห้าต่างกันอย่างเท่าเทียม เส้นทางถูกปิดด้วย [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) และนำไปใช้กับรูปร่างสี่เหลี่ยมด้วย [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) แทนที่โครงร่างเดิม

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

## **สร้างรูปร่างคอมโพสิตกำหนดเอง**

ตัวอย่างนี้กำหนดสองอ็อบเจ็กต์ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ปิดสำหรับส่วนบนและล่างของรูปร่าง การนำสองเส้นทางไปใช้ด้วย [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) จะสร้างรูปร่างคอมโพสิตเดียวที่มีช่องว่างตรงส่วนกลาง

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

## **สร้างรูปร่างกำหนดเองด้วยมุมโค้ง**

ตัวอย่างนี้ผสานส่วนตรงกับ [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) เพื่อสร้างรูปร่างที่มุมโค้งเข้าด้านใน แต่ละขนาดมุมกำหนดความกว้างและความสูงของเส้นโค้งเป็นจุด, การสวิง -90 องศาวาดส่วนโค้งรูปวงรีสี่เหลี่ยมมุมหนึ่งตามเข็มนาฬิกา เส้นทางที่สมบูรณ์ถูกนำไปใช้ด้วย [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) และการนำเสนอจะบันทึกในรูปแบบ PPTX

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

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่าจะจบด้วยส่วนปิดหรือไม่ โดยอ่าน [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) แล้วเปรียบเทียบคำสั่งของส่วนสุดท้ายกับ [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) เทียบกับ [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) จะคืนค่า false เมื่อไม่มีเส้นทางที่ไม่ว่างเปล่า การตรวจสอบนี้ดูคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบทุกรูปย่อยภายในเส้นทาง ตัวอย่างพิมพ์ค่า `true` สำหรับสี่เหลี่ยม

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

## **สกัดและตรวจสอบองค์ประกอบของรูปร่าง**

ใช้ [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) เพื่อตรวจสอบรูปร่างที่มีอยู่เป็นองค์ประกอบที่มีจุดเส้นทางและประเภทจุด แคสต์แต่ละ [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) กลับเป็น [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) เพื่อดึงอาเรย์ของจุดและประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) และ [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) การแสดงผลนี้มีประโยชน์สำหรับการวิเคราะห์เค้าโครงหรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง

ตัวอย่างเปิดไฟล์ input.pptx, ค้นหารูปร่างเรขาคณิตแรกบนสไลด์แรก, แล้วพิมพ์ส่วนเส้นทางของมัน ใช้การนำเสนอที่มีรูปร่างที่มีส่วนตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท ไม่ได้ค้นหาภายในกลุ่ม

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
                int pointType = types[i] & 0x07; // เก็บประเภทของส่วนโดยไม่รวมแฟล็ก
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // ใช้จุดควบคุมทั้งสองจุดและจุดสิ้นสุด
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

อาเรย์สอดคล้องกันตามดัชนี: `points[i]` คือจุดและ `types[i]` บรรยายบทบาทของมัน ประเภท `0` เริ่มรูป, ประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน ส่วน Bézier แบบพาราเมทรศน์เริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` ต่อเนื่องสามรายการ: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่ ลูปจะรับสามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดว่าปิดหรือไม่

ประเภทจุดยังมีแฟลกด้วย การทำมาสก์ด้วย `0x07` เพื่อระบุประเภทส่วน, และทดสอบ `0x80` แยกต่างหากเพื่อตรวจจับเส้นทางย่อยที่ปิด ตัวอย่าง `129` (`0x81`) หมายถึงจุดเส้นที่ปิดเส้นทางย่อย, `131` (`0x83`) หมายถึงจุด Bézier ที่ปิดเส้นทางหนึ่ง Java เก็บแฟลกเหล่านี้ในไบต์ที่เป็น signed; การทำมาสก์จะคงค่าบิตตามที่ตั้งใจ การเปรียบเทียบค่าดิบเพียง `1` หรือ `3` จะพลาดกรณีเหล่านี้ แฟลกอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทส่วนพื้นฐาน

**พิกัดและการแปลง** จุดวัดเป็นจุด (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงด้านล่าง สำหรับรูปร่างที่ไม่ได้อยู่ในกลุ่ม, พิกัดที่สกัดออกมารวมตำแหน่งที่ได้จาก [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) และ [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) และสะท้อนความกว้างและความสูงปัจจุบันของมัน ตัวอย่างสี่เหลี่ยมที่ไม่ได้หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบโครงร่าง `(100, 200)`–`(220, 280)` อย่าเพิ่มตำแหน่งของรูปร่างอีกครั้ง ให้นำ X และ Y ของมันออกเพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่ได้หมุน

จุดที่สกัดออกมาไม่ได้รวมการหมุนของรูปร่างที่ได้จาก [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) หรือการพลิกตามแนวนอนและแนวตั้ง เพื่อสร้างโครงร่างที่แสดงอยู่ ต้องนำการแปลงเหล่านั้นมาปรับรอบศูนย์กลางของรูปร่าง สำหรับรูปร่างที่อยู่ในกลุ่ม ยังต้องคำนึงถึงการแมปพิกัดของกลุ่มและการแปลงต่าง ๆ; อย่าสมมติว่าจุดที่สกัดเป็นพิกัดสุดท้ายบนสไลด์ หรือทำการแปลหรือสเกลซ้ำสองครั้งหากมันได้สะท้อนอยู่แล้วในกรอบของลูก

**การตรวจสอบเทียบกับการแก้ไข** อาเรย์ที่สกัดอธิบายโครงร่าง; การเปลี่ยนแปลงมันจะไม่อัปเดตรูปร่างต้นฉบับ ใช้วิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาเรย์จุด/ประเภท ใช้ [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) หากคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปร่างหรืออยากแก้ไขเรขาคณิตของมัน นำเส้นทางที่แก้ไขไปใช้ผ่าน [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) หรือ [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)

## **แปลง Java AWT Shape ไปเป็น GeometryPath**

ตัวอย่างนี้ผสานโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต วิธี `setFillMode` ของ [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) ปิดการเติมสีของโครงร่าง [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) สร้างเค้าโครงข้อความใน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ตัว [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) ส่งส่วนการย้าย, เส้น, กราฟิกกำลังสอง, กราฟิกพาราเมทรศน์และส่วนปิด ซึ่งตัวอย่างทำซ้ำบน [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)

ข้อความใช้ฟอนต์ Arial ขนาด 40 จุด โครงร่างถูกเคลื่อนที่แนวนอน 20 จุดและวางให้ด้านบนของมันอยู่ 10 จุดต่ำกว่าขอบบนของรูปร่าง เส้นทางข้อความถูกเติมสี, ส่วนสี่เหลี่ยมดั้งเดิมยังคงเป็นโครงร่าง การนำสองเส้นทางไปใช้ด้วย [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) จะสร้างรูปร่างเดียวที่รวมสี่เหลี่ยมและข้อความ

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

    // สร้างเส้นทางกราฟิกใหม่พร้อมข้อความ
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

    // ตั้งค่าการผสมของเส้นทางเรขาคณิตใหม่และเส้นทางเรขาคณิตเดิมให้กับรูปร่าง
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **คำถามที่พบบ่อย**

**การเติมสีและโครงร่างจะเป็นอย่างไรหลังจากเปลี่ยนเรขาคณิต?**

สไตล์ยังคงอยู่กับรูปร่าง; เพียงคอนทัวร์ที่เปลี่ยน แรงเติมสีและโครงร่างจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตได้อย่างถูกต้องอย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) ของรูปร่าง; เรขาคณิตจะหมุนตามรูปร่างเนื่องจากถูกผูกกับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ “ล็อก” ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออก [สไลด์](/slides/th/java/convert-powerpoint-to-png/) ที่ต้องการหรือ [รูปร่าง](/slides/th/java/create-shape-thumbnails/) เองเป็นรูปแบบแรสเตอร์; วิธีนี้ทำให้การทำงานต่อไปกับเรขาคณิตที่ซับซ้อนง่ายขึ้น