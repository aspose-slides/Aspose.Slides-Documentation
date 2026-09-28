---
title: Aspose.Slides für Android über Java
second_title: Aspose.Slides für Android
type: docs
weight: 40
url: /de/androidjava/
keywords:
- Dokumentation
- Präsentationsverarbeitung
- Präsentationskonvertierung
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Beginnen Sie hier: Fügen Sie Aspose.Slides für Android über Java zu Ihrer App hinzu, erstellen Sie eine erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, die API-Referenz und den Support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides für Android über Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android über Java ist eine Klassenbibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint- und OpenDocument-Präsentationen in Android-Anwendungen, ohne Microsoft PowerPoint.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makrofähiger und Vorlagenvarianten, und exportiert in PDF, XPS, HTML, SVG, TIFF, Markdown und Bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>ERSTE SCHRITTE</p>
<ul>
<li><a href="/slides/de/androidjava/install-aspose-slides-for-android-via-java/">Installation</a></li>
<li><a href="/slides/de/androidjava/create-presentation/">Erstellen Sie Ihre erste Präsentation</a></li>
<li><a href="/slides/de/androidjava/getting-started/">Einsteigerleitfaden</a></li>
</ul>
<p>BEWERTEN</p>
<ul>
<li><a href="/slides/de/androidjava/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/androidjava/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/androidjava/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Entwicklung mit Slides</b></p>
<hr>
<p>ALLGEMEINE AUFGABEN</p>
<ul>
<li><a href="/slides/de/androidjava/open-presentation/">Eine Präsentation öffnen</a></li>
<li><a href="/slides/de/androidjava/save-presentation/">Eine Präsentation speichern</a></li>
<li><a href="/slides/de/androidjava/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/androidjava/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/androidjava/manage-text/">Text und Formen bearbeiten</a></li>
</ul>
<p>SLIDES-ARBEITSABLÄUFE</p>
<ul>
<li><a href="/slides/de/androidjava/powerpoint-charts/">Diagramme</a></li>
<li><a href="/slides/de/androidjava/powerpoint-animation/">Animationen</a></li>
<li><a href="/slides/de/androidjava/manage-media-files/">Audio und Video</a></li>
<li><a href="/slides/de/androidjava/presentation-design/">Foliengestaltung</a></li>
<li><a href="/slides/de/androidjava/merge-presentation/">Präsentationen zusammenführen</a></li>
</ul>
<p>BEISPIELE</p>
<ul>
<li><a href="/slides/de/androidjava/examples/">Beispiele nach Folienelement</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API-Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Versionshinweise</a></li>
<li><a href="/slides/de/androidjava/known-issues/">Bekannte Probleme</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Kostenloses Support-Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support-Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihre erste Präsentation**

Die Bibliothek stammt aus dem Maven-Repository von Aspose. Neue Android‑Studio‑Projekte enthalten bereits einen `dependencyResolutionManagement`‑Block in *settings.gradle.kts*. Fügen Sie die unten gezeigte `maven`‑Zeile zum `repositories`‑Block innerhalb dieses Blocks hinzu, anstatt einen zweiten Block einzufügen:

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

Fügen Sie dann die Bibliothek zu *app/build.gradle.kts* hinzu und synchronisieren Sie das Projekt:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

Die [Installation](/slides/de/androidjava/install-aspose-slides-for-android-via-java/) behandelt Groovy-Build‑Skripte, die manuelle JAR‑Datei und die Auswahl einer Version. Der Code für Ihre erste Präsentation finden Sie unter [Create Presentations](/slides/de/androidjava/create-presentation/): Er fügt einer Folie ein Textfeld hinzu und speichert die Präsentation im Speicher Ihrer App. Dieses Beispiel wurde kompiliert und in ein APK gepackt; es wurde nicht auf einem Gerät ausgeführt. Ohne Lizenz erhalten gespeicherte Präsentationen ein Evaluationswasserzeichen – siehe [Licensing](/slides/de/androidjava/licensing/).