---
title: Presentazioni protette da scrittura in Python
linktitle: Protezione da scrittura
type: docs
weight: 25
url: /it/python-java/write-protected-presentation/
keywords:
- protezione da scrittura
- PowerPoint protetto da scrittura
- password per modificare
- limitare la modifica della presentazione
- rimuovere la protezione da scrittura
- convalidare la password di modifica
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Imposta, rileva, convalida e rimuovi le password di protezione da scrittura nelle presentazioni PowerPoint PPT e PPTX usando Aspose.Slides per Python tramite Java."
---
## **Introduzione**

Una password di protezione da scrittura limita la modifica di una presentazione ma non crittografa il suo contenuto. Gli utenti possono caricare e visualizzare una presentazione protetta da scrittura senza la password. A seconda dell'applicazione, potrebbero anche essere in grado di modificare il contenuto e salvarlo con un nome diverso, quindi la protezione da scrittura non deve essere considerata un meccanismo di riservatezza.

Una password di apertura ha uno scopo diverso: crittografa la presentazione ed è necessaria per caricare il suo contenuto. Per crittografare una presentazione o convalidare una password di apertura, vedere [Presentazioni protette da password](/slides/it/python-java/password-protected-presentation/).

I flussi di lavoro in questo articolo si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano file PPTX; quando si salva in PPT, utilizzare l'estensione `.ppt` e il formato di salvataggio PPT corrispondente.

## **Imposta protezione da scrittura su una presentazione**

Utilizza [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#setWriteProtection) per assegnare una password per modificare una presentazione. Il salvataggio della presentazione mantiene l'impostazione di protezione.

Il seguente esempio imposta la protezione da scrittura su una presentazione PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Carica una presentazione protetta da scrittura**

Poiché la protezione da scrittura non crittografa il contenuto della presentazione, non è necessaria alcuna password per caricare la presentazione. La password è rilevante solo quando si convalida l'autorizzazione a modificare la presentazione protetta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Non passare una password di protezione da scrittura a [LoadOptions.setPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setPassword). Quel metodo accetta una password di apertura per contenuti crittografati. Se una presentazione ha entrambi i tipi di protezione, fornire la password di apertura per caricarla e gestire separatamente la password di protezione da scrittura.

## **Rimuovi la protezione da scrittura da una presentazione**

Utilizza [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#removeWriteProtection) per rimuovere la restrizione di modifica, quindi salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verifica se una presentazione è protetta da scrittura**

Per esaminare un file senza creare un'istanza completa di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), chiama [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e controlla [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#isWriteProtected). Il metodo utilizza [NullableBool](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/) e restituisce `NullableBool.True_` quando viene rilevata la protezione da scrittura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

La variante di flusso di [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationfactory/#getPresentationInfo) fornisce le stesse informazioni per una presentazione fornita come stream.

## **Convalida una password di protezione da scrittura**

Utilizza [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#checkWriteProtection) per convalidare una password di modifica senza caricare l'intera presentazione. Controlla prima [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#isWriteProtected) in modo che l'applicazione richieda o convalidi una password solo quando è presente la protezione da scrittura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#checkWriteProtection) convalida solo la password di protezione da scrittura. Non convalida una password di apertura né determina se il contenuto crittografato può essere caricato. Al contrario, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationinfo/#checkPassword) convalida solo una password di apertura. Se una presentazione completa è già stata caricata, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#checkWriteProtection) fornisce il corrispondente controllo di protezione da scrittura tramite il suo gestore di protezione.

Nelle applicazioni di produzione, non registrare le password né includerle nei messaggi diagnostici. Evita tentativi di convalida ripetuti inutili e conserva le password in memoria solo per il tempo necessario.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/it/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/it/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/it/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protezione da scrittura cripta una presentazione?**

No. Limita la modifica ma lascia il contenuto della presentazione disponibile per il caricamento e la visualizzazione.

**La password di protezione da scrittura è necessaria per aprire una presentazione?**

No. È necessaria solo una password di apertura per caricare il contenuto crittografato della presentazione.

**Una presentazione può avere sia una password di apertura sia una password di protezione da scrittura?**

Sì. Fornisci la password di apertura tramite le opzioni di caricamento per aprire la presentazione crittografata e convalida separatamente la password di protezione da scrittura quando è necessaria l'autorizzazione alla modifica.