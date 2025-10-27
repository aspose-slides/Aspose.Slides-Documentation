---
title: Digitale Signaturen zu Präsentationen mit Python hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/python-net/digital-signature-in-powerpoint/
keywords:
- digitale Signatur
- digitales Zertifikat
- Zertifizierungsstelle
- PFX-Zertifikat
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- & OpenDocument-Dateien mit Aspose.Slides für Python via .NET digital signieren. Sichern Sie Ihre Folien in Sekunden mit klaren Codebeispielen."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt markiert ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation – einer Zertifizierungsstelle – erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um über Datei -> Info -> Präsentation schützen eine digitale Signatur zur Präsentation hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint in PowerPoint eine spezielle Meldung:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um eine Präsentation zu signieren oder die Authentizität von Präsentationssignaturen zu prüfen, stellt die **Aspose.Slides API** das [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/)‑Interface, das [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/)‑Interface und die [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)‑Eigenschaft bereit. Derzeit werden digitale Signaturen nur für das PPTX‑Format unterstützt.

## **Digitale Signatur aus PFX-Zertifikat hinzufügen**
Das folgende Codebeispiel zeigt, wie man eine digitale Signatur aus einem PFX-Zertifikat hinzufügt:

1. Öffnen Sie die PFX-Datei und übergeben Sie das PFX-Passwort an das [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/)‑Objekt.  
2. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Create DigitalSignature object with PFX file and PFX password 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comment new digital signature
    signature.comments = "Aspose.Slides digital signing test."

    # Add digital signature to presentation
    pres.digital_signatures.add(signature)

    # save presentation
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```



Jetzt ist es möglich zu prüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:

```py
# Open presentation
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Check if all digital signatures are valid
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **FAQ**

**Kann ich vorhandene Signaturen aus einer Datei entfernen?**

Ja. Die Sammlung digitaler Signaturen unterstützt das [Entfernen einzelner Elemente](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) und das [Komplett‑Leeren](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/); nachdem Sie die Datei gespeichert haben, enthält die Präsentation keine Signaturen mehr.

**Wird die Datei nach dem Signieren „schreibgeschützt“?**

Nein. Eine Signatur gewährleistet Integrität und Urheberschaft, blockiert jedoch keine Änderungen. Um das Bearbeiten einzuschränken, kombinieren Sie sie mit ["Schreibgeschützt" oder einem Passwort](/slides/de/python-net/password-protected-presentation/).

**Wird die Signatur in verschiedenen PowerPoint‑Versionen korrekt angezeigt?**

Die Signatur wird für den OOXML‑Container (PPTX) erstellt. Moderne PowerPoint‑Versionen, die OOXML‑Signaturen unterstützen, zeigen den Status solcher Signaturen korrekt an.