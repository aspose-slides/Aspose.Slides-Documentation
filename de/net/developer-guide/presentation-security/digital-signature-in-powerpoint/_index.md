---
title: Digitale Signatur in PowerPoint
type: docs
weight: 10
url: /de/net/digital-signature-in-powerpoint/
keywords: "Digitales Signaturzertifikat, Zertifizierungsstelle, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Digitale Signatur oder Zertifikat in PowerPoint hinzufügen. Zertifizierungsstelle in C# oder .NET"
---

**Digitalzertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt markiert ist. Ein Digitalzertifikat kann erhalten werden, indem man eine autorisierte Organisation - eine Zertifizierungsstelle - kontaktiert. Nach der Installation des Digitalzertifikats im System kann es verwendet werden, um der Präsentation über Datei -> Info -> Präsentation schützen eine digitale Signatur hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint in PowerPoint eine spezielle Meldung:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um eine Präsentation zu signieren oder die Echtheit von Präsentationssignaturen zu überprüfen, stellt die **Aspose.Slides API** die Schnittstelle [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature), die Schnittstelle [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) und die Eigenschaft [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) bereit. Derzeit werden digitale Signaturen nur für das PPTX‑Format unterstützt.
## **Digitale Signatur aus PFX-Zertifikat hinzufügen**
Das Codebeispiel unten zeigt, wie man eine digitale Signatur aus einem PFX‑Zertifikat hinzufügt:

1. Öffnen Sie die PFX‑Datei und übergeben Sie das PFX‑Passwort an das [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)-Objekt.
2. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.
```c#
using (Presentation pres = new Presentation())
{
    // DigitalSignature‑Objekt mit PFX‑Datei und PFX‑Passwort erstellen 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Kommentar für neue digitale Signatur
    signature.Comments = "Aspose.Slides digital signing test.";

    // Digitale Signatur zur Präsentation hinzufügen
    pres.DigitalSignatures.Add(signature);

    // Präsentation speichern
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


Jetzt ist es möglich zu prüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:
```c#
 // Präsentation öffnen
 using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
 {
     if (pres.DigitalSignatures.Count > 0)
     {
         bool allSignaturesAreValid = true;

         Console.WriteLine("Signatures used to sign the presentation: ");

         // Prüfen, ob alle digitalen Signaturen gültig sind
         foreach (DigitalSignature signature in pres.DigitalSignatures)
         {
             Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                     + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
             allSignaturesAreValid &= signature.IsValid;
         }

         if (allSignaturesAreValid)
             Console.WriteLine("Presentation is genuine, all signatures are valid.");
         else
             Console.WriteLine("Presentation has been modified since signing.");
     }
 }
```


## **FAQ**

**Kann ich vorhandene Signaturen aus einer Datei entfernen?**

Ja. Die Sammlung digitaler Signaturen unterstützt das [Entfernen einzelner Elemente](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) und das [Komplett‑Löschen](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/); nachdem Sie die Datei gespeichert haben, enthält die Präsentation keine Signaturen mehr.

**Wird die Datei nach dem Signieren "schreibgeschützt"?**

Nein. Eine Signatur bewahrt Integrität und Urheberschaft, blockiert jedoch keine Bearbeitungen. Um das Bearbeiten zu beschränken, kombinieren Sie sie mit ["Read-only" oder einem Passwort](/slides/de/net/password-protected-presentation/).

**Wird die Signatur in verschiedenen PowerPoint-Versionen korrekt angezeigt?**

Die Signatur wird für den OOXML‑(PPTX‑)Container erstellt. Moderne PowerPoint‑Versionen, die OOXML‑Signaturen unterstützen, zeigen den Status solcher Signaturen korrekt an.