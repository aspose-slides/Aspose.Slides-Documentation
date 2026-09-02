---
title: Digitale Signaturen zu Präsentationen in PHP hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX-Präsentationen mit PFX-Zertifikaten signieren und Aspose.Slides für PHP über Java verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft dem Empfänger festzustellen, wer eine Präsentation unterschrieben hat und ob der signierte Inhalt geändert wurde. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Arbeitsabläufe verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann dann zur Verifizierung der Signatur verwendet werden. Eine Signatur liefert Nachweis über Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist unabhängig von der digitalen Signatur und wird in [Password-Protected Presentations](/slides/de/php-java/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Add a Digital Signature** unter **Datei > Info > Präsentation schützen** bereit.

![PowerPoint-Menü „Presentation schützen“ mit hervorgehobener Option „Add a Digital Signature“](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Signatur‑Status‑Benachrichtigung anzeigen.

![PowerPoint‑Benachrichtigung, die angibt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDigitalSignatures) bereit, die eine [DigitalSignatureCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignaturecollection/) zurückgibt, deren Elemente durch [DigitalSignature](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/)‑Objekte repräsentiert werden. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX-Zertifikaten und Passwörtern**

Eine PFX‑Datei, auch als PKCS#12‑Datei bekannt und üblicherweise mit der Erweiterung `.pfx` oder `.p12` versehen, kann ein X.509‑Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erstellen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX‑Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. PFX‑Dateien oder deren Passwörter dürfen nicht in die Versionskontrolle eingecheckt werden. In der Produktion sollte der Zugriff auf die Zertifikatsdatei eingeschränkt und das Passwort aus einem Secrets‑Store oder einer anderen geschützten Konfigurationsquelle bezogen werden. Die nachstehenden Beispiele verwenden eine Umgebungsvariable, um das Passwort nicht im Code einzubetten.

## **Eine digitale Signatur zu einer Präsentation hinzufügen**

Um einen echten Präsentations‑Workflow zu signieren, laden Sie eine vorhandene PPTX‑Datei, erstellen Sie eine [DigitalSignature](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen Sie die Signatur zur Signatursammlung der Präsentation hinzu und speichern Sie in einer PPTX‑Datei.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der Wert, der mit [DigitalSignature::setComments](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/setcomments/) gesetzt wird, beschreibt den Zweck der Signatur; er stellt keine Sicherheitskontrolle dar.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, prüfen Sie jedes von [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDigitalSignatures) zurückgegebene Element. Die Methode [DigitalSignature::isValid](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/isvalid/) zeigt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Ein ungültiges Ergebnis bedeutet in der Regel, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, sodass das reine Überprüfen der Gültigkeit der Elemente nicht ausreicht: Ein sicherheitsrelevanter Workflow muss zudem überprüfen, dass die erwartete Anzahl von Signaturen und die erwarteten Unterzeichneridentitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Entscheidung über das Vertrauen in das Zertifikat betrachtet werden. Je nach Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise die X.509‑Zertifikatskette aufbauen und validieren, die Gültigkeitsdaten und den Widerrufsstatus des Zertifikats prüfen, das erwartete Subjekt oder den Fingerabdruck bestätigen, die Schlüsselverwendung überprüfen und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert von [DigitalSignature::getSignTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/getsigntime/) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempeldienststelle.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitsstatus der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignaturecollection/clear/), und speichert eine unsignierte Kopie.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Um nur eine Signatur zu entfernen, rufen Sie [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignaturecollection/removeat/) mit dem nullbasierten Index auf. Speichern Sie in einer neuen Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs- und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, jedoch führen Änderungen am signierten Inhalt normalerweise dazu, dass die bestehende Signatur ungültig wird.
- Führen Sie alle geplanten Änderungen vor dem Signieren durch. Muss eine Präsentation geändert werden, speichern Sie die überarbeitete Präsentation und signieren Sie diese Revision erneut.
- Bewahren Sie die endgültige Ausgabe im PPTX‑Format auf. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erlangt, kann Signaturen erstellen, die so aussehen, als kämen sie vom Zertifikatsinhaber.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Aufbewahrungsrichtlinie dies verlangt.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, solange keine separate Verschlüsselung angewendet wird. Verwenden Sie [password protection](/slides/de/php-java/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Passwort dasselbe wie das Präsentations‑Passwort?**

Nein. Das PFX‑Passwort entsperrt den privaten Schlüssel, der im Zertifikatspaket gespeichert ist. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten darf.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, sofern es einen zugänglichen privaten Schlüssel enthält. Empfänger werden ihm jedoch nicht automatisch vertrauen, es sei denn, das Zertifikat wurde ausdrücklich in ihre vertrauenswürdige Umgebung aufgenommen. Öffentliche oder organisationsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigungen können ebenfalls dazu führen, dass die Validierung fehlschlägt. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht eine Datei mit einer ungültigen Signatur.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Die Integrität der Signatur und das Vertrauen in den Unterzeichner sind getrennte Entscheidungen. Eine Validierungsrichtlinie in der Produktion sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige Anforderungen an vertrauenswürdige Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert nicht die Bytes der Präsentation, beeinflusst jedoch die Bewertung des Vertrauens in das Zertifikat. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur erfolgt ist, während das Zertifikat gültig war. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation noch bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten des signierten Inhalts macht in der Regel die bestehende Signatur ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und die endgültige Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur der Sammlung hinzu, die von [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDigitalSignatures) zurückgegeben wird, bevor Sie speichern. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Vorgänge nur für PPTX. PPT‑ und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinträchtigen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, jedoch enthält die gespeicherte Datei keinen Nachweis mehr über die entfernte Signatur.