---
title: ODP in PPTX mit PHP konvertieren
linktitle: ODP zu PPTX
type: docs
weight: 10
url: /de/php-java/convert-odp-to-pptx/
keywords:
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- ODP konvertieren
- OpenDocument zu PPTX
- ODP zu PPTX
- ODP als PPTX speichern
- ODP nach PPTX exportieren
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "ODP mit Aspose.Slides für PHP über Java in PPTX konvertieren. Saubere Code-Beispiele, Stapel-Tipps und hochwertige Ergebnisse – kein PowerPoint nötig."
---

## **ODP in PPTX/PPT-Präsentation konvertieren**
Aspose.Slides für PHP über Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) an, die eine Präsentationsdatei repräsentiert. Die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) kann nun ebenfalls über den [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) Konstruktor auf ODP zugreifen, wenn das Objekt instanziiert wird. Das nachfolgende Beispiel zeigt, wie eine ODP-Präsentation in eine PPTX-Präsentation konvertiert wird.
```php
// ODP-Datei öffnen
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Speichern der ODP-Präsentation im PPTX-Format
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Live-Beispiel**
Sie können die Web-App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit der **Aspose.Slides API** erstellt wurde. Die App demonstriert, wie die ODP-zu-PPTX-Konvertierung mit der Aspose.Slides API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP in PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und erfordert keine Drittanbieter-Anwendungen, um ODP/PPTX zu lesen oder zu schreiben.

**Werden Masterfolien, Layouts und Designs während der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentationsobjektmodell und behält die Struktur bei, einschließlich Masterfolien und Layouts, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP-Dateien konvertieren?**

Ja. Aspose.Slides unterstützt die Erkennung von Schutz, das Öffnen und Arbeiten mit [geschützten Präsentationen](/slides/de/php-java/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie die Konfiguration von Verschlüsselung und Zugriff auf Dokumenteigenschaften.

**Ist Aspose.Slides für Cloud- oder REST-basierte Konvertierungsdienste geeignet?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST-API) verwenden; beide Optionen unterstützen die ODP -> PPTX-Konvertierung.