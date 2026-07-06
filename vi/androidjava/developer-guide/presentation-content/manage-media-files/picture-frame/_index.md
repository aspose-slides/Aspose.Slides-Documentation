---
title: Quản lý Khung Ảnh trong Bản trình bày trên Android
linktitle: Khung Ảnh
type: docs
weight: 10
url: /vi/androidjava/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- thêm hình ảnh
- tạo hình ảnh
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung ảnh
- thuộc tính khung ảnh
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- trong suốt hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Thêm khung ảnh vào các bản trình bày PowerPoint và OpenDocument với Aspose.Slides cho Android qua Java. Tinh giản quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung ảnh là một hình dạng chứa một hình ảnh—giống như một bức tranh trong khung.

Bạn có thể thêm hình ảnh vào một slide thông qua khung ảnh. Bằng cách này, bạn định dạng hình ảnh bằng cách định dạng khung ảnh.

{{% alert  title="Tip" color="primary" %}} 
Aspose cung cấp các trình chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo nhanh bản trình bày từ hình ảnh. 
{{% /alert %}} 

## **Tạo Khung Ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage]() bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PictureFrame) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `AddPictureFrame` được công bố bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm một khung ảnh (chứa ảnh) vào slide.
7. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java này cho thấy cách tạo một khung ảnh:

```java
// Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tạo một thể hiện của lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Thêm một khung ảnh với chiều cao và chiều rộng tương đương của hình ảnh
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo Khung Ảnh Với Tỷ Lệ Tương Đối**

Bằng cách thay đổi tỷ lệ tương đối của hình ảnh, bạn có thể tạo một khung ảnh phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của presentation.
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung ảnh.
6. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java này cho thấy cách tạo khung ảnh với tỷ lệ tương đối:

```java
// Tạo thể hiện của lớp Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tạo thể hiện của lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Thêm khung ảnh với chiều cao và chiều rộng tương đương của hình ảnh
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Đặt tỷ lệ tương đối cho chiều cao và chiều rộng
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Trích Xuất Hình Ảnh Raster Từ Khung Ảnh**

Bạn có thể trích xuất hình ảnh raster từ [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PictureFrame) và lưu chúng ở định dạng PNG, JPG và các định dạng khác. Đoạn mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu "sample.pptx" và lưu nó ở định dạng PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Trích Xuất Hình Ảnh SVG Từ Khung Ảnh**

Khi một bản trình bày chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides cho Android qua Java cho phép bạn lấy lại các hình ảnh vector gốc với độ trung thực đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/), kiểm tra xem [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) nền tảng có chứa nội dung SVG hay không, và sau đó lưu hình ảnh đó ra đĩa hoặc luồng ở định dạng SVG gốc.

Đoạn mã sau minh họa cách trích xuất một hình ảnh SVG từ một khung ảnh:

```java
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

## **Lấy Độ Trong Suốt Của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Mã Java này minh họa thao tác:

```java
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

## **Lấy Độ Sáng và Độ Tương Phản Của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng độ sáng và độ tương phản được áp dụng cho một hình ảnh. Giao diện [ILuminance](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iluminance/) đại diện cho hiệu ứng chuyển đổi hình ảnh này.

Mã Java này minh họa cách lấy cài đặt độ sáng và độ tương phản từ một khung ảnh:

