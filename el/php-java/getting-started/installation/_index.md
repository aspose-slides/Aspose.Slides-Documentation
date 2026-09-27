---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/php-java/installation/
keywords:
- εγκατάσταση Aspose.Slides
- λήψη Aspose.Slides
- χρήση Aspose.Slides
- εγκατάσταση Aspose.Slides
- Windows
- Linux
- PowerPoint
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εγκαταστήστε το Aspose.Slides για PHP μέσω Java σε Linux και Windows: ρυθμίστε το PHP, τη Java, το Apache Tomcat και το PHP/Java Bridge, προσθέστε το πακέτο με το Composer και επαληθεύστε τη ρύθμιση με ένα σύντομο σενάριο."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP via Java λειτουργεί σε δύο διαδικασίες. Το σενάριο PHP χρησιμοποιεί κλάσεις PHP που στέλνουν κάθε κλήση μέσω του PHP/Java Bridge στο Aspose.Slides, το οποίο εκτελείται σε Java μέσα στο Apache Tomcat. Αυτό το άρθρο εξηγεί πώς να ρυθμίσετε και τις δύο πλευρές, να εγκαταστήσετε το πακέτο με το Composer και να εκτελέσετε ένα σύντομο σενάριο για να επαληθεύσετε την εγκατάσταση.

## **Προαπαιτούμενα**

- **PHP 7.0 έως 8.3**, με `allow_url_include = On` στο `php.ini`. Τα σενάρια σας φορτώνουν τη βιβλιοθήκη-πελάτη της γέφυρας, `Java.inc`, από το Tomcat μέσω HTTP. Στα PHP 8.4 και πιο πρόσφατα, το `Java.inc` σταματά με το σφάλμα «end() expects exactly 1 argument» όποτε η επέκταση `xml` του PHP είναι φορτωμένη, και οι εκδόσεις Windows του PHP την φορτώνουν πάντα.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 ή νεότερη**. Ένα JRE είναι αρκετό.
- **Apache Tomcat 9**. Το PHP/Java Bridge είναι βασισμένο στο API `javax.servlet`, το οποίο δεν παρέχεται πλέον από το Tomcat 10 και νεότερες εκδόσεις, έτσι η γέφυρα δεν εκκινείται εκεί.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, η πιο πρόσφατη έκδοση. Η διαδικτυακή του εφαρμογή, `JavaBridge.war`, εκτελείται στο Tomcat.

Αυτό το άρθρο εκτελεί το Tomcat και τα σενάρια PHP στον ίδιο υπολογιστή. Το Aspose.Slides ανοίγει και αποθηκεύει αρχεία μέσα στο Tomcat, επομένως κάθε διαδρομή που περνάτε στα σενάρια σας πρέπει να είναι έγκυρη εκεί.

## **Εγκατάσταση σε Linux**

Αυτές οι εντολές εγκαθιστούν τα πάντα στον προσωπικό φάκελο σας στο Ubuntu 24.04. Σε άλλες διανομές, εγκαταστήστε τα ίδια πακέτα με το πακέτο διαχείρισης της διανομής.

