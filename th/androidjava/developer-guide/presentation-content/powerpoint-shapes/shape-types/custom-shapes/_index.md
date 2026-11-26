---
title: ปรับแต่งรูปร่างพรีเซนเทชันบน Android
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
- การพรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างประกอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งรูปร่างการพรีเซนเทชันใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต ซึ่งแสดงวิธีการทำงานกับ [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) และ [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่ ทำการดำเนินการแก้ไขเส้นทางพื้นฐาน เพิ่มหรือลบจุด และนำเรขาคณิตที่อัปเดตกลับไปใช้กับรูปร่าง

นอกจากนี้ยังสาธิตวิธีสร้างรูปร่างแบบกำหนดเองและแบบประกอบ สร้างรูปร่างที่มีมุมโค้ง ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่ และตรวจสอบองค์ประกอบรูปร่างโดยใช้แอเรย์ของจุดใน Android

## **การเปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยม:

* ย้ายมุมเข้าไปหรือออกมานอก
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดทำให้คุณเปลี่ยนโครงร่างของรูปร่างหรือใช้รูปร่างที่มีเป็นฐานสำหรับรูปร่างใหม่

## **เคล็ดลับการแก้ไขรูปร่าง**

![ภาพรวม](custom_shape_0.png)

เมื่อแก้ไขรูปร่างใน PowerPoint ให้คำนึงถึงแนวคิดต่อไปนี้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนเส้น
* ส่วนเส้นสามารถเป็นตรงหรือโค้ง จุดยึดและมือควบคุมกำหนดรูปร่างของส่วนเส้น
* จุดยึดมีอยู่ในรูปแบบจุดมุม จุดตรง หรือจุดเรียบ:
  * ที่จุดมุม ส่วนเส้นที่ต่อกันสามารถมาบรรจบกันเป็นมุม
  * ที่จุดเรียบ มือควบคุมสองตัวจะจัดเรียงเป็นเส้นตรงและห่างจากจุดยึดเท่ากัน
  * ที่จุดตรง มือควบคุมสองตัวจะจัดเรียงเป็นเส้นตรงแต่ระยะห่างจากจุดยึดอาจต่างกัน
* การย้ายจุดยึดหรือปรับมือควบคุมจะเปลี่ยนโครงร่างของรูปร่าง

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) และอินเตอร์เฟซ [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/)

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) แสดงเส้นทางเรขาคณิตของอ็อบเจ็กต์ [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) จากอินสแตนซ์ของ [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) ให้ใช้เมธอด [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) ให้กับรูปร่าง ให้ใช้เมธอดเหล่านี้: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) สำหรับรูปร่างที่มีเส้นทางเดียว และ [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มส่วนเส้น ให้ใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/)
* ด้วยเมธอด [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) และ [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิตได้
* ด้วยเมธอด [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) คุณสามารถดึงข้อมูลเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) เป็นอาร์เรย์ของส่วนเส้นได้

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การโอเวอร์โหลดที่รับดัชนีจะใส่ส่วนเส้นที่ตำแหน่งนั้นในอาร์เรย์ส่วนเส้นของเส้นทาง

| การดำเนินการ | วิธีการ |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| เพิ่มหรือแทรกเส้นโค้งเบเซเยอร์ลูกบาศก์พร้อมจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| เพิ่มหรือแทรกเส้นโค้งเบเซเยอร์กำลังสองพร้อมจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| เพิ่มส่วนโค้งวงรีที่มีขนาดและมุมตามระดับองศาที่กำหนด | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| ปิดรูปภาพปัจจุบันโดยเชื่อมจุดสุดท้ายกับจุดเริ่มต้น | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| กำหนดจุดเริ่มต้นของรูปภาพ | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| ลบส่วนเส้นที่ตำแหน่งดัชนีศูนย์ | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**

ตัวอย่างนี้แทรกสองจุดลงในรูปร่างสี่เหลี่ยมโดยใช้ [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) และนำเส้นทางที่แก้ไขไปใช้กับ [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) พิกัดเป็นค่าท้องถิ่นของรูปร่าง: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลางของรูปร่าง, 100 จุดจากด้านซ้ายและ 50 จุดจากด้านบน ดัชนีส่วนเส้น 1 และ 4 จะวางจุดบนขอบบนและขอบล่าง ดึงขอบเหล่านั้นเข้ามา

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

![ตัวอย่าง1](custom_shape_1.png)

