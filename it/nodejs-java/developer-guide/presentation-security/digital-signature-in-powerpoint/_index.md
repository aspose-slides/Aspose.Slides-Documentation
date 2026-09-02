---
title: Aggiungere firme digitali alle presentazioni in JavaScript
linktitle: Firma digitale
type: docs
weight: 10
url: /it/nodejs-java/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PKCS#12
- convalidare firma
- PowerPoint
- PPTX
- sicurezza della presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come firmare presentazioni PPTX esistenti con certificati PFX e utilizzare Aspose.Slides per Node.js tramite Java per convalidare o rimuovere firme digitali."
---
## **Panoramica**

Una firma digitale aiuta il destinatario a determinare chi ha firmato una presentazione e se il contenuto firmato è stato modificato. Tre concetti di sicurezza correlati sono importanti qui:

- Un **certificato digitale** è una credenziale elettronica che associa un’identità a una chiave pubblica. Un’autorità di certificazione (CA) attendibile può rilasciare un certificato, oppure un’organizzazione può utilizzare un certificato autofirmato per flussi di lavoro interni.
- Una **firma digitale** viene creata dal contenuto della presentazione e dalla chiave privata del titolare del certificato. La chiave pubblica del certificato può quindi essere usata per verificare la firma. Una firma fornisce prova di origine e integrità; non crittografa la presentazione.
- **Protezione con password** controlla se un utente può aprire o modificare una presentazione. È separata dalla firma digitale ed è descritta in [Password-Protected Presentations](/nodejs-java/password-protected-presentation/).

PowerPoint fornisce il comando **Add a Digital Signature** sotto **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

Dopo l’apertura di una presentazione firmata, PowerPoint può visualizzare una notifica sullo stato della firma.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides espone le firme tramite [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), che restituisce una [DigitalSignatureCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignaturecollection/) contenente oggetti [DigitalSignature](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignature/). Una presentazione può contenere più firme.

## **Comprendere i certificati PFX e le password**

Un file PFX, noto anche come file PKCS#12 e comunemente con estensione `.pfx` o `.p12`, può contenere un certificato X.509, la sua chiave privata e la catena dei certificati. La chiave privata è ciò che consente al titolare di creare una firma. Un certificato senza una chiave privata accessibile non può essere usato per firmare una presentazione.

La password del PFX protegge il pacchetto del certificato e la chiave privata. **Non** è una password per aprire o modificare la presentazione. Non eseguire il commit di file PFX o delle loro password nel controllo sorgente. In produzione, limita l’accesso al file del certificato e ottieni la sua password da un archivio segreto o da un’altra fonte di configurazione protetta. Gli esempi sotto usano una variabile d’ambiente solo per evitare di inserire la password nel codice.

## **Aggiungere una firma digitale a una presentazione**

Per firmare una presentazione reale, carica un file PPTX esistente, crea una [DigitalSignature](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignature/) da un certificato PFX e dalla sua password, aggiungi la firma alla collezione della presentazione e salva in un file PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Salvare il risultato con un nuovo nome preserva il file sorgente non firmato. Il valore impostato da [DigitalSignature.setComments](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignature/) descrive lo scopo della firma; non è un controllo di sicurezza.

## **Convalidare le firme digitali**

Quando carichi un file PPTX firmato, ispeziona ogni elemento restituito da [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). Il metodo [DigitalSignature.isValid](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignature/) indica se la firma incorporata è valida per il contenuto attuale della presentazione.

L’esempio seguente utilizza anche la classe Node.js `X509Certificate` per leggere il nome del soggetto da ciascun certificato incorporato.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Un risultato non valido significa normalmente che il contenuto firmato della presentazione o i dati della firma sono cambiati dopo la firma, oppure che il file è danneggiato. Rimuovere tutte le firme produce una presentazione non firmata, quindi verificare solo la validità degli elementi non è sufficiente: un flusso di lavoro sensibile alla sicurezza deve anche verificare che siano presenti il numero previsto di firme e le identità dei firmatari attese.

Questo risultato di validità non deve essere trattato come una decisione completa di fiducia nel certificato. A seconda della tua politica di sicurezza, la tua applicazione potrebbe dover anche costruire e convalidare la catena di certificati X.509, controllare le date di validità del certificato e lo stato di revoca, confermare il soggetto o l’impronta attesi, verificare l’uso della chiave e valutare un timestamp attendibile. Il valore restituito da [DigitalSignature.getSignTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignature/) da solo non è prova da un’autorità di timestamp attendibile.

