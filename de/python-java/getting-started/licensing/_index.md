---
title: Lizenzierung
type: docs
weight: 80
url: /de/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- Lizenzdatei
- Temporäre Lizenz
- Nutzungsbasierte Lizenzierung
- Evaluierungsbeschränkungen
description: "Wenden Sie eine Lizenz aus einer Datei, eine bytebasierte oder nutzungsbasierte Lizenz in Aspose.Slides für Python via Java an und entfernen Sie Evaluierungsbeschränkungen aus Ihren Anwendungen."
---
## **Übersicht**

Aspose.Slides für Python via Java kann im Evaluierungsmodus oder mit einer Lizenz ausgeführt werden. Dieser Artikel erklärt, wie man eine Lizenz aus einer Datei oder aus Bytes anwendet und wie man die nutzungsbasierte Lizenzierung konfiguriert.

Für Kaufoptionen siehe [Preisangaben](https://purchase.aspose.com/pricing/slides/de/family). Für allgemeine Lizenz‑ und Kauffragen siehe [Kaufrichtlinien und FAQ](https://purchase.aspose.com/policies).

Für Evaluierungsbeschränkungen und wie man eine temporäre Lizenz anfordert, siehe [Evaluate Aspose.Slides](/slides/de/python-java/evaluate-aspose-slides/). Wenden Sie eine temporäre Lizenz auf die gleiche Weise wie eine gekaufte Lizenzdatei an.

## **Über die Lizenz**

Eine Lizenzdatei enthält Informationen wie den Produktnamen, die Anzahl lizenzierter Entwickler und das Ablaufdatum des Abonnements. Die Datei ist digital signiertes XML.

{{% alert color="warning" title="Warnung" %}}
Bearbeiten Sie die Lizenzdatei nicht. Selbst ein zusätzliches Zeilenumbruch kann deren digitale Signatur ungültig machen.
{{% /alert %}}

Wenden Sie die Lizenz einmal pro Anwendung oder Prozess an, bevor Sie Präsentationen erstellen oder andere Aspose.Slides‑Operationen durchführen. Für eine Lizenzdatei verwenden Sie die Klasse [License](https://reference.aspose.com/slides/de/python-java/aspose.slides/license/). Die nutzungsbasierte Lizenzierung verwendet ein öffentliches und privates Schlüsselpaar anstelle einer Lizenzdatei.

## **Lizenz anwenden**

Die folgenden Beispiele gehen davon aus, dass Aspose.Slides für Python via Java und die erforderlichen Voraussetzungen installiert sind. Jedes Beispiel ist ein eigenständiges Skript, das die JVM startet, die API importiert und eine Lizenz anwendet. Führen Sie in Ihrer Anwendung die Präsentations‑Operationen erst nach dem Anwenden der Lizenz aus und schließen Sie die JVM erst, wenn alle Aspose.Slides‑Arbeiten abgeschlossen sind.

### **Lizenz aus einer Datei anwenden**

Übergeben Sie den Pfad zur Lizenzdatei an [License.setLicense](https://reference.aspose.com/slides/de/python-java/aspose.slides/license/#setLicense). Ersetzen Sie `Aspose.Slides.lic` durch den Pfad zu Ihrer Lizenzdatei.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Führen Sie hier Präsentationsoperationen aus, bevor die JVM heruntergefahren wird.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Verwenden Sie den genauen Dateinamen inklusive seiner Erweiterung. Wenn die Datei beispielsweise `Aspose.Slides.lic.xml` heißt, fügen Sie `.xml` zum Pfad hinzu. Ein absoluter Pfad vermeidet Mehrdeutigkeiten bezüglich des Arbeitsverzeichnisses der Anwendung.

Das Beispiel verwendet [License.isLicensed](https://reference.aspose.com/slides/de/python-java/aspose.slides/license/#isLicensed), um zu prüfen, ob die Lizenz angewendet wurde.

### **Lizenz aus Bytes anwenden**

Verwenden Sie [License.setLicenseFromBytes](https://reference.aspose.com/slides/de/python-java/aspose.slides/license/#setLicenseFromBytes), wenn die Lizenz als Python‑Bytes vorliegt. Das folgende Beispiel liest die Datei im Binärmodus und schließt sie, bevor die Lizenz angewendet wird.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Präsentationsoperationen hier ausführen, bevor die JVM heruntergefahren wird.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Behalten Sie die ursprünglichen Bytes unverändert bei. Dekodieren, formatieren Sie nicht um oder ändern Sie den Lizenzinhalt vor dem Anwenden nicht.

## **Nutzungsbasierte Lizenz anwenden**

Die nutzungsbasierte Lizenz berechnet Ihnen Gebühren basierend auf der API‑Nutzung. Nachdem Sie eine nutzungsbasierte Lizenz erhalten haben, wenden Sie deren öffentlichen und privaten Schlüssel mit [Metered.setMeteredKey](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/#setMeteredKey) an. Initialisieren Sie das Objekt [Metered](https://reference.aspose.com/slides/de/python-java/aspose.slides/metered/) und wenden Sie die Schlüssel einmal beim Anwendungsstart an.

Das folgende Beispiel liest die Schlüssel aus den Umgebungsvariablen `ASPOSE_METERED_PUBLIC_KEY` und `ASPOSE_METERED_PRIVATE_KEY`. Setzen Sie beide Variablen, bevor Sie das Skript ausführen.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Präsentationsoperationen hier ausführen, bevor die JVM heruntergefahren wird.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Hinweis" %}}
Nutzungsbasierte Lizenzierung erfordert eine Internetverbindung, um die Schlüssel zu validieren und die Nutzung zu melden. Halten Sie den privaten Schlüssel außerhalb von Quellcode und Protokollen. Weitere Informationen zu Konnektivität und Abrechnung finden Sie im [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}

## **FAQ**

**Muss ich nach dem Kauf einer Lizenz ein anderes Paket installieren?**

Nein. Wenden Sie die Lizenz auf dasselbe Paket an, das Sie für die Evaluierung verwendet haben.

**Soll ich für jede Präsentation eine Lizenz anwenden?**

Nein. Wenden Sie sie einmal beim Start der Anwendung an, bevor Sie Präsentationen erstellen oder laden.

**Kann ich die Lizenzdatei umbenennen?**

Ja. Verwenden Sie den genauen neuen Dateinamen in Ihrem Code und lassen Sie den Dateinhalt unverändert.

**Kann ich eine temporäre Lizenz mit dem byte‑basierten Beispiel verwenden?**

Ja. Lesen Sie die temporäre Lizenzdatei als Bytes ein und wenden Sie sie auf die gleiche Weise wie eine gekaufte Lizenz an.