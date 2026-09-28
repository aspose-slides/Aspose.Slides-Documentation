---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong .NET
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/net/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- placeholder
- thiết kế bài thuyết trình
- thiết kế slide
- bố cục không sử dụng
- hiển thị footer
- slide tiêu đề
- tiêu đề và nội dung
- tiêu đề phần
- hai nội dung
- so sánh
- chỉ tiêu đề
- bố cục trống
- nội dung có chú thích
- hình ảnh có chú thích
- tiêu đề và văn bản dọc
- tiêu đề dọc và văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- C#
- .NET
- Aspose.Slides
description: "Áp dụng, tạo và sửa đổi bố cục slide trong Aspose.Slides cho .NET, thêm placeholder, xóa các bố cục không sử dụng và kiểm soát hiển thị footer."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các placeholder như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán đồng thời cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các placeholder tiêu đề và phụ đề.
- **Title and Content**: Chứa một placeholder tiêu đề và một placeholder nội dung đa mục đích.
- **Blank**: Không chứa placeholder nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về kế thừa bố cục**

Một bản trình chiếu có ba cấp độ liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/) xác định chủ đề, định dạng chung, nền và các đối tượng chung.
2. Một [layout slide](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/) thuộc về một master và xác định một sắp xếp cụ thể của các placeholder.
3. Một [normal slide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/) sử dụng một bố cục và lưu trữ nội dung đã nhập cho slide đó.

Slide thường kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục kế thừa từ master. Giá trị được đặt trực tiếp trên slide thường sẽ ghi đè giá trị được kế thừa ở cấp độ đó. Khi một slide thường được tạo, các hình dạng placeholder của nó được tạo ra từ bố cục đã chọn, trong khi nội dung nhập vào các placeholder đó thuộc về slide thường.

Thêm các placeholder cần thiết vào một bố cục trước khi tạo slide từ nó. Thêm một placeholder khác vào bố cục sau này sẽ không tự động thêm hình dạng placeholder tương ứng vào các slide thường đã tồn tại.

Mối quan hệ này có hai hệ quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học placeholder hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem xét bản trình chiếu kết quả.
- Một bố cục đang được một slide sử dụng không thể bị xóa. Hãy gán lại các slide phụ thuộc của nó sang một bố cục khác trước, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp độ cao nhất của cấu trúc này, xem [Slide Master](/slides/vi/net/slide-master/).

Để ẩn logo kế thừa hoặc các hình dạng master trang trí trên một slide hoặc thông qua một bố cục chung, xem [Control the Visibility of Master Graphics](/slides/vi/net/slide-master/). Ví dụ so sánh hai slide sử dụng cùng một master.

## **Chọn và áp dụng một bố cục slide**

Sử dụng loại bố cục khi bản trình chiếu tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được bản địa hoá, vì vậy việc chọn dựa trên tên ít tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu bố cục đó không có, nó cố ý chuyển sang **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình chiếu có thể chỉ chứa các bố cục tùy chỉnh. Bố cục được chọn sau đó được áp dụng cho slide thường đầu tiên thông qua thuộc tính [ISlide.LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Thay đổi bố cục của một slide không xóa các hình dạng thông thường đã được thêm trực tiếp vào slide. Tuy nhiên, vị trí placeholder, định dạng kế thừa và sự tương ứng giữa các placeholder hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển đổi giữa các bố cục khác nhau đáng kể.

## **Thêm một bố cục slide**

Việc chọn và tạo là các hoạt động riêng biệt. Ví dụ trước chọn một bố cục hiện có; nó không tạo ra một bố cục mới. Để tạo một bố cục, gọi phương thức [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/vi/net/aspose.slides/masterlayoutslidecollection/add/) trên bộ sưu tập bố cục của master mục tiêu.

Ví dụ sau luôn thêm một bố cục **Title and Content** mới có tên `Report Title and Content`, rồi thêm một slide thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Chỉ thêm một bố cục khi mẫu thực sự cần một cấu trúc có thể tái sử dụng khác. Nếu đã có một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm Placeholder vào một bố cục slide**

Thuộc tính [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/placeholdermanager/) cung cấp một [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutplaceholdermanager/) để thêm các shape placeholder vào một bố cục.

| Placeholder PowerPoint | Phương thức `ILayoutPlaceholderManager` |
| ----------------------- | ---------------------------------------- |
| ![Nội dung](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Nội dung (Dọc)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Văn bản](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Văn bản (Dọc)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Hình ảnh](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Biểu đồ](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Bảng](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Phương tiện](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Hình ảnh trực tuyến](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Ví dụ sau kiểm tra xem bố cục **Blank** có tồn tại hay không, thêm bốn placeholder vào nó, và sau đó tạo một slide thường sử dụng bố cục đã được sửa đổi. Thứ tự này có ý định: các placeholder được thêm trước khi slide thường được tạo, vì vậy Aspose.Slides có thể tạo các shape placeholder tương ứng trên slide đó.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Kết quả:

![Các placeholder trên bố cục slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các placeholder bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một placeholder bố cục mới được thêm vào sẽ không được tự động đưa vào các slide thường hiện có. Hãy thử các thay đổi bố cục trên một bản sao của bản trình chiếu và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các bố cục slide không sử dụng**

Sử dụng phương thức [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để xóa các bố cục mà không có slide thường nào tham chiếu. Phương thức này để lại các bố cục vẫn đang được sử dụng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Để xóa một bố cục cụ thể, trước tiên sử dụng thuộc tính [HasDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/hasdependingslides/) hoặc phương thức [GetDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/getdependingslides/) của nó. Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [ILayoutSlide.Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/remove/). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra lỗi [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception/).

## **Kiểm soát hiển thị Footer trên một bố cục slide**

Một bố cục có các placeholder footer, số slide và ngày‑giờ riêng. Sử dụng thuộc tính [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/headerfootermanager/) để kiểm soát các placeholder đó cho một bố cục. Điều này hữu ích khi, ví dụ, các bố cục nội dung nên hiển thị footer nhưng các bố cục tiêu đề thì không.

Ví dụ sau chọn một bố cục một cách an toàn và làm cho các yếu tố footer của nó hiển thị:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Kiểm soát hiển thị Footer trên Master và các Layout con**

Để áp dụng cài đặt footer nhất quán trên toàn bộ cấu trúc master, sử dụng thuộc tính [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/headerfootermanager/). Các phương pháp lan truyền của [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslideheaderfootermanager/) hoạt động trên master và các layout slide phụ thuộc cũng như các slide thường; chúng không chỉ áp dụng cho một slide thường duy nhất.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Một master slide xác định chủ đề và định dạng chung của bản trình chiếu. Một layout slide thuộc về một master và xác định một sắp xếp placeholder có thể tái sử dụng. Các slide thường sử dụng các bố cục này và lưu trữ nội dung riêng cho từng slide.

**Tôi có thể sao chép một Layout Slide từ một bản trình chiếu sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/globallayoutslidecollection/addclone/). Khi sao chép giữa các bản trình chiếu, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác được bố cục nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi của bố cục trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng tại chỗ. Do đó, hình học placeholder và kiểu kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [GetDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/getdependingslides/) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa bố cục.

**Điều gì xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception/). Đầu tiên hãy gán lại các slide phụ thuộc, hoặc sử dụng [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để chỉ xóa các bố cục không được tham chiếu.