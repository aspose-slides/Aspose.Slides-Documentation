---
title: Requisiti del Security Manager
type: docs
weight: 190
url: /it/java/declaration/
keywords:
- Gestore di sicurezza
- politica di sicurezza
- AllPermission
- permessi
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Quali permessi del Security Manager richiedono Aspose.Slides per Java e il codice che lo chiama su Java 23 e versioni precedenti, e perché non c'è nulla da configurare su Java 24 e versioni successive."
---
## **Panoramica**

Il Java Security Manager limita ciò che il codice può fare in base a una politica di sicurezza. Java 17 lo ha deprecato per la rimozione ([JEP 411](https://openjdk.org/jeps/411)), e Java 24 lo ha disabilitato permanentemente ([JEP 486](https://openjdk.org/jeps/486)). Questo articolo spiega cosa richiede Aspose.Slides per Java quando un'applicazione continua a funzionare con un Security Manager. Se la tua applicazione non ne abilita uno, che è l'impostazione predefinita, non c'è nulla da configurare.

## **Java 23 e versioni precedenti**

Quando un Security Manager è abilitato, la politica di sicurezza deve concedere questi permessi al file JAR di Aspose.Slides e al codice dell'applicazione che lo chiama:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides legge le proprietà di sistema.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides legge i file dei font e altri file.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides avvia programmi del sistema operativo, ad esempio `reg` su Windows e `fc-match` su Linux.
- `java.io.FilePermission` con l'azione `write` per le cartelle in cui la tua applicazione salva i file.

Concedere i permessi solo al file JAR non è sufficiente: anche il codice che chiama Aspose.Slides ha bisogno di questi permessi. Concedere `java.security.AllPermission` a entrambi funziona comunque.

Senza il permesso di leggere le proprietà di sistema o di avviare programmi, Aspose.Slides fallisce al primo utilizzo: la creazione di un [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) genera un `ExceptionInInitializerError`. Senza accesso in lettura ai file dei font, il salvataggio di una presentazione in PDF fallisce con l'errore "Cannot find any fonts installed on the system".

## **Java 24 e versioni successive**

Il Security Manager non può essere abilitato su Java 24 e versioni successive, quindi non ci sono permessi da concedere. Aspose.Slides viene eseguito con i permessi dell'account che esegue la tua applicazione. Per limitare ciò a cui un'applicazione può accedere, il progetto OpenJDK raccomanda tecnologie al di fuori del JDK, come container, hypervisor e funzionalità di sandbox del sistema operativo. Vedi [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Posso usare Aspose.Slides in un ambiente che esegue applicazioni con una politica restrittiva di Security Manager?**

Solo se la politica concede i permessi elencati sopra sia ad Aspose.Slides sia al codice che lo chiama. Questi includono la lettura di tutti i file e l'avvio di qualsiasi programma.