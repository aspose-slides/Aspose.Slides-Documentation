---
title: Digitale Signatur in PowerPoint
type: docs
weight: 10
url: /net/digital-signature-in-powerpoint/
keywords: "Digitales Signaturzertifikat, Zertifizierungsstelle, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Digitale Signatur oder Zertifikat in PowerPoint hinzufügen. Zertifizierungsstelle in C# oder .NET"
---


**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Das digitale Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation - einer Zertifizierungsstelle - erhalten werden. Nach der Installation des digitalen Zertifikats ins System kann es verwendet werden, um eine digitale Signatur zur Präsentation hinzuzufügen über Datei -> Informationen -> Präsentation schützen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, wird eine spezielle Nachricht in PowerPoint angezeigt:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Um eine Präsentation zu signieren oder die Authentizität der Präsentationssignaturen zu überprüfen, bietet die **Aspose.Slides API** die [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature) Schnittstelle, die [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) Schnittstelle und die [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) Eigenschaft. Derzeit werden digitale Signaturen nur im PPTX-Format unterstützt.
## **Digitale Signatur aus PFX-Zertifikat hinzufügen**
Das folgende Codebeispiel zeigt, wie man eine digitale Signatur aus einem PFX-Zertifikat hinzufügt:

1. PFX-Datei öffnen und das PFX-Passwort an das [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature) Objekt übergeben.
1. Die erstellte Signatur zum Präsentationsobjekt hinzufügen.

```c#
using (Presentation pres = new Presentation())
{
    // Erstellen Sie ein DigitalSignature-Objekt mit der PFX-Datei und dem PFX-Passwort 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Kommentar zur neuen digitalen Signatur
    signature.Comments = "Aspose.Slides digitale Signatur-Test.";

    // Digitale Signatur zur Präsentation hinzufügen
    pres.DigitalSignatures.Add(signature);

    // Präsentation speichern
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```



Jetzt ist es möglich zu überprüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:



```c#
// Präsentation öffnen
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signaturen, die zur Signierung der Präsentation verwendet wurden: ");

        // Prüfen, ob alle digitalen Signaturen gültig sind
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "GÜLTIG" : "UNGÜLTIG"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Die Präsentation ist echt, alle Signaturen sind gültig.");
        else
            Console.WriteLine("Die Präsentation wurde seit der Signierung geändert.");
    }
}
```