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
description: "Erfahren Sie, wie Sie vorhandene PPTX-Präsentationen mit PFX-Zertifikaten signieren und Aspose.Slides für Python via .NET verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Überblick**

Eine digitale Signatur hilft dem Empfänger zu bestimmen, wer eine Präsentation unterschrieben hat und ob sich der signierte Inhalt geändert hat. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- **Digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann für interne Workflows ein selbstsigniertes Zertifikat verwenden.
- **Digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann dann zur Überprüfung der Signatur verwendet werden. Eine Signatur liefert Nachweis über Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Nutzer eine Präsentation öffnen oder ändern kann. Er ist von der digitalen Signatur getrennt und wird in [Passwortgeschützte Präsentationen](/python-net/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Add a Digital Signature** unter **Datei > Info > Präsentation schützen** bereit.

![PowerPoint-Menü Präsentation schützen mit Add a Digital Signature hervorgehoben](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Signatur‑Status‑Benachrichtigung anzeigen.

![PowerPoint‑Benachrichtigung, die besagt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [Presentation.digital_signatures](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/digital_signatures/), eine [DigitalSignatureCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignaturecollection/), deren Elemente [DigitalSignature](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/)‑Objekte sind, bereit. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX-Zertifikaten und Passwörtern**

Eine PFX‑Datei, auch bekannt als PKCS#12‑Datei und üblicherweise mit der Endung `.pfx` oder `.p12` versehen, kann ein X.509‑Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erstellen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX‑Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **nicht** das Passwort zum Öffnen oder Bearbeiten der Präsentation. PFX‑Dateien oder deren Passwörter sollten nicht in die Versionskontrolle übernommen werden. In der Produktion sollte der Zugriff auf die Zertifikatsdatei eingeschränkt und das Passwort aus einem Geheimnis‑Speicher oder einer sonstigen geschützten Konfigurationsquelle bezogen werden. Die nachstehenden Beispiele verwenden lediglich eine Umgebungsvariable, um das Einbetten des Passworts im Code zu vermeiden.

## **Eine digitale Signatur zu einer Präsentation hinzufügen**

Um einen realen Präsentations‑Workflow zu signieren, laden Sie eine vorhandene PPTX‑Datei, erstellen ein [DigitalSignature](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen die Signatur zur Signatursammlung der Präsentation hinzu und speichern die Datei als PPTX.

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

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der Wert von [DigitalSignature.comments](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/comments/) beschreibt den Zweck der Signatur; er ist keine Sicherheitskontrolle.

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

Ein ungültiges Ergebnis bedeutet häufig, dass sich der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert haben, oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, sodass das reine Prüfen der Gültigkeit von Elementen nicht ausreicht: Ein sicherheitsrelevanter Workflow muss außerdem überprüfen, dass die erwartete Anzahl von Signaturen und die erwarteten Signatur‑Identitäten vorhanden sind.

Die Eigenschaft [DigitalSignature.certificate](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/certificate/) liefert die Zertifikatsdaten als Byte‑Array. Das Beispiel berechnet den SHA‑256‑Fingerabdruck, sodass eine Anwendung ihn mit dem Fingerabdruck eines erwarteten Signaturzertifikats vergleichen kann.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Entscheidung über das Vertrauen in das Zertifikat angesehen werden. Abhängig von Ihrer Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise auch die X.509‑Zertifikatskette aufbauen und validieren, Gültigkeitsdaten und Widerrufsstatus des Zertifikats prüfen, das erwartete Subjekt oder den Fingerabdruck bestätigen, die Schlüsselverwendung überprüfen und einen vertrauenswürdigen Zeitstempel bewerten. Der Wert [DigitalSignature.sign_time](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignature/sign_time/) allein stellt keinen Nachweis einer vertrauenswürdigen Zeitstempel‑Autorität dar.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignaturecollection/clear/), und speichert eine unsignierte Kopie.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Um nur eine Signatur zu entfernen, rufen Sie [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides/digitalsignaturecollection/remove_at/) mit deren nullbasiertem Index auf. Speichern Sie in eine neue Datei, sofern das Überschreiben der signierten Originaldatei nicht ausdrücklich Teil Ihres Workflows ist.

## **Bearbeitungs‑ und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, jedoch führen Änderungen am signierten Inhalt in der Regel dazu, dass die bestehende Signatur ungültig wird.
- Führen Sie alle beabsichtigten Änderungen vor dem Signieren durch. Muss eine Präsentation geändert werden, speichern Sie die überarbeitete Präsentation und signieren diese Revision erneut.
- Behalten Sie die endgültige Ausgabe im PPTX‑Format bei. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Betrachten Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erlangt, kann möglicherweise Signaturen erstellen, die von diesem Zertifikatsinhaber zu stammen scheinen.
- Bewahren Sie die unsignierte Quelle oder eine weitere kontrollierte Kopie auf, wenn Ihre Dokumentenaufbewahrungsrichtlinie dies verlangt.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern keine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/python-net/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Passwort dasselbe wie das Präsentations‑Passwort?**

Nein. Das PFX‑Passwort entsperrt den im Zertifikatspaket gespeicherten privaten Schlüssel. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger vertrauen ihm jedoch nicht automatisch, es sei denn, das Zertifikat wurde ausdrücklich zu ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder organisationsübergreifende Workflows nutzen in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigung kann ebenfalls zum Validierungsfehler führen. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht eine Datei mit einer ungültigen Signatur.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Die Integrität der Signatur und das Vertrauen in den Unterzeichner sind separate Entscheidungen. Eine Produktions‑Validierungsrichtlinie sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige Anforderungen an einen vertrauenswürdigen Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert nicht die Bytes der Präsentation, beeinflusst jedoch die Bewertung des Zertifikatsvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur erfolgte, während das Zertifikat noch gültig war. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation noch bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten des signierten Inhalts macht in der Regel die bestehende Signatur ungültig, daher sollte die Präsentation zuerst fertiggestellt und dann die letzte Revision signiert werden.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur vor dem Speichern zu [Presentation.digital_signatures](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/digital_signatures/) hinzu. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen Digital‑Signatur‑Operationen nur für PPTX. Die Formate PPT und OpenDocument‑Präsentation werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinflussen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält die entfernten Signaturnachweise nicht mehr.