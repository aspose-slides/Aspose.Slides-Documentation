---
title: Thay đổi kích thước các hình dạng trên slide trình chiếu bằng Java
type: docs
weight: 130
url: /vi/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /vi/java/re-sizing-shapes-on-slide/
keywords:
  - thay đổi kích thước hình dạng
  - thay đổi kích thước hình
  - PowerPoint
  - OpenDocument
  - trình chiếu
  - Java
  - Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên slide PowerPoint và OpenDocument bằng Aspose.Slides cho Java—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Overview**

Khi bạn thay đổi kích thước slide của bản trình chiếu, bạn cũng có thể cần thay đổi kích thước và vị trí lại các hình dạng để chúng phù hợp với kích thước mới. Bài viết này hướng dẫn cách thu phóng các hình dạng một cách thủ công và cách xử lý bảng trên slide, master và layout.

## **Resize Shapes**

Để giữ nguyên vị trí và kích thước tương đối của mỗi hình dạng, nhân tọa độ ngang và chiều rộng của nó với tỉ lệ của chiều rộng slide mới so với chiều rộng gốc. Áp dụng tỉ lệ chiều cao tương ứng cho các tọa độ dọc và chiều cao.

Ví dụ đầu tiên tải một bản trình chiếu mà các slide không chứa bảng, thay đổi kích thước slide thành A4 và lưu kết quả. Nó sử dụng [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) với [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) để vòng lặp tiếp theo kiểm soát việc thu phóng. Các tỉ lệ không có đơn vị; vị trí và kích thước của hình dạng được đo bằng điểm. Các tỉ lệ chiều rộng và chiều cao khác nhau có thể làm biến dạng hình dạng, và việc thay đổi kích thước hình dạng không làm thu phóng kích thước phông chữ.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Tính các hệ số thu phóng ngang và dọc độc lập.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Bảng cần được xử lý riêng: thu phóng độ rộng cột và chiều cao hàng thay vì gán toàn bộ độ rộng và chiều cao cho bảng. Chiều cao hàng có thể vẫn lớn hơn yêu cầu nếu nội dung ô cần thêm không gian.
{{% /alert %}}

Ví dụ thứ hai hỗ trợ bảng và xử lý các hình dạng trên master và layout cũng như trên các slide riêng lẻ trước khi lưu bản trình chiếu đã thay đổi kích thước. Trợ giúp của nó xử lý mỗi [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) bằng cách thu phóng độ rộng cột với [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) và chiều cao tối thiểu của hàng với [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Sau đó nó thu phóng vị trí của bảng mà không thu phóng riêng biệt các kích thước tổng thể của bảng.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Kích thước bảng được kiểm soát bởi độ rộng cột và chiều cao hàng.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Tính các hệ số thu phóng ngang và dọc độc lập.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Thay đổi kích thước các hình dạng được định nghĩa trên master và layout cũng như các slide riêng lẻ.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt sau khi thay đổi kích thước slide?**

Nếu bạn thay đổi kích thước slide mà không thu phóng các hình dạng, chúng sẽ giữ vị trí và kích thước ban đầu và có thể vượt ra ngoài slide. Thu phóng chiều rộng và chiều cao bằng các tỉ lệ khác nhau cũng có thể làm biến dạng hình dạng.

**Mã được cung cấp có hoạt động với mọi loại hình dạng không?**

Ví dụ đầu tiên thay đổi giới hạn của hình dạng trực tiếp và được thiết kế cho các slide không có bảng. Ví dụ thứ hai xử lý bảng riêng biệt. Hãy kiểm tra bố cục kết quả, đặc biệt là văn bản và bảng, vì các ví dụ này không thu phóng kích thước phông chữ và nội dung bảng có thể hạn chế chiều cao hàng.

**Làm thế nào để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Thu phóng độ rộng cột bằng tỉ lệ chiều rộng và chiều cao tối thiểu của hàng bằng tỉ lệ chiều cao, sau đó thu phóng vị trí của bảng, như đã trình bày trong ví dụ thứ hai.

**Việc thay đổi kích thước này có áp dụng cho các slide master và layout không?**

Có. Ví dụ thứ hai lặp qua [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) và từng [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) của master, và áp dụng cùng logic thay đổi kích thước cho các hình dạng của chúng.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Gọi [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) sau khi thay đổi kích thước slide và trước khi đọc các kích thước mục tiêu, để các hệ số thu phóng phản ánh hướng cuối cùng.

**Có giới hạn nào cho kích thước slide mà tôi có thể đặt không?**

Bạn có thể chỉ định kích thước slide tùy chỉnh với [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Các kích thước được hỗ trợ cũng phụ thuộc vào định dạng bản trình chiếu và ứng dụng dùng để mở file.

**Làm sao để ngăn các hình dạng có tỷ lệ khung hình cố định bị biến dạng?**

Sử dụng cùng một hệ số thu phóng cho chiều rộng và chiều cao. Để vừa bố cục gốc trong kích thước slide mới, hãy dùng tỉ lệ nhỏ hơn trong hai tỉ lệ chiều rộng và chiều cao cho cả hai kích thước và vị trí. Cách này giữ tỉ lệ nhưng có thể để lại không gian trống ở một cạnh.