1. Εγκαταστήστε PHP, Composer, Java και τα εργαλεία λήψης, στη συνέχεια ενεργοποιήστε το `allow_url_include` για τη γραμμή εντολών του PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Κατεβάστε το Apache Tomcat 9 και το PHP/Java Bridge, τοποθετήστε το `JavaBridge.war` της γέφυρας στο φάκελο `webapps` του Tomcat και εκκινήστε το Tomcat. Το Tomcat αποσυμπιέζει το αρχείο WAR στο `webapps/JavaBridge` κατά την εκκίνηση:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. Δημιουργήστε έναν φάκελο έργου και εγκαταστήστε το Aspose.Slides for PHP via Java από το [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Σταματήστε το Tomcat, αντιγράψτε το αρχείο JAR του Aspose.Slides από το πακέτο στο φάκελο `WEB-INF/lib` της γέφυρας, αντικαταστήστε το `Java.inc` της γέφυρας με την έκδοση PHP 8 από το πακέτο και εκκινήστε ξανά το Tomcat:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/el/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/el/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   Σε PHP 7, παραλείψτε την αντικατάσταση του `Java.inc`. Το Tomcat χρειάζεται λίγα δευτερόλεπτα για εκκίνηση και πρέπει να είναι ενεργό όποτε τα σενάρια σας χρησιμοποιούν το Aspose.Slides.

## **Εγκατάσταση σε Windows**

1. Εγκαταστήστε το [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows) και προσθέστε το φάκελό του στη μεταβλητή περιβάλλοντος `PATH`. Αντιγράψτε το `php.ini-production` στο `php.ini` στον ίδιο φάκελο. Στο `php.ini`, ορίστε `allow_url_include = On` και αφαιρέστε τα σχόλια από τις γραμμές `extension_dir = "ext"`, `extension=openssl` και `extension=zip`. Το Composer χρειάζεται το `openssl` για λήψη πακέτων και το `zip` για αποσυμπίεση, εκτός εάν είναι εγκατεστημένο το 7‑Zip ή υπάρχει εντολή `unzip` στο `PATH`.

2. Εγκαταστήστε το [Composer](https://getcomposer.org/download/).

3. Εγκαταστήστε τη Java και ορίστε τη μεταβλητή περιβάλλοντος `JAVA_HOME` στο φάκελό της. Το Tomcat δεν εκκινεί χωρίς αυτήν.

4. Στο Command Prompt, κατεβάστε το Apache Tomcat 9 και το PHP/Java Bridge, τοποθετήστε το `JavaBridge.war` της γέφυρας στο φάκελο `webapps` του Tomcat και εκκινήστε το Tomcat. Τα σενάρια του Tomcat εντοπίζουν το Tomcat μέσω της μεταβλητής `CATALINA_HOME`, επομένως διατηρήστε το ίδιο παράθυρο Command Prompt για τα επόμενα βήματα. Το Tomcat αποσυμπιέζει το αρχείο WAR στο `webapps\JavaBridge` κατά την εκκίνηση:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Δημιουργήστε έναν φάκελο έργου και εγκαταστήστε το Aspose.Slides for PHP via Java από το [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Σταματήστε το Tomcat, αντιγράψτε το αρχείο JAR του Aspose.Slides από το πακέτο στον φάκελο `WEB-INF\lib` της γέφυρας, αντικαταστήστε το `Java.inc` της γέφυρας με την έκδοση PHP 8 από το πακέτο και εκκινήστε ξανά το Tomcat:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   Σε PHP 7, παραλείψτε την αντικατάσταση του `Java.inc`. Το Tomcat χρειάζεται λίγα δευτερόλεπτα για εκκίνηση και πρέπει να είναι ενεργό όποτε τα σενάρια σας χρησιμοποιούν το Aspose.Slides.

## **Επαλήθευση της εγκατάστασης**

Αποθηκεύστε αυτό το σενάριο ως *hello.php* στον φάκελο του έργου. Δημιουργεί μια παρουσίαση με ένα πλαίσιο κειμένου και τη σώζει δίπλα στο σενάριο:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/el/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Τρέξτε το από το φάκελο του έργου:

```bash
php hello.php
```

Το σενάριο δημιουργεί το *hello.pptx*, με μία διαφάνεια που περιέχει το πλαίσιο κειμένου. Χωρίς άδεια, η διαφάνεια περιέχει επίσης υδατογράφημα αξιολόγησης· δείτε το [Licensing](/slides/el/php-java/licensing/).

Το σενάριο περιλαμβάνει απευθείας το `aspose.slides.php`: ο αυτόματος φορτωτής του Composer δεν μπορεί να φορτώσει αυτές τις κλάσεις, επειδή όλες ορίζονται σε αυτό το μοναδικό αρχείο. Επίσης περνά μια απόλυτη διαδρομή στη μέθοδο `save`, επειδή το Aspose.Slides εκτελείται μέσα στο Tomcat και επιλύει σχετική διαδρομή σε σχέση με τον φάκελο εργασίας του Tomcat, όχι με αυτό του σεναρίου.

## **Συχνές ερωτήσεις**

**Πώς μπορώ να επαληθεύσω ότι το Aspose.Slides ενσωματώνεται σωστά;**

Εκτελέστε το σενάριο στο [Επαλήθευση της εγκατάστασης](#verify-the-installation). Εάν δημιουργεί το *hello.pptx* χωρίς σφάλματα, τότε το PHP, το PHP/Java Bridge και το Aspose.Slides λειτουργούν από κοινού.

**Γιατί το σενάριό μου διακόπτεται με το μήνυμα "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'";**

Το PHP δεν μπόρεσε να φορτώσει το `Java.inc` από το Tomcat. Εάν το προηγούμενο μήνυμα αναφέρει ότι ο περιτυλιγτής `http://` είναι απενεργοποιημένος, ορίστε `allow_url_include = On` στο αρχείο `php.ini` που φορτώνει η γραμμή εντολών του PHP· η εντολή `php --ini` εμφανίζει ποιο αρχείο είναι. Εάν εμφανίζει «Connection refused», το Tomcat δεν είναι ακόμη ενεργό: ξεκινήστε το ή περιμένετε λίγα δευτερόλεπτα μέχρι να ξεκινήσει.

**Πώς μπορώ να περιορίσω τη χρήση μνήμης κατά την επεξεργασία μεγάλων παρουσιάσεων;**

Αυξήστε τα όρια μνήμης του JVM μόνο όσο χρειάζεται και κλείστε κάθε αντικείμενο [Presentation](https://reference.aspose.com/slides/el/php-java/aspose.slides/presentation/) σε μπλοκ `finally` για άμεση εκκένωση της κρυφής μνήμης. Αυτό αποτρέπει σφάλματα έλλειψης μνήμης και διατηρεί τη συνολική χρήση μνήμης προβλέψιμη κατά τις μαζικές λειτουργίες.

**Μπορώ να εξαιρέσω ανεπιθύμητες μορφές εξαγωγής για να μειώσω το τελικό μέγεθος του JAR;**

Οι τρέχουσες εκδόσεις του Aspose.Slides διανέμονται ως μία ενιαία βιβλιοθήκη, επομένως δεν μπορείτε να απενεργοποιήσετε συγκεκριμένους εξαγωγείς όπως PDF ή SVG κατά τη διαδικασία κατασκευής.