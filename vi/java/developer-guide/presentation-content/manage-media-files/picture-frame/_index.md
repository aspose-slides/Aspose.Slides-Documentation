---
title: Quản lý Khung Ảnh trong Bài Thuyết Trình bằng Java
linktitle: Khung Ảnh
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
- tỉ lệ khung hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bài thuyết trình bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Khung ảnh là một hình dạng trên slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [IImageCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagecollection/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các cài đặt cấp khung khác.

Việc tách rời này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bài thuyết trình một lần, giữ lại [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) trả về và sử dụng tài nguyên hình ảnh đó khi tạo các khung ảnh.

Khung ảnh có thể chứa hình raster như PNG hoặc JPEG và hình vector SVG. Chúng cũng có thể tham chiếu tới hình ảnh được liên kết thay vì lưu trữ byte hình ảnh trong bài thuyết trình. Lựa chọn này ảnh hưởng đến tính di động, kích thước tệp, quá trình trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu hóa.

## **Thêm và Định dạng Hình Ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bài thuyết trình và tạo một khung ảnh với [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Hình ảnh trở thành một phần của gói bài thuyết trình, do đó bài thuyết trình vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một hình JPEG, tạo khung với kích thước gốc của hình và áp dụng định dạng đường viền và xoay:

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

Khung ảnh điều khiển hình học được hiển thị; thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) cung cấp khả năng điều chỉnh tỷ lệ chiều rộng và chiều cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương đương 100 % kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần giữ một mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng thủ công.

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

Tỷ lệ tương đối thay đổi cài đặt tỷ lệ của khung; nó không thực hiện việc lấy mẫu lại hoặc nén hình ảnh nhúng.

## **Hình Ảnh Nhúng và Liên kết**

Hình ảnh nhúng lưu dữ liệu hình ảnh bên trong bài thuyết trình và do đó là lựa chọn an toàn nhất cho tính di động và việc hiển thị dự đoán được. Hình ảnh liên kết lưu vị trí bên ngoài qua phương thức [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu hình ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp được liên kết phải vẫn có thể truy cập được bởi ứng dụng mở hoặc hiển thị bài thuyết trình. Nếu đường dẫn thay đổi, tệp được di chuyển hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không được hiển thị như mong đợi. Đối với các bài thuyết trình cần được gửi email, lưu trữ hoặc hiển thị trong môi trường riêng biệt, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình Ảnh Liên kết**

Ví dụ sau tạo một khung ảnh và trỏ tới một tệp hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; liên kết video là một quy trình media riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Đừng dùng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc hình ảnh bị hỏng thường kém hữu ích hơn so với một bài thuyết trình tự chứa lớn hơn.

## **Trích xuất Hình Ảnh từ Khung Ảnh**

Trước khi trích xuất hình ảnh từ một bài thuyết trình hiện có, kiểm tra xem một hình dạng thực sự là một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) và nó có chứa hình ảnh nhúng không. Các khung ảnh liên kết có thể không chứa byte hình ảnh có thể được trích xuất theo cùng cách.

### **Trích xuất Hình Raster**

API hình ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) trực tiếp và không yêu cầu lớp bao Java cũ. Ví dụ sau tìm hình raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần byte đã mã hoá lưu trong bài thuyết trình thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh.

### **Trích xuất Hình SVG**

Đối với ảnh SVG, [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/). Điều này cho phép bạn truy xuất dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector trong bài thuyết trình. Các xuất raster như PNG hoặc JPEG buộc phải chuyển đổi nội dung vector thành pixel. Xuất slide thành PDF hoặc SVG cũng là một hoạt động render, vì vậy đồ họa đã xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/#getSvgData--) khi cần tài nguyên vector gốc.

## **Cắt Hình Ảnh**

Cắt thay đổi phần hình ảnh nào được hiển thị bên trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng nhìn thấy.

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

Vì dữ liệu hình ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng đảo ngược, các vùng đã cắt có thể được loại bỏ thực tế như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Hình Ảnh Đã Cắt**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu hình ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên hình ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hóa phá hủy: sau khi lưu bài thuyết trình, các pixel đã bị xóa không còn khả năng khôi phục cho thao tác “uncrop” sau này.

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

