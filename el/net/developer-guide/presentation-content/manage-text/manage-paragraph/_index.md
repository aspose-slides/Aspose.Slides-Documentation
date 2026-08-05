---
title: Διαχείριση παραγράφων κειμένου PowerPoint σε .NET
linktitle: Διαχείριση παραγράφου
type: docs
weight: 40
url: /el/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
  - προσθήκη κειμένου
  - προσθήκη παραγράφου
  - διαχείριση κειμένου
  - διαχείριση παραγράφου
  - διαχείριση κουκίδας
  - στοίχιση παραγράφου
  - κρεμαστή στοίχιση
  - κουκίδα παραγράφου
  - αριθμημένη λίστα
  - λίστα με κουκίδες
  - ιδιότητες παραγράφου
  - εισαγωγή HTML
  - κείμενο σε HTML
  - παράγραφος σε HTML
  - παράγραφος σε εικόνα
  - κείμενο σε εικόνα
  - εξαγωγή παραγράφου
  - PowerPoint
  - παρουσίαση
  - .NET
  - C#
  - Aspose.Slides
description: "Αποκτήστε τον έλεγχο της μορφοποίησης παραγράφων με το Aspose.Slides για .NET—βελτιστοποιήστε την στοίχιση, το διάστιχο και το στυλ σε παρουσιάσεις PPT, PPTX και ODP σε C#."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει όλες τις διεπαφές και κλάσεις που χρειάζεστε για να εργάζεστε με κείμενα, παραγράφους και τμήματα του PowerPoint σε C#.

* Το Aspose.Slides παρέχει τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν μια παράγραφο. Ένα αντικείμενο `ITextFame` μπορεί να περιέχει μία ή πολλαπλές παραγράφους (κάθε παράγραφος δημιουργείται μέσω αλλαγής γραμμής).
* Το Aspose.Slides παρέχει τη διεπαφή [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν τμήματα. Ένα αντικείμενο `IParagraph` μπορεί να περιέχει ένα ή πολλαπλά τμήματα (συλλογή αντικειμένων iPortions).
* Το Aspose.Slides παρέχει τη διεπαφή [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/) ώστε να μπορείτε να προσθέτετε αντικείμενα που αντιπροσωπεύουν κείμενα και τις ιδιότητες μορφοποίησής τους.

Ένα αντικείμενο `IParagraph` είναι ικανό να διαχειρίζεται κείμενα με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `IPortion`.

## **Προσθήκη Πολλών Παραγράφων που Περιέχουν Πολλά Τμήματα**

Αυτά τα βήματα δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει 3 παραγράφους, και κάθε παράγραφος περιέχει 3 τμήματα:

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Προσπελάστε το αντίστοιχο slide μέσω του δείκτη του.
3. Προσθέστε ένα Rectangle [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Λάβετε το ITextFrame που σχετίζεται με το [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).
5. Δημιουργήστε δύο αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) και προσθέστε τα στη συλλογή `IParagraphs` του [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).
6. Δημιουργήστε τρία αντικείμενα [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/) για κάθε νέο `IParagraph` (δύο αντικείμενα Portion για την προεπιλεγμένη Παράγραφο) και προσθέστε κάθε αντικείμενο `IPortion` στη συλλογή IPortion του αντίστοιχου `IParagraph`.
7. Ορίστε κείμενο για κάθε τμήμα.
8. Εφαρμόστε τις επιθυμητές μορφοποιήσεις σε κάθε τμήμα χρησιμοποιώντας τις ιδιότητες μορφοποίησης που παρέχει το αντικείμενο `IPortion`.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
using (Presentation pres = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];

    // Προσθέτει ένα Rectangle IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Πρόσβαση στο TextFrame του AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Δημιουργεί παραγράφους και τμήματα με διαφορετικές μορφές κειμένου
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Διαχείριση Κουκίδων Παραγράφων**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παραγραφές με κουκίδες είναι πάντα πιο εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Προσπελάστε το αντίστοιχο slide μέσω του δείκτη του.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη επιλεγμένη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/).
7. Ορίστε την ιδιότητα `Type` της κουκίδας για την παράγραφο σε `Symbol` και ορίστε τον χαρακτήρα της κουκίδας.
8. Ορίστε το `Text` της παραγράφου.
9. Ορίστε το `Indent` της παραγράφου για την κουκίδα.
10. Ορίστε χρώμα για την κουκίδα.
11. Ορίστε ύψος για την κουκίδα.
12. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
13. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία που δίνεται στα βήματα 7 έως 13.
14. Αποθηκεύστε την παρουσίαση.

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
using (Presentation pres = new Presentation())
{

    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];


    // Προσθέτει και προσπελαύνει το Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Πρόσβαση στο πλαίσιο κειμένου του autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Αφαιρεί την προεπιλεγμένη παράγραφο
    txtFrm.Paragraphs.RemoveAt(0);

    // Δημιουργεί μια παράγραφο
    Paragraph para = new Paragraph();

    // Ορίζει το στυλ και το σύμβολο κουκίδας παραγράφου
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Ορίζει το κείμενο παραγράφου
    para.Text = "Welcome to Aspose.Slides";

    // Ορίζει την εσοχή της κουκίδας
    para.ParagraphFormat.Indent = 25;

    // Ορίζει το χρώμα της κουκίδας
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ορίστε IsBulletHardColor σε true για να χρησιμοποιήσετε το δικό σας χρώμα κουκίδας

    // Ορίζει το ύψος της κουκίδας
    para.ParagraphFormat.Bullet.Height = 100;

    // Προσθέτει την παράγραφο στο πλαίσιο κειμένου
    txtFrm.Paragraphs.Add(para);

    // Δημιουργεί τη δεύτερη παράγραφο
    Paragraph para2 = new Paragraph();

    // Ορίζει τον τύπο και το στυλ της κουκίδας παραγράφου
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Προσθέτει κείμενο παραγράφου
    para2.Text = "This is numbered bullet";

    // Ορίζει την εσοχή της κουκίδας
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ορίστε IsBulletHardColor σε true για να χρησιμοποιήσετε το δικό σας χρώμα κουκίδας

    // Ορίζει το ύψος της κουκίδας
    para2.ParagraphFormat.Bullet.Height = 100;

    // Προσθέτει την παράγραφο στο πλαίσιο κειμένου
    txtFrm.Paragraphs.Add(para2);


    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Διαχείριση Κουκίδων Εικόνας**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παράγραφοι με εικόνα είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Προσπελάστε το αντίστοιχο slide μέσω του δείκτη του.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/).
