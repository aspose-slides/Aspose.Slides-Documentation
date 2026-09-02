---
title: Digitale Signaturen zu Präsentationen in Python hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/python-net/digital-signature-in-powerpoint/
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
description: "Erfahren Sie, wie Sie bestehende PPTX‑Präsentationen mit PFX‑Zertifikaten signieren und Aspose.Slides für Python über .NET verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft dem Empfänger zu bestimmen, wer eine Präsentation unterschrieben hat und ob der signierte Inhalt geändert wurde. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann für interne Workflows ein selbstsigniertes Zertifikat verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann anschließend zur Verifizierung der Signatur verwendet werden. Eine Signatur liefert Nachweis über Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist von der digitalen Signatur getrennt und wird in [Passwortgeschützte Präsentationen](/slides/de/python-net/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Add a Digital Signature** unter **File > Info > Protect Presentation** bereit.

![PowerPoint-Menü Präsentation schützen mit hervorgehobenem Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Benachrichtigung zum Signatur‑Status anzeigen.

![PowerPoint-Benachrichtigung, die besagt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [Presentation.digital_signatures](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/digital_signatures/), einer [DigitalSignatureCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignaturecollection/) bereit, deren Elemente [DigitalSignature](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/)‑Objekte sind. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX-Zertifikaten und Passwörtern**

Eine PFX‑Datei, auch als PKCS#12‑Datei bekannt und üblicherweise mit der Erweiterung `.pfx` oder `.p12` versehen, kann ein X.509‑Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erzeugen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX‑Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. PFX‑Dateien oder deren Passwörter dürfen nicht in die Versionsverwaltung eingecheckt werden. In der Produktion sollte der Zugriff auf die Zertifikatdatei eingeschränkt und das Passwort aus einem Geheimnis‑Store oder einer anderen geschützten Konfigurationsquelle bezogen werden. Die nachfolgenden Beispiele verwenden eine Umgebungsvariable ausschließlich, um das Einbetten des Passworts im Code zu vermeiden.

## **Eine digitale Signatur zu einer Präsentation hinzufügen**

Um einen realen Signatur‑Workflow zu implementieren, laden Sie eine vorhandene PPTX‑Datei, erstellen Sie ein [DigitalSignature](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und seinem Passwort, fügen Sie die Signatur der Signatur‑Sammlung der Präsentation hinzu und speichern Sie in einer PPTX‑Datei.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Das Speichern unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der Wert von [DigitalSignature.comments](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/comments/) beschreibt den Zweck der Signatur; er stellt keine Sicherheitskontrolle dar.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, prüfen Sie jedes Element in [Presentation.digital_signatures](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/digital_signatures/). Die Eigenschaft [DigitalSignature.is_valid](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/is_valid/) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Ein ungültiges Ergebnis bedeutet häufig, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, daher reicht das Prüfen nur der Gültigkeit der einzelnen Elemente nicht aus: Ein sicherheitsrelevanter Workflow muss außerdem verifizieren, dass die erwartete Anzahl von Signaturen und die erwarteten Unterzeichner‑Identitäten vorhanden sind.

Die Eigenschaft [DigitalSignature.certificate](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/certificate/) liefert die Zertifikatsdaten als Byte‑Array. Das Beispiel berechnet den SHA‑256‑Fingerabdruck, sodass eine Anwendung ihn mit dem Fingerabdruck eines erwarteten Unterzeichnerzertifikats vergleichen kann.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Vertrauensentscheidung für das Zertifikat angesehen werden. Abhängig von Ihrer Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise auch die X.509‑Zertifikatskette aufbauen und validieren, Gültigkeitsdaten und Widerrufsstatus prüfen, das erwartete Subjekt oder den Fingerabdruck bestätigen, die Schlüsselverwendung überprüfen und einen vertrauenswürdigen Zeitstempel bewerten. Der Wert von [DigitalSignature.sign_time](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/sign_time/) allein ist kein Beweis einer vertrauenswürdigen Zeitstempeldienststelle.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, löscht alle Signaturen mit [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignaturecollection/clear/), und speichert eine unsignierte Kopie.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Um nur eine einzelne Signatur zu entfernen, rufen Sie [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignaturecollection/remove_at/) mit dem nullbasierten Index auf. Speichern Sie in einer neuen Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs- und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt führen normalerweise zur Ungültigkeit der bestehenden Signatur.
- Führen Sie alle beabsichtigten Bearbeitungen vor dem Signieren durch. Wenn eine Präsentation geändert werden muss, speichern Sie die überarbeitete Version und signieren Sie diese Revision erneut.
- Bewahren Sie das endgültige Ergebnis im PPTX‑Format auf. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und sein Passwort erlangt, kann Signaturen erzeugen, die so aussehen, als kämen sie vom Zertifikatsinhaber.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Aufbewahrungsrichtlinie dies erfordert.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, solange keine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/slides/de/python-net/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Passwort dasselbe wie das Präsentations‑Passwort?**

Nein. Das PFX‑Passwort entsperrt den privaten Schlüssel im Zertifikatspaket. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten darf.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger werden es jedoch nicht automatisch vertrauen, es sei denn, das Zertifikat wurde explizit zu ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder bereichsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigungen können ebenfalls dazu führen, dass die Validierung fehlschlägt. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht lediglich mit einer ungültigen Signatur versehen.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Signaturintegrität und Vertrauen zum Unterzeichner sind getrennte Entscheidungen. Eine Produktions‑Validierungspolicy sollte zusätzlich die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige vertrauenswürdige Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert nicht die Präsentationsbytes, beeinflusst aber die Bewertung des Zertifikatsvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass das Signieren während der Gültigkeit des Zertifikats erfolgte. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation weiterhin bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten signierten Inhalts macht in der Regel die bestehende Signatur ungültig, daher sollten Sie die Präsentation fertigstellen und die abschließende Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur zu [Presentation.digital_signatures](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/digital_signatures/) hinzu, bevor Sie speichern. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Operationen ausschließlich für PPTX. Die Formate PPT und OpenDocument‑Präsentation werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinflussen?**

Ja. Sie können eine einzelne Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält die entfernte Signatur nicht mehr.