## **Rimuovere le firme digitali**

Rimuovere le firme modifica lo stato di sicurezza della presentazione. L’esempio seguente carica un file PPTX firmato, rimuove tutte le firme con [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), e salva una copia non firmata.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per rimuovere una sola firma, chiama [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) passando il suo indice basato su zero. Salva in un nuovo file a meno che la sovrascrittura dell’originale firmato non faccia parte esplicita del tuo flusso di lavoro.

## **Considerazioni su modifica e formato**

- Una firma non rende la presentazione di sola lettura. Utenti e applicazioni possono ancora modificare il file, ma le modifiche al contenuto firmato normalmente invalidano la firma esistente.
- Completa tutte le modifiche previste prima di firmare. Se una presentazione deve essere modificata, salva la versione rivista e firma nuovamente quella revisione.
- Mantieni l’output finale in formato PPTX. Convertire una presentazione firmata in un altro formato non trasferisce la firma originale PPTX come firma valida per il file convertito.
- Tratta la chiave privata del certificato come sensibile. Chiunque ottenga la chiave privata e la sua password può creare firme che sembrano provenire dal titolare del certificato.
- Conserva il sorgente non firmato o un’altra copia controllata quando la tua politica di conservazione dei documenti lo richiede.

## **FAQ**

**Una firma digitale cripta la presentazione?**

No. Una firma digitale fornisce prova di origine e integrità, ma il contenuto della presentazione rimane leggibile a meno che non venga applicata una crittografia separata. Usa [password protection](/nodejs-java/password-protected-presentation/) quando è necessario limitare l’accesso al contenuto.

**La password PFX è la stessa della password della presentazione?**

No. La password PFX sblocca la chiave privata contenuta nel pacchetto del certificato. Non controlla chi può aprire o modificare il file PPTX.

**Posso usare un certificato autofirmato?**

Tecnicamente sì, se include una chiave privata accessibile. I destinatari non lo considereranno automaticamente attendibile, a meno che il certificato non sia stato aggiunto esplicitamente al loro ambiente attendibile. I flussi di lavoro pubblici o inter‑organizzativi usano generalmente un certificato emesso da una CA attendibile.

**Cosa rende una firma non valida?**

Modificare il contenuto firmato della presentazione o i dati della firma dopo la firma può invalidare la firma. Anche la corruzione del file può causare un fallimento della convalida. Se tutte le firme vengono rimosse, la presentazione è semplicemente non firmata, non contiene una firma non valida.

**Una firma valida implica che devo fidarmi del firmatario?**

No, da sola. L’integrità della firma e la fiducia nel firmatario sono decisioni separate. Una politica di convalida in produzione dovrebbe anche verificare la catena del certificato, il periodo di validità, lo stato di revoca, l’identità attesa, l’uso della chiave e eventuali requisiti di timestamp attendibile.

**Cosa succede quando il certificato scade?**

La scadenza del certificato non altera i byte della presentazione, ma influisce sulla valutazione della fiducia nel certificato. Se una firma rimane accettabile dipende dalla tua politica e dal fatto che un timestamp attendibile dimostri che la firma è avvenuta mentre il certificato era valido. Non fare affidamento solo sul tempo di firma visualizzato come timestamp attendibile.

**Una presentazione firmata può ancora essere modificata?**

Sì. La firma non blocca il file. Modificare il contenuto firmato generalmente rende la firma esistente non valida, quindi completa prima la presentazione e firma la revisione finale.

**Una presentazione può contenere più di una firma?**

Sì. Aggiungi ciascuna firma alla collezione restituita da [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) prima di salvare. Durante la convalida, ispeziona ogni firma e conferma che tutti i firmatari richiesti siano presenti.

**Quali formati di presentazione supportano queste operazioni?**

Aspose.Slides supporta le operazioni di firma digitale descritte qui solo per PPTX. I formati PPT e OpenDocument non sono supportati da questo flusso di lavoro API.

**Posso rimuovere una firma senza influire sulle diapositive?**

Sì. Puoi rimuovere una firma o cancellare l’intera collezione e poi salvare la presentazione. Il contenuto delle diapositive rimane disponibile, ma il file salvato non contiene più la prova della firma rimossa.