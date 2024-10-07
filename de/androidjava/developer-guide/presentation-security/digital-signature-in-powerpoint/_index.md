---
title: Digitale Signatur in PowerPoint
type: docs
weight: 10
url: /androidjava/digital-signature-in-powerpoint/
keywords: "Digitales Signaturzertifikat, Zertifizierungsstelle"
description: "Fügen Sie ein digitales Signaturzertifikat, eine Zertifizierungsstelle in die PowerPoint-Präsentation mit Aspose.Slides hinzu."
---


**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation - einer Zertifizierungsstelle - erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um eine digitale Signatur zur Präsentation hinzuzufügen über Datei -> Informationen -> Präsentation schützen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint eine spezielle Nachricht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Um die Präsentation zu signieren oder die Echtheit der Präsentationssignaturen zu überprüfen, bietet die **Aspose.Slides API** das [**IDigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignature) Interface, das [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignatureCollection) Interface und die [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) Methode. Derzeit werden digitale Signaturen nur für das PPTX-Format unterstützt.
## **Digitale Signatur von PFX-Zertifikat hinzufügen**
Das folgende Codebeispiel zeigt, wie man eine digitale Signatur von einem PFX-Zertifikat hinzufügt:

1. PFX-Datei öffnen und PFX-Passwort an [**DigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/DigitalSignature) Objekt übergeben.
1. Die erstellte Signatur dem Präsentationsobjekt hinzufügen.

```java
// Öffnen der Präsentationsdatei
Presentation pres = new Presentation();
try {
    // Erstellen Sie das DigitalSignature-Objekt mit der PFX-Datei und dem PFX-Passwort 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Neue digitale Signatur kommentieren
    signature.setComments("Aspose.Slides digitale Signaturtest.");

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

        System.out.println("Signaturen, die zur Unterzeichnung der Präsentation verwendet wurden: ");

        // Überprüfen, ob alle digitalen Signaturen gültig sind
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "GÜLTIG" : "UNGÜLTIG"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Präsentation ist echt, alle Signaturen sind gültig.");
        else
            System.out.println("Die Präsentation wurde seit der Unterzeichnung geändert.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```