Phương thức có thể thêm một tài nguyên hình ảnh mới vào bài thuyết trình. Nếu hình ảnh gốc cũng được các khung ảnh khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các khu vực đã cắt không nhất thiết giảm tổng số hình ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Hình Raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) giảm độ phân giải hình raster so với kích thước mà ảnh được hiển thị. Nó cũng có thể xóa các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi hình ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi.

Sử dụng một giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/java/com.aspose.slides/picturescompression/) định sẵn khi độ phân giải mục tiêu tiêu chuẩn đủ:

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

Một giá trị DPI dương tùy chỉnh cũng có thể được truyền vào thay vì giá trị định sẵn khi cần mục tiêu cụ thể.

Nén được thiết kế cho hình raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Cũng nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bài thuyết trình đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà hình ảnh thực sự sẽ được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Kiểm tra Hiệu Ứng Hình Ảnh**

Hiệu ứng ảnh được lưu trên hình ảnh được khung sử dụng. Bộ sưu tập biến đổi hình ảnh có thể chứa các hiệu ứng như điều chế alpha cố định cho độ trong suốt và độ sáng cho độ tương phản. Ví dụ dưới đây đọc an toàn cả hai loại hiệu ứng từ khung ảnh đầu tiên trên một slide:

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
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Các hiệu ứng này thay đổi cách hình ảnh được render trong khung; chúng không ghi lại lại byte hình ảnh nhúng gốc.

## **Khóa Hình Học Khung Ảnh**

Cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) giữ tỉ lệ của hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được lấy mẫu lại hoặc thay đổi vĩnh viễn theo cùng tỉ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy hình ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao của khung ảnh. Phần trăm dương tạo ra một khoảng cách vào trong từ cạnh, trong khi phần trăm âm tạo ra một khoảng cách ra ngoài.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn được hiển thị; stretch offset thay đổi hình chữ nhật mà ảnh lấp đầy được kéo giãn vào.

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

Sử dụng stretch offset cho việc đặt lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các cân nhắc Khi Xuất**

Các đánh đổi chính dễ quản lý hơn khi lưu trữ hình ảnh và định dạng khung ảnh được xem xét riêng biệt:

- **Hình ảnh nhúng** làm cho bài thuyết trình tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các hình raster lớn làm tăng kích thước PPTX và mức sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bài thuyết trình phụ thuộc vào các tệp ngoại vi phải vẫn tồn tại ở các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các khu vực đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các hình raster quá lớn, nhưng nó đánh đổi độ phân giải nguồn. Nên áp dụng sau khi biết kích thước hiển thị trên slide.
- **Hình SVG** nên được giữ dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector đó. Các xuất slide raster luôn chuyển slide được render thành pixel.
- **Hình ảnh lặp lại** nên tái sử dụng một tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) hiện có khi có thể thay vì tải lại cùng một tệp nhiều lần vào quy trình làm việc của bài thuyết trình.

Đối với các bài thuyết trình lớn, tối ưu hóa hình ảnh thường hiệu quả nhất khi được thực hiện một cách chọn lọc: giữ logo và sơ đồ dưới dạng vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau, và tránh liên kết ngoại trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác biệt giữa khung ảnh và tài nguyên hình ảnh là gì?**

Một [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) đại diện cho một tài nguyên hình ảnh gắn với bài thuyết trình. Một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết hình ảnh?**

Nhúng hình ảnh khi bài thuyết trình phải di động, lưu trữ hoặc render mà không cần truy cập các tài nguyên bên ngoài. Liên kết hình ảnh chỉ khi việc để các tệp hình ảnh ngoài PPTX là có ý định và các vị trí ngoại vi có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt thông thường chỉ ẩn một phần của ảnh nguồn nhưng vẫn giữ lại pixel nền. Sử dụng [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) hoặc nén ảnh với việc loại bỏ khu vực đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster được lưu và việc xóa các khu vực đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ bản gốc nguồn ảnh bên ngoài bài thuyết trình nếu có thể cần chỉnh sửa độ phân giải cao sau này.

**Nên xử lý hình SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render một slide thành định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh các cast không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù cho khung ảnh. Kiểm tra `instanceof` với [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) tránh các cast không hợp lệ và cho phép code xử lý các slide không chứa khung ảnh.