## **ลบจุดจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยลบส่วนเส้นที่ตำแหน่งดัชนีศูนย์ 2 ด้วย [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) การใช้เส้นทางที่แก้ไขกับ [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) จะอัปเดตคอนทัวร์ของรูปร่าง

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
![ตัวอย่าง2](custom_shape_2.png)

## **สร้างรูปร่างกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) รัศมีนอกและในสลับกันที่ 100 และ 50 จุดกำหนดจุดยอดและช่องลึก; การก้าว 72 องศาจะเว้นระยะห่างระหว่างห้าจุดอย่างสม่ำเสมอ เส้นทางถูกปิดด้วย [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) และนำไปใช้กับรูปร่างสี่เหลี่ยมด้วย [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) แทนที่โครงร่างเดิม

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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
![ตัวอย่าง3](custom_shape_3.png)

## **สร้างรูปร่างประกอบกำหนดเอง**

ตัวอย่างนี้นิยามสองอ็อบเจ็กต์ [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) ปิดสำหรับส่วนบนและส่วนล่างของรูปร่าง การใช้ทั้งสองเส้นทางพร้อมกันด้วย [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) จะสร้างรูปร่างประกอบเดี่ยวที่มีช่องว่างตรงกลางหนึ่งในสาม

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
![ตัวอย่าง4](custom_shape_4.png)

## **สร้างรูปร่างกำหนดเองพร้อมมุมโค้ง**

ตัวอย่างนี้ผสานส่วนเส้นตรงกับ [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) เพื่อสร้างรูปร่างที่มุมโค้งเข้าแต่ละมุม กำหนดขนาดมุมจะกำหนดความกว้างและความสูงของโค้งในหน่วยจุด และการสเวป -90 องศาจะวาดสี่เหลี่ยมวงรีควอเตอร์โดยทวนเข็มนาฬิกา เส้นทางที่สมบูรณ์จะถูกนำไปใช้ด้วย [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) และพรีเซนเทชันจะบันทึกเป็นรูปแบบ PPTX

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่าสิ้นสุดด้วยส่วนเส้นปิดหรือไม่ มันอ่าน [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) และเปรียบเทียบคำสั่งของส่วนเส้นสุดท้ายจาก [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) กับ [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) จะคืนค่า false เมื่อไม่มีเส้นทางที่ไม่ว่าง ตัวตรวจสอบนี้พิจารณาคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบแต่ละซับฟิกเกอร์ภายในเส้นทาง ตัวอย่างแสดงค่า `true` สำหรับสี่เหลี่ยม

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

## **ตรวจสอบคำสั่งเส้นทางเรขาคณิต**

ดาวน์โหลด [contour.pptx](contour.pptx) และแทนที่ชื่อไฟล์ตัวอย่างด้วยพาธบนอุปกรณ์ รูปร่างแรกบนสไลด์แรกมีขอบด้านบนเป็นเส้นตรง, เส้นโค้งเบเซเยอร์ลูกบาศก์, และขอบปิดแบบเส้นตรง ใช้ [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) เพื่ออ่านเส้นทางของรูปร่างและ [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) เพื่ออ่านส่วนเส้นของแต่ละเส้นทางตามลำดับการวาด สำหรับแต่ละส่วนเส้น, [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) ระบุคำสั่งและกำหนดวิธีตีความค่าที่คืนจาก [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--)

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

รูปร่างตั้งอยู่ที่จุด (200, 100) บนสไลด์ พิกัดที่รายงานเป็นค่าท้องถิ่นของรูปร่าง โดย (0, 0) อยู่ที่มุมบนซ้าย, x เพิ่มไปทางขวา, y เพิ่มลงล่าง ส่วนเส้นปิดจะกลับไปยังจุดเริ่มต้นโดยไม่มีพิกัดเพิ่มเติม

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![รูปร่าง PowerPoint ที่มีขอบด้านบนเป็นเส้นตรง, ขอบโค้งจากมุมบนขวาไปยังมุมล่างซ้าย, และขอบด้านซ้ายเป็นเส้นตรง](contour.png)

## **ดึงและตรวจสอบองค์ประกอบของรูปร่าง**

ใช้ [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) เพื่อสำรวจรูปร่างที่มีอยู่เป็นองค์ประกอบที่บรรจุจุดเส้นทางและประเภทจุด แคสท์แต่ละ [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) ที่คืนค่าเป็น [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) เพื่อดึงอาร์เรย์จุดและอาร์เรย์ประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) และ [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) การแสดงผลนี้เป็นประโยชน์สำหรับการวิเคราะห์คอนทัวร์หรือส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง

