---
title: Proteggi da scrittura le presentazioni in Python
linktitle: Protezione da scrittura
type: docs
weight: 25
url: /it/python-net/write-protected-presentation/
keywords:
- protezione da scrittura
- protezione da scrittura PowerPoint
- password per modificare
- limitare la modifica della presentazione
- rimuovere la protezione da scrittura
- convalidare la password di modifica
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Imposta, rileva, convalida e rimuovi le password di protezione da scrittura nelle presentazioni PowerPoint PPT e PPTX utilizzando Aspose.Slides per Python."
---
## **Introduzione**

Una password di protezione da scrittura limita la modifica di una presentazione ma non cripta il suo contenuto. Gli utenti possono caricare e visualizzare una presentazione protetta da scrittura senza la password. A seconda dell'applicazione, potrebbero anche essere in grado di modificare il contenuto e salvarlo con un nome diverso, quindi la protezione da scrittura non dovrebbe essere considerata un meccanismo di riservatezza.

Una password di apertura ha uno scopo diverso: cripta la presentazione ed è necessaria per caricare il suo contenuto. Per crittografare una presentazione o convalidare una password di apertura, vedere [Presentazioni protette da password](/slides/it/python-net/password-protected-presentation/).

I flussi di lavoro in questo articolo si applicano sia a presentazioni PPT che PPTX. Gli esempi utilizzano file PPTX; quando si salva in PPT, utilizzare l'estensione `.ppt` e il formato di salvataggio PPT corrispondente.

## **Imposta la protezione da scrittura su una presentazione**

Utilizzare [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/set_write_protection/) per assegnare una password per modificare una presentazione. Salvare la presentazione conserva l'impostazione di protezione.

Il seguente esempio imposta la protezione da scrittura su una presentazione PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Carica una presentazione protetta da scrittura**

Poiché la protezione da scrittura non cripta il contenuto della presentazione, non è necessaria alcuna password per caricarla. La password è rilevante solo quando si convalida l'autorizzazione a modificare la presentazione protetta.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Non passare una password di protezione da scrittura a [LoadOptions.password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/). Tale proprietà accetta una password di apertura per contenuti criptati. Se una presentazione ha entrambi i tipi di protezione, fornire la password di apertura per caricarla e gestire separatamente la password di protezione da scrittura.

## **Rimuovi la protezione da scrittura da una presentazione**

Utilizzare [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/remove_write_protection/) per rimuovere la restrizione di modifica, quindi salvare la presentazione.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Verifica se una presentazione è protetta da scrittura**

Per ispezionare un file senza creare un'istanza completa di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/), chiamare [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) e controllare [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/is_write_protected/). La proprietà utilizza [NullableBool](https://reference.aspose.com/slides/it/python-net/aspose.slides/nullablebool/) e restituisce `NullableBool.TRUE` quando viene rilevata la protezione da scrittura.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

La sovraccarico per stream di [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationfactory/get_presentation_info/) fornisce le stesse informazioni per una presentazione fornita come flusso.

## **Convalida una password di protezione da scrittura**

Utilizzare [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/check_write_protection/) per convalidare una password di modifica senza caricare l'intera presentazione. Controllare prima [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/is_write_protected/) in modo che l'applicazione richieda o convalidi una password solo quando è presente la protezione da scrittura.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/check_write_protection/) convalida solo la password di protezione da scrittura. Non convalida una password di apertura né determina se il contenuto criptato può essere caricato. Al contrario, [PresentationInfo.check_password](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentationinfo/check_password/) convalida solo una password di apertura. Se una presentazione completa è già stata caricata, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/check_write_protection/) fornisce il controllo equivalente della protezione da scrittura tramite il suo gestore di protezione.

Nelle applicazioni di produzione, non registrare le password né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti inutili e conservare le password in memoria solo per il tempo necessario.

{{% alert color="info" title="Vedi anche" %}}
- [Presentazioni protette da password](/slides/it/python-net/password-protected-presentation/)
- [Presentazioni in sola lettura](/slides/it/python-net/read-only-presentation/)
- [Firma digitale in PowerPoint](/slides/it/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protezione da scrittura cripta una presentazione?**

No. Limita la modifica ma lascia il contenuto della presentazione disponibile per il caricamento e la visualizzazione.

**La password di protezione da scrittura è necessaria per aprire una presentazione?**

No. È necessaria solo una password di apertura per caricare il contenuto di una presentazione criptata.

**Una presentazione può avere sia una password di apertura che una password di protezione da scrittura?**

Sì. Fornire la password di apertura tramite le opzioni di caricamento per aprire la presentazione criptata e convalidare separatamente la password di protezione da scrittura quando è necessaria l'autorizzazione alla modifica.