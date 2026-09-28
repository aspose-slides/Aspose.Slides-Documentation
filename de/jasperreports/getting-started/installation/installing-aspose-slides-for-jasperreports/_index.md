---
title: Installation von Aspose.Slides für JasperReports
type: docs
weight: 40
url: /de/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Wählen Sie die Aspose.Slides für JasperReports JARs aus, die zu Ihrer JasperReports-Version passen, und fügen Sie sie zu JasperReports, einem Maven-Projekt oder JasperReports Server hinzu."
---
## **Wählen Sie die JARs für Ihre JasperReports-Version**

Aspose.Slides für JasperReports wird als ZIP-Datei auf der [Download-Seite](https://releases.aspose.com/slides/de/jasperreport/) verteilt. Sein *lib*-Ordner enthält für jeden JasperReports‑Versionbereich einen Unterordner. Nehmen Sie die JARs aus dem Unterordner, der die von Ihnen verwendete JasperReports‑Version abdeckt:

| JasperReports-Version | Unterordner von *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

Es gibt keinen Unterordner für JasperReports 6.17.0 oder höher, einschließlich JasperReports 7. Der *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)*‑Unterordner enthält keine JARs, sondern nur einen Hinweis darauf, dass die Unterstützung für diese Versionen in Aspose.Slides für JasperReports 17.6 beendet wurde.

Jeder Unterordner enthält zwei JARs; *xx.x* in ihren Namen ist die Produktversion:

- *aspose.slides.jasperreports.library-xx.x.jar* enthält die Exporter für JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` und `ASHtmlExporter`) und die Klasse `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* enthält die Export‑Aktionen für JasperReports Server. Es baut auf dem Library‑JAR auf, daher benötigt der Server immer beide JARs aus demselben Unterordner.

## **Fügen Sie das Library‑JAR zu JasperReports oder Ihrer Anwendung hinzu**

Kopieren Sie *aspose.slides.jasperreports.library-xx.x.jar* aus dem passenden Unterordner in den *lib*-Ordner von JasperReports oder in den Klassenpfad Ihrer Anwendung. Ihre Anwendung kann dann die Exporter im Code erstellen.

{{% alert color="info" title="Note" %}}
Unter Linux benötigt JasperReports fontconfig und mindestens eine installierte Schriftart, um einen Bericht zu füllen. Ohne Schriftarten schlägt das Befüllen mit dem Fehler "Error initializing graphic environment" fehl.
{{% /alert %}}

## **Fügen Sie das Library‑JAR zu einem Maven‑Projekt hinzu**

Das JAR wird im ZIP bereitgestellt und nicht aus einem Maven‑Repository. Um es in einem Maven‑Build zu verwenden, installieren Sie es in Ihr lokales Maven‑Repository. Für Version 26.6 führen Sie diesen Befehl in dem Ordner aus, der das JAR enthält:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Fügen Sie es dann zu den Abhängigkeiten in *pom.xml* hinzu, zusammen mit einer JasperReports‑Version, die der Unterordner des JARs abdeckt:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Die Group‑ und Artifact‑IDs sind die, die Sie im Installationsbefehl wählen; sie müssen lediglich übereinstimmen. Ein vollständiges Projekt, das JasperReports 6.16.0 verwendet, finden Sie unter [Ihr erster Export](/slides/de/jasperreports/#your-first-export).

## **Fügen Sie die JARs zu JasperReports Server hinzu**

Kopieren Sie beide JARs aus dem passenden Unterordner in den *WEB-INF/lib*-Ordner der JasperReports‑Server‑Webanwendung und registrieren Sie dann die Exporter wie in [Integration mit JasperServer](/slides/de/jasperreports/integration-with-jasperserver/) beschrieben.