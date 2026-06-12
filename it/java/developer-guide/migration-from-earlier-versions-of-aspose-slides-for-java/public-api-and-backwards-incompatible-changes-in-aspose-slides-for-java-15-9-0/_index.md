---
title: API pubbliche e modifiche incompatibili retroattive in Aspose.Slides per Java 15.9.0
linktitle: Aspose.Slides per Java 15.9.0
type: docs
weight: 170
url: /it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Revisiona gli aggiornamenti dell'API pubblica e le modifiche breaking in Aspose.Slides per Java per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Questa pagina elenca tutte le classi, i metodi, le proprietà [aggiunti](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) o [rimossi](/slides/it/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/), e così via, nonché le altre modifiche introdotte con l'API di Aspose.Slides per Java 15.8.0.
{{% /alert %}} 
## **Modifiche all'API pubblica**
#### **I metodi renderToGraphics sono stati aggiunti a com.aspose.slides.ISlide, Slide**
Sono stati aggiunti i seguenti metodi:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
sono stati aggiunti all'interfaccia com.aspose.slides.ISlide e alla classe com.aspose.slides.Slide. Questi metodi consentono di renderizzare una diapositiva su un oggetto Graphics2D specificato.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```