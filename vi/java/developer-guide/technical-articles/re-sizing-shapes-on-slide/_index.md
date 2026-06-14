---
title: Thay đổi kích thước các hình dạng trên slide trình chiếu
type: docs
weight: 110
url: /vi/java/re-sizing-shapes-on-slide/
keywords:
- thay đổi kích thước hình dạng
- đổi kích thước hình dạng
- PowerPoint
- OpenDocument
- trình chiếu
- Java
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên slide PowerPoint và OpenDocument với Aspose.Slides cho Java—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Một trong những câu hỏi phổ biến nhất từ khách hàng Aspose.Slides for Java là cách thay đổi kích thước các hình dạng sao cho khi kích thước slide thay đổi, dữ liệu không bị cắt bỏ. Bài viết kỹ thuật ngắn này trình bày cách thực hiện.

## **Thay đổi kích thước hình dạng**

Để ngăn các hình dạng bị lệch vị trí khi kích thước slide thay đổi, hãy cập nhật vị trí và kích thước của từng hình dạng sao cho chúng phù hợp với bố cục slide mới.

```java
// Tải tệp trình chiếu.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Lấy kích thước slide gốc.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Thay đổi kích thước slide mà không tỷ lệ các hình dạng hiện có.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Lấy kích thước slide mới.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Thay đổi kích thước và vị trí các hình dạng trên mọi slide.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Tỷ lệ vị trí hình dạng.
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

{{% alert color="primary" %}} 
Nếu một slide chứa bảng, đoạn mã trên sẽ không hoạt động chính xác. Trong trường hợp này, mỗi ô trong bảng phải được thay đổi kích thước.
{{% /alert %}} 

Sử dụng đoạn mã sau phía của bạn để thay đổi kích thước các slide chứa bảng. Đối với bảng, việc đặt chiều rộng hoặc chiều cao là trường hợp đặc biệt: bạn phải điều chỉnh chiều cao từng hàng và chiều rộng từng cột để thay đổi kích thước tổng thể của bảng.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Lấy kích thước slide gốc.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Thay đổi kích thước slide mà không tỷ lệ các hình dạng hiện có.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Lấy kích thước slide mới.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Tỷ lệ vị trí hình dạng.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Tỷ lệ kích thước hình dạng.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Tỷ lệ vị trí hình dạng.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Tỷ lệ kích thước hình dạng.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Tỷ lệ vị trí hình dạng.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt bỏ sau khi thay đổi kích thước slide?**

Khi thay đổi kích thước slide, các hình dạng giữ nguyên vị trí và kích thước ban đầu trừ khi tỉ lệ được thay đổi một cách rõ ràng. Điều này có thể dẫn đến nội dung bị cắt hoặc các hình dạng bị lệch vị trí.

**Mã cung cấp có hoạt động cho mọi loại hình dạng không?**

Ví dụ cơ bản hoạt động cho hầu hết các loại hình dạng (ô văn bản, hình ảnh, biểu đồ, v.v.). Tuy nhiên, đối với bảng, bạn cần xử lý riêng từng hàng và cột, vì chiều cao và chiều rộng của bảng được xác định bởi kích thước của các ô riêng lẻ.

**Làm sao để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Bạn cần duyệt qua tất cả các hàng và cột của bảng và thay đổi chiều cao và chiều rộng của chúng một cách tỉ lệ, như được minh họa trong ví dụ mã thứ hai.

**Việc thay đổi kích thước này có hoạt động cho các slide mẫu và slide bố cục không?**

Có, nhưng bạn cũng nên duyệt qua [Slide mẫu](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getMasters--) và [Slide bố cục](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getLayoutSlides--) và áp dụng cùng logic tỷ lệ cho các hình dạng của chúng để đảm bảo tính nhất quán trong toàn bộ bản trình bày.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Bạn có thể sử dụng [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidesize/#setOrientation-int-) để thay đổi hướng. Đảm bảo bạn thiết lập logic tỷ lệ tương ứng để duy trì bố cục.

**Có giới hạn nào về kích thước slide mà tôi có thể đặt không?**

Aspose.Slides hỗ trợ kích thước tùy chỉnh, nhưng kích thước quá lớn có thể ảnh hưởng đến hiệu năng hoặc tính tương thích với một số phiên bản PowerPoint.

**Làm sao để ngăn các hình dạng có tỷ lệ khung cố định bị biến dạng?**

Bạn có thể kiểm tra phương thức `getAspectRatioLocked` của hình dạng trước khi thực hiện tỷ lệ. Nếu nó bị khóa, hãy điều chỉnh chiều rộng hoặc chiều cao một cách tỉ lệ thay vì thay đổi chúng riêng lẻ.