---
title: ODP in PPTX konvertieren
type: docs
weight: 10
url: /de/nodejs-java/convert-odp-to-pptx/
---

## **ODP in PPTX/PPT-Präsentation konvertieren**
Aspose.Slides für Node.js via Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) an, die eine Präsentationsdatei darstellt. Die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) kann nun ebenfalls über den Konstruktor [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) auf ODP zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie eine ODP‑Präsentation in eine PPTX‑Präsentation konvertiert wird.
```javascript
// ODP-Datei öffnen
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// ODP-Präsentation im PPTX-Format speichern
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Live‑Beispiel**
Sie können die Web‑App [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) besuchen, die mit **Aspose.Slides API** erstellt wurde. Die App zeigt, wie die ODP‑zu‑PPTX‑Konvertierung mit der Aspose.Slides API implementiert werden kann.

## **FAQ**

**Muss ich Microsoft PowerPoint oder LibreOffice installieren, um ODP in PPTX zu konvertieren?**

Nein. Aspose.Slides funktioniert eigenständig und benötigt keine Drittanbieter‑Anwendungen zum Lesen oder Schreiben von ODP/PPTX.

**Werden Master‑Folien, Layouts und Designs während der Konvertierung beibehalten?**

Ja. Die Bibliothek verwendet ein vollständiges Präsentations‑Objektmodell und behält die Struktur, einschließlich Master‑Folien und Layouts, bei, sodass das Design nach der Konvertierung korrekt bleibt.

**Kann ich passwortgeschützte ODP‑Dateien konvertieren?**

Ja. Aspose.Slides unterstützt das Erkennen von Schutz, das Öffnen und die Arbeit mit [protected presentations](/slides/de/nodejs-java/password-protected-presentation/) (einschließlich ODP), wenn Sie das Passwort angeben, sowie das Konfigurieren von Verschlüsselung und den Zugriff auf Dokumenteneigenschaften.

**Ist Aspose.Slides geeignet für Cloud‑ oder REST‑basierte Konvertierungsdienste?**

Ja. Sie können die lokale Bibliothek in Ihrem eigenen Backend oder [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST‑API) verwenden; beide Optionen unterstützen die ODP → PPTX‑Konvertierung.