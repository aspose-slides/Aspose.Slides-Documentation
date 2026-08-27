---
title: Διαχείριση πλαισίων κειμένου σε παρουσιάσεις σε .NET
linktitle: Διαχείριση πλαισίου κειμένου
type: docs
weight: 20
url: /el/net/manage-textbox/
keywords:
- πλαίσιο κειμένου
- πλαίσιο κειμένου
- προσθήκη κειμένου
- ενημέρωση κειμένου
- δημιουργία πλαισίου κειμένου
- έλεγχος πλαισίου κειμένου
- προσθήκη στήλης κειμένου
- προσθήκη υπερσυνδέσμου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Το Aspose.Slides για .NET διευκολύνει τη δημιουργία, επεξεργασία και κλωνοποίηση πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, ενισχύοντας την αυτοματοποίηση των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως υπάρχουν σε πλαίσια κειμένου ή σχήματα. Συνεπώς, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει πρώτα να προσθέσετε ένα πλαίσιο κειμένου και στη συνέχεια να εισάγετε κάποιο κείμενο μέσα στο πλαίσιο.

Για να μπορείτε να προσθέσετε ένα σχήμα που μπορεί να περιέχει κείμενο, το Aspose.Slides για .NET παρέχει τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape) .

{{% alert title="Note" color="warning" %}} 

Το Aspose.Slides παρέχει επίσης τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape) ώστε να μπορείτε να προσθέτετε σχήματα σε διαφάνειες. Ωστόσο, δεν μπορούν όλα τα σχήματα που προστίθενται μέσω της διεπαφής `IShape` να περιέχουν κείμενο. Τα σχήματα που προστίθενται μέσω της διεπαφής [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape) συνήθως περιέχουν κείμενο.

Συνεπώς, όταν εργάζεστε με ένα υπάρχον σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι έχει μετατραπεί μέσω της διεπαφής `IAutoShape`. Μόνο τότε θα μπορείτε να εργαστείτε με το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/properties/textframe), το οποίο είναι μια ιδιότητα του `IAutoShape`. Δείτε την ενότητα [Update Text](https://docs.aspose.com/slides/el/net/manage-textbox/#update-text) σε αυτή τη σελίδα. 

{{% /alert %}}

## **Δημιουργία Πλαισίου Κειμένου σε Διαφάνεια**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation). 
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας μέσω του δείκτη της. 
3. Προσθέστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape) με την ιδιότητα [ShapeType](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/properties/shapetype) ορισμένη σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και λάβετε την αναφορά του νεοδημιουργημένου αντικειμένου `IAutoShape`. 
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `IAutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα, προσθέσαμε το κείμενο: *Aspose TextBox* 
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας C# — υλοποίηση των παραπάνω βημάτων — δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```c#
using Aspose.Slides;

