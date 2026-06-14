---
title: Quản lý Siêu liên kết trong Bản trình bày trên Android
linktitle: Quản lý Siêu liên kết
type: docs
weight: 20
url: /vi/androidjava/manage-hyperlinks/
keywords:
- Thêm URL
- Thêm siêu liên kết
- Tạo siêu liên kết
- Định dạng siêu liên kết
- Xóa siêu liên kết
- Cập nhật siêu liên kết
- Siêu liên kết văn bản
- Siêu liên kết slide
- Siêu liên kết hình dạng
- Siêu liên kết hình ảnh
- Siêu liên kết video
- Siêu liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- Bản trình bày
- Android
- Java
- Aspose.Slides
description: "Quản lý siêu liên kết trong các bản trình bày PowerPoint và OpenDocument một cách dễ dàng với Aspose.Slides cho Android thông qua Java—tăng cường tương tác và quy trình làm việc trong vài phút."
---
## **Giới thiệu**

Liên kết siêu văn bản là một tham chiếu tới một đối tượng, dữ liệu hoặc một vị trí nào đó. Đây là các liên kết siêu văn bản phổ biến trong bản trình bày PowerPoint:

* Liên kết tới các trang web trong văn bản, hình dạng hoặc phương tiện
* Liên kết tới các slide

Aspose.Slides cho Android thông qua Java cho phép bạn thực hiện nhiều tác vụ liên quan đến siêu liên kết trong bản trình bày.

{{% alert color="primary" %}} 
Bạn có thể muốn khám phá Aspose đơn giản, [trình chỉnh sửa PowerPoint trực tuyến miễn phí.](https://products.aspose.app/slides/vi/editor)
{{% /alert %}} 

## **Thêm Siêu liên kết URL**

### **Thêm Siêu liên kết URL vào Văn bản**

Mã Java này cho bạn thấy cách thêm một siêu liên kết trang web vào văn bản:

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **Thêm Siêu liên kết URL vào Hình dạng hoặc Khung**

Mã mẫu này bằng Java cho bạn thấy cách thêm một siêu liên kết trang web vào một hình dạng:

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Thêm Siêu liên kết URL vào Phương tiện**

Aspose.Slides cho phép bạn thêm siêu liên kết vào các tệp hình ảnh, âm thanh và video.

Mã mẫu này cho bạn thấy cách thêm một siêu liên kết vào **hình ảnh**:

```java
Presentation pres = new Presentation();
try {
	// Thêm hình ảnh vào bản trình bày
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Tạo khung hình ảnh trên slide 1 dựa trên hình ảnh đã thêm trước đó
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Mã mẫu này cho bạn thấy cách thêm một siêu liên kết vào **tập tin âm thanh**:

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Mã mẫu này cho bạn thấy cách thêm một siêu liên kết vào **video**:

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
Bạn có thể muốn xem *[Quản lý OLE](/slides/vi/androidjava/manage-ole/)*.
{{% /alert %}}

## **Sử dụng Siêu liên kết để Tạo Mục lục**

Vì siêu liên kết cho phép bạn thêm các tham chiếu tới các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để tạo mục lục.

Mã mẫu này cho bạn thấy cách tạo mục lục với các siêu liên kết:

```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Định dạng Siêu liên kết**

### **Màu**

Với thuộc tính [ColorSource](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) trong giao diện [IHyperlink](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink), bạn có thể đặt màu cho siêu liên kết và cũng có thể lấy thông tin màu từ siêu liên kết. Tính năng này lần đầu được giới thiệu trong PowerPoint 2019, do đó các thay đổi liên quan đến thuộc tính này không áp dụng cho các phiên bản PowerPoint cũ hơn.

Mã mẫu này minh họa một thao tác mà các siêu liên kết với màu khác nhau được thêm vào cùng một slide:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Xóa Siêu liên kết khỏi Bản trình bày**

### **Xóa Siêu liên kết khỏi Văn bản**

Mã Java này cho bạn thấy cách xóa siêu liên kết khỏi văn bản trong một slide bản trình bày:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Xóa Siêu liên kết khỏi Hình dạng hoặc Khung**

Mã Java này cho bạn thấy cách xóa siêu liên kết khỏi một hình dạng trong slide bản trình bày:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Siêu liên kết Có Thể Thay Đổi**

Lớp [Hyperlink](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Hyperlink) là có thể thay đổi. Với lớp này, bạn có thể thay đổi các giá trị của các thuộc tính sau:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Đoạn mã này cho bạn thấy cách thêm một siêu liên kết vào slide và chỉnh sửa tooltip sau này:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Các Thuộc tính Hỗ trợ trong IHyperlinkQueries**

Bạn có thể truy cập [IHyperlinkQueries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries) từ một bản trình bày, slide hoặc văn bản mà siêu liên kết được định nghĩa.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Lớp [IHyperlinkQueries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries) hỗ trợ các phương thức và thuộc tính sau:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể tạo điều hướng nội bộ không chỉ tới một slide, mà còn tới một "section" hoặc slide đầu tiên của một section?**

Các section trong PowerPoint là các nhóm slide; điều hướng về mặt kỹ thuật nhắm tới một slide cụ thể. Để "đi tới một section", thường bạn sẽ liên kết tới slide đầu tiên của section đó.

**Tôi có thể gắn siêu liên kết vào các yếu tố của master slide để nó hoạt động trên tất cả các slide không?**

Có. Các yếu tố của master slide và layout hỗ trợ siêu liên kết. Những liên kết này sẽ xuất hiện trên các slide con và có thể nhấp được trong quá trình trình chiếu.

**Liệu các siêu liên kết có được giữ lại khi xuất sang PDF, HTML, hình ảnh hoặc video không?**

Trong [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), có — các liên kết thường được giữ lại. Khi xuất sang [hình ảnh](/slides/vi/androidjava/convert-powerpoint-to-png/) và [video](/slides/vi/androidjava/convert-powerpoint-to-video/), khả năng nhấp sẽ không được chuyển tiếp vì đặc tính của các định dạng đó (khung raster/video không hỗ trợ siêu liên kết).