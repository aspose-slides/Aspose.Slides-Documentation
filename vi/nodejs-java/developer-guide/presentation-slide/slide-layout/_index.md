---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong JavaScript
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/nodejs-java/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- placeholder
- thiết kế bản trình chiếu
- thiết kế slide
- bố cục không sử dụng
- hiển thị footer
- slide tiêu đề
- tiêu đề và nội dung
- tiêu đề mục
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho Node.js qua Java, thêm placeholder, xóa các bố cục không sử dụng và kiểm soát hiển thị footer."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các placeholder như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán đồng thời cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các placeholder tiêu đề và phụ đề.
- **Title and Content**: Chứa một placeholder tiêu đề và một placeholder nội dung đa mục đích.
- **Blank**: Không chứa placeholder nội dung và hữu ích khi mỗi hình dạng sẽ được đặt thủ công.

## **Hiểu về kế thừa bố cục**

Một bản trình chiếu có ba cấp độ liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) xác định chủ đề, định dạng chung, nền và các đối tượng chung.
1. Một [layout slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/) thuộc về một master và xác định một cách sắp xếp cụ thể các placeholder.
1. Một [normal slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/) sử dụng một bố cục và lưu trữ nội dung được nhập cho slide đó.

Một normal slide kế thừa chủ đề và định dạng từ bố cục của nó, và bố cục kế thừa từ master của nó. Giá trị được đặt trực tiếp trên một normal slide sẽ ghi đè giá trị kế thừa ở mức đó. Khi một normal slide được tạo, các hình dạng placeholder của nó được tạo ra từ bố cục đã chọn, trong khi nội dung được nhập vào các placeholder đó thuộc về normal slide.

Thêm các placeholder cần thiết vào một bố cục trước khi tạo slide từ nó. Thêm một placeholder khác vào bố cục sau này sẽ không tự động thêm hình dạng placeholder tương ứng vào các normal slide hiện có.

Mối quan hệ này có hai hệ quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học placeholder hiện có trên một layout có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một layout đã được sử dụng, kiểm tra các slide phụ thuộc và xem lại bản trình chiếu kết quả.
- Một layout vẫn đang được một slide sử dụng không thể bị xóa. Trước tiên, gán lại các slide phụ thuộc của nó sang layout khác, hoặc chỉ xóa các layout không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của hệ thống này, xem [Slide Master](/slides/vi/nodejs-java/slide-master/).

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng giá trị [SlideLayoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidelayouttype/) khi bản trình chiếu tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được địa phương hoá, do đó việc lựa chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ dưới đây tìm **Title and Content** trên master đầu tiên. Nếu bố cục đó không có, nó cố ý chuyển sang **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình chiếu có thể chỉ chứa các layout tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide normal đầu tiên thông qua phương thức [Slide.setLayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#setLayoutSlide).

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

Thay đổi bố cục của một slide không làm mất các hình dạng thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí placeholder, định dạng kế thừa và sự tương ứng giữa các placeholder hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển giữa các bố cục có sự khác biệt đáng kể.

## **Thêm Layout Slide**

Việc lựa chọn và tạo mới là các hoạt động riêng biệt. Ví dụ trước lựa chọn một layout hiện có; nó không tạo ra một layout mới. Để tạo một layout, gọi phương thức [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) trên bộ sưu tập layout của master mục tiêu.

Ví dụ dưới đây luôn thêm một layout **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một slide normal dựa trên nó. Tên layout phải là duy nhất trong bộ sưu tập.

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

Chỉ thêm layout khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã có một layout phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm Placeholder vào Layout Slide**

Phương thức [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) cung cấp một [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/) để thêm các hình dạng placeholder vào một layout.

| Placeholder PowerPoint | Phương thức `LayoutPlaceholderManager` |
| ---------------------- | --------------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Ví dụ dưới đây kiểm tra xem bố cục **Blank** có tồn tại, thêm bốn placeholder vào nó, và sau đó tạo một slide normal sử dụng layout đã chỉnh sửa. Thứ tự này có ý định: các placeholder được thêm trước khi slide normal được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng placeholder tương ứng trên slide đó.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các placeholder layout hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một placeholder layout mới được thêm sẽ không được tự động áp dụng vào các slide normal hiện có. Kiểm tra các thay đổi layout trên bản sao của bản trình chiếu và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa Layout Slides Không được sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) để xóa các layout mà không có slide normal nào tham chiếu. Phương thức này giữ lại các layout vẫn đang được sử dụng.

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

Để xóa một layout cụ thể, đầu tiên sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) của nó. Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [LayoutSlide.remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#remove). Cố gắng xóa một layout đang được sử dụng sẽ gây ra lỗi [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/).

## **Kiểm soát Hiện thị Footer trên Layout Slide**

Một layout có các placeholder footer, slide-number và date-time riêng. Sử dụng phương thức [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) để kiểm soát các placeholder này cho một layout. Điều này hữu ích khi, ví dụ, các layout nội dung cần hiển thị footer nhưng các layout tiêu đề không cần.

Ví dụ dưới đây chọn một layout một cách an toàn và làm cho các thành phần footer của nó hiển thị:

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

## **Kiểm soát Hiện thị Footer trên Master và Các Layout Con của Nó**

Để áp dụng cài đặt footer nhất quán trên toàn bộ cây master, sử dụng phương thức [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Các phương thức lan truyền của [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslideheaderfootermanager/) hoạt động trên master và các layout slide phụ thuộc cùng các slide normal; chúng không chỉ nhắm vào một slide normal duy nhất.

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

## **FAQ**

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Một master slide xác định chủ đề và định dạng chung của bản trình chiếu. Một layout slide thuộc về một master và xác định một cách sắp xếp placeholder có thể tái sử dụng. Các slide normal sử dụng các layout này và lưu trữ nội dung riêng cho từng slide.

**Tôi có thể sao chép Layout Slide từ một bản trình chiếu sang bản trình chiếu khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Khi sao chép giữa các bản trình chiếu, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác được layout nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi của layout trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng tại chỗ. Do đó, hình học placeholder và kiểu kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa layout.

**Điều gì sẽ xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra một lỗi [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/). Hãy gán lại các slide phụ thuộc trước, hoặc sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) để chỉ xóa các layout không được tham chiếu.