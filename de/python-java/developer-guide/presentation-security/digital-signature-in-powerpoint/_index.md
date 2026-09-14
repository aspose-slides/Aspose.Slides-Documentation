---
title: Digitale Signaturen zu Präsentationen in Python hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/python-java/digital-signature-in-powerpoint/
keywords:
- digitale Signatur
- digitales Zertifikat
- Zertifizierungsstelle
- PFX-Zertifikat
- PKCS#12
- Signatur validieren
- PowerPoint
- PPTX
- Präsentationssicherheit
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX‑Präsentationen mit PFX‑Zertifikaten signieren und Aspose.Slides für Python via Java verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft dem Empfänger festzustellen, wer eine Präsentation unterschrieben hat und ob sich der signierte Inhalt geändert hat. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Workflows verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann dann zur Überprüfung der Signatur verwendet werden. Eine Signatur liefert Nachweis über Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** regelt, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist vom digitalen Signieren getrennt und wird in [Passwortgeschützte Präsentationen](/slides/de/python-java/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Add a Digital Signature** unter **Datei > Info > Präsentation schützen** bereit.

![PowerPoint-Menü „Präsentation schützen“ mit hervorgehobenem Befehl „Add a Digital Signature“](add-digital-signature-in-powerpoint.png)

Nach dem Öffnen einer signierten Präsentation kann PowerPoint eine Signatur‑Status‑Benachrichtigung anzeigen.

![PowerPoint-Benachrichtigung, die angibt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getDigitalSignatures) bereit, die eine [DigitalSignatureCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/digitalsignaturecollection/) zurückgibt, deren Elemente Instanzen von [DigitalSignature](https://reference.aspose.com/slides/de/python-java/aspose.slides/digitalsignature/) sind. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX‑Zertifikaten und Passwörtern**

Eine PFX‑Datei, auch bekannt als PKCS#12‑Datei und üblicherweise mit der Endung `.pfx` oder `.p12` versehen, kann ein X.509‑Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erstellen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX‑Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **nicht** ein Passwort zum Öffnen oder Bearbeiten der Präsentation. Committen Sie PFX‑Dateien oder deren Passwörter nicht in die Quellcodeverwaltung. In der Produktion sollten Sie den Zugriff auf die Zertifikatsdatei einschränken und das Passwort aus einem geheimen Speicher oder einer anderen geschützten Konfigurationsquelle beziehen. Die nachstehenden Beispiele verwenden nur eine Umgebungsvariable, um das Einbetten des Passworts im Code zu vermeiden.

## **Eine digitale Signatur zu einer Präsentation hinzufügen**

Um einen realen Präsentations‑Workflow zu signieren, laden Sie eine vorhandene PPTX‑Datei, erstellen eine [DigitalSignature](https://reference.aspose.com/slides/de/python-java/aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen die Signatur zur Signatursammlung der Präsentation hinzu und speichern in einer PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der durch [DigitalSignature.setComments](https://reference.aspose.com/slides/de/python-java/aspose.slides/digitalsignature/#setComments) festgelegte Wert beschreibt den Zweck der Signatur; er stellt keine Sicherheitskontrolle dar.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, prüfen Sie jedes Element, das von [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getDigitalSignatures) zurückgegeben wird. Die Methode [DigitalSignature.isValid](https://reference.aspose.com/slides/de/python-java/aspose.slides/digitalsignature/#isValid) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Ein ungültiges Ergebnis bedeutet in der Regel, dass sich der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert haben, oder dass die Datei beschädigt ist. Das Entfernen sämtlicher Signaturen erzeugt eine unsignierte Präsentation, daher reicht das reine Prüfen der Gültigkeit der einzelnen Elemente nicht aus: Ein sicherheitsrelevanter Workflow muss zudem sicherstellen, dass die erwartete Anzahl von Signaturen und die erwarteten Signaturidentitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als komplette Zertifikats‑Vertrauensentscheidung behandelt werden. Je nach Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise die X.509‑Zertifikatskette aufbauen und validieren, Gültigkeitsdaten und Sperrstatus des Zertifikats prüfen, das erwartete Subject oder den Fingerabdruck bestätigen, die Schlüsselverwendung überprüfen und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert von [DigitalSignature.getSignTime](https://reference.aspose.com/slides/de/python-java/aspose.slides/digitalsignature/#getSignTime) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempeldienststelle.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/digitalsignaturecollection/#clear) und speichert eine unsignierte Kopie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Um nur eine Signatur zu entfernen, rufen Sie [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/digitalsignaturecollection/#removeAt) mit dem Null‑basierten Index auf. Speichern Sie in einer neuen Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Bestandteil Ihres Workflows.

## **Bearbeitungs‑ und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt machen in der Regel die bestehende Signatur ungültig.
- Führen Sie alle gewünschten Änderungen vor dem Signieren durch. Wenn eine Präsentation geändert werden muss, speichern Sie die überarbeitete Präsentation und signieren Sie diese Revision erneut.
- Behalten Sie die endgültige Ausgabe im PPTX‑Format. Die Konvertierung einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erhält, kann Signaturen erzeugen, die scheinbar von diesem Zertifikatsinhaber stammen.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Dokumentaufbewahrungs‑Richtlinie dies verlangt.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern nicht eine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/slides/de/python-java/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Passwort dasselbe wie ein Präsentations‑Passwort?**

Nein. Das PFX‑Passwort entsperrt den im Zertifikatspaket gespeicherten privaten Schlüssel. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger vertrauen ihm nicht automatisch, es sei denn, das Zertifikat wurde ausdrücklich zu ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder organisationsübergreifende Workflows nutzen in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Änderungen am signierten Präsentationsinhalt oder an den Signaturdaten nach dem Signieren können die Signatur ungültig machen. Dateibeschädigungen können ebenfalls zu einer fehlgeschlagenen Validierung führen. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht einfach nur eine Datei mit einer ungültigen Signatur.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Signaturintegrität und das Vertrauen in den Unterzeichner sind separate Entscheidungen. Eine Produktions‑Validierungsrichtlinie sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Sperrstatus, die erwartete Identität, die Schlüsselverwendung und etwaige vertrauenswürdige Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert die Bytes der Präsentation nicht, beeinflusst jedoch die Bewertung des Zertifikat‑Vertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur erfolgt ist, während das Zertifikat gültig war. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation weiterhin bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten des signierten Inhalts macht in der Regel die vorhandene Signatur ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und dann die endgültige Version signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur zur Sammlung hinzu, die von [Presentation.getDigitalSignatures] zurückgegeben wird, bevor Sie speichern. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Vorgänge nur für PPTX. PPT‑ und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinträchtigen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält keinen Nachweis mehr über die entfernte Signatur.