---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.9.0
linktitle: Aspose.Slides cho Java 15.9.0
type: docs
weight: 170
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) hoặc [được loại bỏ](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for Java 15.8.0.
{{% /alert %}} 
## **Thay đổi API công khai**
#### **Các phương thức renderToGraphics đã được thêm vào com.aspose.slides.ISlide, Slide**
Các phương thức sau đã được thêm vào:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
được thêm vào giao diện com.aspose.slides.ISlide và lớp com.aspose.slides.Slide. Các phương thức này cho phép render một slide vào đối tượng Graphics2D được chỉ định.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```