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
- thiết kế bài thuyết trình
- thiết kế slide
- bố cục không dùng
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
- Android
- Java
- Aspose.Slides
description: "Quản lý và tùy chỉnh bố cục slide trong Aspose.Slides cho Android. Khám phá các loại bố cục, kiểm soát trình giữ chỗ và hiển thị footer thông qua các ví dụ mã Java."
---
## **Giới thiệu**

Một bố cục slide xác định cách sắp xếp các hộp placeholder và định dạng cho nội dung trên một slide. Nó kiểm soát các placeholder nào khả dụng và chúng xuất hiện ở đâu. Các bố cục slide giúp bạn thiết kế bản trình bày nhanh chóng và nhất quán — cho dù bạn tạo một cái đơn giản hay phức tạp hơn. Một số bố cục slide phổ biến nhất trong PowerPoint bao gồm:

**Title Slide layout** – Bao gồm hai placeholder văn bản: một cho tiêu đề và một cho phụ đề.

**Title and Content layout** – Có một placeholder tiêu đề nhỏ ở trên cùng và một placeholder lớn hơn bên dưới cho nội dung chính (như văn bản, danh sách có dấu đầu dòng, biểu đồ, hình ảnh và nhiều hơn nữa).

**Blank layout** – Không chứa placeholder nào, cho phép bạn kiểm soát toàn bộ việc thiết kế slide từ đầu.

Bố cục slide là một phần của slide master, là slide cấp cao nhất xác định kiểu bố cục cho bản trình bày. Bạn có thể truy cập và chỉnh sửa các slide bố cục thông qua slide master — theo loại, tên hoặc ID duy nhất. Ngoài ra, bạn cũng có thể chỉnh sửa một slide bố cục cụ thể trực tiếp trong bản trình bày.

Để làm việc với bố cục slide trong Aspose.Slides for Android, bạn có thể sử dụng:

