---
title: Tối ưu quản lý hình ảnh trong bản trình chiếu bằng JavaScript
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/nodejs-java/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thay thế hình ảnh
- bộ sưu tập hình ảnh
- khung ảnh
- hình ảnh liên kết
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- SVG thành hình dạng
- tài nguyên SVG bên ngoài
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thêm, tái sử dụng, liên kết, thay thế và quản lý các hình ảnh raster và SVG trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java."
---
## **Giới thiệu**

Aspose.Slides for Node.js via Java cung cấp một số cách để làm việc với hình ảnh, và mỗi cách phục vụ một mục đích khác nhau. Bạn có thể lưu trữ một hình ảnh trong bản trình chiếu, hiển thị nó trong khung ảnh, sử dụng nó làm nền slide, liên kết tới một hình ảnh bên ngoài, thay thế một tài nguyên hình ảnh chia sẻ, hoặc chuyển đổi nội dung SVG thành các hình dạng có thể chỉnh sửa.

Bài viết này tập trung vào tài nguyên hình ảnh và cách chúng được sử dụng trong một bản trình chiếu. Đối với việc cắt, trong suốt, hiệu ứng, kéo dài và các định dạng khác được áp dụng cho một khung ảnh riêng lẻ, xem [Picture Frame](/slides/vi/nodejs-java/picture-frame/).

## **Hiểu mô hình hình ảnh**

Các khái niệm API sau đây có liên quan chặt chẽ nhưng không thể thay thế cho nhau:

- Bộ sưu tập hình ảnh của bản trình chiếu ([presentation image collection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/)) lưu trữ các tài nguyên hình ảnh được sử dụng bởi bản trình chiếu. Sử dụng [ImageCollection.addImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/) để thêm dữ liệu hình ảnh và nhận một tài nguyên [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/).
- Một [picture frame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) là một hình dạng hiển thị hình ảnh trên slide, layout hoặc master. Sử dụng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/) để đặt tài nguyên hình ảnh lên slide.
- Nền slide sử dụng hình ảnh như một phần của việc tô đầy slide thay vì là một hình dạng. Do đó nó không hành xử như một khung ảnh.
- [PPImage.replaceImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) thay thế một tài nguyên hình ảnh. Nếu nhiều thành phần trong bản trình chiếu sử dụng tài nguyên đó, tất cả chúng sẽ dùng tài nguyên thay thế.
- Chuyển đổi SVG thành các hình dạng tạo ra các hình dạng slide có thể chỉnh sửa. Sau khi chuyển đổi, nội dung không còn được quản lý như một tài nguyên hình ảnh duy nhất.

Một quy trình công việc điển hình do đó: thêm dữ liệu hình ảnh vào bộ sưu tập hình ảnh, nhận một [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/), và sau đó sử dụng tài nguyên đó trong một hoặc nhiều khung ảnh hoặc vùng tô.

## **Thêm hình ảnh nhúng**

Để chèn một hình ảnh cục bộ, tải tệp, thêm nó vào bộ sưu tập hình ảnh và tạo một khung ảnh sử dụng tài nguyên [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) đã trả về.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình ảnh được thêm theo cách này được nhúng trong bản trình chiếu, vì vậy tệp kết quả không phụ thuộc vào việc tệp hình ảnh gốc còn tồn tại hay không.

### **Thêm hình ảnh từ Web**

Khi một hình ảnh khả dụng qua HTTP hoặc HTTPS, tải byte của nó, thêm chúng vào bộ sưu tập hình ảnh của bản trình chiếu và sử dụng tài nguyên hình ảnh đã trả về theo cùng cách như hình ảnh cục bộ.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

Trong các ứng dụng chạy lâu dài, hãy tái sử dụng một client HTTP hoặc chiến lược quản lý kết nối phù hợp với ứng dụng thay vì liên tục tạo ra cơ sở hạ tầng mạng không cần thiết. Ngoài ra, hãy xác thực URL từ xa, kích thước phản hồi và kiểu nội dung khi nguồn không đáng tin cậy.

## **Tái sử dụng hình ảnh trên nhiều slide**

Nếu cùng một hình ảnh cần được dùng nhiều lần, hãy thêm nó vào bản trình chiếu một lần và tái sử dụng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) đã trả về khi tạo các khung ảnh bổ sung. Điều này tránh việc tải lại cùng dữ liệu nguồn và làm cho mối quan hệ giữa tài nguyên hình ảnh chia sẻ và các lần sử dụng của nó trở nên rõ ràng.

Đối với các đồ họa nên xuất hiện tự động trên nhiều slide, chẳng hạn như logo công ty, hãy xem xét đặt khung ảnh trên một [slide master](/slides/vi/nodejs-java/slide-master/) hoặc layout thay vì thêm một hình dạng tương đương vào mỗi slide.

## **Sử dụng hình ảnh làm nền slide**

