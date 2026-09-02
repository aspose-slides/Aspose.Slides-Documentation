---
title: Presentazioni sicure con password usando Python
linktitle: Protezione con password
type: docs
weight: 20
url: /it/python-net/password-protected-presentation/
keywords:
- blocca PowerPoint
- blocca presentazione
- sblocca PowerPoint
- sblocca presentazione
- proteggi PowerPoint
- proteggi presentazione
- imposta password
- aggiungi password
- crittografa PowerPoint
- crittografa presentazione
- decrittografa PowerPoint
- decrittografa presentazione
- protezione in scrittura
- sicurezza PowerPoint
- sicurezza presentazione
- rimuovi password
- rimuovi protezione
- rimuovi crittografia
- disabilita password
- disabilita protezione
- rimuovi protezione in scrittura
- presentazione PowerPoint
- Python
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per Python tramite .NET. Incrementa la tua produttività e proteggi le tue presentazioni con la nostra guida passo-passo."
---
## **Introduzione**

Quando si protegge una presentazione con password, si imposta una password che applica determinate restrizioni alla presentazione. Per rimuovere le restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

In genere, è possibile impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

  Se si desidera che solo determinati utenti possano modificare la presentazione, è possibile impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella presentazione (a meno che non forniscano la password). 

  Tuttavia, in questo caso, anche senza la password, un utente potrà accedere al documento e aprirlo. In modalità sola lettura, l’utente può visualizzare il contenuto o elementi—collegamenti ipertestuali, animazioni, effetti e altri—della presentazione, ma non può copiare elementi né salvare la presentazione. 

- **Apertura**

  Se si desidera che solo determinati utenti possano aprire la presentazione, è possibile impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare il contenuto della presentazione (a meno che non forniscano la password).

  Tecnica­mente, la restrizione di apertura impedisce anche la modifica delle presentazioni: quando le persone non possono aprire una presentazione, non possono modificarla né apportare cambiamenti. 
  
  **Nota** che quando si protegge una presentazione con password per impedirne l’apertura, il file della presentazione diventa crittografato.

## Come proteggere con password una presentazione online

1. Visita la nostra pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Fai clic su **Drop or upload your files**.

3. Seleziona il file che desideri proteggere con password sul tuo computer. 

4. Inserisci la password preferita per la protezione di modifica; inserisci la password preferita per la protezione di visualizzazione. 

5. Se vuoi che gli utenti vedano la tua presentazione come copia finale, spunta la casella **Mark as final**.

6. Fai clic su **PROTECT NOW.** 

7. Fai clic su **DOWNLOAD NOW.**

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni nei seguenti formati: 

- PPTX e PPT – Microsoft PowerPoint Presentation 
- ODP – OpenDocument Presentation 
- OTP – OpenDocument Presentation Template 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche nei seguenti modi:

- Crittografare una presentazione
- Impostare una protezione di scrittura a una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre attività relative a protezione con password e crittografia nei seguenti modi:

- Decrittografare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione di scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

## **Crittografare una presentazione**

È possibile crittografare una presentazione impostando una password. Successivamente, per modificare la presentazione bloccata, l'utente deve fornire la password. 

Per crittografare o proteggere con password una presentazione, è necessario utilizzare il metodo **encrypt** (da [ProtectionManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/)) per impostare una password per la presentazione. Si passa la password al metodo **encrypt** e si utilizza il metodo **save** per salvare la presentazione ora crittografata. 

Questo esempio di codice mostra come crittografare una presentazione:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la protezione di scrittura a una presentazione** 

È possibile aggiungere un'etichetta “Do not modify” a una presentazione. In questo modo, si informa l'utente che non si desidera che apporti modifiche alla presentazione.  

**Nota** che il processo di protezione di scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso. 

Per impostare la protezione di scrittura, è necessario utilizzare il metodo **setWriteProtection**. Questo esempio di codice mostra come impostare una protezione di scrittura a una presentazione:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Decrittografare una presentazione; aprire una presentazione crittografata**

