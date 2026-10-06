---
title: Requisiti di sistema
type: docs
weight: 60
url: /it/java/system-requirements/
keywords:
- requisiti di sistema
- piattaforme supportate
- versioni Java
- JDK
- JRE
- fontconfig
- font
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Verifica cosa richiede Aspose.Slides per Java prima di installarlo: le versioni Java supportate e i sistemi operativi, e la libreria di font e i font richiesti da Linux."
---
## **Introduzione**

Aspose.Slides for Java è una libreria autonoma: non necessita di Microsoft PowerPoint né di Microsoft Office. È un unico file JAR, pubblicato nel repository Maven di Aspose. Il file JAR contiene solo classi Java e risorse, senza librerie native, e non dichiara dipendenze da altre librerie. Lo stesso file quindi gira su ogni sistema operativo e processore per i quali è disponibile un runtime Java supportato.

Questo articolo elenca le versioni Java supportate e i sistemi operativi, nonché la libreria di font e i font di cui Linux ha bisogno, e termina con un breve programma che verifica la tua configurazione. Per aggiungere la libreria a un progetto, vedere [Installazione](/slides/it/java/installation/).

## **Versioni Java supportate**

Aspose.Slides for Java funziona su Java 8 o versioni successive, con un JDK o un JRE. Include le versioni a lungo termine Java 8, 11, 17, 21 e 25, nonché versioni successive come Java 26 e Java 27. Il runtime Java può provenire da qualsiasi fornitore, ad esempio Eclipse Temurin, Amazon Corretto, Oracle o i pacchetti OpenJDK di una distribuzione Linux.

Aspose.Slides non richiede opzioni JVM, come `--add-opens`, su nessuna di queste versioni. Su Java 11, la JVM stampa un avviso che inizia con "WARNING: An illegal reflective access operation has occurred"; l'avviso non influisce sul risultato.

{{% alert color="warning" title="Warning" %}}
Java 6 e Java 7 sono deprecati. Aspose.Slides for Java 26.9 funziona ancora su di essi ma stampa un avviso di deprecazione. A partire dalla versione 26.10, Java 8 è il minimo, e Java 6 e Java 7 non sono più supportati.
{{% /alert %}}

