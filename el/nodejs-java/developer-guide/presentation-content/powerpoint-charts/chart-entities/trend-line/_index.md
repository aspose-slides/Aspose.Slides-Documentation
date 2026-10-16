---
title: Προσθήκη Γραμμών Τάσης σε Διαγράμματα Παρουσίασης με JavaScript
linktitle: Γραμμή Τάσης
type: docs
url: /el/nodejs-java/trend-line/
keywords:
- διάγραμμα
- γραμμή τάσης
- εκθετική γραμμή τάσης
- γραμμική γραμμή τάσης
- λογαριθμική γραμμή τάσης
- γραμμή τάσης κινητού μέσου
- πολυωνυμική γραμμή τάσης
- γραμμή τάσης δύναμης
- προσαρμοσμένη γραμμή τάσης
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσθέστε γρήγορα και προσαρμόστε γραμμές τάσης σε διαγράμματα PowerPoint με JavaScript και Aspose.Slides για Node.js μέσω Java — ένας πρακτικός οδηγός για να εντυπωσιάσετε το ακροατήριό σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσθέσετε γραμμές τάσης σε διαγράμματα παρουσίασης χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να δημιουργήσετε ένα διάγραμμα, να προσθέσετε γραμμές τάσης στις σειρές του διαγράμματος και να εργαστείτε με διάφορους τύπους γραμμών τάσης, όπως εκθετική, γραμμική, λογαριθμική, κινητός μέσος όρος, πολυωνυμική και δύναμη.

Περιγράφει επίσης πώς να προσθέσετε μια προσαρμοσμένη γραμμή σε ένα διάγραμμα εισάγοντας ένα σχήμα γραμμής και περιλαμβάνει μια σύντομη Συχνές Ερωτήσεις για τις τιμές πρόωρης και οπισθομεταβολής της γραμμής τάσης και το αν οι γραμμές τάσης διατηρούνται κατά την εξαγωγή σε PDF ή SVG και κατά τη δημιουργία εικόνων των διαγραμμάτων.

## **Προσθήκη Γραμμής Τάσης**

Use [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) to add a trend line to a chart series, selecting its type with [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). Το παράδειγμα δημιουργεί ένα ομαδοποιημένο ράβδο διάγραμμα με προεπιλεγμένα δεδομένα και προσθέτει δύο γραμμές τάσης σε κάθε μία από τις τρεις σειρές του.

Η εκθετική γραμμή τάσης κρύβει την εξίσωσή της και την τιμή R‑τετράγωνο μέσω του [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) και του [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), ενώ η γραμμική γραμμή τάσης είναι κόκκινη. Η λογαριθμική γραμμή τάσης χρησιμοποιεί το [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) για προσαρμοσμένη ετικέτα. Ο κινητός μέσος όρος χρησιμοποιεί ένα [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) τριών σημείων δεδομένων και ένα προσαρμοσμένο [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName).

