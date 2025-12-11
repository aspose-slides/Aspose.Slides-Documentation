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
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für C++ digital signieren. Sichern Sie Ihre Folien in Sekunden mit klaren Codebeispielen."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint‑Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation — einer Zertifizierungsstelle — erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um der Präsentation über Datei → Info → Präsentation schützen eine digitale Signatur hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint in PowerPoint eine spezielle Meldung:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um eine Präsentation zu signieren oder die Echtheit von Präsentationssignaturen zu überprüfen, bietet die **Aspose.Slides API** die Schnittstelle [**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature), die Schnittstelle [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) und die Methode [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Derzeit werden digitale Signaturen nur für das PPTX‑Format unterstützt.

## **Digitale Signatur aus einem PFX‑Zertifikat hinzufügen**
Das folgende Codebeispiel zeigt, wie man eine digitale Signatur aus einem PFX‑Zertifikat hinzufügt:

1. Öffnen Sie die PFX‑Datei und übergeben Sie das PFX‑Passwort an das Objekt [**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature).
2. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.
``` cpp
auto pres = System::MakeObject<Presentation>();

// Erstelle DigitalSignature-Objekt mit PFX-Datei und PFX-Passwort 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Kommentiere neue digitale Signatur
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Füge digitale Signatur zur Präsentation hinzu
pres->get_DigitalSignatures()->Add(signature);

// Speichere Präsentation
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```


Jetzt ist es möglich zu prüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:
``` cpp
// Präsentation öffnen
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Überprüfen, ob alle digitalen Signaturen gültig sind
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```


## **FAQ**

**Kann ich vorhandene Signaturen aus einer Datei entfernen?**

Ja. Die Sammlung digitaler Signaturen unterstützt das [Entfernen einzelner Elemente](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/removeat/) und das [komplette Leeren](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/clear/); nachdem Sie die Datei gespeichert haben, enthält die Präsentation keine Signaturen mehr.

**Wird die Datei nach dem Signieren "schreibgeschützt"?**

Nein. Eine Signatur bewahrt Integrität und Urheberschaft, blockiert jedoch keine Änderungen. Um das Bearbeiten zu beschränken, kombinieren Sie sie mit ["Read-only" oder einem Passwort](/slides/de/cpp/password-protected-presentation/).

**Wird die Signatur in verschiedenen PowerPoint-Versionen korrekt angezeigt?**

Die Signatur wird für den OOXML‑(PPTX‑)Container erstellt. Moderne PowerPoint‑Versionen, die OOXML‑Signaturen unterstützen, zeigen den Status solcher Signaturen korrekt an.