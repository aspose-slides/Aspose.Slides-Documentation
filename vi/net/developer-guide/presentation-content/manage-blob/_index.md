---
title: Quản lý BLOB của bài thuyết trình trong .NET để sử dụng bộ nhớ hiệu quả
linktitle: Quản lý BLOB
type: docs
weight: 10
url: /vi/net/manage-blob/
keywords:
- đối tượng lớn
- mục lớn
- tệp lớn
- thêm BLOB
- xuất BLOB
- thêm hình ảnh dưới dạng BLOB
- giảm bộ nhớ
- tiêu thụ bộ nhớ
- bài thuyết trình lớn
- tệp tạm thời
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quản lý dữ liệu BLOB trong Aspose.Slides cho .NET để tối ưu hoá các thao tác với tệp PowerPoint và OpenDocument, giúp xử lý bài thuyết trình hiệu quả."
---
## **Tổng quan**

Aspose.Slides cung cấp việc xử lý dựa trên BLOB cho dữ liệu nhị phân lớn trong các bài thuyết trình nhằm giúp giảm tiêu thụ bộ nhớ khi làm việc với hình ảnh, âm thanh, video và tệp bài thuyết trình lớn.

Bài viết này hướng dẫn cách sử dụng xử lý dựa trên BLOB để thêm phương tiện đa phương tiện lớn vào bài thuyết trình, xuất phương tiện lớn từ bài thuyết trình và tải các bài thuyết trình lớn một cách hiệu quả hơn. Nó cũng giải thích cách sử dụng tệp tạm thời trong quá trình xử lý và cách thay đổi thư mục lưu trữ chúng.

## **Về BLOB**

**BLOB** (**Binary Large Object**) thường là một mục lớn (hình ảnh, bài thuyết trình, tài liệu hoặc phương tiện) được lưu dưới dạng nhị phân.

Aspose.Slides for .NET cho phép bạn sử dụng BLOB cho các đối tượng theo cách giảm tiêu thụ bộ nhớ khi làm việc với các tệp lớn.

## **Sử dụng BLOB để giảm tiêu thụ bộ nhớ**

### **Thêm tệp lớn qua BLOB vào bài thuyết trình**

[Aspose.Slides](/slides/vi/net/) cho .NET cho phép bạn thêm các tệp lớn (trong trường hợp này là tệp video lớn) thông qua quy trình liên quan đến BLOB để giảm tiêu thụ bộ nhớ.

Đoạn mã C# dưới đây cho thấy cách thêm một tệp video lớn thông qua quy trình BLOB vào một bài thuyết trình:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Tạo một bài thuyết trình mới mà video sẽ được thêm vào
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Hãy thêm video vào bài thuyết trình - chúng tôi chọn hành vi KeepLocked vì chúng tôi
        // không có ý định truy cập tệp "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Lưu bài thuyết trình. Khi một bài thuyết trình lớn được xuất ra, mức tiêu thụ bộ nhớ
        // vẫn thấp suốt vòng đời của đối tượng pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Xuất tệp lớn qua BLOB từ bài thuyết trình**

Aspose.Slides cho .NET cho phép bạn xuất các tệp lớn (trong trường hợp này là tệp âm thanh hoặc video) thông qua quy trình liên quan đến BLOB từ các bài thuyết trình. Ví dụ, bạn có thể cần trích xuất một tệp phương tiện lớn từ bài thuyết trình nhưng không muốn tệp này được nạp vào bộ nhớ máy tính của bạn. Bằng cách xuất tệp qua quy trình BLOB, bạn có thể duy trì mức tiêu thụ bộ nhớ thấp.

Đoạn mã C# sau minh họa hoạt động đã mô tả:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Khóa tệp nguồn và KHÔNG tải nó vào bộ nhớ
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Tạo một thể hiện Presentation, khóa tệp "hugePresentationWithAudiosAndVideos.pptx" file.
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Hãy lưu mỗi video vào một tệp. Để ngăn ngừa việc sử dụng bộ nhớ cao, chúng ta cần một bộ đệm sẽ được sử dụng
	// để truyền dữ liệu từ luồng video của bài thuyết trình sang một luồng cho tệp video mới được tạo.
	byte[] buffer = new byte[8 * 1024];

	// Duyệt qua các video
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Mở luồng video của bài thuyết trình. Lưu ý, chúng tôi cố ý tránh truy cập các thuộc tính
		// như video.BinaryData - vì thuộc tính này trả về một mảng byte chứa toàn bộ video, dẫn đến
		//   làm cho byte được tải vào bộ nhớ. Chúng tôi dùng video.GetStream, nó sẽ trả về Stream - và KHÔNG
		//   yêu cầu chúng ta tải toàn bộ video vào bộ nhớ.
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

		// Tiêu thụ bộ nhớ sẽ luôn thấp bất kể kích thước của video hay bài thuyết trình,
	}

	// Nếu cần, bạn có thể áp dụng các bước tương tự cho các tệp âm thanh. 
}
```

### **Thêm hình ảnh dưới dạng BLOB vào bài thuyết trình**

Bằng các phương thức từ giao diện [**IImageCollection**](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) và lớp [**ImageCollection** ](https://reference.aspose.com/slides/vi/net/aspose.slides/imagecollection)class, bạn có thể thêm một hình ảnh lớn dưới dạng luồng để nó được xử lý như một BLOB.

Đoạn mã C# dưới đây cho bạn thấy cách thêm một hình ảnh lớn thông qua quy trình BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// tạo một bài thuyết trình mới mà hình ảnh sẽ được thêm vào.
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
    {
        // Hãy thêm hình ảnh vào bài thuyết trình - chúng tôi chọn hành vi KeepLocked vì chúng tôi
        // KHÔNG có ý định truy cập tệp "largeImage.png".
        IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

        // Lưu bài thuyết trình. Khi một bài thuyết trình lớn được xuất ra, mức tiêu thụ bộ nhớ 
        // vẫn thấp trong suốt vòng đời của đối tượng pres
        pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
    }
}
```

