---
title: Installazione
type: docs
weight: 70
url: /it/php-java/installation/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- utilizzare Aspose.Slides
- installazione di Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Installa rapidamente Aspose.Slides per PHP via Java. Guida passo-passo, requisiti di sistema e esempi di codice - inizia a lavorare con le presentazioni PowerPoint oggi stesso!"
---
## **Panoramica**

Questo articolo spiega come installare e configurare Aspose.Slides per PHP via Java. Copre la configurazione dell'ambiente richiesto, il download della libreria tramite Packagist, la configurazione di Apache Tomcat con PHP/Java Bridge e l'esecuzione di un esempio per verificare l'installazione.

## **Configurare l'ambiente**

1. Installare PHP 7, aggiungere il percorso di PHP alla variabile di sistema `PATH` e impostare `allow_url_include` su `On` nel file `php.ini`.
1. Installare JRE 8. Impostare la variabile di ambiente `JAVA_HOME` sul percorso del JRE installato.
1. Installare Apache Tomcat 8.0.

## **Scaricare Aspose.Slides per PHP via Java**

`packagist` è il modo più semplice per scaricare [Aspose.Slides per PHP via Java](https://packagist.org/packages/aspose/slides).

Per installare Aspose.Slides usando Packagist, eseguire questo comando: 
   ```bash
   composer require aspose/slides
   ```

## **Configurare Apache Tomcat**

1. Scaricare PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) da http://php-java-bridge.sourceforge.net/pjb/download.php ed estrarre il file `JavaBridge.war` nella cartella `webapps` di Tomcat.
1. Avviare il servizio Apache Tomcat.
1. Scaricare [“Aspose.Slides per PHP via Java”](https://downloads.aspose.com/slides/it/php-java) e estrarlo nella cartella `aspose.slides`. Copiare il file `jar/aspose-slides-x.x-php.jar` nella cartella `webapps\JavaBridge\WEB-INF\lib`. Se si utilizza **PHP 8**, sostituire il file originale `Java.inc` del PHP-Java Bridge con il `Java.inc` presente in `Java.inc.php8.zip`.
1. Riavviare il servizio Apache Tomcat.
1. Eseguire `example.php` nella cartella `aspose.slides` per avviare l'esempio con questo comando:
   ```bash
   php example.php
   ```

## **FAQ**

**Come posso verificare che Aspose.Slides sia integrato correttamente?**

Compilare il progetto, istanziare una presentazione vuota [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e salvarla con un nuovo nome. Se il file viene creato senza generare eccezioni, la libreria è stata integrata correttamente.

**Come posso limitare il consumo di memoria durante l'elaborazione di presentazioni di grandi dimensioni?**

Aumentare i limiti di memoria della JVM solo quanto necessario, e chiudere ogni istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) in un blocco `finally` per rilasciare rapidamente la cache. Questo evita errori di out-of-memory e mantiene prevedibile l'utilizzo complessivo della memoria durante le operazioni batch.

**Posso escludere formati di esportazione indesiderati per ridurre la dimensione finale del JAR?**

Le versioni correnti di Aspose.Slides sono distribuite come una singola libreria monolitica, quindi non è possibile disabilitare esportatori specifici come PDF o SVG al momento della compilazione.