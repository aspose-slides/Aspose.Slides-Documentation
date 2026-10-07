---
title: Aspose.Slides voor Android via Java
second_title: Aspose.Slides voor Android
type: docs
weight: 40
url: /nl/androidjava/
keywords:
- documentatie
- presentatieverwerking
- presentatieconversie
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Begin hier: voeg Aspose.Slides voor Android via Java toe aan je app, maak een eerste presentatie, en vind de handleidingen voor algemene taken, de API‑referentie en ondersteuning."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides voor Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides voor Android via Java is een classbibliotheek voor het maken, lezen, bewerken en converteren van PowerPoint- en OpenDocument‑presentaties in Android‑applicaties, zonder Microsoft PowerPoint.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ingeschakelde en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>EERSTE STAPPEN</p>
<ul>
<li><a href="/slides/nl/androidjava/install-aspose-slides-for-android-via-java/">Installatie</a></li>
<li><a href="/slides/nl/androidjava/create-presentation/">Maak je eerste presentatie</a></li>
<li><a href="/slides/nl/androidjava/getting-started/">Gids voor aan de slag</a></li>
</ul>
<p>EVALUEREN</p>
<ul>
<li><a href="/slides/nl/androidjava/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/androidjava/evaluate-aspose-slides/">Beperkingen van de proefversie</a></li>
<li><a href="/slides/nl/androidjava/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/androidjava/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/androidjava/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/androidjava/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/androidjava/convert-slide/">Render slides als afbeeldingen</a></li>
<li><a href="/slides/nl/androidjava/manage-text/">Bewerk tekst en vormen</a></li>
</ul>
<p>SLIDES-WERKSTROMEN</p>
<ul>
<li><a href="/slides/nl/androidjava/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/androidjava/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/androidjava/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/androidjava/presentation-design/">Slide‑ontwerp</a></li>
<li><a href="/slides/nl/androidjava/merge-presentation/">Presentaties samenvoegen</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/androidjava/examples/">Voorbeelden per slide‑element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Ondersteuning</b></p>
<hr>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API‑referentie</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Release‑notities</a></li>
<li><a href="/slides/nl/androidjava/known-issues/">Bekende problemen</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Productpagina</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Download</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteuningshelpdesk</a></li>
</ul>
</div>
</div>

------

## **Je eerste presentatie**

De bibliotheek komt uit de Maven‑repository van Aspose. Nieuwe Android‑Studio‑projecten hebben al een `dependencyResolutionManagement`‑blok in *settings.gradle.kts*. Voeg de onderstaande `maven`‑regel toe aan het `repositories`‑blok daarin, in plaats van een tweede blok te plakken:

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

Voeg vervolgens de bibliotheek toe aan *app/build.gradle.kts* en synchroniseer het project:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installatie](/slides/nl/androidjava/install-aspose-slides-for-android-via-java/) behandelt Groovy‑build‑scripts, het handmatige JAR‑bestand en hoe je een versie kiest. De code voor je eerste presentatie staat op [Maak presentaties](/slides/nl/androidjava/create-presentation/): deze voegt een tekstvak toe aan een slide en slaat de presentatie op in de opslag van je app. Die voorbeeld‑app is gecompileerd en gebouwd tot een APK; hij is niet uitgevoerd op een apparaat. Zonder licentie bevatten opgeslagen presentaties een evaluatiewatermerk — zie [Licenties](/slides/nl/androidjava/licensing/).