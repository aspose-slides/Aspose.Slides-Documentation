---
title: Προσθήκη διαφάνειας διάταξης στην παρουσίαση
type: docs
weight: 10
url: /el/net/add-layout-slide-to-presentation/
---
Το Aspose.Slides για .NET επιτρέπει στους προγραμματιστές να προσθέσουν νέες Διαφάνειες Διάταξης σε παρουσίαση. Για να προσθέσετε μια Διαφάνεια Διάταξης, παρακαλούμε ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε ένα αντικείμενο της κλάσης Presentation
- Αποκτήστε πρόσβαση στη συλλογή Master Slide
- Δοκιμάστε να βρείτε υπάρχουσες Διαφάνειες Διάταξης για να δείτε αν η απαιτούμενη είναι ήδη διαθέσιμη στη συλλογή Layout Slide ή όχι
- Προσθέστε μια νέα Διαφάνεια Διάταξης εάν η επιθυμητή διάταξη δεν είναι διαθέσιμη
- Προσθέστε μια κενή διαφάνεια με τη νέα προστιθέμενη Διαφάνεια Διάταξης
- Τέλος, γράψτε το αρχείο παρουσίασης χρησιμοποιώντας το αντικείμενο Presentation.
## **Παράδειγμα**
``` csharp

 //Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης

using (Presentation p = new Presentation("Test.pptx"))

{

   // Προσπάθεια αναζήτησης κατά τύπο διαφάνειας διάταξης

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // Η περίπτωση όταν μια παρουσίαση δεν περιέχει κάποιον τύπο διατάξεων.

     // Η παρουσίαση Technographics.pptx περιέχει μόνο τύπους διατάξεων Blank και Custom.

     // Αλλά οι διαφάνειες διάταξης με τύπους Custom έχουν διαφορετικά ονόματα διαφάνειας,

     // όπως "Title", "Title and Content", κ.ά. Και είναι δυνατόν να χρησιμοποιηθούν αυτά

     // ονόματα για την επιλογή διαφάνειας διάταξης.

     // Επίσης είναι δυνατόν να χρησιμοποιηθεί το σύνολο τύπων σχήματος placeholder. Για παράδειγμα,

     // Η διαφάνεια Title θα πρέπει να έχει μόνο τύπο placeholder Title, κ.λπ.

     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

     {

       if (titleAndObjectLayoutSlide.Name == "Title and Object")

       {

          layoutSlide = titleAndObjectLayoutSlide;

          break;

       }

      }

      if (layoutSlide == null)

      {

         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

         {

            if (titleLayoutSlide.Name == "Title")

            {

                layoutSlide = titleLayoutSlide;

                break;

            }

          }

          if (layoutSlide == null)

          {

             layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

             if (layoutSlide == null)

             {

                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

             }

          }

      }

  }

  //Προσθήκη κενής διαφάνειας με τη προστιθέμενη διαφάνεια διάταξης

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Αποθήκευση παρουσίασης

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Λήψη Εκτελούμενου Παραδείγματος**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Λήψη Δείγματος Κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Για περισσότερες λεπτομέρειες, επισκεφτείτε [Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε .NET](/slides/el/net/slide-layout/).
{{% /alert %}}