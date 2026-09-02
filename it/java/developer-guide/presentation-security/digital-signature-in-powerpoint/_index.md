---
title: Aggiungi firme digitali alle presentazioni in Java
linktitle: Firma digitale
type: docs
weight: 10
url: /it/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Scopri come firmare presentazioni PPTX esistenti con certificati PFX e utilizzare Aspose.Slides per Java per convalidare o rimuovere firme digitali."
---
## **Panoramica**

Una firma digitale aiuta il destinatario a determinare chi ha firmato una presentazione e se il contenuto firmato è stato modificato. Tre concetti di sicurezza correlati sono importanti qui:

- Un **certificato digitale** è una credenziale elettronica che associa un'identità a una chiave pubblica. Un'autorità di certificazione (CA) affidabile può rilasciare un certificato, oppure un'organizzazione può utilizzare un certificato autofirmato per flussi di lavoro interni.
- Una **firma digitale** viene creata dal contenuto della presentazione e dalla chiave privata del titolare del certificato. La chiave pubblica del certificato può quindi essere usata per verificare la firma. Una firma fornisce prova di origine e integrità; non cripta la presentazione.
- **Protezione con password** controlla se un utente può aprire o modificare una presentazione. È separata dalla firma digitale ed è descritta in [Presentazioni protette da password](/java/password-protected-presentation/).

PowerPoint fornisce il comando **Aggiungi una firma digitale** sotto **File > Info > Proteggi presentazione**.

![Menu Proteggi presentazione di PowerPoint con Aggiungi una firma digitale evidenziato](add-digital-signature-in-powerpoint.png)

Dopo l'apertura di una presentazione firmata, PowerPoint può mostrare una notifica sullo stato della firma.

![Notifica di PowerPoint indicando che la presentazione contiene firme valide](digital-signature-status-in-powerpoint.png)

