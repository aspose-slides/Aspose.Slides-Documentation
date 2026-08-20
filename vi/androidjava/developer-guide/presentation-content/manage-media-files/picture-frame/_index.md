---
title: Quản lý khung ảnh trong bản trình chiếu trên Android
linktitle: Khung ảnh
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
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình chiếu với Aspose.Slides cho Android thông qua Java."
---
## **Tổng quan**

Một picture frame là một shape của slide hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và shape hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [IImageCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagecollection/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các cài đặt cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình chiếu một lần, giữ lại [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) được trả về, và sử dụng tài nguyên hình ảnh đó khi tạo picture frame.

Picture frame có thể chứa ảnh raster như PNG hoặc JPEG và ảnh vector SVG. Chúng cũng có thể tham chiếu đến ảnh được liên kết thay vì lưu trữ byte ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến khả năng di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ ảnh trước khi áp dụng định dạng hoặc tối ưu hoá.

## **Thêm và Định dạng Ảnh Nhúng**

Đối với ảnh nhúng, thêm dữ liệu ảnh vào bản trình chiếu và tạo picture frame bằng [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Ảnh sẽ trở thành một phần của gói bản trình chiếu, vì vậy bản trình chiếu vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một ảnh JPEG, tạo khung với kích thước gốc của ảnh, và áp dụng định dạng đường viền cũng như xoay:

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

Picture frame điều khiển hình học hiển thị; việc thay đổi kích thước khung không làm thay đổi kích thước pixel gốc lưu trong tài nguyên ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) cung cấp khả năng điều chỉnh tỷ lệ chiều rộng và chiều cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương ứng với 100 % kích thước hình ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần duy trì mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng một cách thủ công.

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

Tỷ lệ tương đối chỉ thay đổi cài đặt tỷ lệ của khung; nó không thực hiện tái mẫu hay nén ảnh nhúng.

## **Ảnh Nhúng và Ảnh Liên kết**

Ảnh được nhúng lưu trữ dữ liệu ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho khả năng di động và việc hiển thị dự đoán được. Ảnh được liên kết lưu trữ vị trí ngoại vi thông qua phương thức [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu ảnh theo cùng cách.

Ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải luôn có thể truy cập được đối với ứng dụng mở hoặc hiển thị bản trình chiếu. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, ảnh liên kết có thể không được hiển thị như mong đợi. Đối với các bản trình chiếu cần được gửi email, lưu trữ, hoặc hiển thị trong môi trường cô lập, ảnh được nhúng thường đáng tin cậy hơn.

### **Thêm Ảnh Liên kết**

Ví dụ sau tạo một picture frame và trỏ tới một tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; liên kết video là một quy trình truyền thông đa phương tiện riêng và cố ý không được trộn vào ví dụ này.

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

Sử dụng liên kết khi quản lý tệp ngoại vi là có chủ ý. Không sử dụng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc ảnh bị hỏng thường kém hữu ích hơn so với một bản trình chiếu lớn tự chứa.

## **Trích xuất Ảnh từ Picture Frame**

Trước khi trích xuất ảnh từ một bản trình chiếu hiện có, hãy kiểm tra xem shape thực sự là một [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) và nó có chứa ảnh nhúng không. Các picture frame được liên kết có thể không chứa byte ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Ảnh Raster**

API ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) trực tiếp và không yêu cầu wrapper ảnh Java cũ. Ví dụ sau tìm ảnh raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) sẽ chuyển đổi ảnh đã trích xuất sang định dạng đầu ra được yêu cầu. Nếu bạn cần các byte đã mã hoá lưu trong bản trình chiếu thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên ảnh thay vào đó.

### **Trích xuất Ảnh SVG**

Đối với ảnh SVG, [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/). Điều này cho phép bạn truy xuất dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình chiếu. Các xuất raster như PNG hay JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một hoạt động render, vì vậy đồ họa xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/#getSvgData--) khi cần tài nguyên vector gốc.

## **Cắt ảnh**

