---
title: Aggiungere firme digitali alle presentazioni in C++
linktitle: Firma digitale
type: docs
weight: 10
url: /it/cpp/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come firmare digitalmente file PowerPoint e OpenDocument con Aspose.Slides per C++. Proteggi le tue slide in pochi secondi con esempi di codice chiari."
---
## **Introduzione**

**Certificato digitale** è usato per creare una presentazione PowerPoint protetta da password, contrassegnata come creata da una specifica organizzazione o persona. Il certificato digitale può essere ottenuto contattando un'organizzazione autorizzata, un'autorità di certificazione. Dopo aver installato il certificato digitale nel sistema, può essere usato per aggiungere una firma digitale alla presentazione tramite File -> Info -> Proteggi presentazione:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Una presentazione può contenere più di una firma digitale. Dopo che la firma digitale è stata aggiunta alla presentazione, verrà visualizzato un messaggio speciale in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Per firmare una presentazione o verificare l'autenticità delle firme della presentazione, **Aspose.Slides API** fornisce l'interfaccia [**IDigitalSignature**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_digital_signature), l'interfaccia [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_digital_signature_collection) e il metodo [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Attualmente, le firme digitali sono supportate solo per il formato PPTX.

## **Aggiungere una firma digitale da un certificato PFX**
Il campione di codice sottostante dimostra come aggiungere una firma digitale da un certificato PFX:

1. Apri il file PFX e passa la password PFX a [**DigitalSignature**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.digital_signature)object.
1. Aggiungi la firma creata all'oggetto presentazione.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Crea oggetto DigitalSignature con file PFX e password PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Commenta nuova firma digitale
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Aggiungi firma digitale alla presentazione
pres->get_DigitalSignatures()->Add(signature);

// Salva presentazione
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Ora è possibile verificare se la presentazione è stata firmata digitalmente e non è stata modificata:

``` cpp
// Apri presentazione
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Verifica se tutte le firme digitali sono valide
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**Posso rimuovere le firme esistenti da un file?**

Sì. La collezione di firme digitali supporta la [rimozione di elementi individuali](https://reference.aspose.com/slides/it/cpp/aspose.slides/digitalsignaturecollection/removeat/) e la [cancellazione completa](https://reference.aspose.com/slides/it/cpp/aspose.slides/digitalsignaturecollection/clear/); dopo aver salvato il file, la presentazione non avrà firme.

**Il file diventa "sola lettura" dopo la firma?**

No. Una firma preserva l'integrità e l'autorialità ma non blocca le modifiche. Per limitare la modifica, combinatela con ["Read-only" o una password](/slides/it/cpp/password-protected-presentation/).

**La firma verrà visualizzata correttamente in diverse versioni di PowerPoint?**

La firma è creata per il contenitore OOXML (PPTX). Le versioni moderne di PowerPoint che supportano le firme OOXML visualizzano correttamente lo stato di tali firme.