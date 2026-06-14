---
title: "Áp dụng hoặc Thay đổi Bố cục Slide trong Java"
linktitle: "Bố cục Slide"
type: docs
weight: 60
url: /vi/java/slide-layout/
keywords:
- "bố cục slide"
- "bố cục nội dung"
- "placeholder"
- "thiết kế bài thuyết trình"
- "thiết kế slide"
- "bố cục không sử dụng"
- "hiển thị footer"
- "slide tiêu đề"
- "tiêu đề và nội dung"
- "đầu mục phần"
- "hai nội dung"
- "so sánh"
- "chỉ tiêu đề"
- "bố cục trống"
- "nội dung có chú thích"
- "hình ảnh có chú thích"
- "tiêu đề và văn bản dọc"
- "tiêu đề dọc và văn bản"
- "PowerPoint"
- "OpenDocument"
- "bài thuyết trình"
- "Java"
- "Aspose.Slides"
description: "Quản lý và tùy chỉnh bố cục slide trong Aspose.Slides cho Java. Khám phá các loại bố cục, kiểm soát placeholder và khả năng hiển thị footer qua các ví dụ mã Java."
---
## **Giới thiệu**

Bố cục slide xác định cách sắp xếp các hộp placeholder và định dạng cho nội dung trên một slide. Nó kiểm soát các placeholder nào khả dụng và chúng xuất hiện ở đâu. Bố cục slide giúp bạn thiết kế bài thuyết trình nhanh chóng và nhất quán—cho dù bạn đang tạo một thứ đơn giản hay phức tạp hơn. Một số bố cục slide phổ biến nhất trong PowerPoint bao gồm:

**Title Slide layout** – Bao gồm hai placeholder văn bản: một cho tiêu đề và một cho phụ đề.

**Title and Content layout** – Có một placeholder tiêu đề nhỏ hơn ở trên cùng và một placeholder lớn hơn phía dưới cho nội dung chính (như văn bản, danh sách gạch đầu dòng, biểu đồ, hình ảnh và hơn thế nữa).

**Blank layout** – Không chứa bất kỳ placeholder nào, cho phép bạn kiểm soát hoàn toàn để thiết kế slide từ đầu.

Bố cục slide là một phần của slide master, là slide cấp cao nhất định nghĩa các kiểu bố cục cho bài thuyết trình. Bạn có thể truy cập và chỉnh sửa các layout slide thông qua slide master—bằng loại, tên hoặc ID duy nhất của chúng. Ngoài ra, bạn có thể chỉnh sửa một layout slide cụ thể trực tiếp trong bài thuyết trình.

Để làm việc với bố cục slide trong Aspose.Slides for Java, bạn có thể sử dụng:

