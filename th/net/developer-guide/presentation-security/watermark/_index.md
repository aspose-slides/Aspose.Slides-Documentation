---
title: เพิ่มลายน้ำในงานนำเสนอด้วย .NET
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/net/watermark/
keywords:
- ลายน้ำ
- ลายน้ำข้อความ
- ลายน้ำรูปภาพ
- เพิ่มลายน้ำ
- เปลี่ยนลายน้ำ
- ลบลายน้ำ
- ลบลายน้ำ
- เพิ่มลายน้ำใน PPT
- เพิ่มลายน้ำใน PPTX
- เพิ่มลายน้ำใน ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- ลบลายน้ำจาก PPT
- ลบลายน้ำจาก PPTX
- ลบลายน้ำจาก ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการลายน้ำข้อความและลายน้ำรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย .NET เพื่อบ่งบอกว่าเป็นร่าง ข้อมูลลับ ลิขสิทธิ์ และอื่น ๆ"
---
## **บทนำ**

**ลายน้ำ** ในการนำเสนอคือสตั๊มข้อความหรือรูปภาพที่ใช้ในสไลด์หนึ่งหรือทั่วทั้งสไลด์ของการนำเสนอ โดยทั่วไปลายน้ำจะใช้เพื่อบ่งชี้ว่าการนำเสนอนี้เป็นร่าง (เช่น ลายน้ำ “Draft”) มีข้อมูลลับ (เช่น ลายน้ำ “Confidential”) ระบุว่าเป็นของบริษัทใด (เช่น ลายน้ำ “Company Name”) หรือระบุผู้เขียนการนำเสนอ ฯลฯ ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่าการนำเสนอไม่ควรคัดลอก ลายน้ำใช้ได้ทั้งในรูปแบบ PowerPoint และ OpenDocument ใน Aspose.Slides คุณสามารถเพิ่มลายน้ำในไฟล์ PowerPoint PPT, PPTX และ OpenDocument ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/net/) มีวิธีต่าง ๆ ที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenDocument และปรับการออกแบบและพฤติกรรมของลายน้ำได้ ด้านร่วมคือการเพิ่มลายน้ำข้อความต้องใช้ interface [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ส่วนการเพิ่มลายน้ำรูปภาพใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) หรือเติมรูปภาพลงในรูปทรงของลายน้ำ `PictureFrame` implements interface [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape) ทำให้คุณใช้การตั้งค่าที่ยืดหยุ่นทั้งหมดของวัตถุ shape ได้ เนื่องจาก `ITextFrame` ไม่ใช่ shape และการตั้งค่ามีข้อจำกัด จึงถูกห่อหุ้มไว้ในอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape)

ลายน้ำสามารถนำไปใช้ได้สองวิธี: กับสไลด์เดียวหรือกับสไลด์ทั้งหมด Slide Master ใช้เพื่อเพิ่มลายน้ำให้กับสไลด์ทั้งหมด — ลายน้ำจะถูกเพิ่มใน Slide Master ออกแบบที่นั่นอย่างเต็มที่ และนำไปใช้กับสไลด์ทั้งหมดโดยไม่กระทบต่อสิทธิ์การแก้ไขลายน้ำบนสไลด์แต่ละสไลด์

ลายน้ำมักถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้คนอื่น ๆ เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปทรงพาเรนท์ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปทรง รูปทรงเฉพาะสามารถล็อกบนสไลด์ปกติหรือบน Slide Master ได้ เมื่อรูปทรงลายน้ำถูกล็อกบน Slide Master จะถูกล็อกบนสไลด์ทั้งหมด

คุณสามารถตั้งชื่อให้ลายน้ำได้ เพื่อให้ในอนาคตเมื่อคุณต้องการลบ สามารถค้นหารูปทรงตามชื่อนั้นในสไลด์ได้

คุณสามารถออกแบบลายน้ำได้ทุกแบบ; อย่างไรก็ตามโดยทั่วไปลายน้ำมักมีลักษณะร่วมเช่น การจัดกึ่งกลาง การหมุน การวางอยู่ด้านหน้า ฯลฯ เราจะพิจารณา วิธีการใช้งานเหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปทรงลงบนสไลด์ก่อน แล้วเพิ่ม text frame ให้กับรูปทรงนั้น Text frame แทนด้วย interface [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe) ประเภทนี้ไม่ได้สืบทอดจาก [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ซึ่งมีชุดคุณสมบัติที่กว้างขวางสำหรับการกำหนดตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe) จะถูกห่อหุ้มในอ็อบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปทรง ให้ใช้เมธอด [AddTextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/methods/addtextframe) ตามตัวอย่างด้านล่าง

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// เพิ่มลายน้ำลงบนสไลด์.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class?](/slides/th/net/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความในงานนำเสนอ**

