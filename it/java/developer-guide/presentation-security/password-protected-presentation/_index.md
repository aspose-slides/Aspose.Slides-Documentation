---
title: Proteggere le presentazioni con password in Java
linktitle: Protezione password
type: docs
weight: 20
url: /it/java/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- crittografare PowerPoint
- decrittografare PowerPoint
- convalidare password della presentazione
- verificare password della presentazione
- aprire presentazione crittografata
- rimuovere crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- Java
- Aspose.Slides
description: "Crittografa, rileva, convalida, apri e decrittografa presentazioni PowerPoint PPT e PPTX protette da password in Java con Aspose.Slides."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione garantisce la riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita la modifica ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Proteggi da scrittura le presentazioni](/slides/it/java/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia a presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati quando è importante il comportamento basato su file o su stream.

## **Crittografa una presentazione con una password di apertura**

Utilizzare [IProtectionManager.encrypt](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) per assegnare una password di apertura. Quindi utilizzare [IPresentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) per salvare la presentazione crittografata.

L'esempio seguente cripta una presentazione PPTX:

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

## **Carica una presentazione crittografata**

Impostare [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) sulla password di apertura e passare le opzioni a [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Lavorare con la presentazione decrittografata.
} finally {
    presentation.dispose();
}
```

## **Rimuovi la crittografia da una presentazione**

Caricare la presentazione con la sua password di apertura, chiamare [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) e salvare il risultato. La presentazione salvata può quindi essere caricata senza password.

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

Utilizzare [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) per ottenere [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/) senza creare un'istanza completa della presentazione. Verificare [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) prima di richiedere o convalidare una password. Quando è presente una protezione, convalidare il valore fornito con [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Flusso di lavoro basato su percorso file**

L'esempio seguente convalida una password di apertura per un file PPTX, passa il valore convalidato a [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-), quindi carica la presentazione completa:

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

La sovraccarico stream di [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) fornisce lo stesso flusso di lavoro. Reimpostare la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

L'esempio seguente utilizza un file PPT:

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) restituisce `true` solo quando la presentazione dispone di una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno dei seguenti casi:

- La password è errata.
- La presentazione non dispone di una password di apertura.
- La password fornita è `null` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispezionare [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) per confermare che la presentazione originale fosse crittografata. Per rilevare la protezione con password di apertura prima del caricamento, utilizzare `IPresentationInfo.isPasswordProtected` come mostrato sopra.

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

{{% alert color="warning" title="Sicurezza" %}}
Non registrare le password di apertura né includerle in messaggi diagnostici. Evitare tentativi di convalida ripetuti e non necessari, mantenere le password in memoria solo per il tempo strettamente necessario e riutilizzare un risultato di convalida riuscito quando si carica immediatamente la presentazione.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Apri l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
2. Seleziona o carica la presentazione.
3. Inserisci una password per la protezione della visualizzazione.
4. Facoltativamente inserisci una password separata per la protezione della modifica.
5. Applica la protezione e scarica il file risultante.

{{% alert color="info" title="Vedi anche" %}}
- [Proteggi da scrittura le presentazioni](/slides/it/java/write-protected-presentation/)
- [Firma digitale in PowerPoint](/slides/it/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita la modifica senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottieni le informazioni della presentazione, verifica se è presente una protezione con password di apertura e convalida la password prima di creare un'istanza completa della presentazione.

**I flussi di lavoro per il controllo della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.