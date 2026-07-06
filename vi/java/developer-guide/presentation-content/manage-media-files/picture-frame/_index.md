---
title: Quản lý khung hình trong các bản trình bày bằng Java
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/java/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- thêm hình ảnh
- tạo hình ảnh
- trích xuất hình ảnh
- hình raster
- hình vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung hình
- thuộc tính khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khía cạnh
- độ trong suốt hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: Thêm khung hình vào các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Tối ưu hoá quy trình làm việc của bạn và nâng cao thiết kế slide.
---
## **Giới thiệu**

Khung hình là một hình dạng chứa một hình ảnh — nó giống như một bức tranh trong khung.  

Bạn có thể thêm hình ảnh vào một slide thông qua khung hình. Bằng cách này, bạn sẽ định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bản trình bày nhanh chóng từ hình ảnh. 

{{% /alert %}} 

## **Tạo một Khung Hình**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu đến slide qua chỉ số của nó.  
3. Tạo một đối tượng [IPPImage]() bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImageCollection) được liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.  
4. Xác định chiều rộng và chiều cao của hình ảnh.  
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/PictureFrame) dựa trên chiều rộng và chiều cao của ảnh thông qua phương thức `AddPictureFrame` được cung cấp bởi đối tượng shape được liên kết với slide đã tham chiếu.  
6. Thêm khung hình (chứa ảnh) vào slide.  
7. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.  

Mã Java dưới đây cho thấy cách tạo một khung hình:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
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

{{% alert color="warning" %}} 

Khung hình cho phép bạn nhanh chóng tạo các slide trình bày dựa trên hình ảnh. Khi kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác các hoạt động nhập/xuất để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Bạn có thể tham khảo các trang này: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/java/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/java/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/java/conversion/jpg-to-png/), chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/java/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/java/conversion/png-to-svg/), chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/java/conversion/svg-to-png/). 

{{% /alert %}}

## **Tạo Khung Hình với Tỷ Lệ Tương Đối**

Bằng cách thay đổi tỷ lệ tương đối của hình ảnh, bạn có thể tạo một khung hình phức tạp hơn.  

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu đến slide qua chỉ số của nó.  
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của presentation.  
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImageCollection) được liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.  
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung hình.  
6. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.  

Mã Java dưới đây cho thấy cách tạo một khung hình với tỷ lệ tương đối:

```java
// Khởi tạo lớp Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Thêm Picture Frame với chiều cao và chiều rộng tương đương của Picture
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Đặt tỷ lệ tương đối cho chiều rộng và chiều cao
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Trích Xuất Hình Raster từ Khung Hình**

Bạn có thể trích xuất các hình raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/PictureFrame) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một ảnh từ tài liệu “sample.pptx” và lưu nó ở định dạng PNG.

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

## **Trích Xuất Hình SVG từ Khung Hình**

Khi một bản trình bày chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/), Aspose.Slides cho Java cho phép bạn lấy lại các hình ảnh vector gốc với độ chính xác đầy đủ. Bằng cách duyệt bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/), kiểm tra xem [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) nền có chứa nội dung SVG hay không, và sau đó lưu ảnh đó vào đĩa hoặc stream ở định dạng SVG gốc.  

Ví dụ mã dưới đây minh họa cách trích xuất một ảnh SVG từ khung hình:

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

## **Lấy Độ Trong Suốt của Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một ảnh. Mã Java dưới đây minh họa thao tác này:

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

## **Lấy Độ Sáng và Độ Tương Phản của Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng độ sáng và độ tương phản được áp dụng cho một ảnh. Giao diện [ILuminance](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iluminance/) đại diện cho hiệu ứng biến đổi ảnh này.  

Mã Java dưới đây minh họa cách lấy các cài đặt độ sáng và độ tương phản từ một khung hình:

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

## **Định Dạng Khung Hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung hình. Sử dụng các tùy chọn này, bạn có thể điều chỉnh khung hình để đáp ứng các yêu cầu cụ thể.  

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu đến slide qua chỉ số của nó.  
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPPImage) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImageCollection) được liên kết với đối tượng presentation sẽ được dùng để lấp đầy hình dạng.  
4. Xác định chiều rộng và chiều cao của hình ảnh.  
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của ảnh thông qua phương thức [AddPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) được cung cấp bởi đối tượng [IShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection) liên kết với slide đã tham chiếu.  
6. Thêm khung hình (chứa ảnh) vào slide.  
7. Đặt màu đường viền cho khung hình.  
8. Đặt độ rộng đường viền cho khung hình.  
9. Xoay khung hình bằng cách đưa vào giá trị dương hoặc âm.  
   * Giá trị dương xoay ảnh theo chiều kim đồng hồ.  
   * Giá trị âm xoay ảnh ngược chiều kim đồng hồ.  
10. Thêm khung hình (chứa ảnh) vào slide.  
11. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.  

Mã Java dưới đây minh họa quy trình định dạng khung hình:

```java
// Khởi tạo lớp Presentation đại diện cho PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Khởi tạo lớp Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Thêm Picture Frame với chiều cao và chiều rộng tương đương của Picture
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

