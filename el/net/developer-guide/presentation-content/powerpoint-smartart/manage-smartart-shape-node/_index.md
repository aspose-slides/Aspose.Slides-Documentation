---
title: Διαχείριση Κόμβων Σχήματος SmartArt σε Παρουσιάσεις σε .NET
linktitle: Κόμβος Σχήματος SmartArt
type: docs
weight: 30
url: /el/net/manage-smartart-shape-node/
keywords:
- Κόμβος SmartArt
- Υποκόμβος
- Προσθήκη κόμβου
- Θέση κόμβου
- Πρόσβαση σε κόμβο
- Αφαίρεση κόμβου
- Προσαρμοσμένη θέση
- Κόμβος βοηθού
- Μορφή γεμίσματος
- Απόδοση κόμβου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τους κόμβους σχήματος SmartArt σε αρχεία PPT και PPTX με το Aspose.Slides για .NET. Λάβετε σαφή παραδείγματα κώδικα και συμβουλές για τη βελτιστοποίηση των παρουσιάσεών σας."
---
## **Επισκόπηση**

Τα γραφικά SmartArt σε παρουσιάσεις PowerPoint οργανώνονται μέσω κόμβων που περιέχουν κείμενο και ορίζουν τη δομή του διαγράμματος. Το Aspose.Slides σας επιτρέπει να εργάζεστε με αυτούς τους κόμβους SmartArt προγραμματιστικά: να προσθέτετε νέους κόμβους και υποκόμβους, να εισάγετε υποκόμβους σε συγκεκριμένη θέση, να προσπελάζετε υπάρχοντες κόμβους και να διαβάζετε το κείμενο, το επίπεδο και τη θέση τους.

Αυτό το άρθρο εξηγεί πώς να διαχειρίζεστε τους κόμβους σχήματος SmartArt. Δείχνει πώς να αφαιρείτε κόμβους, να εργάζεστε με υποκόμβους με βάση τον δείκτη ή τη θέση, να μετατρέπετε έναν κόμβο βοηθό σε κανονικό κόμβο, να προσαρμόζετε τη θέση, το μέγεθος και την περιστροφή των σχημάτων κόμβου SmartArt, να ορίζετε μορφές γεμίσματος κόμβου και να δημιουργείτε μικρογραφία για έναν υποκόμβο SmartArt.

## **Προσθήκη Κόμβου SmartArt**
Το Aspose.Slides for .NET παρέχει το πιο απλό API για τη διαχείριση των σχημάτων SmartArt με τον ευκολότερο τρόπο. Ο παρακάτω κώδικας δείγμα θα βοηθήσει στην προσθήκη κόμβου και υποκόμβου μέσα σε σχήμα SmartArt.

- Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) και φορτώστε την παρουσίαση με σχήμα SmartArt.  
- Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
- Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
- Ελέγξτε αν το σχήμα είναι τύπου SmartArt και κάντε μετατροπή (typecast) του επιλεγμένου σχήματος σε SmartArt αν είναι SmartArt.  
- Προσθέστε ένα νέο κόμβο στη συλλογή NodeCollection του σχήματος SmartArt και ορίστε το κείμενο στο TextFrame.  
- Στη συνέχεια, προσθέστε έναν υποκόμβο στο νεοδημιουργημένο κόμβο SmartArt και ορίστε το κείμενο στο TextFrame.  
- Αποθηκεύστε την παρουσίαση.

```c#
// Φόρτωση της επιθυμητής παρουσίασης
Presentation pres = new Presentation("AddNodes.pptx");

// Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Μετατρέψτε το σχήμα σε SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Προσθήκη νέου κόμβου SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Προσθήκη κειμένου
        TemNode.TextFrame.Text = "Test";

        // Προσθήκη νέου υποκόμβου στον γονικό κόμβο. Θα προστεθεί στο τέλος της συλλογής
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Προσθήκη κειμένου
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Αποθήκευση παρουσίασης
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Προσθήκη Κόμβου SmartArt σε Συγκεκριμένη Θέση**
Στον παρακάτω κώδικα δείγμα εξηγούμε πώς να προσθέσετε τους υποκόμβους που ανήκουν στους αντίστοιχους κόμβους του σχήματος SmartArt σε συγκεκριμένη θέση.

- Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation`.  
- Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
- Προσθέστε ένα σχήμα SmartArt τύπου StackedList στη διαφάνεια που αποκτήθηκε.  
- Προσπελάστε τον πρώτο κόμβο στο προστεθειμένο σχήμα SmartArt.  
- Στη συνέχεια, προσθέστε τον υποκόμβο για τον επιλεγμένο κόμβο στη θέση 2 και ορίστε το κείμενό του.  
- Αποθηκεύστε την παρουσίαση.

