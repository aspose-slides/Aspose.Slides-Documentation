---
title: "Tối ưu hóa Quản lý Hình ảnh trong Bài thuyết trình bằng JavaScript"
linktitle: "Quản lý Hình ảnh"
type: docs
weight: 10
url: /vi/nodejs-java/image/
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
- "bộ giải quyết SVG"
- "hình ảnh SVG liên kết"
- "phông chữ SVG"
- "thêm EMF"
- "thêm WMF"
- "thêm TIFF"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Tối ưu hóa việc quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides for Node.js via Java, nâng cao hiệu suất và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bài thuyết trình sinh động và hấp dẫn hơn. Trong Microsoft PowerPoint, bạn có thể chèn ảnh vào các slide từ tệp, internet hoặc các nguồn khác. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trình chiếu theo nhiều cách.

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các trình chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—giúp bạn nhanh chóng tạo bài thuyết trình từ hình ảnh. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Nếu bạn muốn thêm một hình ảnh dưới dạng khung ảnh—đặc biệt nếu bạn dự định thay đổi kích thước, áp dụng hiệu ứng hoặc sử dụng các tùy chọn định dạng tiêu chuẩn khác—hãy xem [Picture Frame](/slides/vi/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Bạn có thể chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Xem các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/vi/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/vi/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/vi/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/vi/nodejs-java/conversion/png-to-svg/), và [SVG to PNG](https://products.aspose.com/slides/vi/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides hỗ trợ các định dạng hình ảnh phổ biến như JPEG, PNG, BMP, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Được Lưu Trên Máy Tính Vào Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh được lưu trên máy tính vào một slide trình chiếu. Mã mẫu JavaScript dưới đây cho thấy cách thêm hình ảnh vào slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Thêm Hình Ảnh Từ Web Vào Slide**

Nếu hình ảnh bạn muốn thêm vào slide không được lưu trên máy tính, bạn có thể thêm trực tiếp từ web. 

Mã mẫu JavaScript dưới đây cho thấy cách thêm hình ảnh từ web vào slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master lưu trữ và kiểm soát thông tin như chủ đề và bố cục cho các slide sử dụng nó. Khi bạn thêm hình ảnh vào slide master, hình ảnh sẽ xuất hiện trên mọi slide dựa trên master đó. 

Mã mẫu JavaScript dưới đây cho thấy cách thêm hình ảnh vào slide master:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Thêm Hình Ảnh Là Nền Slide**

Bạn có thể sử dụng một bức ảnh làm nền cho một hoặc nhiều slide. Để biết chi tiết, xem *[Setting Images as Backgrounds for Slides](/slides/vi/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bài Thuyết Trình**

Nội dung SVG có thể được thêm vào bài thuyết trình bằng lớp [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/). Đối tượng hình ảnh SVG tạo ra sau đó có thể được thêm vào bộ sưu tập hình ảnh của bài thuyết trình và dùng để tạo khung ảnh.

Mã mẫu JavaScript dưới đây nhập một chuỗi SVG tự chứa. Tất cả các hình ảnh, kiểu dáng và tài nguyên khác được SVG này sử dụng đều được nhúng trực tiếp trong nội dung SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nhập Nội Dung SVG Với Tài Nguyên Bên Ngoài**

Các tệp SVG được xuất từ công cụ thiết kế, trình chỉnh sửa sơ đồ, hệ thống biểu tượng và quy trình xử lý web có thể tham chiếu đến các tài nguyên được lưu bên ngoài tài liệu SVG. Ví dụ, một SVG có thể chứa liên kết hình ảnh như `images/photo.png`, một giá trị CSS `url(...)` hoặc một URL phông chữ.

Để nhập nội dung SVG như vậy, cung cấp một bộ giải quyết tài nguyên bên ngoài và truyền nó, cùng với URI cơ sở, vào một hàm khởi tạo [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/) thích hợp. URI cơ sở xác định vị trí của tài liệu SVG và được dùng để giải quyết các liên kết tương đối.

Lớp `SvgImage` cung cấp truy cập tới thông tin về SVG đã nhập:

- `getSvgContent()` trả về mã SVG dưới dạng chuỗi.
- `getSvgData()` trả về nội dung SVG dưới dạng mảng byte.
- `getBaseUri()` trả về URI cơ sở được dùng cho các liên kết tương đối.
- `getExternalResourceResolver()` trả về bộ giải quyết đã gán cho hình ảnh SVG.

### **Triển khai Bộ giải quyết tài nguyên bên ngoài**

Bộ giải quyết có hai phương thức:

- `resolveUri` kết hợp URI cơ sở và một liên kết tài nguyên tương đối và trả về một URI tuyệt đối. Trả về `null` khi không thể giải quyết liên kết hoặc không được phép.
- `getEntity` trả về một luồng Java đọc được cho một URI tài nguyên tuyệt đối. Trả về `null` khi tài nguyên bị thiếu, bị chặn hoặc không khả dụng. Một luồng dự phòng cũng có thể được trả về khi thích hợp.

Trợ giúp dưới đây tạo một bộ giải quyết chỉ tải các tài nguyên liên kết từ một thư mục cục bộ được phép. Các tài nguyên mạng và các đường dẫn ngoài thư mục cho phép sẽ bị chặn. Một ảnh dự phòng tùy chọn sẽ được trả về cho các liên kết ảnh không thể giải quyết.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Bộ giải quyết này cố ý chỉ cho phép các tệp cục bộ.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Chỉ sử dụng ảnh dự phòng cho các tài nguyên hình ảnh. Trả về luồng ảnh
                // cho phông chữ hoặc stylesheet bị thiếu sẽ không hợp lệ.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Giải Quyết Tài Nguyên Liên Kết Khi Nhập SVG**

Giả sử rằng `assets/diagram.svg` chứa một tham chiếu tương đối như:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Mã JavaScript dưới đây truyền URI của tệp SVG làm URI cơ sở và cung cấp một bộ giải quyết tùy chỉnh. Bộ giải quyết chuyển liên kết ảnh tương đối thành URI tuyệt đối và trả về một luồng chứa tài nguyên liên kết trong khi Aspose.Slides xử lý SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// URI cơ sở đại diện cho vị trí của tài liệu SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lớp `SvgImage` cũng cung cấp các overload cho phép nhận dữ liệu SVG dưới dạng mảng byte, cũng như các phương thức khởi tạo dựa trên luồng, kèm theo bộ giải quyết tài nguyên bên ngoài và URI cơ sở.

{{% alert title="Important" color="warning" %}}

Bộ giải quyết tài nguyên làm cho các tài nguyên bên ngoài khả dụng trong khi Aspose.Slides xử lý và render SVG. Nó không thay đổi mã SVG gốc hoặc tự động nhúng các tài nguyên đã giải quyết vào trong đó.

Khi một hình ảnh SVG được thêm vào bộ sưu tập hình ảnh của bài thuyết trình, tệp PPTX có thể chứa cả biểu diễn SVG gốc và một ảnh raster dự phòng. Một tài nguyên được liên kết có thể xuất hiện trong ảnh dự phòng được tạo ra trong khi một liên kết tương đối như `images/photo.png` vẫn giữ nguyên trong SVG đã lưu. Do đó, một ứng dụng render biểu diễn SVG gốc có thể bỏ qua nội dung liên kết khi tài nguyên bên ngoài gốc không khả dụng.

{{% /alert %}}

### **Tạo Ảnh SVG Di động**

Để tạo một ảnh SVG không phụ thuộc vào các tệp bên ngoài, hãy làm cho SVG tự chứa trước khi tạo `SvgImage`. Ví dụ, thay thế các URL hình ảnh liên kết bằng các URI `data:` chứa dữ liệu hình ảnh:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Sau khi nhúng tất cả các tài nguyên cần thiết vào nội dung SVG, tạo `SvgImage`, thêm nó vào bộ sưu tập hình ảnh của bài thuyết trình và chèn vào khung ảnh như trong ví dụ trước.

### **Xử Lý Tài Nguyên Thiếu Hoặc Bị Chặn**

Trả về `null` từ `resolveUri` khi URI tài nguyên không hợp lệ, bị cấm hoặc không thể giải quyết. Trả về `null` từ `getEntity` khi không thể đọc tài nguyên. Aspose.Slides sẽ tiếp tục xử lý SVG mà không có tài nguyên đó khi có thể.

Một luồng dự phòng có thể được trả về cho tài nguyên bị thiếu, nhưng nội dung của nó phải tương thích với loại tài nguyên được yêu cầu. Ví dụ, chỉ trả về luồng ảnh cho ảnh bị thiếu, không phải cho phông chữ hay stylesheet.

{{% alert title="Security" color="warning" %}}

Không giải quyết các đường dẫn tệp tùy ý hoặc URL mạng không giới hạn từ các tệp SVG không đáng tin cậy. Hạn chế các scheme, thư mục và host được phép. Đối với tài nguyên mạng, cũng áp dụng thời gian chờ kết nối, giới hạn kích thước phản hồi và xác thực nội dung.

{{% /alert %}}

## **Chuyển Đổi SVG Thành Tập Hình Dạng**

Aspose.Slides có thể chuyển đổi một SVG thành một tập hợp các hình dạng, tương tự chức năng tương ứng trong PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một overload của phương thức [addGroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) của lớp [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection) nhận đối tượng hình ảnh SVG làm đối số đầu tiên.

Mã mẫu JavaScript dưới đây cho thấy cách sử dụng phương thức này để chuyển đổi tệp SVG thành một tập hợp các hình dạng:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Tên tệp SVG nguồn.
const svgFileName = "sample.svg";

// Tên tệp bài thuyết trình đầu ra.
const outPptxPath = "presentation.pptx";

// Tạo một bài thuyết trình mới.
const presentation = new aspose.slides.Presentation();
try {
    // Đọc nội dung tệp SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Tạo đối tượng SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Lấy kích thước slide.
    const slideSize = presentation.getSlideSize().getSize();

    // Chuyển đổi ảnh SVG thành một nhóm hình dạng và co giãn theo kích thước slide.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Lưu bài thuyết trình ở định dạng PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**

Aspose.Slides for Node.js via Java cho phép bạn tạo các hình ảnh EMF từ các bảng tính Excel bằng Aspose.Cells và thêm chúng vào các slide trình chiếu.

Mã mẫu JavaScript dưới đây cho thấy cách thực hiện:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Lưu workbook vào một luồng.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Thêm tệp nguyên vẹn để hình ảnh vẫn là EMF vector thay vì bị raster hoá.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của bài thuyết trình, bao gồm cả các hình ảnh được các hình dạng slide sử dụng. Phần này mô tả một số cách cập nhật hình ảnh trong bộ sưu tập. Bạn có thể thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải tệp bài thuyết trình chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Tải một hình ảnh mới từ tệp vào một mảng byte.
1. Thay thế hình ảnh mục tiêu bằng hình ảnh mới bằng mảng byte.
1. Trong cách thứ hai, tải hình ảnh vào đối tượng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.
1. Trong cách thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bài thuyết trình.
1. Ghi lại bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Cách thứ nhất.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Cách thứ hai.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Cách thứ ba.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Lưu bài thuyết trình ra tệp.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Với trình chuyển đổi miễn phí [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose, bạn có thể dễ dàng tạo hoạt ảnh chữ và tạo GIF từ văn bản. 

{{% /alert %}}

## **FAQ**

**Độ phân giải gốc của hình ảnh có được giữ nguyên sau khi chèn không?**

Có. Các pixel nguồn được bảo toàn, nhưng ngoại hình cuối cùng phụ thuộc vào cách mà [picture](/slides/vi/nodejs-java/picture-frame/) được thu phóng trên slide và bất kỳ việc nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide một lúc là gì?**

Đặt logo trên slide master hoặc layout và thay thế nó trong bộ sưu tập hình ảnh của bài thuyết trình—các cập nhật sẽ lan tới tất cả các thành phần sử dụng tài nguyên đó.

**Có thể chuyển một SVG đã chèn thành các hình dạng có thể chỉnh sửa không?**

Có. Bạn có thể chuyển SVG thành một nhóm các hình dạng, sau đó các phần riêng lẻ trở nên có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.

**Làm sao để đặt một ảnh làm nền cho nhiều slide cùng lúc?**

[Chỉ định hình ảnh làm nền](/slides/vi/nodejs-java/presentation-background/) trên slide master hoặc layout liên quan—bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.

**Làm thế nào để ngăn một bài thuyết trình trở nên quá lớn vì quá nhiều hình ảnh?**

Tái sử dụng một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu và giữ các đồ họa lặp lại trên master khi thích hợp.