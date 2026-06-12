---
title: Aggiungi firme digitali alle presentazioni in PHP
linktitle: Firma digitale
type: docs
weight: 10
url: /it/php-java/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Impara a firmare digitalmente file PowerPoint e OpenDocument con Aspose.Slides per PHP via Java. Metti al sicuro le tue diapositive in pochi secondi con esempi di codice chiari."
---
## **Introduzione**

**certificato digitale** è usato per creare una presentazione PowerPoint protetta da password, contrassegnata come creata da una determinata organizzazione o persona. Il certificato digitale può essere ottenuto contattando un'organizzazione autorizzata – un'autorità di certificazione. Dopo aver installato il certificato digitale nel sistema, può essere usato per aggiungere una firma digitale alla presentazione tramite File -> Info -> Proteggi presentazione:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentazione può contenere più di una firma digitale. Dopo che la firma digitale è stata aggiunta alla presentazione, appare un messaggio speciale in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Per firmare la presentazione o verificare l'autenticità delle firme della presentazione, **Aspose.Slides API** fornisce la classe [**DigitalSignature**](https://reference.aspose.com/slides/it/php-java/aspose.slides/DigitalSignature), la classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/it/php-java/aspose.slides/DigitalSignatureCollection) e il metodo [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation/#getDigitalSignatures). Attualmente, le firme digitali sono supportate solo per il formato PPTX.

## **Aggiungi una firma digitale da un certificato PFX**

Il codice di esempio seguente dimostra come aggiungere una firma digitale da un certificato PFX:

1. Apri il file PFX e passa la password PFX all'oggetto [**DigitalSignature**](https://reference.aspose.com/slides/it/php-java/aspose.slides/DigitalSignature).
1. Aggiungi la firma creata all'oggetto presentazione.

```php
  # Apertura del file di presentazione
  $pres = new Presentation();
  try {
    # Crea oggetto DigitalSignature con file PFX e password PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Commenta la nuova firma digitale
    $signature->setComments("Aspose.Slides digital signing test.");
    # Aggiungi firma digitale alla presentazione
    $pres->getDigitalSignatures()->add($signature);
    # Salva presentazione
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Ora è possibile verificare se la presentazione è stata firmata digitalmente e non è stata modificata:

```php
  # Apri presentazione
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Verifica se tutte le firme digitali sono valide
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso rimuovere le firme esistenti da un file?**

Sì. La collezione di firme digitali supporta la [rimozione di singoli elementi](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignaturecollection/removeat/) e la [pulizia completa](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignaturecollection/clear/); dopo aver salvato il file, la presentazione non avrà firme.

**Il file diventa "read-only" dopo la firma?**

No. Una firma preserva l'integrità e la paternità ma non blocca le modifiche. Per limitare le modifiche, combinare con ["Read-only" or a password](/slides/it/php-java/password-protected-presentation/).

**La firma verrà visualizzata correttamente in diverse versioni di PowerPoint?**

La firma è creata per il contenitore OOXML (PPTX). Le versioni moderne di PowerPoint che supportano le firme OOXML visualizzano correttamente lo stato di tali firme.