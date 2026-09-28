---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong JavaScript
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/nodejs-java/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- trình giữ chỗ
- thiết kế bài thuyết trình
- thiết kế slide
- bố cục không dùng
- hiển thị chân trang
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng, tạo và sửa đổi bố cục slide trong Aspose.Slides cho Node.js thông qua Java, thêm trình giữ chỗ, xóa các bố cục không dùng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các trình giữ chỗ như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán trong khi cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Tiêu đề Slide**: Chứa các trình giữ chỗ tiêu đề và phụ đề.
- **Tiêu đề và Nội dung**: Chứa một trình giữ chỗ tiêu đề và một trình giữ chỗ nội dung đa mục đích.
- **Trống**: Không chứa trình giữ chỗ nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về kế thừa bố cục**

Một bản trình chiếu có ba mức liên quan:

1. A [master slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
1. A [layout slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
1. A [normal slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

Một slide bình thường kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục kế thừa từ master. Giá trị được đặt trực tiếp trên slide bình thường sẽ ghi đè giá trị kế thừa ở mức đó. Khi một slide bình thường được tạo, các hình dạng trình giữ chỗ của nó được tạo ra từ bố cục đã chọn, trong khi nội dung được nhập vào các trình giữ chỗ đó thuộc về slide bình thường.

Thêm các trình giữ chỗ cần thiết vào một bố cục trước khi tạo slide từ nó. Thêm một trình giữ chỗ khác vào bố cục sau này không tự động thêm một hình dạng trình giữ chỗ tương ứng vào các slide bình thường đã tồn tại.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của các trình giữ chỗ hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, kiểm tra các slide phụ thuộc và xem lại bản trình chiếu kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Gán lại các slide phụ thuộc của nó sang một bố cục khác trước, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cây cấu trúc này, xem [Master Slide](/slides/vi/nodejs-java/slide-master/).

Để ẩn logo kế thừa hoặc các hình dạng trang trí master trên một slide hoặc qua một bố cục chia sẻ, xem [Kiểm soát Hiển thị Đồ họa Master](/slides/vi/nodejs-java/slide-master/). Ví dụ so sánh hai slide sử dụng cùng một master.

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng một giá trị [SlideLayoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidelayouttype/) khi bản trình chiếu tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được địa phương hóa, vì vậy việc chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu bố cục đó không có, nó cố ý chuyển sang **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình chiếu có thể chỉ chứa các bố cục tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide bình thường đầu tiên thông qua phương thức [Slide.setLayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Thay đổi bố cục của một slide không xóa các hình dạng thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí trình giữ chỗ, định dạng kế thừa và sự tương ứng giữa các trình giữ chỗ hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra đầu ra khi chuyển đổi giữa các bố cục có sự khác biệt đáng kể.

## **Thêm Bố cục Slide**

Lựa chọn và tạo mới là các thao tác riêng biệt. Ví dụ trước chỉ chọn một bố cục hiện có; nó không tạo một bố cục mới. Để tạo một bố cục, gọi phương thức [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) trên bộ sưu tập bố cục của master mục tiêu.

Ví dụ sau luôn thêm một bố cục **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một slide bình thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chỉ thêm bố cục khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã có một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm Trình giữ chỗ vào Bố cục Slide**

Phương thức [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) cung cấp một [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/) để thêm các hình dạng trình giữ chỗ vào một bố cục.

| Trình giữ chỗ PowerPoint | Phương thức `LayoutPlaceholderManager` |
| ------------------------ | -------------------------------------- |
| ![Nội dung](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Nội dung (Dọc)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Văn bản](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Văn bản (Dọc)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Hình ảnh](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Biểu đồ](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Bảng](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Phương tiện](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Hình ảnh trực tuyến](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Ví dụ sau xác nhận bố cục **Blank** tồn tại, thêm bốn trình giữ chỗ vào nó, và sau đó tạo một slide bình thường sử dụng bố cục đã chỉnh sửa. Thứ tự này có chủ đích: các trình giữ chỗ được thêm trước khi slide bình thường được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng trình giữ chỗ tương ứng trên slide đó.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các trình giữ chỗ trên bố cục slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các trình giữ chỗ bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một trình giữ chỗ bố cục mới được thêm vào sẽ không được tự động bổ sung vào các slide bình thường đã tồn tại. Hãy kiểm tra các thay đổi bố cục trên một bản sao của bản trình chiếu và kiểm tra từng slide phụ thuộc.
{{% /alert %}}

## **Xóa Bố cục Slide Không được Sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) để xóa các bố cục mà không có slide bình thường nào tham chiếu. Phương thức này giữ nguyên các bố cục vẫn đang được sử dụng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để xóa một bố cục cụ thể, trước tiên sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [LayoutSlide.remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#remove). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra lỗi [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/).

## **Kiểm soát hiển thị Chân trang trên Bố cục Slide**

Một bố cục có các trình giữ chỗ chân trang, số slide và ngày giờ riêng. Sử dụng phương thức [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) để kiểm soát các trình giữ chỗ này cho một bố cục. Điều này hữu ích khi, ví dụ, các bố cục nội dung cần hiển thị chân trang nhưng các bố cục tiêu đề thì không.

Ví dụ sau chọn một bố cục một cách an toàn và làm cho các phần tử chân trang của nó hiển thị:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm soát hiển thị Chân trang trên Master và các Bố cục Con của nó**

Để áp dụng cài đặt chân trang nhất quán trên toàn bộ cây master, sử dụng phương thức [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Các phương thức lan truyền của [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslideheaderfootermanager/) hoạt động trên master và các bố cục slide phụ thuộc cũng như các slide bình thường; chúng không chỉ nhắm vào một slide bình thường duy nhất.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Master Slide định nghĩa chủ đề và định dạng chung của bản trình chiếu. Layout Slide thuộc về một master và xác định một cách sắp xếp trình giữ chỗ có thể tái sử dụng. Các slide bình thường sử dụng các bố cục này và lưu trữ nội dung riêng cho mỗi slide.

**Tôi có thể sao chép Layout Slide từ một bản trình chiếu sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Khi sao chép giữa các bản trình chiếu, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác được bố cục nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Layout đã được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi bố cục trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng ở mức cục bộ. Hình học của trình giữ chỗ và kiểu kế thừa do đó có thể thay đổi trên nhiều slide đồng thời. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa bố cục.

**Điều gì sẽ xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/). Hãy gán lại các slide phụ thuộc trước, hoặc sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) để chỉ xóa các bố cục không được tham chiếu.