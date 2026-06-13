---
title: ปรับแต่งรูปร่างการนำเสนอใน JavaScript
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/nodejs-java/custom-shape/
keywords:
- รูปร่างกำหนดเอง
- เพิ่มรูปร่าง
- สร้างรูปร่าง
- เปลี่ยนรูปร่าง
- เรขาคณิตรูปร่าง
- เส้นทางเรขาคณิต
- จุดบนเส้นทาง
- จุดแก้ไข
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างแบบรวม."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งรูปร่างการนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไข (edit points) และเส้นทางเรขาคณิต (geometry paths) แสดงวิธีทำงานกับ `GeometryPath` เพื่อแก้ไขรูปร่างที่มีอยู่ ทำการแก้ไขเส้นทางพื้นฐาน เพิ่มหรือเอาจุดออก และนำเรขาคณิตที่อัปเดตกลับไปใช้กับรูปร่าง

นอกจากนี้ยังสาธิตวิธีสร้างรูปร่างแบบกำหนดเองและแบบรวมกัน สร้างรูปร่างที่มุมโค้ง ตรวจสอบว่ารูปร่างเป็นแบบปิดหรือไม่ และแปลงระหว่าง `GeometryPath` กับ `java.awt.Shape` สำหรับกรณีการปรับแต่งเรขาคณิตเพิ่มเติม

## **เปลี่ยนรูปร่างด้วยจุดแก้ไข**

ให้พิจารณาสี่เหลี่ยมจัตุรัส ใน PowerPoint หากใช้ **edit points** คุณสามารถ  

* ย้ายมุมของสี่เหลี่ยมเข้าออก  
* กำหนดความโค้งของมุมหรือจุด  
* เพิ่มจุดใหม่ลงในสี่เหลี่ยม  
* จัดการกับจุดบนสี่เหลี่ยม ฯลฯ  

โดยพื้นฐานแล้ว คุณสามารถทำสิ่งเหล่านี้กับรูปร่างใดก็ได้ การใช้จุดแก้ไขทำให้คุณสามารถเปลี่ยนรูปร่างหรือสร้างรูปร่างใหม่จากรูปร่างที่มีอยู่ได้

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

ก่อนที่คุณจะเริ่มแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข ควรพิจารณาประเด็นต่อไปนี้เกี่ยวกับรูปร่าง  

* รูปร่าง (หรือเส้นทางของมัน) อาจเป็นแบบปิดหรือเปิด  
* เมื่อรูปร่างเป็นแบบปิด จะไม่มีจุดเริ่มต้นหรือจุดสิ้นสุด เมื่อเป็นแบบเปิด จะมีจุดเริ่มต้นและจุดสิ้นสุด  
* รูปร่างทั้งหมดประกอบด้วยจุดยึด (anchor point) อย่างน้อย 2 จุดที่เชื่อมต่อกันด้วยเส้น  
* เส้นอาจเป็นเส้นตรงหรือเส้นโค้ง จุดยึดกำหนดลักษณะของเส้น  
* จุดยึดมีอยู่ในรูปแบบมุม (corner point) จุดตรง (straight point) หรือจุดเรียบ (smooth point)  

  * มุม (corner point) คือจุดที่เส้นตรงสองเส้นมาบรรจบกันเป็นมุม  
  * จุดเรียบ (smooth point) คือจุดที่มีมือ (handle) สองอันอยู่บนเส้นตรงเดียวกันและส่วนของเส้นเชื่อมต่อกันเป็นโค้งเรียบ ในกรณีนี้ มือทั้งหมดจะอยู่ห่างจากจุดยึดเท่ากัน  
  * จุดตรง (straight point) คือจุดที่มีมือสองอันอยู่บนเส้นตรงเดียวกันและส่วนของเส้นเชื่อมต่อกันเป็นโค้งเรียบ ในกรณีนี้ มือไม่จำเป็นต้องอยู่ห่างจากจุดยึดเท่ากัน  

