---
title: Presentazioni sicure con password in Java
linktitle: Protezione con password
type: docs
weight: 20
url: /it/java/password-protected-presentation/
keywords:
- blocca PowerPoint
- blocca presentazione
- sblocca PowerPoint
- sblocca presentazione
- proteggi PowerPoint
- proteggi presentazione
- imposta password
- aggiungi password
- cripta PowerPoint
- cripta presentazione
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
- Java
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per Java. Metti al sicuro le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con password, imposti una password che applica determinate restrizioni alla presentazione. Per rimuovere queste restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

In genere, puoi impostare una password per far rispettare queste restrizioni su una presentazione:

- **Modifica**

Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella presentazione a meno che non forniscano la password.

Tuttavia, anche senza la password, un utente potrà comunque accedere e aprire il documento. In questa modalità di sola lettura, l'utente può visualizzare il contenuto—including hyperlink, animazioni, effetti e altri elementi—della presentazione, ma non può copiare elementi né salvare la presentazione.

- **Apertura**

Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare il contenuto della presentazione a meno che non forniscano la password.

Tecnicamente, la restrizione di apertura impedisce anche la modifica della presentazione: se le persone non possono aprire una presentazione, non possono modificarla né apportare cambiamenti.

**Nota:** Quando proteggi una presentazione con password per impedirne l'apertura, il file della presentazione diventa crittografato.

## **Protezione con password in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni nei seguenti formati:

- PPTX e PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Operazioni supportate**

Aspose.Slides ti consente di utilizzare la protezione con password su presentazioni per impedire modifiche in questi modi:

- Crittografia di una presentazione
- Impostazione di una protezione in scrittura su una presentazione

**Altre operazioni**

Aspose.Slides ti permette di eseguire altre attività relative a protezione con password e crittografia in questi modi:

- Decrittazione di una presentazione; apertura di una presentazione crittografata
- Rimozione della crittografia; disabilitazione della protezione con password
- Rimozione della protezione in scrittura da una presentazione
- Ottenimento delle proprietà di una presentazione crittografata
- Verifica se una presentazione è crittografata
- Verifica se una presentazione è protetta da password.

## **Proteggi una presentazione con password**

Puoi crittografare una presentazione impostando una password. Poi, per modificare la presentazione bloccata, l'utente deve fornire la password.

Per crittografare o proteggere con password una presentazione, devi utilizzare il metodo encrypt (da [IProtectionManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager)) per impostare una password per la presentazione. Passi la password al metodo encrypt e usi il metodo save per salvare la presentazione ora crittografata.

Questo frammento di codice mostra come crittografare una presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Imposta la protezione in scrittura su una presentazione**

Puoi aggiungere un marchio “Do not modify” a una presentazione. In questo modo, indichi agli utenti che non vuoi che apportino modifiche alla presentazione.

**Nota** il processo di protezione in scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono ancora modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso.

Per impostare una protezione in scrittura, devi utilizzare il metodo [setWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Questo frammento di codice mostra come impostare una protezione in scrittura su una presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Carica una presentazione crittografata**

Aspose.Slides ti consente di caricare una presentazione crittografata passando la password corretta tramite [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/).

Questo frammento di codice mostra come caricare una presentazione crittografata:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // lavorare con la presentazione decrittografata
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Rimuovi la crittografia da una presentazione**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni.

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#removeEncryption--) . Questo frammento di codice mostra come rimuovere la crittografia da una presentazione:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Rimuovi la protezione in scrittura da una presentazione**

Puoi usare Aspose.Slides per rimuovere la protezione in scrittura usata su un file di presentazione. In questo modo, gli utenti possono modificare come desiderano—e non ricevono avvisi quando compiono tali operazioni.

Puoi rimuovere la protezione in scrittura da una presentazione utilizzando il metodo [removeWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Questo frammento di codice mostra come rimuovere la protezione in scrittura da una presentazione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ottieni le proprietà di una presentazione crittografata**

In genere, gli utenti hanno difficoltà a recuperare le proprietà del documento di una presentazione crittografata o protetta da password. Tuttavia, Aspose.Slides offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle sue proprietà.

**Nota:** Per impostazione predefinita, quando Aspose.Slides cripta una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se hai bisogno di rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides ti permette di farlo.

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione crittografata, passa `false` a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Questo frammento di codice mostra come crittografare una presentazione mantenendo l'accesso degli utenti alle proprietà del documento:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Carica solo le proprietà del documento da una presentazione crittografata**

Per ispezionare i metadati di una presentazione crittografata senza caricare le sue diapositive o altri contenuti, crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/) e passa `true` a [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In questa modalità, Aspose.Slides ignora la password e carica solo le proprietà del documento che sono pubblicamente accessibili.

Il seguente esempio di codice legge le proprietà del documento predefinite e personalizzate tramite [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Leggi le proprietà del documento predefinite.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Leggi le proprietà del documento personalizzate.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Questo flusso di lavoro funziona solo quando le proprietà del documento erano rimaste non crittografate (pubbliche) al momento della crittografia della presentazione. Se le proprietà del documento sono crittografate, il passare `true` a `loadOptions.setOnlyLoadDocumentProperties` genera un'eccezione perché la password è ignorata in questa modalità. Per accedere a proprietà del documento crittografate o per caricare la presentazione completa, incluse diapositive e altri contenuti, fornisci la password corretta tramite [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Verifica se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia stata protetta da password. In questo modo eviti errori e problemi simili che si verificano quando si carica una presentazione protetta da password senza fornire la password.

Questo codice Java mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Verifica se una presentazione è crittografata**

Aspose.Slides ti permette di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare la proprietà [isEncrypted](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#isEncrypted--) , che restituisce `true` se la presentazione è crittografata o `false` se non lo è.

Questo frammento di codice mostra come verificare se una presentazione è crittografata:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verifica se una presentazione è protetta in scrittura**

Aspose.Slides ti permette di verificare se una presentazione è protetta in scrittura. Per eseguire questa operazione, puoi utilizzare la proprietà [isWriteProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#isWriteProtected--) , che restituisce `true` se la presentazione è protetta in scrittura o `false` se non lo è.

Questo frammento di codice mostra come verificare se una presentazione è protetta in scrittura:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Convalida o conferma che una password specifica sia stata usata**

Potresti voler verificare e confermare che una password specifica sia stata utilizzata per proteggere un documento di presentazione. Aspose.Slides fornisce i mezzi per convalidare una password.

Questo frammento di codice mostra come convalidare una password:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // verifica se "pass" corrisponde
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Restituisce `true` se la presentazione è stata protetta in scrittura con la password specificata. Altrimenti, restituisce `false`.

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/it/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene sollevata un'eccezione se viene usata una password errata, segnalando che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle tue attività sulla presentazione.