Η πολυωνυμική γραμμή τάσης έχει [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) τριών και επεκτείνεται μία κατηγορία εμπρός μέσω του [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). Η γραμμή τάσης δύναμης επεκτείνεται μία κατηγορία πίσω μέσω του [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ορισμός Τομής Γραμμής Τάσης**

Χρησιμοποιήστε το [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) για να καθορίσετε την τιμή Y μιας γραμμής τάσης στο X = 0. Αυτή η ρύθμιση υποστηρίζεται για γραμμικές, εκθετικές και πολυωνυμικές γραμμές τάσης.

Για παράδειγμα, ένα μοντέλο κόστους παραγωγής μπορεί να χρειάζεται να ξεκινά από γνωστά σταθερά κόστη των 100, ακόμα και όταν μετρήσεις σε μη μηδενικούς όγκους παραγωγής υποδεικνύουν διαφορετική βάση. Για μια γραμμική γραμμή τάσης, ο καθορισμός του σημείου τομής περιορίζει την εξίσωση `y = ax + b` στο `b = 100`; η κλίση προσαρμόζεται στα δεδομένα υπό αυτήν την προϋπόθεση. Δεν μετακινεί απλώς μια ήδη προσαρμοσμένη γραμμή. Οι ρυθμίσεις διασταύρωσης αξόνων ελέγχουν το που οι άξονες του διαγράμματος συναντώνται, όχι τους συντελεστές της προσαρμοσμένης γραμμής τάσης.

Το παρακάτω παράδειγμα δημιουργεί ένα διάγραμμα διασποράς (XY) με όγκους παραγωγής από 1 έως 4 και κόστη 170, 200, 230 και 260. Αποθηκεύει το διάγραμμα με το προεπιλεγμένο αυτόματο σημείο τομής, ορίζει το σημείο τομής στο 100 και αποθηκεύει ένα δεύτερο PPTX. Τα δύο αρχεία διαφέρουν μόνο στη ρύθμιση του σημείου τομής. Η γραμμή τάσης εμφανίζει την εξίσωσή της και επεκτείνεται πίσω στο X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Με αυτόματο υπολογισμό, αυτά τα δεδομένα παράγουν `y = 30x + 140`. Ορίζοντας το σημείο τομής στο 100 παράγει περίπου `y = 43.33x + 100`: η προσαρμοσμένη τιμή στο μηδέν ταιριάζει με τη γνωστή βάση, ενώ η γραμμή δεν περνά πλέον από κάθε σημείο δεδομένων.

| Αυτόματο σημείο τομής | Σταθερό σημείο τομής 100 |
| --- | --- |
| ![Γραμμική γραμμή τάσης με αυτόματα υπολογισμένο σημείο τομής 140](intercept-automatic.png) | ![Γραμμική γραμμή τάσης με σταθερό σημείο τομής 100](intercept-fixed.png) |

Και οι δύο εικόνες χρησιμοποιούν τα ίδια δεδομένα και κλίμακες αξόνων. Οι γραμμές τάσης επεκτείνονται πίσω στο X = 0 για να δείξουν τα σημεία τομής τους.

Από προεπιλογή, το [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) επιστρέφει `NaN`, που αντιπροσωπεύει ένα ακαθόριστο σημείο τομής αντί για μηδέν. Στη συνέχεια το σημείο τομής υπολογίζεται αυτόματα από τα δεδομένα.

## **Προσθήκη Προσαρμοσμένης Γραμμής**

Μια προσαρμοσμένη γραμμή είναι ένα σχήμα σχεδιασμένο πάνω από το διάγραμμα αντί για μια γραμμή τάσης που υπολογίζεται από τα δεδομένα των σειρών. Αυτό το παράδειγμα χρησιμοποιεί το [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) για να προσθέσει μια οριζόντια γραμμή στη διαφάνεια πάνω από το διάγραμμα. Η θέση της γραμμής καθορίζεται σε συντεταγμένες διαφάνειας, μετρημένες σε points, έτσι αρχίζει από την αριστερή άκρη του διαγράμματος και βρίσκεται στη μέση του ύψους του διαγράμματος. Το πλάτος της ταιριάζει με το πλάτος του διαγράμματος. Το [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) δίνει στη γραμμή ένα συμπαγές κόκκινο χρώμα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Τι σημαίνουν τα 'forward' και 'backward' για μια γραμμή τάσης;**

Αυτά είναι τα μήκη της γραμμής τάσης που εκτείνονται εμπρός/πίσω: για διαγράμματα διασποράς (XY) — σε μονάδες άξονα· για μη‑διαγράμματα διασποράς — σε αριθμό κατηγοριών. Επιτρέπονται μόνο μη‑αρνητικές τιμές.

**Θα διατηρηθεί η γραμμή τάσης όταν εξάγεται η παρουσίαση σε PDF ή SVG, ή όταν αποδώσετε μια διαφάνεια ως εικόνα;**

Ναι. Το Aspose.Slides μετατρέπει τις παρουσιάσεις σε [PDF](/slides/el/nodejs-java/convert-powerpoint-to-pdf/) ή [SVG](/slides/el/nodejs-java/render-a-slide-as-an-svg-image/) και αποδίδει τα διαγράμματα ως εικόνες· οι γραμμές τάσης, ως μέρος του διαγράμματος, διατηρούνται κατά τις εν αυτές λειτουργίες. Διατίθεται επίσης μια μέθοδος για [εξαγωγή εικόνας του διαγράμματος](/slides/el/nodejs-java/create-shape-thumbnails/).