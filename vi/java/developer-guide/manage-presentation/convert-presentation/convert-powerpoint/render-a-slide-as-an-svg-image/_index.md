---
title: Xuất các slide trình chiếu dưới dạng hình ảnh SVG trong Java
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- trình chiếu
- Java
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong Java và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện với Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình truy cập và xử lý tự động. Aspose.Slides xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) khi SVG xuất ra cần gọn nhẹ, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), chọn một slide và ghi nó vào luồng bằng [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Ví dụ sau xuất mỗi slide trong một bản trình chiếu thành một tệp SVG riêng.

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

Tên tệp sử dụng [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) xác định liệu phép quay khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) thành `true` khi văn bản phải được render mà không có ligature.

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

Khi xuất slide sang SVG, bạn có thể kiểm soát việc văn bản giữ nguyên dạng văn bản hay được chuyển thành đồ họa vector, và cách các phông chữ ngoài được bao gồm hoặc tham chiếu. Các tùy chọn dưới đây giúp bạn cân bằng giữa tính nhất quán về hình ảnh, việc chọn văn bản và phụ thuộc phông chữ trong SVG đã xuất.

### **Vector hoá toàn bộ Văn bản**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hay tìm kiếm dưới dạng văn bản SVG.

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

### **Chọn cách Xử lý Phông chữ Ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn `AddLinksToFontFiles` để tham chiếu đến các tệp phông chữ riêng biệt, `Embed` để bao gồm dữ liệu phông chữ trong SVG, hoặc `Vectorize` để render chỉ văn bản sử dụng phông chữ ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

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

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) để giảm độ phân giải của hình ảnh nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) để bỏ qua các khu vực đã cắt nguồn, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là độ trung thực hoặc dữ liệu hình ảnh được giữ lại.

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

## **Kiểm soát Độ phân giải Raster hoá Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) thiết lập giới hạn độ phân giải thấp nhất cho việc raster hoá metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một hình ảnh EMF hoặc WMF được raster hoá. Nó không định nghĩa DPI toàn cục cho SVG hoặc buộc mọi đối tượng trên slide trở thành hình ảnh raster.

Tải xuống [metafile-rasterization.pptx](metafile-rasterization.pptx), tệp chứa hình ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên của nó ở ba độ phân giải raster hoá khác nhau thông qua [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Tất cả các cài đặt xuất khác giữ nguyên để có thể so sánh kết quả.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

Trong kết quả, EMF đã chuyển thành một PNG nhúng trong mỗi SVG. Các đo lường sau dành cho bản trình chiếu được cung cấp; chúng không phải là công thức chung để chuyển đổi DPI sang kích thước pixel.

| DPI raster hoá Metafile | Kích thước PNG nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây hiển thị cùng một vùng raster nhúng ở kích thước hiển thị phóng to giống nhau. Các đường chéo cho thấy hiện tượng pixel hoá rõ ràng ở 72 DPI và các cạnh mượt hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng kích thước. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hoặc thay đổi mọi hình ảnh đã xuất.

![Chi tiết đường chéo phóng to ở 72, 150 và 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) điều khiển việc giảm độ phân giải hình ảnh và có thể che giấu tác động của việc thay đổi độ phân giải raster hoá metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) điều khiển chất lượng mã hoá JPEG, không phải độ phân giải raster hoá metafile.

## **Gán ID Ổn định cho Hình dạng và Văn bản**

Sử dụng [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) để đặt [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) cho mỗi hình dạng SVG. Để đặt giá trị [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) trên các phần tử `tspan` của văn bản, triển khai [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Gán bất kỳ controller nào bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Controller dưới đây sử dụng [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), giá trị này ổn định trong suốt vòng đời của hình dạng, và một bộ đếm có thể lặp lại cho các đoạn văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình chiếu không thay đổi.

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

## **Thêm Bộ xử lý Sự kiện SVG**

Trong một [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), gọi [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) với giá trị [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) để thêm bộ xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán controller bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

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

Trang chủ có thể định nghĩa hàm JavaScript được tham chiếu bởi bộ xử lý. Gán ID và bộ xử lý sự kiện cho phép trình xem slide, cải thiện khả năng truy cập và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) khi tất cả văn bản phải không phụ thuộc vào phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) khi chỉ những văn bản sử dụng phông chữ ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm cho SVG nhỏ hơn là gì?**

Bắt đầu bằng việc nén các hình ảnh nhúng, xóa các khu vực hình ảnh đã cắt và chọn các tệp phông chữ được liên kết khi môi trường đích có thể cung cấp chúng. Kiểm thử kết quả vì độ phân giải hình ảnh thấp hơn, chất lượng JPEG thấp hơn và văn bản vector hoá mỗi yếu tố đều có sự đánh đổi giữa chất lượng và kích thước.

**Tôi có thể chỉnh sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một controller định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.