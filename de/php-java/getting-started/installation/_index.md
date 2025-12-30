---
title: Installation
type: docs
weight: 70
url: /de/php-java/installation/
keywords:
- Aspose.Slides installieren
- Aspose.Slides herunterladen
- Aspose.Slides verwenden
- Installation von Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Installieren Sie Aspose.Slides für PHP via Java schnell. Schritt-für-Schritt-Anleitung, Systemanforderungen und Code-Beispiele - beginnen Sie noch heute mit PowerPoint-Präsentationen zu arbeiten!"
---

## **Umgebung konfigurieren**

1. Installieren Sie PHP 7, fügen Sie den PHP-Pfad der System‑`PATH`‑Variablen hinzu und setzen Sie `allow_url_include` in der `php.ini`‑Datei auf `On`.
1. Installieren Sie JRE 8. Setzen Sie die Umgebungsvariable `JAVA_HOME` auf den Pfad der installierten JRE.
1. Installieren Sie Apache Tomcat 8.0.

## **Aspose.Slides für PHP via Java herunterladen** 

`packagist` ist die einfachste Möglichkeit, [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides) herunterzuladen. 

Um Aspose.Slides mit Packagist zu installieren, führen Sie diesen Befehl aus: 
   ```bash
   composer require aspose/slides
   ```


## **Apache Tomcat konfigurieren**

1. Laden Sie PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) von http://php-java-bridge.sourceforge.net/pjb/download.php herunter und extrahieren Sie die Datei `JavaBridge.war` in den `webapps`‑Ordner von Tomcat.
1. Starten Sie den Apache Tomcat‑Dienst.
1. Laden Sie [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) herunter und extrahieren Sie sie in den Ordner `aspose.slides`. Kopieren Sie die Datei `jar/aspose-slides-x.x-php.jar` in den Ordner `webapps\JavaBridge\WEB-INF\lib`. Wenn Sie **PHP 8** verwenden, ersetzen Sie das ursprüngliche `Java.inc` der PHP‑Java Bridge durch das `Java.inc` aus `Java.inc.php8.zip`.
1. Starten Sie den Apache Tomcat‑Dienst neu.
1. Führen Sie `example.php` im Ordner `aspose.slides` aus, um das Beispiel mit folgendem Befehl zu starten:
   ```bash
   php example.php
   ```


## **FAQ**

**Wie kann ich überprüfen, ob Aspose.Slides korrekt integriert ist?**

Erstellen Sie Ihr Projekt, instanziieren Sie eine leere [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und speichern Sie sie unter einem neuen Namen. Wenn die Datei ohne Ausnahme erstellt wird, war die Bibliothek erfolgreich integriert.

**Wie kann ich den Speicherverbrauch bei der Verarbeitung großer Präsentationen begrenzen?**

Erhöhen Sie die JVM‑Speicherlimits nur so weit, wie nötig, und schließen Sie jede [Presentation]‑Instanz in einem `finally`‑Block, um den Cache sofort freizugeben. Das verhindert Out‑of‑Memory‑Fehler und sorgt dafür, dass der Gesamtspeicherverbrauch bei Batch‑Operationen vorhersehbar bleibt.

**Kann ich unerwünschte Exportformate ausschließen, um die endgültige JAR‑Größe zu verkleinern?**

Aktuelle Aspose.Slides‑Versionen werden als eine einzige monolithische Bibliothek ausgeliefert, sodass Sie bestimmte Exporter wie PDF oder SVG zur Build‑Zeit nicht deaktivieren können.