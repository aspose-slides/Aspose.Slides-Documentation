---
title: Sicurezza
type: docs
weight: 160
url: /it/net/security/
keywords:
- sicurezza
- dipendenze
- componenti di terze parti
- NuGet
- scansione delle vulnerabilità
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esamina come Aspose.Slides per .NET elabora le presentazioni, quali pacchetti NuGet dipende per ogni framework di destinazione e quali componenti di terze parti include."
---
## **Sicurezza in Aspose.Slides**

Aspose applica le migliori pratiche quando sviluppa i suoi prodotti.

* Aspose.Slides per .NET è usato per manipolare le presentazioni e convertirle in altri formati. Non esegue script nelle presentazioni. Aspose.Slides analizza la struttura della presentazione e consente al codice dell'utente finale di manipolare il modello di oggetti in modo comodo.
* Aspose.Slides funziona come una libreria che analizza e interpreta i documenti senza eseguire codice remoto. Tutti i prodotti Aspose vengono eseguiti sui tuoi computer. Non trasmettono alcun dato ad Aspose. L'unica eccezione è una [licenza a consumo](https://purchase.aspose.com/faqs/licensing/metered): se ne utilizzi una, vengono elaborati solo i dati di utilizzo della tua API.
* I componenti Aspose vengono eseguiti nello stesso contesto utente delle applicazioni normali. Pertanto, i componenti Aspose non rappresentano un rischio per le risorse di sistema critiche. Inoltre, quando un componente Aspose apre un documento, le macro non vengono eseguite automaticamente.
* I rischi intrinseci o associati al pacchetto Microsoft Office non si applicano ai componenti Aspose, quindi i prodotti Aspose sono molto sicuri.

## **Dipendenze NuGet**

Aspose.Slides per .NET dipende da pacchetti che Microsoft pubblica su NuGet. Le dipendenze variano in base al pacchetto e al framework di destinazione:

| Pacchetto | Framework di destinazione | Dipendenze |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

La sezione **Dependencies** della pagina [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) e della pagina [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) su NuGet elenca la versione minima di ogni dipendenza per ogni rilascio.

Quando aggiungi Aspose.Slides a un progetto, NuGet ripristina anche le dipendenze di questi pacchetti. Per elencare tutti i pacchetti che il tuo progetto ripristina, incluse queste dipendenze transitive, esegui questo comando nella cartella del progetto:

```bash
dotnet list package --include-transitive
```

Per verificare lo stesso insieme di pacchetti rispetto a vulnerabilità note, esegui:

```bash
dotnet list package --vulnerable --include-transitive
```

Per altri modi di verificare i pacchetti NuGet, vedi [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Componenti di Terze Parti**

Aspose.Slides include codice proveniente da componenti open‑source di terze parti. Essi fanno parte del prodotto, non sono pacchetti NuGet separati, quindi gli strumenti che leggono solo le dipendenze NuGet non li elencano. Entrambi i pacchetti contengono il file *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, che elenca i componenti e le loro licenze:

| Componente | Licenza indicata nella nota |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**Quali sistemi vengono utilizzati per monitorare le vulnerabilità nel codice Aspose?**

Eseguiamo un'analisi statica del codice per ogni rilascio di Aspose.Slides. Possiamo fornire rapporti di sicurezza che dimostrano che il codice di Aspose.Slides rispetta i criteri OWASP Top 10.

**Aspose.Slides utilizza pacchetti esterni?**

Sì. Dipende dai pacchetti Microsoft NuGet elencati in [Dipendenze NuGet](#nuget-dependencies) e include i componenti di terze parti elencati in [Componenti di Terze Parti](#third-party-components). Includi entrambi nella tua revisione della sicurezza e usa `dotnet list package --vulnerable --include-transitive` per controllare i pacchetti NuGet che il tuo progetto ripristina.