```c#
// Δημιουργία μιας παρουσίασης
Presentation pres = new Presentation();

// Access the presentation slide
ISlide slide = pres.Slides[0];

// Add Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accessing the SmartArt node at index 0
ISmartArtNode node = smart.AllNodes[0];

// Adding new child node at position 2 in parent node
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Add Text
chNode.TextFrame.Text = "Sample Text Added";

// Save Presentation
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Πρόσβαση σε Κόμβο SmartArt**
Ο παρακάτω κώδικας δείγμα θα βοηθήσει στην πρόσβαση στους κόμβους μέσα σε σχήμα SmartArt. Σημειώστε ότι δεν μπορείτε να αλλάξετε το LayoutType του SmartArt, καθώς είναι μόνο για ανάγνωση και ορίζεται μόνο όταν προστίθεται το σχήμα SmartArt.

- Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation` και φορτώστε την παρουσίαση με σχήμα SmartArt.  

- Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  

- Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  

- Ελέγξτε αν το σχήμα είναι τύπου SmartArt και κάντε μετατροπή του επιλεγμένου σχήματος σε SmartArt αν είναι SmartArt.  

- Διασχίστε όλους τους κόμβους μέσα στο σχήμα SmartArt.  

- Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση του κόμβου SmartArt, το επίπεδο και το κείμενο.

  ```c#
  // Φορτώστε την επιθυμητή παρουσίαση
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Μετατρέψτε το σχήμα σε SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Διασχίστε όλους τους κόμβους μέσα στο SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Πρόσβαση στον κόμβο SmartArt με δείκτη i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Εκτύπωση των παραμέτρων του κόμβου SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```

  


## **Πρόσβαση σε Υποκόμβο SmartArt**
Ο παρακάτω κώδικας δείγμα θα βοηθήσει στην πρόσβαση στους υποκόμβους που ανήκουν στους αντίστοιχους κόμβους του σχήματος SmartArt.

- Δημιουργήστε ένα αντικείμενο της κλάσης PresentationEx και φορτώστε την παρουσίαση με σχήμα SmartArt.  
- Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
- Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
- Ελέγξτε αν το σχήμα είναι τύπου SmartArt και κάντε μετατροπή του επιλεγμένου σχήματος σε SmartArtEx αν είναι SmartArt.  
- Διασχίστε όλους τους κόμβους μέσα στο σχήμα SmartArt.  
- Για κάθε επιλεγμένο σχήμα SmartArt, διασχίστε όλους τους υποκόμβους μέσα στον συγκεκριμένο κόμβο.  
- Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση του υποκόμβου, το επίπεδο και το κείμενο.

```c#
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Μετατρέψτε το σχήμα σε SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Διασχίστε όλους τους κόμβους μέσα στο SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Πρόσβαση στον κόμβο SmartArt με δείκτη i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Διασχίζοντας τους υποκόμβους στον κόμβο SmartArt με δείκτη i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Πρόσβαση στον υποκόμβο στο SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Εκτύπωση των παραμέτρων του υποκόμβου SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **Πρόσβαση σε Υποκόμβο SmartArt σε Συγκεκριμένη Θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να προσπελάζουμε τους υποκόμβους σε μια συγκεκριμένη θέση που ανήκουν στους αντίστοιχους κόμβους του σχήματος SmartArt.

- Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation`.  
- Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
- Προσθέστε ένα σχήμα SmartArt τύπου StackedList.  
- Προσπελάστε το προστεθειμένο σχήμα SmartArt.  
- Προσπελάστε τον κόμβο με δείκτη 0 για το πρόσβαση σχήμα SmartArt.  
- Στη συνέχεια, προσπελάστε τον υποκόμβο στη θέση 1 για τον πρόσβαση κόμβο SmartArt χρησιμοποιώντας τη μέθοδο GetNodeByPosition().  
- Προσπελάστε και εμφανίστε πληροφορίες όπως η θέση του υποκόμβου, το επίπεδο και το κείμενο.

```c#
 // Δημιουργία της παρουσίασης
 Presentation pres = new Presentation();

 // Πρόσβαση στην πρώτη διαφάνεια
 ISlide slide = pres.Slides[0];

 // Προσθήκη του σχήματος SmartArt στην πρώτη διαφάνεια
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
 ISmartArtNode node = smart.AllNodes[0];

 // Πρόσβαση στον υποκόμβο στη θέση 1 στον γονικό κόμβο
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // Εκτύπωση των παραμέτρων του υποκόμβου SmartArt
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```



