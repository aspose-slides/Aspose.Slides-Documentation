---
title: Aspose.Slides per Android via Java
second_title: Aspose.Slides per Android
type: docs
weight: 40
url: /it/androidjava/
keywords:
- documentazione
- elaborazione di presentazioni
- conversione di presentazioni
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Inizia qui: aggiungi Aspose.Slides per Android via Java alla tua app, crea una prima presentazione e trova le guide per attività comuni, la referenza API e il supporto."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides per Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java è una libreria di classi per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument nelle applicazioni Android, senza Microsoft PowerPoint.

Carica e salva file PPT, PPTX, PPS, POT e ODP, incluse le varianti con macro e i modelli, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>INIZIARE</p>
<ul>
<li><a href="/slides/it/androidjava/install-aspose-slides-for-android-via-java/">Installazione</a></li>
<li><a href="/slides/it/androidjava/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/androidjava/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTAZIONE</p>
<ul>
<li><a href="/slides/it/androidjava/supported-file-formats/">Formati di file supportati</a></li>
<li><a href="/slides/it/androidjava/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/androidjava/licensing/">Licenze</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>COMPITI COMUNI</p>
<ul>
<li><a href="/slides/it/androidjava/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/androidjava/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/androidjava/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/androidjava/convert-slide/">Renderizza le diapositive come immagini</a></li>
<li><a href="/slides/it/androidjava/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO SLIDES</p>
<ul>
<li><a href="/slides/it/androidjava/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/androidjava/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/androidjava/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/androidjava/presentation-design/">Design delle diapositive</a></li>
<li><a href="/slides/it/androidjava/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/androidjava/examples/">Esempi per elemento della diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento e Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/androidjava/known-issues/">Problemi noti</a></li>
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

[Installazione](/slides/it/androidjava/install-aspose-slides-for-android-via-java/) copre gli script di build Groovy, il file JAR manuale e come scegliere una versione. Il codice per la tua prima presentazione si trova su [Crea presentazioni](/slides/it/androidjava/create-presentation/): aggiunge una casella di testo a una diapositiva e salva la presentazione nella memoria della tua app. Questo esempio è stato compilato e costruito in un APK; non è stato eseguito su un dispositivo. Senza licenza, le presentazioni salvate presentano una filigrana di valutazione — vedi [Licenza](/slides/it/androidjava/licensing/).