---
title: เพิ่มลายน้ำในงานพรีเซนเทชั่นด้วย C++
linktitle: ลายน้ำ
type: docs
weight: 40
url: /th/cpp/watermark/
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
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการลายน้ำข้อความและลายน้ำรูปภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย C++ เพื่อบ่งบอกว่าเป็นฉบับร่าง, ข้อมูลเป็นความลับ, ลิขสิทธิ์, และอื่น ๆ"
---
## **บทนำ**

**ลายน้ำ** ในงานพรีเซนเทชั่นคือสติ๊กเกอร์ข้อความหรือรูปภาพที่ใช้บนสไลด์หรือทั่วทั้งสไลด์ของงานพรีเซนเทชั่น โดยทั่วไปแล้วลายน้ำจะใช้เพื่อบ่งบอกว่างานพรีเซนเทชั่นเป็นฉบับร่าง (เช่น ลายน้ำ “Draft”) มีข้อมูลเป็นความลับ (เช่น ลายน้ำ “Confidential”) ระบุว่าข้อมูลเป็นของบริษัทใด (เช่น ลายน้ำ “Company Name”) ระบุตัวผู้สร้างงานพรีเซนเทชั่น เป็นต้น ลายน้ำช่วยป้องกันการละเมิดลิขสิทธิ์โดยบ่งบอกว่างานไม่ควรถูกคัดลอก ลายน้ำใช้ได้ทั้งในรูปแบบ PowerPoint และ OpenOffice ใน Aspose.Slides คุณสามารถเพิ่มลายน้ำลงในไฟล์ PowerPoint PPT, PPTX และ OpenOffice ODP ได้

ใน [**Aspose.Slides**](https://products.aspose.com/slides/th/cpp/) มีวิธีต่าง ๆ ที่คุณสามารถสร้างลายน้ำในเอกสาร PowerPoint หรือ OpenOffice และปรับการออกแบบและพฤติกรรมของลายน้ำได้ จุดร่วมคือการเพิ่มลายน้ำข้อความควรใช้อินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) และการเพิ่มลายน้ำรูปภาพให้ใช้คลาส [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) หรือเติมรูปภาพลงในรูปร่างลายน้ำ `PictureFrame` implements the [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) interface, allowing you to use all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) object.

มีสองวิธีในการใช้ลายน้ำ: กับสไลด์เดี่ยวหรือกับสไลด์ทั้งหมดของงานพรีเซนเทชั่น โดย Slide Master จะถูกใช้เพื่อใช้ลายน้ำกับสไลด์ทั้งหมด — ลายน้ำถูกเพิ่มลงใน Slide Master ออกแบบที่นั่นอย่างเต็มที่และจะนำไปใช้กับทุกสไลด์โดยไม่กระทบต่อสิทธิ์การแก้ไขลายน้ำในสไลด์แต่ละใบ

ลายน้ำโดยทั่วไปจะถือว่าไม่สามารถแก้ไขได้โดยผู้ใช้คนอื่น เพื่อป้องกันไม่ให้ลายน้ำ (หรือรูปร่างแม่ของลายน้ำ) ถูกแก้ไข Aspose.Slides มีฟังก์ชันการล็อกรูปร่างให้ใช้งานได้ รูปร่างใด ๆ สามารถล็อกได้บนสไลด์ปกติหรือบน Slide Master เมื่อรูปร่างลายน้ำถูกล็อกบน Slide Master มันจะถูกล็อกบนสไลด์ทั้งหมดของงานพรีเซนเทชั่น

คุณสามารถตั้งชื่อให้ลายน้ำได้ เพื่อให้ในอนาคตเมื่อต้องการลบคุณสามารถค้นหารูปร่างโดยใช้ชื่อได้

คุณสามารถออกแบบลายน้ำได้อย่างอิสระ; อย่างไรก็ตามลายน้ำมักมีคุณลักษณะทั่วไป เช่น การจัดกึ่งกลาง การหมุน การวางตำแหน่งด้านหน้า เป็นต้น เราจะพิจารณาการใช้คุณลักษณะเหล่านี้ในตัวอย่างต่อไป

## **ลายน้ำข้อความ**

### **เพิ่มลายน้ำข้อความลงในสไลด์**

เพื่อเพิ่มลายน้ำข้อความในไฟล์ PPT, PPTX หรือ ODP คุณสามารถเริ่มด้วยการเพิ่มรูปร่างลงในสไลด์ แล้วเพิ่มเฟรมข้อความลงในรูปร่างนั้น เฟรมข้อความถูกแทนด้วยอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ซึ่งไม่ได้สืบทอดจาก [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ที่มีคุณสมบัติด้านการวางตำแหน่งลายน้ำอย่างยืดหยุ่น ดังนั้นอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) จะถูกห่อหุ้มในอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) เพื่อเพิ่มข้อความลายน้ำลงในรูปร่าง ให้ใช้เมธอด [AddTextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/addtextframe/) ตามตัวอย่างด้านล่าง

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [วิธีใช้คลาส TextFrame](/slides/th/cpp/text-formatting/)
{{% /alert %}}

