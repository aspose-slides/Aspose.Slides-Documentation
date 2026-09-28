---
title: Requisiti del livello di fiducia
type: docs
weight: 190
url: /it/net/declaration/
keywords:
- livello di fiducia
- permesso Full Trust
- trust parziale
- Medium Trust
- sicurezza di accesso al codice
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Quale livello di fiducia della sicurezza di accesso al codice richiede Aspose.Slides per .NET: piena fiducia su .NET Framework e nessuna impostazione di fiducia su .NET 6 e versioni successive."
---
## **Panoramica**

I livelli di fiducia della Code Access Security (CAS) esistono solo in .NET Framework. Questo articolo spiega cosa significano per Aspose.Slides per .NET: la libreria richiede piena fiducia su .NET Framework, e su .NET 6 e versioni successive non esiste alcun livello di fiducia da configurare.

## **.NET Framework**

Aspose.Slides richiede piena fiducia su .NET Framework. Non funziona in modalità di fiducia parziale, ad esempio un'applicazione ASP.NET configurata per Medium Trust (`<trust level="Medium" />`): la creazione di un oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) fallisce con una `SecurityException`.

Microsoft non considera più la partial trust di ASP.NET un modo per isolare le applicazioni tra loro, e raccomanda di eseguire le applicazioni in pool di applicazioni separati. See [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 e versioni successive**

La Code Access Security non è disponibile su .NET 6 e versioni successive, quindi non esiste alcun livello di fiducia da concedere. Aspose.Slides viene eseguito con i permessi dell'account che esegue la tua applicazione. Per limitare ciò a cui un'applicazione può accedere, Microsoft raccomanda limiti a livello di sistema operativo, come account utente, container o macchine virtuali. See [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **FAQ**

**Posso usare Aspose.Slides con un provider di hosting che esegue applicazioni ASP.NET in Medium Trust?**

Non in Medium Trust. Su .NET Framework, l'applicazione che utilizza Aspose.Slides deve essere eseguita con piena fiducia.