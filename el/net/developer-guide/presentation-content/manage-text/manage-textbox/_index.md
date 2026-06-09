---
title: Διαχείριση Πλαισίων Κειμένου σε Παρουσιάσεις σε .NET
linktitle: Διαχείριση Πλαισίου Κειμένου
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
description: "Το Aspose.Slides για .NET καθιστά εύκολη τη δημιουργία, επεξεργασία και αντιγραφή πλαισίων κειμένου σε αρχεία PowerPoint και OpenDocument, ενισχύοντας τον αυτοματισμό των παρουσιάσεών σας."
---
## **Εισαγωγή**

Τα κείμενα στις διαφάνειες συνήθως βρίσκονται σε πλαίσια κειμένου ή σχήματα. Συνεπώς, για να προσθέσετε κείμενο σε μια διαφάνεια, πρέπει πρώτα να προσθέσετε ένα πλαίσιο κειμένου και μετά να τοποθετήσετε κάποιο κείμενο μέσα στο πλαίσιο.

Για να μπορείτε να προσθέσετε ένα σχήμα που να μπορεί να περιέχει κείμενο, το Aspose.Slides for .NET παρέχει τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape).

{{% alert title="Note" color="warning" %}} 

Το Aspose.Slides παρέχει επίσης τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape) για την προσθήκη σχημάτων σε διαφάνειες. Ωστόσο, δεν μπορούν όλα τα σχήματα που προστίθενται μέσω της διεπαφής `IShape` να περιέχουν κείμενο. Τα σχήματα που προστίθενται μέσω της διεπαφής [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape) περιέχουν συνήθως κείμενο.

Επομένως, όταν εργάζεστε με ένα υπάρχον σχήμα στο οποίο θέλετε να προσθέσετε κείμενο, ίσως θελήσετε να ελέγξετε και να επιβεβαιώσετε ότι έχει μετατραπεί μέσω της διεπαφής `IAutoShape`. Μόνο τότε θα μπορείτε να δουλέψετε με το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/properties/textframe), το οποίο είναι ιδιότητα του `IAutoShape`. Δείτε την ενότητα [Update Text](https://docs.aspose.com/slides/el/net/manage-textbox/#update-text) σε αυτή τη σελίδα.

{{% /alert %}}

## **Δημιουργία Πλαισίου Κειμένου σε Διαφάνεια**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα αντικείμενο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape) με το [ShapeType](https://reference.aspose.com/slides/el/net/aspose.slides/igeometryshape/properties/shapetype) ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και λάβετε την αναφορά του νεοδημιουργημένου αντικειμένου `IAutoShape`.  
4. Προσθέστε την ιδιότητα `TextFrame` στο αντικείμενο `IAutoShape` που θα περιέχει κείμενο. Στο παρακάτω παράδειγμα προσθέσαμε αυτό το κείμενο: *Aspose TextBox*  
5. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`.  

Αυτός ο κώδικας C#—μια υλοποίηση των παραπάνω βημάτων—δείχνει πώς να προσθέσετε κείμενο σε μια διαφάνεια:

```c#
// Δημιουργεί ένα αντικείμενο PresentationEx
using (Presentation pres = new Presentation())
{

    // Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
    ISlide sld = pres.Slides[0];

    // Προσθέτει ένα AutoShape με τύπο ορισμένο ως Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Προσθέτει TextFrame στο Rectangle
    ashp.AddTextFrame(" ");

    // Προσπελαύνει το πλαίσιο κειμένου
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

Το Aspose.Slides παρέχει την ιδιότητα [IsTextBox](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/istextbox/) από τη διεπαφή [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) για να εξετάζετε τα σχήματα και να εντοπίζετε πλαίσια κειμένου.

![Πλαίσιο κειμένου και σχήμα](istextbox.png)

Αυτός ο κώδικας C# δείχνει πώς να ελέγξετε εάν ένα σχήμα δημιουργήθηκε ως πλαίσιο κειμένου:

```c#
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

Σημειώστε ότι αν προσθέσετε απλώς ένα αυτόματο σχήμα χρησιμοποιώντας τη μέθοδο `AddAutoShape` από τη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/net/aspose.slides/ishapecollection/), η ιδιότητα `IsTextBox` του αυτόματου σχήματος θα επιστρέψει `false`. Ωστόσο, αφού προσθέσετε κείμενο στο αυτόματο σχήμα χρησιμοποιώντας τη μέθοδο `AddTextFrame` ή την ιδιότητα `Text`, η ιδιότητα `IsTextBox` επιστρέφει `true`.

```cs
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

## **Προσθήκη Στηλών σε Πλαίσιο Κειμένου**

Το Aspose.Slides παρέχει τις ιδιότητες [ColumnCount](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/columncount) και [ColumnSpacing](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/properties/columnspacing) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat) και την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat)) για να προσθέτετε στήλες σε πλαίσια κειμένου. Μπορείτε να καθορίσετε τον αριθμό των στηλών σε ένα πλαίσιο κειμένου και στη συνέχεια το κενό μεταξύ των στηλών σε points.

Αυτός ο κώδικας C# επιδεικνύει τη λειτουργία:

