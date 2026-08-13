---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /el/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

Το PresentationML είναι ένα όνομα για μια οικογένεια μορφών βασισμένων σε XML για έγγραφα παρουσίασης. Το Office OpenXML (OOXML) είναι η μορφή βασισμένη σε XML που εισήχθη στις εφαρμογές Microsoft Office 2007. Το Office OpenXML είναι μια μορφή κοντέινερ για πολλές εξειδικευμένες γλώσσες σήμανσης βασισμένες σε XML. Το PresentationML είναι η γλώσσα σήμανσης που χρησιμοποιείται από το Microsoft Office PowerPoint 2007 για την αποθήκευση εγγράφων.

{{% /alert %}} 

## **PresentationML στο Aspose.Slides for Java**
Τα έγγραφα OOXML PresentationML εμφανίζονται ως αρχεία PPTX, συμπιεσμένα πακέτα XML που ακολουθούν την προδιαγραφή [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Το Aspose.Slides for Java υποστηρίζει εκτενώς τη δημιουργία, ανάγνωση, επεξεργασία και εγγραφή εγγράφων PresentationML. Επιπλέον, το Aspose.Slides for Java μπορεί να εξάγει έγγραφα PresentationML σε μια ευρέως χρησιμοποιούμενη μορφή εγγράφου όπως το PDF. Αυτό είναι δυνατό επειδή το Aspose.Slides for Java σχεδιάστηκε με στόχο να διαχειρίζεται ολοκληρωμένα έγγραφα παρουσίασης και το PresentationML ουσιαστικά αποθηκεύει την εσωτερική παρουσίαση των εγγράφων ως συμπιεσμένο πακέτο XML.

**Έγγραφο PPTX που δημιουργήθηκε από το Aspose.Slides for Java και ανοίχθηκε στο Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Προβολή του ίδιου εγγράφου PPTX που δημιουργήθηκε από το Aspose.Slides for Java σε αρχείο ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML είναι ανοιχτό, γιατί να χρησιμοποιήσετε το Aspose.Slides for Java?**
Δεδομένου ότι το PresentationML βασίζεται σε XML, είναι απολύτως δυνατό να δημιουργηθούν εφαρμογές για την επεξεργασία και δημιουργία εγγράφων PresentationML χρησιμοποιώντας κλάσσες XML, χωρίς να εξαρτώνται από μια βιβλιοθήκη τρίτου μέρους όπως το Aspose.Slides for Java. Ωστόσο, υπάρχουν αρκετά πλεονεκτήματα στη χρήση του Aspose.Slides for Java σε σχέση με τις κλάσσες XML όταν εργάζεστε με έγγραφα PresentationML.

Η προδιαγραφή OOXML έχει χιλιάδες σελίδες, έτσι για να χειριστείτε σωστά τα έγγραφα PresentationML πρέπει να αφιερώσετε πολλή ώρα και προσπάθεια για να κατανοήσετε τη μορφή. Από την άλλη, με το Aspose.Slides for Java, χρησιμοποιείτε απλώς κλάσσες και τις μεθόδους και ιδιότητές τους για την εκτέλεση εργασιών που φαίνονται πολύπλοκες αν γίνονται μέσω κλάσσων XML.

Μερικά από τα χαρακτηριστικά που προσφέρει το Aspose.Slides δεν είναι καν διαθέσιμα όταν εργάζεστε με έγγραφα PresentationML μέσω κλάσσων XML:

- Εξαγωγή εγγράφων PPT σε μορφή PDF.
- Απόδοση μιας διαφάνειας σε οποιαδήποτε μορφή εικόνας υποστηρίζεται από το Java Framework.
- Αυτόματη αντιγραφή master από μια πηγή παρουσίασης χρησιμοποιώντας τη λειτουργία κλωνοποίησης.
- Εφαρμογή προστασίας σε σχήματα.

Ακολουθεί ένα παράδειγμα εγγράφου PresentationML με μία μόνο διαφάνεια που περιέχει ένα πλαίσιο κειμένου με το κείμενο «Hello World». Για να διαβάσετε το κείμενο χρησιμοποιώντας κλάσσες XML, πρέπει να γράψετε ένα πρόγραμμα που μπορεί να αναλύσει αυτό το απλό κείμενο από το παρακάτω απόσπασμα. Το Aspose.Slides το κάνει αυτό για εσάς.

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
```