---
title: Aggiungere firme digitali alle presentazioni in .NET
linktitle: Firma digitale
type: docs
weight: 10
url: /it/net/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come firmare digitalmente file PowerPoint e OpenDocument con Aspose.Slides per .NET. Proteggi le tue diapositive in pochi secondi con chiari esempi di codice."
---
## **Introduzione**

**Certificato digitale** è usato per creare una presentazione PowerPoint protetta da password, contrassegnata come creata da un'organizzazione o persona specifica. Il certificato digitale può essere ottenuto contattando un'organizzazione autorizzata – un'autorità di certificazione. Dopo aver installato il certificato digitale nel sistema, può essere usato per aggiungere una firma digitale alla presentazione tramite File -> Info -> Proteggi presentazione:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentazione può contenere più di una firma digitale. Dopo che la firma digitale è stata aggiunta alla presentazione, apparirà un messaggio speciale in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Per firmare una presentazione o verificare l'autenticità delle firme della presentazione, **Aspose.Slides API** fornisce [**IDigitalSignature**](https://reference.aspose.com/slides/it/net/aspose.slides/idigitalsignature) interface, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/it/net/aspose.slides/IDigitalSignatureCollection) interface e la proprietà [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/properties/digitalsignatures). Attualmente, le firme digitali sono supportate solo per il formato PPTX.

## **Aggiungere una firma digitale da un certificato PFX**

Il seguente esempio di codice dimostra come aggiungere una firma digitale da un certificato PFX:

1. Aprire il file PFX e passare la password PFX a l'oggetto [**DigitalSignature**](https://reference.aspose.com/slides/it/net/aspose.slides/digitalsignature).
2. Aggiungere la firma creata all'oggetto presentazione.

```c#
using (Presentation pres = new Presentation())
{
    // Crea l'oggetto DigitalSignature con file PFX e password PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Commenta la nuova firma digitale
    signature.Comments = "Aspose.Slides digital signing test.";

    // Aggiungi la firma digitale alla presentazione
    pres.DigitalSignatures.Add(signature);

    // Salva la presentazione
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

Ora è possibile verificare se la presentazione è stata firmata digitalmente e non è stata modificata:

```c#
 // Apri presentazione
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Verifica se tutte le firme digitali sono valide
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**Posso rimuovere le firme esistenti da un file?**

Sì. La collezione di firme digitali supporta [rimozione di elementi individuali](https://reference.aspose.com/slides/it/net/aspose.slides/digitalsignaturecollection/removeat/) e [cancellazione completa](https://reference.aspose.com/slides/it/net/aspose.slides/digitalsignaturecollection/clear/); dopo aver salvato il file, la presentazione non avrà firme.

**Il file diventa "sola lettura" dopo la firma?**

No. Una firma preserva l'integrità e l'autore, ma non blocca le modifiche. Per limitare la modifica, combinarla con [\"Sola lettura\" o una password](/slides/it/net/password-protected-presentation/).

**La firma verrà visualizzata correttamente in diverse versioni di PowerPoint?**

La firma è creata per il contenitore OOXML (PPTX). Le versioni moderne di PowerPoint che supportano le firme OOXML visualizzano correttamente lo stato di tali firme.