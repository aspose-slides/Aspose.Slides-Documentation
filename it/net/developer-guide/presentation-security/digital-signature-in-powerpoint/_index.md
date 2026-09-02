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
- PKCS#12
- validare firma
- PowerPoint
- PPTX
- sicurezza della presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come firmare presentazioni PPTX esistenti con certificati PFX e utilizzare Aspose.Slides per .NET per convalidare o rimuovere firme digitali."
---
## **Panoramica**

Una firma digitale aiuta il destinatario a determinare chi ha firmato una presentazione e se il contenuto firmato è stato modificato. Tre concetti di sicurezza correlati sono importanti qui:

- Un **certificato digitale** è una credenziale elettronica che associa un'identità a una chiave pubblica. Un'autorità di certificazione (CA) di fiducia può rilasciare un certificato, oppure un'organizzazione può utilizzare un certificato autofirmato per flussi di lavoro interni.
- Una **firma digitale** viene creata dal contenuto della presentazione e dalla chiave privata del titolare del certificato. La chiave pubblica del certificato può quindi essere utilizzata per verificare la firma. Una firma fornisce evidenza di origine e integrità; non crittografa la presentazione.
- **Protezione tramite password** controlla se un utente può aprire o modificare una presentazione. È separata dalla firma digitale ed è descritta in [Presentazioni protette da password](/net/password-protected-presentation/).

PowerPoint fornisce il comando **Aggiungi una firma digitale** sotto **File > Info > Proteggi presentazione**.

![Menu Proteggi presentazione di PowerPoint con Aggiungi una firma digitale evidenziato](add-digital-signature-in-powerpoint.png)

Dopo l'apertura di una presentazione firmata, PowerPoint può visualizzare una notifica sullo stato della firma.

![Notifica di PowerPoint che indica che la presentazione contiene firme valide](digital-signature-status-in-powerpoint.png)

