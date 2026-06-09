---
title: Διαχείριση κελιών πινάκων σε παρουσιάσεις σε .NET
linktitle: Διαχείριση κελιών
type: docs
weight: 30
url: /el/net/manage-cells/
keywords:
- κελί πίνακα
- συγχώνευση κελιών
- αφαίρεση περιγράμματος
- διαχωρισμός κελιού
- εικόνα σε κελί
- χρώμα φόντου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε άψογα κελία πινάκων στο PowerPoint με το Aspose.Slides για .NET. Κατακτήστε την πρόσβαση, την τροποποίηση και το στυλ των κελιών γρήγορα για αδιάλειπτη αυτοματοποίηση διαφανειών."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να έχετε πρόσβαση και να τροποποιείτε τα κελιά πινάκων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο εξηγεί πώς να εντοπίζετε συγχωνευμένα κελιά πινάκων, να αφαιρείτε τα περιθώρια των κελιών, να εργάζεστε με την αρίθμηση των κελιών μετά τη συγχώνευση ή τη διάσπασή τους, να αλλάζετε το χρώμα υποβάθρου ενός κελιού και να προσθέτετε μια εικόνα μέσα σε κελί πίνακα. Τα παραδείγματα δείχνουν πώς να δημιουργήσετε ή να ανοίξετε μια παρουσίαση, να λάβετε έναν πίνακα από μια διαφάνεια, να ενημερώσετε τη μορφοποίηση του κελιού μέσω των ιδιοτήτων του κελιού και να αποθηκεύσετε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

## **Εντοπισμός Συγχωνευμένου Κελιού Πίνακα**

1. Δημιουργήστε μια νέα παρουσία της[Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)κλάσης.  
2. Λάβετε τον πίνακα από την πρώτη διαφάνεια.  
3. Περιηγηθείτε στις σειρές και στήλες του πίνακα για να βρείτε συγχωνευμένα κελιά.  
4. Εκτυπώστε μήνυμα όταν βρεθούν συγχωνευμένα κελιά.  

Αυτός ο κώδικας C# σας δείχνει πώς να εντοπίσετε συγχωνευμένα κελιά πινάκων σε μια παρουσίαση:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // υποθέτοντας ότι το Slide#0.Shape#0 είναι πίνακας
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Αφαίρεση Περιθωρίων Κελιού Πίνακα**
1. Δημιουργήστε μια νέα παρουσία της `Presentation`κλάσης.  
2. Λάβετε την αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Ορίστε έναν πίνακα στηλών με πλάτος.  
4. Ορίστε έναν πίνακα σειρών με ύψος.  
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου `AddTable`.  
6. Περιηγηθείτε σε κάθε κελί για να καθαρίσετε τα άνω, κάτω, δεξιά και αριστερά περιθώρια.  
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.  

Αυτός ο κώδικας C# σας δείχνει πώς να αφαιρέσετε τα περιθώρια από τα κελιά πινάκων:

