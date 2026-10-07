---
title: Aspose.Slides per Android tramite Java
second_title: Aspose.Slides per Android
type: docs
weight: 40
url: /it/androidjava/
keywords:
- documentazione
- elaborazione presentazioni
- conversione presentazioni
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Inizia qui: aggiungi Aspose.Slides per Android tramite Java alla tua app, crea una prima presentazione e trova le guide per le attività comuni, il riferimento API e il supporto."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides per Android tramite Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides per Android tramite Java è una libreria di classi per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument in applicazioni Android, senza Microsoft PowerPoint.

Carica e salva file PPT, PPTX, PPS, POT e ODP, incluse le varianti con macro e i modelli, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>INIZIO</p>
<ul>
<li><a href="/slides/it/androidjava/install-aspose-slides-for-android-via-java/">Installazione</a></li>
<li><a href="/slides/it/androidjava/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/androidjava/getting-started/">Guida per iniziare</a></li>
</ul>
<p>VALUTAZIONE</p>
<ul>
<li><a href="/slides/it/androidjava/supported-file-formats/">Formati file supportati</a></li>
<li><a href="/slides/it/androidjava/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/androidjava/licensing/">Licenza</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>ATTIVITÀ COMUNI</p>
<ul>
<li><a href="/slides/it/androidjava/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/androidjava/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/androidjava/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/androidjava/convert-slide/">Rendi le diapositive come immagini</a></li>
<li><a href="/slides/it/androidjava/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO SLIDES</p>
<ul>
<li><a href="/slides/it/androidjava/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/androidjava/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/androidjava/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/androidjava/presentation-design/">Progettazione diapositive</a></li>
<li><a href="/slides/it/androidjava/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/androidjava/examples/">Esempi per elemento della diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento &amp; Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/androidjava/known-issues/">Problemi noti</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Pagina del prodotto</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

## **La tua prima presentazione**

La libreria proviene dal repository Maven di Aspose. I nuovi progetti Android Studio hanno già un blocco `dependencyResolutionManagement` in *settings.gradle.kts*. Aggiungi la riga `maven` mostrata di seguito al blocco `repositories` al suo interno, invece di incollare un secondo blocco:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

Quindi aggiungi la libreria a *app/build.gradle.kts* e sincronizza il progetto:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installazione](/slides/it/androidjava/install-aspose-slides-for-android-via-java/) copre gli script di build Groovy, il file JAR manuale e come scegliere una versione. Il codice per la tua prima presentazione è disponibile su [Crea presentazioni](/slides/it/androidjava/create-presentation/): aggiunge una casella di testo a una diapositiva e salva la presentazione nella memoria dell'app. Questo esempio è stato compilato e costruito in un APK; non è stato eseguito su un dispositivo. Senza una licenza, le presentazioni salvate contengono un marchio d'acqua di valutazione — vedi [Licenza](/slides/it/androidjava/licensing/).