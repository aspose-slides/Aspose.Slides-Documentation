---
title: Quản lý Placeholder trong Java
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/java/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- trình giữ chỗ nội dung
- văn bản gợi ý
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, đồng thời hiểu về kế thừa placeholder với Aspose.Slides cho Java."
---
## **Tổng quan**

Placeholder là một hình dạng giữ chỗ cho một loại nội dung cụ thể trong mẫu bản trình chiếu. Các ví dụ phổ biến bao gồm tiêu đề, nội dung, hình ảnh, biểu đồ và placeholder nội dung đa mục đích. Không giống như một hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ slide bố cục hoặc slide chủ.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/). Phương thức trả về một đối tượng [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) hoặc `null` cho hình dạng bình thường. Sử dụng [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) để xác định placeholder dự kiến chứa gì.

Giao diện hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder trống cho văn bản, hình ảnh, biểu đồ hoặc nội dung thường được biểu diễn bằng một [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
- Một placeholder hình ảnh đã được điền dữ liệu có thể được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/).
- Một placeholder biểu đồ đã được điền dữ liệu có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/).
- Placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) và giao diện hình dạng thời gian chạy thay vì giả định mọi placeholder đều là một [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) mô tả vai trò của placeholder; nó không đảm bảo kiểu thời gian chạy của hình dạng. Luôn thực hiện kiểm tra kiểu trước khi truy cập các thành viên đặc thù cho văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu về kế thừa Placeholder**

Placeholder tạo thành một cấp bậc:

1. Slide chủ định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức chủ.
2. Slide bố cục định nghĩa cách sắp xếp được sử dụng cho một hoặc nhiều slide bình thường và có thể kế thừa từ slide chủ.
3. Slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ bố cục của nó.

Gọi [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) để di chuyển lên một cấp trong cây này. Placeholder của slide thường trả về placeholder của bố cục; placeholder của bố cục có thể trả về placeholder của slide chủ. Phương thức trả về `null` khi hình dạng không có placeholder cơ sở.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo placeholder cơ sở của chúng:

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

Chỉnh sửa một placeholder trên slide bình thường tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa bố cục hoặc slide chủ liên quan có thể ảnh hưởng tới tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng bình thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Xóa trạng thái Placeholder**

Khi điều chỉnh mẫu, sử dụng [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) để giữ một đối tượng hiện có như một hình dạng bình thường. Phương thức [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) của nó trả về `null`, nhưng hình dạng vẫn còn trong bộ sưu tập của slide. Ngược lại, [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) xóa hình dạng khỏi bộ sưu tập đó.

Ví dụ sau yêu cầu `template.pptx` có ít nhất một slide và một placeholder văn bản không rỗng trên slide đầu tiên. Sử dụng một placeholder với định dạng kế thừa từ bố cục hoặc slide chủ để nhìn hiệu quả của việc xóa quan hệ đó. Ví dụ kiểm tra rằng cùng một hình dạng vẫn còn, gọi lại phương thức trên hình dạng đã chuyển thành bình thường, và lưu kết quả.

{{% alert color="warning" title="Warning" %}}
Xóa trạng thái placeholder không tự động giữ lại các thiết lập hiển thị được kế thừa. Ví dụ dưới đây cố ý để nguyên các thiết lập đó, vì vậy đầu ra có thể trông khác. Một hình dạng mà vị trí và kích thước hoàn toàn được kế thừa có thể có tọa độ và kích thước bằng không sau cuộc gọi và trở nên vô hình dù vẫn còn trong bộ sưu tập.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || 
            textFrame == null || 
            textFrame.getText() == null || 
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Gọi phương thức trên một hình dạng thường không có hiệu lực.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Đối với một placeholder phù hợp, cả ba kiểm tra đều in `true`. Văn bản vẫn còn, nhưng vị trí, kích thước, xoay, phông chữ, căn đoạn, lề khung văn bản, neo dọc, độ phủ và thiết lập đường viền được kế thừa có thể thay đổi khi quan hệ placeholder bị xóa. Ví dụ, định dạng tiêu đề được kế thừa có thể quay lại định dạng văn bản thông thường. Xem [Slide Layout](/slides/vi/java/slide-layout/) để biết thêm về bố cục.

Để bảo toàn giao diện mong muốn, ghi lại vị trí, kích thước và góc xoay đã được giải quyết trước khi gọi, và sao chép các giá trị định dạng hiệu quả cần thiết vào các biến riêng. Lấy các giá trị này thông qua [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), và [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--). Không dựa vào việc chỉ giữ lại các đối tượng định dạng hiệu quả, vì các giá trị định dạng văn bản của chúng có thể thay đổi sau khi quan hệ bị xóa. Áp dụng rõ ràng các giá trị đã ghi lại cho hình dạng bình thường sau đó, bao gồm họ phông chữ, kích thước, kiểu, màu, thiết lập đoạn, thiết lập khung văn bản, độ phủ và đường viền được mẫu sử dụng.

