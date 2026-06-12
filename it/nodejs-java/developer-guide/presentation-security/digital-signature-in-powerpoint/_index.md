---
title: Aggiungi firme digitali alle presentazioni in JavaScript
linktitle: Firma digitale
type: docs
weight: 10
url: /it/nodejs-java/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come firmare digitalmente file PowerPoint e OpenDocument con Aspose.Slides per Node.js via Java. Metti al sicuro le tue diapositive in pochi secondi con esempi di codice chiari."
---
## **Introduzione**

**Certificato digitale** è usato per creare una presentazione PowerPoint protetta da password, contrassegnata come creata da una particolare organizzazione o persona. Il certificato digitale può essere ottenuto contattando un'organizzazione autorizzata – un'autorità di certificazione. Dopo aver installato il certificato digitale nel sistema, può essere usato per aggiungere una firma digitale alla presentazione tramite File -> Info -> Proteggi presentazione:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Una presentazione può contenere più di una firma digitale. Dopo che la firma digitale è stata aggiunta alla presentazione, verrà visualizzato un messaggio speciale in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Per firmare una presentazione o verificare l'autenticità delle firme della presentazione, **Aspose.Slides API** fornisce la classe [**DigitalSignature**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/DigitalSignature), la classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/DigitalSignatureCollection) e il metodo [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--). Attualmente, le firme digitali sono supportate solo per il formato PPTX.

## **Aggiungi firma digitale da certificato PFX**

Il campione di codice qui sotto dimostra come aggiungere una firma digitale da un certificato PFX:

1. Apri il file PFX e passa la password PFX all'oggetto [**DigitalSignature**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/DigitalSignature).
1. Aggiungi la firma creata all'oggetto presentazione.

```javascript
// Apertura del file di presentazione
var pres = new aspose.slides.Presentation();
try {
    // Crea l'oggetto DigitalSignature con file PFX e password PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Commenta la nuova firma digitale
    signature.setComments("Aspose.Slides digital signing test.");
    // Aggiungi firma digitale alla presentazione
    pres.getDigitalSignatures().add(signature);
    // Salva la presentazione
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Ora è possibile verificare se la presentazione è stata firmata digitalmente e non è stata modificata:

```javascript
// Apri la presentazione
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Verifica se tutte le firme digitali sono valide
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

**Posso rimuovere le firme esistenti da un file?**

Sì. La collezione di firme digitali supporta [la rimozione di singoli elementi](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) e [la cancellazione completa](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); dopo aver salvato il file, la presentazione non avrà firme.

**Il file diventa "sola lettura" dopo la firma?**

No. Una firma preserva l'integrità e la paternità ma non blocca le modifiche. Per limitare la modifica, combinatela con ["Read-only" or a password](/slides/it/nodejs-java/password-protected-presentation/).

**La firma verrà visualizzata correttamente in diverse versioni di PowerPoint?**

La firma è creata per il contenitore OOXML (PPTX). Le versioni moderne di PowerPoint che supportano le firme OOXML visualizzano correttamente lo stato di tali firme.