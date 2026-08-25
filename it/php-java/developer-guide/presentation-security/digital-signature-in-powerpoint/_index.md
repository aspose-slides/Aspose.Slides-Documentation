---
title: Aggiungere firme digitali alle presentazioni in PHP
linktitle: Firma digitale
type: docs
weight: 10
url: /it/php-java/digital-signature-in-powerpoint/
keywords:
- firma digitale
- certificato digitale
- autorità di certificazione
- certificato PFX
- PKCS#12
- convalidare firma
- PowerPoint
- PPTX
- sicurezza delle presentazioni
- PHP
- Aspose.Slides
description: "Impara come firmare presentazioni PPTX esistenti con certificati PFX e usare Aspose.Slides per PHP tramite Java per convalidare o rimuovere firme digitali."
---
## **Panoramica**

Una firma digitale aiuta il destinatario a determinare chi ha firmato una presentazione e se il contenuto firmato è stato modificato. Tre concetti di sicurezza correlati sono importanti qui:

- Un **certificato digitale** è una credenziale elettronica che associa un'identità a una chiave pubblica. Un'autorità di certificazione (CA) affidabile può emettere un certificato, oppure un'organizzazione può utilizzare un certificato autofirmato per flussi di lavoro interni.
- Una **firma digitale** viene creata dal contenuto della presentazione e dalla chiave privata del titolare del certificato. La chiave pubblica del certificato può quindi essere usata per verificare la firma. Una firma fornisce evidenza di origine e integrità; non cripta la presentazione.
- **Password protection** controlla se un utente può aprire o modificare una presentazione. È separata dalla firma digitale ed è descritta in [Presentazioni protette da password](/slides/it/php-java/password-protected-presentation/).

PowerPoint fornisce il comando **Add a Digital Signature** sotto **File > Info > Protect Presentation**.

![Menu Proteggi Presentazione di PowerPoint con Aggiungi firma digitale evidenziata](add-digital-signature-in-powerpoint.png)

Dopo l'apertura di una presentazione firmata, PowerPoint può visualizzare una notifica sullo stato della firma.

![Notifica di PowerPoint che indica che la presentazione contiene firme valide](digital-signature-status-in-powerpoint.png)

Aspose.Slides espone le firme tramite [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDigitalSignatures), che restituisce una [DigitalSignatureCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignaturecollection/), i cui elementi sono rappresentati da oggetti [DigitalSignature](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/). Una presentazione può contenere più firme.

## **Comprendere i certificati PFX e le password**

Un file PFX, noto anche come file PKCS#12 e comunemente con estensione `.pfx` o `.p12`, può contenere un certificato X.509, la sua chiave privata e la catena del certificato. La chiave privata è ciò che consente al titolare di creare una firma. Un certificato senza una chiave privata accessibile non può essere usato per firmare una presentazione.

La password PFX protegge il pacchetto del certificato e la chiave privata. **Non** è una password per aprire o modificare la presentazione. Non inserire i file PFX o le loro password nel controllo di versione. In produzione, limita l'accesso al file del certificato e ottieni la sua password da un secret store o da un'altra fonte di configurazione protetta. Gli esempi seguenti usano una variabile d'ambiente solo per evitare di incorporare la password nel codice.

## **Aggiungere una firma digitale a una presentazione**

Per firmare una presentazione reale, carica un file PPTX esistente, crea un [DigitalSignature](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/) da un certificato PFX e dalla sua password, aggiungi la firma alla collezione della presentazione e salva in un file PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Salvare il risultato con un nome nuovo preserva il file sorgente non firmato. Il valore impostato mediante [DigitalSignature::setComments](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/setcomments/) descrive lo scopo della firma; non è un controllo di sicurezza.

## **Convalidare le firme digitali**

Quando carichi un file PPTX firmato, esamina ogni elemento restituito da [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDigitalSignatures). Il metodo [DigitalSignature::isValid](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/isvalid/) indica se la firma incorporata è valida per il contenuto attuale della presentazione.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Un risultato non valido indica comunemente che il contenuto firmato della presentazione o i dati della firma sono cambiati dopo la firma, oppure che il file è danneggiato. Rimuovere tutte le firme produce una presentazione non firmata, quindi verificare solo la validità degli elementi non è sufficiente: un flusso di lavoro sensibile alla sicurezza deve anche verificare che il numero previsto di firme e le identità dei firmatari attesi siano presenti.

