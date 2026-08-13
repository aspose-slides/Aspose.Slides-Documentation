---
title: Thay đổi kích thước hình dạng trên các slide trình chiếu
type: docs
weight: 110
url: /vi/java/re-sizing-shapes-on-slide/
keywords:
- thay đổi kích thước hình dạng
- thay đổi kích thước hình dạng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước hình dạng trên các slide PowerPoint và OpenDocument với Aspose.Slides cho Java—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Một trong những câu hỏi phổ biến nhất từ khách hàng Aspose.Slides for Java là cách thay đổi kích thước các hình dạng để khi kích thước slide thay đổi, dữ liệu không bị cắt bỏ. Bài viết kỹ thuật ngắn này sẽ chỉ cách thực hiện.

## **Thay đổi kích thước hình dạng**

Để ngăn các hình dạng bị lệch khi kích thước slide thay đổi, hãy cập nhật vị trí và kích thước của từng hình dạng sao cho chúng phù hợp với bố cục slide mới.

```java
import com.aspose.slides.*;

// Tải tệp trình chiếu.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Lấy kích thước slide gốc.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Thay đổi kích thước slide mà không thay đổi tỷ lệ các hình dạng hiện có.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Lấy kích thước slide mới.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Thay đổi kích thước và vị trí các hình dạng trên mỗi slide.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Thay đổi tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Thay đổi tỷ lệ vị trí hình dạng.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}Bảng không cần xử lý đặc biệt: việc đặt chiều rộng và chiều cao cho bảng sẽ tự động thay đổi tỷ lệ cột và hàng một cách tỷ lệ, vì vậy việc lại thay đổi lại chiều cao hàng và chiều rộng cột sẽ áp dụng tỷ lệ hai lần.{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Lấy kích thước slide gốc.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Thay đổi kích thước slide mà không thay đổi tỷ lệ các hình dạng hiện có.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Lấy kích thước slide mới.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Thay đổi tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Thay đổi tỷ lệ vị trí hình dạng.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Thay đổi tỷ lệ kích thước hình dạng.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Thay đổi tỷ lệ vị trí hình dạng.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Thay đổi tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Thay đổi tỷ lệ vị trí hình dạng.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

### Tại sao các hình dạng bị biến dạng hoặc bị cắt khi thay đổi kích thước slide?

Khi thay đổi kích thước slide, các hình dạng giữ nguyên vị trí và kích thước ban đầu trừ khi tỷ lệ được thay đổi một cách rõ ràng. Điều này có thể dẫn đến nội dung bị cắt hoặc các hình dạng bị lệch.

### Mã được cung cấp có hoạt động với mọi loại hình dạng không?

Có. Việc đặt chiều cao và chiều rộng hoạt động cho các hộp văn bản, hình ảnh, biểu đồ và bảng giống nhau.

### Làm thế nào để thay đổi kích thước bảng khi thay đổi kích thước slide?

Thay đổi kích thước hình dạng bảng giống như bất kỳ hình dạng nào khác. Các hàng và cột của nó sẽ theo tỷ lệ, vì vậy không cần thay đổi lại chúng sau đó.

### Thay đổi kích thước này có áp dụng cho các slide master và layout không?

Có, nhưng bạn cũng nên duyệt qua [Masters](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getMasters--) và [Layout slides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getLayoutSlides--) và áp dụng cùng logic scaling cho các hình dạng của chúng để đảm bảo tính nhất quán trong toàn bộ bản trình bày.

### Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?

Có. Bạn có thể sử dụng [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidesize/#setOrientation-int-) để thay đổi hướng. Đảm bảo bạn thiết lập logic scaling phù hợp để giữ nguyên bố cục.

### Có giới hạn nào cho kích thước slide tôi có thể đặt không?

Aspose.Slides hỗ trợ kích thước tùy chỉnh, nhưng kích thước rất lớn có thể ảnh hưởng đến hiệu suất hoặc khả năng tương thích với một số phiên bản PowerPoint.

### Làm sao để ngăn các hình dạng có tỷ lệ khung cố định bị biến dạng?

Bạn có thể kiểm tra phương thức `getAspectRatioLocked` của hình dạng trước khi scaling. Nếu nó bị khóa, hãy điều chỉnh chiều rộng hoặc chiều cao một cách tỷ lệ thay vì thay đổi chúng riêng lẻ.