## **Αφαίρεση Κόμβου SmartArt**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt.

- Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation` και φορτώστε την παρουσίαση με σχήμα SmartArt.  
- Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
- Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
- Ελέγξτε αν το σχήμα είναι τύπου SmartArt και κάντε μετατροπή του επιλεγμένου σχήματος σε SmartArt αν είναι SmartArt.  
- Ελέγξτε αν το SmartArt έχει περισσότερους από 0 κόμβους.  
- Επιλέξτε τον κόμβο SmartArt που θα διαγραφεί.  
- Στη συνέχεια, αφαιρέστε τον επιλεγμένο κόμβο χρησιμοποιώντας τη μέθοδο RemoveNode().* Αποθηκεύστε την παρουσίαση.

```c#
// Φορτώστε την επιθυμητή παρουσίαση
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (shape is ISmartArt)
        {
            // Μετατρέψτε το σχήμα σε SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
                ISmartArtNode node = smart.AllNodes[0];

                // Αφαίρεση του επιλεγμένου κόμβου
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Αποθήκευση παρουσίασης
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Αφαίρεση Κόμβου SmartArt σε Συγκεκριμένη Θέση**
Σε αυτό το παράδειγμα, θα μάθουμε πώς να αφαιρέσουμε τους κόμβους μέσα σε σχήμα SmartArt σε συγκεκριμένη θέση.

- Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation` και φορτώστε την παρουσίαση με σχήμα SmartArt.  
- Λάβετε την αναφορά της πρώτης διαφάνειας χρησιμοποιώντας το Index της.  
- Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
- Ελέγξτε αν το σχήμα είναι τύπου SmartArt και κάντε μετατροπή του επιλεγμένου σχήματος σε SmartArt αν είναι SmartArt.  
- Επιλέξτε το σχήμα κόμβου SmartArt με δείκτη 0.  
- Στη συνέχεια, ελέγξτε αν ο επιλεγμένος κόμβος SmartArt έχει περισσότερους από 2 υποκόμβους.  
- Στη συνέχεια, αφαιρέστε τον κόμβο στη θέση 1 χρησιμοποιώντας τη μέθοδο RemoveNodeByPosition().  
- Αποθηκεύστε την παρουσίαση.

```c#
// Φορτώστε την επιθυμητή παρουσίαση             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Μετατρέψτε το σχήμα σε SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Πρόσβαση στον κόμβο SmartArt με δείκτη 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Αφαίρεση του υποκόμβου στη θέση 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Αποθήκευση παρουσίασης
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Ορισμός Προσαρμοσμένης Θέσης για Υποκόμβο σε Αντικείμενο SmartArt**
Τώρα το Aspose.Slides for .NET υποστηρίζει τον καθορισμό των ιδιοτήτων X και Y του SmartArtShape. Το τμήμα κώδικα παρακάτω δείχνει πώς να ορίσετε προσαρμοσμένη θέση, μέγεθος και περιστροφή του SmartArtShape· παρακαλούμε σημειώστε ότι η προσθήκη νέων κόμβων προκαλεί επανυπολογισμό των θέσεων και μεγεθών όλων των κόμβων.

```c#
// Φορτώστε την επιθυμητή παρουσίαση
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Μετακινήστε το σχήμα SmartArt σε νέα θέση
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Αλλάξτε το πλάτος του σχήματος SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Αλλάξτε το ύψος του σχήματος SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Αλλάξτε την περιστροφή του σχήματος SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **Έλεγχος Κόμβου Βοηθού**
Στον παρακάτω κώδικα δείγμα θα εξετάσουμε πώς να εντοπίσουμε Κόμβους Βοηθού στη συλλογή κόμβων SmartArt και να τους αλλάξουμε.

- Δημιουργήστε ένα αντικείμενο της κλάσης PresentationEx και φορτώστε την παρουσίαση με σχήμα SmartArt.  
- Λάβετε την αναφορά της δεύτερης διαφάνειας χρησιμοποιώντας το Index της.  
- Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια.  
- Ελέγξτε αν το σχήμα είναι τύπου SmartArt και κάντε μετατροπή του επιλεγμένου σχήματος σε SmartArtEx αν είναι SmartArt.  
- Διασχίστε όλους τους κόμβους μέσα στο σχήμα SmartArt και ελέγξτε αν είναι Κόμβοι Βοηθού.  
- Αλλάξτε την κατάσταση του Κόμβου Βοηθού σε κανονικό κόμβο.  
- Αποθηκεύστε την παρουσίαση.

```c#
// Δημιουργία μιας παρουσίασης
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Διασχίστε όλα τα σχήματα μέσα στην πρώτη διαφάνεια
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Ελέγξτε αν το σχήμα είναι τύπου SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Μετατρέψτε το σχήμα σε SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Διασχίζοντας όλους τους κόμβους του σχήματος SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Ελέγξτε αν ο κόμβος είναι κόμβος βοηθού
                if (node.IsAssistant)
                {
                    // Ορισμός του κόμβου βοηθού σε false και μετατροπή του σε κανονικό κόμβο
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Αποθήκευση παρουσίασης
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Ορισμός Μορφής Γεμίσματος Κόμβου**
Το Aspose.Slides for .NET καθιστά δυνατή την προσθήκη προσαρμοσμένων σχημάτων SmartArt και τον ορισμό των μορφών γεμίσματος τους. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να προσπελάσετε σχήματα SmartArt και να ορίσετε τη μορφή γεμίσματος χρησιμοποιώντας το Aspose.Slides for .NET.

Ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation`.  
- Λάβετε την αναφορά μιας διαφάνειας χρησιμοποιώντας το index της.  
- Προσθέστε ένα σχήμα SmartArt ορίζοντας το LayoutType του.  
- Ορίστε το FillFormat για τους κόμβους του σχήματος SmartArt.  
- Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στη διαφάνεια
    ISlide slide = presentation.Slides[0];

    // Προσθήκη σχήματος SmartArt και κόμβων
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Ορισμός χρώματος γεμίσματος κόμβου
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Αποθήκευση παρουσίασης
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **Δημιουργία Μικρογραφίας Υποκόμβου SmartArt**
Οι προγραμματιστές μπορούν να δημιουργήσουν μικρογραφία ενός υποκόμβου SmartArt ακολουθώντας τα παρακάτω βήματα:

1. Δημιουργήστε ένα αντικείμενο της κλάσης `Presentation` που αντιπροσωπεύει το αρχείο PPTX.  
1. Προσθέστε SmartArt.  
1. Λάβετε την αναφορά ενός κόμβου χρησιμοποιώντας το Index του.  
1. Λάβετε τη μικρογραφία.  
1. Αποθηκεύστε τη μικρογραφία σε οποιαδήποτε επιθυμητή μορφή εικόνας.

Το παράδειγμα παρακάτω δημιουργεί μια μικρογραφία του υποκόμβου SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η κίνηση του SmartArt;**

Ναι. Το SmartArt θεωρείται κανονικό σχήμα, επομένως μπορείτε να [εφαρμόσετε τυπικές κινούμενες εφέ](/slides/el/net/shape-animation/) (εισόδους, εξόδους, έμφαση, διαδρομές κίνησης) και να ρυθμίσετε το χρονοδιάγραμμα. Μπορείτε επίσης να κινήσετε σχήματα μέσα σε κόμβους SmartArt όταν χρειάζεται.

**Πώς μπορώ αξιόπιστα να εντοπίσω ένα συγκεκριμένο SmartArt σε μια διαφάνεια αν το εσωτερικό του αναγνωριστικό είναι άγνωστο;**

Αναθέστε και αναζητήστε με βάση το [εναλλακτικό κείμενο]https://reference.aspose.com/slides/el/net/aspose.slides/shape/alternativetext/. Ορίζοντας ένα διακριτικό AltText στο SmartArt, μπορείτε να το βρείτε προγραμματιστικά χωρίς να εξαρτάται από εσωτερικά αναγνωριστικά.

**Θα διατηρηθεί η εμφάνιση του SmartArt κατά τη μετατροπή της παρουσίασης σε PDF;**

Ναι. Το Aspose.Slides αποδίδει το SmartArt με υψηλή οπτική πιστότητα κατά την [εξαγωγή σε PDF](/slides/el/net/convert-powerpoint-to-pdf/), διατηρώντας διάταξη, χρώματα και εφέ.

**Μπορώ να εξάγω εικόνα ολόκληρου του SmartArt (για προεπισκοπήσεις ή αναφορές);**

Ναι. Μπορείτε να αποδώσετε ένα σχήμα SmartArt σε [ακατέργαστες μορφές]https://reference.aspose.com/slides/el/net/aspose.slides/shape/getimage/ ή σε [SVG]https://reference.aspose.com/slides/el/net/aspose.slides/shape/writeassvg/ για διανυσματική έξοδο, καθιστώντας το κατάλληλο για μικρογραφίες, αναφορές ή χρήση στο web.