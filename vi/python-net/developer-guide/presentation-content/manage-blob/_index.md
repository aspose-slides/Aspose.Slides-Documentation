---
title: Quản lý BLOB trong các bài thuyết trình với Python để tối ưu việc sử dụng bộ nhớ
linktitle: Quản lý BLOB
type: docs
weight: 10
url: /vi/python-net/manage-blob/
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
- tệp tạm
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Quản lý dữ liệu BLOB trong Aspose.Slides cho Python qua .NET để tối ưu hoá các hoạt động với tệp PowerPoint và OpenDocument, giúp xử lý bài thuyết trình hiệu quả."
---
## **Tổng quan**

Aspose.Slides cung cấp việc xử lý dựa trên BLOB cho dữ liệu nhị phân lớn trong các bài thuyết trình nhằm giúp giảm tiêu thụ bộ nhớ khi làm việc với hình ảnh, âm thanh, video và tệp trình chiếu lớn.

Bài viết này trình bày cách sử dụng xử lý dựa trên BLOB để thêm phương tiện đa phương tiện lớn vào bài thuyết trình, xuất phương tiện lớn ra khỏi bài thuyết trình và tải các bài thuyết trình lớn một cách hiệu quả hơn. Nó cũng giải thích cách sử dụng tệp tạm trong quá trình xử lý và cách thay đổi thư mục lưu trữ chúng.

## **Về BLOB**

**BLOB** (**Binary Large Object**) thường là một mục lớn (hình ảnh, bài thuyết trình, tài liệu hoặc phương tiện) được lưu dưới dạng nhị phân.

Aspose.Slides for Python qua .NET cho phép bạn sử dụng BLOB cho các đối tượng theo cách giảm tiêu thụ bộ nhớ khi có các tệp lớn.

## **Sử dụng BLOB để giảm tiêu thụ bộ nhớ**

### **Thêm tệp lớn qua BLOB vào bài thuyết trình**

[Aspose.Slides](/slides/vi/python-net/) for .NET cho phép bạn thêm các tệp lớn (trong trường hợp này là một tệp video lớn) thông qua một quy trình liên quan đến BLOB nhằm giảm tiêu thụ bộ nhớ.

Mã Python này cho bạn thấy cách thêm một tệp video lớn thông qua quy trình BLOB vào một bài thuyết trình:
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Tạo một bài thuyết trình mới mà video sẽ được thêm vào
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Hãy thêm video vào bài thuyết trình - chúng tôi chọn hành vi KeepLocked vì chúng tôi
        # không có ý định truy cập tệp "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Lưu bài thuyết trình. Khi một bài thuyết trình lớn được xuất, tiêu thụ bộ nhớ
        # vẫn ở mức thấp trong suốt vòng đời của đối tượng pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Xuất tệp lớn qua BLOB từ bài thuyết trình**

Aspose.Slides for Python qua .NET cho phép bạn xuất các tệp lớn (trong trường hợp này là tệp âm thanh hoặc video) thông qua một quy trình liên quan đến BLOB từ các bài thuyết trình. Ví dụ, bạn có thể cần trích xuất một tệp phương tiện lớn từ bài thuyết trình nhưng không muốn tệp này được tải vào bộ nhớ máy tính của bạn. Bằng cách xuất tệp qua quy trình BLOB, bạn có thể giữ mức tiêu thụ bộ nhớ thấp.

Mã Python này minh họa hoạt động đã mô tả:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Hãy lưu mỗi video vào một tệp. Để ngăn ngừa việc sử dụng bộ nhớ cao, chúng ta cần một bộ đệm sẽ được sử dụng
	# để chuyển dữ liệu từ luồng video của bài thuyết trình sang một luồng cho tệp video mới được tạo.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Duyệt qua các video
    index = 0
    # Nếu cần, bạn có thể áp dụng các bước tương tự cho các tệp âm thanh. 
    for video in pres.videos:
		# Mở luồng video của bài thuyết trình. Vui lòng lưu ý rằng chúng tôi cố ý tránh truy cập các thuộc tính
		# như video.BinaryData - vì thuộc tính này trả về một mảng byte chứa toàn bộ video, điều đó
		# gây ra việc tải byte vào bộ nhớ. Chúng tôi sử dụng video.GetStream, nó sẽ trả về Stream - và KHÔNG
		#  yêu cầu chúng tôi phải tải toàn bộ video vào bộ nhớ.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Thêm hình ảnh dưới dạng BLOB trong bài thuyết trình**

Với các phương thức từ lớp [**ImageCollection**](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/), bạn có thể thêm một hình ảnh lớn dưới dạng luồng để nó được xử lý như một BLOB.

