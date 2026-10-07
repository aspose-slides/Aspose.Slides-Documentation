---
title: Aspose.Slides för Android via Java
second_title: Aspose.Slides för Android
type: docs
weight: 40
url: /sv/androidjava/
keywords:
- dokumentation
- presentationsbehandling
- presentationskonvertering
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Börja här: lägg till Aspose.Slides för Android via Java i din app, skapa en första presentation och hitta guiderna för vanliga uppgifter, API-referensen och supporten."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java är ett klassbibliotek för att skapa, läsa, redigera och konvertera PowerPoint- och OpenDocument-presentationer i Android-applikationer, utan Microsoft PowerPoint.

Det laddar och sparar PPT, PPTX, PPS, POT och ODP, inklusive makroaktiverade och mallvarianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>Kom igång</p>
<ul>
<li><a href="/slides/sv/androidjava/install-aspose-slides-for-android-via-java/">Installation</a></li>
<li><a href="/slides/sv/androidjava/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/androidjava/getting-started/">Kom igång-guide</a></li>
</ul>
<p>Utvärdera</p>
<ul>
<li><a href="/slides/sv/androidjava/supported-file-formats/">Filformat som stöds</a></li>
<li><a href="/slides/sv/androidjava/evaluate-aspose-slides/">Begränsningar för provversionen</a></li>
<li><a href="/slides/sv/androidjava/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>Vanliga uppgifter</p>
<ul>
<li><a href="/slides/sv/androidjava/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/androidjava/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/androidjava/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/androidjava/convert-slide/">Rendera bildspel som bilder</a></li>
<li><a href="/slides/sv/androidjava/manage-text/">Redigera text och former</a></li>
</ul>
<p>Slides-arbetsflöden</p>
<ul>
<li><a href="/slides/sv/androidjava/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/androidjava/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/androidjava/manage-media-files/">Audio och video</a></li>
<li><a href="/slides/sv/androidjava/presentation-design/">Design av bildspel</a></li>
<li><a href="/slides/sv/androidjava/merge-presentation/">Slå ihop presentationer</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/androidjava/examples/">Exempel per bildelement</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API‑referens</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Versionsnoteringar</a></li>
<li><a href="/slides/sv/androidjava/known-issues/">Kända problem</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Produktsida</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Nedladdning</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald supporthelpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första presentation**

Biblioteket hämtas från Asposes Maven‑arkiv. Nya Android Studio‑projekt har redan ett `dependencyResolutionManagement`‑block i *settings.gradle.kts*. Lägg till `maven`‑raden som visas nedan i `repositories`‑blocket i det, istället för att klistra in ett andra block:

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

Lägg sedan till biblioteket i *app/build.gradle.kts* och synkronisera projektet:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/sv/androidjava/install-aspose-slides-for-android-via-java/) täcker Groovy‑byggskript, den manuella JAR‑filen och hur du väljer en version. Koden för din första presentation finns på [Create Presentations](/slides/sv/androidjava/create-presentation/): den lägger till en textruta på en bild och sparar presentationen i din apps lagring. Det exemplet har kompilerats och byggts till en APK; det har inte körts på en enhet. Utan licens har sparade presentationer ett utvärderingsvattenstämpel — se [Licensing](/slides/sv/androidjava/licensing/).