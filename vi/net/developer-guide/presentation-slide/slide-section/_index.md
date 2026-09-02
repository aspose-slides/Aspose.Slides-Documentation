---
title: Quản lý các phần slide trong bản trình chiếu trong .NET
linktitle: Phần Slide
type: docs
weight: 100
url: /vi/net/slide-section/
keywords:
- tạo phần
- thêm phần
- chỉnh sửa phần
- thay đổi phần
- tên phần
- lấy slide của phần
- xử lý slide của phần
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quản lý các phần slide với Aspose.Slides cho .NET: tạo, đổi tên, sắp xếp lại, truy xuất và xử lý slide của phần trong các bản trình bày PPTX."
---
## **Giới thiệu**

Các phần tổ chức các slide liên tiếp thành các nhóm có tên mà không thay đổi nội dung slide. Với Aspose.Slides for .NET, bạn có thể tạo, sắp xếp lại, đổi tên, kiểm tra và xóa các phần thông qua thuộc tính [Presentation.Sections](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sections/) .

Các phần đặc biệt hữu ích khi:

- một bản trình bày lớn cần được chia thành các chủ đề hoặc chương logic;
- các nhóm slide khác nhau được giao cho các cộng tác viên khác nhau;
- các slide cần được xử lý, di chuyển hoặc hợp nhất dưới dạng nhóm.

Chọn các tên phần ngắn gọn mô tả mục đích của các slide đã được nhóm lại. Vì các phần là một phần của cấu trúc bản trình bày, hãy sử dụng API phần để xác định thành viên thay vì suy ra từ vị trí slide.

## **Tạo và Quản lý Các Phần**

Sử dụng [ISectionCollection.AddSection](https://reference.aspose.com/slides/vi/net/aspose.slides/sectioncollection/addsection/) để tạo một phần bằng cách chỉ định tên và slide bắt đầu. Aspose.Slides xác định slide nào thuộc phần dựa trên cấu trúc phần hiện tại của bản trình bày.

Cùng với [ISectionCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/isectioncollection/) còn cho phép bạn:

- di chuyển một phần cùng với các slide của nó bằng cách sử dụng [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/sectioncollection/reordersectionwithslides/) ;
- chỉ xóa định nghĩa phần bằng [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/vi/net/aspose.slides/sectioncollection/removesection/), giữ lại các slide của nó;
- xóa một phần và các slide của nó bằng [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/sectioncollection/removesectionwithslides/) ;
- thêm một phần rỗng ở cuối bằng [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/vi/net/aspose.slides/sectioncollection/appendemptysection/) .

Ví dụ dưới đây tạo hai phần, di chuyển một trong số chúng, xóa nó cùng với các slide, và thêm một phần rỗng ở cuối:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Sau các thao tác này, bản trình bày chứa phần `Introduction` với các slide của nó và một phần rỗng `Appendix`. Phần `Results` và các slide của nó đã bị xóa.

## **Đổi Tên Các Phần**

Để đổi tên một phần, đặt thuộc tính [ISection.Name](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/name/) của nó. Các slide và vị trí của phần vẫn không thay đổi.

Ví dụ dưới đây tạo một phần và thay đổi tên của nó:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Lấy Các Slide Từ Các Phần**

Thuộc tính [Presentation.Sections](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sections/) trả về một [ISectionCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/isectioncollection/) mà bạn có thể liệt kê. Đối với mỗi [ISection](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/), gọi [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/getslideslistofsection/) để lấy các slide hiện đang thuộc về nó. Phương thức trả về một [ISectionSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/isectionslidecollection/), cung cấp số lượng, truy cập theo chỉ mục và việc liệt kê.

Ví dụ dưới đây tạo hai phần đã được điền nội dung và một phần rỗng, sau đó in ra [tên](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/name/), [định danh](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/sectionid/), [slide bắt đầu](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/startedfromslide/), số lượng slide và số thứ tự slide của mỗi phần. Nó sử dụng bộ chỉ mục của collection để đọc slide đầu tiên và `foreach` để xử lý mọi slide. Đối với phần rỗng, collection trả về có số lượng bằng không, bộ chỉ mục không được truy cập và việc liệt kê không thực hiện vòng lặp nào.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

Sự thuộc về của phần được xác định bởi cấu trúc phần của bản trình bày. Không tự tính phạm vi của phần một cách thủ công từ [ISection.StartedFromSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/startedfromslide/), chỉ mục slide và slide bắt đầu của phần tiếp theo.

Việc chỉnh sửa cấu trúc có thể thay đổi cả các slide trả về cho một phần và số thứ tự slide của chúng. Điều này bao gồm sắp xếp lại slide, sao chép một slide vào một phần, di chuyển một phần cùng với các slide của nó, xóa slide và xóa phần. Ví dụ tiếp theo gọi [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/getslideslistofsection/) sau mỗi thay đổi như vậy thay vì giữ các giả định về giới hạn trước của phần.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Gọi lại [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/getslideslistofsection/) bất cứ khi nào slide hoặc phần được sắp xếp lại, sao chép, di chuyển hoặc xóa. Điều này giữ cho việc xử lý tiếp theo đồng bộ với cấu trúc bản trình bày hiện tại.

Định dạng PPT (PowerPoint 97–2003) không lưu trữ siêu dữ liệu phần. Hãy sử dụng quy trình này với định dạng hỗ trợ các phần, chẳng hạn như PPTX; việc chuyển đổi sang PPT sẽ loại bỏ cấu trúc phần cần thiết cho việc liệt kê sau này.

## **Câu hỏi thường gặp**

**Các phần có được giữ lại khi lưu dưới định dạng PPT (PowerPoint 97–2003) không?**

Không. Định dạng PPT không hỗ trợ siêu dữ liệu phần, do đó việc nhóm phần sẽ bị mất khi lưu dưới dạng .ppt.

**Có thể ẩn toàn bộ một phần không?**

Không. Một phần không có trạng thái hiển thị. Để ẩn nội dung của nó, hãy đặt thuộc tính [ISlide.Hidden](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/hidden/) cho mỗi slide trong phần đó.

**Làm thế nào tôi có thể tìm phần chứa một slide?**

Liệt kê [Presentation.Sections](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/sections/), gọi [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/getslideslistofsection/) cho mỗi phần, và so sánh các slide trả về với slide mục tiêu. Đối với phần không rỗng, [ISection.StartedFromSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/isection/startedfromslide/) trả về slide đầu tiên; đối với phần rỗng, nó trả về `null`.