---
title: Quản lý Khung Hình trong Bản Thuyết Trình trên Android
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/androidjava/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- thêm hình ảnh
- tạo hình ảnh
- trich xuất hình ảnh
- hình ảnh raster
- hình ảnh vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung hình
- thuộc tính khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- độ trong suốt của hình ảnh
- PowerPoint
- OpenDocument
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Thêm khung hình vào các bản thuyết trình PowerPoint và OpenDocument với Aspose.Slides cho Android qua Java. Tinh giản quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa hình ảnh—nó giống như một bức tranh trong khung.

Bạn có thể thêm hình ảnh vào một slide thông qua khung hình. Bằng cách này, bạn định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert  title="Tip" color="info" %}} 
Aspose cung cấp các trình chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bản thuyết trình nhanh chóng từ hình ảnh. 
{{% /alert %}} 

## **Create a Picture Frame**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage]() bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PictureFrame) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `AddPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide được tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Ghi bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Thêm khung hình với độ rộng và chiều cao tương đương của hình ảnh
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ghi tệp PPTX vào đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create a Picture Frame with Relative Scale**

Bằng cách thay đổi tỷ lệ tương đối của hình ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của presentation.
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung hình.
6. Ghi bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Khởi tạo lớp Presentation đại diện cho file PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Thêm Picture Frame với chiều cao và chiều rộng tương đương với hình ảnh
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Đặt tỷ lệ chiều cao và chiều rộng tương đối
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Ghi tệp PPTX vào đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extract Raster Images from Picture Frames**

Bạn có thể trích xuất hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PictureFrame) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu “sample.pptx” và lưu nó ở định dạng PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extract SVG Images from Picture Frames**

Khi một bản thuyết trình chứa đồ họa SVG được đặt trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) , Aspose.Slides for Android via Java cho phép bạn lấy lại các hình ảnh vector gốc với độ trung thực đầy đủ. Khi bạn có một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) có [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) chứa nội dung SVG, bạn có thể đọc hình ảnh SVG đó và lưu nó vào đĩa hoặc stream ở định dạng SVG gốc.

Mã dưới đây minh họa cách trích xuất một hình ảnh SVG từ khung hình:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Get Transparency of an Image**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Đoạn mã Java này minh họa thao tác:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Get Brightness and Contrast of an Image**

Aspose.Slides cho phép bạn lấy độ sáng và độ tương phản được áp dụng cho một hình ảnh. Giao diện [ILuminance](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iluminance/) đại diện cho hiệu ứng biến đổi này.

Đoạn mã Java dưới đây minh họa cách lấy các thiết lập độ sáng và độ tương phản từ một khung hình:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Picture Frame Formatting**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung hình. Bằng các tùy chọn này, bạn có thể điều chỉnh khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [AddPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) được cung cấp bởi đối tượng [IShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection) liên kết với slide được tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Đặt màu đường viền cho khung hình.
8. Đặt độ rộng đường viền cho khung hình.
9. Xoay khung hình bằng cách cung cấp một giá trị dương hoặc âm.
   * Giá trị dương sẽ xoay hình ảnh theo chiều kim đồng hồ. 
   * Giá trị âm sẽ xoay hình ảnh ngược chiều kim đồng hồ.
