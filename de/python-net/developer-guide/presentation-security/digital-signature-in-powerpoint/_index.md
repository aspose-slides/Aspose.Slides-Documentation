---
title: Digitale Signatur in PowerPoint
type: docs
weight: 10
url: /python-net/digital-signature-in-powerpoint/
keywords: "Digitales Signaturzertifikat, Zertifizierungsstelle, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Digitale Signatur oder Zertifikat in PowerPoint hinzufügen. Zertifizierungsstelle in Python"
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation - einer Zertifizierungsstelle - erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um eine digitale Signatur zur Präsentation über Datei -> Informationen -> Präsentation schützen hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Die Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint eine spezielle Nachricht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um die Präsentation zu signieren oder die Authentizität der Präsentationssignaturen zu überprüfen, stellt die **Aspose.Slides API** die [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/) Schnittstelle, die [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) Schnittstelle und die [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) Eigenschaft bereit. Derzeit werden digitale Signaturen nur für das PPTX-Format unterstützt.
## **Digitale Signatur aus PFX-Zertifikat hinzufügen**
Das folgende Коде-Beispiel zeigt, wie eine digitale Signatur aus einem PFX-Zertifikat hinzugefügt wird:

1. Öffnen Sie die PFX-Datei und geben Sie das PFX-Passwort an den [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/) Objekt weiter.
1. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Konnte die Datei oder Assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' nicht laden. Datei wurde nicht gefunden.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Erstellen Sie das DigitalSignature-Objekt mit der PFX-Datei und dem PFX-Passwort 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Kommentieren Sie die neue digitale Signatur
    signature.comments = "Aspose.Slides digitale Signaturtest."

    # Fügen Sie die digitale Signatur der Präsentation hinzu
    pres.digital_signatures.add(signature)

    # Präsentation speichern
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Jetzt ist es möglich zu überprüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:

```py
# Präsentation öffnen
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signaturen, die zur Unterzeichnung der Präsentation verwendet wurden: ")
        # Prüfen, ob alle digitalen Signaturen gültig sind
        for signature in pres.digital_signatures:
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "GÜLTIG" if signature.is_valid else "UNGÜLTIG")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        
        if allSignaturesAreValid:
            print("Präsentation ist echt, alle Signaturen sind gültig.")
        else:
            print("Präsentation wurde seit der Unterzeichnung geändert.")
```