---
title: Áp dụng hoặc Thay đổi bố cục slide trong JavaScript
linktitle: Bố cục Slide
type: docs
weight: 60
url: /vi/nodejs-java/slide-layout/
keywords:
- bố cục slide
- bố cục nội dung
- vị trí giữ chỗ
- thiết kế bài thuyết trình
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý và tùy chỉnh bố cục slide trong Aspose.Slides cho Node.js. Khám phá các loại bố cục, kiểm soát placeholder và hiển thị chân trang qua các ví dụ mã."
---
## **Giới thiệu**

Một bố cục slide định nghĩa cách sắp xếp các hộp giữ chỗ và định dạng cho nội dung trên slide. Nó kiểm soát các placeholder nào có sẵn và chúng xuất hiện ở đâu. Bố cục slide giúp bạn thiết kế bài thuyết trình nhanh chóng và nhất quán—dù bạn đang tạo một slide đơn giản hay phức tạp. Một số bố cục slide phổ biến nhất trong PowerPoint bao gồm:

**Bố cục Slide Tiêu đề** – Bao gồm hai placeholder văn bản: một cho tiêu đề và một cho phụ đề.

**Bố cục Tiêu đề và Nội dung** – Có một placeholder tiêu đề nhỏ ở trên cùng và một placeholder lớn hơn bên dưới dành cho nội dung chính (như văn bản, danh sách dấu đầu dòng, biểu đồ, hình ảnh, và hơn thế nữa).

**Bố cục Trống** – Không chứa placeholder nào, cho phép bạn thiết kế slide từ đầu.

Bố cục slide là một phần của slide master, là slide cấp cao nhất định nghĩa các kiểu bố cục cho toàn bộ bài thuyết trình. Bạn có thể truy cập và sửa đổi các slide bố cục thông qua slide master—bằng loại, tên hoặc ID duy nhất. Ngoài ra, bạn cũng có thể chỉnh sửa trực tiếp một slide bố cục cụ thể trong bài thuyết trình.

Để làm việc với bố cục slide trong Aspose.Slides for Node.js, bạn có thể sử dụng:

