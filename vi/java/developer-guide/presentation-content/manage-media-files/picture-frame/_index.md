---
title: Quản lý khung ảnh trong bản trình chiếu bằng Java
linktitle: Khung ảnh
type: docs
weight: 10
url: /vi/java/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- hình ảnh nhúng
- hình ảnh liên kết
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh SVG
- cắt hình ảnh
- xóa các vùng đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình chiếu với Aspose.Slides cho Java."
---
## **Overview**

Khung ảnh là một hình dạng trên slide hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị chúng là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [IImageCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagecollection/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các thiết lập cấp độ khung khác.

Việc tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình bày một lần, giữ lại [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) được trả về, và sử dụng tài nguyên hình ảnh đó khi tạo các khung ảnh.

Khung ảnh có thể chứa hình ảnh raster như PNG hoặc JPEG và hình ảnh vector SVG. Chúng cũng có thể tham chiếu tới các hình ảnh được liên kết thay vì lưu trữ byte hình ảnh trong bản trình bày. Lựa chọn này ảnh hưởng đến tính di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu hoá.

## **Add and Format an Embedded Image**

Đối với hình ảnh được nhúng, thêm dữ liệu hình ảnh vào bản trình bày và tạo một khung ảnh bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Hình ảnh trở thành một phần của gói bản trình bày, do đó bản trình bày vẫn tự chứa khi được di chuyển sang máy tính khác.

Ví dụ sau thêm một hình ảnh JPEG, tạo khung với kích thước gốc của hình ảnh và áp dụng định dạng đường viền cùng xoay:

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

Khung ảnh kiểm soát hình học hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh được nhúng. Sự khác biệt này quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Use Relative Scale**

[IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) cung cấp khả năng thu phóng chiều rộng và chiều cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương ứng với 100 % kích thước ảnh gốc. Thu phóng tương đối hữu ích khi quy trình làm việc cần duy trì mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng một cách thủ công.

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

Thu phóng tương đối thay đổi các thiết lập tỷ lệ của khung; nó không thực hiện tái mẫu hoặc nén hình ảnh được nhúng.

## **Embedded and Linked Images**

Hình ảnh được nhúng lưu dữ liệu hình ảnh bên trong bản trình bày và do đó là lựa chọn an toàn nhất cho tính di động và việc hiển thị dự đoán được. Hình ảnh được liên kết lưu vị trí ngoại vi thông qua phương thức [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu hình ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải luôn có thể truy cập được bởi ứng dụng mở hoặc hiển thị bản trình bày. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình bày cần được gửi email, lưu trữ, hoặc hiển thị trong môi trường cô lập, hình ảnh được nhúng thường đáng tin cậy hơn.

### **Add a Linked Image**

Ví dụ sau tạo một khung ảnh và trỏ nó tới một tệp hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; việc liên kết video là một quy trình truyền thông riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi quản lý tệp ngoại vi là mục đích dự định. Đừng sử dụng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ có các phụ thuộc hình ảnh bị hỏng thường ít hữu ích hơn một bản trình bày tự chứa lớn hơn.

## **Extract Images from Picture Frames**

Trước khi trích xuất hình ảnh từ một bản trình bày hiện có, hãy kiểm tra xem hình dạng thực sự là một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) và nó có chứa hình ảnh được nhúng hay không. Các khung ảnh được liên kết có thể không chứa byte hình ảnh có thể được trích xuất cùng cách.

### **Extract a Raster Image**

API hình ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) trực tiếp và không yêu cầu lớp bao Java cũ. Ví dụ sau tìm ảnh raster được nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) sẽ chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần các byte đã mã hoá lưu trong bản trình bày thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh thay vì.

### **Extract an SVG Image**

