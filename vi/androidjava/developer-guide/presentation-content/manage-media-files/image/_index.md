---
title: Tối ưu hóa Quản lý Hình ảnh trong Bài thuyết trình trên Android
linktitle: Quản lý Hình ảnh
type: docs
weight: 10
url: /vi/androidjava/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thay thế hình ảnh
- bộ sưu tập hình ảnh
- khung hình
- hình ảnh liên kết
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- SVG thành hình dạng
- tài nguyên SVG bên ngoài
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, tái sử dụng, liên kết, thay thế và quản lý hình ảnh raster và SVG trong các bài thuyết trình PowerPoint và OpenDocument với Aspose.Slides cho Android qua Java."
---
## **Giới thiệu**

Aspose.Slides for Android via Java cung cấp một số cách làm việc với hình ảnh, và mỗi cách phục vụ một mục đích khác nhau. Bạn có thể lưu trữ một hình ảnh trong bài thuyết trình, hiển thị nó trong khung hình, sử dụng nó làm nền slide, liên kết tới một hình ảnh bên ngoài, thay thế một tài nguyên hình ảnh được chia sẻ, hoặc chuyển đổi nội dung SVG thành các hình dạng có thể chỉnh sửa.

Bài viết này tập trung vào các tài nguyên hình ảnh và cách chúng được sử dụng trong toàn bộ bài thuyết trình. Đối với việc cắt, trong suốt, hiệu ứng, kéo dài và các định dạng khác được áp dụng cho một khung hình riêng lẻ, hãy xem [Khung Hình](/slides/vi/androidjava/picture-frame/).

## **Hiểu Mô Hình Hình Ảnh**

Các khái niệm API sau đây có liên quan chặt chẽ nhưng không thể hoán đổi được:

- Bộ sưu tập hình ảnh của bài thuyết trình ([presentation image collection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagecollection/)) lưu trữ các tài nguyên hình ảnh được sử dụng bởi bài thuyết trình. Sử dụng [ImageCollection.addImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imagecollection/) để thêm dữ liệu hình ảnh và nhận một tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/).
- Một khung hình ([picture frame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/)) là một hình dạng hiển thị hình ảnh trên slide, layout hoặc master. Sử dụng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/) để đặt tài nguyên hình ảnh lên slide.
- Nền slide sử dụng hình ảnh như một phần của nền slide thay vì là một hình dạng. Do đó nó không hành xử giống như một khung hình.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) thay thế một tài nguyên hình ảnh. Nếu nhiều thành phần trong bài thuyết trình sử dụng tài nguyên đó, chúng đều sẽ sử dụng hình ảnh mới.
- Chuyển đổi SVG thành các hình dạng tạo ra các hình dạng slide có thể chỉnh sửa. Sau khi chuyển đổi, nội dung không còn được quản lý như một tài nguyên hình ảnh duy nhất.

Do đó, quy trình điển hình là: thêm dữ liệu hình ảnh vào bộ sưu tập hình ảnh, nhận một [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/), và sau đó sử dụng tài nguyên đó trong một hoặc nhiều khung hình hoặc nền.

## **Thêm Hình Ảnh Được Nhúng**

Để chèn một hình ảnh cục bộ, tải tệp, thêm nó vào bộ sưu tập hình ảnh và tạo một khung hình sử dụng `IPPImage` đã trả về.

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

Hình ảnh được thêm theo cách này sẽ được nhúng trong bài thuyết trình, vì vậy tệp kết quả không phụ thuộc vào việc tệp hình ảnh gốc còn tồn tại hay không.

### **Thêm Hình Ảnh Từ Web**

Khi một hình ảnh có sẵn qua HTTP hoặc HTTPS, tải về dữ liệu byte của nó, thêm chúng vào bộ sưu tập hình ảnh của bài thuyết trình, và sử dụng tài nguyên hình ảnh đã trả về tương tự như hình ảnh cục bộ.

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

Trong các ứng dụng chạy lâu dài, tái sử dụng một client HTTP hoặc chiến lược quản lý kết nối phù hợp với ứng dụng thay vì liên tục tạo ra cơ sở hạ tầng mạng không cần thiết. Đồng thời, xác thực các URL từ xa, kích thước phản hồi và kiểu nội dung khi nguồn không đáng tin cậy.

## **Tái Sử Dụng Hình Ảnh Trên Nhiều Slide**

Nếu cùng một hình ảnh cần được sử dụng nhiều hơn một lần, hãy thêm nó vào bài thuyết trình một lần và tái sử dụng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) đã trả về khi tạo các khung hình bổ sung. Điều này tránh việc tải lại dữ liệu nguồn liên tục và làm cho mối quan hệ giữa tài nguyên hình ảnh chia sẻ và các lần sử dụng của nó trở nên rõ ràng.

Đối với các đồ họa nên xuất hiện tự động trên nhiều slide, chẳng hạn như logo công ty, hãy cân nhắc đặt khung hình trên một [master slide](/slides/vi/androidjava/slide-master/) hoặc layout thay vì thêm một hình dạng tương đương vào mỗi slide.

## **Sử Dụng Hình Ảnh Là Nền Slide**

