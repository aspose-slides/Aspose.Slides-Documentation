---
title: "Διαχείριση παραγράφων κειμένου PowerPoint στο .NET"
linktitle: "Διαχείριση Παραγράφου"
type: docs
weight: 40
url: /el/net/manage-paragraph/
keywords:
- "προσθήκη κειμένου"
- "προσθήκη παραγράφου"
- "διαχείριση κειμένου"
- "διαχείριση παραγράφου"
- "διαχείριση κουκίδας"
- "εσοχή παραγράφου"
- "κρεμαστή εσοχή"
- "κουκίδα παραγράφου"
- "αριθμημένη λίστα"
- "λίστα με κουκίδες"
- "ιδιότητες παραγράφου"
- "εισαγωγή HTML"
- "κείμενο σε HTML"
- "παράγραφος σε HTML"
- "παράγραφος σε εικόνα"
- "κείμενο σε εικόνα"
- "εξαγωγή παραγράφου"
- "PowerPoint"
- "παρουσίαση"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Απόκτηση πλήρους διαμόρφωσης παραγράφων με το Aspose.Slides για .NET—βελτιστοποίηση στοίχισης, διαστήματος και στυλ σε παρουσιάσεις PPT, PPTX και ODP σε C#."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει όλες τις διεπαφές και κλάσεις που χρειάζεστε για να εργαστείτε με κείμενα, παραγράφους και τμήματα PowerPoint σε C#.

* Το Aspose.Slides παρέχει τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) για να προσθέτετε αντικείμενα που αντιπροσωπεύουν μια παράγραφο. Ένα αντικείμενο `ITextFame` μπορεί να έχει μία ή πολλαπλές παραγράφους (κάθε παράγραφος δημιουργείται μέσω αλλαγής γραμμής).
* Το Aspose.Slides παρέχει τη διεπαφή [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) για να προσθέτετε αντικείμενα που αντιπροσωπεύουν τμήματα. Ένα αντικείμενο `IParagraph` μπορεί να έχει ένα ή πολλαπλά τμήματα (συλλογή αντικειμένων iPortions).
* Το Aspose.Slides παρέχει τη διεπαφή [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/) για να προσθέτετε αντικείμενα που αντιπροσωπεύουν κείμενα και τις ιδιότητες μορφοποίησής τους.

Ένα αντικείμενο `IParagraph` είναι ικανό να διαχειρίζεται κείμενα με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `IPortion`.

## **Προσθήκη Πολλαπλών Παραγράφων που Περιέχουν Πολλαπλά Τμήματα**

