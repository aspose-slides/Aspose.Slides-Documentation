---
title: Protezione in scrittura delle presentazioni su Android
linktitle: Protezione in scrittura
type: docs
weight: 25
url: /it/androidjava/write-protected-presentation/
keywords:
- protezione in scrittura
- protezione in scrittura PowerPoint
- password per modificare
- limitare modifica presentazione
- rimuovere protezione in scrittura
- convalidare password di modifica
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Imposta, rileva, convalida e rimuovi le password di protezione in scrittura nelle presentazioni PowerPoint PPT e PPTX utilizzando Aspose.Slides per Android tramite Java."
---
## **Introduzione**

Una password di protezione in scrittura limita la modifica di una presentazione ma non cripta il suo contenuto. Gli utenti possono caricare e visualizzare una presentazione protetta in scrittura senza la password. A seconda dell'applicazione, potrebbero anche essere in grado di modificare il contenuto e salvarlo con un nome diverso, quindi la protezione in scrittura non deve essere considerata un meccanismo di riservatezza.

Una password di apertura ha uno scopo diverso: cripta la presentazione ed è necessaria per caricare il suo contenuto. Per criptare una presentazione o convalidare una password di apertura, vedere [Password-Protect Presentations](/slides/it/androidjava/password-protected-presentation/).

I flussi di lavoro in questo articolo si applicano sia alle presentazioni PPT sia a quelle PPTX. Gli esempi utilizzano file PPTX; quando si salva in PPT, utilizzare l'estensione `.ppt` e il relativo formato di salvataggio PPT.

## **Imposta la protezione in scrittura su una presentazione**

Utilizzare [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) per assegnare una password alla modifica di una presentazione. Il salvataggio della presentazione mantiene l'impostazione di protezione.

Il seguente esempio imposta la protezione in scrittura su una presentazione PPTX:

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

## **Carica una presentazione protetta in scrittura**

Poiché la protezione in scrittura non cripta il contenuto della presentazione, non è necessaria alcuna password per caricare la presentazione. La password è rilevante solo quando si valida l'autorizzazione a modificare la presentazione protetta.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Non passare una password di protezione in scrittura a [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Questo metodo accetta una password di apertura per contenuti criptati. Se una presentazione possiede entrambi i tipi di protezione, fornire la password di apertura per caricarla e gestire separatamente la password di protezione in scrittura.

## **Rimuovi la protezione in scrittura da una presentazione**

Utilizzare [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) per rimuovere la restrizione di modifica, quindi salvare la presentazione.

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

## **Verifica se una presentazione è protetta in scrittura**

Per ispezionare un file senza creare un'istanza completa di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/), chiamare [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) e verificare [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). Il metodo utilizza [NullableBool](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/nullablebool/) e restituisce `NullableBool.True` quando viene rilevata la protezione in scrittura.

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

La overload basata su stream di [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) fornisce la stessa informazione per una presentazione fornita come stream.

## **Convalida una password di protezione in scrittura**

Utilizzare [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) per convalidare una password di modifica senza caricare l'intera presentazione. Verificare prima [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) in modo che l'applicazione richieda o convalidi una password solo quando è presente la protezione in scrittura.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) convalida solo la password di protezione in scrittura. Non convalida una password di apertura né determina se il contenuto criptato può essere caricato. Al contrario, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) convalida solo una password di apertura. Se una presentazione completa è già stata caricata, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) fornisce l'equivalente verifica di protezione in scrittura tramite il suo manager di protezione.

Nelle applicazioni in produzione, non registrare le password né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti inutili e conservare le password in memoria solo per il tempo strettamente necessario.

{{% alert color="info" title="See also" %}}
- [Presentazioni protette da password](/slides/it/androidjava/password-protected-presentation/)
- [Presentazioni in sola lettura](/slides/it/androidjava/read-only-presentation/)
- [Firma digitale in PowerPoint](/slides/it/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protezione in scrittura cifra una presentazione?**

No. Limita la modifica ma lascia il contenuto della presentazione disponibile per il caricamento e la visualizzazione.

**È necessaria la password di protezione in scrittura per aprire una presentazione?**

No. È necessaria solo una password di apertura per caricare il contenuto criptato della presentazione.

**Una presentazione può avere sia una password di apertura sia una password di protezione in scrittura?**

Sì. Fornire la password di apertura tramite le opzioni di caricamento per aprire la presentazione criptata e convalidare separatamente la password di protezione in scrittura quando è necessaria l'autorizzazione alla modifica.