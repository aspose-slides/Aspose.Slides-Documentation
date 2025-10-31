---
title: Digitale Signaturen zu Präsentationen mit Python hinzufügen
linktitle: Digitale Signatur
type: docs
weight: 10
url: /de/python-net/digital-signature-in-powerpoint/
keywords:
- digitale signatur
- digitales zertifikat
- zertifizierungsstelle
- PFX zertifikat
- PowerPoint
- OpenDocument
- präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑ und OpenDocument‑Dateien mit Aspose.Slides für Python via .NET digital signieren. Sichern Sie Ihre Folien in wenigen Sekunden mit klaren Codebeispielen."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint‑Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation – einer Zertifizierungsstelle – erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um über Datei → Informationen → Präsentation schützen eine digitale Signatur zur Präsentation hinzuzufügen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Eine Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint im PowerPoint eine spezielle Meldung:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um Präsentationen zu signieren oder die Authentizität von Signaturen zu überprüfen, stellt die **Aspose.Slides API** das [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/)‑Interface, das [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/)‑Interface und die [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)‑Eigenschaft bereit. Derzeit werden digitale Signaturen nur für das PPTX‑Format unterstützt.

## **Digitale Signatur aus PFX‑Zertifikat hinzufügen**

Das folgende Beispiel demonstriert, wie eine digitale Signatur aus einem PFX‑Zertifikat hinzugefügt wird:

1. Öffnen Sie die PFX‑Datei und übergeben Sie das PFX‑Passwort an das [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/)‑Objekt.  
2. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.

```py
#[TODO:Exception] RuntimeError: Proxy-Fehler (FileNotFoundException): Kann die Datei oder Assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' nicht laden. Datei wurde nicht gefunden.

import aspose.slides as slides

with slides.Presentation() as pres:
    # DigitalSignature‑Objekt mit PFX‑Datei und PFX‑Passwort erstellen
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Kommentar zur neuen digitalen Signatur
    signature.comments = "Aspose.Slides digital signing test."

    # Digitale Signatur zur Präsentation hinzufügen
    pres.digital_signatures.add(signature)

    # Präsentation speichern
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Jetzt ist es möglich zu prüfen, ob die Präsentation digital signiert wurde und nicht verändert wurde:

```py
# Präsentation öffnen
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Verwendete Signaturen zur Signatur der Präsentation: ")
        # Prüfen, ob alle digitalen Signaturen gültig sind
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Die Präsentation ist echt, alle Signaturen sind gültig.")
        else:
            print("Die Präsentation wurde seit der Signatur verändert.")
```

## **FAQ**

**Kann ich vorhandene Signaturen aus einer Datei entfernen?**

Ja. Die Sammlung digitaler Signaturen unterstützt das [Entfernen einzelner Elemente](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) und das [komplette Löschen](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/); nach dem Speichern der Datei enthält die Präsentation keine Signaturen mehr.

**Wird die Datei nach dem Signieren „schreibgeschützt“?**

Nein. Eine Signatur bewahrt Integrität und Urheberschaft, blockiert jedoch keine Bearbeitungen. Um das Bearbeiten zu verhindern, kombinieren Sie sie mit ["Schreibgeschützt" oder einem Passwort](/slides/de/python-net/password-protected-presentation/).

**Wird die Signatur in verschiedenen PowerPoint‑Versionen korrekt angezeigt?**

Die Signatur wird für den OOXML‑Container (PPTX) erstellt. Moderne PowerPoint‑Versionen, die OOXML‑Signaturen unterstützen, zeigen den Status solcher Signaturen korrekt an.