หากต้องการเพิ่มลายน้ำข้อความให้กับงานนำเสนอทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/masterslide/) ส่วนตรรกะที่เหลือเหมือนกับการเพิ่มลายน้ำในสไลด์เดียว — สร้างอ็อบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วเพิ่มลายน้ำด้วยเมธอด [AddTextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/methods/addtextframe)

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// เพิ่มลายน้ำลงบนสไลด์มาสเตอร์.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master?](/slides/th/net/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปทรงลายน้ำ**

โดยค่าเริ่มต้น รูปร่างสี่เหลี่ยมจะมีสีเติมและสีเส้น ซึ่งหมายความว่าลายน้ำอาจปรากฏพร้อมพื้นหลังหรือเส้นขอบที่หนาแน่น และอาจทำให้ผู้ชมเสียสมาธิจากเนื้อหา เพื่อให้ลายน้ำดูบางเบาและไม่รบกวนการออกแบบของสไลด์ คุณสามารถทำให้รูปทรงโปร่งใสอย่างสมบูรณ์ได้

บรรทัดโค้ดต่อไปนี้ทำให้รูปทรงโปร่งใสโดยลบสีเติมและสีเส้นทั้งสอง

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **ตั้งค่าแบบอักษรสำหรับลายน้ำข้อความ**

ก่อนที่จะใส่ลายน้ำข้อความลงสไลด์ ควรปรับแต่งลักษณะการแสดงผลเพื่อให้สอดคล้องกับการออกแบบโดยรวม คุณสามารถเปลี่ยนประเภทและขนาดของแบบอักษรเพื่อให้ลายน้ำอ่านง่ายและสวยงาม การปรับแบบอักษรยังช่วยเสริมสร้างเอกลักษณ์ของแบรนด์หรือให้สไลด์ดูสอดคล้องกับสไตล์ของการนำเสนอ

โค้ดตัวอย่างด้านล่างแสดงวิธีปรับตั้งค่าแบบอักษรของลายน้ำโดยเลือกแบบอักษร Latin เฉพาะและกำหนดความสูงของแบบอักษรที่เหมาะสม

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **ตั้งค่าสีข้อความลายน้ำ**

ก่อนใส่ลายน้ำ ต้องตรวจสอบให้แน่ใจว่าสีข้อความถูกตั้งค่าอย่างเหมาะสมเพื่อให้ผสมผสานกับเนื้อหาสไลด์โดยไม่ทำให้เกิดความรบกวน การปรับค่า transparency (alpha) พร้อมกับค่าเเดง, เขียว, น้ำเงิน ทำให้คุณสร้างลายน้ำที่บางเบา กึ่งโปร่งใส ที่มองเห็นได้แต่ไม่ทำให้สไลด์ดูรก

เพื่อกำหนดสีของข้อความลายน้ำ ให้ใช้โค้ดต่อไปนี้

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **จัดกึ่งกลางลายน้ำข้อความ**

การจัดกึ่งกลางลายน้ำข้อความอย่างเหมาะสมสามารถเพิ่มความสวยงามของการนำเสนอได้อย่างมาก โดยทำให้ลายน้ำอยู่ในตำแหน่งสมมาตร ไม่ว่าขนาดสไลด์จะเป็นเท่าใด วิธีนี้ช่วยให้สไลด์ดูเป็นมืออาชีพและลายน้ำไม่กีดขวางเนื้อหาหลัก

โค้ดตัวอย่างด้านล่างแสดงวิธีคำนวณตำแหน่งกึ่งกลางของสไลด์และวางลายน้ำข้อความตามนั้น

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

รูปด้านล่างแสดงผลลัพธ์สุดท้าย