Aspose gần đây đã phát triển một [free Collage Maker](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [gộp JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc ảnh PNG, [tạo lưới từ ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 

{{% /alert %}}

## **Thêm Ảnh dưới Dạng Liên Kết**

Để tránh kích thước bản trình bày quá lớn, bạn có thể thêm ảnh (hoặc video) dưới dạng liên kết thay vì nhúng tệp trực tiếp vào bản trình bày. Mã Java dưới đây cho thấy cách thêm ảnh và video vào một placeholder:

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

## **Cắt Ảnh**

Mã Java dưới đây cho thấy cách cắt một ảnh hiện có trên slide:

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

    // Cắt ảnh (giá trị phần trăm)
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

## **Xóa Các Vùng Đã Cắt của Khung Hình**

Nếu bạn muốn xóa các vùng đã cắt của một ảnh có trong khung, bạn có thể sử dụng phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Phương thức này trả về ảnh đã cắt hoặc ảnh gốc nếu không cần cắt.  

Mã Java dưới đây minh họa thao tác này:

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

{{% alert title="NOTE" color="warning" %}} 

Phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) thêm ảnh đã cắt vào bộ sưu tập hình ảnh của presentation. Nếu ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/) đã xử lý, cách thiết lập này có thể giảm kích thước bản trình bày. Ngược lại, số lượng ảnh trong bản trình bày kết quả sẽ tăng.  

Phương thức này chuyển đổi các tệp WMF/EMF sang ảnh raster PNG trong quá trình cắt. 

{{% /alert %}}

## **Nén Ảnh**

Bạn có thể nén một ảnh trong bản trình bày bằng phương thức [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Phương thức này nén ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải đã chỉ định, với tùy chọn xóa các vùng đã cắt.  

Nó điều chỉnh kích thước và độ phân giải của ảnh tương tự như tính năng **Picture Format -> Compress Pictures -> Resolution** của PowerPoint.  

Các ví dụ Java dưới đây minh họa cách nén ảnh trong bản trình bày bằng cách chỉ định độ phân giải mục tiêu và tùy chọn xóa các vùng đã cắt:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Nén ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải Web) và xóa các vùng đã cắt.
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

Hoặc sử dụng trực tiếp giá trị DPI tùy chỉnh:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Nén ảnh tới 150 DPI (độ phân giải web), xóa các vùng đã cắt.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Phương thức chuyển đổi ảnh sang độ phân giải thấp hơn dựa trên kích thước của hình dạng và DPI cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.  
Nếu ảnh là tệp metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ dựa trên độ phân giải, tương tự như cách PowerPoint xử lý JPEG độ phân giải cao.

{{% /alert %}}

## **Khóa Tỷ Lệ Khung Hình**

Nếu bạn muốn một hình dạng chứa ảnh giữ nguyên tỷ lệ khung ngay cả khi thay đổi kích thước ảnh, bạn có thể sử dụng phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) để đặt cài đặt *Lock Aspect Ratio*.  

Mã Java dưới đây cho thấy cách khóa tỷ lệ khung hình:

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

    // đặt hình dạng để giữ tỷ lệ khía cạnh khi thay đổi kích thước
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Cài đặt *Lock Aspect Ratio* này chỉ giữ nguyên tỷ lệ của hình dạng chứ không phải của ảnh bên trong. 

{{% /alert %}}

## **Sử Dụng Thuộc Tính StretchOff**

Bằng cách sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPictureFillFormat) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPictureFillFormat), bạn có thể xác định một hình chữ nhật lấp đầy.  

Khi chỉ định kéo dài cho một ảnh, một hình chữ nhật nguồn sẽ được cân tỷ lệ để vừa với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được định nghĩa bằng phần trăm độ lệch so với cạnh tương ứng của hộp giới hạn của hình dạng. Phần trăm dương chỉ ra chèn vào trong khi phần trăm âm chỉ ra mở rộng ra ngoài.  

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu đến slide qua chỉ số của nó.  
3. Thêm một hình chữ nhật `AutoShape`.  
4. Tạo một ảnh.  
5. Đặt loại lấp đầy cho hình dạng.  
6. Đặt chế độ lấp đầy ảnh cho hình dạng.  
7. Thêm ảnh đã đặt để lấp đầy hình dạng.  
8. Xác định độ lệch ảnh từ cạnh tương ứng của hộp giới hạn hình dạng.  
9. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.  

Mã Java dưới đây minh họa quy trình sử dụng thuộc tính StretchOff:

```java
// Khởi tạo lớp Presentation đại diện cho một tệp PPTX
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

    // Thêm một AutoShape dạng Hình chữ nhật
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Đặt loại lấp đầy cho hình dạng
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Đặt chế độ lấp đầy ảnh cho hình dạng
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Đặt ảnh để lấp đầy hình dạng
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Xác định độ lệch của ảnh từ cạnh tương ứng của hộp giới hạn hình dạng
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

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết những định dạng ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và ảnh vector (ví dụ, SVG) thông qua đối tượng ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng với khả năng của động cơ chuyển đổi slide và ảnh.

**Việc thêm hàng chục ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu năng của PPTX?**

Nhúng ảnh lớn làm tăng kích thước tệp và sử dụng bộ nhớ; liên kết ảnh giúp giữ kích thước bản trình bày nhỏ hơn nhưng yêu cầu các tệp bên ngoài vẫn có thể truy cập được. Aspose.Slides cung cấp khả năng thêm ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao tôi khóa một đối tượng ảnh để tránh việc di chuyển/đổi kích thước vô tình?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) cho một [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá di chuyển hoặc thay đổi kích thước). Cơ chế khóa được mô tả cho các hình dạng trong một [bài viết bảo vệ](/slides/vi/java/applying-protection-to-presentation/) riêng và được hỗ trợ cho nhiều loại hình dạng, bao gồm [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/).

**Độ trung thực của vector SVG có được giữ nguyên khi xuất bản trình bày sang PDF/ảnh không?**

Aspose.Slides cho phép trích xuất một SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [xuất sang PDF](/slides/vi/java/convert-powerpoint-to-pdf/) hoặc [định dạng raster](/slides/vi/java/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; thực tế rằng SVG gốc được lưu dưới dạng vector được xác nhận bằng hành vi trích xuất.