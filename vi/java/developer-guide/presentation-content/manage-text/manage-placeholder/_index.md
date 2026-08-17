---
title: Quản lý Placeholder trong Java
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/java/manage-placeholder/
keywords:
- trình giữ chỗ
- placeholder văn bản
- placeholder hình ảnh
- placeholder biểu đồ
- placeholder nội dung
- văn bản gợi ý
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, cũng như hiểu về kế thừa placeholder với Aspose.Slides cho Java."
---
## **Tổng quan**

Placeholder là một hình dạng dành để giữ vị trí cho một loại nội dung nhất định trong mẫu bản trình chiếu. Các ví dụ phổ biến gồm tiêu đề, nội dung, hình ảnh, biểu đồ và các placeholder nội dung đa năng. Không giống như một hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ slide bố cục hoặc slide master.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [IShape.getPlaceholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/). Phương thức này trả về một đối tượng [IPlaceholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholder/) hoặc `null` đối với hình dạng bình thường. Sử dụng [IPlaceholder.getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholder/) để xác định placeholder dự định chứa gì.

Giao diện hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder văn bản, hình ảnh, biểu đồ hoặc nội dung trống thường được biểu diễn bằng một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/).
- Placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [IPlaceholder.getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholder/) và giao diện hình dạng tại thời gian chạy thay vì giả định mọi placeholder đều là một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholder/) mô tả vai trò của placeholder; nó không bảo đảm kiểu hình dạng tại thời gian chạy. Luôn kiểm tra kiểu trước khi truy cập các thành viên đặc thù cho văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu về kế thừa Placeholder**

Placeholder tạo thành một cây hierarchy:

1. Slide master xác định các kiểu dáng có thể tái sử dụng và, trong một số trường hợp, các placeholder ở cấp master.
2. Slide layout xác định bố trí được sử dụng bởi một hoặc nhiều slide bình thường và có thể kế thừa từ master.
3. Slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ layout của nó.

Gọi [IShape.getBasePlaceholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để di chuyển lên một cấp trong cây hierarchy này. Placeholder của một slide bình thường thường trả về placeholder của layout; placeholder của layout có thể trả về placeholder của master. Phương thức trả về `null` khi hình dạng không có base placeholder.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo base placeholder của chúng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Chỉnh sửa một placeholder trên slide bình thường sẽ tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa layout hoặc master liên quan có thể ảnh hưởng đến tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng bình thường cục bộ không có base placeholder và sẽ không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Thay đổi Văn bản trong Placeholder**

Tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và placeholder văn bản thường hỗ trợ văn bản. Kiểm tra xem có phải là một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) trước khi dùng phương thức [getTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) của nó.

Ví dụ này cập nhật placeholder tiêu đề đầu tiên trên slide đầu tiên và lưu kết quả:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mẫu này tránh việc ép kiểu các placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện sang [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/). Nó cũng nhận dạng placeholder theo mục đích thay vì dựa vào chỉ mục hình dạng không ổn định.

## **Đặt Văn bản Gợi ý trên Layout**

Văn bản gợi ý là hướng dẫn hiển thị trong một placeholder trống, chẳng hạn *Nhấn để thêm tiêu đề*. Đặt văn bản gợi ý tùy chỉnh trên placeholder của layout thay vì cố gắng truy cập thông qua bộ sưu tập hình dạng của slide bình thường. Truy cập layout qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/) và duyệt qua bộ sưu tập trả về bởi [ILayoutSlide.getShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/).

Ví dụ sau thay đổi gợi ý tiêu đề và phụ đề trên layout được sử dụng bởi slide đầu tiên:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Văn bản gợi ý không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, gợi ý sẽ không còn hiển thị. Thay đổi gợi ý cũng không thay thế văn bản hiện có trên các slide sử dụng layout đó.

## **Cập nhật Placeholder Hình ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/), thay thế ảnh qua [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) và [ISlidesPicture.setImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidespicture/).
- Nếu nó vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/) và xóa placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình chiếu:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Việc thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [IShape.getPlaceholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) không cung cấp setter. Nó giữ vị trí đã dành nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu cần giữ quan hệ placeholder, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) được tạo bằng Aspose.Slides.

Đối với độ trong suốt, cắt xén và các hiệu ứng đặc thù của hình ảnh, xem mục [Manage Picture Frames](/slides/vi/java/picture-frame/). Các thao tác đó thuộc về picture frame hoặc picture fill, không phải metadata của placeholder.

## **Làm việc với Placeholder Biểu đồ và Nội dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/). Ví dụ này tìm một biểu đồ như vậy bằng cả loại placeholder và giao diện thời gian chạy, thay đổi tiêu đề và lưu file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Placeholder nội dung chung thường có [PlaceholderType.Object](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholdertype/). Trong PowerPoint, nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi được điền, kiểm tra giao diện hình dạng thực tế để biết nó chứa gì. Các layout chuyên biệt cũng có thể hiển thị [PlaceholderType.Chart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholdertype/), hoặc [PlaceholderType.Diagram](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholdertype/).

Aspose.Slides không chuyển một placeholder [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) trống thành một [IChart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/) chỉ bằng cách thay đổi [IPlaceholder.getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholder/); loại không thể thay đổi qua giao diện. Để điền một biểu đồ hoặc vùng nội dung trống bằng chương trình, hãy thêm đối tượng cần thiết tại tọa độ của placeholder rồi xóa placeholder trống. Ví dụ sau thực hiện việc này cho một biểu đồ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm khu vực của placeholder nhưng không kế thừa từ placeholder của layout. Sử dụng các bài viết chuyên về quản lý biểu đồ [/slides/vi/java/powerpoint-charts/] khi bạn cần thay thế danh mục, series hoặc dữ liệu workbook của nó.

## **Ví dụ hoàn chỉnh: Cập nhật Nội dung Văn bản hoặc Hình ảnh**

Ví dụ end‑to‑end sau mở một mẫu, tìm placeholder tiêu đề hoặc hình ảnh trên slide đầu tiên, kiểm tra loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ này cố ý tránh việc giả định chỉ mục hình dạng hoặc ép kiểu mọi placeholder sang cùng một giao diện.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên layout hoặc master mà placeholder khác kế thừa. Sử dụng [IShape.getBasePlaceholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để lấy nó. Một hình dạng cục bộ thông thường trả về `null` vì không thuộc hierarchy của placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa một placeholder trên layout không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản gợi ý thông qua layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế tiêu đề thực tế trên toàn bản trình chiếu, cần lặp qua các slide và cập nhật từng placeholder tiêu đề.

**Làm thế nào để quản lý placeholder ngày tháng, số slide, tiêu đề và chân trang?**

Sử dụng các trình quản lý header và footer ở mức slide, layout, master, notes hoặc handout tương ứng. Xem mục [Manage Presentation Header and Footer](/slides/vi/java/presentation-header-and-footer/) để có các ví dụ đầy đủ.