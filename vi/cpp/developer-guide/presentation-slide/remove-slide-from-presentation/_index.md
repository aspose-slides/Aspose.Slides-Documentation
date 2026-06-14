---
title: Xóa slides khỏi bản trình chiếu trong C++
linktitle: Xóa slide
type: docs
weight: 30
url: /vi/cpp/remove-slide-from-presentation/
keywords:
- xóa slide
- xóa slide
- xóa slide không sử dụng
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Dễ dàng xóa slide khỏi các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Nhận các ví dụ mã rõ ràng và tăng năng suất công việc của bạn."
---
## **Giới thiệu**

Nếu một slide (hoặc nội dung của nó) trở nên thừa, bạn có thể xóa nó. Aspose.Slides cung cấp lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) mà bao bọc [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/), là kho lưu trữ cho tất cả các slide trong một bản trình chiếu. Bằng cách sử dụng các con trỏ (tham chiếu hoặc chỉ mục) cho một đối tượng [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/) đã biết, bạn có thể chỉ định slide bạn muốn xóa. 

## **Xóa Slide theo Tham chiếu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu của slide bạn muốn xóa thông qua ID hoặc chỉ mục của nó.
1. Xóa slide đã tham chiếu khỏi bản trình chiếu.
1. Lưu bản trình chiếu đã chỉnh sửa. 

Đoạn mã C++ này cho bạn thấy cách xóa một slide qua tham chiếu: 

```c++
	// Đường dẫn tới thư mục tài liệu
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Truy cập một slide thông qua chỉ mục trong bộ sưu tập các slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Xóa một slide thông qua tham chiếu của nó
	pres->get_Slides()->Remove(slide);

	// Lưu bản trình chiếu đã chỉnh sửa
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Xóa Slide theo Chỉ mục**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Xóa slide khỏi bản trình chiếu bằng vị trí chỉ mục của nó.
1. Lưu bản trình chiếu đã chỉnh sửa. 

Đoạn mã C++ này cho bạn thấy cách xóa một slide qua chỉ mục: 

```c++
	// Đường dẫn tới thư mục tài liệu
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Xóa một slide thông qua chỉ mục của nó
	pres->get_Slides()->RemoveAt(0);

	// Lưu bản trình chiếu đã chỉnh sửa
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Xóa Các Slide Bố Cục Không Sử Dụng**

Aspose.Slides cung cấp phương thức [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (từ lớp [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/)) để cho phép bạn xóa các slide bố cục không mong muốn và không được sử dụng. Đoạn mã C++ này cho bạn thấy cách xóa một slide bố cục khỏi bản trình chiếu PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Xóa Các Slide Chủ Đề Không Sử Dụng**

Aspose.Slides cung cấp phương thức [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (từ lớp [Compress](https://reference.aspose.com/slides/vi/cpp/aspose.slides.lowcode/compress/)) để cho phép bạn xóa các slide chủ đề không mong muốn và không được sử dụng. Đoạn mã C++ này cho bạn thấy cách xóa một slide chủ đề khỏi bản trình chiếu PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Chỉ mục slide sẽ như thế nào sau khi tôi xóa một slide?**

Sau khi xóa, [collection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidecollection/) sẽ được đánh chỉ mục lại: mọi slide tiếp theo dịch sang trái một vị trí, vì vậy các số chỉ mục cũ không còn chính xác. Nếu bạn cần một tham chiếu ổn định, hãy sử dụng ID cố định của mỗi slide thay vì chỉ mục.

**ID của slide có khác với chỉ mục không, và nó có thay đổi khi các slide lân cận bị xóa không?**

Có. Chỉ mục là vị trí của slide và sẽ thay đổi khi slide được thêm hoặc xóa. ID slide là định danh cố định và không thay đổi khi các slide khác bị xóa.

**Xóa một slide ảnh hưởng như thế nào đến các phần (section) của slide?**

Nếu slide thuộc về một phần, phần đó sẽ chỉ có ít hơn một slide. Cấu trúc phần vẫn giữ nguyên; nếu một phần trở nên rỗng, bạn có thể [remove or reorganize sections](/slides/vi/cpp/slide-section/) theo nhu cầu.

**Ghi chú và bình luận gắn vào slide sẽ như thế nào khi slide bị xóa?**

[Notes](/slides/vi/cpp/presentation-notes/) và [comments](/slides/vi/cpp/presentation-comments/) được liên kết với slide cụ thể đó và sẽ bị xóa cùng với nó. Nội dung trên các slide khác không bị ảnh hưởng.

**Xóa slide khác gì so với việc dọn dẹp các bố cục/slide chủ đề không sử dụng?**

Xóa slide loại bỏ các slide bình thường cụ thể khỏi bộ sưu tập. Dọn dẹp các bố cục/slide chủ đề không sử dụng loại bỏ các slide bố cục hoặc chủ đề mà không có bất kỳ slide nào tham chiếu tới, giảm kích thước tệp mà không thay đổi nội dung các slide còn lại. Hai thao tác này bổ trợ cho nhau: thường xóa slide trước, rồi mới dọn dẹp.