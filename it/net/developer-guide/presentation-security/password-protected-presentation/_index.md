---
title: Presentazioni protette da password in .NET
linktitle: Protezione password
type: docs
weight: 20
url: /it/net/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- cifrare PowerPoint
- decifrare PowerPoint
- convalidare password della presentazione
- verificare password della presentazione
- aprire presentazione crittografata
- rimuovere crittografia
- PowerPoint
- PPT
- PPTX
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Cifra, rileva, convalida, apri e decifra presentazioni PowerPoint PPT e PPTX protette da password in C# con Aspose.Slides per .NET."
---
## **Panoramica**

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione garantisce la riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita la modifica ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/net/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano entrambi i formati quando è importante il loro comportamento basato su file o su stream.

## **Crittografa una presentazione con una password di apertura**

Utilizzare [IProtectionManager.Encrypt](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/encrypt/) per assegnare una password di apertura. Quindi utilizzare [IPresentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/save/) per salvare la presentazione crittografata.

Il seguente esempio crittografa una presentazione PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Mantieni pubbliche le proprietà del documento**

Per impostazione predefinita, Aspose.Slides include le proprietà del documento nella crittografia della presentazione. La proprietà [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) controlla questo comportamento in modo indipendente dalla crittografia del contenuto delle diapositive. Impostarla su `false` prima di chiamare [IProtectionManager.Encrypt](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/encrypt/) quando un sistema di indicizzazione, classificazione, ricerca o gestione dei documenti deve leggere i metadati senza la password di apertura.

Il seguente esempio crea una presentazione PPTX crittografata lasciando pubbliche le sue proprietà integrate del documento:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Impostare `EncryptDocumentProperties` su `false` non rende pubbliche diapositive, master, layout, forme, media o altri contenuti della presentazione. Influisce solo sulle proprietà del documento. Per leggere tali proprietà senza caricare il contenuto crittografato, vedere [Manage Presentation Properties](/slides/it/net/presentation-properties/).

## **Carica una presentazione crittografata**

Impostare [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/) sulla password di apertura e passare le opzioni a [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Lavora con la presentazione decrittata.
```

## **Rimuovi la crittografia da una presentazione**

Caricare la presentazione con la sua password di apertura, chiamare [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/removeencryption/) e salvare il risultato. La presentazione salvata può quindi essere caricata senza una password.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Convalida una password di apertura prima del caricamento**

Utilizzare [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationfactory/getpresentationinfo/) per ottenere [IPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/) senza creare un'istanza completa della presentazione. Verificare [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/ispasswordprotected/) prima di richiedere o convalidare una password. Quando la protezione è presente, convalidare il valore fornito con [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Flusso di lavoro con percorso file**

Il seguente esempio convalida una password di apertura per un file PPTX, passa il valore convalidato a [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/) e quindi carica la presentazione completa:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Flusso di lavoro con stream**

La sovraccarico basata su stream di [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationfactory/getpresentationinfo/) fornisce lo stesso flusso di lavoro. Resettare la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

Il seguente esempio utilizza un file PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Valori di ritorno di CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/checkpassword/) restituisce `true` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è `null` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una presentazione caricata è crittografata**

Dopo aver caricato una presentazione con la password corretta, ispezionare [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/isencrypted/) per confermare che la presentazione di origine fosse crittografata. Per rilevare la protezione con password di apertura prima del caricamento, utilizzare `IPresentationInfo.IsPasswordProtected` come mostrato sopra.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Raccomandazioni di sicurezza**

{{% alert color="warning" title="Security" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti non necessari, mantenere le password in memoria solo per il tempo necessario e riutilizzare un risultato di convalida riuscito quando si carica immediatamente la presentazione.

Le proprietà pubbliche del documento possono rivelare nomi degli autori, titoli, soggetti, parole chiave, informazioni aziendali, commenti e valori personalizzati anche se il contenuto della presentazione è crittografato. Crittografare i metadati sensibili insieme alla presentazione. Lasciare le proprietà pubbliche dovrebbe essere una decisione esplicita presa solo quando i sistemi devono indicizzare, classificare, cercare o gestire il file senza una password di apertura.
{{% /alert %}}

## **Proteggi con password una presentazione online**

1. Aprire l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Selezionare o caricare la presentazione.
1. Inserire una password per la protezione della visualizzazione.
1. Facoltativamente inserire una password separata per la protezione della modifica.
1. Applicare la protezione e scaricare il file risultante.

{{% alert color="info" title="See also" %}}
- [Proteggi in scrittura le presentazioni](/slides/it/net/write-protected-presentation/)
- [Firma digitale in PowerPoint](/slides/it/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura crittografa la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita la modifica senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottenere le informazioni sulla presentazione, verificare se è presente la protezione con password di apertura e convalidare la password prima di creare un'istanza completa della presentazione.

**Un'applicazione può leggere i metadati senza la password di apertura?**

Sì, ma solo quando la presentazione è stata crittografata con `EncryptDocumentProperties` impostato su `false`. L'applicazione deve quindi utilizzare la modalità di caricamento solo delle proprietà del documento descritta in [Manage Presentation Properties](/slides/it/net/presentation-properties/).

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file e su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.