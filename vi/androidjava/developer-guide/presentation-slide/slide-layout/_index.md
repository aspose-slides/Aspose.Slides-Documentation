---
title: Áp dụng hoặc Thay đổi Bố cục Slide trên Android
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/androidjava/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- khung giữ chỗ
- thiết kế bản trình bày
- thiết kế slide
- bố cục không sử dụng
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
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho Android bằng Java, thêm khung giữ chỗ, xóa các bố cục không sử dụng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Bố cục slide xác định vị trí và định dạng của các khung giữ chỗ như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán đồng thời cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Slide Tiêu đề**: chứa các khung giữ chỗ tiêu đề và phụ đề.
- **Tiêu đề và Nội dung**: chứa một khung giữ chỗ tiêu đề và một khung giữ chỗ nội dung đa mục đích.
- **Trống**: không chứa khung giữ chỗ nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về Kế thừa Bố cục**

Một bản trình bày có ba cấp độ liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) xác định giao diện, định dạng chia sẻ, nền và các đối tượng chung.
2. Một [layout slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/) thuộc về slide chủ đề và xác định một sắp xếp cụ thể của các khung giữ chỗ.
3. Một [normal slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/) sử dụng một bố cục và lưu trữ nội dung được nhập cho slide đó.

Một slide bình thường kế thừa giao diện và định dạng từ bố cục của nó, và bố cục kế thừa từ slide chủ đề. Giá trị được đặt trực tiếp trên slide bình thường sẽ ghi đè lên giá trị kế thừa ở cấp độ đó. Khi một slide bình thường được tạo, các hình dạng khung giữ chỗ của nó được tạo ra từ bố cục đã chọn, trong khi nội dung nhập vào các khung giữ chỗ đó thuộc về slide bình thường.

Thêm các khung giữ chỗ cần thiết vào bố cục trước khi tạo slide từ nó. Thêm một khung giữ chỗ khác vào bố cục sau này sẽ không tự động thêm hình dạng khung giữ chỗ tương ứng vào các slide bình thường đã tồn tại.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của khung giữ chỗ hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem xét bản trình bày kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Hãy chuyển các slide phụ thuộc sang một bố cục khác trước, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cây phân cấp này, xem [Slide Master](/slides/vi/androidjava/slide-master/).

## **Chọn và Áp dụng Bố cục Slide**

Sử dụng kiểu bố cục khi bản trình bày tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên bố cục có thể chỉnh sửa bởi người dùng và có thể được địa phương hoá, vì vậy việc lựa chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Tiêu đề và Nội dung** trên slide chủ đề đầu tiên. Nếu bố cục đó không khả dụng, nó sẽ cố tình chuyển sang **Trống**. Kiểm tra null thứ hai là cần thiết vì một bản trình bày có thể chỉ chứa các bố cục tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide bình thường đầu tiên thông qua phương thức [ISlide.setLayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Thay đổi bố cục của một slide không xóa các hình dạng thông thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí khung giữ chỗ, định dạng kế thừa và sự tương ứng giữa các khung giữ chỗ hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển đổi giữa các bố cục có sự khác biệt đáng kể.

## **Thêm một Slide Bố cục**

Lựa chọn và tạo mới là hai thao tác riêng biệt. Ví dụ trước chọn một bố cục hiện có; nó không tạo ra một bố cục mới. Để tạo một bố cục, gọi phương thức [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) trên bộ sưu tập bố cục của slide chủ đề mục tiêu.

Ví dụ sau luôn thêm một bố cục **Tiêu đề và Nội dung** mới có tên `Report Title and Content`, sau đó thêm một slide bình thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chỉ thêm một bố cục khi mẫu thực sự cần một cấu trúc có thể tái sử dụng khác. Nếu đã tồn tại một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm Khung Giữ chỗ vào Slide Bố cục**

Phương thức [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) cung cấp một [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) để thêm các hình dạng khung giữ chỗ vào một bố cục.

| Khung Giữ chỗ PowerPoint | Phương thức `ILayoutPlaceholderManager` |
| ------------------------ | ---------------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Ví dụ sau kiểm tra xem bố cục **Trống** có tồn tại không, thêm bốn khung giữ chỗ vào nó, và sau đó tạo một slide bình thường sử dụng bố cục đã sửa đổi. Thứ tự này có mục đích: các khung giữ chỗ được thêm trước khi slide bình thường được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng khung giữ chỗ tương ứng trên slide đó.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các khung giữ chỗ bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một khung giữ chỗ bố cục mới được thêm sẽ không được tự động bổ sung vào các slide bình thường đã tồn tại. Hãy thử nghiệm các thay đổi bố cục trên một bản sao của bản trình bày và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Slide Bố cục Không được Sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) để xóa các bố cục mà không có slide bình thường nào tham chiếu. Phương thức này sẽ giữ nguyên các bố cục vẫn đang được sử dụng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để xóa một bố cục cụ thể, đầu tiên sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) của nó. Chuyển giao bất kỳ slide phụ thuộc nào trước khi gọi [ILayoutSlide.remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#remove--). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra lỗi [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxeditexception/).

## **Kiểm soát Hiển thị Chân trang trên Slide Bố cục**

Một bố cục có các khung giữ chỗ chân trang, số slide và ngày‑giờ riêng. Sử dụng phương thức [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) để kiểm soát các khung giữ chỗ này cho một bố cục. Điều này hữu ích khi, ví dụ, các bố cục nội dung nên hiển thị chân trang nhưng các bố cục tiêu đề không nên.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm soát Hiển thị Chân trang trên Master và Các Bố cục Con của Nó**

Để áp dụng cài đặt chân trang nhất quán trên toàn bộ cây master, sử dụng phương thức [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Các phương thức lan truyền của [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) hoạt động trên master và các slide bố cục và slide bình thường phụ thuộc; chúng không chỉ áp dụng cho một slide bình thường duy nhất.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Sự Khác nhau giữa Master Slide và Layout Slide là gì?**

Một master slide xác định giao diện và định dạng chia sẻ của bản trình bày. Một layout slide thuộc về một master và xác định một sắp xếp có thể tái sử dụng của các khung giữ chỗ. Các slide bình thường sử dụng các bố cục đó và lưu trữ nội dung riêng cho từng slide.

**Tôi có thể sao chép một Layout Slide từ một bản trình bày sang bản trình bày khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Khi sao chép giữa các bản trình bày, cũng nên kiểm tra phông chữ, giao diện, hình ảnh và các nguồn tài nguyên khác mà bố cục nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Layout đã được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi của bố cục trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng ở cấp địa phương. Vì vậy, hình học của khung giữ chỗ và kiểu kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa bố cục.

**Điều gì sẽ xảy ra nếu tôi xóa một Layout đang được sử dụng?**

Aspose.Slides sẽ ném ra một lỗi [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxeditexception/). Hãy chuyển giao các slide phụ thuộc trước, hoặc sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) để chỉ xóa các bố cục không được tham chiếu.