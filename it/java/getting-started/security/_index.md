---
title: Sicurezza
type: docs
weight: 160
url: /it/java/security/
keywords:
- sicurezza
- dipendenze
- componenti di terze parti
- Maven
- firma JAR
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esamina come Aspose.Slides per Java elabora le presentazioni, cosa aggiunge alle dipendenze del tuo progetto, come verificare il file JAR e quali componenti di terze parti include."
---
## **Introduzione**

Questo articolo raccoglie le informazioni che una revisione della sicurezza di un'applicazione che utilizza Aspose.Slides for Java solitamente richiede: come la libreria elabora le presentazioni, cosa aggiunge alle dipendenze del tuo progetto, come verificare che il file JAR provenga da Aspose e quali componenti di terze parti contiene il file JAR.

## **Sicurezza in Aspose.Slides**

* Aspose.Slides for Java viene utilizzato per creare, modificare e convertire le presentazioni. Non esegue script nelle presentazioni. Aspose.Slides analizza la struttura della presentazione e consente al tuo codice di lavorare con il modello di oggetti.
* Aspose.Slides funziona come una libreria che analizza e interpreta i documenti senza eseguire codice remoto. Tutti i prodotti Aspose vengono eseguiti sulle tue macchine. Non trasmettono alcun dato ad Aspose. L'unica eccezione è [metered licensing](/slides/it/java/metered-licensing/): se lo utilizzi, vengono elaborati solo i dati di utilizzo della tua API.
* I componenti Aspose vengono eseguiti nello stesso contesto utente delle applicazioni normali. Pertanto, i componenti Aspose non rappresentano un rischio per le risorse di sistema vitali. Inoltre, quando un componente Aspose apre un documento, le macro non vengono eseguite automaticamente.

## **Dipendenze Maven**

L'artefatto Maven di Aspose.Slides for Java, `com.aspose:aspose-slides`, non dichiara dipendenze: il suo file POM contiene solo le coordinate dell'artefatto stesso. Quando lo aggiungi a un progetto, Maven aggiunge questo unico file JAR e nient'altro. Per elencare tutti gli artefatti risolti dal tuo progetto, incluse le dipendenze transitive, esegui questo comando nella cartella del progetto:

```bash
mvn dependency:tree
```

Nel progetto di [Installation](/slides/it/java/installation/), l'output elenca Aspose.Slides come unica dipendenza:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Verifica del file JAR**

Aspose firma il file JAR. Per verificare la firma, esegui lo strumento `jarsigner` fornito dal JDK nella cartella che contiene il file JAR:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

Il comando stampa `jar verified.` quando la firma è valida e nessuna voce è stata modificata dal momento della firma del file. Questo messaggio non indica il firmatario. Per confermare che Aspose abbia firmato il file, aggiungi le opzioni `-verbose` e `-certs` e verifica che il certificato del firmatario sia rilasciato a `CN=ASPOSE PTY LTD`. Quando Maven scarica il file JAR, controlla anche il checksum SHA-1 pubblicato dal repository accanto al file.

## **Componenti di terze parti**

Aspose.Slides for Java include codice e dati provenienti da componenti di terze parti. Sono parte del file JAR, non artefatti Maven separati, quindi `mvn dependency:tree` e altri strumenti che leggono le dipendenze Maven non li elencano. Il file JAR contiene l'avviso *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, che elenca i componenti e le loro licenze:

| Componente | Licenza indicata nell'avviso |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | licenza in stile MIT |
| Mono | licenza MIT; alcune parti sotto altre licenze elencate nell'avviso |
| RSWOP.ICM color profile | termini di licenza Microsoft |
| sRGB_v4_ICC_preference.icc color profile | autorizzazione ICC a usare, copiare e distribuire il file invariato |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Per estrarre l'avviso dal file JAR, esegui lo strumento `jar` fornito dal JDK nella cartella che contiene il file JAR:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Aspose.Slides for Java utilizza pacchetti esterni?**

Non ha dipendenze Maven, come mostrato in [Maven Dependencies](#maven-dependencies), ma include i componenti di terze parti elencati in [Third-Party Components](#third-party-components). Includi sia il file JAR sia questi componenti nella tua revisione della sicurezza.

**Aspose.Slides for Java richiede accesso di rete?**

No. Creare, salvare ed eseguire il rendering delle presentazioni funziona su un sistema senza alcuna connessione di rete. L'unica funzionalità che invia dati ad Aspose è [metered licensing](/slides/it/java/metered-licensing/), che riporta l'utilizzo dell'API.

**Aspose.Slides for Java contiene codice nativo?**

No. Il file JAR contiene solo classi Java e risorse, quindi non aggiunge librerie native alla tua applicazione. Su Linux, il supporto dei font del runtime Java richiede la libreria fontconfig e i font del sistema operativo; vedi [System Requirements](/slides/it/java/system-requirements/#linux).