- Các phương thức như [getLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getLayoutSlides) và [getMasters](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getMasters) trong lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/)
- Các kiểu như [LayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/), và [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Để tìm hiểu thêm về cách làm việc với slide master, hãy xem bài viết [Slide Master](/slides/vi/nodejs-java/slide-master/).
{{% /alert %}}

## **Thêm Bố cục Slide vào Bài thuyết trình**

Để tùy chỉnh giao diện và cấu trúc của các slide, bạn có thể cần thêm các slide bố cục mới vào bài thuyết trình. Aspose.Slides for Node.js cho phép bạn kiểm tra xem một bố cục cụ thể đã tồn tại chưa, thêm mới nếu cần và sử dụng nó để chèn slide dựa trên bố cục đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Truy cập vào [MasterLayoutSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Kiểm tra xem slide bố cục mong muốn đã có trong bộ sưu tập chưa. Nếu chưa, thêm slide bố cục cần thiết.
1. Thêm một slide trống dựa trên slide bố cục mới.
1. Lưu bài thuyết trình.

Mã JavaScript sau minh họa cách thêm một bố cục slide vào bài thuyết trình PowerPoint:

```js
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Duyệt qua các loại slide bố cục để chọn một slide bố cục.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Trường hợp bài thuyết trình không chứa tất cả các loại bố cục.
        // Tệp bài thuyết trình chỉ chứa các loại bố cục Trống và Tùy chỉnh.
        // Tuy nhiên, các slide bố cục với loại tùy chỉnh có thể có tên nhận dạng được,
        // chẳng hạn như "Title", "Title and Content", v.v., có thể dùng để chọn slide bố cục.
        // Bạn cũng có thể dựa trên một tập hợp các loại hình placeholder.
        // Ví dụ, một slide Tiêu đề chỉ nên có loại placeholder Tiêu đề, v.v.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Thêm một slide trống sử dụng slide bố cục đã thêm.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Lưu bài thuyết trình ra đĩa.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Các Slide Bố cục Không được sử dụng**

Aspose.Slides cung cấp phương thức [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) từ lớp [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/) để cho phép bạn xóa các slide bố cục không cần và không được sử dụng.

Mã JavaScript sau cho thấy cách loại bỏ một slide bố cục khỏi bài thuyết trình PowerPoint:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Placeholder vào Bố cục Slide**

Aspose.Slides cung cấp phương thức [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager), cho phép bạn thêm các placeholder mới vào một slide bố cục.

Trình quản lý này chứa các phương thức cho các loại placeholder sau:

| Placeholder trong PowerPoint        | Phương thức của [LayoutPlaceholderManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Nội dung](content.png)           | addContentPlaceholder(float x, float y, float width, float height) |
| ![Nội dung (Chiều dọc)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Văn bản](text.png)               | addTextPlaceholder(float x, float y, float width, float height) |
| ![Văn bản (Chiều dọc)](textV.png)  | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Hình ảnh](picture.png)           | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Biểu đồ](chart.png)              | addChartPlaceholder(float x, float y, float width, float height) |
| ![Bảng](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)          | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Hình ảnh trực tuyến](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Mã JavaScript dưới đây minh họa cách thêm các hình dạng placeholder mới vào slide bố cục Trống:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Lấy slide bố cục Trống.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Lấy trình quản lý placeholder của slide bố cục.
    let placeholderManager = layout.getPlaceholderManager();

    // Thêm các placeholder khác nhau vào slide bố cục Trống.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Thêm một slide mới với bố cục Trống.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các placeholder trên slide bố cục](add_placeholders.png)

## **Đặt Hiển thị Chân trang cho Slide Bố cục**

Trong bài thuyết trình PowerPoint, các thành phần chân trang như ngày tháng, số slide và văn bản tùy chỉnh có thể được hiển thị hoặc ẩn tùy thuộc vào bố cục slide. Aspose.Slides for Node.js cho phép bạn kiểm soát việc hiển thị các placeholder chân trang này. Điều này hữu ích khi bạn muốn một số bố cục hiển thị thông tin chân trang trong khi các bố cục khác giữ sạch sẽ và tối giản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến slide bố cục theo chỉ mục.
1. Đặt placeholder chân trang slide thành hiển thị.
1. Đặt placeholder số slide thành hiển thị.
1. Đặt placeholder ngày‑giờ thành hiển thị.
1. Lưu bài thuyết trình.

Mã JavaScript sau cho thấy cách đặt hiển thị chân trang slide và thực hiện các tác vụ liên quan:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Đặt Hiển thị Chân trang Con cho Slide**

​Trong bài thuyết trình PowerPoint, các thành phần chân trang như ngày tháng, số slide và văn bản tùy chỉnh có thể được kiểm soát ở mức slide master để đảm bảo tính nhất quán trên tất cả các slide bố cục. Aspose.Slides for Node.js cho phép bạn thiết lập hiển thị và nội dung của các placeholder chân trang này trên slide master và lan truyền các cài đặt này tới tất cả các slide bố cục con. Cách làm này đảm bảo thông tin chân trang đồng nhất trong suốt bài thuyết trình.​

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy tham chiếu đến slide master theo chỉ mục.
1. Đặt các placeholder chân trang của master và tất cả các slide con thành hiển thị.
1. Đặt các placeholder số slide của master và tất cả các slide con thành hiển thị.
1. Đặt các placeholder ngày‑giờ của master và tất cả các slide con thành hiển thị.
1. Lưu bài thuyết trình.

Mã JavaScript dưới đây minh họa thao tác này:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **CÂU HỎI THƯỜNG GẶP**

**Sự khác nhau giữa slide master và slide bố cục là gì?**

Slide master định nghĩa chủ đề chung và định dạng mặc định, trong khi các slide bố cục xác định cách sắp xếp cụ thể các placeholder cho các loại nội dung khác nhau.

**Tôi có thể sao chép một slide bố cục từ bài thuyết trình này sang bài thuyết trình khác không?**

Có, bạn có thể sao chép một slide bố cục từ bộ sưu tập slide bố cục của một bài thuyết trình (có thể truy cập qua phương thức [getLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getLayoutSlides)) và chèn nó vào một bài thuyết trình khác bằng phương thức `addClone`.

**Điều gì sẽ xảy ra nếu tôi xóa một slide bố cục mà vẫn còn được một slide nào đó sử dụng?**

Nếu bạn cố gắng xóa một slide bố cục mà vẫn được ít nhất một slide tham chiếu trong bài thuyết trình, Aspose.Slides sẽ ném ra một ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxeditexception/). Để tránh tình huống này, hãy sử dụng [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), phương thức sẽ an toàn xóa chỉ những slide bố cục không được sử dụng.