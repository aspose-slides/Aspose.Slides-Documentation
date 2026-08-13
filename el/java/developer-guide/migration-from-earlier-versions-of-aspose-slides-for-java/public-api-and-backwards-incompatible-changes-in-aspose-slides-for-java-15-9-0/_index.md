---
title: Δημόσιο API και αλλαγές που δεν είναι συμβατές με προηγούμενες εκδόσεις στο Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides για Java 15.9.0
type: docs
weight: 170
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- κληρονομική προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των διακοπτικών αλλαγών στο Aspose.Slides for Java, ώστε να μετακομίσετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 
Αυτή η σελίδα απαριθμεί όλες τις [προστιθέμενες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) ή [αφαιρεθείσες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for Java 15.8.0 API.
{{% /alert %}} 
## **Αλλαγές δημόσιου API**
#### **Οι μέθοδοι renderToGraphics προστέθηκαν στο com.aspose.slides.ISlide, Slide**
Οι ακόλουθες μέθοδοι προστέθηκαν:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
προστέθηκαν στη διεπαφή com.aspose.slides.ISlide και στην κλάση com.aspose.slides.Slide. Αυτές οι μέθοδοι επιτρέπουν την απόδοση μιας διαφάνειας σε καθορισμένο αντικείμενο Graphics2D.

Οι μέθοδοι `renderToGraphics` έχουν αφαιρεθεί από το δημόσιο API. Στις τρέχουσες εκδόσεις, η απόδοση μιας διαφάνειας γίνεται με το [ISlide.getImage](https://reference.aspose.com/slides/el/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), όπως κάνει το παρακάτω παράδειγμα:

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