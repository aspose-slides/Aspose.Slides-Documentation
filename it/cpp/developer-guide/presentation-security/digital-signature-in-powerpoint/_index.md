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
- PKCS#12
- validare firma
- PowerPoint
- PPTX
- sicurezza della presentazione
- C++
- Aspose.Slides
description: "Scopri come firmare presentazioni PPTX esistenti con certificati PFX e utilizzare Aspose.Slides per C++ per validare o rimuovere firme digitali."
---
## **Panoramica**

Una firma digitale aiuta il destinatario a determinare chi ha firmato una presentazione e se il contenuto firmato è stato modificato. Tre concetti di sicurezza correlati sono importanti qui:

- Un **certificato digitale** è un documento elettronico che associa un'identità a una chiave pubblica. Un'autorità di certificazione (CA) affidabile può rilasciare un certificato, oppure un'organizzazione può usare un certificato auto-firmato per flussi di lavoro interni.
- Una **firma digitale** viene creata dal contenuto della presentazione e dalla chiave privata del titolare del certificato. La chiave pubblica del certificato può quindi essere usata per verificare la firma. Una firma fornisce prova di origine e integrità; non crittografa la presentazione.
- **Protezione con password** controlla se un utente può aprire o modificare una presentazione. È separata dalla firma digitale ed è descritta in [Presentazioni protette da password](/cpp/password-protected-presentation/).

PowerPoint fornisce il comando **Add a Digital Signature** sotto **File > Info > Protect Presentation**.

![Menu Proteggi presentazione di PowerPoint con Aggiungi firma digitale evidenziata](add-digital-signature-in-powerpoint.png)

Dopo l'apertura di una presentazione firmata, PowerPoint può visualizzare una notifica sullo stato della firma.

![Notifica di PowerPoint che indica che la presentazione contiene firme valide](digital-signature-status-in-powerpoint.png)