ตัวอย่างเปิดไฟล์ input.pptx, ค้นหารูปร่างเรขาคณิตแรกบนสไลด์แรก, และพิมพ์ส่วนเส้นของมัน ใช้พรีเซนเทชันที่มีรูปร่างที่มีส่วนเส้นตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท ตัวอย่างนี้ไม่ทำการค้นหาภายในกลุ่ม

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // เก็บประเภทของส่วนเส้นไว้โดยไม่รวมแฟล็ก.
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

อาร์เรย์สอดคล้องกันตามดัชนี: `points[i]` คือจุดและ `types[i]` บรรยายบทบาทของจุดนั้น ประเภท `0` เริ่มฟิกเกอร์, ประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน ส่วนเส้นเบเซเยอร์ลูกบาศก์เริ่มที่จุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` สามรายการต่อเนื่อง: จุดควบคุมสองจุดและจุดสิ้นสุดใหม่ ลูปจะประมวลผลสามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดเพื่อดูว่าปิดหรือไม่

ประเภทจุดยังมีแฟล็กด้วย ให้ทำหน้ากากด้วย `0x07` เพื่อระบุประเภทส่วนเส้นและทดสอบ `0x80` แยกต่างหากเพื่อตรวจจับซับพาธที่ปิด ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดสิ้นสุดของเส้นที่ปิดซับพาธ, `131` (`0x83`) หมายถึงจุดสิ้นสุดของเบเซเยอร์ที่ปิดหนึ่งซับพาธ Java เก็บแฟล็กเหล่านี้ในไบต์แบบ signed; การทำหน้ากากจะรักษาค่าบิตตามที่ตั้งใจ การเปรียบเทียบค่าดิบเพียง `1` หรือ `3` จะพลาดกรณีเหล่านี้ แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทส่วนเส้นพื้นฐาน

**พิกัดและการแปลง** จุดวัดเป็นหน่วย points (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงล่าง สำหรับรูปร่างที่ไม่ได้อยู่ในกลุ่ม พิกัดที่สกัดแล้วจะรวมตำแหน่งที่คืนจาก [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) และ [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) รวมถึงความกว้างและความสูงปัจจุบันของรูปร่าง ตัวอย่างเช่น สี่เหลี่ยมที่ไม่ได้หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` จะมีขอบคอนทัวร์ `(100, 200)`–`(220, 280)` อย่าเพิ่มตำแหน่งของรูปร่างอีกครั้ง ให้ลบ X และ Y ของมันเพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่หมุน

จุดที่สกัดจะไม่รวมการหมุนของรูปร่างที่คืนจาก [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) หรือการพลิกแนวนอนและแนวตั้ง เพื่อจำลองคอนทัวร์ที่แสดงบนหน้าจอ ให้ทำการแปลงเหล่านี้รอบศูนย์กลางของรูปร่าง สำหรับรูปร่างในกลุ่ม ยังต้องคำนึงถึงการแมพพิกัดของกลุ่มและการแปลง; อย่าสมมติว่าจุดที่สกัดเป็นพิกัดสุดท้ายบนสไลด์หรือทำการแปลหรือสเกลซ้ำหากมันได้ถูกนำเข้ามาในกรอบลูกแล้ว

**การตรวจสอบเทียบกับการแก้ไข** อาร์เรย์ที่สกัดอธิบายคอนทัวร์; การเปลี่ยนแปลงอาร์เรย์เหล่านี้จะไม่อัปเดตรูปร่างต้นฉบับ เลือกวิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาร์เรย์จุด/ประเภท ใช้ [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปร่างหรืออยากแก้ไขเรขาคณิตของมัน ใช้เส้นทางที่แก้ไขผ่าน [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) หรือ [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)

## **FAQ**

**การเติมสีและโครงร่างจะเป็นอย่างไรหลังจากเปลี่ยนเรขาคณิต?**

สไตล์ยังคงอยู่กับรูปร่าง; เพียงคอนทัวร์เปลี่ยนไป สีและโครงร่างจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่

**วิธีหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องคืออะไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) ของรูปร่าง; เรขาคณิตจะหมุนพร้อมกับรูปร่างเนื่องจากผูกกับระบบพิกัดของรูปร่างเอง

**สามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ “ล็อก” ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออก [สไลด์](/slides/th/androidjava/convert-powerpoint-to-png/) ที่ต้องการหรือ [รูปร่าง](/slides/th/androidjava/create-shape-thumbnails/) เองเป็นรูปแบบราสเตอร์; วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น