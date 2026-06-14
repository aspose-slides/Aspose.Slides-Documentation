---
title: Quản lý BLOB trong bản trình chiếu C++ để tối ưu sử dụng bộ nhớ
linktitle: Quản lý BLOB
type: docs
weight: 10
url: /vi/cpp/manage-blob/
keywords:
- đối tượng lớn
- mục lớn
- tệp lớn
- thêm BLOB
- xuất BLOB
- thêm hình ảnh dưới dạng BLOB
- giảm bộ nhớ
- tiêu thụ bộ nhớ
- bản trình chiếu lớn
- tệp tạm
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý dữ liệu BLOB trong Aspose.Slides cho C++ để tối ưu hoá thao tác với file PowerPoint và OpenDocument, nâng cao hiệu quả xử lý bản trình chiếu."
---
## **Tổng quan**

Aspose.Slides cung cấp cách xử lý dựa trên BLOB cho dữ liệu nhị phân lớn trong các bản trình chiếu nhằm giúp giảm tiêu thụ bộ nhớ khi làm việc với hình ảnh, âm thanh, video và các tệp bản trình chiếu lớn.

Bài viết này cho thấy cách sử dụng xử lý dựa trên BLOB để thêm phương tiện lớn vào bản trình chiếu, xuất phương tiện lớn từ bản trình chiếu và tải các bản trình chiếu lớn một cách hiệu quả hơn. Nó cũng giải thích cách sử dụng tệp tạm trong quá trình xử lý và cách thay đổi thư mục lưu trữ chúng.

## **Về BLOB**

**BLOB** (**Binary Large Object**) thường là một đối tượng lớn (hình ảnh, bản trình chiếu, tài liệu hoặc phương tiện) được lưu ở định dạng nhị phân.  

Aspose.Slides for C++ cho phép bạn sử dụng BLOB cho các đối tượng theo cách giảm tiêu thụ bộ nhớ khi làm việc với các tệp lớn.

## **Sử dụng BLOB để giảm tiêu thụ bộ nhớ**

### **Thêm tệp lớn qua BLOB vào bản trình chiếu**

[Aspose.Slides](/slides/vi/cpp/) for C++ cho phép bạn thêm các tệp lớn (trong trường hợp này là một tệp video lớn) thông qua quy trình sử dụng BLOB để giảm tiêu thụ bộ nhớ.

Mã C++ này cho bạn cách thêm một tệp video lớn qua quy trình BLOB vào bản trình chiếu:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Tạo một bản trình chiếu mới để thêm video vào
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Thêm video vào bản trình chiếu - chúng tôi đã chọn hành vi KeepLocked vì chúng tôi
// không dự định truy cập tệp "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Lưu bản trình chiếu. Khi một bản trình chiếu lớn được xuất, mức tiêu thụ bộ nhớ
// vẫn thấp suốt vòng đời của đối tượng pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Xuất tệp lớn qua BLOB từ bản trình chiếu**

Aspose.Slides for C++ cho phép bạn xuất các tệp lớn (ví dụ: tệp âm thanh hoặc video) thông qua quy trình sử dụng BLOB từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất một tệp phương tiện lớn từ bản trình chiếu nhưng không muốn tệp được tải vào bộ nhớ máy tính. Bằng cách xuất tệp qua quy trình BLOB, bạn giữ mức tiêu thụ bộ nhớ ở mức thấp.

Mã C++ này minh họa thao tác trên:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Tạo một thể hiện Presentation, khóa tệp "hugePresentationWithAudiosAndVideos.pptx" file.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Hãy lưu mỗi video vào một tệp. Để ngăn ngừa việc sử dụng bộ nhớ cao, chúng ta cần một bộ đệm sẽ được sử dụng
// để truyền dữ liệu từ luồng video của bản trình chiếu sang một luồng cho tệp video mới được tạo.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Mở luồng video của bản trình chiếu. Xin lưu ý rằng chúng tôi cố ý tránh truy cập các phương thức
	// như video->get_BinaryData - vì phương thức này trả về một mảng byte chứa toàn bộ video, sau đó
	// gây ra việc các byte được tải vào bộ nhớ. Chúng tôi sử dụng video->GetStream, phương thức sẽ trả về Stream - và KHÔNG
	// yêu cầu chúng ta tải toàn bộ video vào bộ nhớ.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Tiêu thụ bộ nhớ sẽ vẫn thấp bất kể kích thước của video hay bản trình chiếu,
}

