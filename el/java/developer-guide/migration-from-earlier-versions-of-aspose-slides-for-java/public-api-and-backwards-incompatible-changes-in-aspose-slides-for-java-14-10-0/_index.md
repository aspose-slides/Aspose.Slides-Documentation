---
title: Δημόσιο API και Μη Συμβατές Αλλαγές σε Aspose.Slides για Java 14.10.0
linktitle: Aspose.Slides για Java 14.10.0
type: docs
weight: 90
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- μετάβαση
- παραδοσιακός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των καταστροφικών αλλαγών στο Aspose.Slides για Java, ώστε να μετατρέψετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 
Αυτή η σελίδα παραθέτει όλες τις [προστιθέμενες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) κλάσεις, μεθόδους, ιδιότητες κλπ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) που εισήχθησαν με το Aspose.Slides for Java 14.10.0 API.
{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Η μέθοδος com.aspose.slides.FieldType.getFooter() προστέθηκε**
Η μέθοδος getFooter() επιστρέφει τον τύπο πεδίου υποσέλιδου. Προστέθηκε για την υλοποίηση της δυνατότητας δημιουργίας πεδίων αυτού του τύπου και για έγκυρη σειριοποίηση παρουσίασης.
### **Το στοιχείο com.aspose.slides.ShapeElementFillSource.Own διαγράφηκε**
Το στοιχείο ShapeElementFillSource.Own διαγράφηκε επειδή ήταν διπλό. Χρησιμοποιήστε το ShapeElementFillSource.Shape αντί του ShapeElementFillSource.Own.
### **Προστέθηκαν μέθοδοι για αφαίρεση σημείων δεδομένων γραφήματος και κατηγοριών**
**Οι παρακάτω μέθοδοι, οι οποίες επιτρέπουν την αφαίρεση σημείου δεδομένων γραφήματος από τη συλλογή σημείων δεδομένων γραφήματος, προστέθηκαν:**
IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()
**Η παρακάτω μέθοδος, η οποία επιτρέπει την αφαίρεση μιας κατηγορίας γραφήματος από τη συλλογή που τη περιέχει, προστέθηκε:**
IChartCategory.remove()
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // αφαίρεση με ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // αφαίρεση με ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // αφαίρεση με ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);
```
### **Οι παρωχημένες μέθοδοι Aspose.Slides.ParagraphFormat έχουν αφαιρεθεί**
Οι μέθοδοι getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() και οι αντίστοιχες μέθοδοι set έχουν αφαιρεθεί. Είχαν επισημανθεί ως παρωχημένες από πολύ καιρό.
### **Αχρησιμοποίητοι και παρωχημένοι κατασκευαστές έχουν αφαιρεθεί**
Οι παρακάτω κατασκευαστές έχουν αφαιρεθεί:
com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)