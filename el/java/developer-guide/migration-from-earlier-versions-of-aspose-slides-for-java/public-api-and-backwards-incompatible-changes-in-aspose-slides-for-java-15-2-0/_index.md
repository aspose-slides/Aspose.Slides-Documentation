---
title: Δημοτικό API και Ασυμβίβαστες Αλλαγές σε Aspose.Slides για Java 15.2.0
linktitle: Aspose.Slides για Java 15.2.0
type: docs
weight: 110
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- μετάβαση
- κληρονομικός κώδικας
- μοντέρνος κώδικας
- κληρονομική προσέγγιση
- μοντέρνα προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των κατατρακτικών αλλαγών σε Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 
Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) κλάσεις, μεθόδους, ιδιότητες κ.ά., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) που εισήχθησαν με το Aspose.Slides for Java 15.2.0 API.
{{% /alert %}} {{% alert color="info" %}} 
Υπάρχουν γνωστά προβλήματα με ορισμένες εικόνες κουκίδων και αντικείμενα WordArt που θα διορθωθούν στο Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Προστέθηκαν μέθοδοι addDataPointForDoughnutSeries**
Οι δύο υπερφορτώσεις της μεθόδου IChartDataPointCollection.addDataPointForDoughnutSeries() προστέθηκαν για την προσθήκη σημείων δεδομένων σε σειρές τύπου Doughnut.
### **Η κλάση com.aspose.slides.SmartArtShape κληρονομεί από την κλάση com.aspose.slides.GeometryShape**
Η κλάση com.aspose.slides.SmartArtShape κληρονομεί από την κλάση com.aspose.slides.GeometryShape. Αυτή η αλλαγή βελτιώνει το αντικειμενοεπιχειρησιακό μοντέλο του Aspose.Slides και προσθέτει νέες δυνατότητες στην κλάση SmartArtShape.
### **Οι μέθοδοι IGradientStopCollection.add(...) και IGradientStopCollection.insert(...) άλλαξαν**
Η υπογραφή της IGradientStop add(float position, int presetColor) αντικαθίσταται με την υπογραφή IGradientStop addPresetColor(float position, int presetColor).
Η υπογραφή της μεθόδου IGradientStop add(float position, SchemeColor schemeColor) της IGradientStopCollection αντικαθίσταται με την υπογραφή IGradientStop addSchemeColor(float position, int schemeColor).
Η υπογραφή της μεθόδου void insert(int index, float position, int presetColor) της IGradientStopCollection αντικαθίσταται με την υπογραφή void insertPresetColor(int index, float position, int presetColor).
Η υπογραφή της μεθόδου void insert(int index, float position, SchemeColor schemeColor) της IGradientStopCollection αντικαθίσταται με την υπογραφή void insertSchemeColor(int index, float position, int schemeColor).
### **Η μέθοδος java.awt.Color getAutomaticSeriesColor() προστέθηκε στο com.aspose.slides.IChartSeries**
Η μέθοδος getAutomaticSeriesColor() επιστρέφει ένα αυτόματο χρώμα σειράς βάσει του δείκτη της σειράς και του στυλ διαγράμματος. Αυτό το χρώμα χρησιμοποιείται εξ ορισμού εάν το FillType ισούται με NotDefined.
 
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Προστέθηκε μέθοδος για την αφαίρεση σημείου δεδομένων διαγράμματος και κατηγορίας διαγράμματος με βάση τον δείκτη του**
Η μέθοδος IChartDataPointCollection.removeAt(int index) προστέθηκε για την αφαίρεση σημείου δεδομένων διαγράμματος με βάση τον δείκτη του.
Η μέθοδος IChartCategoryCollection.removeAt(int index) προστέθηκε για την αφαίρεση κατηγορίας διαγράμματος με βάση τον δείκτη του.
### **Η τιμή PptXPptY προστέθηκε στην απαρίθμηση com.aspose.slides.PropertyType**
Η τιμή PptXPptY προστέθηκε στην απαρίθμηση com.aspose.slides.PropertyType στο πλαίσιο διόρθωσης προβλήματος σειριοποίησης.