---
title: Aspose.Slides per .NET 6 multipiattaforma (pacchetto ZIP)
type: docs
weight: 237
url: /it/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- multipiattaforma
- .NET 6
- GLIBC
- csproj
- percorso di destinazione
- libreria dipendente
- Aspose.Slides.dll
- System.Drawing.Common
- conflitto di nome
- alias esterno
- CS0433
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Utilizza Aspose.Slides per .NET 6 per creare applicazioni C# multipiattaforma su Windows, Linux e macOS che creano, modificano e convertono file PowerPoint PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega come utilizzare Aspose.Slides per .NET 6 Cross-Platform da un pacchetto ZIP. Descrive come scaricare il pacchetto, estrarre i file dalla cartella `net6.0/crossplatform`, aggiungere un riferimento a `Aspose.Slides.dll` e configurare il file di progetto affinché le librerie dipendenti richieste vengano copiate nella directory di output dell’applicazione.

L’articolo descrive inoltre il contenuto del pacchetto cross‑platform, inclusi l’assembly principale di Aspose.Slides per .NET e le librerie del sottosistema grafico specifiche per piattaforma per Windows, Linux e macOS.

{{% alert title="Nota" color="primary" %}}

Aspose.Slides per .NET 6 Cross-Platform è disponibile anche su [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Utilizzare Aspose.Slides Cross‑Platform da un pacchetto ZIP**

1. Scaricare il pacchetto ZIP dell’ultima versione di Aspose.Slides dalla [Release Page](https://releases.aspose.com/slides/it/net/).

2. Estrarre i file da *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* e posizionarli nella cartella che verrà usata per le dipendenze nel progetto.

3. Aggiungere un riferimento a Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   Nel nostro esempio (sotto), le librerie si trovano nella cartella del progetto al percorso: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Posizionare i file rimanenti (di cui Aspose.Slides ha bisogno) nella directory di output aggiungendo le istruzioni al file csproj del progetto in questo modo:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Prestare attenzione a `TargetPath`.

   Per impostazione predefinita, `<CopyToOutputDirectory>` copia i file preservando il percorso relativo, ma è necessario che le librerie dipendenti vadano nella stessa cartella in cui viene generato l’output (posizione di Aspose.Slides.dll).

## **Note**

### **Subsystem di grafica proprietario**

Aspose.Slides cross‑platform è una raccolta di librerie:

| Aspose.Slides.dll                                          | Assembly .NET principale responsabile di tutta la logica di Aspose.Slides |
| ---------------------------------------------------------- | --------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Dipendenza: implementazione del sottosistema grafico per Win x64           |
| aspose.slides.drawing.capi_vc14x86.dll                     | Dipendenza: implementazione del sottosistema grafico per Win x86           |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Dipendenza: implementazione del sottosistema grafico per Linux (x86/x64)   |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Dipendenza: implementazione del sottosistema grafico per macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Dipendenza: implementazione del sottosistema grafico per macOS ARM64 (AArch64) |

Aspose.Slides.dll utilizza la libreria richiesta dal sistema su cui viene eseguito. Le librerie si trovano solitamente nella stessa posizione di Aspose.Slides.dll in qualsiasi file system.

### **Struttura del pacchetto ZIP**

Il pacchetto ZIP contiene la seguente struttura di cartelle:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Ogni cartella contiene gli assembly per la rispettiva versione .NET. Per net6.0 esistono due versioni: default e crossplatform. Quest’ultima contiene Aspose.Slides.dll cross‑platform e tutte le sue dipendenze. Il contenuto estratto di questa cartella può essere usato come aggiunta di dipendenza in un progetto per sviluppo cross‑platform e per altri scenari di utilizzo di Aspose.Slides.

## **Vedi anche**

- [Requisiti di sistema](/slides/it/net/system-requirements/)