Một hình nền được gán cho vùng tô đầy slide; nó không được thêm như một hình dạng khung ảnh. Điều này hữu ích khi hình ảnh cần bao phủ toàn bộ nền slide và không nên được thao tác như một đối tượng slide thông thường.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các tùy chọn nền bổ sung, bao gồm nền master và layout, xem [Presentation Background](/slides/vi/nodejs-java/presentation-background/).

## **Hình ảnh nhúng và hình ảnh liên kết**

Hình ảnh nhúng và hình ảnh liên kết có các cân bằng khác nhau về tính di động và kích thước tệp:

- **Hình ảnh nhúng:** dữ liệu hình ảnh được lưu trong bản trình chiếu. Bản trình chiếu tự chứa, nhưng kích thước tệp bao gồm cả dữ liệu hình ảnh.
- **Hình ảnh liên kết:** bản trình chiếu lưu trữ một đường dẫn hoặc URL tới hình ảnh bên ngoài. Điều này có thể giảm kích thước bản trình chiếu, nhưng tài nguyên bên ngoài phải luôn khả dụng khi bản trình chiếu được mở hoặc render.

Một hình ảnh liên kết có thể được tạo bằng cách gán đường dẫn hoặc URL bên ngoài thông qua [Picture.setLinkPathLong](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/) thay vì nhúng dữ liệu hình ảnh.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chỉ sử dụng hình ảnh liên kết khi môi trường triển khai có thể tin cậy truy cập tài nguyên bên ngoài. Đối với các bản trình chiếu phải hoạt động offline hoặc được chuyển giữa các hệ thống, hình ảnh nhúng thường an toàn hơn.

## **Làm việc với hình ảnh SVG**

SVG là định dạng vector, vì vậy nó hữu ích cho biểu tượng, sơ đồ và các đồ họa khác cần phóng to mà không mất chi tiết như hình ảnh raster. Aspose.Slides hỗ trợ SVG cả dưới dạng tài nguyên hình ảnh và là nguồn cho các hình dạng slide có thể chỉnh sửa.

### **Thêm SVG dưới dạng hình ảnh**

Tạo một [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/), thêm nó vào bộ sưu tập hình ảnh và đặt tài nguyên hình ảnh kết quả vào một khung ảnh.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Tập tin SVG với tài nguyên bên ngoài**

Một SVG có thể tham chiếu đến các hình ảnh, stylesheet hoặc font bên ngoài. Đối với các trường hợp này, [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/) cung cấp các constructor chấp nhận một [ExternalResourceResolver](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/externalresourceresolver/) và một URI cơ sở. Resolver có thể ánh xạ một URI tương đối sang một URI tuyệt đối được phép và trả về một stream cho tài nguyên được yêu cầu.

Resolver làm cho các tài nguyên bên ngoài khả dụng trong khi Aspose.Slides xử lý SVG, nhưng nó không ghi lại lại SVG thành một tài liệu tự chứa. Nếu SVG cần vẫn di động, hãy nhúng các tài nguyên cần thiết vào chính SVG, ví dụ bằng cách sử dụng URI `data:` cho các hình ảnh liên kết.

Khi các tệp SVG đến từ nguồn không đáng tin cậy, hãy hạn chế các scheme, vị trí tệp và máy chủ mà resolver có thể truy cập. Resolver mạng cũng nên áp dụng thời gian chờ, giới hạn kích thước phản hồi và kiểm tra nội dung.

### **Chuyển đổi SVG thành các hình dạng có thể chỉnh sửa**

Aspose.Slides có thể chuyển đổi một SVG thành một nhóm các hình dạng slide có thể chỉnh sửa, tương tự lệnh tương đương trong PowerPoint.

![Menu bật lên PowerPoint](img_01_01.png)

Sử dụng phương thức overload của [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/) chấp nhận hình ảnh SVG để thực hiện chuyển đổi.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sử dụng chuyển đổi SVG‑to‑shapes khi các phần tử vector riêng lẻ cần được chỉnh sửa dưới dạng các hình dạng PowerPoint. Nếu SVG chỉ cần hiển thị, giữ nó dưới dạng hình ảnh sẽ đơn giản hơn và tránh tạo ra nhiều hình dạng riêng biệt.

## **Thay thế tài nguyên hình ảnh hiện có**

Sử dụng [PPImage.replaceImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) khi bạn muốn thay thế một tài nguyên hình ảnh hiện có. Điều này đặc biệt hữu ích cho các đồ họa chia sẻ như logo.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu nhiều khung ảnh, nền, master hoặc layout sử dụng cùng một tài nguyên hình ảnh, việc thay thế tài nguyên đó sẽ cập nhật tất cả các lần sử dụng. Nếu chỉ một khung ảnh cần thay đổi, hãy gán một hình ảnh khác cho khung đó thay vì thay thế tài nguyên chia sẻ.

[PPImage.replaceImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) cũng cung cấp các overload chấp nhận một mảng byte hoặc một [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) khác.

## **Hướng dẫn thực tế về quản lý hình ảnh**

