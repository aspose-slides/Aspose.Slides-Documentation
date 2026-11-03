---
title: Quản lý Placeholder trong Bản trình chiếu trên Android
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/androidjava/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- trình giữ chỗ nội dung
- văn bản nhắc nhở
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, đồng thời hiểu cách kế thừa placeholder với Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

A placeholder is a shape that reserves a position for a particular kind of content in a presentation template. Common examples are title, body, picture, chart, and general-purpose content placeholders. Unlike an ordinary shape, a placeholder can inherit its position, size, formatting, and other settings from a layout slide or master slide.

Aspose.Slides provides placeholder information through the [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) method. The method returns an [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) object or `null` for a normal shape. Use [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) to determine what the placeholder is intended to contain.

The shape interface still matters after you know the placeholder type:

- A placeholder văn bản, hình ảnh, biểu đồ hoặc nội dung trống thường được biểu diễn bằng một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- Một placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) và giao diện hình dạng thời gian chạy thay vì giả định rằng mọi placeholder đều là một [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) mô tả vai trò của placeholder; nó không đảm bảo loại hình dạng thời gian chạy. Luôn luôn kiểm tra loại trước khi truy cập các thành viên liên quan tới văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu về kế thừa Placeholder**

Placeholders tạo thành một hệ thống phân cấp:

1. Một slide master định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức master.
2. Một slide layout định nghĩa cách sắp xếp được sử dụng cho một hoặc nhiều slide thông thường và có thể kế thừa từ master.
3. Một slide thông thường chứa các placeholder cho slide đó và có thể kế thừa từ layout của nó.

Gọi [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) để di chuyển lên một cấp trong hệ thống phân cấp này. Một placeholder slide thường trả về placeholder layout của nó; một placeholder layout có thể trả về placeholder master. Phương thức trả về `null` khi hình dạng không có placeholder cơ sở.

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

Chỉnh sửa một placeholder trên slide thông thường tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa layout hoặc master liên quan có thể ảnh hưởng đến tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Xóa trạng thái Placeholder**

Khi tùy chỉnh một mẫu, sử dụng [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) để giữ một đối tượng hiện có như một hình dạng thường. Phương thức [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) của nó trả về `null`, nhưng hình dạng vẫn còn trong bộ sưu tập của slide. Ngược lại, [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) sẽ xóa hình dạng khỏi bộ sưu tập đó.

Ví dụ sau yêu cầu `template.pptx` có ít nhất một slide và một placeholder văn bản không rỗng trên slide đầu tiên. Sử dụng một placeholder với định dạng kế thừa từ layout hoặc master để nhìn thấy hiệu quả của việc xóa mối quan hệ đó. Ví dụ kiểm tra rằng hình dạng vẫn còn, gọi lại phương thức trên hình dạng hiện là thường, và lưu kết quả.

{{% alert color="warning" title="Warning" %}}
Xóa trạng thái placeholder không tự động giữ lại các thiết lập hiển thị kế thừa. Ví dụ dưới đây cố ý để các thiết lập đó không thay đổi, vì vậy đầu ra có thể trông khác. Một hình dạng mà vị trí và kích thước hoàn toàn được kế thừa có thể có tọa độ và kích thước bằng zero sau cuộc gọi và trở nên vô hình mặc dù vẫn còn trong bộ sưu tập.
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

        // Gọi phương thức trên một hình dạng thường không có tác dụng.
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

Đối với một placeholder khớp, cả ba kiểm tra đều in `true`. Văn bản vẫn còn, nhưng vị trí, kích thước, xoay, phông chữ, căn đoạn, lề khung văn bản, neo dọc, màu nền và thiết lập đường viền kế thừa có thể thay đổi khi mối quan hệ placeholder bị xóa. Ví dụ, định dạng tiêu đề kế thừa có thể quay lại định dạng văn bản thường. Xem [Slide Layout](/slides/vi/androidjava/slide-layout/) để biết thêm về layout.

Để giữ nguyên giao diện mong muốn, hãy ghi lại vị trí, kích thước và góc xoay đã được giải quyết trước khi gọi, và sao chép các giá trị định dạng hiệu quả cần thiết vào các biến riêng. Lấy các giá trị này thông qua [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), và [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). Không nên chỉ dựa vào các đối tượng định dạng hiệu quả, vì các giá trị định dạng văn bản của chúng có thể thay đổi sau khi mối quan hệ bị xóa. Áp dụng một cách rõ ràng các giá trị đã ghi lại cho hình dạng thường sau đó, bao gồm họ phông chữ, kích thước, kiểu, màu, cài đặt đoạn, cài đặt khung văn bản, màu nền và đường viền được sử dụng trong mẫu của bạn.

