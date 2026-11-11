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
- các tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- trình chiếu
- Java
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong Java và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện bằng Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình hỗ trợ truy cập, và xử lý hậu kỳ tự động. Aspose.Slides xuất từng slide ra một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) khi SVG xuất ra cần gọn gàng, nhất quán trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất một Slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), chọn một slide và ghi nó vào stream bằng [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Ví dụ sau xuất mọi slide trong một bản trình bày dưới dạng tệp SVG riêng.

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

Tên tệp sử dụng [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) khi một trình xem slide hoặc trang web chỉ cần hình dạng đó.

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

## **Kiểm soát cắt đầu dòng ở đầu mũi tên**

SVG 1.1 không có thiết lập marker inset để chỉ định nơi một đường nên dừng lại dưới đầu mũi tên. Mặc định, Aspose.Slides rút ngắn đường xuất ra để nét vẽ không vượt ra ngoài marker. Gọi [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) với `true` để vẽ nét vẽ tới điểm cuối gốc của đường. Cài đặt này chỉ ảnh hưởng đến đầu ra SVG. Đường vẫn giữ vị trí và độ dài trên slide.

Ví dụ vẽ các đầu mũi tên hình tam giác và hình thoi trên các đường có độ rộng 2 và 10 điểm. Nó xuất cùng một slide hai lần, chỉ thay đổi tùy chọn cắt.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

So sánh cho thấy đầu mũi tên tam giác trên đường 10 điểm. Khi bật cắt, đầu mũi tên sắc nhọn. Khi tắt cắt, nét vẽ vượt ra khỏi các mặt chéo của marker và để lại một đầu phẳng.

![Tam giác 10‑điểm được phóng to với đầu nhọn khi bật cắt và đầu phẳng khi tắt cắt](line-end-cropping.png)

Trong các đường khác của ví dụ, nét vẽ vượt ra ít đáng chú ý hơn ở tam giác 2 điểm. Hình thoi đã được tô đầy bao phủ đầu nét ở cả hai độ rộng.

## **Kiểm soát Văn bản và Phông chữ**

Khi xuất slide sang SVG, bạn có thể kiểm soát việc văn bản giữ lại dưới dạng văn bản hay được chuyển thành đồ họa vector, và cách các phông chữ bên ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng tính nhất quán về hình ảnh, khả năng chọn văn bản và phụ thuộc vào phông chữ trong SVG đã xuất.

### **Vector hóa toàn bộ văn bản**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) thành `true` để ghi mọi văn bản trên slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hoặc tìm kiếm dưới dạng văn bản SVG.

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

### **Chọn cách xử lý Phông chữ bên ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải bên ngoài. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để bao gồm dữ liệu phông chữ trong SVG, hoặc `Vectorize` để render chỉ các văn bản sử dụng phông chữ bên ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng.

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

## **Giảm kích thước hình ảnh được nhúng**

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) để giảm độ phân giải của hình ảnh được nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) để bỏ qua các khu vực đã cắt của nguồn ảnh, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với cái giá là giảm độ trung thực hình ảnh hoặc dữ liệu hình ảnh được giữ lại.

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

## **Kiểm soát độ phân giải raster hóa Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) thiết lập ngưỡng độ phân giải thấp nhất cho việc raster hóa metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một ảnh EMF hoặc WMF được raster hóa. Nó không định nghĩa DPI toàn cục cho SVG hay buộc mọi đối tượng trên slide phải trở thành ảnh raster.

Tải xuống [metafile-rasterization.pptx](metafile-rasterization.pptx), chứa một ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên của nó ở ba độ phân giải raster khác nhau qua [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Tất cả các cài đặt xuất khác giữ nguyên để có thể so sánh kết quả.

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

Trong đầu ra, EMF trở thành một PNG được nhúng trong mỗi SVG. Các đo lường sau áp dụng cho bản trình bày được cung cấp; chúng không phải là công thức chung để chuyển DPI sang kích thước pixel.

| DPI raster hóa Metafile | Kích thước PNG được nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây cho thấy cùng một vùng raster đã nhúng ở cùng kích thước hiển thị phóng to. Các đường chéo hiển thị hiện tượng pixel hoá ở 72 DPI và các cạnh mượt hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng lên. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hay thay đổi mọi hình ảnh đã xuất.

![Chi tiết đường chéo được phóng to ở 72, 150 và 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) kiểm soát việc giảm độ phân giải ảnh và có thể làm mờ hiệu ứng của việc thay đổi độ phân giải raster hóa metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) kiểm soát chất lượng mã hoá JPEG, không phải độ phân giải raster hóa metafile.

## **Gán ID ổn định cho Hình dạng và Văn bản**

Sử dụng [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) để đặt [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) cho mỗi hình dạng SVG. Để đặt giá trị [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) trên các phần tử `tspan` của văn bản, triển khai [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Gán một trong các controller này bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Controller dưới đây sử dụng [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) – một giá trị ổn định trong suốt vòng đời của hình dạng – và một bộ đếm có thể lặp lại cho các span văn bản. Điều này khiến các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình bày không thay đổi.

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

Trong một [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), gọi [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) với một giá trị [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) để thêm trình xử lý JavaScript vào một hình dạng đã xuất. Gán controller bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

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

Trang chủ có thể định nghĩa hàm JavaScript mà trình xử lý tham chiếu. Gán ID và trình xử lý sự kiện cho phép các trình xem slide, tính năng hỗ trợ truy cập, và các quy trình SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) khi mọi văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ bên ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm cho SVG nhỏ hơn là gì?**

Bắt đầu bằng cách nén hình ảnh được nhúng, xóa các khu vực ảnh đã cắt, và chọn liên kết tới tệp phông chữ khi môi trường mục tiêu có thể cung cấp chúng. Kiểm tra kết quả vì giảm độ phân giải ảnh, giảm chất lượng JPEG, và vector hóa văn bản mỗi thứ đều có các cân bằng giữa chất lượng và kích thước.

**Tôi có thể sửa đổi các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một controller định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.