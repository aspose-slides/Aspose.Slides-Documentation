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
- เพิ่มลายน้ำลงใน PPT
- เพิ่มลายน้ำลงใน PPTX
- เพิ่มลายน้ำลงใน ODP
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
description: "จัดการลายน้ำข้อความและรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย .NET เพื่อระบุว่าเป็นร่าง ข้อมูลลับ ลิขสิทธิ์ และอื่น ๆ"
---
## **บทนำ**

**ลายน้ำ** ในการนำเสนอคือสติ๊กเกอร์ข้อความหรือรูปภาพที่ใช้บนสไลด์หรือทั่วทั้งสไลด์ของการนำเสนอทั่วไป โดยปกติแล้วลายน้ำจะใช้เพื่อบ่งบอกว่าการนำเสนอเป็นร่าง (เช่นลายน้ำ “Draft”) หรือมีข้อมูลลับ (เช่นลายน้ำ “Confidential”) หรือระบุว่าติดกับบริษัทใด (เช่นลายน้ำ “Company Name”) เพื่อระบุตัวผู้สร้างการนำเสนอ ฯลฯ ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่าการนำเสนอไม่ควรคัดลอก ลายน้ำถูกใช้ทั้งในรูปแบบ PowerPoint และ OpenDocument ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/net/) คุณสามารถเพิ่มลายน้ำให้กับไฟล์ PowerPoint PPT, PPTX และ OpenDocument ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/net/) มีวิธีต่าง ๆ มากมายที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenDocument และปรับแต่งการออกแบบและพฤติกรรมของลายน้ำได้ ส่วนที่สำคัญคือเมื่อต้องการเพิ่มลายน้ำข้อความคุณควรใช้อินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) และเมื่อต้องการเพิ่มลายน้ำรูปภาพให้ใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) หรือเติมรูปภาพให้กับรูปทรงลายน้ำ `PictureFrame` implements the [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape) interface, allowing you to use all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape) object.

มีสองวิธีที่สามารถใช้ลายน้ำได้: ใส่บนสไลด์เดียวหรือใส่บนสไลด์ทั้งหมดของการนำเสนอ Slide Master จะถูกใช้เพื่อใส่ลายน้ำบนสไลด์ทั้งหมด — ลายน้ำจะถูกเพิ่มใน Slide Master ออกแบบเต็มรูปแบบที่นั่นและจะถูกนำไปใช้กับสไลด์ทั้งหมดโดยไม่กระทบต่อสิทธิ์ในการแก้ไขลายน้ำบนสไลด์แต่ละอัน

ลายน้ำโดยทั่วไปถือว่าไม่ควรให้ผู้ใช้อื่นแก้ไข เพื่อป้องกันไม่ให้รูปทรงของลายน้ำ (หรือที่จริงคือรูปทรงแม่ของลายน้ำ) ถูกแก้ไข Aspose.Slides ให้ความสามารถในการล็อครูปทรง สามารถล็อครูปทรงเฉพาะบนสไลด์ปกติหรือบน Slide Master เมื่อรูปทรงลายน้ำถูกล็อคบน Slide Master มันจะถูกล็อคบนสไลด์ทั้งหมดของการนำเสนอ

คุณสามารถตั้งชื่อให้กับลายน้ำเพื่อว่าในอนาคตหากต้องการลบคุณจะสามารถค้นหาได้โดยใช้ชื่อของรูปทรงในสไลด์

คุณสามารถออกแบบลายน้ำได้ตามต้องการ อย่างไรก็ตามลักษณะทั่วไปของลายน้ำมักจะเป็นการจัดกึ่งกลาง การหมุน การอยู่ด้านหน้า ฯลฯ เราจะพิจารณาวิธีการใช้สิ่งเหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความในสไลด์**

เพื่อเพิ่มลายน้ำข้อความใน PPT, PPTX หรือ ODP คุณสามารถเพิ่มรูปทรงลงในสไลด์ก่อน แล้วจึงเพิ่มเฟรมข้อความลงในรูปทรงนั้น ฟรมข้อความจะถูกแทนด้วยอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe) ประเภทนี้ไม่ได้สืบทอดจาก [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ซึ่งมีชุดคุณสมบัติที่กว้างขวางสำหรับการกำหนดตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นวัตถุ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe) จะถูกห่อหุ้มไว้ในวัตถุ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปทรง ให้ใช้เมธอด [AddTextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/methods/addtextframe) ตามตัวอย่างด้านล่าง

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// เพิ่มลายน้ำลงในสไลด์.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [วิธีใช้คลาส TextFrame?](/slides/th/net/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความในงานนำเสนอ**

หากคุณต้องการเพิ่มลายน้ำข้อความให้กับงานนำเสนอทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/masterslide/) ส่วนตรรกะที่เหลือเหมือนกับการเพิ่มลายน้ำลงในสไลด์เดียว — สร้างวัตถุ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) แล้วจึงเพิ่มลายน้ำโดยใช้เมธอด [AddTextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/methods/addtextframe)

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// เพิ่มลายน้ำลงในมาสเตอร์สไลด์.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [วิธีใช้ Slide Master?](/slides/th/net/slide-master/)
{{% /alert %}}

