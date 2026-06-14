---
title: Quản lý Header và Footer cho Bài thuyết trình trong C++
linktitle: Header và Footer
type: docs
weight: 140
url: /vi/cpp/presentation-header-and-footer/
keywords:
- tiêu đề
- văn bản tiêu đề
- chân trang
- văn bản chân trang
- đặt tiêu đề
- đặt chân trang
- bản phát tay
- ghi chú
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho C++ để thêm và tùy chỉnh header và footer trong các bài thuyết trình PowerPoint và OpenDocument, tạo diện mạo chuyên nghiệp."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý cài đặt header và footer trong các bài thuyết trình PowerPoint. Header và footer được xử lý ở mức master của bài thuyết trình, và API cung cấp các phương thức để đặt văn bản footer, thay đổi hiển thị của footer, và cập nhật văn bản header trên các slide ghi chú master.

Bạn cũng có thể quản lý header và footer cho các slide bản phát tay và ghi chú. Điều này bao gồm việc thay đổi hiển thị và văn bản của các placeholder header, footer, số slide và ngày‑giờ cho notes master, tất cả các notes slide con, hoặc một notes slide riêng lẻ.

## **Quản lý văn bản Header và Footer**

Ghi chú của một số slide cụ thể có thể được cập nhật như trong ví dụ dưới đây:

``` cpp
// Hàm để đặt văn bản Header/Footer
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Tải bài thuyết trình
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Đặt Footer
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Truy cập và cập nhật Header
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Lưu bài thuyết trình
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Quản lý Header và Footer trên bản phát tay và các slide ghi chú**

Aspose.Slides for C++ hỗ trợ Header và Footer trong bản phát tay và các slide ghi chú. Vui lòng thực hiện các bước sau:

- Tải một [Presentation ](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) chứa video.
- Thay đổi cài đặt Header và Footer cho notes master và tất cả các notes slide.
- Đặt các placeholder Footer trên master notes slide và tất cả các child hiển thị.
- Đặt các placeholder Date và time trên master notes slide và tất cả các child hiển thị.
- Thay đổi cài đặt Header và Footer chỉ cho notes slide đầu tiên.
- Đặt placeholder Header của notes slide hiển thị.
- Đặt văn bản cho placeholder Header của notes slide.
- Đặt văn bản cho placeholder Date-time của notes slide.
- Ghi file bản trình chiếu đã sửa đổi.

Đoạn mã được cung cấp trong ví dụ dưới đây.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Thay đổi cài đặt Header và Footer cho notes master và tất cả các notes slide
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// làm cho master notes slide và tất cả các placeholder Footer con hiển thị
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// làm cho master notes slide và tất cả các placeholder Header con hiển thị
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// làm cho master notes slide và tất cả các placeholder SlideNumber con hiển thị
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// làm cho master notes slide và tất cả các placeholder Date và time con hiển thị
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// đặt văn bản cho master notes slide và tất cả các placeholder Header con
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// đặt văn bản cho master notes slide và tất cả các placeholder Footer con
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// đặt văn bản cho master notes slide và tất cả các placeholder Date và time con
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Thay đổi cài đặt Header và Footer cho slide ghi chú đầu tiên chỉ
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// làm cho placeholder Header của slide ghi chú này hiển thị
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// làm cho placeholder Footer của slide ghi chú này hiển thị
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// làm cho placeholder SlideNumber của slide ghi chú này hiển thị
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// làm cho placeholder Date-time của slide ghi chú này hiển thị
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// đặt văn bản cho placeholder Header của slide ghi chú
	headerFooterManager->SetHeaderText(u"New header text");
	// đặt văn bản cho placeholder Footer của slide ghi chú
	headerFooterManager->SetFooterText(u"New footer text");
	// đặt văn bản cho placeholder Date-time của slide ghi chú
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể thêm "header" vào các slide bình thường không?**

Trong PowerPoint, "Header" chỉ tồn tại cho notes và handout; trên các slide bình thường, các phần tử được hỗ trợ là footer, ngày/giờ và số slide. Trong Aspose.Slides điều này cũng tương tự: header chỉ áp dụng cho Notes/Handout, còn trên slide thì có Footer/DateTime/SlideNumber.

**Nếu bố cục không có vùng footer—tôi có thể "bật" hiển thị của nó không?**

Có. Kiểm tra trạng thái hiển thị qua trình quản lý header/footer và bật nó nếu cần. Các chỉ báo và phương thức API này được thiết kế cho các trường hợp placeholder bị thiếu hoặc bị ẩn.

**Làm sao để số slide bắt đầu từ giá trị khác 1?**

Đặt [first slide number](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/set_firstslidenumber/) của bài thuyết trình; sau đó, mọi việc đánh số sẽ được tính lại. Ví dụ, bạn có thể bắt đầu từ 0 hoặc 10, và ẩn số trên slide tiêu đề.

**Header/footer sẽ như thế nào khi xuất ra PDF/hình ảnh/HTML?**

Chúng được render như các phần tử văn bản thông thường của bài thuyết trình. Nghĩa là, nếu các phần tử này hiển thị trên slide/notes, chúng cũng sẽ xuất hiện trong định dạng đầu ra cùng với phần nội dung còn lại.