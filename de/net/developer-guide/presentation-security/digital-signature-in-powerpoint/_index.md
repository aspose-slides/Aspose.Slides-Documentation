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
description: "Erfahren Sie, wie Sie vorhandene PPTX‑Präsentationen mit PFX‑Zertifikaten signieren und Aspose.Slides für .NET verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft dem Empfänger zu bestimmen, wer eine Präsentation signiert hat und ob der signierte Inhalt verändert wurde. Drei damit zusammenhängende Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Anmelde­nachweis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Workflows verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann anschließend verwendet werden, um die Signatur zu überprüfen. Eine Signatur liefert Nachweis über Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Kennwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist von der digitalen Signatur getrennt und wird in [Passwortgeschützte Präsentationen](/slides/de/net/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Add a Digital Signature** unter **File > Info > Protect Presentation** bereit.

![PowerPoint-Menü „Präsentation schützen“ mit hervorgehobener Option „Digitale Signatur hinzufügen“](add-digital-signature-in-powerpoint.png)

Nachdem eine signierte Präsentation geöffnet wurde, kann PowerPoint eine Signatur‑Status‑Benachrichtigung anzeigen.

![PowerPoint-Benachrichtigung, die besagt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/digitalsignatures/), eine [IDigitalSignatureCollection](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignaturecollection/) bereit, deren Elemente [IDigitalSignature](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignature/) implementieren. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX‑Zertifikaten und Kennwörtern**

Eine PFX‑Datei, auch als PKCS#12‑Datei bekannt und üblicherweise mit der Endung `.pfx` oder `.p12` versehen, kann ein X.509‑Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erzeugen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX‑Kennwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Kennwort zum Öffnen oder Bearbeiten der Präsentation. Committet PFX‑Dateien oder deren Kennwörter nicht in die Quellcodeverwaltung. In der Produktion sollte der Zugriff auf die Zertifikatdatei eingeschränkt und das Kennwort aus einem Geheimnis‑Store oder einer anderen geschützten Konfigurationsquelle bezogen werden. Die Beispiele unten verwenden eine Umgebungsvariable, um das Einbetten des Kennworts im Code zu vermeiden.

## **Digitale Signatur zu einer Präsentation hinzufügen**

Um einen echten Präsentations‑Workflow zu signieren, laden Sie eine vorhandene PPTX‑Datei, erstellen Sie ein [DigitalSignature](https://reference.aspose.com/slides/de/net/aspose.slides/digitalsignature/) aus einem PFX‑Zertifikat und dessen Kennwort, fügen Sie die Signatur zur Signatursammlung der Präsentation hinzu und speichern Sie in einer PPTX‑Datei.

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

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der Wert [DigitalSignature.Comments](https://reference.aspose.com/slides/de/net/aspose.slides/digitalsignature/comments/) beschreibt den Zweck der Signatur; er stellt keine Sicherheitskontrolle dar.

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

Ein ungültiges Ergebnis bedeutet häufig, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, daher reicht das reine Prüfen der Gültigkeit von Elementen nicht aus: Ein sicherheitsrelevanter Workflow muss zudem überprüfen, ob die erwartete Anzahl von Signaturen und die erwarteten Unterzeichner‑Identitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Entscheidung über das Vertrauen in das Zertifikat behandelt werden. Je nach Sicherheits‑Richtlinie muss Ihre Anwendung möglicherweise die X.509‑Zertifikatskette bauen und validieren, Gültigkeitsdaten und Widerrufsstatus des Zertifikats prüfen, den erwarteten Betreff oder Fingerabdruck bestätigen, die Schlüsselverwendung überprüfen und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert [IDigitalSignature.SignTime](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignature/signtime/) allein ist kein Beweis einer vertrauenswürdigen Zeitstempel‑Behörde.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX‑Datei, entfernt alle Signaturen mit [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignaturecollection/clear/) und speichert eine unsignierte Kopie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Um nur eine Signatur zu entfernen, rufen Sie [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/idigitalsignaturecollection/removeat/) mit dem nullbasierten Index auf. Speichern Sie in einer neuen Datei, es sei denn, das Überschreiben der signierten Originaldatei ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs‑ und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt machen die bestehende Signatur in der Regel ungültig.
- Führen Sie alle gewünschten Änderungen vor dem Signieren durch. Muss eine Präsentation geändert werden, speichern Sie die überarbeitete Version und signieren Sie diese Revision erneut.
- Behalten Sie die endgültige Ausgabe im PPTX‑Format. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die originale PPTX‑Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Kennwort erhält, kann Signaturen erzeugen, die scheinbar vom Zertifikatsinhaber stammen.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Aufbewahrungsrichtlinie dies verlangt.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, solange keine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/slides/de/net/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX‑Kennwort dasselbe wie das Präsentations‑Kennwort?**

Nein. Das PFX‑Kennwort entsperrt den privaten Schlüssel, der im Zertifikatspaket gespeichert ist. Es steuert nicht, wer die PPTX‑Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch ja, sofern es einen zugänglichen privaten Schlüssel enthält. Empfänger vertrauen einem selbstsignierten Zertifikat jedoch nicht automatisch, es sei denn, es wurde explizit in deren vertrauenswürdige Umgebung aufgenommen. Öffentliche oder bereichsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Änderungen am signierten Präsentationsinhalt oder an den Signaturdaten nach dem Signieren können die Signatur ungültig machen. Dateibeschädigungen können ebenfalls zu einem Validierungsfehler führen. Werden alle Signaturen entfernt, ist die Präsentation unsigniert und nicht „ungültig signiert“.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Signaturintegrität und Vertrauen in den Unterzeichner sind separate Entscheidungen. Eine Produktions‑Validierungsrichtlinie sollte zusätzlich die Zertifikatskette, Gültigkeitszeitraum, Widerrufsstatus, erwartete Identität, Schlüsselverwendung und eventuelle vertrauenswürdige Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufen des Zertifikats ändert die Bytes der Präsentation nicht, beeinflusst aber die Bewertung des Zertifikatsvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger, vertrauenswürdiger Zeitstempel nachweist, dass die Signatur vorgenommen wurde, solange das Zertifikat gültig war. Verlassen Sie sich nicht allein auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation noch bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten signierter Inhalte macht die bestehende Signatur in der Regel ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und dann die finale Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur zu [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/digitalsignatures/) hinzu, bevor Sie speichern. Beim Validieren prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen digitalen Signatur‑Operationen nur für PPTX. PPT‑ und OpenDocument‑Präsentationsformate werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinträchtigen?**

Ja. Sie können eine einzelne Signatur entfernen oder die gesamte Sammlung leeren und dann die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält die entfernten Signaturnachweise nicht mehr.