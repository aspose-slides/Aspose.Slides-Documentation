---
title: Aggiungere firme digitali alle presentazioni con Python
linktitle: Firma digitale
type: docs
weight: 10
url: /it/python-net/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come firmare digitalmente file PowerPoint e OpenDocument con Aspose.Slides per Python via .NET. Proteggi le tue diapositive in pochi secondi con esempi di codice chiari."
---
## **Introduzione**

**Digital certificate** è utilizzato per creare una presentazione PowerPoint protetta da password, contrassegnata come creata da una particolare organizzazione o persona. Il certificato digitale può essere ottenuto contattando un'organizzazione autorizzata – un'autorità di certificazione. Dopo aver installato il certificato digitale nel sistema, può essere utilizzato per aggiungere una firma digitale alla presentazione tramite File -> Info -> Proteggi presentazione:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Una presentazione può contenere più di una firma digitale. Dopo che la firma digitale è stata aggiunta alla presentazione, verrà visualizzato un messaggio speciale in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Per firmare una presentazione o verificare l'autenticità delle firme della presentazione, **Aspose.Slides API** fornisce la classe [**DigitalSignature**](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignature/) , la classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/it/python-net/aspose.slides/DigitalSignatureCollection/) e la proprietà [**Presentation.digital_signatures**](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/digital_signatures/) . Attualmente, le firme digitali sono supportate solo per il formato PPTX.

## **Aggiungere firma digitale da certificato PFX**

Il esempio di codice seguente mostra come aggiungere una firma digitale da un certificato PFX:

1. Aprire il file PFX e passare la password PFX all'oggetto [**DigitalSignature**](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignature/).
2. Aggiungere la firma creata all'oggetto presentazione.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Crea l'oggetto DigitalSignature con file PFX e password PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Aggiungi commento nuova firma digitale
    signature.comments = "Aspose.Slides digital signing test."

    # Aggiungi firma digitale alla presentazione
    pres.digital_signatures.add(signature)

    # salva presentazione
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Ora è possibile verificare se la presentazione è stata firmata digitalmente e non è stata modificata:

```py
# Apri presentazione
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Verifica se tutte le firme digitali sono valide
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **Domande frequenti**

**Posso rimuovere le firme esistenti da un file?**

Sì. La raccolta di firme digitali supporta la [removing individual items](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignaturecollection/remove_at/) e la [clearing it entirely](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignaturecollection/clear/); dopo aver salvato il file, la presentazione non avrà firme.

**Il file diventa "sola lettura" dopo la firma?**

No. Una firma preserva l'integrità e l'autore, ma non blocca le modifiche. Per limitare la modifica, combinarla con ["Read-only" or a password](/slides/it/python-net/password-protected-presentation/).

**La firma verrà visualizzata correttamente in diverse versioni di PowerPoint?**

La firma è creata per il contenitore OOXML (PPTX). Le versioni moderne di PowerPoint che supportano le firme OOXML visualizzano correttamente lo stato di tali firme.