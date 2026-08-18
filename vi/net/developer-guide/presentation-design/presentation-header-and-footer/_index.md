---
title: Quản lý tiêu đề và chân trang trong .NET
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
- tài liệu phát tay
- ghi chú
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách quản lý các vị trí giữ chỗ chân trang, ngày-giờ, số slide và tiêu đề trên slide, trang ghi chú và tài liệu phát tay với Aspose.Slides cho .NET."
---
## **Tổng quan**

PowerPoint sử dụng các vị trí giữ chỗ tiêu đề và chân trang khác nhau tùy theo loại trang. Aspose.Slides for .NET cho phép bạn kiểm soát văn bản và khả năng hiển thị của các vị trí giữ chỗ này thông qua các giao diện quản lý tiêu đề/chân trang.

Các vị trí giữ chỗ có sẵn phụ thuộc vào phạm vi:

| Phạm vi | Đầu đề | Chân trang | Ngày/giờ | Số slide/trang |
|---|---|---|---|---|
| Slide thông thường | Không | Có | Có | Có |
| Master ghi chú | Có | Có | Có | Có |
| Slide ghi chú | Có | Có | Có | Có |
| Master tài liệu phát tay | Có | Có | Có | Có |

Một slide trình chiếu thông thường không có vị trí giữ chỗ đầu đề. Đầu đề chỉ có trên các trang ghi chú và tài liệu phát tay. Đối với các slide thông thường, sử dụng các vị trí giữ chỗ chân trang, ngày/giờ và số slide thay vì đầu đề.

Phạm vi của một thay đổi phụ thuộc vào trình quản lý bạn sử dụng. Giao diện [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/islideheaderfootermanager/) điều khiển một slide thông thường. Giao diện [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/inotesslideheaderfootermanager/) điều khiển một slide ghi chú. Các trình quản lý master và layout cũng có thể truyền các cài đặt tới các slide phụ thuộc, trong khi giao diện [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterhandoutslideheaderfootermanager/) điều khiển master tài liệu phát tay.

## **Đặt chân trang, ngày/giờ và số slide trên các slide thông thường**

Đối với các slide thông thường, quy trình cơ bản là truy cập trình quản lý tiêu đề/chân trang của từng slide, đặt văn bản chân trang và ngày/giờ, kích hoạt các vị trí giữ chỗ cần thiết và lưu bản trình chiếu. Số slide được tạo tự động bởi bản trình chiếu, vì vậy bạn chỉ cần kiểm soát khả năng hiển thị của chúng.

Sử dụng [`SetFooterText`](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) và [`SetDateTimeText`](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) để đặt văn bản, và sử dụng [`SetFooterVisibility`](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), và [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) để hiển thị các vị trí giữ chỗ tương ứng.

Ví dụ toàn diện dưới đây áp dụng cùng một chân trang, văn bản ngày/giờ và khả năng hiển thị số slide cho tất cả các slide thông thường:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Nếu bạn chỉ cần cập nhật một slide, truy cập trực tiếp slide đó thông qua bộ sưu tập [`Slides`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slides/vi/) thay vì lặp qua toàn bộ bộ sưu tập.

## **Đặt đầu đề và chân trang trên Master ghi chú**

Master ghi chú xác định định dạng chung và hành vi vị trí giữ chỗ cho các trang ghi chú. Sử dụng giao diện [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasternotesslideheaderfootermanager/) khi bạn muốn thay đổi chỉ master ghi chú.

Ví dụ sau đặt đầu đề, chân trang và văn bản ngày/giờ trên master ghi chú và làm cho tất cả các vị trí giữ chỗ được hỗ trợ hiển thị trên master đó:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

Thuộc tính [`MasterNotesSlide`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasternotesslidemanager/masternotesslide/) sẽ trả về `null` khi bản trình chiếu không chứa master ghi chú.

## **Áp dụng cài đặt Master ghi chú cho các Slide ghi chú con**

Master ghi chú có thể áp dụng cài đặt đầu đề và chân trang cho chính nó và cho tất cả các slide ghi chú phụ thuộc. Sử dụng các phương pháp truyền tải chuyên biệt trên [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasternotesslideheaderfootermanager/) khi cùng một cài đặt cần được áp dụng trên toàn bộ cây ghi chú.

