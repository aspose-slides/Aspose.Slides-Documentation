---
title: Προσθήκη Διαφανειών Layout στην Παρουσίαση
type: docs
weight: 20
url: /el/net/add-layout-slides-to-presentation/
---
Η Aspose.Slides for .NET επιτρέπει στους προγραμματιστές να προσθέτουν νέες διαφάνειες Layout στην παρουσίαση. Για να προσθέσετε μια διαφάνεια Layout, ακολουθήστε τα παρακάτω βήματα:

- Δημιουργήστε μια παρουσία της κλάσης Presentation
- Πρόσβαση στη συλλογή Master Slide
- Προσπαθήστε να βρείτε υπάρχουσες διαφάνειες Layout για να δείτε αν η απαιτούμενη υπάρχει ήδη στη συλλογή Layout Slide ή όχι
- Προσθέστε μια νέα διαφάνεια Layout αν το επιθυμητό layout δεν είναι διαθέσιμο
- Προσθέστε μια κενή διαφάνεια με τη νέα προστιθέμενη διαφάνεια Layout
- Τέλος, γράψτε το αρχείο της παρουσίασης χρησιμοποιώντας το αντικείμενο Presentation
## **Παράδειγμα**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει το αρχείο παρουσίασης

using (Presentation p = new Presentation(FileName))

{

    //Προσπάθεια αναζήτησης κατά τύπο διαφάνειας layout

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        //Η περίπτωση όταν μια παρουσίαση δεν περιέχει κάποιον τύπο διαφανειών layout.

        //Η παρουσίαση Technographics.pptx περιέχει μόνο τύπους διαφανειών Blank και Custom.

        //Ωστόσο, οι διαφάνειες layout με τύπους Custom έχουν διαφορετικά ονόματα διαφανειών,

        //όπως "Title", "Title and Content" κ.λπ. Και είναι δυνατό να χρησιμοποιηθεί αυτά

        //ονόματα για επιλογή διαφάνειας layout.

        //Επίσης, είναι δυνατό να χρησιμοποιηθεί το σύνολο των τύπων placeholder σχήματος. Για παράδειγμα,

        //Η διαφάνεια τίτλου πρέπει να έχει μόνο τύπο placeholder Title, κλπ.

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

    //Προσθήκη κενής διαφάνειας με τη προστιθέμενη διαφάνεια layout 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Αποθήκευση παρουσίασης    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Λήψη Δειγματικού Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Λήψη Εκτελέσιμου Παραδείγματος**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20 Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Για περισσότερες λεπτομέρειες, επισκεφθείτε [Εφαρμογή ή Αλλαγή Διατάξεων Διαφάνειας σε .NET](/slides/el/net/slide-layout/).

{{% /alert %}}