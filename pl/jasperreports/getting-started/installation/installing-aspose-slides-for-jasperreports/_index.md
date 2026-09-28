---
title: Instalowanie Aspose.Slides dla JasperReports
type: docs
weight: 40
url: /pl/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Wybierz pliki JAR Aspose.Slides dla JasperReports, które pasują do Twojej wersji JasperReports i dodaj je do JasperReports, projektu Maven lub JasperReports Server."
---
## **Wybierz pliki JAR dla swojej wersji JasperReports**

Aspose.Slides for JasperReports jest dystrybuowany jako plik ZIP na [download page](https://releases.aspose.com/slides/pl/jasperreport/). jego folder *lib* zawiera jeden podfolder dla każdego zakresu wersji JasperReports. Pobierz pliki JAR z podfolderu, który obejmuje wersję JasperReports, której używasz:

| Wersja JasperReports | Podfolder *lib* |
| :- | :- |
| 3.7.2 do 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 do 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 do 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Nie ma podfolderu dla JasperReports 6.17.0 lub nowszych, w tym JasperReports 7. Podfolder *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* nie zawiera plików JAR, tylko informację, że wsparcie dla tych wersji zakończyło się w Aspose.Slides for JasperReports 17.6.

Każdy podfolder zawiera dwa pliki JAR; *xx.x* w ich nazwach to wersja produktu:

- *aspose.slides.jasperreports.library-xx.x.jar* zawiera eksportery dla JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` i `ASHtmlExporter`) oraz klasę `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* zawiera akcje eksportu dla JasperReports Server. Opiera się na pliku biblioteki, więc serwer zawsze potrzebuje obu plików JAR z tego samego podfolderu.

## **Dodaj plik JAR biblioteki do JasperReports lub swojej aplikacji**

Skopiuj *aspose.slides.jasperreports.library-xx.x.jar* z odpowiedniego podfolderu do folderu *lib* JasperReports lub do ścieżki klas swojej aplikacji. Twoja aplikacja będzie wtedy mogła tworzyć eksportery w kodzie.

{{% alert color="info" title="Note" %}}
W systemie Linux JasperReports potrzebuje fontconfig oraz przynajmniej jednej zainstalowanej czcionki do wypełniania raportu. Bez czcionek wypełnianie kończy się błędem "Error initializing graphic environment".
{{% /alert %}}

## **Dodaj plik JAR biblioteki do projektu Maven**

Plik JAR znajduje się w archiwum ZIP, a nie w repozytorium Maven. Aby użyć go w kompilacji Maven, zainstaluj go w lokalnym repozytorium Maven. Dla wersji 26.6 uruchom to polecenie w folderze zawierającym plik JAR:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Następnie dodaj go do zależności w *pom.xml*, wraz z wersją JasperReports, którą obejmuje podfolder pliku JAR:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Identyfikatory grupy i artefaktu to te, które wybierzesz w poleceniu instalacji; muszą jedynie się zgadzać. Pełny projekt wykorzystujący JasperReports 6.16.0 znajduje się w [Twój pierwszy eksport](/slides/pl/jasperreports/#your-first-export).

## **Dodaj pliki JAR do JasperReports Server**

Skopiuj oba pliki JAR z odpowiedniego podfolderu do folderu *WEB-INF/lib* aplikacji webowej JasperReports Server, a następnie zarejestruj eksportery zgodnie z opisem w [Integracja z JasperServer](/slides/pl/jasperreports/integration-with-jasperserver/).