* การย้ายหรือแก้ไขจุดยึด (ซึ่งเปลี่ยนมุมของเส้น) สามารถเปลี่ยนลักษณะของรูปร่างได้  

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข **Aspose.Slides** ให้บริการคลาส [**GeometryPath**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath) และคลาส [**GeometryPath**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath)

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath) แทนเส้นทางเรขาคณิตของอ็อบเจ็กต์ [GeometryShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape)  
* เพื่อดึง `GeometryPath` จากอินสแตนซ์ `GeometryShape` ให้ใช้เมธอด [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--)  
* เพื่อกำหนด `GeometryPath` ให้กับรูปร่าง ให้ใช้เมธอดต่อไปนี้: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) สำหรับ *รูปร่างแบบทึบ* และ [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) สำหรับ *รูปร่างแบบรวม*  
* เพื่อเพิ่มส่วนเส้น ให้ใช้เมธอดใน [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath)  
* ใช้เมธอด [GeometryPath.setStroke](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) และ [GeometryPath.setFillMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) เพื่อกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต  
* ด้วยเมธอด [GeometryPath.getPathData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath#getPathData--) คุณสามารถดึงข้อมูลเส้นทางของ `GeometryShape` เป็นอาเรย์ของส่วนเส้นได้  
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตของรูปร่างเพิ่มเติม คุณสามารถแปลง [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath) เป็น [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)  
* ใช้เมธอด [geometryPathToGraphicsPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) และ [graphicsPathToGeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (จากคลาส [ShapeUtil](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeUtil)) เพื่อแปลง [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath) ไป-กลับกับ [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)

## **การทำงานแก้ไขอย่างง่าย**

โค้ด JavaScript นี้แสดงวิธี  

**เพิ่มเส้น** ที่ท้ายเส้นทาง  

```javascript
lineTo(point);
lineTo(x, y);
```  
**เพิ่มเส้น** ที่ตำแหน่งระบุบนเส้นทาง:  

```javascript
lineTo(point, index);
lineTo(x, y, index);
```  
**เพิ่มเส้นโค้งคืบเบียร์แบบพาราเมตริก** ที่ท้ายเส้นทาง:  

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```  
**เพิ่มเส้นโค้งคืบเบียร์แบบพาราเมตริก** ที่ตำแหน่งระบุบนเส้นทาง:  

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```  
**เพิ่มเส้นโค้งควอดราติก** ที่ท้ายเส้นทาง:  

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```  
**เพิ่มเส้นโค้งควอดราติก** ที่ตำแหน่งระบุบนเส้นทาง:  

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```  
**ต่อส่วนโค้ง (arc)** ให้กับเส้นทาง:  

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```  
**ปิดรูปทรงปัจจุบัน** ของเส้นทาง:  

```javascript
closeFigure();
```  
**กำหนดตำแหน่งของจุดต่อไป**:  

```javascript
moveTo(point);
moveTo(x, y);
```  
**ลบส่วนเส้น** ที่ดัชนีระบุ:  

```javascript
removeAt(index);
```

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**
1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape) และกำหนดประเภทเป็น [ShapeType.Rectangle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeType)  
2. รับอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath) จากรูปร่าง  
3. เพิ่มจุดใหม่ระหว่างจุดบนสุดสองจุดบนเส้นทาง  
4. เพิ่มจุดใหม่ระหว่างจุดล่างสุดสองจุดบนเส้นทาง  
5. นำเส้นทางไปใช้กับรูปร่าง  

โค้ด JavaScript นี้แสดงวิธีเพิ่มจุดกำหนดเองให้กับรูปร่าง:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```  
![example1_image](custom_shape_1.png)

## **ลบจุดจากรูปร่าง**

1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape) และกำหนดประเภทเป็น [ShapeType.Heart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeType)  
2. รับอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath) จากรูปร่าง  
3. ลบส่วนเส้นของเส้นทาง  
4. นำเส้นทางไปใช้กับรูปร่าง  

