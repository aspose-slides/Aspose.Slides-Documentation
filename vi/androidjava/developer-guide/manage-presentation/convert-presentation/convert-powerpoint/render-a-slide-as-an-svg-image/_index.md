---
title: "Hiển thị các slide bản trình bày dưới dạng ảnh SVG trên Android"
linktitle: "Slide sang SVG"
type: docs
weight: 50
url: /vi/androidjava/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint sang SVG"
- "bản trình bày sang SVG"
- "slide sang SVG"
- "PPT sang SVG"
- "PPTX sang SVG"
- "các tùy chọn xuất SVG"
- "SVG tương tác"
- "PowerPoint"
- "bản trình bày"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Xuất các slide PowerPoint dưới dạng ảnh SVG trên Android và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện bằng Aspose.Slides."
---
## **Tổng quan**

SVG là một định dạng ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình truy cập, và xử lý hậu kỳ tự động. Aspose.Slides cho Android thông qua Java xuất mỗi slide ra một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/) khi SVG xuất ra cần gọn nhẹ, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), chọn một slide, và ghi nó vào một luồng bằng [ISlide.writeAsSvg](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Ví dụ sau xuất mỗi slide trong một bản trình bày ra một tệp SVG riêng.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Tên tệp sử dụng [ISlide.getSlideNumber](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getSlideNumber--) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [IShape.writeAsSvg](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình Đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/) điều khiển việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) xác định liệu phép quay khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) thành `true` khi văn bản phải được render mà không có ligature.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Kiểm soát Văn bản và Phông chữ**

### **Biểu diễn Văn bản Dạng Vector**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể được chọn hoặc tìm kiếm dưới dạng văn bản SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Chọn Cách Xử lý Phông chữ Ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgexternalfontshandling/) để tham chiếu các tệp phông chữ riêng biệt, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgexternalfontshandling/) để đưa dữ liệu phông chữ vào trong SVG, hoặc [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgexternalfontshandling/) để render chỉ văn bản sử dụng phông chữ bên ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Giảm Kích thước Hình ảnh Nhúng**

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) để giảm độ phân giải của các hình ảnh nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) để bỏ qua các khu vực nguồn đã cắt, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là độ trung thực hoặc dữ liệu hình ảnh được giữ lại.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Gán ID Ổn định cho Hình dạng và Văn bản**

Sử dụng [ISvgShapeFormattingController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) để đặt [ISvgShape.setId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) cho mỗi hình dạng SVG. Để đặt giá trị [ISvgTSpan.setId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) trên các phần tử `tspan` văn bản, hãy triển khai [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Gán bất kỳ bộ điều khiển nào bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Bộ điều khiển sau sử dụng [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), giá trị này ổn định trong suốt vòng đời của hình dạng, và một bộ đếm lặp lại cho các span văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình bày không thay đổi.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Thêm Trình xử lý Sự kiện SVG**

Trong một [ISvgShapeFormattingController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), gọi [ISvgShape.setEventHandler](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) với một giá trị [SvgEvent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán bộ điều khiển bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

Trang chủ có thể định nghĩa hàm JavaScript được trình xử lý tham chiếu. Việc gán ID và trình xử lý sự kiện cho phép các trình xem slide, cải thiện khả năng truy cập và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ bên ngoài cần được chuyển đổi thành đồ họa.

**Cách tốt nhất để làm cho SVG nhỏ hơn là gì?**

Bắt đầu bằng việc nén các hình ảnh nhúng, xóa các khu vực ảnh đã cắt, và chọn các tệp phông chữ liên kết khi môi trường đích có thể cung cấp chúng. Kiểm tra kết quả vì giảm độ phân giải hình ảnh, giảm chất lượng JPEG và văn bản vector hóa đều có các đánh đổi khác nhau về chất lượng và kích thước.

**Tôi có thể chỉnh sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một bộ điều khiển định dạng, sau đó chọn các phần tử SVG phù hợp trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.