Aspose.Slides permette di caricare un file crittografato fornendo la sua password. Per decrittografare una presentazione, è necessario chiamare il metodo [remove_encryption](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/) senza parametri. Verrà poi richiesto di inserire la password corretta per caricare la presentazione. 

Questo esempio di codice mostra come decrittografare una presentazione: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Rimuovere la crittografia; disabilitare la protezione con password**

È possibile rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni. 

Per rimuovere la crittografia o la protezione con password, è necessario chiamare il metodo [remove_encryption](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/). Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovere la protezione di scrittura da una presentazione**

È possibile utilizzare Aspose.Slides per rimuovere la protezione di scrittura applicata a un file di presentazione. In questo modo, gli utenti possono modificare a loro piacimento—senza avvisi quando eseguono tali operazioni.

È possibile rimuovere la protezione di scrittura da una presentazione utilizzando il metodo [remove_write_protection](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/). Questo esempio di codice mostra come rimuovere la protezione di scrittura da una presentazione:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottenere le proprietà di una presentazione crittografata**

In genere, gli utenti hanno difficoltà a recuperare le proprietà del documento di una presentazione crittografata o protetta da password. Tuttavia, Aspose.Slides offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle sue proprietà.

**Nota:** Per impostazione predefinita, quando Aspose.Slides crittografa una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se è necessario rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides lo consente.

Se si desidera che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione crittografata, impostare la proprietà `encrypt_document_properties` di [ProtectionManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/) su `False`. Questo esempio di codice mostra come crittografare una presentazione mantenendo l'accesso alle proprietà del documento:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Caricare solo le proprietà del documento da una presentazione crittografata**

Per ispezionare i metadati di una presentazione crittografata senza caricare le sue diapositive o altri contenuti, creare un oggetto [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/) e impostare [only_load_document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/only_load_document_properties/) su `True`. In questa modalità, Aspose.Slides ignora la password e carica solo le proprietà del documento accessibili pubblicamente.

Il seguente esempio di codice legge le proprietà di documento integrate e elenca le proprietà di documento personalizzate tramite [Presentation.document_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Leggi le proprietà di documento integrate.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Elenca le proprietà di documento personalizzate.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Questo flusso di lavoro funziona solo quando le proprietà del documento sono state lasciate non crittografate (pubbliche) al momento della crittografia della presentazione. Se le proprietà del documento sono crittografate, impostare `only_load_document_properties` su `True` genera un'eccezione perché la password viene ignorata in questa modalità. Per accedere a proprietà di documento crittografate o per caricare la presentazione completa, incluse le diapositive e altri contenuti, fornire il valore corretto di `password` in [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/).

## **Verificare se una presentazione è protetta da password prima di caricarla**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia stata protetta da password. In questo modo, eviti errori e problemi analoghi che sorgono quando si carica una presentazione protetta senza la relativa password.

Questo codice Python mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Verificare se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, è possibile utilizzare la proprietà [is_encrypted](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/), che restituisce `True` se la presentazione è crittografata o `False` se non lo è. 

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Verificare se una presentazione è protetta da scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta da scrittura. Per eseguire questa operazione, è possibile utilizzare la proprietà [is_write_protected](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/), che restituisce `True` se la presentazione è protetta da scrittura o `False` se non lo è. 

Questo esempio di codice mostra come verificare se una presentazione è protetta da scrittura:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Convalidare o confermare che una password specifica sia stata usata per proteggere una presentazione**

Potresti voler verificare e confermare che una password specifica sia stata usata per proteggere un documento di presentazione. Aspose.Slides fornisce gli strumenti per convalidare una password. 

Questo esempio di codice mostra come convalidare una password:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # verifica se "pass" è corrispondente a
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Restituisce `True` se la presentazione è stata crittografata con la password specificata. In caso contrario, restituisce `False`. 

{{% alert color="primary" title="Vedi anche" %}} 
- [Firma digitale in PowerPoint](/slides/it/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi gli algoritmi basati su AES, garantendo un elevato livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata quando si tenta di aprire una presentazione?**

Viene generata un'eccezione se viene usata una password errata, avvisando che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero sovraccarico durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle attività della presentazione.