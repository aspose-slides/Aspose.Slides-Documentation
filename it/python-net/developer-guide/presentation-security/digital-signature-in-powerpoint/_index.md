---
title: Aggiungere firme digitali alle presentazioni in Python
linktitle: Firma digitale
type: docs
weight: 10
url: /it/python-net/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PKCS#12
- convalida firma
- PowerPoint
- PPTX
- sicurezza della presentazione
- Python
- Aspose.Slides
description: "Scopri come firmare presentazioni PPTX esistenti con certificati PFX e utilizzare Aspose.Slides per Python tramite .NET per convalidare o rimuovere firme digitali."
---
## **Panoramica**

Una firma digitale aiuta il destinatario a determinare chi ha firmato una presentazione e se il contenuto firmato è cambiato. Tre concetti di sicurezza correlati sono importanti qui:

- Un **certificato digitale** è una credenziale elettronica che associa un'identità a una chiave pubblica. Un'autorità di certificazione (CA) fidata può rilasciare un certificato, oppure un'organizzazione può utilizzare un certificato autofirmato per flussi di lavoro interni.
- Una **firma digitale** è creata dal contenuto della presentazione e dalla chiave privata del titolare del certificato. La chiave pubblica del certificato può quindi essere usata per verificare la firma. Una firma fornisce evidenza di origine e integrità; non crittografa la presentazione.
- **Protezione con password** controlla se un utente può aprire o modificare una presentazione. È separata dalla firma digitale ed è descritta in [Presentazioni protette da password](/slides/it/python-net/password-protected-presentation/).

PowerPoint fornisce il comando **Aggiungi una firma digitale** sotto **File > Info > Proteggi presentazione**.

![Menu Proteggi presentazione di PowerPoint con Aggiungi una firma digitale evidenziato](add-digital-signature-in-powerpoint.png)

Dopo che una presentazione firmata viene aperta, PowerPoint può visualizzare una notifica sullo stato della firma.

![Notifica di PowerPoint che indica che la presentazione contiene firme valide](digital-signature-status-in-powerpoint.png)

Aspose.Slides espone le firme tramite [Presentation.digital_signatures](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/digital_signatures/), una [DigitalSignatureCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignaturecollection/) i cui elementi sono oggetti [DigitalSignature](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignature/). Una presentazione può contenere più firme.

## **Comprendere i certificati PFX e le password**

Un file PFX, noto anche come file PKCS#12 e comunemente con estensione `.pfx` o `.p12`, può contenere un certificato X.509, la sua chiave privata e la catena di certificati. La chiave privata è ciò che consente al titolare di creare una firma. Un certificato senza una chiave privata accessibile non può essere usato per firmare una presentazione.

La password PFX protegge il pacchetto del certificato e la chiave privata. **Non** è una password per aprire o modificare la presentazione. Non commettere file PFX o le loro password nel controllo del codice sorgente. In produzione, limita l'accesso al file del certificato e ottieni la sua password da un archivio segreto o da un'altra fonte di configurazione protetta. Gli esempi seguenti usano una variabile d'ambiente solo per evitare di incorporare la password nel codice.

## **Aggiungere una firma digitale a una presentazione**

Per firmare un flusso di lavoro reale di una presentazione, carica un file PPTX esistente, crea un [DigitalSignature](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignature/) da un certificato PFX e dalla sua password, aggiungi la firma alla collezione della presentazione e salva in un file PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Salvare il risultato con un nuovo nome preserva il file di origine non firmato. Il valore [DigitalSignature.comments](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignature/comments/) descrive lo scopo della firma; non è un controllo di sicurezza.

## **Convalidare le firme digitali**

Quando carichi un file PPTX firmato, ispeziona ogni elemento in [Presentation.digital_signatures](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/digital_signatures/). La proprietà [DigitalSignature.is_valid](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignature/is_valid/) indica se la firma incorporata è valida per il contenuto attuale della presentazione.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Un risultato non valido indica comunemente che il contenuto della presentazione firmata o i dati della firma sono cambiati dopo la firma, o che il file è danneggiato. Rimuovere tutte le firme produce una presentazione non firmata, quindi verificare solo la validità degli elementi non è sufficiente: un flusso di lavoro sensibile alla sicurezza deve anche verificare che siano presenti il numero previsto di firme e le identità dei firmatari attesi.

La proprietà [DigitalSignature.certificate](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignature/certificate/) fornisce i dati del certificato come array di byte. L'esempio calcola il suo fingerprint SHA-256 in modo che un'applicazione possa confrontarlo con il fingerprint di un certificato firmatario previsto.

