---
title: Instalacja
type: docs
weight: 70
url: /pl/php-java/installation/
keywords:
- zainstaluj Aspose.Slides
- pobierz Aspose.Slides
- użyj Aspose.Slides
- instalacja Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Szybko zainstaluj Aspose.Slides dla PHP via Java. Przewodnik krok po kroku, wymagania systemowe i przykłady kodu — zacznij już dziś pracować z prezentacjami PowerPoint!"
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zainstalować i skonfigurować Aspose.Slides dla PHP via Java. Obejmuje on wymagane przygotowanie środowiska, pobieranie biblioteki z Packagist, konfigurację Apache Tomcat z PHP/Java Bridge oraz uruchomienie przykładu w celu weryfikacji instalacji.

## **Konfiguracja środowiska**

1. Zainstaluj PHP 7, dodaj ścieżkę do PHP do zmiennej systemowej `PATH` i ustaw `allow_url_include` na `On` w pliku `php.ini`.
1. Zainstaluj JRE 8. Ustaw zmienną środowiskową `JAVA_HOME` na ścieżkę do zainstalowanego JRE.
1. Zainstaluj Apache Tomcat 8.0.

## **Pobierz Aspose.Slides dla PHP via Java** 

`packagist` jest najprostszym sposobem pobrania [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

Aby zainstalować Aspose.Slides przy użyciu Packagist, uruchom następujące polecenie: 
   ```bash
   composer require aspose/slides
   ```

## **Konfiguracja Apache Tomcat**

1. Pobierz PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) z http://php-java-bridge.sourceforge.net/pjb/download.php i wypakuj plik `JavaBridge.war` do folderu `webapps` Tomcata.
1. Uruchom usługę Apache Tomcat.
1. Pobierz [„Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/pl/php-java) i wypakuj go do folderu `aspose.slides`. Skopiuj plik `jar/aspose-slides-x.x-php.jar` do folderu `webapps\JavaBridge\WEB-INF\lib`. Jeśli używasz **PHP 8**, zastąp oryginalny `Java.inc` z PHP-Java Bridge plikiem `Java.inc` z archiwum `Java.inc.php8.zip`.
1. Uruchom ponownie usługę Apache Tomcat.
1. Uruchom `example.php` w folderze `aspose.slides`, aby wykonać przykład przy użyciu następującego polecenia:
   ```bash
   php example.php
   ```

## **FAQ**

**Jak mogę zweryfikować, że Aspose.Slides został poprawnie zintegrowany?**

Zbuduj swój projekt, utwórz pustą [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i zapisz ją pod nową nazwą. Jeśli plik zostanie utworzony bez wyrzucania wyjątków, biblioteka została pomyślnie zintegrowana.

**Jak mogę ograniczyć zużycie pamięci podczas przetwarzania dużych prezentacji?**

Zwiększaj limity pamięci JVM tylko do niezbędnego poziomu i zamykaj każdą instancję [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) w bloku `finally`, aby niezwłocznie zwolnić pamięć podręczną. Zapobiega to błędom braku pamięci i utrzymuje przewidywalne zużycie pamięci podczas operacji wsadowych.

**Czy mogę wykluczyć niepotrzebne formaty eksportu, aby zmniejszyć ostateczny rozmiar pliku JAR?**

Obecne wydania Aspose.Slides są dostarczane jako jedyna monolityczna biblioteka, więc nie można wyłączyć konkretnych eksporterów, takich jak PDF czy SVG, w czasie kompilacji.