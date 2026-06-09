---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /el/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 
Το PresentationML είναι όνομα για μια οικογένεια μορφών βασισμένων σε XML για έγγραφα παρουσίασης. Το Office OpenXML (OOXML) είναι η μορφή βάσει XML που εισήχθη στις εφαρμογές Microsoft Office 2007. Το Office OpenXML είναι μορφή δομής για πολλές εξειδικευμένες γλώσσες σήμανσης βασισμένες σε XML. Το PresentationML είναι η γλώσσα σήμανσης που χρησιμοποιεί το Microsoft Office PowerPoint 2007 για την αποθήκευση εγγράφων.
{{% /alert %}} 
## **PresentationML στο Aspose.Slides για PHP μέσω Java**
Τα έγγραφα OOXML PresentationML έρχονται ως αρχεία PPTX, συμπιεσμένα πακέτα XML που ακολουθούν την προδιαγραφή [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Το Aspose.Slides για PHP μέσω Java υποστηρίζει εκτενώς τη δημιουργία, ανάγνωση, επεξεργασία και εγγραφή εγγράφων PresentationML. Επιπλέον, το Aspose.Slides για PHP μέσω Java μπορεί να εξάγει έγγραφα PresentationML σε μια ευρέως χρησιμοποιούμενη μορφή εγγράφου όπως το PDF. Αυτό είναι εφικτό επειδή το Aspose.Slides για PHP μέσω Java σχεδιάστηκε με σκοπό την ολοκληρωμένη διαχείριση εγγράφων παρουσίασης και το PresentationML βασικά περιέχει την εσωτερική παρουσίαση των εγγράφων ως ένα συμπιεσμένο πακέτο XML.
**Έγγραφο PPTX που δημιουργήθηκε από το Aspose.Slides για PHP μέσω Java και ανοίχθηκε στο Microsoft PowerPoint**
![todo:image_alt_text](presentationml-pptx-xml_1.png)
**Προβολή του ίδιου εγγράφου PPTX που δημιουργήθηκε από το Aspose.Slides για PHP μέσω Java σε αρχείο ZIP**
![todo:image_alt_text](presentationml-pptx-xml_2.jpg)
## **PresentationML είναι ανοιχτό, γιατί να χρησιμοποιήσετε το Aspose.Slides για PHP μέσω Java;**
Επειδή το PresentationML βασίζεται σε XML, είναι απολύτως εφικτό να δημιουργηθούν εφαρμογές που επεξεργάζονται και παράγουν έγγραφα PresentationML χρησιμοποιώντας κλάσεις XML χωρίς να βασίζονται σε βιβλιοθήκη τρίτου μέρους όπως το Aspose.Slides για PHP μέσω Java. Ωστόσο, υπάρχουν αρκετά πλεονεκτήματα στη χρήση του Aspose.Slides για PHP μέσω Java έναντι των κλάσεων XML όταν εργάζεστε με έγγραφα PresentationML.
Η προδιαγραφή OOXML έχει χιλιάδες σελίδες, έτσι για να διαχειριστείτε σωστά τα έγγραφα PresentationML, πρέπει να δαπανήσετε πολύ χρόνο και προσπάθεια για να κατανοήσετε τη μορφή. Από την άλλη πλευρά, με το Aspose.Slides για PHP μέσω Java, χρησιμοποιείτε απλώς τις κλάσεις και τις μεθόδους και ιδιότητες τους για να εκτελείτε λειτουργίες που φαίνονται σύνθετες αν γίνονται μέσω κλάσεων XML.
Ορισμένα από τα χαρακτηριστικά που προσφέρει το Aspose.Slides δεν είναι ακόμη διαθέσιμα όταν εργάζεστε με έγγραφα PresentationML μέσω κλάσεων XML:
- Εξαγωγή εγγράφων PPT σε μορφή PDF.
- Απόδοση μιας διαφάνειας σε οποιαδήποτε μορφή εικόνας που υποστηρίζεται από το Java Framework.
- Αυτόματη αντιγραφή master από πηγές παρουσιάσεων χρησιμοποιώντας τη λειτουργία κλωνοποίησης.
- Εφαρμογή προστασίας σε σχήματα.
Παρακάτω φαίνεται ένα παράδειγμα εγγράφου PresentationML με μία μοναδική διαφάνεια που περιέχει ένα πλαίσιο κειμένου με το κείμενο “Hello World”. Για να διαβάσετε το κείμενο χρησιμοποιώντας κλάσεις XML, πρέπει να γράψετε ένα πρόγραμμα που μπορεί να αναλύσει αυτό το απλό κείμενο από το παρακάτω απόσπασμα. Το Aspose.Slides το κάνει αυτό για εσάς.
**XML**
``` xml
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
```php
```