Αυτά τα βήματα δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει 3 παραγράφους και κάθε παράγραφος να περιέχει 3 τμήματα:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Λάβετε το ITextFrame που σχετίζεται με το [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).
5. Δημιουργήστε δύο αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/) και προσθέστε τα στη συλλογή `IParagraphs` του [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/).
6. Δημιουργήστε τρία αντικείμενα [IPortion](https://reference.aspose.com/slides/el/net/aspose.slides/iportion/) για κάθε νέο `IParagraph` (δύο Portion objects for default Paragraph) και προσθέστε κάθε `IPortion` object στη συλλογή IPortion του κάθε `IParagraph`.
7. Ορίστε κάποιο κείμενο για κάθε τμήμα.
8. Εφαρμόστε τα προτιμώμενα χαρακτηριστικά μορφοποίησης σε κάθε τμήμα χρησιμοποιώντας τις ιδιότητες μορφοποίησης του αντικειμένου `IPortion`.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation())
{
    // Αποκτά πρόσβαση στην πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];

    // Προσθέτει ένα ορθογώνιο IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Αποκτά πρόσβαση στο TextFrame του AutoShape
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

## **Διαχείριση Κουκίδων Παραγράφου**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παράγραφοι με κουκίδες είναι πάντα πιο εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στην επιλεγμένη διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/).
8. Ορίστε το `Type` της κουκίδας για την παράγραφο σε `Symbol` και ορίστε τον χαρακτήρα της κουκίδας.
9. Ορίστε το `Text` της παραγράφου.
10. Ορίστε το `Indent` της παραγράφου για την κουκίδα.
11. Ορίστε χρώμα για την κουκίδα.
12. Ορίστε ύψος για την κουκίδα.
13. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
14. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία που περιγράφεται στα βήματα 7 έως 13.
15. Αποθηκεύστε την παρουσίαση.

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation())
{

    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];


    // Προσθέτει και προσπελαύνει το Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Προσπελαύνει το πλαίσιο κειμένου του autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Αφαιρεί την προεπιλεγμένη παράγραφο
    txtFrm.Paragraphs.RemoveAt(0);

    // Δημιουργεί μια παράγραφο
    Paragraph para = new Paragraph();

    // Ορίζει το στυλ και το σύμβολο κουκίδας της παραγράφου
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Ορίζει το κείμενο της παραγράφου
    para.Text = "Welcome to Aspose.Slides";

    // Ορίζει την εσοχή της κουκίδας
    para.ParagraphFormat.Indent = 25;

    // Ορίζει το χρώμα της κουκίδας
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ορίζει το IsBulletHardColor σε true για να χρησιμοποιήσει το δικό του χρώμα κουκίδας

    // Ορίζει το ύψος της κουκίδας
    para.ParagraphFormat.Bullet.Height = 100;

    // Προσθέτει την Παράγραφο στο πλαίσιο κειμένου
    txtFrm.Paragraphs.Add(para);

    // Δημιουργεί τη δεύτερη παράγραφο
    Paragraph para2 = new Paragraph();

    // Ορίζει τον τύπο και το στυλ της κουκίδας της παραγράφου
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Προσθέτει κείμενο στην παράγραφο
    para2.Text = "This is numbered bullet";

    // Ορίζει την εσοχή της κουκίδας
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ορίζει το IsBulletHardColor σε true για να χρησιμοποιήσει το δικό του χρώμα κουκίδας

    // Ορίζει το ύψος της κουκίδας
    para2.ParagraphFormat.Bullet.Height = 100;

    // Προσθέτει την Παράγραφο στο πλαίσιο κειμένου
    txtFrm.Paragraphs.Add(para2);


    // Αποθηκεύει την τροποποιημένη παρουσίαση
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Διαχείριση Κουκίδων Εικόνας**

Οι λίστες με κουκίδες σας βοηθούν να οργανώσετε και να παρουσιάσετε πληροφορίες γρήγορα και αποδοτικά. Οι παράγραφοι με εικόνα είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) του autoshape.
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/).
7. Φορτώστε την εικόνα σε [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).
8. Ορίστε τον τύπο της κουκίδας σε [Picture](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) και ορίστε την εικόνα.
9. Ορίστε το `Text` της Paragraph.
10. Ορίστε το `Indent` της Paragraph για την κουκίδα.
11. Ορίστε χρώμα για την κουκίδα.
12. Ορίστε ύψος για την κουκίδα.
13. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
14. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία βάσει των προηγούμενων βημάτων.
15. Αποθηκεύστε την παρουσίαση.

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
Presentation presentation = new Presentation();

// Προσπελαύνει την πρώτη διαφάνεια
ISlide slide = presentation.Slides[0];

// Δημιουργεί την εικόνα για τις κουκίδες
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Προσθέτει και προσπελαύνει το Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Προσπελαύνει το πλαίσιο κειμένου του autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Αφαιρεί την προεπιλεγμένη παράγραφο
textFrame.Paragraphs.RemoveAt(0);

