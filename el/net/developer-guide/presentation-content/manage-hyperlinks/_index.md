---
title: Διαχείριση Υπερσυνδέσμων Παρουσίασης σε .NET
linktitle: Διαχείριση Υπερσυνδέσμου
type: docs
weight: 20
url: /el/net/manage-hyperlinks/
keywords:
- Προσθήκη URL
- Προσθήκη υπερσυνδέσμου
- Δημιουργία υπερσυνδέσμου
- Μορφοποίηση υπερσυνδέσμου
- Αφαίρεση υπερσυνδέσμου
- Ενημέρωση υπερσυνδέσμου
- Υπερσύνδεσμος κειμένου
- Υπερσύνδεσμος διαφάνειας
- Υπερσύνδεσμος σχήματος
- Υπερσύνδεσμος εικόνας
- Υπερσύνδεσμος βίντεο
- Μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε άψογα τους υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για .NET—βελτιώστε την αλληλεπίδραση και τη ροή εργασίας σε λίγα λεπτά."
---
## **Εισαγωγή**

Ένας υπερσύνδεσμος είναι μια αναφορά σε ένα αντικείμενο ή δεδομένα ή μια θέση σε κάτι. Αυτοί είναι συνηθισμένοι υπερσύνδεσμοι σε παρουσιάσεις PowerPoint:

* Σύνδεσμοι προς ιστοσελίδες μέσα σε κείμενα, σχήματα ή μέσα
* Σύνδεσμοι προς διαφάνειες

Aspose.Slides for .NET σας επιτρέπει να εκτελείτε πολλές εργασίες που αφορούν υπερσυνδέσμους σε παρουσιάσεις. 

