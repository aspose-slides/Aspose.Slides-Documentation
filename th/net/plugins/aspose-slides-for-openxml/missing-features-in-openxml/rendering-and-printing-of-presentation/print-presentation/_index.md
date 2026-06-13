---
title: พิมพ์งานนำเสนอ
type: docs
url: /th/net/print-the-presentation/
---
Aspose.Slides for .NET มีเมธอด overload สี่วิธีสำหรับการพิมพ์งานนำเสนอ เมธอดเหล่านี้มีความยืดหยุ่นพอที่จะพิมพ์งานนำเสนอไปยังเครื่องพิมพ์เริ่มต้นหรือเครื่องพิมพ์ใด ๆ ที่มีพร้อมการตั้งค่าที่กำหนดเอง คุณเพียงต้องเลือกเมธอดการพิมพ์ที่เหมาะสมตามความต้องการ
## **พิมพ์ไปยังเครื่องพิมพ์เริ่มต้น**
การพิมพ์งานนำเสนอไปยังเครื่องพิมพ์เริ่มต้นใน Aspose.Slides for .NET นั้นค่อนข้างง่าย ทำตามขั้นตอนต่อไปนี้เพื่อพิมพ์งานนำเสนอไปยังเครื่องพิมพ์เริ่มต้น:

- สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดงานนำเสนอที่ต้องการพิมพ์
- เรียกเมธอด Print โดยไม่มีพารามิเตอร์ตามที่ Presentation object เปิดให้

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //โหลดงานนำเสนอ

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //เรียกเมธอดพิมพ์เพื่อพิมพ์งานนำเสนอทั้งหมดไปยังเครื่องพิมพ์เริ่มต้น

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //โหลดงานนำเสนอ

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //เรียกเมธอดพิมพ์เพื่อพิมพ์งานนำเสนอทั้งหมดไปยังเครื่องพิมพ์ที่ต้องการ

    asposePresentation.Print("LaserJet1100");

``` 
## **พิมพ์ไปยังเครื่องพิมพ์เฉพาะ**
การพิมพ์งานนำเสนอไปยังเครื่องพิมพ์เฉพาะต้องระบุชื่อเครื่องพิมพ์เป็นพารามิเตอร์ให้กับเมธอด Print ของ Presentation ทำตามขั้นตอนต่อไปนี้เพื่อพิมพ์งานนำเสนอไปยังเครื่องพิมพ์ที่ต้องการ:

- สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดงานนำเสนอที่ต้องการพิมพ์
- เรียกเมธอด Print ของคลาส Presentation พร้อมชื่อเครื่องพิมพ์เป็นพารามิเตอร์ประเภทสตริง

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //โหลดงานนำเสนอ

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //เรียกเมธอดพิมพ์เพื่อพิมพ์งานนำเสนอทั้งหมดไปยังเครื่องพิมพ์ที่ต้องการ

    asposePresentation.Print("LaserJet1100");

}

``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)