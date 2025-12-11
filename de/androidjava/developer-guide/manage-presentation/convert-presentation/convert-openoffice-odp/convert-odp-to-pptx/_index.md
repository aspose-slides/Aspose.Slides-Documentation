---
title: ODP zu PPTX auf Android konvertieren
linktitle: ODP zu PPTX
type: docs
weight: 10
url: /de/androidjava/convert-odp-to-pptx/
keywords:
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- ODP konvertieren
- OpenDocument zu PPTX
- ODP zu PPTX
- ODP als PPTX speichern
- ODP zu PPTX exportieren
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie ODP zu PPTX mit Aspose.Slides für Android. Saubere Java-Codebeispiele, Batch-Tipps und hochwertige Ergebnisse - kein PowerPoint erforderlich."
---

## **ODP in PPTX/PPT Präsentation konvertieren**
Aspose.Slides für Android über Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) an, die eine Präsentationsdatei darstellt. Die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) kann nun auch über den Konstruktor [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine ODP-Präsentation in eine PPTX-Präsentation konvertiert.
```java
// Öffne die ODP-Datei
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Speichere die ODP-Präsentation im PPTX-Format
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Live-Beispiel**
Sie können die Web-App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP-zu-PPTX-Konvertierung mit Aspose.Slides API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP in PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und erfordert keine Drittanbieter-Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Masterfolien, Layouts und Designs bei der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentationsobjektmodell und behält die Struktur, einschließlich Masterfolien und Layouts, bei, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP-Dateien konvertieren?**

Ja. Aspose.Slides unterstützt das Erkennen von Schutz, das Öffnen und Arbeiten mit [protected presentations](/slides/de/androidjava/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie das Konfigurieren von Verschlüsselung und den Zugriff auf Dokumenteneigenschaften.

**Ist Aspose.Slides für cloud- oder REST-basierte Konvertierungsdienste geeignet?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API) verwenden; beide Optionen unterstützen die ODP→PPTX-Konvertierung.