---
title: Áp dụng hoặc Thay đổi Bố cục Slide trong Java
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/java/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- vị trí giữ chỗ
- thiết kế bản trình bày
- thiết kế slide
- bố cục không sử dụng
- hiển thị chân trang
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
- bản trình bày
- Java
- Aspose.Slides
description: "Áp dụng, tạo và chỉnh sửa bố cục slide trong Aspose.Slides cho Java, thêm vị trí giữ chỗ, xóa các bố cục không sử dụng và kiểm soát hiển thị chân trang."
---
## **Tổng quan**

Một bố cục slide xác định vị trí và định dạng của các vị trí giữ chỗ như tiêu đề, văn bản, hình ảnh, biểu đồ và bảng. Áp dụng một bố cục giúp các slide có cấu trúc nhất quán trong khi vẫn cho phép mỗi slide chứa nội dung riêng của nó.

Các bố cục phổ biến nhất bao gồm:

- **Title Slide**: Chứa các vị trí giữ chỗ tiêu đề và phụ đề.
- **Title and Content**: Chứa một vị trí giữ chỗ tiêu đề và một vị trí giữ chỗ nội dung đa dụng.
- **Blank**: Không chứa vị trí giữ chỗ nội dung và hữu ích khi mọi hình dạng sẽ được đặt thủ công.

## **Hiểu kế thừa bố cục**

Một bản trình bày có ba cấp độ liên quan:

1. A [master slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/) xác định giao diện, định dạng chung, nền và các đối tượng chung.
1. A [layout slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/) thuộc về một master và xác định một cách sắp xếp cụ thể của các vị trí giữ chỗ.
1. A [normal slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/) sử dụng một bố cục và lưu trữ nội dung được nhập cho slide đó.

Một slide bình thường kế thừa giao diện và định dạng từ bố cục của nó, và bố cục kế thừa từ master. Giá trị được đặt trực tiếp trên slide bình thường sẽ ghi đè giá trị kế thừa ở mức đó. Khi tạo một slide bình thường, các hình dạng vị trí giữ chỗ của nó được tạo ra từ bố cục đã chọn, trong khi nội dung nhập vào các vị trí giữ chỗ đó thuộc về slide bình thường.

Thêm các vị trí giữ chỗ cần thiết vào một bố cục trước khi tạo slide từ nó. Thêm một vị trí giữ chỗ khác vào bố cục sau này sẽ không tự động thêm một hình dạng vị trí giữ chỗ tương ứng vào các slide bình thường đã tồn tại.

Mối quan hệ này có hai hậu quả quan trọng:

- Thay đổi định dạng kế thừa hoặc hình học của vị trí giữ chỗ hiện có trên một bố cục có thể cập nhật mọi slide phụ thuộc vào nó. Trước khi chỉnh sửa một bố cục đã được sử dụng, hãy kiểm tra các slide phụ thuộc và xem lại bản trình bày kết quả.
- Một bố cục vẫn đang được một slide sử dụng không thể bị xóa. Hãy gán lại các slide phụ thuộc của nó sang một bố cục khác trước, hoặc chỉ xóa các bố cục không được sử dụng.

Để biết thêm thông tin về cấp cao nhất của cây phân cấp này, xem [Slide Master](/slides/vi/java/slide-master/).

## **Chọn và áp dụng bố cục slide**

Sử dụng loại bố cục khi bản trình bày tuân theo các định nghĩa bố cục chuẩn của PowerPoint. Tên bố cục có thể được chỉnh sửa bởi người dùng và có thể được địa phương hoá, do đó việc chọn dựa trên tên kém đáng tin cậy trừ khi bạn kiểm soát mẫu nguồn.

