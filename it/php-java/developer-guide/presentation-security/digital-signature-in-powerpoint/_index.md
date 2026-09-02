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
- sicurezza della presentazione
- PHP
- Aspose.Slides
description: "Scopri come firmare presentazioni PPTX esistenti con certificati PFX e utilizzare Aspose.Slides per PHP tramite Java per convalidare o rimuovere firme digitali."
---
## **Panoramica**

Una firma digitale aiuta il destinatario a determinare chi ha firmato una presentazione e se il contenuto firmato è stato modificato. Tre concetti di sicurezza correlati sono importanti in questo contesto:

- Un **certificato digitale** è una credenziale elettronica che associa un'identità a una chiave pubblica. Un'autorità di certificazione (CA) affidabile può emettere un certificato, oppure un'organizzazione può utilizzare un certificato autofirmato per flussi di lavoro interni.
- Una **firma digitale** è creata dal contenuto della presentazione e dalla chiave privata del titolare del certificato. La chiave pubblica del certificato può quindi essere usata per verificare la firma. Una firma fornisce una prova di origine e integrità; non cripta la presentazione.
- **Protezione con password** controlla se un utente può aprire o modificare una presentazione. È separata dalla firma digitale ed è descritta in [Presentazioni protette da password](/php-java/password-protected-presentation/).

PowerPoint offre il comando **Add a Digital Signature** sotto **File > Info > Protect Presentation**.

![Menu Protect Presentation di PowerPoint con Add a Digital Signature evidenziato](add-digital-signature-in-powerpoint.png)

Dopo l'apertura di una presentazione firmata, PowerPoint può visualizzare una notifica sullo stato della firma.

![Notifica di PowerPoint che indica che la presentazione contiene firme valide](digital-signature-status-in-powerpoint.png)

Aspose.Slides espone le firme tramite [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDigitalSignatures), che restituisce una [DigitalSignatureCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignaturecollection/) i cui elementi sono rappresentati da oggetti [DigitalSignature](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/). Una presentazione può contenere più firme.

## **Comprendere i certificati PFX e le password**

Un file PFX, noto anche come file PKCS#12 e solitamente dotato dell'estensione `.pfx` o `.p12`, può contenere un certificato X.509, la sua chiave privata e la catena di certificati. La chiave privata è ciò che consente al titolare di creare una firma. Un certificato senza una chiave privata accessibile non può essere usato per firmare una presentazione.

La password PFX protegge il pacchetto del certificato e la chiave privata. Non è **una** password per aprire o modificare la presentazione. Non eseguire il commit di file PFX o delle loro password nel controllo di versione. In produzione, limitare l'accesso al file del certificato e ottenere la sua password da un archivio segreto o da un'altra fonte di configurazione protetta. Gli esempi seguenti usano una variabile d'ambiente solo per evitare di incorporare la password nel codice.

## **Aggiungere una firma digitale a una presentazione**

Per firmare un flusso di lavoro reale di presentazione, carica un file PPTX esistente, crea un [DigitalSignature](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/) da un certificato PFX e dalla sua password, aggiungi la firma alla collezione della presentazione e salva in un file PPTX.

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

Salvare il risultato con un nuovo nome preserva il file sorgente non firmato. Il valore impostato da [DigitalSignature::setComments](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/setcomments/) descrive lo scopo della firma; non è un controllo di sicurezza.

## **Convalidare le firme digitali**

Quando carichi un file PPTX firmato, ispeziona ogni elemento restituito da [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDigitalSignatures). Il metodo [DigitalSignature::isValid](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/isvalid/) indica se la firma incorporata è valida per il contenuto attuale della presentazione.

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

Un risultato non valido indica comunemente che il contenuto della presentazione firmata o i dati della firma sono cambiati dopo la firma, oppure che il file è danneggiato. Rimuovere tutte le firme produce una presentazione non firmata, quindi verificare solo la validità degli elementi non è sufficiente: un flusso di lavoro sensibile alla sicurezza deve anche verificare che siano presenti il numero previsto di firme e le identità dei firmatari attese.

Questo risultato di validità non dovrebbe essere considerato una decisione completa di fiducia del certificato. A seconda della tua politica di sicurezza, l'applicazione potrebbe dover anche costruire e convalidare la catena di certificati X.509, verificare le date di validità del certificato e lo stato di revoca, confermare il soggetto o l'impronta attesi, verificare l'uso della chiave e valutare un timestamp affidabile. Il valore restituito da [DigitalSignature::getSignTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignature/getsigntime/) da solo non è una prova da un'autorità di timestamp affidabile.

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

