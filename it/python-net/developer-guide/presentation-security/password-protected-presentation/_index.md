---
title: Presentazioni protette da password con Python
linktitle: Protezione con password
type: docs
weight: 20
url: /it/python-net/password-protected-presentation/
keywords:
- bloccare PowerPoint
- bloccare presentazione
- sbloccare PowerPoint
- sbloccare presentazione
- proteggere PowerPoint
- proteggere presentazione
- impostare password
- aggiungi password
- crittografa PowerPoint
- crittografa presentazione
- decrittografa PowerPoint
- decrittografa presentazione
- protezione di scrittura
- sicurezza PowerPoint
- sicurezza presentazione
- rimuovi password
- rimuovi protezione
- rimuovi crittografia
- disabilita password
- disabilita protezione
- rimuovi protezione di scrittura
- presentazione PowerPoint
- Python
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per Python tramite .NET. Aumenta la tua produttività e proteggi le tue presentazioni con la nostra guida passo passo."
---
## **Introduzione**

Quando proteggi una presentazione con una password, imposti una password che applica determinate restrizioni sulla presentazione. Per rimuovere le restrizioni è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Normalmente, puoi impostare una password per applicare queste restrizioni su una presentazione:

- **Modification**

  Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione (a meno che non forniscano la password). 

  Tuttavia, in questo caso, anche senza la password, un utente potrà accedere al tuo documento e aprirlo. In modalità sola lettura, l'utente può visualizzare i contenuti o elementi — collegamenti ipertestuali, animazioni, effetti e altri — all'interno della presentazione, ma non può copiare elementi né salvare la presentazione. 

- **Opening**

  Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare persino il contenuto della tua presentazione (a meno che non forniscano la password).

  Tecnicamente, la restrizione di apertura impedisce anche agli utenti di modificare le presentazioni: quando le persone non possono aprire una presentazione, non possono modificarla o apportare cambiamenti a essa. 
  
  **Nota** che quando proteggi una presentazione con password per impedire l'apertura, il file della presentazione viene crittografato.

## Come proteggere con password una presentazione online

1. Vai alla nostra pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Fai clic su **Rilascia o carica i tuoi file**.

3. Seleziona il file che desideri proteggere con password sul tuo computer. 

4. Inserisci la password preferita per la protezione di modifica; Inserisci la password preferita per la protezione di visualizzazione. 

5. Se desideri che gli utenti vedano la tua presentazione come copia finale, spunta la casella **Mark as final**.

6. Fai clic su **PROTECT NOW.** 

7. Fai clic su **DOWNLOAD NOW.**

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni in questi formati: 

- PPTX e PPT - Presentazione Microsoft PowerPoint 
- ODP - Presentazione OpenDocument 
- OTP - Modello di Presentazione OpenDocument 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche in questi modi:

- Crittografare una presentazione
- Impostare una protezione di scrittura su una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre attività relative alla protezione con password e alla crittografia in questi modi:

- Decifrare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione di scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

## **Crittografia di una presentazione**

Puoi crittografare una presentazione impostando una password. Poi, per modificare la presentazione bloccata, l'utente deve fornire la password. 

Per crittografare o proteggere con password una presentazione, devi utilizzare il metodo encrypt (da [ProtectionManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/)) per impostare una password per la presentazione. Passi la password al metodo encrypt e usi il metodo save per salvare la presentazione ora crittografata. 

Questo esempio di codice mostra come crittografare una presentazione:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostazione della protezione di scrittura su una presentazione** 

Puoi aggiungere un'indicazione “Do not modify” a una presentazione. In questo modo, informi gli utenti che non desideri che apportino modifiche alla presentazione.  

**Nota** che il processo di protezione di scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso. 

Per impostare una protezione di scrittura, devi utilizzare il metodo setWriteProtection. Questo esempio di codice mostra come impostare una protezione di scrittura su una presentazione:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Decifrazione di una presentazione; apertura di una presentazione crittografata**

Aspose.Slides consente di caricare un file crittografato fornendo la sua password. Per decifrare una presentazione, devi chiamare il metodo [remove_encryption](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione. 

Questo esempio di codice mostra come decifrare una presentazione: 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Rimozione della crittografia; disabilitazione della protezione con password**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni. 

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [remove_encryption](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/). Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimozione della protezione di scrittura da una presentazione**

Puoi usare Aspose.Slides per rimuovere la protezione di scrittura utilizzata su un file di presentazione. In questo modo, gli utenti possono modificare a loro piacere e non ricevono avvisi quando eseguono tali operazioni.

Puoi rimuovere la protezione di scrittura da una presentazione usando il metodo [remove_write_protection](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/). Questo esempio di codice mostra come rimuovere la protezione di scrittura da una presentazione:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottenere le proprietà di una presentazione crittografata**

In genere, gli utenti hanno difficoltà a ottenere le proprietà del documento di una presentazione crittografata o protetta da password. Aspose.Slides, tuttavia, offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle proprietà di quella presentazione.

**Nota** che quando Aspose.Slides crittografa una presentazione, le proprietà del documento della presentazione vengono protette da password per impostazione predefinita. Ma se è necessario rendere le proprietà della presentazione accessibili (anche dopo che la presentazione è stata crittografata), Aspose.Slides consente di farlo esattamente. 

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione che hai crittografato, puoi impostare la proprietà [EncryptDocumentProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/) su `True`. Questo esempio di codice mostra come crittografare una presentazione fornendo agli utenti i mezzi per accedere alle sue proprietà del documento:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Verifica se una presentazione è protetta da password prima di caricarla**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia protetta da password. In questo modo, eviti errori e problemi simili, che si verificano quando una presentazione protetta da password viene caricata senza la password.

Questo codice Python mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Verifica se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare la proprietà [is_encrypted](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/), che restituisce `True` se la presentazione è crittografata o `False` se la presentazione non è crittografata. 

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Verifica se una presentazione è protetta da scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta da scrittura. Per eseguire questa operazione, puoi utilizzare la proprietà [is_write_protected](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/), che restituisce `True` se la presentazione è protetta da scrittura o `False` se non lo è. 

Questo esempio di codice mostra come verificare se una presentazione è protetta da scrittura:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validare o confermare che una password specifica è stata usata per proteggere una presentazione**

Potresti voler verificare e confermare che una password specifica sia stata usata per proteggere un documento di presentazione. Aspose.Slides offre i mezzi per convalidare una password. 

Questo esempio di codice mostra come convalidare una password:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # verifica se "pass" corrisponde
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Restituisce `True` se la presentazione è stata crittografata con la password specificata. Altrimenti, restituisce `False`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/it/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene usata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittazione può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo di elaborazione complessivo delle tue attività di presentazione.