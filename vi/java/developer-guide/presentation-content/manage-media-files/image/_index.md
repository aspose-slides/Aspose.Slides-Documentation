---
title: Tối ưu hóa quản lý hình ảnh trong bản trình chiếu bằng Java
linktitle: Quản lý Hình ảnh
type: docs
weight: 10
url: /vi/java/image/
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
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, tái sử dụng, liên kết, thay thế và quản lý hình ảnh raster và SVG trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Java."
---
## **Giới thiệu**

Aspose.Slides for Java cung cấp nhiều cách để làm việc với hình ảnh, và mỗi cách phục vụ một mục đích khác nhau. Bạn có thể lưu trữ một hình ảnh trong bản trình chiếu, hiển thị nó trong khung ảnh, sử dụng nó làm nền slide, liên kết tới một hình ảnh bên ngoài, thay thế một tài nguyên hình ảnh chia sẻ, hoặc chuyển nội dung SVG thành các hình dạng có thể chỉnh sửa.

Bài viết này tập trung vào các tài nguyên hình ảnh và cách chúng được sử dụng trong toàn bộ bản trình chiếu. Đối với việc cắt, độ trong suốt, hiệu ứng, kéo dãn và các định dạng khác được áp dụng cho một khung ảnh riêng lẻ, xem [Picture Frame](/slides/vi/java/picture-frame/).

## **Hiểu mô hình hình ảnh**

Những khái niệm API sau liên quan chặt chẽ nhưng không thay thế cho nhau:

- Bộ sưu tập hình ảnh của bản trình chiếu ([presentation image collection](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iimagecollection/)) lưu trữ các tài nguyên hình ảnh được bản trình chiếu sử dụng. Sử dụng [ImageCollection.addImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.imagecollection/) để thêm dữ liệu hình ảnh và nhận một tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/).
- Một [picture frame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ipictureframe/) là một hình dạng hiển thị hình ảnh trên một slide, bố cục hoặc master. Sử dụng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ishapecollection/) để đặt tài nguyên hình ảnh lên slide.
- Nền slide sử dụng hình ảnh như một phần của việc tô nền slide thay vì như một hình dạng. Do đó nó không hoạt động giống như một picture frame.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) thay thế một tài nguyên hình ảnh. Nếu nhiều thành phần trong bản trình chiếu sử dụng tài nguyên đó, chúng đều sẽ sử dụng hình ảnh thay thế.
- Chuyển đổi một SVG thành các hình dạng tạo ra các hình dạng slide có thể chỉnh sửa. Sau khi chuyển đổi, nội dung không còn được quản lý như một tài nguyên hình ảnh duy nhất.

Do đó quy trình điển hình là: thêm dữ liệu hình ảnh vào bộ sưu tập hình ảnh, nhận một [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/), và sau đó sử dụng tài nguyên đó trong một hoặc nhiều picture frame hoặc fill.

## **Thêm hình ảnh nhúng**

Để chèn một hình ảnh cục bộ, tải tệp lên, thêm nó vào bộ sưu tập hình ảnh và tạo một picture frame sử dụng `IPPImage` trả về.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình ảnh được thêm theo cách này sẽ được nhúng vào bản trình chiếu, vì vậy tệp kết quả không phụ thuộc vào việc tệp hình ảnh gốc còn tồn tại hay không.

### **Thêm hình ảnh từ Web**

Khi một hình ảnh có sẵn qua HTTP hoặc HTTPS, tải xuống các byte của nó, thêm chúng vào bộ sưu tập hình ảnh của bản trình chiếu, và sử dụng tài nguyên hình ảnh trả về tương tự như hình ảnh cục bộ.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong các ứng dụng chạy lâu, hãy tái sử dụng một client HTTP hoặc chiến lược quản lý kết nối phù hợp thay vì tạo liên tục cơ sở hạ tầng mạng không cần thiết. Ngoài ra, hãy xác thực URL từ xa, kích thước phản hồi và kiểu nội dung khi nguồn không được tin cậy.

## **Tái sử dụng hình ảnh trên các slide**

Nếu cùng một hình ảnh cần được sử dụng nhiều lần, hãy thêm nó vào bản trình chiếu một lần và tái sử dụng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) khi tạo các picture frame bổ sung. Điều này tránh việc liên tục tải cùng một dữ liệu nguồn và làm cho mối quan hệ giữa tài nguyên hình ảnh chia sẻ và các lần sử dụng của nó trở nên rõ ràng.

Đối với các đồ họa nên xuất hiện tự động trên nhiều slide, chẳng hạn như logo công ty, hãy cân nhắc đặt picture frame trên một [slide master](/slides/vi/java/slide-master/) hoặc layout thay vì thêm một hình dạng tương đương vào mỗi slide.

## **Sử dụng hình ảnh làm nền slide**

