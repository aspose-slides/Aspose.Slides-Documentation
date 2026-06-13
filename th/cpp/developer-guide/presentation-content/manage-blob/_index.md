---
title: จัดการ Presentation BLOBs ใน C++ เพื่อการใช้หน่วยความจำที่มีประสิทธิภาพ
linktitle: จัดการ BLOB
type: docs
weight: 10
url: /th/cpp/manage-blob/
keywords:
- ออบเจกต์ขนาดใหญ่
- รายการขนาดใหญ่
- ไฟล์ขนาดใหญ่
- เพิ่ม BLOB
- ส่งออก BLOB
- เพิ่มภาพเป็น BLOB
- ลดหน่วยความจำ
- การใช้หน่วยความจำ
- พรีเซนเทชั่นขนาดใหญ่
- ไฟล์ชั่วคราว
- PowerPoint
- OpenDocument
- พรีเซนเทชั่น
- C++
- Aspose.Slides
description: "จัดการข้อมูล BLOB ใน Aspose.Slides สำหรับ C++ เพื่อทำให้การดำเนินการไฟล์ PowerPoint และ OpenDocument มีประสิทธิภาพในการจัดการพรีเซนเทชั่น"
---
## **ภาพรวม**

Aspose.Slides ให้การจัดการแบบอิง BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในพรีเซนเทชั่นเพื่อช่วยลดการใช้หน่วยความจำเมื่อทำงานกับภาพขนาดใหญ่, เสียง, วิดีโอ, และไฟล์พรีเซนเทชั่น

บทความนี้แสดงวิธีใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ไปยังพรีเซนเทชั่น, ส่งออกสื่อขนาดใหญ่จากพรีเซนเทชั่น, และโหลดพรีเซนเทชั่นขนาดใหญ่อย่างมีประสิทธิภาพมากขึ้น นอกจากนี้ยังอธิบายวิธีใช้ไฟล์ชั่วคราวระหว่างการประมวลผลและวิธีเปลี่ยนโฟลเดอร์ที่ใช้เก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) มักเป็นรายการขนาดใหญ่ (ภาพ, พรีเซนเทชั่น, เอกสาร, หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for C++ อนุญาตให้คุณใช้ BLOB สำหรับอ็อบเจกต์ในวิธีที่ลดการใช้หน่วยความจำเมื่อไฟล์ขนาดใหญ่เข้ามาเกี่ยวข้อง

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ผ่าน BLOB ไปยังพรีเซนเทชั่น**

[Aspose.Slides](/slides/th/cpp/) for C++ อนุญาตให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB เพื่อลดการใช้หน่วยความจำ

โค้ด C++ นี้แสดงวิธีเพิ่มไฟล์วิดีโอขนาดใหญ่ผ่านกระบวนการ BLOB ไปยังพรีเซนเทชั่น:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// สร้างพรีเซนเทชั่นใหม่ที่จะเพิ่มวิดีโอลงไป
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// เราจะเพิ่มวิดีโอลงพรีเซนเทชั่น - เราเลือกพฤติกรรม KeepLocked เนื่องจากเราต้องการ
// ไม่ต้องการเข้าถึงไฟล์ "veryLargeVideo.avi" .
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// บันทึกพรีเซนเทชั่น ระหว่างที่พรีเซนเทชั่นขนาดใหญ่ถูกส่งออก การใช้หน่วยความจำ
// คงต่ำตลอดวงจรอายุของอ็อบเจกต์ pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **ส่งออกไฟล์ขนาดใหญ่ผ่าน BLOB จากพรีเซนเทชั่น**

Aspose.Slides for C++ อนุญาตให้คุณส่งออกไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB จากพรีเซนเทชั่น ตัวอย่างเช่น คุณอาจต้องการแยกไฟล์สื่อขนาดใหญ่จากพรีเซนเทชั่นแต่ไม่ต้องการให้ไฟล์นั้นโหลดเข้าสู่หน่วยความจำของคอมพิวเตอร์ การส่งออกไฟล์ผ่านกระบวนการ BLOB จะช่วยให้การใช้หน่วยความจำต่ำลง

โค้ด C++ นี้สาธิตการดำเนินการที่อธิบายไว้:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Creates a Presentation's instance, locks the "hugePresentationWithAudiosAndVideos.pptx" file.
auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
// to transfer the data from the presentation's video stream to a stream for a newly created video file.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Opens the presentation video stream. Please, note that we intentionally avoided accessing methods
	// like video->get_BinaryData - because this method returns a byte array containing a full video, which then
	// causes bytes to be loaded into memory. We use video->GetStream, which will return Stream - and does NOT
	// require us to load the whole video into the memory.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Memory consumption will remain low regardless of the size of the video or presentation,
}

