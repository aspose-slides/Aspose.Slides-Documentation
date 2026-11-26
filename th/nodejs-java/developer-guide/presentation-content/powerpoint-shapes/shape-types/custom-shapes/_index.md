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
- เรขาคณิตของรูปร่าง
- เส้นทางเรขาคณิต
- จุดในเส้นทาง
- แก้ไขจุด
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างคอมโพสิต."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งรูปร่างการนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต แสดงวิธีใช้ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่, ทำการดำเนินการแก้ไขพื้นฐานของเส้นทาง, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปร่าง

นอกจากนี้ยังสาธิตวิธีสร้างรูปร่างกำหนดเองและแบบคอมโพสิต, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่, ตรวจสอบองค์ประกอบของรูปร่าง, และแปลงเค้าโครงข้อความ Java AWT เป็นเส้นทางเรขาคณิต

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยม:

* ย้ายมุมเข้าไปหรือออกไป
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดช่วยให้คุณปรับแก้โครงร่างของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นฐานสำหรับรูปร่างใหม่

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปร่างใน PowerPoint ควรคำนึงถึงแนวคิดต่อไปนี้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึด (anchor points) ที่เชื่อมต่อด้วยส่วน (segments)
* ส่วนสามารถเป็นเส้นตรงหรือโค้งได้ จุดยึดและจุดควบคุมกำหนดรูปร่างของมัน
* จุดยึดมีรูปแบบเป็นจุดมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม, ส่วนที่เชื่อมต่ออาจมาพบกันเป็นมุม
  * ที่จุดเรียบ, ตัวควบคุมสองตัวเรียงแนวเดียวกันและห่างจากจุดยึดเท่ากัน
  * ที่จุดตรง, ตัวควบคุมสองตัวเรียงแนวเดียวกันแต่ระยะห่างจากจุดยึดอาจต่างกัน
* การย้ายจุดยึดหรือการปรับตัวควบคุมจะเปลี่ยนโครงร่างของรูปร่าง

เพื่อแก้ไขรูปร่างใน PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)

* ตัวอย่างของ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) แสดงถึงเส้นทางเรขาคณิตของอ็อบเจกต์ [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), คุณสามารถใช้เมธอด [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths)
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ให้กับรูปร่าง, คุณสามารถใช้เมธอดเหล่านี้: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) สำหรับรูปร่างที่มีเส้นทางเดี่ยว และ [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มส่วน, คุณสามารถใช้เมธอดภายใต้ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)
* ด้วยเมธอด [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) และ [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิตได้
* ด้วยเมธอด [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) คุณสามารถดึงข้อมูลเส้นทางของ [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) เป็นอาร์เรย์ของส่วนเส้นทาง
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตเพิ่มเติม, คุณสามารถอ่าน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ผ่าน [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) แล้วนำส่วนกลับมาวาดบน [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)

## **การดำเนินการแก้ไขง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต  การโอเวอร์โหลดที่รับดัชนีจะทำการแทรกส่วนที่ตำแหน่งนั้นในอาร์เรย์ส่วนของเส้นทาง

| การดำเนินการ | วิธี |
| --- | --- |
| แทรกหรือเพิ่มเส้นตรง | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| แทรกหรือเพิ่มเส้นโค้ง Bézier แบบคิวบิกที่มีจุดควบคุมสองจุดและจุดสุดท้าย | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| แทรกหรือเพิ่มเส้นโค้ง Bézier แบบควอดราติกที่มีจุดควบคุมหนึ่งจุดและจุดสุดท้าย | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| แทรกส่วนโค้งวงรีโดยระบุขนาดและมุมเป็นองศา | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| ปิดรูปปัจจุบันโดยเชื่อมจุดสุดท้ายกับจุดเริ่มต้น | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| กำหนดจุดเริ่มต้นของรูป | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| ลบส่วนที่ตำแหน่งดัชนีศูนย์ | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **เพิ่มจุดกำหนดเองไปยังรูปร่าง**

ตัวอย่างนี้แทรกสองจุดลงในรูปร่างสี่เหลี่ยมโดยใช้ [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) และนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) พิกัดเป็นพิกัดท้องถิ่นของรูปร่าง: ทั้งสองจุดใหม่อยู่ที่ศูนย์กลางของรูปร่าง, ห่างจากด้านซ้าย 100 จุดและจากด้านบน 50 จุด ดัชนีส่วน 1 และ 4 จะวางจุดบนขอบบนและขอบล่าง, ดึงขอบเหล่านั้นเข้าหา

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **ลบจุดออกจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยลบส่วนที่ตำแหน่งดัชนีศูนย์ 2 ด้วย [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) การนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) จะอัปเดตขอบของรูปร่าง

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **สร้างรูปร่างกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุดกำหนดหัวและส่วนตัน; ขั้นตอน 72 องศาจะเว้นระยะห่างระหว่างหัวทั้งห้าอย่างเท่า ๆ กัน เส้นทางถูกปิดด้วย [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) และนำไปใช้กับรูปร่างสี่เหลี่ยมโดยใช้ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) แทนที่โครงร่างเดิม

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **สร้างรูปร่างกำหนดเองแบบรวม**

