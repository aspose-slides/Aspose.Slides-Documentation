---
title: Digitale Signatur in PowerPoint
type: docs
weight: 10
url: /de/java/digital-signature-in-powerpoint/
keywords: "Digitales Signaturzertifikat, Zertifizierungsstelle"
description: "Fügen Sie digitales Signaturzertifikat und Zertifizierungsstelle in eine PowerPoint-Präsentation mit Aspose.Slides ein."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt markiert ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation - einer Zertifizierungsstelle - erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um eine digitale Signatur zur Präsentation über Datei -> Informationen -> Präsentation schützen hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Die Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint eine spezielle Nachricht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um die Präsentation zu signieren oder die Authentizität der Präsentationssignaturen zu überprüfen, bietet die **Aspose.Slides API** das [**IDigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignature) -Interface, das [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignatureCollection) -Interface und die [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getDigitalSignatures--) -Methode an. Derzeit werden digitale Signaturen nur für das PPTX-Format unterstützt.
## **Digitale Signatur aus PFX-Zertifikat hinzufügen**
Das folgende Codebeispiel zeigt, wie man eine digitale Signatur aus einem PFX-Zertifikat hinzufügt:

1. Öffnen Sie die PFX-Datei und übergeben Sie das PFX-Passwort an das [**DigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/DigitalSignature) -Objekt.
1. Fügen Sie die erstellte Signatur zum Präsentationsobjekt hinzu.

```java
// Öffnen der Präsentationsdatei
Presentation pres = new Presentation();
try {
    // Erstellen Sie ein DigitalSignature-Objekt mit der PFX-Datei und dem PFX-Passwort
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Kommentar zur neuen digitalen Signatur
    signature.setComments("Aspose.Slides digitales Signaturtest.");

    // Fügen Sie die digitale Signatur zur Präsentation hinzu
    pres.getDigitalSignatures().add(signature);

    // Speichern der Präsentation
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Jetzt ist es möglich zu überprüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:

```java
// Öffnen der Präsentation
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signaturen, die zur Signierung der Präsentation verwendet wurden:");

        // Überprüfen, ob alle digitalen Signaturen gültig sind
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "GÜLTIG" : "UNGÜLTIG"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Die Präsentation ist authentisch, alle Signaturen sind gültig.");
        else
            System.out.println("Die Präsentation wurde seit der Signatur geändert.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```