Hình ảnh nền được gán cho phần nền slide; nó không được thêm như một hình dạng khung hình. Điều này hữu ích khi hình ảnh cần phủ toàn bộ nền slide và không nên được thao tác như một đối tượng slide bình thường.

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

Đối với các tùy chọn nền bổ sung, bao gồm nền master và layout, hãy xem [Nền Bài Thuyết Trình](/slides/vi/androidjava/presentation-background/).

## **Hình Ảnh Nhúng và Hình Ảnh Liên Kết**

Embedded và linked images có những cân nhắc khác nhau về tính di động và kích thước tệp:

- **Hình ảnh nhúng:** dữ liệu hình ảnh được lưu trữ trong bài thuyết trình. Bài thuyết trình là tự chứa, nhưng kích thước tệp bao gồm dữ liệu hình ảnh.
- **Hình ảnh liên kết:** bài thuyết trình lưu trữ một đường dẫn hoặc URL tới hình ảnh bên ngoài. Điều này có thể giảm kích thước bài thuyết trình, nhưng tài nguyên bên ngoài phải luôn có thể truy cập khi bài thuyết trình được mở hoặc render.

Một hình ảnh liên kết có thể được tạo bằng cách gán đường dẫn hoặc URL bên ngoài qua [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidespicture/) thay vì nhúng dữ liệu hình ảnh.

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

Chỉ sử dụng hình ảnh liên kết khi môi trường triển khai có thể truy cập đáng tin cậy vào tài nguyên bên ngoài. Đối với các bài thuyết trình phải hoạt động offline hoặc chuyển giữa các hệ thống, hình ảnh nhúng thường an toàn hơn.

## **Làm Việc Với Hình Ảnh SVG**

SVG là một định dạng vector, vì vậy nó hữu ích cho các biểu tượng, sơ đồ và các đồ họa khác cần phóng to thu nhỏ mà không mất chi tiết như ảnh raster. Aspose.Slides hỗ trợ SVG cả như một tài nguyên hình ảnh và như một nguồn cho các hình dạng slide có thể chỉnh sửa.

### **Thêm SVG Là Hình Ảnh**

Tạo một [SvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgimage/), thêm nó vào bộ sưu tập hình ảnh và đặt tài nguyên hình ảnh kết quả vào một khung hình.

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

### **Tệp SVG Với Tài Nguyên Bên Ngoài**

Một SVG có thể tham chiếu tới các hình ảnh, stylesheet hoặc phông chữ bên ngoài. Đối với các trường hợp này, [SvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgimage/) cung cấp các constructor nhận một [IExternalResourceResolver](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iexternalresourceresolver/) và một base URI. Trình giải quyết có thể ánh xạ một URI tương đối sang một URI tuyệt đối cho phép và trả về một luồng cho tài nguyên được yêu cầu.

Trình giải quyết làm cho các tài nguyên bên ngoài có sẵn trong khi Aspose.Slides xử lý SVG, nhưng nó không ghi lại lại SVG thành một tài liệu tự chứa. Nếu SVG cần duy trì tính di động, hãy nhúng các tài nguyên cần thiết vào trong SVG, ví dụ bằng cách sử dụng URI `data:` cho các hình ảnh liên kết.

Khi các tệp SVG đến từ nguồn không tin cậy, hãy hạn chế các scheme, vị trí tệp và máy chủ mà trình giải quyết có thể truy cập. Trình giải quyết mạng cũng nên áp dụng thời gian chờ, giới hạn kích thước phản hồi và kiểm tra nội dung.

### **Chuyển Đổi SVG Thành Các Hình Dạng Có Thể Chỉnh Sửa**

Aspose.Slides có thể chuyển đổi một SVG thành một nhóm các hình dạng slide có thể chỉnh sửa, tương tự như lệnh trong PowerPoint.

![Menu Pop-up PowerPoint](img_01_01.png)

Sử dụng overload [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/) chấp nhận một [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/) để thực hiện quá trình chuyển đổi.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sử dụng chuyển đổi SVG thành hình dạng khi các phần tử vector riêng lẻ cần được chỉnh sửa như các hình dạng PowerPoint. Nếu SVG chỉ cần hiển thị, giữ nó dưới dạng hình ảnh sẽ đơn giản hơn và tránh tạo ra nhiều hình dạng riêng biệt.

## **Thay Thế Tài Nguyên Hình Ảnh Hiện Có**

Sử dụng [IPPImage.replaceImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) khi bạn muốn thay thế một tài nguyên hình ảnh hiện có. Điều này đặc biệt hữu ích cho các đồ họa chia sẻ như logo.

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

Nếu nhiều khung hình, nền, master hoặc layout sử dụng cùng một tài nguyên hình ảnh, việc thay thế tài nguyên đó sẽ cập nhật tất cả các lần sử dụng. Nếu chỉ một khung hình cần thay đổi, hãy gán một hình ảnh khác cho khung đó thay vì thay thế tài nguyên chung.

`replaceImage` cũng cung cấp các overload cho phép truyền một mảng byte hoặc một [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) khác.

