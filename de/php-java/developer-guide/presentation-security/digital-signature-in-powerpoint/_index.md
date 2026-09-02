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
- Sicherheit der Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX‑Präsentationen mit PFX‑Zertifikaten signieren und Aspose.Slides für PHP über Java verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft einem Empfänger zu bestimmen, wer eine Präsentation signiert hat und ob sich der signierte Inhalt geändert hat. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Workflows verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann dann zur Überprüfung der Signatur verwendet werden. Eine Signatur liefert einen Nachweis über Ursprung und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder bearbeiten kann. Er ist getrennt von der digitalen Signatur und wird in [Password-Protected Presentations](/php-java/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Digitale Signatur hinzufügen** unter **Datei > Info > Präsentation schützen** zur Verfügung.

![PowerPoint-Menü Präsentation schützen mit hervorgehobener Digitale Signatur hinzufügen](add-digital-signature-in-powerpoint.png)

![PowerPoint-Benachrichtigung, die anzeigt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDigitalSignatures) bereit, die eine [DigitalSignatureCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignaturecollection/) zurückgibt, deren Elemente durch [DigitalSignature](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/) Objekte repräsentiert werden. Eine Präsentation kann mehrere Signaturen enthalten.

## **PFX-Zertifikate und Passwörter verstehen**

Eine PFX-Datei, auch als PKCS#12-Datei bekannt und üblicherweise mit der Endung `.pfx` oder `.p12` versehen, kann ein X.509-Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht dem Inhaber das Erstellen einer Signatur. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX-Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. Committieren Sie PFX-Dateien oder deren Passwörter nicht in die Quellcodeverwaltung. In der Produktion sollten Sie den Zugriff auf die Zertifikatsdatei einschränken und das Passwort aus einem Geheimnisspeicher oder einer anderen geschützten Konfigurationsquelle beziehen. Die nachstehenden Beispiele verwenden eine Umgebungsvariable, um das Passwort nicht im Code zu verankern.

## **Eine digitale Signatur zu einer Präsentation hinzufügen**

Um einen realen Präsentations-Workflow zu signieren, laden Sie eine vorhandene PPTX-Datei, erstellen Sie ein [DigitalSignature](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/) aus einem PFX-Zertifikat und dessen Passwort, fügen Sie die Signatur der Sammlung der Präsentation hinzu und speichern Sie in eine PPTX-Datei.

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

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der durch [DigitalSignature::setComments](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/setcomments/) festgelegte Wert beschreibt den Zweck der Signatur; er ist keine Sicherheitskontrolle.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX-Datei laden, untersuchen Sie jedes von [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDigitalSignatures) zurückgegebene Element. Die Methode [DigitalSignature::isValid](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/isvalid/) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

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

Ein ungültiges Ergebnis bedeutet häufig, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, sodass das bloße Prüfen der Gültigkeit der Elemente nicht ausreicht: Ein sicherheitssensitiver Workflow muss zudem prüfen, dass die erwartete Anzahl von Signaturen und die erwarteten Unterzeichner‑Identitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Zertifikatvertrauensentscheidung angesehen werden. Je nach Ihrer Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise die X.509-Zertifikatskette aufbauen und validieren, das Gültigkeitsdatum und den Widerrufsstatus des Zertifikats prüfen, den erwarteten Betreff oder Fingerabdruck bestätigen, die Schlüsselnutzung verifizieren und einen vertrauenswürdigen Zeitstempel bewerten. Der Wert von [DigitalSignature::getSignTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignature/getsigntime/) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempelstelle.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX-Datei, entfernt alle Signaturen mit [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignaturecollection/clear/) und speichert eine unsignierte Kopie.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Um nur eine Signatur zu entfernen, rufen Sie [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/digitalsignaturecollection/removeat/) mit dem nullbasierten Index auf. Speichern Sie in eine neue Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Teil Ihres Workflows.

## **Bearbeitung und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, jedoch führen Änderungen am signierten Inhalt in der Regel dazu, dass die vorhandene Signatur ungültig wird.
- Führen Sie alle beabsichtigten Änderungen vor dem Signieren durch. Wenn eine Präsentation geändert werden muss, speichern Sie die überarbeitete Präsentation und signieren Sie diese Revision erneut.
- Behalten Sie die endgültige Ausgabe im PPTX-Format. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erhält, kann möglicherweise Signaturen erzeugen, die zu stammen scheinen, als kämen sie vom Zertifikatsinhaber.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Dokumentenaufbewahrungsrichtlinie dies erfordert.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert einen Nachweis über Ursprung und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern keine separate Verschlüsselung angewendet wird. Verwenden Sie [password protection](/php-java/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX-Passwort dasselbe wie das Präsentationspasswort?**

Nein. Das PFX-Passwort entsperrt den im Zertifikatspaket gespeicherten privaten Schlüssel. Es steuert nicht, wer die PPTX-Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger vertrauen ihm jedoch nicht automatisch, es sei denn, das Zertifikat wurde ausdrücklich zu ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder organisationsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigung kann ebenfalls dazu führen, dass die Validierung fehlschlägt. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht eine Datei, die eine ungültige Signatur enthält.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Die Integrität der Signatur und das Vertrauen in den Unterzeichner sind getrennte Entscheidungen. Eine produktive Validierungsrichtlinie sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselnutzung und etwaige Anforderungen an einen vertrauenswürdigen Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufen des Zertifikats ändert die Bytes der Präsentation nicht, beeinflusst jedoch die Bewertung des Zertifikatvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass das Signieren stattfand, während das Zertifikat gültig war. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation weiterhin bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten signierten Inhalts macht in der Regel die bestehende Signatur ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und die endgültige Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur der Sammlung, die von [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDigitalSignatures) zurückgegeben wird, vor dem Speichern hinzu. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Operationen nur für PPTX. PPT- und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinflussen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält die entfernten Signaturnachweise nicht mehr.