// Nếu cần, bạn có thể áp dụng các bước tương tự cho các tệp âm thanh.
```

### **Thêm hình ảnh dưới dạng BLOB vào bản trình chiếu**

Với các phương thức từ giao diện [**IImageCollection**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_image_collection) và lớp [**ImageCollection** ](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.image_collection)class, bạn có thể thêm một hình ảnh lớn dưới dạng luồng để xử lý như một BLOB.  

Mã C++ này cho bạn cách thêm một hình ảnh lớn qua quy trình BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// tạo một bản trình chiếu mới để thêm hình ảnh vào.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Hãy thêm hình ảnh vào bản trình chiếu - chúng tôi chọn hành vi KeepLocked vì chúng tôi
// KHÔNG dự định truy cập tệp "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Lưu bản trình chiếu. Khi một bản trình chiếu lớn được xuất, mức tiêu thụ bộ nhớ 
// vẫn thấp trong suốt vòng đời của đối tượng pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Bộ nhớ và các bản trình chiếu lớn**

Thông thường, để tải một bản trình chiếu lớn, máy tính cần rất nhiều bộ nhớ tạm. Toàn bộ nội dung của bản trình chiếu được tải vào bộ nhớ và tệp nguồn (tệp mà bản trình chiếu được tải từ đó) sẽ không còn được sử dụng.

Xét một bản PowerPoint lớn (large.pptx) chứa một tệp video 1,5 GB. Phương pháp tiêu chuẩn để tải bản trình chiếu được mô tả trong mã C++ này:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Nhưng phương pháp này tiêu tốn khoảng 1,6 GB bộ nhớ tạm.

### **Tải bản trình chiếu lớn dưới dạng BLOB**

Thông qua quy trình sử dụng BLOB, bạn có thể tải một bản trình chiếu lớn trong khi sử dụng ít bộ nhớ. Mã C++ này mô tả cách thực hiện khi sử dụng quy trình BLOB để tải tệp bản trình chiếu lớn (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Thay đổi thư mục cho tệp tạm**

Khi sử dụng quy trình BLOB, máy tính của bạn tạo các tệp tạm trong thư mục mặc định cho tệp tạm. Nếu muốn các tệp tạm được lưu ở một thư mục khác, bạn có thể thay đổi cài đặt lưu trữ bằng `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Khi bạn sử dụng `TempFilesRootPath`, Aspose.Slides sẽ không tự động tạo thư mục để lưu tệp tạm. Bạn phải tạo thư mục này thủ công. 
{{% /alert %}}

### **Giải phóng đối tượng Presentation để giải phóng bộ nhớ**

Khi xử lý các bản trình chiếu lớn, hãy đảm bảo rằng đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) được giải phóng đúng cách để bộ nhớ nó chiếm giữ được giải phóng. Gọi `Dispose()` sau khi bạn hoàn tất sử dụng bản trình chiếu để giải phóng tài nguyên không quản lý.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **FAQ**

**Dữ liệu nào trong bản trình chiếu Aspose.Slides được xem là BLOB và bị điều khiển bởi các tùy chọn BLOB?**  
Các đối tượng nhị phân lớn như hình ảnh, âm thanh và video được xem là BLOB. Toàn bộ tệp bản trình chiếu cũng liên quan đến việc xử lý BLOB khi nó được tải hoặc lưu. Những đối tượng này được quản lý bởi các chính sách BLOB cho phép bạn kiểm soát việc sử dụng bộ nhớ và chuyển sang tệp tạm khi cần.

**Tôi cấu hình các quy tắc xử lý BLOB ở đâu khi tải bản trình chiếu?**  
Sử dụng [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/) kèm theo [BlobManagementOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/blobmanagementoptions/). Tại đây bạn thiết lập giới hạn bộ nhớ cho BLOB, cho phép hoặc không cho phép tệp tạm, chọn đường dẫn gốc cho tệp tạm và xác định hành vi khóa nguồn.

**Các cài đặt BLOB có ảnh hưởng đến hiệu năng không, và làm sao cân bằng tốc độ với bộ nhớ?**  
Có. Giữ BLOB trong bộ nhớ tối đa tốc độ nhưng tăng tiêu thụ RAM; giảm giới hạn bộ nhớ sẽ chuyển nhiều công việc sang tệp tạm, giảm RAM nhưng tạo thêm I/O. Sử dụng phương thức [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/vi/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) để tìm cân bằng phù hợp với khối lượng công việc và môi trường của bạn.

**Các tùy chọn BLOB có hữu ích khi mở các bản trình chiếu cực lớn (ví dụ: hàng gigabyte) không?**  
Có. [BlobManagementOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/blobmanagementoptions/) được thiết kế cho các kịch bản này: bật tệp tạm và sử dụng khóa nguồn có thể giảm đáng kể mức RAM tối đa và ổn định quá trình xử lý cho các bộ sưu tập rất lớn.

**Tôi có thể sử dụng chính sách BLOB khi tải từ luồng thay vì tệp trên đĩa không?**  
Có. Các quy tắc tương tự áp dụng cho luồng: thể hiện bản trình chiếu có thể sở hữu và khóa luồng đầu vào (tùy vào chế độ khóa đã chọn), và tệp tạm sẽ được sử dụng khi được cho phép, giúp dự đoán mức tiêu thụ bộ nhớ trong quá trình xử lý.