// If necessary, you can apply the same steps for audio files.
```

### **เพิ่มภาพเป็น BLOB ไปยังพรีเซนเทชั่น**

ด้วยเมธอดจากอินเตอร์เฟซ [**IImageCollection**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) และ [**ImageCollection** ](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.image_collection)class คุณสามารถเพิ่มภาพขนาดใหญ่เป็นสตรีมเพื่อให้จัดการเป็น BLOB

โค้ด C++ นี้แสดงวิธีเพิ่มภาพขนาดใหญ่ผ่านกระบวนการ BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// สร้างพรีเซนเทชั่นใหม่ที่จะเพิ่มรูปภาพลงไป.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// เราจะเพิ่มรูปภาพลงพรีเซนเทชั่น - เราเลือกพฤติกรรม KeepLocked เนื่องจากเราต้องการ
// ไม่ได้ตั้งใจเข้าถึงไฟล์ "largeImage.png" .
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// บันทึกพรีเซนเทชั่น ระหว่างที่พรีเซนเทชั่นขนาดใหญ่ถูกส่งออก การใช้หน่วยความจำ
// คงต่ำตลอดวงจรชีวิตของอ็อบเจกต์ pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **หน่วยความจำและพรีเซนเทชั่นขนาดใหญ่**

โดยทั่วไป การโหลดพรีเซนเทชั่นขนาดใหญ่จะต้องใช้หน่วยความจำชั่วคราวจำนวนมาก เนื้อหาทั้งหมดของพรีเซนเทชั่นจะถูกโหลดเข้าสู่หน่วยความจำและไฟล์ต้นทาง (ไฟล์ที่พรีเซนเทชั่นถูกโหลดจากนั้น) จะหยุดใช้งาน

พิจารณาพรีเซนเทชั่น PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานในการโหลดพรีเซนเทชั่นถูกอธิบายในโค้ด C++ นี้:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

แต่วิธีนี้ใช้หน่วยความจำชั่วคราวประมาณ 1.6 GB

### **โหลดพรีเซนเทชั่นขนาดใหญ่เป็น BLOB**

ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB คุณสามารถโหลดพรีเซนเทชั่นขนาดใหญ่โดยใช้หน่วยความจำน้อย โค้ด C++ นี้อธิบายการนำไปใช้ที่ใช้กระบวนการ BLOB เพื่อโหลดไฟล์พรีเซนเทชั่นขนาดใหญ่ (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **เปลี่ยนโฟลเดอร์สำหรับไฟล์ชั่วคราว**

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้นของไฟล์ชั่วคราว หากคุณต้องการให้ไฟล์ชั่วคราวถูกเก็บไว้ในโฟลเดอร์อื่น สามารถเปลี่ยนการตั้งค่าการจัดเก็บโดยใช้ `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
เมื่อคุณใช้ `TempFilesRootPath` Aspose.Slides จะไม่สร้างโฟลเดอร์สำหรับเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง
{{% /alert %}}

### **ทำลายอ็อบเจกต์ Presentation เพื่อปล่อยหน่วยความจำ**

เมื่อประมวลผลพรีเซนเทชั่นขนาดใหญ่ ให้แน่ใจว่าอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ถูกทำลายอย่างถูกต้องเพื่อให้หน่วยความจำที่ครอบครองถูกปล่อยออกมา เรียก `Dispose()` หลังจากใช้พรีเซนเทชั่นเสร็จเพื่อปล่อยทรัพยากรที่ไม่ได้จัดการ

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...ดำเนินการพรีเซนเทชั่น...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// ปล่อยทรัพยากรอย่างชัดเจน.
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ข้อมูลใดในพรีเซนเทชั่นของ Aspose.Slides ที่ถูกจัดการเป็น BLOB และควบคุมโดยตัวเลือก BLOB?**

วัตถุไบนารีขนาดใหญ่เช่นภาพ, เสียง, และวิดีโอจะถูกจัดการเป็น BLOB ไฟล์พรีเซนเทชั่นทั้งหมดก็เกี่ยวข้องกับการจัดการ BLOB เมื่อโหลดหรือบันทึก วัตถุเหล่านี้อยู่ภายใต้แนวทาง BLOB ที่ให้คุณจัดการการใช้หน่วยความจำและสลับไปใช้ไฟล์ชั่วคราวเมื่อจำเป็น

**ฉันตั้งค่ากฎการจัดการ BLOB ระหว่างการโหลดพรีเซนเทชั่นได้ที่ไหน?**

ใช้ [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) พร้อมกับ [BlobManagementOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/blobmanagementoptions/) ที่นั่นคุณสามารถกำหนดขีดจำกัดการเก็บ BLOB ในหน่วยความจำ, เปิดหรือปิดไฟล์ชั่วคราว, เลือกเส้นทางรากสำหรับไฟล์ชั่วคราว, และเลือกพฤติกรรมการล็อกแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และจะปรับสมดุลระหว่างความเร็วและหน่วยความจำอย่างไร?**

มีผล การเก็บ BLOB ไอยู่ในหน่วยความจำจะทำให้เร็วที่สุดแต่ใช้ RAM มาก; การลดขีดจำกัดหน่วยความจำจะผลักงานส่วนใหญ่ไปยังไฟล์ชั่วคราว ลด RAM แต่เพิ่ม I/O ใช้เมธอด [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/th/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) เพื่อหาจุดสมดุลที่เหมาะกับงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดพรีเซนเทชั่นที่ใหญ่มาก (เช่นหลายกิกะไบต์) หรือไม่?**

ช่วย [BlobManagementOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์เช่นนี้: เปิดใช้งานไฟล์ชั่วคราวและใช้การล็อกแหล่งข้อมูลสามารถลดการใช้ RAM สูงสุดได้อย่างสำคัญและทำให้การประมวลผลพรีเซนเทชั่นขนาดใหญ่อยู่ในระดับที่เสถียร

**ฉันสามารถใช้แนวทาง BLOB เมื่อโหลดจากสตรีมแทนไฟล์ดิสก์ได้หรือไม่?**

ได้ กฎเดียวกันใช้กับสตรีม: อินสแตนซ์พรีเซนเทชั่นสามารถเป็นเจ้าของและล็อกสตรีมอินพุต (ขึ้นอยู่กับโหมดการล็อกที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่ออนุญาต ทำให้การใช้หน่วยความจำคาดการณ์ได้ระหว่างการประมวลผล