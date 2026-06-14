---
title: Truy cập các slide trong bài thuyết trình bằng .NET
linktitle: Truy cập Slide
type: docs
weight: 20
url: /vi/net/access-slide-in-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách truy cập và quản lý các slide trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Tăng năng suất với các ví dụ mã."
---
## **Tổng quan**

Bài viết này giải thích cách truy cập và quản lý các slide trong một bài thuyết trình bằng cách sử dụng Aspose.Slides. Nó minh họa cách lấy các slide theo chỉ mục bắt đầu từ 0 từ bộ sưu tập `Slides` và cách truy cập một slide bằng ID duy nhất của nó bằng phương thức `GetSlideById`.

Bạn cũng sẽ học cách thay đổi vị trí của một slide bằng cách đặt thuộc tính `SlideNumber` và cách xác định số slide bắt đầu cho một bài thuyết trình bằng thuộc tính `FirstSlideNumber`. Các ví dụ minh họa cách tải một bài thuyết trình, lấy tham chiếu tới slide, cập nhật thứ tự hoặc số thứ tự của slide, và lưu lại bài thuyết trình đã sửa đổi.

## **Truy cập slide theo chỉ mục**

Tất cả các slide trong một bài thuyết trình được sắp xếp theo thứ tự số dựa trên vị trí slide, bắt đầu từ 0. Slide đầu tiên có thể truy cập bằng chỉ mục 0; slide thứ hai được truy cập bằng chỉ mục 1; v.v.

Lớp Presentation, đại diện cho tệp bài thuyết trình, cung cấp tất cả các slide dưới dạng một bộ sưu tập [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) (bộ sưu tập các đối tượng [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/)). Đoạn mã C# này cho bạn thấy cách truy cập một slide qua chỉ mục của nó:

```c#
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
Presentation presentation = new Presentation("AccessSlides.pptx");

// Lấy tham chiếu của một slide qua chỉ mục của nó
ISlide slide = presentation.Slides[0];
```

## **Truy cập slide theo ID**

Mỗi slide trong một bài thuyết trình có một ID duy nhất liên kết với nó. Bạn có thể sử dụng phương thức [GetSlideById](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/methods/getslidebyid) (được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)) để nhắm mục tiêu ID đó. Đoạn mã C# này cho bạn thấy cách cung cấp một ID slide hợp lệ và truy cập slide đó thông qua phương thức [GetSlideById](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/methods/getslidebyid):

```c#
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
Presentation presentation = new Presentation("AccessSlides.pptx");

// Lấy ID của slide
uint id = presentation.Slides[0].SlideId;

// Truy cập slide qua ID của nó
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Thay đổi vị trí slide**

Aspose.Slides cho phép bạn thay đổi vị trí của một slide. Ví dụ, bạn có thể chỉ định rằng slide đầu tiên sẽ trở thành slide thứ hai.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu của slide (vị trí mà bạn muốn thay đổi) qua chỉ mục của nó
1. Đặt vị trí mới cho slide qua thuộc tính [SlideNumber](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/slidenumber/).
1. Lưu bài thuyết trình đã sửa đổi.

Đoạn mã C# này minh họa một thao tác trong đó slide ở vị trí 1 được chuyển đến vị trí 2:

```c#
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Lấy slide mà vị trí sẽ được thay đổi
    ISlide sld = pres.Slides[0];

    // Đặt vị trí mới cho slide
    sld.SlideNumber = 2;

    // Lưu bài thuyết trình đã sửa đổi
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

Slide đầu tiên trở thành slide thứ hai; slide thứ hai trở thành slide đầu tiên. Khi bạn thay đổi vị trí của một slide, các slide khác sẽ được điều chỉnh tự động.

## **Đặt số slide**

Sử dụng thuộc tính [FirstSlideNumber](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/firstslidenumber/) (được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)), bạn có thể chỉ định một số mới cho slide đầu tiên trong một bài thuyết trình. Thao tác này sẽ làm cho các số slide khác được tính lại.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy số slide.
1. Đặt số slide.
1. Lưu bài thuyết trình đã sửa đổi.

Đoạn mã C# này minh họa một thao tác mà số slide đầu tiên được đặt thành 10:

```c#
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bài thuyết trình
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Lấy số slide
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Đặt số slide
    presentation.FirstSlideNumber=10;
    
    // Lưu bài thuyết trình đã sửa đổi
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

Nếu bạn muốn bỏ qua slide đầu tiên, bạn có thể bắt đầu đánh số từ slide thứ hai (và ẩn số thứ tự cho slide đầu tiên) như sau:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Đặt số cho slide đầu tiên của bài thuyết trình
    presentation.FirstSlideNumber = 0;

    // Hiển thị số slide cho tất cả các slide
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Ẩn số slide cho slide đầu tiên
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Lưu bài thuyết trình đã sửa đổi
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Số slide mà người dùng thấy có khớp với chỉ mục bắt đầu từ 0 của bộ sưu tập không?**

Số hiển thị trên một slide có thể bắt đầu từ một giá trị bất kỳ (ví dụ, 10) và không nhất thiết phải khớp với chỉ mục; mối quan hệ này được điều khiển bởi cài đặt [số slide đầu tiên](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/firstslidenumber/) của bài thuyết trình.

**Các slide ẩn có ảnh hưởng đến việc chỉ mục không?**

Có. Slide ẩn vẫn nằm trong bộ sưu tập và được tính trong việc chỉ mục; “ẩn” chỉ đề cập đến việc hiển thị, không phải vị trí của nó trong bộ sưu tập.

**Chỉ mục của một slide có thay đổi khi các slide khác được thêm hoặc xóa không?**

Có. Chỉ mục luôn phản ánh thứ tự hiện tại của các slide và được tính lại khi thực hiện các thao tác chèn, xóa và di chuyển.