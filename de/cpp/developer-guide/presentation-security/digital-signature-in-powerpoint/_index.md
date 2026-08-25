---
title: Digitale Signaturen zu Präsentationen in C++ hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie vorhandene PPTX-Präsentationen mit PFX-Zertifikaten signieren und Aspose.Slides für C++ verwenden, um digitale Signaturen zu validieren oder zu entfernen."
---
## **Übersicht**

Eine digitale Signatur hilft dem Empfänger zu bestimmen, wer eine Präsentation unterschrieben hat und ob der signierte Inhalt geändert wurde. Drei verwandte Sicherheitskonzepte sind hier wichtig:

- Ein **digitales Zertifikat** ist ein elektronisches Zeugnis, das eine Identität mit einem öffentlichen Schlüssel verknüpft. Eine vertrauenswürdige Zertifizierungsstelle (CA) kann ein Zertifikat ausstellen, oder eine Organisation kann ein selbstsigniertes Zertifikat für interne Arbeitsabläufe verwenden.
- Eine **digitale Signatur** wird aus dem Präsentationsinhalt und dem privaten Schlüssel des Zertifikatsinhabers erstellt. Der öffentliche Schlüssel des Zertifikats kann dann zur Verifizierung der Signatur verwendet werden. Eine Signatur liefert Nachweis über Herkunft und Integrität; sie verschlüsselt die Präsentation nicht.
- **Passwortschutz** steuert, ob ein Benutzer eine Präsentation öffnen oder ändern kann. Er ist von der digitalen Signatur getrennt und wird in [Passwortgeschützte Präsentationen](/slides/de/cpp/password-protected-presentation/) beschrieben.

PowerPoint stellt den Befehl **Digitale Signatur hinzufügen** unter **Datei > Info > Präsentation schützen** bereit.

![PowerPoint-Menü ‚Präsentation schützen‘ mit hervorgehobener Option ‚Digitale Signatur hinzufügen‘](add-digital-signature-in-powerpoint.png)

![PowerPoint-Benachrichtigung, die anzeigt, dass die Präsentation gültige Signaturen enthält](digital-signature-status-in-powerpoint.png)

