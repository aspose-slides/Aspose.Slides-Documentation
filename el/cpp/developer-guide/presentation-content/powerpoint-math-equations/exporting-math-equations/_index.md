---
title: Εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις σε C++
linktitle: Εξαγωγή εξισώσεων
type: docs
weight: 30
url: /el/cpp/exporting-math-equations/
keywords:
- εξαγωγή μαθηματικών εξισώσεων
- εξαγωγή εξισώσεων σε LaTeX
- PowerPoint σε LaTeX
- MathML
- LaTeX
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εξάγετε μαθηματικές εξισώσεις από παρουσιάσεις PowerPoint σε LaTeX ή MathML απευθείας με το Aspose.Slides για C++."
---
## **Εισαγωγή**

Το Aspose.Slides για C++ επιτρέπει την εξαγωγή μαθηματικών εξισώσεων από παρουσιάσεις. Για παράδειγμα, μπορεί να χρειαστείτε να εξάγετε τις μαθηματικές εξισώσεις από τις διαφάνειες (από μια συγκεκριμένη παρουσίαση) και να τις χρησιμοποιήσετε σε άλλο πρόγραμμα ή πλατφόρμα. 

{{% alert color="primary" %}} 
Μπορείτε να εξάγετε τις εξισώσεις απευθείας σε LaTeX ή σε MathML, ένα δημοφιλές πρότυπο για μαθηματικό περιεχόμενο που χρησιμοποιείται στο διαδίκτυο και σε πολλές εφαρμογές.
{{% /alert %}}

## **Εξαγωγή μαθηματικών εξισώσεων σε LaTeX**

Το Aspose.Slides μπορεί να μετατρέψει μια μαθηματική εξίσωση PowerPoint απευθείας σε LaTeX· δεν απαιτείται ενδιάμεσο αρχείο MathML ή εξωτερικός μετατροπέας. Μια μαθηματική εξίσωση αποθηκεύεται σε ένα πλαίσιο κειμένου ως ένα [IMathPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/imathportion/). Χρησιμοποιήστε το [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) για να λάβετε ένα [IMathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/imathparagraph/), και στη συνέχεια καλέστε το [IMathParagraph::ToLatex](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). Η μέθοδος επιστρέφει ένα κείμενο που μπορείτε να αποθηκεύσετε, να εμφανίσετε, να στείλετε σε άλλη εφαρμογή ή να επεξεργαστείτε περαιτέρω.

Το παρακάτω παράδειγμα εξετάζει κάθε πλαίσιο κειμένου σε κάθε διαφάνεια, βρίσκει όλα τα μαθηματικά τμήματα και γράφει κάθε εξίσωση σε ξεχωριστό αρχείο `.tex`:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/el/cpp/aspose.slides.util/slideutil/getalltextboxes/) επιστρέφει όλα τα πλαίσια κειμένου που βρέθηκαν σε μια διαφάνεια. Ο έλεγχος τύπου [IMathPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/imathportion/) διαχωρίζει τις πραγματικές επεξεργάσιμες εξισώσεις από το συνηθισμένο κείμενο και τις εικόνες.

Οι μηχανές LaTeX και τα πρότυπα εγγράφων δεν υποστηρίζουν όλες τις ίδιες εντολές, πακέτα ή χαρακτήρες Unicode. Δοκιμάστε το επιστρεφόμενο κείμενο με τη μηχανή LaTeX που χρησιμοποιεί η εφαρμογή σας. Εάν ένα σύμβολο ή στοιχείο Office Math δεν έχει κατάλληλη αναπαράσταση σε αυτό το περιβάλλον, αντικαταστήστε το στο επιστρεφόμενο κείμενο με εντολή ειδική για το έργο ή παραλείψτε την εξίσωση και καταγράψτε το θέμα για ανασκόπηση.

## **Αποθήκευση μαθηματικών εξισώσεων ως MathML**

Ενώ οι άνθρωποι γράφουν εύκολα τον κώδικα για κάποιες μορφές εξισώσεων όπως το LaTeX, δυσκολεύονται να γράψουν τον κώδικα για το MathML επειδή αυτό προορίζεται να δημιουργείται αυτόματα από εφαρμογές. Τα προγράμματα διαβάζουν και αναλύουν το MathML εύκολα επειδή ο κώδικάς του είναι σε XML, έτσι το MathML χρησιμοποιείται συχνά ως μορφή εξόδου και εκτύπωσης σε πολλά πεδία. 

Αυτός ο κώδικας δείγματος δείχνει πώς να εξάγετε μια μαθηματική εξίσωση από μια παρουσίαση σε MathML:

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

**Τι ακριβώς εξάγεται σε MathML—ένα παράγραφο ή ένα μεμονωμένο μπλοκ τύπου;**  
Μπορείτε να εξάγετε είτε ολόκληρη μαθηματική παράγραφο ([MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/)) είτε ένα μεμονωμένο μπλοκ ([MathBlock](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathblock/)) σε MathML. Και οι δύο τύποι παρέχουν μέθοδο για εγγραφή σε MathML.

**Πώς μπορώ να καταλάβω ότι ένα αντικείμενο σε μια διαφάνεια είναι μαθηματικός τύπος και όχι απλό κείμενο ή εικόνα;**  
Ένας τύπος βρίσκεται σε ένα [MathPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathportion/) και έχει ένα [MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/). Οι εικόνες και τα απλά τμήματα κειμένου χωρίς ένα [MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/) δεν είναι εξαγώγιμοι τύποι.

**Από πού προέρχεται το MathML σε μια παρουσίαση—είναι ειδικό για το PowerPoint ή είναι πρότυπο;**  
Η εξαγωγή στοχεύει το πρότυπο MathML (XML). Το Aspose χρησιμοποιεί το Presentation MathML—το υποσύνολο παρουσίασης του προτύπου—που χρησιμοποιείται εκτενώς σε εφαρμογές και στο διαδίκτυο.

**Υποστηρίζεται η εξαγωγή τύπων μέσα σε πίνακες, SmartArt, ομάδες κ.λπ.;**  
Ναι, εάν αυτά τα αντικείμενα περιέχουν τμήματα κειμένου με ένα [MathParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides.mathtext/mathparagraph/) (δηλαδή αληθινά τύπους PowerPoint), εξάγονται. Εάν ένας τύπος είναι ενσωματωμένος ως εικόνα, δεν εξάγεται.

**Τροποποιεί η εξαγωγή σε MathML την αρχική παρουσίαση;**  
Όχι. Η εγγραφή MathML είναι μια σειριοποίηση του περιεχομένου του τύπου· δεν τροποποιεί το αρχείο παρουσίασης.