---
title: Quản lý tiêu đề và chân trang của bài thuyết trình trong .NET
linktitle: Tiêu đề và Chân trang
type: docs
weight: 140
url: /vi/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho .NET để thêm và tùy chỉnh tiêu đề và chân trang trong các bài thuyết trình PowerPoint và OpenDocument, mang lại vẻ ngoài chuyên nghiệp."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý cài đặt header và footer trong các bài thuyết trình PowerPoint. Header và footer được xử lý ở mức master của bài thuyết trình, và API cung cấp các phương thức để đặt văn bản footer, thay đổi hiển thị footer, và cập nhật văn bản header trên các slide ghi chú master.

Bạn cũng có thể quản lý header và footer cho các slide handout và notes. Điều này bao gồm việc thay đổi hiển thị và văn bản của các placeholder header, footer, số slide, và ngày‑giờ cho notes master, tất cả các slide notes con, hoặc một slide notes riêng lẻ.

## **Quản lý Văn bản Header và Footer**

Ghi chú của một số slide cụ thể có thể được cập nhật như trong ví dụ dưới đây:

```c#
// Tải bài thuyết trình
Presentation pres = new Presentation("headerTest.pptx");

// Đặt chân trang
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Truy cập và cập nhật tiêu đề
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// Lưu bài thuyết trình
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```


```c#
// Phương thức để đặt Văn bản Header/Footer
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```

## **Quản lý Header và Footer trên Slide Handout và Notes**

Aspose.Slides cho .NET hỗ trợ Header và Footer trên các slide Handout và notes. Vui lòng làm theo các bước dưới đây:

- Tải một [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)chứa video.
- Thay đổi cài đặt Header và Footer cho notes master và tất cả các slide notes.
- Đặt các placeholder Footer trên master notes slide và tất cả các slide con hiển thị.
- Đặt các placeholder Date và time trên master notes slide và tất cả các slide con hiển thị.
- Thay đổi cài đặt Header và Footer chỉ cho slide notes đầu tiên.
- Đặt placeholder Header của slide notes hiển thị.
- Đặt văn bản cho placeholder Header của slide notes.
- Đặt văn bản cho placeholder Date-time của slide notes.
- Ghi file bài thuyết trình đã chỉnh sửa.

Đoạn mã mẫu được cung cấp trong ví dụ dưới đây.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Thay đổi cài đặt Header và Footer cho notes master và tất cả các slide ghi chú
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // làm cho slide ghi chú master và tất cả các placeholder Footer con hiển thị
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // làm cho slide ghi chú master và tất cả các placeholder Header con hiển thị
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // làm cho slide ghi chú master và tất cả các placeholder SlideNumber con hiển thị
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // làm cho slide ghi chú master và tất cả các placeholder Date và time con hiển thị

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // đặt văn bản cho slide ghi chú master và tất cả các placeholder Header con
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // đặt văn bản cho slide ghi chú master và tất cả các placeholder Footer con
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // đặt văn bản cho slide ghi chú master và tất cả các placeholder Date và time con
	}

	// Thay đổi cài đặt Header và Footer chỉ cho slide ghi chú đầu tiên
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // làm cho placeholder Header của slide ghi chú này hiển thị

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // làm cho placeholder Footer của slide ghi chú này hiển thị

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // làm cho placeholder SlideNumber của slide ghi chú này hiển thị

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // làm cho placeholder Date-time của slide ghi chú này hiển thị

		headerFooterManager.SetHeaderText("New header text"); // đặt văn bản cho placeholder Header của slide ghi chú
		headerFooterManager.SetFooterText("New footer text"); // đặt văn bản cho placeholder Footer của slide ghi chú
		headerFooterManager.SetDateTimeText("New date and time text"); // đặt văn bản cho placeholder Date-time của slide ghi chú
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **Câu hỏi thường gặp**

**Tôi có thể thêm "header" vào các slide thường không?**

Trong PowerPoint, "Header" chỉ tồn tại cho notes và handouts; trên các slide thường, các yếu tố được hỗ trợ là footer, ngày/giờ và số slide. Trong Aspose.Slides điều này cũng giống nhau: header chỉ áp dụng cho Notes/Handout, và trên các slide—Footer/DateTime/SlideNumber.

**Nếu bố cục không chứa khu vực footer—tôi có thể "bật" hiển thị của nó không?**

Có. Kiểm tra tính hiển thị thông qua trình quản lý header/footer và bật nó nếu cần. Các chỉ báo và phương thức API này được thiết kế cho trường hợp placeholder bị thiếu hoặc ẩn.

**Làm sao để số slide bắt đầu từ giá trị khác 1?**

Đặt [first slide number](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/firstslidenumber/) của bài thuyết trình; sau đó, tất cả các số sẽ được tính lại. Ví dụ, bạn có thể bắt đầu từ 0 hoặc 10, và ẩn số trên slide tiêu đề.

**Điều gì xảy ra với header/footer khi xuất sang PDF/hình ảnh/HTML?**

Chúng được render như các yếu tố văn bản thông thường của bài thuyết trình. Nghĩa là, nếu các yếu tố này hiển thị trên slide/notes, chúng cũng sẽ xuất hiện trong định dạng đầu ra cùng với phần nội dung còn lại.