### **ตั้งค่าความโปร่งใสของรูปทรงลายน้ำ**

โดยค่าเริ่มต้น รูปสี่เหลี่ยมจะถูกจัดสไตล์ด้วยสีเติมและสีเส้น ซึ่งหมายความว่าลายน้ำอาจปรากฏด้วยพื้นหลังหรือเส้นขอบที่ทึบและอาจทำให้ผู้ชมละความสนใจจากเนื้อหาในสไลด์ เพื่อให้ลายน้ำดูเบาบางและไม่รบกวนการออกแบบภาพของการนำเสนอ คุณสามารถทำให้รูปทรงเป็นโปร่งใสอย่างเต็มที่ได้

บรรทัดโค้ดต่อไปนี้ทำให้รูปทรงโปร่งใสโดยลบสีเติมและสีเส้นออกทั้งสองอย่าง

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **ตั้งค่าแบบอักษรสำหรับลายน้ำข้อความ**

ก่อนนำลายน้ำข้อความไปใช้ในสไลด์ของคุณ ควรปรับแต่งลักษณะการแสดงผลเพื่อให้สอดคล้องกับการออกแบบโดยรวม คุณสามารถเปลี่ยนแบบอักษรและขนาดเพื่อให้ลายน้ำอ่านง่ายและสวยงาม การปรับแบบอักษรยังช่วยเสริมความแข็งแรงของแบรนด์หรือให้เข้ากับสไตล์การนำเสนอได้ง่ายขึ้น

โค้ดตัวอย่างด้านล่างแสดงวิธีปรับตั้งค่าฟอนต์ของลายน้ำโดยเลือกฟอนต์ Latin เฉพาะและกำหนดความสูงของฟอนต์ที่เหมาะสม

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **ตั้งค่าสีข้อความลายน้ำ**

ก่อนนำลายน้ำของคุณไปใช้ สิ่งสำคัญคือต้องตั้งค่าสีข้อความให้เหมาะสมเพื่อให้สอดคล้องกับเนื้อหาสไลด์โดยไม่ทำให้เด่นเกินไป การปรับค่าความโปร่งใส (alpha) ของสีพร้อมกับส่วนประกอบสีแดง เขียว น้ำเงิน จะช่วยสร้างลายน้ำที่เบาบางกึ่งโปร่งใส ซึ่งมองเห็นได้แต่ไม่รบกวนการนำเสนอหลัก วิธีนี้ช่วยให้ผู้ชมโฟกัสที่เนื้อหาหลักของการนำเสนอขณะเดียวกันยังคงปกป้องเนื้อหาไว้

เพื่อกำหนดสีของข้อความลายน้ำ ใช้โค้ดต่อไปนี้

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **จัดกึ่งกลางลายน้ำข้อความ**

การจัดกึ่งกลางลายน้ำข้อความอย่างเหมาะสมสามารถยกระดับความสวยงามโดยรวมของการนำเสนอได้อย่างมาก โดยทำให้ลายน้ำอยู่ในตำแหน่งสมมาตรไม่ว่าจะมีขนาดสไลด์เท่าใด วิธีนี้ไม่เพียงทำให้สไลด์ดูเป็นมืออาชีพเท่านั้น แต่ยังทำให้ลายน้ำไม่ขัดขวางเนื้อหาหลักของสไลด์ด้วย

โค้ดตัวอย่างด้านล่างแสดงวิธีคำนวณตำแหน่งกึ่งกลางของสไลด์และวางลายน้ำข้อความตามนั้น

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

ภาพด้านล่างแสดงผลลัพธ์สุดท้าย

