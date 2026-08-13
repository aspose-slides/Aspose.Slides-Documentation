---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides cho Java 15.9.0
type: docs
weight: 170
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- di chuyển
- mã nguồn kế thừa
- mã nguồn hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides for Java để di chuyển suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) hoặc [đã bị xóa](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/), và các thay đổi khác được giới thiệu với Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Thay đổi API công cộng**
#### **Các phương thức renderToGraphics đã được thêm vào com.aspose.slides.ISlide, Slide**
Các phương thức sau đã được thêm:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
được thêm vào giao diện com.aspose.slides.ISlide và lớp com.aspose.slides.Slide. Các phương thức này cho phép render một slide tới đối tượng Graphics2D được chỉ định.

Các phương thức `renderToGraphics` sau đây đã bị loại bỏ khỏi API công cộng. Trong các phiên bản hiện tại, render một slide bằng [ISlide.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), như ví dụ dưới đây làm:

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```