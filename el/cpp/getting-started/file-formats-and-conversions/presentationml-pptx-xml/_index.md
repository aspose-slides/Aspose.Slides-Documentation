---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /el/cpp/presentationml-pptx-xml/
---
## **Σχετικά με το PresentationML**
Το PresentationML είναι όνομα μιας οικογένειας μορφών βασισμένων σε XML για έγγραφα παρουσίασης. Το Office OpenXML (OOXML) είναι η μορφή βασισμένη σε XML που εισήχθη στις εφαρμογές Microsoft Office 2007. Το Office OpenXML είναι μορφή περιέκτη για πολλές εξειδικευμένες γλώσσες σήμανσης βασισμένες σε XML. Το PresentationML είναι η γλώσσα σήμανσης που χρησιμοποιεί το Microsoft Office PowerPoint 2007 για την αποθήκευση των εγγράφων του. 

## **PresentationML στο Aspose.Slides for C++**
Τα έγγραφα OOXML PresentationML εμφανίζονται ως αρχεία PPTX που είναι συμπιεσμένα πακέτα XML σύμφωνα με τις προδιαγραφές του [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) . Το Aspose.Slides for C++ υποστηρίζει εκτενώς τη δημιουργία, ανάγνωση, τροποποίηση και εγγραφή εγγράφων PresentationML. Επιπλέον, το Aspose.Slides for C++ είναι ικανό να εξάγει έγγραφα PresentationML σε διαφορετικές ευρέως χρησιμοποιούμενες μορφές εγγράφων όπως PDF, TIFF και XPS. Αυτό είναι δυνατό επειδή το Aspose.Slides for C++ σχεδιάστηκε με στόχο τη πλήρη διαχείριση εγγράφων παρουσίασης και το PresentationML βασικά διατηρεί την εσωτερική παρουσίαση των εγγράφων ως συμπιεσμένο πακέτο XML. 

## **Το PresentationML είναι ανοιχτό, γιατί να χρησιμοποιήσετε το Aspose.Slides for C++**
Επειδή το PresentationML είναι βασισμένο σε XML, είναι απολύτως εφικτό να δημιουργηθούν εφαρμογές για την επεξεργασία και δημιουργία εγγράφων PresentationML χρησιμοποιώντας κλάσεις XML χωρίς να εξαρτώνται από βιβλιοθήκες τρίτων όπως το Aspose.Slides for C++. Ωστόσο, υπάρχουν αρκετά πλεονεκτήματα στη χρήση του Aspose.Slides for C++ σε σχέση με τις κλάσεις XML κατά την εργασία με έγγραφα PresentationML. 

Οι προδιαγραφές του OOXML είναι πολύ μεγάλες, φτάνοντας σε χιλιάδες σελίδες. Αυτό σημαίνει ότι για να χειριστείτε σωστά τα έγγραφα PresentationML, θα πρέπει να αφιερώσετε πολύ χρόνο και προσπάθεια στην κατανόηση της μορφής αυτών των εγγράφων. Από την άλλη πλευρά, χρησιμοποιώντας το Aspose.Slides for C++, χρειάζεται απλώς να χρησιμοποιήσετε τις σχετικές κλάσεις και τις αντίστοιχες μεθόδους/ιδιότητες τους για την εκτέλεση εργασιών που φαίνονται αρκετά σύνθετες όταν γίνονται μέσω κλάσεων XML. 

Ακολουθούν ορισμένα από τα χαρακτηριστικά που ακόμη και δεν είναι διαθέσιμα όταν εργάζεστε με έγγραφα PresentationML μέσω κλάσεων XML: 

- Εξαγωγή εγγράφων PPT σε μορφές PDF, TIFF, XPS
- Εξαγωγή διαφανειών στα έγγραφα PPT σε μορφές SVG
- Απόδοση διαφάνειας σε οποιαδήποτε μορφή εικόνας υποστηρίζεται από το C++ Framework
- Αυτόματη αντιγραφή master από πηγές παρουσιάσεων χρησιμοποιώντας τη λειτουργία κλωνοποίησης
- Εφαρμογή προστασίας σε σχήματα

Ας πάρουμε ένα παράδειγμα εγγράφου PresentationML που περιέχει μία διαφάνεια με ένα πλαίσιο κειμένου που περιέχει το κείμενο “Hello World”. Για να διαβάσετε το κείμενο μέσω κλάσεων XML, θα πρέπει να γράψετε ένα πρόγραμμα που μπορεί να αναλύσει αυτό το απλό κείμενο από το παρακάτω απόσπασμα: 
## **Παράδειγμα**


``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>



```