7. Φορτώστε την εικόνα στο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).
8. Ορίστε τον τύπο κουκίδας σε [Picture](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) και ορίστε την εικόνα.
9. Ορίστε το `Text` της Παραγράφου.
10. Ορίστε το `Indent` της Παραγράφου για την κουκίδα.
11. Ορίστε χρώμα για την κουκίδα.
12. Ορίστε ύψος για την κουκίδα.
13. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
14. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία βάσει των προηγούμενων βημάτων.
15. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation presentation = new Presentation();

// Πρόσβαση στην πρώτη διαφάνεια
ISlide slide = presentation.Slides[0];

// Δημιουργεί την εικόνα για τις κουκίδες
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Προσθέτει και προσπελαύνει το Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Πρόσβαση στο πλαίσιο κειμένου του autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Αφαιρεί την προεπιλεγμένη παράγραφο
textFrame.Paragraphs.RemoveAt(0);

// Δημιουργεί μια νέα παράγραφο
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Ορίζει το στυλ κουκίδας παραγράφου και την εικόνα
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Ορίζει το ύψος της κουκίδας
paragraph.ParagraphFormat.Bullet.Height = 100;

// Προσθέτει την παράγραφο στο πλαίσιο κειμένου
textFrame.Paragraphs.Add(paragraph);

// Αποθηκεύει την παρουσίαση ως αρχείο PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Αποθηκεύει την παρουσίαση ως αρχείο PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Διαχείριση Πολυεπίπεδων Κουκίδων**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι πολυεπίπεδες κουκίδες είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)class.
2. Προσπελάστε το αντίστοιχο slide μέσω του δείκτη του.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη νέα διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) και ορίστε το βάθος σε 0.
7. Δημιουργήστε τη δεύτερη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 1.
8. Δημιουργήστε την τρίτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 2.
9. Δημιουργήστε την τέταρτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 3.
10. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει αρχείο PPTX
using (Presentation pres = new Presentation())
{

    // Πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];
    
    // Προσθέτει και προσπελαύνει Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου autoshape
    ITextFrame text = aShp.AddTextFrame("");
    
    // Καθαρίζει την προεπιλεγμένη παράγραφο
    text.Paragraphs.Clear();

    // Προσθέτει την πρώτη παράγραφο
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ορίζει το επίπεδο κουκίδας
    para1.ParagraphFormat.Depth = 0;

    // Προσθέτει τη δεύτερη παράγραφο
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ορίζει το επίπεδο κουκίδας
    para2.ParagraphFormat.Depth = 1;

    // Προσθέτει την τρίτη παράγραφο
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ορίζει το επίπεδο κουκίδας
    para3.ParagraphFormat.Depth = 2;

    // Προσθέτει την τέταρτη παράγραφο
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ορίζει το επίπεδο κουκίδας
    para4.ParagraphFormat.Depth = 3;

    // Προσθέτει τις παραγράφους στη συλλογή
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Αποθηκεύει την παρουσίαση ως αρχείο PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Διαχείριση Παραγράφου με Προσαρμοσμένη Αριθμημένη Λίστα**

Η διεπαφή [IBulletFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/) παρέχει την ιδιότητα [NumberedBulletStartWith](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/numberedbulletstartwith) και άλλες που επιτρέπουν τη διαχείριση παραγράφων με προσαρμοσμένη αρίθμηση ή μορφοποίηση.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)class.
2. Προσπελάστε τη διαφάνεια που περιέχει την παράγραφο.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) και ορίστε το [NumberedBulletStartWith](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/numberedbulletstartwith) σε 2.
7. Δημιουργήστε τη δεύτερη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 3.
8. Δημιουργήστε την τρίτη παράγραφο μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 7.
9. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Πρόσβαση στο πλαίσιο κειμένου του δημιουργημένου autoshape
	ITextFrame textFrame = shape.TextFrame;

	// Αφαιρεί την προεπιλεγμένη υπάρχουσα παράγραφο
	textFrame.Paragraphs.RemoveAt(0);

	// Πρώτη λίστα
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Στοίχισης Πρώτης Γραμμής για Παράγραφο**

