---
title: Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε C++
linktitle: Εξαγωγή εξισώσεων
type: docs
weight: 30
url: /el/cpp/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Αποκτήστε αδιάκοπη εξαγωγή μαθηματικών εξισώσεων από PowerPoint σε MathML χρησιμοποιώντας το Aspose.Slides για C++ — διατηρήστε τη μορφοποίηση και βελτιώστε τη συμβατότητα."
---
## **Εισαγωγή**

Το Aspose.Slides για C++ σας επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, ίσως χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις στις διαφάνειες (από συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα.

{{% alert color="primary" %}} 
Μπορείτε να εξάγετε εξισώσεις σε MathML, μια δημοφιλής μορφή ή πρότυπο για μαθηματικές εξισώσεις και παρόμοιο περιεχόμενο που εμφανίζεται στο διαδίκτυο και σε πολλές εφαρμογές. 
{{% /alert %}}

## **Αποθήκευση μαθηματικών εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα κώδικα για ορισμένες μορφές εξισώσεων όπως LaTeX, δυσκολεύονται να γράψουν κώδικα για MathML επειδή το τελευταίο προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συνήθως ως μορφή εξόδου και εκτύπωσης σε πολλούς τομείς.

Αυτό το δείγμα κώδικα σας δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **Συχνές Ερωτήσεις**

**Τι εξάγεται ακριβώς σε MathML—ένα παράγραφο ή ένα μεμονωμένο μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη μαθηματική παράγραφο([MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ([MathBlock](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να καταλάβω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματική εξίσωση και όχι απλό κείμενο ή εικόνα;**

Μια εξίσωση βρίσκεται σε ένα[MathPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathportion/) και έχει ένα[MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/). Οι εικόνες και τα συνηθισμένα τμήματα κειμένου χωρίς[MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/) δεν είναι εξαγώγιμες εξισώσεις.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή ένα πρότυπο;**

Η εξαγωγή στοχεύει το πρότυπο MathML (XML). Το Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—το οποίο χρησιμοποιείται ευρέως σε εφαρμογές και στο διαδίκτυο.

**Υποστηρίζεται η εξαγωγή εξισώσεων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με ένα[MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/) (δηλαδή αυθεντικές εξισώσεις PowerPoint), εξάγονται. Εάν μια εξίσωση είναι ενσωματωμένη ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η δημιουργία MathML είναι μια σειριοποίηση του περιεχομένου της εξίσωσης· δεν τροποποιεί το αρχείο της παρουσίασης.