ตัวอย่างนี้กำหนดสองอ็อบเจกต์ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ที่ปิดเป็นรูปส่วนบนและส่วนล่างของรูปร่าง การนำสองเส้นทางไปใช้พร้อมกันด้วย [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างคอมโพสิตหนึ่งรูปที่มีช่องว่างตรงส่วนที่สามของรูปร่าง

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **สร้างรูปร่างกำหนดเองที่มีมุมโค้ง**

ตัวอย่างนี้ผสมส่วนตรงกับ [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) เพื่อสร้างรูปร่างที่มุมโค้งเข้าแต่ละมุม ขนาดมุมแต่ละอันจะตั้งความกว้างและความสูงของส่วนโค้งเป็นหน่วยจุด, และการสวิง -90 องศาจะวาดส่วนโค้งวงรีสี่เหลี่ยมในทิศทางทวนเข็มนาฬิกา เส้นทางที่เสร็จสมบูรณ์นำไปใช้ด้วย [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) และบันทึกการนำเสนอเป็นรูปแบบ PPTX

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นปิดหรือไม่**

ฮีลเปอร์ด้านล่างนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างสิ้นสุดด้วยส่วนปิดหรือไม่ มันอ่าน [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) แล้วเปรียบเทียบคำสั่งของส่วนสุดท้ายผ่าน [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) กับ [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) จะคืนค่า false เมื่อไม่มีเส้นทางที่ไม่ว่าง สิ่งนี้ตรวจสอบคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบทุกส่วนย่อยภายในเส้นทาง ตัวอย่างพิมพ์ `true` สำหรับสี่เหลี่ยม

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบคำสั่งเส้นทางเรขาคณิต**

ดาวน์โหลด [contour.pptx](contour.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน รูปร่างแรกบนสไลด์แรกมีขอบบนเป็นเส้นตรง, มีเส้นโค้ง Bézier แบบคิวบิก, และขอบปิดเป็นเส้นตรง ใช้ [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) เพื่ออ่านเส้นทางของรูปร่างและ [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) เพื่ออ่านส่วนของแต่ละเส้นทางตามลำดับการวาด สำหรับแต่ละส่วน, [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) จะบ่งชี้คำสั่งและกำหนดวิธีตีความค่าที่ส่งกลับมาจาก [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData)

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

รูปร่างตั้งอยู่ที่จุด (200, 100) บนสไลด์ พิกัดที่รายงานเป็นพิกัดท้องถิ่นของรูปร่าง, โดย (0, 0) อยู่ที่มุมซ้ายบน, x เพิ่มไปทางขวา, y เพิ่มลงด้านล่าง ส่วนปิดจะกลับไปยังจุดเริ่มต้นโดยไม่มีพิกัดเพิ่มเติม

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![รูปร่าง PowerPoint ที่มีขอบบนเป็นเส้นตรง, ขอบโค้งจากมุมบนขวาไปยังมุมล่างซ้าย, และขอบซ้ายเป็นเส้นตรง](contour.png)

## **สกัดและตรวจสอบส่วนประกอบของรูปร่าง**

ใช้ [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) เพื่อสกัดรูปร่างที่มีอยู่เป็นองค์ประกอบที่บรรจุจุดเส้นทางและประเภทของจุด ใช้แต่ละ [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) ที่ส่งกลับเพื่อดึงอาร์เรย์จุดและประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) และ [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) การแสดงผลแบบนี้มีประโยชน์สำหรับการวิเคราะห์โครงร่างหรือการส่งข้อมูลเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง

ตัวอย่างเปิด input.pptx, ค้นหารูปร่างเรขาคณิตแรกโดยตรงบนสไลด์แรก, และพิมพ์ส่วนของเส้นทาง ใช้การนำเสนอที่มีรูปร่างที่มีส่วนเส้นตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท ไม่ได้ค้นหาภายในกลุ่ม

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // เก็บประเภทส่วนโดยไม่รวมแฟล็ก.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // ใช้จุดควบคุมทั้งสองจุดและจุดสิ้นสุด.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

อาร์เรย์สอดคล้องกันตามดัชนี: `points[i]` เป็นจุด และ `types[i]` บอกบทบาทของจุดนั้น ประเภท `0` เริ่มรูป, ประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน ส่วนคิวบิก Bézier เริ่มที่จุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` ติดต่อกันสามรายการ: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่ ลูปจะอ่านสามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดเพื่อดูว่าปิดหรือไม่

ประเภทจุดยังมีแฟล็กด้วย การทำมาสก์ด้วย `0x07` เพื่อระบุประเภทส่วน, และตรวจสอบ `0x80` แยกต่างหากเพื่อค้นหาช่วงปิด ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดสิ้นสุดเส้นที่ปิดช่วงย่อย, และ `131` (`0x83`) หมายถึงจุดสิ้นสุด Bézier ที่ปิดช่วงเดียวกัน Java เก็บแฟล็กเหล่านี้ในไบต์แบบ signed; การทำมาสก์จะรักษาค่าบิตตามที่ตั้งใจ การเปรียบเทียบค่า raw เพียงกับ `1` หรือ `3` จะพลาดกรณีเหล่านี้ แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทส่วนพื้นฐาน

**พิกัดและการแปลง** จุดวัดเป็นหน่วยจุด (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงด้านล่าง สำหรับรูปร่างที่ไม่ได้เป็นกลุ่ม, พิกัดที่สกัดออกมาจะรวมตำแหน่งที่ได้จาก [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) และ [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) รวมถึงความกว้างและความสูงปัจจุบัน ตัวอย่างเช่น สี่เหลี่ยมที่ไม่หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` จะมีขอบโครงร่างเป็น `(100, 200)`–`(220, 280)` อย่าเพิ่มตำแหน่งของรูปร่างอีกครั้ง ให้ลบ X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่ได้หมุน

จุดที่สกัดไม่ได้ใช้การหมุนของรูปร่างที่ได้จาก [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) หรือการพลิกแนวนอนและแนวตั้ง เพื่อสร้างโครงร่างที่แสดงอย่างถูกต้อง ให้นำการแปลงเหล่านั้นมาปรับรอบศูนย์กลางของรูปร่าง สำหรับรูปร่างที่เป็นกลุ่ม, ต้องคำนึงถึงการแมปพิกัดของกลุ่มและการแปลง; อย่า Assume ว่าจุดที่สกัดเป็นพิกัดสุดท้ายบนสไลด์หรือทำการแปลหรือสเกลซ้ำหากมันได้สะท้อนอยู่แล้วในกรอบของลูก

**การตรวจสอบเทียบกับการแก้ไข** อาร์เรย์ที่สกัดอธิบายโครงร่าง; การเปลี่ยนแปลงอาร์เรย์จะไม่อัปเดตรูปร่างต้นฉบับ ใช้วิธีนี้เมื่อการวิเคราะห์หรือโค้ดการวาดของคุณต้องการอาร์เรย์จุด/ประเภท ใช้ [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปร่างหรือเมื่อคุณต้องการแก้ไขเรขาคณิตของมัน นำเส้นทางที่แก้ไขไปใช้ผ่าน [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) หรือ [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)

## **แปลง Java AWT Shape ไปเป็น GeometryPath**

ตัวอย่างนี้ผสมโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต วิธี [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) ของโครงร่างปิดการเติมสี [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) สร้างเค้าโครงข้อความใน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ตัว [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) ให้ข้อมูลการเคลื่อนย้าย, เส้น, ควอดราติก, คิวบิก และส่วนปิด ซึ่งตัวอย่างนี้นำกลับมาเล่นบน [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)

สะพาน Java ใช้ค่า float และ byte อย่างชัดเจนสำหรับพารามิเตอร์ของ Java ที่สอดคล้องกัน ตัว iterator เขียนพิกัดลงในอาร์เรย์ float ของ Java; การสะท้อนอ่านค่าที่อัปเดตกลับไปยัง JavaScript ข้อความใช้ฟอนต์ Arial ขนาด 40 จุด โครงร่างเลื่อนด้านแนวนอน 20 จุดและวางตำแหน่งให้ด้านบนของข้อความอยู่ 10 จุดใต้ขอบบนของรูปร่าง เส้นทางข้อความถูกเติมสี ในขณะที่สี่เหลี่ยมเดิมยังคงเป็นโครงร่างเท่านั้น การนำทั้งสองเส้นทางไปใช้ด้วย [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างเดียวที่ประกอบด้วยสี่เหลี่ยมและข้อความ

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // ย้ายไป.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // วาดเส้นไป.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // เส้นโค้ง Bézier แบบควอดราติก.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // เส้นโค้ง Bézier แบบคิวบิก.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // ปิดรูป.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **คำถามที่พบบ่อย**

**อะไรจะเกิดขึ้นกับการเติมสีและโครงรอบหลังจากเปลี่ยนเรขาคณิตย์?**

สไตล์ยังคงอยู่กับรูปร่าง; เพียงโครงร่างเท่านั้นที่เปลี่ยน การเติมสีและโครงรอบจะถูกนำมาใช้โดยอัตโนมัติกับเรขาคณิตย์ใหม่

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตย์ได้อย่างถูกต้องอย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) ของรูปร่าง; เรขาคณิตย์จะหมุนพร้อมกับรูปร่างเนื่องจากผูกกับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ "ล็อก" ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออก [slide](/slides/th/nodejs-java/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/nodejs-java/create-shape-thumbnails/) เองเป็นรูปแบบราสเตอร์; วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตย์ซับซ้อนง่ายขึ้น