Χρησιμοποιήστε την ιδιότητα [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για να ελέγξετε την στοίχιση της πρώτης γραμμής μιας παραγράφου. Αυτή η ιδιότητα μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετακινεί την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) όταν θέλετε να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές `Indent` για να δείξει πώς η στοίχιση της πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) .
2. Προσπελάστε τη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές [Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) γι’ αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η στοίχιση πρώτης γραμμής των παραγράφων](first_line_indent.png)

## **Ορισμός Κρεμαστής Στοίχισης για Παράγραφο**

Η κρεμαστή στοίχιση είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή ξεκινά αριστερά από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/). Ορίστε το `Indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή προς τα αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) ορίζει τη θέση του αριστερού περιθωρίου του σώματος της παραγράφου, ενώ το [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε κρεμαστή στοίχιση, ορίστε μια θετική τιμή στο `MarginLeft` και μια αρνητική τιμή στο `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, γλῶσσες όρων και άλλες παραγράφους όπου οι τυλιγμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) .
2. Προσπελάστε τη στοχευμένη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για να δημιουργήσετε το εφέ της κρεμαστής στοίχισης.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Η κρεμαστή στοίχιση των παραγράφων](hanging_indent.png)

## **Διαχείριση Ιδιοτήτων Τέλους Παραγράφου**

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
1. Λάβετε τη αναφορά για τη διαφάνεια που περιέχει την παράγραφο μέσω της θέσης της.
1. Προσθέστε ένα ορθογώνιο [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια.
1. Προσθέστε ένα [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) με δύο παραγράφους στο Rectangle.
1. Ορίστε το `FontHeight` και τον τύπο γραμματοσειράς για τις παραγράφους.
1. Ορίστε τις ιδιότητες End για τις παραγράφους.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Εισαγωγή HTML Κειμένου σε Παραγράφους**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για την εισαγωγή κειμένου HTML σε παραγράφους.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
2. Προσπελάστε το αντίστοιχο slide μέσω του δείκτη του.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε και προσπελάστε το `autoshape` [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) .
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `ITextFrame`.
6. Διαβάστε το αρχείο HTML πηγής σε έναν TextReader.
7. Δημιουργήστε την πρώτη παράγραφο μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) .
8. Προσθέστε το περιεχόμενο του αρχείου HTML από τον αναγνώστη TextReader στη [ParagraphCollection](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphcollection/) του TextFrame.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
// Δημιουργεί κενή παρουσίαση
using (Presentation pres = new Presentation())
{
    // Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.Slides[0];

    // Προσθέτει το AutoShape για να φιλοξενήσει το περιεχόμενο HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Προσθέτει πλαίσιο κειμένου στο σχήμα
    ashape.AddTextFrame("");

    // Καθαρίζει όλες τις παραγράφους στο προστιθέμενο πλαίσιο κειμένου
    ashape.TextFrame.Paragraphs.Clear();

    // Φορτώνει το αρχείο HTML χρησιμοποιώντας stream reader
    TextReader tr = new StreamReader("file.html");

    // Προσθέτει το κείμενο από το stream reader HTML στο πλαίσιο κειμένου
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Αποθηκεύει την παρουσίαση
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για την εξαγωγή κειμένων (που περιέχονται σε παραγράφους) σε HTML.

1. Δημιουργήστε μια παρουσίαση της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την επιθυμητή παρουσίαση.
2. Προσπελάστε το αντίστοιχο slide μέσω του δείκτη του.
3. Προσπελάστε το σχήμα που περιέχει το κείμενο που θα εξαχθεί σε HTML.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) του σχήματος.
5. Δημιουργήστε μια εμφάνιση `StreamWriter` και προσθέστε το νέο αρχείο HTML.
6. Παρέχετε ένα αρχικό δείκτη στο StreamWriter και εξάγετε τις επιλεγμένες παραγράφους.

