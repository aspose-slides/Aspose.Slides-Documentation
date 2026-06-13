---
title: ประกอบสไลด์
type: docs
weight: 10
url: /th/net/assemble-slides/
---
## **เพิ่มสไลด์ในงานนำเสนอ**
ก่อนจะพูดถึงการเพิ่มสไลด์ในไฟล์งานนำเสนอ เรามาอธิบายข้อเท็จจริงเกี่ยวกับสไลด์กันก่อน แต่ละไฟล์ PowerPoint จะมีสไลด์ Master / Layout และสไลด์ Normal อื่น ๆ หมายความว่าไฟล์งานนำเสนอมีอย่างน้อยหนึ่งสไลด์หรือมากกว่า ต้องทราบว่าไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่รองรับโดย Aspose.Slides for .NET แต่ละสไลด์มี Id ที่เป็นเอกลักษณ์และสไลด์ Normal ทั้งหมดจะจัดเรียงตามลำดับที่กำหนดโดยดัชนีเริ่มจากศูนย์

Aspose.Slides for .NET อนุญาตให้ผู้พัฒนาสามารถเพิ่มสไลด์เปล่าเข้าไปในงานนำเสนอได้ เพื่อเพิ่มสไลด์เปล่าในงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส **Presentation**
- อินสแตนซ์คลาส **SlideCollection** โดยอ้างอิงถึงคุณสมบัติ Slides (คอลเลกชันของวัตถุ Slide) ที่เปิดเผยโดยวัตถุ Presentation
- เพิ่มสไลด์เปล่าไปที่ท้ายคอลเลกชันสไลด์เนื้อหาโดยเรียกใช้เมธอด **AddEmptySlide** ของวัตถุ **SlideCollection**
- ทำงานกับสไลด์เปล่าที่เพิ่มใหม่
- สุดท้ายบันทึกไฟล์งานนำเสนอโดยใช้วัตถุ **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//สร้างอินสแตนซ์คลาส SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//เพิ่มสไลด์เปล่าไปยังคอลเลกชัน Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//บันทึกไฟล์ PPTX ไปยังดิสก์

pres.Write("EmptySlide.pptx");

``` 
## **เข้าถึงสไลด์ของงานนำเสนอ**
Aspose.Slides for .NET มีคลาส Presentation ซึ่งสามารถใช้เพื่อค้นหาและเข้าถึงสไลด์ที่ต้องการในงานนำเสนอได้

**ใช้คอลเลกชัน Slides**

คลาส **Presentation** แทนไฟล์งานนำเสนอและเปิดเผยสไลด์ทั้งหมดในไฟล์เป็นคอลเลกชัน **SlideCollection** (ซึ่งเป็นคอลเลกชันของวัตถุ **Slide**) ทั้งหมดนี้สามารถเข้าถึงได้จากคอลเลกชัน **Slides** นี้โดยใช้ดัชนีสไลด์

``` csharp

 //สร้างวัตถุ Presentation ที่แทนไฟล์งานนำเสนอ

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//เข้าถึงสไลด์โดยใช้ดัชนีสไลด์ของมัน

SlideEx slide = pres.Slides[0];

``` 
## **ลบสไลด์**
เราทราบว่าคลาส Presentation ใน **Aspose.Slides for .NET** แทนไฟล์งานนำเสนอ คลาส Presentation มี **SlideCollection** ซึ่งทำหน้าที่เป็นคลังข้อมูลของสไลด์ทั้งหมดที่เป็นส่วนหนึ่งของงานนำเสนอ ผู้พัฒนาสามารถลบสไลด์จากคอลเลกชัน Slides นี้ได้สองวิธี:

- ใช้การอ้างอิงสไลด์
- ใช้ดัชนีสไลด์

**ใช้การอ้างอิงสไลด์**

เพื่อให้ลบสไลด์โดยใช้การอ้างอิง โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับการอ้างอิงของสไลด์โดยใช้ Id หรือ Index ของสไลด์
- ลบสไลด์ที่อ้างอิงจากงานนำเสนอ
- บันทึกไฟล์งานนำเสนอที่แก้ไขแล้ว

``` csharp

 //สร้างวัตถุ Presentation ที่แทนไฟล์งานนำเสนอ

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//เข้าถึงสไลด์โดยใช้ดัชนีในคอลเลกชันสไลด์

SlideEx slide = pres.Slides[0];

//ลบสไลด์โดยใช้การอ้างอิงของมัน

pres.Slides.Remove(slide);

//เขียนไฟล์งานนำเสนอ

pres.Write("modified.pptx");

``` 
## **เปลี่ยนตำแหน่งของสไลด์**
การเปลี่ยนตำแหน่งของสไลด์ในงานนำเสนอทำได้ง่ายมาก เพียงทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับการอ้างอิงของสไลด์โดยใช้ Index ของสไลด์
- เปลี่ยนค่า SlideNumber ของสไลด์ที่อ้างอิง
- บันทึกไฟล์งานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้เปลี่ยนตำแหน่งของสไลด์ (ซึ่งอยู่ที่ตำแหน่งดัชนีศูนย์ 1) ของงานนำเสนอเป็นดัชนี 1 (ตำแหน่ง 2)

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//สร้างอินสแตนซ์คลาส SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //เพิ่มสไลด์เปล่าไปยังคอลเลกชัน Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//บันทึกไฟล์ PPTX ไปยังดิสก์

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//สร้างวัตถุ Presentation ที่แทนไฟล์งานนำเสนอ

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//เข้าถึงสไลด์โดยใช้ดัชนีสไลด์ของมัน

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//สร้างวัตถุ Presentation ที่แทนไฟล์งานนำเสนอ

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//เข้าถึงสไลด์โดยใช้ดัชนีในคอลเลกชันสไลด์

ISlide slide = pres.Slides[0];

//ลบสไลด์โดยใช้การอ้างอิงของมัน

pres.Slides.Remove(slide);

//เขียนไฟล์งานนำเสนอ

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//สร้างอินสแตนซ์คลาส Presentation เพื่อโหลดไฟล์งานนำเสนอต้นฉบับ

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //รับสไลด์ที่ต้องการเปลี่ยนตำแหน่ง

    ISlide sld = pres.Slides[0];

    //กำหนดตำแหน่งใหม่ให้สไลด์

    sld.SlideNumber = 2;

    //บันทึกงานนำเสนอไปยังดิสก์

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)