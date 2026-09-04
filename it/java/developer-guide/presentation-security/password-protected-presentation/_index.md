---
title: Presentazioni protette da password in Java
linktitle: Protezione con password
type: docs
weight: 20
url: /it/java/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- crittografa PowerPoint
- decrittografa PowerPoint
- convalida password della presentazione
- verifica password della presentazione
- apri presentazione crittografata
- rimuovi crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- Java
- Aspose.Slides
description: "Crittografa, rileva, convalida, apre e decrittografa le presentazioni PowerPoint PPT e PPTX protette da password in Java con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita la modifica ma non cripta il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, consultare [Presentazioni protette da scrittura](/slides/it/java/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia a presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati quando è importante il loro comportamento basato su file o su stream.

## **Crittografa una presentazione con una password di apertura**

Usa [IProtectionManager.encrypt](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) per assegnare una password di apertura. Quindi usa [IPresentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) per salvare la presentazione crittografata.

Il seguente esempio cripta una presentazione PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mantieni le proprietà del documento pubbliche**

Per impostazione predefinita, Aspose.Slides include le proprietà del documento nella crittografia della presentazione. Il metodo [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) controlla questo comportamento in modo indipendente dalla crittografia del contenuto delle diapositive. Passa `false` prima di chiamare [IProtectionManager.encrypt](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) quando un sistema di indicizzazione, classificazione, ricerca o gestione dei documenti deve leggere i metadati senza la password di apertura.

Il seguente esempio crea una presentazione PPTX crittografata lasciando pubbliche le sue proprietà di documento incorporate:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Passare `false` a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) non rende pubblici diapositive, master, layout, forme, media o altri contenuti della presentazione. Influisce solo sulle proprietà del documento. Per leggere tali proprietà senza caricare il contenuto crittografato, vedere [Gestisci le proprietà della presentazione](/slides/it/java/presentation-properties/).

## **Carica una presentazione crittografata**

Imposta [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) alla password di apertura e passa le opzioni a [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Lavora con la presentazione decrittata.
} finally {
    presentation.dispose();
}
```

## **Rimuovi la crittografia da una presentazione**

Carica la presentazione con la sua password di apertura, chiama [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#removeEncryption--), e salva il risultato. La presentazione salvata può poi essere caricata senza password.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Convalida una password di apertura prima del caricamento**

Usa [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) per ottenere [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/) senza creare un'istanza completa della presentazione. Controlla [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) prima di richiedere o convalidare una password. Quando è presente la protezione, convalida il valore fornito con [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Flusso di lavoro basato su percorso file**

Il seguente esempio convalida una password di apertura per un file PPTX, passa il valore convalidato a [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), quindi carica la presentazione completa:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Flusso di lavoro basato su stream**

La sovraccarico stream di [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) fornisce lo stesso flusso di lavoro. Reimposta la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

Il seguente esempio utilizza un file PPT:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **Valori di ritorno di checkPassword**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) restituisce `true` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è `null` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispeziona [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) per confermare che la presentazione di origine fosse crittografata. Per rilevare la protezione da password di apertura prima del caricamento, usa `IPresentationInfo.isPasswordProtected` come mostrato sopra.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Raccomandazioni di sicurezza**

{{% alert color="warning" title="Security" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evita tentativi ripetuti non necessari di convalida, mantieni le password in memoria solo per il tempo strettamente necessario e riutilizza un risultato di convalida riuscito quando si carica immediatamente la presentazione.

Le proprietà pubbliche del documento possono rivelare nomi degli autori, titoli, soggetti, parole chiave, informazioni aziendali, commenti e valori personalizzati anche se il contenuto della presentazione è crittografato. Cripta i metadati sensibili insieme alla presentazione. Lasciare le proprietà pubbliche dovrebbe essere una decisione esplicita presa solo quando i sistemi devono indicizzare, classificare, cercare o gestire il file senza una password di apertura.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Apri l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
2. Seleziona o carica la presentazione.
3. Inserisci una password per la protezione della visualizzazione.
4. Facoltativamente inserisci una password separata per la protezione della modifica.
5. Applica la protezione e scarica il file risultante.

{{% alert color="info" title="See also" %}}
- [Presentazioni protette da scrittura](/slides/it/java/write-protected-presentation/)
- [Firma digitale in PowerPoint](/slides/it/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura cripta la presentazione ed è necessaria per caricarne il contenuto. Una password di protezione in scrittura limita la modifica senza criptare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottieni le informazioni della presentazione, verifica se è presente la protezione da password di apertura e convalida la password prima di creare un'istanza completa della presentazione.

**Un'applicazione può leggere i metadati senza la password di apertura?**

Sì, ma solo quando la presentazione è stata crittografata con la crittografia delle proprietà del documento disabilitata. L'applicazione deve quindi utilizzare la modalità di caricamento solo per le proprietà del documento descritta in [Gestisci le proprietà della presentazione](/slides/it/java/presentation-properties/).

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.