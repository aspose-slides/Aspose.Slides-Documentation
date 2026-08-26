---
title: Presentazioni protette da password in JavaScript
linktitle: Protezione con password
type: docs
weight: 20
url: /it/nodejs-java/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- cifratura PowerPoint
- decifratura PowerPoint
- convalida password della presentazione
- verifica password della presentazione
- apri presentazione crittografata
- rimuovi crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Cifra, rileva, convalida, apre e decifra presentazioni PowerPoint PPT e PPTX protette da password in JavaScript con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa da una password di protezione dalla scrittura. La protezione dalla scrittura limita le modifiche ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per modificare le presentazioni, vedere [Write-Protect Presentations](/slides/it/nodejs-java/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati quando il loro comportamento basato su file e su stream è importante.

## **Crittografa una presentazione con una password di apertura**

Usa [ProtectionManager.encrypt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#encrypt) per assegnare una password di apertura. Quindi usa [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) per salvare la presentazione crittografata.

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

## **Carica una presentazione crittografata**

Imposta [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword) alla password di apertura e passa le opzioni a [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) quando carichi il file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

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

## **Rimuovi la crittografia da una presentazione**

Carica la presentazione con la sua password di apertura, chiama [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) e salva il risultato. La presentazione salvata può quindi essere caricata senza password.

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

## **Convalida una password di apertura prima del caricamento**

Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) per ottenere [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/) senza creare un'istanza completa della presentazione. Controlla [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) prima di richiedere o convalidare una password. Quando la protezione è presente, convalida il valore fornito con [PresentationInfo.checkPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Flusso di lavoro percorso file**

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

### **Flusso di lavoro stream**

Usa [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) per ispezionare uno stream leggibile di Node.js. Dopo che lo stream di ispezione è stato consumato, crea un nuovo stream prima di caricare la presentazione completa con [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

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

### **Valori di ritorno di checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#checkPassword) restituisce `true` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è `null` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispeziona [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) per confermare che la presentazione di origine era crittografata. Per rilevare la protezione con password di apertura prima del caricamento, usa [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) come mostrato sopra.

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

{{% alert color="warning" title="Security" %}}
Do not log opening passwords or include them in diagnostic messages. Avoid unnecessary repeated validation attempts, keep passwords in memory only as long as needed, and reuse a successful validation result when immediately loading the presentation.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Apri l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Seleziona o carica la presentazione.
1. Inserisci una password per la protezione della visualizzazione.
1. Facoltativamente inserisci una password separata per la protezione della modifica.
1. Applica la protezione e scarica il file risultante.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/it/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/it/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione dalla scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricarne il contenuto. Una password di protezione dalla scrittura limita le modifiche senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottieni le informazioni della presentazione, verifica se è presente la protezione con password di apertura e convalida la password prima di creare un'istanza completa della presentazione.

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e stream si comportano allo stesso modo per le presentazioni PPT e PPTX.