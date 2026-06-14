---
title: Tối ưu hoá quản lý hình ảnh trong bài thuyết trình bằng Java
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/java/image/
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
- bài thuyết trình
- EMF
- SVG
- Java
- Aspose.Slides
description: "Tinh gọn quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho Java, tối ưu hiệu suất và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bài thuyết trình trở nên sinh động và thú vị hơn. Trong Microsoft PowerPoint, bạn có thể chèn hình ảnh từ tệp, internet hoặc các vị trí khác vào các slide. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trong bài thuyết trình của mình thông qua các phương pháp khác nhau. 

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các trình chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bài thuyết trình nhanh chóng từ hình ảnh. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Nếu bạn muốn thêm một hình ảnh dưới dạng đối tượng khung—đặc biệt nếu bạn dự định sử dụng các tùy chọn định dạng tiêu chuẩn để thay đổi kích thước, thêm hiệu ứng, v.v.—xem [Picture Frame](https://docs.aspose.com/slides/vi/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Bạn có thể thao tác các hoạt động nhập/xuất liên quan đến hình ảnh và bài thuyết trình PowerPoint để chuyển đổi một hình ảnh từ định dạng này sang định dạng khác. Xem các trang này: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/java/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/java/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/java/conversion/jpg-to-png/), chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/java/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/java/conversion/png-to-svg/), chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides hỗ trợ các thao tác với hình ảnh trong các định dạng phổ biến này: JPEG, PNG, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Được Lưu Trên Máy Tính Vào Các Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh trên máy tính của mình vào một slide trong bài thuyết trình. Đoạn mã mẫu này bằng Java cho thấy cách thêm hình ảnh vào slide:

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

## **Thêm Hình Ảnh Từ Web Vào Các Slide**

Nếu hình ảnh bạn muốn thêm vào slide không có trên máy tính, bạn có thể thêm hình ảnh trực tiếp từ web. 

Đoạn mã mẫu này cho thấy cách thêm hình ảnh từ web vào slide trong Java:

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

Slide master là slide chính lưu trữ và kiểm soát thông tin (chủ đề, bố cục, v.v.) về tất cả các slide dưới nó. Vì vậy, khi bạn thêm một hình ảnh vào slide master, hình ảnh đó sẽ xuất hiện trên mọi slide dưới slide master đó. 

Đoạn mã mẫu Java này cho thấy cách thêm hình ảnh vào slide master:

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

Bạn có thể quyết định sử dụng một bức tranh làm nền cho một slide cụ thể hoặc nhiều slide. Trong trường hợp đó, bạn cần xem *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/vi/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bài Thuyết Trình**
Bạn có thể thêm hoặc chèn bất kỳ hình ảnh nào vào bài thuyết trình bằng cách sử dụng phương thức [addPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) thuộc giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection). 

Để tạo một đối tượng hình ảnh dựa trên ảnh SVG, bạn có thể thực hiện như sau:

1. Tạo đối tượng SvgImage để chèn vào ImageShapeCollection
2. Tạo đối tượng PPImage từ ISvgImage
3. Tạo đối tượng PictureFrame sử dụng giao diện IPPImage

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

## **Chuyển Đổi SVG Thành Bộ Hình Dạng**
Việc chuyển đổi SVG thành một tập hợp các hình dạng của Aspose.Slides tương tự như chức năng của PowerPoint dùng để làm việc với hình ảnh SVG:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một trong các overload của phương thức [addGroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) của giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection) nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISvgImage) làm đối số đầu tiên.

Đoạn mã mẫu này cho thấy cách sử dụng phương thức đã mô tả để chuyển đổi tệp SVG thành một tập hợp các hình dạng:

```java 
// Tạo bài thuyết trình mới
IPresentation presentation = new Presentation();
try {
    // Đọc nội dung tệp SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Tạo đối tượng SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Lấy kích thước slide
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Chuyển đổi hình ảnh SVG thành nhóm hình dạng và co giãn nó theo kích thước slide
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Lưu bài thuyết trình ở định dạng PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**
Aspose.Slides cho Java cho phép bạn tạo hình ảnh EMF từ các bảng tính Excel và thêm các hình ảnh dưới dạng EMF vào slide bằng Aspose.Cells. 

Đoạn mã mẫu này cho thấy cách thực hiện nhiệm vụ đã mô tả:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Lưu workbook vào luồng
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

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của bài thuyết trình (bao gồm những hình ảnh được sử dụng bởi các hình dạng slide). Phần này trình bày một số cách tiếp cận để cập nhật hình ảnh trong bộ sưu tập. API cung cấp các phương thức đơn giản để thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện của [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/), hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

1. Tải tệp bài thuyết trình chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
1. Tải một hình ảnh mới từ tệp vào một mảng byte.
1. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.
1. Trong cách thứ hai, tải hình ảnh vào một đối tượng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.
1. Trong cách thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bài thuyết trình.
1. Ghi bài thuyết trình đã sửa đổi dưới dạng tệp PPTX.

```java
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Cách thứ nhất.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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
    
    // Lưu bài thuyết trình vào tệp.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Sử dụng trình chuyển đổi Aspose FREE [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif), bạn có thể dễ dàng tạo hoạt hình cho văn bản, tạo GIF từ văn bản, v.v. 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Độ phân giải gốc của hình ảnh có giữ nguyên sau khi chèn không?**

Có. Các pixel nguồn được giữ nguyên, nhưng diện mạo cuối cùng phụ thuộc vào cách mà [picture](/slides/vi/java/picture-frame/) được co giãn trên slide và bất kỳ việc nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide cùng một lúc là gì?**

Đặt logo trên master slide hoặc một layout và thay thế nó trong bộ sưu tập hình ảnh của bài thuyết trình—các cập nhật sẽ lan tới tất cả các yếu tố sử dụng tài nguyên đó.

**Hình SVG đã chèn có thể được chuyển đổi thành các hình dạng có thể chỉnh sửa không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó từng phần sẽ có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.

**Làm sao để đặt một bức tranh làm nền cho nhiều slide cùng một lúc?**

[Gán hình ảnh làm nền](/slides/vi/java/presentation-background/) trên master slide hoặc layout liên quan—bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.

**Làm sao để ngăn bài thuyết trình "phình to" kích thước do quá nhiều hình ảnh?**

Sử dụng lại một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu và giữ các đồ họa lặp lại trên master khi cần.