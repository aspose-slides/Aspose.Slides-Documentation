---
title: Installatie
type: docs
weight: 70
url: /nl/php-java/installation/
keywords:
- Installeer Aspose.Slides
- Download Aspose.Slides
- Gebruik Aspose.Slides
- Aspose.Slides installatie
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Installeer snel Aspose.Slides voor PHP via Java. Stapsgewijze handleiding, systeemvereisten en code‑voorbeelden — begin vandaag nog met het werken met PowerPoint‑presentaties!"
---
## **Overzicht**

Dit artikel legt uit hoe je Aspose.Slides for PHP via Java installeert en configureert. Het behandelt de vereiste omgeving, het downloaden van de bibliotheek via Packagist, het configureren van Apache Tomcat met PHP/Java Bridge, en het uitvoeren van een voorbeeld om de installatie te verifiëren.

## **Configureer omgeving**

1. Installeer PHP 7, voeg het PHP‑pad toe aan de systeem‑`PATH`‑variabele en stel `allow_url_include` in op `On` in het `php.ini`‑bestand.
2. Installeer JRE 8. Stel de omgeving‑variabele `JAVA_HOME` in op het pad van de geïnstalleerde JRE.
3. Installeer Apache Tomcat 8.0.

## **Download Aspose.Slides voor PHP via Java** 

`packagist` is de gemakkelijkste manier om [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides) te downloaden. 

Om Aspose.Slides via Packagist te installeren, voer dit commando uit: 
```bash
   composer require aspose/slides
   ```

## **Configureer Apache Tomcat**

1. Download PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) van http://php-java-bridge.sourceforge.net/pjb/download.php en pak het bestand `JavaBridge.war` uit naar de `webapps`‑map van Tomcat.
2. Start de Apache Tomcat‑service.
3. Download [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/nl/php-java) en pak het uit naar de map `aspose.slides`. Kopieer het bestand `jar/aspose-slides-x.x-php.jar` naar de map `webapps\JavaBridge\WEB-INF\lib`. Als je **PHP 8** gebruikt, vervang dan het originele `Java.inc` van PHP‑Java Bridge door het `Java.inc` uit `Java.inc.php8.zip`.
4. Herstart de Apache Tomcat‑service.
5. Voer `example.php` uit in de map `aspose.slides` om het voorbeeld te draaien met dit commando:
```bash
   php example.php
   ```

## **Veelgestelde vragen**

**Hoe kan ik controleren of Aspose.Slides correct is geïntegreerd?**

Bouw je project, maak een lege [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) aan en sla deze onder een nieuwe naam op. Als het bestand wordt aangemaakt zonder dat er uitzonderingen worden gegooid, is de bibliotheek succesvol geïntegreerd.

**Hoe kan ik het geheugenverbruik beperken bij het verwerken van grote presentaties?**

Verhoog de JVM‑geheugenlimieten alleen zo hoog als nodig is, en sluit elke [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie af in een `finally`‑blok om de cache onmiddellijk vrij te geven. Dit voorkomt out‑of‑memory‑fouten en houdt het totale geheugenverbruik voorspelbaar tijdens batch‑bewerkingen.

**Kan ik ongewenste exportformaten uitsluiten om de uiteindelijke JAR‑grootte te verkleinen?**

De huidige releases van Aspose.Slides worden geleverd als één monolithische bibliotheek, dus je kunt specifieke exporters zoals PDF of SVG niet uitschakelen tijdens het bouwen.