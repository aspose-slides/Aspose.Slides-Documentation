---
title: สร้างสไลด์เป็นภาพ SVG
type: docs
weight: 70
url: /th/net/create-slide-as-svg-image/
---
เพื่อสร้างภาพ SVG จากสไลด์ที่ต้องการด้วย Aspose.Slides.Pptx สำหรับ .NET โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- รับอ้างอิงของสไลด์ที่ต้องการโดยใช้ ID หรือดัชนีของมัน
- รับภาพ SVG ในสตรีมหน่วยความจำ
- บันทึกสตรีมหน่วยความจำลงไฟล์
## **ตัวอย่าง**

```

 //สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //เข้าถึงสไลด์ที่สอง

   ISlide sld = pres.Slides[1];

   //สร้างอ็อบเจ็กต์ Memory Stream

   MemoryStream SvgStream = new MemoryStream();

   //สร้างภาพ SVG ของสไลด์และบันทึกใน Memory Stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //บันทึก Memory Stream ไปยังไฟล์

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **ดาวน์โหลดตัวอย่างที่ทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
สำหรับรายละเอียดเพิ่มเติม ดูที่ [แสดงสไลด์การนำเสนอเป็นภาพ SVG ใน .NET](/slides/th/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}