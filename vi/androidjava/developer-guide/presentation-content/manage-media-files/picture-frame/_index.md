---
title: Quản lý Khung Hình trong Bài Thuyết Trình trên Android
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
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung hình
- thuộc tính khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỉ lệ khung hình
- độ trong suốt của hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Thêm khung hình vào các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java. Tinh giản quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa hình ảnh — nó giống như một bức tranh trong khung.

Bạn có thể thêm hình ảnh vào một slide thông qua khung hình. Bằng cách này, bạn có thể định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert  title="Mẹo" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bài thuyết trình nhanh chóng từ hình ảnh. 

{{% /alert %}} 

## **Tạo khung hình**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage]() bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PictureFrame) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `AddPictureFrame` được khai báo bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm một khung hình (chứa hình ảnh) vào slide.
7. Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java sau đây cho bạn thấy cách tạo khung hình:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Thêm một khung hình với chiều cao và chiều rộng bằng với hình ảnh
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tạo khung hình với tỉ lệ tương đối**

Bằng cách thay đổi tỉ lệ tương đối của hình ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của presentation.
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung hình.
6. Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java sau đây cho bạn thấy cách tạo khung hình với tỉ lệ tương đối:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Thêm khung hình với chiều cao và chiều rộng bằng với hình ảnh
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Thiết lập tỉ lệ tương đối chiều cao và chiều rộng
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Trích xuất hình ảnh raster từ khung hình**

Bạn có thể trích xuất hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PictureFrame) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu "sample.pptx" và lưu nó ở định dạng PNG.

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

## **Trích xuất hình ảnh SVG từ khung hình**

Khi một bài thuyết trình chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides for Android qua Java cho phép bạn lấy lại các hình ảnh vector gốc với độ trung thực đầy đủ. Bằng cách duyệt bộ sưu tập hình dạng của slide, bạn có thể xác định mỗi [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/), kiểm tra xem [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) nền chứa nội dung SVG hay không, và sau đó lưu hình ảnh đó vào đĩa hoặc luồng ở định dạng SVG gốc.

Đoạn mã dưới đây minh họa cách trích xuất một hình ảnh SVG từ khung hình:

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

## **Lấy độ trong suốt của một hình ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Đoạn mã Java này minh họa thao tác:

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

## **Định dạng khung hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho khung hình. Sử dụng các tùy chọn này, bạn có thể thay đổi khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [AddPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) được khai báo bởi đối tượng [IShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection) liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Đặt màu đường viền cho khung hình.
8. Đặt độ rộng đường viền cho khung hình.
9. Xoay khung hình bằng cách cung cấp giá trị dương hoặc âm.
   * Giá trị dương sẽ xoay hình ảnh theo chiều kim đồng hồ. 
   * Giá trị âm sẽ xoay hình ảnh ngược chiều kim đồng hồ.
10. Thêm khung hình (chứa hình ảnh) vào slide.
11. Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này minh họa quá trình định dạng khung hình:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Thêm Khung Hình với chiều cao và chiều rộng tương đương với Hình ảnh
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

{{% alert title="LƯU Ý" color="primary" %}}

