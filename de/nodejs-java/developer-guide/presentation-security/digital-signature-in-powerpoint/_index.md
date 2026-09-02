---
title: Digitale Signaturen zu Präsentationen in JavaScript hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/nodejs-java/digital-signature-in-powerpoint/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX-Präsentationen mit PFX-Zertifikaten signieren und Aspose.Slides für Node.js über Java verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Überblick**

Eine digitale Signatur hilft dem Empfänger zu bestimmen, wer eine Präsentation unterschrieben hat und ob der signierte Inhalt geändert wurde. Drei verwandte Sicherheitskonzepte sind hierbei wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Workflows verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann anschließend zur Verifizierung der Signatur verwendet werden. Eine Signatur liefert Nachweise über Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist separat von der digitalen Signatur und wird in [Passwortgeschützte Präsentationen](/slides/de/nodejs-java/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Digitale Signatur hinzufügen** unter **Datei > Info > Präsentation schützen** bereit.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Benachrichtigung zum Signaturstatus anzeigen.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) bereit, das eine [DigitalSignatureCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/digitalsignaturecollection/) mit [DigitalSignature](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/digitalsignature/)‑Objekten zurückgibt. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX‑Zertifikaten und Passwörtern**

Eine PFX‑Datei, auch bekannt als PKCS#12‑Datei und üblicherweise mit der Endung `.pfx` oder `.p12` versehen, kann ein X.509‑Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erzeugen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX‑Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. Committen Sie PFX‑Dateien oder deren Passwörter nicht in die Versionskontrolle. In der Produktion sollten Sie den Zugriff auf die Zertifikatsdatei einschränken und das Passwort aus einem Geheimnisspeicher oder einer anderen geschützten Konfigurationsquelle beziehen. Die untenstehenden Beispiele verwenden eine Umgebungsvariable, um das Passwort nicht im Code zu verankern.

## **Eine digitale Signatur zu einer Präsentation hinzufügen**

Um einen echten Präsentations‑Workflow zu signieren, laden Sie eine vorhandene PPTX‑Datei, erstellen Sie ein [DigitalSignature](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen Sie die Signatur zur Signatur‑Sammlung der Präsentation hinzu und speichern Sie sie als PPTX‑Datei.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der Wert, der über [DigitalSignature.setComments](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/digitalsignature/) gesetzt wird, beschreibt den Zweck der Signatur; er ist keine Sicherheitskontrolle.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, prüfen Sie jedes Element, das von [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) zurückgegeben wird. Die Methode [DigitalSignature.isValid](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/digitalsignature/) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

Das folgende Beispiel verwendet außerdem die Node.js‑Klasse `X509Certificate`, um den Betreffnamen jedes eingebetteten Zertifikats auszulesen.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Ein ungültiges Ergebnis bedeutet in der Regel, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, sodass das reine Prüfen der Gültigkeit von Elementen nicht ausreicht: Ein sicherheitskritischer Workflow muss ebenfalls sicherstellen, dass die erwartete Anzahl von Signaturen und die erwarteten Signatur‑Identitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Entscheidung über das Vertrauen in das Zertifikat interpretiert werden. Je nach Sicherheitsrichtlinie kann Ihre Anwendung zudem die X.509‑Zertifikatskette aufbauen und validieren, Gültigkeitsdaten und Widerrufsstatus des Zertifikats prüfen, den erwarteten Betreff oder Fingerabdruck bestätigen, die Schlüsselverwendung überprüfen und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert von [DigitalSignature.getSignTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/digitalsignature/) allein ist kein Beweis einer vertrauenswürdigen Zeitstempeldienststelle.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), und speichert eine unsignierte Kopie.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um nur eine Signatur zu entfernen, rufen Sie [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) mit dem nullbasierten Index auf. Speichern Sie in eine neue Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs‑ und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt invalidieren normalerweise die vorhandene Signatur.
- Führen Sie alle beabsichtigten Änderungen vor dem Signieren durch. Wenn eine Präsentation geändert werden muss, speichern Sie die überarbeitete Präsentation und signieren Sie diese Revision erneut.
- Bewahren Sie die endgültige Ausgabe im PPTX‑Format auf. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erhält, kann Signaturen erzeugen, die scheinbar von diesem Zertifikatsinhaber stammen.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Aufbewahrungsrichtlinie dies erfordert.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweise über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern keine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/slides/de/nodejs-java/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Passwort dasselbe wie das Präsentations‑Passwort?**

Nein. Das PFX‑Passwort entschlüsselt den privaten Schlüssel, der im Zertifikatspaket gespeichert ist. Es kontrolliert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger werden ihm jedoch nicht automatisch vertrauen, es sei denn, das Zertifikat wurde explizit zu ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder bereichsübergreifende Workflows nutzen in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Änderungen am signierten Präsentationsinhalt oder an den Signaturdaten nach dem Signieren können die Signatur ungültig machen. Dateibeschädigungen können ebenfalls zum Scheitern der Validierung führen. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht einfach „eine Datei mit einer ungültigen Signatur“.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Signaturintegrität und Vertrauen in den Unterzeichner sind separate Entscheidungen. Eine Produktions‑Validierungsrichtlinie sollte zusätzlich die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige Anforderungen an einen vertrauenswürdigen Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert die Bytes der Präsentation nicht, beeinflusst jedoch die Bewertung des Zertifikatsvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur erfolgt ist, während das Zertifikat noch gültig war. Verlassen Sie sich nicht allein auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation weiterhin bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten signierten Inhalts macht in der Regel die vorhandene Signatur ungültig, daher sollten Sie die Präsentation fertigstellen und dann die endgültige Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur zur Sammlung hinzu, die von [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) zurückgegeben wird, bevor Sie speichern. Beim Validieren prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Operationen ausschließlich für PPTX. PPT‑ und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinträchtigen?**

Ja. Sie können eine einzelne Signatur entfernen oder die gesamte Sammlung leeren und dann die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält die entfernte Signatur nicht mehr.