---
title: Διαχείριση Υπερσυνδέσμων σε Παρουσιάσεις με Python
linktitle: Διαχείριση Υπερσυνδέσμου
type: docs
weight: 20
url: /el/python-net/manage-hyperlinks/
keywords:
- προσθήκη URL
- προσθήκη υπερσυνδέσμου
- δημιουργία υπερσυνδέσμου
- μορφοποίηση υπερσυνδέσμου
- αφαίρεση υπερσυνδέσμου
- ενημέρωση υπερσυνδέσμου
- υπερσύνδεσμος κειμένου
- υπερσύνδεσμος διαφάνειας
- υπερσύνδεσμος σχήματος
- υπερσύνδεσμος εικόνας
- υπερσύνδεσμος βίντεο
- μεταβλητός υπερσύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
description: "Διαχειριστείτε εύκολα τους υπερσυνδέσμους σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Python μέσω .NET—βελτιώστε την αλληλεπίδραση και τη ροή εργασίας σε λίγα λεπτά."
---
## **Εισαγωγή**

Υπερσύνδεσμος είναι μια αναφορά σε εξωτερική πηγή, ένα αντικείμενο ή ένα στοιχείο δεδομένων, ή σε μια συγκεκριμένη θέση σε ένα αρχείο. Συνηθισμένοι τύποι υπερσυνδέσμων στις παρουσιάσεις PowerPoint περιλαμβάνουν:

* Σύνδεσμοι σε ιστοσελίδες ενσωματωμένοι σε κείμενο, σχήματα ή πολυμέσα
* Σύνδεσμοι σε διαφάνειες

Το Aspose.Slides για Python μέσω .NET παρέχει ένα ευρύ φάσμα λειτουργιών σχετικών με υπερσυνδέσμους σε παρουσιάσεις.

## **Προσθήκη Υπερσυνδέσμων URL**

Αυτή η ενότητα εξηγεί πώς να προσθέσετε υπερσυνδέσμους URL σε στοιχεία διαφάνειας όταν εργάζεστε με το Aspose.Slides. Καλύπτει την ανάθεση διευθύνσεων συνδέσμων σε κείμενο, σχήματα και εικόνες ώστε να εξασφαλιστεί ομαλή πλοήγηση κατά τις παρουσιάσεις.

### **Προσθήκη Υπερσυνδέσμων URL σε Κείμενο**

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε κείμενο:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Προσθήκη Υπερσυνδέσμων URL σε Σχήματα ή Πλαίσια**

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο ιστοσελίδας σε ένα σχήμα:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Προσθήκη Υπερσυνδέσμων URL σε Πολυμέσα**

Το Aspose.Slides σας επιτρέπει να προσθέσετε υπερσυνδέσμους σε εικόνες, αρχεία ήχου και βίντεο.

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να προσθέσετε υπερσύνδεσμο σε μια **εικόνα**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Προσθέστε μια εικόνα στην παρουσίαση.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Δημιουργήστε ένα πλαίσιο εικόνας στη διαφάνεια 1 χρησιμοποιώντας την εικόνα που προστέθηκε προηγουμένως.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να προσθέσετε υπερσύνδεσμο σε ένα **αρχείο ήχου**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να προσθέσετε υπερσύνδεσμο σε ένα **βίντεο**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Ίσως θελήσετε να δείτε [Διαχείριση OLE σε Παρουσιάσεις με Python](/slides/el/python-net/manage-ole/).
{{% /alert %}}

## **Χρήση Υπερσυνδέσμων για Δημιουργία Πίνακα Περιεχομένων**

Επειδή οι υπερσύνδεσμοι σας επιτρέπουν να αναφέρετε αντικείμενα ή θέσεις, μπορείτε να τους χρησιμοποιήσετε για τη δημιουργία πίνακα περιεχομένων.

Ο παρακάτω κώδικας δείχνει πώς να δημιουργήσετε έναν πίνακα περιεχομένων με υπερσυνδέσμους:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Μορφοποίηση Υπερσυνδέσμων**

Αυτή η ενότητα δείχνει πώς να μορφοποιήσετε την εμφάνιση των υπερσυνδέσμων στο Aspose.Slides. Θα μάθετε να ελέγχετε το χρώμα και άλλες επιλογές στυλ ώστε η μορφοποίηση των υπερσυνδέσμων να παραμένει συνεπής σε κείμενο, σχήματα και εικόνες.

### **Χρώμα Υπερσυνδέσμου**

