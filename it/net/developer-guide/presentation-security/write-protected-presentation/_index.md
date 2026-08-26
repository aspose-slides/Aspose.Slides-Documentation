---
title: Proteggi le presentazioni da scrittura in .NET
linktitle: Protezione da scrittura
type: docs
weight: 25
url: /it/net/write-protected-presentation/
keywords:
- protezione da scrittura
- protezione da scrittura PowerPoint
- password per modificare
- limitare la modifica della presentazione
- rimuovere la protezione da scrittura
- convalidare la password di modifica
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Imposta, rileva, convalida e rimuovi le password di protezione da scrittura nelle presentazioni PowerPoint PPT e PPTX utilizzando Aspose.Slides per .NET."
---
## **Introduzione**

Una password di protezione da scrittura limita la modifica di una presentazione ma non ne cripta il contenuto. Gli utenti possono caricare e visualizzare una presentazione protetta da scrittura senza la password. A seconda dell'applicazione, potrebbero anche essere in grado di modificare il contenuto e salvarlo con un nome diverso, quindi la protezione da scrittura non dovrebbe essere considerata un meccanismo di riservatezza.

Una password di apertura ha uno scopo diverso: cripta la presentazione ed è necessaria per caricare il suo contenuto. Per crittografare una presentazione o convalidare una password di apertura, vedere [Proteggi con password le presentazioni](/slides/it/net/password-protected-presentation/).

I flussi di lavoro in questo articolo si applicano sia alle presentazioni PPT che PPTX. Gli esempi utilizzano file PPTX; quando si salva in PPT, utilizzare l'estensione `.ppt` e il relativo formato di salvataggio PPT.

## **Imposta la protezione da scrittura su una presentazione**

Utilizzare [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/setwriteprotection/) per assegnare una password per la modifica di una presentazione. Salvare la presentazione conserva l'impostazione di protezione.

Il seguente esempio imposta la protezione da scrittura su una presentazione PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Carica una presentazione protetta da scrittura**

Poiché la protezione da scrittura non cripta il contenuto della presentazione, non è necessaria alcuna password per caricare la presentazione. La password è rilevante solo quando si convalida l'autorizzazione a modificare la presentazione protetta.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Non passare una password di protezione da scrittura a [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/). Tale proprietà accetta una password di apertura per contenuti crittografati. Se una presentazione ha entrambi i tipi di protezione, fornire la password di apertura per caricarla e gestire separatamente la password di protezione da scrittura.

## **Rimuovi la protezione da scrittura da una presentazione**

Utilizzare [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/removewriteprotection/) per rimuovere la restrizione di modifica, quindi salvare la presentazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Verifica se una presentazione è protetta da scrittura**

Per ispezionare un file senza creare un'istanza completa di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), chiamare [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationfactory/getpresentationinfo/) e controllare [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/iswriteprotected/). La proprietà utilizza [NullableBool](https://reference.aspose.com/slides/it/net/aspose.slides/nullablebool/) e restituisce `NullableBool.True` quando viene rilevata la protezione da scrittura.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

La sovraccarico per stream di [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationfactory/getpresentationinfo/) fornisce le stessa informazione per una presentazione fornita come stream.

## **Convalida una password di protezione da scrittura**

Utilizzare [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/checkwriteprotection/) per convalidare una password di modifica senza caricare la presentazione completa. Verificare prima [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/iswriteprotected/) in modo che l'applicazione richieda o convalidi una password solo quando è presente la protezione da scrittura.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/checkwriteprotection/) convalida solo la password di protezione da scrittura. Non convalida una password di apertura né determina se il contenuto crittografato può essere caricato. Al contrario, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/checkpassword/) convalida solo una password di apertura. Se una presentazione completa è già stata caricata, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/it/net/aspose.slides/iprotectionmanager/checkwriteprotection/) fornisce la verifica equivalente della protezione da scrittura tramite il suo gestore di protezione.

Nelle applicazioni di produzione, non registrare le password né includerle nei messaggi diagnostici. Evitare tentativi di convalida ripetuti non necessari e conservare le password in memoria solo per il tempo strettamente necessario.

{{% alert color="info" title="See also" %}}
- [Proteggi con password le presentazioni](/slides/it/net/password-protected-presentation/)
- [Presentazioni in sola lettura](/slides/it/net/read-only-presentation/)
- [Firma digitale in PowerPoint](/slides/it/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protezione da scrittura cripta una presentazione?**

No. Limita la modifica ma lascia il contenuto della presentazione disponibile per il caricamento e la visualizzazione.

**La password di protezione da scrittura è necessaria per aprire una presentazione?**

No. È necessaria solo una password di apertura per caricare il contenuto crittografato della presentazione.

**Una presentazione può avere sia una password di apertura sia una password di protezione da scrittura?**

Sì. Fornire la password di apertura tramite le opzioni di caricamento per aprire la presentazione crittografata e convalidare separatamente la password di protezione da scrittura quando è necessaria l'autorizzazione alla modifica.