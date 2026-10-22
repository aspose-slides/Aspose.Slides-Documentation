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
- จุดเส้นทาง
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
description: "สร้างและปรับแต่งรูปร่างในการนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างแบบผสม"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปร่างของงานนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต โดยจะแสดงวิธีการใช้งาน [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่, ทำการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือลบจุด, และนำเรขาคณิตที่อัปเดตกลับไปที่รูปร่าง

มันยังสาธิตวิธีการสร้างรูปร่างแบบกำหนดเองและแบบผสม, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่, ตรวจสอบองค์ประกอบของรูปร่าง, และแปลงโครงร่างข้อความของ Java AWT ให้เป็นเส้นทางเรขาคณิต

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยมจัตุรัส:

* ย้ายมุมเข้าหรือออกจากศูนย์กลาง
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดทำให้คุณสามารถปรับเปลี่ยนโครงร่างของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นพื้นฐานสำหรับสร้างรูปร่างใหม่ได้

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

เมื่อตั้งค่าแก้ไขรูปร่างใน PowerPoint ให้จดจำแนวคิดต่อไปนี้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนต่าง ๆ
* ส่วนอาจเป็นเส้นตรงหรือเส้นโค้ง จุดยึดและตัวจับการควบคุมกำหนดรูปร่างของมัน
* จุดยึดมีประเภทเป็น จุดมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม ส่วนที่เชื่อมต่ออาจพบกันเป็นมุม
  * ที่จุดเรียบ ตัวจับควบคุมสองตัวจะอยู่ในแนวเดียวกันและอยู่ห่างจากจุดยึดเท่ากัน
  * ที่จุดตรง ตัวจับควบคุมสองตัวอยู่ในแนวเดียวกันแต่ระยะห่างจากจุดยึดอาจต่างกัน
* การย้ายจุดยึดหรือการปรับตัวจับของมันจะเปลี่ยนโครงร่างของรูปร่าง

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข **Aspose.Slides** ให้คลาส [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 

* อ็อบเจ็กต์ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) เป็นตัวแทนของเส้นทางเรขาคณิตของอ็อบเจ็กต์ [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), คุณสามารถใช้เมธอด [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths)
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ให้กับรูปร่าง คุณสามารถใช้เมธอดเหล่านี้: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) สำหรับรูปร่างที่มีเส้นทางเดียวและ [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มส่วน คุณสามารถใช้เมธอดภายใต้ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)
* โดยใช้เมธอด [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) และ [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิตได้
* โดยใช้เมธอด [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) เป็นอาเรย์ของส่วนเส้นทางได้
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตของรูปร่างเพิ่มเติม คุณสามารถอ่านอ็อบเจ็กต์ [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ผ่าน [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) และทำซ้ำส่วนบน [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การอ้างอิงที่รับดัชนีจะทำการแทรกส่วนที่ตำแหน่งศูนย์ฐานในอาเรย์ส่วนของเส้นทาง

| การดำเนินการ | เมธอด |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบคิวบิกที่มีจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบกำลังสองที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| เพิ่มส่วนโค้งวงรีที่มีขนาดและมุมตามที่ระบุ (หน่วยเป็นองศา) | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| ปิดรูปปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| กำหนดจุดเริ่มต้นของรูป | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| ลบส่วนที่ตำแหน่งดัชนีศูนย์ฐาน | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**

ตัวอย่างนี้แทรกจุดสองจุดลงในรูปร่างสี่เหลี่ยมผืนผ้าโดยใช้ [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) และนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). พิกัดเป็นค่าท้องถิ่นของรูปร่าง: ทั้งสองจุดใหม่อยู่ที่ศูนย์กลางของรูปร่าง, ห่างจากด้านซ้าย 100 จุดและจากด้านบน 50 จุด. ดัชนีส่วนที่ 1 และ 4 วางจุดเหล่านี้บนขอบบนและขอบล่าง, ดึงขอบเหล่านั้นเข้าหากัน

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

## **ลบจุดจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยลบส่วนที่ดัชนีศูนย์ฐาน 2 ด้วย [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). การนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) จะอัปเดตขอบลักษณะของรูปร่าง

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

ตัวอย่างนี้สร้างดาวห้าแฉกโดยใช้ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุดกำหนดปลายและส่วนเว้า; ขั้นที่ 72 องศาทำให้ห้าปลายห่างกันอย่างเท่าเทียม. เส้นทางถูกปิดด้วย [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) และนำไปใช้กับรูปร่างสี่เหลี่ยมผืนผ้าโดยใช้ [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), แทนที่โครงร่างเดิม

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

## **สร้างรูปร่างกำหนดเองแบบประกอบ**

ตัวอย่างนี้กำหนดสองอ็อบเจ็กต์ [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ปิดสำหรับหนึ่งในสามส่วนบนและล่างของรูปร่าง. การใช้ทั้งสองเส้นทางด้วย [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างประกอบเดียวที่มีช่องว่างครอบครึ่งกลางของรูปร่าง

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

## **สร้างรูปร่างกำหนดเองพร้อมมุมโค้ง**

ตัวอย่างนี้รวมส่วนตรงกับ [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) เพื่อสร้างรูปร่างที่มุมโค้งเข้าหากัน. ขนาดมุมแต่ละอันกำหนดความกว้างและความสูงของโค้งในหน่วยจุด, และการสวิง -90 องศาจะวาดส่วนหนึ่งของวงรัตทวนเข็มนาฬิกา. เส้นทางที่เสร็จสมบูรณ์ถูกนำไปใช้ด้วย [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), และการนำเสนอจะบันทึกเป็นรูปแบบ PPTX

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

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่าจบด้วยส่วนปิดหรือไม่ มันอ่าน [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) และเปรียบเทียบคำสั่งสุดท้ายของส่วนกับ [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) กับ [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). จะคืนค่า false หากไม่มีเส้นทางที่ไม่ว่างเปล่า การตรวจสอบนี้ดูคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบรูปย่อยทั้งหมดภายในเส้นทาง ตัวอย่างจะแสดง `true` สำหรับสี่เหลี่ยมผืนผ้า

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

## **สกัดและตรวจสอบองค์ประกอบของรูปร่าง**

ใช้ [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) เพื่อตรวจสอบรูปร่างที่มีอยู่เป็นองค์ประกอบที่มีจุดเส้นทางและประเภทของจุด ใช้แต่ละ [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) ที่คืนค่าเพื่อดึงอาเรย์ของจุดและประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) และ [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). การแสดงผลนี้เป็นประโยชน์สำหรับการวิเคราะห์โครงร่างหรือการส่งเรขาคณิตไปยังเครื่องมือการวาดแบบกำหนดเอง

ตัวอย่างนี้เปิดไฟล์ input.pptx, ค้นหาเรขาคณิตรูปร่างแรกโดยตรงบนสไลด์แรก, และพิมพ์ส่วนเส้นทางของมัน ใช้ presentation ที่มีรูปร่างที่มีส่วนตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท ไม่ได้ค้นหาภายในกลุ่ม

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
                const pointType = types[i] & 0x07; // เก็บประเภทส่วน, ไม่รวมแฟล็ก.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
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

อาเรย์สอดคล้องกันตามดัชนี: `points[i]` คือจุดและ `types[i]` บรรยายบทบาทของมัน ประเภท `0` เริ่มรูป, ประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน ส่วน Bézier แบบคิวบิกเริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` ติดต่อกันสามรายการ: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่ ลูปจะใช้สามรายการนี้ร่วมกันและตรวจสอบจุดสิ้นสุดเพื่อดูว่าปิดหรือไม่

ประเภทจุดยังมีแฟล็กด้วย การทำมาสก์ด้วย `0x07` เพื่อระบุประเภทส่วน, และทดสอบ `0x80` แยกต่างหากเพื่อจับสภาพสับพาธที่ปิด ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดสิ้นสุดของเส้นที่ปิดสับพาธ, และ `131` (`0x83`) หมายถึงจุดสิ้นสุดของ Bézier ที่ปิดสับพาธหนึ่ง Java เก็บแฟล็กเหล่านี้ในไบต์ที่เป็น signed; การมาสก์ช่วยรักษาค่าบิตตามต้องการ การเปรียบเทียบค่าดิบเฉพาะกับ `1` หรือ `3` จะพลาดกรณีเหล่านี้ แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทส่วนพื้นฐาน

**พิกัดและการแปลง.**  
จุดวัดเป็นหน่วยจุด (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงด้านล่าง สำหรับรูปร่างที่ไม่ได้รวมกลุ่ม พิกัดที่สกัดได้จะรวมตำแหน่งที่ได้จาก [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) และ [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) และสะท้อนความกว้างและความสูงปัจจุบันของมัน ตัวอย่างเช่น สี่เหลี่ยมผืนผ้าไม่มีการหมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบโครงร่าง `(100, 200)`–`(220, 280)` อย่าเพิ่มตำแหน่งของรูปร่างอีกครั้ง ให้ลบค่า X และ Y ของมันออกเพื่อให้ได้พิกัดที่สัมพันธ์กับกรอบที่ไม่ได้หมุน  

จุดที่สกัดจะไม่รวมการหมุนของรูปร่างที่ได้จาก [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), หรือการพลิกแนวนอนและแนวตั้ง เพื่อทำให้ได้โครงร่างที่แสดงผล ต้องนำการแปลงเหล่านั้นไปใช้รอบศูนย์กลางของรูปร่าง สำหรับรูปร่างที่รวมกลุ่ม ต้องพิจารณาการแมปพิกัดของกลุ่มและการแปลงด้วย; อย่าสมมติว่าจุดที่สกัดเป็นพิกัดสุดท้ายที่แสดงบนสไลด์หรือทำการแปลงการย้ายหรือสเกลสองครั้งหากมันได้สะท้อนแล้วในกรอบของลูก  

**การตรวจสอบเทียบกับการแก้ไข.**  
อาเรย์ที่สกัดอธิบายโครงร่าง; การเปลี่ยนแปลงอาเรย์เหล่านี้จะไม่อัปเดตรูปร่างต้นฉบับ เลือกวิธีนี้เมื่อการวิเคราะห์หรือโค้ดการวาดของคุณต้องการอาเรย์จุด/ประเภท ใช้ [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปร่างหรืออยากแก้ไขเรขาคณิตของมัน นำเส้นทางที่แก้ไขไปใช้ผ่าน [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) หรือ [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)

## **แปลง Java AWT Shape เป็น GeometryPath**

ตัวอย่างนี้รวมโครงร่างสี่เหลี่ยมผืนผ้ากับข้อความที่แปลงเป็นเรขาคณิต วิธีการ [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) ของโครงร่างจะปิดการเติมเต็มของมัน [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) สร้างโครงร่างข้อความใน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) ของมันจัดหาการเคลื่อน, เส้น, โค้งกำลังสอง, คิวบิก, และส่วนปิด, ซึ่งตัวอย่างนี้ทำซ้ำบน [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)

ส่วนเชื่อม Java ใช้ค่า float และ byte อย่างชัดเจนสำหรับพารามิเตอร์ Java ที่สอดคล้องกัน ตัววนซ้ำเขียนพิกัดลงในอาร์เรย์ float ของ Java; การสะท้อนอ่านค่าที่อัปเดตกลับเข้าสู่ JavaScript ข้อความใช้ฟอนต์ Arial ขนาด 40 จุด โครงร่างถูกเลื่อน 20 จุดในแนวนอนและตำแหน่งโดยส่วนบนที่มองเห็นอยู่ 10 จุดด้านล่างขอบบนของรูปร่าง เส้นทางข้อความถูกเติมสี, ขณะที่สี่เหลี่ยมต้นฉบับยังคงเป็นโครงร่าง การนำทั้งสองเส้นทางไปใช้ด้วย [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างเดียวที่ประกอบด้วยสี่เหลี่ยมและข้อความ

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
            case 1: // เส้นไป.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // เส้นโค้งเบซิเยร์ระดับสอง.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // เส้นโค้งเบซิเยร์ระดับสาม.
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

**สิ่งที่จะเกิดขึ้นกับการเติมสีและโครงร่างหลังจากเปลี่ยนเรขาคณิตคืออะไร?**  
สไตล์คงอยู่กับรูปร่าง; มีเพียงโครงร่างที่เปลี่ยนแปลง การเติมสีและโครงร่างจะถูกนำไปใช้กับเรขาคณิตใหม่โดยอัตโนมัติ

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**  
ใช้เมธอด [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) ของรูปร่าง; เรขาคณิตจะหมุนพร้อมกับรูปร่างเนื่องจากถูกผูกกับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ 'ล็อค' ผลลัพธ์ได้หรือไม่?**  
ได้. ส่งออกพื้นที่ [slide](/slides/th/nodejs-java/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/nodejs-java/create-shape-thumbnails/) เองเป็นรูปแบบราสเตอร์; นี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนได้ง่ายขึ้น