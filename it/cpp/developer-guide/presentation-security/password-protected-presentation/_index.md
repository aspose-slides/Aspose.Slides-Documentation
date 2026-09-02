---
title: Presentazioni sicure con password in C++
linktitle: Protezione con password
type: docs
weight: 20
url: /it/cpp/password-protected-presentation/
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
- protezione di scrittura
- sicurezza PowerPoint
- sicurezza presentazione
- rimuovi password
- rimuovi protezione
- rimuovi crittografia
- disabilita password
- disabilita protezione
- rimuovi protezione di scrittura
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per C++. Metti al sicuro le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con password, imposti una password che applica determinate restrizioni alla presentazione. Per rimuovere le restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

In genere, è possibile impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

  Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione (a meno che non forniscano la password). 

  Tuttavia, in questo caso, anche senza la password, un utente potrà accedere al documento e aprirlo. In modalità sola lettura, l'utente può visualizzare i contenuti o gli elementi—collegamenti ipertestuali, animazioni, effetti e altri—della presentazione, ma non può copiare elementi né salvare la presentazione. 

- **Apertura**

  Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare anche i contenuti della presentazione (a meno che non forniscano la password).

  Tecnicamente, la restrizione di apertura impedisce anche agli utenti di modificare le presentazioni: quando le persone non possono aprire una presentazione, non possono modificarla né apportare modifiche. 

**Nota** che quando proteggi una presentazione con password per impedirne l'apertura, il file della presentazione viene criptato.

## **Come proteggere con password una presentazione online**

1. Vai alla nostra pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Fai clic su **Drop or upload your files**.

3. Seleziona il file che desideri proteggere con password sul tuo computer. 

4. Inserisci la password desiderata per la protezione di modifica; Inserisci la password desiderata per la protezione di visualizzazione. 

5. Se desideri che gli utenti vedano la tua presentazione come copia finale, seleziona la casella di controllo **Mark as final**.

6. Fai clic su **PROTECT NOW.** 

7. Fai clic su **DOWNLOAD NOW.**

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni nei seguenti formati: 

- PPTX e PPT - Presentazione Microsoft PowerPoint 
- ODP - Presentazione OpenDocument 
- OTP - Modello di presentazione OpenDocument 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche in questi modi:

- Crittografare una presentazione
- Impostare una protezione di scrittura su una presentazione

**Altre operazioni**

Aspose.Slides permette di eseguire altre attività relative alla protezione con password e alla crittografia nei seguenti modi:

- Decriptare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione di scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

## **Crittografare una presentazione**

Puoi crittografare una presentazione impostando una password. Per modificare la presentazione bloccata, l'utente deve fornire la password. 

Per crittografare o proteggere con password una presentazione, devi utilizzare il metodo encrypt (da [ProtectionManager](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager)) per impostare una password per la presentazione. Passi la password al metodo encrypt e utilizzi il metodo save per salvare la presentazione ora crittografata. 

Questo codice di esempio mostra come crittografare una presentazione:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Impostare la protezione di scrittura su una presentazione** 

Puoi aggiungere una dicitura “Do not modify” a una presentazione. In questo modo informi gli utenti che non desideri che apportino modifiche alla presentazione.  

**Nota** che il processo di protezione di scrittura non cripta la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso. 

Per impostare una protezione di scrittura, devi utilizzare il metodo setWriteProtection. Questo codice di esempio mostra come impostare una protezione di scrittura su una presentazione:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Caricare una presentazione crittografata**

Aspose.Slides consente di caricare un file crittografato passando la sua password. Per decrittare una presentazione, è necessario chiamare il metodo [RemoveEncryption](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione. 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// lavora con la presentazione decrittata
```

## **Rimuovere la crittografia da una presentazione**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni. 

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [RemoveEncryption](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Questo codice di esempio mostra come rimuovere la crittografia da una presentazione:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Rimuovere la protezione di scrittura da una presentazione**

Puoi utilizzare Aspose.Slides per rimuovere la protezione di scrittura utilizzata su un file di presentazione. In questo modo, gli utenti possono modificare a loro piacere—e non ricevono avvisi quando eseguono tali operazioni.

Puoi rimuovere la protezione di scrittura da una presentazione usando il metodo [RemoveWriteProtection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Questo codice di esempio mostra come rimuovere la protezione di scrittura da una presentazione:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Ottenere le proprietà di una presentazione crittografata**

In genere, gli utenti hanno difficoltà a recuperare le proprietà del documento di una presentazione crittografata o protetta da password. Tuttavia, Aspose.Slides fornisce un meccanismo che consente di proteggere con password una presentazione mantenendo l'accesso alle sue proprietà del documento.

**Nota:** Per impostazione predefinita, quando Aspose.Slides cripta una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se è necessario rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides consente di farlo.

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione crittografata, passa `false` al metodo `set_EncryptDocumentProperties` di [IProtectionManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprotectionmanager/). Questo codice di esempio mostra come crittografare una presentazione mantenendo l'accesso degli utenti alle sue proprietà del documento:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Caricare solo le proprietà del documento da una presentazione crittografata**

Per ispezionare i metadati di una presentazione crittografata senza caricare le sue diapositive o altri contenuti, crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/) e imposta [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) su `true`. In questa modalità, Aspose.Slides ignora la password e carica solo le proprietà del documento accessibili pubblicamente.

Il seguente esempio di codice legge le proprietà del documento predefinite e personalizzate tramite [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Questo flusso di lavoro funziona solo quando le proprietà del documento sono state lasciate non crittografate (pubbliche) al momento della crittografia della presentazione. Se le proprietà del documento sono crittografate, impostare `LoadOptions::set_OnlyLoadDocumentProperties` su `true` genera un'eccezione perché la password viene ignorata in questa modalità. Per accedere alle proprietà del documento crittografate o caricare la presentazione completa, incluse diapositive e altri contenuti, fornisci la password corretta con `LoadOptions::set_Password` in [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/).

## **Verificare se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia stata protetta con una password. In questo modo eviti errori e problemi simili, che si verificano quando una presentazione protetta da password viene caricata senza la password.

Questo codice C++ mostra come esaminare una presentazione per verificare se è protetta da password (senza caricare la presentazione stessa):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Verificare se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare il metodo [get_IsEncrypted()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), che restituisce `true` se la presentazione è crittografata o `false` se non lo è. 

Questo codice di esempio mostra come verificare se una presentazione è crittografata:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Verificare se una presentazione è protetta da scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta da scrittura. Per eseguire questa operazione, puoi utilizzare il metodo [get_IsWriteProtected()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), che restituisce `true` se la presentazione è protetta da scrittura o `false` se non lo è. 

Questo codice di esempio mostra come verificare se una presentazione è protetta da scrittura:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verificare l'uso della password sulla presentazione**

Potresti voler verificare e confermare che una specifica password sia stata utilizzata per proteggere un documento di presentazione. Aspose.Slides offre gli strumenti per convalidare una password. 

Questo codice di esempio mostra come convalidare una password:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// verifica se "pass" corrisponde a
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata. Altrimenti, restituisce `false`. 

{{% alert color="primary" title="Vedi anche" %}} 
- [Digital Signature in PowerPoint](/slides/it/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi gli algoritmi basati su AES, garantendo un elevato livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle tue attività di presentazione.