---
title: จัดการ Presentation BLOBs ใน .NET เพื่อการใช้หน่วยความจำที่มีประสิทธิภาพ
linktitle: จัดการ BLOB
type: docs
weight: 10
url: /th/net/manage-blob/
keywords:
- วัตถุขนาดใหญ่
- รายการขนาดใหญ่
- ไฟล์ขนาดใหญ่
- เพิ่ม BLOB
- ส่งออก BLOB
- เพิ่มรูปภาพเป็น BLOB
- ลดหน่วยความจำ
- การใช้หน่วยความจำ
- พรีเซนเทชันขนาดใหญ่
- ไฟล์ชั่วคราว
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "จัดการข้อมูล BLOB ใน Aspose.Slides สำหรับ .NET เพื่อทำให้การดำเนินการไฟล์ PowerPoint และ OpenDocument มีประสิทธิภาพมากขึ้นในการจัดการพรีเซนเทชัน."
---
## **ภาพรวม**

Aspose.Slides มีการจัดการแบบใช้ BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในงานพรีเซนเทชัน เพื่อช่วยลดการใช้หน่วยความจำเมื่อทำงานกับรูปภาพขนาดใหญ่, เสียง, วิดีโอ และไฟล์พรีเซนเทชัน

บทความนี้แสดงวิธีใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ลงในพรีเซนเทชัน ส่งออกสื่อขนาดใหญ่จากพรีเซนเทชัน และโหลดพรีเซนเทชันขนาดใหญ่ได้อย่างมีประสิทธิภาพมากขึ้น นอกจากนี้ยังอธิบายวิธีการใช้ไฟล์ชั่วคราวระหว่างการประมวลผลและวิธีเปลี่ยนโฟลเดอร์ที่ใช้เก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) โดยทั่วไปคือรายการขนาดใหญ่ (ภาพถ่าย, พรีเซนเทชัน, เอกสาร หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for .NET อนุญาตให้ใช้ BLOB สำหรับวัตถุต่าง ๆ เพื่อลดการใช้หน่วยความจำเมื่อมีไฟล์ขนาดใหญ่เข้ามาเกี่ยวข้อง

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ผ่าน BLOB ไปยังพรีเซนเทชัน**

[Aspose.Slides](/slides/th/net/) for .NET อนุญาตให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่ใช้ BLOB เพื่อลดการใช้หน่วยความจำ

โค้ดนี้ใน C# แสดงวิธีเพิ่มไฟล์วิดีโอขนาดใหญ่ผ่านกระบวนการ BLOB ไปยังพรีเซนเทชัน:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// สร้างพรีเซนเทชันใหม่ที่วิดีโอจะถูกเพิ่มเข้ามา
using (Presentation pres = new Presentation())
{
        using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
        {
                // ให้เราเพิ่มวิดีโอลงในพรีเซนเทชัน - เราเลือกพฤติกรรม KeepLocked เพราะเราต้องการ
                // ไม่ต้องการเข้าถึงไฟล์ "veryLargeVideo.avi"
                IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
                pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

                // บันทึกพรีเซนเทชัน ในขณะที่พรีเซนเทชันขนาดใหญ่ถูกสร้างออกมา การใช้หน่วยความจำ
                // ยังคงต่ำตลอดอายุการทำงานของอ็อบเจกต์ pres 
                pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
        }
}
```

### **ส่งออกไฟล์ขนาดใหญ่ผ่าน BLOB จากพรีเซนเทชัน**

Aspose.Slides for .NET อนุญาตให้คุณส่งออกไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่ใช้ BLOB จากพรีเซนเทชัน ตัวอย่างเช่น คุณอาจต้องการดึงไฟล์สื่อขนาดใหญ่จากพรีเซนเทชันโดยไม่ต้องให้ไฟล์นั้นโหลดเข้าสู่หน่วยความจำของคอมพิวเตอร์ การส่งออกไฟล์ผ่านกระบวนการ BLOB จะช่วยให้การใช้หน่วยความจำคงที่ต่ำ

โค้ดนี้ใน C# แสดงการทำงานตามที่อธิบายไว้:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// ป้องกันไฟล์ต้นทางและไม่โหลดลงหน่วยความจำ
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// สร้างอินสแตนซ์ Presentation และล็อกไฟล์ "hugePresentationWithAudiosAndVideos.pptx"
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// ให้เราบันทึกวิดีโอแต่ละคลิปลงไฟล์ เพื่อป้องกันการใช้หน่วยความจำสูง เราต้องใช้บัฟเฟอร์ที่ใช้
	// เพื่อถ่ายโอนข้อมูลจากสตรีมวิดีโอของพรีเซนเทชันไปยังสตรีมของไฟล์วิดีโอที่สร้างใหม่
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// เปิดสตรีมวิดีโอของพรีเซนเทชัน โปรดทราบว่าเราตั้งใจหลีกเลี่ยงการเข้าถึงคุณสมบัติต่าง ๆ
		// เช่น video.BinaryData - เพราะคุณสมบัตินี้คืนอาร์เรย์ไบต์ที่มีวิดีโอเต็มรูปแบบ ซึ่งต่อมาจะ
		// ทำให้ไบต์ถูกโหลดเข้าสู่หน่วยความจำ เราใช้ video.GetStream ซึ่งจะคืนค่า Stream - และไม่
		//  ต้องการให้เราต้องโหลดวิดีโอทั้งหมดเข้าสู่หน่วยความจำ.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// การใช้หน่วยความจำจะคงต่ำไม่ว่าขนาดของวิดีโอหรือพรีเซนเทชันจะเป็นเท่าใด
	}

	// หากจำเป็น คุณสามารถใช้ขั้นตอนเดียวกันสำหรับไฟล์เสียง. 
}
```

### **เพิ่มรูปภาพเป็น BLOB ไปยังพรีเซนเทชัน**

ด้วยวิธีการจากอินเทอร์เฟซ [**IImageCollection**](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) และคลาส [**ImageCollection**](https://reference.aspose.com/slides/th/net/aspose.slides/imagecollection) คุณสามารถเพิ่มรูปภาพขนาดใหญ่เป็นสตรีมเพื่อให้ถูกจัดการเป็น BLOB

โค้ดนี้ใน C# แสดงวิธีเพิ่มรูปภาพขนาดใหญ่ผ่านกระบวนการ BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// สร้างพรีเซนเทชันใหม่ที่ภาพจะถูกเพิ่มเข้าไป.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// ให้เราเพิ่มรูปภาพลงในพรีเซนเทชัน - เราเลือกพฤติกรรม KeepLocked เพราะเรา
		// ไม่ได้ตั้งใจเข้าถึงไฟล์ "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// บันทึกพรีเซนเทชัน ขณะพรีเซนเทชันขนาดใหญ่ถูกสร้างออกมา การใช้หน่วยความจำ 
		// ยังคงต่ำตลอดอายุการทำงานของอ็อบเจกต์ pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **หน่วยความจำและพรีเซนเทชันขนาดใหญ่**

โดยทั่วไป การโหลดพรีเซนเทชันขนาดใหญ่ต้องการหน่วยความจำชั่วคราวจำนวนมาก เนื้อหาทั้งหมดของพรีเซนเทชันจะถูกโหลดเข้าสู่หน่วยความจำและไฟล์ต้นฉบับ (ที่พรีเซนเทชันถูกโหลดจาก) จะไม่ถูกใช้อีกต่อไป

พิจารณาพรีเซนเทชัน PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานสำหรับการโหลดพรีเซนเทชันระบุในโค้ด C# นี้:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

แต่วิธีนี้ใช้หน่วยความจำชั่วคราวประมาณ 1.6 GB

### **โหลดพรีเซนเทชันขนาดใหญ่เป็น BLOB**

ผ่านกระบวนการที่ใช้ BLOB คุณสามารถโหลดพรีเซนเทชันขนาดใหญ่โดยใช้หน่วยความจำน้อย โค้ด C# นี้แสดงการนำ BLOB ไปใช้ในการโหลดไฟล์พรีเซนเทชันขนาดใหญ่ (large.pptx):

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **เปลี่ยนโฟลเดอร์สำหรับไฟล์ชั่วคราว**

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้น หากต้องการให้ไฟล์ชั่วคราวเก็บไว้ในโฟลเดอร์อื่น คุณสามารถเปลี่ยนการตั้งค่าโดยใช้ `TempFilesRootPath`:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
เมื่อคุณใช้ `TempFilesRootPath` Aspose.Slides จะไม่สร้างโฟลเดอร์สำหรับเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง
{{% /alert %}}

### **ทำลายออบเจ็กต์ Presentation เพื่อลดการใช้หน่วยความจำ**

เมื่อประมวลผลพรีเซนเทชันขนาดใหญ่ ควรตรวจสอบให้แน่ใจว่าอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ถูกทำลายอย่างถูกต้องเพื่อให้หน่วยความจำที่ครอบครองถูกปล่อยคืน วิธีที่แนะนำคือใช้คำสั่งหรือการประกาศ `using` ตามที่แสดงในตัวอย่างข้างต้น; มันจะทำลายพรีเซนเทชันโดยอัตโนมัติและคืนทรัพยากรที่ไม่ได้จัดการเมื่อบล็อกสิ้นสุด

หากคุณสร้างพรีเซนเทชันโดยไม่ใช้บล็อก `using` ให้เรียก `Dispose()` อย่างชัดเจนหลังจากเสร็จสิ้นการใช้

```cs
Presentation presentation = new Presentation("large.pptx");

// ...ประมวลผลพรีเซนเทชัน...
presentation.Save("large.pdf", SaveFormat.Pdf);

// ปลดปล่อยทรัพยากรโดยเจตนา.
presentation.Dispose();
```

## **FAQ**

**ข้อมูลใดในพรีเซนเทชัน Aspose.Slides ที่ถูกจัดการเป็น BLOB และถูกควบคุมโดยตัวเลือก BLOB?**

วัตถุไบนารีขนาดใหญ่เช่นรูปภาพ, เสียง, และวิดีโอจะถูกจัดการเป็น BLOB ไฟล์พรีเซนเทชันทั้งหมดก็รวมถึงการจัดการ BLOB เมื่อโหลดหรือบันทึก วัตถุเหล่านี้อยู่ภายใต้นโยบาย BLOB ที่ช่วยให้คุณจัดการการใช้หน่วยความจำและสลับไปยังไฟล์ชั่วคราวเมื่อจำเป็น

**ฉันตั้งค่ากฎการจัดการ BLOB ระหว่างการโหลดพรีเซนเทชันได้ที่ไหน?**

ใช้ [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) ร่วมกับ [BlobManagementOptions](https://reference.aspose.com/slides/th/net/aspose.slides/blobmanagementoptions/) ที่นั่นคุณสามารถกำหนดขีดจำกัดหน่วยความจำสำหรับ BLOB, เปิดหรือปิดการใช้ไฟล์ชั่วคราว, ระบุเส้นทางรากของไฟล์ชั่วคราว, และเลือกพฤติกรรมการล็อกแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และทำอย่างไรจึงจะสมดุลระหว่างความเร็วและหน่วยความจำ?**

ใช่ การเก็บ BLOB ในหน่วยความจำทำให้ความเร็วสูงสุดแต่ใช้ RAM มากขึ้น; การลดขีดจำกัดหน่วยความจำจะย้ายงานไปที่ไฟล์ชั่วคราว ลด RAM แต่เพิ่มการ I/O ปรับค่าเกณฑ์ [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/th/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) ให้เหมาะกับภาระงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดพรีเซนเทชันที่ใหญ่มาก (เช่นหลายกิกะไบต์) หรือไม่?**

ใช่ [BlobManagementOptions](https://reference.aspose.com/slides/th/net/aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์เช่นนั้น: การเปิดไฟล์ชั่วคราวและการล็อกแหล่งข้อมูลช่วยลดการใช้ RAM สูงสุดและทำให้การประมวลผลพรีเซนเทชันขนาดใหญ่อยู่ในระดับที่เสถียร

**ฉันสามารถใช้แนวทาง BLOB เมื่อโหลดจากสตรีมแทนไฟล์บนดิสก์ได้หรือไม่?**

ได้ โดยกฎเดียวกันจะใช้กับสตรีม: อินสแตนซ์พรีเซนเทชันสามารถเป็นเจ้าของและล็อกสตรีมอินพุต (ตามโหมดการล็อกที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่อเปิดใช้งาน ทำให้การใช้หน่วยความจำคาดเดาได้ตลอดการประมวลผล