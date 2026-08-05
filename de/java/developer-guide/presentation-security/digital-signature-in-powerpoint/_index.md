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
description: "Erfahren Sie, wie Sie vorhandene PPTX‑Präsentationen mit PFX‑Zertifikaten signieren und Aspose.Slides für Java verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft einem Empfänger zu bestimmen, wer eine Präsentation unterschrieben hat und ob sich der signierte Inhalt geändert hat. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Beglaubigungsdokument, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Workflows verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann dann zur Verifizierung der Signatur verwendet werden. Eine Signatur liefert Nachweis über Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist vom digitalen Signieren getrennt und wird in [Password-Protected Presentations](/java/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Add a Digital Signature** unter **Datei > Info > Präsentation schützen** bereit.

![PowerPoint-Menü Präsentation schützen mit hervorgehobener Option Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Benachrichtigung zum Signaturstatus anzeigen.

![PowerPoint-Benachrichtigung, die besagt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) bereit, das eine [IDigitalSignatureCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignaturecollection/) zurückgibt, deren Elemente [IDigitalSignature](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignature/) implementieren. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX-Zertifikaten und Passwörtern**

Eine PFX-Datei, auch als PKCS#12-Datei bekannt und üblicherweise mit der Erweiterung `.pfx` oder `.p12` versehen, kann ein X.509-Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erzeugen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX-Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. Comitten Sie PFX-Dateien oder deren Passwörter nicht in die Versionskontrolle. In der Produktion sollten Sie den Zugriff auf die Zertifikatsdatei einschränken und das Passwort aus einem Secret Store oder einer anderen geschützten Konfigurationsquelle beziehen. Die nachstehenden Beispiele verwenden eine Umgebungsvariable, um das Einbetten des Passworts im Code zu vermeiden.

## **Digitale Signatur zu einer Präsentation hinzufügen**

Um einen echten Präsentations‑Workflow zu signieren, laden Sie eine vorhandene PPTX‑Datei, erstellen Sie ein [DigitalSignature](https://reference.aspose.com/slides/de/java/com.aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen Sie die Signatur zur Sammlung der Präsentation hinzu und speichern Sie in einer PPTX‑Datei.

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

Durch das Speichern des Ergebnisses unter einem neuen Namen bleibt die nicht signierte Quelldatei erhalten. Der von [IDigitalSignature.setComments](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) festgelegte Wert beschreibt den Zweck der Signatur; er ist keine Sicherheitskontrolle.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, prüfen Sie jedes Element, das von [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) zurückgegeben wird. Die Methode [IDigitalSignature.isValid](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignature/#isValid--) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

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

Ein ungültiges Ergebnis bedeutet in der Regel, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Durch das Entfernen aller Signaturen entsteht eine nicht signierte Präsentation, daher reicht das bloße Prüfen der Gültigkeit der Elemente nicht aus: Ein sicherheitssensitiver Workflow muss zudem verifizieren, dass die erwartete Anzahl von Signaturen und die erwarteten Unterzeichneridentitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Zertifikatsvertrauensentscheidung betrachtet werden. Je nach Ihrer Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise auch die X.509‑Zertifikatskette erstellen und validieren, Gültigkeitsdaten und den Widerrufsstatus des Zertifikats prüfen, den erwarteten Betreff oder Fingerabdruck bestätigen, die Schlüsselverwendung verifizieren und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert von [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignature/#getSignTime--) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempelbehörde.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitsstatus der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignaturecollection/#clear--), und speichert eine nicht signierte Kopie.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um nur eine Signatur zu entfernen, rufen Sie [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) mit ihrem nullbasierten Index auf. Speichern Sie in einer neuen Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs- und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt machen in der Regel die vorhandene Signatur ungültig.
- Führen Sie alle geplanten Änderungen vor dem Signieren durch. Wenn eine Präsentation geändert werden muss, speichern Sie die überarbeitete Präsentation und signieren Sie diese Revision erneut.
- Bewahren Sie die endgültige Ausgabe im PPTX‑Format auf. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erhält, kann Signaturen erzeugen, die so aussehen, als kämen sie vom Zertifikatsinhaber.
- Bewahren Sie die nicht signierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Dokumentenaufbewahrungsrichtlinie dies erfordert.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, es sei denn, es wird eine separate Verschlüsselung angewendet. Verwenden Sie [Passwortschutz](/java/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Passwort dasselbe wie das Präsentationspasswort?**

Nein. Das PFX‑Passwort entsperrt den im Zertifikatspaket gespeicherten privaten Schlüssel. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger werden ihm jedoch nicht automatisch vertrauen, es sei denn, das Zertifikat wurde ausdrücklich in ihre vertrauenswürdige Umgebung aufgenommen. Öffentliche oder bereichsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigungen können ebenfalls zum Fehlschlagen der Validierung führen. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht nur eine Datei mit einer ungültigen Signatur.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Die Integrität der Signatur und das Vertrauen zum Unterzeichner sind separate Entscheidungen. Eine Produktions‑Validierungsrichtlinie sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige Anforderungen an einen vertrauenswürdigen Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufen des Zertifikats ändert die Bytes der Präsentation nicht, beeinflusst jedoch die Bewertung des Zertifikatsvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger, vertrauenswürdiger Zeitstempel nachweist, dass die Signatur erfolgt ist, während das Zertifikat gültig war. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation weiterhin bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten des signierten Inhalts macht in der Regel die vorhandene Signatur ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und dann die endgültige Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie vor dem Speichern jeder Signatur zur Sammlung hinzu, die von [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) zurückgegeben wird. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Vorgänge nur für PPTX. PPT‑ und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinträchtigen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält den Nachweis der entfernten Signatur nicht mehr.