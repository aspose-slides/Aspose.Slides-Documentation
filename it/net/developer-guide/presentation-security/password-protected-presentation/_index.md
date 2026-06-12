---
title: Presentazioni sicure con password in .NET
linktitle: Protezione con password
type: docs
weight: 20
url: /it/net/password-protected-presentation/
keywords:
- blocca PowerPoint
- blocca presentazione
- sblocca PowerPoint
- sblocca presentazione
- proteggi PowerPoint
- proteggi presentazione
- imposta password
- aggiungi password
- cifra PowerPoint
- cifra presentazione
- decifra PowerPoint
- decifra presentazione
- protezione in scrittura
- sicurezza PowerPoint
- sicurezza presentazione
- rimuovi password
- rimuovi protezione
- rimuovi crittografia
- disabilita password
- disabilita protezione
- rimuovi protezione in scrittura
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente le presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per .NET. Metti al sicuro le tue presentazioni."
---
## **Introduzione**

Quando proteggi con password una presentazione, imposti una password che applica determinate restrizioni sulla presentazione. Per rimuovere queste restrizioni è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, puoi impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione a meno che non forniscano la password.

Tuttavia, anche senza la password, un utente potrà comunque accedere e aprire il documento. In modalità sola lettura, l'utente può visualizzare il contenuto—comprese ipertestuali, animazioni, effetti e altri elementi—della presentazione, ma non può copiare elementi né salvare la presentazione.

- **Apertura**

Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare il contenuto della presentazione a meno che non forniscano la password.

Tecnicamente, la restrizione di apertura impedisce anche la modifica delle presentazioni—se le persone non possono aprire una presentazione, non possono modificarla né apportare cambiamenti.

**Nota:** Quando proteggi con password una presentazione per impedirne l'apertura, il file della presentazione diventa crittografato.

## **Protezione con password in Aspose.Slides**

**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni nei seguenti formati:

- PPTX e PPT – Presentazioni Microsoft PowerPoint
- ODP – Presentazioni OpenDocument
- OTP – Modelli di presentazione OpenDocument

**Operazioni supportate**

Aspose.Slides ti consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche nei seguenti modi:

- Crittografia di una presentazione
- Impostazione della protezione in scrittura su una presentazione

**Altre operazioni**

Aspose.Slides ti consente di eseguire attività aggiuntive relative a protezione con password e crittografia nei seguenti modi:

- Decrittografia di una presentazione; apertura di una presentazione crittografata
- Rimozione della crittografia; disabilitazione della protezione con password
- Rimozione della protezione in scrittura da una presentazione
- Recupero delle proprietà di una presentazione crittografata
- Verifica se una presentazione è protetta da password prima di caricarla
- Verifica se una presentazione è crittografata
- Verifica se una presentazione è protetta da password

## **Proteggere una presentazione con una password**

Puoi crittografare una presentazione impostando una password. Poi, per modificare la presentazione bloccata, l'utente deve fornire la password.

Per crittografare (o proteggere con password) una presentazione, utilizza il metodo `Encrypt` di [ProtectionManager](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager) per impostare una password. Passa la password al metodo `Encrypt`, quindi usa il metodo `Save` per salvare la presentazione ora crittografata.

Questo esempio di codice mostra come crittografare una presentazione:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Impostare la protezione in scrittura su una presentazione** 

Puoi aggiungere un contrassegno "Non modificare" a una presentazione. Questo informa gli utenti che non desideri che apportino modifiche alla presentazione.

**Nota:** Il processo di protezione in scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno salvarla con un nome diverso.

Per impostare la protezione in scrittura, utilizza il metodo `SetWriteProtection`. Questo esempio di codice mostra come impostare la protezione in scrittura su una presentazione:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Caricare una presentazione crittografata**

Aspose.Slides ti consente di caricare una presentazione crittografata fornendo la password corretta. Questo esempio di codice mostra come caricare una presentazione crittografata:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Lavora con la presentazione decrittata.
}
```

## **Rimuovere la crittografia da una presentazione**

Puoi rimuovere la crittografia o la protezione con password da una presentazione, consentendo agli utenti di accedervi o modificarla senza restrizioni.

Per rimuovere la crittografia o la protezione con password, chiama il metodo [RemoveEncryption](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/methods/removeencryption). Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Rimuovere la protezione in scrittura da una presentazione**

Puoi usare Aspose.Slides per rimuovere la protezione in scrittura da un file di presentazione. In questo modo, gli utenti possono modificarla a piacere e non riceveranno avvisi durante tali operazioni.

Puoi rimuovere la protezione in scrittura utilizzando il metodo [RemoveWriteProtection](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/methods/removewriteprotection). Questo esempio di codice mostra come rimuovere la protezione in scrittura da una presentazione:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Ottenere le proprietà di una presentazione crittografata**

Tipicamente, gli utenti faticano a recuperare le proprietà del documento di una presentazione crittografata o protetta da password. Tuttavia, Aspose.Slides offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle sue proprietà.

**Nota:** Per impostazione predefinita, quando Aspose.Slides cripta una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se è necessario rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides lo permette.

Se desideri che gli utenti mantengano la capacità di accedere alle proprietà di una presentazione crittografata, puoi impostare la proprietà [EncryptDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) su `true`. Questo esempio di codice mostra come crittografare una presentazione consentendo comunque agli utenti di accedere alle proprietà del documento:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **Verificare se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler verificare che non sia stata protetta con una password. Questo ti aiuta a evitare errori e problemi simili che si verificano quando una presentazione protetta da password viene caricata senza la password corretta.

Questo codice C# mostra come esaminare una presentazione per vedere se è protetta da password senza effettivamente caricarla:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Verificare se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare la proprietà [IsEncrypted](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/properties/isencrypted), che restituisce `true` se la presentazione è crittografata o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Verificare se una presentazione è protetta in scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta in scrittura. Per eseguire questa operazione, puoi utilizzare la proprietà [IsWriteProtected](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/properties/iswriteprotected), che restituisce `true` se la presentazione è protetta in scrittura o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è protetta in scrittura:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verificare l'uso della password di una presentazione**

Potresti voler controllare e confermare che una password specifica sia stata utilizzata per proteggere un documento di presentazione. Aspose.Slides fornisce i mezzi per convalidare una password.

Questo esempio di codice mostra come convalidare una password:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Verifica se la password corrisponde.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata; altrimenti, restituisce `false`.

{{% alert color="primary" title="Vedi anche" %}} 
- [Digital Signature in PowerPoint](/slides/it/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Vai alla pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock). 
2. Fai clic su **Drop or upload your files**. 
3. Seleziona il file che desideri proteggere con password sul tuo computer. 
4. Inserisci la password preferita per la protezione di modifica e la password preferita per la protezione di visualizzazione. 
5. Se desideri che gli utenti vedano la tua presentazione come copia finale, spunta la casella **Mark as final**. 
6. Fai clic su **PROTECT NOW.** 
7. Fai clic su **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

** Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire l'accesso non autorizzato e a proteggere il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo di elaborazione complessivo delle tue attività di presentazione.