โค้ด JavaScript นี้แสดงวิธีลบจุดจากรูปร่าง:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```  
![example2_image](custom_shape_2.png)

## **สร้างรูปร่างกำหนดเอง**

1. คำนวณจุดสำหรับรูปร่าง  
2. สร้างอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath)  
3. เติมเส้นทางด้วยจุดที่คำนวณได้  
4. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape)  
5. นำเส้นทางไปใช้กับรูปร่าง  

โค้ด JavaScript นี้แสดงวิธีสร้างรูปร่างกำหนดเอง:  

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```  
![example3_image](custom_shape_3.png)


## **สร้างรูปร่างกำหนดเองแบบรวม**

  1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape)  
  2. สร้างอินสแตนซ์แรกของคลาส [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath)  
  3. สร้างอินสแตนซ์ที่สองของคลาส [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath)  
  4. นำเส้นทางเหล่านั้นไปใช้กับรูปร่าง  

โค้ด JavaScript นี้แสดงวิธีสร้างรูปร่างกำหนดเองแบบรวม:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```  
![example4_image](custom_shape_4.png)

## **สร้างรูปร่างกำหนดเองที่มุมโค้ง**

โค้ด JavaScript นี้แสดงวิธีสร้างรูปร่างกำหนดเองที่มุมโค้ง (โค้งเข้าด้านใน)  

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
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
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตรวจสอบว่ารูปร่างเป็นแบบปิดหรือไม่**

รูปร่างแบบปิดหมายถึงรูปที่ทุกด้านเชื่อมต่อกันเป็นเส้นขอบเดียวโดยไม่มีช่องว่าง รูปร่างนี้อาจเป็นรูปทรงเรขาคณิตพื้นฐานหรือโครงร่างกำหนดเองที่ซับซ้อน ตัวอย่างโค้ดต่อไปนี้แสดงการตรวจสอบว่ารูปร่างเป็นแบบปิดหรือไม่  

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **แปลง GeometryPath ไปเป็น java.awt.Shape**

1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryShape)  
2. สร้างอินสแตนซ์ของคลาส [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)  
3. ใช้ [ShapeUtil](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeUtil) แปลงอินสแตนซ์ [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ไปเป็นอินสแตนซ์ [GeometryPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GeometryPath)  
4. นำเส้นทางไปใช้กับรูปร่าง  

โค้ด JavaScript — การนำขั้นตอนข้างต้นไปใช้งาน — แสดงกระบวนการแปลง **GeometryPath** เป็น **GraphicsPath**  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // สร้างรูปร่างใหม่
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // รับเส้นทางเรขาคณิตของรูปร่าง
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // สร้างเส้นทางกราฟิกใหม่พร้อมข้อความ
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // แปลงเส้นทางกราฟิกเป็นเส้นทางเรขาคณิต
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // ตั้งค่าการรวมของเส้นทางเรขาคณิตใหม่และเส้นทางเรขาคณิตเดิมให้กับรูปร่าง
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```  
![example5_image](custom_shape_5.png)

## **คำถามที่พบบ่อย**

**การแทนที่เรขาคณิตจะส่งผลต่อการเติมสีและโครงร่างอย่างไร?**

สไตล์จะยังคงอยู่กับรูปร่าง เพียงแค่เส้นขอบเปลี่ยนไป การเติมสีและโครงร่างจะถูกนำไปใช้กับเรขาคณิตใหม่โดยอัตโนมัติ  

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/setrotation/) ของรูปร่าง เรขาคณิตจะหมุนพร้อมกับรูปร่างเนื่องจากถูกผูกกับระบบพิกัดของรูปร่างเอง  

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ “ล็อก” ผลลัพธ์ได้หรือไม่?**

ได้ — ให้ส่งออก [สไลด์](/slides/th/nodejs-java/convert-powerpoint-to-png/) หรือ [รูปร่าง](/slides/th/nodejs-java/create-shape-thumbnails/) ที่ต้องการเป็นรูปแบบแรสเตอร์ วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น