Il progetto Maven e i comandi in [Installazione](/slides/it/java/installation/) richiedono JDK 11 o versioni successive. Con Java 8, compila ed esegui il tuo programma come mostrato in [Controlla la tua configurazione](#check-your-setup).

## **Sistemi operativi supportati**

Poiché il file JAR non contiene codice nativo, Aspose.Slides for Java funziona su Windows, Linux e macOS, su qualsiasi architettura di processore supportata dal runtime Java, come x64 e ARM64. Il runtime Java è l'unico requisito su Windows. Su Linux, il supporto ai font di Java richiede anche la libreria di font e i font descritti in [Linux](#linux).

## **Linux**

Aspose.Slides for Java imposta e disegna il testo con il supporto ai font del runtime Java. Su Linux, tale supporto richiede la libreria fontconfig e almeno un font installato. Le immagini container ufficiali delle distribuzioni Linux spesso non hanno né l'una né l'altra. Senza di esse, il primo esempio in [Create Presentations](/slides/it/java/create-presentation/) fallisce quando salva la presentazione, lascia un file vuoto e segnala questo errore:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Le immagini container ufficiali `eclipse-temurin`, per Ubuntu e per Alpine Linux, contengono già fontconfig e i font DejaVu, quindi non è necessario installare nulla su di esse. Su altri sistemi, installa i pacchetti sotto. I comandi per Debian, Ubuntu e Red Hat usano `sudo`; in un Dockerfile, eseguili in un'istruzione `RUN` senza `sudo`. I font DejaVu sono sufficienti per far funzionare Aspose.Slides; i font utilizzati nelle tue presentazioni sono trattati in [Font](#fonts).

### **Debian e Ubuntu**

Se installi Java dai pacchetti Debian o Ubuntu con le impostazioni predefinite di `apt-get`, come fa il comando in [Installazione](/slides/it/java/installation/#linux), i pacchetti Java installano anche la libreria fontconfig, i font DejaVu e la libreria HarfBuzz necessaria a questi pacchetti Java, e non è richiesto nient'altro.

Con un runtime Java da un'altra fonte, come un archivio Eclipse Temurin, installa fontconfig e i font DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Un Dockerfile spesso installa i pacchetti Java Debian o Ubuntu, come `openjdk-21-jdk-headless` o `default-jdk-headless`, con l'opzione `--no-install-recommends`, che salta tutti e tre. Installa fontconfig e i font DejaVu con il comando sopra, e installa anche HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Senza HarfBuzz, questi pacchetti Java stampano `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, e il salvataggio fallisce con un `UnsatisfiedLinkError` che segnala che `libharfbuzz.so.0` non può essere aperto.

### **Red Hat Enterprise Linux**

I pacchetti `java-<version>-openjdk-headless` di Red Hat Enterprise Linux non installano la libreria fontconfig. Installala insieme ai font DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

I pacchetti completi `java-<version>-openjdk` installano fontconfig e font come dipendenze, così come i pacchetti Amazon Corretto di Amazon Linux 2023, ad esempio `java-21-amazon-corretto-headless`.

### **Alpine Linux**

In un Dockerfile basato su Alpine Linux, installa fontconfig e i font DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Nelle versioni attuali di Alpine, `ttf-dejavu` installa il pacchetto `font-dejavu`. Installa Java con il pacchetto `openjdk<version>-jre` o `openjdk<version>-jdk`, ad esempio `openjdk25-jdk`. I pacchetti `openjdk<version>-jre-headless` di Alpine Linux non contengono la libreria dei font di Java, quindi con essi il programma fallisce con `UnsatisfiedLinkError: no fontmanager in system library path`, anche se i font sono installati.

### **Font**

Affinché il testo venga renderizzato con i font e le metriche corrette, i font utilizzati nelle tue presentazioni, o sostituti adeguati, devono essere installati sul sistema o caricati dalla tua applicazione. Vedi [Deploy Fonts](/slides/it/java/deploy-fonts/), [Font Substitution](/slides/it/java/font-substitution/), e [Custom Fonts](/slides/it/java/custom-font/).

## **Verifica la tua configurazione**

Per verificare che la libreria e i suoi requisiti siano presenti, esegui un programma che salva una presentazione e rende una diapositiva in un'immagine. Il salvataggio e il rendering usano il supporto ai font del runtime Java, che è quanto forniscono i requisiti Linux sopra indicati.

Salva il codice sottostante come *CheckSetup.java* nella cartella che contiene il file JAR di Aspose.Slides. Per scaricare il file JAR, vedere [Use the JAR File without Maven](/slides/it/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Aggiungi un rettangolo con testo alla prima diapositiva e salva la presentazione.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Renderizza la diapositiva a un pixel per punto e salva l'immagine.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

Con JDK 11 o versioni successive, esegui il programma in quella cartella con il comando sotto. Se il tuo file JAR ha un nome diverso, modifica il nome nei comandi.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Con Java 8, o su un sistema che ha solo un JRE, compila il programma con `javac` da un JDK e poi esegui la classe compilata. Su Linux e macOS, esegui:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Su Windows, esegui lo stesso comando `javac`, e poi esegui la classe con un punto e virgola come separatore del percorso di classe. Mantieni le virgolette, così PowerShell non interpreta il punto e virgola come fine del comando: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Il programma aggiunge un rettangolo con testo alla prima diapositiva e salva la presentazione come *hello.pptx* con il metodo [save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Quindi rende la diapositiva con [getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getImage-float-float-) e salva il risultato come *hello.png* con [IImage.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/#save-java.lang.String-int-) nel formato [ImageFormat.Png](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/). I fattori di scala di 1 rendono un pixel per punto, così la diapositiva predefinita di 720 × 540 punti diventa un'immagine di 720 × 540 pixel, con il testo visibile all'interno del rettangolo. Senza licenza, entrambi i file includono anche una filigrana di valutazione; vedere [Licensing](/slides/it/java/licensing/). Se manca un requisito, il programma si interrompe con uno dei errori descritti in [Linux](#linux).

## **Strumenti di sviluppo**

Puoi creare applicazioni che utilizzano Aspose.Slides con qualsiasi JDK di una versione Java supportata. Usa Apache Maven con il repository Maven di Aspose, come descritto in [Installazione](/slides/it/java/installation/), o qualsiasi altro strumento di build che possa usare un repository Maven. Puoi anche aggiungere manualmente il file JAR al class path del tuo IDE o dello strumento di build.

## **FAQ**

**Devo avere Microsoft PowerPoint installato per le conversioni e il rendering?**

No, PowerPoint non è richiesto. Aspose.Slides è un motore autonomo per [creare](/slides/it/java/create-presentation/), modificare, [convertire](/slides/it/java/convert-presentation/), e [rendere](/slides/it/java/convert-powerpoint-to-png/) presentazioni.

**Aspose.Slides for Java ha bisogno di un display o di un ambiente desktop su un server Linux?**

No. Aspose.Slides non ha bisogno di un server X o di un display, quindi funziona su server e in container. Su Linux, ha bisogno solo della libreria di font e dei font descritti in [Linux](#linux).

**Quali font sono necessari per un rendering corretto?**

I font utilizzati nella presentazione, o i [sostituti](/slides/it/java/font-substitution/) adeguati, devono essere disponibili. Su Linux e macOS, installa i pacchetti di font di cui necessitano le tue presentazioni per ottenere un rendering coerente.

**Perché un font personalizzato viene renderizzato come fallback o testo mancante su Linux?**

Se il file del font contiene voci della tabella dei nomi incoerenti o corrotte, lo stack di corrispondenza dei font di Linux (FreeType/fontconfig) può selezionare un record non valido, causando il mancato riconoscimento del font. Usare una versione del font con voci della tabella dei nomi corrette o installare una sostituzione coerente risolve il problema.