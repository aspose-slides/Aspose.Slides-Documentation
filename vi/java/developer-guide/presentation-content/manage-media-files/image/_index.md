---
title: "Tối ưu hóa Quản lý Hình ảnh trong Bài trình chiếu bằng Java"
linktitle: "Quản lý Hình ảnh"
type: docs
weight: 10
url: /vi/java/image/
keywords:
- "thêm hình ảnh"
- "thêm ảnh"
- "thêm bitmap"
- "thay thế hình ảnh"
- "thay thế ảnh"
- "từ web"
- "nền"
- "thêm PNG"
- "thêm JPG"
- "thêm SVG"
- "tài nguyên SVG bên ngoài"
- "trình giải quyết SVG"
- "hình ảnh SVG được liên kết"
- "phông chữ SVG"
- "thêm EMF"
- "thêm WMF"
- "thêm TIFF"
- "PowerPoint"
- "OpenDocument"
- "bài trình chiếu"
- "Java"
- "Aspose.Slides"
description: "Tối ưu hóa quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho Java, nâng cao hiệu suất và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bản trình bày trở nên sinh động và hấp dẫn hơn về mặt trực quan. Trong Microsoft PowerPoint, bạn có thể chèn ảnh vào các slide từ tệp, internet hoặc các nguồn khác. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trình chiếu theo nhiều cách.