```c#
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

	// Καθορίζει το κενό μεταξύ των στηλών
	format.ColumnSpacing = 10;

	// Αποθηκεύει την παρουσίαση
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Στηλών σε Πλαίσιο Κειμένου**

Το Aspose.Slides for .NET παρέχει την ιδιότητα [ColumnCount](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat/properties/columncount) (από τη διεπαφή [ITextFrameFormat](https://reference.aspose.com/slides/el/net/aspose.slides/itextframeformat)) που σας επιτρέπει να προσθέσετε στήλες σε πλαίσια κειμένου. Μέσω αυτής της ιδιότητας, μπορείτε να ορίσετε τον προτιμώμενο αριθμό στηλών σε ένα πλαίσιο κειμένου.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε μια στήλη μέσα σε πλαίσιο κειμένου:

```c#
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
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
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

Το Aspose.Slides σάς επιτρέπει να αλλάξετε ή να ενημερώσετε το κείμενο που περιέχεται σε ένα πλαίσιο κειμένου ή όλα τα κείμενα που περιέχονται σε μια παρουσίαση.

Αυτός ο κώδικας C# επιδεικνύει μια λειτουργία όπου όλα τα κείμενα σε μια παρουσίαση ενημερώνονται ή τροποποιούνται:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Ελέγχει εάν το σχήμα υποστηρίζει πλαίσιο κειμένου (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Διασχίζει τις παραγράφους στο πλαίσιο κειμένου
               {
                   foreach (IPortion portion in paragraph.Portions) //Διασχίζει κάθε τμήμα στην παράγραφο
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

Μπορείτε να εισάγετε έναν σύνδεσμο μέσα σε ένα πλαίσιο κειμένου. Όταν το πλαίσιο κειμένου κάνει κλικ, οι χρήστες οδηγούνται στο άνοιγμα του συνδέσμου.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης `Presentation`.  
2. Αποκτήστε την αναφορά της πρώτης διαφάνειας μέσω του δείκτη της.  
3. Προσθέστε ένα αντικείμενο `AutoShape` με το `ShapeType` ορισμένο σε `Rectangle` σε συγκεκριμένη θέση στη διαφάνεια και λάβετε την αναφορά του νεοδημιουργημένου αντικειμένου AutoShape.  
4. Προσθέστε ένα `TextFrame` στο αντικείμενο `AutoShape` που περιέχει *Aspose TextBox* ως προεπιλεγμένο κείμενο.  
5. Δημιουργήστε ένα στιγμιότυπο της κλάσης `IHyperlinkManager`.  
6. Εκχωρήστε το αντικείμενο `IHyperlinkManager` στην ιδιότητα [HyperlinkClick](https://reference.aspose.com/slides/el/net/aspose.slides/shape/properties/hyperlinkclick) που σχετίζεται με το επιθυμητό τμήμα του `TextFrame`.  
7. Τέλος, γράψτε το αρχείο PPTX μέσω του αντικειμένου `Presentation`.  

Αυτός ο κώδικας C#—μια υλοποίηση των παραπάνω βημάτων—δείχνει πώς να προσθέσετε ένα πλαίσιο κειμένου με υπερσύνδεσμο σε μια διαφάνεια:

```c#
// Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα PPTX
Presentation pptxPresentation = new Presentation();

// Λαμβάνει την πρώτη διαφάνεια στην παρουσίαση
ISlide slide = pptxPresentation.Slides[0];

// Προσθέτει ένα αντικείμενο AutoShape με τύπο ορισμένο ως Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Κάνει cast το σχήμα σε AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Προσπελαύνει την ιδιότητα ITextFrame που σχετίζεται με το AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Προσθέτει κάποιο κείμενο στο πλαίσιο
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Ορίζει το Hyperlink για το κείμενο του τμήματος
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Αποθηκεύει την παρουσίαση PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Ποια είναι η διαφορά μεταξύ πλαισίου κειμένου και υπόδειξης κειμένου όταν εργάζεστε με κύριες διαφάνειες;**

Ένα [placeholder](/slides/el/net/manage-placeholder/) κληρονομεί το στυλ/θέση από το [master](https://reference.aspose.com/slides/el/net/aspose.slides/masterslide/) και μπορεί να παρακαμφθεί σε [layouts](https://reference.aspose.com/slides/el/net/aspose.slides/layoutslide/), ενώ ένα κανονικό πλαίσιο κειμένου είναι ανεξάρτητο αντικείμενο σε συγκεκριμένη διαφάνεια και δεν αλλάζει όταν αλλάζετε τα layout.

**Πώς μπορώ να πραγματοποιήσω μαζική αντικατάσταση κειμένου σε ολόκληρη την παρουσίαση χωρίς να επηρεάσω το κείμενο μέσα σε διαγράμματα, πίνακες και SmartArt;**

Περιορίστε την επανάληψη σας σε αυτόματα σχήματα που έχουν πλαίσια κειμένου και εξαιρέστε ενσωματωμένα αντικείμενα ([charts](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/el/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/smartart/)) διασχίζοντας τις συλλογές τους ξεχωριστά ή παραλείποντας αυτούς τους τύπους αντικειμένων.