Ví dụ, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) và [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) cập nhật đầu đề master ghi chú và tất cả các đầu đề con. Các phương pháp tương đương cũng có sẵn cho chân trang, ngày/giờ và số slide.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Các phương pháp truyền tải được sử dụng ở trên là [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), và [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/vi/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Đặt đầu đề và chân trang trên một Slide ghi chú cá nhân**

Một slide ghi chú thuộc về một slide thông thường cụ thể. Sử dụng giao diện [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/inotesslideheaderfootermanager/) khi bạn muốn tùy chỉnh chỉ trang ghi chú đó.

Phương pháp [`AddNotesSlide`](https://reference.aspose.com/slides/vi/net/aspose.slides/inotesslidemanager/addnotesslide/) trả về slide ghi chú cho slide hiện tại và tạo mới nếu chưa tồn tại. Ví dụ sau cấu hình trang ghi chú liên kết với slide trình chiếu đầu tiên:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Nếu bạn trước tiên truyền tải cài đặt từ master ghi chú và sau đó thay đổi một slide ghi chú cá nhân, các cài đặt theo slide sau này cho phép bạn tùy chỉnh trang ghi chú đó một cách độc lập.

## **Đặt đầu đề và chân trang trên Master tài liệu phát tay**

Các trang tài liệu phát tay sử dụng master tài liệu phát tay cho các vị trí giữ chỗ đầu đề, chân trang, ngày/giờ và số trang. Không giống như các trang ghi chú, cài đặt tài liệu phát tay được quản lý thông qua master tài liệu phát tay chứ không phải từng slide tài liệu phát tay riêng lẻ.

Sử dụng thuộc tính [`MasterHandoutSlide`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) để truy cập master tài liệu phát tay. Nếu không tồn tại, gọi [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) để tạo master tài liệu phát tay mặc định.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Hiểu về phạm vi và kế thừa**

Chọn trình quản lý đầu đề/chân trang phù hợp với phạm vi bạn muốn thay đổi:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/islideheaderfootermanager/) thay đổi cài đặt chân trang, ngày/giờ và số slide cho một slide thông thường.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslideheaderfootermanager/) điều khiển một slide layout và có thể truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslideheaderfootermanager/) điều khiển một master slide thông thường và có thể truyền các cài đặt được hỗ trợ tới các slide phụ thuộc.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasternotesslideheaderfootermanager/) điều khiển master ghi chú và có thể truyền cài đặt tới tất cả các slide ghi chú phụ thuộc.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/inotesslideheaderfootermanager/) thay đổi một slide ghi chú và hỗ trợ vị trí giữ chỗ đầu đề bên cạnh chân trang, ngày/giờ và số slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterhandoutslideheaderfootermanager/) thay đổi master tài liệu phát tay và hỗ trợ cả bốn loại vị trí giữ chỗ.

Sử dụng việc truyền tải từ một master hoặc layout khi cùng một cài đặt phải áp dụng trên toàn bộ cây của nó. Sử dụng một slide cá nhân hoặc trình quản lý slide‑ghi chú khi bạn cần một cài đặt cục bộ cho một trang.

## **Câu hỏi thường gặp**

**Có thể thêm đầu đề vào slide thông thường không?**

Không. PowerPoint không định nghĩa vị trí giữ chỗ đầu đề cho các slide thông thường. Trên các slide thông thường, sử dụng các vị trí giữ chỗ chân trang, ngày/giờ và số slide. Vị trí giữ chỗ đầu đề chỉ có trên các trang ghi chú và tài liệu phát tay.

**Nếu vị trí giữ chỗ chân trang, ngày/giờ hoặc số slide không hiển thị thì sao?**

Sử dụng trình quản lý tiêu đề/chân trang tương ứng để kiểm tra khả năng hiển thị và bật nó khi cần. Ví dụ, [`IsFooterVisible`](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) báo cáo liệu vị trí giữ chỗ chân trang có tồn tại hay không, và [`SetFooterVisibility`](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) thay đổi khả năng hiển thị của nó.

**Làm thế nào để bắt đầu đánh số slide từ giá trị khác 1?**

Đặt thuộc tính [`FirstSlideNumber`](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/firstslidenumber/) của bản trình chiếu. Các vị trí giữ chỗ số slide sau đó sẽ sử dụng chuỗi đánh số đã cập nhật.

**Điều gì xảy ra với đầu đề và chân trang khi xuất ra PDF, ảnh hoặc HTML?**

Các yếu tố đầu đề và chân trang hiện ra sẽ được vẽ cùng với phần còn lại của nội dung bản trình chiếu trong định dạng đầu ra. Diện mạo của chúng phụ thuộc vào loại trang đang được xuất và các cài đặt khả năng hiển thị vị trí giữ chỗ tương ứng.