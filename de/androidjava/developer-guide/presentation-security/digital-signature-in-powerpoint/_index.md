---
title: Digitale Signaturen zu Präsentationen unter Android hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX-Präsentationen mit PFX-Zertifikaten signieren und Aspose.Slides für Android über Java verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft einem Empfänger festzustellen, wer eine Präsentation unterschrieben hat und ob sich der signierte Inhalt geändert hat. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Arbeitsabläufe verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erzeugt. Der öffentliche Schlüssel des Zertifikats kann dann zur Prüfung der Signatur verwendet werden. Eine Signatur liefert Nachweis über Ursprung und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** bestimmt, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist von der digitalen Signatur getrennt und wird in [Passwortgeschützte Präsentationen](/androidjava/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Add a Digital Signature** unter **Datei > Info > Präsentation schützen** bereit.

![PowerPoint-Menü „Präsentation schützen“ mit hervorgehobener Option „Add a Digital Signature“](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Benachrichtigung über den Signaturstatus anzeigen.

![PowerPoint-Benachrichtigung, die besagt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) bereit, das eine [IDigitalSignatureCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignaturecollection/) zurückgibt, deren Elemente [IDigitalSignature](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignature/) implementieren. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX‑Zertifikaten und Passwörtern**

Eine PFX‑Datei, auch als PKCS#12‑Datei bekannt und typischerweise mit der Endung `.pfx` oder `.p12` versehen, kann ein X.509‑Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erstellen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX‑Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **nicht** das Passwort zum Öffnen oder Bearbeiten der Präsentation. Übertragen Sie PFX‑Dateien oder deren Passwörter nicht in die Versionskontrolle. In der Produktion sollten Sie den Zugriff auf die Zertifikatsdatei beschränken und das Passwort aus einem Geheimnis‑Store oder einer anderen geschützten Konfigurationsquelle beziehen. Die Beispiele unten verwenden nur eine Umgebungsvariable, um das Einbetten des Passworts im Code zu vermeiden.

## **Digitale Signatur zu einer Präsentation hinzufügen**

Um einen echten Signatur‑Workflow zu demonstrieren, laden Sie eine vorhandene PPTX‑Datei, erstellen Sie ein [DigitalSignature](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen Sie die Signatur zur Signatursammlung der Präsentation hinzu und speichern Sie sie als PPTX‑Datei.

```java
import com.aspose.slides.*;

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

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der über [IDigitalSignature.setComments](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) festgelegte Wert beschreibt den Zweck der Signatur; er stellt keine Sicherheitskontrolle dar.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, prüfen Sie jedes Element, das von [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) zurückgegeben wird. Die Methode [IDigitalSignature.isValid](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignature/#isValid--) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

```java
import com.aspose.slides.*;

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

Ein ungültiges Ergebnis bedeutet häufig, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, sodass das bloße Prüfen der Gültigkeit einzelner Elemente nicht ausreicht: Ein sicherheitsrelevanter Workflow muss zudem bestätigen, dass die erwartete Anzahl von Signaturen und die erwarteten Signatur‑Identitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Entscheidung über das Zertifikats‑Vertrauen angesehen werden. Je nach Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise die X.509‑Zertifikatskette aufbauen und prüfen, Gültigkeitsdaten und Widerrufsstatus prüfen, das erwartete Subject oder den Fingerabdruck bestätigen, die Schlüsselverwendung prüfen und einen vertrauenswürdigen Zeitstempel bewerten. Der Wert von [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempeldienst‑Autorität.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--) und speichert eine unsignierte Kopie.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um nur eine Signatur zu entfernen, rufen Sie [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) mit dem nullbasierten Index auf. Speichern Sie in eine neue Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Bestandteil Ihres Workflows.

## **Bearbeitungs- und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt führen in der Regel dazu, dass die vorhandene Signatur ungültig wird.
- Führen Sie alle gewünschten Änderungen vor dem Signieren durch. Wenn eine Präsentation geändert werden muss, speichern Sie die überarbeitete Version und signieren Sie diese Revision erneut.
- Behalten Sie das Endergebnis im PPTX‑Format. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erlangt, kann Signaturen erzeugen, die scheinbar von diesem Zertifikatsinhaber stammen.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Aufbewahrungsrichtlinie dies erfordert.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Ursprung und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern nicht zusätzlich verschlüsselt wird. Verwenden Sie [Passwortschutz](/androidjava/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Passwort dasselbe wie das Präsentations‑Passwort?**

Nein. Das PFX‑Passwort entsperrt den privaten Schlüssel, der im Zertifikatspaket gespeichert ist. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger vertrauen ihm jedoch nicht automatisch, es sei denn, das Zertifikat wurde ausdrücklich zu ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder bereichsübergreifende Workflows nutzen in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigungen können ebenfalls zum Fehlschlagen der Validierung führen. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht „eine Datei mit einer ungültigen Signatur“.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Signaturintegrität und Vertrauen in den Unterzeichner sind separate Entscheidungen. Eine Produktions‑Validierungsrichtlinie sollte zusätzlich die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige Anforderungen an einen vertrauenswürdigen Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert die Bytes der Präsentation nicht, beeinflusst jedoch die Bewertung des Zertifikats‑Vertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur während der Gültigkeit des Zertifikats erfolgt ist. Verlassen Sie sich nicht allein auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation trotzdem bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten signierten Inhalts macht in der Regel die vorhandene Signatur ungültig; schließen Sie also die Präsentation ab und signieren Sie die endgültige Revision.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur zur Sammlung hinzu, die von [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) zurückgegeben wird, bevor Sie speichern. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Vorgänge ausschließlich für PPTX. Die Formate PPT und OpenDocument‑Präsentation werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinflussen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, jedoch enthält die gespeicherte Datei die entfernten Signaturnachweise nicht mehr.