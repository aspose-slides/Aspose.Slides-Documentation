---
title: Thay đổi kích thước hình dạng trên các slide của bản trình chiếu trong Java
type: docs
weight: 130
url: /vi/java/resizing-shapes-on-slide/
aliases:
  - /vi/java/re-sizing-shapes-on-slide/
  /java/re-sizing-shapes-on-slide/
keywords:
- thay đổi kích thước hình dạng
- đổi kích thước hình dạng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước hình dạng trên các slide PowerPoint và OpenDocument với Aspose.Slides cho Java—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Khi bạn thay đổi kích thước slide của bản trình chiếu, bạn có thể cần phải thay đổi kích thước và vị trí lại các hình dạng để chúng phù hợp với kích thước mới. Bài viết này cho biết cách thu phóng hình dạng một cách thủ công và cách xử lý bảng trên slide, master và layout.

## **Thay đổi kích thước hình dạng**

Để giữ nguyên vị trí và kích thước tương đối của mỗi hình dạng, nhân tọa độ ngang và chiều rộng của nó với tỉ lệ giữa chiều rộng slide mới và chiều rộng gốc. Áp dụng tỉ lệ chiều cao tương ứng cho tọa độ dọc và chiều cao của nó.

Ví dụ đầu tiên tải một bản trình chiếu mà các slide không chứa bảng, thay đổi kích thước slide thành A4 và lưu kết quả. Nó sử dụng [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) cùng với [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) để vòng lặp tiếp theo kiểm soát việc thu phóng. Các tỉ lệ không có đơn vị; vị trí và kích thước hình dạng được đo bằng điểm. Các tỉ lệ chiều rộng và chiều cao khác nhau có thể làm biến dạng hình dạng, và việc thay đổi kích thước của một hình dạng không làm thay đổi kích thước phông chữ của nó.

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
Bảng yêu cầu xử lý riêng: thu phóng chiều rộng các cột và chiều cao các hàng thay vì chỉ định chiều rộng và chiều cao tổng thể của bảng. Chiều cao hàng có thể vẫn lớn hơn yêu cầu nếu nội dung ô yêu cầu nhiều không gian hơn.
{{% /alert %}}

Ví dụ thứ hai hỗ trợ bảng và xử lý các hình dạng trên master và layout cũng như trên các slide riêng lẻ trước khi lưu bản trình chiếu đã thay đổi kích thước. Trợ giúp của nó xử lý mỗi [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) bằng cách thu phóng chiều rộng các cột bằng [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) và chiều cao tối thiểu của các hàng bằng [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Sau đó nó thu phóng vị trí của bảng mà không thu phóng riêng biệt các kích thước tổng thể của nó.

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

    // Thay đổi kích thước các hình dạng được định nghĩa trên master và layout cũng như trên các slide riêng lẻ.
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

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt sau khi thay đổi kích thước slide?**

Nếu bạn thay đổi kích thước slide mà không thu phóng các hình dạng, chúng sẽ giữ nguyên vị trí và kích thước gốc và có thể vượt ra ngoài slide. Thu phóng chiều rộng và chiều cao bằng các tỉ lệ khác nhau cũng có thể làm biến dạng các hình dạng.

**Mã được cung cấp có hoạt động cho tất cả các loại hình dạng không?**

Ví dụ đầu tiên thay đổi giới hạn của hình dạng trực tiếp và được thiết kế cho các slide không có bảng. Ví dụ thứ hai xử lý bảng riêng biệt. Hãy kiểm tra bố cục kết quả, đặc biệt là văn bản và bảng, vì các ví dụ này không thu phóng kích thước phông chữ và nội dung bảng có thể giới hạn chiều cao hàng.

**Làm thế nào để tôi thay đổi kích thước bảng khi thay đổi kích thước slide?**

Thu phóng chiều rộng các cột theo tỉ lệ chiều rộng và chiều cao tối thiểu của các hàng theo tỉ lệ chiều cao, sau đó thu phóng vị trí của bảng mà không thu phóng riêng biệt các kích thước tổng thể của nó.

**Việc thay đổi kích thước này có hoạt động cho các slide master và layout không?**

Có. Ví dụ thứ hai duyệt qua [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) và các [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) của mỗi master và áp dụng cùng một logic thay đổi kích thước cho các hình dạng của chúng.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Gọi [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) sau khi thay đổi kích thước slide và trước khi đọc các kích thước mục tiêu, để các hệ số thu phóng phản ánh hướng cuối cùng.

**Có giới hạn nào đối với kích thước slide tôi có thể đặt không?**

Bạn có thể chỉ định kích thước slide tùy chỉnh bằng [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). Các kích thước được hỗ trợ còn phụ thuộc vào định dạng bản trình chiếu và ứng dụng dùng để mở tệp.

**Làm sao tôi có thể ngăn các hình dạng có tỉ lệ khung cố định bị biến dạng?**

Sử dụng cùng một hệ số thu phóng cho chiều rộng và chiều cao. Để vừa với bố cục gốc trong kích thước slide mới, hãy sử dụng tỉ lệ nhỏ hơn giữa tỉ lệ chiều rộng và chiều cao cho cả kích thước và vị trí. Điều này giữ nguyên tỉ lệ nhưng có thể để lại không gian chưa sử dụng ở một cạnh.