## **Bộ nhớ và bài thuyết trình lớn**

Thông thường, để tải một bài thuyết trình lớn, máy tính cần một lượng lớn bộ nhớ tạm. Toàn bộ nội dung của bài thuyết trình được nạp vào bộ nhớ và tệp (từ đó bài thuyết trình được tải) không còn được sử dụng.

Hãy xét một bài thuyết trình PowerPoint lớn (large.pptx) chứa một tệp video 1.5 GB. Phương pháp tiêu chuẩn để tải bài thuyết trình được mô tả trong đoạn mã C# sau:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Nhưng phương pháp này tiêu tốn khoảng 1.6 GB bộ nhớ tạm.

### **Tải bài thuyết trình lớn dưới dạng BLOB**

Thông qua quy trình liên quan đến BLOB, bạn có thể tải một bài thuyết trình lớn trong khi sử dụng ít bộ nhớ. Đoạn mã C# này mô tả cách thực hiện khi quy trình BLOB được dùng để tải một tệp bài thuyết trình lớn (large.pptx):

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

### **Thay đổi thư mục cho tệp tạm thời**

Khi quy trình BLOB được sử dụng, máy tính của bạn tạo các tệp tạm thời trong thư mục mặc định cho tệp tạm. Nếu bạn muốn các tệp tạm được giữ trong một thư mục khác, bạn có thể thay đổi cài đặt lưu trữ bằng cách sử dụng `TempFilesRootPath`:

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
Khi bạn sử dụng `TempFilesRootPath`, Aspose.Slides sẽ không tự động tạo thư mục để lưu trữ tệp tạm. Bạn phải tạo thư mục này một cách thủ công. 
{{% /alert %}}

### **Giải phóng đối tượng Presentation để giải phóng bộ nhớ**

Khi xử lý các bài thuyết trình lớn, hãy đảm bảo rằng thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) được giải phóng đúng cách để bộ nhớ đã chiếm được giải phóng. Cách khuyến nghị là sử dụng câu lệnh hoặc khai báo `using` như đã trình bày trong các ví dụ ở trên; nó sẽ tự động giải phóng bản trình bày và giải phóng các tài nguyên không quản lý khi khối kết thúc.

Nếu bạn tạo một bản trình bày mà không có khối `using`, hãy gọi `Dispose()` một cách rõ ràng sau khi bạn đã hoàn thành việc sử dụng nó.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...xử lý bài thuyết trình...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Giải phóng tài nguyên một cách rõ ràng.
presentation.Dispose();
```

## **Câu hỏi thường gặp**

**Dữ liệu nào trong một bản trình bày Aspose.Slides được xem như BLOB và được điều khiển bởi các tùy chọn BLOB?**

Các đối tượng nhị phân lớn như hình ảnh, âm thanh và video được coi là BLOB. Toàn bộ tệp bản trình bày cũng liên quan đến việc xử lý BLOB khi nó được tải hoặc lưu. Các đối tượng này được quản lý bởi các chính sách BLOB cho phép bạn kiểm soát việc sử dụng bộ nhớ và chuyển sang tệp tạm khi cần.

**Tôi cấu hình các quy tắc xử lý BLOB trong quá trình tải bản trình bày ở đâu?**

Sử dụng [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/) kết hợp với [BlobManagementOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/blobmanagementoptions/). Tại đây bạn có thể đặt giới hạn bộ nhớ cho BLOB, cho phép hoặc không cho phép tệp tạm, chọn đường dẫn gốc cho tệp tạm, và chọn hành vi khóa nguồn.

**Các cài đặt BLOB có ảnh hưởng đến hiệu năng không, và làm thế nào tôi cân bằng tốc độ và bộ nhớ?**

Có. Giữ BLOB trong bộ nhớ tối ưu tốc độ nhưng làm tăng mức tiêu thụ RAM; giảm giới hạn bộ nhớ sẽ chuyển nhiều công việc sang tệp tạm, giảm RAM nhưng tăng I/O. Điều chỉnh ngưỡng [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/vi/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) để đạt được sự cân bằng phù hợp cho tải công việc và môi trường của bạn.

**Các tùy chọn BLOB có hữu ích khi mở các bản trình bày cực kỳ lớn (ví dụ, hàng gigabyte) không?**

Có. [BlobManagementOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/blobmanagementoptions/) được thiết kế cho các kịch bản như vậy: bật tệp tạm và sử dụng khóa nguồn có thể giảm đáng kể mức RAM tối đa và ổn định quá trình xử lý cho các bộ sưu tập rất lớn.

**Tôi có thể sử dụng chính sách BLOB khi tải từ luồng thay vì tệp trên đĩa không?**

Có. Các quy tắc tương tự áp dụng cho luồng: thể hiện bản trình bày có thể sở hữu và khóa luồng đầu vào (tùy thuộc vào chế độ khóa được chọn), và các tệp tạm sẽ được dùng khi được cho phép, giữ cho mức tiêu thụ bộ nhớ dự đoán được trong quá trình xử lý.