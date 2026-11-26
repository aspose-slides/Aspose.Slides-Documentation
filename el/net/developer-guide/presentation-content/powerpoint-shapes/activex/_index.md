---
title: Διαχείριση των ActiveX Controls σε Παρουσιάσεις στο .NET
linktitle: ActiveX
type: docs
weight: 80
url: /el/net/activex/
keywords:
- ActiveX
- ActiveX control
- διαχείριση ActiveX
- προσθήκη ActiveX
- τροποποίηση ActiveX
- πρόγραμμα αναπαραγωγής πολυμέσων
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Επεξεργασία πλαισίων κειμένου και κουμπιών ActiveX, ενημέρωση προεπισκοπήσεων ελέγχου και επαναχρήση ελέγχου Windows Media Player σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET."
---
## **Εισαγωγή**

Τα ActiveX controls παρέχουν σε μια διαφάνεια του PowerPoint διαδραστικά στοιχεία όπως πλαίσια κειμένου, κουμπιά εντολών και αναπαραγωγείς πολυμέσων. Το Aspose.Slides για .NET εκθέτει τα controls μιας διαφάνειας μέσω του [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Χρησιμοποιήστε αυτή τη συλλογή για να επεξεργαστείτε ένα control, να το μετακινήσετε στη διαφάνεια ή να το καταργήσετε.

## **Λίστα των ActiveX Controls και των Αποθηκευμένων Ιδιοτήτων τους**

Για να εξετάσετε ένα άγνωστο πρότυπο, ανοίξτε το για ανάγνωση και επαναλάβετε τα controls σε κάθε διαφάνεια. Το παράδειγμα αναφέρει τον αριθμό της διαφάνειας, το όνομα του control, το [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), και κάθε ζεύγος κλειδί‑τιμή στις [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Διαβάζει την παρουσίαση χωρίς να ενεργοποιεί controls, να καλεί γεγονότα ή μακροεντολές, να αλλάζει τιμές ή να αποθηκεύει το αρχείο.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

Η επιλεγμένη έξοδος από `ActiveX.pptm` εμφανίζει ένα πλαίσιο κειμένου και ένα κουμπί εντολής.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Μια κενή συλλογή ιδιοτήτων εμφανίζεται ως `[]`. Για controls που χρησιμοποιούν δυαδική αποθήκευση, οι `Properties` μπορούν να επιστρέψουν `null`, που εμφανίζεται ως `Properties unavailable`. Εάν χρειάζεστε μόνο τα ονόματα, χρησιμοποιήστε το [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) μετά τον έλεγχο του `null`. Η αναφορά καταχωρεί τις ιδιότητες που είναι διαθέσιμες από την παρουσίαση. Ένα control μπορεί να υποστηρίζει επιπλέον ιδιότητες σε χρόνο εκτέλεσης.

## **Τροποποίηση των ActiveX Controls**

Το παράδειγμα αναμένει μια παρουσίαση με υποστήριξη μακροεντολών που περιέχει ένα πλαίσιο κειμένου με όνομα `TextBox1` και ένα κουμπί εντολής με όνομα `CommandButton1` στην πρώτη διαφάνεια. Χρησιμοποιεί τη [συλλογή ιδιοτήτων ελέγχου](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) για να αλλάξει την τιμή του πλαισίου κειμένου και τη λεζάντα του κουμπιού. Κάθε control έχει επίσης μια στατική προεπισκόπηση που το PowerPoint μπορεί να εμφανίσει πριν από την ενεργοποίηση. Παραχωρήστε ένα PNG για κάθε control που να δείχνει το ενημερωμένο κείμενο και την εμφάνισή του. Το παράδειγμα αντιστοιχίζει αυτές τις εικόνες μέσω του [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

Το παράδειγμα μετακινεί κάθε control στην πρώτη διαφάνεια κάτω κατά 100 σημεία αλλάζοντας το [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Αποθηκεύει την επεξεργασμένη παρουσίαση σε μορφή PPTM, στη συνέχεια χρησιμοποιεί το [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) για να αποθηκεύσει ένα δεύτερο αντίγραφο με όλα τα ActiveX controls αφαιρεμένα από αυτή τη διαφάνεια.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```
## **Προσθήκη ενός ActiveX Media Player Control**

Για να επαναχρησιμοποιήσετε ένα ρυθμισμένο Windows Media Player control, ξεκινήστε με ένα πρότυπο του οποίου η πρώτη διαφάνεια περιέχει έναν παίκτη με όνομα `WindowsMediaPlayer1`. Το [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) αντιγράφει ολόκληρη τη διαφάνεια σε μια νέα παρουσίαση. Το παράδειγμα ορίζει το `URL` του παίκτη στη [συλλογή ιδιοτήτων](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) και αποθηκεύει τη κλωνοποιημένη διαφάνεια ως τη μοναδική διαφάνεια στην έξοδο. Το βίντεο παραμένει εξωτερικό, έτσι επιλέξτε μια διαδρομή που ο παίκτης να μπορεί να προσπελάσει κατά την αναπαραγωγή.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```
## **Συχνές Ερωτήσεις**

**Μπορεί το Aspose.Slides να διατηρήσει τα ActiveX controls χωρίς να τα εκτελεί;**

Ναι. Το Aspose.Slides μπορεί να διαβάζει και να αποθηκεύει τα controls, συμπεριλαμβανομένων των ιδιοτήτων και των θέσεών τους, χωρίς να τα ενεργοποιεί.

**Πώς διαφέρουν τα ActiveX controls από τα αντικείμενα OLE;**

Τα ActiveX controls επιτρέπουν στους χρήστες να αλληλεπιδρούν με μια διαφάνεια, για παράδειγμα εισάγοντας κείμενο ή πατώντας ένα κουμπί. Ένα [αντικείμενο OLE](/slides/el/net/manage-ole/) επιτρέπει σε μια διαφάνεια να περιέχει ή να συνδέεται με περιεχόμενο που διαχειρίζεται μια άλλη εφαρμογή, όπως ένα φύλλο εργασίας του Excel.

**Θα εξακολουθούν τα συμβάντα ActiveX να ενεργοποιούν μακροεντολές VBA μετά την αποθήκευση μιας παρουσίασης με το Aspose.Slides;**

Αποθηκεύστε την παρουσίαση σε μορφή που υποστηρίζει μακροεντολές, όπως PPTM, για να διατηρήσετε το έργο VBA. Το PowerPoint για Windows μπορεί να εκτελέσει τους υπάρχοντες χειριστές συμβάντων όταν οι ρυθμίσεις ασφαλείας του επιτρέπουν τόσο τα ActiveX controls όσο και τις μακροεντολές.