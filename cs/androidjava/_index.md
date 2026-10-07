---
title: Aspose.Slides pro Android pomocí Javy
second_title: Aspose.Slides pro Android
type: docs
weight: 40
url: /cs/androidjava/
keywords:
- dokumentace
- zpracování prezentací
- konverze prezentací
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Začněte zde: přidejte Aspose.Slides pro Android pomocí Javy do své aplikace, vytvořte první prezentaci a najděte průvodce pro běžné úkoly, referenční API a podporu."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java je knihovna tříd pro vytváření, čtení, úpravu a převod prezentací PowerPoint a OpenDocument v Android aplikacích, bez Microsoft PowerPoint.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablonami, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>Začínáme</p>
<ul>
<li><a href="/slides/cs/androidjava/install-aspose-slides-for-android-via-java/">Instalace</a></li>
<li><a href="/slides/cs/androidjava/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/androidjava/getting-started/">Průvodce pro začátek</a></li>
</ul>
<p>EVALUACE</p>
<ul>
<li><a href="/slides/cs/androidjava/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/androidjava/evaluate-aspose-slides/">Omezení trial verze</a></li>
<li><a href="/slides/cs/androidjava/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvářejte s Slides</b></p>
<hr>
<p>OBECNÉ ÚKOLY</p>
<ul>
<li><a href="/slides/cs/androidjava/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/androidjava/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/androidjava/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/androidjava/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/androidjava/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>WORKFLOWY SLIDES</p>
<ul>
<li><a href="/slides/cs/androidjava/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/androidjava/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/androidjava/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/androidjava/presentation-design/">Návrh snímků</a></li>
<li><a href="/slides/cs/androidjava/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/androidjava/examples/">Příklady podle prvku snímku</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference a podpora</b></p>
<hr>
<p>REFERENČNÍ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Reference API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/androidjava/known-issues/">Známé problémy</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">Produktová stránka</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Stáhnout</a></li>
</ul>
<p>PODPORA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Fórum zdarma</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora helpdesk</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Knihovna pochází z Maven repozitáře společnosti Aspose. Nové projekty Android Studio již mají blok `dependencyResolutionManagement` v *settings.gradle.kts*. Přidejte řádek `maven` uvedený níže do bloku `repositories` uvnitř něj, místo vkládání druhého bloku:

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

Poté přidejte knihovnu do *app/build.gradle.kts* a synchronizujte projekt:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Instalace](/slides/cs/androidjava/install-aspose-slides-for-android-via-java/) pokrývá skripty Groovy, ruční JAR soubor a jak vybrat verzi. Kód vaší první prezentace je na [Vytvořit prezentace](/slides/cs/androidjava/create-presentation/): přidá textové pole na snímek a uloží prezentaci do úložiště vaší aplikace. Tento ukázkový kód byl zkompilován a vytvořen jako APK; nebyl spuštěn na zařízení. Bez licence mají uložené prezentace vodoznak pro hodnocení — viz [Licencování](/slides/cs/androidjava/licensing/).