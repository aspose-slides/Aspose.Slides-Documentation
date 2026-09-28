---
title: Ανάπτυξη και Ενεργοποίηση
type: docs
weight: 20
url: /el/sharepoint/deployment-and-activation/
description: "Τι εγκαθιστά η λύση Aspose.Slides for SharePoint στο farm όταν αναπτύσσεται και τι προσθέτει η δυνατότητα συλλογής τοποθεσιών όταν ενεργοποιείται."
---
## **Ανάπτυξη**

Κατά τη διάρκεια της ανάπτυξης, η λύση Aspose.Slides for SharePoint:

- Εγκαθιστά τη συναρμολόγησή της στη Global Assembly Cache και προσθέτει καταχωρήσεις SafeControl στο αρχείο **web.config**. Στο SharePoint 2010 και μεταγενέστερα, αυτό είναι *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* ή *Aspose.Slides.SharePoint2016.dll* (το πακέτο SharePoint 2019 επίσης εγκαθιστά *Aspose.Slides.SharePoint2016.dll*). Στο SharePoint 2007, είναι *Aspose.Slides.SharePointUI.dll*, μαζί με *Aspose.Slides.SharePoint.Deployment.dll*.
- Αντιγράφει τη σελίδα μετατροπής και τις εικόνες της καθώς και άλλα υποστηρικτικά αρχεία στους φακέλους εγκατάστασης του SharePoint.
- Εγκαθιστά τη δυνατότητα και την καθιστά διαθέσιμη για ενεργοποίηση σε συλλογές τοποθεσιών.

## **Ενεργοποίηση**

Το Aspose.Slides for SharePoint συσκευάζεται ως δυνατότητα συλλογής τοποθεσιών και μπορεί να ενεργοποιηθεί ή να απενεργοποιηθεί σε συλλογές τοποθεσιών. Όταν ενεργοποιείται σε μια συλλογή τοποθεσιών, η δυνατότητα προσθέτει:

- Στο SharePoint 2010 και μεταγενέστερα:
  - το στοιχείο **Convert via Aspose.Slides** στο μενού εγγράφων στις βιβλιοθήκες εγγράφων·
  - την καρτέλα ταινίας **Aspose Tools** με το κουμπί **Convert Slides**, το οποίο μετατρέπει τα επιλεγμένα έγγραφα·
  - το στοιχείο **View Slides** στο μενού των αρχείων PPT, PPTX, PPS και PPSX.
- Στο SharePoint 2007:
  - το στοιχείο **Convert with Aspose.Slides** στο μενού εγγράφων στις βιβλιοθήκες εγγράφων·
  - το στοιχείο **Convert All with Aspose.Slides** στο μενού **Actions** των βιβλιοθηκών εγγράφων.

Στο SharePoint 2007, η ενεργοποίηση κάνει επίσης αλλαγές στον εικονικό κατάλογο της γονικής web εφαρμογής της συλλογής τοποθεσιών. Συγκεκριμένα:

- Προσθέτει τη σελίδα ρυθμίσεων μετατροπής στο αρχείο sitemap.
- Αντιγράφει τα απαραίτητα αρχεία πόρων στο φάκελο App_GlobalResources στον εικονικό κατάλογο.

Το πρόγραμμα εγκατάστασης ενεργοποιεί τη δυνατότητα στις συλλογές τοποθεσιών που επιλέγετε κατά τη διάρκεια της [εγκατάστασης](/slides/el/sharepoint/installing-aspose-slides-for-sharepoint/).