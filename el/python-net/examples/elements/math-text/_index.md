---
title: Μαθηματικό Κείμενο
type: docs
weight: 160
url: /el/python-net/examples/elements/math-text/
keywords:
- μαθηματικό κείμενο
- προσθήκη μαθηματικού κειμένου
- πρόσβαση σε μαθηματικό κείμενο
- αφαίρεση μαθηματικού κειμένου
- μορφοποίηση μαθηματικού κειμένου
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εργαστείτε με μαθηματικό κείμενο σε Python χρησιμοποιώντας Aspose.Slides: δημιουργήστε και επεξεργαστείτε εξισώσεις, κλάσματα, ρίζες, δείκτες, μορφοποίηση και αποδώστε τα αποτελέσματα για PPT και PPTX."
---
Απεικονίζει τη δουλειά με σχήματα μαθηματικού κειμένου και τη μορφοποίηση εξισώσεων χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη Μαθηματικού Κειμένου**

Δημιουργήστε ένα μαθηματικό σχήμα που περιέχει ένα κλάσμα και τον Πυθαγόρειο τύπο.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Προσθέστε ένα μαθηματικό σχήμα στη διαφάνεια.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Πρόσβαση στην μαθηματική παράγραφο.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Προσθέστε ένα απλό κλάσμα: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Προσθέστε εξίσωση: c² = a² + b².
        math_block = (
            slides.mathtext.MathematicalText("c")
            .set_superscript("2")
            .join("=")
            .join(slides.mathtext.MathematicalText("a").set_superscript("2"))
            .join("+")
            .join(slides.mathtext.MathematicalText("b").set_superscript("2"))
        )
        math_paragraph.add(math_block)

        presentation.save("math_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση Μαθηματικού Κειμένου**

Εντοπίστε ένα σχήμα που περιέχει μια μαθηματική παράγραφο στη διαφάνεια.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Βρείτε το πρώτο σχήμα που περιέχει μια μαθηματική παράγραφο.
        math_shape = next(
            (
                shape for shape in slide.shapes
                if isinstance(shape, slides.AutoShape)
                and shape.text_frame is not None
                and any(
                    any(isinstance(portion, slides.mathtext.MathPortion) for portion in paragraph.portions)
                    for paragraph in shape.text_frame.paragraphs
                )
            ),
            None
        )
```

## **Αφαίρεση Μαθηματικού Κειμένου**

Διαγράψτε ένα μαθηματικό σχήμα από τη διαφάνεια.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι ένα σχήμα με μαθηματικό κείμενο.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Διαμόρφωση Μαθηματικού Κειμένου**

Ορίστε τις ιδιότητες της γραμματοσειράς για ένα μαθηματικό τμήμα.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Υποθέτοντας ότι το πρώτο σχήμα είναι ένα σχήμα με μαθηματικό κείμενο.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```