### **เพิ่มลายน้ำข้อความลงในงานพรีเซนเทชั่น**

หากต้องการเพิ่มลีน้ำข้อความให้กับงานพรีเซนเทชั่นทั้งหมด (คือทุกสไลด์พร้อมกัน) ให้เพิ่มลงใน [MasterSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/masterslide/) ส่วนของตรรกะที่เหลือเหมือนกับการเพิ่มลายน้ำลงในสไลด์เดียว — สร้างอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) แล้วเพิ่มลายน้ำลงในอ็อบเจกต์นั้นโดยใช้เมธอด [AddTextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/addtextframe/)

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [วิธีใช้ Slide Master](/slides/th/cpp/slide-master/)
{{% /alert %}}

### **กำหนดความโปร่งใสของรูปร่างลายน้ำ**

โดยค่าเริ่มต้นรูปร่างสี่เหลี่ยมจะมีสีเติมและสีเส้นบรรทัดบรรจุ โค้ดต่อไปนี้ทำให้รูปร่างโปร่งใส

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **กำหนดแบบอักษรสำหรับลายน้ำข้อความ**

คุณสามารถเปลี่ยนแบบอักษรของลายน้ำข้อความได้ตามตัวอย่างด้านล่าง

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **กำหนดสีข้อความลายน้ำ**

เพื่อกำหนดสีของข้อความลายน้ำให้ใช้โค้ดนี้:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **จัดกึ่งกลางลายน้ำข้อความ**

สามารถจัดกึ่งกลางลายน้ำบนสไลด์ได้ โดยทำตามขั้นตอนดังนี้:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

รูปภาพด้านล่างแสดงผลลัพธ์ขั้นสุดท้าย

![ลายน้ำข้อความ](text_watermark.png)

## **ลายน้ำรูปภาพ**

### **เพิ่มลายน้ำรูปภาพลงในงานพรีเซนเทชั่น**

เพื่อเพิ่มลายน้ำรูปภาพลงในสไลด์ของงานพรีเซนเทชั่น คุณสามารถทำตามขั้นตอนต่อไปนี้:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **ล็อกลายน้ำไม่ให้แก้ไข**

หากต้องการป้องกันไม่ให้ลายน้ำถูกแก้ไข ให้ใช้เมธอด [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/get_autoshapelock/) บนรูปร่าง ด้วยคุณสมบัตินี้คุณสามารถป้องกันไม่ให้รูปร่างถูกเลือก, ปรับขนาด, ย้ายตำแหน่ง, รวมกลุ่มกับองค์ประกอบอื่น, ล็อกข้อความจากการแก้ไข, เป็นต้น:

