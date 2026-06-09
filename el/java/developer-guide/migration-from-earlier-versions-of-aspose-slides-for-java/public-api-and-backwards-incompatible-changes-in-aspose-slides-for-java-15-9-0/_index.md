---
title: Δημόσιο API και Αντίστροφες Ασυμβατότητες στο Aspose.Slides για Java 15.9.0
linktitle: Aspose.Slides για Java 15.9.0
type: docs
weight: 170
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- μεταφορά
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Επισκόπηση των ενημερώσεων του δημόσιου API και των διασπαστικών αλλαγών στο Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλα τα [added](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) ή [removed](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και τις άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **Αλλαγές Δημοσίου API**
#### **Οι μέθοδοι renderToGraphics προστέθηκαν στο com.aspose.slides.ISlide, Slide**
Οι παρακάτω μέθοδοι έχουν προστεθεί:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
Προστέθηκαν στο interface com.aspose.slides.ISlide και στην κλάση com.aspose.slides.Slide. Αυτές οι μέθοδοι επιτρέπουν την απόδοση μιας διαφάνειας σε καθορισμένο αντικείμενο Graphics2D.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```