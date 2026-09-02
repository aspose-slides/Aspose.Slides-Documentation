---
title: Digitale Signaturen zu Präsentationen in Java hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX-Präsentationen mit PFX-Zertifikaten signieren und Aspose.Slides für Java zur Validierung oder zum Entfernen digitaler Signaturen verwenden."
---
## **Überblick**

Eine digitale Signatur hilft dem Empfänger festzustellen, wer eine Präsentation unterschrieben hat und ob der signierte Inhalt verändert wurde. Drei damit zusammenhängende Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Arbeitsabläufe verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann dann zur Verifizierung der Signatur verwendet werden. Eine Signatur liefert Nachweis für Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist von der digitalen Signatur getrennt und wird in [Passwortgeschützte Präsentationen](/slides/de/java/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Digitale Signatur hinzufügen** unter **Datei > Informationen > Präsentation schützen** bereit.

![PowerPoint-Menü „Präsentation schützen“ mit hervorgehobener „Digitale Signatur hinzufügen“](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Benachrichtigung zum Signaturstatus anzeigen.

![PowerPoint‑Benachrichtigung, die anzeigt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) bereit, das eine [IDigitalSignatureCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignaturecollection/) zurückgibt, deren Elemente [IDigitalSignature](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignature/) implementieren. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX‑Zertifikaten und Passwörtern**

Eine PFX‑Datei, auch bekannt als PKCS#12‑Datei und üblicherweise mit der Erweiterung `.pfx` oder `.p12` versehen, kann ein X.509‑Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erstellen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX‑Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. Committen Sie PFX‑Dateien oder deren Passwörter nicht in die Versionskontrolle. In der Produktion sollten Sie den Zugriff auf die Zertifikatsdatei einschränken und das Passwort aus einem Geheimnisspeicher oder einer anderen geschützten Konfigurationsquelle beziehen. Die nachstehenden Beispiele verwenden eine Umgebungsvariable, nur um das Einbetten des Passworts im Code zu vermeiden.

## **Digitale Signatur zu einer Präsentation hinzufügen**

Um einen realen Signatur‑Workflow zu demonstrieren, laden Sie eine vorhandene PPTX‑Datei, erstellen ein [DigitalSignature](https://reference.aspose.com/slides/de/java/com.aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen die Signatur der Signatursammlung der Präsentation hinzu und speichern sie als PPTX‑Datei.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Ausgangsdatei. Der mit [IDigitalSignature.setComments](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) festgelegte Wert beschreibt den Zweck der Signatur; er stellt keine Sicherheitskontrolle dar.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, untersuchen Sie jedes Element, das von [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) zurückgegeben wird. Die Methode [IDigitalSignature.isValid](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignature/#isValid--) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Ein ungültiges Ergebnis bedeutet meist, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, daher reicht das Prüfen nur der Gültigkeit der Elemente nicht aus: Ein sicherheitsrelevanter Workflow muss außerdem die erwartete Anzahl von Signaturen und die erwarteten Signatur‑Identitäten verifizieren.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Zertifikats‑Vertrauensentscheidung interpretiert werden. Je nach Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise die X.509‑Zertifikatskette aufbauen und validieren, Gültigkeitsdaten und Widerrufsstatus prüfen, den erwarteten Betreff oder Fingerabdruck bestätigen, die Schlüsselverwendung überprüfen und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert von [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignature/#getSignTime--) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempel‑Autorität.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitsstatus der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignaturecollection/#clear--) und speichert eine unsignierte Kopie.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um nur eine Signatur zu entfernen, rufen Sie [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) mit dem nullbasierten Index auf. Speichern Sie in eine neue Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs‑ und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen an signierten Inhalten machen in der Regel die bestehende Signatur ungültig.
- Führen Sie alle geplanten Änderungen vor dem Signieren durch. Muss eine Präsentation geändert werden, speichern Sie die überarbeitete Version und signieren diese Revision erneut.
- Bewahren Sie die endgültige Ausgabe im PPTX‑Format auf. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Wer den privaten Schlüssel und dessen Passwort erhält, kann Signaturen erzeugen, die angeblich von diesem Zertifikatsinhaber stammen.
- Bewahren Sie die unsignierte Ausgangsdatei oder eine andere kontrollierte Kopie auf, wenn Ihre Aufbewahrungsrichtlinie dies verlangt.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern keine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/slides/de/java/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Passwort dasselbe wie das Präsentations‑Passwort?**

Nein. Das PFX‑Passwort entsperrt den privaten Schlüssel, der im Zertifikatspaket gespeichert ist. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat benutzen?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger vertrauen ihm jedoch nicht automatisch, es sei denn, das Zertifikat wurde ausdrücklich ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder organisationsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigungen können ebenfalls zur Validierungsfehler führen. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht einfach nur ungültig signiert.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Signaturintegrität und Vertrauenswürdigkeit des Unterzeichners sind separate Entscheidungen. Eine produktive Validierungspolicy sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige Anforderungen an vertrauenswürdige Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert die Präsentationsbytes nicht, beeinflusst jedoch die Bewertung des Zertifikatsvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur während der Gültigkeit des Zertifikats erstellt wurde. Verlassen Sie sich nicht allein auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation weiterhin bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten signierter Inhalte macht in der Regel die bestehende Signatur ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und dann die endgültige Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur zur Sammlung hinzu, die von [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) zurückgegeben wird, bevor Sie speichern. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Vorgänge nur für PPTX. PPT- und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinflussen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und dann die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält keine Signatur‑Nachweise mehr.