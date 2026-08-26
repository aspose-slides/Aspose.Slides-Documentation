---
title: Proteggi da scrittura le presentazioni in JavaScript
linktitle: Protezione da scrittura
type: docs
weight: 25
url: /it/nodejs-java/write-protected-presentation/
keywords:
- protezione da scrittura
- PowerPoint con protezione da scrittura
- password per modificare
- limitare la modifica della presentazione
- rimuovere la protezione da scrittura
- convalidare la password di modifica
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Imposta, rileva, convalida e rimuovi le password di protezione da scrittura in presentazioni PowerPoint PPT e PPTX utilizzando Aspose.Slides per Node.js via Java."
---
## **Introduzione**

Una password di protezione da scrittura limita la modifica di una presentazione ma non cripta il suo contenuto. Gli utenti possono caricare e visualizzare una presentazione protetta da scrittura senza la password. A seconda dell'applicazione, potrebbero anche essere in grado di modificare il contenuto e salvarlo con un nome diverso, quindi la protezione da scrittura non deve essere considerata un meccanismo di riservatezza.

Una password di apertura ha uno scopo diverso: cripta la presentazione ed è necessaria per caricare il suo contenuto. Per criptare una presentazione o convalidare una password di apertura, vedere [Password-Protect Presentations](/slides/it/nodejs-java/password-protected-presentation/).

I flussi di lavoro di questo articolo si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano file PPTX; quando si salva in PPT, usare l'estensione `.ppt` e il corrispondente formato di salvataggio PPT.

## **Imposta la protezione da scrittura su una presentazione**

Utilizzare [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) per assegnare una password per modificare una presentazione. Il salvataggio della presentazione conserva l'impostazione di protezione.

Il seguente esempio imposta la protezione da scrittura su una presentazione PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Carica una presentazione protetta da scrittura**

Poiché la protezione da scrittura non cripta il contenuto della presentazione, non è necessaria alcuna password per caricare la presentazione. La password è rilevante solo durante la convalida dell'autorizzazione a modificare la presentazione protetta.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Non passare una password di protezione da scrittura a [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword). Questo metodo accetta una password di apertura per contenuti criptati. Se una presentazione ha entrambi i tipi di protezione, fornire la password di apertura per caricarla e gestire separatamente la password di protezione da scrittura.

## **Rimuovi la protezione da scrittura da una presentazione**

Utilizzare [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) per rimuovere la restrizione di modifica, quindi salvare la presentazione.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verifica se una presentazione è protetta da scrittura**

Per ispezionare un file senza creare un'istanza completa di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/), chiamare [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) e controllare [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Il metodo utilizza [NullableBool](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/nullablebool/) e restituisce `NullableBool.True` quando viene rilevata la protezione da scrittura.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Il metodo basato su stream [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) fornisce le stesse informazioni per una presentazione fornita come stream leggibile di Node.js.

## **Convalida una password di protezione da scrittura**

Utilizzare [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) per convalidare una password di modifica senza caricare l'intera presentazione. Controllare prima [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) in modo che l'applicazione richieda o convalidi una password solo quando è presente la protezione da scrittura.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) convalida solo la password di protezione da scrittura. Non convalida una password di apertura né determina se il contenuto criptato può essere caricato. Al contrario, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#checkPassword) convalida solo una password di apertura. Se una presentazione completa è già stata caricata, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) fornisce il controllo equivalente della protezione da scrittura tramite il suo gestore di protezione.

Nelle applicazioni di produzione, non registrare le password né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti e non necessari, e conservare le password in memoria solo per il tempo strettamente necessario.

{{% alert color="info" title="Vedi anche" %}}
- [Presentazioni protette da password](/slides/it/nodejs-java/password-protected-presentation/)
- [Presentazioni in sola lettura](/slides/it/nodejs-java/read-only-presentation/)
- [Firma digitale in PowerPoint](/slides/it/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protezione da scrittura cripta una presentazione?**

No. Limita la modifica ma lascia il contenuto della presentazione disponibile per il caricamento e la visualizzazione.

**La password di protezione da scrittura è necessaria per aprire una presentazione?**

No. È necessaria solo una password di apertura per caricare il contenuto criptato della presentazione.

**Una presentazione può avere sia una password di apertura sia una password di protezione da scrittura?**

Sì. Fornire la password di apertura tramite le opzioni di caricamento per aprire la presentazione criptata e convalidare separatamente la password di protezione da scrittura quando è necessaria l'autorizzazione alla modifica.