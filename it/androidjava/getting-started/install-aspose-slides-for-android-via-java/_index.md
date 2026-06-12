---
title: Installare Aspose.Slides per Android via Java
type: docs
weight: 90
url: /it/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- usare Aspose.Slides
- installazione di Aspose.Slides
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Installa rapidamente Aspose.Slides per Android. Guida passo-passo, requisiti di sistema e esempi di codice Java -- inizia a lavorare con le presentazioni PowerPoint oggi!"
---
## **Panoramica**

Questo articolo spiega come installare Aspose.Slides for Android via Java e aggiungerlo a un progetto Android. Descrive due opzioni di installazione: aggiungere manualmente il file JAR di Aspose.Slides al progetto e installare la libreria dal repository Maven.

L'articolo fornisce anche un esempio passo‑passo che mostra come creare una nuova applicazione Android in Android Studio, fare riferimento alla libreria Aspose.Slides, creare una presentazione PowerPoint programmaticamente e salvarla nel formato PPTX. Include inoltre note sul versionamento e risponde a domande comuni su come verificare l'integrazione, gestire l'utilizzo della memoria e ridurre la dimensione finale del JAR.

## **Installazione**
In precedenza, Aspose.Slides for Android via Java era distribuito come un unico file ZIP contenente il file JAR, le demo e la documentazione del prodotto. 

1. Se desideri utilizzare una versione precedente a Aspose.Words for Android via Java 18.9, devi estrarre la versione di Aspose.Slides.Android.zip nella directory che preferisci. 
1. Aggiungi il file Jar estratto nella tua applicazione usando la configurazione Build Path. 

### **Aggiungere un riferimento a Aspose.Slides for Android via Java Jar**
1. Scarica la versione più recente di [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/it/androidjava)
1. Copia aspose-slides-18.9-android.via.java.jar nella cartella *libs/* del tuo progetto

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

### **Installare Aspose.Slides for Android via Java dal repository Maven**
1. Aggiungi il repository Maven nel tuo file build.gradle. 
1. Aggiungi [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR come dipendenza.

``` java

 // 1. Aggiungi il repository Maven nel tuo build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Aggiungi il JAR 'Aspose.Slides for Android via Java' come dipendenza

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **La tua prima applicazione con Aspose.Slides for Android via Java**
In questa sezione imparerai come iniziare con Aspose.Slides for Android via Java. Ti mostreremo come configurare un nuovo progetto Android da zero, aggiungere un riferimento al JAR di Aspose.Slides e creare una nuova presentazione PowerPoint che viene salvata sul disco nel formato PPTX. L'esempio utilizza [Android Studio](https://developer.android.com/studio/index.html) per lo sviluppo e l'applicazione viene eseguita sull'Emulatore Android. Per iniziare con Aspose.Slides for Android via Java, segui questo tutorial passo‑passo per creare un'app che utilizza Aspose.Slides for Android via Java:

1. Scarica e installa [Android Studio](https://developer.android.com/studio/index.html) in una posizione a tua scelta.
1. Avvia Android Studio.
1. Crea un nuovo progetto di applicazione Android.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)

1. Copia aspose-slides-XX.XX-android.via.java.jar nella cartella libs del tuo progetto

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)

1. Seleziona la sezione Project (dal menu File) e fai clic sulla scheda Dependencies.  
   1. Fai clic sul pulsante “+”. Seleziona l'opzione file dependency.  
   1. Seleziona la libreria Aspose.Slides dalla cartella libs e fai clic su OK.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)

1. Sincronizza il progetto con i file Gradle se necessario. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)

1. Per accedere alla SDcard, è necessario aggiungere permessi speciali. Apri il file AndroidManifest.xml e scegli la vista XML. Aggiungi questa riga al file `<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />`

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)

1. Torna alla sezione codice dell'app e aggiungi questi import: 

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment;

```

Ora inserisci questo codice nel corpo del metodo onCreate per creare una nuova Presentation da zero usando Aspose.Slides e salvarla sulla SDCard in formato PPTX.

``` java

 try

{

    // Istanziare la classe Presentation che rappresenta un PPTX
    Presentation pres = new Presentation();



    // Accedere alla prima slide
    ISlide sld = pres.getSlides().get_Item(0);



    // Aggiungere un AutoShape di tipo Rettangolo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Aggiungere TextFrame al rettangolo
    ashp.addTextFrame(" ");



    // Accedere al TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();



    // Creare l'oggetto Paragraph per il TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Creare l'oggetto Portion per il paragrafo
    IPortion portion = para.getPortions().get_Item(0);



    // Impostare il testo
    portion.setText("Aspose TextBox");



    // Salvare il PPTX sulla scheda
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}

catch (Exception e)

{
   e.printStackTrace();
}
```

Il codice completo dovrebbe apparire così:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)

1. Ora esegui nuovamente l'applicazione. Questa volta il codice Aspose.Slides verrà eseguito in background e genererà un documento salvato sulla SDcard.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Per visualizzare il documento creato, vai al menu Tools. Scegli Android e poi Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)

## **Versionamento**
Dal 2018, il versionamento di Aspose.Slides for Android via Java è allineato a quello di Aspose.Slides for Java. 

## **FAQ**

**Come posso verificare che Aspose.Slides sia integrato correttamente?**

Compila il tuo progetto, istanzia una presentazione vuota [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e salvala con un nuovo nome. Se il file viene creato senza eccezioni, la libreria è stata integrata con successo.

**Come posso limitare il consumo di memoria durante l'elaborazione di presentazioni di grandi dimensioni?**

Aumenta i limiti di memoria JVM solo quanto necessario e chiudi ogni istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) in un blocco `finally` per rilasciare la cache tempestivamente. Questo evita errori di out‑of‑memory e mantiene prevedibile l'utilizzo complessivo della memoria durante operazioni batch.

**Posso escludere formati di esportazione indesiderati per ridurre la dimensione finale del JAR?**

Le versioni attuali di Aspose.Slides sono distribuite come una singola libreria monolitica, quindi non è possibile disabilitare esportatori specifici come PDF o SVG al momento della compilazione.