Hình học của hình dạng kế thừa cũng có thể cần được chỉ định rõ ràng thông qua [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). Đối với một placeholder văn bản dạng hình chữ nhật, điều này có nghĩa là gán [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle); chỉ khôi phục màu nền và đường viền có thể không khôi phục lại hình chữ nhật hiển thị. Các mẫu có hiệu ứng bổ sung hoặc định dạng phức tạp hơn cũng đòi hỏi các thiết lập này được xử lý.

## **Thay đổi Văn bản trong Placeholder**

Các placeholder tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và văn bản thường hỗ trợ văn bản. Kiểm tra xem có phải là [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) trước khi sử dụng phương thức [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) của nó.

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

Mẫu này tránh việc ép kiểu các placeholder hình ảnh, biểu đồ, bảng hoặc media sang [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Nó cũng xác định placeholder dựa trên mục đích thay vì dựa vào chỉ số hình dạng dễ gãy.

## **Đặt Văn bản Nhắc Nhở trên Layout**

Văn bản nhắc nhở là hướng dẫn thời gian thiết kế hiển thị trong một placeholder trống, chẳng hạn *Click to add title*. Đặt văn bản nhắc nhở tùy chỉnh trên placeholder của layout thay vì cố gắng truy cập nó thông qua bộ sưu tập hình dạng của slide thường. Truy cập layout qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) và duyệt qua bộ sưu tập trả về bởi [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

Ví dụ dưới đây thay đổi các nhắc nhở tiêu đề và phụ đề trên layout được sử dụng bởi slide đầu tiên:

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

Văn bản nhắc nhở không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, nhắc nhở sẽ không còn hiển thị. Thay đổi nhắc nhở cũng không thay thế văn bản hiện có trên các slide sử dụng layout đó.

## **Cập nhật Placeholder Hình ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), thay thế hình ảnh thông qua [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) và [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Nếu nó vẫn là một placeholder trống, thêm một khung hình ảnh tại tọa độ của placeholder bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) và xóa placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình chiếu:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

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

Việc thay thế được tạo cho một placeholder trống là một khung hình ảnh cục bộ, không phải một placeholder mới, vì [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) không cung cấp setter. Nó giữ vị trí đã dự trữ nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc giữ mối quan hệ placeholder là quan trọng, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt hình ảnh, cắt và các hiệu ứng đặc thù khác, xem [Manage Picture Frames](/slides/vi/androidjava/picture-frame/). Các thao tác đó thuộc về khung hình ảnh hoặc màu nền hình ảnh, không phải metadata của placeholder.

## **Làm việc với Placeholder Biểu đồ và Nội dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). Ví dụ này tìm biểu đồ như vậy bằng cả loại placeholder và giao diện thời gian chạy, thay đổi tiêu đề và lưu file:

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

Một placeholder nội dung chung thường có [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). Trong PowerPoint nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi đã được điền, kiểm tra giao diện hình dạng thực tế để biết nó chứa gì. Các layout chuyên biệt cũng có thể hiển thị [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), hoặc [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides không chuyển một placeholder [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) trống thành một [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) chỉ bằng cách thay đổi [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); loại không thể thay đổi qua giao diện. Để điền một biểu đồ hoặc khu vực nội dung trống theo chương trình, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó xóa placeholder trống. Ví dụ sau làm điều đó cho một biểu đồ:

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

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm vùng của placeholder nhưng không kế thừa từ placeholder layout. Sử dụng các bài viết quản lý biểu đồ chuyên biệt [chart management articles](/slides/vi/androidjava/powerpoint-charts/) khi bạn cần thay thế các danh mục, chuỗi hoặc dữ liệu workbook của nó.

## **Ví dụ hoàn chỉnh: Cập nhật Nội dung Văn bản hoặc Hình ảnh**

Ví dụ toàn diện dưới đây mở một mẫu, tìm kiếm slide đầu tiên cho một placeholder tiêu đề hoặc hình ảnh, kiểm tra các loại placeholder và hình dạng, cập nhật nội dung phù hợp, và lưu kết quả. Ví dụ cố ý tránh giả định chỉ số hình dạng hoặc ép kiểu mọi placeholder sang cùng một giao diện.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

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

Placeholder cơ sở là hình dạng tương ứng trên layout hoặc master mà một placeholder khác kế thừa. Sử dụng [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) để lấy nó. Một hình dạng thường cục bộ trả về `null` vì nó không thuộc hệ thống phân cấp placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa một placeholder layout không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản nhắc nhở thông qua một layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide thông thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, duyệt qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm sao quản lý các placeholder ngày, số slide, header và footer?**

Sử dụng các trình quản lý header và footer tại phạm vi slide, layout, master, notes hoặc handout thích hợp. Xem [Manage Presentation Header and Footer](/slides/vi/androidjava/presentation-header-and-footer/) để có các ví dụ đầy đủ.