---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.9.0
linktitle: Aspose.Slides untuk Java 15.9.0
type: docs
weight: 170
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memutuskan di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan lain‑lain yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) atau [dihapus](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/), serta perubahan lainnya yang diperkenalkan dengan API Aspose.Slides for Java 15.8.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Metode renderToGraphics telah ditambahkan ke com.aspose.slides.ISlide, Slide**
Metode berikut telah ditambahkan:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
metode tersebut ditambahkan ke antarmuka com.aspose.slides.ISlide dan ke kelas com.aspose.slides.Slide. Metode ini memungkinkan merender slide ke objek Graphics2D yang ditentukan.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```