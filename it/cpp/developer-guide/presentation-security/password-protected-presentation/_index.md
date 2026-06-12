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
- C++
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per C++. Proteggi le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con password, imposti una password che applica determinate restrizioni sulla presentazione. Per rimuovere le restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, è possibile impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

  Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione (a meno che non forniscano la password). 

  Tuttavia, in questo caso, anche senza password, un utente potrà accedere al documento e aprirlo. In modalità di sola lettura, l'utente può visualizzare il contenuto o elementi—collegamenti ipertestuali, animazioni, effetti e altri—all'interno della presentazione, ma non può copiare elementi né salvare la presentazione. 

- **Apertura**

  Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare il contenuto della presentazione (a meno che non forniscano la password).

  Tecnica­mente, la restrizione di apertura impedisce anche agli utenti di modificare le presentazioni: quando le persone non possono aprire una presentazione, non possono modificarla o apportare modifiche. 
  
  **Nota**: quando proteggi una presentazione con password per impedirne l'apertura, il file della presentazione diventa crittografato.

## **Come proteggere con password una presentazione online**

1. Vai alla nostra pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Fai clic su **Trascina o carica i tuoi file**.

3. Seleziona il file che desideri proteggere con password sul tuo computer. 

4. Inserisci la password preferita per la protezione della modifica; Inserisci la password preferita per la protezione della visualizzazione. 

5. Se desideri che gli utenti vedano la tua presentazione come copia finale, spunta la casella di controllo **Segna come finale**.

6. Fai clic su **PROTEGGI ORA.** 

7. Fai clic su **SCARICA ORA.**

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni in questi formati: 

- PPTX e PPT - Presentazione Microsoft PowerPoint 
- ODP - Presentazione OpenDocument 
- OTP - Modello di Presentazione OpenDocument 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedirne le modifiche in questi modi:

- Crittografare una presentazione
- Impostare una protezione di scrittura su una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre attività relative alla protezione con password e alla crittografia in questi modi:

- Decrittografare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione di scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

## **Crittografa una presentazione**

Puoi crittografare una presentazione impostando una password. Successivamente, per modificare la presentazione bloccata, l'utente deve fornire la password. 

Per crittografare o proteggere con password una presentazione, devi utilizzare il metodo encrypt (da [ProtectionManager](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager)) per impostare una password per la presentazione. Passi la password al metodo encrypt e usi il metodo save per salvare la presentazione ora crittografata. 

Questo esempio di codice mostra come crittografare una presentazione:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Imposta la protezione di scrittura su una presentazione** 

Puoi aggiungere un'indicazione “Non modificare” a una presentazione. In questo modo, informi gli utenti che non vuoi che apportino modifiche alla presentazione.  

**Nota**: il processo di protezione di scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso. 

Per impostare una protezione di scrittura, devi utilizzare il metodo setWriteProtection. Questo esempio di codice mostra come impostare una protezione di scrittura su una presentazione:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Carica una presentazione crittografata**

Aspose.Slides consente di caricare un file crittografato fornendo la sua password. Per decrittografare una presentazione, devi chiamare il metodo [RemoveEncryption](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione. 

Questo esempio di codice mostra come decrittografare una presentazione: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// lavora con la presentazione decrittografata
```

## **Rimuovi la crittografia da una presentazione**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni. 

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [RemoveEncryption](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Rimuovi la protezione di scrittura da una presentazione**

Puoi utilizzare Aspose.Slides per rimuovere la protezione di scrittura utilizzata su un file di presentazione. In questo modo, gli utenti possono modificare a loro piacere—senza alcun avviso durante tali operazioni.

Puoi rimuovere la protezione di scrittura da una presentazione usando il metodo [RemoveWriteProtection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Questo esempio di codice mostra come rimuovere la protezione di scrittura da una presentazione:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Ottieni le proprietà di una presentazione crittografata**

Tipicamente, gli utenti hanno difficoltà a ottenere le proprietà del documento di una presentazione crittografata o protetta da password. Aspose.Slides, tuttavia, offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle proprietà di tale presentazione.

**Nota**: quando Aspose.Slides crittografa una presentazione, le proprietà del documento della presentazione vengono anch'esse protette da password per impostazione predefinita. Ma se è necessario rendere le proprietà della presentazione accessibili (anche dopo che la presentazione è stata crittografata), Aspose.Slides consente di farlo esattamente. 

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione che hai crittografato, puoi passare `true` al metodo [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Questo esempio di codice mostra come crittografare una presentazione fornendo ai clienti il modo di accedere alle sue proprietà del documento:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Verifica se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia stata protetta da password. In questo modo, eviti errori e problemi analoghi che si verificano quando una presentazione protetta da password viene caricata senza la relativa password.

Questo codice C++ mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Verifica se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi usare il metodo [get_IsEncrypted()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), che restituisce `true` se la presentazione è crittografata o `false` se non lo è. 

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Verifica se una presentazione è protetta da scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta da scrittura. Per eseguire questa operazione, puoi usare il metodo [get_IsWriteProtected()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), che restituisce `true` se la presentazione è protetta da scrittura o `false` se non lo è. 

Questo esempio di codice mostra come verificare se una presentazione è protetta da scrittura:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verifica l'uso della password della presentazione**

Potresti voler verificare e confermare che una password specifica sia stata utilizzata per proteggere un documento di presentazione. Aspose.Slides fornisce i mezzi per convalidare una password. 

Questo esempio di codice mostra come convalidare una password:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// verifica se "pass" corrisponde
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata. Altrimenti, restituisce `false`. 

{{% alert color="primary" title="Vedi anche" %}} 
- [Firma digitale in PowerPoint](/slides/it/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi gli algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

**Cosa accade se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in maniera significativa sul tempo di elaborazione complessivo delle attività di presentazione.