![ลายน้ำข้อความ](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพในงานนำเสนอ**

ในหลายกรณี ลายน้ำรูปภาพสามารถเป็นองค์ประกอบการสร้างแบรนด์ที่เป็นเอกลักษณ์ หรือเป็นทางเลือกที่น่าสนใจต่อการใช้ลายน้ำข้อความ ก่อนเพิ่มลายน้ำให้ตรวจสอบให้แน่ใจว่าไฟล์รูปภาพพร้อมใช้งาน (เช่น PNG สำหรับความโปร่งใส) ตัวอย่างต่อไปนี้แสดงวิธีโหลดรูปภาพจากระบบไฟล์ของคุณ เพิ่มลงในงานนำเสนอ แล้วใช้คุณสมบัติเพิ่มเติมของรูปทรงเพื่อกำหนดเป็นลายน้ำ

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **ล็อคลายน้ำไม่ให้แก้ไข**

หากต้องการป้องกันไม่ให้ลายน้ำถูกแก้ไข ให้ใช้คุณสมบัติ [IAutoShape.ShapeLock](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/properties/shapelock) บนรูปทรง โดยคุณสมบัตินี้คุณสามารถป้องกันไม่ให้รูปทรงถูกเลือก ปรับขนาด ย้ายตำแหน่ง กลุ่มกับองค์ประกอบอื่น ๆ ล็อกข้อความจากการแก้ไข ฯลฯ

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// ล็อกรูปทรงลายน้ำจากการแก้ไข.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **นำลายน้ำไปอยู่ด้านหน้า**

ใน Aspose.Slides สามารถตั้งค่าลำดับ Z ของรูปทรงได้ผ่านเมธอด [IShapeCollection.Reorder](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/reorder/#reorder) เพื่อทำเช่นนี้ให้เรียกเมธอดจากรายการสไลด์ของงานนำเสนอและส่งอ้างอิงรูปทรงพร้อมหมายเลขลำดับเข้าไป ด้วยวิธีนี้คุณสามารถนำรูปทรงไปอยู่ด้านหน้า หรือส่งไปอยู่ด้านหลังของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์เป็นพิเศษเมื่อคุณต้องการวางลายน้ำอยู่ด้านหน้าของการนำเสนอ

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **ตั้งค่าการหมุนของลายน้ำ**

การปรับการหมุนของลายน้ำสามารถเพิ่มผลกระทบทางภาพและความละเอียดอ่อนของการนำเสนอได้อย่างมาก ตัวอย่างเช่น ลายน้ำแนวทแยงมุมอาจรบกวนน้อยลงในขณะที่ยังคงให้การป้องกันที่แข็งแรง ตัวอย่างต่อไปนี้คำนวณมุมที่เหมาะสมตามขนาดสไลด์เพื่อให้ลายน้ำวางเป็นแนวทแยงมุมทั่วสไลด์ การคำนวณแบบไดนามิกนี้ทำให้ลายน้ำยังคงมีประสิทธิภาพไม่ว่าขนาดสไลด์จะเปลี่ยนแปลงอย่างไร

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **ตั้งชื่อลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปทรงได้ โดยใช้ชื่อรูปทรงคุณสามารถเข้าถึงในอนาคตเพื่อแก้ไขหรือทำลบได้ เพื่อกำหนดชื่อให้กับรูปทรงลายน้ำ ให้กำหนดค่าให้กับคุณสมบัติ [IAutoShape.Name](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/name)

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **ลบลายน้ำ**

เพื่อทำลบรูปทรงลายน้ำ ให้ใช้คุณสมบัติ [IAutoShape.Name](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/name) เพื่อค้นหาในรูปทรงของสไลด์ จากนั้นส่งรูปทรงลายน้ำเข้าเมธอด [IShapeCollection.Remove](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/remove/)  

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **ตัวอย่างจริง**

คุณอาจอยากลองใช้เครื่องมือออนไลน์ **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/th/watermark) และ [Remove Watermark](https://products.aspose.app/slides/th/watermark/remove-watermark)

![เครื่องมือออนไลน์สำหรับเพิ่มและลบลายน้ำ](online_tools.png)

## **คำถามที่พบบ่อย**

### ลายน้ำคืออะไรและทำไมต้องใช้?

ลายน้ำคือการวางข้อความหรือรูปภาพทับบนสไลด์ที่ช่วยปกป้องทรัพย์สินทางปัญญา เพิ่มการรับรู้แบรนด์ หรือป้องกันการใช้งานเอกสารโดยไม่ได้รับอนุญาต

### ฉันสามารถใส่ลายน้ำลงในทุกสไลด์ของงานนำเสนอได้หรือไม่?

ใช่ Aspose.Slides อนุญาตให้คุณเพิ่มลายน้ำลงในทุกสไลด์ของงานนำเสนอได้โดยอัตโนมัติ คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและกำหนดค่าลายน้ำให้แต่ละสไลด์ได้

### ฉันจะปรับความโปร่งใสของลายน้ำได้อย่างไร?

คุณสามารถปรับความโปร่งใสของลายน้ำได้โดยแก้ไขการตั้งค่าเติมของรูปทรง ([FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/shape/fillformat/)) ซึ่งทำให้ลายน้ำดูเบาบางและไม่ดึงความสนใจจากเนื้อหาสไลด์

### รูปแบบภาพใดบ้างที่รองรับสำหรับลายน้ำ?

Aspose.Slides รองรับรูปแบบภาพหลายชนิด เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

### ฉันสามารถปรับแต่งฟอนต์และสไตล์ของลายน้ำข้อความได้หรือไม่?

ได้ คุณสามารถเลือกฟอนต์ ขนาด และสไตล์ใด ๆ ที่ต้องการเพื่อให้สอดคล้องกับการออกแบบของงานนำเสนอและคงความสมดุลของแบรนด์

### ฉันจะเปลี่ยนตำแหน่งหรือการวางแนวของลายน้ำได้อย่างไร?

คุณสามารถปรับตำแหน่งและการวางแนวของลายน้ำโดยโปรแกรมโดยแก้ไขค่าพิกัด ขนาด และการหมุนของรูปทรงได้