### **Kiểm soát kích thước bản trình chiếu**

Hình ảnh raster lớn có thể làm cho bản trình chiếu trở nên không cần thiết lớn. Sử dụng hình ảnh nguồn có kích thước phù hợp với kích thước hiển thị dự kiến, tái sử dụng các tài nguyên hình ảnh chia sẻ khi có thể và tránh nhúng các bản sao lặp lại của cùng một đồ họa độ phân giải cao.

Đối với các hình ảnh raster đã được đặt trong khung ảnh, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) có thể giảm dữ liệu hình ảnh theo độ phân giải và cài đặt cắt đã chọn. Đây là xử lý khung ảnh chứ không phải quản lý bộ sưu tập hình ảnh, vì vậy hãy xem [Picture Frame](/slides/vi/nodejs-java/picture-frame/) để biết các thao tác định dạng liên quan.

### **Chọn giữa nội dung nhúng và liên kết**

Nhúng làm cho bản trình chiếu di động vì tất cả dữ liệu hình ảnh cần thiết đi cùng tệp. Liên kết có thể giảm kích thước tệp, nhưng nó tạo ra một phụ thuộc bên ngoài. Chỉ sử dụng liên kết khi phụ thuộc đó chấp nhận được và ổn định.

### **Tái sử dụng thương hiệu chung**

Đối với các logo, watermark hoặc đồ họa trang trí được lặp lại, hãy sử dụng một tài nguyên hình ảnh và tái sử dụng nó. Nếu đồ họa thuộc về thiết kế bản trình chiếu hơn là nội dung slide, hãy đặt nó trên một master hoặc layout để nó được kế thừa bởi các slide thích hợp.

### **Giữ tài nguyên SVG di động**

Một SVG tự chứa dễ di chuyển và render nhất quán hơn so với một SVG phụ thuộc vào các tệp hoặc tài nguyên mạng bên ngoài. Khi có thể, hãy nhúng các tài nguyên cần thiết trước khi nhập SVG. Chuyển đổi SVG thành các hình dạng chỉ nên thực hiện khi các phần tử vector riêng lẻ cần được chỉnh sửa.

### **Sử dụng API hình ảnh đa nền tảng hiện đại**

Đối với mã Node.js via Java mới, hãy sử dụng các API Aspose.Slides [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) và [Images](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/images/) thay vì API công cộng kế thừa dựa trên `java.awt.image.BufferedImage`. Xem [Modern API](/slides/vi/nodejs-java/modern-api/) để biết hướng dẫn di chuyển.

WMF và EMF cần xem xét đặc biệt. Khi các định dạng này được truyền qua một [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/) chuyển đổi metafile thành một đại diện PNG raster trước khi chèn. Nếu việc giữ nguyên dữ liệu metafile là quan trọng, hãy sử dụng overload dựa trên stream của [ImageCollection.addImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/) thay thế. Tạo nội dung EMF từ bảng tính hoặc các sản phẩm khác là một quy trình tích hợp riêng và nằm ngoài phạm vi của bài viết này.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa bộ sưu tập hình ảnh và một khung ảnh là gì?**

Bộ sưu tập hình ảnh lưu trữ các tài nguyên hình ảnh có thể tái sử dụng. Một khung ảnh là một hình dạng slide hiển thị một trong các tài nguyên đó và cung cấp các định dạng đặc thù cho hình ảnh như cắt và hiệu ứng.

**Cách tốt nhất để thay thế cùng một logo ở khắp mọi nơi là gì?**

Nếu logo đã được chia sẻ dưới dạng một tài nguyên hình ảnh, hãy thay thế tài nguyên đó bằng [PPImage.replaceImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/). Đối với việc xây dựng thương hiệu trên toàn bộ bản trình chiếu, việc đặt logo trên một master hoặc layout cũng có thể giảm nội dung slide trùng lắp.

**Tại sao một hình ảnh liên kết lại biến mất trên máy tính khác?**

Một hình ảnh liên kết phụ thuộc vào tệp hoặc URL bên ngoài. Nếu tài nguyên đó không thể truy cập được từ máy tính khác, hình ảnh liên kết sẽ không có sẵn. Hãy nhúng hình ảnh khi bản trình chiếu phải tự chứa.

**Có thể chỉnh sửa một SVG đã chèn thành các hình dạng PowerPoint không?**

Có. Chuyển đổi SVG bằng [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/); nhóm kết quả chứa các hình dạng slide có thể chỉnh sửa thay vì một hình ảnh SVG duy nhất.

**Làm sao để giữ các bản trình chiếu có nhiều hình ảnh có kích thước nhỏ hơn?**

Tái sử dụng các tài nguyên hình ảnh chia sẻ, tránh sử dụng các nguồn raster không cần thiết lớn, nén các hình raster phù hợp khi cần, giữ các thương hiệu lặp lại trên master hoặc layout, và chỉ sử dụng hình ảnh liên kết khi phụ thuộc bên ngoài là chấp nhận được.