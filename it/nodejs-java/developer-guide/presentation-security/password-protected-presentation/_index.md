---
title: Proteggi con password le presentazioni in JavaScript
linktitle: Protezione password
type: docs
weight: 20
url: /it/nodejs-java/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- crittografare PowerPoint
- decrittografare PowerPoint
- convalidare password presentazione
- verificare password presentazione
- aprire presentazione crittata
- rimuovere crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crittografa, rileva, valida, apri e decrittografa presentazioni PowerPoint PPT e PPTX protette da password in JavaScript con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa da una password di protezione della scrittura. La protezione della scrittura limita la modifica ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/nodejs-java/write-protected-presentation/).

I flussi di lavoro di seguito si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati quando il loro comportamento basato su file o su stream è importante.

## **Crittare una presentazione con una password di apertura**

Utilizzare [ProtectionManager.encrypt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#encrypt) per assegnare una password di apertura. Quindi utilizzare [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) per salvare la presentazione crittata.

Il seguente esempio crittografa una presentazione PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mantenere le proprietà del documento pubbliche**

Per impostazione predefinita, Aspose.Slides include le proprietà del documento nella crittografia della presentazione. Il metodo [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) controlla questo comportamento in modo indipendente dalla crittografia del contenuto delle diapositive. Passare `false` prima di chiamare [ProtectionManager.encrypt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#encrypt) quando un sistema di indicizzazione, classificazione, ricerca o gestione dei documenti deve leggere i metadati senza la password di apertura.

Il seguente esempio crea una presentazione PPTX crittata lasciando pubbliche le sue proprietà di documento incorporate:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Passare `false` a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) non rende pubbliche le diapositive, i master, i layout, le forme, i media o altri contenuti della presentazione. Influisce solo sulle proprietà del documento. Per leggere tali proprietà senza caricare il contenuto crittato, vedere [Manage Presentation Properties](/slides/it/nodejs-java/presentation-properties/).

## **Caricare una presentazione crittata**

Impostare [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword) sulla password di apertura e passare le opzioni a [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Lavora con la presentazione decrittata.
} finally {
    presentation.dispose();
}
```

## **Rimuovere la crittografia da una presentazione**

Caricare la presentazione con la sua password di apertura, chiamare [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) e salvare il risultato. La presentazione salvata può quindi essere caricata senza password.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Convalidare una password di apertura prima del caricamento**

Utilizzare [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) per ottenere [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/) senza creare un'istanza completa della presentazione. Verificare [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) prima di richiedere o convalidare una password. Quando è presente la protezione, convalidare il valore fornito con [PresentationInfo.checkPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Flusso di lavoro per percorso file**

Il seguente esempio convalida una password di apertura per un file PPTX, passa il valore convalidato a [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword) e quindi carica la presentazione completa:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Flusso di lavoro basato su stream**

Utilizzare [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) per ispezionare uno stream leggibile Node.js. Dopo che lo stream di ispezione è stato consumato, creare un nuovo stream prima di caricare la presentazione completa con [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Il seguente esempio utilizza un file PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Valori restituiti da checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#checkPassword) restituisce `true` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è `null` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verificare se una presentazione caricata è crittata**

Dopo aver caricato una presentazione con la password corretta, ispezionare [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) per confermare che la presentazione di origine fosse crittata. Per rilevare la protezione con password di apertura prima del caricamento, utilizzare [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) come mostrato sopra.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Raccomandazioni di sicurezza**

{{% alert color="warning" title="Sicurezza" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti non necessari, conservare le password in memoria solo per il tempo necessario e riutilizzare un risultato di convalida riuscito quando si carica immediatamente la presentazione.

Le proprietà pubbliche del documento possono rivelare nomi degli autori, titoli, soggetti, parole chiave, informazioni aziendali, commenti e valori personalizzati anche se il contenuto della presentazione è crittato. Crittografare i metadati sensibili insieme alla presentazione. Lasciare le proprietà pubbliche dovrebbe essere una decisione esplicita presa solo quando i sistemi devono indicizzare, classificare, cercare o gestire il file senza una password di apertura.
{{% /alert %}}

## **Proteggere con password una presentazione online**

1. Aprire l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
2. Selezionare o caricare la presentazione.
3. Inserire una password per la protezione della visualizzazione.
4. Facoltativamente inserire una password separata per la protezione della modifica.
5. Applicare la protezione e scaricare il file risultante.

{{% alert color="info" title="Vedi anche" %}}
- [Protezione in scrittura delle presentazioni](/slides/it/nodejs-java/write-protected-presentation/)
- [Firma digitale in PowerPoint](/slides/it/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione della scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione della scrittura limita la modifica senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottenere le informazioni della presentazione, verificare se è presente la protezione con password di apertura e convalidare la password prima di creare un'istanza completa della presentazione.

**Un'applicazione può leggere i metadati senza la password di apertura?**

Sì, ma solo quando la presentazione è stata crittata con la crittografia delle proprietà del documento disabilitata. L'applicazione deve quindi utilizzare la modalità di caricamento solo delle proprietà del documento descritta in [Manage Presentation Properties](/slides/it/nodejs-java/presentation-properties/).

**I flussi di lavoro per il controllo della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.