```cpp
// ล็อกรูปร่างลายน้ำไม่ให้แก้ไขได้
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **นำลายน้ำไปไว้ด้านหน้า**

ใน Aspose.Slides การจัดลำดับ Z ของรูปร่างสามารถตั้งค่าได้ผ่านเมธอด [IShapeCollection::Reorder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/reorder/) เพื่อทำเช่นนี้ให้เรียกเมธอดนี้จากรายการสไลด์ของงานพรีเซนเทชั่นและส่งอ้างอิงรูปร่างและหมายเลขลำดับที่ต้องการเข้าไป วิธีนี้ทำให้สามารถนำรูปร่างไปไว้ด้านหน้า หรือส่งไปอยู่ด้านหลังของสไลด์ได้ ฟีเจอร์นี้มีประโยชน์อย่างยิ่งเมื่อคุณต้องการวางลายน้ำไว้หน้าหนังสือพรีเซนเทชั่น:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **ตั้งค่าการหมุนของลายน้ำ**

นี่คือตัวอย่างโค้ดว่าต้องปรับการหมุนของลายน้ำอย่างไรให้วางเป็นแนวทแยงมุมบนสไลด์:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **กำหนดชื่อให้ลายน้ำ**

Aspose.Slides อนุญาตให้คุณตั้งชื่อให้กับรูปร่างได้ โดยใช้ชื่อรูปร่างคุณสามารถเข้าถึงในอนาคตเพื่อแก้ไขหรือทำการลบได้ เพื่อกำหนดชื่อให้กับรูปร่างลายน้ำ ให้เรียกเมธอด [IAutoShape::set_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **ลบลายน้ำ**

เพื่อทำการลบรูปร่างลายน้ำ ให้ใช้เมธอด [IAutoShape::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_name/) เพื่อค้นหาในรูปร่างของสไลด์ จากนั้นส่งรูปร่างลายน้ำเข้าไปในเมธอด [IShapeCollection::Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/remove/) :

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **ตัวอย่างแบบเรียลไทม์**

คุณอาจต้องการลองใช้เครื่องมือ **Aspose.Slides ฟรี** [Add Watermark](https://products.aspose.app/slides/th/watermark) และ [Remove Watermark](https://products.aspose.app/slides/th/watermark/remove-watermark) ออนไลน์

![เครื่องมือออนไลน์สำหรับเพิ่มและลบลายน้ำ](online_tools.png)

## **คำถามที่พบบ่อย**

**ลายน้ำคืออะไรและทำไมต้องใช้?**

ลายน้ำคือการซ้อนข้อความหรือรูปภาพบนสไลด์ที่ช่วยปกป้องทรัพย์สินทางปัญญา เพิ่มการรู้จักแบรนด์ หรือป้องกันการนำงานพรีเซนเทชั่นไปใช้โดยไม่ได้รับอนุญาต

**ฉันสามารถเพิ่มลายน้ำให้กับสไลด์ทั้งหมดในงานพรีเซนเทชั่นได้หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณเพิ่มลายน้ำให้กับทุกสไลด์ในงานพรีเซนเทชั่นโดยอัตโนมัติ คุณสามารถวนลูปผ่านสไลด์ทั้งหมดและตั้งค่าลายน้ำให้แต่ละสไลด์ได้

**ฉันจะปรับความโปร่งใสของลายน้ำได้อย่างไร?**

คุณสามารถปรับความโปร่งใสของลายน้ำได้โดยแก้ไขการตั้งค่าการเติมสี ([FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/get_fillformat/)) ของรูปร่าง ซึ่งทำให้ลายน้ำดูอ่อนโยนและไม่รบกวนเนื้อหาของสไลด์

**ลายน้ำรองรับรูปแบบภาพใดบ้าง?**

Aspose.Slides รองรับรูปแบบภาพหลายประเภท เช่น PNG, JPEG, GIF, BMP, SVG และอื่น ๆ

**ฉันสามารถปรับแต่งแบบอักษรและสไตล์ของลายน้ำข้อความได้หรือไม่?**

ได้, คุณสามารถเลือกแบบอักษร, ขนาด, และสไตล์ใดก็ได้เพื่อให้สอดคล้องกับการออกแบบงานพรีเซนเทชั่นและรักษาความสอดคล้องของแบรนด์