Đối với ảnh SVG, [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo toàn nguồn vector bên trong bản trình bày. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide sang PDF hoặc SVG cũng là một hoạt động render, vì vậy đồ họa đã xuất không nên được xem như một bản sao byte‑for‑byte của SVG được nhúng; hãy dùng dữ liệu [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/#getSvgData--) khi cần tài nguyên vector gốc.

## **Crop an Image**

Cắt thay đổi phần nào của hình ảnh hiển thị bên trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không ngay lập tức xóa các pixel ẩn khỏi hình ảnh được nhúng; nó chỉ thay đổi vùng hiển thị.

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

Vì dữ liệu ảnh ẩn vẫn còn tồn tại, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng đảo ngược, các khu vực đã cắt có thể được loại bỏ thực sự như mô tả trong phần tiếp theo.

## **Remove Cropped Image Data**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu ảnh nằm ngoài vùng cắt hiện tại và trả về tài nguyên hình ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá có tính phá hủy: sau khi bản trình bày được lưu, các pixel đã bị xóa sẽ không còn khả dụng cho thao tác hủy cắt sau này.

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

Phương thức có thể thêm một tài nguyên hình ảnh mới vào bản trình bày. Nếu ảnh gốc cũng được các khung ảnh khác sử dụng, các khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các khu vực đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương pháp này sẽ raster hoá kết quả đã cắt thành PNG.

## **Compress Raster Images**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) giảm độ phân giải hình raster so với kích thước mà ảnh được hiển thị. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi ảnh được thay đổi kích thước hoặc cắt và `false` khi không cần thiết phải thay đổi.

Sử dụng một giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturescompression/) được định sẵn khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Có thể truyền một giá trị DPI dương tùy chỉnh thay cho giá trị định sẵn khi cần mục tiêu cụ thể.

Nén được thiết kế cho hình ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Đồng thời nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình bày đã tối ưu hoá. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất trên toàn bộ.

## **Manage Image Transform Effects**

Đối với một quy trình hoàn chỉnh bao gồm điều chỉnh độ sáng, độ tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác minh vòng lặp, xem [Image Transform Effects](/slides/vi/java/image-transform-effects/).

## **Lock Picture Frame Geometry**

Các cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) giữ nguyên tỷ lệ hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn theo cùng tỷ lệ.

## **Adjust the StretchOffset Values**

Khi chế độ điền ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) định nghĩa hình chữ nhật điền tương đối với hộp bao của khung ảnh. Phần trăm dương tạo khoảng inset từ mép, trong khi phần trăm âm tạo khoảng outset.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà ảnh đã điền được kéo dãn vào.

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

Sử dụng stretch offset để định vị việc điền. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các mép ảnh nguồn.

## **Storage, File Size, and Export Considerations**

Các cân nhắc chính trở nên dễ quản lý hơn khi việc lưu trữ ảnh và định dạng khung ảnh được tách riêng:

- **Embedded images** làm cho bản trình bày tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các hình raster lớn sẽ tăng kích thước PPTX và sử dụng bộ nhớ.
- **Linked images** có thể giữ gói nhỏ hơn, nhưng bản trình bày phụ thuộc vào các tệp ngoại vi vẫn phải tồn tại tại các đường dẫn hoặc vị trí đã lưu.
- **Cropping** ban đầu không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các khu vực đã cắt được xóa rõ ràng hoặc bị loại bỏ trong quá trình nén.
- **Compression** có thể giảm đáng kể kích thước tệp cho các hình raster quá lớn, nhưng đổi lại mất độ phân giải nguồn. Nên áp dụng sau khi đã biết kích thước thực tế trên slide.
- **SVG images** nên giữ dưới dạng SVG khi cần bảo toàn vector. Trích xuất SVG được nhúng trực tiếp khi bạn cần tài nguyên vector gốc. Các xuất slide raster luôn chuyển đổi slide đã render thành pixel.
- **Repeated images** nên tái sử dụng một tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) hiện có khi có thể thay vì tải lại cùng tệp nhiều lần trong quy trình làm việc.

Đối với các bản trình bày lớn, tối ưu hoá ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng vector, nén ảnh chụp dựa trên kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết ngoại vi trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

Một [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) đại diện cho tài nguyên hình ảnh được liên kết với bản trình bày. Một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thiết lập cấp độ khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Should I embed or link images?**

Nên nhúng hình ảnh khi bản trình bày phải di động, lưu trữ hoặc render mà không cần truy cập vào tài nguyên bên ngoài. Chỉ liên kết hình ảnh khi việc giữ các tệp hình ảnh bên ngoài PPTX là mục đích dự định và các vị trí ngoại vi có thể được duy trì một cách đáng tin cậy.

**Does cropping reduce PPTX file size?**

Không tự động. Cài đặt cắt thông thường chỉ ẩn một phần ảnh nguồn mà vẫn giữ nguyên pixel nền. Hãy sử dụng [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) hoặc nén ảnh có loại bỏ khu vực đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Can I restore image quality after compression?**

Không. Nén có thể giảm độ phân giải raster đã lưu, và việc loại bỏ các vùng đã cắt sẽ xóa dữ liệu ảnh. Giữ lại ảnh nguồn gốc bên ngoài bản trình bày nếu có thể cần chỉnh sửa ở độ phân giải cao sau này.

**How should SVG images be handled?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/) được nhúng có thể được trích xuất trực tiếp. Render một slide thành định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của hình ảnh slide.

**How can I avoid unsafe casts when reading existing slides?**

Kiểm tra loại hình dạng trước khi sử dụng các thành viên đặc thù của khung ảnh. Kiểm tra `instanceof` đối với [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) sẽ tránh các cast không hợp lệ và cho phép mã xử lý các slide không chứa khung ảnh.