Per rimuovere solo una firma, chiama [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/digitalsignaturecollection/removeat/) con il suo indice basato su zero. Salva in un nuovo file a meno che la sovrascrittura dell'originale firmato non sia una parte esplicita del tuo flusso di lavoro.

## **Considerazioni su modifica e formato**

- Una firma non rende una presentazione di sola lettura. Utenti e applicazioni possono comunque modificare il file, ma le modifiche al contenuto firmato normalmente invalidano la firma esistente.
- Completa tutte le modifiche previste prima di firmare. Se una presentazione deve essere modificata, salva la presentazione rivista e firma nuovamente quella revisione.
- Mantieni l'output finale in formato PPTX. Convertire una presentazione firmata in un altro formato non trasferisce la firma originale PPTX come firma valida per il file convertito.
- Considera la chiave privata del certificato come sensibile. Chiunque ottenga la chiave privata e la sua password può essere in grado di creare firme che sembrano provenire da quel titolare del certificato.
- Conserva il sorgente non firmato o un'altra copia controllata quando la tua politica di conservazione dei documenti lo richiede.

## **FAQ**

**La firma digitale cripta la presentazione?**

No. Una firma digitale fornisce una prova di origine e integrità, ma il contenuto della presentazione rimane leggibile a meno che non venga applicata una crittografia separata. Usa [protezione con password](/php-java/password-protected-presentation/) quando l'accesso al contenuto deve essere limitato.

**La password PFX è la stessa della password della presentazione?**

No. La password PFX sblocca la chiave privata contenuta nel pacchetto del certificato. Non controlla chi può aprire o modificare il file PPTX.

**Posso usare un certificato autofirmato?**

Tecnicamente, un certificato autofirmato può essere usato quando include una chiave privata accessibile. I destinatari non lo considereranno automaticamente attendibile, a meno che il certificato non sia stato aggiunto esplicitamente al loro ambiente fidato. I flussi di lavoro pubblici o inter-organizzativi generalmente usano un certificato rilasciato da una CA affidabile.

**Cosa rende una firma invalida?**

Modificare il contenuto della presentazione firmata o i dati della firma dopo la firma può invalidare la firma. Anche la corruzione del file può causare un fallimento della convalida. Se tutte le firme vengono rimosse, la presentazione è non firmata anziché contenere una firma non valida.

**Una firma valida significa che devo fidarmi del firmatario?**

Non da sola. L'integrità della firma e la fiducia nel firmatario sono decisioni separate. Una politica di convalida in produzione dovrebbe anche verificare la catena di certificati, il periodo di validità, lo stato di revoca, l'identità attesa, l'uso della chiave e eventuali requisiti di timestamp affidabile.

**Cosa succede quando il certificato scade?**

La scadenza del certificato non altera i byte della presentazione, ma influisce sulla valutazione della fiducia del certificato. Se una firma rimane accettabile dipende dalla tua politica e dal fatto che un timestamp affidabile dimostri che la firma è avvenuta mentre il certificato era ancora valido. Non fare affidamento solo sul tempo di firma visualizzato come timestamp affidabile.

**Una presentazione firmata può ancora essere modificata?**

Sì. Firmare non blocca il file. Modificare il contenuto firmato generalmente rende la firma esistente invalida, quindi completa la presentazione prima e firma la revisione finale.

**Una presentazione può contenere più di una firma?**

Sì. Aggiungi ogni firma alla collezione restituita da [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDigitalSignatures) prima di salvare. Durante la convalida, ispeziona ogni firma e conferma che tutti i firmatari richiesti siano presenti.

**Quali formati di presentazione supportano queste operazioni?**

Aspose.Slides supporta le operazioni di firma digitale descritte qui solo per PPTX. I formati PPT e OpenDocument non sono supportati da questo flusso di lavoro API.

**Posso rimuovere una firma senza influire sulle diapositive?**

Sì. Puoi rimuovere una firma o cancellare l'intera collezione e poi salvare la presentazione. Il contenuto delle diapositive rimane disponibile, ma il file salvato non contiene più la prova della firma rimossa.