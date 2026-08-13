---
title: Δημόσιο API και Μη Συμβατές Πίσω Αλλαγές στο Aspose.Slides για .NET 15.10.0
linktitle: Aspose.Slides για .NET 15.10.0
type: docs
weight: 200
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- μεταφορά
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των διακοπτικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="info" %}} 

Αυτή η σελίδα καταγράφει όλες τις προστιθέμενες ή αφαιρεμένες κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides για .NET 15.10.0.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Προστέθηκε νέο VideoPlayerHtmlController για την Υποστήριξη Εξαγωγής Αρχείων Πολυμέσων σε HTML**
Η νέα δημόσια κλάση VideoPlayerHtmlController προστέθηκε στο namespace Aspose.Slides.Export. Χρησιμοποιώντας ένα στιγμιότυπο αυτής της κλάσης, ο χρήστης μπορεί να εξάγει αρχεία βίντεο και ήχου σε HTML.
VideoPlayerHtmlController οι κατασκευαστές δέχονται τις ακόλουθες παραμέτρους:

path: Η διαδρομή όπου θα δημιουργηθούν τα αρχεία βίντεο και ήχου  
fileName: Το όνομα του αρχείου HTML  

baseUri: Το βασικό URI που θα χρησιμοποιηθεί για τη δημιουργία συνδέσμων  
Παράδειγμα χρήσης:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("example.pptx"))

{

    const string path = "path";

    const string fileName = "video.html";

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);

}

``` 
#### **Προστέθηκε API Ανίμασης Σειρών Διαγραμμάτων**
Οι νέες 2 μέθοδοι προστέθηκαν στη διεπαφή Aspose.Slides.Animation.ISequence.

``` csharp
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;


 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

Αυτές οι μέθοδοι προορίζονται να υποστηρίξουν τις αναπαραγωγές των στοιχείων των διαγραμμάτων:
κατά σειρά  
κατά κατηγορίες  
κατά στοιχεία σειράς  
κατά στοιχεία κατηγοριών  

Οι δύο νέοι enum EffectChartMajorGroupingType και EffectChartMinorGroupingType που σχετίζονται με την ανίμαση των στοιχείων του διαγράμματος εισήχθησαν.

Για να προσθέσετε μια ανίμαση σειράς στο διάγραμμα, μπορεί να χρησιμοποιηθεί ο παρακάτω κώδικας:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

Ανίμαση κατηγοριών:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

Ανίμαση στοιχείων σειράς:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

Ανίμαση στοιχείων κατηγοριών:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 2,
        EffectType.Appear, EffectSubtype None, EffectTriggerType AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
```