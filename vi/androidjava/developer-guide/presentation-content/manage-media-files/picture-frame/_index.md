---
title: Quản lý Khung Ảnh trong Bản Trình Chiếu trên Android
linktitle: Khung Ảnh
type: docs
weight: 10
url: /vi/androidjava/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- ảnh nhúng
- ảnh liên kết
- trích xuất ảnh
- ảnh raster
- ảnh SVG
- cắt ảnh
- xóa vùng đã cắt
- nén ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỉ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình chiếu với Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Khung ảnh là một hình dạng slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên ảnh và hình dạng hiển thị ảnh là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) sở hữu các tài nguyên ảnh nhúng thông qua [IImageCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagecollection/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các thiết lập mức khung khác.

Sự tách biệt này hữu ích khi cùng một ảnh được hiển thị nhiều lần. Thêm ảnh vào bản trình chiếu một lần, giữ lại đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) trả về, và sử dụng tài nguyên ảnh đó khi tạo các khung ảnh.

Khung ảnh có thể chứa ảnh raster như PNG hoặc JPEG và ảnh vector SVG. Chúng cũng có thể tham chiếu tới ảnh liên kết thay vì lưu trữ byte ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng tới khả năng di chuyển, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ ảnh trước khi áp dụng định dạng hoặc tối ưu hóa.

## **Thêm và Định dạng ảnh nhúng**

Đối với ảnh nhúng, thêm dữ liệu ảnh vào bản trình chiếu và tạo một khung ảnh bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Ảnh sẽ trở thành một phần của gói bản trình chiếu, do đó bản trình chiếu vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một ảnh JPEG, tạo khung ở kích thước gốc của ảnh, và áp dụng định dạng đường viền cùng việc xoay:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Khung ảnh điều khiển hình học được hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc lưu trong tài nguyên ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng tỷ lệ tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) cung cấp khả năng điều chỉnh tỷ lệ rộng và cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương ứng với 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình cần giữ một mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng thủ công.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tỷ lệ tương đối thay đổi các thiết lập tỷ lệ của khung; nó không tái mẫu hay nén ảnh nhúng.

## **Ảnh nhúng và ảnh liên kết**

Ảnh nhúng lưu dữ liệu ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho khả năng di chuyển và việc hiển thị dự đoán được. Ảnh liên kết lưu vị trí ngoại vi thông qua phương thức [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu ảnh theo cùng cách.

Ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn truy cập được cho ứng dụng mở hoặc hiển thị bản trình chiếu. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình chiếu cần được gửi email, lưu trữ, hoặc hiển thị trong môi trường cô lập, ảnh nhúng thường đáng tin cậy hơn.

### **Thêm ảnh liên kết**

Ví dụ sau tạo một khung ảnh và chỉ tới một tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; liên kết video là một quy trình media riêng và không được trộn vào ví dụ này.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Đừng sử dụng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc ảnh bị hỏng thường kém hữu ích hơn so với một bản trình chiếu lớn tự chứa.

## **Trích xuất ảnh từ khung ảnh**

Trước khi trích xuất ảnh từ bản trình chiếu hiện có, kiểm tra xem hình dạng thực sự là một [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) và nó có chứa ảnh nhúng hay không. Các khung ảnh liên kết có thể không chứa byte ảnh có thể trích xuất theo cùng cách.

### **Trích xuất ảnh raster**

API ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) trực tiếp và không yêu cầu wrapper Java cũ. Ví dụ sau tìm ảnh raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) chuyển đổi ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần các byte đã mã hoá lưu trong bản trình chiếu thay vì một tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên ảnh.

### **Trích xuất ảnh SVG**