{{% alert color="info" %}} 
Ίσως θέλετε να δείτε το απλό, [δωρεάν online επεξεργαστή PowerPoint.](https://products.aspose.app/slides/el/editor)
{{% /alert %}} 

## **Προσθήκη Υπερσυνδέσμων URL**

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Αυτός ο κώδικας C# σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε κείμενο:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα ή Πλαίσια**

Αυτό το δείγμα κώδικα σε C# σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε ένα σχήμα:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Προσθήκη Υπερσυνδέσμων URL σε Πολυμέσα**

Το Aspose.Slides σας επιτρέπει να προσθέτετε υπερσυνδέσμους σε εικόνες, ήχο και αρχεία βίντεο. 

Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια **εικόνα**:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // Προσθέτει εικόνα στην παρουσίαση
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Δημιουργεί πλαίσιο εικόνας στη διαφάνεια 1 βάσει της προηγουμένως προστιθέμενης εικόνας
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **αρχείο ήχου**:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Αυτό το δείγμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε ένα **βίντεο**:
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 
Ίσως θέλετε να δείτε *[Διαχείριση OLE](https://docs.aspose.com/slides/el/net/manage-ole/)*.
{{% /alert %}}

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Επειδή οι υπερσύνδεσμοι σας επιτρέπουν να προσθέτετε αναφορές σε αντικείμενα ή θέσεις, μπορείτε να τους χρησιμοποιήσετε για τη δημιουργία πίνακα περιεχομένων. 

Αυτό το δείγμα κώδικα σας δείχνει πώς να δημιουργήσετε έναν πίνακα περιεχομένων με υπερσυνδέσμους:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Μορφοποίηση Υπερσυνδέσμων**

### **Χρώμα**

Με την ιδιότητα [ColorSource](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/properties/colorsource), στην διεπαφή [IHyperlink](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink), μπορείτε να ορίσετε το χρώμα για τους υπερσυνδέσμους και επίσης να λάβετε τις πληροφορίες χρώματος από τους υπερσυνδέσμους. Η δυνατότητα εισήχθη για πρώτη φορά στο PowerPoint 2019, επομένως οι αλλαγές που αφορούν αυτή την ιδιότητα δεν ισχύουν για παλαιότερες εκδόσεις του PowerPoint.

Αυτό το δείγμα κώδικα δείχνει μια λειτουργία κατά την οποία υπερσύνδεσμοι με διαφορετικά χρώματα προστέθηκαν στην ίδια διαφάνεια:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```

### **Ήχος**

Το Aspose.Slides παρέχει αυτές τις ιδιότητες για να σας επιτρέψει να τονίσετε έναν υπερσύνδεσμο με ήχο:
- [IHyperlink.Sound](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Προσθήκη Ήχου σε Υπερσύνδεσμο**

Αυτός ο κώδικας C# σας δείχνει πώς να ορίσετε τον υπερσύνδεσμο που παίζει ήχο και να τον σταματήσετε με έναν άλλο υπερσύνδεσμο:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// Προσθέτει νέο ήχο στη συλλογή ήχων της παρουσίασης
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Προσθέτει νέο σχήμα με υπερσύνδεσμο στην επόμενη διαφάνεια
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Ελέγχει τον υπερσύνδεσμο για «Χωρίς ήχο»
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Ορίζει τον υπερσύνδεσμο που παίζει ήχο
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Προσθέτει την κενή διαφάνεια 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Προσθέτει νέο σχήμα με τον υπερσύνδεσμο NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Ορίζει τη σημαία υπερσυνδέσμου «Σταμάτημα προηγούμενου ήχου» 
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Εξαγωγή Ήχου από Υπερσύνδεσμο**

Αυτός ο κώδικας C# σας δείχνει πώς να εξάγετε τον ήχο που χρησιμοποιείται σε έναν υπερσύνδεσμο:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Λαμβάνει τον υπερσύνδεσμο του πρώτου σχήματος
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Εξάγει τον ήχο του υπερσυνδέσμου σε πίνακα byte
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

### **Αφαίρεση Υπερσυνδέσμων από Κείμενο**

Αυτός ο κώδικας C# σας δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από κείμενο σε μια διαφάνεια παρουσίασης:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **Αφαίρεση Υπερσυνδέσμων από Σχήματα ή Πλαίσια**

Αυτός ο κώδικας C# σας δείχνει πώς να αφαιρέσετε τον υπερσύνδεσμο από ένα σχήμα σε μια διαφάνεια παρουσίασης: 
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **Μεταβλητός Υπερσύνδεσμος**

Η κλάση [Hyperlink](https://reference.aspose.com/slides/el/net/aspose.slides/hyperlink) είναι μεταβλητή. Με αυτή την κλάση, μπορείτε να αλλάξετε τις τιμές για τις ακόλουθες ιδιότητες:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlink/properties/highlightclick)

Το απόσπασμα κώδικα σας δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια διαφάνεια και να επεξεργαστείτε το tooltip του αργότερα:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Υποστηριζόμενες Ιδιότητες στο IHyperlinkQueries**

Μπορείτε να αποκτήσετε πρόσβαση στο IHyperlinkQueries από μια παρουσίαση, διαφάνεια ή κείμενο για το οποίο ορίζεται ο υπερσύνδεσμος. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Η κλάση IHyperlinkQueries υποστηρίζει αυτές τις μεθόδους και ιδιότητες: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/el/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **Συχνές Ερωτήσεις**

### Πώς μπορώ να δημιουργήσω εσωτερική πλοήγηση όχι μόνο σε μία διαφάνεια, αλλά σε μια «ενότητα» ή στην πρώτη διαφάνεια μιας ενότητας;

Οι ενότητες στο PowerPoint είναι ομάδες διαφανειών· η πλοήγηση τεχνικά στοχεύει σε συγκεκριμένη διαφάνεια. Για να «πλοηγηθείτε σε μια ενότητα», συνήθως συνδέεστε με την πρώτη της διαφάνεια.

### Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία του κύριου master slide ώστε να λειτουργεί σε όλες τις διαφάνειες;

Ναι. Τα στοιχεία του master slide και των διατάξεων υποστηρίζουν υπερσυνδέσμους. Αυτοί οι σύνδεσμοι εμφανίζονται στις θυγατρικές διαφάνειες και είναι κλικαρίσιμα κατά τη διάρκεια της παρουσίασης.

### Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;

Στα [PDF](/slides/el/net/convert-powerpoint-to-pdf/) και [HTML](/slides/el/net/convert-powerpoint-to-html/), ναι — οι σύνδεσμοι διατηρούνται γενικά. Κατά την εξαγωγή σε [εικόνες](/slides/el/net/convert-powerpoint-to-png/) και [βίντεο](/slides/el/net/convert-powerpoint-to-video/), η δυνατότητα κλικ δεν μεταφέρεται λόγω της φύσης των μορφών αυτών (τα ρεαλιστικά καρέ/βίντεο δεν υποστηρίζουν υπερσυνδέσμους).