![The text watermark](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพในงานนำเสนอ**

ในหลายกรณี ลายน้ำรูปภาพสามารถให้เอกลักษณ์ของแบรนด์หรือเป็นตัวเลือกที่สวยงามกว่าลายน้ำข้อความ ก่อนเพิ่มลายน้ำ ให้ตรวจสอบว่าไฟล์ภาพพร้อมใช้งาน (เช่น PNG สำหรับความโปร่งใส) ตัวอย่างต่อไปนี้แสดงวิธีโหลดภาพจากระบบไฟล์ของคุณ เพิ่มลงในงานนำเสนอ และใช้เป็นลายน้ำผ่านคุณลักษณะการเติมรูปของรูปทรง

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **ล็อกลายน้ำจากการแก้ไข**

หากต้องการป้องกันไม่ให้ลายน้ำถูกแก้ไข ให้ใช้ property [IAutoShape.ShapeLock](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/properties/shapelock) บนรูปทรง ด้วย property นี้คุณสามารถป้องกันไม่ให้รูปทรงถูกเลือก, ปรับขนาด, ย้ายตำแหน่ง, รวมกลุ่มกับองค์ประกอบอื่น, ล็อกข้อความจากการแก้ไข, และอื่น ๆ อีกมาก

```cs
// ล็อกรูปทรงลายน้ำจากการแก้ไข.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **นำลายน้ำขึ้นหน้า**

ใน Aspose.Slides การจัดลำดับ Z‑order ของรูปทรงสามารถตั้งค่าได้ผ่านเมธอด [IShapeCollection.Reorder](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/reorder/#reorder) เพื่อทำเช่นนี้ คุณต้องเรียกเมธอดจากรายการสไลด์ของงานนำเสนอและส่งผ่านอ้างอิงรูปทรงและหมายเลขลำดับเข้าเมธอด วิธีนี้ทำให้คุณสามารถนำรูปทรงขึ้นหน้าหรือส่งลงด้านหลังของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์อย่างยิ่งหากต้องการวางลายน้ำไว้ด้านหน้าของงานนำเสนอ

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **ตั้งค่าการหมุนของลายน้ำ**

การปรับการหมุนของลายน้ำสามารถเพิ่มผลกระทบด้านภาพและความละเอียดอ่อนของการนำเสนอได้อย่างมาก ลายน้ำแนวทแยงมุมเช่นนี้อาจก่อความรบกวนน้อยลง แต่ยังคงให้การปกป้องที่แข็งแกร่ง ตัวอย่างต่อไปนี้คำนวณมุมที่เหมาะสมตามขนาดสไลด์เพื่อให้ลายน้ำวางเป็นแนวทแยงมุมทั่วสไลด์ การคำนวณแบบไดนามิกนี้ทำให้ลายน้ำยังคงมีประสิทธิภาพไม่ว่าจะขนาดสไลด์เปลี่ยนแปลงอย่างไร

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **ตั้งชื่อลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปทรงได้ โดยใช้ชื่อรูปทรงคุณสามารถเข้าถึงมันในอนาคตเพื่อแก้ไขหรือทำการลบได้ เพื่อกำหนดชื่อลายน้ำ ให้กำหนดค่าที่ property [IAutoShape.Name](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/name)

```cs
watermarkShape.Name = "watermark";
```

## **ลบลายน้ำ**

เพื่อทำการลบรูปทรงลายน้ำ ให้ใช้ property [IAutoShape.Name](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/name) ค้นหารูปทรงในสไลด์ แล้วส่งรูปทรงลายน้ำเข้าเมธอด [IShapeCollection.Remove](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/remove/)

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **ตัวอย่างสด**

คุณอาจต้องการลองใช้ **Aspose.Slides ฟรี** เครื่องมือออนไลน์ [Add Watermark](https://products.aspose.app/slides/th/watermark) และ [Remove Watermark](https://products.aspose.app/slides/th/watermark/remove-watermark)

![Online tools to add and remove watermarks](online_tools.png)

## **คำถามที่พบบ่อย**

**ลายน้ำคืออะไรและทำไมต้องใช้งาน?**

ลายน้ำคือการทับข้อความหรือรูปภาพบนสไลด์ที่ช่วยปกป้องทรัพย์สินทางปัญญา เสริมการรับรู้แบรนด์ หรือป้องกันการใช้งานงานนำเสนอโดยไม่ได้รับอนุญาต

**ฉันสามารถเพิ่มลายน้ำให้กับทุกสไลด์ในงานนำเสนอได้หรือไม่?**

ได้, Aspose.Slides ให้คุณเพิ่มลายน้ำให้กับสไลด์ทั้งหมดได้โดยโปรแกรมmatically โดยคุณสามารถวนลูปผ่านทุกสไลด์และตั้งค่าลายน้ำแต่ละสไลด์ได้

**ฉันจะปรับความโปร่งใสของลายน้ำได้อย่างไร?**

คุณสามารถปรับความโปร่งใสของลายน้ำได้โดยแก้ไขการตั้งค่าการเติม ([FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/shape/fillformat/)) ของรูปทรง ทำให้ลายน้ำดูเบาบางและไม่รบกวนเนื้อหาสไลด์

**รูปแบบภาพใดบ้างที่สนับสนุนสำหรับลายน้ำ?**

Aspose.Slides รองรับรูปแบบภาพหลายแบบ เช่น PNG, JPEG, GIF, BMP, SVG ฯลฯ

**ฉันสามารถปรับแต่งแบบอักษรและสไตล์ของลายน้ำข้อความได้หรือไม่?**

ได้, คุณสามารถเลือกแบบอักษร, ขนาด, และสไตล์ใดก็ได้เพื่อให้สอดคล้องกับการออกแบบงานนำเสนอและรักษาความสอดคล้องของแบรนด์

**ฉันจะเปลี่ยนตำแหน่งหรือทิศทางของลายน้ำอย่างไร?**

คุณสามารถปรับตำแหน่งและทิศทางของลายน้ำโดยโปรแกรมโดยการแก้ไขพิกัด, ขนาด, และคุณสมบัติการหมุนของรูปทรงได้