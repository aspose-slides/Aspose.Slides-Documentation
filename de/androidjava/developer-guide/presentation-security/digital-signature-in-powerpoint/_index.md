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
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Android digital signieren. Sichern Sie Ihre Folien in Sekunden mit klaren Java-Code-Beispielen."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint‑Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation – einer Zertifizierungsstelle – erhalten werden. Nachdem das digitale Zertifikat im System installiert wurde, kann es verwendet werden, um der Präsentation über Datei → Info → Präsentation schützen eine digitale Signatur hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint in PowerPoint eine spezielle Meldung:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um eine Präsentation zu signieren oder die Echtheit von Präsentationssignaturen zu prüfen, bietet die **Aspose.Slides API** die Schnittstelle [**IDigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignature), die Schnittstelle [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignatureCollection) und die Methode [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) . Derzeit werden digitale Signaturen nur für das PPTX‑Format unterstützt.

## **Digitale Signatur aus einem PFX‑Zertifikat hinzufügen**
Das nachstehende Code‑Beispiel zeigt, wie eine digitale Signatur aus einem PFX‑Zertifikat hinzugefügt wird:

1. Öffnen Sie die PFX‑Datei und übergeben Sie das PFX‑Passwort an das Objekt [**DigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/DigitalSignature).
2. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.
```java
// Öffnen der Präsentationsdatei
Presentation pres = new Presentation();
try {
    // Erstelle DigitalSignature-Objekt mit PFX-Datei und PFX-Passwort
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Kommentar zur neuen digitalen Signatur
    signature.setComments("Aspose.Slides digital signing test.");

    // Füge digitale Signatur zur Präsentation hinzu
    pres.getDigitalSignatures().add(signature);

    // Präsentation speichern
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Jetzt ist es möglich zu prüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:
```java
// Präsentation öffnen
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Überprüfen, ob alle digitalen Signaturen gültig sind
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

Ja. Die Sammlung digitaler Signaturen unterstützt das [Entfernen einzelner Elemente](https://reference.aspose.com/slides/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) und das [Komplett‑Leeren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--) ; nachdem Sie die Datei gespeichert haben, enthält die Präsentation keine Signaturen mehr.

**Wird die Datei nach dem Signieren „schreibgeschützt“?**

Nein. Eine Signatur bewahrt Integrität und Urheberschaft, blockiert jedoch keine Änderungen. Um das Bearbeiten zu beschränken, kombinieren Sie sie mit ["Schreibgeschützt" oder ein Passwort](/slides/de/androidjava/password-protected-presentation/).

**Wird die Signatur in verschiedenen PowerPoint‑Versionen korrekt angezeigt?**

Die Signatur wird für den OOXML‑(PPTX‑)Container erstellt. Moderne PowerPoint‑Versionen, die OOXML‑Signaturen unterstützen, zeigen den Status solcher Signaturen korrekt an.