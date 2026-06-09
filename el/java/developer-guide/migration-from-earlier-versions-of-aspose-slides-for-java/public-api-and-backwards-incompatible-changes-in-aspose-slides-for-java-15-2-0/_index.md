---
title: Δ öffentlich API και μη συμβατές αλλαγές προς τα πίσω στο Aspose.Slides for Java 15.2.0
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- μεταφορά
- παλιός κώδικας
- σύγχρονος κώδικας
- παλιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σημαντικών αλλαγών στο Aspose.Slides for Java για ομαλή μετάβαση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}}

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) κλάσεις, μεθόδους, ιδιότητες κλπ., τυχόν νέους περιορισμούς και άλλες [αλλαγές](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) που εισήχθησαν με το API του Aspose.Slides for Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}}

Υπάρχουν γνωστά ζητήματα με ορισμένες εικόνες κύκλων και αντικείμενα WordArt που θα διορθωθούν στο Aspose.Slides for Java 15.2.0.

{{% /alert %}}
## **Δημόσιες Αλλαγές API**
### **Προστέθηκαν μέθοδοι addDataPointForDoughnutSeries**
Οι δύο υπερφορτώσεις της μεθόδου IChartDataPointCollection.addDataPointForDoughnutSeries() προστέθηκαν για την προσθήκη σημείων δεδομένων σε σειρές τύπου Doughnut.

### **Η κλάση com.aspose.slides.SmartArtShape κληρονομήθηκε από την κλάση com.aspose.slides.GeometryShape**
Η κλάση com.aspose.slides.SmartArtShape κληρονομήθηκε από την κλάση com.aspose.slides.GeometryShape. Αυτή η αλλαγή βελτιώνει το αντικειμενοστραφές μοντέλο του Aspose.Slides και προσθέτει νέες δυνατότητες στην κλάση SmartArtShape.

### **Οι μέθοδοι IGradientStopCollection.add(...) και IGradientStopCollection.insert(...) έχουν αλλάξει**
Η υπογραφή του IGradientStop add(float position, int presetColor) αντικαθίσταται με την υπογραφή IGradientStop addPresetColor(float position, int presetColor).
Η υπογραφή της μεθόδου IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) αντικαθίσταται με την υπογραφή IGradientStop addSchemeColor(float position, int schemeColor).
Η υπογραφή της μεθόδου IGradientStopCollection void insert(int index, float position, int presetColor) αντικαθίσταται με την υπογραφή void insertPresetColor(int index, float position, int presetColor).
Η υπογραφή της μεθόδου IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) αντικαθίσταται με την υπογραφή void insertSchemeColor(int index, float position, int schemeColor).

### **Η μέθοδος java.awt.Color getAutomaticSeriesColor() προστέθηκε στην κλάση com.aspose.slides.IChartSeries**
Η μέθοδος getAutomaticSeriesColor() επιστρέφει ένα αυτόματο χρώμα σειράς βάσει του δείκτη σειράς και του στυλ διαγράμματος. Αυτό το χρώμα χρησιμοποιείται εξ ορισμού εάν το FillType ισούται με NotDefined.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Προστέθηκε μέθοδος για αφαίρεση σημείου δεδομένων διαγράμματος και κατηγορίας διαγράμματος με βάση το δείκτη του**
Η μέθοδος IChartDataPointCollection.removeAt(int index) προστέθηκε για την αφαίρεση σημείου δεδομένων διαγράμματος με βάση το δείκτη του.
Η μέθοδος IChartCategoryCollection.removeAt(int index) προστέθηκε για την αφαίρεση κατηγορίας διαγράμματος με βάση το δείκτη του.

### **Η τιμή PptXPptY προστέθηκε στην απαρίθμηση com.aspose.slides.PropertyType**
Η τιμή PptXPptY προστέθηκε στην απαρίθμηση com.aspose.slides.PropertyType στο πλαίσιο διόρθωσης προβλήματος σειριοποίησης.