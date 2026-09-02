---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong .NET
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/net/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- trình giữ chỗ
- thiết kế bản trình bày
- thiết kế slide
- bố cục không sử dụng
- hiển thị footer
- slide tiêu đề
- tiêu đề và nội dung
- đầu mục phần
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
- bản trình bày
- C#
- .NET
- Aspose.Slides
description: "Áp dụng, tạo và sửa đổi bố cục slide trong Aspose.Slides cho .NET, thêm trình giữ chỗ, xóa bố cục không sử dụng và kiểm soát hiển thị footer."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các placeholder như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán trong khi cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các placeholder tiêu đề và phụ đề.
- **Title and Content**: Chứa một placeholder tiêu đề và một placeholder nội dung chung.
- **Blank**: Không chứa placeholder nội dung nào và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về Kế thừa Bố cục**

Một bản trình bày có ba cấp độ liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/) xác định chủ đề, định dạng chung, nền và các đối tượng chung.
2. Một [layout slide](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/) thuộc về một master và xác định một sắp xếp cụ thể của các placeholder.
3. Một [normal slide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/) sử dụng một bố cục và lưu trữ nội dung đã nhập cho slide đó.

Một normal slide kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục kế thừa từ master của nó. Giá trị được đặt trực tiếp trên một normal slide sẽ ghi đè giá trị kế thừa ở cấp độ đó. Khi một normal slide được tạo, các shape placeholder của nó được tạo ra từ bố cục đã chọn, trong khi nội dung nhập vào các placeholder đó thuộc về normal slide.

Thêm các placeholder cần thiết vào một bố cục trước khi tạo slide từ nó. Thêm một placeholder khác vào bố cục sau này sẽ không tự động thêm shape placeholder tương ứng vào các normal slide đã tồn tại.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của các placeholder hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem lại bản trình bày kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Đầu tiên hãy gán lại các slide phụ thuộc của nó sang một bố cục khác, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cấu trúc này, xem [Slide Master](/slides/vi/net/slide-master/).

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng kiểu bố cục khi bản trình bày tuân theo các định nghĩa bố cục tiêu chuẩn của PowerPoint. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được địa phương hoá, do đó việc chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu bố cục đó không khả dụng, nó sẽ cố ý chuyển sang **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình bày có thể chỉ chứa các bố cục tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide bình thường đầu tiên thông qua thuộc tính [ISlide.LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/layoutslide/).

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

Thay đổi bố cục của một slide không loại bỏ các shape thông thường đã được thêm trực tiếp vào slide. Tuy nhiên, vị trí placeholder, định dạng kế thừa và sự tương ứng giữa các placeholder hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra đầu ra khi chuyển đổi giữa các bố cục khác nhau đáng kể.

## **Thêm Layout Slide**

Lựa chọn và tạo mới là các thao tác riêng biệt. Ví dụ trước chọn một bố cục hiện có; nó không tạo mới. Để tạo một bố cục, gọi phương thức [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/vi/net/aspose.slides/masterlayoutslidecollection/add/) trên bộ sưu tập bố cục của master mục tiêu.

Ví dụ sau luôn thêm một bố cục **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một normal slide dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Chỉ thêm bố cục khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã có một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm Placeholder vào Layout Slide**

Thuộc tính [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/placeholdermanager/) cung cấp một [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutplaceholdermanager/) để thêm các shape placeholder vào một bố cục.

| Placeholder PowerPoint               | `ILayoutPlaceholderManager` Phương thức |
| ------------------------------------ | --------------------------------------- |
| ![Content](content.png)              | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png)  | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                    | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)        | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)              | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)                  | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)                  | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)            | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                  | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)     | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Ví dụ sau xác nhận rằng bố cục **Blank** tồn tại, thêm bốn placeholder vào nó, và sau đó tạo một normal slide sử dụng bố cục đã chỉnh sửa. Thứ tự này có chủ đích: các placeholder được thêm trước khi normal slide được tạo, để Aspose.Slides có thể tạo các shape placeholder tương ứng trên slide đó.

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

![Các placeholder trên layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các placeholder hiện có trên bố cục có thể ảnh hưởng đến các slide phụ thuộc. Một placeholder mới được thêm vào không được tự động bổ sung vào các normal slide đã tồn tại. Hãy thử các thay đổi bố cục trên một bản sao của bản trình bày và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa Layout Slides Không sử dụng**

Sử dụng phương thức [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để xóa các bố cục mà không có normal slide nào tham chiếu. Phương thức sẽ để nguyên các bố cục vẫn đang được sử dụng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Để xóa một bố cục cụ thể, đầu tiên hãy sử dụng thuộc tính [HasDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/hasdependingslides/) hoặc phương thức [GetDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/getdependingslides/). Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [ILayoutSlide.Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/remove/). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception/).

## **Kiểm soát Hiển thị Footer trên Layout Slide**

Một layout có footer, số slide và placeholder ngày‑giờ riêng. Sử dụng thuộc tính [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/headerfootermanager/) để điều khiển các placeholder này cho một layout. Điều này hữu ích khi, ví dụ, các layout nội dung cần hiển thị footer nhưng các layout tiêu đề thì không.

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

## **Kiểm soát Hiển thị Footer trên Master và Các Layout Con của Nó**

Để áp dụng cài đặt footer nhất quán trên toàn bộ cây master, sử dụng thuộc tính [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/headerfootermanager/). Các phương pháp lan truyền của [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslideheaderfootermanager/) hoạt động trên master và các layout slide cũng như normal slide phụ thuộc; chúng không chỉ ảnh hưởng đến một normal slide duy nhất.

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

**Sự khác biệt giữa Master Slide và Layout Slide là gì?**

Master slide xác định chủ đề và định dạng chung của bản trình bày. Layout slide thuộc về một master và xác định một cách sắp xếp placeholder có thể tái sử dụng. Normal slide sử dụng các layout này và lưu trữ nội dung riêng cho từng slide.

**Tôi có thể sao chép Layout Slide từ một bản trình bày sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương pháp [AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/globallayoutslidecollection/addclone/). Khi sao chép giữa các bản trình bày, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác mà layout nguồn sử dụng.

**Điều gì sẽ xảy ra nếu tôi chỉnh sửa một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi của layout trừ khi chúng đã ghi đè định dạng hoặc đối tượng liên quan cục bộ. Vì vậy hình học placeholder và kiểu định dạng kế thừa có thể thay đổi đồng thời trên nhiều slide. Sử dụng [GetDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/getdependingslides/) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa layout.

**Nếu tôi xóa một Layout vẫn đang được sử dụng thì sẽ ra sao?**

Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception/). Hãy gán lại các slide phụ thuộc trước, hoặc dùng [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) để chỉ xóa những layout không được tham chiếu.