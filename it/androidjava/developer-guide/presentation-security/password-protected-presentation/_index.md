---
title: Proteggi con password le presentazioni su Android
linktitle: Protezione con password
type: docs
weight: 20
url: /it/androidjava/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- cifrare PowerPoint
- decifrare PowerPoint
- convalidare la password della presentazione
- verificare la password della presentazione
- aprire presentazione crittografata
- rimuovere la crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- Android
- Java
- Aspose.Slides
description: "Cifra, rileva, convalida, apri e decifra presentazioni PowerPoint PPT e PPTX protette da password con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita la modifica ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/androidjava/write-protected-presentation/).

I flussi di lavoro di seguito si applicano sia alle presentazioni PPT che PPTX. Gli esempi usano entrambi i formati dove il comportamento basato su file e su stream è importante.

## **Crittografa una presentazione con una password di apertura**

Utilizzare [IProtectionManager.encrypt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) per assegnare una password di apertura. Quindi utilizzare [IPresentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) per salvare la presentazione crittografata.

L'esempio seguente crittografa una presentazione PPTX:

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

Impostare [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) alla password di apertura e passare le opzioni a [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

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

## **Rimuovere la crittografia da una presentazione**

Caricare la presentazione con la sua password di apertura, chiamare [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) e salvare il risultato. La presentazione salvata può quindi essere caricata senza password.

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

## **Convalidare una password di apertura prima del caricamento**

Utilizzare [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) per ottenere [IPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/) senza creare un'istanza completa della presentazione. Verificare [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) prima di richiedere o convalidare una password. Quando è presente una protezione, convalidare il valore fornito con [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-).

### **Flusso di lavoro con percorso file**

L'esempio seguente convalida una password di apertura per un file PPTX, passa il valore convalidato a [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) e quindi carica la presentazione completa:

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

### **Flusso di lavoro con stream**

La sovraccarico stream di [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) fornisce lo stesso flusso di lavoro. Reimpostare la posizione di uno stream seekable prima di caricare la presentazione completa da quello stream.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) restituisce `true` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è `null` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verificare se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispezionare [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) per confermare che la presentazione di origine era crittografata. Per rilevare la protezione con password di apertura prima del caricamento, utilizzare `IPresentationInfo.isPasswordProtected` come mostrato sopra.

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

## **Security Recommendations**

{{% alert color="warning" title="Security" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti non necessari, mantenere le password in memoria solo per il tempo necessario e riutilizzare un risultato di convalida riuscito quando si carica immediatamente la presentazione.
{{% /alert %}}

## **Password-Protect a Presentation Online**

1. Aprire l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Selezionare o caricare la presentazione.
1. Inserire una password per la protezione della visualizzazione.
1. Facoltativamente inserire una password diversa per la protezione della modifica.
1. Applicare la protezione e scaricare il file risultante.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/it/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/it/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita la modifica senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottenere le informazioni della presentazione, verificare se è presente la protezione con password di apertura e convalidare la password prima di creare un'istanza completa della presentazione.

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.