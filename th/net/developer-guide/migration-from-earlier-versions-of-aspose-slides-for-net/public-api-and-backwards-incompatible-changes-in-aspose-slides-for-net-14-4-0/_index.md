---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.4.0
linktitle: Aspose.Slides สำหรับ .NET 14.4.0
type: docs
weight: 60
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้แตกต่างใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
## **API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลัง**
### **เพิ่มอินเทอร์เฟซ, คลาส, เมธอดและพร็อพเพอร์ตี**
#### **พร็อพเพอร์ตี Aspose.Slides.ILayoutSlide.HasDependingSlides ได้ถูกเพิ่ม**
พร็อพเพอร์ตี Aspose.Slides.ILayoutSlide.HasDependingSlides คืนค่า true หากมีสไลด์อย่างน้อยหนึ่งสไลด์ที่พึ่งพา layout slide นี้ ตัวอย่างเช่น:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **เมธอด Aspose.Slides.ILayoutSlide.Remove()**
เมธอด Aspose.Slides.ILayoutSlide.Remove() ช่วยให้คุณลบเลเอาท์ออกจากการพรีเซนเทชั่นด้วยโค้ดเพียงเล็กน้อย ตัวอย่างเช่น:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **เมธอด Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide)**
เมธอด Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) ช่วยให้คุณลบเลเอาท์ออกจากคอลเลกชัน ตัวอย่างโค้ด:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

หรือ

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
เมธอด Aspose.Slides.ILayoutSlideCollection.RemoveUnused() ช่วยให้คุณลบเลเอาท์สไลด์ที่ไม่ได้ใช้ (เลเอาท์สไลด์ที่ HasDependingSlides เป็น false) ตัวอย่างโค้ด:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

หรือ

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **พร็อพเพอร์ตี Aspose.Slides.IMasterSlide.HasDependingSlides**
พร็อพเพอร์ตี Aspose.Slides.IMasterSlide.HasDependingSlides คืนค่า true หากมีสไลด์อย่างน้อยหนึ่งสไลด์ที่พึ่งพา master slide นี้ ตัวอย่างเช่น:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **เมธอด Aspose.Slides.ISlide.Remove()**
เมธอด Aspose.Slides.ISlide.Remove() ช่วยให้คุณลบสไลด์ออกจากการพรีเซนเทชั่นด้วยโค้ดเพียงเล็กน้อย ตัวอย่างเช่น:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
พร็อพเพอร์ตี Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat คืนค่า IFillFormat สำหรับบูลเล็ตของโหนด SmartArt หากเลเอาท์มีบูลเล็ต สามารถใช้ตั้งค่ารูปภาพบูลเล็ตได้

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **พร็อพเพอร์ตี Aspose.Slides.SmartArt.ISmartArtNode.Level**
พร็อพเพอร์ตี Aspose.Slides.SmartArt.ISmartArtNode.Level คืนค่าระดับการซ้อนของโหนด SmartArt

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **พร็อพเพอร์ตี Aspose.Slides.SmartArt.ISmartArtNode.Position**
พร็อพเพอร์ตี Aspose.Slides.SmartArt.ISmartArtNode.Position คืนค่าตำแหน่งของโหนดในบรรพบุรุษของมัน

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **เมธอด Aspose.Slides.SmartArt.ISmartArtNode.Remove() ได้ถูกเพิ่ม**
เมธอด Aspose.Slides.SmartArt.ISmartArtNode.Remove() ช่วยให้สามารถลบโหนดออกจากไดอะแกรมได้

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **อินเทอร์เฟซ IGlobalLayoutSlideCollection และคลาส GlobalLayoutSlideCollection**
อินเทอร์เฟซ IGlobalLayoutSlideCollection และคลาส GlobalLayoutSlideCollection ถูกเพิ่มเข้าในเนมสเปซ Aspose.Slides

คลาส GlobalLayoutSlideCollection implements อินเทอร์เฟซ IGlobalLayoutSlideCollection