- Các phương thức như [getLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getLayoutSlides--) và [getMasters](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getMasters--) trong lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) 
- Các kiểu như [ILayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutplaceholdermanager/), và [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Để tìm hiểu thêm về việc làm việc với slide master, hãy xem bài viết [Slide Master](/slides/vi/java/slide-master/).
{{% /alert %}}

## **Thêm Bố Cục Slide vào Bài Thuyết Trình**

Để tùy chỉnh giao diện và cấu trúc của các slide, bạn có thể cần thêm các layout slide mới vào một bài thuyết trình. Aspose.Slides for Java cho phép bạn kiểm tra xem một layout cụ thể đã tồn tại chưa, thêm mới nếu cần, và sử dụng nó để chèn các slide dựa trên layout đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Truy cập [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterlayoutslidecollection/).
3. Kiểm tra xem layout slide mong muốn đã tồn tại trong bộ sưu tập chưa. Nếu chưa, thêm layout slide cần thiết.
4. Thêm một slide trống dựa trên layout slide mới.
5. Lưu bài thuyết trình.

```java
// Tạo một thể hiện của lớp Presentation đại diện cho tệp PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Duyệt qua các loại layout slide để chọn một layout slide.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Trường hợp bài thuyết trình không chứa tất cả các loại layout.
        // Tệp bài thuyết trình chỉ chứa các loại layout Blank và Custom.
        // Tuy nhiên, các layout slide với loại tùy chỉnh có thể có tên dễ nhận biết,
        // chẳng hạn như "Title", "Title and Content", v.v., có thể được dùng để chọn layout slide.
        // Bạn cũng có thể dựa vào một tập hợp các kiểu hình placeholder.
        // Ví dụ, một slide Title chỉ nên có kiểu placeholder Title, và tương tự cho các slide khác.
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

    // Thêm một slide trống bằng cách sử dụng layout slide đã thêm.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Lưu bài thuyết trình vào đĩa.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Các Layout Slide Không Được Sử Dụng**

Aspose.Slides cung cấp phương thức [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) từ lớp [Compress](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/) để cho phép bạn xóa các layout slide không cần thiết và không được sử dụng.

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

Aspose.Slides cung cấp phương thức [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) cho phép bạn thêm các placeholder mới vào một layout slide.

Trình quản lý này chứa các phương thức cho các loại placeholder sau:

| Placeholder PowerPoint | Phương thức [ILayoutPlaceholderManager] |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Đoạn mã Java sau minh họa cách thêm các hình placeholder mới vào layout slide Blank:

```java
Presentation presentation = new Presentation();
try {
    // Lấy layout slide Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Lấy trình quản lý placeholder của layout slide.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Thêm các placeholder khác nhau vào layout slide Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Thêm một slide mới với layout Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các placeholder trên layout slide](add_placeholders.png)

## **Đặt Khả Năng Hiển Thị Footer cho Layout Slide**

Trong các bài thuyết trình PowerPoint, các thành phần footer như ngày, số slide và văn bản tùy chỉnh có thể được hiển thị hoặc ẩn tùy vào bố cục slide. Aspose.Slides for Java cho phép bạn kiểm soát khả năng hiển thị của các placeholder footer này. Điều này hữu ích khi bạn muốn một số layout hiển thị thông tin footer trong khi các layout khác vẫn gọn gàng và tối giản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Lấy tham chiếu tới một layout slide bằng chỉ mục của nó.
3. Đặt placeholder footer của slide thành hiển thị.
4. Đặt placeholder số slide thành hiển thị.
5. Đặt placeholder ngày‑giờ thành hiển thị.
6. Lưu bài thuyết trình.

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

## **Đặt Khả Năng Hiển Thị Footer Con cho Slide**

Trong các bài thuyết trình PowerPoint, các thành phần footer như ngày, số slide và văn bản tùy chỉnh có thể được kiểm soát ở mức slide master để đảm bảo tính nhất quán trên tất cả các layout slide. Aspose.Slides for Java cho phép bạn đặt khả năng hiển thị và nội dung của các placeholder footer này trên slide master và lan truyền các cài đặt này tới tất cả các layout slide con. Cách tiếp cận này đảm bảo thông tin footer đồng nhất trên toàn bộ bài thuyết trình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Lấy tham chiếu tới slide master bằng chỉ mục của nó.
3. Đặt các placeholder footer của master và tất cả các layout con thành hiển thị.
4. Đặt các placeholder số slide của master và tất cả các layout con thành hiển thị.
5. Đặt các placeholder ngày‑giờ của master và tất cả các layout con thành hiển thị.
6. Lưu bài thuyết trình.

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

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa master slide và layout slide là gì?**

Master slide xác định chủ đề tổng thể và định dạng mặc định, trong khi layout slide xác định cách sắp xếp cụ thể của các placeholder cho các loại nội dung khác nhau.

**Tôi có thể sao chép một layout slide từ một bài thuyết trình sang bài thuyết trình khác không?**

Có, bạn có thể sao chép một layout slide từ bộ sưu tập layout slide của một bài thuyết trình, có thể truy cập qua phương thức [getLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getLayoutSlides--) và chèn nó vào bài thuyết trình khác bằng phương thức `addClone`.

**Điều gì sẽ xảy ra nếu tôi xóa một layout slide mà vẫn đang được một slide sử dụng?**

Nếu bạn cố gắng xóa một layout slide vẫn còn được ít nhất một slide trong bài thuyết trình tham chiếu, Aspose.Slides sẽ ném ra một [PptxEditException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxeditexception/). Để tránh điều này, hãy sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) để an toàn xóa chỉ những layout slide không được sử dụng.