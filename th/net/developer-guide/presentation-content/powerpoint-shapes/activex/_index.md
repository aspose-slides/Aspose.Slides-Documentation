---
title: "จัดการ ActiveX Controls ในงานนำเสนอด้วย .NET"
linktitle: "ActiveX"
type: docs
weight: 80
url: /th/net/activex/
keywords:
  - ActiveX
  - ควบคุม ActiveX
  - จัดการ ActiveX
  - เพิ่ม ActiveX
  - แก้ไข ActiveX
  - เครื่องเล่นสื่อ
  - PowerPoint
  - งานนำเสนอ
  - .NET
  - C#
  - Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides สำหรับ .NET ใช้ ActiveX เพื่อทำให้การทำงานของ PowerPoint เป็นอัตโนมัติและเพิ่มประสิทธิภาพอย่างไร ซึ่งให้ผู้พัฒนามีการควบคุมสไลด์อย่างมีประสิทธิภาพ"
---
## **บทนำ**

ActiveX controls ถูกใช้ในงานนำเสนอ. Aspose.Slides for .NET ให้คุณจัดการ ActiveX controls, แต่การจัดการพวกมันค่อนข้างซับซ้อนและแตกต่างจากรูปทรงปกติในงานนำเสนอ. ตั้งแต่ Aspose.Slides for .NET 6.9.0, คอมโพเนนต์นี้รองรับการจัดการ ActiveX controls. ในขณะนี้, คุณสามารถเข้าถึง ActiveX control ที่ได้เพิ่มไว้ในงานนำเสนอและแก้ไขหรือทำลายมันโดยใช้คุณสมบัติต่างๆ ของมัน. จำไว้ว่า ActiveX controls ไม่ใช่ shape และไม่ได้อยู่ใน IShapeCollection ของงานนำเสนอแต่เป็นส่วนของ IControlCollection แยกออกมา. บทความนี้จะแสดงวิธีการทำงานกับพวกมัน.

## **แก้ไข ActiveX Controls**

1. สร้างอินสแตนซ์ของคลาส Presentation และโหลดงานนำเสนอที่มี ActiveX controls อยู่ในนั้น.  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน.  
3. เข้าถึง ActiveX controls ในสไลด์โดยการเรียก IControlCollection.  
4. เข้าถึง ActiveX control TextBox1 ด้วยวัตถุ ControlEx.  
5. เปลี่ยนคุณสมบัติต่างๆ ของ ActiveX control TextBox1 รวมถึงข้อความ, ฟอนต์, ความสูงของฟอนต์ และตำแหน่งเฟรม.  
6. เข้าถึงการควบคุมที่สองที่ชื่อ CommandButton1.  
7. เปลี่ยนคำบรรยายของปุ่ม, ฟอนต์ และตำแหน่ง.  
8. ย้ายตำแหน่งของเฟรม ActiveX controls.  
9. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.  

โค้ดสแนปเพ็ตด้านล่างจะอัปเดต ActiveX controls บนสไลด์ของงานนำเสนอตามสไลด์ที่แสดงด้านล่าง.

```c#
// กำลังเข้าถึงงานนำเสนอที่มี ActiveX controls
Presentation presentation = new Presentation("ActiveX.pptm");

// กำลังเข้าถึงสไลด์แรกในงานนำเสนอ
ISlide slide = presentation.Slides[0];

// เปลี่ยนข้อความใน TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // เปลี่ยนภาพแทน. PowerPoint จะเปลี่ยนภาพนี้ระหว่างการเปิดใช้งาน ActiveX, ดังนั้นบางครั้งอาจปล่อยภาพไว้โดยไม่เปลี่ยนแปลงก็ได้.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// เปลี่ยนคำบรรยายของปุ่ม
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // เปลี่ยนภาพแทน
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// ย้ายเฟรม ActiveX ลง 100 พิกเซล
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// บันทึกงานนำเสนอที่มี ActiveX Controls ที่แก้ไขแล้ว
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// กำลังลบคอนโทรล
slide.Controls.Clear();

// บันทึกงานนำเสนอที่ลบคอนโทรล ActiveX แล้ว
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **เพิ่ม ActiveX Media Player Control**

เพื่​​อเพิ่ม ActiveX Media Player control, โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส Presentation และโหลดตัวอย่างงานนำเสนอที่มี Media Player ActiveX controls อยู่ในนั้น.  
2. สร้างอินสแตนซ์ของคลาส Presentation เป้าหมายและสร้างอินสแตนซ์งานนำเสนอเปล่า.  
3. คัดลอกสไลด์ที่มี Media Player ActiveX control จากงานนำเสนอเทมเพลตไปยังงานนำเสนอเป้าหมาย.  
4. เข้าถึงสไลด์ที่คัดลอกในงานนำเสนอเป้าหมาย.  
5. เข้าถึง ActiveX controls ในสไลด์โดยการเรียก IControlCollection.  
6. เข้าถึง Media Player ActiveX control และตั้งค่าที่อยู่ของวิดีโอนโดยใช้คุณสมบัติของมัน.  
7. บันทึกงานนำเสนอเป็นไฟล์ PPTX.  

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation presentation = new Presentation("template.pptx");

// สร้างอินสแตนซ์งานนำเสนอเปล่า
Presentation newPresentation = new Presentation();

// ลบสไลด์เริ่มต้น
newPresentation.Slides.RemoveAt(0);

// คัดลอกสไลด์ที่มี Media Player ActiveX Control
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// เข้าถึง Media Player ActiveX control และตั้งค่าที่อยู่ของวิดีโอ
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// บันทึกงานนำเสนอ
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**Aspose.Slides เก็บรักษา ActiveX controls ไว้หรือไม่เมื่อทำการอ่านและบันทึกใหม่หากไม่สามารถเรียกใช้ใน .NET runtime ได้?**  
ใช่. Aspose.Slides ถือว่าพวกมันเป็นส่วนหนึ่งของงานนำเสนอและสามารถอ่าน/แก้ไขคุณสมบัติและเฟรมของมันได้; ไม่จำเป็นต้องเรียกใช้คontrols เองเพื่อเก็บรักษาไว้.

**ActiveX controls แตกต่างจาก OLE objects ในงานนำเสนออย่างไร?**  
ActiveX controls เป็นคontrol ที่โต้ตอบได้และจัดการได้ (เช่น ปุ่ม, กล่องข้อความ, ตัวเล่นสื่อ), ในขณะที่ [OLE](/slides/th/net/manage-ole/) หมายถึงวัตถุแอปพลิเคชันแบบฝัง (เช่น แผ่นงาน Excel). พวกเขาถูกเก็บและจัดการต่างกันและมีโมเดลคุณสมบัตที่ต่างกัน.

**เหตุการณ์ ActiveX และแมโคร VBA ทำงานได้หรือไม่หากไฟล์ถูกแก้ไขโดย Aspose.Slides?**  
Aspose.Slides เก็บรักษา markup และ metadata ที่มีอยู่; อย่างไรก็ตาม เหตุการณ์และแมโครจะทำงานเฉพาะใน PowerPoint บน Windows เมื่อความปลอดภัยอนุญาตเท่านั้น. ไลบรารีนี้ไม่ได้เรียกใช้ VBA.