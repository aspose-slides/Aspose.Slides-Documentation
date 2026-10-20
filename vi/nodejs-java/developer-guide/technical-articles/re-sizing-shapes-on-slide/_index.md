---
title: Thay đổi kích thước hình dạng trên slide bản trình chiếu trong Node.js
type: docs
weight: 130
url: /vi/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/doi-kich-thuoc-hinh-trong-slide/
keywords:
- thay đổi kích thước hình dạng
- thay đổi kích thước hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước hình dạng trên slide PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js thông qua Java—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Khi bạn thay đổi kích thước slide của một bản trình chiếu, bạn cũng có thể cần thay đổi kích thước và định vị lại các hình dạng để chúng vừa với kích thước mới. Bài viết này mô tả cách thu phóng các hình dạng một cách thủ công và cách xử lý bảng trên slide, master và layout.

## **Thay đổi kích thước hình dạng**

Để duy trì vị trí và kích thước tương đối của mỗi hình dạng, nhân tọa độ ngang và chiều rộng của nó với tỉ lệ giữa chiều rộng slide mới và chiều rộng gốc. Áp dụng tỉ lệ chiều cao tương ứng cho tọa độ dọc và chiều cao.

Ví dụ đầu tiên tải một bản trình chiếu có các slide không chứa bảng, thay đổi kích thước slide thành A4 và lưu kết quả. Nó sử dụng [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) cùng với [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) để vòng lặp tiếp theo kiểm soát việc thu phóng. Các tỉ lệ không có đơn vị; vị trí và kích thước của hình dạng được đo bằng điểm. Các tỉ lệ chiều rộng và chiều cao khác nhau có thể làm hình dạng bị biến dạng, và việc thay đổi kích thước của hình dạng không làm thay đổi kích thước phông chữ.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Tính các hệ số thu phóng ngang và dọc độc lập.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Bảng yêu cầu xử lý riêng: thu phóng chiều rộng cột và chiều cao hàng thay vì gán chiều rộng và chiều cao tổng thể cho bảng. Chiều cao hàng có thể vẫn lớn hơn yêu cầu nếu nội dung ô yêu cầu nhiều không gian hơn.
{{% /alert %}}

Ví dụ thứ hai hỗ trợ bảng và xử lý các hình dạng trên master và layout cũng như trên các slide riêng lẻ trước khi lưu bản trình chiếu đã được thay đổi kích thước. Trợ giúp của nó xử lý từng [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) bằng cách thu phóng chiều rộng cột với [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) và chiều cao tối thiểu của hàng với [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Sau đó nó thu phóng vị trí của bảng mà không thu phóng riêng biệt các kích thước tổng thể của bảng.
```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Kích thước bảng được kiểm soát bởi độ rộng cột và chiều cao hàng.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Tính các hệ số thu phóng ngang và dọc độc lập.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Thay đổi kích thước các hình dạng được định nghĩa trên master và layout cũng như trên các slide riêng lẻ.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt sau khi thay đổi kích thước slide?**

Nếu bạn thay đổi kích thước slide mà không thu phóng các hình dạng, chúng sẽ giữ vị trí và kích thước ban đầu và có thể vượt ra ngoài slide. Thu phóng chiều rộng và chiều cao bằng các tỉ lệ khác nhau cũng có thể làm hình dạng bị biến dạng.

**Mã được cung cấp có hoạt động cho tất cả các loại hình dạng không?**

Ví dụ đầu tiên thay đổi giới hạn của hình dạng một cách trực tiếp và được thiết kế cho các slide không có bảng. Ví dụ thứ hai xử lý bảng riêng biệt. Kiểm tra bố cục kết quả, đặc biệt là văn bản và bảng, vì các ví dụ này không thu phóng kích thước phông chữ và nội dung bảng có thể giới hạn chiều cao hàng.

**Làm sao để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Thu phóng chiều rộng cột theo tỉ lệ chiều rộng và chiều cao tối thiểu của hàng theo tỉ lệ chiều cao, sau đó thu phóng vị trí của bảng, như đã trình bày trong ví dụ thứ hai.

**Việc thay đổi kích thước này có áp dụng cho slide master và slide layout không?**

Có. Ví dụ thứ hai duyệt qua [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) và [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) của mỗi master và áp dụng cùng một logic thay đổi kích thước cho các hình dạng của chúng.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Gọi [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) sau khi thay đổi kích thước slide và trước khi đọc các kích thước mục tiêu, để các hệ số thu phóng phản ánh hướng cuối cùng.

**Có giới hạn nào về kích thước slide mà tôi có thể đặt không?**

Bạn có thể chỉ định kích thước slide tùy chỉnh bằng [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Các kích thước được hỗ trợ cũng phụ thuộc vào định dạng bản trình chiếu và ứng dụng được dùng để mở tệp.

**Làm sao tôi ngăn được các hình dạng có tỷ lệ khung cố định bị biến dạng?**

Sử dụng cùng một hệ số thu phóng cho chiều rộng và chiều cao. Để vừa bố cục gốc trong kích thước slide mới, hãy dùng tỉ lệ nhỏ hơn giữa tỉ lệ chiều rộng và chiều cao cho cả hai kích thước và vị trí. Điều này giữ nguyên tỉ lệ nhưng có thể để lại không gian trống ở một cạnh.