Đối với ảnh SVG, [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Giữ nội dung SVG dưới dạng SVG giúp bảo tồn nguồn vector trong bản trình chiếu. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa xuất không nên được xem như một bản sao byte‑for‑byte của SVG nhúng gốc; sử dụng dữ liệu [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/#getSvgData--) khi cần tài nguyên vector gốc.

## **Cắt ảnh**

Cắt thay đổi phần ảnh nào hiển thị trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung ảnh một cách an toàn và áp dụng các giá trị cắt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Vì dữ liệu ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn khả năng đảo ngược, các vùng đã cắt có thể được xóa vật lý như mô tả trong phần tiếp theo.

## **Xóa dữ liệu ảnh đã cắt**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu ảnh nằm ngoài vùng cắt hiện tại và trả về tài nguyên ảnh mới. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình chiếu được lưu, các pixel đã xóa không còn khả dụng cho thao tác “uncrop” sau này.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình chiếu. Nếu ảnh gốc cũng được các khung ảnh khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, do đó xóa các vùng đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén ảnh raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) giảm độ phân giải ảnh raster tương ứng với kích thước hiển thị của ảnh. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao vụ. Phương thức trả về `true` khi ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không có thay đổi nào cần thiết.

Sử dụng một giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/picturescompression/) định trước khi độ phân giải mục tiêu chuẩn là đủ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Một giá trị DPI dương tùy chỉnh có thể được truyền thay cho giá trị định trước khi cần mục tiêu cụ thể.

Nén được thiết kế cho ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Ngoài ra, hãy nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình chiếu đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Quản lý hiệu ứng biến đổi ảnh**

Đối với quy trình đầy đủ bao gồm độ sáng, tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác nhận vòng vòng, xem [Image Transform Effects](/androidjava/image-transform-effects/).

## **Khóa hình học khung ảnh**

Các thiết lập [IPictureFrameLock](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) giữ tỉ lệ hình dạng khi nó được thay đổi kích thước.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn thành cùng tỉ lệ.

## **Điều chỉnh giá trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao của khung ảnh. Phần trăm dương tạo khoảng cách vào trong từ cạnh, trong khi phần trăm âm tạo khoảng cách ra ngoài.

Điều này khác với cắt. Giá trị cắt chọn phần ảnh nguồn hiển thị; các offset stretch thay đổi hình chữ nhật mà phần ảnh hiển thị được kéo dãn vào.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sử dụng stretch offsets để định vị lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, kích thước tệp và cân nhắc xuất**

Các điểm cân bằng chính dễ quản lý hơn khi lưu trữ ảnh và định dạng khung ảnh được xử lý riêng biệt:

- **Ảnh nhúng** làm cho bản trình chiếu tự chứa và là đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng ảnh raster lớn làm tăng kích thước PPTX và mức sử dụng bộ nhớ.
- **Ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tệp ngoài phải luôn khả dụng tại các đường dẫn đã lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc bị loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho ảnh raster quá lớn, nhưng sẽ mất độ phân giải nguồn. Nên áp dụng sau khi biết kích thước thực tế trên slide.
- **Ảnh SVG** nên để lại dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Xuất slide raster luôn chuyển đổi slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) hiện có khi có thể thay vì tải cùng một tệp nhiều lần vào quy trình.

Đối với các bản trình chiếu lớn, tối ưu ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng vector, nén ảnh chụp theo kích thước hiển thị thực tế, xóa các pixel đã cắt chỉ khi không cần chỉnh sửa sau, và tránh liên kết ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác nhau gì giữa khung ảnh và tài nguyên ảnh?**

Một [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) đại diện cho một tài nguyên ảnh được liên kết với bản trình chiếu. Một [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị ảnh và lưu trữ các dữ liệu hình học và định dạng mức khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình chiếu phải di động, lưu trữ hoặc render mà không cần tài nguyên bên ngoài. Liên kết ảnh chỉ khi việc giữ các tệp ảnh ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có làm giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt thông thường ẩn các phần của ảnh nguồn nhưng vẫn giữ các pixel nền. Sử dụng [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) hoặc nén ảnh kèm loại bỏ vùng đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc xóa các vùng đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ ảnh nguồn gốc bên ngoài bản trình chiếu nếu cần chỉnh sửa với độ phân giải cao sau này.

**Nên xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render slide thành định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh lỗi cast không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên riêng của khung ảnh. Kiểm tra `instanceof` với [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) tránh các cast không hợp lệ và cho phép mã xử lý các slide không chứa khung ảnh.