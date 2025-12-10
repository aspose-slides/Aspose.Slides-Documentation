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
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für .NET digital signieren. Schützen Sie Ihre Folien in Sekundenschnelle mit klaren Codebeispielen."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint‑Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation – einer Zertifizierungsstelle – erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um der Präsentation über Datei → Informationen → Präsentation schützen eine digitale Signatur hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint eine spezielle Meldung in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um eine Präsentation zu signieren oder die Authentizität von Präsentationssignaturen zu prüfen, stellt **Aspose.Slides API** das [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)‑Interface, das [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)‑Interface und die [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures)‑Eigenschaft bereit. Derzeit werden digitale Signaturen nur für das PPTX‑Format unterstützt.

## **Digitale Signatur aus einem PFX‑Zertifikat hinzufügen**
Das nachstehende Code‑Beispiel zeigt, wie eine digitale Signatur aus einem PFX‑Zertifikat hinzugefügt wird:

1. PFX‑Datei öffnen und das PFX‑Passwort an das [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)-Objekt übergeben.  
2. Die erstellte Signatur dem Präsentations‑Objekt hinzufügen.  
```c#
using (Presentation pres = new Presentation())
{
    // Erstelle DigitalSignature-Objekt mit PFX-Datei und PFX-Passwort
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Kommentar zur neuen digitalen Signatur
    signature.Comments = "Aspose.Slides digital signing test.";

    // digitale Signatur zur Präsentation hinzufügen
    pres.DigitalSignatures.Add(signature);

    // Präsentation speichern
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


Jetzt ist es möglich zu prüfen, ob die Präsentation digital signiert ist und nicht verändert wurde:  
```c#
 // Präsentation öffnen
 using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
 {
     if (pres.DigitalSignatures.Count > 0)
     {
         bool allSignaturesAreValid = true;

         Console.WriteLine("Signatures used to sign the presentation: ");

         // Überprüfen, ob alle digitalen Signaturen gültig sind
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

Ja. Die Sammlung digitaler Signaturen unterstützt das [Entfernen einzelner Elemente](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) und das [komplette Leeren](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/); nach dem Speichern der Datei hat die Präsentation keine Signaturen mehr.

**Wird die Datei nach dem Signieren „schreibgeschützt“?**

Nein. Eine Signatur bewahrt Integrität und Urheberschaft, blockiert jedoch keine Bearbeitungen. Um das Bearbeiten einzuschränken, kann sie mit ["Schreibgeschützt" oder einem Passwort](/slides/de/net/password-protected-presentation/) kombiniert werden.

**Wird die Signatur in verschiedenen PowerPoint‑Versionen korrekt angezeigt?**

Die Signatur wird für den OOXML‑(PPTX‑)Container erstellt. Moderne PowerPoint‑Versionen, die OOXML‑Signaturen unterstützen, zeigen den Status solcher Signaturen korrekt an.