Mã Python này cho bạn thấy cách thêm một hình ảnh lớn thông qua quy trình BLOB:
```py
import aspose.slides as slides

# tạo một bài thuyết trình mới mà hình ảnh sẽ được thêm vào.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Bộ nhớ và các bài thuyết trình lớn**

Thông thường, để tải một bài thuyết trình lớn, máy tính cần rất nhiều bộ nhớ tạm thời. Toàn bộ nội dung của bài thuyết trình được tải vào bộ nhớ và tệp (từ đó bài thuyết trình được tải) không còn được sử dụng.

Xem xét một bài thuyết trình PowerPoint lớn (large.pptx) chứa một tệp video 1,5 GB. Phương pháp tiêu chuẩn để tải bài thuyết trình được mô tả trong mã Python này:
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Nhưng phương pháp này tiêu tốn khoảng 1,6 GB bộ nhớ tạm.

### **Tải một bài thuyết trình lớn dưới dạng BLOB**

Thông qua quy trình liên quan đến BLOB, bạn có thể tải một bài thuyết trình lớn mà chỉ sử dụng ít bộ nhớ. Mã Python này mô tả cách thực hiện trong đó quy trình BLOB được dùng để tải một tệp bài thuyết trình lớn (large.pptx):
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Thay đổi thư mục cho tệp tạm thời**

Khi quy trình BLOB được sử dụng, máy tính của bạn tạo các tệp tạm trong thư mục mặc định cho tệp tạm. Nếu bạn muốn các tệp tạm được lưu trong một thư mục khác, bạn có thể thay đổi cài đặt lưu trữ bằng cách sử dụng `temp_files_root_path`:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Khi bạn sử dụng `temp_files_root_path`, Aspose.Slides sẽ không tự động tạo thư mục để lưu các tệp tạm. Bạn phải tạo thư mục này theo cách thủ công.
{{% /alert %}}

### **Giải phóng các đối tượng Presentation để giải phóng bộ nhớ**

Khi xử lý các bài thuyết trình lớn, hãy đảm bảo rằng thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) được giải phóng đúng cách để bộ nhớ mà nó chiếm được giải phóng. Cách khuyến nghị là sử dụng context manager (`with slides.Presentation(...) as presentation:`) như đã minh họa trong các ví dụ trên; nó tự động đóng bài thuyết trình và giải phóng các tài nguyên không quản lý khi khối kết thúc.

Nếu bạn tạo một bài thuyết trình mà không sử dụng khối `with`, hãy gọi rõ ràng `presentation.dispose()` sau khi đã xong việc sử dụng, và loại bỏ bất kỳ tham chiếu còn lại nào để bộ thu gom rác của Python có thể thu hồi bộ nhớ.
```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...xử lý bài thuyết trình...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Giải phóng tài nguyên một cách rõ ràng.
presentation.dispose()
```

## **Câu hỏi thường gặp**

**Dữ liệu nào trong một bài thuyết trình Aspose.Slides được xử lý như BLOB và được kiểm soát bởi các tùy chọn BLOB?**

Các đối tượng nhị phân lớn như hình ảnh, âm thanh và video được xử lý như BLOB. Toàn bộ tệp bài thuyết trình cũng liên quan đến việc xử lý BLOB khi nó được tải hoặc lưu. Các đối tượng này được điều khiển bởi các chính sách BLOB cho phép bạn quản lý việc sử dụng bộ nhớ và chuyển sang tệp tạm khi cần.

**Tôi cấu hình các quy tắc xử lý BLOB trong quá trình tải bài thuyết trình ở đâu?**

Sử dụng [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/) cùng với [BlobManagementOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/blobmanagementoptions/). Ở đó bạn có thể đặt giới hạn bộ nhớ cho BLOB, cho phép hoặc không cho phép tệp tạm, chọn đường dẫn gốc cho tệp tạm, và chọn hành vi khóa nguồn.

**Cài đặt BLOB ảnh hưởng đến hiệu năng không, và tôi cân bằng tốc độ và bộ nhớ như thế nào?**

Có. Giữ BLOB trong bộ nhớ tối đa hoá tốc độ nhưng làm tăng tiêu thụ RAM; giảm giới hạn bộ nhớ sẽ chuyển nhiều công việc sang tệp tạm, giảm RAM nhưng tăng I/O. Điều chỉnh ngưỡng [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/vi/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) để đạt được cân bằng phù hợp với khối lượng công việc và môi trường của bạn.

**Các tùy chọn BLOB có giúp khi mở các bài thuyết trình cực kỳ lớn (ví dụ, gigabyte) không?**

Có. [BlobManagementOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/blobmanagementoptions/) được thiết kế cho các kịch bản như vậy: bật tệp tạm và sử dụng khóa nguồn có thể giảm đáng kể mức RAM cao nhất và ổn định quá trình xử lý cho các bộ sưu tập rất lớn.

**Tôi có thể sử dụng các chính sách BLOB khi tải từ luồng thay vì tệp trên đĩa không?**

Có. Các quy tắc tương tự áp dụng cho luồng: thể hiện bài thuyết trình có thể sở hữu và khóa luồng đầu vào (tùy thuộc vào chế độ khóa được chọn), và tệp tạm sẽ được sử dụng khi được cho phép, giúp việc sử dụng bộ nhớ dự đoán được trong quá trình xử lý.