Aspose.Slides espone le firme attraverso [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_digitalsignatures/), che restituisce un [IDigitalSignatureCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/idigitalsignaturecollection/), i cui elementi implementano [IDigitalSignature](https://reference.aspose.com/slides/it/cpp/aspose.slides/idigitalsignature/). Una presentazione può contenere più firme.

## **Comprendere i certificati PFX e le password**

Un file PFX, noto anche come file PKCS#12 e comunemente con estensione `.pfx` o `.p12`, può contenere un certificato X.509, la sua chiave privata e la catena di certificati. La chiave privata è ciò che consente al titolare di creare una firma. Un certificato senza una chiave privata accessibile non può essere usato per firmare una presentazione.

La password PFX protegge il pacchetto del certificato e la chiave privata. **Non** è una password per aprire o modificare la presentazione. Non eseguire il commit di file PFX o delle loro password nel controllo della versione. In produzione, limita l'accesso al file del certificato e ottieni la sua password da un secret store o un'altra fonte di configurazione protetta. Gli esempi seguenti usano una variabile d'ambiente solo per evitare di inserire la password nel codice.

## **Aggiungere una firma digitale a una presentazione**

Per firmare una presentazione reale, carica un file PPTX esistente, crea un [DigitalSignature](https://reference.aspose.com/slides/it/cpp/aspose.slides/digitalsignature/) da un certificato PFX e dalla sua password, aggiungi la firma alla collezione della presentazione e salva in un file PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Salvare il risultato con un nuovo nome preserva il file sorgente non firmato. Il valore [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/it/cpp/aspose.slides/idigitalsignature/set_comments/) descrive lo scopo della firma; non è un controllo di sicurezza.

## **Convalidare le firme digitali**

Quando carichi un file PPTX firmato, ispeziona ogni elemento restituito da [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_digitalsignatures/). Il metodo [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/it/cpp/aspose.slides/idigitalsignature/get_isvalid/) indica se la firma incorporata è valida per il contenuto attuale della presentazione.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Un risultato non valido indica solitamente che il contenuto della presentazione firmata o i dati della firma sono stati modificati dopo la firma, oppure che il file è danneggiato. Rimuovere tutte le firme genera una presentazione non firmata, quindi verificare solo la validità degli elementi non è sufficiente: un flusso di lavoro sensibile alla sicurezza deve anche verificare che siano presenti il numero previsto di firme e le identità dei firmatari attese.

Questo risultato di validità non dovrebbe essere considerato una decisione completa di fiducia nel certificato. A seconda della tua politica di sicurezza, l'applicazione potrebbe dover anche costruire e validare la catena di certificati X.509, verificare le date di validità e lo stato di revoca del certificato, confermare il soggetto o l'impronta attesi, controllare l'uso della chiave e valutare un timestamp affidabile. Il valore [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/it/cpp/aspose.slides/idigitalsignature/get_signtime/) da solo non è una prova da un'autorità di timestamp affidabile.

## **Rimuovere le firme digitali**

La rimozione delle firme modifica lo stato di sicurezza della presentazione. L'esempio seguente carica un file PPTX firmato, rimuove tutte le firme con [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/it/cpp/aspose.slides/idigitalsignaturecollection/clear/), e salva una copia non firmata.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Per rimuovere una sola firma, chiama [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/it/cpp/aspose.slides/idigitalsignaturecollection/removeat/) con il suo indice basato su zero. Salva in un nuovo file a meno che la sovrascrittura dell'originale firmato non sia una parte esplicita del tuo flusso di lavoro.

## **Considerazioni su modifica e formato**

- Una firma non rende la presentazione di sola lettura. Utenti e applicazioni possono ancora modificare il file, ma le modifiche al contenuto firmato di solito invalidano la firma esistente.
- Completa tutte le modifiche previste prima di firmare. Se una presentazione deve essere modificata, salva la presentazione revisionata e firma nuovamente quella revisione.
- Mantieni l'output finale in formato PPTX. Convertire una presentazione firmata in un altro formato non trasferisce la firma PPTX originale come firma valida per il file convertito.
- Considera la chiave privata del certificato come sensibile. Chiunque ottenga la chiave privata e la sua password potrebbe creare firme che sembrano provenire dal titolare del certificato.
- Conserva il sorgente non firmato o un'altra copia controllata quando la tua politica di conservazione dei documenti lo richiede.

## **FAQ**

**Una firma digitale crittografa la presentazione?**

No. Una firma digitale fornisce una prova sull'origine e sull'integrità, ma il contenuto della presentazione rimane leggibile a meno che non venga applicata una crittografia separata. Usa [protezione con password](/cpp/password-protected-presentation/) quando è necessario limitare l'accesso al contenuto.

**La password PFX è la stessa della password della presentazione?**

No. La password PFX sblocca la chiave privata memorizzata nel pacchetto del certificato. Non controlla chi può aprire o modificare il file PPTX.

**Posso usare un certificato auto-firmato?**

Tecnicamente, un certificato auto-firmato può essere usato se include una chiave privata accessibile. Tuttavia i destinatari non lo potranno automaticamente considerare attendibile, a meno che il certificato non sia stato aggiunto esplicitamente al loro ambiente di fiducia. I flussi di lavoro pubblici o inter-organizzativi tipicamente usano un certificato rilasciato da una CA affidabile.

**Cosa rende una firma non valida?**

Modificare il contenuto della presentazione firmata o i dati della firma dopo la firma può invalidare la firma. La corruzione del file può anche causare il fallimento della convalida. Se tutte le firme vengono rimosse, la presentazione è non firmata anziché contenere una firma non valida.

**Una firma valida significa che devo fidarmi del firmatario?**

Non da sola. L'integrità della firma e la fiducia nel firmatario sono decisioni separate. Una politica di convalida in produzione dovrebbe anche verificare la catena di certificati, il periodo di validità, lo stato di revoca, l'identità attesa, l'uso della chiave e eventuali requisiti di timestamp affidabili.

**Cosa succede quando il certificato scade?**

La scadenza del certificato non altera i byte della presentazione, ma influisce sulla valutazione della fiducia nel certificato. Se una firma rimane accettabile dipende dalla tua politica e dal fatto che un timestamp affidabile valido dimostri che la firma è avvenuta mentre il certificato era valido. Non fare affidamento solo sul tempo di firma visualizzato come timestamp affidabile.

**Una presentazione firmata può ancora essere modificata?**

Sì. La firma non blocca il file. Modificare il contenuto firmato di solito rende la firma esistente non valida, quindi completa prima la presentazione e firma la revisione finale.

**Una presentazione può contenere più di una firma?**

Sì. Aggiungi ogni firma alla collezione restituita da [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_digitalsignatures/) prima di salvare. Durante la convalida, ispeziona ogni firma e conferma che tutti i firmatari richiesti siano presenti.

**Quali formati di presentazione supportano queste operazioni?**

Aspose.Slides supporta le operazioni di firma digitale descritte qui solo per PPTX. I formati di presentazione PPT e OpenDocument non sono supportati da questo flusso di lavoro API.

**Posso rimuovere una firma senza influire sulle diapositive?**

Sì. Puoi rimuovere una firma o svuotare l'intera collezione e poi salvare la presentazione. Il contenuto delle diapositive rimane disponibile, ma il file salvato non porta più la prova della firma rimossa.