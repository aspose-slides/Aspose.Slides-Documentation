---
title: Digitale Signaturen zu Präsentationen auf Android hinzufügen
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
- Sicherheit von Präsentationen
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX‑Präsentationen mit PFX‑Zertifikaten signieren und Aspose.Slides für Android via Java verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft dem Empfänger zu bestimmen, wer eine Präsentation unterschrieben hat und ob sich der signierte Inhalt geändert hat. Drei damit zusammenhängende Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Berechtigungsnachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Arbeitsabläufe verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann anschließend verwendet werden, um die Signatur zu prüfen. Eine Signatur liefert einen Nachweis über Ursprung und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist von der digitalen Signatur getrennt und wird in [Passwortgeschützte Präsentationen](/slides/de/androidjava/password-protected-presentation/) beschrieben.

PowerPoint bietet den Befehl **Digitale Signatur hinzufügen** unter **Datei > Info > Präsentation schützen** an.

![PowerPoint-Menü „Präsentation schützen“ mit hervorgehobener Option „Digitale Signatur hinzufügen“](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Benachrichtigung zum Signaturstatus anzeigen.

![PowerPoint-Benachrichtigung, die angibt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) bereit, das eine [IDigitalSignatureCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignaturecollection/) zurückgibt, deren Elemente [IDigitalSignature](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignature/) implementieren. Eine Präsentation kann mehrere Signaturen enthalten.

## **PFX-Zertifikate und Passwörter verstehen**

Eine PFX-Datei, auch als PKCS#12-Datei bekannt und häufig mit der Erweiterung `.pfx` oder `.p12` versehen, kann ein X.509-Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erstellen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX-Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. PFX-Dateien oder deren Passwörter sollten nicht in die Quellcodeverwaltung eingecheckt werden. In der Produktion sollte der Zugriff auf die Zertifikatsdatei eingeschränkt und das Passwort aus einem geheimen Speicher oder einer anderen geschützten Konfigurationsquelle bezogen werden. Die nachstehenden Beispiele verwenden eine Umgebungsvariable, nur um zu vermeiden, dass das Passwort im Code eingebettet wird.

## **Digitale Signatur zu einer Präsentation hinzufügen**

Um einen realen Präsentations‑Workflow zu signieren, laden Sie eine vorhandene PPTX‑Datei, erstellen Sie eine [DigitalSignature](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen Sie die Signatur zur Signatursammlung der Präsentation hinzu und speichern Sie sie als PPTX‑Datei.

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

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der durch [IDigitalSignature.setComments](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) festgelegte Wert beschreibt den Zweck der Signatur; er ist keine Sicherheitsmaßnahme.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, prüfen Sie jedes vom [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) zurückgegebene Element. Die Methode [IDigitalSignature.isValid](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignature/#isValid--) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

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

Ein ungültiges Ergebnis bedeutet in der Regel, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, sodass das reine Prüfen der Gültigkeit der Elemente nicht ausreicht: Ein sicherheitskritischer Workflow muss zudem überprüfen, dass die erwartete Anzahl an Signaturen und die erwarteten Unterzeichneridentitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Entscheidung über das Vertrauen in das Zertifikat betrachtet werden. Abhängig von Ihrer Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise auch die X.509‑Zertifikatskette aufbauen und validieren, Gültigkeitsdaten und den Widerrufsstatus des Zertifikats prüfen, den erwarteten Betreff oder Fingerabdruck bestätigen, die Schlüsselverwendung überprüfen und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert von [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempeldienststelle.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitsstatus der Präsentation. Das nachfolgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), und speichert eine unsignierte Kopie.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um nur eine Signatur zu entfernen, rufen Sie [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) mit dessen nullbasiertem Index auf. Speichern Sie in eine neue Datei, es sei denn, das Überschreiben des signierten Originals ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs- und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt machen in der Regel die vorhandene Signatur ungültig.
- Führen Sie alle beabsichtigten Änderungen vor dem Signieren durch. Wenn eine Präsentation geändert werden muss, speichern Sie die überarbeitete Präsentation und signieren Sie diese Revision erneut.
- Behalten Sie die endgültige Ausgabe im PPTX‑Format bei. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Betrachten Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erhält, kann möglicherweise Signaturen erstellen, die so aussehen, als kämen sie vom Zertifikatsinhaber.
- Bewahren Sie die unsignierte Quelle oder eine weitere kontrollierte Kopie auf, wenn Ihre Dokumentenaufbewahrungsrichtlinie dies erfordert.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert einen Nachweis über Ursprung und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern nicht eine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/slides/de/androidjava/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Entspricht das PFX-Passwort dem Präsentationspasswort?**

Nein. Das PFX‑Passwort entsperrt den im Zertifikatspaket gespeicherten privaten Schlüssel. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, sofern es einen zugänglichen privaten Schlüssel enthält. Empfänger werden es jedoch nicht automatisch vertrauen, es sei denn, das Zertifikat wurde ausdrücklich zu ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder organisationsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Eine Änderung des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigungen können ebenfalls zum Fehlschlagen der Validierung führen. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht eine Datei mit einer ungültigen Signatur.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Die Integrität der Signatur und das Vertrauen in den Unterzeichner sind separate Entscheidungen. Eine Validierungsrichtlinie in der Produktion sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige Anforderungen an einen vertrauenswürdigen Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert die Bytes der Präsentation nicht, beeinflusst jedoch die Bewertung des Zertifikatsvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur erfolgt ist, während das Zertifikat gültig war. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation weiterhin bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten von signiertem Inhalt macht in der Regel die vorhandene Signatur ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und die endgültige Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur der von [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) zurückgegebenen Sammlung hinzu, bevor Sie speichern. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen Digital‑Signatur‑Operationen ausschließlich für PPTX. PPT‑ und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinträchtigen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält keine Nachweise mehr über die entfernte Signatur.