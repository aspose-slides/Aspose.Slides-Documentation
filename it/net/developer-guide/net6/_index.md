---
title: Supporto .NET 6
type: docs
weight: 235
url: /it/net/net6/
keywords:
- Supporto .NET 6
- Soluzione cloud
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Configura Aspose.Slides per .NET 6 per creare, modificare e convertire presentazioni PowerPoint PPT, PPTX e ODP in applicazioni C# moderne e multipiattaforma."
---
## **Introduzione**

Con l'introduzione di [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), è stato implementato il supporto per .NET6. La particolarità di questo supporto è che .NET6 non supporta più System.Drawing.Common per Linux ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) e Slides implementa questo sottosistema grafico internamente come componente C++.

Aspose.Slides per .NET ora funziona senza dipendenze da GDI/libgdiplus su:
* Windows
* Linux

Il supporto per _MacOS_ è in corso.

## **Utilizzare Slides per .NET 6 su AWS e Azure**

.NET6 è la versione consigliata per Aspose.Slides utilizzato nel cloud (AWS, Azure o altre soluzioni cloud).

In precedenza, quando Aspose.Slides veniva usato su un host Linux, era necessario installare dipendenze aggiuntive (libgdiplus) e ciò era spesso scomodo o poco pratico (ad esempio, quando si utilizza [AWS Lambda](https://aws.amazon.com/lambda)). Con Slides per .NET6, tali dipendenze non sono più necessarie, rendendo il deployment molto più semplice.

Un altro aspetto sono i problemi che si verificavano quando Aspose.Slides veniva utilizzato in una soluzione cloud con un host Windows. Ad esempio, [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) hanno limitazioni per il processo e causano problemi durante un'operazione di esportazione PDF (vedi [questo](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). L'utilizzo di Aspose.Slides per .NET6 risolve questo problema.

## **Utilizzare il pacchetto System.Drawing.Common e le classi Slides per .NET 6 (CS0433: Errore Tipo presente sia in Slides che in System.Drawing.Common)**

A volte, le dipendenze sia di System.Drawing sia di Slides per .NET6 devono essere utilizzate in un progetto (ad esempio, quando il progetto .NET6 dipende da altri pacchetti, i quali a loro volta dipendono da System.Drawing). Questo può provocare errori di complicazione come i seguenti:

* CS0433: The type 'Image' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0
* CS0433: The type 'Graphics' exists in both 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' and 'System.Drawing.Common, Version=6.0.0.0

In questo caso, è possibile utilizzare [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) per Aspose.Slides (versione inferiore a 24.8):
1) Selezionare l'assembly Aspose.Slides dalle dipendenze del progetto e poi fare clic su **Properties**.
  ![Proprietà del pacchetto Aspose Slides](package_properties.png)
2) Impostare un alias (ad esempio, "Slides").
  ![Alias Aspose Slides](set_alias.png)

Ora, i tipi da System.Drawing.Common verranno utilizzati per impostazione predefinita. L'alias dell'assembly esterno deve essere specificato dove sono necessari i tipi di Aspose.Slides.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Esempio completo:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

A partire dalla versione 24.8, l'API pubblica deprecata con dipendenze da System.Drawing è stata rimossa. Riguardo all'esempio di codice sopra, è possibile ottenere l'immagine della diapositiva come mostrato di seguito.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
La nuova API è descritta in dettaglio nella [API moderna](/slides/it/net/modern-api/).