Cắt thay đổi phần ảnh nào được hiển thị trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm picture frame một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu ảnh ẩn vẫn còn tồn tại, việc cắt có thể được thay đổi sau này mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng hoàn nguyên, các vùng đã cắt có thể được loại bỏ thực tế như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Ảnh Đã Cắt**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình chiếu được lưu, các pixel đã bị xóa không còn khả dụng cho thao tác hủy cắt sau này.

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

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình chiếu. Nếu ảnh gốc cũng được các picture frame khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Ảnh Raster**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) giảm độ phân giải ảnh raster tương ứng với kích thước hiển thị của picture. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/picturescompression/) định trước khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Bạn cũng có thể truyền một giá trị DPI dương tùy chỉnh thay cho giá trị định trước khi cần mục tiêu cụ thể.

Nén được thiết kế cho ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Đồng thời nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể phục hồi từ bản trình chiếu đã tối ưu hoá. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh thực tế sẽ được xem hoặc xuất, thay vì áp dụng DPI thấp nhất trên toàn bộ.

## **Kiểm tra Hiệu Ứng Ảnh**

Hiệu ứng picture được lưu trên picture được khung sử dụng. Bộ sưu tập biến đổi ảnh có thể chứa các hiệu ứng như điều chế alpha cố định để tạo độ trong suốt và luminance để điều chỉnh độ sáng và độ tương phản. Ví dụ dưới đây đọc an toàn cả hai loại hiệu ứng từ picture frame đầu tiên trên một slide:

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

Các hiệu ứng này thay đổi cách ảnh được render trong khung; chúng không ghi đè lại byte ảnh nhúng gốc.

## **Khóa Hình Học Picture Frame**

Cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho picture frame. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) giữ tỷ lệ dạng của shape khi nó được thay đổi kích thước.

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

Khóa áp dụng cho shape picture frame. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn thành cùng tỷ lệ.

## **Điều Chỉnh Giá Trị StretchOffset**

Khi chế độ fill ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/) xác định hình chữ nhật fill tương đối với bounding box của picture frame. Phần trăm dương tạo ra một khoảng lùi từ cạnh, trong khi phần trăm âm tạo ra một khoảng mở rộng.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà hình fill hiển thị được kéo dãn vào.

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

Sử dụng stretch offset để đặt vị trí fill. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Xem Xét Khi Xuất**

Các trade‑off chính dễ quản lý hơn khi lưu trữ ảnh và định dạng picture‑frame được xử lý riêng biệt:

- **Hình ảnh được nhúng** làm cho bản trình chiếu tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các ảnh raster lớn làm tăng kích thước PPTX và mức dùng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tệp ngoại vi phải luôn có sẵn tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng sẽ mất độ phân giải nguồn. Nên áp dụng sau khi đã xác định kích thước hiển thị trên slide.
- **Ảnh SVG** nên giữ ở dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector gốc. Các xuất slide raster luôn chuyển slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng một tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình làm việc của bản trình chiếu.

Đối với các bản trình chiếu lớn, tối ưu hoá ảnh thường hiệu quả nhất khi được thực hiện một cách chọn lọc: giữ logo và sơ đồ dưới dạng vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh các liên kết ngoại trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **FAQ**

**Sự khác nhau giữa picture frame và tài nguyên ảnh là gì?**

[IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) đại diện cho một tài nguyên ảnh gắn với bản trình chiếu. [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) là một shape trên slide hiển thị ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình chiếu phải di động, lưu trữ hoặc render mà không cần truy cập vào tài nguyên ngoại vi. Liên kết ảnh chỉ khi việc giữ ảnh ngoài PPTX là có chủ đích và các vị trí ngoại vi có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt thông thường ẩn các phần của ảnh nguồn nhưng vẫn giữ lại pixel nền. Hãy dùng [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) hoặc nén ảnh kèm loại bỏ vùng đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ và việc xóa các vùng đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ bản sao ảnh gốc bên ngoài bản trình chiếu nếu có thể cần chỉnh sửa độ phân giải cao sau này.

**Nên xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh các cast không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu shape trước khi sử dụng các thành viên đặc thù cho picture frame. Kiểm tra `instanceof` đối với [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) giúp tránh cast không hợp lệ và cho phép code xử lý các slide không chứa picture frame.