// Δημιουργεί ένα αντικείμενο PresentationEx
using (Presentation pres = new Presentation())
{

    // Αποκτά την πρώτη διαφάνεια στην παρουσίαση
    ISlide sld = pres.Slides[0];

    // Προσθέτει ένα AutoShape με τύπο ορισμένο ως Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Προσθέτει TextFrame στο Rectangle
    ashp.AddTextFrame(" ");

    // Πρόσβαση στο πλαίσιο κειμένου
    ITextFrame txtFrame = ashp.TextFrame;

    // Δημιουργεί το αντικείμενο Paragraph για το πλαίσιο κειμένου
    IParagraph para = txtFrame.Paragraphs[0];

    // Δημιουργεί ένα αντικείμενο Portion για την παράγραφο
    IPortion portion = para.Portions[0];

    // Ορίζει το κείμενο
    portion.Text = "Aspose TextBox";

    // Αποθηκεύει την παρουσίαση στο δίσκο
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Έλεγχος για Σχήμα Πλαισίου Κειμένου**

Το Aspose.Slides παρέχει την ιδιότητα [IsTextBox](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/istextbox/) από τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) , επιτρέποντάς σας να εξετάζετε σχήματα και να εντοπίζετε πλαίσια κειμένου.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Αυτός ο κώδικας C# δείχνει πώς να ελέγξετε αν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου: 

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Σημειώστε ότι εάν προσθέσετε απλώς ένα autoshape χρησιμοποιώντας τη μέθοδο `AddAutoShape` από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/) , η ιδιότητα `IsTextBox` του autoshape θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο autoshape χρησιμοποιώντας τη μέθοδο `AddTextFrame` ή την ιδιότητα `Text`, η ιδιότητα `IsTextBox` επιστρέφει `true`.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox είναι ψευδές
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox είναι αληθές

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox είναι ψευδές
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox είναι αληθές

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox είναι ψευδές
    shape3.AddTextFrame("");
    // shape3.IsTextBox είναι ψευδές

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox είναι ψευδές
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox είναι ψευδές
}
```

## **Εύρεση του Σχήματος που Κατέχει ένα Πλαίσιο Κειμένου**

Σε γενικό κώδικα επεξεργασίας κειμένου, μπορεί να λάβετε ένα [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) χωρίς να γνωρίζετε ήδη ποιο αντικείμενο παρουσίασης το περιέχει. Χρησιμοποιήστε την ιδιότητα [ITextFrame.ParentShape](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentshape/) για να πλοηγηθείτε πίσω στο κειμενικό [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/).

Για ένα πλαίσιο κειμένου που ανήκει σε ένα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) ή σε άλλο σχήμα που περιέχει κείμενο, η ιδιότητα [ITextFrame.ParentShape](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentshape/) είναι ορισμένη και η [ITextFrame.ParentCell](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/parentcell/) είναι `null`. Και οι δύο ιδιότητες είναι μόνο για ανάγνωση και η ανάγνωσή τους δεν αλλάζει την ιδιοκτησία. Πάντα ελέγχετε την τιμή που επιστρέφει για `null` πριν προσπελάσετε το σχήμα.

Για ένα πλήρες παράδειγμα που εντοπίζει ιδιοκτήτες σχήματος και κελιού πίνακα, συμπεριλαμβανομένων σχημάτων που σχετίζονται με κόμβους SmartArt, δείτε το [Search and Replace Text](/slides/el/net/search-and-replace-text/).

## **Προσθήκη Στηλών σε Πλαίσιο Κειμένου**

Το Aspose.Slides παρέχει τις ιδιότητες [ColumnCount](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/columncount) και [ColumnSpacing](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/properties/columnspacing) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat) και την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat)) που σας επιτρέπουν να προσθέτετε στήλες σε πλαίσια κειμένου. Μπορείτε να καθορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και στη συνέχεια το διάστημα σε σημεία μεταξύ των στηλών. 

Αυτός ο κώδικας C# επιδεικνύει τη περιγραφόμενη λειτουργία: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
	ISlide slide = presentation.Slides[0];

	// Προσθέτει ένα AutoShape με τύπο ορισμένο ως Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Προσθέτει TextFrame στο Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Λαμβάνει τη μορφή κειμένου του TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Καθορίζει τον αριθμό των στηλών στο TextFrame
	format.ColumnCount = 3;

	// Καθορίζει το διάστημα μεταξύ των στηλών
	format.ColumnSpacing = 10;

	// Αποθηκεύει την παρουσίαση
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Στηλών σε Πλαίσιο Κειμένου**

Το Aspose.Slides για .NET παρέχει την ιδιότητα [ColumnCount](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/columncount) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat)) που σας επιτρέπει να προσθέτετε στήλες σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να καθορίσετε τον επιθυμητό αριθμό στηλών σε ένα πλαίσιο κειμένου. 

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε μια στήλη μέσα σε ένα πλαίσιο κειμένου:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Ενημέρωση Κειμένου**

Το Aspose.Slides σας επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλο το κείμενο που περιέχεται σε μια παρουσίαση. 

Αυτός ο κώδικας C# επιδεικνύει μια λειτουργία όπου όλα τα κείμενα σε μια παρουσίαση ενημερώνονται ή αλλάζουν:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Ελέγχει εάν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Διατρέχει τις παραγράφους στο πλαίσιο κειμένου
               {
                   foreach (IPortion portion in paragraph.Portions) //Διατρέχει κάθε τμήμα στην παράγραφο
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Αλλάζει το κείμενο
                       portion.PortionFormat.FontBold = NullableBool.True; //Αλλάζει τη μορφοποίηση
                   }
               }
           }
       }
   }
  
   //Αποθηκεύει την τροποποιημένη παρουσίαση
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Πλαισίου Κειμένου με Υπερσύνδεσμο** 

Μπορείτε να εισάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν γίνεται κλικ στο πλαίσιο κειμένου, οι χρήστες οδηγούνται να ανοίξουν το σύνδεσμο. 

1. Δημιουργήστε μια παρουσίαση της κλάσης `Presentation`. 
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα αντικείμενο `AutoShape` με `ShapeType` ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και λάβετε την αναφορά του νεοσυμπληρωμένου αντικειμένου AutoShape. 
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο. 
5. Δημιουργήστε μια παρουσία της κλάσης `IHyperlinkManager`. 
6. Αναθέστε το αντικείμενο `IHyperlinkManager` στην ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/shape/properties/hyperlinkclick) που σχετίζεται με το προτιμώμενο τμήμα του `TextFrame`. 
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`. 

Αυτός ο κώδικας C# — υλοποίηση των παραπάνω βημάτων — δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```c#
using Aspose.Slides;

// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα PPTX
Presentation pptxPresentation = new Presentation();

// Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
ISlide slide = pptxPresentation.Slides[0];

// Προσθέτει ένα αντικείμενο AutoShape με τύπο ορισμένο ως Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Μετατρέπει το σχήμα σε AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Πρόσβαση στην ιδιότητα ITextFrame που σχετίζεται με το AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Προσθέτει κάποιο κείμενο στο πλαίσιο
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Ορίζει τον υπερσύνδεσμο για το κείμενο του τμήματος
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Αποθηκεύει την παρουσίαση PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου κειμένου και κράτησης θέσης κειμένου όταν εργάζεστε με κύριες διαφάνειες;**

Ένα [placeholder](/slides/el/net/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/net/aspose.slides/masterslide/) και μπορεί να αντικατασταθεί σε [layouts](https://reference.aspose.com/slides/el/net/aspose.slides/layoutslide/), ενώ ένα κανονικό πλαίσιο κειμένου είναι ανεξάρτητο αντικείμενο σε μια συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layouts.

**Πώς μπορώ να πραγματοποιήσω αντικατάσταση κειμένου μαζικά σε όλη την παρουσίαση χωρίς να επηρεάσω το κείμενο μέσα σε γραφήματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψή σας σε αυτό-σχήματα που έχουν πλαίσια κειμένου και εξαιρέστε ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/el/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/smartart/)) διασχίζοντας τις συλλογές τους ξεχωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.