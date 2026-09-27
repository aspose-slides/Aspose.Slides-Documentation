---
title: Aspose.Slides για Android μέσω Java
second_title: Aspose.Slides για Android
type: docs
weight: 40
url: /el/androidjava/
keywords:
- τεκμηρίωση
- επεξεργασία παρουσίασης
- μετατροπή παρουσίασης
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Ξεκινήστε εδώ: προσθέστε το Aspose.Slides για Android μέσω Java στην εφαρμογή σας, δημιουργήστε την πρώτη παρουσίαση και βρείτε τους οδηγούς για κοινές εργασίες, την αναφορά API και την υποστήριξη."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides για Android μέσω Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides για Android μέσω Java είναι μια βιβλιοθήκη κλάσεων για δημιουργία, ανάγνωση, επεξεργασία και μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εφαρμογές Android, χωρίς το Microsoft PowerPoint.

Φορτώνει και αποθηκεύει αρχεία PPT, PPTX, PPS, POT και ODP, συμπεριλαμβανομένων των εκδόσεων με μακροεντολές και προτύπων, και εξάγει σε PDF, XPS, HTML, SVG, TIFF, Markdown και εικόνες.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Ξεκινήστε</b></p>
<hr>
<p>ΞΕΚΙΝΗΣΤΕ</p>
<ul>
<li><a href="/slides/el/androidjava/install-aspose-slides-for-android-via-java/">Εγκατάσταση</a></li>
<li><a href="/slides/el/androidjava/create-presentation/">Δημιουργήστε την πρώτη σας παρουσίαση</a></li>
<li><a href="/slides/el/androidjava/getting-started/">Οδηγός έναρξης</a></li>
</ul>
<p>ΑΞΙΟΛΟΓΗΣΤΕ</p>
<ul>
<li><a href="/slides/el/androidjava/supported-file-formats/">Υποστηριζόμενες μορφές αρχείων</a></li>
<li><a href="/slides/el/androidjava/evaluate-aspose-slides/">Περιορισμοί δοκιμής</a></li>
<li><a href="/slides/el/androidjava/licensing/">Άδειες</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Δημιουργήστε με Slides</b></p>
<hr>
<p>ΚΑΝΟΝΙΚΕΣ ΕΡΓΑΣΙΕΣ</p>
<ul>
<li><a href="/slides/el/androidjava/open-presentation/">Άνοιγμα παρουσίασης</a></li>
<li><a href="/slides/el/androidjava/save-presentation/">Αποθήκευση παρουσίασης</a></li>
<li><a href="/slides/el/androidjava/convert-powerpoint-to-pdf/">Μετατροπή σε PDF</a></li>
<li><a href="/slides/el/androidjava/convert-slide/">Απόδοση διαφανειών ως εικόνες</a></li>
<li><a href="/slides/el/androidjava/manage-text/">Επεξεργασία κειμένου και σχημάτων</a></li>
</ul>
<p>ΡΟΜΠΟΤΑ ΕΡΓΑΣΙΩΝ SLIDES</p>
<ul>
<li><a href="/slides/el/androidjava/powerpoint-charts/">Διαγράμματα</a></li>
<li><a href="/slides/el/androidjava/powerpoint-animation/">Κινούμενα γραφικά</a></li>
<li><a href="/slides/el/androidjava/manage-media-files/">Ήχος και βίντεο</a></li>
<li><a href="/slides/el/androidjava/presentation-design/">Σχεδίαση διαφανειών</a></li>
<li><a href="/slides/el/androidjava/merge-presentation/">Συγχώνευση παρουσιάσεων</a></li>
</ul>
<p>ΠΑΡΑΔΕΙΓΜΑΤΑ</p>
<ul>
<li><a href="/slides/el/androidjava/examples/">Παραδείγματα ανά στοιχείο διαφάνειας</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Αναφορά &amp; Υποστήριξη</b></p>
<hr>
<p>ΑΝΑΦΟΡΑ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/el/androidjava/">Αναφορά API</a></li>
<li><a href="https://releases.aspose.com/slides/el/androidjava/release-notes/">Σημειώσεις έκδοσης</a></li>
<li><a href="/slides/el/androidjava/known-issues/">Γνωστά προβλήματα</a></li>
<li><a href="https://releases.aspose.com/slides/el/androidjava/">Λήψη</a></li>
</ul>
<p>ΥΠΟΣΤΗΡΙΞΗ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/el/11">Δωρεάν φόρουμ υποστήριξης</a></li>
<li><a href="https://helpdesk.aspose.com/">Πληρωμένη υπηρεσία υποστήριξης</a></li>
</ul>
</div>
</div>

------

## **Η πρώτη σας παρουσίαση**

Η βιβλιοθήκη προέρχεται από το αποθετήριο Maven της Aspose. Τα νέα έργα Android Studio διαθέτουν ήδη ένα μπλοκ `dependencyResolutionManagement` στο *settings.gradle.kts*. Προσθέστε τη γραμμή `maven` που φαίνεται παρακάτω στο μπλοκ `repositories` μέσα σε αυτό, αντί να επικολλήσετε ένα δεύτερο μπλοκ:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

Στη συνέχεια προσθέστε τη βιβλιοθήκη στο *app/build.gradle.kts* και συγχρονίστε το έργο:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/el/androidjava/install-aspose-slides-for-android-via-java/) καλύπτει τα σενάρια κατασκευής Groovy, το χειροκίνητο αρχείο JAR και πώς να επιλέξετε μια έκδοση. Ο κώδικας για την πρώτη σας παρουσίαση είναι στο [Create Presentations](/slides/el/androidjava/create-presentation/): προσθέτει ένα πλαίσιο κειμένου σε μια διαφάνεια και αποθηκεύει την παρουσίαση στη μνήμη της εφαρμογής σας. Το δείγμα αυτό έχει μεταγλωττιστεί και κατασκευαστεί ως APK· δεν έχει εκτελεστεί σε συσκευή. Χωρίς άδεια, οι αποθηκευμένες παρουσιάσεις φέρουν υδατογράφημα αξιολόγησης — δείτε το [Licensing](/slides/el/androidjava/licensing/).