```c#
// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
using (Presentation pres = new Presentation())
{
   // Προσπελαύνει την πρώτη διαφάνεια
    Slide sld = (Slide)pres.Slides[0];

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφοποίηση περιγράφματος για κάθε κελί
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Γράφει το αρχείο PPTX στο δίσκο
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Αρίθμηση σε Συγχωνευμένα Κελιά**
Αν συγχωνεύσουμε 2 ζεύγη κελιών (1, 1) × (2, 1) και (1, 2) × (2, 2), ο τελικός πίνακας θα είναι αριθμημένος. Αυτός ο κώδικας C# επιδεικνύει τη διαδικασία:

```c#
 // Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
 using (Presentation presentation = new Presentation())
 {
    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide sld = presentation.Slides[0];

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ορίζει τη μορφοποίηση περιγράμματος για κάθε κελί
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Συγχωνεύει τα κελιά (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Στη συνέχεια συγχωνεύουμε περαιτέρω τα κελιά συγχωνεύοντας το (1, 1) και το (1, 2). Το αποτέλεσμα είναι ένας πίνακας που περιέχει ένα μεγάλο συγχωνευμένο κελί στο κέντρο του:

```c#
 // Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
 using (Presentation presentation = new Presentation())
 {
     // Προσπελαύνει την πρώτη διαφάνεια
     ISlide slide = presentation.Slides[0];

     // Ορίζει στήλες με πλάτη και σειρές με ύψη
     double[] dblCols = { 70, 70, 70, 70 };
     double[] dblRows = { 70, 70, 70, 70 };

     // Προσθέτει σχήμα πίνακα στη διαφάνεια
     ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

     // Ορίζει τη μορφοποίηση περιγράμματος για κάθε κελί
     foreach (IRow row in table.Rows)
     {
         foreach (ICell cell in row)
         {
             cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
             cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
             cell.CellFormat.BorderTop.Width = 5;

             cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
             cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
             cell.CellFormat.BorderBottom.Width = 5;

             cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
             cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
             cell.CellFormat.BorderLeft.Width = 5;

             cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
             cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
             cell.CellFormat.BorderRight.Width = 5;

         }
     }

     // Συγχωνεύει τα κελιά (1, 1) x (2, 1)
     table.MergeCells(table[1, 1], table[2, 1], false);

     // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
     table.MergeCells(table[1, 2], table[2, 2], false);

     // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
     table.MergeCells(table[1, 1], table[1, 2], true);

     //Γράφει το αρχείο PPTX στο δίσκο
     presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
 }
```

## **Αρίθμηση σε Διαχωρισμένο Κελί**
Στα προηγούμενα παραδείγματα, όταν τα κελιά του πίνακα συγχωνεύτηκαν, η αρίθμηση ή το σύστημα αριθμών σε άλλα κελιά δεν άλλαζε.  

Αυτή τη φορά παίρνουμε έναν κανονικό πίνακα (πίνακα χωρίς συγχωνευμένα κελιά) και στη συνέχεια προσπαθούμε να διαχωρίσουμε το κελί (1,1) για να δημιουργήσουμε έναν ιδιαίτερο πίνακα. Ίσως θέλετε να δώσετε προσοχή στην αρίθμηση αυτού του πίνακα, η οποία μπορεί να φαίνεται περίεργη. Ωστόσο, έτσι αριθμεί τα κελιά πίνακα το Microsoft PowerPoint και το Aspose.Slides κάνει το ίδιο.  

Αυτός ο κώδικας C# επιδεικνύει τη διαδικασία που περιγράψαμε:

```c#
 // Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
 using (Presentation presentation = new Presentation())
 {
     // Προσπελαύνει την πρώτη διαφάνεια
     ISlide slide = presentation.Slides[0];

     // Ορίζει στήλες με πλάτη και σειρές με ύψη
     double[] dblCols = { 70, 70, 70, 70 };
     double[] dblRows = { 70, 70, 70, 70 };

     // Προσθέτει σχήμα πίνακα στη διαφάνεια
     ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

     // Ορίζει τη μορφοποίηση περιγράμματος για κάθε κελί
     foreach (IRow row in table.Rows)
     {
         foreach (ICell cell in row)
         {
             cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
             cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
             cell.CellFormat.BorderTop.Width = 5;

             cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
             cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
             cell.CellFormat.BorderBottom.Width = 5;

             cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
             cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
             cell.CellFormat.BorderLeft.Width = 5;

             cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
             cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
             cell.CellFormat.BorderRight.Width = 5;

         }
     }

     // Συγχωνεύει τα κελιά (1, 1) x (2, 1)
     table.MergeCells(table[1, 1], table[2, 1], false);

     // Συγχωνεύει τα κελιά (1, 2) x (2, 2)
     table.MergeCells(table[1, 2], table[2, 2], false);

     // Διαίρει το κελί (1, 1). 
     table[1, 1].SplitByWidth(table[2, 1].Width / 2);

     //Γράφει το αρχείο PPTX στο δίσκο
     presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
 }
```

## **Αλλαγή Χρώματος Υποβάθρου Κελιού Πίνακα**

Αυτός ο κώδικας C# σας δείχνει πώς να αλλάξετε το χρώμα υποβάθρου ενός κελιού πίνακα:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // δημιουργεί νέο πίνακα
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // ορίζει το χρώμα φόντου για ένα κελί 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Προσθήκη Εικόνας Μέσα σε Κελί Πίνακα**

1. Δημιουργήστε μια νέα παρουσία της`Presentation`κλάσης.  
2. Λάβετε την αναφορά σε μια διαφάνεια μέσω του δείκτη της.  
3. Ορίστε έναν πίνακα στηλών με πλάτος.  
4. Ορίστε έναν πίνακα σειρών με ύψος.  
5. Προσθέστε έναν πίνακα στη διαφάνεια μέσω της μεθόδου `AddTable`.  
6. Δημιουργήστε ένα αντικείμενο `Bitmap` για να κρατήσει το αρχείο εικόνας.  
7. Προσθέστε την εικόνα bitmap στο αντικείμενο `IPPImage`.  
8. Ορίστε το `FillFormat` για το Κελί Πίνακα σε `Picture`.  
9. Προσθέστε την εικόνα στο πρώτο κελί του πίνακα.  
10. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX  

Αυτός ο κώδικας C# σας δείχνει πώς να τοποθετήσετε μια εικόνα μέσα σε κελί πίνακα κατά τη δημιουργία πίνακα:

```c#
// Δημιουργεί μια παρουσία της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
using (Presentation presentation = new Presentation())
{
    // Προσπελαύνει την πρώτη διαφάνεια
    ISlide slide = presentation.Slides[0];

    // Ορίζει στήλες με πλάτη και σειρές με ύψη
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Προσθέτει σχήμα πίνακα στη διαφάνεια
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Φορτώνει εικόνα από αρχείο και την προσθέτει στους πόρους της παρουσίασης
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Προσθέτει την εικόνα στο πρώτο κελί του πίνακα
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Αποθηκεύει το αρχείο PPTX στο δίσκο
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ορίσω διαφορετικά πάχη και στυλ γραμμής για τις διαφορετικές πλευρές ενός μόνο κελιού;**

Ναι. Τα περιθώρια[top](https://reference.aspose.com/slides/el/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/el/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/el/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/el/net/aspose.slides/cellformat/borderright/) έχουν ξεχωριστές ιδιότητες, έτσι ώστε το πάχος και το στυλ κάθε πλευράς να μπορεί να διαφέρει. Αυτό ακολουθεί λογικά τον έλεγχο περιθωρίων ανά πλευρά για ένα κελί που δείχνεται στο άρθρο.

**Τι συμβαίνει με την εικόνα αν αλλάξω το μέγεθος στήλης/γραμμής μετά τον ορισμό μιας εικόνας ως φόντο του κελιού;**

Η συμπεριφορά εξαρτάται από τη[fill mode](https://reference.aspose.com/slides/el/net/aspose.slides/picturefillmode/)(stretch/tile). Με το stretching, η εικόνα προσαρμόζεται στο νέο κελί· με το tiling, τα πλακίδια επανυπολογίζονται. Το άρθρο αναφέρει τις μορφές εμφάνισης της εικόνας σε κελί.

**Μπορώ να προσθέσω υπερσύνδεσμο σε όλο το περιεχόμενο ενός κελιού;**

[Hyperlinks](/slides/el/net/manage-hyperlinks/) ορίζονται σε επίπεδο κειμένου (portion) μέσα στο πλαίσιο κειμένου του κελιού ή σε επίπεδο ολόκληρου πίνακα/σχήματος. Στην πράξη, ορίζετε τον σύνδεσμο σε μια portion ή σε όλο το κείμενο του κελιού.

**Μπορώ να ορίσω διαφορετικές γραμματοσειρές μέσα σε ένα μόνο κελί;**

Ναι. Το πλαίσιο κειμένου ενός κελιού υποστηρίζει[portions](https://reference.aspose.com/slides/el/net/aspose.slides/portion/)(runs) με ανεξάρτητη μορφοποίηση — οικογένεια γραμματοσειράς, στυλ, μέγεθος και χρώμα.