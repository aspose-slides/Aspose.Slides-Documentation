---
title: Aggiungere firme digitali alle presentazioni su Android
linktitle: Firma digitale
type: docs
weight: 10
url: /it/androidjava/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come firmare digitalmente file PowerPoint e OpenDocument con Aspose.Slides per Android. Proteggi le tue diapositive in pochi secondi con chiari esempi di codice Java."
---
## **Introduzione**

**Digital certificate** è utilizzato per creare una presentazione PowerPoint protetta da password, contrassegnata come creata da una specifica organizzazione o persona. Il certificato digitale può essere ottenuto contattando un'organizzazione autorizzata – un'autorità di certificazione. Dopo aver installato il certificato digitale nel sistema, può essere usato per aggiungere una firma digitale alla presentazione tramite File -> Info -> Proteggi presentazione:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Una presentazione può contenere più di una firma digitale. Dopo che la firma digitale è stata aggiunta alla presentazione, verrà visualizzato un messaggio speciale in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Per firmare la presentazione o verificare l'autenticità delle firme della presentazione, **Aspose.Slides API** fornisce l'interfaccia [**IDigitalSignature**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IDigitalSignature) , l'interfaccia [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IDigitalSignatureCollection) e il metodo [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) . Attualmente, le firme digitali sono supportate solo per il formato PPTX.

## **Aggiungere una firma digitale da un certificato PFX**
Il seguente esempio di codice mostra come aggiungere una firma digitale da un certificato PFX:

1. Aprire il file PFX e passare la password PFX all'oggetto [**DigitalSignature**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/DigitalSignature).
2. Aggiungere la firma creata all'oggetto presentazione.

```java
// Apertura del file di presentazione
Presentation pres = new Presentation();
try {
    // Creare l'oggetto DigitalSignature con file PFX e password PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Commenta la nuova firma digitale
    signature.setComments("Aspose.Slides digital signing test.");

    // Aggiungi la firma digitale alla presentazione
    pres.getDigitalSignatures().add(signature);

    // Salva la presentazione
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Ora è possibile verificare se la presentazione è stata firmata digitalmente e non è stata modificata:

```java
// Apri la presentazione
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Verifica se tutte le firme digitali sono valide
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

**Posso rimuovere le firme esistenti da un file?**

Sì. La raccolta di firme digitali supporta la rimozione di elementi individuali e la cancellazione completa; dopo aver salvato il file, la presentazione non conterrà firme.

**Il file diventa "sola lettura" dopo la firma?**

No. Una firma preserva l'integrità e l'autore, ma non blocca le modifiche. Per limitare la modifica, combinatela con ["Solo lettura" o una password](/slides/it/androidjava/password-protected-presentation/).

**La firma verrà visualizzata correttamente in diverse versioni di PowerPoint?**

La firma è creata per il contenitore OOXML (PPTX). Le versioni moderne di PowerPoint che supportano le firme OOXML visualizzano correttamente lo stato di tali firme.