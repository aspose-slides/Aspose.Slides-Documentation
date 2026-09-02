---
title: Quản lý Khung Hình Ảnh trong Bản Trình Chiếu bằng Java
linktitle: Khung Hình Ảnh
type: docs
weight: 10
url: /vi/java/picture-frame/
keywords:
- khung hình ảnh
- thêm khung hình ảnh
- tạo khung hình ảnh
- ảnh nhúng
- ảnh liên kết
- trích xuất ảnh
- ảnh raster
- ảnh SVG
- cắt ảnh
- xóa khu vực đã cắt
- nén ảnh
- StretchOffset
- định dạng khung hình ảnh
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung hình ảnh trong bản trình chiếu với Aspose.Slides cho Java."
---
## **Tổng quan**

Khung hình ảnh là một hình dạng trên slide hiển thị một ảnh. Trong Aspose.Slides, tài nguyên ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) sở hữu các tài nguyên ảnh nhúng thông qua [IImageCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagecollection/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các cài đặt ở mức khung khác.

Sự phân tách này hữu ích khi cùng một ảnh được hiển thị nhiều lần. Thêm ảnh vào bản trình chiếu một lần, giữ lại đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) được trả về, và sử dụng tài nguyên ảnh đó khi tạo các khung hình ảnh.

Khung hình ảnh có thể chứa ảnh raster như PNG hoặc JPEG và ảnh vector SVG. Chúng cũng có thể tham chiếu tới ảnh liên kết thay vì lưu trữ byte ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến khả năng di động, kích thước tệp, việc trích xuất và hành vi xuất khẩu, vì vậy nên quyết định cách lưu trữ ảnh trước khi áp dụng định dạng hoặc tối ưu hóa.

## **Thêm và Định dạng Ảnh Nhúng**

Đối với ảnh nhúng, thêm dữ liệu ảnh vào bản trình chiếu và tạo một khung hình ảnh bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Ảnh sẽ trở thành một phần của gói bản trình chiếu, do đó bản trình chiếu vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một ảnh JPEG, tạo khung với kích thước gốc của ảnh, và áp dụng định dạng đường viền và xoay:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Khung hình ảnh kiểm soát hình học hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) cung cấp khả năng điều chỉnh tỷ lệ chiều rộng và chiều cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương đương với 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình công việc cần bảo lưu mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng thủ công.

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

Thay đổi tỷ lệ tương đối chỉ điều chỉnh các thiết lập tỷ lệ của khung; nó không tái mẫu hoặc nén ảnh nhúng.

## **Ảnh Nhúng và Ảnh Liên kết**

Ảnh nhúng lưu dữ liệu ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho khả năng di động và việc hiển thị dự đoán được. Ảnh liên kết lưu vị trí bên ngoài thông qua phương thức [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu ảnh theo cách truyền thống.

Ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải luôn có thể truy cập được bởi ứng dụng mở hoặc hiển thị bản trình chiếu. Nếu đường dẫn thay đổi, tệp được di chuyển, hoặc tài nguyên không còn, ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình chiếu cần được gửi email, lưu trữ hoặc hiển thị trong môi trường cô lập, ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Ảnh Liên kết**

Ví dụ sau tạo một khung hình ảnh và trỏ nó tới tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; việc liên kết video là một quy trình media riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là cố ý. Đừng dùng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc ảnh bị hỏng thường kém hữu ích hơn so với một bản trình chiếu lớn tự chứa.

## **Trích xuất Ảnh từ Khung Hình**

Trước khi trích xuất ảnh từ một bản trình chiếu hiện có, hãy kiểm tra xem hình dạng thực sự là một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) và nó có chứa ảnh nhúng hay không. Các khung hình ảnh liên kết có thể không chứa byte ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Ảnh Raster**

API ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) trực tiếp và không yêu cầu lớp bao Java cũ. Ví dụ dưới đây tìm ảnh raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) sẽ chuyển đổi ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần các byte đã mã hoán được lưu trong bản trình chiếu thay vì một tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên ảnh.

### **Trích xuất Ảnh SVG**

