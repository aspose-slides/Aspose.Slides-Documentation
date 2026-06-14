---
title: Tối ưu hóa quản lý hình ảnh trong bản trình bày trên Android
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/androidjava/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thêm bitmap
- thay thế hình ảnh
- thay thế ảnh
- từ web
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- thêm EMF
- thêm WMF
- thêm TIFF
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Đơn giản hóa quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho Android qua Java, tối ưu hiệu suất và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bản trình bày trở nên sống động và thú vị hơn. Trong Microsoft PowerPoint, bạn có thể chèn ảnh từ tệp, internet hoặc các vị trí khác vào các slide. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trong bản trình bày của mình thông qua các phương thức khác nhau. 

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bản trình bày nhanh chóng từ hình ảnh. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Nếu bạn muốn thêm một hình ảnh dưới dạng đối tượng khung—đặc biệt nếu bạn dự định sử dụng các tùy chọn định dạng tiêu chuẩn để thay đổi kích thước, thêm hiệu ứng, v.v.—xem [Picture Frame](https://docs.aspose.com/slides/vi/androidjava/picture-frame/). 

{{% /alert %}} 

Aspose.Slides hỗ trợ các thao tác với hình ảnh trong các định dạng phổ biến này: JPEG, PNG, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Lưu Trữ Cục Bộ Vào Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh từ máy tính của mình vào một slide trong bản trình bày. Đoạn mã mẫu này bằng Java cho bạn thấy cách thêm hình ảnh vào slide:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Thêm Hình Ảnh Từ Web Vào Slide**

Nếu hình ảnh bạn muốn thêm vào slide không có trên máy tính của bạn, bạn có thể thêm hình ảnh trực tiếp từ web. 

Đoạn mã mẫu này cho bạn thấy cách thêm hình ảnh từ web vào slide bằng Java:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master là slide cấp cao nhất lưu trữ và kiểm soát thông tin (chủ đề, bố cục, v.v.) của tất cả các slide dưới nó. Vì vậy, khi bạn thêm một hình ảnh vào slide master, hình ảnh đó sẽ xuất hiện trên mọi slide dưới slide master đó. 

Đoạn mã mẫu Java này cho bạn thấy cách thêm hình ảnh vào slide master:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Thêm Hình Ảnh Là Nền Cho Slide**

Bạn có thể quyết định sử dụng một bức ảnh làm nền cho một slide cụ thể hoặc nhiều slide. Trong trường hợp đó, bạn nên xem *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/vi/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bản Trình Bày**

Bạn có thể thêm hoặc chèn bất kỳ hình ảnh nào vào bản trình bày bằng cách sử dụng phương thức [addPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) thuộc giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection). 

Để tạo một đối tượng hình ảnh dựa trên hình ảnh SVG, bạn có thể thực hiện như sau:

1. Tạo đối tượng SvgImage để chèn vào ImageShapeCollection
2. Tạo đối tượng PPImage từ ISvgImage
3. Tạo đối tượng PictureFrame bằng giao diện IPPImage

```java 
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chuyển Đổi SVG Sang Tập Hình Dạng**

Việc chuyển đổi SVG sang một tập hợp các hình dạng của Aspose.Slides tương tự như chức năng trong PowerPoint được sử dụng để làm việc với hình ảnh SVG:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một trong các overload của phương thức [addGroupShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) của giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection), phương thức này nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISvgImage) làm đối số đầu tiên.

Đoạn mã mẫu này cho bạn thấy cách sử dụng phương pháp đã mô tả để chuyển đổi tệp SVG thành một tập hợp các hình dạng:

```java 
// Tạo bản trình bày mới
IPresentation presentation = new Presentation();
try {
    // Đọc nội dung tệp SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Tạo đối tượng SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Lấy kích thước slide
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Chuyển đổi hình ảnh SVG thành nhóm các hình dạng, điều chỉnh kích thước theo slide
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Lưu bản trình bày dưới dạng PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**

Aspose.Slides cho Android qua Java cho phép bạn tạo hình ảnh EMF từ các bảng tính Excel và thêm các hình ảnh dưới dạng EMF vào slide bằng Aspose.Cells.  

```java 
// Lưu workbook vào luồng
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Save the workbook to stream
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh lưu trong bộ sưu tập hình ảnh của một bản trình bày (bao gồm những hình ảnh được sử dụng bởi các hình dạng slide). Phần này trình bày một số cách tiếp cận để cập nhật hình ảnh trong bộ sưu tập. API cung cấp các phương pháp đơn giản để thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/), hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

1. Tải tệp bản trình bày chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Tải một hình ảnh mới từ tệp vào một mảng byte.
3. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.
4. Trong cách tiếp cận thứ hai, tải hình ảnh vào một đối tượng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.
5. Trong cách tiếp cận thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bản trình bày.
6. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```java
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Cách thứ nhất.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Cách thứ hai.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Cách thứ ba.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Lưu bản trình bày vào tệp.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Sử dụng bộ chuyển đổi Aspose FREE [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif), bạn có thể dễ dàng tạo hoạt ảnh cho văn bản, tạo GIF từ văn bản, v.v. 

{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

**Does the original image resolution remain intact after insertion?**

Có. Các pixel gốc được bảo toàn, nhưng ngoại hình cuối cùng phụ thuộc vào cách [picture](/slides/vi/androidjava/picture-frame/) được thu phóng trên slide và bất kỳ áp dụng nén nào khi lưu.

**What’s the best way to replace the same logo across dozens of slides at once?**

Đặt logo trên slide master hoặc một layout và thay thế nó trong bộ sưu tập hình ảnh của bản trình bày—các cập nhật sẽ lan tới tất cả các thành phần sử dụng tài nguyên đó.

**Can an inserted SVG be converted into editable shapes?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó các phần riêng lẻ có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.

**How can I set a picture as the background for multiple slides at once?**

[Assign the image as the background](/slides/vi/androidjava/presentation-background/) trên slide master hoặc layout liên quan—bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.

**How do I prevent the presentation from "ballooning" in size because of many pictures?**

Sử dụng lại một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các đồ họa lặp lại trên master khi cần.