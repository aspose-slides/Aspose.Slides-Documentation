---
title: Áp dụng hoặc Thay đổi Bố cục Slide trên Android
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/androidjava/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- trình giữ chỗ
- thiết kế bản trình chiếu
- thiết kế slide
- bố cục không sử dụng
- hiển thị chân trang
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
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho Android bằng Java, thêm trình giữ chỗ, xóa các bố cục không sử dụng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Một bố cục slide xác định vị trí và định dạng của các placeholder như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán đồng thời cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục thường gặp bao gồm:

- **Title Slide**: Chứa các placeholder tiêu đề và phụ đề.
- **Title and Content**: Chứa một placeholder tiêu đề và một placeholder nội dung đa mục đích.
- **Blank**: Không chứa placeholder nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu về kế thừa bố cục**

Một bản trình bày có ba mức liên quan:

1. Một [master slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) xác định chủ đề, định dạng chia sẻ, nền và các đối tượng chung.
2. Một [layout slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/) thuộc về master và xác định một bố trí cụ thể của các placeholder.
3. Một [normal slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/) sử dụng một layout và lưu trữ nội dung được nhập cho slide đó.

Một slide bình thường kế thừa chủ đề và định dạng từ layout của nó, và layout kế thừa từ master. Giá trị được đặt trực tiếp trên slide bình thường sẽ ghi đè giá trị kế thừa ở mức đó. Khi một slide bình thường được tạo, các hình dạng placeholder của nó được tạo từ layout đã chọn, trong khi nội dung nhập vào các placeholder đó thuộc về slide bình thường.

Thêm các placeholder cần thiết vào layout trước khi tạo slide từ nó. Thêm một placeholder khác vào layout sau này sẽ không tự động thêm một hình dạng placeholder tương ứng vào các slide bình thường đã tồn tại.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học placeholder hiện có trên layout có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một layout đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem lại bản trình bày kết quả.
- Một layout vẫn đang được một slide sử dụng không thể bị xóa. Hãy chuyển các slide phụ thuộc sang một layout khác trước, hoặc chỉ xóa các layout không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cây phân cấp này, xem [Slide Master](/slides/vi/androidjava/slide-master/).

Để ẩn logo kế thừa hoặc các hình dạng trang trí master trên một slide hoặc thông qua một layout chia sẻ, xem [Control the Visibility of Master Graphics](/slides/vi/androidjava/slide-master/). Ví dụ so sánh hai slide sử dụng cùng một master.

## **Chọn và Áp dụng một Slide Layout**

Sử dụng một loại layout khi bản trình bày tuân theo các định nghĩa layout chuẩn của PowerPoint. Tên layout có thể chỉnh sửa bởi người dùng và có thể được địa phương hóa, vì vậy việc lựa chọn dựa trên tên ít đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu layout đó không có, nó sẽ cố tình chuyển sang **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình bày có thể chỉ chứa các layout tùy chỉnh. Layout đã chọn sau đó được áp dụng cho slide bình thường đầu tiên thông qua phương thức [ISlide.setLayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

Thay đổi layout của một slide không xóa các hình dạng thông thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí placeholder, định dạng kế thừa và sự tương ứng giữa các placeholder hiện có và layout mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển đổi giữa các layout có sự khác biệt đáng kể.

## **Thêm một Layout Slide**

Lựa chọn và tạo là các thao tác riêng biệt. Ví dụ trước chọn một layout đã tồn tại; nó không tạo mới. Để tạo một layout, gọi phương thức [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) trên bộ sưu tập layout của master mục tiêu.

Ví dụ sau luôn thêm một layout **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một slide bình thường dựa trên nó. Tên layout phải là duy nhất trong bộ sưu tập.

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

Chỉ thêm layout khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã tồn tại layout phù hợp, hãy chọn và sử dụng lại nó thay vì tạo bản sao.

## **Thêm Placeholder vào một Layout Slide**

Phương thức [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) cung cấp một [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) để thêm các hình dạng placeholder vào layout.

| Placeholder PowerPoint | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Nội dung](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Nội dung (Dọc)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Văn bản](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Văn bản (Dọc)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Hình ảnh](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Biểu đồ](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Bảng](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Phương tiện](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Hình ảnh trực tuyến](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Ví dụ sau kiểm tra xem layout **Blank** có tồn tại, thêm bốn placeholder vào nó, và sau đó tạo một slide bình thường sử dụng layout đã chỉnh sửa. Thứ tự này có mục đích: các placeholder được thêm trước khi slide bình thường được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng placeholder tương ứng trên slide đó.

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

![Các placeholder trên layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các placeholder layout hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một placeholder layout mới được thêm vào sẽ không được tự động bổ sung vào các slide bình thường đã tồn tại. Hãy thử thay đổi layout trên một bản sao của bản trình bày và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các Layout Slide Không được Sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) để xóa các layout mà không có slide bình thường nào tham chiếu. Phương thức này giữ lại các layout vẫn đang được sử dụng.

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

Để xóa một layout cụ thể, trước tiên sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) của nó. Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [ILayoutSlide.remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#remove--). Cố gắng xóa một layout đang được sử dụng sẽ gây ra [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxeditexception/).

## **Kiểm soát Hiển thị Footer trên Layout Slide**

Một layout có các placeholder footer, số slide và ngày‑giờ riêng. Sử dụng phương thức [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) để điều khiển các placeholder này cho một layout. Điều này hữu ích khi, ví dụ, layout nội dung nên hiển thị footer nhưng layout tiêu đề thì không.

Ví dụ sau chọn một layout một cách an toàn và làm cho các thành phần footer của nó hiển thị:

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

## **Kiểm soát Hiển thị Footer trên Master và Các Layout Con của Nó**

Để áp dụng cài đặt footer nhất quán trên toàn bộ cây master, sử dụng phương thức [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Các phương thức lan truyền của [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) hoạt động trên master và các layout slide và slide bình thường phụ thuộc; chúng không chỉ nhắm mục tiêu một slide bình thường duy nhất.

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

## **Câu hỏi thường gặp**

**Sự khác biệt giữa Master Slide và Layout Slide là gì?**

Master slide xác định chủ đề và định dạng chung của bản trình bày. Layout slide thuộc về một master và xác định một bố trí placeholder có thể tái sử dụng. Các slide bình thường sử dụng các layout này và lưu trữ nội dung riêng của từng slide.

**Bạn có thể sao chép một Layout Slide từ một bản trình bày sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Khi sao chép giữa các bản trình bày, cũng cần kiểm tra phông chữ, chủ đề, hình ảnh và các tài nguyên khác mà layout nguồn sử dụng.

**Điều gì xảy ra khi tôi chỉnh sửa một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi của layout trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng tại chỗ. Do đó, hình học placeholder và kiểu dáng kế thừa có thể thay đổi trên nhiều slide cùng lúc. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa layout.

**Điều gì sẽ xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxeditexception/). Hãy chuyển lại các slide phụ thuộc trước, hoặc dùng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) để chỉ xóa các layout không được tham chiếu.