Đối với ảnh SVG, [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hóa ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình chiếu. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa xuất ra không nên được coi là một bản sao byte‑for‑byte của SVG nhúng gốc; hãy dùng dữ liệu [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/#getSvgData--) khi cần tài nguyên vector nguyên bản.

## **Cắt Ảnh**

Cắt thay đổi phần ảnh nào sẽ hiển thị bên trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không ngay lập tức xóa các pixel ẩn khỏi ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ dưới đây tìm khung hình ảnh một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu ảnh ẩn vẫn còn tồn tại, việc cắt có thể được thay đổi sau này mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng hoàn tác, các vùng đã cắt có thể được xóa thực tế như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Ảnh Đã Cắt**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu ảnh nằm ngoài vùng cắt hiện tại và trả về tài nguyên ảnh mới. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình chiếu được lưu, các pixel đã bị xóa sẽ không còn khả dụng cho thao tác “uncrop” sau này.

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

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình chiếu. Nếu ảnh gốc cũng được các khung hình ảnh khác sử dụng, các khung đó vẫn cần tài nguyên hiện có, do đó việc xóa các vùng đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Ảnh Raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) giảm độ phân giải ảnh raster tương đối với kích thước hiển thị của ảnh. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không có thay đổi nào cần thiết.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturescompression/) đã được xác định trước khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Có thể truyền một giá trị DPI dương tùy chỉnh thay cho giá trị đã xác định trước khi cần một mục tiêu cụ thể.

Nén được thiết kế cho ảnh raster. Nội dung SVG và metafile không bị giảm kích thước bởi quy trình nén raster này. Ngoài ra, hãy nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình chiếu đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Quản lý Hiệu ứng Biến đổi Ảnh**

Đối với quy trình hoàn chỉnh bao gồm độ sáng, độ tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác thực vòng lặp, xem [Image Transform Effects](/java/image-transform-effects/).

## **Khóa Hình Học Khung Ảnh**

Các cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung hình ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) giữ tỷ lệ hình dạng khi thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung hình ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn để có cùng tỷ lệ khung.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) xác định hình chữ nhật lấp đầy tương đối với khung bao của khung hình ảnh. Phần trăm dương tạo ra một khoảng lùi từ cạnh, trong khi phần trăm âm tạo ra một khoảng mở rộng.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn sẽ hiển thị; các offset stretch thay đổi hình chữ nhật mà trong đó phần ảnh hiển thị được kéo dài.

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

Sử dụng stretch offset để đặt vị trí lấp đầy. Dùng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Lưu ý Khi Xuất**

Các cân nhắc chính dễ quản lý hơn khi việc lưu trữ ảnh và định dạng khung hình ảnh được tách riêng:

- **Ảnh nhúng** làm cho bản trình chiếu tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía server, nhưng ảnh raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tệp bên ngoài phải vẫn tồn tại ở các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn được nhúng cho tới khi các khu vực đã cắt được xóa rõ ràng hoặc bị loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng sẽ mất độ phân giải nguồn. Nên áp dụng sau khi đã biết kích thước thực tế trên slide.
- **Ảnh SVG** nên để nguyên dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Các xuất slide raster luôn chuyển đổi slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình làm việc.

Đối với các bản trình chiếu lớn, tối ưu hóa ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng vector, nén ảnh chụp theo kích thước hiển thị thực tế, xóa pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác biệt giữa khung hình ảnh và tài nguyên ảnh là gì?**

[IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) đại diện cho một tài nguyên ảnh được liên kết với bản trình chiếu. [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị ảnh và lưu trữ các thuộc tính ở mức khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình chiếu phải di động, lưu trữ hoặc render mà không cần truy cập tới tài nguyên bên ngoài. Liên kết ảnh chỉ khi việc giữ các tệp ảnh bên ngoài PPTX là cố ý và các vị trí bên ngoài có thể được duy trì đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt bình thường chỉ ẩn một phần ảnh nguồn mà không giảm pixel nền. Hãy sử dụng [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) hoặc nén ảnh kèm việc xóa khu vực đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ và việc loại bỏ các khu vực đã cắt sẽ xóa dữ liệu ảnh. Giữ ảnh nguồn gốc bên ngoài bản trình chiếu nếu có thể cần chỉnh sửa độ phân giải cao sau này.

**Cần xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ chính xác vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render slide sang định dạng raster như PNG hoặc JPEG sẽ raster hóa SVG như một phần của ảnh slide.

**Làm sao tránh lỗi ép kiểu không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù của khung hình ảnh. Kiểm tra `instanceof` đối với [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) giúp tránh các ép kiểu không hợp lệ và cho phép mã xử lý các slide không chứa khung hình ảnh.