Χρησιμοποιώντας την ιδιότητα [color_source](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/color_source/) της κλάσης [Hyperlink](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/), μπορείτε να ορίσετε το χρώμα ενός υπερσυνδέσμου και να διαβάσετε τις πληροφορίες του χρώματος. Η δυνατότητα αυτή εισήχθη στο PowerPoint 2019, έτσι οι αλλαγές μέσω αυτής της ιδιότητας δεν ισχύουν για παλαιότερες εκδόσεις του PowerPoint.

Το παρακάτω παράδειγμα δείχνει πώς να προσθέσετε υπερσυνδέσμους με διαφορετικά χρώματα στην ίδια διαφάνεια:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Αφαίρεση Υπερσυνδέσμων από Παρουσιάσεις**

Αυτή η ενότητα εξηγεί πώς να αφαιρέσετε υπερσυνδέσμους από παρουσιάσεις όταν εργάζεστε με το Aspose.Slides. Θα μάθετε πώς να διαγράψετε τους προορισμούς των συνδέσμων από κείμενο, σχήματα και εικόνες διατηρώντας το αρχικό περιεχόμενο και τη μορφοποίηση.

### **Αφαίρεση Υπερσυνδέσμων από Κείμενο**

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αφαιρέσετε υπερσυνδέσμους από κείμενο σε μια διαφάνεια παρουσίασης:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Αφαίρεση Υπερσυνδέσμων από Σχήματα ή Πλαίσια**

Το παρακάτω παράδειγμα κώδικα δείχνει πώς να αφαιρέσετε υπερσυνδέσμους από σχήματα σε μια διαφάνεια παρουσίασης: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Μεταβλητοί Υπερσύνδεσμοι**

Η κλάση [Hyperlink](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/) είναι μεταβλητή. Χρησιμοποιώντας αυτήν την κλάση, μπορείτε να αλλάξετε τις τιμές των παρακάτω ιδιοτήτων:

- [target_frame](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να προσθέσετε έναν υπερσύνδεσμο σε μια διαφάνεια και στη συνέχεια να επεξεργαστείτε το tooltip του:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Υποστηριζόμενες Ιδιότητες στο IHyperlinkQueries**

Μπορείτε να έχετε πρόσβαση στο [HyperlinkQueries](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/) από την παρουσίαση, τη διαφάνεια ή το κείμενο που περιέχει τον υπερσύνδεσμο.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/el/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/el/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/el/python-net/aspose.slides/textframe/hyperlink_queries/)

Η κλάση [HyperlinkQueries](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/) υποστηρίζει τις παρακάτω μεθόδους: 

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/el/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Ίσως να θέλετε να δείτε τον απλό, δωρεάν διαδικτυακό [επεξεργαστή PowerPoint](https://products.aspose.app/slides/el/editor) της Aspose.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να δημιουργήσω εσωτερική πλοήγηση όχι μόνο σε μια διαφάνεια, αλλά και σε μια «ενότητα» ή στην πρώτη διαφάνεια μιας ενότητας;**

Οι ενότητες στο PowerPoint είναι ομάδες διαφανειών· η πλοήγηση τεχνικά στοχεύει σε μια συγκεκριμένη διαφάνεια. Για να «πλοηγηθείτε σε μια ενότητα», συνήθως συνδέεστε στην πρώτη διαφάνειά της.

**Μπορώ να συνδέσω έναν υπερσύνδεσμο σε στοιχεία κύριας διαφάνειας ώστε να λειτουργεί σε όλες τις διαφάνειες;**

Ναι. Τα στοιχεία της κύριας διαφάνειας και των διατάξεων υποστηρίζουν υπερσυνδέσμους. Αυτοί οι σύνδεσμοι εμφανίζονται στις θυγατρικές διαφάνειες και είναι κλικαρίσιμα κατά την παρουσίαση.

**Θα διατηρηθούν οι υπερσύνδεσμοι κατά την εξαγωγή σε PDF, HTML, εικόνες ή βίντεο;**

Στα [PDF](/slides/el/python-net/convert-powerpoint-to-pdf/) και [HTML](/slides/el/python-net/convert-powerpoint-to-html/), ναι—οι σύνδεσμοι συνήθως διατηρούνται. Κατά την εξαγωγή σε [εικόνες](/slides/el/python-net/convert-powerpoint-to-png/) και [βίντεο](/slides/el/python-net/convert-powerpoint-to-video/), η δυνατότητα κλικ δεν θα μεταφερθεί λόγω της φύσης αυτών των μορφών (πλαίσια raster/βίντεο δεν υποστηρίζουν υπερσυνδέσμους).