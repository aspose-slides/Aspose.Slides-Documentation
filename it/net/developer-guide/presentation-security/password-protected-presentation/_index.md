---
title: Proteggi le presentazioni con password in .NET
linktitle: Protezione password
type: docs
weight: 20
url: /it/net/password-protected-presentation/
keywords:
- presentazione protetta da password
- password di apertura
- cifratura PowerPoint
- decifra PowerPoint
- convalida password presentazione
- verifica password presentazione
- apri presentazione crittografata
- rimuovi crittografia
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

Una password di apertura crittografa una presentazione. La password corretta è necessaria per caricare e visualizzare il contenuto della presentazione, quindi questa protezione fornisce la riservatezza.

Una password di apertura è diversa da una password di protezione in scrittura. La protezione in scrittura limita le modifiche ma non crittografa il contenuto né impedisce il caricamento della presentazione. Per gestire le password per la modifica delle presentazioni, vedere [Write-Protect Presentations](/slides/it/net/write-protected-presentation/).

I flussi di lavoro seguenti si applicano sia alle presentazioni PPT sia a quelle PPTX. Gli esempi utilizzano entrambi i formati quando il loro comportamento basato su file o su stream è importante.

## **Crittografa una Presentazione con una Password di Apertura**

Usa [IProtectionManager.Encrypt](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/encrypt/) per assegnare una password di apertura. Quindi usa [IPresentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/save/) per salvare la presentazione crittografata.

Il seguente esempio cripta una presentazione PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Carica una Presentazione Crittografata**

Imposta [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/) sulla password di apertura e passa le opzioni a [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) durante il caricamento del file. Il caricamento fallisce quando è richiesta una password di apertura ma la password fornita è mancante o errata.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Lavora con la presentazione decrittata.
```

## **Rimuovi la Crittografia da una Presentazione**

Carica la presentazione con la sua password di apertura, chiama [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/removeencryption/) e salva il risultato. La presentazione salvata può quindi essere caricata senza password.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Convalida una Password di Apertura Prima del Caricamento**

Usa [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationfactory/getpresentationinfo/) per ottenere [IPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/) senza creare un'istanza completa della presentazione. Controlla [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/ispasswordprotected/) prima di richiedere o convalidare una password. Quando la protezione è presente, convalida il valore fornito con [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Flusso di Lavoro con Percorso File**

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

### **Flusso di Lavoro con Stream**

La sovraccarico con stream di [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationfactory/getpresentationinfo/) fornisce lo stesso flusso di lavoro. Ripristina la posizione di uno stream ricercabile prima di caricare la presentazione completa da quello stream.

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

### **Valori di Ritorno di CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/checkpassword/) restituisce `true` solo quando la presentazione ha una password di apertura e la password fornita è corretta. Restituisce `false` in ciascuno di questi casi:

- La password è errata.
- La presentazione non ha una password di apertura.
- La password fornita è `null` o vuota.

Il comportamento è lo stesso per le presentazioni PPT e PPTX.

## **Verifica se una Presentazione Caricata è Crittografata**

Dopo aver caricato una presentazione con la password corretta, verifica [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/isencrypted/) per confermare che la presentazione originale fosse crittografata. Per rilevare la protezione con password di apertura prima del caricamento, utilizza `IPresentationInfo.IsPasswordProtected` come mostrato sopra.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Raccomandazioni di Sicurezza**

{{% alert color="warning" title="Security" %}}
Non registrare le password di apertura né includerle nei messaggi diagnostici. Evita tentativi di convalida ripetuti non necessari, mantieni le password in memoria solo per il tempo necessario e riutilizza un risultato di convalida riuscito quando carichi immediatamente la presentazione.
{{% /alert %}}

## **Proteggi con Password una Presentazione Online**

1. Apri l'applicazione [Aspose.Slides Lock](https://products.aspose.app/slides/it/lock).
1. Seleziona o carica la presentazione.
1. Inserisci una password per la protezione della visualizzazione.
1. Facoltativamente inserisci una password separata per la protezione della modifica.
1. Applica la protezione e scarica il file risultante.

{{% alert color="info" title="See also" %}}
- [Proteggi da Scrittura le Presentazioni](/slides/it/net/write-protected-presentation/)
- [Firma Digitale in PowerPoint](/slides/it/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual è la differenza tra una password di apertura e una password di protezione in scrittura?**

Una password di apertura cripta la presentazione ed è necessaria per caricare il suo contenuto. Una password di protezione in scrittura limita le modifiche senza crittografare il contenuto.

**Posso convalidare una password di apertura senza caricare tutte le diapositive?**

Sì. Ottieni le informazioni della presentazione, verifica se è presente una protezione con password di apertura e convalida la password prima di creare un'istanza completa della presentazione.

**I flussi di lavoro di verifica della password supportano sia PPT che PPTX?**

Sì. Il rilevamento e la convalida della password basati su percorso file o su stream si comportano allo stesso modo per le presentazioni PPT e PPTX.