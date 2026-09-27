---
title: Installazione
type: docs
weight: 70
url: /it/php-java/installation/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- usare Aspose.Slides
- installazione Aspose.Slides
- Windows
- Linux
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Installa Aspose.Slides per PHP via Java su Linux e Windows: configura PHP, Java, Apache Tomcat e PHP/Java Bridge, aggiungi il pacchetto con Composer e verifica la configurazione con un breve script."
---
## **Panoramica**

Aspose.Slides per PHP via Java funziona in due processi. Il tuo script PHP utilizza classi PHP che inoltrano ogni chiamata tramite PHP/Java Bridge ad Aspose.Slides, che viene eseguito su Java all'interno di Apache Tomcat. Questo articolo spiega come configurare entrambi i lati, installare il pacchetto con Composer ed eseguire un breve script per verificare l'installazione.

## **Prerequisiti**

- **PHP 7.0 a 8.3**, con `allow_url_include = On` in `php.ini`. I tuoi script caricano la libreria client del bridge, `Java.inc`, da Tomcat via HTTP. Su PHP 8.4 e successive, `Java.inc` si arresta con l'errore "end() expects exactly 1 argument" ogni volta che è caricata l'estensione `xml` di PHP, e le versioni Windows di PHP la caricano sempre.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 o successivo.** Una JRE è sufficiente.
- **Apache Tomcat 9.** PHP/Java Bridge è basato sull'API `javax.servlet`, che Tomcat 10 e successive non forniscono più, quindi il bridge non si avvia su di esse.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, la sua ultima versione. La sua applicazione web, `JavaBridge.war`, viene eseguita in Tomcat.

Questo articolo esegue Tomcat e i tuoi script PHP sullo stesso computer. Aspose.Slides apre e salva file all'interno di Tomcat, quindi ogni percorso che i tuoi script gli passano deve essere valido lì.

## **Installazione su Linux**

Questi comandi installano tutto nella tua cartella home su Ubuntu 24.04. Su altre distribuzioni, installa gli stessi pacchetti con il gestore di pacchetti della distribuzione.

1. Installa PHP, Composer, Java e gli strumenti di download, poi attiva `allow_url_include` per la riga di comando di PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. Scarica Apache Tomcat 9 e PHP/Java Bridge, copia il file `JavaBridge.war` del bridge nella cartella `webapps` di Tomcat e avvia Tomcat. Tomcat estrae il file WAR in `webapps/JavaBridge` durante l'avvio:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Crea una cartella di progetto e installa Aspose.Slides per PHP via Java da [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Ferma Tomcat, copia il file JAR di Aspose.Slides dal pacchetto nella cartella `WEB-INF/lib` del bridge, sostituisci il file `Java.inc` del bridge con la versione per PHP 8 fornita nel pacchetto e avvia nuovamente Tomcat:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/it/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/it/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   Su PHP 7, salta la sostituzione di `Java.inc`. Tomcat impiega qualche secondo per avviarsi e deve essere in esecuzione ogni volta che i tuoi script utilizzano Aspose.Slides.

## **Installazione su Windows**

1. Installa [PHP 8.3 per Windows](https://www.php.net/downloads.php?os=windows) e aggiungi la sua cartella alla variabile d'ambiente `PATH`. Copia `php.ini-production` in `php.ini` nella stessa cartella. In `php.ini`, imposta `allow_url_include = On` e decommenta le linee `extension_dir = "ext"`, `extension=openssl` e `extension=zip`. Composer ha bisogno di `openssl` per scaricare i pacchetti e di `zip` per estrarli, a meno che non sia installato 7‑Zip o un comando `unzip` sia presente in `PATH`.
2. Installa [Composer](https://getcomposer.org/download/).
3. Installa Java e imposta la variabile d'ambiente `JAVA_HOME` sulla sua cartella. Tomcat non si avvia senza di essa.
4. In Prompt dei comandi, scarica Apache Tomcat 9 e PHP/Java Bridge, copia il file `JavaBridge.war` del bridge nella cartella `webapps` di Tomcat e avvia Tomcat. Gli script di Tomcat trovano Tomcat tramite la variabile `CATALINA_HOME`, quindi continua a utilizzare la stessa finestra del Prompt dei comandi per i passaggi successivi. Tomcat estrae il file WAR in `webapps\JavaBridge` durante l'avvio:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Crea una cartella di progetto e installa Aspose.Slides per PHP via Java da [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Ferma Tomcat, copia il file JAR di Aspose.Slides dal pacchetto nella cartella `WEB-INF\lib` del bridge, sostituisci il file `Java.inc` del bridge con la versione per PHP 8 fornita nel pacchetto e avvia nuovamente Tomcat:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   Su PHP 7, salta la sostituzione di `Java.inc`. Tomcat impiega qualche secondo per avviarsi e deve essere in esecuzione ogni volta che i tuoi script utilizzano Aspose.Slides.

## **Verifica dell'installazione**

Salva questo script come *hello.php* nella cartella del progetto. Crea una presentazione con una casella di testo e la salva nella stessa cartella dello script:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/it/lib/aspose.slides.php");

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

Eseguilo dalla cartella del progetto:

```bash
php hello.php
```

Lo script genera *hello.pptx*, con una diapositiva che contiene la casella di testo. Senza licenza, la diapositiva presenta anche una filigrana di valutazione; vedi [Licenza](/slides/it/php-java/licensing/).

Lo script include direttamente `aspose.slides.php`: l'autoloader di Composer non può caricare queste classi, perché sono tutte definite in quel unico file. Inoltre passa un percorso assoluto a `save`, poiché Aspose.Slides viene eseguito all'interno di Tomcat e risolve un percorso relativo rispetto alla cartella di lavoro di Tomcat, non rispetto al tuo script.

## **FAQ**

**Come posso verificare che Aspose.Slides sia integrato correttamente?**

Esegui lo script in [Verifica dell'installazione](#verify-the-installation). Se genera *hello.pptx* senza errori, PHP, PHP/Java Bridge e Aspose.Slides funzionano correttamente insieme.

**Perché il mio script si arresta con "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP non è riuscito a caricare `Java.inc` da Tomcat. Se il messaggio precedente indica che il wrapper `http://` è disabilitato, imposta `allow_url_include = On` nel file `php.ini` caricato dalla riga di comando di PHP; `php --ini` mostra quale file sia. Se dice "Connection refused", Tomcat non è ancora in esecuzione: avvialo o attendi qualche secondo finché non sarà avviato.

**Come posso limitare il consumo di memoria durante l'elaborazione di presentazioni di grandi dimensioni?**

Aumenta i limiti di memoria della JVM solo quanto necessario e chiudi ogni istanza di [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) in un blocco `finally` per rilasciare la cache tempestivamente. Questo previene errori di out‑of‑memory e mantiene prevedibile l'uso complessivo della memoria durante le operazioni batch.

**Posso escludere formati di esportazione indesiderati per ridurre la dimensione finale del JAR?**

Le versioni attuali di Aspose.Slides vengono distribuite come una singola libreria monolitica, quindi non è possibile disabilitare esportatori specifici come PDF o SVG al momento della compilazione.