Aspose gần đây đã phát triển một công cụ [Collage Maker miễn phí](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [gộp các hình JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, hoặc [tạo lưới từ ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 

{{% /alert %}}

## **Thêm hình ảnh dưới dạng liên kết**

Để tránh tăng kích thước bài thuyết trình, bạn có thể thêm hình ảnh (hoặc video) thông qua liên kết thay vì nhúng tệp trực tiếp vào bài thuyết trình. Đoạn mã Java này cho bạn thấy cách thêm hình ảnh và video vào một placeholder:

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

## **Cắt ảnh**

Đoạn mã Java này cho bạn thấy cách cắt một hình ảnh hiện có trên slide:

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

## **Xóa các vùng đã cắt của khung hình**

Nếu bạn muốn xóa các vùng đã cắt của hình ảnh chứa trong khung, bạn có thể sử dụng phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu việc cắt không cần thiết.

Đoạn mã Java này minh họa thao tác:

```java
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

{{% alert title="LƯU Ý" color="warning" %}} 

Phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của presentation. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) đã xử lý, cách thiết lập này có thể giảm kích thước bài thuyết trình. Ngược lại, số lượng hình ảnh trong bài thuyết trình kết quả sẽ tăng.

Phương thức này chuyển đổi các tệp metafile WMF/EMF sang hình ảnh raster PNG trong quá trình cắt. 

{{% /alert %}}

## **Nén hình ảnh**

Bạn có thể nén một hình ảnh trong bài thuyết trình bằng phương thức [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các vùng đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format > Compress Pictures > Resolution** của PowerPoint.

Các ví dụ Java sau đây minh họa cách nén hình ảnh trong bài thuyết trình bằng cách chỉ định độ phân giải mục tiêu và tùy chọn xóa các vùng đã cắt:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Nén hình ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải Web) và xóa các vùng đã cắt.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Kiểm tra kết quả của quá trình nén.
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

{{% alert title="LƯU Ý" color="warning" %}} 

Phương thức chuyển đổi hình ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.  
Nếu hình ảnh là metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ hoặc giảm nhẹ dựa trên độ phân giải, tương tự như cách PowerPoint xử lý JPEG có độ phân giải cao.

{{% /alert %}}

## **Khóa tỉ lệ khung hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ tỉ lệ khung hình ngay cả khi thay đổi kích thước ảnh, bạn có thể sử dụng phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) để thiết lập tùy chọn *Lock Aspect Ratio*.

Đoạn mã Java này cho bạn thấy cách khóa tỉ lệ khung hình:

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

    // đặt hình dạng để giữ tỉ lệ khung hình khi thay đổi kích thước
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="LƯU Ý" color="warning" %}} 

Cài đặt *Lock Aspect Ratio* này chỉ bảo tồn tỉ lệ khung hình và không ảnh hưởng đến hình ảnh bên trong.

{{% /alert %}}

## **Sử dụng thuộc tính StretchOff**

Bằng cách sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPictureFillFormat), bạn có thể xác định một hình chữ nhật lấp đầy.

Khi được chỉ định kéo giãn cho một hình ảnh, một hình chữ nhật nguồn sẽ được tỷ lệ để vừa với hình chữ nhật lấp đầy đã xác định. Mỗi cạnh của hình chữ nhật lấp đầy được định nghĩa bằng phần trăm độ dịch chuyển từ cạnh tương ứng của hộp bao quanh hình dạng. Phần trăm dương chỉ xác định chèn vào trong khi phần trăm âm chỉ xác định mở rộng ra ngoài.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh.
5. Đặt kiểu lấp đầy cho hình dạng.
6. Đặt chế độ lấp đầy hình ảnh cho hình dạng.
7. Thêm một hình ảnh đã đặt để lấp đầy hình dạng.
8. Xác định độ dịch chuyển của hình ảnh từ cạnh tương ứng của hộp bao quanh hình dạng
9. Ghi bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Java này minh họa quy trình sử dụng thuộc tính StretchOff:

```java
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

    // Thêm một AutoShape dạng Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Đặt loại lấp đầy cho hình dạng
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ lấp đầy hình ảnh cho hình dạng
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Đặt hình ảnh để lấp đầy hình dạng
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Xác định độ dịch chuyển của hình ảnh từ cạnh tương ứng của hộp bao quanh hình dạng
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để tôi biết định dạng hình ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của engine chuyển đổi slide và hình ảnh.

**Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu năng của PPTX?**

Nhúng hình ảnh lớn làm tăng kích thước tệp và sử dụng bộ nhớ; liên kết hình ảnh giúp giữ kích thước bài thuyết trình nhỏ hơn nhưng yêu cầu các tệp bên ngoài phải luôn khả dụng. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao tôi có thể khóa đối tượng hình ảnh tránh bị di chuyển/đổi kích thước vô tình?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) cho một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá việc di chuyển hoặc đổi kích thước). Cơ chế khóa được hỗ trợ cho nhiều loại hình dạng, bao gồm [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/).

**Độ trung thực vector SVG có được giữ khi xuất bài thuyết trình sang PDF/hình ảnh không?**

Aspose.Slides cho phép trích xuất SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [xuất sang PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) hoặc [định dạng raster](/slides/vi/androidjava/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; việc SVG gốc được lưu dưới dạng vector được xác nhận qua hành vi trích xuất.