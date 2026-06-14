---
title: Truy cập các slide trong bài thuyết trình bằng C++
linktitle: Truy cập Slide
type: docs
weight: 20
url: /vi/cpp/access-slide-in-presentation/
keywords:
- truy cập slide
- chỉ mục slide
- id slide
- vị trí slide
- thay đổi vị trí
- thuộc tính slide
- số slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách truy cập và quản lý các slide trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Tăng năng suất với các ví dụ mã."
---
## **Tổng quan**

Bài viết này giải thích cách truy cập và quản lý các slide trong một bản trình bày bằng Aspose.Slides. Nó trình bày cách lấy slide theo chỉ mục bắt đầu từ 0 từ bộ sưu tập slide và cách truy cập một slide bằng ID duy nhất của nó bằng phương thức `GetSlideById`.

Bạn cũng sẽ học cách thay đổi vị trí của slide bằng phương thức `set_SlideNumber` và cách định nghĩa số slide bắt đầu cho một bản trình bày bằng phương thức `set_FirstSlideNumber`. Các ví dụ minh họa việc tải bản trình bày, lấy tham chiếu slide, cập nhật thứ tự hoặc đánh số slide, và lưu bản trình bày đã sửa đổi.

## **Truy cập slide theo chỉ mục**

Tất cả các slide trong một bản trình bày được sắp xếp theo thứ tự số dựa trên vị trí slide, bắt đầu từ 0. Slide đầu tiên có thể truy cập qua chỉ mục 0; slide thứ hai qua chỉ mục 1; v.v.

Lớp Presentation, đại diện cho tệp bản trình bày, khai báo tất cả các slide dưới dạng một bộ sưu tập [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) (tập hợp các đối tượng [ISlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/)). Đoạn mã C++ này cho bạn thấy cách truy cập slide qua chỉ mục của nó:

```c++
	// Đường dẫn tới thư mục tài liệu.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Khởi tạo lớp Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Lấy tham chiếu slide qua chỉ mục của nó
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Truy cập slide theo ID**

Mỗi slide trong bản trình bày có một ID duy nhất gắn với nó. Bạn có thể sử dụng phương thức [GetSlideById()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/getslidebyid/) (được khai báo bởi lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/)) để nhắm tới ID đó. Đoạn mã C++ này cho bạn thấy cách cung cấp một ID slide hợp lệ và truy cập slide đó qua phương thức [GetSlideById()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// Đường dẫn tới thư mục tài liệu.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Khởi tạo lớp Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Lấy ID slide
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Truy cập slide qua ID của nó
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Thay đổi vị trí slide**

Aspose.Slides cho phép bạn thay đổi vị trí của một slide. Ví dụ, bạn có thể chỉ định rằng slide đầu tiên sẽ trở thành slide thứ hai.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu slide (slide mà bạn muốn thay đổi vị trí) qua chỉ mục của nó
1. Đặt vị trí mới cho slide qua thuộc tính [set_SlideNumber()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/set_slidenumber/).
1. Lưu bản trình bày đã sửa đổi.

Đoạn mã C++ này minh họa một thao tác trong đó slide ở vị trí 1 được chuyển tới vị trí 2:

```c++
	// Đường dẫn tới thư mục tài liệu.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Khởi tạo lớp Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Lấy slide mà vị trí sẽ được thay đổi
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Đặt vị trí mới cho slide
	slide->set_SlideNumber(2);

	// Lưu bản trình bày đã sửa đổi
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Slide đầu tiên trở thành slide thứ hai; slide thứ hai trở thành slide đầu tiên. Khi bạn thay đổi vị trí của một slide, các slide khác sẽ tự động được điều chỉnh.

## **Đặt số slide**

Bằng cách sử dụng thuộc tính [set_FirstSlideNumber()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/set_firstslidenumber/) (được khai báo bởi lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/)), bạn có thể chỉ định một số mới cho slide đầu tiên trong một bản trình bày. Thao tác này sẽ làm cho các số slide khác được tính lại.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy số slide.
1. Đặt số slide.
1. Lưu bản trình bày đã sửa đổi.

Đoạn mã C++ này minh họa một thao tác trong đó số slide đầu tiên được đặt thành 10:

```c++
	// Đường dẫn tới thư mục tài liệu.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Khởi tạo lớp Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Lấy số slide
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Đặt số slide
	pres->set_FirstSlideNumber(2);
	
	// Lưu bản trình bày đã sửa đổi
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Nếu bạn muốn bỏ qua slide đầu tiên, bạn có thể bắt đầu đánh số từ slide thứ hai (và ẩn số thứ tự cho slide đầu tiên) theo cách sau:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Số slide mà người dùng thấy có khớp với chỉ mục zero‑based của bộ sưu tập không?**

Số hiển thị trên slide có thể bắt đầu từ một giá trị tùy ý (ví dụ, 10) và không nhất thiết phải khớp với chỉ mục; mối quan hệ này được kiểm soát bằng cài đặt [first slide number](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/set_firstslidenumber/) của bản trình bày.

**Các slide ẩn có ảnh hưởng đến việc đánh chỉ mục không?**

Có. Slide ẩn vẫn tồn tại trong bộ sưu tập và được tính trong việc đánh chỉ mục; “ẩn” chỉ đề cập đến việc hiển thị, không phải vị trí trong bộ sưu tập.

**Chỉ mục của một slide có thay đổi khi các slide khác được thêm hoặc xóa không?**

Có. Chỉ mục luôn phản ánh thứ tự hiện tại của các slide và được tính lại khi thực hiện các thao tác chèn, xóa và di chuyển.