อินเทอร์เฟซ IGlobalLayoutSlideCollection แสดงคอลเลกชันของเลเอาท์สไลด์ทั้งหมดในพรีเซนเทชั่น property IPresentation.LayoutSlides มีประเภท IGlobalLayoutSlideCollection IGlobalLayoutSlideCollection สืบทอดจาก ILayoutSlideCollection พร้อมเมธอดสำหรับเพิ่มและโคลนเลเอาท์สไลด์ในบริบทของการรวมคอลเลกชันเลเอาท์ของแต่ละ master:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – สามารถใช้เพื่อเพิ่มสำเนาของเลเอาท์สไลด์ที่ระบุลงในพรีเซนเทชั่น เมธอดนี้รักษาการฟอร์แมตของแหล่งที่มา (เมื่อโคลนเลเอาท์ระหว่างพรีเซนเทชั่นที่ต่างกัน master ของเลเอาท์ก็อาจถูกโคลนด้วย โดยมีรีจิสทรีภายในใช้ติดตาม master ที่ถูกโคลนอัตโนมัติเพื่อป้องกันการสร้างสำเนาหลายครั้งของ master สไลด์เดิม)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – ใช้เพื่อเพิ่มสำเนาของเลเอาท์สไลด์ที่ระบุลงในพรีเซนเทชั่นเลเอาท์ใหม่จะถูกเชื่อมโยงกับ master ที่กำหนดในพรีเซนเทชั่นปลายทาง ตัวเลือกนี้เทียบเท่าการคัดลอกหรือวางโดยใช้ตัวเลือก **Use Destination Theme** ใน Microsoft PowerPoint
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – ใช้เพื่อเพิ่มเลเอาท์สไลด์ใหม่ลงในพรีเซนเทชั่น ประเภทเลเอาท์ที่รองรับ: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom ชื่อเลเอาท์สามารถสร้างอัตโนมัติได้ เลเอาท์ประเภท SlideLayoutType.Custom จะไม่มี placeholder และไม่มี shape วิธีการที่คล้ายกับเมธอดนี้คือ IMasterLayoutSlideCollection.Add(SlideLayoutType, string) ที่เข้าถึงได้ผ่าน property IMasterSlide.LayoutSlides
#### **อินเทอร์เฟซ IMasterLayoutSlideCollection และคลาส MasterLayoutSlideCollection**
อินเทอร์เฟซ IMasterLayoutSlideCollection และคลาส MasterLayoutSlideCollection ถูกเพิ่มเข้าในเนมสเปซ Aspose.Slides คลาส MasterLayoutSlideCollection implements อินเทอร์เฟซ IMasterLayoutSlideCollection

อินเทอร์เฟซ IMasterLayoutSlideCollection แสดงคอลเลกชันของเลเอาท์สไลด์ทั้งหมดของ master ที่กำหนด มันสืบทอดจาก ILayoutSlideCollection พร้อมเมธอดสำหรับเพิ่ม, แทรก, ลบหรือโคลนเลเอาท์สไลด์ในบริบทของคอลเลกชันเลเอาท์ของ master แต่ละอัน:

``` csharp

 // ลายเซ็นเมธอด:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// ตัวอย่างโค้ดที่แนบสำเนาของ sourceLayout ไปยัง destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

เมธอดนี้สามารถใช้เพื่อเพิ่มสำเนาของเลเอาท์สไลด์ที่ระบุไปยังตำแหน่งสุดท้ายของคอลเลกชัน เลเอาท์ใหม่จะเชื่อมโยงกับ master พาเรนต์ของคอลเลกชันเลเอาท์สไลด์นี้ ดังนั้นจึงเทียบเท่าการคัดลอกหรือวางโดยใช้ตัวเลือก **Use Destination Theme** ใน PowerPoint วิธีการที่คล้ายกับเมธอดนี้คือ IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) ที่เข้าถึงได้ผ่าน property IPresentation.LayoutSlides

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – ใช้เพื่อแทรกสำเนาของเลเอาท์สไลด์ที่ระบุลงในตำแหน่งที่กำหนดของคอลเลกชัน เลเอาท์ใหม่จะเชื่อมโยงกับ master พาเรนต์ของคอลเลกชันเลเอาท์สไลด์นี้ ดังนั้นจึงเทียบเท่าการคัดลอกและวางโดยใช้ตัวเลือก **Use Destination Theme** ใน PowerPoint
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – ใช้เพื่อเพิ่มหรือแทรกเลเอาท์สไลด์ใหม่ ประเภทเลเอาท์ที่รองรับ: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom ชื่อเลเอาท์สามารถสร้างอัตโนมัติได้ เลเอาท์ประเภท SlideLayoutType.Custom จะไม่มี placeholder และไม่มี shape วิธีการที่คล้ายกับเมธอดนี้คือ IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) ที่เข้าถึงได้ผ่าน property IPresentation.LayoutSlides
- void RemoveAt(int index); – ใช้เพื่อลบเลเอาท์ที่ตำแหน่ง index ของคอลเลกชัน
- void Reorder(int index, ILayoutSlide layoutSlide); – ใช้เพื่อย้ายเลเอาท์สไลด์ในคอลเลกชันไปยังตำแหน่งที่กำหนด
### **เมธอดและพร็อพเพอร์ตีที่เปลี่ยนแปลง**
#### **ลายเซ็นของเมธอด Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide)**
ลายเซ็นของเมธอด ISlideCollection:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

ตอนนี้ถูกทำให้ล้าสมัยและถูกแทนที่ด้วยลายเซ็น

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

พารามิเตอร์ allowCloneMissingLayout ระบุว่าจะทำอย่างไรหากไม่มีเลเอาท์ที่เหมาะสมใน destMaster สำหรับสไลด์ (ที่ถูกโคลน) เลเอาท์ที่เหมาะสมคือเลเอาท์ที่มีประเภทหรือชื่อเดียวกับเลเอาท์ของสไลด์ต้นฉบับ หากไม่มีเลเอาท์ที่เหมาะสมใน master ที่ระบุ เลเอาท์ของสไลด์ต้นฉบับจะถูกโคลน (ถ้า allowCloneMissingLayout เป็น true) หรือจะโยน PptxEditException (ถ้า allowCloneMissingLayout เป็น false)

การเรียกเมธอดที่ล้าสมัยเช่น

AddClone(sourceSlide, destMaster);

ถือว่า allowCloneMissingLayout มีค่าเป็น false (หมายความว่าจะโยน PptxEditException หากไม่มีเลเอาท์ที่เหมาะสม) การเรียกที่ทำงานเท่าเดิมโดยใช้ลายเซ็นใหม่เป็นดังนี้:
AddClone(sourceSlide, destMaster, false);

หากต้องการให้เลเอาท์ที่ขาดหายถูกโคลนอัตโนมัติเพียงการโยน PptxEditException ให้ส่งพารามิเตอร์ allowCloneMissingLayout เป็น true

เดียวกันนี้ใช้กับเมธอด ISlideCollection:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

ก็ถูกทำให้ล้าสมัยและแทนที่ด้วยลายเซ็น

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **ประเภทของพร็อพเพอร์ตี Aspose.Slides.IMasterSlide.LayoutSlides**
ประเภทของพร็อพเพอร์ตี Aspose.Slides.IMasterSlide.LayoutSlides ถูกเปลี่ยนจาก ILayoutSlideCollection เป็นอินเทอร์เฟซ IMasterLayoutSlideCollection ใหม่ IMasterLayoutSlideCollection สืบทอดจาก ILayoutSlideCollection ดังนั้นโค้ดที่มีอยู่เดิมไม่ต้องปรับเปลี่ยน
#### **ประเภทของพร็อพเพอร์ตี Aspose.Slides.IPresentation.LayoutSlides ได้ถูกเปลี่ยน**
ประเภทของพร็อพเพอร์ตี Aspose.Slides.IPresentation.LayoutSlides ถูกเปลี่ยนจาก ILayoutSlideCollection เป็นอินเทอร์เฟซ IGlobalLayoutSlideCollection ใหม่ IGlobalLayoutSlideCollection สืบทอดจาก ILayoutSlideCollection ดังนั้นโค้ดที่มีอยู่เดิมไม่ต้องปรับเปลี่ยน