Hình học của hình dạng được kế thừa cũng có thể cần được gán một cách rõ ràng qua [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-). Đối với một placeholder văn bản hình chữ nhật, điều này có nghĩa là gán [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle); chỉ khôi phục độ phủ và đường viền có thể không khôi phục lại hình chữ nhật hiển thị. Các mẫu có hiệu ứng bổ sung hoặc định dạng phức tạp hơn cũng cần xử lý các thiết lập đó.

## **Thay đổi Văn bản trong Placeholder**

Tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và placeholder văn bản thường hỗ trợ văn bản. Kiểm tra xem có phải là [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) trước khi sử dụng phương thức [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) của nó.

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

Mẫu này tránh việc ép kiểu placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện sang [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Nó cũng xác định placeholder theo mục đích thay vì dựa vào chỉ mục hình dạng dễ bị phá vỡ.

## **Đặt Văn bản Gợi ý trên Layout**

Văn bản gợi ý là hướng dẫn thời gian thiết kế hiển thị trong một placeholder trống, chẳng hạn *Nhấn vào để thêm tiêu đề*. Đặt văn bản gợi ý tùy chỉnh trên placeholder của bố cục thay vì cố gắng truy cập nó qua bộ sưu tập hình dạng của slide bình thường. Truy cập bố cục qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) và lặp qua bộ sưu tập trả về bởi [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/).

Ví dụ sau thay đổi các gợi ý tiêu đề và phụ đề trên bố cục được sử dụng bởi slide đầu tiên:

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

Văn bản gợi ý không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, gợi ý sẽ không còn hiển thị. Thay đổi gợi ý cũng không thay thế văn bản hiện có trên các slide dùng bố cục đó.

## **Cập nhật Placeholder Hình ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền dữ liệu và được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), thay thế ảnh qua [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) và [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/).
- Nếu nó vẫn là một placeholder trống, thêm một khung hình ảnh tại tọa độ của placeholder bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) và xóa placeholder trống.

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

Việc thay thế được tạo cho một placeholder trống là một khung hình ảnh cục bộ, không phải một placeholder mới, vì [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) không cung cấp setter. Nó giữ vị trí đã được dự trữ nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc duy trì quan hệ placeholder là thiết yếu, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt ảnh, cắt ảnh và các hiệu ứng đặc thù khác, xem [Manage Picture Frames](/slides/vi/java/picture-frame/). Các thao tác này thuộc về khung ảnh hoặc độ phủ ảnh, không phải siêu dữ liệu placeholder.

## **Làm việc với Placeholder Biểu đồ và Nội dung**

Một placeholder biểu đồ đã được điền dữ liệu có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/). Ví dụ này tìm biểu đồ như vậy bằng cả loại placeholder và giao diện thời gian chạy, thay đổi tiêu đề và lưu tệp:

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

Placeholder nội dung chung thường có [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). Trong PowerPoint nó hoạt động như một bộ khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi được điền, kiểm tra giao diện hình dạng thực tế để biết nó chứa gì. Các bố cục chuyên biệt cũng có thể hiển thị [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), hoặc [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/).

Aspose.Slides không chuyển một placeholder [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) trống thành một [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) chỉ bằng cách thay đổi [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/); loại không thể thay đổi qua giao diện. Để lập trình tạo một biểu đồ hoặc khu vực nội dung trống, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó xóa placeholder trống. Ví dụ sau thực hiện điều này cho một biểu đồ:

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

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm khu vực của placeholder nhưng không kế thừa từ placeholder bố cục. Sử dụng các bài viết chuyên về quản lý biểu đồ ([chart management articles](/slides/vi/java/powerpoint-charts/)) khi cần thay thế danh mục, chuỗi hoặc dữ liệu workbook.

## **Ví dụ hoàn chỉnh: Cập nhật nội dung Văn bản hoặc Hình ảnh**

Ví dụ cuối cùng này mở một mẫu, tìm kiếm slide đầu tiên cho một placeholder tiêu đề hoặc hình ảnh, kiểm tra các loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu đầu ra. Ví dụ cố ý tránh việc giả định chỉ mục hình dạng hoặc ép kiểu mọi placeholder sang cùng một giao diện.

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

## **FAQ**

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên bố cục hoặc slide chủ mà một placeholder khác kế thừa. Sử dụng [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) để lấy nó. Một hình dạng cục bộ bình thường trả về `null` vì nó không thuộc cây placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa một placeholder bố cục không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản gợi ý qua bố cục, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, hãy lặp qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm thế nào để quản lý placeholder ngày tháng, số slide, header và footer?**

Sử dụng các trình quản lý header và footer ở cấp slide, bố cục, slide chủ, ghi chú hoặc handout tương ứng. Xem [Manage Presentation Header and Footer](/slides/vi/java/presentation-header-and-footer/) để có các ví dụ hoàn chỉnh.