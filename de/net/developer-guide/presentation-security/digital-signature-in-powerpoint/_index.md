---
title: Digitale Signaturen zu Präsentationen in .NET hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX-Präsentationen mit PFX-Zertifikaten signieren und Aspose.Slides für .NET verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft dem Empfänger zu bestimmen, wer eine Präsentation signiert hat und ob der signierte Inhalt geändert wurde. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Nachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Workflows verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann dann verwendet werden, um die Signatur zu überprüfen. Eine Signatur liefert einen Nachweis für Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist von der digitalen Signatur getrennt und wird in [Passwortgeschützte Präsentationen](/net/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Add a Digital Signature** unter **Datei > Info > Präsentation schützen** bereit.

![PowerPoint-Menü Präsentation schützen mit hervorgehobener Add a Digital Signature](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Benachrichtigung zum Signaturstatus anzeigen.

![PowerPoint-Benachrichtigung, die angibt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/digitalsignatures/), eine [IDigitalSignatureCollection](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignaturecollection/) deren Elemente [IDigitalSignature](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignature/) implementieren. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX-Zertifikaten und Passwörtern**

Eine PFX-Datei, auch als PKCS#12-Datei bekannt und üblicherweise mit der Endung `.pfx` oder `.p12` versehen, kann ein X.509-Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht dem Inhaber die Erstellung einer Signatur. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX-Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. Committen Sie PFX-Dateien oder deren Passwörter nicht in die Versionskontrolle. In der Produktion begrenzen Sie den Zugriff auf die Zertifikatsdatei und holen Sie das Passwort aus einem Geheimnis-Store oder einer anderen geschützten Konfigurationsquelle. Die nachfolgenden Beispiele verwenden eine Umgebungsvariable nur, um das Einbetten des Passworts im Code zu vermeiden.

## **Eine digitale Signatur zu einer Präsentation hinzufügen**

Um einen realen Präsentations‑Workflow zu signieren, laden Sie eine vorhandene PPTX‑Datei, erstellen Sie ein [DigitalSignature](https://reference.aspose.com/slides/de/net/aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Passwort, fügen Sie die Signatur zur Signatursammlung der Präsentation hinzu und speichern Sie in einer PPTX‑Datei.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der Wert [DigitalSignature.Comments](https://reference.aspose.com/slides/de/net/aspose.slides/digitalsignature/comments/) beschreibt den Zweck der Signatur; er ist keine Sicherheitsmaßnahme.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX‑Datei laden, prüfen Sie jedes Element in [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/digitalsignatures/). Die Eigenschaft [IDigitalSignature.IsValid](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignature/isvalid/) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Ein ungültiges Ergebnis bedeutet in der Regel, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, daher reicht die reine Validierung der Elemente nicht aus: Ein sicherheitskritischer Workflow muss zudem prüfen, dass die erwartete Anzahl von Signaturen und die erwarteten Unterzeichneridentitäten vorhanden sind.

Dieses Validierungsergebnis sollte nicht als endgültige Zertifikatsvertrauensentscheidung angesehen werden. Je nach Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise auch die X.509‑Zertifikatskette aufbauen und validieren, Gültigkeitsdaten und Widerrufsstatus des Zertifikats prüfen, den erwarteten Betreff oder Fingerabdruck bestätigen, die Schlüsselverwendung verifizieren und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert [IDigitalSignature.SignTime](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignature/signtime/) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempelbehörde.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignaturecollection/clear/) und speichert eine unsignierte Kopie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Um nur eine Signatur zu entfernen, rufen Sie [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignaturecollection/removeat/) mit dem nullbasierten Index auf. Speichern Sie in einer neuen Datei, es sei denn, das Überschreiben des signierten Originals ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs- und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt invalidieren in der Regel die bestehende Signatur.
- Führen Sie alle beabsichtigten Änderungen vor dem Signieren durch. Muss eine Präsentation geändert werden, speichern Sie die überarbeitete Präsentation und signieren Sie diese Revision erneut.
- Bewahren Sie die endgültige Ausgabe im PPTX‑Format auf. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erlangt, kann Signaturen erstellen, die zu stammen scheinen vom Zertifikatsinhaber.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Dokumentenaufbewahrungsrichtlinie dies verlangt.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert einen Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern keine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/net/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX-Passwort dasselbe wie das Präsentationspasswort?**

Nein. Das PFX‑Passwort entsperrt den privaten Schlüssel im Zertifikatspaket. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger werden ihm jedoch nicht automatisch vertrauen, es sei denn, das Zertifikat wurde ausdrücklich zu ihrer vertrauenswürdigen Umgebung hinzugefügt. Öffentliche oder organisationsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigungen können ebenfalls zum Scheitern der Validierung führen. Werden alle Signaturen entfernt, ist die Präsentation unsigniert und nicht eine Datei mit einer ungültigen Signatur.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Die Integrität der Signatur und das Vertrauen in den Unterzeichner sind separate Entscheidungen. Eine Produktions‑Validierungspolicy sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselverwendung und etwaige Anforderungen an einen vertrauenswürdigen Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert nicht die Bytes der Präsentation, beeinflusst jedoch die Bewertung des Zertifikatsvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur erfolgt ist, während das Zertifikat gültig war. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation trotzdem bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten von signiertem Inhalt macht in der Regel die bestehende Signatur ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und die endgültige Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jeder Signatur vor dem Speichern zu [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/digitalsignatures/) hinzu. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen Digital‑Signature‑Operationen ausschließlich für PPTX. PPT‑ und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinträchtigen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und dann die Präsentation speichern. Der Folieninhalt bleibt erhalten, jedoch enthält die gespeicherte Datei keinen Nachweis mehr über die entfernte Signatur.