Một hình ảnh nền được gán cho phần tô nền slide; nó không được thêm như một hình dạng picture-frame. Điều này hữu ích khi hình ảnh nên bao phủ toàn bộ nền slide và không nên được thao tác như một đối tượng slide thông thường.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các tùy chọn nền bổ sung, bao gồm nền master và layout, xem [Presentation Background](/slides/vi/java/presentation-background/).

## **Hình ảnh nhúng và hình ảnh liên kết**

Hình ảnh nhúng và hình ảnh liên kết có các cân bằng khác nhau về khả năng di động và kích thước tệp:

- **Embedded image:** dữ liệu hình ảnh được lưu trữ bên trong bản trình chiếu. Bản trình chiếu là độc lập, nhưng kích thước tệp bao gồm dữ liệu hình ảnh.
- **Linked image:** bản trình chiếu lưu trữ một đường dẫn hoặc URL tới một hình ảnh bên ngoài. Điều này có thể giảm kích thước bản trình chiếu, nhưng tài nguyên bên ngoài phải vẫn có thể truy cập khi bản trình chiếu được mở hoặc render.

Một picture liên kết có thể được tạo bằng cách gán đường dẫn hoặc URL bên ngoài thông qua [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/vi/java/com.aspose.slides.islidespicture/) , thay vì nhúng dữ liệu hình ảnh.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chỉ sử dụng hình ảnh liên kết khi môi trường triển khai có thể tin cậy truy cập tài nguyên bên ngoài. Đối với các bản trình chiếu phải hoạt động offline hoặc di chuyển giữa các hệ thống, hình ảnh nhúng thường an toàn hơn.

## **Làm việc với hình ảnh SVG**

SVG là định dạng vector, vì vậy nó hữu ích cho biểu tượng, sơ đồ và các đồ họa khác cần phóng to mà không mất chi tiết như hình ảnh raster. Aspose.Slides hỗ trợ SVG cả như một tài nguyên hình ảnh và như nguồn cho các hình dạng slide có thể chỉnh sửa.

### **Thêm SVG dưới dạng hình ảnh**

Tạo một [SvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.svgimage/), thêm nó vào bộ sưu tập hình ảnh, và đặt tài nguyên hình ảnh kết quả vào một picture frame.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Tệp SVG với tài nguyên bên ngoài**

Một SVG có thể tham chiếu tới các hình ảnh, stylesheet hoặc phông chữ bên ngoài. Đối với các trường hợp này, [SvgImage] cung cấp các constructor nhận một [IExternalResourceResolver](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iexternalresourceresolver/) và một base URI. Bộ giải quyết có thể ánh xạ một URI tương đối tới một URI tuyệt đối được phép và trả về một stream cho tài nguyên được yêu cầu.

Bộ giải quyết làm cho các tài nguyên bên ngoài khả dụng trong quá trình Aspose.Slides xử lý SVG, nhưng nó không ghi lại lại SVG thành một tài liệu độc lập. Nếu SVG cần giữ tính di động, hãy nhúng các tài nguyên cần thiết vào chính SVG, ví dụ bằng cách sử dụng URI `data:` cho các hình ảnh liên kết.

Khi các tệp SVG đến từ nguồn không tin cậy, hạn chế các scheme, vị trí tệp và host mà bộ giải quyết có thể truy cập. Các resolver mạng cũng nên áp dụng timeout, giới hạn kích thước phản hồi và xác thực nội dung.

### **Chuyển đổi SVG thành các hình dạng có thể chỉnh sửa**

Aspose.Slides có thể chuyển đổi một SVG thành một nhóm các hình dạng slide có thể chỉnh sửa, tương tự như lệnh tương ứng trong PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Sử dụng overload [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ishapecollection/) nhận một [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.isvgimage/) để thực hiện chuyển đổi.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sử dụng chuyển đổi SVG-to-shapes khi các phần tử vector riêng lẻ cần được chỉnh sửa dưới dạng các hình dạng PowerPoint. Nếu SVG chỉ cần hiển thị, giữ nó dưới dạng hình ảnh sẽ đơn giản hơn và tránh tạo ra nhiều hình dạng riêng biệt.

## **Thay thế tài nguyên hình ảnh hiện có**

Sử dụng [IPPImage.replaceImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) khi bạn muốn thay thế một tài nguyên hình ảnh hiện có. Điều này đặc biệt hữu ích cho các đồ họa chia sẻ như logo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu nhiều picture frame, nền, master hoặc layout sử dụng cùng một tài nguyên hình ảnh, việc thay thế tài nguyên đó sẽ cập nhật tất cả các lần sử dụng. Nếu chỉ một picture frame cần thay đổi, hãy gán một hình ảnh khác cho khung đó thay vì thay thế tài nguyên chia sẻ.

`replaceImage` cũng cung cấp các overload chấp nhận một mảng byte hoặc một [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) khác.

## **Hướng dẫn thực tiễn quản lý hình ảnh**

