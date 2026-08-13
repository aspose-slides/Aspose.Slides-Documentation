---
title: Quản lý liên kết siêu văn bản trong bản trình bày trên Android
linktitle: Quản lý Siêu liên kết
type: docs
weight: 20
url: /vi/androidjava/manage-hyperlinks/
keywords:
- Thêm URL
- Thêm liên kết
- Tạo liên kết
- Định dạng liên kết
- Xóa liên kết
- Cập nhật liên kết
- Liên kết văn bản
- Liên kết slide
- Liên kết hình dạng
- Liên kết hình ảnh
- Liên kết video
- Liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- Bản trình bày
- Android
- Java
- Aspose.Slides
description: "Quản lý liên kết siêu văn bản trong các bản trình bày PowerPoint và OpenDocument một cách dễ dàng với Aspose.Slides cho Android thông qua Java—tăng cường tính tương tác và quy trình công việc trong vài phút."
---
## **Giới thiệu**

Liên kết siêu văn bản là một tham chiếu tới một đối tượng, dữ liệu hoặc một vị trí trong một tài liệu. Đây là các liên kết siêu văn bản phổ biến trong các bản trình bày PowerPoint:

* Liên kết tới các trang web trong văn bản, hình dạng hoặc phương tiện
* Liên kết tới các slide

Aspose.Slides cho Android thông qua Java cho phép bạn thực hiện nhiều tác vụ liên quan đến liên kết siêu văn bản trong bản trình bày.

{{% alert color="info" %}} 

Bạn có thể muốn khám phá Aspose đơn giản, [trình chỉnh sửa PowerPoint trực tuyến miễn phí.](https://products.aspose.app/slides/vi/editor)

{{% /alert %}} 

## **Thêm Liên Kết URL**

### **Thêm Liên Kết URL vào Văn Bản**

Đoạn mã Java này cho bạn thấy cách thêm một liên kết siêu văn bản tới một website vào văn bản:

```java
import com.aspose.slides.*;

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

### **Thêm Liên Kết URL vào Hình Dạng hoặc Khung**

Đoạn mã mẫu trong Java này cho bạn thấy cách thêm một liên kết siêu văn bản tới một hình dạng:

```java
import com.aspose.slides.*;

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

### **Thêm Liên Kết URL vào Phương Tiện**

Aspose.Slides cho phép bạn thêm liên kết siêu văn bản vào hình ảnh, tệp âm thanh và video.

Đoạn mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **hình ảnh**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Thêm ảnh vào bản trình bày
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Tạo khung hình ảnh trên slide 1 dựa trên ảnh đã thêm trước đó
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Đoạn mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **tệp âm thanh**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

Đoạn mã mẫu này cho bạn thấy cách thêm một liên kết siêu văn bản vào **video**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

{{%  alert  title="Tip"  color="info"  %}} 

Bạn có thể muốn xem *[Quản Lý OLE](/slides/vi/androidjava/manage-ole/)*.

{{% /alert %}}

## **Sử Dụng Liên Kết Để Tạo Mục Lục**

Vì liên kết siêu văn bản cho phép bạn thêm tham chiếu tới các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để tạo mục lục.

Đoạn mã mẫu này cho bạn thấy cách tạo mục lục với các liên kết siêu văn bản:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Định Dạng Liên Kết**

### **Màu**

Với thuộc tính [ColorSource](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) trong giao diện [IHyperlink](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink), bạn có thể đặt màu cho các liên kết siêu văn bản và cũng có thể lấy thông tin màu từ các liên kết. Tính năng này lần đầu được giới thiệu trong PowerPoint 2019, vì vậy các thay đổi liên quan đến thuộc tính này không áp dụng cho các phiên bản PowerPoint cũ hơn.

Đoạn mã mẫu này minh họa một thao tác mà các liên kết siêu văn bản với màu sắc khác nhau đã được thêm vào cùng một slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Xóa Liên Kết Khỏi Bản Trình Bày**

### **Xóa Liên Kết Khỏi Văn Bản**

Đoạn mã Java này cho bạn thấy cách xóa liên kết siêu văn bản khỏi văn bản trong một slide của bản trình bày:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
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

### **Xóa Liên Kết Khỏi Hình Dạng hoặc Khung**

Đoạn mã Java này cho bạn thấy cách xóa liên kết siêu văn bản khỏi một hình dạng trong slide của bản trình bày: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

## **Liên Kết Siêu Văn Bản Có Thể Thay Đổi**

Class [Hyperlink](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Hyperlink) là có thể thay đổi. Với lớp này, bạn có thể thay đổi các giá trị cho các thuộc tính sau:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Đoạn mã minh họa cho bạn cách thêm một liên kết siêu văn bản vào slide và chỉnh sửa tooltip của nó sau này:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// Thay đổi tooltip của hyperlink đã được thêm
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Các Thuộc Tính Hỗ Trợ trong IHyperlinkQueries**

Bạn có thể truy cập [IHyperlinkQueries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries) từ một bản trình bày, slide hoặc văn bản mà liên kết siêu văn bản được định nghĩa.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Class [IHyperlinkQueries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries) hỗ trợ các phương thức và thuộc tính sau:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **Câu Hỏi Thường Gặp**

### Làm thế nào tôi có thể tạo điều hướng nội bộ không chỉ tới một slide, mà còn tới một "phần" hoặc slide đầu tiên của một phần?

Các phần trong PowerPoint là nhóm các slide; điều hướng về mặt kỹ thuật hướng tới một slide cụ thể. Để "điều hướng tới một phần", bạn thường liên kết tới slide đầu tiên của phần đó.

### Tôi có thể gắn liên kết siêu văn bản vào các phần tử master slide để nó hoạt động trên tất cả các slide không?

Có. Các phần tử master slide và layout hỗ trợ liên kết siêu văn bản. Những liên kết này xuất hiện trên các slide con và có thể nhấp trong khi trình chiếu.

### Liên kết siêu văn bản có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?

Trong [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), có—liên kết thường được giữ lại. Khi xuất ra [hình ảnh](/slides/vi/androidjava/convert-powerpoint-to-png/) và [video](/slides/vi/androidjava/convert-powerpoint-to-video/), tính năng nhấp không được chuyển sang vì bản chất của các định dạng đó (khung raster/video không hỗ trợ liên kết siêu văn bản).