## **Hướng Dẫn Quản Lý Hình Ảnh Thực Tiễn**

### **Kiểm Soát Kích Thước Bài Thuyết Trình**

Các ảnh raster kích thước lớn có thể làm cho bài thuyết trình trở nên quá to. Sử dụng các hình ảnh nguồn có kích thước phù hợp với kích thước hiển thị dự kiến, tái sử dụng các tài nguyên hình ảnh chia sẻ khi có thể, và tránh nhúng các bản sao lặp lại của cùng một đồ họa độ phân giải cao.

Đối với các ảnh raster đã được đặt trong khung hình, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) có thể giảm dữ liệu hình ảnh dựa trên độ phân giải và cài đặt cắt đã chọn. Đây là xử lý khung hình chứ không phải quản lý bộ sưu tập hình ảnh, vì vậy hãy xem [Khung Hình](/slides/vi/androidjava/picture-frame/) để biết các thao tác định dạng liên quan.

### **Chọn Giữa Nội Dung Nhúng và Liên Kết**

Nhúng làm cho bài thuyết trình di động vì tất cả dữ liệu hình ảnh cần thiết đi kèm với tệp. Liên kết có thể giảm kích thước tệp, nhưng nó tạo ra một phụ thuộc bên ngoài. Chỉ sử dụng liên kết khi phụ thuộc đó chấp nhận được và ổn định.

### **Tái Sử Dụng Thương Hiệu Chung**

Đối với các logo, watermark hoặc đồ họa trang trí lặp lại, hãy sử dụng một tài nguyên hình ảnh và tái sử dụng nó. Nếu đồ họa thuộc về thiết kế bài thuyết trình chứ không phải nội dung slide, hãy đặt nó trên một master hoặc layout để nó được thừa kế bởi các slide phù hợp.

### **Giữ Tài Nguyên SVG Di Động**

Một SVG tự chứa dễ di chuyển và render một cách nhất quán hơn so với SVG phụ thuộc vào các tệp hoặc tài nguyên mạng bên ngoài. Khi có thể, hãy nhúng các tài nguyên cần thiết trước khi nhập SVG. Chuyển đổi SVG thành hình dạng chỉ khi các phần tử vector riêng lẻ cần được chỉnh sửa.

### **Sử Dụng API Hình Ảnh Đa Nền Tảng Hiện Đại**

Đối với mã Android via Java mới, hãy sử dụng các API Aspose.Slides [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) và [Images](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/images/) thay vì API công cộng cũ dựa trên `android.graphics.Bitmap`. Xem [Modern API](/slides/vi/androidjava/modern-api/) để biết hướng dẫn di chuyển.

WMF và EMF yêu cầu xem xét đặc biệt. Khi các định dạng này được truyền qua một [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imagecollection/) chuyển đổi metafile thành một biểu diễn PNG raster trước khi chèn. Nếu việc bảo tồn dữ liệu metafile là quan trọng, hãy sử dụng overload dựa trên stream của [ImageCollection.addImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imagecollection/) thay thế. Tạo nội dung EMF từ bảng tính hoặc các sản phẩm khác là một quy trình tích hợp riêng và không nằm trong phạm vi của bài viết này.

## **Câu Hỏi Thường Gặp**

**Sự khác biệt giữa bộ sưu tập hình ảnh và khung hình là gì?**

Bộ sưu tập hình ảnh lưu trữ các tài nguyên hình ảnh có thể tái sử dụng. Khung hình là một hình dạng slide hiển thị một trong các tài nguyên đó và cung cấp các định dạng đặc thù cho hình ảnh như cắt và hiệu ứng.

**Cách tốt nhất để thay thế cùng một logo ở mọi nơi là gì?**

Nếu logo đã được chia sẻ dưới dạng một tài nguyên hình ảnh, hãy thay thế tài nguyên đó bằng [IPPImage.replaceImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/). Đối với thương hiệu trên toàn bộ bài thuyết trình, việc đặt logo trên một master hoặc layout cũng có thể giảm nội dung slide trùng lặp.

**Tại sao một hình ảnh liên kết lại biến mất trên máy tính khác?**

Một hình ảnh liên kết phụ thuộc vào tệp hoặc URL bên ngoài của nó. Nếu tài nguyên đó không thể truy cập được từ máy tính khác, hình ảnh liên kết có thể không khả dụng. Nhúng hình ảnh khi bài thuyết trình phải tự chứa.

**Có thể chỉnh sửa SVG được chèn thành các hình dạng PowerPoint không?**

Có. Chuyển đổi SVG bằng [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/); nhóm kết quả chứa các hình dạng slide có thể chỉnh sửa thay vì một hình ảnh SVG duy nhất.

**Làm sao để giữ bài thuyết trình có nhiều hình ảnh mà vẫn nhỏ gọn?**

Tái sử dụng các tài nguyên hình ảnh chia sẻ, tránh các nguồn raster không cần thiết lớn, nén các ảnh raster phù hợp khi cần, giữ thương hiệu lặp lại trên master hoặc layout, và chỉ sử dụng hình ảnh liên kết khi phụ thuộc bên ngoài là chấp nhận được.