### **Kiểm soát kích thước bản trình chiếu**

Các hình raster lớn có thể làm cho bản trình chiếu trở nên quá lớn. Sử dụng hình ảnh nguồn có kích thước phù hợp với kích thước hiển thị mong muốn, tái sử dụng các tài nguyên hình ảnh chung khi có thể và tránh nhúng các bản sao lặp lại của cùng một đồ họa độ phân giải cao.

Đối với các hình raster đã được đặt trong picture frame, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ipicturefillformat/) có thể giảm dữ liệu hình ảnh theo độ phân giải và cài đặt cắt đã chọn. Đây là xử lý picture-frame chứ không phải quản lý image-collection, vì vậy xem [Picture Frame](/slides/vi/java/picture-frame/) để biết các thao tác định dạng liên quan.

### **Chọn giữa nội dung nhúng và liên kết**

Nhúng làm cho bản trình chiếu có thể di động vì tất cả dữ liệu hình ảnh cần thiết đi kèm với tệp. Liên kết có thể giảm kích thước tệp, nhưng nó tạo ra một phụ thuộc bên ngoài. Chỉ sử dụng liên kết khi phụ thuộc đó chấp nhận được và ổn định.

### **Tái sử dụng thương hiệu chung**

Đối với các logo, watermark hoặc đồ họa trang trí lặp lại, sử dụng một tài nguyên hình ảnh và tái sử dụng nó. Nếu đồ họa thuộc về thiết kế bản trình chiếu hơn là nội dung slide, hãy đặt nó trên master hoặc layout để các slide thích hợp kế thừa.

### **Giữ tài nguyên SVG di động**

Một SVG độc lập dễ dàng di chuyển và render một cách nhất quán hơn so với SVG phụ thuộc vào tệp hoặc tài nguyên mạng bên ngoài. Khi có thể, hãy nhúng các tài nguyên cần thiết trước khi nhập SVG. Chuyển đổi SVG thành các hình dạng chỉ khi các phần tử vector riêng lẻ cần được chỉnh sửa.

### **Sử dụng API hình ảnh hiện đại đa nền tảng**

Đối với mã Java mới, hãy sử dụng các API Aspose.Slides [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iimage/) và [Images](https://reference.aspose.com/slides/vi/java/com.aspose.slides.images/) thay vì API công cộng lỗi thời dựa trên `java.awt.image.BufferedImage`. Xem [Modern API](/slides/vi/java/modern-api/) để biết hướng dẫn di chuyển.

WMF và EMF cần xem xét đặc biệt. Khi các định dạng này được truyền qua một [IImage], [ImageCollection.addImage] chuyển đổi metafile thành đại diện PNG raster trước khi chèn. Nếu việc bảo tồn dữ liệu metafile quan trọng, hãy sử dụng overload dựa trên stream của [ImageCollection.addImage] thay thế. Tạo nội dung EMF từ bảng tính hoặc các sản phẩm khác là một quy trình tích hợp riêng và nằm ngoài phạm vi của bài viết này.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa bộ sưu tập hình ảnh và picture frame là gì?**

Bộ sưu tập hình ảnh lưu trữ các tài nguyên hình ảnh có thể tái sử dụng. Picture frame là một hình dạng slide hiển thị một trong các tài nguyên đó và cung cấp các định dạng đặc thù cho hình ảnh như cắt và hiệu ứng.

**Cách tốt nhất để thay thế cùng một logo ở mọi nơi là gì?**

Nếu logo đã được chia sẻ dưới dạng một tài nguyên hình ảnh, hãy thay thế tài nguyên đó bằng [IPPImage.replaceImage]. Đối với thương hiệu toàn bộ bản trình chiếu, việc đặt logo trên master hoặc layout cũng có thể giảm nội dung slide trùng lặp.

**Tại sao một hình ảnh liên kết lại biến mất trên máy tính khác?**

Một picture liên kết phụ thuộc vào tệp hoặc URL bên ngoài. Nếu tài nguyên đó không thể truy cập được từ máy tính khác, hình ảnh liên kết có thể không có. Nhúng hình ảnh khi bản trình chiếu phải tự chứa.

**Có thể chỉnh sửa SVG được chèn dưới dạng các hình dạng PowerPoint không?**

Có. Chuyển đổi SVG bằng [IShapeCollection.addGroupShape]; nhóm kết quả chứa các hình dạng slide có thể chỉnh sửa thay vì một picture SVG.

**Làm sao để giữ các bản trình chiếu có nhiều hình ảnh luôn nhỏ gọn?**

Tái sử dụng các tài nguyên hình ảnh chung, tránh các nguồn raster không cần thiết quá lớn, nén các hình raster phù hợp khi cần, giữ các thương hiệu lặp lại trên master hoặc layout, và chỉ sử dụng hình ảnh liên kết khi phụ thuộc bên ngoài được chấp nhận.