Questo risultato di validità non dovrebbe essere considerato una decisione completa di fiducia nel certificato. A seconda della tua politica di sicurezza, l'applicazione potrebbe anche dover costruire e convalidare la catena di certificati X.509, verificare le date di validità del certificato e lo stato di revoca, confermare il soggetto o l'impronta attesi, verificare l'uso della chiave e valutare un timestamp attendibile. Il valore [DigitalSignature.sign_time](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignature/sign_time/) da solo non è una prova da un'autorità di timestamp attendibile.

## **Rimuovere le firme digitali**

Rimuovere le firme cambia lo stato di sicurezza della presentazione. Il seguente esempio carica un file PPTX firmato, rimuove tutte le firme con [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignaturecollection/clear/), e salva una copia non firmata.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Per rimuovere solo una firma, chiama [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/it/python-net/aspose.slides/digitalsignaturecollection/remove_at/) con il suo indice a partire da zero. Salva in un nuovo file a meno che la sovrascrittura dell'originale firmato non sia una parte esplicita del tuo flusso di lavoro.

## **Considerazioni su modifica e formato**

- Una firma non rende la presentazione di sola lettura. Utenti e applicazioni possono comunque modificare il file, ma le modifiche al contenuto firmato normalmente invalidano la firma esistente.
- Completa tutte le modifiche previste prima di firmare. Se una presentazione deve essere modificata, salva la versione rivista e firma nuovamente quella revisione.
- Mantieni l'output finale in formato PPTX. Convertire una presentazione firmata in un altro formato non trasferisce la firma PPTX originale come firma valida per il file convertito.
- Considera la chiave privata del certificato come sensibile. Chiunque ottenga la chiave privata e la sua password potrebbe creare firme che sembrano provenire dal titolare del certificato.
- Conserva la sorgente non firmata o un'altra copia controllata quando la tua politica di conservazione dei documenti lo richiede.

## **FAQ**

**Una firma digitale crittografa la presentazione?**

No. Una firma digitale fornisce evidenza sull'origine e sull'integrità, ma il contenuto della presentazione rimane leggibile a meno che non venga applicata una crittografia separata. Usa [protezione con password](/slides/it/python-net/password-protected-presentation/) quando l'accesso al contenuto deve essere limitato.

**La password PFX è la stessa della password della presentazione?**

No. La password PFX sblocca la chiave privata memorizzata nel pacchetto del certificato. Non controlla chi può aprire o modificare il file PPTX.

**Posso usare un certificato autofirmato?**

Tecnicamente, un certificato autofirmato può essere usato quando include una chiave privata accessibile. Tuttavia i destinatari non lo fidano automaticamente, a meno che il certificato non sia stato esplicitamente aggiunto al loro ambiente di fiducia. I flussi di lavoro pubblici o tra organizzazioni solitamente usano un certificato rilasciato da una CA fidata.

**Cosa rende una firma non valida?**

La modifica del contenuto firmato della presentazione o dei dati della firma dopo la firma può invalidare la firma. La corruzione del file può anche far fallire la convalida. Se tutte le firme sono rimosse, la presentazione è non firmata anziché un file contenente una firma non valida.

**Una firma valida significa che devo fidarmi del firmatario?**

Non di per sé. L'integrità della firma e la fiducia nel firmatario sono decisioni separate. Una politica di convalida in produzione dovrebbe anche verificare la catena del certificato, il periodo di validità, lo stato di revoca, l'identità prevista, l'uso della chiave e qualsiasi requisito di timestamp attendibile.

**Cosa succede quando il certificato scade?**

La scadenza del certificato non altera i byte della presentazione, ma influisce sulla valutazione della fiducia nel certificato. Se una firma rimane accettabile dipende dalla tua politica e dal fatto che un timestamp attendibile valido dimostri che la firma è avvenuta mentre il certificato era valido. Non fare affidamento solo sul tempo di firma visualizzato come timestamp attendibile.

**Una presentazione firmata può ancora essere modificata?**

Sì. La firma non blocca il file. Modificare il contenuto firmato generalmente rende la firma esistente non valida, quindi completa prima la presentazione e firma la revisione finale.

**Una presentazione può contenere più di una firma?**

Sì. Aggiungi ogni firma a [Presentation.digital_signatures](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/digital_signatures/) prima di salvare. Durante la convalida, ispeziona ogni firma e conferma che tutti i firmatari richiesti siano presenti.

**Quali formati di presentazione supportano queste operazioni?**

Aspose.Slides supporta le operazioni di firma digitale descritte qui solo per PPTX. I formati PPT e OpenDocument Presentation non sono supportati da questo flusso di lavoro API.

**Posso rimuovere una firma senza influire sulle diapositive?**

Sì. Puoi rimuovere una firma o pulire l'intera collezione e poi salvare la presentazione. Il contenuto delle diapositive rimane disponibile, ma il file salvato non contiene più la prova della firma rimossa.