- Các phương thức như [getLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) và [getMasters](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getMasters--) trong lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/)
- Các kiểu như [ILayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), và [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Để tìm hiểu thêm về cách làm việc với master slide, hãy xem bài viết [Slide Master](/slides/vi/androidjava/slide-master/).
{{% /alert %}}

## **Thêm Bố Cục Slide vào Bản Trình Bày**

Để tùy chỉnh giao diện và cấu trúc của các slide, bạn có thể cần thêm các slide bố cục mới vào bản trình bày. Aspose.Slides for Android cho phép bạn kiểm tra xem một bố cục cụ thể đã tồn tại chưa, thêm mới nếu cần, và sử dụng nó để chèn các slide dựa trên bố cục đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Truy cập [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Kiểm tra xem slide bố cục mong muốn đã tồn tại trong bộ sưu tập chưa. Nếu chưa, thêm slide bố cục bạn cần.
1. Thêm một slide trống dựa trên slide bố cục mới.
1. Lưu bản trình bày.

Đoạn mã Java sau minh họa cách thêm một bố cục slide vào bản trình bày PowerPoint:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Duyệt qua các loại slide bố cục để chọn một slide bố cục.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Trường hợp bản trình bày không chứa tất cả các loại bố cục.
        // Tệp bản trình bày chỉ chứa các loại bố cục Blank và Custom.
        // Tuy nhiên, các slide bố cục có loại tùy chỉnh có thể có tên dễ nhận biết,
        // ví dụ như "Title", "Title and Content", v.v., có thể được sử dụng để chọn slide bố cục.
        // Bạn cũng có thể dựa vào một tập hợp các loại hình dạng placeholder.
        // Ví dụ, slide Title chỉ nên có loại placeholder Title, và tương tự cho các slide khác.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Thêm một slide trống sử dụng slide bố cục đã thêm.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Lưu bản trình bày xuống đĩa.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Các Bố Cục Slide Không Sử Dụng**

Aspose.Slides cung cấp phương thức [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) từ lớp [Compress](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/) để cho phép bạn xoá các slide bố cục không mong muốn và không được sử dụng.

Đoạn mã Java sau cho thấy cách xoá một slide bố cục khỏi bản trình bày PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Placeholder Vào Bố Cục Slide**

Aspose.Slides cung cấp phương thức [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) cho phép bạn thêm các placeholder mới vào một slide bố cục.

Trình quản lý này chứa các phương thức cho các loại placeholder sau:

| Placeholder PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) Phương thức |
| ---------------------- | ------------------------------------------------------------ |
| ![Nội dung](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Nội dung (Dọc)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Văn bản](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Văn bản (Dọc)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Hình ảnh](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Biểu đồ](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Bảng](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Phương tiện](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Hình ảnh trực tuyến](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Đoạn mã Java sau minh họa cách thêm các hình dạng placeholder mới vào slide bố cục Blank:

```java
Presentation presentation = new Presentation();
try {
    // Lấy slide bố cục Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Lấy trình quản lý placeholder của slide bố cục.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Thêm các placeholder khác nhau vào slide bố cục Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Thêm một slide mới với bố cục Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các placeholder trên bố cục slide](add_placeholders.png)

## **Đặt Hiển Thị Footer Cho Bố Cục Slide**

Trong các bản trình bày PowerPoint, các yếu tố footer như ngày tháng, số slide và văn bản tùy chỉnh có thể được hiển thị hoặc ẩn tùy theo bố cục slide. Aspose.Slides for Android cho phép bạn điều khiển khả năng hiển thị của các placeholder footer này. Điều này hữu ích khi bạn muốn một số bố cục hiển thị thông tin footer trong khi các bố cục khác giữ sạch sẽ và tối giản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến một slide bố cục theo chỉ mục của nó.
1. Đặt placeholder footer của slide thành hiển thị.
1. Đặt placeholder số slide thành hiển thị.
1. Đặt placeholder ngày‑giờ thành hiển thị.
1. Lưu bản trình bày.

Đoạn mã Java sau cho thấy cách đặt khả năng hiển thị của footer slide và thực hiện các tác vụ liên quan:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Đặt Hiển Thị Footer Con Cho Slide**

Trong các bản trình bày PowerPoint, các yếu tố footer như ngày tháng, số slide và văn bản tùy chỉnh có thể được kiểm soát ở mức master slide để đảm bảo tính nhất quán trên tất cả các slide bố cục. Aspose.Slides for Android cho phép bạn đặt khả năng hiển thị và nội dung của các placeholder footer này trên master slide và truyền các cài đặt này tới tất cả các slide bố cục con. Cách tiếp cận này đảm bảo thông tin footer đồng nhất trong toàn bộ bản trình bày.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu đến master slide theo chỉ mục của nó.
1. Đặt các placeholder footer của master và tất cả các slide bố cục con thành hiển thị.
1. Đặt các placeholder số slide của master và tất cả các slide bố cục con thành hiển thị.
1. Đặt các placeholder ngày‑giờ của master và tất cả các slide bố cục con thành hiển thị.
1. Lưu bản trình bày.

Đoạn mã Java sau minh họa thao tác này:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa master slide và layout slide là gì?**

Master slide định nghĩa chủ đề chung và định dạng mặc định cho toàn bộ bản trình bày, trong khi layout slide xác định cách sắp xếp cụ thể của các placeholder cho các loại nội dung khác nhau.

**Tôi có thể sao chép một layout slide từ bản trình bày này sang bản trình bày khác không?**

Có, bạn có thể sao chép (clone) một layout slide từ bộ sưu tập layout slide của một bản trình bày, truy cập bằng phương thức [getLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getLayoutSlides--), và chèn nó vào bản trình bày khác bằng phương thức `addClone`.

**Nếu tôi xoá một layout slide mà vẫn còn được một slide khác sử dụng thì sẽ xảy ra gì?**

Nếu bạn cố gắng xoá một layout slide vẫn còn được tham chiếu bởi ít nhất một slide trong bản trình bày, Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxeditexception/). Để tránh tình trạng này, hãy sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) để an toàn xoá chỉ các layout slide không còn được sử dụng.