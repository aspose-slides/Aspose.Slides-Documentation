---
title: จัดการรูปร่างในการนำเสนอด้วย .NET
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/net/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างการนำเสนอ
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ Interop Shape ID
- ข้อความแทนของรูปร่าง
- รูปแบบการจัดวางของรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้การสร้าง, แก้ไขและเพิ่มประสิทธิภาพของรูปร่างใน Aspose.Slides สำหรับ .NET และส่งมอบการนำเสนอ PowerPoint ที่มีประสิทธิภาพสูง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับรูปร่างในงานนำเสนอโดยใช้ Aspose.Slides ซึ่งแสดงวิธีค้นหารูปร่างบนสไลด์, คัดลอก, ลบ, ซ่อน, เปลี่ยนลำดับ, รับ Interop shape ID, และตั้งค่าข้อความแทนเพื่อการระบุและการประมวลผลต่อไป  

นอกจากนี้ยังครอบคลุมวิธีเข้าถึงรูปแบบการจัดวางสำหรับรูปร่าง, เรนเดอร์รูปร่างเป็น SVG, จัดแนวรูปร่างบนสไลด์, และใช้คุณสมบัติการพลิกเพื่อสร้างกระจกส่องในแนวนอนและแนวตั้ง อีกทั้งบทความยังมีส่วน FAQ สั้น ๆ เกี่ยวกับการรวมรูปร่าง, ลำดับการซ้อนกัน, และการล็อครูปร่าง

## **ค้นหารูปร่างบนสไลด์**
หัวข้อนี้จะอธิบายเทคนิคง่าย ๆ เพื่อช่วยให้นักพัฒนาค้นหารูปร่างที่ต้องการบนสไลด์โดยไม่ต้องใช้ Id ภายใน ซึ่งไฟล์ PowerPoint ไม่มีวิธีระบุรูปร่างบนสไลด์นอกจาก Id ที่เป็นค่าเอกลักษณ์ภายใน การค้นหารูปร่างโดยใช้ Id ภายในอาจทำได้ยาก ทุกรูปร่างที่เพิ่มลงในสไลด์จะมีข้อความแทนบางส่วน เราแนะนำให้นักพัฒนาใช้ข้อความแทนเพื่อค้นหารูปร่างที่ต้องการ คุณสามารถใช้ Microsoft PowerPoint กำหนดข้อความแทนสำหรับวัตถุที่คุณวางแผนจะเปลี่ยนในอนาคต  

