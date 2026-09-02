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
- crittografa PowerPoint
- crittografa presentazione
- decrittografa PowerPoint
- decrittografa presentazione
- protezione da scrittura
- sicurezza PowerPoint
- sicurezza presentazione
- rimuovi password
- rimuovi protezione
- rimuovi crittografia
- disabilita password
- disabilita protezione
- rimuovi protezione da scrittura
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per .NET. Metti al sicuro le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con password, imposti una password che applica determinate restrizioni alla presentazione. Per rimuovere queste restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, puoi impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione a meno che non forniscano la password.

Tuttavia, anche senza password, un utente potrà comunque accedere e aprire il documento. In modalità sola lettura, l'utente può visualizzare il contenuto—incluse ipertesti, animazioni, effetti e altri elementi—della presentazione, ma non può copiare elementi né salvare la presentazione.

- **Apertura**

Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare il contenuto della presentazione a meno che non forniscano la password.

Tecnicamente, la restrizione di apertura impedisce anche la modifica delle presentazioni—se gli utenti non possono aprire una presentazione, non possono modificarla né apportare modifiche.

**Nota:** Quando proteggi una presentazione con password per impedire l'apertura, il file della presentazione diventa crittografato.

## **Protezione con password in Aspose.Slides**

**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni analoghe per le presentazioni nei seguenti formati:

- PPTX e PPT – Presentazioni Microsoft PowerPoint
- ODP – Presentazioni OpenDocument
- OTP – Modelli di presentazione OpenDocument

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire le modifiche nei modi seguenti:

- Crittografare una presentazione
- Impostare la protezione da scrittura su una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire attività aggiuntive relative a protezione con password e crittografia nei modi seguenti:

- Decrittografare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione da scrittura da una presentazione
- Recuperare le proprietà di una presentazione crittografata
- Verificare se una presentazione è protetta da password prima di caricarla
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password

## **Proteggi una presentazione con una password**

Puoi crittografare una presentazione impostando una password. Quindi, per modificare la presentazione bloccata, l'utente deve fornire la password.

Per crittografare (o proteggere con password) una presentazione, utilizza il metodo `Encrypt` di [ProtectionManager](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager) per impostare una password. Passa la password al metodo `Encrypt`, poi utilizza il metodo `Save` per salvare la presentazione ora crittografata.

Questo esempio di codice mostra come crittografare una presentazione:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Imposta la protezione da scrittura su una presentazione** 

Puoi aggiungere un'etichetta “Do not modify” a una presentazione. Questo informa gli utenti che non desideri loro apportino modifiche alla presentazione.

**Nota:** Il processo di protezione da scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno salvarla con un nome diverso.

Per impostare la protezione da scrittura, usa il metodo `SetWriteProtection`. Questo esempio di codice mostra come impostare la protezione da scrittura su una presentazione:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Carica una presentazione crittografata**

Aspose.Slides consente di caricare una presentazione crittografata passando la password corretta. Questo esempio di codice mostra come caricare una presentazione crittografata:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Lavora con la presentazione decrittografata.
}
```

## **Rimuovi la crittografia da una presentazione**

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

## **Rimuovi la protezione da scrittura da una presentazione**

Puoi usare Aspose.Slides per rimuovere la protezione da scrittura da un file di presentazione. In questo modo, gli utenti possono modificarla a piacere—e non riceveranno avvisi durante tali operazioni.

Puoi rimuovere la protezione da scrittura utilizzando il metodo [RemoveWriteProtection](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/methods/removewriteprotection). Questo esempio di codice mostra come rimuovere la protezione da scrittura da una presentazione:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Recupera le proprietà di una presentazione crittografata**

Tipicamente, gli utenti hanno difficoltà a recuperare le proprietà del documento di una presentazione crittografata o protetta da password. Tuttavia, Aspose.Slides offre un meccanismo che consente di proteggere una presentazione con password mantenendo la possibilità per gli utenti di accedere alle sue proprietà.

**Nota:** Per impostazione predefinita, quando Aspose.Slides crittografa una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se desideri rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides permette di farlo esattamente.

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione crittografata, imposta la proprietà `EncryptDocumentProperties` di [IProtectionManager](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/) su `false`. Questo esempio di codice mostra come crittografare una presentazione mantenendo l’accesso alle proprietà del documento:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Carica solo le proprietà del documento da una presentazione crittografata**

Per ispezionare i metadati di una presentazione crittografata senza caricare le diapositive o altro contenuto, crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/) e imposta [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) su `true`. In questa modalità, Aspose.Slides ignora la password e carica solo le proprietà del documento pubblicamente accessibili.

Il seguente esempio di codice legge le proprietà del documento integrate e personalizzate tramite [IPresentation.DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Questo flusso di lavoro funziona solo quando le proprietà del documento sono state lasciate non crittografate (pubbliche) al momento della crittografia della presentazione. Se le proprietà del documento sono crittografate, impostare `OnlyLoadDocumentProperties` su `true` genera un’eccezione perché la password viene ignorata in questa modalità. Per accedere alle proprietà del documento crittografate o per caricare l’intera presentazione, incluse diapositive e altro contenuto, fornisci il valore corretto `Password` in [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/).

## **Verifica se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler verificare che non sia stata protetta da password. Questo ti aiuta a evitare errori e problemi simili che si verificano quando una presentazione protetta da password viene caricata senza la password corretta.

Questo codice C# mostra come esaminare una presentazione per vedere se è protetta da password senza caricarla effettivamente:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Verifica se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare la proprietà [IsEncrypted](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/properties/isencrypted), che restituisce `true` se la presentazione è crittografata o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Verifica se una presentazione è protetta da scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta da scrittura. Per eseguire questa operazione, puoi utilizzare la proprietà [IsWriteProtected](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/properties/iswriteprotected), che restituisce `true` se la presentazione è protetta da scrittura o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è protetta da scrittura:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verifica l’utilizzo della password della presentazione**

Potresti voler controllare e confermare che una password specifica sia stata usata per proteggere un documento di presentazione. Aspose.Slides fornisce i mezzi per convalidare una password.

Questo esempio di codice mostra come convalidare una password:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Verifica se la password corrisponde.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata; altrimenti restituisce `false`.

{{% alert color="primary" title="Vedi anche" %}} 
- [Digital Signature in PowerPoint](/slides/it/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Proteggi una presentazione con password online**

1. Vai alla nostra pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock). 
1. Fai clic su **Drop or upload your files**.
1. Seleziona il file che vuoi proteggere con password sul tuo computer. 
1. Inserisci la password preferita per la protezione in modifica e la password preferita per la protezione in visualizzazione.
1. Se desideri che gli utenti vedano la tua presentazione come copia finale, spunta la casella **Mark as final**.
1. Fai clic su **PROTECT NOW.** 
1. Fai clic su **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

** Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, segnalando che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle tue attività di presentazione.