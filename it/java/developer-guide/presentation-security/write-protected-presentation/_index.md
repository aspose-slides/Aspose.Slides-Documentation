---
title: Proteggi da scrittura le presentazioni in Java
linktitle: Protezione da scrittura
type: docs
weight: 25
url: /it/java/write-protected-presentation/
keywords:
- protezione da scrittura
- PowerPoint con protezione da scrittura
- password per modificare
- limitare la modifica della presentazione
- rimuovere la protezione da scrittura
- convalidare la password di modifica
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Imposta, rileva, convalida e rimuovi le password di protezione da scrittura nelle presentazioni PowerPoint PPT e PPTX utilizzando Aspose.Slides per Java."
---
## **Introduzione**

Una password di protezione da scrittura limita la modifica di una presentazione ma non cifra il suo contenuto. Gli utenti possono caricare e visualizzare una presentazione protetta da scrittura senza la password. A seconda dell'applicazione, possono anche modificare il contenuto e salvarlo con un nome diverso, perciò la protezione da scrittura non deve essere considerata un meccanismo di riservatezza.

Una password di apertura ha uno scopo diverso: cifra la presentazione ed è necessaria per caricare il suo contenuto. Per cifrare una presentazione o convalidare una password di apertura, vedere [Password-Protect Presentations](/slides/it/java/password-protected-presentation/).

I flussi di lavoro in questo articolo si applicano sia alle presentazioni PPT sia a quelle PPTX. Gli esempi utilizzano file PPTX; quando si salva in PPT, utilizzare l'estensione `.ppt` e il relativo formato di salvataggio PPT.

## **Imposta la protezione da scrittura su una presentazione**

Utilizzare [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) per assegnare una password per la modifica di una presentazione. Il salvataggio della presentazione conserva l'impostazione di protezione.

Il seguente esempio imposta la protezione da scrittura su una presentazione PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Carica una presentazione protetta da scrittura**

Poiché la protezione da scrittura non cifra il contenuto della presentazione, non è necessaria alcuna password per caricare la presentazione. La password è rilevante solo quando si convalida l'autorizzazione a modificare la presentazione protetta.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Non passare una password di protezione da scrittura a [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). quel metodo accetta una password di apertura per contenuti cifrati. Se una presentazione ha entrambi i tipi di protezione, fornire la password di apertura per caricarla e gestire separatamente la password di protezione da scrittura.

## **Rimuovi la protezione da scrittura da una presentazione**

Utilizzare [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) per rimuovere la restrizione di modifica, quindi salvare la presentazione.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verifica se una presentazione è protetta da scrittura**

Per ispezionare un file senza creare un'istanza completa di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/), chiamare [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) e controllare [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Il metodo utilizza [NullableBool](https://reference.aspose.com/slides/it/java/com.aspose.slides/nullablebool/) e restituisce `NullableBool.True` quando viene rilevata la protezione da scrittura.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

La sovraccarico per stream di [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) fornisce le stesse informazioni per una presentazione fornita come stream.

## **Convalida una password di protezione da scrittura**

Utilizzare [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) per convalidare una password di modifica senza caricare l'intera presentazione. Verificare prima [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) in modo che l'applicazione richieda o convalidi una password solo quando è presente la protezione da scrittura.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) convalida solo la password di protezione da scrittura. Non convalida una password di apertura né determina se il contenuto cifrato può essere caricato. Al contrario, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) convalida solo una password di apertura. Se una presentazione completa è già stata caricata, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) fornisce il controllo equivalente della protezione da scrittura tramite il suo gestore di protezione.

Nelle applicazioni di produzione, non registrare le password né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti non necessari e mantenere le password in memoria solo per il tempo strettamente necessario.

{{% alert color="info" title="See also" %}}
- [Presentazioni protette da password](/slides/it/java/password-protected-presentation/)
- [Presentazioni in sola lettura](/slides/it/java/read-only-presentation/)
- [Firma digitale in PowerPoint](/slides/it/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protezione da scrittura cifra una presentazione?**

No. Limita la modifica ma lascia il contenuto della presentazione disponibile per il caricamento e la visualizzazione.

**È necessaria la password di protezione da scrittura per aprire una presentazione?**

No. È necessaria solo una password di apertura per caricare il contenuto della presentazione cifrata.

**Una presentazione può avere sia una password di apertura sia una password di protezione da scrittura?**

Sì. Fornire la password di apertura tramite le opzioni di caricamento per aprire la presentazione cifrata e convalidare separatamente la password di protezione da scrittura quando è necessaria l'autorizzazione alla modifica.