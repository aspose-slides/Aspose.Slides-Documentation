---
title: Digitale Signatur in PowerPoint
type: docs
weight: 10
url: /de/php-java/digital-signature-in-powerpoint/
keywords: "Digitales Signaturzertifikat, Zertifizierungsstelle"
description: "Fügen Sie digitale Signaturzertifikate und Zertifizierungsstellen in eine PowerPoint-Präsentation mit Aspose.Slides ein."
---

**Digitales Zertifikat** wird verwendet, um eine passwortgeschützte PowerPoint-Präsentation zu erstellen, die als von einer bestimmten Organisation oder Person erstellt gekennzeichnet ist. Ein digitales Zertifikat kann durch Kontaktaufnahme mit einer autorisierten Organisation - einer Zertifizierungsstelle - erhalten werden. Nach der Installation des digitalen Zertifikats im System kann es verwendet werden, um der Präsentation eine digitale Signatur hinzuzufügen über Datei -> Informationen -> Präsentation schützen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Die Präsentation kann mehr als eine digitale Signatur enthalten. Nachdem die digitale Signatur zur Präsentation hinzugefügt wurde, erscheint eine spezielle Nachricht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Um die Präsentation zu signieren oder die Echtheit der Präsentationssignaturen zu überprüfen, bietet die **Aspose.Slides API** die [**IDigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignature) Schnittstelle, die [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignatureCollection) Schnittstelle und die [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getDigitalSignatures--) Methode. Derzeit werden digitale Signaturen nur für das PPTX-Format unterstützt.
## **Digitale Signatur aus PFX-Zertifikat hinzufügen**
Das folgende Codebeispiel zeigt, wie man eine digitale Signatur aus einem PFX-Zertifikat hinzufügt:

1. Öffnen Sie die PFX-Datei und übergeben Sie das PFX-Passwort an das [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature) Objekt.
1. Fügen Sie die erstellte Signatur dem Präsentationsobjekt hinzu.

```php
  # Präsentationsdatei öffnen
  $pres = new Presentation();
  try {
    # DigitalSignature Objekt mit PFX-Datei und PFX-Passwort erstellen
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Bemerkung zur neuen digitalen Signatur
    $signature->setComments("Aspose.Slides digitale Signaturtest.");
    # Digitale Signatur zur Präsentation hinzufügen
    $pres->getDigitalSignatures()->add($signature);
    # Präsentation speichern
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Jetzt ist es möglich zu überprüfen, ob die Präsentation digital signiert wurde und nicht modifiziert wurde:

```php
  # Präsentation öffnen
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Verwendete Signaturen zum Signieren der Präsentation: ");
      # Überprüfen, ob alle digitalen Signaturen gültig sind
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "GÜLTIG" : "UNGÜLTIG");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Präsentation ist echt, alle Signaturen sind gültig.");
      } else {
        echo("Präsentation wurde seit der Signatur geändert.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```