Questo risultato di validità non dovrebbe essere considerato come una decisione completa di fiducia del certificato. A seconda della tua politica di sicurezza, l'applicazione potrebbe dover costruire e convalidare la catena del certificato X.509, controllare le date di validità e lo stato di revoca del certificato, confermare il soggetto o l'impronta digitale attesa, verificare l'uso della chiave e valutare un timestamp affidabile. Il valore restituito da [DigitalSignature::getSignTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/getsigntime/) da solo non è una prova da un'autorità di timestamp affidabile.

## **Rimuovere le firme digitali**

Rimuovere le firme modifica lo stato di sicurezza della presentazione. L'esempio seguente carica un file PPTX firmato, rimuove tutte le firme con [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignaturecollection/clear/), e salva una copia non firmata.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per rimuovere una sola firma, chiama [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignaturecollection/removeat/) con il suo indice basato su zero. Salva in un nuovo file a meno che la sovrascrittura dell'originale firmato non sia una parte esplicita del tuo flusso di lavoro.

## **Considerazioni su modifica e formato**

- Una firma non rende una presentazione di sola lettura. Utenti e applicazioni possono ancora modificare il file, ma le modifiche al contenuto firmato normalmente invalidano la firma esistente.
- Completa tutte le modifiche previste prima di firmare. Se la presentazione deve essere cambiata, salva la versione revisionata e firma nuovamente quella revisione.
- Mantieni il risultato finale in formato PPTX. Convertire una presentazione firmata in un altro formato non trasferisce la firma PPTX originale come firma valida per il file convertito.
- Tratta la chiave privata del certificato come informazioni sensibili. Chiunque ottenga la chiave privata e la sua password potrebbe creare firme che sembrano provenire dal titolare del certificato.
- Conserva il sorgente non firmato o un'altra copia controllata quando la tua politica di conservazione dei documenti lo richiede.

## **FAQ**

**Una firma digitale cripta la presentazione?**

No. Una firma digitale fornisce evidenza sull'origine e sull'integrità, ma il contenuto della presentazione rimane leggibile a meno che non venga applicata una crittografia separata. Usa [protezione con password](/slides/it/php-java/password-protected-presentation/) quando l'accesso al contenuto deve essere limitato.

**La password PFX è la stessa della password della presentazione?**

No. La password PFX sblocca la chiave privata contenuta nel pacchetto del certificato. Non controlla chi può aprire o modificare il file PPTX.

**Posso utilizzare un certificato autofirmato?**

Tecnicamente sì, un certificato autofirmato può essere usato se contiene una chiave privata accessibile. I destinatari non lo considereranno automaticamente attendibile, a meno che non sia stato aggiunto esplicitamente al loro ambiente fidato. I flussi di lavoro pubblici o inter‑organizzativi generalmente usano un certificato emesso da una CA affidabile.

**Cosa rende una firma non valida?**

Modificare il contenuto firmato della presentazione o i dati della firma dopo la firma può invalidare la firma. Anche la corruzione del file può causare il fallimento della convalida. Se tutte le firme vengono rimosse, la presentazione è semplicemente non firmata, non contiene una firma non valida.

**Una firma valida implica che devo fidarmi del firmatario?**

Non automaticamente. L'integrità della firma e la fiducia nel firmatario sono decisioni separate. Una politica di convalida in produzione dovrebbe anche verificare la catena del certificato, il periodo di validità, lo stato di revoca, l'identità attesa, l'uso della chiave e eventuali requisiti di timestamp affidabile.

**Cosa succede quando il certificato scade?**

La scadenza del certificato non modifica i byte della presentazione, ma influisce sulla valutazione della fiducia del certificato. Se una firma rimane accettabile dipende dalla tua politica e dal fatto che un timestamp affidabile dimostri che la firma è avvenuta mentre il certificato era valido. Non fare affidamento solo sul tempo di firma visualizzato come timestamp fiduciario.

**Una presentazione firmata può ancora essere modificata?**

Sì. La firma non blocca il file. Modificare il contenuto firmato rende generalmente la firma esistente non valida, quindi completa la presentazione prima e poi firma la revisione finale.

**Una presentazione può contenere più di una firma?**

Sì. Aggiungi ogni firma alla collezione restituita da [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDigitalSignatures) prima di salvare. Durante la convalida, esamina ogni firma e conferma che tutti i firmatari richiesti siano presenti.

**Quali formati di presentazione supportano queste operazioni?**

Aspose.Slides supporta le operazioni di firma digitale descritte qui solo per PPTX. I formati PPT e OpenDocument non sono supportati da questo workflow API.

**Posso rimuovere una firma senza influire sulle diapositive?**

Sì. Puoi rimuovere una firma o cancellare l'intera collezione e poi salvare la presentazione. Il contenuto delle diapositive rimane disponibile, ma il file salvato non contiene più la prova della firma rimossa.