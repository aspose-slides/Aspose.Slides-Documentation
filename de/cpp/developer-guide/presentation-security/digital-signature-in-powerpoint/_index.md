---
title: Digitale Signatur in PowerPoint
type: docs
weight: 10
url: /cpp/digital-signature-in-powerpoint/
keywords: "Digitales Signaturzertifikat, Zertifizierungsstelle"
description: "Fügen Sie digitales Signaturzertifikat, Zertifizierungsstelle in PowerPoint-Präsentation mit Aspose.Slides ein."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation - einer Zertifizierungsstelle - erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um eine digitale Signatur zur Präsentation hinzuzufügen über Datei -> Informationen -> Präsentation schützen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Die Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, wird eine spezielle Nachricht in PowerPoint angezeigt:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um die Präsentation zu signieren oder die Authentizität der Präsentationssignaturen zu überprüfen, bietet die **Aspose.Slides API** die [**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature) Schnittstelle, die [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) Schnittstelle und die [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) Methode. Derzeit werden digitale Signaturen nur für das PPTX-Format unterstützt.
## **Digitale Signatur aus PFX-Zertifikat hinzufügen**
Das folgende Codebeispiel zeigt, wie man eine digitale Signatur aus einem PFX-Zertifikat hinzufügt:

1. Öffnen Sie die PFX-Datei und geben Sie das PFX-Passwort an den [**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature) Objekt weiter.
1. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Erstellen Sie das DigitalSignature-Objekt mit der PFX-Datei und dem PFX-Passwort 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Kommentieren Sie die neue digitale Signatur
signature->set_Comments(u"Aspose.Slides digitale Signaturtest.");

// Fügen Sie die digitale Signatur zur Präsentation hinzu
pres->get_DigitalSignatures()->Add(signature);

// Präsentation speichern
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Jetzt ist es möglich zu überprüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:

``` cpp
// Präsentation öffnen
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signaturen, die zur Signierung der Präsentation verwendet wurden: ");

    // Überprüfen Sie, ob alle digitalen Signaturen gültig sind
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"GÜLTIG") : System::String(u"UNGÜLTIG")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Präsentation ist echt, alle Signaturen sind gültig.");
    }
    else
    {
        Console::WriteLine(u"Präsentation wurde seit der Signierung geändert.");
    }
}
```