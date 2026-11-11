---
title: Kết xuất slide bản trình chiếu thành ảnh SVG trên Android
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- bản trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Xuất các slide PowerPoint thành ảnh SVG trên Android và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện với Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng ảnh dựa trên XML có khả năng mở rộng, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình truy cập, và xử lý hậu kỳ tự động. Aspose.Slides for Android thông qua Java xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) khi SVG xuất ra phải gọn nhẹ, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc sử dụng tương tác.

## **Xuất slide thành SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), chọn một slide và ghi nó vào một luồng với [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Ví dụ sau xuất mỗi slide trong một bản trình bày thành một tệp SVG riêng.

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

Tên tệp sử dụng [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) thay vì chỉ mục vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) bao gồm khung văn bản trong vùng render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) xác định liệu góc quay của khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) thành `true` khi văn bản phải được render mà không có ligature.

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

## **Kiểm soát cắt đầu dòng tại đầu mũi tên**

SVG 1.1 không có cài đặt chèn marker để chỉ định nơi một đường nên dừng lại dưới đầu mũi tên. Theo mặc định, Aspose.Slides rút ngắn đường xuất ra để nét vẽ không vượt qua marker. Gọi [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) với `true` để vẽ nét vẽ tới cuối điểm ban đầu của đường. Cài đặt này chỉ ảnh hưởng đến đầu ra SVG. Đường vẫn giữ vị trí và độ dài trên slide.

Ví dụ vẽ đầu mũi tên hình tam giác và hình kim cương trên các đường có độ rộng 2 và 10 điểm. Nó xuất cùng một slide hai lần, chỉ thay đổi tùy chọn cắt.

```java
import com.aspose.slides.*;
import android.graphics.Color;
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
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

So sánh cho thấy đầu mũi tên tam giác trên đường 10 điểm. Khi bật cắt, ngọn mũi nhọn. Khi tắt cắt, nét vẽ vượt qua các mặt nghiêng của marker và để lại đầu phẳng.

![Tam giác 10 điểm được phóng to với đầu nhọn khi bật cắt và đầu phẳng khi tắt cắt](line-end-cropping.png)

Trong các đường khác của ví dụ, nét vẽ vượt ra ít nhìn thấy hơn trên tam giác 2 điểm. Hình kim cương đã được tô đầy bao phủ đầu nét vẽ ở cả hai độ rộng.

## **Kiểm soát văn bản và phông chữ**

Khi xuất slide sang SVG, bạn có thể kiểm soát liệu văn bản vẫn giữ dạng văn bản hay được chuyển sang đồ họa vector, và cách các phông chữ bên ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng tính nhất quán hình ảnh, khả năng chọn văn bản và phụ thuộc phông chữ trong SVG đã xuất.

### **Vector hoá toàn bộ văn bản**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hay tìm kiếm được dưới dạng văn bản SVG.

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

### **Chọn cách xử lý phông chữ bên ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) để tham chiếu các tệp phông chữ riêng biệt, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) để bao gồm dữ liệu phông chữ trong SVG, hoặc [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) để render chỉ những văn bản sử dụng phông chữ bên ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

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

## **Giảm kích thước hình ảnh nhúng**

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) để giảm độ phân giải của hình ảnh nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) để bỏ qua các khu vực ảnh đã cắt, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là độ trung thực của hình ảnh hoặc dữ liệu hình ảnh được giữ lại.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) đặt giới hạn độ phân giải thấp hơn cho việc raster hoá metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một ảnh EMF hoặc WMF được raster hoá. Nó không định nghĩa DPI toàn cục cho SVG hoặc buộc mọi đối tượng trên slide trở thành ảnh raster.

Tải về [metafile-rasterization.pptx](metafile-rasterization.pptx), chứa một ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên ở ba độ phân giải raster hoá thông qua [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Tất cả các cài đặt xuất khác giữ nguyên để có thể so sánh kết quả.

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

Trong output, EMF trở thành một PNG nhúng trong mỗi SVG. Các đo lường sau dành cho bản trình bày được cung cấp; chúng không phải là công thức chung để chuyển DPI thành kích thước pixel.

| DPI raster hóa Metafile | Kích thước PNG nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây cho thấy cùng một khu vực raster đã nhúng ở cùng kích thước hiển thị phóng đại. Các đường chéo hiển thị điểm ảnh rõ rệt ở 72 DPI và cạnh mượt hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng lớn. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hay thay đổi mọi ảnh đã xuất.

![Chi tiết đường chéo được phóng to ở 72, 150 và 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) kiểm soát việc giảm độ phân giải hình ảnh và có thể che giấu ảnh hưởng của việc thay đổi độ phân giải raster hoá metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) kiểm soát chất lượng mã hoá JPEG, không phải độ phân giải raster hoá metafile.

## **Gán ID ổn định cho các hình dạng và văn bản**

Sử dụng [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) để đặt [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) cho mỗi hình dạng SVG. Để đặt giá trị [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) cho các phần tử `tspan` văn bản, triển khai [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Gán bất kỳ controller nào với [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Controller sau sử dụng [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), ổn định trong suốt vòng đời của hình dạng, và một bộ đếm có thể lặp lại cho các đoạn văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình bày không thay đổi.

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

## **Thêm trình xử lý sự kiện SVG**

Trong một [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), gọi [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) với một giá trị [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán controller với [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

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

Trang chủ có thể định nghĩa hàm JavaScript được trình xử lý tham chiếu. Gán ID và trình xử lý sự kiện cho phép các trình xem slide, cải thiện khả năng truy cập và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) khi toàn bộ văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) khi chỉ những văn bản sử dụng phông chữ bên ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm cho SVG nhỏ hơn là gì?**

Bắt đầu bằng cách nén các hình ảnh nhúng, xóa các vùng ảnh đã cắt, và chọn các tệp phông chữ liên kết khi môi trường đích có thể phục vụ chúng. Kiểm tra kết quả vì độ phân giải hình ảnh thấp hơn, chất lượng JPEG thấp hơn và văn bản vector hoá mỗi yếu tố đều có sự đánh đổi về chất lượng và kích thước.

**Tôi có thể sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một controller định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.