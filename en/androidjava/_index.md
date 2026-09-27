---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /androidjava/
keywords:
- documentation
- presentation processing
- presentation conversion
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Start here: add Aspose.Slides for Android via Java to your app, create a first presentation, and find the guides for common tasks, the API reference and support."
is_root: true
---

<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java is a class library for creating, reading, editing and converting PowerPoint and OpenDocument presentations in Android applications, without Microsoft PowerPoint.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, SVG, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/androidjava/install-aspose-slides-for-android-via-java/">Installation</a></li>
<li><a href="/slides/androidjava/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/androidjava/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/androidjava/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/androidjava/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/androidjava/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/androidjava/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/androidjava/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/androidjava/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/androidjava/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/androidjava/manage-text/">Edit text and shapes</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/androidjava/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/androidjava/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/androidjava/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/androidjava/presentation-design/">Slide design</a></li>
<li><a href="/slides/androidjava/merge-presentation/">Merge presentations</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/androidjava/examples/">Examples by slide element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Release notes</a></li>
<li><a href="/slides/androidjava/known-issues/">Known issues</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

## **Your first presentation**

The library comes from Aspose's Maven repository. New Android Studio projects already have a `dependencyResolutionManagement` block in *settings.gradle.kts*. Add the `maven` line shown below to the `repositories` block inside it, rather than pasting a second block:

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

Then add the library to *app/build.gradle.kts* and sync the project:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/androidjava/install-aspose-slides-for-android-via-java/) covers Groovy build scripts, the manual JAR file, and how to choose a version. The code for your first presentation is on [Create Presentations](/slides/androidjava/create-presentation/): it adds a text box to a slide and saves the presentation to your app's storage. That sample has been compiled and built into an APK; it has not been run on a device. Without a license, saved presentations carry an evaluation watermark — see [Licensing](/slides/androidjava/licensing/).
