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
- temporäre Lizenz
- nutzungsbasierte Lizenzierung
- Evaluierungseinschränkungen
description: "Wenden Sie eine Datei-, bytebasierte oder nutzungsbasierte Lizenz in Aspose.Slides für Python via Java an und entfernen Sie Evaluierungseinschränkungen aus Ihren Anwendungen."
---
## **Übersicht**

Aspose.Slides für Python via Java kann im Evaluierungsmodus oder mit einer Lizenz ausgeführt werden. Im Evaluierungsmodus fügt es jeder Folie jeder Präsentation, die es speichert, ein Wasserzeichen‑Textfeld hinzu und kürzt Text, den Ihr Code aus Präsentationen liest. Dieser Artikel erklärt, wie man eine Lizenz aus einer Datei oder aus Bytes anwendet und wie man die nutzungsbasierte Lizenzierung konfiguriert.

Für Kaufoptionen siehe [Preisgestaltung](https://purchase.aspose.com/pricing/slides/family). Für allgemeine Lizenz‑ und Kauffragen siehe [Kaufbedingungen und FAQ](https://purchase.aspose.com/policies).

Für Evaluierungsbeschränkungen und wie man eine temporäre Lizenz anfordert, siehe [Aspose.Slides evaluieren](/slides/de/python-java/evaluate-aspose-slides/). Wenden Sie eine temporäre Lizenz auf dieselbe Weise an wie eine gekaufte Lizenzdatei.

## **Über die Lizenz**

Eine Lizenzdatei enthält Informationen wie den Produktnamen, die Anzahl lizenzierter Entwickler und das Ablaufdatum des Abonnements. Die Datei ist eine digital signierte XML.

{{% alert color="warning" title="Warnung" %}}
Bearbeiten Sie die Lizenzdatei nicht. Auch ein zusätzliches Zeilenumbruch kann die digitale Signatur ungültig machen.
{{% /alert %}}

Wenden Sie die Lizenz einmal pro Anwendung oder Prozess an, bevor Sie Präsentationen erstellen oder andere Aspose.Slides‑Operationen durchführen. Für eine Lizenzdatei verwenden Sie die Klasse [License](https://reference.aspose.com/slides/python-java/aspose.slides/license/). Die nutzungsbasierte Lizenzierung verwendet ein öffentliches und privates Schlüsselpaar anstelle einer Lizenzdatei.

## **Lizenz anwenden**

Die folgenden Beispiele gehen davon aus, dass Aspose.Slides für Python via Java und seine Voraussetzungen installiert sind. Jedes Beispiel ist ein eigenständiges Skript, das die JVM startet, die API importiert und eine Lizenz anwendet. In Ihrer Anwendung führen Sie Ihre Präsentationsoperationen erst nach dem Anwenden der Lizenz aus und schließen die JVM erst, wenn alle Aspose.Slides‑Arbeiten abgeschlossen sind.

### **Lizenz aus einer Datei anwenden**

Übergeben Sie den Pfad zur Lizenzdatei an [License.setLicense](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicense). Ersetzen Sie `Aspose.Slides.lic` durch den Pfad zu Ihrer Lizenzdatei.

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

Verwenden Sie den genauen Dateinamen inklusive seiner Erweiterung. Zum Beispiel, wenn die Datei `Aspose.Slides.lic.xml` heißt, fügen Sie `.xml` zum Pfad hinzu. Ein absoluter Pfad vermeidet Mehrdeutigkeiten bezüglich des Arbeitsverzeichnisses der Anwendung.

Das Beispiel verwendet [License.isLicensed](https://reference.aspose.com/slides/python-java/aspose.slides/license/#isLicensed), um zu prüfen, ob die Lizenz angewendet wurde.

### **Lizenz aus Bytes anwenden**

Verwenden Sie [License.setLicenseFromBytes](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicenseFromBytes), wenn die Lizenz als Python‑Bytes vorliegt. Das folgende Beispiel liest die Datei im Binärmodus und schließt sie, bevor die Lizenz angewendet wird.

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
        # Führen Sie hier Präsentationsoperationen aus, bevor die JVM heruntergefahren wird.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Behalten Sie die originalen Bytes unverändert bei. Dekodieren, formatieren Sie sie nicht um und ändern Sie den Lizenzinhalt vor dem Anwenden nicht.

## **Nutzungsbasierte Lizenz anwenden**

Bei der nutzungsbasierten Lizenzierung werden Ihnen die API‑Nutzung berechnet. Nachdem Sie eine nutzungsbasierte Lizenz erhalten haben, wenden Sie deren öffentlichen und privaten Schlüssel mit [Metered.setMeteredKey](https://reference.aspose.com/slides/python-java/aspose.slides/metered/#setMeteredKey) an. Initialisieren Sie das Objekt [Metered](https://reference.aspose.com/slides/python-java/aspose.slides/metered/) und wenden Sie die Schlüssel einmal beim Anwendungsstart an.

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
        # Führen Sie hier Präsentationsoperationen aus, bevor die JVM heruntergefahren wird.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Hinweis" %}}
Nutzungsbasierte Lizenzierung erfordert eine Internetverbindung, um die Schlüssel zu validieren und die Nutzung zu melden. Halten Sie den privaten Schlüssel aus dem Quellcode und den Protokollen heraus. Siehe die [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) für Details zu Konnektivität und Abrechnung.
{{% /alert %}}

## **FAQ**

**Muss ich nach dem Kauf einer Lizenz ein anderes Paket installieren?**

Nein. Wenden Sie die Lizenz auf dasselbe Paket an, das Sie für die Evaluierung verwendet haben.

**Soll ich für jede Präsentation eine Lizenz anwenden?**

Nein. Wenden Sie sie einmal beim Anwendungsstart an, bevor Sie Präsentationen erstellen oder laden.

**Kann ich die Lizenzdatei umbenennen?**

Ja. Verwenden Sie den genauen neuen Dateinamen in Ihrem Code und lassen Sie den Dateinhalt unverändert.

**Kann ich eine temporäre Lizenz mit dem bytebasierten Beispiel verwenden?**

Ja. Lesen Sie die temporäre Lizenzdatei als Bytes und wenden Sie sie auf dieselbe Weise an wie eine gekaufte Lizenz.