---
title: Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε C++
linktitle: Εξαγωγή Εξισώσεων
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
description: "Ενεργοποιήστε την αδιάβλητη εξαγωγή μαθηματικών εξισώσεων από το PowerPoint σε MathML χρησιμοποιώντας το Aspose.Slides για C++ — διατηρήστε τη μορφοποίηση και βελτιώστε τη συμβατότητα."
---
## **Εισαγωγή**

Το Aspose.Slides for C++ σάς επιτρέπει να εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστεί να εξάγετε τις μαθηματικές εξισώσεις στις διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα. 

{{% alert color="primary" %}} 
Μπορείτε να εξάγετε εξισώσεις σε MathML, μια δημοφιλής μορφή ή πρότυπο για μαθηματικές εξισώσεις και παρόμοιο περιεχόμενο που εμφανίζεται στο διαδίκτυο και σε πολλές εφαρμογές. 
{{% /alert %}}

## **Αποθήκευση μαθηματικών εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για ορισμένες μορφές εξισώσεων όπως LaTeX, δυσκολεύονται να γράψουν τον κώδικα για το MathML, επειδή το τελευταίο προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συχνά ως μορφή εξαγωγής και εκτύπωσης σε πολλούς τομείς. 

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

## **Συχνές ερωτήσεις**

**Τι ακριβώς εξάγεται σε MathML—μια παράγραφος ή ένα μεμονωμένο μπλοκ τύπου;**

Μπορείτε να εξάγετε είτε ολόκληρη παράγραφο μαθηματικών ([MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μια μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να προσδιορίσω αν ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι απλό κείμενο ή εικόνα;**

Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/). Οι εικόνες και οι κανονικές περιοχές κειμένου χωρίς ένα [MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/) δεν είναι εξαγώγιμες τύποι.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό του PowerPoint ή πρότυπο;**

Η εξαγωγή στοχεύει στο πρότυπο MathML (XML). Το Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται εκτενώς σε εφαρμογές και στο διαδίκτυο.

**Υποστηρίζεται η εξαγωγή τύπων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**

Ναι, εφόσον αυτά τα αντικείμενα περιέχουν περιοχές κειμένου με ένα [MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/) (δηλαδή γνήσιους τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**

Όχι. Η εγγραφή του MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο της παρουσίασης.