10. Thêm khung hình (chứa hình ảnh) vào slide.
11. Ghi bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Khởi tạo lớp Presentation đại diện cho file PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Thêm Picture Frame với chiều cao và chiều rộng tương đương với hình ảnh
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Áp dụng một số định dạng cho PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Ghi file PPTX vào đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose gần đây đã phát triển một công cụ [free Collage Maker](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [merge JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, hoặc [create grids from photos](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 
{{% /alert %}}

## **Add an Image as a Link**

Để tránh kích thước bản thuyết trình quá lớn, bạn có thể thêm hình ảnh (hoặc video) thông qua liên kết thay vì nhúng tệp trực tiếp vào bản thuyết trình. Đoạn mã Java này cho thấy cách thêm hình ảnh và video vào một placeholder:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Crop Images**

Đoạn mã Java này minh họa cách cắt một hình ảnh đã tồn tại trên slide:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// Tạo đối tượng hình ảnh mới
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Thêm PictureFrame vào Slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Cắt hình ảnh (giá trị phần trăm)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Lưu kết quả
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Delete Cropped Areas of a Picture**

Nếu bạn muốn xóa các vùng đã cắt của hình ảnh chứa trong khung, bạn có thể sử dụng phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu việc cắt không cần thiết.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lấy PictureFrame từ slide đầu tiên
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Xóa các vùng đã cắt của hình ảnh PictureFrame và trả về hình ảnh đã cắt
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Lưu kết quả
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) sẽ thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của presentation. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) đã xử lý, cách thiết lập này có thể giảm kích thước bản thuyết trình. Ngược lại, số lượng hình ảnh trong bản thuyết trình kết quả sẽ tăng.

Phương thức này chuyển đổi các metafile WMF/EMF sang hình ảnh raster PNG trong quá trình cắt. 
{{% /alert %}}

## **Compress Images**

Bạn có thể nén một hình ảnh trong bản thuyết trình bằng phương thức [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) .
Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải đã chỉ định, với tùy chọn xóa các khu vực đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format > Compress Pictures > Resolution** của PowerPoint.

Các ví dụ Java sau đây minh họa cách nén một hình ảnh trong bản thuyết trình bằng cách chỉ định độ phân giải mục tiêu và tùy chọn loại bỏ các khu vực đã cắt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Nén hình ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải Web) và xóa các vùng đã cắt.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Kiểm tra kết quả của việc nén.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hoặc sử dụng trực tiếp một giá trị DPI tùy chỉnh:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Nén hình ảnh tới 150 DPI (độ phân giải web), xóa các vùng đã cắt.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Phương thức chuyển đổi hình ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.  
Nếu hình ảnh là metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ tùy theo độ phân giải, giống như cách PowerPoint xử lý JPEG độ phân giải cao. 
{{% /alert %}}

## **Lock Aspect Ratio**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ nguyên tỷ lệ khung hình ngay cả khi thay đổi kích thước ảnh, bạn có thể sử dụng phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) để bật cài đặt *Lock Aspect Ratio*.

Đoạn mã Java này cho thấy cách khóa tỷ lệ khung hình của một hình dạng:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // đặt hình dạng để bảo toàn tỷ lệ khung hình khi thay đổi kích thước
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Cài đặt *Lock Aspect Ratio* này chỉ bảo tồn tỷ lệ của hình dạng chứ không phải của hình ảnh bên trong. 
{{% /alert %}}

## **Use the StretchOff Property**

Bằng cách sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat), bạn có thể chỉ định một hình chữ nhật lấp đầy.

Khi kéo dài được chỉ định cho một hình ảnh, một hình chữ nhật nguồn sẽ được tỷ lệ để vừa khớp với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được xác định bằng phần trăm offset so với cạnh tương ứng của khung bao hình dạng. Phần trăm dương chỉ nội suy, phần trăm âm chỉ ngoại suy.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh.
5. Đặt kiểu lấp đầy cho hình dạng.
6. Đặt chế độ lấp đầy hình ảnh cho hình dạng.
7. Thêm một hình ảnh đã đặt để lấp đầy hình dạng.
8. Xác định offset của hình ảnh so với các cạnh tương ứng của khung bao hình dạng.
9. Ghi bản thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);

    // Khởi tạo lớp ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Thêm AutoShape dạng Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Đặt kiểu lấp đầy cho hình dạng
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ lấp đầy hình ảnh cho hình dạng
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Đặt hình ảnh để lấp đầy hình dạng
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Xác định khoảng cách offset của hình ảnh từ các cạnh tương ứng của hộp bao của hình dạng
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // Ghi tệp PPTX vào đĩa
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

### Làm thế nào để tôi biết định dạng hình ảnh nào được hỗ trợ cho PictureFrame?

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của công cụ chuyển đổi slide và hình ảnh.

### Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu năng của PPTX?

Nhúng hình ảnh lớn làm tăng kích thước tệp và sử dụng bộ nhớ; liên kết hình ảnh giúp giảm kích thước bản thuyết trình nhưng yêu cầu các tệp ngoại vi phải luôn có sẵn. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

### Làm sao tôi có thể khóa đối tượng hình ảnh tránh việc di chuyển hoặc thay đổi kích thước vô tình?

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) cho một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá di chuyển hoặc thay đổi kích thước). Cơ chế khóa này được hỗ trợ cho nhiều loại hình dạng, bao gồm cả [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/).

### Độ trung thực vector SVG có được bảo tồn khi xuất bản thuyết trình ra PDF/hình ảnh không?

Aspose.Slides cho phép trích xuất SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [exporting to PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) hoặc [raster formats](/slides/vi/androidjava/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; việc SVG gốc được lưu trữ dưới dạng vector được xác nhận bằng hành vi trích xuất.