Aspose.Slides espone le firme tramite [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/digitalsignatures/), una [IDigitalSignatureCollection](https://reference.aspose.com/slides/it/net/aspose.slides/idigitalsignaturecollection/) i cui elementi implementano [IDigitalSignature](https://reference.aspose.com/slides/it/net/aspose.slides/idigitalsignature/). Una presentazione può contenere più firme.

## **Comprendere i certificati PFX e le password**

Un file PFX, noto anche come file PKCS#12 e comunemente con estensione `.pfx` o `.p12`, può contenere un certificato X.509, la sua chiave privata e la catena di certificati. La chiave privata è quella che consente al titolare di creare una firma. Un certificato privo di una chiave privata accessibile non può essere usato per firmare una presentazione.

La password PFX protegge il pacchetto del certificato e la chiave privata. **Non** è una password per aprire o modificare la presentazione. Non inviare i file PFX o le loro password al controllo del codice sorgente. In produzione, limita l'accesso al file certificato e ottieni la sua password da un secret store o da un'altra fonte di configurazione protetta. Gli esempi seguenti usano una variabile d'ambiente solo per evitare di incorporare la password nel codice.

## **Aggiungere una firma digitale a una presentazione**

Per firmare un flusso di lavoro reale, carica un file PPTX esistente, crea un [DigitalSignature](https://reference.aspose.com/slides/it/net/aspose.slides/digitalsignature/) da un certificato PFX e dalla sua password, aggiungi la firma alla collezione della presentazione e salva in un file PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Salvare il risultato con un nuovo nome preserva il file sorgente non firmato. Il valore [DigitalSignature.Comments](https://reference.aspose.com/slides/it/net/aspose.slides/digitalsignature/comments/) descrive lo scopo della firma; non è un controllo di sicurezza.

## **Convalidare le firme digitali**

Quando carichi un file PPTX firmato, ispeziona ogni elemento in [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/digitalsignatures/). La proprietà [IDigitalSignature.IsValid](https://reference.aspose.com/slides/it/net/aspose.slides/idigitalsignature/isvalid/) indica se la firma incorporata è valida per il contenuto della presentazione corrente.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Un risultato non valido indica normalmente che il contenuto firmato della presentazione o i dati della firma sono stati modificati dopo la firma, oppure che il file è danneggiato. Rimuovere tutte le firme produce una presentazione non firmata, quindi verificare solo la validità degli elementi non è sufficiente: un flusso di lavoro sensibile alla sicurezza deve anche verificare che siano presenti il numero previsto di firme e le identità dei firmatari attese.

Questo risultato di validità non dovrebbe essere trattato come una decisione completa di fiducia del certificato. A seconda della tua politica di sicurezza, l'applicazione potrebbe dover anche costruire e convalidare la catena di certificati X.509, controllare le date di validità e lo stato di revoca del certificato, confermare il soggetto o l'impronta attesi, verificare l'uso della chiave e valutare un timestamp affidabile. Il valore [IDigitalSignature.SignTime](https://reference.aspose.com/slides/it/net/aspose.slides/idigitalsignature/signtime/) da solo non è una prova da un'autorità di timestamp affidabile.

## **Rimuovere le firme digitali**

Rimuovere le firme cambia lo stato di sicurezza della presentazione. Il seguente esempio carica un file PPTX firmato, rimuove tutte le firme con [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/it/net/aspose.slides/idigitalsignaturecollection/clear/), e salva una copia non firmata.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Per rimuovere solo una firma, chiama [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides/idigitalsignaturecollection/removeat/) con il suo indice basato su zero. Salva in un nuovo file a meno che la sovrascrittura dell'originale firmato non sia una parte esplicita del tuo flusso di lavoro.

## **Considerazioni su modifica e formato**

- Una firma non rende una presentazione di sola lettura. Utenti e applicazioni possono ancora modificare il file, ma le modifiche al contenuto firmato di solito invalidano la firma esistente.
- Completa tutte le modifiche previste prima di firmare. Se una presentazione deve essere modificata, salva la presentazione rivista e firma nuovamente quella revisione.
- Mantieni l'output finale in formato PPTX. Convertire una presentazione firmata in un altro formato non trasferisce la firma originale PPTX come firma valida per il file convertito.
- Considera la chiave privata del certificato come sensibile. Chiunque ottenga la chiave privata e la sua password può creare firme che appaiono provenire dal titolare del certificato.
- Conserva la sorgente non firmata o un'altra copia controllata quando la tua politica di conservazione dei documenti lo richiede.

## **FAQ**

**Una firma digitale cripta la presentazione?**

No. Una firma digitale fornisce prove sull'origine e sull'integrità, ma il contenuto della presentazione rimane leggibile a meno che non venga applicata una crittografia separata. Usa [protezione tramite password](/net/password-protected-presentation/) quando l'accesso al contenuto deve essere limitato.

**La password PFX è la stessa della password della presentazione?**

No. La password PFX sblocca la chiave privata memorizzata nel pacchetto del certificato. Non controlla chi può aprire o modificare il file PPTX.

**Posso usare un certificato autofirmato?**

Tecnicamente, un certificato autofirmato può essere utilizzato quando include una chiave privata accessibile. Tuttavia, i destinatari non lo considereranno automaticamente attendibile, a meno che il certificato non sia stato aggiunto esplicitamente al loro ambiente di fiducia. I flussi di lavoro pubblici o inter-organizzativi generalmente utilizzano un certificato emesso da una CA fidata.

**Cosa rende una firma non valida?**

Modificare il contenuto firmato della presentazione o i dati della firma dopo la firma può invalidare la firma. La corruzione del file può anche provocare il fallimento della convalida. Se tutte le firme sono rimosse, la presentazione è non firmata anziché contenere una firma non valida.

**Una firma valida significa che devo fidarmi del firmatario?**

Non di per sé. L'integrità della firma e la fiducia nel firmatario sono decisioni separate. Una politica di convalida in produzione dovrebbe anche verificare la catena di certificati, il periodo di validità, lo stato di revoca, l'identità prevista, l'uso della chiave e eventuali requisiti di timestamp affidabile.

**Cosa succede quando il certificato scade?**

La scadenza del certificato non altera i byte della presentazione, ma influisce sulla valutazione della fiducia del certificato. Se una firma rimane accettabile dipende dalla tua politica e dal fatto che un timestamp affidabile valido dimostri che la firma è avvenuta mentre il certificato era valido. Non fare affidamento solo sul tempo di firma visualizzato come timestamp affidabile.

**Una presentazione firmata può ancora essere modificata?**

Sì. La firma non blocca il file. Modificare il contenuto firmato di solito rende la firma esistente non valida, quindi completa prima la presentazione e firma la revisione finale.

**Una presentazione può contenere più di una firma?**

Sì. Aggiungi ogni firma a [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/digitalsignatures/) prima di salvare. Durante la convalida, ispeziona ogni firma e conferma che tutti i firmatari richiesti siano presenti.

**Quali formati di presentazione supportano queste operazioni?**

Aspose.Slides supporta le operazioni di firma digitale descritte qui solo per PPTX. I formati di presentazione PPT e OpenDocument non sono supportati da questo flusso di lavoro API.

**Posso rimuovere una firma senza influire sulle diapositive?**

Sì. Puoi rimuovere una firma o svuotare l'intera collezione e poi salvare la presentazione. Il contenuto delle diapositive rimane disponibile, ma il file salvato non contiene più la prova della firma rimossa.