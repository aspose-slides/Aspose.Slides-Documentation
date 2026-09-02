---
title: Quản lý Placeholder của Bản trình chiếu trong JavaScript
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/nodejs-java/manage-placeholder/
keywords:
- placeholder
- placeholder văn bản
- placeholder hình ảnh
- placeholder biểu đồ
- placeholder nội dung
- văn bản nhắc
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, cũng như hiểu về kế thừa placeholder với Aspose.Slides cho Node.js thông qua Java."
---
## **Tổng quan**

Một placeholder là một hình dạng giữ vị trí cho một loại nội dung cụ thể trong mẫu trình chiếu. Các ví dụ phổ biến là tiêu đề, nội dung, hình ảnh, biểu đồ và các placeholder nội dung đa mục đích. Không giống như hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các cài đặt khác từ một slide bố cục hoặc slide master.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [Shape.getPlaceholder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getPlaceholder). Phương thức trả về một đối tượng [Placeholder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholder/) hoặc `null` đối với hình dạng bình thường. Sử dụng [Placeholder.getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholder/#getType) để xác định placeholder dự định chứa gì.

Lớp hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder văn bản, hình ảnh, biểu đồ hoặc nội dung trống thường được biểu diễn bằng một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/).
- Một placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [Placeholder.getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholder/#getType) và lớp hình dạng thời gian chạy thay vì giả định rằng mọi placeholder đều là một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholder/#getType) mô tả vai trò của placeholder; nó không đảm bảo loại hình dạng thời gian chạy. Luôn luôn kiểm tra kiểu trước khi truy cập các thành viên liên quan tới văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu về kế thừa Placeholder**

Placeholder tạo thành một cây phân cấp:

1. Một slide master xác định các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức master.
2. Một slide layout xác định cách sắp xếp được một hoặc nhiều slide bình thường sử dụng và có thể kế thừa từ master.
3. Một slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ layout của nó.

Gọi [Shape.getBasePlaceholder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getBasePlaceholder) để di chuyển lên một cấp trong cây phân cấp này. Một placeholder slide thường trả về placeholder layout của nó; một placeholder layout có thể trả về placeholder master. Phương thức trả về `null` khi hình dạng không có placeholder cơ sở.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo placeholder cơ sở của chúng:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Chỉnh sửa một placeholder trên slide bình thường sẽ tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa layout hoặc master liên quan có thể ảnh hưởng tới tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng bình thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Thay đổi Văn bản trong Placeholder**

Tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và placeholder văn bản thường hỗ trợ văn bản. Kiểm tra [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) trước khi sử dụng phương thức [getTextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/#getTextFrame) của nó.

Ví dụ này cập nhật placeholder tiêu đề đầu tiên trên slide đầu và lưu kết quả:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mẫu này tránh việc xử lý các placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện như các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/). Nó cũng xác định placeholder theo mục đích thay vì dựa vào chỉ mục hình dạng dễ vỡ.

## **Đặt Văn bản Nhắc trong Layout**

Văn bản nhắc là hướng dẫn được hiển thị trong một placeholder trống ở thời điểm thiết kế, chẳng hạn như *Click to add title*. Đặt văn bản nhắc tùy chỉnh trên placeholder layout thay vì cố gắng truy cập nó qua bộ sưu tập hình dạng của slide bình thường. Truy cập layout thông qua [Slide.getLayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getLayoutSlide) và lặp qua bộ sưu tập trả về bởi [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getShapes).

Ví dụ sau thay đổi nhắc tiêu đề và phụ đề trên layout được sử dụng bởi slide đầu tiên:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Văn bản nhắc không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, nhắc sẽ không còn hiển thị. Thay đổi nhắc cũng không thay thế văn bản hiện có trên các slide sử dụng layout đó.

## **Cập nhật Placeholder Hình ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/), thay thế hình ảnh qua [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#getPicture) và [Picture.setImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/#setImage).
- Nếu nó vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) và loại bỏ placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình chiếu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Việc thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [Shape.getPlaceholder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getPlaceholder) không cung cấp setter. Nó giữ vị trí đã dự trữ nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu cần duy trì mối quan hệ placeholder, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt hình ảnh, cắt ảnh và các hiệu ứng đặc thù khác, xem [Quản lý Khung Hình](/slides/vi/nodejs-java/picture-frame/). Các thao tác này thuộc về picture frame hoặc picture fill, không phải metadata của placeholder.

## **Làm việc với Placeholder Biểu đồ và Nội dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/). Ví dụ này tìm biểu đồ như vậy bằng cả loại placeholder và lớp thời gian chạy, thay đổi tiêu đề và lưu tệp:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Một placeholder nội dung chung thường có [PlaceholderType.Object](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholdertype/#Object). Trong PowerPoint, nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi được điền, kiểm tra lớp hình dạng thực tế để biết nó chứa gì. Các layout chuyên dụng cũng có thể hiển thị [PlaceholderType.Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholdertype/#Media) hoặc [PlaceholderType.Diagram](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides không chuyển một placeholder [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) trống thành một [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/) chỉ bằng cách thay đổi [Placeholder.getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholder/#getType); kiểu không thể được thay đổi qua đối tượng. Để điền một khu vực biểu đồ hoặc nội dung trống bằng program, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó loại bỏ placeholder trống. Ví dụ sau thực hiện việc này cho một biểu đồ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm vùng của placeholder nhưng không kế thừa từ placeholder layout. Sử dụng các [bài viết quản lý biểu đồ](/slides/vi/nodejs-java/powerpoint-charts/) khi bạn cần thay thế danh mục, series hoặc dữ liệu workbook.

## **Ví dụ hoàn chỉnh: Cập nhật Văn bản hoặc Nội dung Hình ảnh**

Ví dụ end-to-end sau mở một mẫu, tìm kiếm slide đầu tiên cho placeholder tiêu đề hoặc hình ảnh, kiểm tra loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ này cố ý tránh giả định chỉ mục hình dạng hoặc xử lý mọi placeholder như cùng một lớp.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên layout hoặc master mà một placeholder khác kế thừa. Sử dụng [Shape.getBasePlaceholder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getBasePlaceholder) để lấy nó. Một hình dạng cục bộ bình thường trả về `null` vì nó không thuộc cây placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa placeholder layout không?**

Bạn có thể thay đổi định dạng hoặc văn bản nhắc được kế thừa qua layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, hãy lặp qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm thế nào để quản lý placeholder ngày, số slide, tiêu đề và chân trang?**

Sử dụng các trình quản lý tiêu đề và chân trang ở cấp slide, layout, master, notes hoặc handout phù hợp. Xem [Quản lý Tiêu đề và Chân trang Bản trình chiếu](/slides/vi/nodejs-java/presentation-header-and-footer/) để có các ví dụ hoàn chỉnh.