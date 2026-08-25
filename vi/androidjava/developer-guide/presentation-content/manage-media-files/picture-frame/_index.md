---
title: Quản lý khung hình trong bản trình bày trên Android
linktitle: Khung hình
type: docs
weight: 10
url: /vi/androidjava/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- ảnh nhúng
- ảnh liên kết
- trích xuất ảnh
- ảnh raster
- ảnh SVG
- cắt ảnh
- xóa vùng đã cắt
- nén ảnh
- StretchOffset
- định dạng khung hình
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung hình trong bản trình bày với Aspose.Slides cho Android bằng Java."
---
## **Tổng quan**

Khung hình là một hình dạng trên slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [IImageCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagecollection/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) kiểm soát vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các cài đặt cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình bày một lần, giữ lại đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) được trả về, và sử dụng tài nguyên hình ảnh đó khi tạo các khung hình.

Khung hình có thể chứa các ảnh raster như PNG hoặc JPEG và các ảnh vector SVG. Chúng cũng có thể tham chiếu đến các ảnh liên kết thay vì lưu trữ byte ảnh trong bản trình bày. Lựa chọn này ảnh hưởng đến khả năng di chuyển, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ ảnh trước khi áp dụng định dạng hoặc tối ưu hoá.

## **Thêm và Định dạng Ảnh Nhúng**

Đối với ảnh được nhúng, thêm dữ liệu ảnh vào bản trình bày và tạo một khung hình bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Ảnh sẽ trở thành một phần của gói bản trình bày, vì vậy bản trình bày vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một ảnh JPEG, tạo khung ở kích thước gốc của ảnh và áp dụng định dạng đường viền và xoay:

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

Khung hình kiểm soát hình học hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên ảnh nhúng. Sự khác biệt này quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) cung cấp khả năng điều chỉnh tỷ lệ chiều rộng và chiều cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương đương với 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần duy trì mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng thủ công.

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

Tỷ lệ tương đối thay đổi cài đặt tỉ lệ của khung; nó không tái mẫu hoặc nén ảnh nhúng.

## **Ảnh Nhúng và Ảnh Liên kết**

Ảnh nhúng lưu dữ liệu ảnh bên trong bản trình bày và do đó là lựa chọn an toàn nhất cho khả năng di chuyển và việc hiển thị dự đoán được. Ảnh liên kết lưu vị trí bên ngoài thông qua phương thức [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu ảnh theo cùng cách.

Ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được bởi ứng dụng mở hoặc hiển thị bản trình bày. Nếu đường dẫn thay đổi, tệp bị di chuyển hoặc tài nguyên không khả dụng, ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình bày cần gửi email, lưu trữ hoặc hiển thị trong môi trường cô lập, ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Ảnh Liên kết**

Ví dụ sau tạo một khung hình và trỏ tới một tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; liên kết video là một quy trình truyền thông riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Đừng dùng chúng chỉ để thay thế nén: một PPTX nhỏ có các phụ thuộc ảnh bị hỏng thường ít hữu ích hơn một bản trình bày tự chứa lớn hơn.

## **Trích xuất Ảnh từ Khung Hình**

Trước khi trích xuất ảnh từ một bản trình bày hiện có, kiểm tra xem hình dạng thực sự có phải là [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) và nó có chứa ảnh nhúng hay không. Các khung ảnh liên kết có thể không chứa byte ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Ảnh Raster**

API ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) trực tiếp và không yêu cầu lớp bao Java cũ. Ví dụ sau tìm ảnh raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) chuyển đổi ảnh đã trích xuất sang định dạng đầu ra được yêu cầu. Nếu bạn cần các byte đã mã hoá lưu trong bản trình bày thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên ảnh thay vì.

### **Trích xuất Ảnh SVG**

Đối với ảnh SVG, [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp mà không cần raster hoá ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình bày. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa được xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/#getSvgData--) khi cần tài nguyên vector gốc.

## **Cắt Ảnh**

Cắt thay đổi phần ảnh nào sẽ hiển thị bên trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung hình một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu ảnh ẩn vẫn còn tồn tại, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng phục hồi, các vùng đã cắt có thể được loại bỏ thực tế như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Ảnh Đã Cắt**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu ảnh ngoài vùng cắt hiện tại và trả về tài nguyên ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình bày được lưu, các pixel đã bị xóa sẽ không còn khả năng phục hồi cho thao tác “uncrop” sau này.

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

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình bày. Nếu ảnh gốc cũng được các khung hình khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Ảnh Raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) giảm độ phân giải ảnh raster so với kích thước hiển thị của ảnh. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/picturescompression/) đã được định sẵn khi một độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Có thể truyền một giá trị DPI dương tùy chỉnh thay cho giá trị đã định sẵn khi cần một mục tiêu cụ thể.

Nén chủ yếu dành cho ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Đồng thời nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình bày đã tối ưu. Hãy chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Quản lý Hiệu Ứng Biến Đổi Ảnh**

Đối với quy trình hoàn chỉnh bao gồm điều chỉnh độ sáng, độ tương phản, biến đổi màu sắc, làm mờ, hiệu ứng alpha, chuỗi đã sắp xếp, kiểm tra, loại bỏ và xác minh vòng quay, xem [Image Transform Effects](/slides/vi/androidjava/image-transform-effects/).

## **Khóa Hình Học Khung Ảnh**

Cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho khung ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) giữ tỷ lệ hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn thành cùng tỷ lệ.

## **Điều Chỉnh Giá Trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao của khung ảnh. Phần trăm dương tạo lề vào từ cạnh, trong khi phần trăm âm tạo lề ra ngoài.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn sẽ hiển thị; offset stretch thay đổi hình chữ nhật mà ảnh lấp đầy được kéo dài vào.

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

Sử dụng stretch offset để định vị lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Cân Nhắc Khi Xuất**

Các cân bằng chính dễ quản lý hơn khi lưu trữ ảnh và định dạng khung ảnh được xử lý riêng biệt:

- **Ảnh nhúng** làm cho bản trình bày tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các ảnh raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình bày phụ thuộc vào các tệp bên ngoài vẫn phải có sẵn tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc bị loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng nó sẽ mất độ phân giải nguồn. Nên áp dụng sau khi biết kích thước hiển thị trên slide.
- **Ảnh SVG** nên giữ dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi cần tài nguyên vector. Các xuất slide raster như PNG hoặc JPEG luôn chuyển đổi slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình làm việc.

Đối với các bản trình bày lớn, tối ưu hoá ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa lại sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác biệt giữa khung ảnh và tài nguyên ảnh là gì?**

[IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) đại diện cho một tài nguyên ảnh được liên kết với bản trình bày. [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị ảnh và lưu trữ các thông tin hình học và định dạng cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình bày phải di động, lưu trữ hoặc render mà không cần truy cập vào tài nguyên bên ngoài. Liên kết ảnh chỉ khi việc giữ các tệp ảnh ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Các cài đặt cắt bình thường ẩn một phần ảnh nguồn nhưng vẫn giữ các pixel bên dưới. Hãy sử dụng [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) hoặc nén ảnh với việc loại bỏ vùng đã cắt khi có thể xóa vĩnh viễn các pixel đó.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc xóa các vùng đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ ảnh nguồn gốc bên ngoài bản trình bày nếu có thể cần chỉnh sửa độ phân giải cao sau này.

**Cách xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của hình ảnh slide.

**Làm sao tránh cast không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù của khung ảnh. Kiểm tra `instanceof` đối với [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) giúp tránh cast không hợp lệ và cho phép mã xử lý các slide không chứa khung ảnh.