{{% alert  title="Tip" color="info" %}} 
Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—giúp bạn nhanh chóng tạo bản trình bày từ hình ảnh. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Nếu bạn muốn thêm ảnh dưới dạng khung hình—đặc biệt nếu bạn dự định thay đổi kích thước, áp dụng hiệu ứng hoặc sử dụng các tùy chọn định dạng tiêu chuẩn khác—xem [Picture Frame](/slides/vi/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Bạn có thể chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Xem các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/vi/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/vi/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/vi/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/vi/java/conversion/png-to-svg/), và [SVG to PNG](https://products.aspose.com/slides/vi/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides hỗ trợ hình ảnh ở các định dạng phổ biến như JPEG, PNG, BMP, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Được Lưu Trên Máy Tính Vào Các Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh được lưu trên máy tính vào một slide trình chiếu. Đoạn mã mẫu Java sau cho thấy cách thêm hình ảnh vào slide:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Thêm Hình Ảnh Từ Web Vào Các Slide**

Nếu hình ảnh bạn muốn thêm vào slide không được lưu trên máy tính, bạn có thể thêm trực tiếp từ web. 

Đoạn mã mẫu Java sau cho thấy cách thêm hình ảnh từ web vào slide:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master lưu trữ và kiểm soát thông tin như chủ đề và bố cục cho các slide sử dụng nó. Khi bạn thêm hình ảnh vào slide master, hình ảnh sẽ xuất hiện trên mọi slide dựa trên master đó. 

Đoạn mã mẫu Java sau cho thấy cách thêm hình ảnh vào slide master:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Thêm Hình Ảnh Là Nền Cho Slide**

Bạn có thể sử dụng một hình ảnh làm nền cho một hoặc nhiều slide. Để biết chi tiết, xem *[Setting Images as Backgrounds for Slides](/slides/vi/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bản Trình Chiếu**

Nội dung SVG có thể được thêm vào bản trình chiếu bằng lớp [SvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgimage/). Đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/) tạo ra sau đó có thể được thêm vào bộ sưu tập hình ảnh của bản trình chiếu và dùng để tạo khung hình.

Đoạn mã Java sau nhập một chuỗi SVG tự chứa. Tất cả hình ảnh, kiểu dáng và các tài nguyên khác được sử dụng bởi SVG này đều được nhúng trực tiếp trong nội dung SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nhập Nội Dung SVG Với Các Tài Nguyên Bên Ngoài**

Các tệp SVG xuất ra từ công cụ thiết kế, trình chỉnh sửa sơ đồ, hệ thống biểu tượng và quy trình web có thể tham chiếu tới các tài nguyên được lưu ngoài tài liệu SVG. Ví dụ, một SVG có thể chứa liên kết hình ảnh như `images/photo.png`, giá trị CSS `url(...)` hoặc URL phông chữ.

Để nhập nội dung SVG như vậy, tạo một triển khai [IExternalResourceResolver](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iexternalresourceresolver/) và truyền nó, cùng với URI cơ sở, vào một trình khởi tạo [SvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgimage/) thích hợp. URI cơ sở xác định vị trí của tài liệu SVG và được dùng để giải quyết các liên kết tương đối.

Giao diện [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/) cung cấp quyền truy cập thông tin về SVG đã nhập:

- `getSvgContent()` trả về mã SVG dưới dạng chuỗi.
- `getSvgData()` trả về nội dung SVG dưới dạng mảng byte.
- `getBaseUri()` trả về URI cơ sở dùng cho các liên kết tương đối.
- `getExternalResourceResolver()` trả về bộ giải quyết được gán cho hình ảnh SVG.

### **Triển Khai Bộ Giải Quyết Tài Nguyên Bên Ngoài**

Bộ giải quyết có hai phương thức:

- `resolveUri` kết hợp URI cơ sở và liên kết tài nguyên tương đối và trả về URI tuyệt đối. Trả về `null` khi không thể giải quyết liên kết hoặc không được phép.
- `getEntity` trả về luồng đọc được cho một URI tài nguyên tuyệt đối. Trả về `null` khi tài nguyên bị thiếu, bị chặn hoặc không khả dụng. Luồng dự phòng cũng có thể được trả về khi thích hợp.

Bộ giải quyết sau chỉ tải các tài nguyên liên kết từ một thư mục cục bộ được cho phép. Các tài nguyên mạng và đường dẫn ngoài thư mục cho phép sẽ bị chặn. Một hình ảnh dự phòng tùy chọn sẽ được trả về cho các liên kết hình ảnh không giải quyết được.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Trình giải quyết này cố ý chỉ cho phép các tệp tin cục bộ.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Chỉ sử dụng hình dự phòng cho các tài nguyên hình ảnh. Trả về một luồng hình ảnh
            // cho phông chữ hoặc stylesheet bị thiếu sẽ không hợp lệ.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Giải Quyết Tài Nguyên Liên Kết Khi Nhập SVG**

Giả sử `assets/diagram.svg` chứa một tham chiếu tương đối như:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Đoạn ví dụ Java sau truyền URI tệp SVG làm URI cơ sở và cung cấp một bộ giải quyết tùy chỉnh. Bộ giải quyết chuyển đổi liên kết hình ảnh tương đối thành URI tuyệt đối và trả về một luồng chứa tài nguyên liên kết trong khi Aspose.Slides xử lý SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// URI cơ sở đại diện cho vị trí của tài liệu SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lớp `SvgImage` cũng cung cấp các overload chấp nhận dữ liệu SVG dưới dạng mảng byte hoặc luồng nhập, cùng với một bộ giải quyết tài nguyên bên ngoài và một URI cơ sở.

{{% alert title="Important" color="warning" %}}
Bộ giải quyết tài nguyên làm cho các tài nguyên bên ngoài khả dụng trong khi Aspose.Slides xử lý và render SVG. Nó không chỉnh sửa mã SVG gốc hay tự động nhúng các tài nguyên đã giải quyết vào SVG.
Khi một `ISvgImage` được thêm vào bộ sưu tập hình ảnh của bản trình chiếu, tệp PPTX có thể chứa cả đại diện SVG gốc và một hình raster dự phòng. Một tài nguyên được liên kết có thể xuất hiện trong hình dự phòng được tạo ra trong khi một liên kết tương đối như `images/photo.png` vẫn giữ nguyên trong SVG đã lưu. Do đó, một ứng dụng render đại diện SVG gốc có thể bỏ qua nội dung liên kết khi tài nguyên bên ngoài gốc không khả dụng.
{{% /alert %}}

### **Tạo Một Hình Ảnh SVG Di Động**

Để tạo một hình ảnh SVG không phụ thuộc vào các tệp bên ngoài, hãy làm cho SVG tự chứa trước khi tạo `SvgImage`. Ví dụ, thay thế các URL hình ảnh liên kết bằng URI `data:` chứa dữ liệu hình ảnh:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Sau khi tất cả các tài nguyên cần thiết đã được nhúng vào nội dung SVG, tạo `SvgImage`, thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu và chèn nó vào khung hình như trong ví dụ trước.

### **Xử Lý Tài Nguyên Thiếu Hoặc Bị Chặn**

Trả về `null` từ `resolveUri` khi URI tài nguyên không hợp lệ, bị cấm hoặc không thể giải quyết. Trả về `null` từ `getEntity` khi tài nguyên không thể đọc được. Aspose.Slides sẽ tiếp tục xử lý SVG mà không có tài nguyên đó khi có thể.

Một luồng dự phòng có thể được trả về cho tài nguyên thiếu, nhưng nội dung của nó phải tương thích với loại tài nguyên được yêu cầu. Ví dụ, chỉ trả về luồng hình ảnh cho một hình ảnh bị thiếu, không phải cho phông chữ hoặc stylesheet.

{{% alert title="Security" color="warning" %}}
Không giải quyết các đường dẫn tệp tùy ý hoặc URL mạng không giới hạn từ các tệp SVG không tin cậy. Hạn chế các scheme, thư mục và host được phép. Đối với tài nguyên mạng, cũng áp dụng thời gian chờ kết nối, giới hạn kích thước phản hồi và xác thực nội dung.
{{% /alert %}}

## **Chuyển Đổi SVG Thành Tập Hình Dạng**

Aspose.Slides có thể chuyển đổi một SVG thành tập hợp các hình dạng, tương tự chức năng tương ứng trong PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một overload của phương thức [addGroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) của giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection) nhận đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISvgImage) làm tham số đầu tiên.