```java
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

## **Định Dạng Khung Ảnh**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung ảnh. Sử dụng các tùy chọn này, bạn có thể thay đổi khung ảnh để phù hợp với yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [AddPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) được công bố bởi đối tượng [IShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection) liên kết với slide đã tham chiếu.
6. Thêm khung ảnh (chứa ảnh) vào slide.
7. Đặt màu đường viền cho khung ảnh.
8. Đặt độ rộng đường viền cho khung ảnh.
9. Xoay khung ảnh bằng cách đưa vào giá trị dương hoặc âm.
   * Giá trị dương xoay hình ảnh theo chiều kim đồng hồ. 
   * Giá trị âm xoay hình ảnh ngược chiều kim đồng hồ.
10. Thêm khung ảnh (chứa ảnh) vào slide.
11. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java này minh họa quy trình định dạng khung ảnh:

```java
// Tạo một thể hiện của lớp Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tạo một thể hiện của lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Thêm khung ảnh với chiều cao và chiều rộng tương đương của hình ảnh
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Áp dụng một số định dạng cho PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose gần đây đã phát triển một công cụ [free Collage Maker](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [merge JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, [create grids from photos](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 
{{% /alert %}}

## **Thêm Hình Ảnh Là Liên Kết**

Để tránh kích thước bản trình bày lớn, bạn có thể thêm hình ảnh (hoặc video) qua liên kết thay vì nhúng tệp trực tiếp vào bản trình bày. Mã Java này cho thấy cách thêm hình ảnh và video vào một placeholder:

```java
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

## **Cắt Hình Ảnh**

Mã Java này cho thấy cách cắt một hình ảnh hiện có trên slide:

```java
Presentation pres = new Presentation();
// Tạo đối tượng hình ảnh mới
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Thêm một PictureFrame vào Slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Cắt hình ảnh (giá trị phần trăm)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Lưu kết quả
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa Các Vùng Đã Cắt Của Hình Ảnh**

Nếu bạn muốn xóa các vùng đã cắt của hình ảnh chứa trong khung, bạn có thể sử dụng phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Phương thức này trả về hình đã cắt hoặc hình gốc nếu không cần cắt.

Mã Java này minh họa thao tác:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lấy PictureFrame từ slide đầu tiên
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Xóa các vùng đã cắt của hình ảnh trong PictureFrame và trả về hình ảnh đã cắt
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Lưu kết quả
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) thêm hình đã cắt vào bộ sưu tập hình ảnh của bản trình bày. Nếu hình chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) đã xử lý, cấu hình này có thể giảm kích thước bản trình bày. Ngược lại, số lượng hình ảnh trong bản trình bày kết quả sẽ tăng.

Phương thức này chuyển đổi các metafile WMF/EMF thành hình ảnh PNG raster trong quá trình cắt. 
{{% /alert %}}

## **Nén Hình Ảnh**

Bạn có thể nén một hình ảnh trong bản trình bày bằng phương thức [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) .
Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các vùng đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình tương tự như tính năng **Picture Format > Compress Pictures > Resolution** của PowerPoint.

Các ví dụ Java sau đây minh họa cách nén hình ảnh trong bản trình bày bằng cách chỉ định độ phân giải mục tiêu và tùy chọn loại bỏ các khu vực đã cắt:

```java
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

Hoặc sử dụng giá trị DPI tùy chỉnh trực tiếp:

```java
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
Phương thức chuyển đổi hình ảnh thành độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.  
Nếu hình ảnh là metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ dựa trên độ phân giải, tương tự như cách PowerPoint xử lý JPEG độ phân giải cao. 
{{% /alert %}}

## **Khóa Tỷ Lệ Khung Hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ nguyên tỷ lệ khung hình ngay cả khi thay đổi kích thước hình ảnh, bạn có thể sử dụng phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) để đặt cài đặt *Lock Aspect Ratio*.

Mã Java này cho thấy cách khóa tỷ lệ khung hình của một shape:

```java
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
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // đặt shape để giữ tỷ lệ khung hình khi thay đổi kích thước
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Cài đặt *Lock Aspect Ratio* này chỉ bảo tồn tỷ lệ khung hình của shape mà không bảo tồn hình ảnh bên trong. 
{{% /alert %}}

## **Sử Dụng Thuộc Tính StretchOff**

Bằng cách sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat), bạn có thể chỉ định một hình chữ nhật lấp đầy.

Khi kéo dài được chỉ định cho một hình ảnh, một hình chữ nhật nguồn sẽ được thu phóng để vừa với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được định nghĩa bằng phần trăm độ lệch so với cạnh tương ứng của hộp bao shape. Phần trăm dương chỉ ra một inset, trong khi phần trăm âm chỉ ra một outset.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh.
5. Đặt loại fill cho shape.
6. Đặt chế độ fill hình ảnh cho shape.
7. Thêm hình ảnh đã đặt để lấp đầy shape.
8. Xác định độ lệch hình ảnh từ cạnh tương ứng của hộp bao shape
9. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Java này minh họa quy trình sử dụng thuộc tính StretchOff:

```java
// Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);

    // Tạo một thể hiện của lớp ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Thêm một AutoShape dạng Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Đặt kiểu fill cho shape
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ fill hình ảnh cho shape
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Đặt hình ảnh để lấp đầy shape
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Xác định độ lệch hình ảnh so với các cạnh tương ứng của hộp bao shape
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Ghi tệp PPTX ra đĩa
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Làm thế nào tôi có thể biết các định dạng hình ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của engine chuyển đổi slide và hình ảnh.

**Thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào tới kích thước và hiệu năng của PPTX?**

Nhúng hình ảnh lớn làm tăng kích thước tệp và tiêu thụ bộ nhớ; liên kết hình ảnh giúp giảm kích thước bản trình bày nhưng yêu cầu các tệp ngoại vi phải luôn có sẵn. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao tôi có thể khóa đối tượng hình ảnh để tránh việc di chuyển/thay đổi kích thước không mong muốn?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) cho một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá việc di chuyển hoặc thay đổi kích thước). Cơ chế khóa được hỗ trợ cho nhiều loại shape, bao gồm cả [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/).

**Độ trung thực vector SVG có được bảo tồn khi xuất bản trình bày sang PDF/hình ảnh không?**

Aspose.Slides cho phép trích xuất SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [exporting to PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) hoặc [raster formats](/slides/vi/androidjava/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; thực tế rằng SVG gốc được lưu dưới dạng vector được xác nhận bằng hành vi trích xuất.