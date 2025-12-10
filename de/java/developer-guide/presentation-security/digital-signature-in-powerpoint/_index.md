---
title: Digitale Signaturen zu Präsentationen in Java hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/java/digital-signature-in-powerpoint/
keywords:
- digitale Signatur
- digitales Zertifikat
- Zertifizierungsstelle
- PFX-Zertifikat
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Java digital signieren. Sichern Sie Ihre Folien in Sekunden mit klaren Codebeispielen."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt markiert ist. Das digitale Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation – einer Zertifizierungsstelle – erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um der Präsentation über Datei → Info → Präsentation schützen eine digitale Signatur hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint in PowerPoint eine spezielle Meldung:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um eine Präsentation zu signieren oder die Echtheit von Präsentationssignaturen zu überprüfen, stellt die **Aspose.Slides API** das Interface [**IDigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignature) bereit, das Interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignatureCollection) und die Methode [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getDigitalSignatures--) zur Verfügung. Derzeit werden digitale Signaturen nur für das PPTX‑Format unterstützt.

## **Digitale Signatur aus einem PFX‑Zertifikat hinzufügen**
Das nachstehende Codebeispiel zeigt, wie eine digitale Signatur aus einem PFX‑Zertifikat hinzugefügt wird:

1. Öffnen Sie die PFX‑Datei und übergeben Sie das PFX‑Passwort an das Objekt [**DigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/DigitalSignature).
1. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.
```java
// Öffnen der Präsentationsdatei
Presentation pres = new Presentation();
try {
    // DigitalSignature-Objekt mit PFX-Datei und PFX-Passwort erstellen
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Kommentar neue digitale Signatur
    signature.setComments("Aspose.Slides digital signing test.");

    // Digitale Signatur zur Präsentation hinzufügen
    pres.getDigitalSignatures().add(signature);

    // Präsentation speichern
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Jetzt ist es möglich zu überprüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:
```java
// Präsentation öffnen
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Prüfen, ob alle digitalen Signaturen gültig sind
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich vorhandene Signaturen aus einer Datei entfernen?**

Ja. Die Sammlung digitaler Signaturen unterstützt das [Entfernen einzelner Elemente](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) sowie das [Komplett‑Leeren](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#clear--); nachdem Sie die Datei gespeichert haben, enthält die Präsentation keine Signaturen mehr.

**Wird die Datei nach dem Signieren "schreibgeschützt"?**

Nein. Eine Signatur bewahrt die Integrität und Urheberschaft, blockiert jedoch keine Bearbeitungen. Um das Bearbeiten zu beschränken, kombinieren Sie sie mit ["Read-only" oder einem Kennwort](/slides/de/java/password-protected-presentation/).

**Wird die Signatur in verschiedenen PowerPoint‑Versionen korrekt angezeigt?**

Die Signatur wird für den OOXML‑Container (PPTX) erstellt. Moderne PowerPoint‑Versionen, die OOXML‑Signaturen unterstützen, zeigen den Status solcher Signaturen korrekt an.