// Δημιουργεί μια νέα παράγραφο
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Ορίζει το στυλ και την εικόνα της κουκίδας της παραγράφου
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

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)class.
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη νέα διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/).
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) και ορίστε το βάθος σε 0.
7. Δημιουργήστε το δεύτερο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 1.
8. Δημιουργήστε το τρίτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 2.
9. Δημιουργήστε το τέταρτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 3.
10. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
using (Presentation pres = new Presentation())
{

    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide slide = pres.Slides[0];
    
    // Προσθέτει και προσπελαύνει το Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Προσπελαύνει το πλαίσιο κειμένου του δημιουργημένου autoshape
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
    // Ορίζει το επίπεδο της κουκίδας
    para1.ParagraphFormat.Depth = 0;

    // Προσθέτει τη δεύτερη παράγραφο
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ορίζει το επίπεδο της κουκίδας
    para2.ParagraphFormat.Depth = 1;

    // Προσθέτει την τρίτη παράγραφο
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ορίζει το επίπεδο της κουκίδας
    para3.ParagraphFormat.Depth = 2;

    // Προσθέτει την τέταρτη παράγραφο
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ορίζει το επίπεδο της κουκίδας
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

Η διεπαφή [IBulletFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/) παρέχει την ιδιότητα [NumberedBulletStartWith](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/numberedbulletstartwith) και άλλες που σας επιτρέπουν να διαχειρίζεστε παραγράφους με προσαρμοσμένη αρίθμηση ή μορφοποίηση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)class.
2. Αποκτήστε την διαφάνεια που περιέχει την παράγραφο.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) στη διαφάνεια.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/).
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/) και ορίστε το [NumberedBulletStartWith](https://reference.aspose.com/slides/el/net/aspose.slides/ibulletformat/numberedbulletstartwith) σε 2.
7. Δημιουργήστε το δεύτερο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 3.
8. Δημιουργήστε το τρίτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 7.
9. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
10. Αποθηκεύστε την παρουσίαση.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Προσπελαύνει το πλαίσιο κειμένου του δημιουργημένου autoshape
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

## **Ορισμός Εσοχής Πρώτης Γραμμής για Παράγραφο**

Χρησιμοποιήστε την ιδιότητα [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η ιδιότητα μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε την [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε την [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές `Indent` για να δείξει πώς η εσοχή της πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Αποκτήστε τη διαφάνεια-στόχο.
3. Προσθέστε ένα όρθιο [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλαπλές παραγράφους και ορίστε διαφορετικές τιμές [Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για αυτές.
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

![The first-line indent of the paragraphs](first_line_indent.png)

## **Ορισμός Κρεμαστής Εσοχής για Παράγραφο**

Μια κρεμαστή εσοχή είναι μια διάταξη παραγράφου στην οποία η πρώτη γραμμή αρχίζει αριστερά από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με την ιδιότητα [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/). Ορίστε το `Indent` σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, η [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) ορίζει τη θέση αριστερά του σώματος της παραγράφου, και η [IParagraphFormat.Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε κρεμαστή εσοχή, ορίστε μια θετική τιμή για το `MarginLeft` και μια αρνητική τιμή για το `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, όρους γλωσσοραίου και άλλες παραγράφους όπου οι αναδιπλωμένες γραμμές πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου αντί κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Αποκτήστε τη διαφάνεια-στόχο.
3. Προσθέστε ένα όρθιο [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [MarginLeft](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/marginleft/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [Indent](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraphformat/indent/) για να δημιουργήσετε το εφέ κρεμαστής εσοχής.
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

![Η κρεμαστή εσοχή των παραγράφων](hanging_indent.png)

## **Διαχείριση Ιδιοτήτων End Paragraph Run**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) .
2. Αποκτήστε την αναφορά της διαφάνειας που περιέχει την παράγραφο μέσω της θέσης της.
3. Προσθέστε ένα ορθογώνιο [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) με δύο παραγράφους στο ορθογώνιο.
5. Ορίστε το `FontHeight` και τον τύπο γραμματοσειράς για τις παραγράφους.
6. Ορίστε τις ιδιότητες End για τις παραγράφους.
7. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

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

## **Εισαγωγή Κειμένου HTML σε Παραγράφους**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για εισαγωγή κειμένου HTML σε παραγράφους.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation).
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε και αποκτήστε πρόσβαση στο `autoshape` [ITextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/itextframe/).
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `ITextFrame`.
6. Διαβάστε το πηγαίο αρχείο HTML με έναν TextReader.
7. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/).
8. Προσθέστε το περιεχόμενο του αρχείου HTML στον διαβασμένο TextReader στη [ParagraphCollection](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphcollection/) του TextFrame.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
// Δημιουργεί κενό στιγμιότυπο παρουσίασης
using (Presentation pres = new Presentation())
{
    // Προσπελαύνει την προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
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

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για εξαγωγή κειμένων (που περιέχονται σε παραγράφους) σε HTML.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την επιθυμητή παρουσίαση.
2. Αποκτήστε την αναφορά της αντίστοιχης διαφάνειας μέσω του δείκτη της.
3. Αποκτήστε το σχήμα που περιέχει το κείμενο που θα εξαχθεί σε HTML.
4. Αποκτήστε το [TextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/) του σχήματος.
5. Δημιουργήστε ένα στιγμιότυπο του `StreamWriter` και προσθέστε το νέο αρχείο HTML.
6. Δώστε έναν αρχικό δείκτη στο StreamWriter και εξάγετε τις προτιμώμενες παραγράφους.

```c#
// Φορτώνει το αρχείο παρουσίασης
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Προσπελαύνει την προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
    ISlide slide = pres.Slides[0];

    // Προσπελαύνει το απαιτούμενο  δείκτη
    int index = 0;

    // Προσπελαύνει το προστεθέν σχήμα
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Γράφει τα δεδομένα των παραγράφων σε HTML καθορίζοντας τον αρχικό δείκτη παραγράφου και τον αριθμό των παραγράφων που θα αντιγραφούν
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Αποθήκευση Παραγράφου ως Εικόνα**

Σε αυτήν την ενότητα, θα εξετάσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, που αντιπροσωπεύεται από τη διεπαφή [IParagraph](https://reference.aspose.com/slides/el/net/aspose.slides/iparagraph/), ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν την απόκτηση της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `GetImage` από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/), τον υπολογισμό των ορίων της παραγράφου μέσα στο σχήμα και την εξαγωγή της ως bitmap εικόνα. Αυτές οι προσεγγίσεις σας επιτρέπουν να εξάγετε συγκεκριμένα τμήματα του κειμένου από παρουσιάσεις PowerPoint και να τα αποθηκεύετε ως ξεχωριστές εικόνες, χρήσιμες για περαιτέρω χρήση σε διάφορα σενάρια.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Παράδειγμα 1**

Σε αυτό το παράδειγμα, λαμβάνουμε τη δεύτερη παράγραφο ως εικόνα. Για να το κάνουμε αυτό, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και στη συνέχεια υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Η παράγραφος στη συνέχεια επανασχεδιάζεται σε μια νέα bitmap εικόνα, η οποία αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα διατηρώντας τις ακριβείς διαστάσεις και τη μορφοποίηση του κειμένου.

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

Σε αυτό το παράδειγμα, επεκτείνουμε την προηγούμενη προσέγγιση προσθέτοντας συντελεστές κλιμάκωσης στην εικόνα της παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με συντελεστή κλιμάκωσης `2`. Αυτό επιτρέπει υψηλότερης ανάλυσης έξοδο όταν εξάγετε την παράγραφο. Τα όρια της παραγράφου υπολογίζονται στη συνέχεια λαμβάνοντας υπόψη την κλίμακα. Η κλιμάκωση μπορεί να είναι ιδιαίτερα χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, για παράδειγμα για χρήση σε υψηλής ποιότητας έντυπο υλικό.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να απενεργοποιήσω πλήρως την αναδίπλωση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Χρησιμοποιήστε τη ρύθμιση αναδίπλωσης του πλαισίου κειμένου ([WrapText](https://reference.aspose.com/slides/el/net/aspose.slides/textframeformat/wraptext/)) για να απενεργοποιήσετε την αναδίπλωση ώστε οι γραμμές να μην σπάζουν στα άκρα του πλαισίου.

**Πώς μπορώ να λάβω τα ακριβή όρια μιας συγκεκριμένης παραγράφου στην διαφάνεια;**

Μπορείτε να ανακτήσετε το ορθογώνιο σύνορο της παραγράφου (και ακόμη ενός μόνο τμήματος) για να γνωρίζετε τη ακριβή θέση και το μέγεθός του στη διαφάνεια.

**Πού ελέγχεται η Στοίχιση παραγράφου (αριστερά/δεξιά/κέντρο/δικαιολογημένο);**

Η [Alignment](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphformat/alignment/) είναι μια ρύθμιση σε επίπεδο παραγράφου στο [ParagraphFormat](https://reference.aspose.com/slides/el/net/aspose.slides/paragraphformat/); εφαρμόζεται σε ολόκληρη την παράγραφο ανεξάρτητα από τη μορφοποίηση των μεμονωμένων τμημάτων.

**Μπορώ να ορίσω γλώσσα ορθογραφικού ελέγχου μόνο για μέρος μιας παραγράφου (π.χ., μια λέξη);**

Ναι. Η γλώσσα ορίζεται σε επίπεδο τμήματος ([PortionFormat.LanguageId](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/languageid/)), ώστε να μπορούν να συνυπάρχουν πολλές γλώσσες μέσα σε μία παράγραφο.