หลังจากตั้งค่าข้อความแทนของรูปร่างใดรูปร่างหนึ่งแล้ว คุณสามารถเปิดงานนำเสนอนั้นด้วย Aspose.Slides for .NET และวนลูปตรวจสอบข้อความแทนของแต่ละรูปร่าง รูปร่างที่มีข้อความแทนตรงกันจะเป็นรูปร่างที่คุณต้องการ เพื่อแสดงเทคนิคนี้อย่างชัดเจนเราจึงสร้างเมธอด [FindShape](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/findshape/#findshape_1) เพื่อค้นหารูปร่างเฉพาะในสไลด์และส่งกลับรูปร่างนั้น

```c#
public static void Run()
{
    // สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // ข้อความแทนของรูปร่างที่ต้องการค้นหา
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// การนำไปใช้ของเมธอดเพื่อค้นหารูปร่างในสไลด์โดยใช้ข้อความแทนของมัน
public static IShape FindShape(ISlide slide, string alttext)
{
    // วนลูปผ่านรูปร่างทั้งหมดภายในสไลด์
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // หากข้อความแทนของสไลด์ตรงกับที่ต้องการ
        // คืนค่ารูปร่าง
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **คัดลอกรูปร่าง**
เพื่อคัดลอกรูปร่างไปยังสไลด์โดยใช้ Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เข้าถึงคอลเลกชันรูปร่างของสไลด์ต้นทาง
1. เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
1. คัดลอกรูปร่างจากคอลเลกชันรูปร่างของสไลด์ต้นทางไปยังสไลด์ใหม่
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่มกลุ่มรูปร่างไปยังสไลด์

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// บันทึกไฟล์ PPTX ลงดิสก์
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **ลบรูปร่าง**
Aspose.Slides for .NET อนุญาตให้ผู้พัฒนาลบรูปร่างใดก็ได้ เพื่อลบรูปร่างจากสไลด์ใดสไลด์หนึ่ง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`
1. เข้าถึงสไลด์แรก
1. ค้นหารูปร่างที่มี AlternativeText เฉพาะ
1. ลบรูปร่าง
1. บันทึกไฟล์ลงดิสก์

```c#
// สร้างอ็อบเจ็กต์ Presentation
Presentation pres = new Presentation();

// ดึงสไลด์แรก
ISlide sld = pres.Slides[0];

// เพิ่ม AutoShape ชนิดสี่เหลี่ยม
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// บันทึกการนำเสนอลงดิสก์
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **ซ่อนรูปร่าง**
Aspose.Slides for .NET อนุญาตให้ผู้พัฒนาซ่อนรูปร่างใดก็ได้ เพื่อต้องการซ่อนรูปร่างจากสไลด์ใดสไลด์หนึ่ง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`
1. เข้าถึงสไลด์แรก
1. ค้นหารูปร่างที่มี AlternativeText เฉพาะ
1. ซ่อนรูปร่าง
1. บันทึกไฟล์ลงดิสก์

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
 Presentation pres = new Presentation();

 // ดึงสไลด์แรก
 ISlide sld = pres.Slides[0];

 // เพิ่ม AutoShape ชนิดสี่เหลี่ยม
 IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
 IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
 String alttext = "User Defined";
 int iCount = sld.Shapes.Count;
 for (int i = 0; i < iCount; i++)
 {
     AutoShape ashp = (AutoShape)sld.Shapes[i];
     if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
     {
         ashp.Hidden = true;
     }
 }

 // บันทึกการนำเสนอลงดิสก์
 pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **เปลี่ยนลำดับรูปร่าง**
Aspose.Slides for .NET อนุญาตให้ผู้พัฒนาจัดลำดับรูปร่างใหม่ การจัดลำดับกำหนดว่ารูปร่างใดอยู่ด้านหน้า หรือด้านหลัง เพื่อจัดลำดับรูปร่างจากสไลด์ใดสไลด์หนึ่ง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปร่างหนึ่ง
1. เพิ่มข้อความบางส่วนในกรอบข้อความของรูปร่าง
1. เพิ่มรูปร่างอีกหนึ่งอันโดยใช้พิกัดเดียวกัน
1. จัดลำดับรูปร่างใหม่
1. บันทึกไฟล์ลงดิสก์

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```

## **รับ Interop Shape ID**
Aspose.Slides for .NET อนุญาตให้ผู้พัฒนารับตัวระบุรูปร่างเฉพาะในระดับสไลด์ ซึ่งแตกต่างจากคุณสมบัติ UniqueId ที่ให้ตัวระบุระดับงานนำเสนอ  Property OfficeInteropShapeId ถูกเพิ่มในอินเทอร์เฟซ IShape และคลาส Shape ตามลำดับ  ค่า ที่ได้จาก OfficeInteropShapeId จะสอดคล้องกับค่า Id ของอ็อบเจ็กต์ Microsoft.Office.Interop.PowerPoint.Shape ด้านล่างเป็นตัวอย่างโค้ด

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// รับตัวระบุรูปร่างที่เป็นเอกลักษณ์ในระดับสไลด์
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **ตั้งค่าข้อความแทนสำหรับรูปร่าง**
Aspose.Slides for .NET อนุญาตให้ผู้พัฒนาตั้งค่า AlternateText ของรูปร่างใดก็ได้  
รูปร่างในงานนำเสนอสามารถระบุแยกจากกันด้วยคุณสมบัติ AlternativeText หรือ Shape Name  
คุณสมบัติ AlternativeText สามารถอ่านหรือกำหนดได้โดยใช้ Aspose.Slides เช่นเดียวกับ Microsoft PowerPoint  
โดยใช้คุณสมบัตินี้ คุณสามารถแท็กรูปร่างและดำเนินการต่าง ๆ เช่น การลบ, การซ่อน หรือการจัดลำดับรูปร่างบนสไลด์  
เพื่อกำหนด AlternateText ของรูปร่าง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปร่างใดก็ได้ลงในสไลด์
1. ดำเนินการบางอย่างกับรูปร่างที่เพิ่งเพิ่ม
1. วนลูปตรวจสอบรูปร่างเพื่อค้นหารูปร่างที่ต้องการ
1. ตั้งค่า AlternativeText
1. บันทึกไฟล์ลงดิสก์

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();

// ดึงสไลด์แรก
ISlide sld = pres.Slides[0];

// เพิ่ม AutoShape ชนิดสี่เหลี่ยม
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// บันทึกการนำเสนอลงดิสก์
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **เข้าถึงรูปแบบการจัดวางสำหรับรูปร่าง**
Aspose.Slides for .NET ให้ API ที่ง่ายสำหรับเข้าถึงรูปแบบการจัดวางของรูปร่าง บทความนี้แสดงวิธีเข้าถึงรูปแบบการจัดวาง  

ด้านล่างเป็นตัวอย่างโค้ด

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **เรนเดอร์รูปร่างเป็น SVG**
ตอนนี้ Aspose.Slides for .NET รองรับการเรนเดอร์รูปร่างเป็น SVG  เมธอด WriteAsSvg (และโอเวอร์โหลด) ถูกเพิ่มในคลาส Shape และอินเทอร์เฟซ IShape  เมธอดนี้ช่วยให้บันทึกเนื้อหาของรูปร่างเป็นไฟล์ SVG  ตัวอย่างโค้ดด้านล่างแสดงวิธีส่งออกรูปร่างของสไลด์เป็นไฟล์ SVG

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **จัดแนวรูปร่าง**

ผ่านเมธอด [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/methods/alignshapes/index) ที่มีการโอเวอร์โหลด คุณสามารถ  

* จัดแนวรูปร่างตามระยะขอบของสไลด์ ดูตัวอย่างที่ 1  
* จัดแนวรูปร่างตามกันและกัน ดูตัวอย่างที่ 2  

Enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/th/net/aspose.slides/shapesalignmenttype) กำหนดตัวเลือกการจัดแนวที่มีให้

**Example 1**

โค้ด C# นี้แสดงวิธีจัดแนวรูปร่างที่มีดัชนี 1,2 และ 4 ให้เรียงตามขอบด้านบนของสไลด์: โค้ดต้นฉบับด้านล่างจัดแนวรูปร่างที่มีดัชนี 1,2 และ 4 ตามขอบบนของสไลด์

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Example 2**

โค้ด C# นี้แสดงวิธีจัดแนวชุดรูปร่างทั้งหมดโดยอิงจากรูปร่างที่อยู่ด้านล่างสุดในชุด

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **คุณสมบัติการพลิก**

ใน Aspose.Slides คลาส [ShapeFrame](https://reference.aspose.com/slides/th/net/aspose.slides/shapeframe/) ให้การควบคุมการทำกระจกส่องในแนวนอนและแนวตั้งของรูปร่างผ่านคุณสมบัติ `FlipH` และ `FlipV` ทั้งสองเป็นประเภท [NullableBool](https://reference.aspose.com/slides/th/net/aspose.slides/nullablebool/) ซึ่งรับค่า `True` เพื่อระบุการพลิก, `False` แสดงว่าไม่พลิก, หรือ `NotDefined` เพื่อใช้พฤติกรรมเริ่มต้น ค่าดังกล่าวสามารถเข้าถึงได้จาก [Frame](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/frame/) ของรูปร่าง  

เพื่อปรับตั้งค่าการพลิก เราสร้างอินสแตนซ์ใหม่ของ [ShapeFrame](https://reference.aspose.com/slides/th/net/aspose.slides/shapeframe/) ด้วยตำแหน่งและขนาดปัจจุบันของรูปร่าง, ค่าที่ต้องการสำหรับ `FlipH` และ `FlipV`, รวมถึงมุมการหมุน แล้วกำหนดอินสแตนซ์นี้ให้กับ [Frame](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/frame/) ของรูปร่างและบันทึกงานนำเสนอ การทำเช่นนี้จะใช้การเปลี่ยนแปลงกระจกส่องและบันทึกผลลงไฟล์เอาต์พุต  

สมมติว่าเรามีไฟล์ sample.pptx ที่สไลด์แรกมีรูปร่างเดียวกับการตั้งค่าการพลิกเริ่มต้นตามด้านล่าง  

![The shape to be flipped](shape_to_be_flipped.png)

โค้ดต่อไปนี้เรียกคืนคุณสมบัติการพลิกปัจจุบันของรูปร่างและพลิกทั้งแนวนอนและแนวตั้ง

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // ดึงค่าคุณสมบัติการพลิกแนวนอนของรูปร่าง.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // ดึงค่าคุณสมบัติการพลิกแนวตั้งของรูปร่าง.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // พลิกแนวนอน.
    NullableBool flipV = NullableBool.True; // พลิกแนวตั้ง.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The flipped shape](flipped_shape.png)

## **FAQ**

**ฉันสามารถรวมรูปร่าง (union/intersect/subtract) บนสไลด์เหมือนในโปรแกรมแก้ไขเดสก์ท็อปได้หรือไม่?**

ไม่มี API สำหรับการดำเนินการบูลีนในตัว คุณสามารถประมาณได้โดยสร้างรูปร่างขอบเขตที่ต้องการด้วยตนเอง เช่น คำนวณเรขาคณิตผลลัพธ์ (โดยใช้ [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath/)) และสร้างรูปร่างใหม่ด้วยคอนทัวร์นั้น พร้อมกับอาจลบรูปแบบเดิมออก

**ฉันจะควบคุมลำดับการซ้อนกัน (z-order) เพื่อให้รูปร่างคงอยู่บนสุดได้อย่างไร?**

เปลี่ยนลำดับการแทรก/ย้ายภายในคอลเลกชัน [shapes](https://reference.aspose.com/slides/th/net/aspose.slides/baseslide/shapes/) ของสไลด์ เพื่อผลลัพธ์ที่คาดเดาได้ ควรสรุปลำดับ z-order หลังจากทำการแก้ไขสไลด์ทั้งหมดเสร็จแล้ว

**ฉันสามารถ “ล็อค” รูปร่างเพื่อป้องกันผู้ใช้จากการแก้ไขใน PowerPoint ได้หรือไม่?**

ได้ สามารถตั้งค่า [shape-level protection flags](/slides/th/net/applying-protection-to-presentation/) (เช่น ล็อคการเลือก, การย้าย, การปรับขนาด, การแก้ไขข้อความ) หากต้องการอาจกำหนดข้อจำกัดบนมาสเตอร์หรือเลย์เอาต์ โปรดทราบว่าเป็นการป้องกันระดับ UI ไม่ใช่คุณลักษณะความปลอดภัย; หากต้องการความคุ้มครองที่แข็งแรงขึ้นควรผสานกับข้อจำกัดระดับไฟล์ เช่น คำแนะนำให้อ่านอย่างเดียวหรือรหัสผ่าน [read-only recommendations or passwords](/slides/th/net/password-protected-presentation/)