Ví dụ sau tìm **Title and Content** trên master đầu tiên. Nếu bố cục đó không khả dụng, nó cố ý quay lại **Blank**. Kiểm tra null thứ hai là cần thiết vì một bản trình bày có thể chỉ chứa các bố cục tùy chỉnh. Bố cục đã chọn sau đó được áp dụng cho slide bình thường đầu tiên thông qua phương thức [ISlide.setLayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

Thay đổi bố cục của một slide không xóa các hình dạng thường được thêm trực tiếp vào slide. Tuy nhiên, vị trí các vị trí giữ chỗ, định dạng kế thừa và sự tương ứng giữa các vị trí giữ chỗ hiện có và bố cục mới có thể thay đổi, vì vậy hãy kiểm tra kết quả khi chuyển giữa các bố cục có sự khác biệt đáng kể.

## **Thêm một bố cục slide**

Việc chọn và tạo là hai thao tác riêng biệt. Ví dụ trước chỉ chọn một bố cục hiện có; nó không tạo mới. Để tạo một bố cục, gọi phương thức [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) trên bộ sưu tập bố cục của master mục tiêu.

Ví dụ sau luôn thêm một bố cục **Title and Content** mới có tên `Report Title and Content`, sau đó thêm một slide bình thường dựa trên nó. Tên bố cục phải là duy nhất trong bộ sưu tập.

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

Chỉ thêm một bố cục khi mẫu thực sự cần một cấu trúc tái sử dụng khác. Nếu đã tồn tại một bố cục phù hợp, hãy chọn và tái sử dụng nó thay vì tạo bản sao.

## **Thêm vị trí giữ chỗ vào một bố cục slide**

Phương thức [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) cung cấp một [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/) để thêm các hình dạng vị trí giữ chỗ vào một bố cục.

| Vị trí giữ chỗ PowerPoint | `ILayoutPlaceholderManager` Phương thức |
| -------------------------- | ---------------------------------------- |
| ![Nội dung](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Nội dung (Dọc)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Văn bản](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Văn bản (Dọc)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Hình ảnh](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Biểu đồ](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Bảng](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Phương tiện](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Hình ảnh trực tuyến](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Ví dụ sau kiểm tra rằng bố cục **Blank** tồn tại, thêm bốn vị trí giữ chỗ vào nó, và sau đó tạo một slide bình thường sử dụng bố cục đã sửa đổi. Thứ tự này có mục đích: các vị trí giữ chỗ được thêm trước khi slide bình thường được tạo, vì vậy Aspose.Slides có thể tạo các hình dạng vị trí giữ chỗ tương ứng trên slide đó.

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

![Các vị trí giữ chỗ trên bố cục slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Thay đổi định dạng kế thừa hoặc hình học của các vị trí giữ chỗ bố cục hiện có có thể ảnh hưởng đến các slide phụ thuộc. Một vị trí giữ chỗ bố cục mới được thêm sẽ không được tự động bổ sung vào các slide bình thường đã tồn tại. Hãy thử nghiệm các thay đổi bố cục trên một bản sao của bản trình bày và kiểm tra mọi slide phụ thuộc.
{{% /alert %}}

## **Xóa các bố cục slide không sử dụng**

Sử dụng phương thức [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) để xóa các bố cục mà không có slide bình thường nào tham chiếu. Phương thức sẽ để lại các bố cục vẫn đang được sử dụng.

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

Để xóa một bố cục cụ thể, trước tiên sử dụng phương thức [hasDependingSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) hoặc [getDependingSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) của nó. Gán lại bất kỳ slide phụ thuộc nào trước khi gọi [ILayoutSlide.remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#remove--). Cố gắng xóa một bố cục đang được sử dụng sẽ gây ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxeditexception/).

## **Kiểm soát hiển thị chân trang trên một bố cục slide**

Một bố cục có các vị trí giữ chỗ chân trang, số slide và ngày‑giờ riêng. Sử dụng phương thức [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) để kiểm soát các vị trí giữ chỗ này cho một bố cục. Điều này hữu ích khi, ví dụ, các bố cục nội dung nên hiển thị chân trang nhưng các bố cục tiêu đề thì không.

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

## **Kiểm soát hiển thị chân trang trên Master và các bố cục con của nó**

Để áp dụng cài đặt chân trang nhất quán trên toàn bộ cây master, sử dụng phương thức [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . Các phương thức truyền tải của [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslideheaderfootermanager/) hoạt động trên master và các bố cục slide phụ thuộc cũng như các slide bình thường; chúng không chỉ áp dụng cho một slide bình thường duy nhất.

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

**Sự khác nhau giữa Master Slide và Layout Slide là gì?**

Master Slide xác định giao diện và định dạng chung của bản trình bày. Layout Slide thuộc về một master và xác định một cách sắp xếp tái sử dụng các vị trí giữ chỗ. Các slide bình thường sử dụng những bố cục này và lưu trữ nội dung riêng của từng slide.

**Tôi có thể sao chép một Layout Slide từ một bản trình bày sang bản khác không?**

Có. Thêm một bản sao vào bộ sưu tập đích bằng phương thức [addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Khi sao chép giữa các bản trình bày, cũng cần xác minh phông chữ, giao diện, hình ảnh và các tài nguyên khác được bố cục nguồn sử dụng.

**Điều gì xảy ra khi tôi sửa đổi một Layout đang được sử dụng?**

Các slide phụ thuộc sẽ kế thừa các thay đổi bố cục trừ khi chúng ghi đè định dạng hoặc đối tượng bị ảnh hưởng ở cấp địa phương. Vì vậy, hình học của vị trí giữ chỗ và kiểu kế thừa có thể thay đổi đồng thời trên nhiều slide. Sử dụng [getDependingSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) để xác định các slide bị ảnh hưởng trước khi chỉnh sửa bố cục.

**Điều gì xảy ra nếu tôi xóa một Layout vẫn đang được sử dụng?**

Aspose.Slides sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxeditexception/). Hãy gán lại các slide phụ thuộc trước, hoặc sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) để chỉ xóa các bố cục không được tham chiếu.