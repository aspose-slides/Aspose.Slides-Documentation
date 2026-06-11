---
title: Installation
type: docs
weight: 70
url: /sv/php-java/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides-installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Installera snabbt Aspose.Slides för PHP via Java. Steg-för-steg-guide, systemkrav och kodexempel — börja arbeta med PowerPoint-presentationer idag!"
---
## **Översikt**

Denna artikel förklarar hur man installerar och konfigurerar Aspose.Slides för PHP via Java. Den täcker den nödvändiga miljöinställningen, nedladdning av biblioteket via Packagist, konfiguration av Apache Tomcat med PHP/Java Bridge samt körning av ett exempel för att verifiera installationen.

## **Konfigurera miljö**

1. Installera PHP 7, lägg till PHP‑sökvägen i systemvariabeln `PATH` och sätt `allow_url_include` till `On` i filen `php.ini`.
1. Installera JRE 8. Ställ in miljövariabeln `JAVA_HOME` till sökvägen för den installerade JRE:n.
1. Installera Apache Tomcat 8.0.

## **Ladda ner Aspose.Slides för PHP via Java**

`packagist` är det enklaste sättet att ladda ner [Aspose.Slides för PHP via Java](https://packagist.org/packages/aspose/slides).

För att installera Aspose.Slides med Packagist, kör detta kommando:  
```bash
   composer require aspose/slides
   ```

## **Konfigurera Apache Tomcat**

1. Ladda ner PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) från http://php-java-bridge.sourceforge.net/pjb/download.php och extrahera filen `JavaBridge.war` till Tomcats `webapps`‑mapp.
1. Starta Apache Tomcat‑tjänsten.
1. Ladda ner [“Aspose.Slides för PHP via Java”](https://downloads.aspose.com/slides/sv/php-java) och extrahera den till mappen `aspose.slides`. Kopiera filen `jar/aspose-slides-x.x-php.jar` till mappen `webapps\JavaBridge\WEB-INF\lib`. Om du använder **PHP 8**, ersätt den ursprungliga `Java.inc` från PHP-Java Bridge med `Java.inc` från `Java.inc.php8.zip`.
1. Starta om Apache Tomcat‑tjänsten.
1. Kör `example.php` i `aspose.slides`‑mappen för att köra exemplet med följande kommando:  
```bash
   php example.php
   ```

## **Vanliga frågor**

**Hur kan jag verifiera att Aspose.Slides är korrekt integrerat?**

Bygg ditt projekt, skapa en tom [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och spara den under ett nytt namn. Om filen skapas utan att kasta undantag har biblioteket integrerats framgångsrikt.

**Hur kan jag begränsa minnesanvändningen när jag behandlar stora presentationer?**

Höj JVM:s minnesgränser bara så högt som nödvändigt, och stäng varje [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instans i ett `finally`‑block för att snabbt frigöra cachen. Detta förhindrar out‑of‑memory‑fel och håller den totala minnesanvändningen förutsägbar under batch‑operationer.

**Kan jag utesluta oönskade exportformat för att minska den slutliga JAR‑storleken?**

Aktuella Aspose.Slides‑utgåvor levereras som ett enda monolitiskt bibliotek, så du kan inte inaktivera specifika exportörer som PDF eller SVG vid byggtid.