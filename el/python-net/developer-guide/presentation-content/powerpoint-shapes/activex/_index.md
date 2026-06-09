---
title: Διαχείριση ελέγχων ActiveX σε παρουσιάσεις με Python
linktitle: ActiveX
type: docs
weight: 80
url: /el/python-net/activex/
keywords:
- ActiveX
- Έλεγχος ActiveX
- διαχείριση ActiveX
- προσθήκη ActiveX
- τροποποίηση ActiveX
- πρόγραμμα αναπαραγωγής πολυμέσων
- PowerPoint
- παρουσίαση
- Python
- Aspose.Slides
description: "Μάθετε πώς το Aspose.Slides for Python via .NET αξιοποιεί το ActiveX για να αυτοματοποιήσει και να βελτιώσει τις παρουσιάσεις PowerPoint, παρέχοντας στους προγραμματιστές ισχυρό έλεγχο επί των διαφάνειων."
---
## **Εισαγωγή**

Οι έλεγχοι ActiveX χρησιμοποιούνται σε παρουσιάσεις. Το Aspose.Slides for Python via .NET σας επιτρέπει να διαχειρίζεστε ελέγχους ActiveX, αλλά η διαχείρισή τους είναι λίγο πιο δύσκολη και διαφορετική από τα κανονικά σχήματα παρουσίασης. Από το Aspose.Slides for Python via .NET 6.9.0, το στοιχείο υποστηρίζει τη διαχείριση ελέγχων ActiveX. Αυτή τη στιγμή, μπορείτε να προσπελάσετε έναν ήδη προστιθέμενο έλεγχο ActiveX στην παρουσίασή σας και να τον τροποποιήσετε ή να τον διαγράψετε χρησιμοποιώντας τις διάφορες ιδιότητές του. Να θυμάστε, οι έλεγχοι ActiveX δεν είναι σχήματα και δεν ανήκουν στη IShapeCollection της παρουσίασης, αλλά στη ξεχωριστή IControlCollection. Αυτό το άρθρο δείχνει πώς να δουλέψετε με αυτούς.

## **Τροποποίηση ελέγχων ActiveX**

1. Δημιουργήστε μια παρουσία της κλάσης Presentation και φορτώστε την παρουσίαση που περιέχει ελέγχους ActiveX.  
2. Αποκτήστε μια αναφορά σε διαφάνεια με βάση τον δείκτη της.  
3. Προσιθείτε στους ελέγχους ActiveX στη διαφάνεια μέσω του IControlCollection.  
4. Προσιθείτε στον έλεγχο ActiveX TextBox1 χρησιμοποιώντας το αντικείμενο ControlEx.  
5. Αλλάξτε τις διάφορες ιδιότητες του ελέγχου ActiveX TextBox1, όπως κείμενο, γραμματοσειρά, ύψος γραμματοσειράς και θέση πλαισίου.  
6. Προσιθείτε στον δεύτερο έλεγχο πρόσβασης που ονομάζεται CommandButton1.  
7. Αλλάξτε τη λεζάντα του κουμπιού, τη γραμματοσειρά και τη θέση.  
8. Μετακινήστε τη θέση των πλαισίων των ελέγχων ActiveX.  
9. Γράψτε την τροποποιημένη παρουσίαση σε αρχείο PPTX.

Το παρακάτω απόσπασμα κώδικα ενημερώνει τους ελέγχους ActiveX στις διαφάνειες της παρουσίασης όπως φαίνεται παρακάτω.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Πρόσβαση στην παρουσίαση με ελέγχους ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης
    slide = presentation.slides[0]

    # αλλαγή κειμένου TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # αλλαγή εικόνας αντικατάστασης. Το PowerPoint θα αντικαταστήσει αυτήν την εικόνα κατά την ενεργοποίηση του ActiveX, έτσι κάποιες φορές είναι εντάξει να παραμείνει η εικόνα αμετάβλητη.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # αλλαγή λεζάντας κουμπιού
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # αλλαγή αντικατάστασης
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Μετακίνηση πλαισίων ActiveX 100 σημεία προς τα κάτω
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Αποθήκευση της παρουσίασης με επεξεργασμένους ελέγχους ActiveX
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Τώρα αφαιρούνται οι έλεγχοι
    slide.controls.clear()

    # Αποθήκευση της παρουσίασης με εκκαθαρισμένους ελέγχους ActiveX
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Προσθήκη ελέγχου ActiveX Media Player**

1. Δημιουργήστε μια παρουσία της κλάσης Presentation και φορτώστε τη δείγμα παρουσίασης που περιέχει ελέγχους Media Player ActiveX.  
2. Δημιουργήστε μια παρουσία της κλάσης Presentation-στόχο και δημιουργήστε μια κενή παρουσίαση.  
3. Κλωνοποιήστε τη διαφάνεια με τον έλεγχο Media Player ActiveX από την πρότυπη παρουσίαση στην παρουσίαση-στόχο.  
4. Προσιθείτε στην κλωνοποιημένη διαφάνεια στην παρουσίαση-στόχο.  
5. Προσιθείτε στους ελέγχους ActiveX στη διαφάνεια μέσω του IControlCollection.  
6. Προσιθείτε στον έλεγχο Media Player ActiveX και ορίστε τη διαδρομή του βίντεο χρησιμοποιώντας τις ιδιότητές του.  
7. Αποθηκεύστε την παρουσίαση σε αρχείο PPTX.

```py
import aspose.slides as slides

# Δημιουργία αντικειμένου κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Δημιουργία κενής παρουσίασης
    with slides.Presentation() as newPresentation:

        # Αφαίρεση προεπιλεγμένης διαφάνειας
        newPresentation.slides.remove_at(0)

        # Κλωνοποίηση διαφάνειας με έλεγχο Media Player ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Πρόσβαση στον έλεγχο Media Player ActiveX και ορισμός διαδρομής βίντεο
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Αποθήκευση της παρουσίασης
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Συχνές ερωτήσεις**

**Διατηρεί το Aspose.Slides τους ελέγχους ActiveX κατά την ανάγνωση και επανα-αποθήκευση εάν δεν μπορούν να εκτελεστούν στο περιβάλλον Python;**

Ναι. Το Aspose.Slides θεωρεί τους ελέγχους ως μέρος της παρουσίασης και μπορεί να διαβάσει/τροποποιήσει τις ιδιότητές τους και τα πλαίσια· δεν απαιτείται η εκτέλεση των ελέγχων για τη διατήρησή τους.

**Πώς διαφέρουν οι έλεγχοι ActiveX από τα αντικείμενα OLE σε μια παρουσίαση;**

Οι έλεγχοι ActiveX είναι διαδραστικά διαχειριζόμενα στοιχεία (κουμπιά, πεδία κειμένου, media player), ενώ το [OLE](/slides/el/python-net/manage-ole/) αναφέρεται σε ενσωματωμένα αντικείμενα εφαρμογών (για παράδειγμα, ένα φύλλο εργασίας Excel). Αποθηκεύονται και επεξεργάζονται διαφορετικά και έχουν διαφορετικά μοντέλα ιδιοτήτων.

**Λειτουργούν τα γεγονότα ActiveX και οι μακροεντολές VBA εάν το αρχείο έχει τροποποιηθεί από το Aspose.Slides;**

Το Aspose.Slides διατηρεί τη υπάρχουσα σήμανση και μεταδεδομένα· ωστόσο, τα γεγονότα και οι μακροεντολές εκτελούνται μόνο μέσα στο PowerPoint στα Windows όταν η ασφάλεια το επιτρέπει. Η βιβλιοθήκη δεν εκτελεί VBA.