Aspose.Slides espone le firme tramite [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), che restituisce una [IDigitalSignatureCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/idigitalsignaturecollection/) i cui elementi implementano [IDigitalSignature](https://reference.aspose.com/slides/it/java/com.aspose.slides/idigitalsignature/). Una presentazione può contenere più firme.

## **Comprendere i certificati PFX e le password**

Un file PFX, noto anche come file PKCS#12 e solitamente con estensione `.pfx` o `.p12`, può contenere un certificato X.509, la sua chiave privata e la catena di certificati. La chiave privata è ciò che consente al titolare di creare una firma. Un certificato senza una chiave privata accessibile non può essere usato per firmare una presentazione.

La password PFX protegge il pacchetto del certificato e la chiave privata. **Non** è una password per aprire o modificare la presentazione. Non inserire i file PFX o le loro password nel controllo di versione. In produzione, limitare l'accesso al file del certificato e ottenere la sua password da un archivio segreto o da un'altra fonte di configurazione protetta. Gli esempi seguenti usano una variabile d'ambiente solo per evitare di incorporare la password nel codice.

## **Aggiungere una firma digitale a una presentazione**

Per firmare un flusso di lavoro di una presentazione reale, carica un file PPTX esistente, crea un [DigitalSignature](https://reference.aspose.com/slides/it/java/com.aspose.slides/digitalsignature/) da un certificato PFX e dalla sua password, aggiungi la firma alla collezione della presentazione e salva in un file PPTX.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Salvare il risultato con un nuovo nome preserva il file sorgente non firmato. Il valore impostato da [IDigitalSignature.setComments](https://reference.aspose.com/slides/it/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) descrive lo scopo della firma; non è un controllo di sicurezza.

## **Convalidare le firme digitali**

Quando carichi un file PPTX firmato, ispeziona ogni elemento restituito da [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). Il metodo [IDigitalSignature.isValid](https://reference.aspose.com/slides/it/java/com.aspose.slides/idigitalsignature/#isValid--) indica se la firma incorporata è valida per il contenuto attuale della presentazione.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Un risultato non valido indica comunemente che il contenuto della presentazione firmata o i dati della firma sono cambiati dopo la firma, oppure che il file è danneggiato. Rimuovere ogni firma produce una presentazione non firmata, quindi verificare solo la validità degli elementi non è sufficiente: un flusso di lavoro sensibile alla sicurezza deve anche verificare che siano presenti il numero previsto di firme e le identità dei firmatari attesi.

Questo risultato di validità non dovrebbe essere considerato una decisione completa di fiducia nel certificato. A seconda della tua politica di sicurezza, l'applicazione potrebbe anche dover costruire e convalidare la catena di certificati X.509, verificare le date di validità del certificato e lo stato di revoca, confermare il soggetto o l'impronta attesi, verificare l'uso della chiave e valutare un timestamp affidabile. Il valore [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/it/java/com.aspose.slides/idigitalsignature/#getSignTime--) da solo non è una prova da un'autorità di timestamp affidabile.

## **Rimuovere le firme digitali**

Rimuovere le firme modifica lo stato di sicurezza della presentazione. L'esempio seguente carica un file PPTX firmato, rimuove tutte le firme con [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/idigitalsignaturecollection/#clear--) e salva una copia non firmata.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per rimuovere solo una firma, chiama [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/it/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) con il suo indice a base zero. Salva in un nuovo file a meno che la sovrascrittura dell'originale firmato non sia una parte esplicita del tuo flusso di lavoro.

## **Considerazioni su modifica e formato**

- Una firma non rende una presentazione di sola lettura. Gli utenti e le applicazioni possono comunque modificare il file, ma le modifiche al contenuto firmato di solito invalidano la firma esistente.
- Completa tutte le modifiche previste prima di firmare. Se una presentazione deve essere modificata, salva la versione rivista e firma nuovamente tale revisione.
- Mantieni il risultato finale in formato PPTX. Convertire una presentazione firmata in un altro formato non trasferisce la firma PPTX originale come firma valida per il file convertito.
- Considera la chiave privata del certificato come sensibile. Chiunque ottenga la chiave privata e la sua password potrebbe creare firme che sembrano provenire dal titolare del certificato.
- Conserva il sorgente non firmato o un'altra copia controllata quando la tua politica di conservazione dei documenti lo richiede.

## **FAQ**

**Una firma digitale cripta la presentazione?**

No. Una firma digitale fornisce prove sull'origine e sull'integrità, ma il contenuto della presentazione rimane leggibile a meno che non venga applicata una crittografia separata. Usa [protezione con password](/java/password-protected-presentation/) quando l'accesso al contenuto deve essere limitato.

**La password PFX è la stessa della password della presentazione?**

No. La password PFX sblocca la chiave privata contenuta nel pacchetto del certificato. Non controlla chi può aprire o modificare il file PPTX.

**Posso usare un certificato autofirmato?**

Tecnicamente, un certificato autofirmato può essere usato se include una chiave privata accessibile. Tuttavia, i destinatari non lo fidano automaticamente, a meno che il certificato non sia stato aggiunto esplicitamente al loro ambiente fidato. I flussi di lavoro pubblici o inter-organizzativi generalmente utilizzano un certificato rilasciato da una CA affidabile.

**Cosa rende una firma non valida?**

Modificare il contenuto della presentazione firmata o i dati della firma dopo la firma può invalidare la firma. Anche la corruzione del file può causare il fallimento della convalida. Se tutte le firme vengono rimosse, la presentazione è non firmata anziché un file contenente una firma non valida.

**Una firma valida significa che dovrei fidarmi del firmatario?**

Non da sola. L'integrità della firma e la fiducia nel firmatario sono decisioni separate. Una politica di convalida in produzione dovrebbe inoltre verificare la catena di certificati, il periodo di validità, lo stato di revoca, l'identità prevista, l'uso della chiave e eventuali requisiti di timestamp affidabile.

**Cosa succede quando il certificato scade?**

La scadenza del certificato non altera i byte della presentazione, ma influisce sulla valutazione della fiducia nel certificato. Se una firma rimane accettabile dipende dalla tua politica e dal fatto che un timestamp affidabile valido dimostri che la firma è avvenuta mentre il certificato era valido. Non fare affidamento solo sull'ora di firma visualizzata come timestamp affidabile.

**Una presentazione firmata può ancora essere modificata?**

Sì. La firma non blocca il file. Modificare il contenuto firmato generalmente rende la firma esistente non valida, quindi completa prima la presentazione e firma la revisione finale.

**Una presentazione può contenere più di una firma?**

Sì. Aggiungi ogni firma alla collezione restituita da [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) prima di salvare. Durante la convalida, ispeziona ogni firma e conferma che tutti i firmatari richiesti siano presenti.

**Quali formati di presentazione supportano queste operazioni?**

Aspose.Slides supporta le operazioni di firma digitale descritte qui solo per PPTX. I formati di presentazione PPT e OpenDocument non sono supportati da questo flusso di lavoro API.

**Posso rimuovere una firma senza influire sulle diapositive?**

Sì. Puoi rimuovere una firma o svuotare l'intera collezione e poi salvare la presentazione. Il contenuto delle diapositive rimane disponibile, ma il file salvato non contiene più la prova della firma rimossa.