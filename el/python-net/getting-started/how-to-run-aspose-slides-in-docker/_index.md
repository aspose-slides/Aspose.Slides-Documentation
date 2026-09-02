---
title: Πώς να εκτελέσετε το Aspose.Slides σε Docker
linktitle: Aspose.Slides σε Docker
type: docs
weight: 150
url: /el/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides σε Docker
- Κοντέινερ Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- γραμματοσειρές
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Εκτέλεση Aspose.Slides για Python μέσω .NET σε Docker: ένα λειτουργικό Dockerfile, οι εγγενείς βιβλιοθήκες που χρειάζεται το πακέτο, ρύθμιση γραμματοσειρών και αδειοδότηση μέσα σε κοντέινερ."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω .NET εκτελείται σε Linux containers, αλλά το πακέτο είναι ένας Python wrapper γύρω από ένα ενσωματωμένο runtime .NET Core 3.1. Αυτό το runtime χρειάζεται τρεις εγγενείς βιβλιοθήκες που δεν περιλαμβάνονται στις ελαφριές εικόνες Python, και είναι ιδιαίτερα απαιτητικό ως προς τις εκδόσεις τους. Αυτό το άρθρο παρέχει ένα Dockerfile που λειτουργεί, εξηγεί γιατί υπάρχει κάθε εξάρτηση, και δείχνει πώς να προσθέσετε γραμματοσειρές και άδεια.

## **Ένα λειτουργικό Dockerfile**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Κατασκευή και εκτέλεση:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Γιατί η βασική εικόνα είναι Debian 11**

Το wheel `aspose.slides` περιέχει ένα runtime **.NET Core 3.1**, και αυτό το runtime προηγορούσε τις εκδόσεις βιβλιοθηκών που περιλαμβάνονται στις τρέχουσες εκδόσεις του Debian. Στα Debian 12 και 13 το container δημιουργείται επιτυχώς και στη συνέχεια αποτυγχάνει στην πρώτη κλήση `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Το μήνυμα είναι παραπλανητικό — το ICU *είναι* εγκατεστημένο σε αυτές τις εικόνες, αλλά είναι ICU 72 ή 76, και το .NET Core 3.1 αναγνωρίζει μόνο παλαιότερες κύριες εκδόσεις. Το Debian 12 επιπλέον περιλαμβάνει OpenSSL 3, που προκαλεί δεύτερο σφάλμα:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` είναι Debian 11, που παρέχει και τις δύο εκδόσεις που περιμένει το ενσωματωμένο runtime:

| Πακέτο | Έκδοση στο Debian 11 | Γιατί απαιτείται |
|---|---|---|
| `libgdiplus` | 6.0.4 | Υλοποίηση GDI+ που χρησιμοποιείται για την απόδοση σχημάτων, κειμένου και εικόνων |
| `libicu67` | 67.1 | Δεδομένα παγκοσμιοποίησης. Οι νεότερες κύριες εκδόσεις δεν αναγνωρίζονται από το .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Κρυπτογραφία. Προεγκατεστημένο στο Debian 11· απουσιάζει στο Debian 12+ |
| `libfontconfig1` | — | Ανακάλυψη γραμματοσειρών |

`libssl1.1` είναι ήδη παρόν στη βασική εικόνα, έτσι δεν χρειάζεται να καταγραφεί στο `apt-get install`.

Αν πρέπει να χρησιμοποιήσετε μια νεότερη βασική εικόνα, ορίστε `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` για να παρακάμψετε την απαίτηση του ICU. Αυτό απενεργοποιεί τη μορφοποίηση συγκεκριμένης κουλτούρας και **δεν** λύνει το πρόβλημα του OpenSSL, έτσι το Debian 11 παραμένει η πιο απλή επιλογή.

## **Γραμματοσειρές**

Οι ελαφριές εικόνες δεν περιέχουν καθόλου γραμματοσειρές. Χωρίς τουλάχιστον μία εγκατεστημένη γραμματοσειρά, το κείμενο εμφανίζεται ως κενά κουτιά σε PDF, εικόνα και έξοδο HTML. Το `fonts-dejavu-core` είναι ένα μικρό γενικού σκοπού σημείο εκκίνησης.

Για να ταιριάξετε την προτιμώμενη εμφάνιση της παρουσίασης, αντιγράψτε τις γραμματοσειρές που χρησιμοποιεί στην εικόνα και κατευθύνετε το Aspose.Slides σε αυτές:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Αδειοδότηση μέσα σε container**

Μην ενσωματώνετε το αρχείο άδειας στην εικόνα — όποιος κατεβάσει την εικόνα λαμβάνει την άδεια. Αντ' αυτού, προσαρτήστε το κατά την εκτέλεση:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Χωρίς άδεια η βιβλιοθήκη λειτουργεί σε κατάσταση αξιολόγησης, η οποία προσθέτει υδατογράφημα και περιορίζει τον αριθμό των επεξεργασμένων διαφανειών. Δείτε το [Αδειοδότηση](/slides/el/python-net/licensing/) για λεπτομέρειες.

## **Μνήμη**

Η απόδοση σε PDF ή εικόνες απαιτεί περισσότερη μνήμη από την ανάγνωση ενός αρχείου. Τα containers με περιορισμένη μνήμη μπορούν να τερματιστούν από το OOM killer κατά τη διάρκεια μιας μετατροπής, κάτι που συνήθως εμφανίζεται ως εξαφάνιση της διαδικασίας χωρίς ανίχνευση σφάλματος Python. Αν συμβεί αυτό, αυξήστε το όριο μνήμης του container πριν ερευνήσετε τον κώδικα.