Đoạn mã mẫu Java sau cho thấy cách sử dụng phương thức này để chuyển đổi tệp SVG thành tập hợp các hình dạng:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Tên tệp SVG nguồn.
String svgFileName = "sample.svg";

// Tên tệp đầu ra của bản trình chiếu.
String outPptxPath = "presentation.pptx";

// Tạo một bản trình chiếu mới.
IPresentation presentation = new Presentation();
try {
    // Đọc nội dung tệp SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Tạo đối tượng SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Lấy kích thước slide.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Chuyển đổi hình ảnh SVG thành một nhóm các hình dạng và thu phóng nó theo kích thước slide.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Lưu bản trình chiếu ở định dạng PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**

Aspose.Slides for Java cho phép bạn tạo hình ảnh EMF từ các bảng tính Excel bằng Aspose.Cells và thêm chúng vào các slide trình chiếu.

Đoạn mã mẫu Java sau cho thấy cách thực hiện:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Lưu workbook vào một luồng.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Thêm tệp nguyên dạng để hình ảnh giữ dạng vector EMF thay vì bị raster hoá.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của bản trình chiếu, bao gồm cả hình ảnh được các hình dạng slide sử dụng. Phần này mô tả một số cách cập nhật hình ảnh trong bộ sưu tập. Bạn có thể thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải tệp bản trình chiếu chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
1. Tải một hình ảnh mới từ tệp vào một mảng byte.
1. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.
1. Trong cách thứ hai, tải hình ảnh vào đối tượng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.
1. Trong cách thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bản trình chiếu.
1. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Khởi tạo lớp Presentation đại diện cho một tệp trình chiếu.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Cách thứ nhất.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Cách thứ hai.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Cách thứ ba.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Lưu trình chiếu vào tệp.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Với trình chuyển đổi miễn phí [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose, bạn có thể dễ dàng tạo hoạt ảnh từ văn bản và tạo GIF từ văn bản. 
{{% /alert %}}

## **FAQ**

**Độ phân giải gốc của hình ảnh có được giữ nguyên sau khi chèn không?**

Có. Các pixel nguồn được giữ lại, nhưng ngoại hình cuối cùng phụ thuộc vào cách [picture](/slides/vi/java/picture-frame/) được thu phóng trên slide và bất kỳ nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide một lúc là gì?**

Đặt logo trên master slide hoặc layout và thay thế nó trong bộ sưu tập hình ảnh của bản trình chiếu—các cập nhật sẽ lan tới mọi yếu tố sử dụng tài nguyên đó.

**SVG đã chèn có thể được chuyển đổi thành các hình dạng có thể chỉnh sửa không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó các phần riêng lẻ có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.

**Làm sao để đặt một hình ảnh làm nền cho nhiều slide cùng lúc?**

Gán hình ảnh làm nền [link](/slides/vi/java/presentation-background/) trên master slide hoặc layout liên quan—bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.

**Làm sao để ngăn bản trình chiếu trở nên quá lớn vì có quá nhiều hình ảnh?**

Tái sử dụng một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các đồ họa lặp lại trên master khi thích hợp.