Aspose.Slides stellt Signaturen über [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_digitalsignatures/) bereit, das eine [IDigitalSignatureCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/idigitalsignaturecollection/) zurückgibt, deren Elemente [IDigitalSignature](https://reference.aspose.com/slides/de/cpp/aspose.slides/idigitalsignature/) implementieren. Eine Präsentation kann mehrere Signaturen enthalten.

## **Verstehen von PFX-Zertifikaten und Passwörtern**

Eine PFX-Datei, auch bekannt als PKCS#12-Datei und üblicherweise mit der Endung `.pfx` oder `.p12` versehen, kann ein X.509-Zertifikat, dessen privaten Schlüssel und die Zertifikatskette enthalten. Der private Schlüssel ermöglicht es dem Inhaber, eine Signatur zu erstellen. Ein Zertifikat ohne zugänglichen privaten Schlüssel kann nicht zum Signieren einer Präsentation verwendet werden.

Das PFX-Passwort schützt das Zertifikatspaket und den privaten Schlüssel. Es ist **kein** Passwort zum Öffnen oder Bearbeiten der Präsentation. Committen Sie keine PFX-Dateien oder deren Passwörter in die Versionskontrolle. In der Produktion beschränken Sie den Zugriff auf die Zertifikatsdatei und holen das Passwort aus einem geheimen Speicher oder einer anderen geschützten Konfigurationsquelle. Die nachstehenden Beispiele verwenden lediglich eine Umgebungsvariable, um das Festschreiben des Passworts im Code zu vermeiden.

## **Eine digitale Signatur zu einer Präsentation hinzufügen**

Um einen echten Präsentations-Workflow zu signieren, laden Sie eine bestehende PPTX-Datei, erstellen Sie eine [DigitalSignature](https://reference.aspose.com/slides/de/cpp/aspose.slides/digitalsignature/) aus einem PFX-Zertifikat und dessen Passwort, fügen Sie die Signatur zur Signatursammlung der Präsentation hinzu und speichern Sie sie als PPTX-Datei.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Speichern des Ergebnisses unter einem neuen Namen bewahrt die unsignierte Quelldatei. Der Wert von [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/de/cpp/aspose.slides/idigitalsignature/set_comments/) beschreibt den Zweck der Signatur; er stellt keine Sicherheitskontrolle dar.

## **Digitale Signaturen validieren**

Wenn Sie eine signierte PPTX-Datei laden, prüfen Sie jedes von [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_digitalsignatures/) zurückgegebene Element. Die Methode [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/de/cpp/aspose.slides/idigitalsignature/get_isvalid/) gibt an, ob die eingebettete Signatur für den aktuellen Präsentationsinhalt gültig ist.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Ein ungültiges Ergebnis bedeutet in der Regel, dass der signierte Präsentationsinhalt oder die Signaturdaten nach dem Signieren geändert wurden oder dass die Datei beschädigt ist. Das Entfernen aller Signaturen erzeugt eine unsignierte Präsentation, daher reicht das bloße Prüfen der Gültigkeit der Elemente nicht aus: Ein sicherheitssensitiver Workflow muss außerdem verifizieren, dass die erwartete Anzahl von Signaturen und die erwarteten Signaturidentitäten vorhanden sind.

Dieses Gültigkeitsergebnis sollte nicht als vollständige Zertifikatsvertrauensentscheidung betrachtet werden. Je nach Sicherheitsrichtlinie muss Ihre Anwendung möglicherweise die X.509-Zertifikatskette erstellen und validieren, Gültigkeitsdaten und Widerrufsstatus des Zertifikats prüfen, den erwarteten Betreff oder Fingerabdruck bestätigen, die Schlüsselnutzung verifizieren und einen vertrauenswürdigen Zeitstempel auswerten. Der Wert von [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/de/cpp/aspose.slides/idigitalsignature/get_signtime/) allein ist kein Nachweis einer vertrauenswürdigen Zeitstempelbehörde.

## **Digitale Signaturen entfernen**

Das Entfernen von Signaturen ändert den Sicherheitszustand der Präsentation. Das folgende Beispiel lädt eine signierte PPTX-Datei, entfernt alle Signaturen mit [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/idigitalsignaturecollection/clear/) und speichert eine unsignierte Kopie.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Um nur eine Signatur zu entfernen, rufen Sie [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides/idigitalsignaturecollection/removeat/) mit dem nullbasierten Index auf. Speichern Sie in eine neue Datei, es sei denn, das Überschreiben des signierten Originals ist ein expliziter Teil Ihres Workflows.

## **Bearbeitungs- und Formatüberlegungen**

- Eine Signatur macht eine Präsentation nicht schreibgeschützt. Benutzer und Anwendungen können die Datei weiterhin bearbeiten, aber Änderungen am signierten Inhalt machen die vorhandene Signatur in der Regel ungültig.
- Führen Sie alle geplanten Änderungen vor dem Signieren durch. Muss eine Präsentation geändert werden, speichern Sie die überarbeitete Präsentation und signieren Sie diese Revision erneut.
- Behalten Sie das Endergebnis im PPTX-Format. Das Konvertieren einer signierten Präsentation in ein anderes Format überträgt die ursprüngliche PPTX-Signatur nicht als gültige Signatur für die konvertierte Datei.
- Behandeln Sie den privaten Schlüssel des Zertifikats als sensibel. Jeder, der den privaten Schlüssel und dessen Passwort erhält, kann Signaturen erstellen, die scheinbar vom Zertifikatsinhaber stammen.
- Bewahren Sie die unsignierte Quelle oder eine andere kontrollierte Kopie auf, wenn Ihre Aufbewahrungsrichtlinie dies erfordert.

## **FAQ**

**Verschlüsselt eine digitale Signatur die Präsentation?**

Nein. Eine digitale Signatur liefert Nachweis über Herkunft und Integrität, aber der Präsentationsinhalt bleibt lesbar, sofern nicht eine separate Verschlüsselung angewendet wird. Verwenden Sie [Passwortschutz](/slides/de/cpp/password-protected-presentation/), wenn der Zugriff auf den Inhalt eingeschränkt werden muss.

**Ist das PFX-Passwort dasselbe wie ein Präsentationspasswort?**

Nein. Das PFX-Passwort entsperrt den privaten Schlüssel, der im Zertifikatspaket gespeichert ist. Es steuert nicht, wer die PPTX-Datei öffnen oder bearbeiten kann.

**Kann ich ein selbstsigniertes Zertifikat verwenden?**

Technisch kann ein selbstsigniertes Zertifikat verwendet werden, wenn es einen zugänglichen privaten Schlüssel enthält. Empfänger werden ihm jedoch nicht automatisch vertrauen, es sei denn, das Zertifikat wurde ausdrücklich in ihre Vertrauensumgebung aufgenommen. Öffentliche oder bereichsübergreifende Workflows verwenden in der Regel ein von einer vertrauenswürdigen CA ausgestelltes Zertifikat.

**Was macht eine Signatur ungültig?**

Das Ändern des signierten Präsentationsinhalts oder der Signaturdaten nach dem Signieren kann die Signatur ungültig machen. Dateibeschädigung kann ebenfalls zum Scheitern der Validierung führen. Wenn alle Signaturen entfernt werden, ist die Präsentation unsigniert und nicht eine Datei, die eine ungültige Signatur enthält.

**Bedeutet eine gültige Signatur, dass ich dem Unterzeichner vertrauen sollte?**

Nicht allein. Die Integrität der Signatur und das Vertrauen in den Unterzeichner sind separate Entscheidungen. Eine Produktions‑Validierungspolicy sollte zudem die Zertifikatskette, den Gültigkeitszeitraum, den Widerrufsstatus, die erwartete Identität, die Schlüsselnutzung und etwaige Anforderungen an einen vertrauenswürdigen Zeitstempel prüfen.

**Was passiert, wenn das Zertifikat abläuft?**

Das Ablaufdatum des Zertifikats ändert die Bytes der Präsentation nicht, beeinflusst jedoch die Bewertung des Zertifikatvertrauens. Ob eine Signatur weiterhin akzeptabel ist, hängt von Ihrer Richtlinie und davon ab, ob ein gültiger vertrauenswürdiger Zeitstempel nachweist, dass die Signatur erfolgt ist, während das Zertifikat noch gültig war. Verlassen Sie sich nicht ausschließlich auf die angezeigte Signaturzeit als vertrauenswürdigen Zeitstempel.

**Kann eine signierte Präsentation noch bearbeitet werden?**

Ja. Das Signieren sperrt die Datei nicht. Das Bearbeiten signierter Inhalte macht in der Regel die vorhandene Signatur ungültig, daher sollten Sie die Präsentation zuerst fertigstellen und die endgültige Revision signieren.

**Kann eine Präsentation mehr als eine Signatur enthalten?**

Ja. Fügen Sie jede Signatur der von [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_digitalsignatures/) zurückgegebenen Sammlung hinzu, bevor Sie speichern. Während der Validierung prüfen Sie jede Signatur und bestätigen, dass alle erforderlichen Unterzeichner vorhanden sind.

**Welche Präsentationsformate unterstützen diese Vorgänge?**

Aspose.Slides unterstützt die hier beschriebenen Digital‑Signatur‑Operationen ausschließlich für PPTX. Die Formate PPT und OpenDocument‑Präsentation werden von diesem API‑Workflow nicht unterstützt.

**Kann ich eine Signatur entfernen, ohne die Folien zu beeinträchtigen?**

Ja. Sie können eine Signatur entfernen oder die gesamte Sammlung leeren und anschließend die Präsentation speichern. Der Folieninhalt bleibt erhalten, aber die gespeicherte Datei enthält die entfernten Signaturnachweise nicht mehr.