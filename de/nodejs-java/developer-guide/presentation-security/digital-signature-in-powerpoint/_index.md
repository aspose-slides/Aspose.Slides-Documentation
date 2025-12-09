---
title: Digitale Signatur in PowerPoint
type: docs
weight: 10
url: /de/nodejs-java/digital-signature-in-powerpoint/
keywords: "Digitales Signaturzertifikat, Zertifizierungsstelle"
description: "Fügen Sie ein digitales Signaturzertifikat und eine Zertifizierungsstelle in die PowerPoint-Präsentation mit Aspose.Slides ein."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint‑Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Das digitale Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation – einer Zertifizierungsstelle – erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um der Präsentation über **Datei → Info → Präsentation schützen** eine digitale Signatur hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint eine spezielle Meldung in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um eine Präsentation zu signieren oder die Authentizität von Präsentationssignaturen zu überprüfen, stellt die **Aspose.Slides‑API** die Klasse [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature), die Klasse [**DigitalSignatureCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignatureCollection) und die Methode [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) bereit. Derzeit werden digitale Signaturen nur für das PPTX‑Format unterstützt.

## **Digitale Signatur aus PFX‑Zertifikat hinzufügen**
Das folgende Codebeispiel zeigt, wie eine digitale Signatur aus einem PFX‑Zertifikat hinzugefügt wird:

1. Öffnen Sie die PFX‑Datei und übergeben Sie das PFX‑Passwort an das Objekt [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature).
2. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.
```javascript
// Öffnen der Präsentationsdatei
var pres = new aspose.slides.Presentation();
try {
    // DigitalSignature-Objekt mit PFX-Datei und PFX-Passwort erstellen
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Neue digitale Signatur kommentieren
    signature.setComments("Aspose.Slides digital signing test.");
    // Digitale Signatur zur Präsentation hinzufügen
    pres.getDigitalSignatures().add(signature);
    // Präsentation speichern
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Jetzt ist es möglich zu prüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:
```javascript
// Präsentation öffnen
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Prüfen, ob alle digitalen Signaturen gültig sind
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich vorhandene Signaturen aus einer Datei entfernen?**

Ja. Die Sammlung digitaler Signaturen unterstützt das [Entfernen einzelner Elemente](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) und das [Komplett‑Leeren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); nach dem Speichern der Datei hat die Präsentation keine Signaturen mehr.

**Wird die Datei nach dem Signieren „schreibgeschützt“?**

Nein. Eine Signatur bewahrt Integrität und Urheberschaft, blockiert jedoch keine Bearbeitungen. Um das Bearbeiten zu beschränken, kombinieren Sie sie mit „[Schreibgeschützt](/slides/de/nodejs-java/password-protected-presentation/)“ oder einem Passwort.

**Wird die Signatur in verschiedenen PowerPoint‑Versionen korrekt angezeigt?**

Die Signatur wird für den OOXML‑Container (PPTX) erstellt. Moderne PowerPoint‑Versionen, die OOXML‑Signaturen unterstützen, zeigen den Status solcher Signaturen korrekt an.