```c#
// Φορτώνει το αρχείο παρουσίασης
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.Slides[0];

    // Πρόσβαση στον απαιτούμενο δείκτη
    int index = 0;

    // Πρόσβαση στο προστεθειμένο σχήμα
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Γράφει τα δεδομένα των παραγράφων σε HTML καθορίζοντας τον αρχικό δείκτη παραγράφου και τον αριθμό των παραγράφων που θα αντιγραφούν
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Αποθήκευση Παραγράφου ως Εικόνα**

Σε αυτήν την ενότητα θα εξετάσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, που αντιπροσωπεύεται από τη διεπαφή [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/), ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν τη λήψη της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `GetImage` από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/), τον υπολογισμό των ορίων της παραγράφου μέσα στο σχήμα και την εξαγωγή της ως bitmap εικόνα. Αυτές οι προσεγγίσεις σας επιτρέπουν να εξάγετε συγκεκριμένα τμήματα του κειμένου από παρουσιάσεις PowerPoint και να τα αποθηκεύσετε ως ξεχωριστές εικόνες, κάτι που μπορεί να είναι χρήσιμο σε διάφορα σενάρια.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Παράδειγμα 1**

Σε αυτό το παράδειγμα, λαμβάνουμε τη δεύτερη παράγραφο ως εικόνα. Για να το επιτύχουμε, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και στη συνέχεια υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Η παράγραφος στη συνέχεια επανασχεδιάζεται πάνω σε μια νέα bitmap εικόνα, η οποία αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα διατηρώντας τις ακριβείς διαστάσεις και μορφοποίηση του κειμένου.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Το αποτέλεσμα:

![The paragraph image](paragraph_to_image_output.png)

**Παράδειγμα 2**

Σε αυτό το παράδειγμα, επεκτείνουμε την προηγούμενη προσέγγιση προσθέτοντας παράγοντες κλιμάκωσης στην εικόνα της παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με παράγοντα κλιμάκωσης `2`. Αυτό επιτρέπει υψηλότερη ανάλυση εξόδου κατά την εξαγωγή της παραγράφου. Τα όρια της παραγράφου υπολογίζονται έπειτα λαμβάνοντας υπόψη την κλίμακα. Η κλιμάκωση μπορεί να είναι ιδιαίτερα χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, για παράδειγμα για χρήση σε εκτυπώσεις υψηλής ποιότητας.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Αποθηκεύει το σχήμα στη μνήμη ως bitmap με κλιμάκωση.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Δημιουργεί bitmap σχήματος από τη μνήμη.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Υπολογίζει τα όρια της δεύτερης παραγράφου.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Υπολογίζει το μέγεθος της εξαγόμενης εικόνας (ελάχιστο μέγεθος - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Προετοιμάζει ένα bitmap για την παράγραφο.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Επανασχεδιάζει την παράγραφο από το bitmap του σχήματος στο bitmap της παραγράφου.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να απενεργοποιήσω εντελώς τη σημειοθέτηση γραμμής μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Χρησιμοποιήστε τη ρύθμιση περιτυλίγματος του πλαισίου κειμένου ([WrapText](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/wraptext/)) για να κλείσετε το περιτύλιγμα, ώστε οι γραμμές να μην σπάνε στα όρια του πλαισίου.

**Πώς μπορώ να λάβω τα ακριβή όρια μιας συγκεκριμένης παραγράφου στη διαφάνεια;**

Μπορείτε να ανακτήσετε το ορθογώνιο που περιβάλλει την παράγραφο (και ακόμη και ένα μόνο τμήμα) για να γνωρίζετε την ακριβή θέση και μέγεθός της στη διαφάνεια.

**Πού ελέγχεται η στοίχιση της παραγράφου (αριστερά/δεξιά/κέντρο/διάσπαρτη);**

Η [Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphformat/alignment/) είναι ρύθμιση επιπέδου παραγράφου στο [ParagraphFormat](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphformat/); εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των μεμονωμένων τμημάτων.

**Μπορώ να ορίσω γλώσσα ορθογραφικού ελέγχου μόνο για μέρος μιας παραγράφου (π.χ. μια λέξη);**

Ναι. Η γλώσσα ορίζεται σε επίπεδο τμήματος ([PortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/languageid/)), οπότε μπορούν να συνυπάρχουν πολλές γλώσσες μέσα σε μία παράγραφο.